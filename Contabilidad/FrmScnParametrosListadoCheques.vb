Public Class FrmScnParametrosListadoCheques

    Dim IntPermiteConsultar As Integer
    Dim IntDepartamento As Integer

    Dim IntDelegacion As Integer

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String

    'Listado de Reportes
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        ListadoChequesEmitidos = 1
        ListadoChequesRango = 2
        ListadoChequesFechaEntrega = 3
        ListadoChequesTODOS = 4
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property
    Public ModeloPequeno As Integer
    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet
            EncuentraParametros()
            If cdeFechaInicial.Enabled Then
                cdeFechaInicial.Text = Format(CDate(FechaServer()), "dd/MM/yyyy")
            End If
            If CdeFechaFinal.Enabled Then
                CdeFechaFinal.Text = Format(CDate(FechaServer()), "dd/MM/yyyy")
            End If
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
            '  CargarDelegacion()
            HabilitarComboMunicipio()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    '-- CARGAR DELEGACIONES ---
    Private Sub CargarDelegacion()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 0 Then
                Strsql = " Select a.nStbDelegacionProgramaID,a.nCodigo,a.sNombreDelegacion as Descripcion,1 as Orden " & _
                         " From StbDelegacionPrograma a " & _
                         " Where a.nStbDelegacionProgramaID = " & Me.IntDelegacion & _
                         " Order by a.nCodigo"
            Else


                Strsql = " Select a.nStbDelegacionProgramaID,a.nCodigo,a.sNombreDelegacion as Descripcion,1 as Orden " & _
                         " From StbDelegacionPrograma a " & _
                         " Order by a.nCodigo"
            End If

            If XdsCombos.ExistTable("Delegacion") Then
                XdsCombos("Delegacion").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Delegacion")
                XdsCombos("Delegacion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboDelegacion.DataSource = XdsCombos("Delegacion").Source
            Me.CboDelegacion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.CboDelegacion.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboDelegacion.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboDelegacion.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.CboDelegacion.Splits(0).DisplayColumns("nCodigo").Width = 43
            Me.CboDelegacion.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.CboDelegacion.Columns("nCodigo").Caption = "Código"
            Me.CboDelegacion.Columns("Descripcion").Caption = "Descripción"

            Me.CboDelegacion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.CboDelegacion.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '          Me.cboReporte.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            '           Me.cboReporte.Splits(0).DisplayColumns(0).Width = 238

            '            Me.cboReporte.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General


            'Ubicarlo en el primer registro
            If Me.CboDelegacion.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("Delegacion").AddRow()
                XdsCombos("Delegacion").ValueField("Descripcion") = "TODAS LAS DELEGACIONES"
                XdsCombos("Delegacion").ValueField("nStbDelegacionProgramaID") = -19
                XdsCombos("Delegacion").ValueField("Orden") = 0
                XdsCombos("Delegacion").UpdateLocal()
                XdsCombos("Delegacion").Sort = "Orden,nCodigo asc"
                Me.CboDelegacion.SelectedIndex = 0
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


    Private Sub CargarOrden()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            cboOrden.AddItem("Número de Cheque")
            cboOrden.AddItem("Fecha de Transacción")
            cboOrden.AddItem("Número de cédula")
            cboOrden.AddItem("Nombre de Socia")
            cboOrden.AddItem("Monto desembolsado")
            cboOrden.Columns(0).Caption = "Ordenado Por"
            cboOrden.SelectedIndex = 0
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarCuentas()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = "SELECT nSteCuentaBancariaID, sNumeroCuenta + ' ( ' + sNombreCuenta + ')' AS CuentaBancaria ,1 As Orden            FROM dbo.SteCuentaBancaria " & _
                     " ORDER BY sNumeroCuenta"


            If XdsCombos.ExistTable("Cuenta") Then
                XdsCombos("Cuenta").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Cuenta")
                XdsCombos("Cuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCuentaBancaria.DataSource = XdsCombos("Cuenta").Source
            Me.cboCuentaBancaria.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cboCuentaBancaria.Splits(0).DisplayColumns("Orden").Visible = False
            'Configurar el combo
            Me.cboCuentaBancaria.Splits(0).DisplayColumns("CuentaBancaria").Width = 43
            Me.cboCuentaBancaria.Columns("CuentaBancaria").Caption = "Cuenta Bancaria"
            Me.cboCuentaBancaria.Splits(0).DisplayColumns("CuentaBancaria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Ubicarlo en el primer registro
            'If Me.CboDepartamento.ListCount > 0 Then
            '    XdsCombos("Cuenta").AddRow()
            '    XdsCombos("Cuenta").ValueField("CuentaBancaria") = "Todas"
            '    XdsCombos("Cuenta").ValueField("nSteCuentaBancariaID") = -19
            '    XdsCombos("Cuenta").ValueField("Orden") = 0
            '    XdsCombos("Cuenta").UpdateLocal()
            '    XdsCombos("Cuenta").Sort = "Orden,CuentaBancaria asc"
            '    Me.cboCuentaBancaria.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        Try

            VbResultado = False
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

            'Fechas Validas:
            If (Me.NomRep <> EnumReportes.ListadoChequesRango) Then
                If IsDBNull(cdeFechaInicial.Value) Then
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
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
                ''Máximo 31 días entre la fecha de inicio y corte:
                'If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 30 Then
                '    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                '    Me.cdeFechaInicial.Focus()
                '    Exit Function
                'End If
            End If

            'Cuenta Bancaria:
            If Me.cboCuentaBancaria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboCuentaBancaria, "Debe seleccionar una Cuenta Bancaria.")
                Me.cboCuentaBancaria.Focus()
                GoTo SALIR
            End If

            'Filtro hasta Municipio:
            If Me.NomRep = EnumReportes.ListadoChequesFechaEntrega Then
                If Me.cboBarrio.Text <> "Todos" Or Me.cboDistrito.Text <> "Todos" Then
                    REM Esto porq los Cheques Anulados no registraron Ubicacion Geografica
                    REM a Solicitud de Lester se ubicaran en Managua.
                    MsgBox("Debe indicar Todos en Distrito y Barrio.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboBarrio, "Debe indicar Todos en Distrito y Barrio.")
                    Me.cboBarrio.Focus()
                    GoTo SALIR
                End If
            End If

            'Si se obliga rango de cheques:
            If Me.NomRep = EnumReportes.ListadoChequesRango Then
                '1. Número Cheque Desde: 
                If Trim(RTrim(Me.txtCkDesde.Text)).ToString.Length = 0 Then
                    MsgBox("El Número Inicial de Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtCkDesde, "El Número del Cheque Inicial NO DEBE quedar vacío.")
                    Me.txtCkDesde.Focus()
                    GoTo SALIR
                End If
                '2. Número Recibo Hasta: 
                If Trim(RTrim(Me.txtCkHasta.Text)).ToString.Length = 0 Then
                    MsgBox("El Número del Cheque Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtCkHasta, "El Número del Cheque Final NO DEBE quedar vacío.")
                    Me.txtCkHasta.Focus()
                    GoTo SALIR
                End If
                '3. Número Cheque Desde > 0: 
                If CInt(Me.txtCkDesde.Text) = 0 Then
                    MsgBox("Número de Cheque Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtCkDesde, "Número de Cheque Inicial Inválido.")
                    Me.txtCkDesde.Focus()
                    GoTo SALIR
                End If
                '4. Número Cheque Hasta: 
                If CInt(Me.txtCkHasta.Text) = 0 Then
                    MsgBox("Número de Cheque Final Inválido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtCkHasta, "Número de Cheque Final Inválido.")
                    Me.txtCkHasta.Focus()
                    GoTo SALIR
                End If
                '5. Número de Recibo (Hasta) mayor: 
                If CInt(Me.txtCkHasta.Text) < CInt(Me.txtCkDesde.Text) Then
                    MsgBox("El No. del Cheque Final NO DEBE ser Menor que el No. Inicial.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtCkHasta, "El Número del Cheque Final NO DEBE ser Menor.")
                    Me.txtCkHasta.Focus()
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
        Dim OrdenExt As String
        Dim OrdenExtDesc As String
        Dim CadSql As String
        Try

            If ValidarParametros() = False Then Exit Sub

            Filtro = ""
            CadSql = ""
            Me.Cursor = Cursors.WaitCursor

            If Me.NomRep = EnumReportes.ListadoChequesRango Then
                frmVisor.WindowState = FormWindowState.Maximized
                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"




                'frmVisor.NombreReporte = "RepScnCN4.rpt"

                If ModeloPequeno = 0 Then
                    frmVisor.NombreReporte = "RepScnCN4.rpt"
                Else
                    frmVisor.NombreReporte = "RepScnCN4_4cheques.rpt"
                End If


                frmVisor.Text = "Comprobante de Pago"
                frmVisor.SQLQuery = "Select * From vwScnComprobantesDePago " & _
                                    "WHERE (NoCheque BETWEEN " & CInt(Me.txtCkDesde.Text) & " AND " & CInt(Me.txtCkHasta.Text) & ") " & _
                                    "AND (nSteCuentaBancariaID = " & Me.cboCuentaBancaria.Columns("nSteCuentaBancariaID").Value & ") " & _
                                    "Order by NoCheque asc"

            ElseIf (Me.NomRep = EnumReportes.ListadoChequesTODOS) Then

                frmVisor.WindowState = FormWindowState.Maximized

                'Fórmulas:
                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked = True, 1, 2) & "'"
                frmVisor.Formulas("Fecha") = "'DEL " & Format(CDate(cdeFechaInicial.Text), "dd/MM/yyyy") & " AL " & Format(CDate(CdeFechaFinal.Text), "dd/MM/yyyy") & " '"
                frmVisor.Formulas("Delegacion") = "'" & CboDelegacion.SelectedText & "'"



                'Fecha Transaccion Contable:
                If Trim(Filtro) = "" Then
                    Filtro = " Where dFechaTransaccion >= CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                Else
                    Filtro = Filtro & " And dFechaTransaccion >=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                End If
                'Cuenta Bancaria:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And nSteCuentaBancariaID=" & Me.cboCuentaBancaria.Columns("nSteCuentaBancariaID").Value
                Else
                    Filtro = " Where nSteCuentaBancariaID=" & Me.cboCuentaBancaria.Columns("nSteCuentaBancariaID").Value
                End If
                'Programa: NO ES NECESARIO FILTRAR POR PROGRAMA YA QUE SE FILTRA POR CUENTA BANCARIA Q PERTENECE A UN PROGRAMA.
                'If Trim(Filtro) <> "" Then
                '    Filtro = Filtro & " And CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                'Else
                '    Filtro = " Where CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                'End If

                'AGREGADO FILTRO POR DELEGACION
                If Trim(Filtro) <> "" And Me.CboDelegacion.Columns("nStbDelegacionProgramaID").Value <> -19 Then
                    Filtro = Filtro & " And nStbDelegacionProgramaID=" & Me.CboDelegacion.Columns("nStbDelegacionProgramaID").Value
                ElseIf (Me.CboDelegacion.Columns("nStbDelegacionProgramaID").Value <> -19) Then
                    Filtro = "Where nStbDelegacionProgramaID=" & Me.CboDelegacion.Columns("nStbDelegacionProgramaID").Value

                End If

                frmVisor.NombreReporte = "RepScnCN39.rpt"
                frmVisor.Text = "Listado de Cheques Emitidos"
                'frmVisor.SQLQuery = " Select * From vwScnListadoChequesEmitidosTODOS " & Filtro & "  Order by sNumeroCuenta, nCodigo"

                frmVisor.Parametros("@nSteCuentaBancariaID") = Me.cboCuentaBancaria.Columns("nSteCuentaBancariaID").Value
                frmVisor.Parametros("@nStbDelegacionProgramaID") = Me.CboDelegacion.Columns("nStbDelegacionProgramaID").Value
                frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                frmVisor.Formulas("Delegacion") = "'" & Me.CboDelegacion.Columns("Descripcion").Text & "'"

            ElseIf (Me.NomRep = EnumReportes.ListadoChequesEmitidos) Or (Me.NomRep = EnumReportes.ListadoChequesFechaEntrega) Then
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro = Filtro & " Where nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
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

                'Por Fecha Tx/Entrega
                If (Me.NomRep = EnumReportes.ListadoChequesEmitidos) Then
                    If Trim(Filtro) = "" Then
                        Filtro = " Where dFechaTransaccion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    Else
                        Filtro = Filtro & " And dFechaTransaccion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    End If
                Else 'Or (Me.NomRep = EnumReportes.ListadoChequesFechaEntrega)
                    If Trim(Filtro) = "" Then
                        Filtro = " Where FechaEntregaCK>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And FechaEntregaCK<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    Else
                        Filtro = Filtro & " And FechaEntregaCK>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And FechaEntregaCK<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
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
                If cboBarrio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    Else
                        Filtro = " Where nStbBarrioID=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                    End If
                End If
                'Cuenta Bancaria:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And nSteCuentaBancariaID=" & Me.cboCuentaBancaria.Columns("nSteCuentaBancariaID").Value
                Else
                    Filtro = " Where nSteCuentaBancariaID=" & Me.cboCuentaBancaria.Columns("nSteCuentaBancariaID").Value
                End If

                OrdenExtDesc = ""
                OrdenExt = ""
                Select Case Me.cboOrden.SelectedIndex + 1
                    Case 1
                        OrdenExt = "nCodigo"
                        OrdenExtDesc = "Num. de Cheque"
                    Case 2
                        OrdenExt = "dFechaTransaccion"
                        OrdenExtDesc = "Fecha Transaccion"
                    Case 3
                        OrdenExt = "SNumeroCedula"
                        OrdenExtDesc = "Num. de Cédula"
                    Case 4
                        OrdenExt = "Socia"
                        OrdenExtDesc = "Nomb. Socia"
                    Case 5
                        OrdenExt = "nMontoCreditoAprobado"
                        OrdenExtDesc = "Monto Cred."

                End Select

                ''Select Case cboReporte.SelectedIndex

                Select Case mNomRep
                    Case EnumReportes.ListadoChequesEmitidos
                        frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked = True, 1, 2) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                        Else
                            Filtro = " Where CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                        End If

                        If cboMontoAprobado.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                'MsgBox(Val(Replace(Trim(Me.cboMontoAprobado.Text), ",", "")))
                                Filtro = Filtro & " And nMontoCreditoAprobado=" & Val(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                            End If
                        Else
                            'Filtro = Filtro & " And nMontoCreditoAprobado<>10000 And nMontoCreditoAprobado<>1850 And nMontoCreditoAprobado<>3700 And nMontoCreditoAprobado<>4600 And nMontoCreditoAprobado<>5500"
                        End If

                        frmVisor.Formulas("Parametro") = "' Parámetros Cuenta :" & Me.cboCuentaBancaria.Text & " , Dpto: " & Me.CboDepartamento.Text & " , Munic: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " , Distrito: ", "") & cboDistrito.Text & " , Barrio : " & Me.cboBarrio.Text & " , Monto C$ :  " & Trim(cboMontoAprobado.Text) & "  . Ordenado por: Cuenta. Depto. Munic. " & OrdenExtDesc & "'"
                        frmVisor.Formulas("Fecha") = "' DEL " & Me.cdeFechaInicial.Text & " AL  " & Me.CdeFechaFinal.Text & " '"
                        frmVisor.NombreReporte = "RepScnCN16.rpt"
                        frmVisor.Text = "Listado de Cheques Emitidos"
                        frmVisor.SQLQuery = " Select * From vwScnListadoChequesEmitidosReporte " & Filtro & "  Order by   sNumeroCuenta,Departamento,Municipio ," & OrdenExt

                    Case EnumReportes.ListadoChequesFechaEntrega
                        frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked = True, 1, 2) & "'"
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                        Else
                            Filtro = " Where CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                        End If

                        frmVisor.Formulas("Parametro") = "'Parámetros Cuenta: " & Me.cboCuentaBancaria.Text & " Depto.: " & Me.CboDepartamento.Text & "  Munic.: " & Me.cboMunicipio.Text & " " & IIf(cboDistrito.SelectedIndex <= 1, " Distrito: ", "") & cboDistrito.Text & " Barrio : " & Me.cboBarrio.Text & " Ordenado por: Cuenta. Depto. Munic. " & OrdenExtDesc & "'"
                        frmVisor.Formulas("Fecha") = "' ENTREGAS DEL " & Me.cdeFechaInicial.Text & " AL  " & Me.CdeFechaFinal.Text & " '"
                        frmVisor.NombreReporte = "RepScnCN38.rpt"
                        frmVisor.Text = "Listado de Cheques Emitidos x Fecha de Entrega"
                        frmVisor.SQLQuery = " Select * From vwScnListadoChequesEmitidosyAnulados " & Filtro & "  Order by   sNumeroCuenta,Departamento,Municipio ," & OrdenExt

                End Select
            End If

            frmVisor.ShowDialog()
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
        HabilitarComboMunicipio()
    End Sub

    Private Sub HabilitarComboMunicipio()
        'If Me.CboDepartamento.SelectedIndex > 0 Then
        '    Me.cboMunicipio.Enabled = True
        '    'Me.cboBarrio.Enabled = True
        '    If Me.cboMunicipio.Text = "Todos" Then
        '        Me.cboBarrio.Enabled = False
        '    Else
        '        Me.cboBarrio.Enabled = True
        '    End If
        'Else
        '    Me.cboMunicipio.Enabled = False
        '    Me.cboBarrio.Enabled = False
        'End If
        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
            'Me.cboBarrio.Enabled = True
            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboBarrio.Enabled = False

            Else
                Me.cboBarrio.Enabled = True

            End If
        Else
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False

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

                Me.cboDistrito.Enabled = True


            Else
                CargarDistrito(0)
                Me.cboDistrito.Enabled = False
            End If
            'If Me.cboMunicipio.Text <> "Todos" Then
            CargarBarrio(0)

            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboBarrio.Enabled = False
            Else
                If Me.cboMunicipio.Text = "Managua" And Me.cboDistrito.Text = "Todos" Then
                    Me.cboBarrio.Enabled = False
                Else
                    Me.cboBarrio.Enabled = True
                End If

            End If
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

            If (Me.NomRep = EnumReportes.ListadoChequesEmitidos) Or (Me.NomRep = EnumReportes.ListadoChequesFechaEntrega) Then
                ObjGUI.SetFormLayout(Me, "Verde")
                Me.txtCkDesde.Enabled = False
                Me.txtCkHasta.Enabled = False
                Me.lblChequeDesde.Visible = False
                Me.lblChequeHasta.Visible = False
                Me.txtCkDesde.Visible = False
                Me.txtCkHasta.Visible = False
                Me.CboDelegacion.Enabled = False
            ElseIf (Me.NomRep = EnumReportes.ListadoChequesRango) Then
                ObjGUI.SetFormLayout(Me, "Celeste")
                Me.CboDepartamento.Enabled = False
                Me.cboMunicipio.Enabled = False
                Me.cboDistrito.Enabled = False
                Me.cboOrden.Enabled = False
                Me.cdeFechaInicial.Enabled = False
                Me.CdeFechaFinal.Enabled = False
                Me.CboDelegacion.Enabled = False
            Else 'If (Me.NomRep = EnumReportes.ListadoChequesTODOS) Then
                ObjGUI.SetFormLayout(Me, "Celeste")
                Me.CboDepartamento.Enabled = False
                Me.cboMunicipio.Enabled = False
                Me.cboDistrito.Enabled = False
                Me.cboBarrio.Enabled = False
                Me.cboOrden.Enabled = False
                Me.CboDelegacion.Enabled = True
                Me.lblChequeDesde.Visible = False
                Me.lblChequeHasta.Visible = False
                Me.txtCkDesde.Visible = False
                Me.txtCkHasta.Visible = False
                Me.grpPrograma.Visible = False
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            CargarDelegacion()
            HabilitarComboMunicipio()
            CargarCuentas()
            CargarOrden()

            If Me.mNomRep = EnumReportes.ListadoChequesEmitidos Then ' CS43
                cboMontoAprobado.Enabled = True
                cboMontoAprobado.AddItem("(Todos)")
                cboMontoAprobado.AddItem("1,850.00")
                cboMontoAprobado.AddItem("3,700.00")
                cboMontoAprobado.AddItem("4,600.00")
                cboMontoAprobado.AddItem("5,500.00")
                cboMontoAprobado.AddItem("7,000.00")
                cboMontoAprobado.AddItem("10,000.00")
                cboMontoAprobado.AddItem("15,000.00")
                cboMontoAprobado.AddItem("20,000.00")
                cboMontoAprobado.Columns(0).Caption = ""
                cboMontoAprobado.SelectedIndex = 0
                Me.CboDelegacion.Enabled = False
            Else
                cboMontoAprobado.Enabled = False
            End If

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
            If Me.cboDistrito.Text = "Todos" And Me.cboMunicipio.Text = "Managua" Then
                Me.cboBarrio.Enabled = False
            Else
                If Me.cboMunicipio.Text <> "Managua" Then
                    Me.cboBarrio.Enabled = True
                Else
                    If Me.cboMunicipio.Text = "Managua" And Me.cboDistrito.SelectedIndex > 0 Then
                        Me.cboBarrio.Enabled = True
                    Else
                        If Me.cboMunicipio.Text = "Managua" And Me.cboDistrito.SelectedIndex < 1 Then
                            Me.cboBarrio.Enabled = False
                        End If
                    End If
                End If
            End If
        End If


    End Sub

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub txtCkDesde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCkDesde.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtCkHasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCkHasta.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub FrmScnParametrosListadoCheques_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.NomRep = EnumReportes.ListadoChequesEmitidos Then
            Me.Text = " Listado de Cheques de Socias"
        ElseIf Me.NomRep = EnumReportes.ListadoChequesRango Then
            Me.Text = " Comprobantes de Cheque"
        ElseIf Me.NomRep = EnumReportes.ListadoChequesFechaEntrega Then
            Me.Text = " Listado de Cheques de Socias x Fecha de Entrega"
        ElseIf Me.NomRep = EnumReportes.ListadoChequesTODOS Then
            Me.Text = " Listado de Cheques Emitidos"
        End If
    End Sub

End Class