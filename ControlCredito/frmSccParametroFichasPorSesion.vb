Public Class frmSccParametroFichasPorSesion

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
        ListadoDeActasPorSesion = 1
        ListadoDeExpedientesAprobados = 2 ' Listado de creditos aprobados
        ListadoDeExpedientesAnulados = 3
        ListadoDeBarriosPorAtencionYMora = 4
    End Enum

    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

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
    ' Author		    		:	Josué Herrera
    ' Date			    		:	17/02/2012
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

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

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
    ' Autor:                Josué Herrera
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
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
                If intLimpiarID = 1 Then

                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                                                " From StbMunicipio a " & _
                                                " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                                                " Order by a.sCodigo"

                Else

                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                                            " From StbMunicipio a " & _
                                            " WHERE a.nStbMunicipioID = 0" & _
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

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

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
                'End If
            End If
            ''HabilitarComboBarrio()

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
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
    '* Cargar la lista de Fuentes de Financiamiento 
    '**************************************************************************

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
          

            If Me.NomRep = EnumReportes.ListadoDeExpedientesAprobados Then
                If String.IsNullOrEmpty(Me.mskResolucion.Text) Then
                    MsgBox("Debe ún número de sesión válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.mskResolucion, "Debe ún número de sesión válido.")
                    Me.mskResolucion.Focus()
                    GoTo SALIR
                End If
            Else

                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
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

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub frmSccParametroFichasPorSesion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            Me.cboDistrito.Enabled = False
            Me.cboBarrio.Enabled = False

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()
            CargarFuente()

            If Me.NomRep = EnumReportes.ListadoDeExpedientesAprobados Then
                Me.grpFechaCondicion.Enabled = False
                Me.grpFecha.Enabled = False
                Me.grpResolucion.Visible = True
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try

    End Sub

    Private Sub frmSccParametroFichasPorSesion_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
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
        Else
            Me.cboMunicipio.Enabled = False

        End If

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

            Select Case NomRep
                Case EnumReportes.ListadoDeBarriosPorAtencionYMora

                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccBarriosPorAtencionyMora.nDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {spSccBarriosPorAtencionyMora.sMunicipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccBarriosPorAtencionyMora.nMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccBarriosPorAtencionyMora.nMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccBarriosPorAtencionyMora.nDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {spSccBarriosPorAtencionyMora.nDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccBarriosPorAtencionyMora.nBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {spSccBarriosPorAtencionyMora.nBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    frmVisor.NombreReporte = "RepSccCC81.rpt"
                    frmVisor.Text = "Reporte de Listado de Barrio por Atención y Mora"
                    frmVisor.Parametros("@FechaInicio") = Format("yyyy/MM/dd 00:00:00", Me.cdeFechaInicial.Text)
                    frmVisor.Parametros("@FechaFin") = Format("yyyy/MM/dd 00:00:00", Me.CdeFechaFinal.Text)
                    frmVisor.Parametros("@FondoPresupuestario") = IIf(RdPresupuesto.Checked, 1, IIf(RdExterno.Checked, 0, -1))
                    frmVisor.Parametros("@FuenteFinanciamiento") = Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value

                    If Me.RdPDIBA.Checked = True Then
                        frmVisor.Parametros("@Programa") = "3"
                    ElseIf Me.RdVentanadeGenero.Checked = True Then
                        frmVisor.Parametros("@Programa") = "2"
                    Else ' Me.RdUsuraCero.Checked = True Then
                        frmVisor.Parametros("@Programa") = "1"
                    End If
                    'frmVisor.Parametros("@Programa") = IIf(RdUsuraCero.Checked = True, 1, IIf(Me.RdVentanadeGenero.Checked, 2, 3))
                    frmVisor.Formulas("RangoFechas") = " ' DESDE: " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " HASTA: " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"

                'frmVisor.CRVReportes.DisplayGroupTree = True
                ' -- comentariado para evitar warnings

                Case EnumReportes.ListadoDeActasPorSesion, EnumReportes.ListadoDeExpedientesAprobados, EnumReportes.ListadoDeExpedientesAnulados

                    If CboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If

                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If


                    If cboBarrio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        Else
                            Filtro = " {vwSclFichaNotificacionCreditoFuenteCoordinadora.nStbBarrioID}=" & Me.cboBarrio.Columns("nStbBarrioID").Value
                        End If
                    End If

                    If Me.NomRep = EnumReportes.ListadoDeActasPorSesion Then
                        frmVisor.NombreReporte = "RepSccCC78.rpt"
                        frmVisor.Text = "Reporte de Listado de Actas por Sesión"
                    ElseIf Me.NomRep = EnumReportes.ListadoDeExpedientesAprobados Then
                        frmVisor.NombreReporte = "RepSccCC79.rpt"
                        frmVisor.Text = "Listado de Expedientes Aprobados"
                    ElseIf Me.NomRep = EnumReportes.ListadoDeExpedientesAnulados Then
                        frmVisor.NombreReporte = "RepSccCC80.rpt"
                        frmVisor.Text = "Listado de Expedientes Anulados"
                    End If

                    If Me.NomRep <> EnumReportes.ListadoDeExpedientesAprobados Then

                        Dim stipoFecha As String

                        If Me.NomRep = EnumReportes.ListadoDeExpedientesAnulados Then
                            stipoFecha = "dFechaNotificacion"
                        Else
                            stipoFecha = IIf(Me.rdoFDesembolso.Checked = True, "dFechaHoraEntregaCK", "dFechaNotificacion")
                        End If

                        Dim fecha As Date = Me.cdeFechaInicial.Value

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {" & String.Format(" vwSclFichaNotificacionCreditoFuenteCoordinadora.{0}", stipoFecha) & "} in Datetime(" & fecha.Year & "," & fecha.Month & "," & fecha.Day & ",00,00, 00)"
                        Else
                            Filtro = "{" & String.Format(" vwSclFichaNotificacionCreditoFuenteCoordinadora.{0}", stipoFecha) & "} in Datetime(" & fecha.Year & "," & fecha.Month & "," & fecha.Day & ",00,00, 00)"
                        End If

                        fecha = Me.CdeFechaFinal.Value

                        Filtro = Filtro & " to Datetime(" & fecha.Year & "," & fecha.Month & "," & fecha.Day & ",00,00, 00)"
                    Else
                        Filtro = Filtro & " AND {vwSclFichaNotificacionCreditoFuenteCoordinadora.sNumSesion} = '" & Me.mskResolucion.Text & "'"
                    End If

                    If Me.NomRep = EnumReportes.ListadoDeExpedientesAprobados Then

                        If Me.radFondos.Checked Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & IIf(RdPresupuesto.Checked, " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nFondoPresupuestario}=1", IIf(RdExterno.Checked, " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nFondoPresupuestario} =-1", "")))
                            Else
                                Filtro = IIf(RdPresupuesto.Checked, "  {vwSclFichaNotificacionCreditoFuenteCoordinadora.nFondoPresupuestario}=1", IIf(RdExterno.Checked, "  {vwSclFichaNotificacionCreditoFuenteCoordinadora.nFondoPresupuestario}=0", IIf(RdSinFuente.Checked, "  {vwSclFichaNotificacionCreditoFuenteCoordinadora.nFondoPresupuestario} =-1 ", "")))
                            End If
                        End If

                        If Me.CboFuentes.Columns("sCodigo").Value <> -19 And Not Me.radFondos.Checked Then

                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nScnFuenteFinanciamientoID} = " & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                            Else
                                Filtro = "  {vwSclFichaNotificacionCreditoFuenteCoordinadora.nScnFuenteFinanciamientoID} = '" & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value.ToString() & "'"
                            End If

                        End If

                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFichaNotificacionCreditoFuenteCoordinadora.nSclTipodePlandeNegocioID} in " & IIf(RdUsuraCero.Checked, "[1,2]", IIf(RdVentanadeGenero.Checked, "[3,4]", "[5,6]"))
                        Else
                            Filtro = Filtro & "{vwSclFichaNotificacionCreditoFuenteCoordinadora.nSclTipodePlandeNegocioID} in " & IIf(RdUsuraCero.Checked, "[1,2]", IIf(RdVentanadeGenero.Checked, "[3,4]", "[5,6]"))
                        End If

                    End If


                    If Me.NomRep <> EnumReportes.ListadoDeExpedientesAprobados Then
                        If Me.NomRep = EnumReportes.ListadoDeExpedientesAnulados Then
                            frmVisor.Formulas("RangoFechas") = " ' DESDE: " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " HASTA: " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                        Else
                            frmVisor.Formulas("RangoFechas") = IIf(Me.rdoFDesembolso.Checked = True, "' Fecha Desembolso ", "' Fecha Resolución ") & " DEL " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " AL  " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
                        End If
                    End If

                    'frmVisor.CRVReportes.DisplayGroupTree = True
                    ' -- comentariado para evitar warnings

            End Select
            frmVisor.Formulas("Parametros") = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & IIf(String.IsNullOrEmpty(Me.cboMunicipio.Text), "Todos", Me.cboMunicipio.Text) & ") (Distrito:" & IIf(String.IsNullOrEmpty(Me.cboDistrito.Text), "Todos", Me.cboDistrito.Text) & ") (Barrio: " & IIf(String.IsNullOrEmpty(Me.cboBarrio.Text), "Todos", Me.cboBarrio.Text) & ")'"

            If Me.radFondos.Checked Then
                frmVisor.Formulas("Fuente") = "'" & IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, 0)) & "'"
            Else
                If Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value = -19 Then
                    frmVisor.Formulas("Fuente") = "'TFF'"
                Else
                    frmVisor.Formulas("Fuente") = "''"
                End If
            End If


            If Trim(Filtro) <> "" Then
                frmVisor.CRVReportes.SelectionFormula = Filtro
            End If

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.Show()

        Catch ex As Exception

        End Try

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

            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboBarrio.Enabled = False
            Else
                Me.cboBarrio.Enabled = True
            End If
        Else
            CargarDistrito(1)
            CargarBarrio(1)

        End If
    End Sub

    Private Sub rdoFDesembolso_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoFDesembolso.CheckedChanged
        Dim sTituloGrupo As String = String.Empty
        If Me.rdoFDesembolso.Checked Then
            sTituloGrupo = "Fecha Desembolso:"
        Else
            sTituloGrupo = "Fecha Resolución:"
        End If
        Me.grpFecha.Text = sTituloGrupo
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
End Class