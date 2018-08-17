Public Class frmSclParametroGrupoPago

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    'Dim XdtEstados As BOSistema.Win.XDataSet.xDataTable
    'Dim XdtPertenece As BOSistema.Win.XDataSet.xDataTable
    Dim Strsql As String

    Dim IntPermiteConsultar As Integer
    'Dim IntPermiteEditar As Integer
    Dim IntDepartamento As Integer

    'Listado de Reportes
    Public Enum EnumReportes
        rptSclListGrupoPago = 1
        rptSclListGrupoPagoCoordinador = 2
        rptSclListGrupoPagoBarrio = 3
        rptSclListGrupoPagoDistNumerica = 4
        rptSclPagosPlaneadosVSEfectuados = 5
        rptSclNoPagos = 6 ' CS45
        rptSclListGrupoMoroso = 7 'Cs59
        rptSclTotalGruposMorosos = 8 'Cs60
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
            XdsCombos = New BOSistema.Win.XDataSet
            Me.cboMunicipio.Enabled = False
            Me.cboDistrito.Enabled = False
            Me.cboLugarPago.Enabled = False
            'XdtPertenece = New BOSistema.Win.XDataSet.xDataTable
            'XdtEstados = New BOSistema.Win.XDataSet.xDataTable

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptSclListGrupoPago
                    Me.Text = "Parámetros Listado de Pagos"
                Case EnumReportes.rptSclListGrupoMoroso
                    Me.dFechaInicial.Enabled = True
                    Me.dFechaFinal.Enabled = True
            End Select

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
    ' Procedure Name:       CargarLugarPago
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarLugarPago(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql, CadWhere As String

            'Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre, 1 as Orden " & _
            '         " From vwStbPersona a " & _
            '         " Where (a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') " & _
            '         " Order by a.nCodPersona"

            Me.cboLugarPago.ClearFields()

            If intLimpiarID = 0 Then
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre, 1 as Orden " & _
                         " From vwStbPersona a " & _
                         " Where (a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') " '& _

                '       Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre, 1 as Orden " & _
                '" From vwStbPersona a " & _
                '" inner Join " & _
                '" dbo.SteCaja ON a.nStbPersonaID = dbo.SteCaja.nStbPersonaLugarPagosID INNER JOIN " & _
                '" dbo.StbBarrio ON dbo.SteCaja.nStbBarrioID = dbo.StbBarrio.nStbBarrioID INNER JOIN " & _
                '" dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID " & _
                '" Where (a.nLugarPagosPrograma = 1) And (a.sCodEmpleado = 'J') " '& _

                '" Order by a.nCodPersona"
                CadWhere = ""
                'If Me.cboDepartamento.SelectedIndex > -1 Then
                '    CadWhere = " And  dbo.StbMunicipio.nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                'End If

                'If Me.cboMunicipio.SelectedIndex > -1 Then
                '    CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                'End If

                'If Me.cboDistrito.SelectedIndex > -1 Then
                '    CadWhere = CadWhere & " And dbo.StbBarrio.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                'End If

                Strsql = Strsql & CadWhere & " Order by a.sNombre"
            Else
                Strsql = " Select a.nStbPersonaID, a.nCodPersona, a.sNombre, 1 as Orden " & _
                         " From vwStbPersona a " & _
                         " Where a.nStbPersonaID = 0"
            End If

            If XdsCombos.ExistTable("LugarPago") Then
                XdsCombos("LugarPago").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "LugarPago")
                XdsCombos("LugarPago").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboLugarPago.DataSource = XdsCombos("LugarPago").Source
            Me.cboLugarPago.Rebind()

            Me.cboLugarPago.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            Me.cboLugarPago.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboLugarPago.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboLugarPago.Splits(0).DisplayColumns("nCodPersona").Width = 43
            Me.cboLugarPago.Splits(0).DisplayColumns("sNombre").Width = 80

            Me.cboLugarPago.Columns("nCodPersona").Caption = "Código"
            Me.cboLugarPago.Columns("sNombre").Caption = "Nombre"

            Me.cboLugarPago.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboLugarPago.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            'If Me.cboLugarPago.ListCount > 0 Then
            '    XdsCombos("LugarPago").AddRow()
            '    XdsCombos("LugarPago").ValueField("sNombre") = "Todos"
            '    XdsCombos("LugarPago").ValueField("nStbPersonaID") = -19
            '    XdsCombos("LugarPago").ValueField("Orden") = 0
            '    XdsCombos("LugarPago").UpdateLocal()
            '    XdsCombos("LugarPago").Sort = "Orden,nCodPersona asc"
            '    Me.cboLugarPago.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDiaPago
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDiaPago()
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion,1 as Orden " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'DiasSemana') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " Order by a.sCodigoInterno "

            If XdsCombos.ExistTable("DiaPago") Then
                XdsCombos("DiaPago").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "DiaPago")
                XdsCombos("DiaPago").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDiaPago.DataSource = XdsCombos("DiaPago").Source

            Me.cboDiaPago.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboDiaPago.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDiaPago.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDiaPago.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboDiaPago.Splits(0).DisplayColumns("sDescripcion").Width = 80

            Me.cboDiaPago.Columns("sCodigoInterno").Caption = "Código"
            Me.cboDiaPago.Columns("sDescripcion").Caption = "Descripción"

            Me.cboDiaPago.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDiaPago.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDiaPago.ListCount > 0 Then
                XdsCombos("DiaPago").AddRow()
                XdsCombos("DiaPago").ValueField("sDescripcion") = "Todos"
                XdsCombos("DiaPago").ValueField("nStbValorCatalogoID") = -19
                XdsCombos("DiaPago").ValueField("Orden") = 0
                XdsCombos("DiaPago").UpdateLocal()
                XdsCombos("DiaPago").Sort = "Orden,sCodigoInterno asc"
                Me.cboDiaPago.SelectedIndex = 1
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
            Me.cboDepartamento.DataSource = XdsCombos("Departamento").Source

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
            'If Me.cboDepartamento.ListCount > 0 Then
            '    XdsCombos("Departamento").AddRow()
            '    XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
            '    XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
            '    XdsCombos("Departamento").ValueField("Orden") = 0
            '    XdsCombos("Departamento").UpdateLocal()
            '    XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
            '    Me.cboDepartamento.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
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

            'XdtValorParametro.Filter = "nStbParametroID = 15"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Municipio").Count > 0 Then
            '    XdsCombos("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            'If Me.cboMunicipio.ListCount > 0 Then
            '    XdsCombos("Municipio").AddRow()
            '    XdsCombos("Municipio").ValueField("Descripcion") = "Todos"
            '    XdsCombos("Municipio").ValueField("nStbMunicipioID") = -19
            '    XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -19
            '    XdsCombos("Municipio").ValueField("Orden") = 0
            '    XdsCombos("Municipio").UpdateLocal()
            '    XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
            '    Me.cboMunicipio.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
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

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            'If Me.cboDistrito.ListCount > 0 Then
            '    XdsCombos("Distrito").AddRow()
            '    XdsCombos("Distrito").ValueField("Descripcion") = "Todos"
            '    XdsCombos("Distrito").ValueField("nStbDistritoID") = -19
            '    XdsCombos("Distrito").ValueField("Orden") = 0
            '    XdsCombos("Distrito").UpdateLocal()
            '    XdsCombos("Distrito").Sort = "Orden,sCodigo asc"
            '    Me.cboDistrito.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
            Me.cboMunicipio.Enabled = True
        Else
            CargarMunicipio(1)
            Me.cboMunicipio.Enabled = False
        End If

        If Me.mNomRep = EnumReportes.rptSclPagosPlaneadosVSEfectuados Or Me.mNomRep = EnumReportes.rptSclNoPagos Then
            cboMunicipio.Enabled = False
            cboMunicipio.Text = "Todos"
        End If
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                Me.cboDistrito.Enabled = True
                Me.cboDistrito.SelectedIndex = 0
            Else
                CargarDistrito(0)
                'If Me.cboDistrito.ListCount > 0 Then
                '    Me.cboDistrito.SelectedIndex = 0
                'End If
                Me.cboDistrito.Enabled = False
                'CargarBarrio(0, 0)
                Me.cboDistrito.SelectedIndex = 0
            End If
        Else
            CargarDistrito(1)
            Me.cboLugarPago.Enabled = False
        End If
    End Sub
    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False

            'Departamento
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                GoTo SALIR
            End If
            If mNomRep <> EnumReportes.rptSclPagosPlaneadosVSEfectuados And mNomRep <> EnumReportes.rptSclNoPagos Then
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

                'Día de Pago
                If Me.cboDiaPago.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Día de Pago válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboDiaPago, "Debe seleccionar un Día de Pago válido.")
                    Me.cboDiaPago.Focus()
                    GoTo SALIR
                End If

                'If mNomRep <> EnumReportes.rptSclPagosPlaneadosVSEfectuados And mNomRep <> EnumReportes.rptSclNoPagos Then
                'Incluido Programa
                If Me.cboLugarPago.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Lugar de Pago válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboLugarPago, "Debe seleccionar un Lugar de Pago válido.")
                    Me.cboLugarPago.Focus()
                    GoTo SALIR
                End If
            End If
            If mNomRep = EnumReportes.rptSclPagosPlaneadosVSEfectuados Or mNomRep = EnumReportes.rptSclNoPagos Then
                If FechaServer().Date < cdeFechaInicial.Value Then
                    MsgBox("Debe seleccionar una fecha menor o igual que hoy hasta 3 días.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha menor o igual que hoy hasta 3 días.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If

                If Math.Abs(DateDiff(DateInterval.Day, FechaServer().Date, cdeFechaInicial.Value)) > 3 Then
                    MsgBox("Debe seleccionar una fecha menor o igual que hoy hasta 3 días.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha menor o igual que hoy hasta 3 días.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If

            End If
            If mNomRep = EnumReportes.rptSclListGrupoMoroso Or mNomRep = EnumReportes.rptSclTotalGruposMorosos Then
                If dFechaFinal.Value < dFechaInicial.Value Then
                    MsgBox("Debe seleccionar una fecha Final mayor que La fecha Incial.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.dFechaFinal, "Debe seleccionar una fecha mayor que la fecha incial.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
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
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim Presupuesto As Integer
        Try

            If ValidarParametros() = False Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            Select Case mNomRep

                Case EnumReportes.rptSclListGrupoPago
                    ObjReporte = RepGrupoPago()


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
                Case EnumReportes.rptSclListGrupoPagoCoordinador
                    Filtro = ""


                    If cboDepartamento.SelectedIndex > -1 Then
                        Filtro = Filtro & " Where nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        '    Filtro = Filtro & " And nStbDepartamentoID ='" & Trim(cboMunicipio.Text) & "'"
                        'End If
                    End If

                    If cboMunicipio.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " Where nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If



                    'If cboDistrito.SelectedIndex > -1 Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    '    Else
                    '        Filtro = " Where nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    '    End If
                    'End If

                    If cboLugarPago.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And sLugarPago='" & Me.cboLugarPago.Text & "'"
                        Else
                            Filtro = " Where sLugarPago='" & Me.cboLugarPago.Text & "'"
                        End If
                    End If

                    If cboDiaPago.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And SdiaPago= '" & Me.cboDiaPago.Text & "'"
                        Else
                            Filtro = " Where SdiaPago='" & Me.cboDiaPago.Text & "'"
                        End If
                    End If



                    If Me.RadUsura0.Checked Then
                        If Trim(Filtro) <> "Todos" Then
                            Filtro = Filtro & " And CodPrograma= '1'"
                        Else
                            Filtro = " Where  CodPrograma= '1'"
                        End If
                    Else
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And CodPrograma= '0'"
                        Else
                            Filtro = " Where  CodPrograma= '0'"
                        End If
                    End If


                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    If Me.RadUsura0.Checked Then
                        frmVisor.Formulas("Parametro") = "' Parámetros Depto.: " & Me.cboDepartamento.Text & "  Munic.: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito: ", "") & cboDistrito.Text & " Lugar de Pago: " & Me.cboLugarPago.Text & " Día de Pago: " & Me.cboDiaPago.Text & " Programa Usura Cero '"
                    Else
                        frmVisor.Formulas("Parametro") = "' Parámetros Depto.: " & Me.cboDepartamento.Text & "  Munic.: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito: ", "") & cboDistrito.Text & " Lugar de Pago: " & Me.cboLugarPago.Text & " Día de Pago: " & Me.cboDiaPago.Text & " Programa Ventana de Género '"
                    End If

                    '& IIf(Me.RadUsura0.Checked, "'Usura Cero'", "'Ventana de Genero'")
                    frmVisor.NombreReporte = "RepSclCS18.rpt"
                    frmVisor.Text = "Listado de Coordinadoras de grupos"
                    frmVisor.SQLQuery = " Select * From vwSclGrupoPagoRepCoordinador " & Filtro & "  Order by  Departamento,Municipio, SlugarPago,Distrito,DiaSemana "
                    frmVisor.ShowDialog()


                Case EnumReportes.rptSclListGrupoPagoBarrio
                    Filtro = ""


                    If cboDepartamento.SelectedIndex > -1 Then
                        Filtro = Filtro & " Where nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        '    Filtro = Filtro & " And nStbDepartamentoID ='" & Trim(cboMunicipio.Text) & "'"
                        'End If
                    End If

                    If cboMunicipio.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " Where nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If



                    If cboDistrito.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " Where nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboLugarPago.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And sLugarPago='" & Me.cboLugarPago.Text & "'"
                        Else
                            Filtro = " Where sLugarPago='" & Me.cboLugarPago.Text & "'"
                        End If
                    End If

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                        Else
                            Filtro = " Where nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                        End If
                    End If

                    'If cboDiaPago.SelectedIndex > 0 Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And SdiaPago= '" & Me.cboDiaPago.Text & "'"
                    '    Else
                    '        Filtro = " Where SdiaPago='" & Me.cboDiaPago.Text & "'"
                    '    End If
                    'End If
                    frmVisor.WindowState = FormWindowState.Maximized
                    Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " Where ", " And ") & " CodPrograma = " & String.Format("{0}", IIf(Me.RadUsura0.Checked, 1, 0))
                    frmVisor.Formulas("Programa") = "' PROGRAMA " & IIf(Me.RadUsura0.Checked, " USURA0 ", " VENTANA DE GENERO") & "'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(chkIncluirSocias.Checked = True, 1, 0)
                    frmVisor.Formulas("Parametro") = "' Parámetros Depto.: " & Me.cboDepartamento.Text & "  Munic.: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito: ", "") & cboDistrito.Text & " Lugar de Pago: " & Me.cboLugarPago.Text & " Día de Pago: " & Me.cboDiaPago.Text & "'"
                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & "'"
                    frmVisor.NombreReporte = "RepSclCS25.rpt"
                    frmVisor.Text = "Listado de Barrios por Lugares de Pago"
                    frmVisor.SQLQuery = " Select * From vwSclGrupoPagoRepCoordinador " & Filtro & "  Order by  Departamento,Municipio, SlugarPago,Distrito,DiaSemana "
                    frmVisor.ShowDialog()

                Case EnumReportes.rptSclListGrupoPagoDistNumerica
                    Filtro = ""

                    If cboDepartamento.SelectedIndex > -1 Then
                        Filtro = Filtro & " Where nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    End If

                    If cboMunicipio.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " Where nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If



                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " Where nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboLugarPago.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And sLugarPago='" & Me.cboLugarPago.Text & "'"
                        Else
                            Filtro = " Where sLugarPago='" & Me.cboLugarPago.Text & "'"
                        End If
                    End If

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, 1, 0)
                        Else
                            Filtro = " Where nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, 1, 0)
                        End If
                    End If
                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("Parametro") = "' Parámetros Depto.: " & Me.cboDepartamento.Text & "  Munic.: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito: ", "") & cboDistrito.Text & " Lugar de Pago: " & Me.cboLugarPago.Text
                    frmVisor.NombreReporte = "RepSclCS41.rpt"
                    frmVisor.Text = "Distribución numérica de grupos solidarios"
                    frmVisor.SQLQuery = " Select * From dbo.vwSclGrupoPagoRepDistribucionNumericaCajas " & Filtro & "  Order by  Departamento,Municipio, SlugarPago,Distrito"
                    frmVisor.ShowDialog()




                Case EnumReportes.rptSclPagosPlaneadosVSEfectuados
                    Filtro = ""

                    If cboDepartamento.SelectedIndex > -1 Then
                        Filtro = Filtro & " Where nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    End If

                    If cboMunicipio.SelectedIndex > -1 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " Where nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " Where nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If



                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, 1, 0)
                        Else
                            Filtro = " Where nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, 1, 0)
                        End If
                    End If

                    'frmVisor.WindowState = FormWindowState.Maximized
                    'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    'frmVisor.Formulas("Parametro") = "' Parámetros Depto.: " & Me.cboDepartamento.Text & "  Munic.: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito: ", "") & cboDistrito.Text & " Lugar de Pago: " & Me.cboLugarPago.Text
                    'frmVisor.NombreReporte = "RepSclCS44.rpt"
                    'frmVisor.Text = "Distribución de pagos realizados por lugares de pago"
                    'frmVisor.SQLQuery = " spSclRptSociasPago_SC44 '" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & "','" & Me.cboMunicipio.Columns("nStbMunicipioID").Value & "','" & FechaServer().ToString("yyyy-MM-dd") & "'"
                    'frmVisor.ShowDialog()
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, 1, 0)
                    Else
                        Filtro = " Where nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, 1, 0)
                    End If
                    Presupuesto = -1
                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        Presupuesto = IIf(RdPresupuesto.Checked, 1, 0)

          
                    End If



                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("FechaAplica") = "'" & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & "'"
                    frmVisor.NombreReporte = "RepSclCS44.rpt"
                    frmVisor.Text = "Distribución de pagos realizados por lugares de pago"
                    frmVisor.SQLQuery = "spSclRptDptoGruposPaga '" & Me.cboDepartamento.Text & "','" & Format(cdeFechaInicial.Value, "yyyy/MM/dd") & "'" & "," & Presupuesto
                    frmVisor.Formulas("Parametro") = "'Parámetros Depto: " & Me.cboDepartamento.Text & ", Fecha: " & Me.cdeFechaInicial.Text & " " & IIf(Presupuesto = 1, "Fondos presupuesto", IIf(Presupuesto = 0, "Fondos externos", "Todos los fondos")) & "'"
                    'frmVisor.SQLQuery = "spSclRptDptoGruposPaga '" & Me.cboDepartamento.Text & "','" & FechaServer().ToString("yyyy-MM-dd") & "'"
                    'frmVisor.Formulas("Parametros") = "'Parámetros Depto: " & Me.cboDepartamento.Text & ", Fecha: " & FechaServer().ToString("dd/MM/yyyy") & "'"

                    frmVisor.Formulas("Fecha") = "'AL  " & Me.cdeFechaInicial.Text & "'"
                    frmVisor.ShowDialog()


                Case EnumReportes.rptSclNoPagos
                    Presupuesto = -1
                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        Presupuesto = IIf(RdPresupuesto.Checked, 1, 0)


                    End If
                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("Dpto") = "'" & Me.cboDepartamento.Text & "'"
                    'frmVisor.Formulas("Parametros") = FechaServer().ToString("yyyy/MM/dd")
                    frmVisor.Formulas("Parametro") = "'Parámetros Depto: " & Me.cboDepartamento.Text & ", Fecha: " & Me.cdeFechaInicial.Text & " " & IIf(Presupuesto = 1, "Fondos presupuesto", IIf(Presupuesto = 0, "Fondos externos", "Todos los fondos")) & "'"
                    frmVisor.NombreReporte = "RepSclCS45.rpt"
                    frmVisor.Text = "Grupos Solidarios que no pagaron en fecha de pago oficial"
                    frmVisor.SQLQuery = "spSclRptDptoGruposNoPaga '" & Me.cboDepartamento.Text & "','" & FechaServer().ToString("yyyy/MM/dd") & "'" & "," & Presupuesto
                    frmVisor.Formulas("FechaAplica") = "'" & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & "'"
                    frmVisor.ShowDialog()


                    'New Code

                Case EnumReportes.rptSclListGrupoMoroso

                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("Parametro") = "'Parámetros Depto.:" & Me.cboDepartamento.Text & ", Munic.:" & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito:", "") & cboDistrito.Text & ", Lugar de Pago:" & Me.cboLugarPago.Text & ", Día de pago:" & cboDiaPago.Text & "'"
                    frmVisor.Formulas("UnicoDiaPago") = "'" & Me.cboDiaPago.Text & "'"
                    frmVisor.Formulas("ParametroFecha") = "'" & "Desde:" & Me.dFechaInicial.Text & "- Hasta: " & Me.dFechaFinal.Text & "'"
                    frmVisor.NombreReporte = "RepSclCS59.rpt"
                    frmVisor.Text = "Lista de grupos solidarios pendientes de pago"
                    frmVisor.SQLQuery = "SpSclGruposPendientesDePagoPorPeriodo '" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & "','" & Me.cboMunicipio.Columns("nStbMunicipioID").Value & "','" & Me.cboDistrito.Columns("nStbDistritoID").Value & "','" & Me.cboLugarPago.Text & "',' " & Format(Me.dFechaInicial.Value, "yyyy-MM-dd") & "' ,'" & Format(Me.dFechaFinal.Value, "yyyy-MM-dd") & "','" & Me.cboDiaPago.Text & "'"
                    frmVisor.ShowDialog()

                Case EnumReportes.rptSclTotalGruposMorosos

                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("Parametro") = "'Parámetros Depto.:" & Me.cboDepartamento.Text & ", Munic.:" & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito:", "") & cboDistrito.Text & ", Lugar de Pago:" & Me.cboLugarPago.Text & "'"
                    frmVisor.Formulas("ParametroFecha") = "'" & "Desde:" & Me.dFechaInicial.Text & "- Hasta: " & Me.dFechaFinal.Text & "'"
                    frmVisor.NombreReporte = "RepSclCS60.rpt"
                    frmVisor.Text = "Total de grupos solidarios pejndientes de pago"
                    frmVisor.SQLQuery = "SpSclTotalGruposPendientesDePagoPorPeriodo '" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & "','" & Me.cboMunicipio.Columns("nStbMunicipioID").Value & "','" & Me.cboDistrito.Columns("nStbDistritoID").Value & "','" & Me.cboLugarPago.Text & "',' " & Format(Me.dFechaInicial.Value, "yyyy-MM-dd") & "' ,'" & Format(Me.dFechaFinal.Value, "yyyy-MM-dd") & "','" & Me.cboDiaPago.Text & "'"
                    frmVisor.ShowDialog()

            End Select
            Me.Cursor = Cursors.Default
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
                Case EnumReportes.rptSclListGrupoPago
                    ObjVisorReporte.Text = "Reporte de Grupos por Lugar/Día de pago"
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

            'XdtEstados.Close()
            'XdtEstados = Nothing

            XdsCombos.Close()
            XdsCombos = Nothing

            'XdtPertenece.Close()
            'XdtPertenece = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'If mNomRep = EnumReportes.rptStbBarrio Then
            'CargarLugarPago()
            CargarDepartamento()
            CargarDiaPago()
            'End If

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
    ' Procedure name		   	:	RepMercado
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Mercados
    ' -----------------------------------------------------------------------------------------
    Private Function RepGrupoPago() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptSclLstGrupoPago As rptSclLstGrupoPago

        Try
            ObjRptSclLstGrupoPago = New rptSclLstGrupoPago

            'Departamento
            ObjRptSclLstGrupoPago.IdDepartamento = XdsCombos("Departamento").ValueField("nStbDepartamentoID")
            ObjRptSclLstGrupoPago.Departamento = UCase(Me.cboDepartamento.Text)

            'Municipio
            ObjRptSclLstGrupoPago.IdMunicipio = XdsCombos("Municipio").ValueField("nStbMunicipioID")
            ObjRptSclLstGrupoPago.Municipio = UCase(Me.cboMunicipio.Text)

            'Distrito
            ObjRptSclLstGrupoPago.IdDistrito = XdsCombos("Distrito").ValueField("nStbDistritoID")
            ObjRptSclLstGrupoPago.Distrito = UCase(Me.cboDistrito.Text)

            'Lugar de Pago
            ObjRptSclLstGrupoPago.IdLugarPago = XdsCombos("LugarPago").ValueField("nStbPersonaID")
            ObjRptSclLstGrupoPago.LugarPago = UCase(Me.cboLugarPago.Text)

            'Día de Pago
            ObjRptSclLstGrupoPago.IdDiaPago = XdsCombos("DiaPago").ValueField("nStbValorCatalogoID")
            ObjRptSclLstGrupoPago.DiaPago = UCase(Me.cboDiaPago.Text)

            'Programa
            If RadUsura0.Checked Then
                ObjRptSclLstGrupoPago.IdPrograma = 1
                ObjRptSclLstGrupoPago.Programa = "Usura Cero"
            Else
                If Me.RadVentana.Checked Then
                    ObjRptSclLstGrupoPago.IdPrograma = 2
                    ObjRptSclLstGrupoPago.Programa = "Ventana Género"
                End If

            End If



            If Me.chkIncluirSocias.Checked = True Then
                ObjRptSclLstGrupoPago.IncluyeSocias = -19
            Else
                ObjRptSclLstGrupoPago.IncluyeSocias = 1
            End If

            Return ObjRptSclLstGrupoPago

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub frmSclParametroGrupoPago_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        cdeFechaInicial.Visible = False
        Select Case mNomRep
            Case EnumReportes.rptSclListGrupoPagoCoordinador
                grpdestino.Enabled = False
                lblIncluirMunicipio.Enabled = False
                chkIncluirSocias.Enabled = False
                chkIncluirSocias.Checked = False
                grpFuente.Enabled = False
            Case EnumReportes.rptSclListGrupoPagoBarrio
                grpdestino.Enabled = False
                lblIncluirMunicipio.Text = "Incluir Grupos"
                cboDiaPago.Enabled = False
                grpFuente.Enabled = True

            Case EnumReportes.rptSclListGrupoPago
                grpFuente.Enabled = False
            Case EnumReportes.rptSclListGrupoPagoDistNumerica
                grpdestino.Enabled = False
                grpPrograma.Enabled = False
                chkIncluirSocias.Enabled = False
            Case EnumReportes.rptSclPagosPlaneadosVSEfectuados
                grpdestino.Enabled = False
                grpPrograma.Enabled = False
                chkIncluirSocias.Enabled = False
                Me.cboDiaPago.Enabled = False

                lblIncluirMunicipio.Text = "Fecha:"
                chkIncluirSocias.Visible = False
                cdeFechaInicial.Visible = True
                grpFuente.Enabled = True
                Me.cboLugarPago.Enabled = False


            Case EnumReportes.rptSclNoPagos
                grpdestino.Enabled = False
                grpPrograma.Enabled = False
                chkIncluirSocias.Enabled = False
                Me.cboDiaPago.Enabled = False

                lblIncluirMunicipio.Text = "Fecha:"
                chkIncluirSocias.Visible = False
                cdeFechaInicial.Visible = True
                grpFuente.Enabled = True
                Me.cboLugarPago.Enabled = False

            Case EnumReportes.rptSclListGrupoMoroso
                dFechaInicial.Enabled = True
                dFechaFinal.Enabled = True
                grpdestino.Enabled = False
                grpPrograma.Enabled = False
                chkIncluirSocias.Enabled = False

            Case EnumReportes.rptSclTotalGruposMorosos
                dFechaInicial.Enabled = True
                dFechaFinal.Enabled = True
                grpdestino.Enabled = False
                grpPrograma.Enabled = False
                chkIncluirSocias.Enabled = False
        End Select

    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex <> -1 Then
            CargarLugarPago(0)
            If mNomRep <> EnumReportes.rptSclPagosPlaneadosVSEfectuados Then
                Me.cboLugarPago.Enabled = True
            End If
        Else
            If mNomRep <> EnumReportes.rptSclPagosPlaneadosVSEfectuados Then

                CargarLugarPago(1)
                Me.cboLugarPago.Enabled = False
            End If

        End If
    End Sub

  

End Class