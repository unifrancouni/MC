
Public Class frmSteParametrosPagare
    Dim XdtDepartamento As BOSistema.Win.XDataSet
    Dim XdtEstadoPagare As BOSistema.Win.XDataSet
    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3

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
        ListadoPagare = 1 'Reporte de Pagares
        ListadodeRecibosSinAsociar = 2   'Reporte de Recibos Sin Asociar a  una Minuta
    End Enum

    'Nombre del Reporte:
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
            XdtDepartamento = New BOSistema.Win.XDataSet
            XdtEstadoPagare = New BOSistema.Win.XDataSet

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarDepartamento()
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            If XdtDepartamento.ExistTable("Departamento") Then
                XdtDepartamento("Departamento").ExecuteSql(Strsql)
            Else
                XdtDepartamento.NewTable(Strsql, "Departamento")
                XdtDepartamento("Departamento").Retrieve()
            End If

            Me.cboDepartamento.DataSource = XdtDepartamento("Departamento").Source
            Me.cboDepartamento.Rebind()

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            If Me.cboDepartamento.ListCount > 0 Then
                XdtDepartamento("Departamento").AddRow()

                XdtDepartamento("Departamento").ValueField("nStbDepartamentoID") = -19
                XdtDepartamento("Departamento").ValueField("sCodigo") = 0
                XdtDepartamento("Departamento").ValueField("Descripcion") = "Todos"
                XdtDepartamento("Departamento").ValueField("Orden") = 0
                XdtDepartamento("Departamento").UpdateLocal()
                XdtDepartamento("Departamento").Sort = "sCodigo asc"

                Me.cboDepartamento.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarEstadoPagare()

        Try
            Dim Strsql As String

            Strsql = "SELECT     StbValorCatalogo.nStbValorCatalogoID, StbValorCatalogo.sCodigoInterno, StbValorCatalogo.sDescripcion " & _
                     "FROM         StbCatalogo INNER JOIN " & _
                     "StbValorCatalogo ON StbCatalogo.nStbCatalogoID = StbValorCatalogo.nStbCatalogoID " & _
                     "WHERE     (StbCatalogo.sNombre = 'PagareTesoreria') AND (StbValorCatalogo.sCodigoInterno <> '3')"


            If XdtEstadoPagare.ExistTable("EstadoPagare") Then
                XdtEstadoPagare("EstadoPagare").ExecuteSql(Strsql)
            Else
                XdtEstadoPagare.NewTable(Strsql, "EstadoPagare")
                XdtEstadoPagare("EstadoPagare").Retrieve()
            End If
            Me.cboEstadoPagare.DataSource = XdtEstadoPagare("EstadoPagare").Source
            Me.cboEstadoPagare.Rebind()

            Me.cboEstadoPagare.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False


            Me.cboEstadoPagare.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboEstadoPagare.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboEstadoPagare.Splits(0).DisplayColumns("sDescripcion").Width = 80
            Me.cboEstadoPagare.Columns("sCodigoInterno").Caption = "Código"
            Me.cboEstadoPagare.Columns("sDescripcion").Caption = "Descripción"
            Me.cboEstadoPagare.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboEstadoPagare.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            If Me.cboEstadoPagare.ListCount > 0 Then
                XdtEstadoPagare("EstadoPagare").AddRow()
                XdtEstadoPagare("EstadoPagare").ValueField("nStbValorCatalogoID") = -19
                XdtEstadoPagare("EstadoPagare").ValueField("sDescripcion") = "Todos"
                XdtEstadoPagare("EstadoPagare").ValueField("sCodigoInterno") = 0
                XdtEstadoPagare("EstadoPagare").UpdateLocal()
                XdtEstadoPagare("EstadoPagare").Sort = "nStbValorCatalogoID asc"
                Me.cboEstadoPagare.SelectedIndex = 0
            End If
            Me.cboEstadoPagare.Text = "Todos"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        Try
            VbResultado = False
            Me.errParametro.Clear()

            'Departamento:
            If Me.cboDepartamento.Enabled Then
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboEstadoPagare, "Debe seleccionar un Departamento válido.")
                    Me.cboEstadoPagare.Focus()
                    GoTo SALIR
                End If
            End If

            'Estado Pagare:
            If Me.cboEstadoPagare.Enabled Then
                If Me.cboEstadoPagare.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Estado del Pagare válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboEstadoPagare, "Debe seleccionar un Estado del Pagare válido.")
                    Me.cboEstadoPagare.Focus()
                    GoTo SALIR
                End If
            End If

            'Tipo de Programa: 
            If Me.CboPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Programa válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboPrograma, "Debe seleccionar un Programa válido.")
                Me.CboPrograma.Focus()
                GoTo SALIR
            End If

            'Fecha de Inicio:
            If Me.cdeFechaInicial.Enabled Then
                'Indicar Fecha Inicial:
                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
                'Indicar Fecha de Corte:
                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                    Me.CdeFechaFinal.Focus()
                    GoTo SALIR
                End If
                'Fecha de Corte no menor:
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
            End If

            If mNomRep = EnumReportes.ListadoPagare = True Then
                ' maximo 12 meses:
                If DateDiff(DateInterval.Month, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 11 Then
                    'If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 180 Then '180 días
                    MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a 180 días.", MsgBoxStyle.Information)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Imposible seleccionar cortes de fecha superiores a 180 días.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
            ElseIf mNomRep = EnumReportes.ListadodeRecibosSinAsociar = True Then
                ' maximo 30 días:
                If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a 30 días.", MsgBoxStyle.Information)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Imposible seleccionar cortes de fecha superiores a 30 días.")
                    Me.cdeFechaInicial.Focus()
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
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim CadSql As String
        Dim Titulo As String
        Try
            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""
            Titulo = ""
            frmVisor.WindowState = FormWindowState.Maximized

            If mNomRep = EnumReportes.ListadoPagare = True Then
                '1. Estado Pagare:
                If Me.cboEstadoPagare.Text = "En Proceso" Then
                    Filtro = "{vwSteListadoPagareconEstado.sCodigoInterno}='" & Me.cboEstadoPagare.Columns("sCodigoInterno").Value & "'"
                    If Me.cboDepartamento.Text <> "Todos" Then
                        Filtro = Filtro & " And {vwSteListadoPagareconEstado.nStbDepartamentoID}= " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & " And {vwSteListadoPagareconEstado.dFechaInicio} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoPagareconEstado.dFechaInicio} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = Filtro & " And {vwSteListadoPagareconEstado.dFechaInicio} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoPagareconEstado.dFechaInicio} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    End If
                ElseIf Me.cboEstadoPagare.Text = "Cancelado" Then
                    Filtro = "{vwSteListadoPagareconEstado.sCodigoInterno}='" & Me.cboEstadoPagare.Columns("sCodigoInterno").Value & "'"
                    If Me.cboDepartamento.Text <> "Todos" Then
                        Filtro = Filtro & " and {vwSteListadoPagareconEstado.nStbDepartamentoID}= " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & " And {vwSteListadoPagareconEstado.dFechaInicio} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoPagareconEstado.dFechaInicio} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = Filtro & " And {vwSteListadoPagareconEstado.dFechaInicio} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoPagareconEstado.dFechaInicio} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    End If
                Else
                    If Me.cboDepartamento.Text <> "Todos" Then
                        Filtro = "{vwSteListadoPagareconEstado.nStbDepartamentoID}= " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & " And {vwSteListadoPagareconEstado.dFechaInicio} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoPagareconEstado.dFechaInicio} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    Else
                        Filtro = "{vwSteListadoPagareconEstado.dFechaInicio} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoPagareconEstado.dFechaInicio} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                    End If
                End If
                '2. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoPagareconEstado.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " {vwSteListadoPagareconEstado.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If

            ElseIf mNomRep = EnumReportes.ListadodeRecibosSinAsociar = True Then
                If Me.cboDepartamento.Text <> "Todos" Then
                    Filtro = "{vwSteRecibosAutomaticosSinMinutaAsociada.nStbDepartamentoID}= " & Me.cboDepartamento.Columns("nStbDepartamentoID").Value & " And {vwSteRecibosAutomaticosSinMinutaAsociada.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteRecibosAutomaticosSinMinutaAsociada.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = "{vwSteRecibosAutomaticosSinMinutaAsociada.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteRecibosAutomaticosSinMinutaAsociada.dFechaRecibo}<= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                '2. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteRecibosAutomaticosSinMinutaAsociada.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " {vwSteRecibosAutomaticosSinMinutaAsociada.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If

            End If

            'Asignación del Filtro indicado: 
            Me.Cursor = Cursors.WaitCursor

            If Trim(Filtro) <> "" Then
                frmVisor.CRVReportes.SelectionFormula = Filtro
            End If

            If mNomRep = EnumReportes.ListadoPagare = True Then
                frmVisor.NombreReporte = "RepSteTE39.rpt"
                frmVisor.Text = "Listado de Pagares"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                If Me.cboEstadoPagare.Text = "En Proceso" Then
                    frmVisor.Formulas("Titulo") = "'Listado de Pagarés Pendientes de Pago'"
                    CadSql = " SELECT     * " & _
                            "From  vwSteListadoPagareconEstado"
                ElseIf Me.cboEstadoPagare.Text = "Cancelado" Then

                    CadSql = " SELECT    *  FROM         vwSteListadoPagareconEstado"
                    frmVisor.Formulas("Titulo") = "'Listado de Pagarés Cancelados'"
                Else
                    CadSql = " SELECT    *  FROM         vwSteListadoPagareconEstado"
                    frmVisor.Formulas("Titulo") = "'Listado de Todos los Pagarés'"
                End If

            ElseIf mNomRep = EnumReportes.ListadodeRecibosSinAsociar = True Then
                frmVisor.NombreReporte = "RepSteTE40.rpt"
                frmVisor.Text = "Listado de Recibos sin Minuta Asociada"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                frmVisor.Formulas("Titulo") = "'Listado de Recibos Sin Minutas Asociadas'"

                CadSql = " SELECT    *  FROM         vwSteRecibosAutomaticosSinMinutaAsociada"
            End If
            frmVisor.SQLQuery = CadSql

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteParametrosPagare_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
            XdtDepartamento = Nothing
            XdtEstadoPagare = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteParametrosPagare_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            If Trim(Me.ColorVentana) = "" Then
                ObjGUI.SetFormLayout(Me, "Naranja")
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Tesorería")
            Else
                ObjGUI.SetFormLayout(Me, Me.mColorVentana)
                'Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            CargarTipoPrograma()
            If mNomRep = EnumReportes.ListadoPagare = True Then
                CargarEstadoPagare()
            Else
                Me.cboEstadoPagare.Enabled = False
            End If
            Me.cboDepartamento.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                19/01/2010
    ' Procedure Name:       CargarTipoPrograma
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Programas.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPrograma()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion, 1 as Orden " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoDePrograma')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdtEstadoPagare.ExistTable("Programa") Then
                XdtEstadoPagare("Programa").ExecuteSql(Strsql)
            Else
                XdtEstadoPagare.NewTable(Strsql, "Programa")
                XdtEstadoPagare("Programa").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboPrograma.DataSource = XdtEstadoPagare("Programa").Source

            Me.CboPrograma.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("Orden").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.CboPrograma.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.CboPrograma.Columns("sCodigoInterno").Caption = "Código"
            Me.CboPrograma.Columns("sDescripcion").Caption = "Descripción"

            Me.CboPrograma.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboPrograma.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboPrograma.ListCount > 0 Then
                XdtEstadoPagare("Programa").AddRow()
                XdtEstadoPagare("Programa").ValueField("sDescripcion") = "Todos"
                XdtEstadoPagare("Programa").ValueField("nStbValorCatalogoID") = -19
                XdtEstadoPagare("Programa").ValueField("Orden") = 0
                XdtEstadoPagare("Programa").UpdateLocal()
                XdtEstadoPagare("Programa").Sort = "Orden, sCodigoInterno asc"
                Me.CboPrograma.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class