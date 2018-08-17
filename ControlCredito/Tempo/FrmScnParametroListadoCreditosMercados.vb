Public Class FrmScnParametroListadoCreditosMercados
    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim sColor As String

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

    'Listado de Reportes:
    Public Enum EnumReportes
        ListadoMercados = 1
        ConsecutivoRecibosArqueo = 2            'Consecutivo de Recibos por Fecha de Arqueos Cerrados
        ConsecutivoRecibos = 3                  'Consecutivo de Recibos por Fecha de Recibos Activos
        TalonariosNoArqueados = 4               'Recibos Entregados a Cajeros No Contenidos en Arqueos Cerrados
        TalonariosEntregados = 5                'Talonarios Entregados a Cajeros
        ListadoMinutasRecibos = 6               'Listado de Minutas y Recibos por Fecha de Recibos Oficiales
        ListadoRecibosDepositados = 7           'Listado de Recibos y Cuenta Bancaria del Deposito por Fecha de Recibos Oficiales (CN25)
        ListadoMinutasSinComprobantes = 8       'Listado de Minutas Sin Comprobantes Asociados (CN26)
        ListadoConsecutivoRecibosRango = 9      'Listado de Recibos Activos en un Rango (En Crédito) (TE33)
        ListadoFaltantesRecibos = 10            'Listado de Recibos Faltantes en un Rango (En Crédito) (TE34)
        ListadoConsecutivoRecibosRangoTE = 11   'Listado de Recibos Activos en un Rango (En Tesorería) (TE36)
        ListadoFaltantesRecibosTE = 12          'Listado de Recibos Faltantes en un Rango (En Tesorería) (TE37)
        ListadoRecibosCredito = 13              'Listado de Recibos (En Crédito) (TE41)
        ConsolidadoRecibosCredito = 14          'Consolidado de Recibos (En Crédito) (TE42)
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet
            'Si NO es el Listado de Mercados:
            If Me.NomRep <> EnumReportes.ListadoMercados Then
                Me.cboMunicipio.Enabled = False
                Me.cboMercado.Enabled = False
                Me.RadCooperativa.Enabled = False
                Me.RadMercado.Enabled = False
            End If
            'Si no es la Entrega de Talonarios o Recibos Rango:
            If Me.NomRep <> EnumReportes.TalonariosEntregados And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE Then
                Me.txtReciboIni.Enabled = False
                Me.txtReciboFin.Enabled = False
            End If
            'Si es Secuencia de Recibos de un Rango Bloquear Fechas de Corte:
            If (Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango) Or (Me.NomRep = EnumReportes.ListadoFaltantesRecibos) Or (Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE) Or (Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE) Then
                Me.CdeFechaFinal.Enabled = False
                Me.cdeFechaInicial.Enabled = False
            End If
            'Si no es secuencia de recibos: ConsolidadoRecibosCredito
            If (Me.NomRep <> EnumReportes.ConsecutivoRecibosArqueo) And (Me.NomRep <> EnumReportes.ConsecutivoRecibos) And (Me.NomRep <> EnumReportes.TalonariosNoArqueados) And (Me.NomRep <> EnumReportes.TalonariosEntregados) And (Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango) And (Me.NomRep <> EnumReportes.ListadoFaltantesRecibos) And (Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE) And (Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE) And (Me.NomRep <> EnumReportes.ListadoRecibosCredito) And (Me.NomRep <> EnumReportes.ConsolidadoRecibosCredito) Then
                Me.CboPrograma.Enabled = False
            End If

            'Por Corte de Talonarios: 
            If (Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE) Or (Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE) _
                Or (Me.NomRep = EnumReportes.ConsecutivoRecibosArqueo) Or (Me.NomRep = EnumReportes.ConsecutivoRecibos) _
                Or (Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango) Or (Me.NomRep = EnumReportes.ListadoFaltantesRecibos) _
                Or (Me.NomRep = EnumReportes.ListadoRecibosCredito) Or (Me.NomRep = EnumReportes.ConsolidadoRecibosCredito) Then
                Me.grpTalonarios.Visible = True
            End If
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/01/2010
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
            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 225

            Me.CboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.CboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '          Me.cboReporte.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            '           Me.cboReporte.Splits(0).DisplayColumns(0).Width = 238

            '            Me.cboReporte.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General


            'Para Consolidado Departamental permitir TODOS:
            'If Me.NomRep = EnumReportes.ConsolidadoRecibosCredito Then
            If Me.CboDepartamento.ListCount > 0 Then
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.CboDepartamento.SelectedIndex = 0
            End If
            'End If

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
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 225

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            'If Me.cboMunicipio.ListCount > 0 Then
            'XdsCombos("Municipio").AddRow()
            'XdsCombos("Municipio").ValueField("Descripcion") = "Todos"
            'XdsCombos("Municipio").ValueField("nStbMunicipioID") = -19
            'XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -19
            'XdsCombos("Municipio").ValueField("Orden") = 0
            'XdsCombos("Municipio").UpdateLocal()
            'XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
            'Me.cboMunicipio.SelectedIndex = 0
            'End If
            ''HabilitarComboMercado()

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    '**************************************************************************    
    '* Cargar la lista de Mercados existente para un filtro de municipios 
    '**************************************************************************

    Private Sub CargarMercado(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String
            Dim CadWhere As String '' Cadena para el filtro por todos o  departamento y o municipio

            Me.cboMercado.ClearFields()
            CadWhere = ""
            If Me.CboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If

            If Me.RadCooperativa.Checked Then
                CadWhere = CadWhere & IIf(String.IsNullOrEmpty(CadWhere), " Where ", " And ") & " dbo.StbMercado.nCooperativa = 1 "
            Else
                CadWhere = CadWhere & IIf(String.IsNullOrEmpty(CadWhere), " Where ", " And ") & " dbo.StbMercado.nCooperativa = 0"
            End If


            If intLimpiarID = 0 Then
                Strsql = " SELECT  dbo.StbDepartamento.sNombre AS Departamento, dbo.StbMunicipio.sNombre AS Municipio, dbo.StbMercado.nStbMercadoID,dbo.StbMercado.Scodigo, dbo.StbMercado.sNombre,0 As Orden " & _
                         " FROM         dbo.StbBarrio INNER JOIN " & _
                         " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                         " dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID INNER JOIN " & _
                         " dbo.StbDistrito ON dbo.StbBarrio.nStbDistritoID = dbo.StbDistrito.nStbDistritoID INNER JOIN   " & _
                         " dbo.StbMercado ON dbo.StbBarrio.nStbBarrioID = dbo.StbMercado.nStbBarrioID " & _
                         CadWhere & " Order by dbo.StbDepartamento.Snombre,dbo.StbMunicipio.Snombre "



            Else

                Strsql = " SELECT  dbo.StbDepartamento.sNombre AS Departamento, dbo.StbMunicipio.sNombre AS Municipio,   dbo.StbMercado.nStbMercadoID,dbo.StbMercado.Scodigo , dbo.StbMercado.sNombre,0 As Orden " & _
                         " FROM         dbo.StbBarrio INNER JOIN " & _
                         " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                         " dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID INNER JOIN " & _
                         " dbo.StbDistrito ON dbo.StbBarrio.nStbDistritoID = dbo.StbDistrito.nStbDistritoID INNER JOIN   " & _
                         " dbo.StbMercado ON dbo.StbBarrio.nStbBarrioID = dbo.StbMercado.nStbBarrioID " & _
                         " Where  dbo.StbMercado.nStbMercadoID= 0  Order by dbo.StbDepartamento.Snombre,dbo.StbMunicipio.Snombre,stbmercado.scodigo  "


            End If

            If XdsCombos Is Nothing Then
                XdsCombos = New BOSistema.Win.XDataSet
            End If

            If XdsCombos.ExistTable("Mercado") Then
                XdsCombos("Mercado").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Mercado")
                XdsCombos("Mercado").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMercado.DataSource = XdsCombos("Mercado").Source
            Me.cboMercado.Rebind()

            Me.cboMercado.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("Departamento").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("Municipio").Visible = False
            Me.cboMercado.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercado.Splits(0).DisplayColumns("sNombre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.cboMercado.Splits(0).DisplayColumns("Snombre").Width = 225

            Me.cboMercado.Columns("sCodigo").Caption = "Código"
            Me.cboMercado.Columns("Snombre").Caption = "Descripción"
            Me.cboMercado.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMercado.Splits(0).DisplayColumns("Snombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboMercado.ListCount > 0 Then
                'XdsCombos("Mercado").AddRow()
                'XdsCombos("Mercado").ValueField("sNombre") = "Todos"
                'XdsCombos("Mercado").ValueField("Scodigo") = ""
                'XdsCombos("Mercado").ValueField("Departamento") = ""
                'XdsCombos("Mercado").ValueField("Municipio") = ""
                'XdsCombos("Mercado").ValueField("nStbMercadoID") = -19
                'XdsCombos("Mercado").ValueField("Orden") = 0
                'XdsCombos("Mercado").UpdateLocal()
                'XdsCombos("Mercado").Sort = "Orden, Departamento, Municipio, sCodigo asc"
                'Me.cboMercado.SelectedIndex = 0
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

            'Departamento:
            If Me.CboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.CboDepartamento.Focus()
                GoTo SALIR
            End If

            'Tipo de Programa: 
            If Me.CboPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Programa válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboPrograma, "Debe seleccionar un Programa válido.")
                Me.CboPrograma.Focus()
                GoTo SALIR
            End If

            'Si es Listado de secuencia de numeracion de recibos:
            'Se debe seleccionar solamente un tipo de Programa:
            If (Me.NomRep = EnumReportes.ConsecutivoRecibosArqueo) Or (Me.NomRep = EnumReportes.ConsecutivoRecibos) Or (Me.NomRep = EnumReportes.TalonariosNoArqueados) Or (Me.NomRep = EnumReportes.TalonariosEntregados) Or (Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango) Or (Me.NomRep = EnumReportes.ListadoFaltantesRecibos) Or (Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE) Or (Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE) Or (Me.NomRep = EnumReportes.ListadoRecibosCredito) Or (Me.NomRep = EnumReportes.ConsolidadoRecibosCredito) Then
                If Me.CboPrograma.SelectedIndex = 0 Then
                    MsgBox("Debe seleccionar un Programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboPrograma, "Debe seleccionar un Programa.")
                    Me.CboPrograma.Focus()
                    GoTo SALIR
                End If
            End If

            'Si Es el Listado de Mercados:
            If Me.NomRep = EnumReportes.ListadoMercados Then
                'Municipio:
                If Me.cboMunicipio.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                    Me.cboMunicipio.Focus()
                    GoTo SALIR
                End If
                'Mercado:
                If Me.cboMercado.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Mercado válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboMercado, "Debe seleccionar un Lugar de Pago válido.")
                    Me.cboMercado.Focus()
                    GoTo SALIR
                End If
            End If

            'Si no es el reporte de secuencia de recibos por rango sin importar fecha:
            If Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE Then
                'Fechas Validas:
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
            End If

            'Si NO Es el Listado de Mercados ni la secuencia de recibos por rango:
            If Me.NomRep <> EnumReportes.ConsolidadoRecibosCredito Then
                If Me.NomRep <> EnumReportes.ListadoMercados And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE Then
                    'Si es Listado de Recibos por fecha de recibos
                    If Me.NomRep = EnumReportes.ListadoMinutasRecibos Or Me.NomRep = EnumReportes.ListadoRecibosDepositados Or Me.NomRep = EnumReportes.ListadoMinutasSinComprobantes Then
                        'Superiores a Seis Meses:
                        If DateDiff(DateInterval.Month, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 5 Then
                            MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a seis meses.", MsgBoxStyle.Information)
                            Me.errParametro.SetError(Me.cdeFechaInicial, "Imposible seleccionar cortes de fecha superiores a seis meses.")
                            Me.cdeFechaInicial.Focus()
                            GoTo SALIR
                        End If
                    Else
                        'Superiores a Tres Meses:
                        If DateDiff(DateInterval.Month, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 2 Then
                            MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a tres meses.", MsgBoxStyle.Information)
                            Me.errParametro.SetError(Me.cdeFechaInicial, "Imposible seleccionar cortes de fecha superiores a tres meses.")
                            Me.cdeFechaInicial.Focus()
                            GoTo SALIR
                        End If
                    End If
                End If
            End If

            'Si se obliga rango de recibos (Informe de Talonarios Entregados y Entregas Recibos Rango):
            If Me.NomRep = EnumReportes.TalonariosEntregados Or Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango Or Me.NomRep = EnumReportes.ListadoFaltantesRecibos Or Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE Or Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE Then
                '1. Número Recibo Desde: 
                If Trim(RTrim(Me.txtReciboIni.Text)).ToString.Length = 0 Then
                    MsgBox("El Número del Recibo Inicial NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtReciboIni, "El Número del Recibo Inicial NO DEBE quedar vacío.")
                    Me.txtReciboIni.Focus()
                    GoTo SALIR
                End If
                '2. Número Recibo Hasta: 
                If Trim(RTrim(Me.txtReciboFin.Text)).ToString.Length = 0 Then
                    MsgBox("El Número del Recibo Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtReciboFin, "El Número del Recibo Final NO DEBE quedar vacío.")
                    Me.txtReciboFin.Focus()
                    GoTo SALIR
                End If
                '3. Número Recibo Desde > 0: 
                If CInt(Me.txtReciboIni.Text) = 0 Then
                    MsgBox("Número de Recibo Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtReciboIni, "Número de Recibo Inicial Inválido.")
                    Me.txtReciboIni.Focus()
                    GoTo SALIR
                End If
                '4. Número Recibo Hasta: 
                If CInt(Me.txtReciboFin.Text) = 0 Then
                    MsgBox("Número de Recibo Final Inválido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtReciboFin, "Número de Recibo Final Inválido.")
                    Me.txtReciboFin.Focus()
                    GoTo SALIR
                End If
                '5. Número de Recibo (Hasta) mayor: 
                If CInt(Me.txtReciboFin.Text) < CInt(Me.txtReciboIni.Text) Then
                    MsgBox("El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo Inicial.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtReciboFin, "El Número del Recibo Final NO DEBE ser Menor.")
                    Me.txtReciboFin.Focus()
                    GoTo SALIR
                End If
            End If

            'Entregas Recibos Rango:
            'Nota: No mayor rango de 10000 códigos de recibos (a partir 16/03/2009).
            If Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango Or Me.NomRep = EnumReportes.ListadoFaltantesRecibos Or Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE Or Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE Then
                If ((CInt(Me.txtReciboFin.Text) - CInt(Me.txtReciboIni.Text)) + 1) > 10000 Then
                    MsgBox("El rango no debe superar los 10,000 Recibos Oficiales.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.txtReciboFin, "Rango Inválido.")
                    Me.txtReciboFin.Focus()
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
        '----------------------------------------------------------------------------------
        'Llama a los reportes de consolidados y detalle de créditos por distritos y Barrios
        '----------------------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim CadSql As String
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            Me.Cursor = Cursors.WaitCursor

            If Me.NomRep = EnumReportes.ConsecutivoRecibosArqueo Then
                '1. Para Arqueos Cerrados del Departamento: 
                Filtro = Filtro & " {vwSteListadoRecibosArqueadosAnuladosRep.sCodEstado}= '2' And {vwSteListadoRecibosArqueadosAnuladosRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                '2. Entre el rango de fechas de corte indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoRecibosArqueadosAnuladosRep.dFecha} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoRecibosArqueadosAnuladosRep.dFecha} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoRecibosArqueadosAnuladosRep.dFecha} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoRecibosArqueadosAnuladosRep.dFecha} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
                '3. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoRecibosArqueadosAnuladosRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " {vwSteListadoRecibosArqueadosAnuladosRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If
                '4. Para el Número de Talonario:
                If Me.RdMIFIC.Checked = True Then
                    Filtro = Filtro & " And {vwSteListadoRecibosArqueadosAnuladosRep.nCodigoTalonario} = 0"
                Else
                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And {vwSteListadoRecibosArqueadosAnuladosRep.nCodigoTalonario} = 1"

                    Else 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Febrero/2011
                        Filtro = Filtro & " And {vwSteListadoRecibosArqueadosAnuladosRep.nCodigoTalonario} = 2"
                    End If

                End If

            ElseIf Me.NomRep = EnumReportes.ConsecutivoRecibos Then
                '1. Para Recibos del Departamento: 
                Filtro = Filtro & " {vwSteListadoConsecutivoRecibosRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                '2. Entre el rango de fechas de corte indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.dFecha} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoConsecutivoRecibosRep.dFecha} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.dFecha} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoConsecutivoRecibosRep.dFecha} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
                '3. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " {vwSteListadoConsecutivoRecibosRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If
                '4. Para el Número de Talonario:
                If Me.RdMIFIC.Checked = True Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nCodigoTalonario} = 0"
                Else

                    If RdUsura.Enabled = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nCodigoTalonario} = 1"
                    Else 'A partir de: 01/febrero/2011
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nCodigoTalonario} = 2"

                    End If
                End If
                '5. Recibos Manuales:
                Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nManual} = 1"

            ElseIf Me.NomRep = EnumReportes.ListadoMercados Then
                '1. Corte por Departamento:
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro = Filtro & " Where nStbDepartamentoID=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                    End If
                End If

                '2. Corte por Municipio:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = " Where nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If

                '3. Corte por Mercado:
                If cboMercado.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And nStbMercadoID=" & Me.cboMercado.Columns("nStbMercadoID").Value
                    Else
                        Filtro = " Where nStbMercadoID=" & Me.cboMercado.Columns("nStbMercadoID").Value
                    End If
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And nCooperativa = " & IIf(Me.RadMercado.Checked, "0", "1")
                Else
                    Filtro = " Where nCooperativa = " & IIf(Me.RadMercado.Checked, "0", "1")
                End If

                '4. Corte por Fecha: 
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                Else
                    Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                End If

                '5. Monto Aprobado
                If cboMontoAprobado.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                        'MsgBox(Trim(Me.cboMontoAprobado.Text))
                        Filtro = Filtro & " And nMontoCreditoAprobado=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                    End If
                Else
                    'Filtro = Filtro & " And nMontoCreditoAprobado<>10000 And nMontoCreditoAprobado<>1850 And nMontoCreditoAprobado<>3700 And nMontoCreditoAprobado<>4600 And nMontoCreditoAprobado<>5500"
                End If

            ElseIf Me.NomRep = EnumReportes.TalonariosNoArqueados Then
                frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@nStbDepartamentoId") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                frmVisor.Parametros("@nStbTipoProgramaId") = Me.CboPrograma.Columns("nStbValorCatalogoID").Value

            ElseIf Me.NomRep = EnumReportes.TalonariosEntregados Then
                frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@nStbDepartamentoId") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                frmVisor.Parametros("@nStbTipoProgramaId") = Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                frmVisor.Parametros("@RangoInicial") = CInt(Me.txtReciboIni.Text)
                frmVisor.Parametros("@RangoFinal") = CInt(Me.txtReciboFin.Text)

            ElseIf Me.NomRep = EnumReportes.ListadoMinutasRecibos Then
                '1. Para Recibos del Departamento: 
                If Me.CboDepartamento.Columns("nStbDepartamentoID").Value <> -19 Then
                    Filtro = Filtro & " {vwScnListadoMinutasRecibos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                '2. Entre el rango de fechas de corte indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwScnListadoMinutasRecibos.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwScnListadoMinutasRecibos.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwScnListadoMinutasRecibos.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwScnListadoMinutasRecibos.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoRecibosDepositados Then
                '1. Para Recibos del Departamento: 
                If Me.CboDepartamento.Columns("nStbDepartamentoID").Value <> -19 Then
                    Filtro = Filtro & " {vwScnListadoRecibosDepositados.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If

                '2. Entre el rango de fechas de corte indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwScnListadoRecibosDepositados.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwScnListadoRecibosDepositados.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwScnListadoRecibosDepositados.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwScnListadoRecibosDepositados.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoMinutasSinComprobantes Then

                '*********OJO CAMBIO REALIZADO EL 08/JULIO/2011*****************
                If CboDepartamento.Text = "Todos" Then
                    '1. Para Minutas de todos los Departamentos
                    
                    Filtro = " {vwScnListadoMinutasSinComprobante.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#" & " and {vwScnListadoMinutasSinComprobante.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"

                    


                Else
                    '1. Para Minutas del Departamento:
                    Filtro = Filtro & " {vwScnListadoMinutasSinComprobante.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    '2. Entre el rango de fechas de corte indicadas: 
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwScnListadoMinutasSinComprobante.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = " {vwScnListadoMinutasSinComprobante.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    End If
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwScnListadoMinutasSinComprobante.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = " {vwScnListadoMinutasSinComprobante.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    End If
                End If

                '************************************************************************************

                '********ORIGINAL*******
                ''1. Para Minutas del Departamento:
                'Filtro = Filtro & " {vwScnListadoMinutasSinComprobante.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                ''2. Entre el rango de fechas de corte indicadas: 
                'If Trim(Filtro) <> "" Then
                '    Filtro = Filtro & " And {vwScnListadoMinutasSinComprobante.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                'Else
                '    Filtro = " {vwScnListadoMinutasSinComprobante.dFechaDeposito} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                'End If
                'If Trim(Filtro) <> "" Then
                '    Filtro = Filtro & " And {vwScnListadoMinutasSinComprobante.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                'Else
                '    Filtro = " {vwScnListadoMinutasSinComprobante.dFechaDeposito} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                'End If
                '******************************************************************
            ElseIf Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango Then
                '1. Para Recibos del Departamento: 
                Filtro = Filtro & " {vwSteListadoConsecutivoRecibosRangoRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                '2. Entre el rango de Códigos de Recibos indicado:
                Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.NoRecibo} >= " & CInt(Me.txtReciboIni.Text)
                Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.NoRecibo} <= " & CInt(Me.txtReciboFin.Text)
                '3. Para el Tipo de Programa:
                Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nStbTipoProgramaID} = " & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                '4. Para el Número de Talonario:
                If Me.RdMIFIC.Checked = True Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nCodigoTalonario} = 0"
                Else
                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nCodigoTalonario} = 1"
                    Else 'A partir de: 01/febrero/2011
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nCodigoTalonario} = 2"
                    End If
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoFaltantesRecibos Then
                    '1. Para Recibos del Departamento: 
                    Filtro = Filtro & " {vwSteListadoConsecutivoRecibosRangoRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    '2. Entre el rango de Códigos de Recibos indicado:
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.NoRecibo} >= " & CInt(Me.txtReciboIni.Text)
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.NoRecibo} <= " & CInt(Me.txtReciboFin.Text)
                    '3. Para el Tipo de Programa:
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nStbTipoProgramaID} = " & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    '4. Para el Número de Talonario:
                    If Me.RdMIFIC.Checked = True Then
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nCodigoTalonario} = 0"
                Else


                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nCodigoTalonario} = 1"
                    Else 'A partir de: 01/febrero/2011
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRangoRep.nCodigoTalonario} = 2"
                    End If
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE Then
                '1. Para Recibos del Departamento: 
               

                    '2. Entre el rango de Códigos de Recibos indicado:
                Filtro = Filtro & "  {vwSteConsecutivoRecibosRangoTesoreriaRep.NoRecibo} >= " & CInt(Me.txtReciboIni.Text)
                    Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.NoRecibo} <= " & CInt(Me.txtReciboFin.Text)
                    '3. Para el Tipo de Programa:
                    Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nStbTipoProgramaID} = " & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    '4. Para el Número de Talonario:
                    If Me.RdMIFIC.Checked = True Then
                        Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nCodigoTalonario} = 0"
                    Else
                        If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                            Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nCodigoTalonario} = 1"
                        Else 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Febrero/2011
                            Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nCodigoTalonario} = 2"
                        End If
                End If

                If Me.ChkPendiente.Checked Then

                    'frmVisor.CRVReportes.SelectionFormula = "{vwSteConsecutivoRecibosRangoTesoreriaRep.ReciboDiferencia } >0"

                    'If Trim(Filtro) <> "" Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                    '    Filtro = Filtro & " And  {vwSteConsecutivoRecibosRangoTesoreriaRep.ReciboDiferencia} )<>0"


                    'Else 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Febrero/2011
                    '    Filtro = Filtro & "   {vwSteConsecutivoRecibosRangoTesoreriaRep.ReciboDiferencia} )<>0"
                    'End If
                    frmVisor.Formulas("ImprimirSinFiltro") = 0

                Else
                    frmVisor.Formulas("ImprimirSinFiltro") = 1

                End If
                'If Me.CboDepartamento.Columns("nStbDepartamentoID").Value <> -19 Then
                If Trim(Filtro) <> "" Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                    Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                Else 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Febrero/2011
                    Filtro = Filtro & " {vwSteConsecutivoRecibosRangoTesoreriaRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If

                'End If

            ElseIf Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE Then
                '1. Para Recibos del Departamento: 
                Filtro = Filtro & " {vwSteConsecutivoRecibosRangoTesoreriaRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                '2. Entre el rango de Códigos de Recibos indicado:
                Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.NoRecibo} >= " & CInt(Me.txtReciboIni.Text)
                Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.NoRecibo} <= " & CInt(Me.txtReciboFin.Text)
                '3. Para el Tipo de Programa:
                Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nStbTipoProgramaID} = " & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                '4. Para el Número de Talonario:
                If Me.RdMIFIC.Checked = True Then
                    Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nCodigoTalonario} = 0"
                Else
                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nCodigoTalonario} = 1"
                    Else 'A partir de: 01/febrero/2011
                        Filtro = Filtro & " And {vwSteConsecutivoRecibosRangoTesoreriaRep.nCodigoTalonario} = 2"
                    End If
                End If


            ElseIf Me.NomRep = EnumReportes.ListadoRecibosCredito Then
                '1. Para Recibos del Departamento: 
                Filtro = Filtro & " {vwSteListadoConsecutivoRecibosRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                '2. Entre el rango de fechas de corte indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.dFecha} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoConsecutivoRecibosRep.dFecha} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.dFecha} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoConsecutivoRecibosRep.dFecha} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
                '3. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " {vwSteListadoConsecutivoRecibosRep.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If
                '4. Para el Número de Talonario:
                If Me.RdMIFIC.Checked = True Then
                    Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nCodigoTalonario} = 0"
                Else
                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nCodigoTalonario} = 1"
                    Else 'A partir de: 01/febrero/2011
                        Filtro = Filtro & " And {vwSteListadoConsecutivoRecibosRep.nCodigoTalonario} = 2"
                    End If
                End If


            ElseIf Me.NomRep = EnumReportes.ConsolidadoRecibosCredito Then

                frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@nStbTipoProgramaID") = Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                If CboDepartamento.SelectedIndex > 0 Then
                    frmVisor.Parametros("@nStbDepartamentoID") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                Else
                    frmVisor.Parametros("@nStbDepartamentoID") = 0
                End If
                If Me.RdMIFIC.Checked = True Then
                    frmVisor.Parametros("@nCodigoTalonario") = 0
                Else
                    If Me.RdUsura.Checked = True Then 'If Me.RdUsura.Checked = True Then 'A partir de: 01/Marzo/2010
                        frmVisor.Parametros("@nCodigoTalonario") = 1
                    Else 'A partir de: 01/Marzo/2010
                        frmVisor.Parametros("@nCodigoTalonario") = 2
                    End If
                End If

            End If

            Select Case mNomRep
                Case EnumReportes.ListadoMercados
                    frmVisor.NombreReporte = "RepSclCS19.rpt"
                    frmVisor.Text = "Listado de Creditos por Mercados"
                    frmVisor.SQLQuery = " Select * From vwSclListaMercadosCreditoReporte " & Filtro & "  Order by   Departamento,Municipio,nstbmercadoid "
                    frmVisor.Formulas("Parametro") = "' Parámetros.  Dpto: " & Me.CboDepartamento.Text & " , Munic: " & Me.cboMunicipio.Text & " , Mercado:  " & Me.cboMercado.Text & "  , Monto C$:  " & Trim(cboMontoAprobado.Text) & "'"
                    frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    frmVisor.Formulas("TipoAsociacion") = IIf(Me.RadMercado.Checked, 1, 0)

                Case EnumReportes.ConsecutivoRecibosArqueo
                    frmVisor.NombreReporte = "RepSteTE18.rpt"
                    frmVisor.Text = "Consecutivo de Recibos por Fecha de Arqueos Cerrados"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFechas") = "' Arqueos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.ConsecutivoRecibos
                    frmVisor.NombreReporte = "RepSteTE19.rpt"
                    frmVisor.Text = "Consecutivo de Recibos por Fecha de Recibos Oficiales Activos"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFechas") = "' Recibos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.TalonariosNoArqueados
                    frmVisor.NombreReporte = "RepSteTE22.rpt"
                    frmVisor.Text = "Recibos Oficiales Entregados Sin Arqueo Cerrado"
                    frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.TalonariosEntregados
                    frmVisor.NombreReporte = "RepSteTE23.rpt"
                    frmVisor.Text = "Talonarios de Recibos Oficiales Entregados"
                    frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.ListadoMinutasRecibos
                    frmVisor.NombreReporte = "RepScnCN24.rpt"
                    frmVisor.Text = "Listado de Minutas y Recibos por Fecha de Recibos"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFechas") = "' Recibos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                    'Strsql = "SELECT ISNULL(SUM(Total), 0) AS Total " & _
                    '         "FROM  (SELECT nMontoDeposito AS Total, sNumeroDeposito FROM vwScnListadoMinutasRecibos " & _
                    '         "WHERE (dFechaDeposito BETWEEN CONVERT(DATETIME, '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "', 102)) " & _
                    '         "AND (nStbDepartamentoID = " & Me.CboDepartamento.Columns("nStbDepartamentoID").Value & ") GROUP BY nMontoDeposito, sNumeroDeposito) AS a"
                    Strsql = "SELECT ISNULL(SUM(Total), 0) AS Total " & _
                             "FROM  (SELECT nMontoDeposito AS Total, sNumeroDeposito FROM vwScnListadoMinutasRecibos " & _
                             "WHERE (dFechaRecibo BETWEEN CONVERT(DATETIME, '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "', 102)) " & _
                             "AND (nStbDepartamentoID = " & Me.CboDepartamento.Columns("nStbDepartamentoID").Value & ") GROUP BY nMontoDeposito, sNumeroDeposito) AS a"
                    frmVisor.Formulas("nTotalDepositos") = XcDatos.ExecuteScalar(Strsql)

                Case EnumReportes.ListadoRecibosDepositados
                    frmVisor.NombreReporte = "RepScnCN25.rpt"
                    frmVisor.Text = "Detalle de Ingresos por Recuperación de Créditos"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFechas") = "' Recibos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.ListadoMinutasSinComprobantes
                    frmVisor.NombreReporte = "RepScnCN26.rpt"
                    frmVisor.Text = "Listado de Minutas Sin Comprobantes Asociados"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFechas") = "' Minutas Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.ListadoConsecutivoRecibosRango
                    frmVisor.NombreReporte = "RepSteTE33.rpt"
                    frmVisor.Text = "Consecutivo por Rango de Recibos Oficiales Activos (En Crédito)"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoRecibos") = "' Recibos Del " & Me.txtReciboIni.Text & " Al " & Me.txtReciboFin.Text & " '"

                Case EnumReportes.ListadoFaltantesRecibos
                    frmVisor.NombreReporte = "RepSteTE34.rpt"
                    frmVisor.Text = "Listado de Recibos Faltantes en un Rango (En Crédito)"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoRecibos") = "' Recibos Del " & Me.txtReciboIni.Text & " Al " & Me.txtReciboFin.Text & " '"

                Case EnumReportes.ListadoConsecutivoRecibosRangoTE
                    frmVisor.NombreReporte = "RepSteTE36.rpt"
                    frmVisor.Text = "Consecutivo por Rango de Recibos Oficiales Activos (En Tesorería)"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoRecibos") = "' Recibos Del " & Me.txtReciboIni.Text & " Al " & Me.txtReciboFin.Text & " '"

                Case EnumReportes.ListadoFaltantesRecibosTE
                    frmVisor.NombreReporte = "RepSteTE37.rpt"
                    frmVisor.Text = "Listado de Recibos Faltantes en un Rango (En Tesorería)"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoRecibos") = "' Recibos Del " & Me.txtReciboIni.Text & " Al " & Me.txtReciboFin.Text & " '"

                Case EnumReportes.ListadoRecibosCredito
                    frmVisor.NombreReporte = "RepSteTE41.rpt"
                    frmVisor.Text = "Listado de Recibos Oficiales"
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFechas") = "' Recibos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                Case EnumReportes.ConsolidadoRecibosCredito
                    frmVisor.NombreReporte = "RepSteTE42.rpt"
                    frmVisor.Text = "Consolidado de Recibos Oficiales"
                    frmVisor.Formulas("RangoFechas") = "' Recibos Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

            End Select

            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing

            XcDatos.Close()
            XcDatos = Nothing
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
            'CargarMercado(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
        'HabilitarComboMercado()

    End Sub

    Private Sub HabilitarComboMunicipio()
        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            If Me.NomRep <> EnumReportes.ConsecutivoRecibosArqueo And Me.NomRep <> EnumReportes.TalonariosNoArqueados And Me.NomRep <> EnumReportes.TalonariosEntregados And Me.NomRep <> EnumReportes.ListadoMinutasRecibos And Me.NomRep <> EnumReportes.ListadoRecibosDepositados And Me.NomRep <> EnumReportes.ConsecutivoRecibos And Me.NomRep <> EnumReportes.ListadoMinutasSinComprobantes And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE And Me.NomRep <> EnumReportes.ListadoRecibosCredito And Me.NomRep <> EnumReportes.ConsolidadoRecibosCredito Then
                Me.cboMunicipio.Enabled = True
            End If
            'Me.cboBarrio.Enabled = True
            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboMercado.Enabled = False
            Else
                If Me.NomRep <> EnumReportes.ConsecutivoRecibosArqueo And Me.NomRep <> EnumReportes.TalonariosNoArqueados And Me.NomRep <> EnumReportes.TalonariosEntregados And Me.NomRep <> EnumReportes.ListadoMinutasRecibos And Me.NomRep <> EnumReportes.ListadoRecibosDepositados And Me.NomRep <> EnumReportes.ConsecutivoRecibos And Me.NomRep <> EnumReportes.ListadoMinutasSinComprobantes And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE And Me.NomRep <> EnumReportes.ListadoRecibosCredito And Me.NomRep <> EnumReportes.ConsolidadoRecibosCredito Then
                    Me.cboMercado.Enabled = True
                End If
            End If
        Else
            Me.cboMunicipio.Enabled = False
            Me.cboMercado.Enabled = False
        End If
    End Sub

    Private Sub HabilitarComboMercado()
        If Me.cboMunicipio.SelectedIndex > 0 Then
            If Me.NomRep <> EnumReportes.ConsecutivoRecibosArqueo And Me.NomRep <> EnumReportes.TalonariosNoArqueados And Me.NomRep <> EnumReportes.TalonariosEntregados And Me.NomRep <> EnumReportes.ListadoMinutasRecibos And Me.NomRep <> EnumReportes.ListadoRecibosDepositados And Me.NomRep <> EnumReportes.ConsecutivoRecibos And Me.NomRep <> EnumReportes.ListadoMinutasSinComprobantes And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE And Me.NomRep <> EnumReportes.ListadoRecibosCredito And Me.NomRep <> EnumReportes.ConsolidadoRecibosCredito Then
                Me.cboMercado.Enabled = True
            End If
        Else
            Me.cboMercado.Enabled = False
        End If
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then

            CargarMercado(0)
            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboMercado.Enabled = False
            Else
                If Me.NomRep <> EnumReportes.ConsecutivoRecibosArqueo And Me.NomRep <> EnumReportes.TalonariosEntregados And Me.NomRep <> EnumReportes.ListadoMinutasRecibos And Me.NomRep <> EnumReportes.ListadoRecibosDepositados And Me.NomRep <> EnumReportes.ListadoMinutasSinComprobantes And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRango And Me.NomRep <> EnumReportes.ListadoFaltantesRecibos And Me.NomRep <> EnumReportes.ListadoConsecutivoRecibosRangoTE And Me.NomRep <> EnumReportes.ListadoFaltantesRecibosTE Then
                    Me.cboMercado.Enabled = True
                End If
            End If
        Else
            CargarMercado(1)
        End If
        'HabilitarComboMercado()
    End Sub

    Private Sub FrmSccParametroListadoCreditosMercados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            If Me.sColor = "Verde" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
            ElseIf Me.sColor = "Naranja" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Tesorería")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Contabilidad")
            End If

            InicializarVariables()
            CargarDepartamento()
            CargarTipoPrograma()
            HabilitarComboMunicipio()

            If Me.NomRep = EnumReportes.ListadoMercados Then
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

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmScnParametroListadoCreditosMercados_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        ChkPendiente.Visible = False
        If Me.NomRep = EnumReportes.ListadoMercados Then
            Me.Text = " Listado de Créditos por Mercados"
        ElseIf Me.NomRep = EnumReportes.ConsecutivoRecibosArqueo Then
            Me.Text = " Consecutivo de Recibos por Fecha de Arqueos Cerrados"
        ElseIf Me.NomRep = EnumReportes.ConsecutivoRecibos Then
            Me.Text = " Consecutivo de Recibos por Fecha de Recibos Activos"
        ElseIf Me.NomRep = EnumReportes.TalonariosNoArqueados Then
            Me.Text = " Recibos Entregados Sin Arqueo Cerrado"
        ElseIf Me.NomRep = EnumReportes.TalonariosEntregados Then
            Me.Text = " Talonarios de Recibos Entregados"
        ElseIf Me.NomRep = EnumReportes.ListadoMinutasRecibos Then
            Me.Text = " Listado de Minutas y Recibos por Fecha Recibos"
        ElseIf Me.NomRep = EnumReportes.ListadoRecibosDepositados Then
            Me.Text = " Detalle de Ingresos por Recuperación de Créditos"
        ElseIf Me.NomRep = EnumReportes.ListadoMinutasSinComprobantes Then
            Me.Text = " Listado Minutas Sin Comprobantes Asociados"
        ElseIf Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRango Then
            Me.Text = " Consecutivo de Recibos por Rango de Recibos (En Crédito)"
        ElseIf Me.NomRep = EnumReportes.ListadoFaltantesRecibos Then
            Me.Text = " Listado de Recibos Faltantes en un Rango (En Crédito)"
        ElseIf Me.NomRep = EnumReportes.ListadoConsecutivoRecibosRangoTE Then
            Me.Text = " Consecutivo de Recibos por Rango de Recibos (En Tesorería)"
            ChkPendiente.Visible = True
        ElseIf Me.NomRep = EnumReportes.ListadoFaltantesRecibosTE Then
            Me.Text = " Listado de Recibos Faltantes en un Rango (En Tesorería)"
        ElseIf Me.NomRep = EnumReportes.ListadoRecibosCredito Then
            Me.Text = " Listado de Recibos Oficiales (En Crédito)"
        ElseIf Me.NomRep = EnumReportes.ConsolidadoRecibosCredito Then
            Me.Text = " Consolidado de Recibos Oficiales (En Crédito)"
        End If
    End Sub

    Private Sub txtReciboIni_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReciboIni.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtReciboFin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtReciboFin.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub grpdatos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpdatos.Enter

    End Sub

    Private Sub RadMercado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadMercado.CheckedChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarMercado(0)
        End If
    End Sub

    Private Sub RadCooperativa_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCooperativa.CheckedChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarMercado(0)
        End If
    End Sub
End Class