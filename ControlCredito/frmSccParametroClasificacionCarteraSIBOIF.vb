Public Class frmSccParametrosClasificacionCarteraSIBOIF
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
    'Listado de Reportes
    Public Enum EnumReportes
        cc91 = 1
    End Enum

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
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

    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
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

            'If IntPermiteConsultar = 0 Then
            'Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
            '         " From StbDepartamento a " & _
            '         " Where a.nStbDepartamentoID = " & Me.IntDepartamento & _
            '         " Order by a.sCodigo"
            'Else
            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"
            'End If

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
            'If Me.CboDepartamento.ListCount > 0 And IntPermiteConsultar = 1 Then
            XdsCombos("Departamento").AddRow()
            XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
            XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
            XdsCombos("Departamento").ValueField("Orden") = 0
            XdsCombos("Departamento").UpdateLocal()
            XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
            Me.CboDepartamento.SelectedIndex = 0
            'End If
            HabilitarComboMunicipio()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub HabilitarComboMunicipio()
        'If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
        Me.cboMunicipio.Enabled = True
        'Else
        '    Me.cboMunicipio.Enabled = False
        'End If
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


    Private Sub CargarFuente()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            'If IntPermiteConsultar = 0 Then
            'Strsql = "SELECT   1 As Orden , a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
            '         " FROM         dbo.ScnFuenteFinanciamiento a Where  a.nScnFuenteFinanciamientoID=-1"
            'Else
            Strsql = "SELECT     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
                                     " FROM         dbo.ScnFuenteFinanciamiento a Order By a.sCodigo "
            'End If

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
            'If Me.CboFuentes.ListCount > 0 And IntPermiteConsultar = 1 Then
            XdsCombos("Fuente").AddRow()
            XdsCombos("Fuente").ValueField("sNombre") = "Todos"
            XdsCombos("Fuente").ValueField("sCodigo") = -19
            XdsCombos("Fuente").ValueField("Orden") = 0
            XdsCombos("Fuente").UpdateLocal()
            XdsCombos("Fuente").Sort = "Orden,sCodigo asc"
            Me.CboFuentes.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub


    Private Sub frmSccParametrosClasificacionCarteraSIBOIF_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)


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

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim CadSql As String

        Try
            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""
            frmVisor.WindowState = FormWindowState.Maximized

            Select Case mNomRep
                Case EnumReportes.cc91
                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC91.rpt"

                    'frmVisor.Parametros("@CodigoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)
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
                    frmVisor.Text = "Clasificación de Cartera por Normativa SIBOIF"

                    Dim strParametro As String = ""
                    strParametro = "' Parámetros (Depto.: " & Me.CboDepartamento.Text & ")  (Munic.: " & Me.cboMunicipio.Text & ") "
                    If radFondos.Checked Then
                        strParametro &= "(Fondos: " & IIf(RdTodos.Checked, "Todos", IIf(RdPresupuesto.Checked, "Presupuesto", "Externos")) & ") "
                    End If
                    If radFuentes.Checked Then
                        strParametro &= "(Fuente: " & CboFuentes.SelectedText & ") "
                    End If
                    strParametro &= "(Saldos: " & IIf(radTodosFecha.Checked, "Todos", IIf(radVencidosFecha.Checked, "Vencidos", "Activos")) & ") "
                    strParametro &= "(Programa: " & IIf(RdUsuraCero.Checked, "Usura Cero", IIf(RdPDIBA.Checked, "PDIBA", "Ventana de Genero")) & ") "
                    strParametro &= "(Nivel Detalle: " & IIf(ChkBarrio.Checked, "Barrios", IIf(ChkDistrito.Checked, "Distritos", IIf(ChkMun.Checked, "Municipios", "Departamentos"))) & ") "
                    strParametro &= " '"

                    frmVisor.Formulas("Parametro") = strParametro
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@ConMora") = 0
                    frmVisor.Parametros("@DepartamentoId") = IIf(Me.CboDepartamento.SelectedIndex > 0, Me.CboDepartamento.Columns("nStbDepartamentoID").Value, -1)
                    frmVisor.Parametros("@MunicipioId") = IIf(Me.cboMunicipio.SelectedIndex > 0, Me.cboMunicipio.Columns("nStbMunicipioID").Value, -1)
                    frmVisor.Parametros("@VencidosFecha") = IIf(radTodosFecha.Checked, 0, IIf(radVencidosFecha.Checked, 1, 2))
                    frmVisor.Parametros("@nScnFuenteFinanciamientoID") = IIf(Me.radFondos.Checked, 0, Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value)
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    If ChkBarrio.Checked Then
                        frmVisor.Formulas("NivelDetalle") = 3
                    ElseIf ChkDistrito.Checked Then
                        frmVisor.Formulas("NivelDetalle") = 2
                    ElseIf ChkMun.Checked Then
                        frmVisor.Formulas("NivelDetalle") = 1
                    ElseIf ChkDep.Checked Then
                        frmVisor.Formulas("NivelDetalle") = 0
                    End If

            End Select

            frmVisor.Show()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
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

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                If Me.CboDepartamento.SelectedText <> "Todos" Then
                    MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                    Me.cboMunicipio.Focus()
                    GoTo SALIR
                End If
            End If

            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If

            If Not (ChkDep.Checked Or ChkMun.Checked Or ChkDistrito.Checked Or ChkBarrio.Checked) Then
                MsgBox("Debe seleccionar al menos un nivel de detalle.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar al menos un nivel de detalle.")
                GoTo salir
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub ChkDep_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDep.CheckedChanged
        If ChkDep.Checked = True Then
            ChkMun.Enabled = True
        End If
    End Sub

    Private Sub ChkMun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkMun.CheckedChanged
        If ChkMun.Checked = True Then
            ChkDistrito.Enabled = True
        End If
    End Sub

    Private Sub ChkDistrito_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkDistrito.CheckedChanged
        If ChkDistrito.Checked = True Then
            ChkBarrio.Enabled = True
        End If
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

End Class