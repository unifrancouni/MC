
Imports System.Data.SqlClient
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms.VisualStyles
Imports Infragistics.Win
Imports System.IO
Imports BOSistema.Win

' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                19/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnParametroEstadosFinancieros.vb
' Descripción:          Este formulario muestra Parámetros para la emisión
'                       de Estados Financieros.
'-------------------------------------------------------------------------
Public Class frmScnParametroEstadosFinancieros

    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim mNomRep As EnumReportes

    Public LlamadoDesde As eLlamado

    'Llamado Desde.
    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes.
    Public Enum EnumReportes
        EstadoResultados = 1
        BalanceGeneral = 2
        EstadoDisponibilidad = 3
    End Enum

    'Nombre del Reporte.
    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/02/2008
    ' Procedure Name:       frmScnParametroEstadosFinancieros_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables.
    '-------------------------------------------------------------------------
    Private Sub frmScnParametroEstadosFinancieros_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Inicializar:
            XdsCombos = New BOSistema.Win.XDataSet
            CargarFuente()
            'Tres Firmas (Empleados del Programa):
            CargarFirmas(35, "FirmaUno")     'Contador
            CargarFirmas(28, "FirmaDos")     'Responsable de Gestión de Recursos
            CargarFirmas(11, "FirmaTres")    'Director General del Programa
            Me.grpFondos.Enabled = False

            If NomRep = 1 Or NomRep = 2 Then
                GroupBox1.Visible = True
            Else
                GroupBox1.Visible = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/02/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Evento permite salir del formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/02/2008
    ' Procedure Name:       CargarFirmas
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados sugiriendo el empleado registrado en 
    '                       parámetros para primer, segunda y tercer firma:
    '                       intParametroID = 35 (Firma1); StrNombre = FirmaUno
    '                       intParametroID = 28 (Firma2); StrNombre = FirmaDos
    '                       intParametroID = 11 (Firma3); StrNombre = FirmaTres
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intParametroID As Integer, ByVal StrNombre As String)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try

            Dim Strsql As String

            If intParametroID = 35 Then 'Contador
                Me.cboFirma1.ClearFields()
            ElseIf intParametroID = 28 Then 'Responsable de Gestión de Recursos
                Me.cboFirma2.ClearFields()
            Else 'Director General del Programa
                Me.cboFirma3.ClearFields()
            End If

            'If intEmpleadoID = 0 Then
            Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                     " From vwStbEmpleado a " & _
                     " Where (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                     " Order by a.nCodPersona"
            'Else
            'Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
            '         " From vwStbEmpleado a " & _
            '         " Where ((a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
            '         " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
            '         " Order by a.nCodPersona"
            'End If

            If XdsCombos.ExistTable(StrNombre) Then
                XdsCombos(StrNombre).ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, StrNombre)
                XdsCombos(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos:
            If intParametroID = 35 Then
                Me.cboFirma1.DataSource = XdsCombos(StrNombre).Source
                Me.cboFirma1.Rebind()
            ElseIf intParametroID = 28 Then
                Me.cboFirma2.DataSource = XdsCombos(StrNombre).Source
                Me.cboFirma2.Rebind()
            Else
                Me.cboFirma3.DataSource = XdsCombos(StrNombre).Source
                Me.cboFirma3.Rebind()
            End If

            XdtValorParametro.Filter = "nStbParametroID = " & intParametroID
            XdtValorParametro.Retrieve()

            'Ubicarse en el registro recomendado de parámetros:
            If XdsCombos(StrNombre).Count > 0 Then
                XdsCombos(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo: 
            If intParametroID = 35 Then
                Me.cboFirma1.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma1.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma1.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma1.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma1.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ElseIf intParametroID = 28 Then
                Me.cboFirma2.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma2.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma2.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma2.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma2.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboFirma3.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma3.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma3.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/02/2008
    ' Procedure Name:       CargarFuente
    ' Descripción:          Carga listado de Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuente()
        Try

            Dim Strsql As String
            Strsql = " Select a.nScnFuenteFinanciamientoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From ScnFuenteFinanciamiento a " & _
                     " Order by a.sCodigo"


            If XdsCombos.ExistTable("Fuente") Then
                XdsCombos("Fuente").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Fuente")
                XdsCombos("Fuente").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            cboFuentes.DataSource = XdsCombos("Fuente").Source

            'Configurar Combo:
            Me.cboFuentes.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuentes.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").Width = 60
            Me.cboFuentes.Splits(0).DisplayColumns("Descripcion").Width = 305

            Me.cboFuentes.Columns("sCodigo").Caption = "Código"
            Me.cboFuentes.Columns("Descripcion").Caption = "Descripción"

            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuentes.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Ubicarlo en el primer registro:
            If Me.cboFuentes.ListCount > 0 Then
                XdsCombos("Fuente").AddRow()
                XdsCombos("Fuente").ValueField("Descripcion") = "TODAS"
                XdsCombos("Fuente").ValueField("nScnFuenteFinanciamientoID") = -19
                XdsCombos("Fuente").ValueField("Orden") = 0
                XdsCombos("Fuente").UpdateLocal()
                XdsCombos("Fuente").Sort = "Orden,sCodigo asc"
                Me.cboFuentes.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/02/2008
    ' Procedure Name:       cmdAceptar_Click
    ' Descripción:          Genera Estado Financiero.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim frmScnObservacion As New frmScnObservacionesConsolidado
        Dim DescripcionReporte As String
        Dim CadSql As String
        Dim UltimoPeriodoCerrado, PeriodoDeFechaFinal, PeriodoDeFechaInicial As Integer
        Dim FechaInicioMenosUnDia As Date
        Dim FechaUltimoPeriodoCerrado As Date
        Dim Fuentes As Integer
        Dim Fondos As Integer
        Dim XdtTmpPeriodoA As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        XdtTmpPeriodoA = New BOSistema.Win.XDataSet.xDataTable

        Try

            If ValidarParametros() = False Then Exit Sub
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
            frmVisor.Formulas("Indice") = IIf(RdCordoba.Checked = True, 1, 0)
            frmVisor.Formulas("EmpleadoElabora") = "'" & cboFirma1.Text & "'"
            frmVisor.Formulas("EmpleadoRevisa") = "'" & cboFirma2.Text & "'"
            frmVisor.Formulas("EmpleadoAutoriza") = "'" & cboFirma3.Text & "'"
            If chkConsolida.Checked = True Then
                If Me.RdPresupuestarios.Checked Then
                    frmVisor.Formulas("DesFuente") = "'Fondos Presupuestarios'"
                ElseIf Me.RdExternos.Checked Then
                    frmVisor.Formulas("DesFuente") = "'Fondos Externos'"
                Else
                    frmVisor.Formulas("DesFuente") = "'Todos los Fondos'"
                End If
            End If

            CadSql = "SELECT C.sNombreCargo FROM SrhCargo C INNER JOIN SrhEmpleado E ON C.nSrhCargoID = E.nSrhCargoID WHERE (E.nSrhEmpleadoID = " & cboFirma1.Columns("nSrhEmpleadoID").Value & ")"
            frmVisor.Formulas("CargoElabora") = "'" & XcDatos.ExecuteScalar(CadSql) & "'"

            CadSql = "SELECT C.sNombreCargo FROM SrhCargo C INNER JOIN SrhEmpleado E ON C.nSrhCargoID = E.nSrhCargoID WHERE (E.nSrhEmpleadoID = " & cboFirma2.Columns("nSrhEmpleadoID").Value & ")"
            frmVisor.Formulas("CargoRevisa") = "'" & XcDatos.ExecuteScalar(CadSql) & "'"

            CadSql = "SELECT C.sNombreCargo FROM SrhCargo C INNER JOIN SrhEmpleado E ON C.nSrhCargoID = E.nSrhCargoID WHERE (E.nSrhEmpleadoID = " & cboFirma3.Columns("nSrhEmpleadoID").Value & ")"
            frmVisor.Formulas("CargoAutoriza") = "'" & XcDatos.ExecuteScalar(CadSql) & "'"

            Select Case mNomRep

                Case EnumReportes.EstadoResultados, EnumReportes.BalanceGeneral, EnumReportes.EstadoDisponibilidad

                    'Encuentra último período cerrado en forma definitiva: 
                    CadSql = " SELECT MAX(ScnPeriodoContable.nScnPeriodoContableID) AS PeriodoMaximoCerrado " & _
                             " FROM ScnPeriodoContable INNER JOIN StbValorCatalogo ON ScnPeriodoContable.nStbEstadoPeriodoID = StbValorCatalogo.nStbValorCatalogoID " & _
                             " WHERE (StbValorCatalogo.sCodigoInterno = '3')"
                    XdtTmpPeriodoA.ExecuteSql(CadSql)
                    If XdtTmpPeriodoA.Count = 0 Then
                        UltimoPeriodoCerrado = 1
                    Else
                        If IsDBNull(XcDatos.ExecuteScalar(CadSql)) Then
                            CadSql = " SELECT TOP (1) ScnPeriodoContable.nScnPeriodoContableID AS PeriodoInicio " & _
                                     " FROM ScnPeriodoContable INNER JOIN StbValorCatalogo ON ScnPeriodoContable.nStbEstadoPeriodoID = StbValorCatalogo.nStbValorCatalogoID "
                        End If
                        UltimoPeriodoCerrado = XcDatos.ExecuteScalar(CadSql)
                    End If

                    'Encuentra Parámetros restantes:
                    PeriodoDeFechaFinal = IDPeriodo(Me.CdeFechaFinal.Value)

                    REM 1 *******************
                    'If UltimoPeriodoCerrado > PeriodoDeFechaFinal Then
                    'UltimoPeriodoCerrado = PeriodoDeFechaFinal
                    'End If
                    REM 1 *******************
                    REM 2 ******************* 
                    PeriodoDeFechaInicial = IDPeriodo(Me.cdeFechaInicial.Value)
                    If UltimoPeriodoCerrado > PeriodoDeFechaInicial Then
                        UltimoPeriodoCerrado = PeriodoDeFechaInicial
                    End If
                    REM 2 ****************** 

                    If mNomRep = EnumReportes.EstadoResultados Then

                        If UltimoPeriodoCerrado = 1 Then
                            FechaUltimoPeriodoCerrado = FechaDadoPeriodoIdSigMes(UltimoPeriodoCerrado)
                        Else
                            FechaUltimoPeriodoCerrado = FechaDadoPeriodoIdSigMes(UltimoPeriodoCerrado + 1)
                        End If

                    Else
                        FechaUltimoPeriodoCerrado = FechaDadoPeriodoId(UltimoPeriodoCerrado)
                    End If


                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Fuentes = cboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                    Else
                        Fuentes = -1 'Todas las Fuentes.
                    End If
                    FechaInicioMenosUnDia = DateAdd(DateInterval.Day, -1, Me.cdeFechaInicial.Value)

                    'Determina Tipo de Fondos si es reporte Consolidado:
                    If chkConsolida.Checked = True Then
                        If Me.RdTodos.Checked Then
                            Fondos = -1 'Todos Los Fondos
                        ElseIf Me.RdPresupuestarios.Checked Then
                            Fondos = 1  'Solo Fondos Presupuestarios
                        Else
                            Fondos = 0  'Solo Fondos Externos
                        End If
                    Else
                        Fondos = -1
                    End If

                    'Asigna parámetros al Procedimiento Almacenado: 
                    frmVisor.Parametros("@UltimoPeriodoCerrado") = UltimoPeriodoCerrado
                    frmVisor.Parametros("@PeriodoDeFechaFinal") = PeriodoDeFechaFinal

                    'frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    'frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    'frmVisor.Parametros("@FechaInicioMenosUnDia") = Format(FechaInicioMenosUnDia, "yyyy-MM-dd HH:mm:ss")
                    'frmVisor.Parametros("@FechaUltimoPeriodoCerrado") = Format(FechaUltimoPeriodoCerrado, "yyyy-MM-dd HH:mm:ss")

                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd")
                    frmVisor.Parametros("@FechaInicioMenosUnDia") = Format(FechaInicioMenosUnDia, "yyyy-MM-dd")
                    frmVisor.Parametros("@FechaUltimoPeriodoCerrado") = Format(FechaUltimoPeriodoCerrado, "yyyy-MM-dd")

                    frmVisor.Parametros("@FuenteFinancieraId") = Fuentes
                    frmVisor.Parametros("@nTipoFondos") = Fondos
            End Select
           

            'Asigna nombre del Reporte: 
            Select Case mNomRep
                Case EnumReportes.EstadoResultados
                    If chkConsolida.Checked = True Then
                        frmVisor.NombreReporte = "RepScnCN18c.rpt"
                        frmVisor.Text = "Estado de Resultados Consolidado"
                        frmScnObservacion = New frmScnObservacionesConsolidado
                        DescripcionReporte = EnumReportes.EstadoResultados.ToString()
                    Else
                        If optNinguno.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN18.rpt"
                        ElseIf optCAnual.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN18_Anual.rpt"
                        ElseIf optCMensual.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN18_Mensual.rpt"
                        Else
                            frmVisor.NombreReporte = "RepScnCN18_Mensualizado.rpt"
                        End If
                        frmVisor.Text = "Estado de Resultados"
                    End If

                Case EnumReportes.BalanceGeneral
                        If chkConsolida.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN19c.rpt"
                            frmVisor.Text = "Balance General Consolidado"
                            frmScnObservacion = New frmScnObservacionesConsolidado
                            DescripcionReporte = EnumReportes.BalanceGeneral.ToString()
                    Else

                        If optNinguno.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN19.rpt"
                        ElseIf optCAnual.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN19_Anual.rpt"
                        ElseIf optCMensual.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN19_Mensual.rpt"
                        Else
                            frmVisor.NombreReporte = "RepScnCN19_Mensualizado.rpt"
                        End If

                        frmVisor.Text = "Balance General"
                        End If

                Case EnumReportes.EstadoDisponibilidad
                        'Parámetro Adicional para Consolidado (Para uso del Saldo Inicial Banco):
                        If chkConsolida.Checked = True Then
                            frmVisor.Parametros("@nConsolida") = 1
                        Else
                            frmVisor.Parametros("@nConsolida") = 0
                        End If
                        If chkConsolida.Checked = True Then
                            frmVisor.NombreReporte = "RepScnCN29c.rpt"
                            frmVisor.Text = "Estado de Disponibilidad Consolidado"
                        Else
                            frmVisor.NombreReporte = "RepScnCN29.rpt"
                            frmVisor.Text = "Estado de Disponibilidad"
                        End If

            End Select
            Dim DateFin As Date
            DateFin = DateAdd(DateInterval.Day, 1, Me.CdeFechaFinal.Value)
            'Asignar Observaciones a Reportes de Consolidados CN18 Y CN19
            If chkConsolida.Checked And Me.cdeFechaInicial.Value.Day() = 1 And DateFin.Day = 1 And Me.cdeFechaInicial.Value.Month() = Me.CdeFechaFinal.Value.Month() And Me.cdeFechaInicial.Value.Year() = Me.CdeFechaFinal.Value.Year() Then


                Dim dias As Integer
                dias = (Me.CdeFechaFinal.Value - Me.cdeFechaInicial.Value).totalDays
                'If dias >= 29 Then
                'Dim ObjComand As BOSistema.Win.XDataSet.xDataTable
                'Dim SQLstring As String


                'SQLstring = "Select nScnEstadoFinancieroObservacionID from ScnEstadoFinancieroObservacion where sDescripcion='" & DescripcionReporte & "'"
                'ObjComand = New BOSistema.Win.XDataSet.xDataTable
                'ObjComand.ExecuteSql(SQLstring)
                'If ObjComand.Count > 0 Then
                '    'frmScnObservacion.IdObservacion = Convert.ToInt32(ObjComand.Table.Rows(0).Item(0))
                '    frmScnObservacion.ModoFrm = "UPD" + cdeFechaInicial.Value.Month()

                'Else
                '    frmScnObservacion.ModoFrm = "ADD"
                'End If

                frmScnObservacion.Anio = Me.cdeFechaInicial.Value.Year()
                frmScnObservacion.Mes = Me.cdeFechaInicial.Value.Month()
                frmScnObservacion.TipoFondo = IIf(RdPresupuestarios.Checked, 0, IIf(Me.RdExternos.Checked, 1, 2))
                frmScnObservacion.EsBalance = IIf(mNomRep = EnumReportes.BalanceGeneral, 1, 0)

                'frmScnObservacion.SDescripcion = DescripcionReporte
                frmScnObservacion.ShowDialog()
                Dim CadObs As String
                CadObs = frmScnObservacion.sObservacion.Text
                frmVisor.Formulas("Observacion") = "'" & CadObs & "'"


                'frmVisor.Formulas("Observacion") = "''"

                'End If
            End If
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/02/2008
    ' Procedure Name:       ValidarParametros
    ' Descripción:          Valida parámetros de generación de los reportes.
    '-------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables: 
        Dim VbResultado As Boolean

        Try
            VbResultado = False

            'Debe indicar Fuente de Fondos:
            If Me.cboFuentes.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una fuente de financiamento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFuentes, "Debe seleccionar una fuente de financiamiento.")
                Me.cboFuentes.Focus()
                GoTo SALIR
            End If

            'Fecha de Inicio Valida:
            If IsDBNull(cdeFechaInicial.Value) Then
                MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            'Fecha de Corte Valida: 
            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If

            'Fecha de corte no menor que la de inicio:
            If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            'Primer Firma:
            If Me.cboFirma1.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Auxiliar Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFirma1, "Debe indicar nombre del Auxiliar Contable.")
                Me.cboFirma1.Focus()
                GoTo SALIR
            End If

            'Segunda Firma:
            If Me.cboFirma2.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Contador.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFirma2, "Debe indicar nombre del Contador.")
                Me.cboFirma2.Focus()
                GoTo SALIR
            End If

            'Tercer Firma:
            If Me.cboFirma3.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Responsable de Gestión de Recursos.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFirma3, "Debe indicar nombre del Responsable de Gestión de Recursos.")
                Me.cboFirma3.Focus()
                GoTo SALIR
            End If

            'Si es el Estado Financiero Consolidado, deben indicarse Todas las Fuentes:
            If (chkConsolida.Checked = True) And (cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19) Then
                MsgBox("Para el Informe Consolidado Debe seleccionar" & Chr(13) & "TODAS las fuentes de financiamento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFuentes, "Debe seleccionar TODAS las fuentes de financiamiento.")
                Me.cboFuentes.Focus()
                GoTo SALIR
            End If


            REM REM            
            'Si no es consolidado debe indicar una fuente especifica
            If (chkConsolida.Checked = False) And (cboFuentes.Columns("nScnFuenteFinanciamientoID").Value = -19) Then
                MsgBox("Debe seleccionar una fuente de financiamento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFuentes, "Debe seleccionar una fuente de financiamiento.")
                Me.cboFuentes.Focus()
                GoTo SALIR
            End If

            'Si es el Estado de Disponibilidad:
            'Correr para meses completos:
            If Me.NomRep = EnumReportes.EstadoDisponibilidad Then
                'Fecha de Inicio debe corresponder a primer dia de un mes
                If (Microsoft.VisualBasic.DateAndTime.Day(Me.cdeFechaInicial.Value)) <> 1 Then
                    MsgBox("Día de Fecha de Inicio no corresponde" & Chr(13) & "al primer día del mes.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Fecha de Inicio Inválida.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
                'Fecha de Corte debe corresponder a ultimo dia de un mes
                If (Microsoft.VisualBasic.DateAndTime.Day(Me.CdeFechaFinal.Value)) <> IntUltimoDiaMes(Month(Me.CdeFechaFinal.Value), Year(Me.CdeFechaFinal.Value)) Then
                    MsgBox("Día de Fecha de Corte no corresponde" & Chr(13) & "al último día del mes.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Fecha de Corte Inválida.")
                    Me.CdeFechaFinal.Focus()
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

    Private Sub chkConsolida_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkConsolida.CheckedChanged
        If chkConsolida.Checked Then
            Me.grpFondos.Enabled = True
            Me.GroupBox1.Enabled = False
            Me.optNinguno.Checked = True
        Else
            Me.grpFondos.Enabled = False
            Me.GroupBox1.Enabled = True
        End If
    End Sub
End Class