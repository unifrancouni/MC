'------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                10/06/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccParametrosIndicadores.vb
' Descripción:          Este formulario permite imprimir Cuadros de Indicadores
'                       del Programa.
'------------------------------------------------------------------------------
Public Class frmSccParametrosIndicadores

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet

    Dim Strsql As String

    Dim mColorVentana As String

    'Listado de Reportes:
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    'Llamado Desde:
    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes:
    Public Enum EnumReportes
        TablaCreditosAprobados = 1      'Tabla Indicadores No. 2
        TablaAvancesMetas = 2           'Tabla Indicadores No. 3
        TablaCreditosActividad = 3      'Tabla Indicadores No. 5
        TablaCreditosDepartamento = 4   'Tabla Indicadores No. 7
        VistaRecuperacionesReportadas = 5 ' Vista de las Recuperaciones
        VistaMinutasNoEnviadasaMHCP = 6   'Vista de las Minutas no Enviadas al Ministerio de Hacienda
        VistaRecibosNoEnviadosaMHCP = 7     'Vista de los Recibos no enviados al Ministerio de Hacienda
        VistaMinutasEnviadasyAhunNoAPlicadasporMHCP = 8     'Vista de las Minutas Enviadas a MHCP y que ahun NO se han Aplicado
        VistaRecuperacionesReportadasFiltradasPorFechaRecibo = 9    'Vista de las Recuperaciones Filtradas por Fechas de Recibos
    End Enum
    Public Property ColorVentana() As String
        Get
            Return mColorVentana
        End Get
        Set(ByVal value As String)
            mColorVentana = value
        End Set
    End Property
    'Nombre del Reporte:
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
    ' Fecha:                10/06/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdsCombos = New BOSistema.Win.XDataSet
            Me.CboEjercicio.Select()

            'Si es Informe Anual (Tablas 3,5):
            If (Me.NomRep = EnumReportes.TablaAvancesMetas) Or (Me.NomRep = EnumReportes.TablaCreditosActividad) Then
                Me.cdeFechaInicial.Enabled = False
                Me.CdeFechaFinal.Enabled = False
                'Si es Tabla 7: No Mostrar Ejercicios:
            ElseIf (Me.NomRep = EnumReportes.TablaCreditosDepartamento) Or (Me.NomRep = EnumReportes.VistaRecuperacionesReportadas) Or (Me.NomRep = EnumReportes.VistaMinutasNoEnviadasaMHCP) Or (Me.NomRep = EnumReportes.VistaRecibosNoEnviadosaMHCP) Or (Me.NomRep = EnumReportes.VistaMinutasEnviadasyAhunNoAPlicadasporMHCP) Or (Me.NomRep = EnumReportes.VistaRecuperacionesReportadasFiltradasPorFechaRecibo) Then
                Me.CboEjercicio.Enabled = False
                Me.cdeFechaInicial.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/06/2008
    ' Procedure Name:       CargarEjercicios
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Ejercicios Contables.
    '-------------------------------------------------------------------------
    Private Sub CargarEjercicios()
        Try
            Dim Strsql As String

            Strsql = " SELECT nScnEjercicioContableID, YEAR(dFechaInicio) AS Anio, sDescripcion, dFechaInicio, dFechaFin, nCerrado " & _
                     " FROM ScnEjercicioContable " & _
                     " Order By nScnEjercicioContableId"

            If XdsCombos.ExistTable("Ejercicios") Then
                XdsCombos("Ejercicios").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Ejercicios")
                XdsCombos("Ejercicios").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.CboEjercicio.DataSource = XdsCombos("Ejercicios").Source
            Me.CboEjercicio.Splits(0).DisplayColumns("nScnEjercicioContableID").Visible = False
            Me.CboEjercicio.Splits(0).DisplayColumns("nCerrado").Visible = False
            Me.CboEjercicio.Splits(0).DisplayColumns("dFechaInicio").Visible = False
            Me.CboEjercicio.Splits(0).DisplayColumns("dFechaFin").Visible = False

            Me.CboEjercicio.Splits(0).DisplayColumns("Anio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboEjercicio.Splits(0).DisplayColumns("sDescripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo:  
            Me.CboEjercicio.Splits(0).DisplayColumns("Anio").Width = 45
            Me.CboEjercicio.Splits(0).DisplayColumns("sDescripcion").Width = 200

            Me.CboEjercicio.Columns("Anio").Caption = "Año"
            Me.CboEjercicio.Columns("sDescripcion").Caption = "Descripción"

            Me.CboEjercicio.Splits(0).DisplayColumns("Anio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboEjercicio.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/06/2008
    ' Procedure Name:       ValidarParametros
    ' Descripción:          Este procedimiento permite validar los parámetros
    '                       de corte indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        Try

            VbResultado = False
            Me.errParametro.Clear()

            'Ejercicio:
            If Me.CboEjercicio.Enabled = True Then
                If Me.CboEjercicio.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Ejercicio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboEjercicio, "Debe seleccionar un Ejercicio válido.")
                    Me.CboEjercicio.Focus()
                    GoTo SALIR
                End If
            End If

            'Fecha de Inicio:
            If IsDBNull(cdeFechaInicial.Value) Then
                MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            'Fecha de Corte:
            If IsDBNull(CdeFechaFinal.Value) Then
                MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                Me.CdeFechaFinal.Focus()
                GoTo SALIR
            End If


            If Me.CboEjercicio.Enabled = True Then
                'Año de la Fecha Inicial debe corresponder con el año del Ejercicio:
                If Int(Year(cdeFechaInicial.Value)) <> Int(CboEjercicio.Columns("Anio").Value) Then
                    MsgBox("Rango de Fechas debe estar dentro del año seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Rango de Fechas debe estar dentro del año seleccionado.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
                'Año de la Fecha Final debe corresponder con el año del Ejercicio:
                If Int(Year(CdeFechaFinal.Value)) <> Int(CboEjercicio.Columns("Anio").Value) Then
                    MsgBox("Rango de Fechas debe estar dentro del año seleccionado.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Rango de Fechas debe estar dentro del año seleccionado.")
                    Me.CdeFechaFinal.Focus()
                    GoTo SALIR
                End If
                'Fecha Inicial debe corresponder con el primer dia de un mes:
                If Int(Microsoft.VisualBasic.DateAndTime.Day(cdeFechaInicial.Value)) <> 1 Then
                    MsgBox("Fecha Inicial debe corresponder con el primer dia del mes.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Fecha Inicial debe corresponder con el primer dia del mes.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
                'Fecha de Corte debe corresponder con el ultimo dia de un mes:
                If Int(Microsoft.VisualBasic.DateAndTime.Day(CdeFechaFinal.Value)) <> IntUltimoDiaMes(Month(CdeFechaFinal.Value), Year(CdeFechaFinal.Value)) Then
                    MsgBox("Fecha Final debe corresponder con el último dia del mes.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Fecha Final debe corresponder con el último dia del mes.")
                    Me.CdeFechaFinal.Focus()
                    GoTo SALIR
                End If
            End If

            'Fecha de Corte no menor que Fecha Inicial:
            If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                Me.cdeFechaInicial.Focus()
                GoTo SALIR
            End If

            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/06/2008
    ' Procedure Name:       cmdAceptar_Click
    ' Descripción:          Este procedimiento permite generar el reporte
    '                       indicado por el usuario.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
       
        Try

            If ValidarParametros() = False Then Exit Sub
            frmVisor.WindowState = FormWindowState.Maximized
            Me.Cursor = Cursors.WaitCursor

            'Asigna parámetro al Procedimiento Almacenado: 
            If Me.NomRep = EnumReportes.TablaCreditosDepartamento Then
                frmVisor.Parametros("@dFechaDesde") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                frmVisor.Parametros("@dFechaHasta") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
            Else
                frmVisor.Parametros("@nAnio") = Year(Me.CdeFechaFinal.Value)
            End If

            'Fórmulas Comunes:
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

            'Listados: 
            If mNomRep = EnumReportes.TablaCreditosAprobados Then
                frmVisor.NombreReporte = "RepSccCC28.rpt"
                frmVisor.Text = "Comportamiento de Créditos Aprobados"
                'Fórmulas CC28: 
                frmVisor.Formulas("Anio") = Year(Me.CdeFechaFinal.Value)
                frmVisor.Formulas("MesDesde") = Month(Me.cdeFechaInicial.Value)
                frmVisor.Formulas("MesHasta") = Month(Me.CdeFechaFinal.Value)

            ElseIf mNomRep = EnumReportes.TablaAvancesMetas Then
                frmVisor.NombreReporte = "RepSccCC29.rpt"
                frmVisor.Text = "Avances en el Cumplimiento de Metas de Créditos Aprobados"

            ElseIf mNomRep = EnumReportes.TablaCreditosActividad Then
                frmVisor.NombreReporte = "RepSccCC30.rpt"
                frmVisor.Text = "Comportamiento de Créditos Aprobados según principales Actividades Económicas"

            ElseIf mNomRep = EnumReportes.TablaCreditosDepartamento Then
                frmVisor.NombreReporte = "RepSccCC31.rpt"
                frmVisor.Text = "Créditos aprobados por barrios y mercados según Departamento"
            ElseIf mNomRep = EnumReportes.VistaRecuperacionesReportadas Then
                ''''''' Modificado por Alberto Blandón S.
                frmVisor.RegistrosSeleccion = "{vwSccRecuperacionesReportadas.dFechaDeposito} >= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSccRecuperacionesReportadas.dFechaDeposito} <= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                frmVisor.NombreReporte = "RepSccCC54.rpt"
                frmVisor.Text = "Recuperaciones Reportadas al Ministerio de Hacienda y Credito Publico"
            ElseIf mNomRep = EnumReportes.VistaMinutasNoEnviadasaMHCP Then
                frmVisor.RegistrosSeleccion = "{vwScnMinutasNoEnviadasaMHCP.dFechaDeposito} >= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwScnMinutasNoEnviadasaMHCP.dFechaDeposito} <= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                frmVisor.NombreReporte = "RepScnCN31.rpt"
                frmVisor.Text = "Minutas no Enviads al Ministerio de Hacienda y Credito Publico"

            ElseIf mNomRep = EnumReportes.VistaRecibosNoEnviadosaMHCP Then
                frmVisor.RegistrosSeleccion = "{vwSccRecibosNOenviadosMHCP.dFechaRecibo}>= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSccRecibosNOenviadosMHCP.dFechaRecibo} <= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                frmVisor.NombreReporte = "RepSccCC55.rpt"
                frmVisor.Text = "Recibos No Enviados al Ministerio de Hacienda y Credito Publico"
            ElseIf mNomRep = EnumReportes.VistaMinutasEnviadasyAhunNoAPlicadasporMHCP Then
                frmVisor.RegistrosSeleccion = "{vwScnMinutasNoEnviadasaMHCP.dFechaDeposito} >= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwScnMinutasNoEnviadasaMHCP.dFechaDeposito} <= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                frmVisor.NombreReporte = "RepScnCN32.rpt"
                frmVisor.Text = "Minutas Enviads al Ministerio de Hacienda y Credito Publico y que Ahun no son Aplicadas"
            ElseIf mNomRep = EnumReportes.VistaRecuperacionesReportadasFiltradasPorFechaRecibo Then
                frmVisor.RegistrosSeleccion = "{vwSccRecuperacionesReportadas.dFechaRecibo} >= #" & Format(Me.cdeFechaInicial.Value, "yyyy/MM/dd") & "# And {vwSccRecuperacionesReportadas.dFechaRecibo} <= #" & Format(Me.CdeFechaFinal.Value, "yyyy/MM/dd") & "#"
                frmVisor.NombreReporte = "RepSccCC57.rpt"
                frmVisor.Text = "Recuperaciones Reportadas al Ministerio de Hacienda y Credito Publico Filtradas por Fecha de Recibos"
            End If

            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/06/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este procedimiento permite salir de la Interfaz
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
    ' Fecha:                10/06/2008
    ' Procedure Name:       frmSccParametrosIndicadores_FormClosing
    ' Descripción:          Al cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccParametrosIndicadores_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/06/2008
    ' Procedure Name:       frmSccParametrosIndicadores_Load
    ' Descripción:          Al cargar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccParametrosIndicadores_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.mColorVentana)
            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            If Me.mColorVentana = "Verde" Then
                If mNomRep = 9 Or mNomRep = 7 Or mNomRep = 8 Or mNomRep = 5 Then
                    Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
                Else
                    Me.HelpProvider.SetHelpKeyword(Me, "Indicadores (Reportes)")
                End If
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Contabilidad")
            End If

            InicializarVariables()
            CargarEjercicios()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub frmSclParametrosIndicadores_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.NomRep = EnumReportes.TablaCreditosAprobados Then
            Me.Text = "Comportamiento Créditos Aprobados"
        ElseIf Me.NomRep = EnumReportes.TablaAvancesMetas Then
            Me.Text = "Avances en Cumplimiento de Metas"
        ElseIf Me.NomRep = EnumReportes.TablaCreditosActividad Then
            Me.Text = "Comportamiento Créditos Aprobados según Actividad"
        ElseIf Me.NomRep = EnumReportes.TablaCreditosDepartamento Then
            Me.Text = "Créditos Aprobados según Departamento"
        End If
    End Sub

    Private Sub CboEjercicio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboEjercicio.TextChanged
        Me.cdeFechaInicial.Value = Me.CboEjercicio.Columns("dFechaInicio").Value
        Me.CdeFechaFinal.Value = Me.CboEjercicio.Columns("dFechaFin").Value
    End Sub

    Private Sub grpdatos_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grpdatos.Enter

    End Sub
End Class