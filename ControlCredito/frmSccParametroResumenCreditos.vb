Imports System.Text

Public Class frmSccParametroResumenCreditos

    Dim IntPermiteConsultar As Integer
    Dim IntDepartamento As Integer

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim mColorVentana As String

    'Listado de Reportes
    Public Enum EnumReportes
        ResumenCreditos = 0
        Consolidado = 1
        Detalle = 2
        NivelAcademico = 3
        Estadistico = 4
        NuncaPagado = 5
        EstadisticaDesembolso = 6
        EstadisticaRecuperacion = 7
        ComportamientoDeMora = 8

    End Enum

    Dim mNomRep As EnumReportes

    Public Property ColorVentana() As String
        Get
            Return mColorVentana
        End Get
        Set(ByVal value As String)
            mColorVentana = value
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

            'Inicializar las clases 
            XdsCombos = New BOSistema.Win.XDataSet
            'Titúlo de Reporte
            Control.CheckForIllegalCrossThreadCalls = False
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
            Me.cboDepartamento.DataSource = XdsCombos("Departamento").Source

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDepartamento.ListCount > 0 And IntPermiteConsultar = 1 Then
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.cboDepartamento.SelectedIndex = 0
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

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

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

    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
    End Sub

    Private Function ValidarParametros() As Boolean
        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False
            Me.errParametro.Clear()
            'Departamento
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                GoTo SALIR
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                GoTo SALIR
            End If
            ' If mNomRep <> EnumReportes.NivelAcademico Then 'And mNomRep <> EnumReportes.Estadistico Then restaurar

            If IsDBNull(cdeFechaInicial.Value) And mNomRep <> EnumReportes.NuncaPagado Then
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
            If mNomRep <> EnumReportes.NuncaPagado Then
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
            End If

            If mNomRep <> EnumReportes.NivelAcademico And _
               mNomRep <> EnumReportes.Detalle And _
               mNomRep <> EnumReportes.Estadistico And _
               mNomRep <> EnumReportes.NuncaPagado And _
               mNomRep <> EnumReportes.EstadisticaDesembolso And _
               mNomRep <> EnumReportes.EstadisticaRecuperacion And _
               Me.NomRep <> EnumReportes.ComportamientoDeMora Then
                If CboVeces.SelectedIndex = -1 And RdAprobado.Checked = True Then
                    MsgBox("Debe seleccionar El número de créditos para las socias.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboVeces, "Debe seleccionar El número de créditos para las socias.")
                    Me.CboVeces.Focus()
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
        '----------------------------------------------------------------------
        'Llama al reporte del listado de consolidados de créditos
        '----------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim Filtro2 As String
        Dim CadSql As String
        Dim CadSql2 As String
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim SubCadFiltro As String

        Dim TipoReporte As Integer
        Try

            If ValidarParametros() = False Then Exit Sub

            If RdDistrito.Checked = True Then
                If RdAprobado.Checked = True Then
                    TipoReporte = 1
                Else
                    If RdDenegado.Checked = True Then
                        TipoReporte = 2
                    End If
                End If
            ElseIf RdMercado.Checked = True Or rdoCooperativa.Checked = True Then
                If RdAprobado.Checked = True Then
                    TipoReporte = 3
                Else
                    If RdDenegado.Checked = True Then
                        TipoReporte = 4
                    End If
                End If
            ElseIf RdActas.Checked = True Then
                If RdAprobado.Checked = True Then
                    TipoReporte = 5
                Else
                    If RdDenegado.Checked = True Then
                        TipoReporte = 6
                    End If
                End If
            End If

            Filtro = ""

            If mNomRep <> EnumReportes.NivelAcademico And mNomRep <> EnumReportes.Estadistico And mNomRep <> EnumReportes.NuncaPagado Then
                If mNomRep = EnumReportes.ResumenCreditos Then
                    Filtro = " And dFechaNotificacion>=CONVERT(DATETIME,''" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'') And dFechaNotificacion<CONVERT(DATETIME,''" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "'') "
                Else
                    Filtro = " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                End If
            End If

            If TipoReporte = 6 And mNomRep = 0 Then
                If mNomRep = EnumReportes.ResumenCreditos Then
                    Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,''" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'') And dFechaNotificacion<CONVERT(DATETIME,''" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "'') "
                Else
                    Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                End If
            End If

            If cboDepartamento.SelectedIndex <> -1 And cboDepartamento.Text <> "Todos" Then
                If mNomRep = EnumReportes.ResumenCreditos Then
                    Filtro = Filtro & "And Departamento=''" & Trim(cboDepartamento.Text) & "''"
                    If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        Filtro = Filtro & " And Municipio=''" & Trim(cboMunicipio.Text) & "''"
                    End If
                Else
                    Filtro = Filtro & " And Departamento='" & Trim(cboDepartamento.Text) & "'"
                    If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                    End If
                End If
            End If

            frmVisor.WindowState = FormWindowState.Maximized

            If Me.NomRep <> EnumReportes.ComportamientoDeMora Then
                frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
            End If

            frmVisor.Formulas("Parametros") = "'Fechas: " & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & " al " & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "; Departamento: (" & Trim(cboDepartamento.Text) & "); Municipio: (" & Trim(cboMunicipio.Text) & ")" & "; Monto Aprobado C$: " & cboMontoAprobado.Text & "'"
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            Select Case mNomRep
                Case EnumReportes.ComportamientoDeMora
                    Filtro = String.Empty
                    If cboDepartamento.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nStbDepartamentoID") = Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    Else
                        frmVisor.Parametros("@nStbDepartamentoID") = 0
                    End If

                    If cboDepartamento.SelectedIndex > 0 Then
                        If cboMunicipio.SelectedIndex > 0 Then
                            frmVisor.Parametros("@nStbMunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            Filtro = " {spSccComportamientoDeMora;1.nStbMunicipioID} = " & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            frmVisor.Parametros("@nStbMunicipioID") = 0
                        End If

                    Else
                        frmVisor.Parametros("@nStbMunicipioID") = 0
                    End If

                    If Me.RdMayor0.Checked Then
                        Filtro = IIf(String.IsNullOrEmpty(Filtro), "", " And ") & " {spSccComportamientoDeMora;1.MontoEnMora} > 0 "
                    Else
                        Filtro = IIf(String.IsNullOrEmpty(Filtro), "", " And ") & " {spSccComportamientoDeMora;1.MontoEnMora} = 0 "
                    End If

                    'Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value

                    frmVisor.NombreReporte = "RepSccCC85.rpt"
                    frmVisor.Text = "Reporte De Comportamiento de la Mora"
                    frmVisor.Parametros("@FechaInicio") = Format(New Date(2007, 1, 1), "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(RdTodos.Checked And CboFuentes.SelectedIndex = 0, 2, IIf(RdPresupuesto.Checked, 1, IIf(CboFuentes.SelectedIndex > 0, -1, 0)))
                    frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)
                    If Me.CboFuentes.SelectedIndex > 0 Then
                        frmVisor.Parametros("@nScnFuenteFinanciamientoID") = Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                    Else
                        frmVisor.Parametros("@nScnFuenteFinanciamientoID") = 0
                    End If

                    frmVisor.Parametros("@Vigente") = IIf(Me.RdAmbas.Checked, -1, IIf(Me.RdVigente.Checked, 1, 0))
                    frmVisor.Parametros("@nCooperativa") = IIf(Me.rdoCooperativa.Checked, 1, IIf(Me.RdMercado.Checked, 1, -1))
                    frmVisor.Parametros("@nStbMercadoVerificadoID") = IIf(Me.RdDistrito.Checked, 1, 0)
                    If CboFuentes.Enabled = False Then
                        frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & "'"
                    Else
                        If CboFuentes.SelectedIndex > 0 Then
                            frmVisor.Formulas("DesFondo") = "'" & CboFuentes.Columns("sNombre").Value.ToString() & "'"
                        Else
                            frmVisor.Formulas("DesFondo") = "'CON TODAS LAS FUENTES DE FINANCIAMIENTO'"
                        End If
                    End If

                    Dim descCredito As String = String.Empty

                    If Me.RdActas.Checked Then
                        descCredito = IIf(Me.RdAmbas.Checked, " CON TODOS LOS ", "") & "CREDITOS " & IIf(Me.RdVigente.Checked, "VIGENTES ", IIf(Me.RdVencida.Checked, "VENCIDOS ", "")) & " POR ACTAS"
                    ElseIf Me.RdDistrito.Checked Then
                        descCredito = IIf(Me.RdAmbas.Checked, " CON TODOS LOS ", "") & "CREDITOS " & IIf(Me.RdVigente.Checked, "VIGENTES ", IIf(Me.RdVencida.Checked, "VENCIDOS ", "")) & " POR DISTRITOS"
                    ElseIf Me.rdoCooperativa.Checked Then
                        descCredito = IIf(Me.RdAmbas.Checked, " CON TODOS LOS ", "") & "CREDITOS " & IIf(Me.RdVigente.Checked, "VIGENTES ", IIf(Me.RdVencida.Checked, "VENCIDOS ", "")) & " POR COOPERATIVAS"
                    Else
                        descCredito = IIf(Me.RdAmbas.Checked, " CON TODOS LOS ", "") & "CREDITOS " & IIf(Me.RdVigente.Checked, "MERCADOS ", IIf(Me.RdVencida.Checked, "VENCIDOS ", "")) & " POR ACTAS "
                    End If

                    descCredito = descCredito + " E INDICE DE MORA " & IIf(RdMayor0.Checked, "MAYOR QUE 0", "IGUAL A 0")

                    frmVisor.Formulas("DesCredito") = "'" & descCredito & "'"

                Case EnumReportes.EstadisticaDesembolso
                    Filtro = ""
                    If cboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteEstadisticaPorPeriodoPorFuenteR1.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteEstadisticaPorPeriodoPorFuenteR1.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteEstadisticaPorPeriodoPorFuenteR1.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.NombreReporte = "RepSccCC46.rpt"
                    frmVisor.Text = "Reporte Estadístico de la recuperación de cartera "
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(RdPresupuesto.Checked, 1, 0)

                Case EnumReportes.EstadisticaRecuperacion
                    Filtro = ""
                    If cboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteEstadisticaPorPeriodoPorFuenteR2.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteEstadisticaPorPeriodoPorFuenteR2.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteEstadisticaPorPeriodoPorFuenteR2.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC47.rpt"
                    frmVisor.Text = "Reporte Estadístico de la recuperación de cartera "
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(RdPresupuesto.Checked, 1, 0)

                Case EnumReportes.Estadistico
                    Filtro = ""
                    If cboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {spSccReporteEstadisticaPorPeriodo.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteEstadisticaPorPeriodo.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteEstadisticaPorPeriodo.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC26.rpt"
                    frmVisor.Text = "Reporte Estadístico de la Cartera "
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                Case EnumReportes.Detalle
                    frmVisor.Formulas("TipoReporte") = IIf(Me.RdDistrito.Checked = True, 1, IIf(Me.RdMercado.Checked = True, 2, 3))
                    frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                    CadSql = ""

                    If RdAprobado.Checked = True Then

                        CadSql = "SELECT     vwUbicacion.Departamento, vwUbicacion.Municipio, FNC.nSclFichaNotificacionID, FI.nMontoCreditoVerificado AS MontoSolicitado, " & _
                                 " DFNC.nMontoCreditoAprobado, GS.nSclGrupoSolidarioID, Socia.nSclSociaID, GS.nStbMercadoVerificadoID, FNC.dFechaNotificacion, " & _
                                 " FNC.sNumSesion AS SesionDes, SclGrupoSocia_1.nCoordinador, GS.sDescripcion,  " & _
                                 "  Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia, vwUbicacion.Barrio, " & _
                                 "  vwUbicacion.nStbDepartamentoID, vwUbicacion.nStbMunicipioID, vwUbicacion.nStbBarrioID, vwUbicacion.nStbDistritoID, vwUbicacion.CodDistrito, " & _
                                 " vwUbicacion.Distrito, " & _
IIf(Me.RdMercado.Checked = True, " Mercado.nStbMercadoID AS IdAgrupacion, Mercado.sCodigo AS CodAgrupacion, Mercado.sNombre AS NomAgrupacion,  ", " vwUbicacion.nStbDistritoID As IdAgrupacion , vwUbicacion.CodDistrito As CodAgrupacion ,  vwUbicacion.Distrito As NomAgrupacion, ") & _
                                 "  Mercado.nActivo, Mercado.sNombre, GS.sCodigo, EstadoFNC.sCodigoInterno, " & _
                                 " DFNC.nCreditoRechazado " & _
                                 " FROM         dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                                 " dbo.SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " & _
                                 "  (SELECT     dbo.SclGrupoSolidario.nSclGrupoSolidarioID, dbo.SclGrupoSolidario.nStbBarrioVerificadoID,  " & _
                                 " dbo.SclGrupoSolidario.nStbMercadoVerificadoID, dbo.SclGrupoSolidario.sCodigo, dbo.SclGrupoSolidario.sDescripcion" & _
                                 "   FROM          dbo.SclFichaSocia INNER JOIN " & _
                                 "                      dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                 "                      dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                                 "                      dbo.SclGrupoSolidario ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID " & _
                                " WHERE      (dbo.SclGrupoSocia.nCreditoRechazado = 0) AND (dbo.StbValorCatalogo.sCodigoInterno = '5') " & _
                                " GROUP BY dbo.SclGrupoSolidario.nSclGrupoSolidarioID, dbo.SclGrupoSolidario.nStbBarrioVerificadoID,  " & _
                                "                       dbo.SclGrupoSolidario.nStbMercadoVerificadoID, dbo.SclGrupoSolidario.sCodigo, dbo.SclGrupoSolidario.sDescripcion) " & _
                                " AS GS ON " & _
                          " FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                          " dbo.SclFichaSocia AS FI ON DFNC.nSclFichaSociaID = FI.nSclFichaSociaID INNER JOIN " & _
                          " dbo.SclGrupoSocia AS SclGrupoSocia_1 ON GS.nSclGrupoSolidarioID = SclGrupoSocia_1.nSclGrupoSolidarioID AND  " & _
                          " FI.nSclGrupoSociaID = SclGrupoSocia_1.nSclGrupoSociaID INNER JOIN " & _
                          " dbo.SclSocia AS Socia ON SclGrupoSocia_1.nSclSociaID = Socia.nSclSociaID INNER JOIN " & _
                          " dbo.vwStbUbicacionGeografica AS vwUbicacion ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID INNER JOIN " & _
                          " dbo.StbMercado AS Mercado ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID INNER JOIN " & _
                          " dbo.StbValorCatalogo AS EstadoFNC ON FNC.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID " & _
                          "INNER JOIN dbo.vwSccListadoEstadoFichaNotificacionCredito ON  FNC.nSclFichaNotificacionID = dbo.vwSccListadoEstadoFichaNotificacionCredito.nSclFichaNotificacionID " & _
                          "INNER JOIN dbo.vwSccDetalleCreditosProgramaFichaNotificacion ON DFNC.nSclFichaNotificacionDetalleID = dbo.vwSccDetalleCreditosProgramaFichaNotificacion.nSclFichaNotificacionDetalleID "

                    Else
                        CadSql = "SELECT     vwUbicacion.Departamento, vwUbicacion.Municipio, FNC.nSclFichaNotificacionID, FI.nMontoCreditoVerificado AS MontoSolicitado, " & _
                                     " DFNC.nMontoCreditoAprobado, GS.nSclGrupoSolidarioID, Socia.nSclSociaID, GS.nStbMercadoVerificadoID, FNC.dFechaNotificacion, " & _
                                     " FNC.sNumSesion AS SesionDes, SclGrupoSocia_1.nCoordinador, GS.sDescripcion,  " & _
                                     "  Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia, vwUbicacion.Barrio, " & _
                                     "  vwUbicacion.nStbDepartamentoID, vwUbicacion.nStbMunicipioID, vwUbicacion.nStbBarrioID, vwUbicacion.nStbDistritoID, vwUbicacion.CodDistrito, " & _
                                     " vwUbicacion.Distrito,  " & _
                                     IIf(Me.RdMercado.Checked = True, " Mercado.nStbMercadoID AS IdAgrupacion, Mercado.sCodigo AS CodAgrupacion, Mercado.sNombre AS NomAgrupacion,  ", " vwUbicacion.nStbDistritoID As IdAgrupacion , vwUbicacion.CodDistrito As CodAgrupacion ,  vwUbicacion.Distrito As NomAgrupacion, ") & _
                                     "  Mercado.nActivo, Mercado.sNombre, GS.sCodigo, EstadoFNC.sCodigoInterno, " & _
                                     " DFNC.nCreditoRechazado " & _
                                     " FROM         dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                                     " dbo.SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " & _
                                    "                       dbo.SclGrupoSolidario AS GS ON " & _
                              " FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                              " dbo.SclFichaSocia AS FI ON DFNC.nSclFichaSociaID = FI.nSclFichaSociaID INNER JOIN " & _
                              " dbo.SclGrupoSocia AS SclGrupoSocia_1 ON GS.nSclGrupoSolidarioID = SclGrupoSocia_1.nSclGrupoSolidarioID AND  " & _
                              " FI.nSclGrupoSociaID = SclGrupoSocia_1.nSclGrupoSociaID INNER JOIN " & _
                              " dbo.SclSocia AS Socia ON SclGrupoSocia_1.nSclSociaID = Socia.nSclSociaID INNER JOIN " & _
                              " dbo.vwStbUbicacionGeografica AS vwUbicacion ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID INNER JOIN " & _
                              " dbo.StbMercado AS Mercado ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID INNER JOIN " & _
                              " dbo.StbValorCatalogo AS EstadoFNC ON FNC.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID " & _
                              "INNER JOIN dbo.vwSccDetalleCreditosProgramaFichaNotificacion ON DFNC.nSclFichaNotificacionDetalleID = dbo.vwSccDetalleCreditosProgramaFichaNotificacion.nSclFichaNotificacionDetalleID "

                    End If

                    frmVisor.Formulas("RangoFecha") = "' " & IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & " DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    frmVisor.NombreReporte = "RepSclCS20.rpt"

                    Select Case TipoReporte

                        Case 1
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS VIGENTES POR DISTRITO'"
                            frmVisor.Text = "Reporte de Créditos Aprobados Por Distrito"
                            frmVisor.SQLQuery = CadSql & " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And   (SclGrupoSocia_1.nCoordinador = 1) AND (DFNC.nCreditoRechazado = 0) AND (EstadoFNC.sCodigoInterno = '2')  And nStbMercadoVerificadoID = 1 And (dbo.vwSccListadoEstadoFichaNotificacionCredito.FichaActiva = 1) " & Trim(Filtro)

                        Case 2
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS DENEGADOS POR DISTRITO'"
                            frmVisor.Text = "Reporte de Créditos Denegados por Distrito"
                            frmVisor.SQLQuery = CadSql & " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And SclGrupoSocia_1.nCoordinador =1 And (DFNC.nCreditoRechazado = 1) AND (EstadoFNC.sCodigoInterno = '2' OR EstadoFNC.sCodigoInterno = '3')   And (nStbMercadoVerificadoID = 1)  " & Trim(Filtro)

                        Case 3
                            frmVisor.Formulas("Etiqueta") = String.Format("'CREDITOS VIGENTES POR {0}'", IIf(Me.rdoCooperativa.Checked, "COOPERATIVA", "MERCADO"))
                            frmVisor.Text = "Reporte de Créditos Aprobados por " & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado")
                            frmVisor.SQLQuery = CadSql & " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And (SclGrupoSocia_1.nCoordinador = 1) AND (DFNC.nCreditoRechazado = 0) AND (EstadoFNC.sCodigoInterno = '2')  And nStbMercadoVerificadoID <> 1 And (dbo.vwSccListadoEstadoFichaNotificacionCredito.FichaActiva = 1) And ( nCooperativa = " & IIf(Me.rdoCooperativa.Checked, 1, 0) & " ) " & Trim(Filtro)

                        Case 4
                            frmVisor.Formulas("Etiqueta") = String.Format("'CREDITOS DENEGADOS POR {0}'", IIf(Me.rdoCooperativa.Checked, "COOPERATIVA", "MERCADO"))
                            frmVisor.Text = "Reporte de Créditos Aprobados por " & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado")
                            frmVisor.SQLQuery = CadSql & _
                           " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And SclGrupoSocia_1.nCoordinador=1 And  (DFNC.nCreditoRechazado = 1) AND (EstadoFNC.sCodigoInterno = '2' OR EstadoFNC.sCodigoInterno = '3')   And (nStbMercadoVerificadoID <> 1) AND (nCooperativa = " & IIf(Me.rdoCooperativa.Checked, 1, 0) & " ) " & Trim(Filtro)

                        Case 5
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS VIGENTES POR ACTAS'"
                            frmVisor.Text = "Reporte de Créditos Aprobados por Acta"
                            frmVisor.SQLQuery = CadSql & Trim(Filtro) & " And vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'  And (SclGrupoSocia_1.nCoordinador = 1) AND (DFNC.nCreditoRechazado = 0) AND (EstadoFNC.sCodigoInterno = '2') And (dbo.vwSccListadoEstadoFichaNotificacionCredito.FichaActiva = 1)   "

                        Case 6
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS DENEGADOS POR ACTAS'"
                            frmVisor.Text = "Reporte de Créditos Denegados por Acta"
                            frmVisor.SQLQuery = CadSql & Trim(Filtro) & " And vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'  And (SclGrupoSocia_1.nCoordinador = 1) And  (DFNC.nCreditoRechazado = 1) AND (EstadoFNC.sCodigoInterno = '2' OR EstadoFNC.sCodigoInterno = '3')     "

                    End Select

                Case EnumReportes.NivelAcademico

                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", "CON FONDOS EXTERNOS")) & "'"
                    frmVisor.NombreReporte = "RepSclCS21.rpt"
                    frmVisor.Formulas("RangoFecha") = "'DEL" & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & "'"

                    Filtro2 = " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "

                    Dim SqlQuery As New StringBuilder()
                    SqlQuery.Append("( ")
                    SqlQuery.Append("SELECT FI.dFechaInscripcion AS dFechaNotificacion,")
                    SqlQuery.Append("       vwUbicacion.nStbDepartamentoID,")
                    SqlQuery.Append("       vwUbicacion.Departamento,")
                    SqlQuery.Append("       vwUbicacion.nStbMunicipioID,")
                    SqlQuery.Append("       vwUbicacion.Municipio,")
                    SqlQuery.Append("       vwUbicacion.nStbDistritoID,")
                    SqlQuery.Append("       vwUbicacion.CodDistrito,")
                    SqlQuery.Append("       vwUbicacion.Distrito,")
                    SqlQuery.Append("       vwUbicacion.nStbBarrioID,")
                    SqlQuery.Append("       vwUbicacion.Barrio,")
                    SqlQuery.Append("       GS.nStbMercadoVerificadoID,")
                    SqlQuery.Append("       Mercado.sCodigo AS CodigoMercado,")
                    SqlQuery.Append("       Mercado.sNombre AS NombreMercado,")
                    SqlQuery.Append("       FI.nMontoCreditoVerificado AS MontoSolicitado,")
                    SqlQuery.Append("       GS.nSclGrupoSolidarioID,")
                    SqlQuery.Append("       Socia.nSclSociaID,")
                    SqlQuery.Append("       dbo.SclGrupoSocia.nCoordinador,")
                    SqlQuery.Append("       GS.sCodigo,")
                    SqlQuery.Append("       GS.sDescripcion,")
                    SqlQuery.Append("       Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia,")
                    SqlQuery.Append("       FI.nAlfabetizadaVerificada,")
                    SqlQuery.Append("       Primaria.nStbValorCatalogoID AS IDPrimaria,")
                    SqlQuery.Append("       Secundaria.sCodigoInterno AS CodigoPrimaria,")
                    SqlQuery.Append("       Primaria.sDescripcion AS NivelPrimaria,")
                    SqlQuery.Append("       Secundaria.nStbValorCatalogoID AS IDSecundaria,")
                    SqlQuery.Append("       Secundaria.sCodigoInterno AS CodigoSecundaria,")
                    SqlQuery.Append("       Secundaria.sDescripcion AS NivelSecundaria,")
                    SqlQuery.Append("       Tecnico.nStbValorCatalogoID AS IDTecnico,")
                    SqlQuery.Append("       Tecnico.sCodigoInterno AS CodigoTecnico,")
                    SqlQuery.Append("       Tecnico.sDescripcion AS NivelTecnico,")
                    SqlQuery.Append("       CASE WHEN Primaria.sCodigoInterno <> '1' AND Secundaria.sCodigoInterno = '1' AND Tecnico.sCodigoInterno = '1' THEN 1 ELSE 0 END AS SoloPrimaria,")
                    SqlQuery.Append("       CASE WHEN Secundaria.sCodigoInterno <> '1' AND   Tecnico.sCodigoInterno = '1' THEN 1 ELSE 0 END AS SoloSecundaria,")
                    SqlQuery.Append("       CASE WHEN Tecnico.sCodigoInterno <> '1' THEN 1 ELSE 0 END AS SoloTecnico,")
                    SqlQuery.Append("       CASE WHEN Primaria.sCodigoInterno = '1' AND Secundaria.sCodigoInterno = '1' AND Tecnico.sCodigoInterno = '1' AND   FI.nAlfabetizadaVerificada = 1 THEN 1 ELSE 0 END AS SoloAlfabetizada,")
                    SqlQuery.Append("       CASE WHEN Primaria.sCodigoInterno = '1' AND Secundaria.sCodigoInterno = '1' AND Tecnico.sCodigoInterno = '1' AND FI.nAlfabetizadaVerificada = 0 THEN 1 ELSE 0 END AS NoAlfabetizada,")
                    SqlQuery.Append("       dbo.StbValorCatalogo.sCodigoInterno AS EstadoFicha,")
                    SqlQuery.Append("       dbo.StbValorCatalogo.sDescripcion AS DescripcionEstadoFicha,")
                    SqlQuery.Append("       dbo.ScnFuenteFinanciamiento.nFondoPresupuestario ")
                    SqlQuery.Append("FROM   dbo.SclGrupoSocia ")
                    SqlQuery.Append("       INNER JOIN dbo.SclGrupoSolidario AS GS ")
                    SqlQuery.Append("       ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID ")
                    SqlQuery.Append("       INNER JOIN dbo.SclFichaSocia AS FI ")
                    SqlQuery.Append("       ON dbo.SclGrupoSocia.nSclGrupoSociaID = FI.nSclGrupoSociaID ")
                    SqlQuery.Append("       INNER JOIN  dbo.SclSocia AS Socia ")
                    SqlQuery.Append("       ON dbo.SclGrupoSocia.nSclSociaID = Socia.nSclSociaID ")
                    SqlQuery.Append("       INNER JOIN  dbo.vwStbUbicacionGeografica AS vwUbicacion ")
                    SqlQuery.Append("       ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID ")
                    SqlQuery.Append("       INNER JOIN  dbo.StbMercado AS Mercado ")
                    SqlQuery.Append("       ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID ")
                    SqlQuery.Append("       INNER JOIN  dbo.StbValorCatalogo AS Primaria ")
                    SqlQuery.Append("       ON FI.nStbPrimariaVerificadaID = Primaria.nStbValorCatalogoID ")
                    SqlQuery.Append("       INNER JOIN  dbo.StbValorCatalogo AS Secundaria ")
                    SqlQuery.Append("       ON FI.nStbSecundariaVerificadaID = Secundaria.nStbValorCatalogoID ")
                    SqlQuery.Append("       INNER JOIN  dbo.StbValorCatalogo AS Tecnico ")
                    SqlQuery.Append("       ON FI.nStbCarreraTecnicaVerificadaID = Tecnico.nStbValorCatalogoID ")
                    SqlQuery.Append("       INNER JOIN dbo.StbValorCatalogo ON FI.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID ")
                    SqlQuery.Append("       INNER JOIN (SELECT  ")
                    SqlQuery.Append("                          NFichaSociaId,")
                    SqlQuery.Append("                          nSclFichaNotificacionDetalleID")
                    SqlQuery.Append("                   FROM   (")
                    SqlQuery.Append("                           SELECT    dbo.SclSocia.nSclSociaID,")
                    SqlQuery.Append("                                     MAX(dbo.SclFichaSocia.nSclFichaSociaID) AS NFichaSociaId,")
                    SqlQuery.Append("                                     MAX(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS nSclFichaNotificacionDetalleID")
                    SqlQuery.Append("                           FROM      dbo.SclFichaSocia INNER JOIN")
                    SqlQuery.Append("                                     dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN")
                    SqlQuery.Append("                                     dbo.SclGrupoSolidario ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID INNER JOIN")
                    SqlQuery.Append("                                     dbo.SclTipodePlandeNegocio")
                    SqlQuery.Append("                                     ON dbo.SclGrupoSolidario.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID  INNER JOIN")
                    SqlQuery.Append("                                     dbo.StbValorCatalogo AS StbValorCatalogo_1")
                    SqlQuery.Append("                                     ON StbValorCatalogo_1.nStbValorCatalogoID = dbo.SclTipodePlandeNegocio.nStbTipoProgramaID INNER JOIN")
                    SqlQuery.Append("                                     dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN")
                    SqlQuery.Append("                                     dbo.SclFichaNotificacionDetalle")
                    SqlQuery.Append("                                     ON dbo.SclFichaSocia.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN")
                    SqlQuery.Append("                                     dbo.SclFichaNotificacionCredito ON ")
                    SqlQuery.Append("                                     dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN ")
                    SqlQuery.Append("                                     dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID ")
                    SqlQuery.Append("                           WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '2')  ")
                    SqlQuery.Append("                                     AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)  ")
                    SqlQuery.Append("                                     AND StbValorCatalogo_1.sCodigoInterno = '1'  ")
                    SqlQuery.AppendFormat("                                     {0}", Trim(Filtro2))
                    SqlQuery.Append("                           GROUP BY dbo.SclSocia.nSclSociaID  ")
                    SqlQuery.Append("                           ) AS A ")
                    SqlQuery.Append("                   ) AS Credito ")
                    SqlQuery.Append("      ON FI.nSclFichaSociaID = Credito.NFichaSociaId ")
                    SqlQuery.Append("      INNER JOIN  dbo.SccSolicitudDesembolsoCredito ")
                    SqlQuery.Append("      ON  Credito.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID ")
                    SqlQuery.Append("      INNER JOIN  dbo.ScnFuenteFinanciamiento ")
                    SqlQuery.Append("      ON   dbo.SccSolicitudDesembolsoCredito.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID ")
                    SqlQuery.AppendFormat(" {0}", IIf(TipoReporte = 1, " WHERE (nStbMercadoVerificadoID = 1) ", IIf(TipoReporte = 3, " Where (nStbMercadoVerificadoID <> 1)  ", IIf(TipoReporte = 5, " Where nStbMercadoVerificadoID<>-1 ", ""))) & " ) As Vista")

                    CadSql2 = SqlQuery.ToString

                    Filtro = ""

                    If cboDepartamento.SelectedIndex <> -1 And cboDepartamento.Text <> "Todos" Then
                        Filtro = Filtro & "Where Departamento='" & Trim(cboDepartamento.Text) & "'"
                        If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                        End If
                    End If

                    If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                        Else
                            Filtro = " Where  nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                        End If
                    End If

                    Select Case TipoReporte

                        Case 1
                            frmVisor.Formulas("TipoReporte") = 2
                            frmVisor.Text = "Reporte de Totales de Socias en los Distritos"
                            frmVisor.SQLQuery = " SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodDistrito AS CodGrupo, Distrito AS Grupo, SUM(SoloPrimaria) AS TotalPrimaria, " & _
                                                                            " SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, SUM(NoAlfabetizada) AS TotalNoAlfabetizada, " & _
                                                                            " SUM(1) AS TotalSocias FROM    " & CadSql2 & " " & _
                                                                            Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, nStbDistritoID, CodDistrito, Distrito"

                        Case 3
                            frmVisor.Formulas("TipoReporte") = 3
                            frmVisor.Text = String.Format("Reporte de Totales de Socias en {0}", IIf(Me.rdoCooperativa.Checked, "las Cooperativas", "los Mercados"))
                            frmVisor.SQLQuery = "SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodigoMercado AS CodGrupo, NombreMercado AS Grupo, " & _
                                                " SUM(SoloPrimaria) AS TotalPrimaria, SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, " & _
                                                " SUM(NoAlfabetizada) AS TotalNoAlfabetizada,Sum(1) AS TotalSocias FROM  " & CadSql2 & " " & _
                                                " " & Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodigoMercado, NombreMercado "

                        Case 5
                            frmVisor.Formulas("TipoReporte") = 1
                            frmVisor.Text = "Reporte de Totales de Socias en los Distritos y Mercados"
                            frmVisor.SQLQuery = " SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodDistrito AS CodGrupo, Distrito AS Grupo, SUM(SoloPrimaria) AS TotalPrimaria, " & _
                                                                            " SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, SUM(NoAlfabetizada) AS TotalNoAlfabetizada, " & _
                                                                            " SUM(1) AS TotalSocias FROM  " & CadSql2 & " " & _
                                                                            " " & Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, nStbDistritoID, CodDistrito, Distrito"
                    End Select
                Case EnumReportes.NuncaPagado
                    frmVisor.Formulas("Parametros") = "'Departamento(" & Trim(cboDepartamento.Text) & ") Municipio( " & Trim(cboMunicipio.Text) & ")"  '& "'"        ' "  '"  ' Al :" & CdeFechaFinal.Value
                    Filtro = ""

                    If Me.RdPresupuesto.Checked Then
                        Filtro = ""
                        Filtro = " {spSccReporteNuncaPagado.Fondo} =1"
                    Else
                        If Me.RdExterno.Checked Then
                            Filtro = " {spSccReporteNuncaPagado.Fondo} =0"
                        Else
                            If Me.RdSinFuente.Checked Then
                                Filtro = " {spSccReporteNuncaPagado.Fondo} =-1"
                            End If
                        End If
                    End If

                    frmVisor.Formulas("Parametros") = frmVisor.Formulas("Parametros") & "Fondos(" & IIf(Me.RdTodos.Checked = True, "Todos", IIf(Me.RdPresupuesto.Checked, "Presupuesto", IIf(Me.RdExterno.Checked = True, "Externos", IIf(Me.RdSinFuente.Checked, "No asignados", "")))) & ")'"
                    frmVisor.Formulas("DesFondo") = "'" & IIf(RdTodos.Checked, "CON TODAS LAS FUENTES DE FINANCIAMIENTO", IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", "SIN FUENTE DEFINIDA"))) & "'"

                    If cboDepartamento.SelectedIndex > 0 Then
                        If Trim(Filtro) = "" Then
                            Filtro = "  {spSccReporteNuncaPagado.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        Else
                            Filtro = Filtro & " And  {spSccReporteNuncaPagado.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        End If
                    End If

                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteNuncaPagado.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " {spSccReporteNuncaPagado.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If

                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC43.rpt"
                    frmVisor.Text = "Reporte de grupos de al menos una socia que nunca ha pagado"
                    frmVisor.Parametros("@FechaCorte") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)
                    Me.Cursor = Cursors.Default

                Case Else
                    If TipoReporte = 1 Or TipoReporte = 3 Or TipoReporte = 5 Then
                        Filtro = VecesCredito(Filtro)
                        Select Case Me.CboVeces.SelectedIndex
                            Case 0
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con todos sus Créditos '"
                            Case 1
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con un solo Crédito'"
                            Case 2
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Dos Créditos'"
                            Case 3
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Tres Créditos'"
                            Case 4
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Cuatro Créditos'"
                            Case 5
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Cinco Créditos'"
                            Case 6
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Seis Créditos'"
                            Case 7
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Siete Créditos'"
                            Case 8
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Ocho Créditos'"
                            Case 9
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Nueve Créditos'"
                            Case 10
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Diez Créditos'"
                            Case 11
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Once o más Créditos'"
                        End Select
                    End If

                    SubCadFiltro = ""
                    If radFondos.Checked = True Then
                        If Me.RdPresupuesto.Checked Then
                            SubCadFiltro = " Where Fondo=1"
                        Else
                            If Me.RdExterno.Checked Then
                                SubCadFiltro = "Where Fondo=0"
                            Else
                                If Me.RdSinFuente.Checked Then
                                    SubCadFiltro = " Where Fondo=-1"
                                End If
                            End If
                        End If
                    Else
                        If Me.CboFuentes.SelectedIndex > 0 Then
                            If mNomRep = EnumReportes.ResumenCreditos Then
                                SubCadFiltro = " WHERE nScnFuenteFinanciamientoID=" & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                            Else
                                SubCadFiltro = " Where nScnFuenteFinanciamientoID=" & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                            End If
                        End If
                    End If

                    If TipoReporte = 1 Or TipoReporte = 3 Or TipoReporte = 5 Then
                        If Trim(Filtro) = "" Then
                            Filtro = " Where vwGs.TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                        Else
                            Filtro = Filtro & "And vwGs.TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                        End If
                        frmVisor.Formulas("TipoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)
                    End If

                    If TipoReporte = 2 Or TipoReporte = 4 Or TipoReporte = 6 Then
                        If Trim(Filtro) = "" Then
                            'Filtro = " And TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                            If Me.RdPDIBA.Checked = True Then
                                Filtro = " And TipoPrograma= 3"
                            ElseIf Me.RdVentanadeGenero.Checked = True Then
                                Filtro = " And TipoPrograma= 2"
                            Else ' Me.RdUsuraCero.Checked = True Then
                                Filtro = " And TipoPrograma= 1"
                            End If
                        Else
                            'Filtro = Filtro & " And TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                            If Me.RdPDIBA.Checked = True Then
                                Filtro = Filtro & " And TipoPrograma= 3"
                            ElseIf Me.RdVentanadeGenero.Checked = True Then
                                Filtro = Filtro & " And TipoPrograma= 2"
                            Else ' Me.RdUsuraCero.Checked = True Then
                                Filtro = Filtro & " And TipoPrograma= 1"
                            End If
                        End If
                        'frmVisor.Formulas("TipoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)
                        If Me.RdPDIBA.Checked = True Then
                            frmVisor.Formulas("TipoPrograma") = "3"
                        ElseIf Me.RdVentanadeGenero.Checked = True Then
                            frmVisor.Formulas("TipoPrograma") = "2"
                        Else ' Me.RdUsuraCero.Checked = True Then
                            frmVisor.Formulas("TipoPrograma") = "1"
                        End If
                    End If

                    Dim monto As Integer

                    Select Case TipoReporte
                        Case 1

                            'frmVisor.NombreReporte = "RepSccCC2.rpt"
                            'frmVisor.Text = "Reporte de Créditos Vigentes  Por Distrito"
                            ''frmVisor.SQLQuery = "spSccRptCC2 '" & SubCadFiltro & "','" & Trim(Filtro) & "'"
                            'frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)

                            frmVisor.NombreReporte = "RepSccCC2.rpt"
                            frmVisor.Text = "Reporte de Créditos Vigentes  Por Distrito"
                            frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)
                            frmVisor.Parametros("@FechaIni") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                            frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                            If cboDepartamento.SelectedIndex > -1 And cboDepartamento.Text = "Todos" Then
                                frmVisor.Parametros("@DepartamentoID") = -1
                            Else
                                frmVisor.Parametros("@DepartamentoID") = Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                            End If

                            If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text = "Todos" Then
                                frmVisor.Parametros("@MunicipioID") = -1
                            Else
                                frmVisor.Parametros("@MunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            End If

                            If cboMontoAprobado.Text <> "(Todos)" Then
                                monto = cboMontoAprobado.Text
                            Else
                                monto = 0
                            End If
                            frmVisor.Parametros("@nMontoCreditoAprobado") = monto

                            frmVisor.WindowState = FormWindowState.Maximized
                            frmVisor.Parametros("@TipoVecesCreditos") = CboVeces.SelectedIndex

                            If radFondos.Checked = True Then
                                If Me.RdPresupuesto.Checked Then
                                    frmVisor.Parametros("@Fondo") = 1
                                Else
                                    If Me.RdExterno.Checked Then
                                        frmVisor.Parametros("@Fondo") = 0
                                    Else
                                        If Me.RdSinFuente.Checked Then
                                            frmVisor.Parametros("@Fondo") = -1
                                        Else
                                            frmVisor.Parametros("@Fondo") = 2
                                        End If
                                    End If
                                End If
                                frmVisor.Parametros("@PorFondo") = 1
                                frmVisor.Parametros("@Fuente") = -1
                            Else
                                If Me.CboFuentes.SelectedIndex > 0 Then
                                    frmVisor.Parametros("@Fuente") = Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                                Else
                                    frmVisor.Parametros("@Fuente") = -1
                                End If
                                frmVisor.Parametros("@PorFondo") = 0
                                frmVisor.Parametros("@Fondo") = 2
                            End If

                            Dim TipoTurismo As String = ""
                            Dim sTipoTurismo As String = ""

                            TipoTurismo &= IIf(rdTurismoSR.Checked, "-1,", "")
                            TipoTurismo &= IIf(rdTurismoNVT.Checked, "1,", "")
                            TipoTurismo &= IIf(rdTurismoVT.Checked, "2,", "")
                            TipoTurismo &= IIf(rdTurismoT.Checked, "3,", "")

                            sTipoTurismo &= IIf(rdTurismoSR.Checked, "Sin Registrar, ", "")
                            sTipoTurismo &= IIf(rdTurismoNVT.Checked, "No Vinculados, ", "")
                            sTipoTurismo &= IIf(rdTurismoVT.Checked, "Vinculados, ", "")
                            sTipoTurismo &= IIf(rdTurismoT.Checked, "Turismo, ", "")

                            frmVisor.Formulas("Turismo") = "'{0}'".Replace("{0}", sTipoTurismo)

                            frmVisor.Parametros("@nTipoTurismo") = "{0}".Replace("{0}", TipoTurismo)


                            If Me.RdPDIBA.Checked = True Then
                                frmVisor.Parametros("@TipoPrograma") = "3"
                                frmVisor.Formulas("TipoPrograma") = "3"
                            ElseIf Me.RdVentanadeGenero.Checked = True Then
                                frmVisor.Parametros("@TipoPrograma") = "2"
                                frmVisor.Formulas("TipoPrograma") = "2"
                            Else
                                frmVisor.Parametros("@TipoPrograma") = "1"
                                frmVisor.Formulas("TipoPrograma") = "1"
                            End If
                            'frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)

                        Case 2

                            frmVisor.NombreReporte = "RepSccCC3.rpt"
                            frmVisor.Text = "Reporte de Créditos Denegados por Distrito"

                            If cboMontoAprobado.Text <> "(Todos)" Then
                                monto = cboMontoAprobado.Text
                                Filtro = Filtro & " AND nMontoCreditoAprobado = " & monto
                            Else
                                'Filtro = Filtro & " AND nMontoCreditoAprobado <> 1850 AND nMontoCreditoAprobado <> 3700 AND nMontoCreditoAprobado <> 4600 AND nMontoCreditoAprobado <> 5500 AND nMontoCreditoAprobado <> 10000"
                            End If

                            frmVisor.SQLQuery = "spSccRptCC3 '" & Trim(Filtro) & "'"

                        Case 3
                            'frmVisor.NombreReporte = "RepSccCC4.rpt"
                            frmVisor.Formulas("TipoAsociacion") = String.Format("'{0}'", IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado"))
                            'frmVisor.Text = String.Format("Reporte de Créditos Aprobados por {0}", IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado"))

                            ''frmVisor.SQLQuery = "spSccRptCC4 '" & IIf(Me.rdoCooperativa.Checked, 1, 0) & "','" & SubCadFiltro & "','" & Trim(Filtro) & "'"
                            'frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)

                            frmVisor.NombreReporte = "RepSccCC4.rpt"
                            frmVisor.Text = String.Format("Reporte de Créditos Aprobados por {0}", IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado"))
                            'frmVisor.SQLQuery = "RepSccCC4 '" & SubCadFiltro & "','" & Trim(Filtro) & "'"
                            frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)
                            frmVisor.Parametros("@FechaIni") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                            frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                            If cboDepartamento.SelectedIndex > -1 And cboDepartamento.Text = "Todos" Then
                                frmVisor.Parametros("@DepartamentoID") = -1
                            Else
                                frmVisor.Parametros("@DepartamentoID") = Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                            End If

                            If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text = "Todos" Then
                                frmVisor.Parametros("@MunicipioID") = -1
                            Else
                                frmVisor.Parametros("@MunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            End If

                            If cboMontoAprobado.Text <> "(Todos)" Then
                                monto = cboMontoAprobado.Text
                            Else
                                monto = 0
                            End If
                            frmVisor.Parametros("@nMontoCreditoAprobado") = monto

                            frmVisor.Parametros("@TipoVecesCreditos") = CboVeces.SelectedIndex

                            If radFondos.Checked = True Then
                                If Me.RdPresupuesto.Checked Then
                                    frmVisor.Parametros("@Fondo") = 1
                                Else
                                    If Me.RdExterno.Checked Then
                                        frmVisor.Parametros("@Fondo") = 0
                                    Else
                                        If Me.RdSinFuente.Checked Then
                                            frmVisor.Parametros("@Fondo") = -1
                                        Else
                                            frmVisor.Parametros("@Fondo") = 2
                                        End If
                                    End If
                                End If
                                frmVisor.Parametros("@PorFondo") = 1
                                frmVisor.Parametros("@Fuente") = -1
                            Else
                                If Me.CboFuentes.SelectedIndex > 0 Then
                                    frmVisor.Parametros("@Fuente") = Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                                Else
                                    frmVisor.Parametros("@Fuente") = -1
                                End If
                                frmVisor.Parametros("@PorFondo") = 0
                                frmVisor.Parametros("@Fondo") = 2
                            End If

                            frmVisor.Parametros("@cooperativa") = IIf(Me.rdoCooperativa.Checked, 1, 0)
                            'frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)

                            If Me.RdPDIBA.Checked = True Then
                                frmVisor.Formulas("TipoPrograma") = 3
                                frmVisor.Parametros("@TipoPrograma") = 3
                            ElseIf Me.RdVentanadeGenero.Checked = True Then
                                frmVisor.Formulas("TipoPrograma") = 2
                                frmVisor.Parametros("@TipoPrograma") = 2
                            Else ' Me.RdUsuraCero.Checked = True Then
                                frmVisor.Formulas("TipoPrograma") = 1
                                frmVisor.Parametros("@TipoPrograma") = 1
                            End If

                            Dim TipoTurismo As String = ""
                            Dim sTipoTurismo As String = ""

                            TipoTurismo &= IIf(rdTurismoSR.Checked, "-1,", "")
                            TipoTurismo &= IIf(rdTurismoNVT.Checked, "1,", "")
                            TipoTurismo &= IIf(rdTurismoVT.Checked, "2,", "")
                            TipoTurismo &= IIf(rdTurismoT.Checked, "3,", "")

                            sTipoTurismo &= IIf(rdTurismoSR.Checked, "Sin Registrar, ", "")
                            sTipoTurismo &= IIf(rdTurismoNVT.Checked, "No Vinculados, ", "")
                            sTipoTurismo &= IIf(rdTurismoVT.Checked, "Vinculados, ", "")
                            sTipoTurismo &= IIf(rdTurismoT.Checked, "Turismo, ", "")


                            frmVisor.Parametros("@nTipoTurismo") = "{0}".Replace("{0}", TipoTurismo)

                            frmVisor.Formulas("Turismo") = "'{0}'".Replace("{0}", sTipoTurismo)



                        Case 4
                            frmVisor.Parametros("@TipoAsociacion") = IIf(Me.rdoCooperativa.Checked, "'Cooperativa'", "'Mercado'")
                            frmVisor.NombreReporte = "RepSccCC5.rpt"
                            frmVisor.Text = "Reporte de Créditos Denegados por " & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado")

                            If Trim(Filtro) = "" Then
                                Filtro = " Where nCooperativa=" & IIf(Me.rdoCooperativa.Checked, 1, 0)
                            Else
                                Filtro = Filtro & " And nCooperativa=" & IIf(Me.rdoCooperativa.Checked, 1, 0)
                            End If

                            If cboMontoAprobado.Text <> "(Todos)" Then
                                monto = cboMontoAprobado.Text
                                Filtro = Filtro & " AND nMontoCreditoAprobado = " & monto
                            End If

                            frmVisor.SQLQuery = "spSccRptCC5 '" & Trim(Filtro) & "'"
                            frmVisor.Formulas("TipoAsociacion") = "'" & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado") & "'"

                        Case 5
                            frmVisor.NombreReporte = "RepSccCC6.rpt"
                            frmVisor.Text = "Reporte de Créditos Aprobados por Acta"
                            'frmVisor.SQLQuery = "spSccRptCC6 '" & SubCadFiltro & "','" & Trim(Filtro) & "'"
                            frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)
                            frmVisor.Parametros("@FechaIni") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                            frmVisor.Parametros("@FechaFin") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")

                            If cboDepartamento.SelectedIndex > -1 And cboDepartamento.Text = "Todos" Then
                                frmVisor.Parametros("@DepartamentoID") = -1
                            Else
                                frmVisor.Parametros("@DepartamentoID") = Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                            End If

                            If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text = "Todos" Then
                                frmVisor.Parametros("@MunicipioID") = -1
                            Else
                                frmVisor.Parametros("@MunicipioID") = Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            End If

                            If cboMontoAprobado.Text <> "(Todos)" Then
                                monto = cboMontoAprobado.Text
                            Else
                                monto = 0
                            End If
                            frmVisor.Parametros("@nMontoCreditoAprobado") = monto

                            frmVisor.Parametros("@TipoVecesCreditos") = CboVeces.SelectedIndex

                            If rdOcultarActas.Checked Then
                                frmVisor.Formulas("OcultarActas") = 1
                            Else
                                frmVisor.Formulas("OcultarActas") = 0
                            End If

                            If radFondos.Checked = True Then
                                If Me.RdPresupuesto.Checked Then
                                    frmVisor.Parametros("@Fondo") = 1
                                Else
                                    If Me.RdExterno.Checked Then
                                        frmVisor.Parametros("@Fondo") = 0
                                    Else
                                        If Me.RdSinFuente.Checked Then
                                            frmVisor.Parametros("@Fondo") = -1
                                        Else
                                            frmVisor.Parametros("@Fondo") = 2
                                        End If
                                    End If
                                End If
                                frmVisor.Parametros("@PorFondo") = 1
                                frmVisor.Parametros("@Fuente") = -1
                            Else
                                If Me.CboFuentes.SelectedIndex > 0 Then
                                    frmVisor.Parametros("@Fuente") = Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                                Else
                                    frmVisor.Parametros("@Fuente") = -1
                                End If
                                frmVisor.Parametros("@PorFondo") = 0
                                frmVisor.Parametros("@Fondo") = 2
                            End If



                            Dim TipoTurismo As String = ""
                            Dim sTipoTurismo As String = ""

                            TipoTurismo &= IIf(rdTurismoSR.Checked, "-1,", "")
                            TipoTurismo &= IIf(rdTurismoNVT.Checked, "1,", "")
                            TipoTurismo &= IIf(rdTurismoVT.Checked, "2,", "")
                            TipoTurismo &= IIf(rdTurismoT.Checked, "3,", "")

                            sTipoTurismo &= IIf(rdTurismoSR.Checked, "Sin Registrar, ", "")
                            sTipoTurismo &= IIf(rdTurismoNVT.Checked, "No Vinculados, ", "")
                            sTipoTurismo &= IIf(rdTurismoVT.Checked, "Vinculados, ", "")
                            sTipoTurismo &= IIf(rdTurismoT.Checked, "Turismo, ", "")



                            frmVisor.Parametros("@nTipoTurismo") = "{0}".Replace("{0}", TipoTurismo)

                            frmVisor.Formulas("Turismo") = "'{0}'".Replace("{0}", sTipoTurismo)



                            If Me.RdPDIBA.Checked = True Then
                                frmVisor.Parametros("@TipoPrograma") = 3
                                frmVisor.Formulas("TipoPrograma") = 3
                            ElseIf Me.RdVentanadeGenero.Checked = True Then
                                frmVisor.Parametros("@TipoPrograma") = 2
                                frmVisor.Formulas("TipoPrograma") = 2
                            Else ' Me.RdUsuraCero.Checked = True Then
                                frmVisor.Parametros("@TipoPrograma") = 1
                                frmVisor.Formulas("TipoPrograma") = 1
                            End If
                            'frmVisor.Parametros("@TipoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)

                        Case 6
                            frmVisor.NombreReporte = "RepSccCC7.rpt"
                            frmVisor.Text = "Reporte de Créditos Denegados por Acta"

                            If cboMontoAprobado.Text <> "(Todos)" Then
                                monto = cboMontoAprobado.Text
                                Filtro = Filtro & " AND nMontoCreditoAprobado = " & monto
                            Else
                                'Filtro = Filtro & " AND nMontoCreditoAprobado <> 1850 AND nMontoCreditoAprobado <> 3700 AND nMontoCreditoAprobado <> 4600 AND nMontoCreditoAprobado <> 5500 AND nMontoCreditoAprobado <> 10000"
                            End If

                            frmVisor.SQLQuery = "spSccRptCC7 '" & Trim(Filtro) & "'"

                            If Me.RdPDIBA.Checked = True Then
                                frmVisor.Parametros("@CodigoPrograma") = 3
                                frmVisor.Formulas("TipoPrograma") = 3
                            ElseIf Me.RdVentanadeGenero.Checked = True Then
                                frmVisor.Parametros("@CodigoPrograma") = 2
                                frmVisor.Formulas("TipoPrograma") = 2
                            Else ' Me.RdUsuraCero.Checked = True Then
                                frmVisor.Parametros("@CodigoPrograma") = 1
                                frmVisor.Formulas("TipoPrograma") = 1
                            End If
                            'frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)
                    End Select

                    If TipoReporte = 1 Or TipoReporte = 3 Or TipoReporte = 5 Then
                        frmVisor.Formulas("RangoFecha") = "' DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    Else
                        frmVisor.Formulas("RangoFecha") = "' TODAS LAS FUENTES DE FINANCIAMIENTO DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    End If

                    frmVisor.Formulas("Fuente") = "' " & IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"  '"  ' Al :" & CdeFechaFinal.Value

            End Select

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try

    End Sub

    Private Function TipoFondo(ByVal XFiltro As String) As String
        Dim SubCadFiltro As String = ""

        If Me.RdTodos.Checked Then
            Return XFiltro
        End If

        If Me.RdPresupuesto.Checked Then
            SubCadFiltro = " Fondo=1"
        Else
            If Me.RdExterno.Checked Then
                SubCadFiltro = " Fondo=0"
            Else
                If Me.RdSinFuente.Checked Then
                    SubCadFiltro = " Fondo=-1"
                End If
            End If
        End If

        If Trim(SubCadFiltro) <> "" Then
            If Trim(XFiltro) = "" Then
                XFiltro = "  Where " & SubCadFiltro
            Else
                XFiltro = XFiltro & "  And  " & SubCadFiltro
            End If
        End If
        Return XFiltro

    End Function

    Private Function VecesCredito(ByVal XFiltro As String) As String
        Dim SubCadFiltro As String = ""
        Select Case CboVeces.SelectedIndex
            Case 0
                SubCadFiltro = ""
            Case 1, 2, 3, 4, 5, 6, 7, 8, 9, 10
                SubCadFiltro = "TotalCreditos=" & CboVeces.SelectedIndex & " "
            Case 11
                SubCadFiltro = "TotalCreditos>=11 "
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

    Private Sub CargarVeces()

        If (mNomRep > 0) Then
            CboVeces.AddItem("Al menos Un Crédito")
            CboVeces.AddItem("Solo Un Crédito")
            CboVeces.AddItem("Dos Créditos")
            CboVeces.AddItem("Tres Créditos")
            CboVeces.AddItem("Cuatro Créditos o más")
            CboVeces.Columns(0).Caption = ""

        Else
            CboVeces.AddItem("Al menos Un Crédito")
            CboVeces.AddItem("Solo Un Crédito")
            CboVeces.AddItem("Dos Créditos")
            CboVeces.AddItem("Tres Créditos")
            CboVeces.AddItem("Cuatro Créditos")
            CboVeces.AddItem("Cinco Créditos")
            CboVeces.AddItem("Seis Créditos")
            CboVeces.AddItem("Siete Créditos")
            CboVeces.AddItem("Ocho Créditos")
            CboVeces.AddItem("Nueve Créditos")
            CboVeces.AddItem("Diez Créditos")
            CboVeces.AddItem("Once Créditos o más")
            CboVeces.Columns(0).Caption = ""
        End If
    End Sub

    Private Sub CargarMeses()
        CboMeses.AddItem("Enero")
        CboMeses.AddItem("Febrero")
        CboMeses.AddItem("Marzo")
        CboMeses.AddItem("Abril")
        CboMeses.AddItem("Mayo")
        CboMeses.AddItem("Junio")
        CboMeses.AddItem("Julio")
        CboMeses.AddItem("Agosto")
        CboMeses.AddItem("Septiembre")
        CboMeses.AddItem("Octubre")
        CboMeses.AddItem("Noviembre")
        CboMeses.AddItem("Diciembre")
        CboMeses.SelectedIndex = 0
    End Sub

    Private Sub frmSclParametroBarrio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            ObjGUI.SetFormLayout(Me, Me.mColorVentana)

            If mNomRep = 0 Or mNomRep = 2 Or mNomRep = 5 Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
            ElseIf mNomRep = 3 Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Socias")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Indicadores (Reportes)")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            CargarDepartamento()
            CargarVeces()
            CargarMeses()
            CargarFuente()

            Me.grpCartera.Enabled = False

            If Me.NomRep = EnumReportes.ComportamientoDeMora Then
                'Me.grpDistritoOMercado.Enabled = False
                Me.grpAprobadoODenegado.Enabled = False
                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Enabled = False
                Me.grpReporte.Enabled = False
                Me.cdeFechaInicial.Value = New Date(2007, 1, 1)
                Me.cdeFechaInicial.Enabled = False
                Me.grpCartera.Enabled = True
                Me.RdSinFuente.Enabled = False
                Me.grpIndiceMora.Enabled = True
            End If

     

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

            If mNomRep = EnumReportes.ResumenCreditos Then
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

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmSccParametroResumenCreditos_LocationChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.LocationChanged

    End Sub

    Private Sub frmSccParametroResumenCreditos_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll

    End Sub

    Private Sub frmSccParametroResumenCreditos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        grpReporte.Enabled = False
        grpFondooFuente.Enabled = False
        grpPrograma.Visible = False
        Select Case mNomRep

            Case EnumReportes.Detalle
                Me.Text = "Parámetros del Detalle de Créditos"
                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Visible = False
                Me.grpPrograma.Visible = True
            Case EnumReportes.NivelAcademico
                Me.Text = "Parámetros de Detalle de Socias Por Nivel Académico"
                RdActas.Text = "Todos"
                grpAprobadoODenegado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True

                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Visible = False
                RdSinFuente.Enabled = False

            Case EnumReportes.Estadistico
                Me.Text = "Parámetros del Reporte Estadístico"
                RdActas.Text = "Todos"
                grpAprobadoODenegado.Enabled = False
                grpDistritoOMercado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True
                Me.grpVeces.Enabled = False
            Case EnumReportes.EstadisticaDesembolso
                Me.Text = "Parámetros del Reporte Estadístico de distribución crédito"
                RdActas.Text = "Todos"
                grpVeces.Enabled = False
                grpFuente.Enabled = True
                grpAprobadoODenegado.Enabled = False
                grpDistritoOMercado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True
                Me.grpVeces.Enabled = False
                Me.RdTodos.Enabled = False
                Me.RdSinFuente.Enabled = False
                Me.RdPresupuesto.Checked = True

            Case EnumReportes.EstadisticaRecuperacion
                Me.Text = "Parámetros del Reporte Estadístico de distribución crédito"
                RdActas.Text = "Todos"
                grpVeces.Enabled = False
                grpFuente.Enabled = True
                grpAprobadoODenegado.Enabled = False
                grpDistritoOMercado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True
                Me.grpVeces.Enabled = False
                Me.grpVeces.Enabled = False
                Me.RdTodos.Enabled = False
                Me.RdSinFuente.Enabled = False
                Me.RdPresupuesto.Checked = True

            Case EnumReportes.NuncaPagado

                Me.Text = "Parámetros del Reporte de Nunca Pagados"
                RdActas.Text = "Todos"
                grpAprobadoODenegado.Enabled = False
                grpDistritoOMercado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True
                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Visible = False
                Me.grpFuente.Enabled = True
                Me.grpPrograma.Visible = True
            Case EnumReportes.ComportamientoDeMora
                grpReporte.Enabled = False
                Me.Text = "Parámetros del Reporte de Comportamiento de Mora"
                grpFondooFuente.Enabled = True
                grpPrograma.Visible = True
            Case Else
                Me.GrpPeriodo.Visible = False
                Me.Text = "Parámetros del Reporte de Resumen de Créditos"
                grpReporte.Enabled = True
                grpFondooFuente.Enabled = True
                grpPrograma.Visible = True
        End Select

        If IsDBNull(mNomRep) Or mNomRep = 0 Or mNomRep = EnumReportes.NivelAcademico Or mNomRep = EnumReportes.NuncaPagado Or mNomRep <> EnumReportes.EstadisticaDesembolso Or mNomRep <> EnumReportes.EstadisticaRecuperacion Then 'Or mNomRep = EnumReportes.Detalle Then
            grpFuente.Enabled = True
        Else
            grpFuente.Enabled = False
        End If

    End Sub

    Private Sub RdAprobado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdAprobado.CheckedChanged
        If mNomRep <> EnumReportes.Detalle And mNomRep <> EnumReportes.NivelAcademico Then
            If Me.RdAprobado.Checked Then
                grpVeces.Enabled = True
            Else
                grpVeces.Enabled = False
            End If
        End If

        If IsDBNull(mNomRep) Or mNomRep = 0 Then 'Or mNomRep = EnumReportes.Detalle Then
            grpFuente.Enabled = True
            grpReporte.Enabled = True
            grpFondooFuente.Enabled = True
        End If

        grpTurismo.Enabled = True
    End Sub

    Private Sub RdDenegado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdDenegado.CheckedChanged
        If IsDBNull(mNomRep) Or mNomRep = 0 Then ' Or mNomRep = EnumReportes.Detalle Then
            RdTodos.Checked = True
            grpFuente.Enabled = False
            grpReporte.Enabled = False
            grpFondooFuente.Enabled = False
        End If

        grpTurismo.Enabled = False
    End Sub

    Private Sub TxtAnio_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtAnio.KeyPress
        Dim KeyAscii = Asc(e.KeyChar)
        If KeyAscii < 48 Or KeyAscii > 57 Then
            e.Handled = True
        End If
    End Sub

    Private Sub TxtAnio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TxtAnio.TextChanged

    End Sub

    Private Sub CargarFuente()
        Try
            Dim Strsql As String

            'If IntPermiteConsultar = 0 Then
            '    Strsql = "SELECT   1 As Orden , a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" &
            '             " FROM         dbo.ScnFuenteFinanciamiento a Where  a.nScnFuenteFinanciamientoID=-1"
            'Else
            '    Strsql = "SELECT     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" &
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
            If Me.CboFuentes.ListCount > 0 Then
                'And IntPermiteConsultar = 1 Then
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


