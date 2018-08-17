Public Class frmSclEditPromocion

    Public intPromocionID As Integer
    Dim XdsCombos As BOSistema.Win.XDataSet
    Public IntPermiteConsultar As Integer
    Dim IntDepartamento As Integer


    Private Sub frmSclEditPromocion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            Me.cboPromotor.DropDownWidth = cboPromotor.Width
            Me.cboDepartamento.DropDownWidth = Me.cboDepartamento.Width
            Me.cboMunicipio.DropDownWidth = Me.cboMunicipio.Width
            Me.cboDistrito.DropDownWidth = Me.cboDistrito.Width
            Me.cboBarrio.DropDownWidth = Me.cboBarrio.Width

            InicializarVariables()
            CargarDepartamento()
            HabilitarComboMunicipio()

            CargarPromotores()

            CargarPromocion()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarPromocion()

        If intPromocionID <> 0 Then

            Dim cmd As New BOSistema.Win.XDataSet.xDataTable

            cmd.ExecuteSql("Select * from SclPromocion where nSclPromocionID=" & intPromocionID)

            Dim depID As Integer = 0
            Dim munID As Integer = 0
            Dim disID As Integer = 0
            Dim barrID As Integer = 0
            Dim promID As Integer = 0

            Dim fecha As New DateTime()

            Dim nNoAsambleas As Integer = 0
            Dim nNoCasas As Integer = 0
            Dim nNoGrupos As Integer = 0
            Dim nNoNuevas As Integer = 0
            Dim nNoSubsecuentes As Integer = 0
            Dim nNoSociasAI As Integer = 0

            depID = cmd.Current.Item("nStbDepartamentoID")
            munID = cmd.Current.Item("nStbMunicipioID")
            disID = cmd.Current.Item("nStbDistritoID")
            barrID = cmd.Current.Item("nStbBarrioID")
            promID = cmd.Current.Item("nSrhPromotorID")

            fecha = cmd.Current.Item("dFechaPromocion")

            nNoAsambleas = cmd.Current.Item("nNoAsambleas")
            nNoCasas = cmd.Current.Item("nNoCasas")
            nNoGrupos = cmd.Current.Item("nNoGrupos")
            nNoNuevas = cmd.Current.Item("nNoSociasNuevas")
            nNoSubsecuentes = cmd.Current.Item("nNoSociasSubsecuentes")
            nNoSociasAI = cmd.Current.Item("nNoSociasAI")

            XdsCombos("Departamento").SetCurrentByID("nStbDepartamentoID", depID)
            XdsCombos("Municipio").SetCurrentByID("nStbMunicipioID", munID)
            XdsCombos("Distrito").SetCurrentByID("nStbDistritoID", disID)
            XdsCombos("Barrio").SetCurrentByID("nStbBarrioID", barrID)
            XdsCombos("Promotor").SetCurrentByID("nSrhEmpleadoID", promID)

            cdeFecha.Value = fecha

            cneAsambleas.Value = nNoAsambleas
            cneCasas.Value = nNoCasas
            cneGrupos.Value = nNoGrupos
            cneNuevas.Value = nNoNuevas
            cneSubsecuentes.Value = nNoSubsecuentes
            cneInduccion.Value = nNoSociasAI

        End If

    End Sub

    Private Sub HabilitarComboMunicipio()
        'If Me.CboDepartamento.SelectedIndex > 0 Then
        If (Me.cboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 1) Or (Me.cboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
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
            If Me.cboDistrito.SelectedIndex >= 0 Then
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

    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet
            IntPermiteConsultar = 1


            Dim strSQL As String
            Dim cmd As New BOSistema.Win.XComando
            strSQL = "SELECT nStbDepartamentoID FROM vwStbDatosDelegacion WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntDepartamento = cmd.ExecuteScalar(strSQL)

            Me.cdeFecha.Value = FechaServer()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 1 Then
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
                '    XdsCombos("Departamento").AddRow()
                '    XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                '    XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -1
                '    XdsCombos("Departamento").ValueField("Orden") = 0
                '    XdsCombos("Departamento").UpdateLocal()
                '    XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.cboDepartamento.SelectedIndex = 0
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
                If XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -1 Then
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
                '    XdsCombos("Municipio").AddRow()
                '    XdsCombos("Municipio").ValueField("Descripcion") = "Todos"
                '    XdsCombos("Municipio").ValueField("nStbMunicipioID") = -1
                '    XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -1
                '    XdsCombos("Municipio").ValueField("Orden") = 0
                '    XdsCombos("Municipio").UpdateLocal()
                '    XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
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
                '    XdsCombos("Distrito").AddRow()
                '    XdsCombos("Distrito").ValueField("Descripcion") = "Todos"
                '    XdsCombos("Distrito").ValueField("nStbDistritoID") = -1
                '    XdsCombos("Distrito").ValueField("Orden") = 0
                '    XdsCombos("Distrito").UpdateLocal()
                '    XdsCombos("Distrito").Sort = "Orden,sCodigo asc"
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
            If Me.cboDepartamento.SelectedIndex >= 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex >= 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If
            If Me.cboDistrito.SelectedIndex >= 0 Then
                CadWhere = CadWhere & " And dbo.StbBarrio.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
            End If

            'CadWhere = CadWhere & " And dbo.StbBarrio.sCodigo<>'---' "


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
                '    XdsCombos("Barrio").AddRow()
                '    XdsCombos("Barrio").ValueField("Descripcion") = "Todos"
                '    XdsCombos("Barrio").ValueField("nStbDistritoID") = -1
                '    XdsCombos("Barrio").ValueField("Orden") = 0
                '    XdsCombos("Barrio").UpdateLocal()
                '    XdsCombos("Barrio").Sort = "Orden,sCodigo asc"
                Me.cboBarrio.SelectedIndex = 0
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarPromotores()
        Dim strSQL As String

        'Promotores:
        Try
            'strSQL = "spSrhEmpleadoCargoLista '%custom_1%' "
            strSQL = "spSrhEmpleadoDelegacionRRHH " & InfoSistema.IDDelegacion

            If XdsCombos.ExistTable("Promotor") Then
                XdsCombos("Promotor").ExecuteSql(strSQL)
            Else
                XdsCombos.NewTable(strSQL, "Promotor")
                XdsCombos("Promotor").Retrieve()
            End If

            cboPromotor.DataSource = XdsCombos("Promotor").Source

            cboPromotor.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            cboPromotor.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            cboPromotor.Columns("cNombresApellidos").Caption = "Promotor"

            cboPromotor.DisplayMember = "cNombresApellidos"
            cboPromotor.ValueMember = "nSrhEmpleadoID"

            If XdsCombos("Promotor").Count > 0 Then
                cboPromotor.SelectedIndex = 0
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
            'CargarBarrio(0)
        Else
            CargarMunicipio(1)
        End If

        HabilitarComboMunicipio()
        'HabilitarComboBarrio()

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
        Else
            CargarDistrito(1)
            CargarBarrio(1)
        End If
        'HabilitarComboBarrio()
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged

        'Me.cboBarrio.Enabled = True
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarBarrio(0)
        Else
            CargarBarrio(1)
        End If
        HabilitarComboBarrio()
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click

        Try
            If ValidarDatos() Then
                SalvarPromocion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Function ValidarDatos() As Boolean

        If XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -1 Then
            MsgBox("Debe elegir un departamento válido", vbCritical, "SMUSURA0")
            Return False
        End If
        If XdsCombos("Municipio").ValueField("nStbMunicipioID") = -1 Then
            MsgBox("Debe elegir un municipio válido", vbCritical, "SMUSURA0")
            Return False
        End If
        If XdsCombos("Distrito").ValueField("nStbDistritoID") = -1 Then
            MsgBox("Debe elegir un distrito válido", vbCritical, "SMUSURA0")
            Return False
        End If
        If XdsCombos("Barrio").ValueField("nStbBarrioID") = -1 Then
            MsgBox("Debe elegir un barrio válido", vbCritical, "SMUSURA0")
            Return False
        End If
        If XdsCombos("Promotor").ValueField("nSrhEmpleadoID") = -1 Then
            MsgBox("Debe elegir un promotor válido", vbCritical, "SMUSURA0")
            Return False
        End If

        If IsDate(cdeFecha.Value) Then
            If cdeFecha.Value > FechaServer() Then
                MsgBox("La fecha de la visita no puede ser mayor al día de hoy", vbCritical, "SMUSURA0")
                Return False
            End If
        Else
            MsgBox("Debe seleccionar una fecha válida", vbCritical, "SMUSURA0")
            Return False
        End If

        If Not IsNumeric(cneAsambleas.Text) Then
            MsgBox("Debe escribir una cantidad válida", vbCritical, "SMUSURA0")
            Return False
        End If
        If Not IsNumeric(cneGrupos.Text) Then
            MsgBox("Debe escribir una cantidad válida", vbCritical, "SMUSURA0")
            Return False
        End If
        If Not IsNumeric(cneCasas.Text) Then
            MsgBox("Debe escribir una cantidad válida", vbCritical, "SMUSURA0")
            Return False
        End If
        If Not IsNumeric(cneNuevas.Text) Then
            MsgBox("Debe escribir una cantidad válida", vbCritical, "SMUSURA0")
            Return False
        End If
        If Not IsNumeric(cneSubsecuentes.Text) Then
            MsgBox("Debe escribir una cantidad válida", vbCritical, "SMUSURA0")
            Return False
        End If
        If Not IsNumeric(cneInduccion.Text) Then
            MsgBox("Debe escribir una cantidad válida", vbCritical, "SMUSURA0")
            Return False
        End If

        Dim cmd As New BOSistema.Win.XComando
        Dim cantidad As Integer = 0
        cantidad = cmd.ExecuteScalar("Select COUNT(*) from SclPromocion where nSrhPromotorID=" &
        XdsCombos("Promotor").ValueField("nSrhEmpleadoID") & " And CAST(dFechaPromocion as date)='" &
        Format(cdeFecha.Value, "yyyy-MM-dd") & "'"
        )

        If cantidad > 1 And Me.intPromocionID = 0 Then
            MsgBox("Ya existen " & cantidad & " registros para este promotor en esta fecha.", vbExclamation, "Alerta")
            Return False
        End If

        Return True

    End Function

    Private Sub SalvarPromocion()
        Try
            Dim strsql As String

            strsql = "Exec spSclGrabarPromocion "
            strsql &= Me.intPromocionID & ", "
            strsql &= XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ", "
            strsql &= XdsCombos("Municipio").ValueField("nStbMunicipioID") & ", "
            strsql &= XdsCombos("Distrito").ValueField("nStbDistritoID") & ", "
            strsql &= XdsCombos("Barrio").ValueField("nStbBarrioID") & ", "
            strsql &= XdsCombos("Promotor").ValueField("nSrhEmpleadoID") & ", "
            strsql &= "'" & Format(cdeFecha.Value, "yyyy-MM-dd") & "', "

            strsql &= CInt(cneAsambleas.Text) & ", "
            strsql &= CInt(cneCasas.Text) & ", "
            strsql &= CInt(cneGrupos.Text) & ", "
            strsql &= CInt(cneNuevas.Text) & ", "
            strsql &= CInt(cneSubsecuentes.Text) & ", "
            strsql &= CInt(cneInduccion.Text) & ", "

            strsql &= InfoSistema.IDCuenta

            Dim cmd As New BOSistema.Win.XComando

            cmd.ExecuteNonQuery(strsql)

            MsgBox("Se ha grabado la información correctamente", vbInformation, "SMUSURA0")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Close()
        End Try

    End Sub
End Class