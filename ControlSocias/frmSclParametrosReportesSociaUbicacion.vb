Public Class frmSclParametrosReportesSociaUbicacion

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
        RangoEdades = 1
        NivelEscolaridad = 2
        EstadoCivil = 3
        NegocioAnterior = 4
        NegocioActivo = 5
        CaracteristicaNegocio = 6
        RegistroVentas = 7
        FuncionamientoNegocio = 8
        FinanciamientoNegocio = 9
        ProsperidadNegocio = 10
        PercepcionMejoriaNegocioSI = 11
        PercepcionMejoriaNegocioNO = 12
        CantPersonasTrabajanNegocio = 13
        ResumenGerencia = 14
        SociasRubroEconomico = 15
        SociasActividadEconomica = 16
        'Supervisiones
        Supervisiones = 17
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

    Private Sub frmSclParametrosReportesSociaUbicacion_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Try
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSclParametrosReportesSociaUbicacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.strColor)

            InicializarVariables()
            EncuentraParametros()
            CargarDepartamento()
            CargarVeces()
            CargarFuente()
            CargarMonto()

            If mNomRep = EnumReportes.ResumenGerencia Or
                mNomRep = EnumReportes.SociasRubroEconomico Or
                mNomRep = EnumReportes.SociasActividadEconomica Or
                mNomRep = EnumReportes.Supervisiones Then

                'lblDepartamento.Enabled = False
                'lblMunicipio.Enabled = False
                'CboDepartamento.Enabled = False
                'cboMunicipio.Enabled = False
                grpEstadoCredito.Enabled = False
                grpNivelDetalle.Enabled = False
                grpVeces.Enabled = False
                grpMonto.Enabled = False
                grpFondoFuente.Enabled = False
                grpFuente.Enabled = False
                grpPrograma.Enabled = False

            End If

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


    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

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
            ElseIf intLimpiarID = 1 Then
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

    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.TextChanged
        If Me.CboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
    End Sub

    Private Sub HabilitarComboMunicipio()
        'If Me.CboDepartamento.SelectedIndex > 0 Then
        If (Me.CboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.CboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
        Else
            Me.cboMunicipio.Enabled = False
        End If
    End Sub


    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        If mNomRep = EnumReportes.Supervisiones Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmVisor As New frmCRVisorReporte
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@nStbDepartamentoID") = IIf(CboDepartamento.Text <> "Todos", CboDepartamento.SelectedValue, -1)
            frmVisor.Parametros("@nStbMunicipioID") = IIf(cboMunicipio.Text <> "Todos", cboMunicipio.SelectedValue, -1)
            frmVisor.NombreReporte = "RepSclCS65.rpt"
            frmVisor.Text = "Supervisiones"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Show()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If mNomRep = EnumReportes.ResumenGerencia Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmVisor As New frmCRVisorReporte
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Dep") = "'" & CboDepartamento.Text & "'"
            frmVisor.Formulas("Mun") = "'" & cboMunicipio.Text & "'"
            frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@Dep") = IIf(CboDepartamento.Text <> "Todos", CboDepartamento.SelectedValue, -1)
            frmVisor.Parametros("@Mun") = IIf(cboMunicipio.Text <> "Todos", cboMunicipio.SelectedValue, -1)
            frmVisor.Parametros("nRep1") = 1
            frmVisor.Parametros("nRep2") = 2
            frmVisor.Parametros("nRep3") = 3
            frmVisor.Parametros("nRep4") = 4
            frmVisor.Parametros("nRep5") = 5
            frmVisor.NombreReporte = "RepSclCS62.rpt"
            frmVisor.Text = "Resumen de Gerencia"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Show()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        If mNomRep = EnumReportes.SociasRubroEconomico Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmVisor As New frmCRVisorReporte
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Dep") = "'" & CboDepartamento.Text & "'"
            frmVisor.Formulas("Mun") = "'" & cboMunicipio.Text & "'"
            frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@CodDepartamento") = IIf(CboDepartamento.Text <> "Todos", CboDepartamento.SelectedValue, "-1")
            frmVisor.Parametros("@CodMunicipio") = IIf(cboMunicipio.Text <> "Todos", cboMunicipio.SelectedValue, "-1")
            frmVisor.Parametros("@Fondo") = 2
            frmVisor.Parametros("@Fuente") = -1
            frmVisor.Parametros("@TipoPrograma") = 1
            frmVisor.Parametros("@PorFondo") = 1
            frmVisor.Parametros("@TIPOCREDITO") = 1
            frmVisor.NombreReporte = "RepSclCS63.rpt"
            frmVisor.Text = "Resumen de Gerencia"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Show()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        If mNomRep = EnumReportes.SociasActividadEconomica Then
            Me.Cursor = Cursors.WaitCursor
            Dim frmVisor As New frmCRVisorReporte
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Dep") = "'" & CboDepartamento.Text & "'"
            frmVisor.Formulas("Mun") = "'" & cboMunicipio.Text & "'"
            frmVisor.Parametros("@codDepartamento") = IIf(CboDepartamento.Text <> "Todos", CboDepartamento.SelectedValue, "-1")
            frmVisor.Parametros("@codMunicipio") = IIf(cboMunicipio.Text <> "Todos", cboMunicipio.SelectedValue, "-1")
            frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
            frmVisor.Parametros("@nReporte") = "6"
            frmVisor.NombreReporte = "RepSclCS64.rpt"
            frmVisor.Text = "Resumen de Gerencia"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Show()
            Me.Cursor = Cursors.Default
            Exit Sub
        End If

        Try
            If ValidarDatos() Then
                Dim frmVisor As New frmCRVisorReporte
                Dim fechaINI As Date = cdeFechaInicial.Value
                Dim fechaFIN As Date = CdeFechaFinal.Value
                Dim param As String = ""
                Me.Cursor = Cursors.WaitCursor
                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                frmVisor.Formulas("NivelDetalle") = IIf(rdoDept.Checked, 1, IIf(rdoMuni.Checked, 2, IIf(rdoDist.Checked, 3, IIf(rdoBarrio.Checked, 4, 0))))
                param = "'Parámetros: (Dep: " & CboDepartamento.Text & ") (Mun: " & cboMunicipio.Text & ") (Nivel: "
                If rdoDept.Checked Then param &= "Departamentos) "
                If rdoMuni.Checked Then param &= "Municipio) "
                If rdoDist.Checked Then param &= "Distrito) "
                If rdoBarrio.Checked Then param &= "Barrio) "
                param &= "(RangoFechas: " & Mid(cdeFechaInicial.Value, 1, 10) & " - " & Mid(CdeFechaFinal.Value, 1, 10) & ") "
                param &= " (Estado Créditos: "
                If rdCreditoAprobado.Checked Then param &= "Aprobados) "
                If rdCreditoRechazado.Checked Then param &= "Rechazados) "
                param &= "'"
                frmVisor.Formulas("Parametros") = param
                frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
                frmVisor.Parametros("@CodDepartamento") = IIf(CboDepartamento.Text <> "Todos", CboDepartamento.SelectedValue, "-1")
                frmVisor.Parametros("@CodMunicipio") = IIf(cboMunicipio.Text <> "Todos", cboMunicipio.SelectedValue, "-1")
                frmVisor.Parametros("@TipoVecesCreditos") = CboVeces.SelectedIndex
                frmVisor.Parametros("@Fondo") = IIf(RdTodos.Checked, 2, IIf(RdPresupuesto.Checked, 1, IIf(RdExterno.Checked, 0, IIf(RdSinFuente.Checked, -1, -2))))
                frmVisor.Parametros("@Fuente") = IIf(CboFuentes.SelectedIndex <> 0, CboFuentes.Columns("nScnFuenteFinanciamientoID").Value, -1)
                frmVisor.Parametros("@TipoPrograma") = IIf(RdUsuraCero.Checked, 1, IIf(RdVentanadeGenero.Checked, 2, IIf(RdPDIBA.Checked, 3, 0)))
                frmVisor.Parametros("@PorFondo") = IIf(radFondos.Checked, 1, 0)

                If cboMontoAprobado.Text = "(Todos)" Then
                    frmVisor.Parametros("@nMontoCreditoAprobado") = 0
                Else
                    frmVisor.Parametros("@nMontoCreditoAprobado") = CInt(cboMontoAprobado.Text)
                End If

                frmVisor.Parametros("@Aprobado") = IIf(rdCreditoAprobado.Checked, 1, 0)

                Select Case mNomRep
                    Case EnumReportes.RangoEdades
                        frmVisor.NombreReporte = "RepSclCS46.rpt"
                        frmVisor.Text = "Protagonistas por Grupo de Edad"
                        frmVisor.Parametros("@nRep") = 46
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.EstadoCivil
                        frmVisor.NombreReporte = "RepSclCS48.rpt"
                        frmVisor.Text = "Protagonistas por Estado Civil"
                        frmVisor.Parametros("@nRep") = 48
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.NivelEscolaridad
                        frmVisor.NombreReporte = "RepSclCS47.rpt"
                        frmVisor.Text = "Protagonistas por Nivel de Escolaridad"
                        frmVisor.Parametros("@nRep") = 47
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.NegocioAnterior
                        frmVisor.NombreReporte = "RepSclCS49.rpt"
                        frmVisor.Text = "Protagonistas - Negocio Anterior"
                        frmVisor.Parametros("@nRep") = 49
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.NegocioActivo
                        frmVisor.NombreReporte = "RepSclCS50.rpt"
                        frmVisor.Text = "Protagonistas - Negocios Evaluados"
                        frmVisor.Parametros("@nRep") = 50
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.CaracteristicaNegocio
                        frmVisor.NombreReporte = "RepSclCS51.rpt"
                        frmVisor.Text = "Protagonistas - Característica del Negocio"
                        frmVisor.Parametros("@nRep") = 51
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.RegistroVentas
                        frmVisor.NombreReporte = "RepSclCS52.rpt"
                        frmVisor.Text = "Protagonistas - Registros de Ventas"
                        frmVisor.Parametros("@nRep") = 52
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.FuncionamientoNegocio
                        frmVisor.NombreReporte = "RepSclCS53.rpt"
                        frmVisor.Text = "Protagonistas - Funcionamiento del Negocio"
                        frmVisor.Parametros("@nRep") = 53
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.FinanciamientoNegocio
                        frmVisor.NombreReporte = "RepSclCS54.rpt"
                        frmVisor.Text = "Protagonistas - Financiamiento con Otras Instituciones"
                        frmVisor.Parametros("@nRep") = 54
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.ProsperidadNegocio
                        frmVisor.NombreReporte = "RepSclCS55.rpt"
                        frmVisor.Text = "Protagonistas - Prosperidad Negocio"
                        frmVisor.Parametros("@nRep") = 55
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.PercepcionMejoriaNegocioSI
                        frmVisor.NombreReporte = "RepSclCS56.rpt"
                        frmVisor.Text = "Protagonistas que perciben mejorías en su familia"
                        frmVisor.Parametros("@nRep") = 56
                        frmVisor.Parametros("@PercepcionMejoria") = 1
                    Case EnumReportes.PercepcionMejoriaNegocioNO
                        frmVisor.NombreReporte = "RepSclCS56.rpt"
                        frmVisor.Text = "Protagonistas que perciben mejorías en su familia"
                        frmVisor.Parametros("@nRep") = 56
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                    Case EnumReportes.CantPersonasTrabajanNegocio
                        frmVisor.NombreReporte = "RepSclCS57.rpt"
                        frmVisor.Text = "Personas que trabajan con la protagonista"
                        frmVisor.Parametros("@nRep") = 57
                        frmVisor.Parametros("@PercepcionMejoria") = 0
                End Select

                frmVisor.WindowState = FormWindowState.Maximized
                frmVisor.Show()
                Me.Cursor = Cursors.Default
            End If
        Catch

        End Try
    End Sub


    Public Function ValidarDatos() As Boolean
        If CboDepartamento.Text = "" Then
            MsgBox("Debe elejir un departamento.", vbCritical, "SMUSURA0")
            Return False
        End If
        If cboMunicipio.Text = "" Then
            MsgBox("Debe elejir un municipio.", vbCritical, "SMUSURA0")
            Return False
        End If
        If CboVeces.Text = "" And rdCreditoAprobado.Checked Then
            MsgBox("Debe especificar la cantidad de veces aprobadas.", vbCritical, "SMUSURA0")
            Return False
        End If
        If cboMontoAprobado.Text = "" Then
            MsgBox("Debe especificar el monto aprobado.", vbCritical, "SMUSURA0")
            Return False
        End If
        If cdeFechaInicial.Text = "" Or CdeFechaFinal.Text = "" Then
            MsgBox("Debe especificar un rango de fechas válido.", vbCritical, "SMUSURA0")
            Return False
        End If
        'If CDate(cdeFechaInicial.Text) < CDate("15/11/2014") Or CDate(CdeFechaFinal.Text) < CDate(cdeFechaInicial.Text) Then
        '    MsgBox("Debe especificar un rango de fechas válido.", vbCritical, "SMUSURA0")
        '    Return False
        'End If
        If CboFuentes.Text = "" Then
            MsgBox("Debe especificar la fuente de financiamiento asignada.", vbCritical, "SMUSURA0")
            Return False
        End If
        Return True
    End Function

    Private Sub rdCreditoAprobado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdCreditoAprobado.CheckedChanged
        If rdCreditoAprobado.Checked Then
            grpVeces.Enabled = True
            grpMonto.Enabled = True
            grpRangoFechas.Enabled = True
            grpFondoFuente.Enabled = True
            grpFuente.Enabled = True
            grpPrograma.Enabled = False
        Else
            grpVeces.Enabled = False
            grpMonto.Enabled = True
            grpRangoFechas.Enabled = True
            grpFondoFuente.Enabled = False
            grpFuente.Enabled = False
            grpPrograma.Enabled = False
        End If
    End Sub

    Private Sub radFondos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radFondos.CheckedChanged
        If radFondos.Checked Then
            CboFuentes.Enabled = False
            grpFuente.Enabled = True
        Else
            CboFuentes.Enabled = True
            grpFuente.Enabled = False
        End If
    End Sub

    Private Sub CargarVeces()

        'If (mNomRep > 0) Then
        CboVeces.AddItem("Al menos Un Crédito")
        CboVeces.AddItem("Solo Un Crédito")
        CboVeces.AddItem("Dos Créditos")
        CboVeces.AddItem("Tres Créditos")
        CboVeces.AddItem("Cuatro Créditos o más")
        CboVeces.Columns(0).Caption = ""

        'Else
        '    CboVeces.AddItem("Al menos Un Crédito")
        '    CboVeces.AddItem("Solo Un Crédito")
        '    CboVeces.AddItem("Dos Créditos")
        '    CboVeces.AddItem("Tres Créditos")
        '    CboVeces.AddItem("Cuatro Créditos")
        '    CboVeces.AddItem("Cinco Créditos")
        '    CboVeces.AddItem("Seis Créditos")
        '    CboVeces.AddItem("Siete Créditos")
        '    CboVeces.AddItem("Ocho Créditos")
        '    CboVeces.AddItem("Nueve Créditos")
        '    CboVeces.AddItem("Diez Créditos")
        '    CboVeces.AddItem("Once Créditos o más")
        '    CboVeces.Columns(0).Caption = ""
        'End If
    End Sub

    Private Sub CargarFuente()
        Try
            Dim Strsql As String

            'If IntPermiteConsultar = 0 Then
            '    Strsql = "SELECT   1 As Orden , a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
            '             " FROM         dbo.ScnFuenteFinanciamiento a Where  a.nScnFuenteFinanciamientoID=-1"
            'Else
            '    Strsql = "SELECT     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
            '                             " FROM         dbo.ScnFuenteFinanciamiento a Order By a.sCodigo "
            'End If

            Strsql = "SELECT     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" &
                                         " FROM         dbo.ScnFuenteFinanciamiento a Order By a.sCodigo "

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
            If Me.CboFuentes.ListCount > 0 Then
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
        End Try
    End Sub


    Private Sub CargarMonto()
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
    End Sub


End Class