
Public Class frmScnParametroMovimientoContable
    Dim XdsCombos As BOSistema.Win.XDataSet

    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        DetalleTransacciones = 1
        ConsolidadoTransacciones = 2
        TarjetaAuxiliar = 3
        ConsultarCuentas = 4
        ComprobantesRecuperacionAjustes = 5
        SolicitudesSinChequera = 6 'CN37
        AuxiliarBanco = 7 'CN39
        AuxiliarCaja = 8  'CN40
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property
    Private Sub frmScnParametroMovimientoContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarFuente()
            CargarCatalogoCuentas()
            CargarTipoDocumentoContable()
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

    Private Sub CargarFuente()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
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

            'Asignando a las fuentes de datos
            cboFuentes.DataSource = XdsCombos("Fuente").Source

            Me.cboFuentes.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuentes.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").Width = 40
            Me.cboFuentes.Splits(0).DisplayColumns("Descripcion").Width = 180

            Me.cboFuentes.Columns("sCodigo").Caption = "Código"
            Me.cboFuentes.Columns("Descripcion").Caption = "Descripción"

            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuentes.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Ubicarlo en el primer registro
            If Me.cboFuentes.ListCount > 0 Then
                XdsCombos("Fuente").AddRow()
                XdsCombos("Fuente").ValueField("Descripcion") = "Todas las fuentes"
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

    Private Sub CargarCatalogoCuentas()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String


            If Me.cboFuentes.SelectedIndex = 0 Then
                Strsql = "SELECT  nScnCatalogoContableID, nSteCuentaBancariaID, sCodigoCuenta, sNombreCuenta, RTRIM(LTRIM(sCodigoCuenta)) + '( ' + LTRIM(RTRIM(sNombreCuenta)) + ')' AS CuentaNombre,  1  As Orden FROM  dbo.ScnCatalogoContable"
            Else
                Strsql = "SELECT  nScnCatalogoContableID, nSteCuentaBancariaID, sCodigoCuenta, sNombreCuenta, RTRIM(LTRIM(sCodigoCuenta)) + '( ' + LTRIM(RTRIM(sNombreCuenta)) + ')' AS CuentaNombre,  1 As Orden FROM   dbo.ScnCatalogoContable Where nScnFuenteFinanciamientoID=" & Me.cboFuentes.Columns.Item("nScnFuenteFinanciamientoID").Value
            End If
            If XdsCombos.ExistTable("Catalogo") Then
                XdsCombos("Catalogo").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Catalogo")
                XdsCombos("Catalogo").Retrieve()
            End If

            cbCuentaInicial.DataSource = XdsCombos("Catalogo").Source

            Me.cbCuentaInicial.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.cbCuentaInicial.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cbCuentaInicial.Splits(0).DisplayColumns("CuentaNombre").Visible = False
            Me.cbCuentaInicial.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cbCuentaInicial.Splits(0).DisplayColumns("sCodigoCuenta").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.cbCuentaInicial.Splits(0).DisplayColumns("sCodigoCuenta").Width = 120
            Me.cbCuentaInicial.Splits(0).DisplayColumns("sNombreCuenta").Width = 300
            Me.cbCuentaInicial.Columns("sCodigoCuenta").Caption = "Código"
            Me.cbCuentaInicial.Columns("sNombreCuenta").Caption = "Nombre "
            Me.cbCuentaInicial.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cbCuentaInicial.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Ubicarlo en el primer registro
            If Me.cbCuentaInicial.ListCount > 0 Then
                XdsCombos("Catalogo").AddRow()
                XdsCombos("Catalogo").ValueField("sCodigoCuenta") = " "
                XdsCombos("Catalogo").ValueField("sNombreCuenta") = "Todo el Catalogo "
                XdsCombos("Catalogo").ValueField("CuentaNombre") = "Todo el Catalogo "
                XdsCombos("Catalogo").ValueField("nScnCatalogoContableID") = -19
                XdsCombos("Catalogo").ValueField("Orden") = 0
                XdsCombos("Catalogo").UpdateLocal()
                XdsCombos("Catalogo").Sort = "Orden,sCodigoCuenta asc"
                Me.cbCuentaInicial.SelectedIndex = 0
            End If

            If XdsCombos.ExistTable("Catalogo2") Then
                XdsCombos("Catalogo2").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Catalogo2")
                XdsCombos("Catalogo2").Retrieve()
            End If


            Me.cbCuentaFinal.DataSource = XdsCombos("Catalogo2").Source
            Me.cbCuentaFinal.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.cbCuentaFinal.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cbCuentaFinal.Splits(0).DisplayColumns("CuentaNombre").Visible = False
            Me.cbCuentaFinal.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cbCuentaFinal.Splits(0).DisplayColumns("sCodigoCuenta").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.cbCuentaFinal.Splits(0).DisplayColumns("sCodigoCuenta").Width = 120
            Me.cbCuentaFinal.Splits(0).DisplayColumns("sNombreCuenta").Width = 300
            Me.cbCuentaFinal.Columns("sCodigoCuenta").Caption = "Código"
            Me.cbCuentaFinal.Columns("sNombreCuenta").Caption = "Nombre "
            Me.cbCuentaFinal.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cbCuentaFinal.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Ubicarlo en el primer registro
            If Me.cbCuentaFinal.ListCount > 0 Then
                XdsCombos("Catalogo2").AddRow()
                XdsCombos("Catalogo2").ValueField("sCodigoCuenta") = " "
                XdsCombos("Catalogo2").ValueField("sNombreCuenta") = "Todo el Catalogo "
                XdsCombos("Catalogo2").ValueField("CuentaNombre") = "Todo el Catalogo "
                XdsCombos("Catalogo2").ValueField("nScnCatalogoContableID") = -19
                XdsCombos("Catalogo2").ValueField("Orden") = 0
                XdsCombos("Catalogo2").UpdateLocal()
                XdsCombos("Catalogo2").Sort = "Orden,sCodigoCuenta asc"
                Me.cbCuentaFinal.SelectedIndex = 0
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CargarTipoDocumentoContable()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " SELECT  nStbValorCatalogoID, sCodigoInterno, sDescripcion, 1 as Orden " &
                     " FROM dbo.StbValorCatalogo " &
                     " WHERE (nStbCatalogoID = 16) AND (nActivo = 1)" &
                     " ORDER BY sCodigoInterno"


            If XdsCombos.ExistTable("TipoDocumentoContable") Then
                XdsCombos("TipoDocumentoContable").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "TipoDocumentoContable")
                XdsCombos("TipoDocumentoContable").Retrieve()
            End If

            'Asignando a las fuentes de datos
            cboTipoDocumentoContable.DataSource = XdsCombos("TipoDocumentoContable").Source

            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("Orden").Visible = False


            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("sCodigoInterno").Width = 40
            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("sDescripcion").Width = 180

            Me.cboTipoDocumentoContable.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoDocumentoContable.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoDocumentoContable.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Ubicarlo en el primer registro
            If Me.cboFuentes.ListCount > 0 Then
                XdsCombos("TipoDocumentoContable").AddRow()
                'XdsCombos("TipoDocumentoContable").ValueField("sCodigoInterno") = "ALL"
                XdsCombos("TipoDocumentoContable").ValueField("nStbValorCatalogoID") = -19
                XdsCombos("TipoDocumentoContable").ValueField("sDescripcion") = "Todos los Documentos Contables"
                XdsCombos("TipoDocumentoContable").ValueField("Orden") = 0
                XdsCombos("TipoDocumentoContable").UpdateLocal()
                XdsCombos("TipoDocumentoContable").Sort = "Orden asc"
                Me.cboTipoDocumentoContable.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub InicializarVariables()
        Try

            'Inicializar las clases 
            XdsCombos = New BOSistema.Win.XDataSet
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboFuentes_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFuentes.RowChange
        CargarCatalogoCuentas()
    End Sub

    Private Sub HabilitarObjetos()

        If mNomRep = EnumReportes.DetalleTransacciones Or mNomRep = EnumReportes.ConsolidadoTransacciones _
           Or mNomRep = EnumReportes.ComprobantesRecuperacionAjustes Or mNomRep = EnumReportes.SolicitudesSinChequera _
           Or mNomRep = EnumReportes.AuxiliarCaja Then

            cbCuentaInicial.Enabled = False ' No se filtra por cuentas en las transacciones 
            cbCuentaFinal.Enabled = False

        Else ' Para consulta de tarjeta auxiliar y cuentas contables y Auxiliar Bancos (CN39)
            cbCuentaInicial.Enabled = True
            cbCuentaFinal.Enabled = True
        End If

        'Listado de Solicitudes Sin Chequera No Filtra por Moneda:
        If mNomRep = EnumReportes.SolicitudesSinChequera Then
            grpAprobadoODenegado.Enabled = False
        Else
            grpAprobadoODenegado.Enabled = True
        End If

        If mNomRep = EnumReportes.ConsultarCuentas Then  ' Solo para el reporte de consulta de cuentas
            ChkSaldoMayorCero.Visible = True
        Else
            ChkSaldoMayorCero.Visible = False
        End If

        If mNomRep = EnumReportes.TarjetaAuxiliar Then
            grpTipoComprobantes.Visible = True
            grpTipoMinutas.Visible = True
        Else
            grpTipoComprobantes.Visible = False
            grpTipoMinutas.Visible = False
        End If

        If mNomRep = EnumReportes.ConsolidadoTransacciones Or mNomRep = EnumReportes.DetalleTransacciones Then
            cboTipoDocumentoContable.Enabled = True
        End If
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        '---------------------------------------------------------------------
        'Llama  a las opciones de los  reportes
        '---------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro, CadSql As String
        Dim UltimoPeriodoCerrado, PeriodoDeFechaFinal As Integer
        Dim FechaInicioMenosUnDia As Date
        Dim FechaUltimoPeriodoCerrado As Date
        Dim Fuentes As Integer


        Dim XdtTmpPeriodoA As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        XdtTmpPeriodoA = New BOSistema.Win.XDataSet.xDataTable
        Try

            Filtro = " "
            If ValidarParametros() = False Then Exit Sub
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"
            frmVisor.Formulas("Indice") = IIf(RdCordoba.Checked = True, 1, 0)

            Select Case mNomRep
                Case EnumReportes.DetalleTransacciones, EnumReportes.ConsolidadoTransacciones
                    Filtro = " Where dFechaTransaccion>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "

                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Filtro = Filtro & " And nScnFuenteFinanciamientoID= " & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                    End If


                    If cboTipoDocumentoContable.Columns("nStbValorCatalogoID").Value <> -19 Then
                        Filtro = Filtro & "  AND CodTipoCD = '" & cboTipoDocumentoContable.Columns("sCodigoInterno").Value & "'"
                    End If

                Case EnumReportes.SolicitudesSinChequera
                    Filtro = " Where dFechaSolicitudCheque >= CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaSolicitudCheque <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Filtro = Filtro & " And nScnFuenteFinanciamientoID= " & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                    End If

                Case EnumReportes.ComprobantesRecuperacionAjustes
                    Filtro = " Where (dFechaTransaccion >= CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'))  AND" & _
                             " (EstadoCD <> 'Anulada')"
                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Filtro = Filtro & " And (nScnFuenteFinanciamientoID= " & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value & ")"
                    End If

                    '           Filtro = " Where (CONVERT(varchar(10),dFechaTransaccion,120) >= CONVERT(varchar(10),'" & cdeFechaInicial.Value & "',120) And convert(varchar(10),dFechaTransaccion,120) <= CONVERT(varchar(10),'" & CdeFechaFinal.Value & "',120))  AND" & _
                    '" (EstadoCD <> 'Anulada')" 
                    '           If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                    '               Filtro = Filtro & " And (nScnFuenteFinanciamientoID= " & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value & ")"
                    '           End If

                Case EnumReportes.AuxiliarBanco
                    Filtro = " Where (dFechaTransaccion >= CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'))"
                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Filtro = Filtro & " And (nScnFuenteFinanciamientoID= " & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value & ")"
                    End If
                    If cbCuentaInicial.SelectedIndex > 0 Then
                        Filtro = Filtro & " And (nSteCuentaBancariaID = " & cbCuentaInicial.Columns("nSteCuentaBancariaID").Value & ")"
                    End If

                Case EnumReportes.AuxiliarCaja
                    Filtro = " Where (dFechaTransaccion >= CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaTransaccion <= CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "'))"
                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Filtro = Filtro & " And (nScnFuenteFinanciamientoID= " & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value & ")"
                    End If

                Case EnumReportes.TarjetaAuxiliar, EnumReportes.ConsultarCuentas  ' Se arman los argumentos de los parametros de procedimientos
                    CadSql = "SELECT     MAX(dbo.ScnPeriodoContable.nScnPeriodoContableID) AS PeriodoMaximoCerrado " & _
                                  " FROM         dbo.ScnPeriodoContable INNER JOIN  dbo.StbValorCatalogo ON dbo.ScnPeriodoContable.nStbEstadoPeriodoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                                  " WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '3') "



                    XdtTmpPeriodoA.ExecuteSql(CadSql)
                    If XdtTmpPeriodoA.Count = 0 Then
                        UltimoPeriodoCerrado = 1
                    Else

                        If IsDBNull(XcDatos.ExecuteScalar(CadSql)) Then
                            CadSql = "SELECT     TOP (1) dbo.ScnPeriodoContable.nScnPeriodoContableID AS PeriodoInicio " & _
                                     " FROM         dbo.ScnPeriodoContable INNER JOIN   dbo.StbValorCatalogo ON dbo.ScnPeriodoContable.nStbEstadoPeriodoID = dbo.StbValorCatalogo.nStbValorCatalogoID "
                            UltimoPeriodoCerrado = XcDatos.ExecuteScalar(CadSql)
                        End If
                    End If

                    PeriodoDeFechaFinal = IDPeriodo(Me.CdeFechaFinal.Value)
                    FechaUltimoPeriodoCerrado = FechaDadoPeriodoId(UltimoPeriodoCerrado)
                    If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                        Fuentes = cboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                    Else
                        Fuentes = -1
                    End If

                    FechaInicioMenosUnDia = DateAdd(DateInterval.Day, -1, Me.cdeFechaInicial.Value)

                    frmVisor.Parametros("@UltimoPeriodoCerrado") = UltimoPeriodoCerrado
                    frmVisor.Parametros("@PeriodoDeFechaFinal") = PeriodoDeFechaFinal
                    frmVisor.Parametros("@FechaInicial") = Format(Me.cdeFechaInicial.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaFinal") = Format(Me.CdeFechaFinal.Value, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaInicioMenosUnDia") = Format(FechaInicioMenosUnDia, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FechaUltimoPeriodoCerrado") = Format(FechaUltimoPeriodoCerrado, "yyyy-MM-dd HH:mm:ss")
                    frmVisor.Parametros("@FuenteFinancieraId") = Fuentes
                    If cbCuentaInicial.SelectedIndex > 0 Then
                        frmVisor.Parametros("@CuentaInicial") = IIf(IsDBNull(cbCuentaInicial.Columns("sCodigoCuenta").Value), "", cbCuentaInicial.Columns("sCodigoCuenta").Value)
                        frmVisor.Parametros("@CuentaFinal") = IIf(IsDBNull(cbCuentaFinal.Columns("sCodigoCuenta").Value), "", cbCuentaFinal.Columns("sCodigoCuenta").Value)
                    Else
                        frmVisor.Parametros("@CuentaInicial") = ""
                        frmVisor.Parametros("@CuentaFinal") = ""
                    End If


                    If mNomRep = EnumReportes.ConsultarCuentas Then ' Para ver si presenta solo los saldos mayores que cero
                        frmVisor.Parametros("@EliminarSaldoCero") = IIf(Me.ChkSaldoMayorCero.Checked = True, 1, 0)

                    End If

                    If mNomRep = EnumReportes.TarjetaAuxiliar And Me.RdManuales.Checked = True Then
                        frmVisor.CRVReportes.SelectionFormula = "{SpScnRegistroAuxiliar.CodTipoCD}='CD'"

                    End If

                    If mNomRep = EnumReportes.TarjetaAuxiliar And Me.RdTodos.Checked = True And RdSinMinutas.Checked = True Then
                        frmVisor.CRVReportes.SelectionFormula = "ISNULL({SpScnRegistroAuxiliar.sNumeroDeposito})"

                    End If

                    If mNomRep = EnumReportes.TarjetaAuxiliar And Me.RdTodos.Checked = True And RdConMinutas.Checked = True Then
                        frmVisor.CRVReportes.SelectionFormula = "NOT ISNULL({SpScnRegistroAuxiliar.sNumeroDeposito})"

                    End If

            End Select

            CadSql = ""

            Select Case mNomRep

                Case EnumReportes.DetalleTransacciones
                    frmVisor.NombreReporte = "RepScnCN13.rpt"
                    frmVisor.Text = "Detalle de Transacciones"
                    CadSql = " Select * From vwScnComprobantesRep  "

                Case EnumReportes.ConsolidadoTransacciones
                    frmVisor.NombreReporte = "RepScnCN14.rpt"
                    frmVisor.Text = "Consolidado de Transacciones"
                    CadSql = " Select * From vwScnComprobantesRep "

                Case EnumReportes.TarjetaAuxiliar
                    frmVisor.NombreReporte = "RepScnCN11.rpt"
                    frmVisor.Text = "Tarjeta Auxiliar"

                Case EnumReportes.ConsultarCuentas
                    frmVisor.NombreReporte = "RepScnCN12.rpt"
                    frmVisor.Text = "Consulta de Cuentas"

                Case EnumReportes.ComprobantesRecuperacionAjustes
                    frmVisor.NombreReporte = "RepScnCN30.rpt"
                    frmVisor.Text = "Listado de Comprobantes de Recuperación/Ajustes"
                    CadSql = " Select * From vwScnComprobantesRecuperacionAjuste  "

                Case EnumReportes.AuxiliarBanco
                    frmVisor.NombreReporte = "RepScnCN39.rpt"
                    frmVisor.Text = "Auxiliar de Banco"
                    CadSql = " Select * From vwScnReporteCN39"

                Case EnumReportes.AuxiliarCaja
                    frmVisor.NombreReporte = "RepScnCN40.rpt"
                    frmVisor.Text = "Auxiliar de Caja"
                    CadSql = " Select * From vwScnReporteCN40"

                Case EnumReportes.SolicitudesSinChequera
                    frmVisor.NombreReporte = "RepScnCN37.rpt"
                    frmVisor.Text = "Solicitudes de Cheque Sin Chequera Asociada"
                    CadSql = " Select * From vwScnSolicitudesSinChequera "

            End Select
            If mNomRep = EnumReportes.DetalleTransacciones Or mNomRep = EnumReportes.ConsolidadoTransacciones _
               Or mNomRep = EnumReportes.ComprobantesRecuperacionAjustes Or mNomRep = EnumReportes.SolicitudesSinChequera _
               Or mNomRep = EnumReportes.AuxiliarBanco Or mNomRep = EnumReportes.AuxiliarCaja Then
                frmVisor.SQLQuery = CadSql & " " & Filtro
            End If
            frmVisor.ShowDialog()

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
            If Me.cboFuentes.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una fuente de financiamento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFuentes, "Debe seleccionar una fuente de financiamiento.")
                Me.cboFuentes.Focus()
                GoTo SALIR
            End If

            If mNomRep = EnumReportes.TarjetaAuxiliar Or mNomRep = EnumReportes.ConsultarCuentas Or mNomRep = EnumReportes.AuxiliarBanco Then
                If (cbCuentaInicial.SelectedIndex <> 0 And cbCuentaFinal.SelectedIndex = 0) Or (cbCuentaInicial.SelectedIndex = 0 And cbCuentaFinal.SelectedIndex <> 0) Then
                    MsgBox("Debe seleccionar una cuenta de corte o indique todas  .", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cbCuentaInicial, "Debe seleccionar una cuenta de corte o indique todas  .")
                    Me.cbCuentaInicial.Focus()
                    GoTo SALIR
                End If
            End If

            If mNomRep = EnumReportes.AuxiliarBanco Then
                If cbCuentaInicial.Columns("nScnCatalogoContableID").Value <> cbCuentaFinal.Columns("nScnCatalogoContableID").Value Then
                    MsgBox("Debe seleccionar una misma Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cbCuentaInicial, "Debe seleccionar una misma Cuenta Bancaria o indique todas.")
                    Me.cbCuentaInicial.Focus()
                    GoTo SALIR
                End If
                'La Cuenta debe ser Bancaria:
                If (cbCuentaInicial.SelectedIndex <> 0) Then
                    If Not IsNumeric(cbCuentaInicial.Columns("nSteCuentaBancariaID").Value) Then
                        MsgBox("La Cuenta seleccionada no es de Bancos.", MsgBoxStyle.Critical, NombreSistema)
                        Me.errParametro.SetError(Me.cbCuentaInicial, "La Cuenta seleccionada no es de Bancos.")
                        Me.cbCuentaInicial.Focus()
                        GoTo SALIR
                    End If
                End If
            End If

            If IsDBNull(cdeFechaInicial.Value) Then
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
    Private Sub cbCuentaInicial_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCuentaInicial.RowChange
        If cbCuentaInicial.SelectedIndex = 0 And cbCuentaFinal.ListCount > 0 Then cbCuentaFinal.SelectedIndex = 0
    End Sub
    Private Sub cbCuentaFinal_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbCuentaFinal.RowChange
        If cbCuentaFinal.SelectedIndex = 0 And cbCuentaInicial.ListCount > 0 Then cbCuentaInicial.SelectedIndex = 0
    End Sub

    Private Sub frmScnParametroMovimientoContable_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        HabilitarObjetos()
    End Sub

    Private Sub RdTodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdTodos.CheckedChanged
        grpTipoMinutas.Visible = True
    End Sub

    Private Sub RdManuales_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdManuales.CheckedChanged
        grpTipoMinutas.Visible = False
    End Sub
End Class