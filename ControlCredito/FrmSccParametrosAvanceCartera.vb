Public Class FrmSccParametrosAvanceCartera

    Dim IntPermiteConsultar As Integer
    'Dim IntPermiteEditar As Integer
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

        Grupo = 1 ''Mora con todas las recuperaciones incluidas
        GrupoRecupera = 2 ''Recuperacion de cartera
        ReportePrestamosVencidos = 3 'Detalle de los grupos con fechas vencidas por rango
        ConsolidadoPrestamosVencidos = 4 'Totales de los grupos con fechas vencidas por rango
        ConsolidadoEstadisticoPeriodo = 5 'Totales de los grupos con fechas vencidas por rango
        ConsolidadoEstadisticoCreditoSegunUbicacion = 6 'Consolidado de Creditos aprobados, recuperados y en mora segun ubiacion
        ConsolidadoRecuperacion = 7 'Consolidado de Creditos aprobados, recuperados y en mora segun ubiacion
        ConsolidadoMontoRecuperar = 8 'Consolidado de Creditos  recuperados 
        DetalleMontoRecuperarConMora = 9 'Consolidado de Creditos  recuperados 
        DetalleSaldosCartera = 10 'Detalle del Saldo de Cartera para cada grupo CC59
        GrupoCorte = 11 'Mora pero con fecha de corte para los pagos
        GrupoCorteVencidos = 12 'Mora pero con fecha de corte para los pagos
        DetalleSaldosCartera20Cordobas = 13 'Detalle del Saldo de Cartera para cada socia filtro con menor igual a 20 o mayor que 20 cordobas
        DetalleSaldosCartera20CordobasFechaPago = 14 'Detalle del Saldo de Cartera para cada socia filtro con menor igual a 20 o mayor que 20 cordobas
        DetalleSaldosCarteraFechaVence = 15 'Detalle  Saldo Cartera con fecha de vencimiento
        DetalleSaldosCartera20CordobasFechaPagoFechaVence = 16
        TotalGruposySociasAVencermensualmente = 17
        ReporteDeMoraTotalizadoPorBarrios = 18
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

            If mNomRep <> 12 Then
                IntPermiteConsultar = 1
            End If

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
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                         " From StbDepartamento a " &
                         " Where a.nStbDepartamentoID = " & Me.IntDepartamento &
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

            If Me.NomRep = EnumReportes.TotalGruposySociasAVencermensualmente Then
                If Not (IsDBNull(Me.cdeFechaInicial.Value) Or IsDBNull(Me.CdeFechaFinal.Value)) Then
                    Dim fecha As Date = Me.cdeFechaInicial.Value
                    'If Not (fecha.Day = 1) Then
                    '    MsgBox("La fecha de inicio debe ser el 1 de Enero.", MsgBoxStyle.Critical, NombreSistema)
                    '    Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar una fecha válida.")
                    '    Me.CboDepartamento.Focus()
                    '    GoTo SALIR
                    'End If
                    'fecha = Me.CdeFechaFinal.Value
                    'If Not (fecha.Day = 31 And fecha.Month = 12) Then
                    '    MsgBox("La fecha final debe ser el 31 de Diciembre.", MsgBoxStyle.Critical, NombreSistema)
                    '    Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar una fecha válida.")
                    '    Me.CboDepartamento.Focus()
                    '    GoTo SALIR
                    'End If
                Else
                    MsgBox("Debe seleccionar las fechas de créditos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar una fecha válida.")
                    Me.CboDepartamento.Focus()
                    GoTo SALIR
                End If
            End If

            If Me.NomRep = EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then
                'Departamento
                If Me.CboDepartamento.SelectedIndex <= 0 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.CboDepartamento.Focus()
                    GoTo SALIR
                End If

                'Municipio
                If Me.cboMunicipio.SelectedIndex <= 0 Then
                    MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                    Me.cboMunicipio.Focus()
                    GoTo SALIR
                End If

            Else
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



            If mNomRep <> EnumReportes.GrupoCorteVencidos And mNomRep <> EnumReportes.GrupoCorte And mNomRep <> EnumReportes.DetalleSaldosCartera And mNomRep <> EnumReportes.DetalleSaldosCartera20Cordobas And mNomRep <> EnumReportes.GrupoRecupera And mNomRep <> EnumReportes.ConsolidadoEstadisticoCreditoSegunUbicacion And mNomRep <> EnumReportes.ConsolidadoMontoRecuperar And mNomRep <> EnumReportes.DetalleSaldosCarteraFechaVence Then
                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válido.")
                    Me.cdeFechaInicial.Focus()
                    GoTo salir
                End If
            End If




            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If

            If mNomRep <> EnumReportes.GrupoCorteVencidos And mNomRep <> EnumReportes.GrupoCorte And mNomRep <> EnumReportes.DetalleSaldosCartera And mNomRep <> EnumReportes.DetalleSaldosCartera20Cordobas And mNomRep <> EnumReportes.GrupoRecupera And mNomRep <> EnumReportes.ConsolidadoEstadisticoCreditoSegunUbicacion And mNomRep <> EnumReportes.ConsolidadoMontoRecuperar And mNomRep <> EnumReportes.DetalleSaldosCarteraFechaVence Then
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
            End If

            If mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPago Or mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPagoFechaVence Then


                If IsDBNull(Me.cdeFechaInicialRec.Value) Then
                    MsgBox("Debe seleccionar una fecha inicial para recibos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicialRec, "Debe seleccionar una fecha inicial para recibos.")
                    Me.cdeFechaInicialRec.Focus()
                    GoTo SALIR
                End If
                If IsDBNull(Me.CdeFechaFinalRec.Value) Then
                    MsgBox("Debe seleccionar una fecha final para recibos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinalRec, "Debe seleccionar una fecha final para recibos.")
                    Me.CdeFechaFinalRec.Focus()
                    GoTo SALIR
                End If

                If cdeFechaInicialRec.Value > CdeFechaFinalRec.Value Then
                    MsgBox("Debe seleccionar una fecha inicial de recibos menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial de recibos menor o igual que la final.")
                    Me.cdeFechaInicialRec.Focus()
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
                Case EnumReportes.ConsolidadoEstadisticoPeriodo
                    Dim NivelFiltro As Integer
                    NivelFiltro = 0
                    If cboBarrio.SelectedIndex > 0 Then
                        NivelFiltro = 4
                    Else
                        If cboDistrito.SelectedIndex > 0 Then
                            NivelFiltro = 3
                        Else
                            If cboMunicipio.SelectedIndex > 0 Then
                                NivelFiltro = 2
                            Else
                                If CboDepartamento.SelectedIndex > 0 Then
                                    NivelFiltro = 1
                                End If

                            End If
                        End If
                    End If

                    Select Case NivelFiltro
                        Case 0
                            frmVisor.Formulas("FiltroUbicacion") = "' NIVEL NACIONAL '"
                        Case 1
                            frmVisor.Formulas("FiltroUbicacion") = "' DEPARTAMENTO: " & Trim(Me.CboDepartamento.Text) & "'"
                        Case 2
                            frmVisor.Formulas("FiltroUbicacion") = "' DEPARTAMENTO: " & Trim(Me.CboDepartamento.Text) & " MUNICIPIO: " & Trim(Me.cboMunicipio.Text) & "'"
                        Case 3
                            frmVisor.Formulas("FiltroUbicacion") = "' DEPARTAMENTO: " & Trim(Me.CboDepartamento.Text) & " MUNICIPIO: " & Trim(Me.cboMunicipio.Text) & " DISTRITO: " & Trim(Me.cboDistrito.Text) & "'"
                        Case 4
                            frmVisor.Formulas("FiltroUbicacion") = "' DEPARTAMENTO: " & Trim(Me.CboDepartamento.Text) & " MUNICIPIO: " & Trim(Me.cboMunicipio.Text) & " DISTRITO: " & Trim(Me.cboDistrito.Text) & " BARRIO: " & Trim(Me.cboBarrio.Text) & " '"
                    End Select

                    frmVisor.NombreReporte = "RepSccCC32.rpt"
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@NivelFiltro") = NivelFiltro
                    frmVisor.Parametros("@StbDepartamentoID") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    frmVisor.Parametros("@StbMunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    frmVisor.Parametros("@StbDistritoID") = Me.cboDistrito.Columns("nStbDistritoID").Value
                    frmVisor.Parametros("@StbBarrioID") = Me.cboBarrio.Columns("nStbBarrioID").Value
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("RangoFechas") = "' DEL " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " AL  " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                    frmVisor.Text = "Reporte de Estadisticas Por Nivel Escolar y Edad"
                Case EnumReportes.Grupo, EnumReportes.GrupoRecupera, EnumReportes.GrupoCorte, EnumReportes.GrupoCorteVencidos, EnumReportes.ReporteDeMoraTotalizadoPorBarrios

                    'If CboDepartamento.SelectedIndex > 0 Then
                    If CboDepartamento.Text <> "Todos" Then
                        Filtro = Filtro & " {spSccReporteAvanceCartera.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCartera.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCartera.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    If mNomRep <> EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then
                        frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                        frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                        frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    End If

                    If ChkMun.Checked Then
                        frmVisor.Formulas("PorMunicipio") = 1
                    End If
                    If ChkDep.Checked Then
                        frmVisor.Formulas("PorDepartamento") = 1
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCartera.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCartera.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCartera.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        Else
                            Filtro = " {spSccReporteAvanceCartera.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCartera.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        End If
                    Else
                        If Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCartera.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            Else
                                Filtro = " {spSccReporteAvanceCartera.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCartera.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            End If
                        End If
                    End If

                    'If Me.RadSoloMercado.Checked = True Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCartera.nCooperativa} = 0"
                    '    Else
                    '        Filtro = " {spSccReporteAvanceCartera.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCartera.nCooperativa} = 0"
                    '    End If
                    'End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCartera.nStbMercadoVerificadoID} = 1 "
                        Else
                            Filtro = " {spSccReporteAvanceCartera.nStbMercadoVerificadoID}=1"
                        End If
                    End If


                    If mNomRep = EnumReportes.Grupo Then

                        If mNomRep <> EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then
                            If CboFiltroMora.SelectedIndex = 0 Then
                                frmVisor.Formulas("PresentarMora") = 1
                            Else
                                frmVisor.Formulas("PresentarMora") = 0
                            End If
                            Select Case CboFiltroMora.SelectedIndex
                                Case 0
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS VIGENTES "
                                Case 1
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe1A10Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe1A10Dias}>0"
                                    End If

                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS VIGENTES CON MORA DE 1 A 10 DIAS "
                                Case 2
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe11A20Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe11A20Dias}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS VIGENTES CON MORA DE 11 A 20 DIAS "
                                Case 3
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe21A30Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe21A30Dias}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS VIGENTES CON MORA DE 21 A 30 DIAS "
                                Case 4
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe31A40Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe31A40Dias}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS VIGENTES CON MORA DE 31 A 40 DIAS "
                                Case 5
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.Mora41DiasAMas}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.Mora41DiasAMas}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS VIGENTES CON MORA 41 DIAS A MAS "

                            End Select
                        End If

                        frmVisor.Formulas("TipoFiltro") = "'" & frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCartera.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCartera.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCartera.nFondoPresupuestario} =-1", "")))
                        Else
                            Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCartera.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCartera.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCartera.nFondoPresupuestario} =-1 ", "")))
                        End If

                        
                    End If

                    'frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"


                    frmVisor.CRVReportes.ShowRefreshButton = False


                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        If mNomRep = EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then
                            Filtro = Filtro.Replace("spSccReporteAvanceCartera", "spSccMontoColocadoRecuperadoCarteraYMora;1")
                        End If
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    If mNomRep = EnumReportes.GrupoRecupera Then

                        If (Me.RdoCooperativa.Checked Or Me.RadSoloMercado.Checked) Then
                            frmVisor.Parametros("@nCooperativa") = IIf(Me.RdoCooperativa.Checked, 1, 0)
                        Else
                            frmVisor.Parametros("@nCooperativa") = -1
                        End If

                        frmVisor.NombreReporte = "RepSccCC19.rpt"
                        frmVisor.Parametros("@TipoSalida") = 2
                        'frmVisor.Parametros("@TipoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                        If Me.RdPDIBA.Checked = True Then
                            frmVisor.Parametros("@TipoPrograma") = 3
                            frmVisor.Formulas("TipoPrograma") = 3
                        ElseIf Me.RdVentanadeGenero.Checked = True Then
                            frmVisor.Parametros("@TipoPrograma") = 2
                            frmVisor.Formulas("TipoPrograma") = 2
                        Else ' Me.RdUsuraCero.Checked = True Then
                            frmVisor.Parametros("@TipoPrograma") = 1
                            frmVisor.Formulas("TipoPrograma") = 1
                        End If
                        'frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                        frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                        frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                        frmVisor.Text = "Reporte de avance de la Recuperación de Cartera"
                        frmVisor.Formulas("DesFondo") = "'" & frmVisor.Formulas("DesFondo") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"
                    Else
                        If mNomRep = EnumReportes.Grupo Or mNomRep = EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then

                            frmVisor.NombreReporte = IIf(mNomRep = EnumReportes.Grupo, "RepSccCC18.rpt", "RepSccCC84.rpt")

                            If mNomRep = EnumReportes.Grupo Then
                                If Not (Me.RadTodos.Checked Or Me.RadSoloMercado.Checked) Then
                                    frmVisor.Parametros("@nCooperativa") = IIf(Me.RdoCooperativa.Checked, 1, 0)
                                Else
                                    frmVisor.Parametros("@nCooperativa") = -1
                                End If
                            End If

                            If mNomRep = EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then
                                frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                                frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                                frmVisor.Parametros("@MunicipioId") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                                frmVisor.Parametros("@DepartamentoId") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS " & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                            Else
                                frmVisor.Parametros("@TipoSalida") = 1
                                'frmVisor.Parametros("@TipoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                                If Me.RdPDIBA.Checked = True Then
                                    frmVisor.Parametros("@TipoPrograma") = 2
                                    frmVisor.Formulas("TipoPrograma") = 2
                                ElseIf Me.RdVentanadeGenero.Checked = True Then
                                    frmVisor.Parametros("@TipoPrograma") = 3
                                    frmVisor.Formulas("TipoPrograma") = 3
                                Else ' Me.RdUsuraCero.Checked = True Then
                                    frmVisor.Parametros("@TipoPrograma") = 1
                                    frmVisor.Formulas("TipoPrograma") = 1
                                End If
                                frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                            End If

                            frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                            frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                            frmVisor.Text = "Reporte de avance de la Mora"

                        Else

                            Select Case CboFiltroMora.SelectedIndex

                                Case 0
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "

                                Case 1
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 1 A 10 DIAS "
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe1A10Dias}>0"
                                    Else
                                        Filtro = "  {spSccReporteAvanceCartera.MoraDe1A10Dias}>0"
                                    End If

                                Case 2
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe11A20Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe11A20Dias}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 11 A 20 DIAS "

                                Case 3
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe21A30Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe21A30Dias}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 21 A 30 DIAS "

                                Case 4
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.MoraDe31A40Dias}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.MoraDe31A40Dias}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 40 DIAS "

                                Case 5
                                    If Trim(Filtro) <> "" Then
                                        Filtro = Filtro & " And {spSccReporteAvanceCartera.Mora41DiasAMas}>0"
                                    Else
                                        Filtro = " {spSccReporteAvanceCartera.Mora41DiasAMas}>0"
                                    End If
                                    frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA 41 DIAS A MAS "

                            End Select

                            frmVisor.Formulas("TipoFiltro") = "'" & frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"

                            If mNomRep = EnumReportes.GrupoCorte Then
                                frmVisor.NombreReporte = "RepSccCC60.rpt"
                                frmVisor.Parametros("@TipoSalida") = 1
                                'frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                                If Me.RdPDIBA.Checked = True Then
                                    'frmVisor.Formulas("@TipoPrograma") = 3
                                    frmVisor.Parametros("@CodigoPrograma") = 3
                                ElseIf Me.RdVentanadeGenero.Checked = True Then
                                    'frmVisor.Formulas("@TipoPrograma") = 2
                                    frmVisor.Parametros("@CodigoPrograma") = 2
                                Else ' Me.RdUsuraCero.Checked = True Then
                                    'frmVisor.Formulas("@TipoPrograma") = 1
                                    frmVisor.Parametros("@CodigoPrograma") = 1
                                End If
                                frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                                frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                                frmVisor.Text = "Reporte de avance de la Mora"
                            Else
                                frmVisor.NombreReporte = "RepSccCC61.rpt"
                                frmVisor.Parametros("@TipoSalida") = 1
                                frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                                frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                                'frmVisor.Parametros("@TipoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                                If Me.RdPDIBA.Checked = True Then
                                    'frmVisor.Formulas("@TipoPrograma") = 2
                                    frmVisor.Parametros("@TipoPrograma") = 3
                                ElseIf Me.RdVentanadeGenero.Checked = True Then
                                    'frmVisor.Formulas("@TipoPrograma") = 3
                                    frmVisor.Parametros("@TipoPrograma") = 2
                                Else ' Me.RdUsuraCero.Checked = True Then
                                    'frmVisor.Formulas("@TipoPrograma") = 1
                                    frmVisor.Parametros("@TipoPrograma") = 1
                                End If
                                frmVisor.Text = "Reporte de avance de la Mora Creditos Vencidos"
                            End If

                            If Trim(Filtro) <> "" Then
                                frmVisor.CRVReportes.SelectionFormula = Filtro
                            End If

                        End If
                    End If

                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                Case EnumReportes.DetalleSaldosCartera
                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And Me.RadSoloMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 0"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 0"
                        End If
                    Else
                        If Me.RadSoloMercado.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 0"
                            End If
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And Me.RdoCooperativa.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 1"
                        End If
                    Else
                        If Me.RdoCooperativa.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 1"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = 1"
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        End If
                    End If

                    If mNomRep = EnumReportes.Grupo Then
                        frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1", "")))
                        Else
                            Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1 ", "")))
                        End If

                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If





                    If ChkClasifica.Checked Then


                        Select CboFiltroMora.SelectedIndex
                            Case 0
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "

                            Case 1
                                frmVisor.Formulas("TipoFiltro") = "' CATEGORIA A 1-7 DIAS  "
                                'If Trim(Filtro) <> "" Then
                                '    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A7DiasN}>0  OR ( {spSccReporteAvanceCarteraSaldos.MoraDe1A7DiasN}=0  AND {spSccReporteAvanceCarteraSaldos.MoraDe8A20DiasN}=0  AND   {spSccReporteAvanceCarteraSaldos.MoraDe21A30DiasN} =0  And {spSccReporteAvanceCarteraSaldos.MoraDe31A364DiasN} =0   and {spSccReporteAvanceCarteraSaldos.Mora365DiasAmasN}=0 )"
                                'Else
                                '    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A7DiasN}>0  OR ( {spSccReporteAvanceCarteraSaldos.MoraDe1A7DiasN}=0  AND {spSccReporteAvanceCarteraSaldos.MoraDe8A20DiasN}=0  AND   {spSccReporteAvanceCarteraSaldos.MoraDe21A30DiasN} =0  And {spSccReporteAvanceCarteraSaldos.MoraDe31A364DiasN} =0   and {spSccReporteAvanceCarteraSaldos.Mora365DiasAmasN}=0 ) "
                                'End If


                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A7DiasN}>0 "
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A7DiasN}>0 "
                                End If




                            Case 2
                                frmVisor.Formulas("TipoFiltro") = "' CATEGORIA B 8-20 DIAS  "
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe8A20DiasN}>0"
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe8A20DiasN}>0"
                                End If


                            Case 3
                                frmVisor.Formulas("TipoFiltro") = "' CATEGORIA C 21-30 DIAS  "
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe21A30DiasN}>0"
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe21A30DiasN}>0"
                                End If

                            Case 4
                                frmVisor.Formulas("TipoFiltro") = "' CATEGORIA D 31-364 DIAS  "
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A364DiasN}>0"
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe31A364DiasN}>0"
                                End If




                            Case 5
                                frmVisor.Formulas("TipoFiltro") = "' CATEGORIA E CDR 365 DIAS A MAS  "
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Mora365DiasAmasN}>0"
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.Mora365DiasAmasN}>0"
                                End If



                        End Select



                    Else


                        Select Case CboFiltroMora.SelectedIndex
                            Case 0
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "

                            Case 1
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN MORA  "
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                                End If

                            Case 2
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 1 A 10 DIAS "
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                                Else
                                    Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                                End If

                            Case 3
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 11 A 20 DIAS "

                            Case 4
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 21 A 30 DIAS "

                            Case 5
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 40 DIAS "

                            Case 6
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA 41 DIAS A MAS "

                            Case 7
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA MENOR O IGUAL A 30 DIAS  "

                            Case 8
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 60 DIAS  "

                            Case 9
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 61 A 90 DIAS  "

                            Case 10
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 91 A 120 DIAS  "

                            Case 11
                                If Trim(Filtro) <> "" Then
                                    Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                                Else
                                    Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                                End If
                                frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA MAS DE 120 DIAS  "
                        End Select

                    End If



                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & _
                        IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", _
                        IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, _
                        "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), _
                        IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, _
                        "TODAS LAS FUENTES DE FINANCIAMIENTO "))

                    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"

                    'ESPECIFICANDO TIPO DE CARTERA
                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & " " & IIf(rdCTodos.Checked, "( TODOS )", IIf(rdCCDR.Checked, "( CDR )", "( NO CDR )"))

                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & "'"

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC59.rpt"

                    'frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                    If Me.RdPDIBA.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 3
                        frmVisor.Parametros("@CodigoPrograma") = 3
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 2
                        frmVisor.Parametros("@CodigoPrograma") = 2
                    Else ' Me.RdUsuraCero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 1
                        frmVisor.Parametros("@CodigoPrograma") = 1
                    End If

                    If Me.ChkClasifica.Checked Then
                        frmVisor.Formulas("TipoClasificacion") = 1

                    Else
                        frmVisor.Formulas("TipoClasificacion") = 0

                    End If



                    frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                    frmVisor.Text = "Reporte de avance de Saldos de Cartera"
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    frmVisor.Parametros("@TipoCartera") = IIf(rdCTodos.Checked, 0, IIf(rdCNoCDR.Checked, 1, 2))
                Case EnumReportes.DetalleSaldosCarteraFechaVence
                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        End If
                    Else
                        If (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        End If
                    End If
                    If mNomRep = EnumReportes.Grupo Then

                        frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1", "")))
                        Else
                            Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1 ", "")))
                        End If

                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If

                    Select Case CboFiltroMora.SelectedIndex

                        Case 0
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "
                        Case 1
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN SALDO VENCIDO  "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            End If
                        Case 2
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 1 A 10 DIAS "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            End If

                        Case 3
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 11 A 20 DIAS "
                        Case 4
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 21 A 30 DIAS "
                        Case 5
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 40 DIAS "
                        Case 6
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO 41 DIAS A MAS "

                        Case 7
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MENOR O IGUAL A 30 DIAS  "
                        Case 8
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 60 DIAS  "
                        Case 9
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 61 A 90 DIAS  "
                        Case 10
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 91 A 120 DIAS  "

                        Case 11
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MAS DE 120 DIAS  "





                    End Select
                    'frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & String.Format("{0} '", IIf(Me.radSaldoTodos.Checked, "TODOS LOS SALDOS", IIf(Me.RadMayor0.Checked, " SALDOS POSITIVOS", "SALDOS NEGATIVOS")))    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"







                    If Not Me.radTodosFecha.Checked Then
                        Filtro = IIf(String.IsNullOrEmpty(Filtro), "", Filtro + " AND ") & " {spSccReporteAvanceCarteraSaldos.Vigente} " & IIf(Me.radVencidosFecha.Checked, " > 0", " = 0")
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

                    frmVisor.NombreReporte = "RepSccCC68.rpt"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Text = "Reporte de avance de Saldos de Cartera " & IIf(Me.RadMenor0.Checked, " Negativos", " Positivos")
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    'frmVisor.Parametros("TipoVencimiento") = "' " & IIf(radTodosFecha.Checked, "TODOS LOS CREDITOS VENCIDOS Y NO VENCIDOS", IIf(radVencidosFecha.Checked, "CREDITOS VENCIDOS AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy"), "CREDITOS NO VENCIDOS AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy"))) & " '"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    'frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))

                    'frmVisor.Parametros("TipoVencimiento") = "' 00000000000000000 '"
                    frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))

                Case EnumReportes.DetalleSaldosCartera20Cordobas
                    If CboDepartamento.SelectedIndex > 0 Then

                        Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value



                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If

                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If


                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If


                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked = True Or Me.RdoCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        End If
                    Else
                        If (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            End If
                        End If
                    End If



                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        End If
                    End If
                    If mNomRep = EnumReportes.Grupo Then

                        frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1", "")))
                        Else
                            Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1 ", "")))
                        End If

                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If

                    Select Case CboFiltroMora.SelectedIndex

                        Case 0
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "
                        Case 1
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN MORA  "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            End If
                        Case 2
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 1 A 10 DIAS "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            End If

                        Case 3
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 11 A 20 DIAS "

                        Case 4
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 21 A 30 DIAS "

                        Case 5
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 40 DIAS "

                        Case 6
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA 41 DIAS A MAS "

                        Case 7
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA MENOR O IGUAL A 30 DIAS  "

                        Case 8
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 60 DIAS  "

                        Case 9
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 61 A 90 DIAS  "

                        Case 10
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 91 A 120 DIAS  "

                        Case 11
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA MAS DE 120 DIAS  "

                    End Select
                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radSaldoTodos.Checked, " SIN FILTRO DE SALDOS ", IIf(radSaldo20.Checked, " CON SALDOS <=20 CORDOBAS ", IIf(Me.RadMenor0.Checked, " CON SALDO < 0 CORDOBAS ", IIf(Me.RadMayor0.Checked, " CON SALDO >= 0 CORDOBAS ", " CON SALDOS >20 CORDOBAS "))))
                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"

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

                    'frmVisor.NombreReporte = "RepSccCC65.rpt"
                    'frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    'frmVisor.Text = "Reporte de avance de Saldos de Cartera "
                    'frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", "")) & IIf(Me.RadSoloMercado.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    'frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    'frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    'frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    'frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    'frmVisor.Parametros("@SaldoMenor") = IIf(radSaldoTodos.Checked, 0, IIf(radSaldo20.Checked, 1, 2))

                    frmVisor.NombreReporte = "RepSccCC65.rpt"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Text = "Reporte de avance de Saldos de Cartera "
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    frmVisor.Parametros("@SaldoMenor") = IIf(radSaldoTodos.Checked, 0, IIf(radSaldo20.Checked Or Me.RadMenor0.Checked, 1, 2))
                    frmVisor.Parametros("@VencidosFecha") = 0
                    frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    'frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))

                    If Me.RdPDIBA.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 3
                        frmVisor.Parametros("@CodigoPrograma") = 3
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 2
                        frmVisor.Parametros("@CodigoPrograma") = 2
                    Else ' Me.RdUsuraCero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 1
                        frmVisor.Parametros("@CodigoPrograma") = 1
                    End If

                Case EnumReportes.DetalleSaldosCartera20CordobasFechaPago
                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If

                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        End If
                    Else
                        If (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <>1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <>1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        End If
                    End If

                    If mNomRep = EnumReportes.Grupo Then
                        frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1", "")))
                        Else
                            Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1 ", "")))
                        End If

                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If

                    Select Case CboFiltroMora.SelectedIndex
                        Case 0
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "
                        Case 1
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN MORA  "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            End If
                        Case 2
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 1 A 10 DIAS "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            End If

                        Case 3
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 11 A 20 DIAS "
                        Case 4
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 21 A 30 DIAS "
                        Case 5
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 40 DIAS "
                        Case 6
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA 41 DIAS A MAS "

                        Case 7
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA MENOR O IGUAL A 30 DIAS  "
                        Case 8
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 31 A 60 DIAS  "
                        Case 9
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 61 A 90 DIAS  "
                        Case 10
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA DE 91 A 120 DIAS  "

                        Case 11
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON MORA MAS DE 120 DIAS  "

                    End Select

                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radSaldoTodos.Checked, " SIN FILTRO DE SALDOS ", IIf(radSaldo20.Checked, " CON SALDOS <=20 CORDOBAS ", " CON SALDOS >20 CORDOBAS "))
                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC66.rpt"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Text = "Reporte de avance de Saldos de Cartera "
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    frmVisor.Parametros("@FechaSolicitudChequeIni") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaSolicitudChequeFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaPagoIni") = Format(Me.cdeFechaInicialRec.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaPagoFin") = Format(Me.CdeFechaFinalRec.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    frmVisor.Parametros("@SaldoMenor") = IIf(radSaldoTodos.Checked, 0, IIf(radSaldo20.Checked, 1, 2))
                    frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)

                    'frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))
                    If Me.RdPDIBA.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 3
                        frmVisor.Parametros("@CodigoPrograma") = 3
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 2
                        frmVisor.Parametros("@CodigoPrograma") = 2
                    Else ' Me.RdUsuraCero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 1
                        frmVisor.Parametros("@CodigoPrograma") = 1
                    End If

                Case EnumReportes.DetalleSaldosCartera20CordobasFechaPagoFechaVence
                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteAvanceCarteraSaldos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraSaldos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    frmVisor.Formulas("PresentaSocia") = IIf(Me.ChkSocias.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                        End If
                    Else
                        If (Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <>1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID} <>1 And {spSccReporteAvanceCarteraSaldos.nCooperativa} = " & String.Format("{0}", IIf(Me.RdoCooperativa.Checked, "1", "0"))
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraSaldos.nStbMercadoVerificadoID}=1"
                        End If
                    End If
                    If mNomRep = EnumReportes.Grupo Then

                        frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1", "")))
                        Else
                            Filtro = IIf(RdPresupuesto.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {spSccReporteAvanceCarteraSaldos.nFondoPresupuestario} =-1 ", "")))
                        End If

                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If

                    Select Case CboFiltroMora.SelectedIndex

                        Case 0
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS  "
                        Case 1
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS SIN SALDO VENCIDO  "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}=0  And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}=0 And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}=0  And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}=0"
                            End If
                        Case 2

                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 1 A 10 DIAS "
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            Else
                                Filtro = "  {spSccReporteAvanceCarteraSaldos.MoraDe1A10Dias}>0"
                            End If

                        Case 3
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe11A20Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 11 A 20 DIAS "
                        Case 4
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe21A30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 21 A 30 DIAS "
                        Case 5
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A40Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 40 DIAS "
                        Case 6
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.Mora41DiasAMas}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO 41 DIAS A MAS "

                        Case 7
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMenoroIgual30Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MENOR O IGUAL A 30 DIAS  "
                        Case 8
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe31A60Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 31 A 60 DIAS  "
                        Case 9
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe61A90Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 61 A 90 DIAS  "
                        Case 10
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraDe91A120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO DE 91 A 120 DIAS  "

                        Case 11
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraSaldos.MoraMasde120Dias}>0"
                            End If
                            frmVisor.Formulas("TipoFiltro") = "' TODOS LOS CREDITOS CON SALDO VENCIDO MAS DE 120 DIAS  "

                    End Select

                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radSaldoTodos.Checked, " SIN FILTRO DE SALDOS ", IIf(radSaldo20.Checked, " CON SALDOS <=20 CORDOBAS ", " CON SALDOS >20 CORDOBAS "))
                    frmVisor.Formulas("TipoFiltro") = frmVisor.Formulas("TipoFiltro") & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"    '' IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & "'"

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC69.rpt"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Text = "Reporte de avance de Saldos de Cartera "
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    frmVisor.Parametros("@FechaSolicitudChequeIni") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaSolicitudChequeFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaPagoIni") = Format(Me.cdeFechaInicialRec.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaPagoFin") = Format(Me.CdeFechaFinalRec.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = IIf(CboFiltroMora.SelectedIndex > 0, 1, 0)
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    frmVisor.Parametros("@SaldoMenor") = IIf(radSaldoTodos.Checked, 0, IIf(radSaldo20.Checked, 1, 2))
                    ''frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))
                    frmVisor.Parametros("@Fuente") = IIf(Me.radFondos.Checked, IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)), IIf(Me.CboFuentes.SelectedIndex = 0, 2, -1))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, 3))

                Case EnumReportes.ConsolidadoPrestamosVencidos, EnumReportes.ReportePrestamosVencidos, EnumReportes.TotalGruposySociasAVencermensualmente

                    If mNomRep = EnumReportes.ReportePrestamosVencidos Then
                        frmVisor.Formulas("PresentarSocias") = CInt(chkPresentarSocias.Checked)
                    End If

                    If CboDepartamento.SelectedIndex > 0 Then

                        Filtro = Filtro & "{spSccReportePrestamosVencidosPorGruposPorFecha.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If

                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReportePrestamosVencidosPorGruposPorFecha.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If


                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("RangoFecha") = "' DEL " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " AL  " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                    If mNomRep = EnumReportes.ConsolidadoPrestamosVencidos Then
                        frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                        frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                        frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)
                    End If
                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If


                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And Me.RadSoloMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 0 "
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 0 "
                        End If
                    Else
                        If Me.RadSoloMercado.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID} <> 1 And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 0"
                            Else
                                Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID} <> 1 And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 0"
                            End If
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And Me.RdoCooperativa.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID} =" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 1 "
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID} =" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 1 "
                        End If
                    Else
                        If Me.RdoCooperativa.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID} <> 1 And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 1 "
                            Else
                                Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID} <> 1 And {spSccReportePrestamosVencidosPorGruposPorFecha.nCooperativa} = 1"
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nStbMercadoVerificadoID}=1"
                        End If
                    End If

                    If RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nFondoPresupuestario}=1"
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nFondoPresupuestario}=1"
                        End If

                    ElseIf Me.RdExterno.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.nFondoPresupuestario}=0"
                        Else
                            Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.nFondoPresupuestario}=0"
                        End If



                    End If

                    If mNomRep = EnumReportes.ReportePrestamosVencidos Then

                        If rdCC21Cancelados.Checked Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.Cancelado}=1"
                            Else
                                Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.Cancelado}=1"
                            End If
                        ElseIf rdCC21Morosos.Checked Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReportePrestamosVencidosPorGruposPorFecha.Cancelado}=0"
                            Else
                                Filtro = " {spSccReportePrestamosVencidosPorGruposPorFecha.Cancelado}=0"
                            End If
                        End If
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    'frmVisor.SQLQuery = " Select * From vwSccReportePrestamosVencidosPorGruposPorFecha  " & _
                    '                   " Where UltimaFechaDePago>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And UltimaFechaDePago<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "




                    'frmVisor.Formulas("DesFondo") = IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS"))



                    If mNomRep = EnumReportes.ReportePrestamosVencidos Then

                        frmVisor.NombreReporte = "RepSccCC21.rpt"
                        frmVisor.Text = "Reporte por Grupos de Creditos a vencerse"

                    ElseIf mNomRep = EnumReportes.TotalGruposySociasAVencermensualmente Then
                        frmVisor.NombreReporte = "RepSccCC77.rpt"
                        frmVisor.Text = "Totales de Grupos y Socias con Creditos a Vencerce Mensualmente"

                        If Me.radFondos.Checked Then
                            frmVisor.Formulas("DescripcionReporte") = "'" & IIf(RdTodos.Checked, "TODOS LOS FONDOS", IIf(RdPresupuesto.Checked, "FONDOS DEL PRESUPUESTO", "FONDOS EXTERNOS")) & "'"
                        Else
                            frmVisor.Formulas("DescripcionReporte") = "'" & IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ") & "'"
                        End If

                    Else
                        frmVisor.NombreReporte = "RepSccCC22.rpt"
                        frmVisor.Text = "Consolidado de Creditos a vencerse"
                    End If

                    frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, IIf(Me.RdVentanadeGenero.Checked, 2, 3))
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))

                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                Case EnumReportes.ConsolidadoEstadisticoCreditoSegunUbicacion

                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccEstadisticasCreditosRecuperacion.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccEstadisticasCreditosRecuperacion.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If

                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccEstadisticasCreditosRecuperacion.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccEstadisticasCreditosRecuperacion.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = InfoSistema.LoginName & "'"

                    If Me.RadSoloMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccEstadisticasCreditosRecuperacion.Tipo}=2"
                        Else
                            Filtro = " {spSccEstadisticasCreditosRecuperacion.Tipo}=2"
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccEstadisticasCreditosRecuperacion.Tipo}=1"
                        Else
                            Filtro = " {spSccEstadisticasCreditosRecuperacion.Tipo}=1"
                        End If
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                        frmVisor.CRVReportes.ShowRefreshButton = False
                    End If

                    frmVisor.NombreReporte = "RepSccCC34.rpt"
                    frmVisor.Text = "Reporte de Consolidado de Credito Aprobado"
                    frmVisor.Formulas("Parametros") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ")" & "(" & IIf(Me.RadTodos.Checked, "(Incluye Mercados y (Distritos y Municipios ))", IIf(Me.RadSoloMercado.Checked, "(Incluye Solo Mercados)", "(Incluye Solo (Distritos y Municipios))")) & "'"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                Case EnumReportes.ConsolidadoRecuperacion

                    frmVisor.NombreReporte = "RepSccCC51.rpt"
                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(radFuentes.Checked, IIf(CboFuentes.SelectedIndex = 0, 0, CboFuentes.Columns("nScnFuenteFinanciamientoID").Value), 0)
                    frmVisor.Parametros("@nFondoPresupuestario") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    Dim descFuente As String = IIf(Convert.ToInt16(frmVisor.Parametros("@Fuente")) <> 0, "FUENTE DE FINANCIAMIENTO: " & CboFuentes.Columns("sNombre").Value, IIf(RdTodos.Checked, "TODOS LOS FONDOS", IIf(RdPresupuesto.Checked, "FONDOS DEL PRESUPUESTO", "FONDOS EXTERNOS")))
                    frmVisor.Formulas("DesFuente") = "'" + descFuente + "'"
                    frmVisor.Text = "Reporte Total de Recuperaciones por fuente financiera "
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    'frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)
                    If Me.RdPDIBA.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 3
                        frmVisor.Parametros("@CodigoPrograma") = 3
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 2
                        frmVisor.Parametros("@CodigoPrograma") = 2
                    Else ' Me.RdUsuraCero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 1
                        frmVisor.Parametros("@CodigoPrograma") = 1
                    End If

                Case EnumReportes.ConsolidadoMontoRecuperar
                    frmVisor.NombreReporte = "RepSccCC56.rpt"
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Text = "Reporte Total de Monto a Recuperar por fuente financiera "
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                Case EnumReportes.DetalleMontoRecuperarConMora

                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("PresentaGrupo") = IIf(Me.ChkGrupo.Checked, 1, 0)
                    frmVisor.Formulas("PresentaBarrio") = IIf(Me.ChkBarrio.Checked, 1, 0)
                    frmVisor.Formulas("PresentaDistrito") = IIf(Me.ChkDistrito.Checked, 1, 0)

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And Me.RadSoloMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 0"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 0"
                        End If
                    Else
                        If Me.RadSoloMercado.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 0"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 0"
                            End If
                        End If
                    End If

                    If CboMercado.SelectedIndex > 0 And Me.RdoCooperativa.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 1"
                        End If
                    Else
                        If Me.RdoCooperativa.Checked = True Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 1"
                            Else
                                Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID} <> 1 And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nCooperativa} = 1"
                            End If
                        End If
                    End If

                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " {spSccReporteAvanceCarteraConsolidadoRecuperadoDetalle.nStbMercadoVerificadoID}=1"
                        End If
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)

                    If Me.RdPDIBA.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 3
                        frmVisor.Parametros("@CodigoPrograma") = 3
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 2
                        frmVisor.Parametros("@CodigoPrograma") = 2
                    Else ' Me.RdUsuraCero.Checked = True Then
                        'frmVisor.Formulas("@TipoPrograma") = 1
                        frmVisor.Parametros("@CodigoPrograma") = 1
                    End If

                    frmVisor.Text = "Reporte de la Recuperación de Cartera sin y con mora"
                    frmVisor.NombreReporte = "RepSccCC58.rpt"
                    frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", IIf(Me.RdoCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"

                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

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
            'CargarBarrio(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
        'HabilitarComboBarrio()

    End Sub
    Private Sub HabilitarComboMunicipio()

        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
            'Me.cboBarrio.Enabled = True
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
            'If Me.cboMunicipio.Text <> "Todos" Then
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
        'HabilitarComboBarrio()
    End Sub

    Private Sub FrmSccParametrosAvanceCartera_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub HabilitarMercado()
        If mNomRep = EnumReportes.ConsolidadoEstadisticoCreditoSegunUbicacion Then Exit Sub
        CboMercado.Enabled = IIf(Me.RadSoloMercado.Checked Or Me.RdoCooperativa.Checked, True, False)
        If CboMercado.Enabled = False Then
            CboMercado.SelectedIndex = -1
        Else
            CargarMercado(0)
        End If
    End Sub

    Private Sub FrmSccParametrosAvanceCartera_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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
                    Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
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

            If Me.mNomRep = EnumReportes.ReporteDeMoraTotalizadoPorBarrios Then
                Me.CboFiltroMora.Enabled = False
            End If

            If Me.mNomRep = EnumReportes.ReportePrestamosVencidos Then
                grpCC21.Enabled = True
                grpCC21.Visible = True
            End If

            If Me.mNomRep <> EnumReportes.Grupo And Me.mNomRep <> EnumReportes.GrupoCorteVencidos And Me.mNomRep <> EnumReportes.GrupoRecupera Then '<>CC18 <>CC19 <>CC61
                ChkMun.Visible = False
                ChkDep.Visible = False
            End If

            PresentarClasificacionCarteraUsura()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub PresentarClasificacionCarteraUsura()

        If Me.mNomRep = EnumReportes.DetalleSaldosCartera Then
            ChkClasifica.Enabled = True
            radCDR.Enabled = True
        End If
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

    Private Sub FrmSccParametrosAvanceCartera_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll

    End Sub

    Private Sub FrmSccParametrosAvanceCartera_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        grpSaldos.Enabled = False
        grpFechaRecibos.Enabled = False
        grpPrograma.Visible = False
        Select Case mNomRep
            Case EnumReportes.GrupoRecupera
                Me.Text = "Reporte de Avance de la Cartera"
                Me.cdeFechaInicial.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                CboFiltroMora.Enabled = False
                RdSinFuente.Enabled = False
                grpFondooFuente.Enabled = False
                grpPrograma.Visible = True
            Case EnumReportes.Grupo
                Me.Text = "Reporte de Recuperación de la mora"
                'Me.cdeFechaInicial.Enabled = False
                CboFiltroMora.AddItem("Todos")
                CboFiltroMora.AddItem("Mora 1 A 10 Dias")
                CboFiltroMora.AddItem("Mora 11 A 20 Dias")
                CboFiltroMora.AddItem("Mora 21 A 30 Dias")
                CboFiltroMora.AddItem("Mora 31 A 40 Dias")
                CboFiltroMora.AddItem("Mora 41 Dias a más")
                CboFiltroMora.Columns(0).Caption = "Días(Mora)"
                CboFiltroMora.SelectedIndex = 0
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                'grpFondooFuente.Enabled = False

                grpPrograma.Visible = True
            Case EnumReportes.ReportePrestamosVencidos
                ChkDistrito.Visible = False
                ChkBarrio.Visible = False
                ChkGrupo.Visible = False
                Me.Text = "Detalle de los Grupos en Vencimiento de Crédito"
                LblTotales.Visible = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                grpPrograma.Visible = True


            Case EnumReportes.ConsolidadoPrestamosVencidos
                ChkGrupo.Visible = False
                Me.Text = "Consolidado de los Grupos en Vencimiento de Crédito"
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                grpPrograma.Visible = True

            Case EnumReportes.ConsolidadoEstadisticoPeriodo
                Me.Text = "Consolidado Estadistico Por Nivel de Escolaridad y Grupo de Edad"
                RadSinMercado.Enabled = False
                RadSoloMercado.Enabled = False
                RdoCooperativa.Enabled = False
                CboMercado.Enabled = False
                ChkDistrito.Enabled = False
                ChkBarrio.Enabled = False
                ChkGrupo.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = False
            Case EnumReportes.ConsolidadoEstadisticoCreditoSegunUbicacion
                Me.Text = "Consolidado de Credito Aprobado, Recuperado y en Mora"
                RadSinMercado.Enabled = True
                RadSoloMercado.Enabled = True
                RdoCooperativa.Enabled = True
                CboMercado.Enabled = False
                ChkDistrito.Enabled = False
                ChkBarrio.Enabled = False
                ChkGrupo.Enabled = False
                Me.cdeFechaInicial.Enabled = False
                Me.cboBarrio.Enabled = False
                Me.cboDistrito.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = False
            Case EnumReportes.ConsolidadoRecuperacion
                CboDepartamento.Enabled = False
                Me.Text = "Consolidado de Recuperaciones a Nivel Nacional"
                RadSinMercado.Enabled = False
                RadSoloMercado.Enabled = False
                RdoCooperativa.Enabled = False
                CboMercado.Enabled = False
                ChkDistrito.Enabled = False
                ChkBarrio.Enabled = False
                ChkGrupo.Enabled = False
                ''Me.cdeFechaInicial.Enabled = False
                Me.cboBarrio.Enabled = False
                Me.cboDistrito.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                grpPrograma.Visible = True
            Case EnumReportes.ConsolidadoMontoRecuperar
                CboDepartamento.Enabled = False
                Me.Text = "Consolidado de Recuperaciones"
                RadSinMercado.Enabled = False
                RadSoloMercado.Enabled = False
                RdoCooperativa.Enabled = False
                CboMercado.Enabled = False
                ChkDistrito.Enabled = False
                ChkBarrio.Enabled = False
                ChkGrupo.Enabled = False
                Me.cdeFechaInicial.Enabled = False
                Me.cboBarrio.Enabled = False
                Me.cboDistrito.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                grpPrograma.Visible = True
            Case EnumReportes.DetalleMontoRecuperarConMora
                ChkDistrito.Visible = False
                ChkBarrio.Visible = False
                ChkGrupo.Visible = False
                Me.Text = "Detalle de las recuperaciones con o sin mora para los Grupos "
                LblTotales.Visible = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False
                ChkDistrito.Visible = True
                ChkBarrio.Visible = True
                ChkGrupo.Visible = True
                grpPrograma.Visible = True
            Case EnumReportes.DetalleSaldosCartera, EnumReportes.DetalleSaldosCartera20Cordobas, EnumReportes.DetalleSaldosCartera20CordobasFechaPago, EnumReportes.DetalleSaldosCarteraFechaVence, EnumReportes.DetalleSaldosCartera20CordobasFechaPagoFechaVence
                Me.Text = "Reporte de Saldo de Cartera"
                Me.cdeFechaInicial.Enabled = False
                CboFiltroMora.Enabled = False
                grpFuente.Enabled = True
                RdSinFuente.Enabled = False




    

                CargarFiltroSel()

            

                CboFiltroMora.Columns(0).Caption = "Días(Mora)"
                CboFiltroMora.SelectedIndex = 0
                CboFiltroMora.Enabled = True
                ChkSocias.Enabled = True
                If mNomRep = EnumReportes.DetalleSaldosCartera20Cordobas Or mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPago Or mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPagoFechaVence Then
                    grpSaldos.Enabled = True
                End If
                If mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Or mNomRep = EnumReportes.DetalleSaldosCartera20Cordobas Then
                    Me.RadMenor0.Enabled = True
                    Me.RadMayor0.Enabled = True
                    If mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Then
                        Me.radSaldo20.Enabled = False
                        Me.radSaldoMayor20.Enabled = False
                    End If
                    grpSaldos.Enabled = True
                End If
                If mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPago Or mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPagoFechaVence Then
                    grpFechaRecibos.Enabled = True
                    cdeFechaInicial.Enabled = True
                End If

                grpPrograma.Visible = True

            Case EnumReportes.GrupoCorte
                Me.Text = "Reporte de Recuperación de la mora con corte de fecha en recibos"
                Me.cdeFechaInicial.Enabled = False
                CboFiltroMora.AddItem("Todos")
                CboFiltroMora.AddItem("Mora 1 A 10 Dias")
                CboFiltroMora.AddItem("Mora 11 A 20 Dias")
                CboFiltroMora.AddItem("Mora 21 A 30 Dias")
                CboFiltroMora.AddItem("Mora 31 A 40 Dias")
                CboFiltroMora.AddItem("Mora 41 Dias a más")
                CboFiltroMora.Columns(0).Caption = "Días(Mora)"
                CboFiltroMora.SelectedIndex = 0
                grpFuente.Enabled = True
                Me.RdSinFuente.Enabled = False
                'CboFiltroMora.Enabled = False
                grpFondooFuente.Enabled = False
                grpPrograma.Visible = True



            Case EnumReportes.GrupoCorteVencidos
                Me.Text = "Reporte de Recuperación de la mora creditos vencidos con corte de fecha en recibos"
                Me.cdeFechaInicial.Enabled = False
                CboFiltroMora.AddItem("Todos")
                CboFiltroMora.AddItem("Mora 1 A 10 Dias")
                CboFiltroMora.AddItem("Mora 11 A 20 Dias")
                CboFiltroMora.AddItem("Mora 21 A 30 Dias")
                CboFiltroMora.AddItem("Mora 31 A 40 Dias")
                CboFiltroMora.AddItem("Mora 41 Dias a más")

                CboFiltroMora.Columns(0).Caption = "Días(Mora)"
                CboFiltroMora.SelectedIndex = 0
                grpFuente.Enabled = True
                Me.RdSinFuente.Enabled = False
                grpFondooFuente.Enabled = False
                'CboFiltroMora.Enabled = False
                grpPrograma.Visible = True


        End Select

        If mNomRep = EnumReportes.DetalleSaldosCartera Or mNomRep = EnumReportes.DetalleSaldosCartera20CordobasFechaPago Or mNomRep = EnumReportes.DetalleSaldosCarteraFechaVence Then
            grpActivos.Enabled = True
        Else
            grpActivos.Enabled = False
        End If

    End Sub


    Private Sub CargarFiltroSel()

        CboFiltroMora.ClearItems()
        CboFiltroMora.AddItem("Todos")


        'El nuevo criterio de cartera usura cero.
        If ChkClasifica.Checked Then

            CboFiltroMora.AddItem("A. Normal 1-7 días")
            CboFiltroMora.AddItem("B. Sub Normal 8-20 días")
            CboFiltroMora.AddItem("C. Deficiente 21-30 días")
            CboFiltroMora.AddItem("D. Dificil Cobro 31-364 días")
            CboFiltroMora.AddItem("E. Dificil Recuperación 365 días a más")

            ' A PARTIR DE 27/05/2015:
            'grpParticionCartera.Enabled = True

        Else
            If mNomRep <> EnumReportes.DetalleSaldosCarteraFechaVence And mNomRep <> EnumReportes.DetalleSaldosCartera20CordobasFechaPagoFechaVence Then
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

            'grpParticionCartera.Enabled = False

        End If
        CboFiltroMora.SelectedIndex = 0
    End Sub

    Private Sub grpFuente_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpFuente.Enter

    End Sub

    Private Sub FrmSccParametrosAvanceCartera_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.SizeChanged

    End Sub

    Private Sub RadioButton3_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radActivosFecha.CheckedChanged

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

    Private Sub ChkClasifica_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkClasifica.CheckedChanged
        CargarFiltroSel()
    End Sub

    Private Sub radCDR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCDR.CheckedChanged

        CboFiltroMora.SelectedIndex = 5
        'CboFiltroMora.Enabled = False

    End Sub

    Private Sub rdCTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCTodos.CheckedChanged
        CboFiltroMora.Enabled = True
    End Sub

    Private Sub rdCNoCDR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCNoCDR.CheckedChanged
        CboFiltroMora.Enabled = True
    End Sub

    Private Sub rdCCDR_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCCDR.CheckedChanged
        CboFiltroMora.Enabled = False
    End Sub

End Class