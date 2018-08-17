'------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                28/11/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteParametrosCajeros.vb
' Descripción:          Este formulario permite imprimir: 
'                       LISTADO DE RECIBOS ARQUEADOS POR CAJERO TE31
'------------------------------------------------------------------------------
Public Class frmSteParametrosCajeros

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim mColorVentana As String
    Dim nPresentarCajeros As Integer
    Dim nPresentarCajas As Integer

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    Public Property PresentarCajeros() As Integer
        Get
            Return nPresentarCajeros
        End Get
        Set(ByVal value As Integer)
            nPresentarCajeros = value
        End Set
    End Property

    Public Property PresentarCajas() As Integer
        Get
            Return nPresentarCajas
        End Get
        Set(ByVal value As Integer)
            nPresentarCajas = value
        End Set
    End Property

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
        ListadoRecibosCajero = 1
        ListadoRecibosArqueoCajero = 2 'Listado de Grupos
        ListadoRecibosDetalleArqueoCajero = 3 'Listado con detalle de Recibos
        DetalleArqueosDepositos = 4 'TE44
        DiferenciasArqueos = 5 'TE49
        ArqueosEfectuados = 6 'TE50
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdsCombos = New BOSistema.Win.XDataSet

            '-- Encuentra parámetros de Delegación.
            EncuentraParametros()

            'Si no es Reporte por Tipo de Programa:
            If (Me.NomRep <> EnumReportes.ListadoRecibosCajero) And (Me.NomRep <> EnumReportes.DetalleArqueosDepositos) Then
                Me.CboPrograma.Enabled = False
            End If

            If (Me.NomRep = EnumReportes.DetalleArqueosDepositos) Then
                Me.cboCajero.Enabled = False
                Me.CboPrograma.Select()
            End If

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

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2010
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

            If XdsCombos.ExistTable("Programa") Then
                XdsCombos("Programa").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Programa")
                XdsCombos("Programa").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboPrograma.DataSource = XdsCombos("Programa").Source

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
            'If Me.CboPrograma.ListCount > 0 Then
            '    XdsCombos("Programa").AddRow()
            '    XdsCombos("Programa").ValueField("sDescripcion") = "Todos"
            '    XdsCombos("Programa").ValueField("nStbValorCatalogoID") = -19
            '    XdsCombos("Programa").ValueField("Orden") = 0
            '    XdsCombos("Programa").UpdateLocal()
            '    XdsCombos("Programa").Sort = "Orden, sCodigoInterno asc"
            '    Me.CboPrograma.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2008
    ' Procedure Name:       CargarCajero
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Técnicos del Programa.
    '-------------------------------------------------------------------------
    Private Sub CargarCajero(ByVal intCajeroID As Integer)
        Try
            Dim Strsql As String

            Me.cboCajero.ClearFields() 'Empleado q tenga Arqueos registrados.
            If intCajeroID = 0 Then
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE ((a.nSrhEmpleadoID IN (SELECT nSrhCajeroId FROM SteArqueoCaja))) AND (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE ((a.nSrhEmpleadoID IN (SELECT nSrhCajeroId FROM SteArqueoCaja))) " & _
                             " Order by a.nCodigo "
                End If
                Me.cboCajero.Enabled = True
            Else
                'Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                '         " From vwSclRepresentantePrograma a " & _
                '         " WHERE ((a.nSrhEmpleadoID IN (SELECT nSrhCajeroId FROM SteArqueoCaja))) " & _
                '         " Or a.nSrhEmpleadoID = " & intCajeroID & _
                '         " Order by a.nCodigo "
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE a.nSrhEmpleadoID = " & intCajeroID & _
                         " Order by a.nCodigo "
                Me.cboCajero.Enabled = False
            End If

                If XdsCombos.ExistTable("Cajero") Then
                    XdsCombos("Cajero").ExecuteSql(Strsql)
                Else
                    XdsCombos.NewTable(Strsql, "Cajero")
                    XdsCombos("Cajero").Retrieve()
                End If


                'Asignando a las fuentes de datos:
                Me.cboCajero.DataSource = XdsCombos("Cajero").Source
                Me.cboCajero.Rebind()

                Me.cboCajero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboCajero.Splits(0).DisplayColumns("nActivo").Visible = False

                'Configurar el combo: 
                Me.cboCajero.Splits(0).DisplayColumns("nCodigo").Width = 60
                Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

                Me.cboCajero.Columns("nCodigo").Caption = "Código"
                Me.cboCajero.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

                Me.cboCajero.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            XdsCombos("Cajero").AddRow()
            XdsCombos("Cajero").ValueField("sNombreEmpleado") = "Todos"
            XdsCombos("Cajero").ValueField("nSrhEmpleadoID") = -19
            XdsCombos("Cajero").UpdateLocal()
            XdsCombos("Cajero").Sort = " nCodigo asc"

            If Me.cboCajero.ListCount > 0 Then
                If Me.PresentarCajeros = 0 Then
                    Me.cboCajero.SelectedIndex = 0
                Else
                    Me.cboCajero.SelectedIndex = 1
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarCaja(ByVal intCajaID As Integer)
        Try
            Dim Strsql As String

            Me.cboCaja.ClearFields() 'Empleado q tenga Arqueos registrados.
            If intCajaID = 0 Then
                Strsql = "SELECT nSteCajaID, nCodigo, sDescripcionCaja FROM SteCaja"
                Me.cboCaja.Enabled = True
            Else
                Strsql = "SELECT nSteCajaID, nCodigo, sDescripcionCaja FROM SteCaja" & _
                         " WHERE nSteCajaID = " & intCajaID & ""
                Me.cboCaja.Enabled = False
            End If

            If XdsCombos.ExistTable("Caja") Then
                XdsCombos("Caja").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Caja")
                XdsCombos("Caja").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCaja.DataSource = XdsCombos("Caja").Source
            Me.cboCaja.Rebind()

            Me.cboCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False

            'Configurar el combo: 
            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 310

            Me.cboCaja.Columns("nCodigo").Caption = "Código"
            Me.cboCaja.Columns("sDescripcionCaja").Caption = "Nombres y Apellidos"

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            XdsCombos("Caja").AddRow()
            XdsCombos("Caja").ValueField("sDescripcionCaja") = "Todas"
            XdsCombos("Caja").ValueField("nSteCajaID") = -19
            XdsCombos("Caja").UpdateLocal()
            XdsCombos("Caja").Sort = " nCodigo asc"

            If Me.cboCaja.ListCount > 0 Then
                If Me.PresentarCajas = 0 Then
                    Me.cboCaja.SelectedIndex = 0
                Else
                    Me.cboCaja.SelectedIndex = 1
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2008
    ' Procedure Name:       ValidarParametros
    ' Descripción:          Este procedimiento permite validar los parámetros
    '                       de corte indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        Try

            VbResultado = False
            Me.errParametro.Clear()

            'Cajero:
            If Me.cboCajero.Enabled Then
                If Me.cboCajero.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Cajero válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                    Me.cboCajero.Focus()
                    GoTo SALIR
                End If
            End If

            'Tipo de Programa: 
            If Me.CboPrograma.Enabled = True Then
                If Me.CboPrograma.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Programa válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CboPrograma, "Debe seleccionar un Programa válido.")
                    Me.CboPrograma.Focus()
                    GoTo SALIR
                End If
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

            'Detalle y Consolidado de Recibos maximo 5 días:
            If Me.NomRep = EnumReportes.ListadoRecibosDetalleArqueoCajero Or Me.NomRep = EnumReportes.ListadoRecibosArqueoCajero Then
                If DateDiff(DateInterval.Day, CDate(cdeFechaInicial.Text), CDate(CdeFechaFinal.Text)) > 4 Then
                    MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a 5 días.", MsgBoxStyle.Information)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Imposible seleccionar cortes de fecha superiores a 5 días.")
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/11/2008
    ' Procedure Name:       cmdAceptar_Click
    ' Descripción:          Este procedimiento permite generar el reporte
    '                       indicado por el usuario.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String, Filtro2 As String
        Dim CadSql As String

        Try

            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""
            frmVisor.WindowState = FormWindowState.Maximized

            If Me.NomRep = EnumReportes.ListadoRecibosCajero Then
                '1. Reporte para un Cajero en Particular:
                If Me.cboCajero.Columns("nSrhEmpleadoID").Value <> -19 Then
                    Filtro = " {vwSteListadoRecibosCajero.nSrhCajeroID}=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                End If

                '2. Entre el Rango de Fechas de Corte Indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoRecibosCajero.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoRecibosCajero.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteListadoRecibosCajero.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSteListadoRecibosCajero.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
                '3. Para el Tipo de Programa:
                If CboPrograma.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteListadoRecibosCajero.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    Else
                        Filtro = Filtro & " {vwSteListadoRecibosCajero.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                    End If
                End If
            End If

            If Me.NomRep = EnumReportes.ListadoRecibosArqueoCajero Then
                Filtro2 = ""
                If optDetalle.Checked = True Then
                    If chkCaja.Checked = True And cboCaja.Text <> "" Then
                        ' SI ES POR CAJA
                        '1. Reporte para una Caja en Particular:
                        If Me.cboCaja.Columns("nSteCajaID").Value <> -19 Then
                            Filtro2 = "CodigoCaja=" & Me.cboCaja.Columns("nSteCajaID").Value
                        Else
                            Filtro2 = "CodigoCaja>0"
                        End If

                        '2. Reporte para un Cajero en Particular:
                        If Me.cboCajero.Columns("nSrhEmpleadoID").Value <> -19 Then
                            Filtro = Filtro & "{vwSccArqueoRecibosCajasResumenGrupo.nSrhEmpleadoCajeroID}=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                            Filtro2 = Filtro2 & " AND nSrhEmpleadoCajeroID=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                        End If

                        '2. Entre el Rango de Fechas de Corte Indicadas:
                        If Trim(Filtro2) <> "" Then
                            Filtro = Filtro & " And {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = Filtro2 & " AND dFechaRecibo <= '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                        Else
                            Filtro = " {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = " dFechaRecibo <= '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                        End If

                        If Trim(Filtro2) <> "" Then
                            Filtro = Filtro & " And {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = Filtro2 & " And dFechaRecibo >= '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'"
                        Else
                            Filtro = " {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = " dFechaRecibo >= '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'"
                        End If

                    ElseIf chkCaja.Checked = False And cboCaja.Text = "" Then
                        ' SI ES POR CAJERO
                        '1. Reporte para un Cajero en Particular:
                        If Me.cboCajero.Columns("nSrhEmpleadoID").Value <> -19 Then
                            Filtro = "{vwSccArqueoRecibosCajasResumenGrupo.nSrhEmpleadoCajeroID}=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                            Filtro2 = "nSrhEmpleadoCajeroID=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                        End If

                        '2. Entre el Rango de Fechas de Corte Indicadas:
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = Filtro2 & " AND dFechaRecibo <= '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                        Else
                            Filtro = " {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = " dFechaRecibo <= '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                        End If
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = Filtro2 & " And dFechaRecibo >= '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'"
                        Else
                            Filtro = " {vwSccArqueoRecibosCajasResumenGrupo.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                            Filtro2 = " dFechaRecibo >= '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'"
                        End If
                    End If
                Else
                    Filtro2 = " dFechaRecibo <= '" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "' "
                    Filtro2 = Filtro2 & " AND dFechaRecibo >= '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "'"
                End If
            End If

            If Me.NomRep = EnumReportes.ListadoRecibosDetalleArqueoCajero Then
                '1. Reporte para un Cajero en Particular:
                If Me.cboCajero.Columns("nSrhEmpleadoID").Value <> -19 Then
                    Filtro = " {vwSccArqueoRecibosCajas.nSrhEmpleadoCajeroID}=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                End If
                '2. Entre el Rango de Fechas de Corte Indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSccArqueoRecibosCajas.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSccArqueoRecibosCajas.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSccArqueoRecibosCajas.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSccArqueoRecibosCajas.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If
            End If

            If Me.NomRep = EnumReportes.DetalleArqueosDepositos Then
                '1. Entre el Rango de Fechas de Corte Indicadas:
                Filtro = " {vwSteReporteTE44.dFechaArqueo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Filtro = Filtro & " And {vwSteReporteTE44.dFechaArqueo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                '2. Para el Tipo de Programa:
                'If CboPrograma.SelectedIndex > 0 Then
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSteReporteTE44.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                Else
                    Filtro = Filtro & " {vwSteReporteTE44.nStbTipoProgramaID}=" & Me.CboPrograma.Columns("nStbValorCatalogoID").Value
                End If

                If Me.cboCajero.Columns("nSrhEmpleadoID").Value <> -19 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSteReporteTE44.nSrhCajeroID}=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                    Else
                        Filtro = Filtro & " {vwSteReporteTE44.nSrhCajeroID}=" & Me.cboCajero.Columns("nSrhEmpleadoID").Value
                    End If
                End If
            End If

            If Me.NomRep = EnumReportes.DiferenciasArqueos Then
                Filtro = "{@FechaI} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# and {@FechaF} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "# and {@Cajero}= 0 and {@Caja}= 0 "
            End If

            'Asignación del Filtro indicado: 
            Me.Cursor = Cursors.WaitCursor

            If Me.NomRep = EnumReportes.DiferenciasArqueos Then
                If cboCaja.Text = "Todas" And cboCajero.Text = "Todos" Then
                    frmVisor.SQLQuery = "spSteDiferenciasArqueo '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "','" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                ElseIf cboCajero.Text = "Todos" Then
                    frmVisor.SQLQuery = "spSteDiferenciasArqueo '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "','" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "','0','0'"
                ElseIf cboCajero.Text <> "Todos" Then
                    frmVisor.SQLQuery = "spSteDiferenciasArqueo '" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "','" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "','" & Me.cboCajero.Columns("nSrhEmpleadoID").Value & "','0'"
                End If
                frmVisor.Formulas("RangoFechas") = "'Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & "'"
            End If

            If Me.NomRep = EnumReportes.ArqueosEfectuados Then
                If Me.cboCajero.Text <> "" And Me.cboCajero.Text <> "Todos" Then
                    frmVisor.SQLQuery = "SELECT * FROM vwSteArqueo_Maestro WHERE nSrhCajeroId='" & Me.cboCajero.ValueMember & "' AND dFechaArqueo>='" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "' AND dFechaArqueo<='" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                Else
                    frmVisor.SQLQuery = "SELECT * FROM vwSteArqueo_Maestro WHERE dFechaArqueo>='" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "' AND dFechaArqueo<='" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'"
                End If
            End If

            'Formato de Promoción y Capacitación (Detalle / Consolidado):
            If mNomRep = EnumReportes.ListadoRecibosCajero Then
                frmVisor.NombreReporte = "RepSteTE31.rpt"
                frmVisor.Text = "Listado de Recibos Arqueados por Cajero"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                frmVisor.CRVReportes.SelectionFormula = Filtro
            End If

            'Consolidado  de recibos para arqueo por cajero fecha  y grupos:
            If mNomRep = EnumReportes.ListadoRecibosArqueoCajero Then
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
                If optDetalle.Checked = True Then
                    If chkCaja.Checked = True And cboCaja.Text <> "" Then
                        frmVisor.Text = "Monto Por Grupos ingresado por Cajero y Fecha"
                        If Filtro2 <> "" Then
                            frmVisor.SQLQuery = "SELECT * FROM vwSccArqueoRecibosCajasResumenCaja WHERE " & Filtro2
                        Else
                            frmVisor.SQLQuery = "SELECT * FROM vwSccArqueoRecibosCajasResumenCaja"
                        End If

                        frmVisor.NombreReporte = "RepSccCC44A.rpt"
                    End If

                    If chkCaja.Checked = False And cboCaja.Text = "" Then
                        frmVisor.Text = "Monto Por Grupos ingresado por Cajero y Fecha"
                        If Filtro2 <> "" Then
                            frmVisor.SQLQuery = "SELECT * FROM vwSccArqueoRecibosCajasResumenGrupo WHERE " & Filtro2
                        Else
                            frmVisor.SQLQuery = "SELECT * FROM vwSccArqueoRecibosCajasResumenGrupo"
                        End If
                        frmVisor.NombreReporte = "RepSccCC44.rpt"
                    End If
                Else
                    frmVisor.Text = "Consolidado por Cajero y Fecha"
                    If cboCaja.Text = "Todas" And cboCajero.Text = "Todos" Then
                        frmVisor.SQLQuery = "SELECT * FROM vwSccArqueoRecibosCajasResumenCaja_Consolidado WHERE " & Filtro2
                    ElseIf cboCaja.Text <> "Todas" And cboCajero.Text = "Todos" Then
                        frmVisor.SQLQuery = "SELECT * FROM vwSccArqueoRecibosCajasResumenCaja_Consolidado WHERE " & Filtro2 & " AND nCodigo=" & Me.cboCaja.Columns("nCodigo").Value
                    End If
                    frmVisor.NombreReporte = "RepSccCC44B.rpt"
                End If
            End If

            If mNomRep = EnumReportes.ListadoRecibosDetalleArqueoCajero Then
                frmVisor.NombreReporte = "RepSccCC45.rpt"
                frmVisor.Text = "Listado de Recibos ingresado por Cajero y Fecha"
                frmVisor.CRVReportes.SelectionFormula = Filtro
            End If

            'Detalle Arqueos Depositos
            If mNomRep = EnumReportes.DetalleArqueosDepositos Then
                frmVisor.NombreReporte = "RepSteTE44.rpt"
                frmVisor.Text = "Detalle de Arqueos de Caja vs. Depósitos"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                'frmVisor.SQLQuery = "SELECT * FROM vwSteReporteTE44 WHERE " & Filtro
                frmVisor.CRVReportes.SelectionFormula = Filtro
            End If

            'Detalle Arqueos Depositos
            If mNomRep = EnumReportes.DiferenciasArqueos Then
                frmVisor.NombreReporte = "RepSteTE49.rpt"
                frmVisor.Text = "Detalle de Diferencias de Arqueos"
            End If

            'Arqueos Efectuados
            If mNomRep = EnumReportes.ArqueosEfectuados Then
                frmVisor.NombreReporte = "RepSteTE50.rpt"
                frmVisor.Text = "Detalle Arqueos Efectuados"
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
            End If

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
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
    ' Fecha:                28/11/2008
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
    ' Fecha:                28/11/2008
    ' Procedure Name:       frmSteParametrosCajero_FormClosing
    ' Descripción:          Al cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteParametrosCajero_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Fecha:                28/11/2008
    ' Procedure Name:       frmSteParametrosCajero_Load
    ' Descripción:          Al cargar el formulario.
    '-------------------------------------------------------------------------

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Agregar:
            If Seg.HasPermission("VerCajaReporteCC44") = False Then
                chkCaja.Enabled = False
                cboCaja.Enabled = False
            Else  'Habilita
                chkCaja.Enabled = True
                cboCaja.Enabled = True

            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub frmSteParametrosCajero_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim ObjGUI As GUI.ClsGUI
        Try

            Dim XcDatos As New BOSistema.Win.XComando
            Dim strSQL As String
            Dim IdSrhCajero As Integer

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            If Trim(Me.ColorVentana) = "" Or Trim(Me.ColorVentana) = "Naranja" Then
                ObjGUI.SetFormLayout(Me, "Naranja")
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Tesorería")
            Else 'VERDE
                ObjGUI.SetFormLayout(Me, Me.mColorVentana)
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            CargarTipoPrograma()
            If nPresentarCajeros = 0 Then
                CargarCajero(0)
            Else
                'Determinar el Cajero (Empleado que accesa):
                strSQL = " SELECT objEmpleadoID FROM SsgCuenta " & _
                         " WHERE SsgCuentaID = " & InfoSistema.IDCuenta

                IdSrhCajero = XcDatos.ExecuteScalar(strSQL)
                If IdSrhCajero = 0 Then
                    Exit Sub
                End If
                CargarCajero(IdSrhCajero)
            End If
            Me.cboCajero.Select()

            If Me.NomRep = EnumReportes.ListadoRecibosArqueoCajero Then
                chkCaja.Enabled = True
                cboCaja.Enabled = True
                grpCaja.Enabled = True
                CargarCaja(0)
            ElseIf Me.NomRep = EnumReportes.DiferenciasArqueos Or Me.NomRep = EnumReportes.ArqueosEfectuados Then
                cboCajero.Visible = True
                chkCaja.Visible = False
                cboCaja.Visible = False
                grpCaja.Visible = False
            Else
                chkCaja.Visible = False
                cboCaja.Visible = False
                grpCaja.Visible = False
            End If
            If Me.NomRep = EnumReportes.DiferenciasArqueos Then
                cboCajero.Enabled = True
            End If

            Seguridad()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmSccParametrosPromocion_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.NomRep = EnumReportes.ListadoRecibosCajero Then
            Me.Text = "Listado de Recibos Arqueados por Cajero"
        ElseIf Me.NomRep = EnumReportes.DetalleArqueosDepositos Then
            Me.Text = "Detalle de Arqueos de Caja vs. Depósitos"
        End If
    End Sub

    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        If cboCaja.Text <> "" Then
            chkCaja.Checked = True
        Else
            chkCaja.Checked = False
        End If
    End Sub

    Private Sub chkCaja_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCaja.CheckedChanged
        If chkCaja.Checked = False Then
            cboCaja.Text = ""
            optConsolidado.Enabled = False
            optConsolidado.Checked = False
            optDetalle.Checked = True
        Else
            cboCaja.Text = "Todas"
            optConsolidado.Enabled = True
            optConsolidado.Checked = True
            optDetalle.Checked = False
        End If
    End Sub

    Private Sub cboCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCajero.TextChanged
        If Me.NomRep = EnumReportes.ListadoRecibosArqueoCajero Then
            If cboCajero.Text <> "Todos" Then
                optConsolidado.Enabled = False
                optDetalle.Checked = True
            Else
                optConsolidado.Enabled = True
                optConsolidado.Checked = True
            End If
        End If
    End Sub
End Class