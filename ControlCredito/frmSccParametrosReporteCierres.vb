Imports BOSistema.Win

Public Class frmSccParametrosReporteCierres

    Dim xdt As New XDataSet
    Dim XdsCombos As XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntDepartamento As Integer

    Public intReporte As Integer = 0

    Public Enum EnumReportes

        DetalleCarteraClasificacion = 1 'Detalle de Cartera (Socias) por Clasificacion CC89.1
        ConsoliCarteraClasificacion = 2 'Consol. de Cartera (Socias) por Clasificacion CC89.2

    End Enum

    Private Sub frmSccInformesBancor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()

            CargarMeses()
            CargarClasificacion()

            Seguridad()

            'cboClasificacion.SelectedIndex = 0

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub InicializarVariables()
        Try
            XdsCombos = New XDataSet

            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Sub Seguridad()

        If Me.intReporte = EnumReportes.ConsoliCarteraClasificacion Then
            grpRangoFechas.Enabled = True
            grpNivelDetalle.Enabled = False
        ElseIf Me.intReporte = EnumReportes.DetalleCarteraClasificacion Then
            grpRangoFechas.Enabled = False
            grpNivelDetalle.Enabled = True
        End If

    End Sub


    Private Sub CargarClasificacion()

        Dim strsql As String = "select '(Todos)' Clasificacion union select ' Categoria A 0-7 Días' Clasificacion union select ' Categoria B 8-20 Días' Clasificacion union select ' Categoria C 21-30 Días' Clasificacion union select ' Categoria D 31-364 Días' Clasificacion union select ' Categoria E 365 Días a más' Clasificacion"

        If xdt.ExistTable("Clasificacion") Then
            xdt("Clasificacion").ExecuteSql(strsql)
        Else
            xdt.NewTable(strsql, "Clasificacion")
            xdt("Clasificacion").Retrieve()
        End If

        cboClasificacion.DataSource = xdt("Clasificacion").Source

        cboClasificacion.DisplayMember = "Clasificacion"
        cboClasificacion.ValueMember = "Clasificacion"

        cboClasificacion.SelectedIndex = 0

    End Sub


    Private Sub CargarMeses()

        If xdt.ExistTable("Meses") Then
            xdt("Meses").ExecuteSql("ex_sql_desa 'spListaMeses', 'SMUSURA0_Cierre', 'sp'")
        Else
            xdt.NewTable("ex_sql_desa 'spListaMeses', 'SMUSURA0_Cierre', 'sp'", "Meses")
            xdt("Meses").Retrieve()
        End If

        cboMes.DataSource = xdt("Meses").Source

        cboMes.Splits(0).DisplayColumns().Item("nMes").Visible = False

        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "nMes"

        cboMes.SelectedIndex = 0

    End Sub

    Private Sub CargarAños()

        If xdt.ExistTable("Anios") Then
            xdt("Anios").ExecuteSql("ex_sql_desa 'spListaAnios " & cboMes.SelectedValue & "', 'SMUSURA0_Cierre', 'sp'")
        Else
            xdt.NewTable("ex_sql_desa 'spListaAnios " & cboMes.SelectedValue & "', 'SMUSURA0_Cierre', 'sp'", "Anios")
            xdt("Anios").Retrieve()
        End If

        cboAño.DataSource = xdt("Anios").Source

        cboAño.Splits(0).DisplayColumns("nMes").Visible = False
        cboAño.Splits(0).DisplayColumns("nAnio").HeadingStyle.HorizontalAlignment = C1.Win.C1List.AlignHorzEnum.General
        cboAño.Splits(0).DisplayColumns("nAnio").Style.HorizontalAlignment = C1.Win.C1List.AlignHorzEnum.Near
        cboAño.Columns("nAnio").Caption = "Año"

        cboAño.DisplayMember = "nAnio"
        cboAño.ValueMember = "nAnio"

        cboAño.SelectedIndex = 0

    End Sub

    Private Sub cboMes_TextChanged(sender As Object, e As EventArgs) Handles cboMes.TextChanged
        CargarAños()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click

        Dim frmVisor As New frmCRVisorReporte

        frmVisor.Parametros("@DepartamentoID") = cboDepartamento.SelectedValue
        frmVisor.Parametros("@MunicipioID") = cboMunicipio.SelectedValue
        frmVisor.Parametros("@DistritoID") = cboDistrito.SelectedValue
        frmVisor.Parametros("@BarrioID") = cboBarrio.SelectedValue
        frmVisor.Parametros("@nMes") = Me.cboMes.SelectedValue
        frmVisor.Parametros("@nAnio") = Me.cboAño.SelectedValue
        frmVisor.Parametros("@Clasificacion") = String.Format("{0}", Me.cboClasificacion.SelectedValue)

        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

        Select Case Me.intReporte
            Case EnumReportes.DetalleCarteraClasificacion
                frmVisor.Formulas("PresentarDepartamentos") = IIf(chkDepartamento.Checked, 1, 0)
                frmVisor.Formulas("PresentarMunicipios") = IIf(chkMunicipio.Checked, 1, 0)
                frmVisor.Formulas("PresentarDistritos") = IIf(chkDistrito.Checked, 1, 0)
                frmVisor.Formulas("PresentarBarrios") = IIf(chkBarrio.Checked, 1, 0)
                frmVisor.Formulas("PresentarGrupos") = IIf(chkGrupos.Checked, 1, 0)
                frmVisor.Formulas("PresentarSocias") = IIf(chkSocias.Checked, 1, 0)
                frmVisor.Text = "Detalle de Cartera por Clasificación"
                frmVisor.NombreReporte = "RepSccCC89.1.rpt"
            Case EnumReportes.ConsoliCarteraClasificacion
                frmVisor.Parametros("@FechaInicio") = Me.cdeFechaInicial.Value
                frmVisor.Parametros("@FechaFin") = Me.cdeFechaFinal.Value
                frmVisor.Text = "Consolidado de Cartera por Clasificación"
                frmVisor.NombreReporte = "RepSccCC89.2.rpt"
        End Select

        frmVisor.CustomServer(0) = "UCERO-MG1-DESA"
        frmVisor.CustomServer(1) = "SMUSURA0_Cierre"
        frmVisor.CustomServer(2) = "desa"
        frmVisor.CustomServer(3) = "desa"
        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Show()

    End Sub

    Private Sub cboDepartamento_TextChanged(sender As Object, e As EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
            'CargarBarrio(0)
        Else
            CargarMunicipio(1)
        End If

        HabilitarComboMunicipio()
        'HabilitarComboBarrio()
    End Sub

    Private Sub cboMunicipio_TextChanged(sender As Object, e As EventArgs) Handles cboMunicipio.TextChanged
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

    Private Sub cboDistrito_TextChanged(sender As Object, e As EventArgs) Handles cboDistrito.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarBarrio(0)
        Else
            CargarBarrio(1)
        End If
        HabilitarComboBarrio()
    End Sub


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
            Me.cboDepartamento.DataSource = XdsCombos("Departamento").Source
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '          Me.cboReporte.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            '           Me.cboReporte.Splits(0).DisplayColumns(0).Width = 238

            '            Me.cboReporte.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General


            'Ubicarlo en el primer registro
            If Me.cboDepartamento.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -1
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.cboDepartamento.SelectedIndex = 0
            End If

            cboDepartamento.DisplayMember = "Descripcion"
            cboDepartamento.ValueMember = "nStbDepartamentoID"

            HabilitarComboMunicipio()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                         " From StbMunicipio a " &
                         " WHERE a.nStbMunicipioID = 0" &
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
                XdsCombos("Municipio").ValueField("nStbMunicipioID") = -1
                XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -1
                XdsCombos("Municipio").ValueField("Orden") = 0
                XdsCombos("Municipio").UpdateLocal()
                XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
                Me.cboMunicipio.SelectedIndex = 0
            End If
            ''HabilitarComboBarrio()

            cboMunicipio.DisplayMember = "Descripcion"
            cboMunicipio.ValueMember = "nStbMunicipioID"

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

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

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDistrito.ListCount > 0 Then
                XdsCombos("Distrito").AddRow()
                XdsCombos("Distrito").ValueField("Descripcion") = "Todos"
                XdsCombos("Distrito").ValueField("nStbDistritoID") = -1
                XdsCombos("Distrito").ValueField("Orden") = 0
                XdsCombos("Distrito").UpdateLocal()
                XdsCombos("Distrito").Sort = "Orden,sCodigo asc"
                Me.cboDistrito.SelectedIndex = 0
            End If

            cboDistrito.DisplayMember = "Descripcion"
            cboDistrito.ValueMember = "nStbDistritoID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboBarrio.ListCount > 0 Then
                XdsCombos("Barrio").AddRow()
                XdsCombos("Barrio").ValueField("Descripcion") = "Todos"
                XdsCombos("Barrio").ValueField("nStbBarrioID") = -1
                XdsCombos("Barrio").ValueField("nStbDistritoID") = -1
                XdsCombos("Barrio").ValueField("Orden") = 0
                XdsCombos("Barrio").UpdateLocal()
                XdsCombos("Barrio").Sort = "Orden,sCodigo asc"
                Me.cboBarrio.SelectedIndex = 0
            End If

            cboBarrio.DisplayMember = "Descripcion"
            cboBarrio.ValueMember = "nStbBarrioID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub HabilitarComboMunicipio()
        'If Me.CboDepartamento.SelectedIndex > 0 Then
        If (Me.cboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.cboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
            'Me.cboBarrio.Enabled = True

            HabilitarComboBarrio()

        Else
            Me.cboMunicipio.Enabled = False
            Me.cboBarrio.Enabled = False
        End If
    End Sub

    Private Sub HabilitarComboBarrio()

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

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class