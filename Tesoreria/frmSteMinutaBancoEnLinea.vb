' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                18/06/2010
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclTrasladosLugarDePagos.vb
' Descripción:          Este formulario permite importar los registros de
'                       Banca en Línea y Conciliar los mismos con Arqueos
'                       de Caja (TE35).
'-------------------------------------------------------------------------
REM Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmSteMinutaBancoEnLinea

    '- Declaración de Variables 
    Dim XdtBancoLinea As BOSistema.Win.XDataSet.xDataTable
    Dim XdsCuenta As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       frmSteMinutaBancoEnLinea_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteMinutaBancoEnLinea_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtBancoLinea.Close()
            XdtBancoLinea = Nothing

            XdsCuenta.Close()
            XdsCuenta = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       frmSteMinutaBancoEnLinea_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado de en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteMinutaBancoEnLinea_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cboCuenta.Select()

            InicializaVariables()

            'Cargar Cuentas Bancarias:
            XdsCuenta = New BOSistema.Win.XDataSet
            CargarCuenta()

            CargarMinutasBancoLinea()
            FormatoMinutasBancoLinea()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       CargarMinutasBancoLinea
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarMinutasBancoLinea()
        Try
            Dim Strsql As String = ""

            If Me.cboCuenta.SelectedIndex = -1 Then
                Strsql = " SELECT a.nSteMinutaBancoEnLineaID, a.nSteCuentaBancariaID, a.nDeposito, a.dFechaDepositoBanco, " & _
                    " a.sNumeroDepositoBanco, a.nMontoDeposito, a.ImportadoPor, a.dFechaCreacion " & _
                    " FROM vwSteMinutaBancoEnLinea AS a " & _
                    " WHERE (SteMinutaBancoEnLinea.nSteMinutaBancoEnLineaID = 0"
            Else
                Strsql = " SELECT a.nSteMinutaBancoEnLineaID, a.nSteCuentaBancariaID, a.nDeposito, a.dFechaDepositoBanco, " & _
                    " a.sNumeroDepositoBanco, a.nMontoDeposito, a.ImportadoPor, a.dFechaCreacion " & _
                    " FROM vwSteMinutaBancoEnLinea AS a " & _
                    " WHERE (a.nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ")  " & _
                    " AND (a.dFechaDepositoBanco BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                    " Order by a.dFechaDepositoBanco, a.sNumeroDepositoBanco"
            End If
            XdtBancoLinea.ExecuteSql(Strsql)

            'Asignando fuente de datos al Grid:
            Me.grdMinutas.DataSource = XdtBancoLinea.Source
            Me.grdMinutas.Caption = " Listado de Depósitos Banca En Línea (" + Me.grdMinutas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       FormatoMinutasBancoLinea
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoMinutasBancoLinea()
        Try

            'Configuracion del Grid
            Me.grdMinutas.Splits(0).DisplayColumns("nSteMinutaBancoEnLineaID").Visible = False
            Me.grdMinutas.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            Me.grdMinutas.Splits(0).DisplayColumns("nDeposito").Width = 80
            Me.grdMinutas.Splits(0).DisplayColumns("dFechaDepositoBanco").Width = 100
            Me.grdMinutas.Splits(0).DisplayColumns("sNumeroDepositoBanco").Width = 150
            Me.grdMinutas.Splits(0).DisplayColumns("nMontoDeposito").Width = 120
            Me.grdMinutas.Splits(0).DisplayColumns("ImportadoPor").Width = 250
            Me.grdMinutas.Splits(0).DisplayColumns("dFechaCreacion").Width = 100

            Me.grdMinutas.Columns("nDeposito").Caption = "Depósito"
            Me.grdMinutas.Columns("dFechaDepositoBanco").Caption = "Fecha Banco"
            Me.grdMinutas.Columns("sNumeroDepositoBanco").Caption = "Número Cheque/Depósito"
            Me.grdMinutas.Columns("nMontoDeposito").Caption = "Monto Banco"
            Me.grdMinutas.Columns("ImportadoPor").Caption = "Importado Por"
            Me.grdMinutas.Columns("dFechaCreacion").Caption = "Fecha Importación"

            Me.grdMinutas.Splits(0).DisplayColumns("nDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinutas.Splits(0).DisplayColumns("dFechaDepositoBanco").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinutas.Splits(0).DisplayColumns("sNumeroDepositoBanco").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinutas.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinutas.Splits(0).DisplayColumns("ImportadoPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinutas.Splits(0).DisplayColumns("dFechaCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formatos Especiales:
            Me.grdMinutas.Columns("dFechaDepositoBanco").NumberFormat = "dd/MM/yyyy"
            Me.grdMinutas.Splits(0).DisplayColumns("dFechaDepositoBanco").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdMinutas.Columns("nMontoDeposito").NumberFormat = "#,##0.00"
            Me.grdMinutas.Columns("dFechaCreacion").NumberFormat = "dd/MM/yyyy hh:mm tt"
            Me.grdMinutas.Splits(0).DisplayColumns("dFechaCreacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify


            Me.grdMinutas.Columns("nDeposito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdMinutas.Splits(0).DisplayColumns("nDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtBancoLinea = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = " Conciliaciones Banca En Línea"
            'Limpiar Grid, estructura y Datos
            Me.grdMinutas.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       tbMinuta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMinuta.
    '-------------------------------------------------------------------------
    Private Sub tbMinuta_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMinuta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolImportar"
                LlamaImportarHojaExcell()
            Case "toolLimpiar"
                LlamaLimpiarImportacion()
            Case "toolEliminar"
                LlamaEliminarRegistro()
            Case "toolRefrescar"
                'Debe indicar una Cuenta:
                If Me.cboCuenta.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar una Cuenta válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.cboCuenta.Focus()
                    Exit Sub
                End If
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                'If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                '    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                '    Me.cdeFechaD.Focus()
                '    Exit Sub
                'End If

                InicializaVariables()
                CargarMinutasBancoLinea()
                FormatoMinutasBancoLinea()

            Case "toolCerrar"
                LlamaCerrar()
                'Case "toolAyuda"
                '    LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/06/2010
    ' Procedure Name:       LlamaImportarHojaExcell
    ' Descripción:          Este procedimiento permite llamar a formulario
    '                       para importar registros de Excell a SQL Server 2005.
    '-------------------------------------------------------------------------
    Private Sub LlamaImportarHojaExcell()
        Dim ObjFrmSteEditMinuta As New frmSteEditMinutaBancoEnLinea
        Try

            Dim Strsql As String
            'Debe indicar una Cuenta:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.cboCuenta.Focus()
                Exit Sub
            End If

            'Verifica si esta Cerrada:
            Strsql = "SELECT nSteCuentaBancariaID FROM SteCuentaBancaria " & _
                     "WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") AND (nCerrada = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Cuenta Bancaria se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Llama a Formulario para Importar archivo Excell:
            ObjFrmSteEditMinuta.IdCuentaBancaria = cboCuenta.Columns("nSteCuentaBancariaID").Value
            ObjFrmSteEditMinuta.txtCuenta.Text = Me.cboCuenta.Text
            ObjFrmSteEditMinuta.ShowDialog()
            CargarMinutasBancoLinea()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Yesenia Gutiérrez
    ' Fecha:                25/06/2010
    ' Procedure Name:       LlamaEliminarRegistro
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una fila excel importada.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRegistro()
        Dim XdtEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdMinutas.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Eliminar El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                Call GuardarAuditoria(5, 25, "Eliminación Registro Banco en Línea ID: " & XdtBancoLinea.ValueField("nSteMinutaBancoEnLineaID") & ".")
                XdtEliminar.ExecuteSqlNotTable("Delete From SteMinutaBancoEnLinea where nSteMinutaBancoEnLineaID=" & XdtBancoLinea.ValueField("nSteMinutaBancoEnLineaID"))
                CargarMinutasBancoLinea()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinutas.Caption = " Listado de Depósitos Banca En Línea (" + Me.grdMinutas.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtEliminar.Close()
            XdtEliminar = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       LlamaLimpiarImportacion
    ' Descripción:          Este procedimiento permite eliminar
    '                       registros importados.
    '-------------------------------------------------------------------------
    Private Sub LlamaLimpiarImportacion()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Si no existen registros:
            If Me.grdMinutas.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Debe indicar una Cuenta:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.cboCuenta.Focus()
                Exit Sub
            End If

            'Verifica si esta Cerrada:
            Strsql = "SELECT nSteCuentaBancariaID FROM SteCuentaBancaria " & _
                     "WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") AND (nCerrada = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Cuenta Bancaria se encuentra Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fechas de Corte Validas:
            If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fecha de Corte no mayor a la de Inicio:
            If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            'Verificar registros en la Base:
            Strsql = " SELECT * " & _
                     " FROM SteMinutaBancoEnLinea " & _
                     " WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ")  " & _
                     " AND (dFechaDepositoBanco BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("No existen registros importados para esta" & Chr(13) & "Cuenta Bancaria y rangos de fechas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar la importación Bancaria?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                Strsql = " DELETE From SteMinutaBancoEnLinea " & _
                         " WHERE (nSteCuentaBancariaID =" & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         " AND (dFechaDepositoBanco BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                XcDatos.ExecuteNonQuery(Strsql)
                Call GuardarAuditoria(5, 25, "Eliminar Importación Banca en Linea. Del: " & Me.cdeFechaD.Text & " Al: " & Me.cdeFechaH.Text & ". Cuenta ID: " & cboCuenta.Columns("nSteCuentaBancariaID").Value)
                CargarMinutasBancoLinea()
                FormatoMinutasBancoLinea()
                MsgBox("La importación se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinutas.Caption = " Listado de Depósitos Banca En Línea (" + Me.grdMinutas.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            'Control_Error(ex)
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       grdMinutas_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdMinutas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdMinutas.Filter
        Try
            XdtBancoLinea.FilterLocal(e.Condition)
            Me.grdMinutas.Caption = " Listado de Depósitos Banca En Línea (" + Me.grdMinutas.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Importar:
            If Seg.HasPermission("ImportarBancoLinea") Then
                Me.toolImportar.Enabled = True
            Else
                Me.toolImportar.Enabled = False
            End If

            'Eliminar / Limpiar Importación:
            If Seg.HasPermission("LimpiarBancoLinea") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If
            If Seg.HasPermission("LimpiarBancoLinea") Then
                Me.toolLimpiar.Enabled = True
            Else
                Me.toolLimpiar.Enabled = False
            End If

            '-- Imprimir:
            'Reporte de Importaciones Banco en Línea:
            If Seg.HasPermission("ImprimirReporteTE45") Then
                Me.toolImprimirBancoLinea.Enabled = True
            Else
                Me.toolImprimirBancoLinea.Enabled = False
            End If

            'Reporte de Tesorería TE35 sin agrupaciones:
            If Seg.HasPermission("ImprimirReporteTE35x") Then
                Me.toolImprimirArqueosU0.Enabled = True
            Else
                Me.toolImprimirArqueosU0.Enabled = False
            End If

            'Reporte de Diferencias encontradas en Depósitos:
            If Seg.HasPermission("ImprimirReporteTE46") Then
                Me.toolImprimirConciliacionDiferencias.Enabled = True
            Else
                Me.toolImprimirConciliacionDiferencias.Enabled = False
            End If

            'Reporte Listado de Cheques CN39
            If Seg.HasPermission("ImprimirReporteCN39") Then
                Me.toolImprimirListadoCheques.Enabled = True
            Else
                Me.toolImprimirListadoCheques.Enabled = False
            End If

            'Reporte de Diferencias encontradas en Cheques:
            If Seg.HasPermission("ImprimirReporteTE47") Then
                Me.toolConciliacionCheques.Enabled = True
            Else
                Me.toolConciliacionCheques.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdMinutas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdMinutas.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/06/2010
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de Cuentas
    '                       Bancarias en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarCuenta()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String
            Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sInstitucionBancaria " & _
                     " From vwSteCtaBancaria a " & _
                     " Order by a.sNumeroCuenta Asc"

            If XdsCuenta.ExistTable("Cuenta") Then
                XdsCuenta("Cuenta").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "Cuenta")
                XdsCuenta("Cuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCuenta.DataSource = XdsCuenta("Cuenta").Source
            Me.cboCuenta.Rebind()

            'Buscar Cuenta Bancaria predeterminada en Parámetros:
            XdtValorParametro.Filter = "nStbParametroID = 68"
            XdtValorParametro.Retrieve()
            'Ubicarse en el primer registro:
            If XdsCuenta("Cuenta").Count > 0 Then
                XdsCuenta("Cuenta").SetCurrentByID("nSteCuentaBancariaID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo: 
            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 160
            Me.cboCuenta.Splits(0).DisplayColumns("sInstitucionBancaria").Width = 160

            Me.cboCuenta.Columns("sNumeroCuenta").Caption = "No. Cuenta Bancaria"
            Me.cboCuenta.Columns("sInstitucionBancaria").Caption = "Nombre del Banco"

            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sInstitucionBancaria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        InicializaVariables()
        CargarMinutasBancoLinea()
        FormatoMinutasBancoLinea()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/06/2010
    ' Procedure Name:       toolImprimirArqueosU0_Click
    ' Descripción:          Permite imprimir reporte TE35x.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirArqueosU0_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirArqueosU0.Click
        Try

            LlamaImprimirListadoTesoreria(9)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/06/2010
    ' Procedure Name:       LlamaImprimirListadoTesoreria
    ' Descripción:          Permite imprimir reporte TE35x.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirListadoTesoreria(ByVal IDReporte As Integer)
        Dim ObjFrmScnParametroRpt As New frmSteParametrosTesoreria
        Try

            ObjFrmScnParametroRpt.NomRep = IDReporte
            ObjFrmScnParametroRpt.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnParametroRpt.Close()
            ObjFrmScnParametroRpt = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/06/2010
    ' Procedure Name:       LlamaImprimirListadoTesoreria
    ' Descripción:          Permite imprimir reporte TE45.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirBancoLinea_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirBancoLinea.Click
        Dim frmVisor As New frmCRVisorReporte
        Try

            'Fechas de Corte Validas:
            If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fecha de Corte no mayor a la de Inicio:
            If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            'Máximo 3 meses entre la fecha de inicio y corte:
            If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 2 Then
                MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a tres meses.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(Me.cdeFechaD.Value, "dd/MM/yyyy") & " Al " & Format(Me.cdeFechaH.Value, "dd/MM/yyyy") & " '"
            frmVisor.NombreReporte = "RepSteTE45.rpt"
            frmVisor.Text = "Detalle de Importaciones Banca en Línea"
            frmVisor.SQLQuery = " Select * From vwSteMinutaBancoEnLinea " & _
                                " WHERE (nSteCuentaBancariaID =" & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                                " AND (dFechaDepositoBanco BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by nSteCuentaBancariaID, dFechaDepositoBanco"
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/06/2010
    ' Procedure Name:       LlamaImprimirListadoTesoreria
    ' Descripción:          Permite imprimir reporte TE46.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirConciliacionDiferencias_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirConciliacionDiferencias.Click
        Dim frmVisor As New frmCRVisorReporte
        Try

            'Fechas de Corte Validas:
            If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fecha de Corte no mayor a la de Inicio:
            If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            'Máximo 3 meses entre la fecha de inicio y corte:
            If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 2 Then
                MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a tres meses.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(CDate(cdeFechaD.Text), "dd/MM/yyyy") & " Al " & Format(CDate(cdeFechaH.Text), "dd/MM/yyyy") & " '"
            frmVisor.Parametros("@FechaInicial") = Format(CDate(cdeFechaD.Text), "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFinal") = Format(CDate(cdeFechaH.Text), "yyyy-MM-dd")
            frmVisor.Parametros("@CuentaBancariaID") = cboCuenta.Columns("nSteCuentaBancariaID").Value
            frmVisor.NombreReporte = "RepSteTE46.rpt"
            frmVisor.Text = "Conciliación Depósitos"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/07/2010
    ' Procedure Name:       LlamaImprimirListadoCheques
    ' Descripción:          Permite imprimir reporte CN39.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirListadoCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirListadoCheques.Click
        Dim ObjFrmListadoCheques As New FrmScnParametrosListadoCheques
        Try

            ObjFrmListadoCheques.NomRep = 4
            ObjFrmListadoCheques.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmListadoCheques.Close()
            ObjFrmListadoCheques = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/07/2010
    ' Procedure Name:       toolConciliacionCheques
    ' Descripción:          Permite imprimir reporte TE47.
    '-------------------------------------------------------------------------
    Private Sub toolConciliacionCheques_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolConciliacionCheques.Click
        Dim frmVisor As New frmCRVisorReporte
        Try

            'Fechas de Corte Validas:
            If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Fecha de Corte no mayor a la de Inicio:
            If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            'Máximo 3 meses entre la fecha de inicio y corte:
            If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 2 Then
                MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a tres meses.", MsgBoxStyle.Information)
                Me.cdeFechaD.Focus()
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(CDate(cdeFechaD.Text), "dd/MM/yyyy") & " Al " & Format(CDate(cdeFechaH.Text), "dd/MM/yyyy") & " '"

            frmVisor.Parametros("@FechaInicial") = Format(CDate(cdeFechaD.Text), "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFinal") = Format(CDate(cdeFechaH.Text), "yyyy-MM-dd")
            frmVisor.Parametros("@CuentaBancariaID") = cboCuenta.Columns("nSteCuentaBancariaID").Value
            frmVisor.NombreReporte = "RepSteTE47.rpt"
            frmVisor.Text = "Conciliación Cheques"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
End Class