Public Class FrmSccParametrosSaldoSaneamiento

    Dim IntPermiteConsultar As Integer
    Dim IntDepartamento As Integer

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim mColorVentana As String

    Public Property ColorVentana() As String
        Get
            Return mColorVentana
        End Get
        Set(ByVal value As String)
            mColorVentana = value
        End Set
    End Property

    'Listado de Reportes
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        DetalleSaldosCarteraFechaVence = 1 'Detalle  Saldo Cartera con fecha de vencimiento
    End Enum

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
            IntPermiteConsultar = 1
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
            If Me.CboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
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



    '**************************************************************************    
    '* Cargar la lista de Mercados existente  
    '**************************************************************************

    Private Sub CargarMercado(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String
            Dim CadWhere As String '' Cadena para el filtro por todos o  departamento y o municipio

            Me.CboMercado.ClearFields()
            CadWhere = ""
            If Me.CboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If

            If Me.cboDistrito.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbDistrito.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
            End If

            If Me.RdoCooperativa.Checked Or Me.RadSoloMercado.Checked Then
                CadWhere = CadWhere & String.Format(" And dbo.StbMercado.nCooperativa = {0}", IIf(RdoCooperativa.Checked, 1, 0))
            End If

            If intLimpiarID = 0 Then


                Strsql = " Select dbo.StbMercado.nStbMercadoID,dbo.StbMercado.sCodigo ,dbo.StbMercado.sNombre , 1 As Orden " & _
                                     " FROM         dbo.StbBarrio INNER JOIN " & _
                                     " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                                     " dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID INNER JOIN " & _
                                     " dbo.StbDistrito ON dbo.StbBarrio.nStbDistritoID = dbo.StbDistrito.nStbDistritoID INNER JOIN " & _
                                     " dbo.StbMercado ON dbo.StbBarrio.nStbBarrioID = dbo.StbMercado.nStbBarrioID " & _
                                     CadWhere & " Order BY dbo.StbDepartamento.nStbDepartamentoID , dbo.StbMunicipio.nStbMunicipioID, dbo.StbDistrito.nStbDistritoID,dbo.StbMercado.nStbMercadoID "



            Else

                Strsql = " Select dbo.StbMercado.nStbMercadoID,dbo.StbMercado.sCodigo , dbo.StbMercado.sNombre , 1 As Orden " & _
                                     " FROM         dbo.StbBarrio INNER JOIN " & _
                                     " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                                     " dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID INNER JOIN " & _
                                     " dbo.StbDistrito ON dbo.StbBarrio.nStbDistritoID = dbo.StbDistrito.nStbDistritoID INNER JOIN " & _
                                     " dbo.StbMercado ON dbo.StbBarrio.nStbBarrioID = dbo.StbMercado.nStbBarrioID " & _
                                     " Where dbo.StbMercado.nStbMercadoID = -1 Order BY dbo.StbDepartamento.nStbDepartamentoID , dbo.StbMunicipio.nStbMunicipioID, dbo.StbDistrito.nStbDistritoID,dbo.StbMercado.nStbMercadoID "

            End If

            If XdsCombos.ExistTable("Mercado") Then
                XdsCombos("Mercado").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Mercado")
                XdsCombos("Mercado").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboMercado.DataSource = XdsCombos("Mercado").Source
            Me.CboMercado.Rebind()

            Me.CboMercado.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.CboMercado.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboMercado.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboMercado.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.CboMercado.Splits(0).DisplayColumns("SNombre").Width = 80

            Me.CboMercado.Columns("sCodigo").Caption = "Código"
            Me.CboMercado.Columns("sNombre").Caption = "Nombre "

            Me.CboMercado.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboMercado.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboBarrio.ListCount > 0 Then
                XdsCombos("Mercado").AddRow()
                XdsCombos("Mercado").ValueField("sNombre") = "Todos"
                XdsCombos("Mercado").ValueField("nStbMercadoID") = -19
                XdsCombos("Mercado").ValueField("Orden") = 0
                XdsCombos("Mercado").UpdateLocal()
                XdsCombos("Mercado").Sort = "Orden,sCodigo asc"
                Me.CboMercado.SelectedIndex = 0
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

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                GoTo SALIR
            End If

            'Incluido Barrio
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Barrio Valido .", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboBarrio, "Debe seleccionar un Barrio  válido.")
                Me.cboBarrio.Focus()
                GoTo SALIR
            End If

            If Me.RadSoloMercado.Checked = True And Me.CboMercado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Mercado Valido .", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboBarrio, "Debe seleccionar un Mercado válido.")
                Me.CboMercado.Focus()
                GoTo SALIR
            End If

            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Barrio Valido .", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboBarrio, "Debe seleccionar un Barrio  válido.")
                Me.cboBarrio.Focus()
                GoTo SALIR
            End If

            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub CargarFuente()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 0 Then
                Strsql = "SELECT   1 As Orden , a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
                         " FROM         dbo.ScnFuenteFinanciamiento a Where  a.nScnFuenteFinanciamientoID=-1"
            Else
                Strsql = "SELECT     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
                                         " FROM         dbo.ScnFuenteFinanciamiento a Order By a.sCodigo "
            End If

            If XdsCombos.ExistTable("Fuente") Then
                XdsCombos("Fuente").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Fuente")
                XdsCombos("Fuente").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboFuentes.DataSource = XdsCombos("Fuente").Source
            Me.CboFuentes.Rebind()
            Me.CboFuentes.Refresh()
            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Departamento").Count > 0 Then
            '    XdsCombos("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.CboFuentes.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.CboFuentes.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboFuentes.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboFuentes.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.CboFuentes.Splits(0).DisplayColumns("sNombre").Width = 160

            Me.CboFuentes.Columns("sCodigo").Caption = "Código"
            Me.CboFuentes.Columns("sNombre").Caption = "Nombre"

            Me.CboFuentes.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboFuentes.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboFuentes.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("Fuente").AddRow()
                XdsCombos("Fuente").ValueField("sNombre") = "Todos"
                XdsCombos("Fuente").ValueField("sCodigo") = -19
                XdsCombos("Fuente").ValueField("Orden") = 0
                XdsCombos("Fuente").UpdateLocal()
                XdsCombos("Fuente").Sort = "Orden,sCodigo asc"
                Me.CboFuentes.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        '----------------------------------------------------------------------------------
        'Llama a los reportes de consolidados y detalle de créditos por distritos y barrios
        '----------------------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim CadSql As String


        Try
            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""
            frmVisor.WindowState = FormWindowState.Maximized

            Select Case mNomRep
               
                Case EnumReportes.DetalleSaldosCarteraFechaVence
                   
                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos_CC89.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraSaldos_CC89.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        End If
                    Else
                        If (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID}=1"
                        End If
                    End If

                    If mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Then
                        frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                        'If Trim(Filtro) <> "" Then
                        '    Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario} =-1", "")))
                        'Else
                        '    Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario} =-1 ", "")))
                        'End If
                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If

                    Select Case CboFiltroMora.SelectedIndex
                        Case 0
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "
                        Case 1
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN SALDO VENCIDO  "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}=0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}=0"
                            End If
                        Case 2
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 1 A 10 DIAS "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}>0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}>0"
                            End If

                        Case 3
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 11 A 20 DIAS "
                        Case 4
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 21 A 30 DIAS "
                        Case 5
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 40 DIAS "
                        Case 6
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO 41 DIAS A MAS "

                        Case 7
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraMenoroIgual30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraMenoroIgual30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MENOR O IGUAL A 30 DIAS  "
                        Case 8
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A60Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A60Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 60 DIAS  "
                        Case 9
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe61A90Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe61A90Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 61 A 90 DIAS  "
                        Case 10
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe91A120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe91A120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 91 A 120 DIAS  "

                        Case 11
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraMasde120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraMasde120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MAS DE 120 DIAS"

                    End Select

                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & String.Format("{0} '", IIf(Me.radSaldoTodos.Checked, "TODOS LOS SALDOS", IIf(Me.RadMayor0.Checked, " SALDOS POSITIVOS", "SALDOS NEGATIVOS")))    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"

                    If Not Me.radTodosFecha.Checked Then
                        'Filtro = IIf(String.IsNullOrEmpty(Filtro), "", Filtro + " AND ") & " {spSccReporteAvanceCarteraSaldos_CC89.Vigente} " & IIf(Me.radVencidosFecha.Checked, " > 0", " = 0")
                    End If

                    If Me.RadMenor0.Checked Then
                        Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " ", " And ") & " {@TotalCartera} < 0.00 "
                    End If

                    If Me.RadMayor0.Checked Then
                        Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " ", " And ") & " {@TotalCartera} >= 0.00 "
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.Formulas("TipoCartera") = "'" & IIf(Me.radTodosFecha.Checked, "", IIf(Me.radVencidosFecha.Checked, "VENCIDA", "VIGENTE")) & "'"

                    frmVisor.NombreReporte = "RepSccCC89.rpt"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Text = "Reporte de Saldo de Saneamiento de Cartera"
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " (Tipo de Saldo: " & IIf(radTodosFecha.Checked, "Todos", IIf(Me.radVencidosFecha.Checked, "Vencidos", IIf(Me.radActivosFecha.Checked, "Activos", ""))) & ")'"
                    'frmVisor.Parametros("TipoVencimiento") = "' " & IIf(radTodosFecha.Checked, "TODOS LOS CREDITOS VENCIDOS Y NO VENCIDOS", IIf(radVencidosFecha.Checked, "CREDITOS VENCIDOS AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy"), "CREDITOS NO VENCIDOS AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy"))) & " '"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))

                    frmVisor.Parametros("TipoVencimiento") = "' 00000000000000000 '"
                    frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)

                    ' ---------------------------------------------------------------------------------------------------------------------
                    ' ---------------------------------------------------------------------------------------------------------------------
                    ' ---------------------------------------------------------------------------------------------------------------------
                    ' ---------------------------------------------------------------------------------------------------------------------

                    'If CboDepartamento.SelectedIndex > 0 Then
                    '    Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos_CC89.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    '    If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                    '    End If
                    'End If

                    'If cboMunicipio.SelectedIndex > 0 Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    '    Else
                    '        Filtro = "{spSccReporteAvanceCarteraSaldos_CC89.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    '    End If
                    'End If

                    'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    'frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    'frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    'frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    'frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    'If cboDistrito.SelectedIndex > 0 Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    '    Else
                    '        Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    '    End If
                    'End If

                    'If cboBarrio.SelectedIndex > 0 Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    '    Else
                    '        Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    '    End If
                    'End If

                    'If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                    '    Else
                    '        Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                    '    End If
                    'Else
                    '    If (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos_CC89.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                    '        End If
                    '    End If
                    'End If

                    'If Me.RadSinMercado.Checked = True Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID}=1"
                    '    Else
                    '        Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.nStbMercadoVerificadoID}=1"
                    '    End If
                    'End If

                    ''If mNomRep = EnumReportes.Grupo Then
                    'frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                    ''If Trim(Filtro) <> "" Then
                    ''    Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario} =-1", "")))
                    ''Else
                    ''    Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos_CC89.nFondoPresupuestario} =-1 ", "")))
                    ''End If
                    ''frmVisor.CRVReportes.ShowRefreshButton = False
                    ''End If

                    'Select Case CboFiltroMora.SelectedIndex
                    '    Case 0
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "
                    '    Case 1
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN SALDO VENCIDO  "
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}=0"
                    '        Else
                    '            Filtro = "  {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}=0"
                    '        End If
                    '    Case 2
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 1 A 10 DIAS "
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}>0"
                    '        Else
                    '            Filtro = "  {spSccReporteAvanceCarteraSaldos_CC89.MoraDe1A10Dias}>0"
                    '        End If
                    '    Case 3
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe11A20Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 11 A 20 DIAS "
                    '    Case 4
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe21A30Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 21 A 30 DIAS "
                    '    Case 5
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A40Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 40 DIAS "
                    '    Case 6
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.Mora41DiasAMas}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO 41 DIAS A MAS "
                    '    Case 7
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraMenoroIgual30Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraMenoroIgual30Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MENOR O IGUAL A 30 DIAS  "
                    '    Case 8
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A60Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe31A60Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 60 DIAS  "
                    '    Case 9
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe61A90Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe61A90Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 61 A 90 DIAS  "
                    '    Case 10
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraDe91A120Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraDe91A120Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 91 A 120 DIAS  "
                    '    Case 11
                    '        If Trim(Filtro) <> "" Then
                    '            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos_CC89.MoraMasde120Dias}>0"
                    '        Else
                    '            Filtro = " {spSccReporteAvanceCarteraSaldos_CC89.MoraMasde120Dias}>0"
                    '        End If
                    '        frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MAS DE 120 DIAS  "
                    'End Select
                    'frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & String.Format("{0} '", IIf(Me.radSaldoTodos.Checked, "TODOS LOS SALDOS", IIf(Me.RadMayor0.Checked, " SALDOS POSITIVOS", "SALDOS NEGATIVOS")))    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"

                    'If Not Me.radTodosFecha.Checked Then
                    '    Filtro = IIf(String.IsNullOrEmpty(Filtro), "", Filtro + " AND ") & " {spSccReporteAvanceCarteraSaldos_CC89.Vigente} " & IIf(Me.radVencidosFecha.Checked, " > 0", " = 0")
                    'End If

                    'If Me.RadMenor0.Checked Then
                    '    Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " ", " And ") & " {@TotalCartera} < 0.00 "
                    'End If

                    'If Me.RadMayor0.Checked Then
                    '    Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), " ", " And ") & " {@TotalCartera} >= 0.00 "
                    'End If

                    'Me.Cursor = Cursors.WaitCursor
                    'If Trim(Filtro) <> "" Then
                    '    frmVisor.CRVReportes.SelectionFormula = Filtro
                    'End If

                    'frmVisor.Formulas("TipoCartera") = "'" & IIf(Me.radTodosFecha.Checked, "", IIf(Me.radVencidosFecha.Checked, "VENCIDA", "VIGENTE")) & "'"

                    'frmVisor.NombreReporte = "RepSccCC89.rpt"
                    'frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    'frmVisor.Text = "Reporte de avance de Saldos de Cartera " & IIf(Me.RadMenor0.Checked, " Negativos", " Positivos")
                    'frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    ''frmVisor.Parametros("TipoVencimiento") = "' " & IIf(radTodosFecha.Checked, "TODOS LOS CREDITOS VENCIDOS Y NO VENCIDOS", IIf(radVencidosFecha.Checked, "CREDITOS VENCIDOS AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy"), "CREDITOS NO VENCIDOS AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy"))) & " '"
                    'frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    'frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    'frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    'frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    'frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))

                    ''frmVisor.Parametros("TipoVencimiento") = "' 00000000000000000 '"
                    'frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                    'frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    'frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)

            End Select

            frmVisor.Show()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
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
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
    End Sub

    Private Sub HabilitarComboMunicipio()
        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboBarrio.Enabled = False
                HabilitarMercado()
            Else
                Me.cboBarrio.Enabled = True
                HabilitarMercado()
            End If
        Else
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False
            HabilitarMercado()
        End If
    End Sub

    Private Sub HabilitarComboBarrio()
        If Me.cboMunicipio.SelectedIndex > 0 Then
            Me.cboBarrio.Enabled = True
        Else
            Me.cboBarrio.Enabled = False
        End If
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                CargarMercado(0)
                Me.cboDistrito.Enabled = True

                HabilitarMercado()
            Else
                CargarDistrito(0)
                Me.cboDistrito.Enabled = False
            End If
            CargarBarrio(0)
            CargarMercado(0)
            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboBarrio.Enabled = False
            Else
                Me.cboBarrio.Enabled = True
            End If
        Else
            CargarDistrito(1)
            CargarBarrio(1)
            CargarMercado(1)
        End If
    End Sub

    Private Sub FrmSccParametrosSaldoSaneamiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub HabilitarMercado()
        CboMercado.Enabled = IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, True, False)
        If CboMercado.Enabled = False Then
            CboMercado.SelectedIndex = -1
        Else
            CargarMercado(0)
        End If
    End Sub

    Private Sub FrmSccParametrosSaldoSaneamiento_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)

            If Me.ColorVentana = "Verde" Then
                If mNomRep = 5 Or mNomRep = 6 Then
                    Me.HelpProvider.SetHelpKeyword(Me, "Indicadores (Reportes)")
                Else
                    Me.HelpProvider.SetHelpKeyword(Me, "Reportes de Saldo de Saneamiento de Cartera")
                End If
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Contabilidad")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()
            CargarFuente()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex > -1 Then
            CargarBarrio(0)
            CargarMercado(0)
        End If
    End Sub

    Private Sub RadSinMercado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadSinMercado.CheckedChanged
        HabilitarMercado()
    End Sub

    Private Sub RadTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadTodos.CheckedChanged
        HabilitarMercado()
    End Sub

    Private Sub RadSoloMercado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadSoloMercado.CheckedChanged
        HabilitarMercado()
    End Sub

    Private Sub FrmSccParametrosSaldoSaneamiento_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll

    End Sub

    Private Sub FrmSccParametrosSaldoSaneamiento_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        grpSaldos.Enabled = False
        grpFechaRecibos.Enabled = False
        grpPrograma.Visible = False

        Select Case mNomRep
            Case EnumReportes.DetalleSaldosCarteraFechaVence
                Me.Text = "Reporte de Saldo de Cartera"
                Me.cdeFechaInicial.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                CboFiltroMora.AddItem("Todos")
                If mNomRep <> EnumReportes.DetalleSaldosCarteraFechaVence Then
                    CboFiltroMora.AddItem("Sin Mora")
                Else
                    CboFiltroMora.AddItem("Sin Saldo Vencido")
                End If
                CboFiltroMora.AddItem("Mora 1 A 10 Dias")
                CboFiltroMora.AddItem("Mora 11 A 20 Dias")
                CboFiltroMora.AddItem("Mora 21 A 30 Dias")
                CboFiltroMora.AddItem("Mora 31 A 40 Dias")
                CboFiltroMora.AddItem("Mora 41 Dias a más")
                CboFiltroMora.AddItem("Mora 1 A 30 Dias")
                CboFiltroMora.AddItem("Mora 31 A 60 Dias")
                CboFiltroMora.AddItem("Mora 61 A 90 Dias")
                CboFiltroMora.AddItem("Mora 91 A 120 Dias")
                CboFiltroMora.AddItem("Mora 121 Dias a más")

                CboFiltroMora.Columns(0).Caption = "Días(Mora)"
                CboFiltroMora.SelectedIndex = 0
                CboFiltroMora.Enabled = True
                ChkSocias.Enabled = True
                If mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Then
                    Me.RadMenor0.Enabled = True
                    Me.RadMayor0.Enabled = True
                    If mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Then
                        Me.radSaldo20.Enabled = False
                        Me.radSaldoMayor20.Enabled = False
                    End If
                    grpSaldos.Enabled = True
                End If
                grpPrograma.Visible = True
        End Select

        If mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Then
            grpActivos.Enabled = True
        Else
            grpActivos.Enabled = False
        End If

    End Sub

    Private Sub grpFuente_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpFuente.Enter

    End Sub

    Private Sub radFondos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFondos.CheckedChanged
        If Me.radFondos.Checked = True Then
            grpFuente.Enabled = True
            CboFuentes.Enabled = False
        Else
            grpFuente.Enabled = False
            CboFuentes.Enabled = True
        End If
    End Sub

    Private Sub radFuentes_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFuentes.CheckedChanged
        If Me.radFuentes.Checked = True Then
            grpFuente.Enabled = False
            CboFuentes.Enabled = True
        Else
            grpFuente.Enabled = True
            CboFuentes.Enabled = False
        End If
    End Sub

    Private Sub RdoCooperativa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoCooperativa.CheckedChanged
        HabilitarMercado()
    End Sub
End Class