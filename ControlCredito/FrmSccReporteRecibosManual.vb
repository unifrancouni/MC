Public Class FrmSccReporteRecibosManual

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
        TablaCreditosAprobados = 3      'Tabla Indicadores No. 2

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
           
            If (Me.NomRep = 3) Then
                Me.cdeFechaInicial.Enabled = True
                Me.CdeFechaFinal.Enabled = True


                Me.cdeFechaInicial.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    

    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                
    ' Procedure Name:       ValidarParametros
    ' Descripción:          Este procedimiento permite validar los parámetros
    '                       de corte indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        Try

            VbResultado = False
            Me.errParametro.Clear()

         

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
    ' Autor:                
    ' Fecha:               
    ' Procedure Name:       cmdAceptar_Click
    ' Descripción:          Este procedimiento permite generar el reporte
    '                       indicado por el usuario.
    '-------------------------------------------------------------------------
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



            Select Case mNomRep
                Case EnumReportes.TablaCreditosAprobados

                    If mNomRep = 3 Then

                        frmVisor.NombreReporte = "RepSccCC75.rpt"
                        frmVisor.Text = "Reporte por Grupos de Creditos a vencerse"
                   
                    End If


                    frmVisor.Parametros("@FechaInicio") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
            End Select

            frmVisor.Show()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try 'Dim frmVisor As New frmCRVisorReporte







                    'Try

                    '    If ValidarParametros() = False Then Exit Sub
                    '    frmVisor.WindowState = FormWindowState.Maximized
                    '    Me.Cursor = Cursors.WaitCursor

                    '    'Asigna parámetro al Procedimiento Almacenado: 
                    '    If Me.NomRep = EnumReportes.TablaCreditosAprobados Then
                    '        frmVisor.Parametros("@dFechaDesde") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    '        frmVisor.Parametros("@dFechaHasta") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    '    Else
                    '        frmVisor.Parametros("@nAnio") = Year(Me.CdeFechaFinal.Value)
                    '    End If

                    '    'Fórmulas Comunes:
                    '    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

                    '    frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy") & " '"




                    '    frmVisor.ShowDialog()
                    '    Me.Cursor = Cursors.Default

                    'Catch ex As Exception
                    '    Control_Error(ex)
                    'Finally
                    '    frmVisor = Nothing
                    'End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:               
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
    ' Autor:               
    ' Fecha:                
    ' Procedure Name:       frmSccParametrosIndicadores_FormClosing
    ' Descripción:          Al cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub FrmSccReporteRecibosManual_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                
    ' Procedure Name:       
    ' Descripción:          Al cargar el formulario.
    '-------------------------------------------------------------------------
    Private Sub FrmSccReporteRecibosManual_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.mColorVentana)
            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            If Me.mColorVentana = "Verde" Then
                If mNomRep = 3 Then
                    '        Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
                    '    Else
                    '        Me.HelpProvider.SetHelpKeyword(Me, "Indicadores (Reportes)")
                End If
                'Else
                '    Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Contabilidad")
            End If

            InicializarVariables()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmSccReporteRecibosManual_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        'If Me.NomRep = EnumReportes.TablaCreditosAprobados Then
        '    Me.Text = "Comportamiento Créditos Aprobados"
        'ElseIf Me.NomRep = EnumReportes.TablaAvancesMetas Then
        '    Me.Text = "Avances en Cumplimiento de Metas"
        'ElseIf Me.NomRep = EnumReportes.TablaCreditosActividad Then
        '    Me.Text = "Comportamiento Créditos Aprobados según Actividad"

        'End If
    End Sub

   
End Class