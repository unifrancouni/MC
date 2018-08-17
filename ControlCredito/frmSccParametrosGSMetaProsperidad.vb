Public Class frmSccParametrosGSMetaProsperidad
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim strColorFrm As String

    Dim IntPermiteConsultar As Integer = 1
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
        MetaProsperidad = 1
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
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
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

            Me.CboDepartamento.ValueMember = "nStbDepartamentoID"

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
            End If

            Me.cboMunicipio.ValueMember = "nStbMunicipioID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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

            Me.cboDistrito.ValueMember = "nStbDistritoID"

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

            Me.cboBarrio.ValueMember = "nStbBarrioID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        If Not (CboDepartamento.Text <> "" And cboMunicipio.Text <> "" _
            And cboDistrito.Text <> "" And cboBarrio.Text <> "" And cdeFechaInicial.Text <> "" _
            And CdeFechaFinal.Text <> "" And (RdPDIBA.Checked Or RdUsuraCero.Checked Or RdVentanadeGenero.Checked)) Then

            MsgBox("Debe llenar todos los datos.", vbCritical, "SMUSURA0")
            Exit Sub
        End If

        Dim frmVisor As New frmCRVisorReporte
        Try
            Select Case mNomRep
                Case EnumReportes.MetaProsperidad
                    frmVisor.Parametros("@BarrioID") = IIf(cboBarrio.Text <> "Todos", cboBarrio.SelectedValue, 0)
                    frmVisor.Parametros("@DistritoID") = IIf(cboDistrito.Text <> "Todos", cboDistrito.SelectedValue, 0)
                    frmVisor.Parametros("@MunicipioID") = IIf(cboMunicipio.Text <> "Todos", cboMunicipio.SelectedValue, 0)
                    frmVisor.Parametros("@DepartamentoID") = IIf(CboDepartamento.Text <> "Todos", CboDepartamento.SelectedValue, 0)
                    If RdUsuraCero.Checked Then
                        frmVisor.Parametros("@Programa") = 557
                    ElseIf RdVentanadeGenero.Checked Then
                        frmVisor.Parametros("@Programa") = 558
                    Else
                        frmVisor.Parametros("@Programa") = 947
                    End If
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    Dim fechaINI As String = cdeFechaInicial.Text.Split("/")(2) & "-" & cdeFechaInicial.Text.Split("/")(1) & "-" & cdeFechaInicial.Text.Split("/")(0)
                    Dim fechaFIN As String = CdeFechaFinal.Text.Split("/")(2) & "-" & CdeFechaFinal.Text.Split("/")(1) & "-" & CdeFechaFinal.Text.Split("/")(0)
                    frmVisor.Parametros("@Desde") = fechaINI
                    frmVisor.Parametros("@Hasta") = fechaFIN
                    Me.Cursor = Cursors.WaitCursor
                    frmVisor.NombreReporte = "RepSccCC90.rpt"
                    frmVisor.Text = "Resumen por Grupo Solidario y Meta de Prosperidad"
                    frmVisor.Show()
                    Me.Cursor = Cursors.Default
            End Select
        Catch

        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSccParametrosGSMetaProsperidad_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSccParametrosGSMetaProsperidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.strColor)

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()

            Me.cboDistrito.Enabled = False
            Me.cboBarrio.Enabled = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
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

    Private Sub frmSccParametrosGSMetaProsperidad_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        Me.Text = "Parámetros de resumen de grupo solidario y meta de prosperidad."
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