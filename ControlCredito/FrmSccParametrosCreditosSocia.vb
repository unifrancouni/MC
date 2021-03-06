Imports System.Data.OleDb
Imports Microsoft.Office.Interop
Imports System.Data.SqlClient

Public Class FrmSccParametrosCreditosSocia

    Dim n As Integer
    Dim strFileName As String

    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim strColorFrm As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
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
        NumeroDesembolsos = 1
        ListaDeMora = 2
        ListaDeMoraSocias = 3
        GruposCancelados = 4
        sociasCancelados = 5
        ListadoDeRecibosPorTipoFecha = 6
        ListaSociasMonto = 7
        ListadoDesembolsos = 8
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
    ' Author		    		:	Yesenia Guti�rrez
    ' Date			    		:	13/03/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar par�metros de Delegaci�n.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

            'Departamento de la Delegaci�n
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
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripci�n:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selecci�n.
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
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                         " From StbDepartamento a " &
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

            Me.CboDepartamento.Columns("sCodigo").Caption = "C�digo"
            Me.CboDepartamento.Columns("Descripcion").Caption = "Descripci�n"

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboDepartamento.ListCount > 0 And IntPermiteConsultar = 1 Then
                'If mNomRep <> EnumReportes.ListaDeMoraSocias Then '****original
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.CboDepartamento.SelectedIndex = 0
            Else
                If Me.CboDepartamento.ListCount > 0 And IntPermiteConsultar = 0 Then
                    XdsCombos("Departamento").AddRow()
                    'XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                    XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                    XdsCombos("Departamento").ValueField("Orden") = 0
                    XdsCombos("Departamento").UpdateLocal()
                    XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                    Me.CboDepartamento.SelectedIndex = 0
                End If
            End If
            HabilitarComboMunicipio()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMunicipio
    ' Descripci�n:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selecci�n.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer)
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                             " From StbMunicipio a " &
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                             " From StbMunicipio a " &
                             " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" &
                             " Order by a.sCodigo"
                End If
            Else
                If intLimpiarID = 1 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                                                " From StbMunicipio a " &
                                                " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" &
                                                " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                                            " From StbMunicipio a " &
                                            " WHERE a.nStbMunicipioID = 0" &
                                            " Order by a.sCodigo"
                End If
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

            Me.cboMunicipio.Columns("sCodigo").Caption = "C�digo"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripci�n"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboMunicipio.ListCount > 0 Then
                'If mNomRep <> EnumReportes.ListaDeMoraSocias Then
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
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarBarrio
    ' Descripci�n:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selecci�n.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                             " From StbDistrito a " &
                             " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                         " From StbDistrito a " &
                         " Where a.nStbDistritoID = 0" &
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

            Me.cboDistrito.Columns("sCodigo").Caption = "C�digo"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripci�n"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDistrito.ListCount > 0 Then
                'If mNomRep <> EnumReportes.ListaDeMoraSocias Then
                XdsCombos("Distrito").AddRow()
                XdsCombos("Distrito").ValueField("Descripcion") = "Todos"
                XdsCombos("Distrito").ValueField("nStbDistritoID") = -19
                XdsCombos("Distrito").ValueField("Orden") = 0
                XdsCombos("Distrito").UpdateLocal()
                XdsCombos("Distrito").Sort = "Orden,sCodigo asc"
                Me.cboDistrito.SelectedIndex = 0
                'Else
                'Me.cboDistrito.SelectedIndex = 0
                'End If
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
                Strsql = " Select dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre as Descripcion,1 as Orden " &
                             " FROM         dbo.StbBarrio INNER JOIN" &
                             " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " &
                             "  dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " &
                             CadWhere & " Order by dbo.StbBarrio.sCodigo"
            Else
                Strsql = " Select dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre as Descripcion,1 as Orden " &
                             " FROM     dbo.StbBarrio INNER JOIN" &
                             " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " &
                             "  dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " &
                            " Where dbo.StbBarrio.nStbBarrioID = 0" &
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

            Me.cboBarrio.Columns("sCodigo").Caption = "C�digo"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripci�n"

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
                MsgBox("Debe seleccionar un Departamento v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar un Departamento v�lido.")
                Me.CboDepartamento.Focus()
                GoTo salir
            End If

            If Me.mNomRep <> EnumReportes.ListadoDeRecibosPorTipoFecha Then
                'Municipio
                If Me.cboMunicipio.SelectedIndex = -1 And Me.cboMunicipio.Text <> "Todos" Then
                    MsgBox("Debe seleccionar un Municipio v�lido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio v�lido.")
                    Me.cboMunicipio.Focus()
                    GoTo salir
                End If

                'Distrito
                If Me.cboDistrito.SelectedIndex = -1 And Me.cboDistrito.Text <> "Todos" Then
                    MsgBox("Debe seleccionar un Distrito v�lido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboDistrito, "Debe seleccionar un Distrito v�lido.")
                    Me.cboDistrito.Focus()
                    GoTo salir
                End If

                'Incluido Barrio
                If Me.cboBarrio.SelectedIndex = -1 And Me.cboBarrio.Text <> "Todos" Then
                    MsgBox("Debe seleccionar un Lugar de Pago v�lido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboBarrio, "Debe seleccionar un Lugar de Pago v�lido.")
                    Me.cboBarrio.Focus()
                    GoTo salir
                End If

                If CboVeces.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar El n�mero de cr�ditos para las socias.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboVeces, "Debe seleccionar El n�mero de cr�ditos para las socias.")
                    Me.CboVeces.Focus()
                    GoTo salir
                End If
            End If

            If mNomRep = EnumReportes.ListaDeMora Or mNomRep = EnumReportes.ListaDeMoraSocias Or Me.mNomRep = EnumReportes.ListaSociasMonto Then
                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final v�lida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final v�lida.")
                    Me.CdeFechaFinal.Focus()
                    GoTo salir
                End If
            End If

            If mNomRep = EnumReportes.GruposCancelados Then
                'Fecha de Inicio:
                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio v�lida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio v�lida.")
                    Me.cdeFechaInicial.Focus()
                    GoTo salir
                End If

                'Fecha de Corte:
                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final v�lida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final v�lida.")
                    Me.CdeFechaFinal.Focus()
                    GoTo salir
                End If

                'Fecha de Corte no menor:
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    GoTo salir
                End If
            End If

            If Me.mNomRep = EnumReportes.ListaSociasMonto Then
                If Me.cboMontoAprobado.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Monto v�lido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboMontoAprobado, "Debe seleccionar un Monto v�lido.")
                    Me.cboMontoAprobado.Focus()
                    GoTo salir
                End If
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Function VecesCredito(ByVal XFiltro As String) As String
        Dim SubCadFiltro As String = ""
        Select Case CboVeces.SelectedIndex
            Case 0
                SubCadFiltro = ""
            Case 1, 2, 3
                SubCadFiltro = "TotalCreditos=" & CboVeces.SelectedIndex & " "
            Case 4
                SubCadFiltro = "TotalCreditos>=4 "
        End Select
        If Trim(SubCadFiltro) <> "" Then
            If Trim(XFiltro) = "" Then
                XFiltro = "  Where " & SubCadFiltro
            Else
                XFiltro = XFiltro & "  And  " & SubCadFiltro
            End If
        End If
        Return XFiltro
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        '----------------------------------------------------------------------------------
        'Llama a los reportes de consolidados y detalle de cr�ditos por distritos y barrios
        '----------------------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro, SubCadFiltro As String

        Dim CadSql As String


        Try
            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""

            Select Case mNomRep

                Case EnumReportes.ListadoDeRecibosPorTipoFecha
                    If CboDepartamento.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbDepartamentoID") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    Else
                        frmVisor.Parametros("@nStbDepartamentoID") = Nothing
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        'If Trim(Filtro) <> "" Then
                        frmVisor.Parametros("@nStbMunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        frmVisor.Parametros("@nStbMunicipioID") = Nothing
                        'End If
                    End If


                    If Me.cboMunicipio.Columns("nStbMunicipioID").Text = "" Then
                    Else
                        If Me.cboMunicipio.Columns("nStbMunicipioID").Value = 83 Then 'Managua
                            If cboDistrito.SelectedIndex > 0 Then
                                'If Trim(Filtro) <> "" Then
                                frmVisor.Parametros("@nStbDistritoID") = Me.cboDistrito.Columns("nStbDistritoID").Value
                            Else
                                frmVisor.Parametros("@nStbDistritoID") = Nothing
                                'End If
                            End If
                        Else
                            frmVisor.Parametros("@nStbDistritoID") = 1
                        End If
                    End If




                    If cboBarrio.SelectedIndex > 0 Then
                        'If Trim(Filtro) <> "" Then
                        frmVisor.Parametros("@nStbBarrioID") = Me.cboBarrio.Columns("nStbBarrioID").Value
                    Else
                        frmVisor.Parametros("@nStbBarrioID") = Nothing
                        'End If
                    End If

                    frmVisor.Parametros("@FechaInicio") = Format("yyyy-MM-dd HH:mm:ss", Me.cdeFechaInicial.Text)
                    frmVisor.Parametros("@FechaFinal") = Format("yyyy-MM-dd HH:mm:ss", Me.CdeFechaFinal.Text)
                    frmVisor.Parametros("@DigitadorId") = cboUsuario.Columns("NusuarioCreacionId").Value
                    frmVisor.Parametros("@TipoFecha") = IIf(Me.rdoRecibo.Checked = True, 1, 0)
                    frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked = True, 1, IIf(Me.RdVentanadeGenero.Checked = True, 2, 3))

                    Dim stipoFecha As String = IIf(Me.rdoRecibo.Checked = True, "Recibo", "Creaci�n")
                    frmVisor.Formulas("TipoFecha") = "'" & stipoFecha & "'"
                    frmVisor.Text = "Listado de recibos por fecha de " & stipoFecha
                    frmVisor.NombreReporte = "RepSccCC76.rpt"

                    frmVisor.Formulas("Digitador") = IIf(Me.cboUsuario.SelectedIndex = 0, "'Todos'", "'" & Me.cboUsuario.Columns("NombreUsuario").Value & "'")

                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.WindowState = FormWindowState.Maximized

                    If Not String.IsNullOrEmpty(Trim(Filtro)) Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                Case EnumReportes.NumeroDesembolsos

                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {vwSccListadoCreditosPorSocia.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSccListadoCreditosPorSocia.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {vwSccListadoCreditosPorSocia.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {vwSccListadoCreditosPorSocia.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nStbMercadoVerificadoID}=1 "
                        Else
                            Filtro = " {vwSccListadoCreditosPorSocia.nStbMercadoVerificadoID}=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Or Me.RadCooperativa.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nStbMercadoVerificadoID}<>1 "
                        Else
                            Filtro = " {vwSccListadoCreditosPorSocia.nStbMercadoVerificadoID}<>1 "
                        End If
                    End If

                    IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS"))

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nFondoPresupuestario}=" & IIf(RdPresupuesto.Checked, "1", "0")
                        Else
                            Filtro = " {vwSccListadoCreditosPorSocia.nFondoPresupuestario}=" & IIf(RdPresupuesto.Checked, "1", "0")
                        End If
                    End If

                    If Trim(Filtro) <> "" Then
                        'Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.TipoPrograma}=" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked, "2", "3"))
                        If RdUsuraCero.Checked Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.TipoPrograma}=1"
                        ElseIf RdVentanadeGenero.Checked Then
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.TipoPrograma}=2"
                        Else
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.TipoPrograma}=3"
                        End If
                    Else
                        'Filtro = " {vwSccListadoCreditosPorSocia.TipoPrograma}=" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked, "2", "3"))
                        If RdUsuraCero.Checked Then
                            Filtro = " {vwSccListadoCreditosPorSocia.TipoPrograma}=1"
                        ElseIf RdVentanadeGenero.Checked Then
                            Filtro = " {vwSccListadoCreditosPorSocia.TipoPrograma}=2"
                        Else
                            Filtro = " {vwSccListadoCreditosPorSocia.TipoPrograma}=3"
                        End If
                    End If

                    SubCadFiltro = ""
                    Select Case CboVeces.SelectedIndex
                        Case 1, 2, 3
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=" & CboVeces.SelectedIndex & " "
                        Case 4
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=4 "
                        Case 5
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=5 "
                        Case 6
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=6 "
                        Case 7
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=7 "
                        Case 8
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=8 "
                        Case 9
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=9 "
                        Case 10
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}=10 "
                        Case 11
                            SubCadFiltro = "{vwSccListadoCreditosPorSocia.TotalCreditos}>=11 "
                    End Select

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & IIf(Trim(SubCadFiltro) = "", "", " And ") & SubCadFiltro
                    Else
                        Filtro = SubCadFiltro
                    End If

                    Select Case Me.CboVeces.SelectedIndex
                        Case 0
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con al menos Un Cr�dito " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 1
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con un solo Cr�dito " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 2
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Dos Cr�ditos " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 3
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Tres Cr�ditos " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 4
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Cuatro " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 5
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Cinco " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 6
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Seis " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 7
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Siete " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 8
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Ocho " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 9
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Nueve " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 10
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Diez " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                        Case 11
                            frmVisor.Formulas("Parametro") = "'Incluido Socias con Once o m�s Cr�ditos " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                            'Case 4
                            '    frmVisor.Formulas("Parametro") = "'Incluido Socias con Cuatro o m�s Cr�ditos " & IIf(RdMercado.Checked, "En los Mercados", IIf(Me.RdDistrito.Checked, "En los Distritos", "")) & "'"
                    End Select

                    If cboMontoAprobado.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            'MsgBox(Replace(Trim(Me.cboMontoAprobado.Text), ",", ""))
                            'MsgBox(Trim(Me.cboMontoAprobado.Text))
                            Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nMontoCreditoAprobado}=" & Replace(Trim(Me.cboMontoAprobado.Text), ",", "")
                        End If
                    Else
                        'Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nMontoCreditoAprobado}<>10000 And {vwSccListadoCreditosPorSocia.nMontoCreditoAprobado}<>1850 And {vwSccListadoCreditosPorSocia.nMontoCreditoAprobado}<>3700 And {vwSccListadoCreditosPorSocia.nMontoCreditoAprobado}<>4600 And {vwSccListadoCreditosPorSocia.nMontoCreditoAprobado}<>5500"
                    End If



                    ''Select Case cboReporte.SelectedIndex
                    Me.Cursor = Cursors.WaitCursor
                    frmVisor.NombreReporte = "RepSccCC25.rpt"
                    frmVisor.Text = "Listado de Socias Con Desembolsos "
                    'frmVisor.CRVReportes.SelectionFormula = Filtro
                    frmVisor.CRVReportes.ShowRefreshButton = False
                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & "'"
                    'frmVisor.Formulas("TipoPrograma") = "'" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked, "2", "3")) & "'"
                    If RdUsuraCero.Checked Then
                        frmVisor.Formulas("TipoPrograma") = "'1'"
                    ElseIf RdVentanadeGenero.Checked Then
                        frmVisor.Formulas("TipoPrograma") = "'2'"
                    Else
                        frmVisor.Formulas("TipoPrograma") = "'3'"
                    End If

                    If Me.RadCooperativa.Checked Or Me.RdMercado.Checked Then
                        Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.nCooperativa} = " & IIf(Me.RadCooperativa.Checked, 1, 0)
                    End If

                    If Me.chkCancelados.Checked And Me.NomRep = 1 Then
                        Filtro = Filtro & " And {vwSccListadoCreditosPorSocia.sEstadoFicha} = '7'"
                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And ( {vwSccListadoCreditosPorSocia.dFechaDesembolso} in " & String.Format("Date({0}, {1}, {2}) to Date({3}, {4}, {5}))", CDate(cdeFechaInicial.Value).Year, CDate(cdeFechaInicial.Value).Month, CDate(cdeFechaInicial.Value).Day, CDate(CdeFechaFinal.Value).Year, CDate(CdeFechaFinal.Value).Month, CDate(CdeFechaFinal.Value).Day)
                    Else
                        Filtro = Filtro & " ( {vwSccListadoCreditosPorSocia.dFechaDesembolso} in " & String.Format("Date({0}, {1}, {2}) to Date({3}, {4}, {5}))", CDate(cdeFechaInicial.Value).Year, CDate(cdeFechaInicial.Value).Month, CDate(cdeFechaInicial.Value).Day, CDate(CdeFechaFinal.Value).Year, CDate(CdeFechaFinal.Value).Month, CDate(CdeFechaFinal.Value).Day)
                    End If

                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.Formulas("Parametros") = "' Par�metros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ") (Monto C$: " & Me.cboMontoAprobado.Text & ")'"
                    frmVisor.Formulas("FechaINI") = "'" + CDate(Me.cdeFechaInicial.Value).ToString("dd/MM/yyyy") + "'"
                    frmVisor.Formulas("FechaFIN") = "'" + CDate(Me.CdeFechaFinal.Value).ToString("dd/MM/yyyy") + "'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.WindowState = FormWindowState.Maximized

                Case EnumReportes.ListaDeMora

                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteNoPagadosPeriodos.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteNoPagadosPeriodos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nStbMercadoVerificadoID}=1 "
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.nStbMercadoVerificadoID}=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Or Me.RadCooperativa.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nStbMercadoVerificadoID}<>1 "
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.nStbMercadoVerificadoID}<>1 "
                        End If
                    End If

                    If Me.RdCarteraVencida.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.Vigente}>0"
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.Vigente}>0"
                        End If

                    ElseIf Me.RdCarteraVigente.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.Vigente}=0"
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.Vigente}=0"
                        End If
                    End If

                    If Me.RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nFondoPresupuestario}=1"
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.nFondoPresupuestario}=1"
                        End If

                    ElseIf Me.RdExterno.Checked = True Then

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.nFondoPresupuestario}=0"
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodos.nFondoPresupuestario}=0"
                        End If

                    End If


                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {spSccReporteNoPagadosPeriodos.TipoPrograma}=" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked, "2", "3"))
                    Else
                        Filtro = " {spSccReporteNoPagadosPeriodos.TipoPrograma}=" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked, "2", "3"))
                    End If

                    Dim tipoTurismo As String = ""

                    tipoTurismo &= IIf(rdTurismoNVT.Checked, "1,", "")
                    tipoTurismo &= IIf(rdTurismoVT.Checked, "2,", "")
                    tipoTurismo &= IIf(rdTurismoT.Checked, "3,", "")

                    If tipoTurismo.EndsWith(",") Then
                        tipoTurismo = tipoTurismo.Substring(0, tipoTurismo.Length - 1)
                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And ( "

                        If (rdTurismoSR.Checked) Then
                            Filtro = Filtro & " IsNull({spSccReporteNoPagadosPeriodos.nTipoTurismo}) "
                        End If
                        If rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " or {spSccReporteNoPagadosPeriodos.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If
                        If Not rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " {spSccReporteNoPagadosPeriodos.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If

                        Filtro = Filtro & " ) "
                    Else
                        Filtro = " ( "

                        If (rdTurismoSR.Checked) Then
                            Filtro = Filtro & " IsNull({spSccReporteNoPagadosPeriodos.nTipoTurismo}) "
                        End If
                        If rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " or {spSccReporteNoPagadosPeriodos.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If
                        If Not rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " {spSccReporteNoPagadosPeriodos.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If

                        Filtro = Filtro & " ) "
                    End If


                    frmVisor.Formulas("TipoPrograma") = "'" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked, "2", "3")) & "'"
                    frmVisor.NombreReporte = "RepSccCC27.rpt"
                    frmVisor.Text = "Listado de Socias en Mora"
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                    frmVisor.CRVReportes.ShowRefreshButton = False
                    frmVisor.Formulas("Parametros") = "' Par�metros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("TipoCredito") = "'" & IIf(RdActas.Checked, "DISTRITOS, MERCADOS Y COOPERATIVAS", IIf(Me.RdDistrito.Checked, "SOLO DISTRITOS", IIf(Me.RadCooperativa.Checked, "SOLO COOPERATIVAS", "SOLO MERCADOS")))  '& "'"
                    frmVisor.Formulas("TipoCredito") = frmVisor.Formulas("TipoCredito") & IIf(Me.RdCarteraVigente.Checked, " CON CARTERA VIGENTE ", IIf(Me.RdCarteraVencida.Checked, " CON CARTERA  VENCIDA", ""))  '& "'"
                    frmVisor.Formulas("TipoCredito") = frmVisor.Formulas("TipoCredito") & IIf(Me.RdTodos.Checked, " CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(Me.RdPresupuesto.Checked, " CON FONDOS DEL PRESUPUESTO", " CON FONDOS EXTERNOS")) & "'"
                    frmVisor.Parametros("@FechaCorte") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.Columns("nStbDepartamentoID").Value = -19, -1, Me.CboDepartamento.Columns("nStbDepartamentoID").Value)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.Text = "Todos", -1, Me.cboMunicipio.Columns("nStbMunicipioID").Value)
                    ''IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    'Filtrar por mercados o cooperativas

                    Dim sTipoTurismo As String = ""

                    sTipoTurismo &= IIf(rdTurismoSR.Checked, "Sin Registrar, ", "")
                    sTipoTurismo &= IIf(rdTurismoNVT.Checked, "No Vinculados, ", "")
                    sTipoTurismo &= IIf(rdTurismoVT.Checked, "Vinculados, ", "")
                    sTipoTurismo &= IIf(rdTurismoT.Checked, "Turismo, ", "")

                    frmVisor.Formulas("Turismo") = "'{0}'".Replace("{0}", sTipoTurismo)


                    If Me.RadCooperativa.Checked Or Me.RdMercado.Checked Then
                        frmVisor.Parametros("@nCooperativa") = IIf(Me.RadCooperativa.Checked, 1, 0)
                    Else
                        frmVisor.Parametros("@nCooperativa") = -1
                    End If

                    frmVisor.WindowState = FormWindowState.Maximized

                Case EnumReportes.ListaDeMoraSocias

                    ''Modificado Josu� Herrera 16-03-2012
                    If CboDepartamento.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbDepartamentoID") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    Else
                        frmVisor.Parametros("@nStbDepartamentoID") = 0
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbMunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        frmVisor.Parametros("@nStbMunicipioID") = 0
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbDistritoID") = Me.cboDistrito.Columns("nStbDistritoID").Value
                    Else
                        frmVisor.Parametros("@nStbDistritoID") = 0
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbBarrioID") = Me.cboBarrio.Columns("nStbBarrioID").Value
                    Else
                        frmVisor.Parametros("@nStbBarrioID") = 0
                    End If
                    ''Fin modificado

                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodosSocias.nStbMercadoVerificadoID}=1 "
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodosSocias.nStbMercadoVerificadoID}=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Or Me.RadCooperativa.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodosSocias.nStbMercadoVerificadoID}<>1 "
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodosSocias.nStbMercadoVerificadoID}<>1 "
                        End If
                    End If

                    If Me.RdCarteraVencida.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodosSocias.Vigente}>0"
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodosSocias.Vigente}>0"
                        End If

                    ElseIf Me.RdCarteraVigente.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosPeriodosSocias.Vigente}=0"
                        Else
                            Filtro = " {spSccReporteNoPagadosPeriodosSocias.Vigente}=0"
                        End If

                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {spSccReporteNoPagadosPeriodosSocias.TipoPrograma}=" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked = True, "2", "3"))
                    Else
                        Filtro = " {spSccReporteNoPagadosPeriodosSocias.TipoPrograma}=" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked = True, "2", "3"))
                    End If

                    Dim tipoTurismo As String = ""

                    tipoTurismo &= IIf(rdTurismoNVT.Checked, "1,", "")
                    tipoTurismo &= IIf(rdTurismoVT.Checked, "2,", "")
                    tipoTurismo &= IIf(rdTurismoT.Checked, "3,", "")

                    If tipoTurismo.EndsWith(",") Then
                        tipoTurismo = tipoTurismo.Substring(0, tipoTurismo.Length - 1)
                    End If

                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And ( "

                        If (rdTurismoSR.Checked) Then
                            Filtro = Filtro & " IsNull({spSccReporteNoPagadosPeriodosSocias.nTipoTurismo}) "
                        End If
                        If rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " or {spSccReporteNoPagadosPeriodosSocias.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If
                        If Not rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " {spSccReporteNoPagadosPeriodosSocias.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If

                        Filtro = Filtro & " ) "
                    Else
                        Filtro = " ( "

                        If (rdTurismoSR.Checked) Then
                            Filtro = Filtro & " IsNull({spSccReporteNoPagadosPeriodosSocias.nTipoTurismo}) "
                        End If
                        If rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " or {spSccReporteNoPagadosPeriodosSocias.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If
                        If Not rdTurismoSR.Checked And (rdTurismoNVT.Checked Or rdTurismoVT.Checked Or rdTurismoT.Checked) Then
                            Filtro = Filtro & " {spSccReporteNoPagadosPeriodosSocias.nTipoTurismo} in [{0}] ".Replace("{0}", tipoTurismo)
                        End If

                        Filtro = Filtro & " ) "
                    End If


                    frmVisor.NombreReporte = "RepSccCC37.rpt"
                    frmVisor.Text = "Listado de Socias en Mora"
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                    frmVisor.CRVReportes.ShowRefreshButton = False
                    frmVisor.Formulas("TipoPrograma") = "'" & IIf(RdUsuraCero.Checked, "1", IIf(Me.RdVentanadeGenero.Checked = True, "2", "3")) & "'"
                    frmVisor.Formulas("Parametros") = "' Par�metros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("TipoCredito") = "'" & IIf(RdActas.Checked, "DISTRITOS, MERCADOS Y COOPERAIVAS", IIf(Me.RdDistrito.Checked, "SOLO DISTRITOS", IIf(Me.RadCooperativa.Checked, "SOLO COOPERATIVAS", "SOLO MERCADOS")))  '& "'"
                    frmVisor.Formulas("TipoCredito") = frmVisor.Formulas("TipoCredito") & IIf(Me.RdCarteraVigente.Checked, " CON CARTERA VIGENTE ", IIf(Me.RdCarteraVencida.Checked, " CON CARTERA  VENCIDA", "")) & "'"
                    frmVisor.Parametros("@FechaCorte") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")


                    Dim sTipoTurismo As String = ""

                    sTipoTurismo &= IIf(rdTurismoSR.Checked, "Sin Registrar, ", "")
                    sTipoTurismo &= IIf(rdTurismoNVT.Checked, "No Vinculados, ", "")
                    sTipoTurismo &= IIf(rdTurismoVT.Checked, "Vinculados, ", "")
                    sTipoTurismo &= IIf(rdTurismoT.Checked, "Turismo, ", "")

                    frmVisor.Formulas("Turismo") = "'{0}'".Replace("{0}", sTipoTurismo)


                    ' Filtro por mercado o cooperativa 
                    If Me.RadCooperativa.Checked Or Me.RdMercado.Checked Then
                        frmVisor.Parametros("@nCooperativa") = IIf(Me.RadCooperativa.Checked, 1, 0)
                    Else
                        frmVisor.Parametros("@nCooperativa") = -1
                    End If

                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    frmVisor.WindowState = FormWindowState.Maximized

                Case EnumReportes.GruposCancelados
                    ' Se Filtra por programa
                    If RdUsuraCero.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.CodigoPrograma}='1'"
                        Else
                            Filtro = "  {vwSccPagaresSocias.CodigoPrograma}='1'"
                        End If
                    Else
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.CodigoPrograma}='2'"
                        Else
                            Filtro = "  {vwSccPagaresSocias.CodigoPrograma}='2'"
                        End If
                    End If

                    If CboDepartamento.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        Else
                            Filtro = "  {vwSccPagaresSocias.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        End If
                    End If
                    '2. Si se indic� un Municipio en particular:

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSccPagaresSocias.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSccPagaresSocias.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    '3. Si se indic� un Distrito en Particular:
                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {vwSccPagaresSocias.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    '4. Si se indic� un Barrio en Particular:
                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {vwSccPagaresSocias.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    '5. Si se indic� filtrar por tipo creditos de distrito o mercado:

                    If Me.RdDistrito.Checked = True Then

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbMercadoVerificadoID}=1"
                        Else
                            Filtro = " And {vwSccPagaresSocias.nStbMercadoVerificadoID}=1"
                        End If
                    ElseIf Me.RdMercado.Checked = True Then

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccPagaresSocias.nStbMercadoVerificadoID}<>1"
                        Else
                            Filtro = " And {vwSccPagaresSocias.nStbMercadoVerificadoID}<>1"
                        End If

                    End If

                    '7. Entre el Rango de Fechas de Corte Indicadas (Filtro por Fecha de Notificaci�n del Cr�dito):  
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSccPagaresSocias.dFechaNotificacion} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = " {vwSccPagaresSocias.dFechaNotificacion} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    End If
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSccPagaresSocias.dFechaNotificacion} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = " {vwSccPagaresSocias.dFechaNotificacion} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                    End If
                    '4. Filtro por Tipo de Fondos:
                    If Me.RdPresupuesto.Checked Then 'Fondos Presupuesto
                        Filtro = Filtro & " And {vwSccPagaresSocias.nFondoPresupuestario} = 1"
                    ElseIf Me.RdExterno.Checked Then  'Fondos Externos
                        Filtro = Filtro & " And {vwSccPagaresSocias.nFondoPresupuestario} = 0"
                    End If

                    frmVisor.NombreReporte = "RepSccCC71.rpt"
                    frmVisor.Text = "Listado de Grupos con Creditos Cancelados"
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                    frmVisor.CRVReportes.ShowRefreshButton = False
                    frmVisor.Formulas("RangoFechas") = "' DEL " + Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd") + " AL " + Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd") + " '"
                    frmVisor.Formulas("Parametros") = "' Par�metros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")(" & IIf(Me.RdMercado.Checked = True, "SOLO MERCADOS", IIf(Me.RdDistrito.Checked = True, "SOLO DISTRITOS SIN MERCADOS", "DISTRITOS Y MERCADOS")) & " " & IIf(Me.RdPresupuesto.Checked = True, "PRESUPUESTO", IIf(Me.RdExterno.Checked = True, "FONDOS EXTERNOS ", "TODOS LOS FONDOS")) & ")'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    frmVisor.WindowState = FormWindowState.Maximized

                Case EnumReportes.sociasCancelados 'LISTADO POR SOCIAS CANCELADOS
                    ' Se Filtra por programa
                    If RdUsuraCero.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            'Filtro = Filtro & " And {vwSccPagarecreditosunion.CodigoPrograma}='1'"
                            Filtro = Filtro & " And {vwScccreditoscancelados.CodigoProgramaultimo}='1'"
                        Else
                            'Filtro = "  {vwSccPagarecreditosunion.CodigoPrograma}='1'"
                            Filtro = " {vwScccreditoscancelados.CodigoProgramaultimo}='1'"
                        End If
                    Else
                        If Trim(Filtro) <> "" Then
                            ' Filtro = Filtro & " And {vwSccPagarecreditosunion.CodigoPrograma}='2'"
                            Filtro = Filtro & " And {vwScccreditoscancelados.CodigoProgramaultimo}='2'"
                        Else
                            ' Filtro = "  {vwSccPagarecreditosunion.CodigoPrograma}='2'"
                            Filtro = " {vwScccreditoscancelados.CodigoProgramaultimo}='2'"
                        End If
                    End If

                    If CboDepartamento.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            'Filtro = Filtro & " And {vwSccPagarecreditosunion.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                            Filtro = Filtro & " And {vwScccreditoscancelados.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        Else
                            'Filtro = "  {vwSccPagarecreditosunion.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                            Filtro = "  {vwScccreditoscancelados.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        End If
                    End If
                    '2. Si se indic� un Municipio en particular:

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            ' Filtro = Filtro & " And {vwSccPagarecreditosunion.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            Filtro = Filtro & " And {vwScccreditoscancelados.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            'Filtro = "{vwSccPagarecreditosunion.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            Filtro = "{vwSccCreditoscancelados.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            'Filtro = Filtro & " And {vwSccPagarecreditosunion.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            Filtro = Filtro & " And {vwScccreditoscancelados.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            'Filtro = "{vwSccPagarecreditosunion.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            Filtro = "{vwScccreditoscancelados.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value

                        End If
                    End If

                    '3. Si se indic� un Distrito en Particular:
                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            ' Filtro = Filtro & " And {vwSccPagarecreditosunion.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                            Filtro = Filtro & " And {vwScccreditoscancelados.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            ' Filtro = " {vwSccPagarecreditosunion.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                            Filtro = " {vwScccreditoscancelados.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    '4. Si se indic� un Barrio en Particular:
                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            'Filtro = Filtro & " And {vwSccPagarecreditosunion.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                            Filtro = Filtro & " And {vwScccreditoscancelados.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            ' Filtro = " {vwSccPagarecreditosunion.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                            Filtro = " {vwScccreditoscancelados.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    frmVisor.NombreReporte = "RepSccCC72.rpt"
                    frmVisor.Text = "Listado de Socias con Creditos Cancelados y Sin Creditos Vigentes"
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                    frmVisor.CRVReportes.ShowRefreshButton = False
                    'frmVisor.Formulas("RangoFechas") = "' DEL " + Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd") + " AL " + Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd") + " '"
                    frmVisor.Formulas("Parametros") = "' Par�metros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")(" & IIf(Me.RdMercado.Checked = True, "SOLO MERCADOS", IIf(Me.RdDistrito.Checked = True, "SOLO DISTRITOS SIN MERCADOS", "DISTRITOS Y MERCADOS")) & " " & IIf(Me.RdPresupuesto.Checked = True, "PRESUPUESTO", IIf(Me.RdExterno.Checked = True, "FONDOS EXTERNOS ", "TODOS LOS FONDOS")) & ")'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    frmVisor.WindowState = FormWindowState.Maximized

                Case EnumReportes.ListaSociasMonto  'LISTADO DE SOCIAS POR MONTO APROBADO

                    If CboDepartamento.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbDepartamentoID") = Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    Else
                        frmVisor.Parametros("@nStbDepartamentoID") = 0
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbMunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        frmVisor.Parametros("@nStbMunicipioID") = 0
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbDistritoID") = Me.cboDistrito.Columns("nStbDistritoID").Value
                    Else
                        frmVisor.Parametros("@nStbDistritoID") = 0
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbBarrioID") = Me.cboBarrio.Columns("nStbBarrioID").Value
                    Else
                        frmVisor.Parametros("@nStbBarrioID") = 0
                    End If

                    If Me.RdDistrito.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosSociasMonto.nStbMercadoVerificadoID}=1 "
                        Else
                            Filtro = " {spSccReporteNoPagadosSociasMonto.nStbMercadoVerificadoID}=1 "
                        End If
                    ElseIf Me.RdMercado.Checked Or Me.RadCooperativa.Checked Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosSociasMonto.nStbMercadoVerificadoID}<>1 "
                        Else
                            Filtro = " {spSccReporteNoPagadosSociasMonto.nStbMercadoVerificadoID}<>1 "
                        End If
                    End If

                    If Me.RdCarteraVencida.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosSociasMonto.Vigente}>0"
                        Else
                            Filtro = " {spSccReporteNoPagadosSociasMonto.Vigente}>0"
                        End If

                    ElseIf Me.RdCarteraVigente.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNoPagadosSociasMonto.Vigente}=0"
                        Else
                            Filtro = " {spSccReporteNoPagadosSociasMonto.Vigente}=0"
                        End If
                    End If

                    If Trim(Filtro) <> "" Then
                        If Me.RdPDIBA.Checked = True Then
                            Filtro = Filtro & " And ({spSccReporteNoPagadosSociasMonto.TipoPrograma}=5 or {spSccReporteNoPagadosSociasMonto.TipoPrograma}=6)"
                        ElseIf Me.RdVentanadeGenero.Checked = True Then
                            Filtro = Filtro & " And ({spSccReporteNoPagadosSociasMonto.TipoPrograma}=3 or {spSccReporteNoPagadosSociasMonto.TipoPrograma}=4)"
                        Else ' Me.RdUsuraCero.Checked = True Then
                            Filtro = Filtro & " And ({spSccReporteNoPagadosSociasMonto.TipoPrograma}=1 or {spSccReporteNoPagadosSociasMonto.TipoPrograma}=2)"
                        End If
                    Else
                        If Me.RdPDIBA.Checked = True Then
                            Filtro = Filtro & " ({spSccReporteNoPagadosSociasMonto.TipoPrograma}=5 or {spSccReporteNoPagadosSociasMonto.TipoPrograma}=6)"
                        ElseIf Me.RdVentanadeGenero.Checked = True Then
                            Filtro = Filtro & " ({spSccReporteNoPagadosSociasMonto.TipoPrograma}=3 or {spSccReporteNoPagadosSociasMonto.TipoPrograma}=4)"
                        Else ' Me.RdUsuraCero.Checked = True Then
                            Filtro = Filtro & " ({spSccReporteNoPagadosSociasMonto.TipoPrograma}=1 or {spSccReporteNoPagadosSociasMonto.TipoPrograma}=2)"
                        End If
                    End If

                    frmVisor.NombreReporte = "RepSccCC88.rpt"
                    frmVisor.Text = "Listado de Socias en Mora por Monto Aprobado"
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                    frmVisor.CRVReportes.ShowRefreshButton = False

                    If Me.RdPDIBA.Checked = True Then
                        'frmVisor.Formulas("TipoPrograma") = 3
                        frmVisor.Parametros("@Tipo_Programa") = 3
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        'frmVisor.Formulas("TipoPrograma") = 2
                        frmVisor.Parametros("@Tipo_Programa") = 2
                    Else ' Me.RdUsuraCero.Checked = True Then
                        'frmVisor.Formulas("TipoPrograma") = 1
                        frmVisor.Parametros("@Tipo_Programa") = 1
                    End If

                    frmVisor.Formulas("Parametros") = "' Par�metros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") (Distrito:" & Me.cboDistrito.Text & ") (Barrio: " & Me.cboBarrio.Text & ")'"
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.Formulas("TipoCredito") = "'" & IIf(RdActas.Checked, "DISTRITOS, MERCADOS Y COOPERAIVAS", IIf(Me.RdDistrito.Checked, "SOLO DISTRITOS", IIf(Me.RadCooperativa.Checked, "SOLO COOPERATIVAS", "SOLO MERCADOS")))  '& "'"
                    frmVisor.Formulas("TipoCredito") = frmVisor.Formulas("TipoCredito") & IIf(Me.RdCarteraVigente.Checked, " CON CARTERA VIGENTE ", IIf(Me.RdCarteraVencida.Checked, " CON CARTERA  VENCIDA", "")) & "'"
                    frmVisor.Parametros("@FechaCorte") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaCorte") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                    ' Filtro por mercado o cooperativa 
                    If Me.RadCooperativa.Checked Or Me.RdMercado.Checked Then
                        frmVisor.Parametros("@nCooperativa") = IIf(Me.RadCooperativa.Checked, 1, 0)
                    Else
                        frmVisor.Parametros("@nCooperativa") = -1
                    End If

                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0))
                    Dim monto As Integer
                    If cboMontoAprobado.Text <> "(Todos)" Then
                        monto = cboMontoAprobado.Text
                    Else
                        monto = 0
                    End If
                    frmVisor.Parametros("@nMontoCreditoAprobado") = monto
                    frmVisor.WindowState = FormWindowState.Maximized

                Case EnumReportes.ListadoDesembolsos

                    SaveFile.Filter = "Archivos de Excel|*.xlsx"
                    SaveFile.ShowDialog()
                    strFileName = SaveFile.FileName
                    Me.Cursor = Cursors.WaitCursor
                    CrearArchivoExcelListadoDesembolsos()
                    FormatoArchivoExcelListadoDesembolsos()
                    Me.Cursor = Cursors.Default
                    Me.Close()
                    Exit Sub

            End Select

            frmVisor.Show()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
            Me.Cursor = Cursors.Default
        Finally
            frmVisor = Nothing
        End Try

    End Sub

    Private Sub CrearArchivoExcelListadoDesembolsos()
        ' Establecemos la conexi�n con el libro de Excel, utilizando
        ' el ISAM de Excel del motor Microsoft ACE (Excel 2007).
        ' Si no existe, se crear� uno nuevo.
        '

        ' exec dbo.spSccListadoDatosSociasDesembolsos '2016-01-01', '2016-12-30'
        Dim con As New SqlConnection("Data Source=ucero-prod; Initial Catalog=SMUSURA0; User ID=usacceso; Password=usuracero")
        con.Open()
        Dim cmmd As New SqlCommand("exec dbo.spSccListadoDatosSociasDesembolsos '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "', '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'", con)
        cmmd.CommandTimeout = 3600
        cmmd.ExecuteNonQuery()
        con.Close()

        Using cnn As New OleDbConnection(
    "Provider=Microsoft.ACE.OLEDB.12.0;" &
    "Data Source=" & strFileName & ";" &
    "Extended Properties='Excel 12.0 Xml;HDR=Yes'")

            ' Creamos la consulta SQL de creaci�n de tabla
            '
            Dim sql As String =
       "SELECT * INTO [Desembolsos] " &
       "FROM [tmpSccListadoDatosSociasDesembolsos] " &
       "IN ''[ODBC;Driver={SQL Server};" &
               "Server=ucero-prod;" &
               "Database=SMUSURA0;" &
               "UID=usacceso;" &
               "PWD=usuracero]"

            ' Creamos el comando
            '
            Dim cmd As New OleDbCommand(sql, cnn)

            Try
                'ELIMINAR EL ARCHIVO SI EXISTE
                If FileIO.FileSystem.FileExists(strFileName) Then
                    FileIO.FileSystem.DeleteFile(strFileName)
                End If
                ' Abrimos la conexi�n
                cnn.Open()

                cmd.CommandTimeout = 3600

                ' Ejecutamos el comando
                n = cmd.ExecuteNonQuery

                ' Obtenemos los registros afectados
                MsgBox("N� de registros exportados: " & CStr(n), vbInformation)

            Catch ex As Exception
                ' Se ha producido un error
                Control_Error(ex)
                Exit Sub
            End Try

        End Using

    End Sub

    Private Sub FormatoArchivoExcelListadoDesembolsos()
        Dim m_Excel As Excel.Application
        Dim objLibroExcel As Excel.Workbook
        Dim objHojaExcel As Excel.Worksheet

        Try
            m_Excel = New Excel.Application
            m_Excel.Visible = True
            Dim OldCultureInfo As System.Globalization.CultureInfo = System.Threading.Thread.CurrentThread.CurrentCulture
            System.Threading.Thread.CurrentThread.CurrentCulture = New System.Globalization.CultureInfo("en-US")

            objLibroExcel = m_Excel.Workbooks.Open(strFileName)
            objHojaExcel = objLibroExcel.Worksheets(1)
            objHojaExcel.Visible = Excel.XlSheetVisibility.xlSheetVisible
            objHojaExcel.Activate()

            'objHojaExcel.Range("A1").EntireRow.Insert()
            'objHojaExcel.Range("A1").EntireRow.Insert()
            'objHojaExcel.Range("A1").EntireRow.Insert()


            objHojaExcel.Range("A1").ColumnWidth = 15
            objHojaExcel.Range("B1").ColumnWidth = 15
            objHojaExcel.Range("C1").ColumnWidth = 10
            objHojaExcel.Range("D1").ColumnWidth = 36
            objHojaExcel.Range("E1").ColumnWidth = 36
            objHojaExcel.Range("F1").ColumnWidth = 14
            objHojaExcel.Range("G1").ColumnWidth = 8
            objHojaExcel.Range("H1").ColumnWidth = 40
            objHojaExcel.Range("I1").ColumnWidth = 40
            objHojaExcel.Range("J1").ColumnWidth = 22
            objHojaExcel.Range("K1").ColumnWidth = 10


            'objHojaExcel.Range("A1:O1").Merge()
            'objHojaExcel.Range("A1:O1").Value = "PROGRAMA USURA CERO"
            'objHojaExcel.Range("A1:O1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            'objHojaExcel.Range("A1:O1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            'objHojaExcel.Range("A1:O1").RowHeight = 24
            'objHojaExcel.Range("A1:O1").Interior.Color = RGB(155, 194, 230)
            'objHojaExcel.Range("A1:O1").Font.Bold = True
            'objHojaExcel.Range("A1:O1").Font.Name = "Arial Narrow"
            'objHojaExcel.Range("A1:O1").Font.Size = 12

            objHojaExcel.Range("A1:K1").Font.Name = "Arial Narrow"
            objHojaExcel.Range("A1:K1").Font.Size = 10
            objHojaExcel.Range("A1:K1").Font.Bold = True
            objHojaExcel.Range("A1:K1").WrapText = True
            objHojaExcel.Range("A1:K1").HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objHojaExcel.Range("A1:K1").VerticalAlignment = Excel.XlVAlign.xlVAlignCenter
            objHojaExcel.Range("A1:K1").Interior.Color = RGB(91, 155, 213)
            objHojaExcel.Range("A1:K1").RowHeight = 26
            objHojaExcel.Range("A1:K1").Borders(Excel.XlBordersIndex.xlEdgeBottom).LineStyle = Excel.XlLineStyle.xlContinuous
            objHojaExcel.Range("A1:K1").Borders(Excel.XlBordersIndex.xlEdgeTop).LineStyle = Excel.XlLineStyle.xlContinuous
            objHojaExcel.Range("A1:K1").Borders(Excel.XlBordersIndex.xlEdgeLeft).LineStyle = Excel.XlLineStyle.xlContinuous
            objHojaExcel.Range("A1:K1").Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous


            For Each letra In {"A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K"}
                objHojaExcel.Range(letra & "1:" & letra & n + 1).Borders(Excel.XlBordersIndex.xlEdgeRight).LineStyle = Excel.XlLineStyle.xlContinuous
            Next

            objHojaExcel.Range("A2:K" & n + 1).Font.Name = "Arial Narrow"
            objHojaExcel.Range("A2:K" & n + 1).Font.Size = 10

            objHojaExcel.Range("F2:F" & n + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objHojaExcel.Range("G2:G" & n + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter
            objHojaExcel.Range("J2:J" & n + 1).HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter

            objHojaExcel.Range("A2:A" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("B2:B" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("C2:C" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("D2:D" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("E2:E" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("F2:F" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("G2:G" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("H2:H" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("I2:I" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("J2:J" & n + 1).NumberFormat = "@"
            objHojaExcel.Range("K2:K" & n + 1).NumberFormat = "@"

            'objHojaExcel.SaveAs("C:\users\franco.ugarte\desktop\Listado_Desembolsos.xlsx")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSccParametrosCreditosSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
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
        If (Me.CboDepartamento.SelectedIndex <> -1 And Me.CboDepartamento.SelectedIndex > 0) Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
    End Sub

    Private Sub HabilitarComboMunicipio()
        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
            HabilitarComboBarrio()
        Else
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False
            Me.cboMunicipio.Text = "Todos"
            Me.cboDistrito.Text = "Todos"
            Me.cboBarrio.Text = "Todos"
        End If
    End Sub

    Private Sub HabilitarComboBarrio()
        If Me.cboMunicipio.Text = "Managua" Or Me.cboMunicipio.Text = "Todos" Then
            If Me.cboDistrito.SelectedIndex > 0 Then
                Me.cboBarrio.Enabled = True
            Else
                Me.cboBarrio.Enabled = False
            End If
        Else
            If Me.cboDistrito.SelectedIndex >= 0 Then
                Me.cboBarrio.Enabled = True
            Else
                Me.cboBarrio.Enabled = False
            End If
        End If
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0)
                Me.cboDistrito.SelectedIndex = 0
                Me.cboDistrito.Enabled = False
            End If
            CargarBarrio(0)
        Else
            CargarDistrito(1)
            CargarBarrio(1)
        End If
        'HabilitarComboBarrio()
    End Sub

    Private Sub CargarVeces()
        Try
            CboVeces.AddItem("Al menos Un Cr�dito")
            CboVeces.AddItem("Solo Un Cr�dito")
            CboVeces.AddItem("Dos Cr�ditos")
            CboVeces.AddItem("Tres Cr�ditos")
            CboVeces.AddItem("Cuatro Cr�ditos")
            CboVeces.AddItem("Cinco Cr�ditos")
            CboVeces.AddItem("Seis Cr�ditos")
            CboVeces.AddItem("Siete Cr�ditos")
            CboVeces.AddItem("Ocho Cr�ditos")
            CboVeces.AddItem("Nueve Cr�ditos")
            CboVeces.AddItem("Diez Cr�ditos")
            CboVeces.AddItem("Once Cr�ditos o m�s")
            'CboVeces.AddItem("Cuatro Cr�ditos o m�s")
            CboVeces.Columns(0).Caption = ""
            CboVeces.SelectedIndex = 0
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSccParametrosCreditosSocia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaraci�n de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()
            CargarVeces()

            Me.cboDistrito.Enabled = False
            Me.cboBarrio.Enabled = False

            If Me.mNomRep = EnumReportes.ListadoDeRecibosPorTipoFecha Then
                Me.grpTipoFecha.Visible = True
                Me.grpDigitador.Visible = True
                Me.grpDistritoOMercado.Enabled = False
                Me.grpCartera.Enabled = False
                Me.grpFuente.Enabled = False
                Me.CboVeces.Enabled = False
                Me.CargarDigitadores()
            Else
                Me.grpTipoFecha.Visible = False
                Me.grpDigitador.Visible = False
            End If

            If Me.mNomRep = EnumReportes.ListaSociasMonto Then
                CboVeces.Enabled = True
                CboVeces.Text = ""
            End If

            If Me.mNomRep = EnumReportes.NumeroDesembolsos Or Me.mNomRep = EnumReportes.ListaSociasMonto Then ' CC25 y CC88
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
            Else
                cboMontoAprobado.Enabled = False
            End If

            If mNomRep = EnumReportes.ListadoDesembolsos Then 'CC?? - Archivo Excel
                CboDepartamento.Enabled = False
                cboMunicipio.Enabled = False
                cboDistrito.Enabled = False
                cboBarrio.Enabled = False
                cboMontoAprobado.Enabled = False
                CboVeces.Enabled = False
                grpDistritoOMercado.Enabled = False
                grpCartera.Enabled = False
                grpFuente.Enabled = False
                grpPrograma.Enabled = False
                grpTipoFecha.Enabled = False
                grpDigitador.Enabled = False
            End If

            If mNomRep = EnumReportes.ListaDeMora _
                Or mNomRep = EnumReportes.ListaDeMoraSocias Then
                grpTurismo.Enabled = True
            Else
                grpTurismo.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarDigitadores()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 0 Then
                Strsql = "SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID AS NusuarioCreacionId, RTRIM(LTRIM(dbo.StbPersona.sNombre1)) " &
                         " + ' ' + LTRIM(RTRIM(dbo.StbPersona.sNombre2)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido2)) AS NombreUsuario ,1 As Orden" &
                         "   FROM         dbo.SsgCuenta INNER JOIN dbo.SrhEmpleado ON dbo.SsgCuenta.objEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " &
                         " dbo.StbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.StbPersona.nStbPersonaID " &
                         " WHERE (dbo.SsgCuenta.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " &
                         "  ORDER BY RTRIM(LTRIM(dbo.StbPersona.sNombre1)), LTRIM(RTRIM(dbo.StbPersona.sNombre2)), LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)),LTrim(RTrim(dbo.StbPersona.sApellido2))"
            Else
                Strsql = "SELECT     TOP (100) PERCENT dbo.SsgCuenta.SsgCuentaID AS NusuarioCreacionId, RTRIM(LTRIM(dbo.StbPersona.sNombre1)) " &
                         " + ' ' + LTRIM(RTRIM(dbo.StbPersona.sNombre2)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)) + ' ' + LTRIM(RTRIM(dbo.StbPersona.sApellido2)) AS NombreUsuario ,1 As Orden" &
                         "   FROM         dbo.SsgCuenta INNER JOIN dbo.SrhEmpleado ON dbo.SsgCuenta.objEmpleadoID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " &
                         " dbo.StbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.StbPersona.nStbPersonaID " &
                         "  ORDER BY RTRIM(LTRIM(dbo.StbPersona.sNombre1)), LTRIM(RTRIM(dbo.StbPersona.sNombre2)), LTRIM(RTRIM(dbo.StbPersona.sApellido1RS)),LTrim(RTrim(dbo.StbPersona.sApellido2))"
            End If

            If XdsCombos.ExistTable("UsuarioRecibos") Then
                XdsCombos("UsuarioRecibos").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "UsuarioRecibos")
                XdsCombos("UsuarioRecibos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboUsuario.DataSource = XdsCombos("UsuarioRecibos").Source



            'Me.cboUsuario.Splits(0).DisplayColumns("usuarioCreacionId").Visible = False
            Me.cboUsuario.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboUsuario.Splits(0).DisplayColumns("NusuarioCreacionId").Visible = False
            'Me.cboUsuario.Splits(0).DisplayColumns("NombreUsuario").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboUsuario.Splits(0).DisplayColumns("NombreUsuario").Width = 260

            Me.cboUsuario.Columns("NusuarioCreacionId").Caption = "C�digo"
            Me.cboUsuario.Columns("NombreUsuario").Caption = "Digitador"

            Me.cboUsuario.Splits(0).DisplayColumns("NombreUsuario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            'Ubicarlo en el primer registro
            If Me.cboUsuario.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("UsuarioRecibos").AddRow()
                XdsCombos("UsuarioRecibos").ValueField("NombreUsuario") = "Todos"
                XdsCombos("UsuarioRecibos").ValueField("NusuarioCreacionId") = -19
                XdsCombos("UsuarioRecibos").ValueField("Orden") = 0
                XdsCombos("UsuarioRecibos").UpdateLocal()
                XdsCombos("UsuarioRecibos").Sort = "Orden,NombreUsuario asc"
                Me.cboUsuario.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub FrmSccParametrosCreditosSocia_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If mNomRep = EnumReportes.NumeroDesembolsos Then
            Me.Text = "Desembolsos Por Socia"
            'Deshabilitado, solicitud de Beyra (Alega que do�a Leonor lo necesitaba urgente para ya ya ya) el 09/10/2017, no hay formato de cambio
            'cdeFechaInicial.Enabled = False 
            'CdeFechaFinal.Enabled = False
            grpFuente.Enabled = True
            RdSinFuente.Enabled = False
            grpCartera.Enabled = False
            Me.chkCancelados.Visible = True
            Me.chkCancelados.Checked = False
        End If

        If mNomRep = EnumReportes.ListaDeMora Then
            Me.Text = "Listado de Grupos Beneficiaria pendiente de Pago"
            grpDistritoOMercado.Enabled = True
            CboVeces.Enabled = False
            cdeFechaInicial.Enabled = False
            CdeFechaFinal.Enabled = True
            CdeFechaFinal.Value = FechaServer()
            RdSinFuente.Enabled = False
            grpFuente.Enabled = True
            grpCartera.Enabled = True
        End If
        If mNomRep = EnumReportes.ListaDeMoraSocias Then
            Me.Text = "Listado de Beneficiarias pendiente de Pago"
            grpDistritoOMercado.Enabled = True
            CboVeces.Enabled = False
            cdeFechaInicial.Enabled = False
            CdeFechaFinal.Enabled = False
            CdeFechaFinal.Value = FechaServer()
            grpFuente.Enabled = True
            RdSinFuente.Enabled = False
            grpCartera.Enabled = True
        End If

        If mNomRep = EnumReportes.ListaDeMoraSocias Then
            'RdPresupuesto.Checked = True
            'RdTodos.Enabled = False
            'RdExterno.Enabled = False
            RdSinFuente.Enabled = False
        End If

        If mNomRep = EnumReportes.GruposCancelados Then

            Me.Text = "Listado de Grupos Con Creditos Cancelados"
            grpDistritoOMercado.Enabled = True
            CboVeces.Enabled = False
            'cdeFechaInicial.Enabled = False
            'CdeFechaFinal.Enabled = False
            'CdeFechaFinal.Value = FechaServer()
            grpFuente.Enabled = True
            RdSinFuente.Enabled = False
            grpCartera.Enabled = False

        End If

        If mNomRep = EnumReportes.sociasCancelados Then

            Me.Text = "Listado de Socias Con Creditos Cancelados y sin Creditos Vigentes"
            grpDistritoOMercado.Enabled = False
            CboVeces.Enabled = False
            cdeFechaInicial.Enabled = False
            CdeFechaFinal.Enabled = False
            'CdeFechaFinal.Value = FechaServer()
            grpFuente.Enabled = False
            RdSinFuente.Enabled = False
            grpCartera.Enabled = False

        End If

        'If mNomRep = EnumReportes.Barrio Then
        '    grpNegocio.Enabled = False
        '    grpReporte.Enabled = False
        '    GrpFechas.Enabled = False
        'End If
        'If mNomRep = EnumReportes.Socias Then
        '    'grpNegocio.Enabled = False
        '    grpNegocio.Text = "Estado del Credito"
        '    RadNuevos.Text = "Cancelados"
        '    RadActuales.Text = "Vigentes"
        '    GrpFechas.Enabled = False
        'End If
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        'If mNomRep = EnumReportes.Socias Then
        'Me.cboBarrio.Enabled = True
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarBarrio(0)
        Else
            CargarBarrio(1)
        End If

        'End If
        HabilitarComboBarrio()


    End Sub
End Class