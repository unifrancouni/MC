Imports System.Text

Public Class frmSccParametroResumenCreditos

    Dim IntPermiteConsultar As Integer
    'Dim IntPermiteEditar As Integer
    Dim IntDepartamento As Integer

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    'Dim XdtEstados As BOSistema.Win.XDataSet.xDataTable
    'Dim XdtPertenece As BOSistema.Win.XDataSet.xDataTable
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
            'XdtPertenece = New BOSistema.Win.XDataSet.xDataTable
            'XdtEstados = New BOSistema.Win.XDataSet.xDataTable

            'Tit�lo de Reporte
            Control.CheckForIllegalCrossThreadCalls = False

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

            ''Fecha Editar datos de Todas las Delegaciones:
            'Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            'IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

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

            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Departamento").Count > 0 Then
            '    XdsCombos("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "C�digo"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripci�n"

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
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
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

            'XdtValorParametro.Filter = "nStbParametroID = 15"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Municipio").Count > 0 Then
            '    XdsCombos("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "C�digo"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripci�n"

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
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub



    'En caso que haya habido alg�n cambio
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
                MsgBox("Debe seleccionar un Departamento v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento v�lido.")
                Me.cboDepartamento.Focus()
                GoTo SALIR
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio v�lido.")
                Me.cboMunicipio.Focus()
                GoTo SALIR
            End If
            ' If mNomRep <> EnumReportes.NivelAcademico Then 'And mNomRep <> EnumReportes.Estadistico Then restaurar

            If IsDBNull(cdeFechaInicial.Value) And mNomRep <> EnumReportes.NuncaPagado Then
                MsgBox("Debe seleccionar una fecha de inicio v�lido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio v�lido.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final v�lida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final v�lida.")
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

            ' End If



            If mNomRep <> EnumReportes.NivelAcademico And _
               mNomRep <> EnumReportes.Detalle And _
               mNomRep <> EnumReportes.Estadistico And _
               mNomRep <> EnumReportes.NuncaPagado And _
               mNomRep <> EnumReportes.EstadisticaDesembolso And _
               mNomRep <> EnumReportes.EstadisticaRecuperacion And _
               Me.NomRep <> EnumReportes.ComportamientoDeMora Then
                If CboVeces.SelectedIndex = -1 And RdAprobado.Checked = True Then
                    MsgBox("Debe seleccionar El n�mero de cr�ditos para las socias.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboVeces, "Debe seleccionar El n�mero de cr�ditos para las socias.")
                    Me.CboVeces.Focus()
                    GoTo SALIR
                End If
            End If
            'Si Cambio CC26 a Tablas Calculadas Restaurar
            'If mNomRep = EnumReportes.Estadistico Then
            '    If CboMeses.SelectedIndex = -1 Then
            '        MsgBox("Debe seleccionar El mes a filtrar.", MsgBoxStyle.Critical, NombreSistema)
            '        Me.errParametro.SetError(Me.CboMeses, "Debe seleccionar El mes a filtrar.")
            '        Me.CboMeses.Focus()
            '        GoTo SALIR
            '    End If

            '    If Val(Me.TxtAnio.Text) < 2007 Then
            '        MsgBox("Debe seleccionar El a�o mayor o igual que 2007", MsgBoxStyle.Critical, NombreSistema)
            '        Me.errParametro.SetError(Me.TxtAnio, "Debe seleccionar El mes a filtrar.")
            '        Me.TxtAnio.Focus()
            '        GoTo SALIR
            '    End If
            'End If



            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        '----------------------------------------------------------------------
        'Llama al reporte del listado de consolidados de cr�ditos
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
                ''If TipoReporte <= 4 Then

                Filtro = " And dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "

                ''Else
                ''  Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
                ''End If
            Else

            End If

            If TipoReporte = 6 And mNomRep = 0 Then
                Filtro = " Where dFechaNotificacion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNotificacion<CONVERT(DATETIME,'" & Format(DateAdd(DateInterval.Day, 1, CdeFechaFinal.Value), "yyyy-MM-dd") & "') "
            End If


            If cboDepartamento.SelectedIndex <> -1 And cboDepartamento.Text <> "Todos" Then

                Filtro = Filtro & " And Departamento='" & Trim(cboDepartamento.Text) & "'"

                If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then

                    Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                End If
            End If


            frmVisor.WindowState = FormWindowState.Maximized

            If Me.NomRep <> EnumReportes.ComportamientoDeMora Then
                frmVisor.Formulas("RangoFecha") = "' DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
            End If

            frmVisor.Formulas("Parametros") = "' Fechas " & cdeFechaInicial.Value & " - " & CdeFechaFinal.Value & " Departamento(" & Trim(cboDepartamento.Text) & ") Municipio( " & Trim(cboMunicipio.Text) & ")" & "'"        ' "  '"  ' Al :" & CdeFechaFinal.Value
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            'If mNomRep <> EnumReportes.Detalle Then
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
                        'Filtro = " {spSccComportamientoDeMora;1.nStbMunicipioID} = 0"
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
                        'SubCadFiltro = " Where  nScnFuenteFinanciamientoID=" & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
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
                    ''frmVisor.Formulas("TipoFondo") = IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "")))

                Case EnumReportes.EstadisticaDesembolso
                    'CadSql = "EXEC	[dbo].[spSccGeneraEstadisticaPorMes] @FechaInicio = N'2008-07-01',@FechaFinal = N'2008-07-31'"

                    'XdtDatos.ExecuteSql(CadSql)


                    Filtro = ""
                    If cboDepartamento.SelectedIndex > 0 Then

                        'Filtro = Filtro & " {spSccReporteEstadisticaSaldoMes.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        Filtro = Filtro & " {spSccReporteEstadisticaPorPeriodoPorFuenteR1.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value

                        'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        '    Filtro = Filtro & " And {spSccReporteAvanceCartera.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        'End If

                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        'If Trim(Filtro) <> "" Then
                        '    Filtro = Filtro & " And {spSccReporteEstadisticaSaldoMes.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'Else
                        '    Filtro = "{spSccReporteEstadisticaSaldoMes.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'End If
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteEstadisticaPorPeriodoPorFuenteR1.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteEstadisticaPorPeriodoPorFuenteR1.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If
                    'Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.NombreReporte = "RepSccCC46.rpt"
                    frmVisor.Text = "Reporte Estad�stico de la recuperaci�n de cartera "
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(RdPresupuesto.Checked, 1, 0)

                Case EnumReportes.EstadisticaRecuperacion
                    'CadSql = "EXEC	[dbo].[spSccGeneraEstadisticaPorMes] @FechaInicio = N'2008-07-01',@FechaFinal = N'2008-07-31'"

                    'XdtDatos.ExecuteSql(CadSql)


                    Filtro = ""
                    If cboDepartamento.SelectedIndex > 0 Then

                        'Filtro = Filtro & " {spSccReporteEstadisticaSaldoMes.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        Filtro = Filtro & " {spSccReporteEstadisticaPorPeriodoPorFuenteR2.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value

                        'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        '    Filtro = Filtro & " And {spSccReporteAvanceCartera.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        'End If

                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        'If Trim(Filtro) <> "" Then
                        '    Filtro = Filtro & " And {spSccReporteEstadisticaSaldoMes.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'Else
                        '    Filtro = "{spSccReporteEstadisticaSaldoMes.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'End If
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteEstadisticaPorPeriodoPorFuenteR2.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteEstadisticaPorPeriodoPorFuenteR2.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If
                    'Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.NombreReporte = "RepSccCC47.rpt"
                    frmVisor.Text = "Reporte Estad�stico de la recuperaci�n de cartera "
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@Fuente") = IIf(RdPresupuesto.Checked, 1, 0)





                Case EnumReportes.Estadistico
                    'CadSql = "EXEC	[dbo].[spSccGeneraEstadisticaPorMes] @FechaInicio = N'2008-07-01',@FechaFinal = N'2008-07-31'"

                    'XdtDatos.ExecuteSql(CadSql)


                    Filtro = ""
                    If cboDepartamento.SelectedIndex > 0 Then

                        'Filtro = Filtro & " {spSccReporteEstadisticaSaldoMes.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        Filtro = Filtro & " {spSccReporteEstadisticaPorPeriodo.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value

                        'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        '    Filtro = Filtro & " And {spSccReporteAvanceCartera.Municipio}='" & Trim(cboMunicipio.Text) & "'"
                        'End If

                    End If
                    If cboMunicipio.SelectedIndex > 0 Then
                        'If Trim(Filtro) <> "" Then
                        '    Filtro = Filtro & " And {spSccReporteEstadisticaSaldoMes.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'Else
                        '    Filtro = "{spSccReporteEstadisticaSaldoMes.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        'End If
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {spSccReporteEstadisticaPorPeriodo.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{spSccReporteEstadisticaPorPeriodo.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If

                    End If
                    'Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If
                    frmVisor.NombreReporte = "RepSccCC26.rpt"
                    frmVisor.Text = "Reporte Estad�stico de la Cartera "
                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")

                    'frmVisor.Parametros("@Mes") = Me.CboMeses.SelectedIndex + 1
                    'frmVisor.Parametros("@Anio") = CInt(Me.TxtAnio.Text)

                Case EnumReportes.Detalle
                    frmVisor.Formulas("TipoReporte") = IIf(Me.RdDistrito.Checked = True, 1, IIf(Me.RdMercado.Checked = True, 2, 3))
                    frmVisor.Formulas("TipoPrograma") = "'" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'"
                    CadSql = ""

                    If RdAprobado.Checked = True Then
                        '    If Me.RdPresupuesto.Checked Then
                        '        Filtro = Filtro & " AND nFondoPresupuestario = 1"
                        '    Else
                        '        If Me.RdExterno.Checked Then
                        '            Filtro = Filtro & " AND nFondoPresupuestario = 0"
                        '        Else
                        '            If Me.RdSinFuente.Checked Then
                        '                Filtro = Filtro & " AND nFondoPresupuestario IS NULL  "
                        '            End If
                        '        End If
                        '    End If


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
                        '      " LEFT OUTER JOIN dbo.SccSolicitudDesembolsoCredito ON DFNC.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
                        '     " INNER JOIN dbo.SccSolicitudCheque ON dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID " & _
                        '    " INNER JOIN dbo.ScnFuenteFinanciamiento ON dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID "


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
                        '" LEFT OUTER JOIN dbo.SccSolicitudDesembolsoCredito ON DFNC.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
                        '" INNER JOIN dbo.SccSolicitudCheque ON dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID " & _
                        '" INNER JOIN dbo.ScnFuenteFinanciamiento ON dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID "


                    End If

                    '                    " CAST(SUBSTRING(FNC.sNumSesion, 1, CHARINDEX('-', FNC.sNumSesion) - 1) AS int) AS sNumSesion, CAST(SUBSTRING(FNC.sNumSesion, " & _
                    '" CHARINDEX('-', FNC.sNumSesion) + 1, LEN(FNC.sNumSesion) - CHARINDEX('-', FNC.sNumSesion)) AS int) AS sNumAnio, " & _

                    '                    " CAST(SUBSTRING(FNC.sNumSesion, 1, CHARINDEX('-', FNC.sNumSesion) - 1) AS int) AS sNumSesion, CAST(SUBSTRING(FNC.sNumSesion, " & _
                    '" CHARINDEX('-', FNC.sNumSesion) + 1, LEN(FNC.sNumSesion) - CHARINDEX('-', FNC.sNumSesion)) AS int) AS sNumAnio, " & _
                    frmVisor.Formulas("RangoFecha") = "' " & _
                                                       IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))) & " DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value

                    frmVisor.NombreReporte = "RepSclCS20.rpt"

                    Select Case TipoReporte

                        Case 1
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS VIGENTES POR DISTRITO'"
                            frmVisor.Text = "Reporte de Cr�ditos Aprobados Por Distrito"
                            frmVisor.SQLQuery = CadSql & " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And   (SclGrupoSocia_1.nCoordinador = 1) AND (DFNC.nCreditoRechazado = 0) AND (EstadoFNC.sCodigoInterno = '2')  And nStbMercadoVerificadoID = 1 And (dbo.vwSccListadoEstadoFichaNotificacionCredito.FichaActiva = 1) " & Trim(Filtro)
                        Case 2
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS DENEGADOS POR DISTRITO'"
                            frmVisor.Text = "Reporte de Cr�ditos Denegados por Distrito"
                            frmVisor.SQLQuery = CadSql & _
                          " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And SclGrupoSocia_1.nCoordinador =1 And (DFNC.nCreditoRechazado = 1) AND (EstadoFNC.sCodigoInterno = '2' OR EstadoFNC.sCodigoInterno = '3')   And (nStbMercadoVerificadoID = 1)  " & Trim(Filtro)

                        Case 3
                            frmVisor.Formulas("Etiqueta") = String.Format("'CREDITOS VIGENTES POR {0}'", IIf(Me.rdoCooperativa.Checked, "COOPERATIVA", "MERCADO"))
                            frmVisor.Text = "Reporte de Cr�ditos Aprobados por " & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado")
                            'frmVisor.SQLQuery = "Select * From vwSccResumenCreditosVigentesMercadoCoordinadoraRep    " & Trim(Filtro)
                            frmVisor.SQLQuery = CadSql & " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And (SclGrupoSocia_1.nCoordinador = 1) AND (DFNC.nCreditoRechazado = 0) AND (EstadoFNC.sCodigoInterno = '2')  And nStbMercadoVerificadoID <> 1 And (dbo.vwSccListadoEstadoFichaNotificacionCredito.FichaActiva = 1) And ( nCooperativa = " & IIf(Me.rdoCooperativa.Checked, 1, 0) & " ) " & Trim(Filtro)

                        Case 4
                            frmVisor.Formulas("Etiqueta") = String.Format("'CREDITOS DENEGADOS POR {0}'", IIf(Me.rdoCooperativa.Checked, "COOPERATIVA", "MERCADO"))
                            frmVisor.Text = "Reporte de Cr�ditos Aprobados por " & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado")
                            frmVisor.SQLQuery = CadSql & _
                           " WHERE   vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "' And SclGrupoSocia_1.nCoordinador=1 And  (DFNC.nCreditoRechazado = 1) AND (EstadoFNC.sCodigoInterno = '2' OR EstadoFNC.sCodigoInterno = '3')   And (nStbMercadoVerificadoID <> 1) AND (nCooperativa = " & IIf(Me.rdoCooperativa.Checked, 1, 0) & " ) " & Trim(Filtro)

                        Case 5
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS VIGENTES POR ACTAS'"
                            frmVisor.Text = "Reporte de Cr�ditos Aprobados por Acta"
                            frmVisor.SQLQuery = CadSql & Trim(Filtro) & " And vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'  And (SclGrupoSocia_1.nCoordinador = 1) AND (DFNC.nCreditoRechazado = 0) AND (EstadoFNC.sCodigoInterno = '2') And (dbo.vwSccListadoEstadoFichaNotificacionCredito.FichaActiva = 1)   "
                        Case 6
                            frmVisor.Formulas("Etiqueta") = "'CREDITOS DENEGADOS POR ACTAS'"
                            frmVisor.Text = "Reporte de Cr�ditos Denegados por Acta"
                            frmVisor.SQLQuery = CadSql & _
                             Trim(Filtro) & " And vwSccDetalleCreditosProgramaFichaNotificacion.CodigoPrograma='" & IIf(Me.RdUsuraCero.Checked, 1, 2) & "'  And (SclGrupoSocia_1.nCoordinador = 1) And  (DFNC.nCreditoRechazado = 1) AND (EstadoFNC.sCodigoInterno = '2' OR EstadoFNC.sCodigoInterno = '3')     "
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

                    '                    CadSql2 = "(SELECT     FI.dFechaInscripcion AS dFechaNotificacion, vwUbicacion.nStbDepartamentoID, vwUbicacion.Departamento, vwUbicacion.nStbMunicipioID, " & _
                    '                "      vwUbicacion.Municipio, vwUbicacion.nStbDistritoID, vwUbicacion.CodDistrito, vwUbicacion.Distrito, vwUbicacion.nStbBarrioID, vwUbicacion.Barrio, " & _
                    '                 "     GS.nStbMercadoVerificadoID, Mercado.sCodigo AS CodigoMercado, Mercado.sNombre AS NombreMercado, " & _
                    '                 "     FI.nMontoCreditoVerificado AS MontoSolicitado, GS.nSclGrupoSolidarioID, Socia.nSclSociaID, dbo.SclGrupoSocia.nCoordinador, GS.sCodigo, " & _
                    '                  "    GS.sDescripcion, Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia, FI.nAlfabetizadaVerificada, " & _
                    '                   "   Primaria.nStbValorCatalogoID AS IDPrimaria, Secundaria.sCodigoInterno AS CodigoPrimaria, Primaria.sDescripcion AS NivelPrimaria, " & _
                    '                    "  Secundaria.nStbValorCatalogoID AS IDSecundaria, Secundaria.sCodigoInterno AS CodigoSecundaria, Secundaria.sDescripcion AS NivelSecundaria, " & _
                    '                    "  Tecnico.nStbValorCatalogoID AS IDTecnico, Tecnico.sCodigoInterno AS CodigoTecnico, Tecnico.sDescripcion AS NivelTecnico, " & _
                    '                    "  CASE WHEN Primaria.sCodigoInterno <> '1' AND Secundaria.sCodigoInterno = '1' AND " & _
                    '                    "  Tecnico.sCodigoInterno = '1' THEN 1 ELSE 0 END AS SoloPrimaria, CASE WHEN Secundaria.sCodigoInterno <> '1' AND " & _
                    '                    "  Tecnico.sCodigoInterno = '1' THEN 1 ELSE 0 END AS SoloSecundaria, CASE WHEN Tecnico.sCodigoInterno <> '1' THEN 1 ELSE 0 END AS SoloTecnico, " & _
                    '                    "  CASE WHEN Primaria.sCodigoInterno = '1' AND Secundaria.sCodigoInterno = '1' AND Tecnico.sCodigoInterno = '1' AND " & _
                    '                    "  FI.nAlfabetizadaVerificada = 1 THEN 1 ELSE 0 END AS SoloAlfabetizada, CASE WHEN Primaria.sCodigoInterno = '1' AND " & _
                    '                    "  Secundaria.sCodigoInterno = '1' AND Tecnico.sCodigoInterno = '1' AND FI.nAlfabetizadaVerificada = 0 THEN 1 ELSE 0 END AS NoAlfabetizada, " & _
                    '                    "  dbo.StbValorCatalogo.sCodigoInterno AS EstadoFicha, dbo.StbValorCatalogo.sDescripcion AS DescripcionEstadoFicha, " & _
                    '                    " dbo.ScnFuenteFinanciamiento.nFondoPresupuestario " & _
                    '" FROM         dbo.SclGrupoSocia INNER JOIN " & _
                    '                   "   dbo.SclGrupoSolidario AS GS ON dbo.SclGrupoSocia.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                    '                    "  dbo.SclFichaSocia AS FI ON dbo.SclGrupoSocia.nSclGrupoSociaID = FI.nSclGrupoSociaID INNER JOIN " & _
                    '                     " dbo.SclSocia AS Socia ON dbo.SclGrupoSocia.nSclSociaID = Socia.nSclSociaID INNER JOIN " & _
                    '                     " dbo.vwStbUbicacionGeografica AS vwUbicacion ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID INNER JOIN " & _
                    '                     " dbo.StbMercado AS Mercado ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID INNER JOIN " & _
                    '                     " dbo.StbValorCatalogo AS Primaria ON FI.nStbPrimariaVerificadaID = Primaria.nStbValorCatalogoID INNER JOIN " & _
                    '                     " dbo.StbValorCatalogo AS Secundaria ON FI.nStbSecundariaVerificadaID = Secundaria.nStbValorCatalogoID INNER JOIN " & _
                    '                     " dbo.StbValorCatalogo AS Tecnico ON FI.nStbCarreraTecnicaVerificadaID = Tecnico.nStbValorCatalogoID INNER JOIN " & _
                    '                     " dbo.StbValorCatalogo ON FI.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                    '                     "     (SELECT     NFichaSociaId, nSclFichaNotificacionDetalleID " & _
                    '                       "     FROM          (SELECT     dbo.SclSocia.nSclSociaID, MAX(dbo.SclFichaSocia.nSclFichaSociaID) AS NFichaSociaId, " & _
                    '                      "                                                     MAX(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS nSclFichaNotificacionDetalleID  " & _
                    '                        "                            FROM          dbo.SclGrupoSocia AS SclGrupoSocia_1 INNER JOIN " & _
                    '                         "                                                  dbo.SclSocia ON SclGrupoSocia_1.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN " & _
                    '                          "                                                 dbo.SclFichaSocia ON SclGrupoSocia_1.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
                    '                           "                                                dbo.SclFichaNotificacionDetalle INNER JOIN " & _
                    '                            "                                               dbo.SclFichaNotificacionCredito ON  " & _
                    '                             "                                              dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                    '                              "                                             dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  " & _
                    '                               "                                            dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID ON " & _
                    '                    " dbo.SclFichaSocia.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID " & _
                    '                      "                              WHERE      (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (StbValorCatalogo_1.sCodigoInterno = '2') " & Trim(Filtro2) & _
                    '                      "                              GROUP BY dbo.SclSocia.nSclSociaID) AS A) AS Credito ON FI.nSclFichaSociaID = Credito.NFichaSociaId INNER JOIN " & _
                    '                      " dbo.SccSolicitudDesembolsoCredito ON " & _
                    '                      " Credito.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN " & _
                    '                      " dbo.ScnFuenteFinanciamiento ON  " & _
                    '                    " dbo.SccSolicitudDesembolsoCredito.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID  " & _
                    ' " " & IIf(TipoReporte = 1, " WHERE (nStbMercadoVerificadoID = 1) ", IIf(TipoReporte = 3, " Where (nStbMercadoVerificadoID <> 1)  ", IIf(TipoReporte = 5, " Where nStbMercadoVerificadoID<>-1 ", ""))) & " ) As Vista"

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
                            'frmVisor.SQLQuery = " SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodDistrito AS CodGrupo, Distrito AS Grupo, SUM(SoloPrimaria) AS TotalPrimaria, " & _
                            '                    " SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, SUM(NoAlfabetizada) AS TotalNoAlfabetizada, " & _
                            '                    " SUM(1) AS TotalSocias FROM dbo.vwSclNivelAcademicoDetalle   WHERE(nStbMercadoVerificadoID = 1) " & _
                            '                    Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, nStbDistritoID, CodDistrito, Distrito"

                            frmVisor.SQLQuery = " SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodDistrito AS CodGrupo, Distrito AS Grupo, SUM(SoloPrimaria) AS TotalPrimaria, " & _
                                                                            " SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, SUM(NoAlfabetizada) AS TotalNoAlfabetizada, " & _
                                                                            " SUM(1) AS TotalSocias FROM    " & CadSql2 & " " & _
                                                                            Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, nStbDistritoID, CodDistrito, Distrito"

                        Case 3
                            frmVisor.Formulas("TipoReporte") = 3
                            frmVisor.Text = String.Format("Reporte de Totales de Socias en {0}", IIf(Me.rdoCooperativa.Checked, "las Cooperativas", "los Mercados"))
                            'frmVisor.SQLQuery = "SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodigoMercado AS CodGrupo, NombreMercado AS Grupo, " & _
                            '                    " SUM(SoloPrimaria) AS TotalPrimaria, SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, " & _
                            '                    " SUM(NoAlfabetizada) AS TotalNoAlfabetizada,Sum(1) AS TotalSocias FROM dbo.vwSclNivelAcademicoDetalle  WHERE (nStbMercadoVerificadoID <> 1) " & _
                            '                    Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodigoMercado, NombreMercado "

                            frmVisor.SQLQuery = "SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodigoMercado AS CodGrupo, NombreMercado AS Grupo, " & _
                                                " SUM(SoloPrimaria) AS TotalPrimaria, SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, " & _
                                                " SUM(NoAlfabetizada) AS TotalNoAlfabetizada,Sum(1) AS TotalSocias FROM  " & CadSql2 & " " & _
                                                " " & Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodigoMercado, NombreMercado "

                        Case 5
                            frmVisor.Formulas("TipoReporte") = 1
                            frmVisor.Text = "Reporte de Totales de Socias en los Distritos y Mercados"
                            'frmVisor.SQLQuery = " SELECT     nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, CodDistrito AS CodGrupo, Distrito AS Grupo, SUM(SoloPrimaria) AS TotalPrimaria, " & _
                            '                    " SUM(SoloSecundaria) AS TotalSecundaria, SUM(SoloTecnico) AS TotalTecnico, SUM(SoloAlfabetizada) AS TotalAlfabetizada, SUM(NoAlfabetizada) AS TotalNoAlfabetizada, " & _
                            '                    " SUM(1) AS TotalSocias FROM dbo.vwSclNivelAcademicoDetalle  Where   nStbMercadoVerificadoID<>-1  " & _
                            '                    Trim(Filtro) & " GROUP BY nStbDepartamentoID, Departamento, nStbMunicipioID, Municipio, nStbDistritoID, CodDistrito, Distrito"
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
                    ''frmVisor.Formulas("DesFondo") = "Fondos(" & IIf(Me.RdTodos.Checked = True, "Todos", IIf(Me.RdPresupuesto.Checked, "Presupuesto", IIf(Me.RdExterno.Checked = True, "Externos", IIf(Me.RdSinFuente.Checked, "No asignados", "")))) & ")'"
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

                    'If Me.RdExterno.Checked = True Or RdPresupuesto.Checked = True Then
                    '    If Trim(Filtro) <> "" Then
                    '        Filtro = Filtro & " And nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                    '    Else
                    '        Filtro = " nFondoPresupuestario=" & IIf(RdPresupuesto.Checked, "1", "0")
                    '    End If
                    'End If


                    Me.Cursor = Cursors.WaitCursor
                    If Trim(Filtro) <> "" Then
                        frmVisor.CRVReportes.SelectionFormula = Filtro
                    End If

                    frmVisor.NombreReporte = "RepSccCC43.rpt"
                    frmVisor.Text = "Reporte de grupos de al menos una socia que nunca ha pagado"
                    ''frmVisor.Parametros("@FechaCorte") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaCorte") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@CodigoPrograma") = IIf(Me.RdUsuraCero.Checked, 1, 2)
                    Me.Cursor = Cursors.Default










                Case Else
                    If TipoReporte = 1 Or TipoReporte = 3 Or TipoReporte = 5 Then
                        Filtro = VecesCredito(Filtro)
                        Select Case Me.CboVeces.SelectedIndex
                            Case 0
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con todos sus Cr�ditos '"
                            Case 1
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con un solo Cr�dito'"
                            Case 2
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Dos Cr�ditos'"
                            Case 3
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Tres Cr�ditos'"
                            Case 4
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Cuatro Cr�ditos'"
                            Case 5
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Cinco Cr�ditos'"
                            Case 6
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Seis Cr�ditos'"
                            Case 7
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Siete Cr�ditos'"
                            Case 8
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Ocho Cr�ditos'"
                            Case 9
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Nueve Cr�ditos'"
                            Case 10
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Diez Cr�ditos'"

                            Case 11
                                frmVisor.Formulas("NumeroCreditos") = "'Incluido Socias con Once o m�s Cr�ditos'"
                        End Select
                    End If
                    ''Filtro = TipoFondo(Filtro)

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
                            SubCadFiltro = " Where  nScnFuenteFinanciamientoID=" & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                        End If

                    End If
                    If TipoReporte = 1 Or TipoReporte = 3 Or TipoReporte = 5 Then
                        If Trim(Filtro) = "" Then
                            Filtro = " Where  Gs.TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                        Else
                            Filtro = Filtro & " And Gs.TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                        End If
                        frmVisor.Formulas("TipoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)
                    End If

                    If TipoReporte = 2 Or TipoReporte = 4 Or TipoReporte = 6 Then
                        If Trim(Filtro) = "" Then
                            Filtro = " And TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                        Else
                            Filtro = Filtro & " And TipoPrograma=" & IIf(RdUsuraCero.Checked, 1, 2)
                        End If
                        frmVisor.Formulas("TipoPrograma") = IIf(RdUsuraCero.Checked, 1, 2)
                    End If
                    Select Case TipoReporte
                        Case 1


                            frmVisor.NombreReporte = "RepSccCC2.rpt"
                            frmVisor.Text = "Reporte de Cr�ditos Vigentes  Por Distrito"
                            'frmVisor.SQLQuery = "SELECT     TOP (100) PERCENT Departamento, Municipio, Distrito, COUNT(DISTINCT nSclSociaID) AS TotalSociasUnica, COUNT(nSclSociaID) AS TotalSocias, COUNT(DISTINCT nSclFichaNotificacionId) AS TotalGrupos, " & _
                            '     " SUM(MontoSolicitado) AS TotalMontoSolicitado, SUM(nMontoCreditoAprobado) AS TotalMontoCreditoAprobado                     FROM dbo.vwSccResumenCreditosAprobadosRep" & _
                            '     " WHERE(nStbMercadoVerificadoID = 1) " & Trim(Filtro) & "  GROUP BY Departamento, Municipio, Distrito"

                            '  frmVisor.SQLQuery = "SELECT     *   FROM vwSccResumenCreditosAprobadosRep" & _
                            '" WHERE(nStbMercadoVerificadoID = 1) " & Trim(Filtro) & " OPTION (FORCE ORDER) " '' & "  GROUP BY Departamento, Municipio, Distrito"

                            frmVisor.SQLQuery = " SELECT     Departamento, Municipio, Distrito, nSclFichaNotificacionID, MontoSolicitado, nMontoCreditoAprobado, nStbDistritoID, nSclGrupoSolidarioID, " & _
                                                "nSclSociaID, nStbMercadoVerificadoID, dFechaNotificacion, sNombre, SesionDes, sNumSesion, nCoordinador, sCodigo, sDescripcion, NombreSocia, " & _
                                                "CodDistrito, Barrio, nStbDepartamentoID, nStbMunicipioID, nStbBarrioID, TotalCreditos, nFondoPresupuestario, sCodigoInterno, EstadoCheque, Fondo, " & _
                                                "nScnFuenteFinanciamientoID, sNombre1, sNombre2, sApellido1, sApellido2, sNumeroCedula, NumeroDelCredito, " & _
                                                " CASE WHEN NumeroDelCredito = 1 THEN 1 ELSE 0 END AS SociaPosicion " & _
                                                " FROM         (SELECT     vwUbicacion.Departamento, vwUbicacion.Municipio, vwUbicacion.Distrito, FNC.nSclFichaNotificacionID,  " & _
                                                " FI.nMontoCreditoVerificado AS MontoSolicitado, DFNC.nMontoCreditoAprobado, vwUbicacion.nStbDistritoID, GS.nSclGrupoSolidarioID, " & _
                                                " Socia.nSclSociaID, GS.nStbMercadoVerificadoID, FNC.dFechaNotificacion, Mercado.sNombre, FNC.sNumSesion AS SesionDes, " & _
                                                " FNC.sNumSesion, dbo.SclGrupoSocia.nCoordinador, GS.sCodigo, GS.sDescripcion,  " & _
                                                " Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia, vwUbicacion.CodDistrito, " & _
                                                " vwUbicacion.Barrio, vwUbicacion.nStbDepartamentoID, vwUbicacion.nStbMunicipioID, vwUbicacion.nStbBarrioID,  " & _
                                              " SociaCreditos.TotalCreditos, dbo.ScnFuenteFinanciamiento.nFondoPresupuestario, dbo.StbValorCatalogo.sCodigoInterno, " & _
                                              "dbo.StbValorCatalogo.sDescripcion AS EstadoCheque, CASE WHEN dbo.ScnFuenteFinanciamiento.nFondoPresupuestario IS NOT NULL " & _
                                              " THEN dbo.ScnFuenteFinanciamiento.nFondoPresupuestario ELSE - 1 END AS Fondo, " & _
                                              " dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID, Socia.sNombre1, Socia.sNombre2, Socia.sApellido1, Socia.sApellido2, " & _
                                              " Socia.sNumeroCedula, ROW_NUMBER() OVER (PARTITION BY Socia.nSclSociaID " & _
                                              " ORDER BY FNC.dFechaNotificacion ASC) AS NumeroDelCredito " & _
                                              " FROM         dbo.StbValorCatalogo INNER JOIN " & _
                                              "dbo.SccSolicitudDesembolsoCredito INNER JOIN " & _
                      "dbo.SccSolicitudCheque ON " & _
                      " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                      " dbo.ScnFuenteFinanciamiento ON " & _
                      " dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID ON " & _
                      " dbo.StbValorCatalogo.nStbValorCatalogoID = dbo.SccSolicitudCheque.nStbEstadoSolicitudID RIGHT OUTER JOIN " & _
                      " dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                      " dbo.SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " & _
 " (SELECT     dbo.SclGrupoSolidario.nSclGrupoSolidarioID,  dbo.SclGrupoSolidario.nStbBarrioVerificadoID ,dbo.SclGrupoSolidario.nStbMercadoVerificadoID, dbo.SclGrupoSolidario.sCodigo, " & _
"                       dbo.SclGrupoSolidario.sDescripcion, CASE WHEN dbo.SclTipodePlandeNegocio.nCodigo > 2 THEN 2 ELSE 1 END AS TipoPrograma " & _
"  FROM         dbo.SclGrupoSolidario INNER JOIN " & _
"                      dbo.SclTipodePlandeNegocio ON dbo.SclGrupoSolidario.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID )" & _
                      "  AS GS ON FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                      " dbo.SclFichaSocia AS FI ON DFNC.nSclFichaSociaID = FI.nSclFichaSociaID INNER JOIN " & _
                      " dbo.SclGrupoSocia ON GS.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID AND " & _
                      " FI.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                      " dbo.SclSocia AS Socia ON dbo.SclGrupoSocia.nSclSociaID = Socia.nSclSociaID INNER JOIN " & _
                      " dbo.StbValorCatalogo AS CNegocio ON FI.nStbActividadEconomicaVerificadaID = CNegocio.nStbValorCatalogoID INNER JOIN " & _
                      " dbo.StbValorCatalogo AS CTipoPlazo ON DFNC.nStbTipoPlazoAprobadoID = CTipoPlazo.nStbValorCatalogoID INNER JOIN " & _
                      " dbo.vwStbUbicacionGeografica AS vwUbicacion ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID INNER JOIN " & _
                      " dbo.StbMercado AS Mercado ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID INNER JOIN " & _
                      " dbo.vwStbEmpleado ON FNC.nSrhEmpleadoComite1ID = dbo.vwStbEmpleado.nSrhEmpleadoID INNER JOIN " & _
                      " dbo.vwStbEmpleado AS vwStbEmpleado_1 ON FNC.nSrhEmpleadoComite2ID = vwStbEmpleado_1.nSrhEmpleadoID INNER JOIN " & _
                      " dbo.vwStbEmpleado AS vwStbEmpleado_2 ON FNC.nSrhEmpleadoComite3ID = vwStbEmpleado_2.nSrhEmpleadoID INNER JOIN " & _
                      " dbo.StbValorCatalogo AS EstadoFNC ON FNC.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID INNER JOIN " & _
                      "    (SELECT     dbo.SclSocia.nSclSociaID, COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS TotalCreditos " & _
                       "     FROM          dbo.SclSocia INNER JOIN " & _
                      "                             dbo.SclGrupoSocia AS SclGrupoSocia_1 ON dbo.SclSocia.nSclSociaID = SclGrupoSocia_1.nSclSociaID INNER JOIN " & _
                      "                             dbo.SclFichaSocia ON SclGrupoSocia_1.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
                      "                             dbo.SclFichaNotificacionDetalle ON dbo.SclFichaSocia.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN " & _
                      "                             dbo.SclFichaNotificacionCredito ON  " & _
                      "                             dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                      "                             dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  " & _
                       "     dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                        "    WHERE      (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (StbValorCatalogo_1.sCodigoInterno = '2') " & _
                         "   GROUP BY dbo.SclSocia.nSclSociaID) AS SociaCreditos ON Socia.nSclSociaID = SociaCreditos.nSclSociaID ON  " & _
                          "  dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " & _
" WHERE     (EstadoFNC.sCodigoInterno = '2') AND (DFNC.nCreditoRechazado = 0) And nStbMercadoVerificadoID = 1" & Trim(Filtro) & ") AS ListadoCredito  " & SubCadFiltro & " OPTION (FORCE ORDER)"



                            frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)


                        Case 2
                            frmVisor.NombreReporte = "RepSccCC3.rpt"
                            frmVisor.Text = "Reporte de Cr�ditos Denegados por Distrito"
                            frmVisor.SQLQuery = "SELECT     Departamento, Municipio, Distrito, COUNT(DISTINCT nSclFichaNotificacionId ) AS TotalGrupos, COUNT(nSclSociaID) AS TotalSocias, " & _
                                                " SUM(MontoSolicitado) AS MontoDenegado   FROM dbo.vwSccResumenCreditosDenegadosRep WHERE (nStbMercadoVerificadoID = 1) " & Trim(Filtro) & "  GROUP BY Departamento, Municipio, Distrito"

                        Case 3
                            frmVisor.NombreReporte = "RepSccCC4.rpt"
                            frmVisor.Formulas("TipoAsociacion") = String.Format("'{0}'", IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado"))
                            frmVisor.Text = String.Format("Reporte de Cr�ditos Aprobados por {0}", IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado"))
                            'frmVisor.SQLQuery = "SELECT     TOP (100) PERCENT Departamento, Municipio, sNombre, COUNT(DISTINCT nSclSociaID) AS TotalSociasUnica,COUNT(nSclSociaID) AS TotalSocias, COUNT(DISTINCT nSclFichaNotificacionId) " & _
                            '                    "  AS TotalGrupos, SUM(MontoSolicitado) AS TotalMontoSolicitado, SUM(nMontoCreditoAprobado) AS TotalMontoCreditoAprobado  " & _
                            '                    " FROM dbo.vwSccResumenCreditosAprobadosRep WHERE(nStbMercadoVerificadoID <> 1) " & Trim(Filtro) & "  GROUP BY Departamento, Municipio, Snombre"


                            'frmVisor.SQLQuery = "SELECT     *  FROM vwSccResumenCreditosAprobadosRep" & _
                            '                          " WHERE(nStbMercadoVerificadoID <> 1) " & Trim(Filtro) & " OPTION (FORCE ORDER) " '' & "  GROUP BY Departamento, Municipio, Distrito"

                            frmVisor.SQLQuery = " SELECT     Departamento, Municipio, Distrito, nSclFichaNotificacionID, MontoSolicitado, nMontoCreditoAprobado, nStbDistritoID, nSclGrupoSolidarioID, " & _
                                                                            "nSclSociaID, nStbMercadoVerificadoID, dFechaNotificacion, sNombre, SesionDes, sNumSesion, nCoordinador, sCodigo, sDescripcion, NombreSocia, " & _
                                                                            "CodDistrito, Barrio, nStbDepartamentoID, nStbMunicipioID, nStbBarrioID, TotalCreditos, nFondoPresupuestario, sCodigoInterno, EstadoCheque, Fondo, " & _
                                                                            "nScnFuenteFinanciamientoID, sNombre1, sNombre2, sApellido1, sApellido2, sNumeroCedula, NumeroDelCredito, " & _
                                                                            " CASE WHEN NumeroDelCredito = 1 THEN 1 ELSE 0 END AS SociaPosicion " & _
                                                                            " FROM         (SELECT     vwUbicacion.Departamento, vwUbicacion.Municipio, vwUbicacion.Distrito, FNC.nSclFichaNotificacionID,  " & _
                                                                            " FI.nMontoCreditoVerificado AS MontoSolicitado, DFNC.nMontoCreditoAprobado, vwUbicacion.nStbDistritoID, GS.nSclGrupoSolidarioID, " & _
                                                                            " Socia.nSclSociaID, GS.nStbMercadoVerificadoID, FNC.dFechaNotificacion, Mercado.sNombre, FNC.sNumSesion AS SesionDes, " & _
                                                                            " FNC.sNumSesion, dbo.SclGrupoSocia.nCoordinador, GS.sCodigo, GS.sDescripcion,  " & _
                                                                            " Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia, vwUbicacion.CodDistrito, " & _
                                                                            " vwUbicacion.Barrio, vwUbicacion.nStbDepartamentoID, vwUbicacion.nStbMunicipioID, vwUbicacion.nStbBarrioID,  " & _
                                                                          " SociaCreditos.TotalCreditos, dbo.ScnFuenteFinanciamiento.nFondoPresupuestario, dbo.StbValorCatalogo.sCodigoInterno, " & _
                                                                          "dbo.StbValorCatalogo.sDescripcion AS EstadoCheque, CASE WHEN dbo.ScnFuenteFinanciamiento.nFondoPresupuestario IS NOT NULL " & _
                                                                          " THEN dbo.ScnFuenteFinanciamiento.nFondoPresupuestario ELSE - 1 END AS Fondo, " & _
                                                                          " dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID, Socia.sNombre1, Socia.sNombre2, Socia.sApellido1, Socia.sApellido2, " & _
                                                                          " Socia.sNumeroCedula, ROW_NUMBER() OVER (PARTITION BY Socia.nSclSociaID " & _
                                                                          " ORDER BY FNC.dFechaNotificacion ASC) AS NumeroDelCredito " & _
                                                                          " FROM         dbo.StbValorCatalogo INNER JOIN " & _
                                                                          "dbo.SccSolicitudDesembolsoCredito INNER JOIN " & _
                                                  "dbo.SccSolicitudCheque ON " & _
                                                  " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                                                  " dbo.ScnFuenteFinanciamiento ON " & _
                                                  " dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID ON " & _
                                                  " dbo.StbValorCatalogo.nStbValorCatalogoID = dbo.SccSolicitudCheque.nStbEstadoSolicitudID RIGHT OUTER JOIN " & _
                                                  " dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                                                  " dbo.SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " & _
                                                  " (SELECT     dbo.SclGrupoSolidario.nSclGrupoSolidarioID,  dbo.SclGrupoSolidario.nStbBarrioVerificadoID ,dbo.SclGrupoSolidario.nStbMercadoVerificadoID, dbo.SclGrupoSolidario.sCodigo, " & _
"                       dbo.SclGrupoSolidario.sDescripcion, CASE WHEN dbo.SclTipodePlandeNegocio.nCodigo > 2 THEN 2 ELSE 1 END AS TipoPrograma " & _
"  FROM         dbo.SclGrupoSolidario INNER JOIN " & _
"                      dbo.SclTipodePlandeNegocio ON dbo.SclGrupoSolidario.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID )" & _
                                                  "  AS GS ON FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                                                  " dbo.SclFichaSocia AS FI ON DFNC.nSclFichaSociaID = FI.nSclFichaSociaID INNER JOIN " & _
                                                  " dbo.SclGrupoSocia ON GS.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID AND " & _
                                                  " FI.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                                  " dbo.SclSocia AS Socia ON dbo.SclGrupoSocia.nSclSociaID = Socia.nSclSociaID INNER JOIN " & _
                                                  " dbo.StbValorCatalogo AS CNegocio ON FI.nStbActividadEconomicaVerificadaID = CNegocio.nStbValorCatalogoID INNER JOIN " & _
                                                  " dbo.StbValorCatalogo AS CTipoPlazo ON DFNC.nStbTipoPlazoAprobadoID = CTipoPlazo.nStbValorCatalogoID INNER JOIN " & _
                                                  " dbo.vwStbUbicacionGeografica AS vwUbicacion ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID INNER JOIN " & _
                                                  " dbo.StbMercado AS Mercado ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID INNER JOIN " & _
                                                  " dbo.vwStbEmpleado ON FNC.nSrhEmpleadoComite1ID = dbo.vwStbEmpleado.nSrhEmpleadoID INNER JOIN " & _
                                                  " dbo.vwStbEmpleado AS vwStbEmpleado_1 ON FNC.nSrhEmpleadoComite2ID = vwStbEmpleado_1.nSrhEmpleadoID INNER JOIN " & _
                                                  " dbo.vwStbEmpleado AS vwStbEmpleado_2 ON FNC.nSrhEmpleadoComite3ID = vwStbEmpleado_2.nSrhEmpleadoID INNER JOIN " & _
                                                  " dbo.StbValorCatalogo AS EstadoFNC ON FNC.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID INNER JOIN " & _
                                                  "    (SELECT     dbo.SclSocia.nSclSociaID, COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS TotalCreditos " & _
                                                   "     FROM          dbo.SclSocia INNER JOIN " & _
                                                  "                             dbo.SclGrupoSocia AS SclGrupoSocia_1 ON dbo.SclSocia.nSclSociaID = SclGrupoSocia_1.nSclSociaID INNER JOIN " & _
                                                  "                             dbo.SclFichaSocia ON SclGrupoSocia_1.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
                                                  "                             dbo.SclFichaNotificacionDetalle ON dbo.SclFichaSocia.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN " & _
                                                  "                             dbo.SclFichaNotificacionCredito ON  " & _
                                                  "                             dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                                                  "                             dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  " & _
                                                   "     dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                                                    "    WHERE      (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (StbValorCatalogo_1.sCodigoInterno = '2') " & _
                                                     "   GROUP BY dbo.SclSocia.nSclSociaID) AS SociaCreditos ON Socia.nSclSociaID = SociaCreditos.nSclSociaID ON  " & _
                                                      "  dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " & _
                            " WHERE     (EstadoFNC.sCodigoInterno = '2') AND (DFNC.nCreditoRechazado = 0) And nStbMercadoVerificadoID <> 1" & Trim(Filtro) & _
                            String.Format(" AND nCooperativa ={0} )", IIf(Me.rdoCooperativa.Checked, 1, 0)) & " AS ListadoCredito " & SubCadFiltro & " OPTION (FORCE ORDER)"




                            frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)
                        Case 4
                            frmVisor.Parametros("@TipoAsociacion") = IIf(Me.rdoCooperativa.Checked, "'Cooperativa'", "'Mercado'")
                            frmVisor.NombreReporte = "RepSccCC5.rpt"
                            frmVisor.Text = "Reporte de Cr�ditos Denegados por " & IIf(Me.rdoCooperativa.Checked, "Cooperativa", "Mercado")
                            frmVisor.SQLQuery = "SELECT     Departamento, Municipio, sNombre, COUNT(DISTINCT nSclFichaNotificacionId) AS TotalGrupos, COUNT(nSclSociaID) AS TotalSocias, " & _
                                                "   SUM(MontoSolicitado) AS MontoDenegado  FROM dbo.vwSccResumenCreditosDenegadosRep WHERE     (nStbMercadoVerificadoID <> 1) " & String.Format(" AND ( nCooperativa ={0} )", IIf(Me.rdoCooperativa.Checked, 1, 0)) & Trim(Filtro) & "  GROUP BY Departamento, Municipio, Snombre"

                        Case 5
                            frmVisor.NombreReporte = "RepSccCC6.rpt"
                            frmVisor.Text = "Reporte de Cr�ditos Aprobados por Acta"
                            'frmVisor.SQLQuery = "SELECT     TOP (100) PERCENT Departamento, Municipio, sNumSesion AS ActaNumero,COUNT(DISTINCT nSclSociaID) AS TotalSociasUnica, COUNT(nSclSociaID) AS TotalSocias, " & _
                            '                    " COUNT(DISTINCT nSclFichaNotificacionId) AS TotalGrupos, SUM(MontoSolicitado) AS TotalMontoSolicitado, SUM(nMontoCreditoAprobado)   AS TotalMontoCreditoAprobado " & _
                            '                    " FROM dbo.vwSccResumenCreditosAprobadosRep " & Trim(Filtro) & "  GROUP BY Departamento, Municipio, sNumSesion  ORDER BY Departamento, Municipio, sNumSesion "
                            'frmVisor.SQLQuery = "SELECT     *  FROM vwSccResumenCreditosAprobadosRep " & _
                            '    Trim(Filtro) & " OPTION (FORCE ORDER) " '' & "  GROUP BY Departamento, Municipio, Distrito"
                            frmVisor.SQLQuery = " SELECT     Departamento, Municipio, Distrito, nSclFichaNotificacionID, MontoSolicitado, nMontoCreditoAprobado, nStbDistritoID, nSclGrupoSolidarioID, " & _
                                                                            "nSclSociaID, nStbMercadoVerificadoID, dFechaNotificacion, sNombre, SesionDes, sNumSesion, nCoordinador, sCodigo, sDescripcion, NombreSocia, " & _
                                                                            "CodDistrito, Barrio, nStbDepartamentoID, nStbMunicipioID, nStbBarrioID, TotalCreditos, nFondoPresupuestario, sCodigoInterno, EstadoCheque, Fondo, " & _
                                                                            "nScnFuenteFinanciamientoID, sNombre1, sNombre2, sApellido1, sApellido2, sNumeroCedula, NumeroDelCredito, " & _
                                                                            " CASE WHEN NumeroDelCredito = 1 THEN 1 ELSE 0 END AS SociaPosicion " & _
                                                                            " FROM         (SELECT     vwUbicacion.Departamento, vwUbicacion.Municipio, vwUbicacion.Distrito, FNC.nSclFichaNotificacionID,  " & _
                                                                            " FI.nMontoCreditoVerificado AS MontoSolicitado, DFNC.nMontoCreditoAprobado, vwUbicacion.nStbDistritoID, GS.nSclGrupoSolidarioID, " & _
                                                                            " Socia.nSclSociaID, GS.nStbMercadoVerificadoID, FNC.dFechaNotificacion, Mercado.sNombre, FNC.sNumSesion AS SesionDes, " & _
                                                                            " FNC.sNumSesion, dbo.SclGrupoSocia.nCoordinador, GS.sCodigo, GS.sDescripcion,  " & _
                                                                            " Socia.sNombre1 + ' ' + Socia.sNombre2 + ' ' + Socia.sApellido1 + ' ' + Socia.sApellido2 AS NombreSocia, vwUbicacion.CodDistrito, " & _
                                                                            " vwUbicacion.Barrio, vwUbicacion.nStbDepartamentoID, vwUbicacion.nStbMunicipioID, vwUbicacion.nStbBarrioID,  " & _
                                                                          " SociaCreditos.TotalCreditos, dbo.ScnFuenteFinanciamiento.nFondoPresupuestario, dbo.StbValorCatalogo.sCodigoInterno, " & _
                                                                          "dbo.StbValorCatalogo.sDescripcion AS EstadoCheque, CASE WHEN dbo.ScnFuenteFinanciamiento.nFondoPresupuestario IS NOT NULL " & _
                                                                          " THEN dbo.ScnFuenteFinanciamiento.nFondoPresupuestario ELSE - 1 END AS Fondo, " & _
                                                                          " dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID, Socia.sNombre1, Socia.sNombre2, Socia.sApellido1, Socia.sApellido2, " & _
                                                                          " Socia.sNumeroCedula, ROW_NUMBER() OVER (PARTITION BY Socia.nSclSociaID " & _
                                                                          " ORDER BY FNC.dFechaNotificacion ASC) AS NumeroDelCredito " & _
                                                                          " FROM         dbo.StbValorCatalogo INNER JOIN " & _
                                                                          "dbo.SccSolicitudDesembolsoCredito INNER JOIN " & _
                                                  "dbo.SccSolicitudCheque ON " & _
                                                  " dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                                                  " dbo.ScnFuenteFinanciamiento ON " & _
                                                  " dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID ON " & _
                                                  " dbo.StbValorCatalogo.nStbValorCatalogoID = dbo.SccSolicitudCheque.nStbEstadoSolicitudID RIGHT OUTER JOIN " & _
                                                  " dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                                                 " dbo.SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " & _
                                                 " (SELECT     dbo.SclGrupoSolidario.nSclGrupoSolidarioID,  dbo.SclGrupoSolidario.nStbBarrioVerificadoID ,dbo.SclGrupoSolidario.nStbMercadoVerificadoID, dbo.SclGrupoSolidario.sCodigo, " & _
"                       dbo.SclGrupoSolidario.sDescripcion, CASE WHEN dbo.SclTipodePlandeNegocio.nCodigo > 2 THEN 2 ELSE 1 END AS TipoPrograma " & _
"  FROM         dbo.SclGrupoSolidario INNER JOIN " & _
"                      dbo.SclTipodePlandeNegocio ON dbo.SclGrupoSolidario.nSclTipodePlandeNegocioID = dbo.SclTipodePlandeNegocio.nSclTipodePlandeNegocioID )" & _
                                                  " AS GS ON FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                                                  " dbo.SclFichaSocia AS FI ON DFNC.nSclFichaSociaID = FI.nSclFichaSociaID INNER JOIN " & _
                                                  " dbo.SclGrupoSocia ON GS.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID AND " & _
                                                  " FI.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN " & _
                                                  " dbo.SclSocia AS Socia ON dbo.SclGrupoSocia.nSclSociaID = Socia.nSclSociaID INNER JOIN " & _
                                                  " dbo.StbValorCatalogo AS CNegocio ON FI.nStbActividadEconomicaVerificadaID = CNegocio.nStbValorCatalogoID INNER JOIN " & _
                                                  " dbo.StbValorCatalogo AS CTipoPlazo ON DFNC.nStbTipoPlazoAprobadoID = CTipoPlazo.nStbValorCatalogoID INNER JOIN " & _
                                                  " dbo.vwStbUbicacionGeografica AS vwUbicacion ON GS.nStbBarrioVerificadoID = vwUbicacion.nStbBarrioID INNER JOIN " & _
                                                  " dbo.StbMercado AS Mercado ON GS.nStbMercadoVerificadoID = Mercado.nStbMercadoID INNER JOIN " & _
                                                  " dbo.vwStbEmpleado ON FNC.nSrhEmpleadoComite1ID = dbo.vwStbEmpleado.nSrhEmpleadoID INNER JOIN " & _
                                                  " dbo.vwStbEmpleado AS vwStbEmpleado_1 ON FNC.nSrhEmpleadoComite2ID = vwStbEmpleado_1.nSrhEmpleadoID INNER JOIN " & _
                                                  " dbo.vwStbEmpleado AS vwStbEmpleado_2 ON FNC.nSrhEmpleadoComite3ID = vwStbEmpleado_2.nSrhEmpleadoID INNER JOIN " & _
                                                  " dbo.StbValorCatalogo AS EstadoFNC ON FNC.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID INNER JOIN " & _
                                                  "    (SELECT     dbo.SclSocia.nSclSociaID, COUNT(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS TotalCreditos " & _
                                                   "     FROM          dbo.SclSocia INNER JOIN " & _
                                                  "                             dbo.SclGrupoSocia AS SclGrupoSocia_1 ON dbo.SclSocia.nSclSociaID = SclGrupoSocia_1.nSclSociaID INNER JOIN " & _
                                                  "                             dbo.SclFichaSocia ON SclGrupoSocia_1.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
                                                  "                             dbo.SclFichaNotificacionDetalle ON dbo.SclFichaSocia.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN " & _
                                                  "                             dbo.SclFichaNotificacionCredito ON  " & _
                                                  "                             dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                                                  "                             dbo.StbValorCatalogo AS StbValorCatalogo_1 ON  " & _
                                                   "     dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                                                    "    WHERE      (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (StbValorCatalogo_1.sCodigoInterno = '2') " & _
                                                     "   GROUP BY dbo.SclSocia.nSclSociaID) AS SociaCreditos ON Socia.nSclSociaID = SociaCreditos.nSclSociaID ON  " & _
                                                      "  dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " & _
                            " WHERE     (EstadoFNC.sCodigoInterno = '2') AND (DFNC.nCreditoRechazado = 0) " & Trim(Filtro) & ") AS ListadoCredito  " & SubCadFiltro & " OPTION (FORCE ORDER)"





                            frmVisor.Formulas("Consolidado") = IIf(radConsolidado.Checked, 1, 0)
                        Case 6
                            frmVisor.NombreReporte = "RepSccCC7.rpt"
                            frmVisor.Text = "Reporte de Cr�ditos Denegados por Acta"
                            frmVisor.SQLQuery = "SELECT     Departamento, Municipio, sNumSesion AS ActaNumero, COUNT(DISTINCT nSclFichaNotificacionId) AS TotalGrupos, COUNT(nSclSociaID) AS TotalSocias, " & _
                                                " SUM(MontoSolicitado) AS MontoDenegado  FROM dbo.vwSccResumenCreditosDenegadosRep " & Trim(Filtro) & "  GROUP BY Departamento, Municipio, sNumSesion  ORDER BY Departamento, Municipio, sNumSesion "

                    End Select


                    'frmVisor.Formulas("RangoFecha") = "' " & _
                    '                                   IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", ""))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " DEL " & cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    If TipoReporte = 1 Or TipoReporte = 3 Or TipoReporte = 5 Then
                        frmVisor.Formulas("RangoFecha") = "' DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    Else
                        frmVisor.Formulas("RangoFecha") = "' TODAS LAS FUENTES DE FINANCIAMIENTO DEL " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " AL " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"  '"  ' Al :" & CdeFechaFinal.Value
                    End If


                    frmVisor.Formulas("Fuente") = "' " & _
                                                       IIf(radFondos.Checked = True, IIf(RdPresupuesto.Checked, "CON FONDOS DEL PRESUPUESTO ", IIf(RdExterno.Checked, "CON FONDOS EXTERNOS", IIf(Me.RdSinFuente.Checked, "SIN FUENTE ASIGNADA", "TODAS LAS FUENTES DE FINANCIAMIENTO "))), IIf(Me.CboFuentes.SelectedIndex > 0, " CON FUENTE :" & Me.CboFuentes.Columns("sNombre").Value, "TODAS LAS FUENTES DE FINANCIAMIENTO ")) & " '"  '"  ' Al :" & CdeFechaFinal.Value


                    'Else ' Detalle 

            End Select 'Select Case mNomRep

            'End If

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'frmVisor.Close()    'Estaba entre comentario
            'frmVisor.Dispose()
            frmVisor = Nothing
        End Try
    End Sub
    Private Function TipoFondo(ByVal XFiltro As String) As String
        Dim SubCadFiltro As String = ""
        '' ''Select Case CboVeces.SelectedIndex
        '' ''    Case 0
        '' ''        SubCadFiltro = ""
        '' ''    Case 1, 2, 3
        '' ''        SubCadFiltro = "TotalCreditos=" & CboVeces.SelectedIndex & " "
        '' ''    Case 4
        '' ''        SubCadFiltro = "TotalCreditos>=4 "
        '' ''End Select
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
            CboVeces.AddItem("Al menos Un Cr�dito")
            CboVeces.AddItem("Solo Un Cr�dito")
            CboVeces.AddItem("Dos Cr�ditos")
            CboVeces.AddItem("Tres Cr�ditos")
            CboVeces.AddItem("Cuatro Cr�ditos o m�s")
            CboVeces.Columns(0).Caption = ""

        Else
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

            'XdtEstados.Close()
            'XdtEstados = Nothing

            XdsCombos.Close()
            XdsCombos = Nothing

            'XdtPertenece.Close()
            'XdtPertenece = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaraci�n de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            ObjGUI.SetFormLayout(Me, Me.mColorVentana)

            If mNomRep = 0 Or mNomRep = 2 Or mNomRep = 5 Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes M�dulo de Control de Cr�dito")
            ElseIf mNomRep = 3 Then
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes M�dulo de Control de Socias")
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

    Private Sub frmSccParametroResumenCreditos_Scroll(ByVal sender As Object, ByVal e As System.Windows.Forms.ScrollEventArgs) Handles Me.Scroll

    End Sub

    Private Sub frmSccParametroResumenCreditos_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        grpReporte.Enabled = False
        grpFondooFuente.Enabled = False
        grpPrograma.Visible = False
        Select Case mNomRep

            Case EnumReportes.Detalle
                Me.Text = "Par�metros del Detalle de Cr�ditos"
                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Visible = False
                Me.grpPrograma.Visible = True
            Case EnumReportes.NivelAcademico
                Me.Text = "Par�metros de Detalle de Socias Por Nivel Acad�mico"
                RdActas.Text = "Todos"
                grpAprobadoODenegado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True

                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Visible = False
                RdSinFuente.Enabled = False

            Case EnumReportes.Estadistico
                Me.Text = "Par�metros del Reporte Estad�stico"
                RdActas.Text = "Todos"
                grpAprobadoODenegado.Enabled = False
                grpDistritoOMercado.Enabled = False
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True
                Me.grpVeces.Enabled = False
            Case EnumReportes.EstadisticaDesembolso
                Me.Text = "Par�metros del Reporte Estad�stico de distribuci�n cr�dito"
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
                Me.Text = "Par�metros del Reporte Estad�stico de distribuci�n cr�dito"
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




                'Me.GrpPeriodo.Visible = True



            Case EnumReportes.NuncaPagado

                Me.Text = "Par�metros del Reporte de Nunca Pagados"
                RdActas.Text = "Todos"
                grpAprobadoODenegado.Enabled = False
                grpDistritoOMercado.Enabled = False
                Me.cdeFechaInicial.Enabled = False
                Me.CdeFechaFinal.Enabled = True
                Me.grpVeces.Enabled = False
                Me.GrpPeriodo.Visible = False
                Me.grpFuente.Enabled = True
                Me.grpPrograma.Visible = True
            Case EnumReportes.ComportamientoDeMora
                grpReporte.Enabled = False
                Me.Text = "Par�metros del Reporte de Comportamiento de Mora"
                grpFondooFuente.Enabled = True
                grpPrograma.Visible = True
            Case Else
                Me.GrpPeriodo.Visible = False
                Me.Text = "Par�metros del Reporte de Resumen de Cr�ditos"
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
    End Sub

    Private Sub grpFuente_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpFuente.Enter

    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdExterno.CheckedChanged

    End Sub

    Private Sub RdDenegado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdDenegado.CheckedChanged
        If IsDBNull(mNomRep) Or mNomRep = 0 Then ' Or mNomRep = EnumReportes.Detalle Then
            RdTodos.Checked = True
            grpFuente.Enabled = False
            grpReporte.Enabled = False
            grpFondooFuente.Enabled = False
        End If
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

            Me.CboFuentes.Columns("sCodigo").Caption = "C�digo"
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


