'------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                24/03/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteParametrosTesoreria.vb
' Descripción:          Este formulario permite imprimir listados de Tesorería.
'------------------------------------------------------------------------------
Public Class frmSteParametrosTesoreria

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim StrContador As String
    Dim StrCargoContador As String
    Dim StrTesorero As String

    'Listado de Reportes:
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    'Llamado Desde:
    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes:
    Public Enum EnumReportes
        ListadoRecibosMontos = 1
        ListadoRecibos = 2
        ListadoMinutasDepartamentos = 3
        ListadoConsolidadoMinutas = 4
        ListadoRecibosArqueadosNoIngresados = 5
        ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros = 6 'TE35
        ListadoPagaresSocias = 7
        GrupoPagareSocias = 8 'spSccReporteCreditosEstadoAFechaGrupoSaldo
        ListadoTE35x = 9
    End Enum

    'Nombre del Reporte:
    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdsCombos = New BOSistema.Win.XDataSet
            'Si el Listado no requiere de Mercados:
            If Me.NomRep = EnumReportes.ListadoMinutasDepartamentos Or Me.NomRep = EnumReportes.ListadoConsolidadoMinutas Or Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Or Me.NomRep = EnumReportes.ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros Or Me.NomRep = EnumReportes.ListadoTE35x Then
                Me.RadSoloMercado.Enabled = False
                Me.RadTodos.Enabled = False
                Me.RadSinMercado.Enabled = False
                Me.RadCooperativa.Enabled = False
            End If

            'Si no tiene filtro por Tipo de Programa:
            If (Me.NomRep = EnumReportes.ListadoMinutasDepartamentos) Or (Me.NomRep = EnumReportes.ListadoConsolidadoMinutas) Or (Me.NomRep = EnumReportes.ListadoPagaresSocias) Or (Me.NomRep = EnumReportes.GrupoPagareSocias) Then
                Me.CboPrograma.Enabled = False
            End If

            'Por Corte de Talonarios: 
            If (Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados) Then
                Me.grpTalonarios.Visible = True
            ElseIf (Me.NomRep = EnumReportes.ListadoRecibosMontos) Or (Me.NomRep = EnumReportes.ListadoRecibos) Then
                Me.grpTalonarios.Visible = True
                Me.grpRecibos.Visible = True
            End If

            'Filtros de Cuenta Bancaria TE17, TE24:
            If (Me.NomRep = EnumReportes.ListadoMinutasDepartamentos) Or (Me.NomRep = EnumReportes.ListadoConsolidadoMinutas) Then
                Me.lblBanco.Visible = True
                Me.cboCuenta.Visible = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/01/2010
    ' Procedure Name:       CargarTipoPrograma
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Programas.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPrograma()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion, 1 as Orden " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoDePrograma')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsCombos.ExistTable("Programa") Then
                XdsCombos("Programa").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Programa")
                XdsCombos("Programa").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboPrograma.DataSource = XdsCombos("Programa").Source

            Me.CboPrograma.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("Orden").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.CboPrograma.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.CboPrograma.Columns("sCodigoInterno").Caption = "Código"
            Me.CboPrograma.Columns("sDescripcion").Caption = "Descripción"

            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboPrograma.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboPrograma.ListCount > 0 Then
                XdsCombos("Programa").AddRow()
                XdsCombos("Programa").ValueField("sDescripcion") = "Todos"
                XdsCombos("Programa").ValueField("nStbValorCatalogoID") = -19
                XdsCombos("Programa").ValueField("Orden") = 0
                XdsCombos("Programa").UpdateLocal()
                XdsCombos("Programa").Sort = "Orden, sCodigoInterno asc"
                Me.CboPrograma.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/05/2010
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de Cuentas
    '                       Bancarias en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarCuenta()
        Try
            Dim Strsql As String


            Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sNombreCuenta, 1 as Orden  " & _
                     " From vwSteCtaBancaria a " & _
                     " WHERE (a.nCerrada = 0)" & _
                     " Order by a.sNumeroCuenta Asc"

            If XdsCombos.ExistTable("Cuenta") Then
                XdsCombos("Cuenta").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Cuenta")
                XdsCombos("Cuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCuenta.DataSource = XdsCombos("Cuenta").Source

            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("Orden").Visible = False

            'Configurar el combo: 
            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 100
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").Width = 150
            Me.cboCuenta.Columns("sNumeroCuenta").Caption = "No. Cuenta"
            Me.cboCuenta.Columns("sNombreCuenta").Caption = "Nombre Cuenta"
            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
            If Me.cboCuenta.ListCount > 0 Then
                XdsCombos("Cuenta").AddRow()
                XdsCombos("Cuenta").ValueField("sNumeroCuenta") = "Todas"
                XdsCombos("Cuenta").ValueField("nSteCuentaBancariaID") = -19
                XdsCombos("Cuenta").ValueField("Orden") = 0
                XdsCombos("Cuenta").UpdateLocal()
                XdsCombos("Cuenta").Sort = "Orden, sNumeroCuenta asc"
                Me.cboCuenta.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            If XdsCombos.ExistTable("Departamento") Then
                XdsCombos("Departamento").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Departamento")
                XdsCombos("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.CboDepartamento.DataSource = XdsCombos("Departamento").Source
            Me.CboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.CboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo:
            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.CboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.CboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboDepartamento.ListCount > 0 Then
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Municipios en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer)
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

            'Asignando a las fuentes de datos:
            Me.cboMunicipio.DataSource = XdsCombos("Municipio").Source
            Me.cboMunicipio.Rebind()
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo:
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

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Distritos en el combo para su selección.
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

            'Asignando a las fuentes de datos:
            Me.cboDistrito.DataSource = XdsCombos("Distrito").Source
            Me.cboDistrito.Rebind()

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 157

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       CargarMercado
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Mercados en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMercado(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String
            Dim CadWhere As String

            Me.CboMercado.ClearFields()
            CadWhere = ""
            If Me.CboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where dbo.StbDepartamento.nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If

            If Me.cboDistrito.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbDistrito.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
            End If

            If Me.RadCooperativa.Checked Or Me.RadSoloMercado.Checked Then
                CadWhere = CadWhere & " And dbo.StbMercado.nCooperativa = " & String.Format("{0}", IIf(Me.RadCooperativa.Checked, 1, 0))
            End If

            If intLimpiarID = 0 Then
                Strsql = " Select dbo.StbMercado.nStbMercadoID,dbo.StbMercado.sCodigo ,dbo.StbMercado.sNombre , 1 As Orden " & _
                         " FROM dbo.StbBarrio INNER JOIN " & _
                         " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                         " dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID INNER JOIN " & _
                         " dbo.StbDistrito ON dbo.StbBarrio.nStbDistritoID = dbo.StbDistrito.nStbDistritoID INNER JOIN " & _
                         " dbo.StbMercado ON dbo.StbBarrio.nStbBarrioID = dbo.StbMercado.nStbBarrioID " & _
                         CadWhere & " Order BY dbo.StbDepartamento.nStbDepartamentoID , dbo.StbMunicipio.nStbMunicipioID, dbo.StbDistrito.nStbDistritoID,dbo.StbMercado.nStbMercadoID "
            Else
                Strsql = " Select dbo.StbMercado.nStbMercadoID,dbo.StbMercado.sCodigo , dbo.StbMercado.sNombre , 1 As Orden " & _
                         " FROM dbo.StbBarrio INNER JOIN " & _
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

            'Asignando a las fuentes de datos:
            Me.CboMercado.DataSource = XdsCombos("Mercado").Source
            Me.CboMercado.Rebind()

            Me.CboMercado.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.CboMercado.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboMercado.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
            Me.CboMercado.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.CboMercado.Splits(0).DisplayColumns("SNombre").Width = 80

            Me.CboMercado.Columns("sCodigo").Caption = "Código"
            Me.CboMercado.Columns("sNombre").Caption = "Nombre "

            Me.CboMercado.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboMercado.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            XdsCombos("Mercado").AddRow()
            XdsCombos("Mercado").ValueField("sNombre") = "Todos"
            XdsCombos("Mercado").ValueField("nStbMercadoID") = -19
            XdsCombos("Mercado").ValueField("Orden") = 0
            XdsCombos("Mercado").UpdateLocal()
            XdsCombos("Mercado").Sort = "Orden,sCodigo asc"
            Me.CboMercado.SelectedIndex = 0

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       ValidarParametros
    ' Descripción:          Este procedimiento permite validar los parámetros
    '                       de corte indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        'Dim fecha1 As Date
        'Dim fecha2 As Date
        'Dim DiasentreRango As Integer
        Try
            'fecha1 = CDate(Format(cdeFechaInicial.Value, "yyyy-MM-dd"))
            'fecha2 = CDate(Format(CdeFechaFinal.Value, "yyyy-MM-dd"))
            'DiasentreRango = DateDiff(DateInterval.Day, fecha1, fecha2)

            VbResultado = False
            Me.errParametro.Clear()

            'Cuenta Bancaria:
            If (Me.NomRep = EnumReportes.ListadoMinutasDepartamentos) Or (Me.NomRep = EnumReportes.ListadoConsolidadoMinutas) Then
                If Me.cboCuenta.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar una Cuenta válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta válida.")
                    Me.cboCuenta.Focus()
                    GoTo SALIR
                End If
            End If

            'Departamento:
            If Me.CboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.CboDepartamento.Focus()
                GoTo SALIR
            End If

            'Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                GoTo SALIR
            End If

            'Distrito:
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                GoTo SALIR
            End If

            'Mercado (Si se indicó corte por Mercado):
            If Me.RadSoloMercado.Checked = True And Me.CboMercado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Mercado válido .", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboMercado, "Debe seleccionar un Mercado válido.")
                Me.CboMercado.Focus()
                GoTo SALIR
            End If

            'Tipo de Programa: 
            If Me.CboPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Programa válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboPrograma, "Debe seleccionar un Programa válido.")
                Me.CboPrograma.Focus()
                GoTo SALIR
            End If

            'If Me.NomRep <> EnumReportes.GrupoPagareSocias Then
            'Fecha de Inicio:
            If IsDBNull(cdeFechaInicial.Value) Then
                MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If
            'End If
            'Fecha de Corte:
            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If

            'If Me.NomRep = EnumReportes.GrupoPagareSocias Then
            'Fecha de Corte no menor:
            If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If
            'End If
            ''Rango de Fecha no mayor a 30 Dias
            'If DiasentreRango > 30 Then
            '    MsgBox("El Rango de Fecha No Debe Ser Mayor de 30 Días.", MsgBoxStyle.Critical, NombreSistema)
            '    Me.errParametro.SetError(Me.cdeFechaInicial, "El Rango de Fecha No Debe Ser Mayor de 30 Días.")
            '    Me.CdeFechaFinal.Focus()
            '    GoTo SALIR
            'End If

            'Si es Listados de Recibos Arqueados aún no Ingresados en Crédito (sólo un día):
            If Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Or Me.NomRep = EnumReportes.ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros Then
                REM Ampliación de rango Solicitado por Jimmy Alvarado: Memo 09 Marzo 2009.
                REM If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 0 Then
                If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a 31 días.", MsgBoxStyle.Information)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Imposible seleccionar cortes de fecha superiores a 31 días.")
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                16/05/2008
    ' Procedure Name:       cmdAceptar_Click
    ' Descripción:          Este procedimiento permite generar el reporte
    '                       indicado por el usuario.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim CadSql As String
        Dim StrSql As String
        Try

            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""

            frmVisor.WindowState = FormWindowState.Maximized

            'Si es el Listado o el Consolidado de Minutas:
            If Me.NomRep = EnumReportes.ListadoMinutasDepartamentos Or Me.NomRep = EnumReportes.ListadoConsolidadoMinutas Then
                '1. Si se indicó un Departamento en particular:
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro = Filtro & " {vwSteMinutaDepartamentos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                '2. Si se indicó un Municipio en particular:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteMinutaDepartamentos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = "{vwSteMinutaDepartamentos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If
                '3. Si se indico una Cuenta Bancaria:
                If cboCuenta.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteMinutaDepartamentos.nSteCuentaBancariaID}=" & Me.cboCuenta.Columns("nSteCuentaBancariaID").Value
                    Else
                        Filtro = "{vwSteMinutaDepartamentos.nSteCuentaBancariaID}=" & Me.cboCuenta.Columns("nSteCuentaBancariaID").Value
                    End If
                End If
                '4. Entre el Rango de Fechas de Corte Indicadas:  
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteMinutaDepartamentos.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteMinutaDepartamentos.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteMinutaDepartamentos.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteMinutaDepartamentos.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If

                'Si es el Listado de Pagares Socias:
            ElseIf Me.NomRep = EnumReportes.ListadoPagaresSocias Then
                '1. Si se indicó un Departamento en particular:
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro = Filtro & " {vwSccPagaresSocias.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                '2. Si se indicó un Municipio en particular:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSccPagaresSocias.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = "{vwSccPagaresSocias.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If
                '3. Entre el Rango de Fechas de Corte Indicadas (Filtro por Fecha de Notificación del Crédito):  
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSccPagaresSocias.dFechaSesion} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSccPagaresSocias.dFechaSesion} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSccPagaresSocias.dFechaSesion} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSccPagaresSocias.dFechaSesion} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
                '4. Filtro por Tipo de Fondos:
                If Me.RadSinMercado.Checked Then 'Fondos Presupuesto
                    Filtro = Filtro & " And {vwSccPagaresSocias.nFondoPresupuestario} = 1"
                ElseIf Me.RadSoloMercado.Checked Then  'Fondos Externos
                    Filtro = Filtro & " And {vwSccPagaresSocias.nFondoPresupuestario} = 0"
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Then
                '1. Si se indicó un Departamento en particular:
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro = Filtro & " nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    'Filtro = Filtro & " {vwSteRecibosArqueadosNoIngresados.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                '2. Si se indicó un Municipio en particular:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = "nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'Filtro = "{vwSteRecibosArqueadosNoIngresados.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If
                '3. Entre el Rango de Fechas de Corte Indicadas:  
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And dFechaArqueo>=CONVERT(DATETIME,''" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'')"
                    'Filtro = Filtro & " And dFechaArqueo>=#" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " dFechaArqueo>=CONVERT(DATETIME,''" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'')"
                    'Filtro = " dFechaArqueo>=#" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    'Filtro = " {vwSteRecibosArqueadosNoIngresados.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And dFechaArqueo<=CONVERT(DATETIME,''" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'')"
                    'Filtro = Filtro & " And dFechaArqueo<= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " dFechaArqueo<=CONVERT(DATETIME,''" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'')"
                    'Filtro = " dFechaArqueo<= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    'Filtro = " {vwSteRecibosArqueadosNoIngresados.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                '4. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And nStbTipoProgramaID=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                        'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " nStbTipoProgramaID=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                        'Filtro = Filtro & " {vwSteRecibosArqueadosNoIngresados.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If
                '5. Para el Número de Talonario:
                If Me.RdMIFIC.Checked = True Then
                    Filtro = Filtro & " And nCodigoTalonario = 0"
                    'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.nCodigoTalonario} = 0"
                Else
                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And nCodigoTalonario = 1"
                        'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.nCodigoTalonario} = 1"
                    Else 'A partir de: 01/febrero/2011 
                        Filtro = Filtro & " And nCodigoTalonario = 2"
                        'Filtro = Filtro & " And {vwSteRecibosArqueadosNoIngresados.nCodigoTalonario} = 2"
                    End If
                End If

                '*********************************************************************************************************************************************************'
                ''''''''Aca la Modificacion''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
                '*********************************************************************************************************************************************************'

            ElseIf Me.NomRep = EnumReportes.ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros Then

                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            ElseIf Me.NomRep = EnumReportes.ListadoTE35x Then

                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            Else
                If Me.NomRep <> EnumReportes.GrupoPagareSocias Then
                    '1. Si se indicó un Departamento en particular: 
                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {vwSteListadoRecibosArqueoRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    End If
                    '2. Si se indicó un Municipio en particular:
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSteListadoRecibosArqueoRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If
                    '3. Si se indicó un Distrito en Particular:
                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {vwSteListadoRecibosArqueoRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    '4. Si se indicó un Mercado en Particular:
                    If CboMercado.SelectedIndex > 0 And (Me.RadSoloMercado.Checked Or Me.RadCooperativa.Checked) Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {vwSteListadoRecibosArqueoRep.nCooperativa} = " & IIf(Me.RadCooperativa.Checked, 1, 0)
                        Else
                            Filtro = " {vwSteListadoRecibosArqueoRep.nStbMercadoID}=" & Me.CboMercado.Columns("nStbMercadoID").Value & " And {vwSteListadoRecibosArqueoRep.nCooperativa} = " & IIf(Me.RadCooperativa.Checked, 1, 0)
                        End If
                    Else '5. Si sólo se desean mostrar los Mercados:
                        If (Me.RadSoloMercado.Checked Or Me.RadCooperativa.Checked) Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nStbMercadoID} <> 1 And {vwSteListadoRecibosArqueoRep.nCooperativa} = " & IIf(Me.RadCooperativa.Checked, 1, 0)
                            Else
                                Filtro = " {vwSteListadoRecibosArqueoRep.nStbMercadoID} <> 1 And {vwSteListadoRecibosArqueoRep.nCooperativa} = " & IIf(Me.RadCooperativa.Checked, 1, 0)
                            End If
                        End If
                    End If

                    '6. Si se desean excluir los Mercados:
                    If Me.RadSinMercado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nStbMercadoID} = 1"
                        Else
                            Filtro = " {vwSteListadoRecibosArqueoRep.nStbMercadoID} = 1"
                        End If
                    End If

                    '7. Entre el Rango de Fechas de Corte Indicadas:
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = " {vwSteListadoRecibosArqueoRep.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = " {vwSteListadoRecibosArqueoRep.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    End If

                    '8. TE12: Arqueos de Caja Cerrados (por nueva columna de Minuta de Depósito). 
                    If (Me.NomRep = EnumReportes.ListadoRecibosMontos) Then
                        Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.sCodEstado} = '2'"
                    End If

                    '9. Para TE12 y TE15:
                    If (Me.NomRep = EnumReportes.ListadoRecibosMontos) Or (Me.NomRep = EnumReportes.ListadoRecibos) Then
                        'Para el Programa:
                        If CboPrograma.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                            Else
                                Filtro = Filtro & " {vwSteListadoRecibosArqueoRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                            End If
                        End If
                        'Para el Número de Talonario:
                        If Me.RdMIFIC.Checked = True Then
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nCodigoTalonario} = 0"
                        Else
                            If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                                Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nCodigoTalonario} = 1"
                            Else 'A partir de: 01/febrero/2011 BFP
                                Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nCodigoTalonario} = 2"
                            End If
                        End If
                        'Para Recibos Manuales o Automaticos:
                        If Me.RadManuales.Checked Then 'Fondos Presupuesto
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nSccReciboOficialCajaID} = 0"
                        ElseIf Me.RadAutomaticos.Checked Then  'Fondos Externos
                            Filtro = Filtro & " And {vwSteListadoRecibosArqueoRep.nSccReciboOficialCajaID} <> 0"
                        End If
                    End If
                End If
            End If

            'Asignación del Filtro indicado: 
            Me.Cursor = Cursors.WaitCursor

            If Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Then
                'frmVisor.SQLQuery = "spSteTE27 '" & Trim(Filtro) & "'"
            Else
                If Trim(Filtro) <> "" Then
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                End If
            End If

            'Listado de Recibos por Fecha de Arqueo:
            If mNomRep = EnumReportes.ListadoRecibosMontos Then
                frmVisor.NombreReporte = "RepSteTE12.rpt"
                frmVisor.Text = "Listado de Recibos y Montos por Fecha de Arqueo"
                If Me.RadManuales.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE RECIBOS MANUALES Y MONTOS ARQUEADOS (Arqueos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & ")'"
                ElseIf Me.RadAutomaticos.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE RECIBOS AUTOMATICOS Y MONTOS ARQUEADOS (Arqueos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & ")'"
                Else
                    frmVisor.Formulas("Titulo") = "'LISTADO DE RECIBOS Y MONTOS ARQUEADOS (Arqueos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & ")'"
                End If
                frmVisor.Formulas("Parametro") = "'Parámetros: (Depto.: " & Me.CboDepartamento.Text & ") (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") " & IIf(RadSinMercado.Checked, " (Sin incluir Mercados y Cooperativas)", IIf(Me.RadSoloMercado.Checked, " (Solo Mercados)", IIf(Me.RadCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RadCooperativa.Checked, " (" & Me.CboMercado.Text & ")", "") & " '"

            ElseIf mNomRep = EnumReportes.ListadoRecibos Then
                frmVisor.NombreReporte = "RepSteTE15.rpt"
                frmVisor.Text = "Listado de Recibos por Fecha de Arqueo"
                If Me.RadManuales.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE RECIBOS MANUALES ARQUEADOS (Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & ")'"
                ElseIf Me.RadAutomaticos.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE RECIBOS AUTOMATICOS ARQUEADOS (Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & ")'"
                Else
                    frmVisor.Formulas("Titulo") = "'LISTADO DE RECIBOS ARQUEADOS (Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & ")'"
                End If

                frmVisor.Formulas("Parametro") = "'Parámetros: (Depto.: " & Me.CboDepartamento.Text & ") (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") " & IIf(RadSinMercado.Checked, " (Sin incluir Mercados y Cooperativas)", IIf(Me.RadSoloMercado.Checked, " (Solo Mercados)", IIf(Me.RadCooperativa.Checked, "(Solo Cooperativas)", ""))) & IIf(Me.RadSoloMercado.Checked Or Me.RadCooperativa.Checked, " (" & Me.CboMercado.Text & ")", "") & " '"

            ElseIf mNomRep = EnumReportes.ListadoMinutasDepartamentos Then
                frmVisor.NombreReporte = "RepSteTE17.rpt"
                frmVisor.Text = "Listado de Minutas por Fecha de Depósito"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                EncuentraParametros()
                'Entregado Por:
                frmVisor.Formulas("Tesorero") = "'" & StrTesorero & "'"
                'Recibido Por:
                frmVisor.Formulas("Contador") = "'" & StrContador & "'"
                frmVisor.Formulas("CargoContador") = "'" & StrCargoContador & "'"

            ElseIf mNomRep = EnumReportes.ListadoConsolidadoMinutas Then
                frmVisor.NombreReporte = "RepSteTE24.rpt"
                frmVisor.Text = "Listado Consolidado de Minutas de Depósito"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                EncuentraParametros()
                'Entregado Por:
                frmVisor.Formulas("Tesorero") = "'" & StrTesorero & "'"
                'Recibido Por: 
                frmVisor.Formulas("Contador") = "'" & StrContador & "'"
                frmVisor.Formulas("CargoContador") = "'" & StrCargoContador & "'"

            ElseIf mNomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Then
                frmVisor.NombreReporte = "RepSteTE27.rpt"
                frmVisor.Text = "Listado de Recibos Arqueados no ingresados en Crédito"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                frmVisor.Formulas("Parametro") = "'Parámetros: (Depto.: " & Me.CboDepartamento.Text & ") (Munic.: " & Me.cboMunicipio.Text & ")'"



                frmVisor.Parametros("@FechaIni") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                If CboDepartamento.SelectedIndex > -1 And CboDepartamento.Text = "Todos" Then
                    frmVisor.Parametros("@nStbDepartamentoID") = "0"
                Else
                    frmVisor.Parametros("@nStbDepartamentoID") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If

                If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text = "Todos" Then
                    frmVisor.Parametros("@nStbMunicipioID") = "0"
                Else
                    frmVisor.Parametros("@nStbMunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                End If

                If CboPrograma.SelectedIndex > 0 Then
                    frmVisor.Parametros("@nStbTipoProgramaID") = Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                Else
                    frmVisor.Parametros("@nStbTipoProgramaID") = "0"
                End If

                If Me.RdMIFIC.Checked = True Then
                    frmVisor.Parametros("@nCodigoTalonario") = "0"
                Else
                    If Me.RdUsura.Checked = True Then
                        frmVisor.Parametros("@nCodigoTalonario") = "1"
                    Else
                        If RdBfp.Checked Then
                            frmVisor.Parametros("@nCodigoTalonario") = "2"
                        Else
                            If RdUsuraCero.Checked Then
                                frmVisor.Parametros("@nCodigoTalonario") = "3"
                            End If
                        End If


                        End If
                End If











            ElseIf mNomRep = EnumReportes.ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros Then
                If CboDepartamento.SelectedIndex = 0 Or Me.CboDepartamento.Text = "Todos" Then
                    StrSql = "{vwSteArqueoConsolidadoCajeros.dFechaArqueo}>= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSteArqueoConsolidadoCajeros.dFechaArqueo}<= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                Else
                    StrSql = "{vwSteArqueoConsolidadoCajeros.dFechaArqueo}>= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSteArqueoConsolidadoCajeros.dFechaArqueo}<= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "# and {vwSteArqueoConsolidadoCajeros.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                If CboPrograma.SelectedIndex > 0 Then
                    StrSql = StrSql & " And {vwSteArqueoConsolidadoCajeros.nStbTipoProgramaID}= " & Me.CboPrograma.Columns("nStbvalorcatalogoID").Value
                End If
                '2. Si se indicó un Municipio en particular:
                If cboMunicipio.SelectedIndex > 0 Then
                    StrSql = StrSql & " And {vwSteArqueoConsolidadoCajeros.nStbMunicipioID}= " & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                End If
                frmVisor.RegistrosSeleccion = StrSql
                frmVisor.NombreReporte = "RepSteTE35.rpt"
                frmVisor.Text = "Conciliación de Efectivo vs Arqueo de Documentos y Minutas"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

            ElseIf mNomRep = EnumReportes.ListadoTE35x Then
                If CboDepartamento.SelectedIndex = 0 Or Me.CboDepartamento.Text = "Todos" Then
                    StrSql = "{vwSteArqueoConsolidadoCajeros.dFechaArqueo}>= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSteArqueoConsolidadoCajeros.dFechaArqueo}<= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                Else
                    StrSql = "{vwSteArqueoConsolidadoCajeros.dFechaArqueo}>= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSteArqueoConsolidadoCajeros.dFechaArqueo}<= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "# and {vwSteArqueoConsolidadoCajeros.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                If CboPrograma.SelectedIndex > 0 Then
                    StrSql = StrSql & " And {vwSteArqueoConsolidadoCajeros.nStbTipoProgramaID}= " & Me.CboPrograma.Columns("nStbvalorcatalogoID").Value
                End If
                '2. Si se indicó un Municipio en particular:
                If cboMunicipio.SelectedIndex > 0 Then
                    StrSql = StrSql & " And {vwSteArqueoConsolidadoCajeros.nStbMunicipioID}= " & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                End If
                frmVisor.RegistrosSeleccion = StrSql
                frmVisor.NombreReporte = "RepSteTE35x.rpt"
                frmVisor.Text = "Conciliación de Efectivo vs Arqueo de Documentos y Minutas"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

            ElseIf mNomRep = EnumReportes.ListadoPagaresSocias Then
                frmVisor.NombreReporte = "RepSccCC64.rpt"
                frmVisor.Text = "Listado de Pagarés Socias"
                frmVisor.Formulas("RangoFechas") = "' Resolución de Créditos del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                If Me.RadTodos.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE PAGARES DE CREDITOS APROBADOS'"
                ElseIf Me.RadSinMercado.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE PAGARES DE CREDITOS APROBADOS (FONDOS PRESUPUESTO)'"
                ElseIf Me.RadSoloMercado.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE PAGARES DE CREDITOS APROBADOS (FONDOS EXTERNOS)'"
                End If

            ElseIf mNomRep = EnumReportes.GrupoPagareSocias Then
                frmVisor.NombreReporte = "RepSccCC70.rpt"
                frmVisor.Text = "Listado de  Pagarés por Grupos"
                frmVisor.Formulas("Parametros") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ")'"
                frmVisor.Parametros("@Fuente") = IIf(RadSinMercado.Checked, 1, IIf(RadSoloMercado.Checked, 0, -1))

                frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)

                If Me.RadTodos.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE PAGARES DE CREDITOS APROBADOS"
                ElseIf Me.RadSinMercado.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE PAGARES DE CREDITOS APROBADOS (FONDOS PRESUPUESTO)"
                ElseIf Me.RadSoloMercado.Checked Then
                    frmVisor.Formulas("Titulo") = "'LISTADO DE PAGARES DE CREDITOS APROBADOS (FONDOS EXTERNOS)"
                End If

                If Me.RadVigente.Checked = True Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {spSccReporteCreditosEstadoAFechaGrupoSaldo.RestaApagar}>0"
                    Else
                        Filtro = "  {spSccReporteCreditosEstadoAFechaGrupoSaldo.RestaApagar}>0"
                    End If
                    frmVisor.Formulas("Titulo") = frmVisor.Formulas("Titulo") & " SALDOS MAYOR QUE CERO"
                Else
                    If RadCancelado.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteCreditosEstadoAFechaGrupoSaldo.RestaApagar}<=0"
                        Else
                            Filtro = "  {spSccReporteCreditosEstadoAFechaGrupoSaldo.RestaApagar}<=0"
                        End If
                        frmVisor.Formulas("Titulo") = frmVisor.Formulas("Titulo") & " SALDOS MENOR IGUAL QUE CERO"
                    End If

                End If
                frmVisor.Formulas("Titulo") = frmVisor.Formulas("Titulo") & "'"

                If Trim(Filtro) <> "" Then
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                End If

                frmVisor.Formulas("Parametro") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & " )" & IIf(RadSinMercado.Checked, " (Sin incluir Mercados )", IIf(Me.RadSoloMercado.Checked, "(Solo Mercados)", "")) & IIf(Me.RadSoloMercado.Checked, "(" & Me.CboMercado.Text & ")", "") & " '"

            End If

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	12/08/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Tesorero y Contador General.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            'Contador General:
            Strsql = "SELECT vwStbEmpleado.sTitulo + '. ' + vwStbEmpleado.sNombre AS Nombre FROM StbValorParametro INNER JOIN vwStbEmpleado ON StbValorParametro.sValorParametro = vwStbEmpleado.nSrhEmpleadoID WHERE (StbValorParametro.nStbValorParametroID = 35)"
            StrContador = XcDatos.ExecuteScalar(Strsql)

            Strsql = "SELECT SrhCargo.sNombreCargo " & _
                     "FROM SrhEmpleado INNER JOIN SrhCargo ON SrhEmpleado.nSrhCargoID = SrhCargo.nSrhCargoID INNER JOIN StbValorParametro ON SrhEmpleado.nSrhEmpleadoID = StbValorParametro.sValorParametro " & _
                     "WHERE (StbValorParametro.nStbValorParametroID = 35)"
            StrCargoContador = XcDatos.ExecuteScalar(Strsql)

            'Tesorero:
            Strsql = "SELECT vwStbEmpleado.sTitulo + '. ' + vwStbEmpleado.sNombre AS Nombre FROM StbValorParametro INNER JOIN vwStbEmpleado ON StbValorParametro.sValorParametro = vwStbEmpleado.nSrhEmpleadoID WHERE (StbValorParametro.nStbValorParametroID = 34)"
            StrTesorero = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este procedimiento permite salir de la Interfaz
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       CboDepartamento_TextChanged
    ' Descripción:          Al cambiar Departamento.
    '-------------------------------------------------------------------------
    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.TextChanged
        If Me.CboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       HabilitarComboMunicipio
    ' Descripción:          Habilitar Combo Municipio.
    '-------------------------------------------------------------------------
    Private Sub HabilitarComboMunicipio()
        'If Me.NomRep = EnumReportes.ListadoMinutasDepartamentos Then
        '    Me.cboMunicipio.Enabled = False
        'Else
        If Me.CboDepartamento.SelectedIndex > 0 Then 'And Me.NomRep <> EnumReportes.ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros
            Me.cboMunicipio.Enabled = True
            If Me.cboMunicipio.Text = "Todos" Then
                HabilitarMercado()
            Else
                HabilitarMercado()
            End If
        Else
            Me.cboMunicipio.Enabled = False
            HabilitarMercado()
        End If
        'End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       cboMunicipio_TextChanged
    ' Descripción:          Al cambiar Municipio.
    '-------------------------------------------------------------------------
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                CargarMercado(0)
                'Si es el Listado o Consolidado de Minutas bloquear Distrito:
                If Me.NomRep = EnumReportes.ListadoMinutasDepartamentos Or Me.NomRep = EnumReportes.ListadoConsolidadoMinutas Or Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Or Me.NomRep = EnumReportes.ListadoPagaresSocias Then
                    Me.cboDistrito.Enabled = False
                Else
                    Me.cboDistrito.Enabled = True
                End If
                HabilitarMercado()
            Else
                CargarDistrito(0)
                Me.cboDistrito.Enabled = False
            End If
            CargarMercado(0)
        Else
            CargarDistrito(1)
            CargarMercado(1)
        End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       frmSteParametrosTesoreria_FormClosing
    ' Descripción:          Al cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteParametrosTesoreria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       HabilitarMercado
    ' Descripción:          Habilitar Combo de Mercado.
    '-------------------------------------------------------------------------
    Private Sub HabilitarMercado()
        'Si es Listado o Consolidado de Minutas bloquear Mercado:
        If Me.NomRep = EnumReportes.ListadoMinutasDepartamentos Or Me.NomRep = EnumReportes.ListadoConsolidadoMinutas Or Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Or Me.NomRep = EnumReportes.ListadoConciliaciondeEfectivovrsArqueoyMinutasporCajeros Or Me.NomRep = EnumReportes.ListadoTE35x Or Me.NomRep = EnumReportes.ListadoPagaresSocias Then
            CboMercado.Enabled = False
        Else
            CboMercado.Enabled = IIf(Me.RadSoloMercado.Checked = True Or RadCooperativa.Checked, True, False)
            If CboMercado.Enabled = False Then
                CboMercado.SelectedIndex = -1
            Else
                CargarMercado(0)
            End If
        End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       frmSteParametrosTesoreria_Load
    ' Descripción:          Al cargar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteParametrosTesoreria_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            If Me.NomRep = EnumReportes.ListadoPagaresSocias Or Me.NomRep = EnumReportes.GrupoPagareSocias Then
                ObjGUI.SetFormLayout(Me, "Verde")
                Me.RadSinMercado.Text = "Fondos Presupuesto"
                Me.RadSoloMercado.Text = "Fondos Externos"
            Else
                ObjGUI.SetFormLayout(Me, "Naranja")
                Me.RadSinMercado.Text = "No Aplica"
                Me.RadSoloMercado.Text = "Solo Mercados"
            End If

            If Me.NomRep = EnumReportes.GrupoPagareSocias Then
                grpTipoCredito.Enabled = True

            Else
                grpTipoCredito.Enabled = False
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            CargarTipoPrograma()
            CargarCuenta()
            HabilitarComboMunicipio()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/03/2008
    ' Procedure Name:       cboDistrito_TextChanged
    ' Descripción:          Al carbiar Distrito.
    '-------------------------------------------------------------------------
    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex > -1 Then
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

    Private Sub FrmSccParametrosAvanceCartera_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.NomRep = EnumReportes.ListadoRecibosMontos Then
            Me.Text = "Listado de Recibos y Montos por Fecha de Arqueo"
        ElseIf Me.NomRep = EnumReportes.ListadoRecibos Then
            Me.Text = "Listado de Recibos por Fecha de Arqueo"
        ElseIf Me.NomRep = EnumReportes.ListadoMinutasDepartamentos Then
            Me.Text = "Listado de Minutas por Fecha de Depósito"
        ElseIf Me.NomRep = EnumReportes.ListadoConsolidadoMinutas Then
            Me.Text = "Listado Consolidado de Minutas"
        ElseIf Me.NomRep = EnumReportes.ListadoRecibosArqueadosNoIngresados Then
            Me.Text = "Listado Recibos Arqueados aún No Ingresados"
        ElseIf Me.NomRep = EnumReportes.ListadoPagaresSocias Then
            Me.Text = "Listado Pagarés Socias"
        ElseIf Me.NomRep = EnumReportes.GrupoPagareSocias Then
            Me.Text = "Listado de Grupos con Saldos de Pagres"
            'Me.cdeFechaInicial.Enabled = False
        End If
    End Sub

    Private Sub grpTalonarios_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpTalonarios.Enter

    End Sub

    Private Sub RadCooperativa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCooperativa.CheckedChanged
        HabilitarMercado()
    End Sub
End Class