Public Class frmSteParametrosRecibosAnulados

    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim XcDatos As BOSistema.Win.XComando
    Private IntPermiteEditar As Integer
    Private IntPermiteConsultar As Integer
    Private _presentarCajeros As Integer

    Enum TYPECOMBO
        PROGRAMA
        CAJERO
        DELEGACION
    End Enum

    Public Property PresentarCajeros() As Integer
        Get
            Return _presentarCajeros
        End Get
        Set(ByVal value As Integer)
            _presentarCajeros = value
        End Set
    End Property

    Private Sub frmSteParametrosRecibosAnulados_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            XcDatos = New BOSistema.Win.XComando

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            Me.Text = "SMUSURA0 - Parametros Listado de Recibos Anulados "
            ObjGUI.SetFormLayout(Me, "Naranja")
            Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Tesorería")
            InicializarVariables()
            EncuentraParametros()
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            Dim strSQL As String
            Dim IdSrhCajero As Integer
            If _presentarCajeros = 0 Then
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
            Me.CboCajero.Select()

            Me.CargarDelegaciones()
            Me.CargarTipoPrograma()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try

    End Sub

    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet
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

            Me.cboPrograma.SelectedIndex = 0

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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

    Private Sub CargarDelegaciones()
        Try
            Dim Strsql As String

            Me.cboDelegacion.ClearFields()

            If IntPermiteConsultar = 0 Then
                Strsql = " SELECT sdp.nStbDelegacionProgramaID, " & _
                         "        sdp.nCodigo, " & _
                         "        sdp.sNombreDelegacion " & _
                         " FROM StbDelegacionPrograma sdp " & _
                         " WHERE (sdp.nActiva = 1) AND sdp.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion
            Else
                Strsql = " SELECT sdp.nStbDelegacionProgramaID, " & _
                         "        sdp.nCodigo, " & _
                         "        sdp.sNombreDelegacion " & _
                         " FROM StbDelegacionPrograma sdp " & _
                         " WHERE (sdp.nActiva = 1) "
            End If
            Me.CboCajero.Enabled = True

            If XdsCombos.ExistTable("Delegacion") Then
                XdsCombos("Delegacion").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Delegacion")
                XdsCombos("Delegacion").Retrieve()
            End If


            'Asignando a las fuentes de datos:
            Me.cboDelegacion.DataSource = XdsCombos("Delegacion").Source
            Me.cboDelegacion.Rebind()

            Me.cboDelegacion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            'Configurar el combo: 
            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").Width = 310

            Me.cboDelegacion.Columns("nCodigo").Caption = "Código"
            Me.cboDelegacion.Columns("sNombreDelegacion").Caption = "Nombre Delegacion"

            Me.cboDelegacion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            XdsCombos("Delegacion").AddRow()
            XdsCombos("Delegacion").ValueField("sNombreDelegacion") = "Todos"
            XdsCombos("Delegacion").ValueField("nStbDelegacionProgramaID") = -19
            XdsCombos("Delegacion").UpdateLocal()
            XdsCombos("Delegacion").Sort = " nCodigo asc"

            If Me.cboDelegacion.ListCount > 0 Then
                If Me.PresentarCajeros = 0 Then
                    Me.cboDelegacion.SelectedIndex = 0
                Else
                    Me.cboDelegacion.SelectedIndex = 1
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteParametrosRecibosAnulados_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            If Not XdsCombos Is Nothing Then
                XdsCombos.Close()
                XdsCombos = Nothing
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String = String.Empty
        Dim CadSql As String = String.Empty
        Try
            If Me.Validar() Then
                frmVisor.WindowState = FormWindowState.Maximized

                If Me.CboCajero.Columns("nSrhEmpleadoID").Value <> -19 Then
                    Filtro = "{vwSteListadoRecibosAnulados.sNombreCajero} = '" & Me.CboCajero.Columns("sNombreEmpleado").Value & "'"
                End If

                If Me.cboDelegacion.Columns("nStbDelegacionProgramaID").Value <> -19 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro + " AND {vwSteListadoRecibosAnulados.nStbDelegacionProgramaID} = " & Me.cboDelegacion.Columns("nStbDelegacionProgramaID").Value
                    Else
                        Filtro = " {vwSteListadoRecibosAnulados.nStbDelegacionProgramaID} = " & Me.cboDelegacion.Columns("nStbDelegacionProgramaID").Value
                    End If
                End If

                Filtro = Filtro & IIf(String.IsNullOrEmpty(Filtro), "", " AND ") & " {vwSteListadoRecibosAnulados.dFechaRecibo} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "# And {vwSteListadoRecibosAnulados.dFechaRecibo} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"

                Filtro = Filtro & " AND {vwSteListadoRecibosAnulados.CodTipoPrograma} = '" & cboPrograma.Columns("sCodigoInterno").Value & "'"

                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                frmVisor.Formulas("dFechaDesde") = "'" & Format(cdeFechaInicial.Value, "dd-MM-yyyy") & "'"
                frmVisor.Formulas("dFechaHasta") = "'" & Format(CdeFechaFinal.Value, "dd-MM-yyyy") & "'"

                If Trim(Filtro) <> "" Then
                    frmVisor.CRVReportes.SelectionFormula = Filtro
                End If
                'Asignación del Filtro indicado: 
                Me.Cursor = Cursors.WaitCursor
                frmVisor.NombreReporte = "RepSteTE48.rpt"
                frmVisor.Text = "Listado de Recibos Anulados"
                frmVisor.ShowDialog()

                Me.Cursor = Cursors.Default
            End If
        Catch ex As Exception

        End Try
    End Sub

    Private Function Validar() As Boolean

        Dim VbResultado As Boolean
        Try
            VbResultado = False
            Me.errParametro.Clear()

            'Tipo de Programa: 
            If Me.cboPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Programa válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboPrograma, "Debe seleccionar un Programa válido.")
                Me.cboPrograma.Focus()
                Exit Function
            End If

            'Fecha de Inicio:
            If Me.cdeFechaInicial.Enabled Then
                'Indicar Fecha Inicial:
                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
                    Me.cdeFechaInicial.Focus()
                    Exit Function
                End If
                'Indicar Fecha final:
                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                    Me.CdeFechaFinal.Focus()
                    Exit Function
                End If
                'Fecha de Corte no menor:
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    Exit Function
                End If
            End If

            VbResultado = True

            Return VbResultado

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            frmSteParametrosRecibosAnulados_FormClosing(Nothing, Nothing)
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class