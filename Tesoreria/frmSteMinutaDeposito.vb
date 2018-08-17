' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                17/12/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteMinutaDeposito.vb
' Descripción:          Este formulario muestra Listado de Minutas de Depósito.
'-------------------------------------------------------------------------
Public Class frmSteMinutaDeposito

    '- Declaración de Variables 
    Dim XdsMinutaDeposito As BOSistema.Win.XDataSet
    Dim sColor As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       frmSteMinutaDeposito_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteMinutaDeposito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsMinutaDeposito.Close()
            XdsMinutaDeposito = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       frmSteMinutaDeposito_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y se carga listado de Minutas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteMinutaDeposito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Asigna Tópico de Ayuda Dinamico:
            If Me.sColor = "Naranja" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Minutas de Depósito (Tesorería)")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Minutas de Depósito")
            End If

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))

            InicializaVariables()
            CargarMinuta()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	14/03/2008
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
    ' Fecha:                17/12/2007
    ' Procedure Name:       CargarMinuta
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Minutas de Depósito en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarMinuta()
        Try
            Dim Strsql As String
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " Select a.EstadoMinuta, a.nSteMinutaDepositoID, a.nSteCuentaBancariaID, a.sNumeroCuenta, " &
                         "        a.sNombre, a.sNumeroDeposito, a.dFechaDeposito, a.nMontoDeposito, a.nStbDelegacionProgramaID, a.Municipio, " &
                         "        a.nEstadoProceso, a.EstadoEnvioWeb, a.sObservaciones, a.nTransferencia, a.nvirtual " &
                         " From vwSteMinutaDepositoMHCP a " &
                         " WHERE (CONVERT(Varchar(10), dFechaDeposito, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dFechaDeposito, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) " &
                         " Order by a.sNumeroCuenta, a.sNumeroDeposito"
            Else 'Solo Filtra las Minutas de Depósito de su Delegación:
                Strsql = " Select a.EstadoMinuta, a.nSteMinutaDepositoID, a.nSteCuentaBancariaID, a.sNumeroCuenta, " &
                         "        a.sNombre, a.sNumeroDeposito, a.dFechaDeposito, a.nMontoDeposito, a.nStbDelegacionProgramaID, a.Municipio, " &
                         "        a.nEstadoProceso, a.EstadoEnvioWeb, a.sObservaciones, a.nTransferencia, a.nvirtual " &
                         " From vwSteMinutaDepositoMHCP a " &
                         " Where (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " &
                         " And (CONVERT(Varchar(10), dFechaDeposito, 112) > CONVERT(Varchar(10), '" & Format(DateAdd(DateInterval.Day, -1, CDate(cdeFechaD.Text)), "yyyy-MM-dd") & "', 112)) AND (CONVERT(Varchar(10), dFechaDeposito, 112)  <= CONVERT(Varchar(10), '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 112)) " &
                         " Order by a.sNumeroCuenta, a.sNumeroDeposito"
            End If

            If XdsMinutaDeposito.ExistTable("Minuta") Then
                XdsMinutaDeposito("Minuta").ExecuteSql(Strsql)
            Else
                XdsMinutaDeposito.NewTable(Strsql, "Minuta")
                XdsMinutaDeposito("Minuta").Retrieve()
            End If

            'Asignando a las fuentes de datos: 
            Me.grdMinuta.DataSource = XdsMinutaDeposito("Minuta").Source

            'Actualizando el caption de los GRIDS:
            Me.grdMinuta.Caption = " Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            FormatoMinuta()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       FormatoMinuta
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Minutas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoMinuta()
        Try
            'Configuracion del Grid: 
            Me.grdMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.grdMinuta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.grdMinuta.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdMinuta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 155
            Me.grdMinuta.Splits(0).DisplayColumns("sNombre").Width = 160
            Me.grdMinuta.Splits(0).DisplayColumns("sNumeroDeposito").Width = 120
            Me.grdMinuta.Splits(0).DisplayColumns("dFechaDeposito").Width = 90
            Me.grdMinuta.Splits(0).DisplayColumns("nMontoDeposito").Width = 120
            Me.grdMinuta.Splits(0).DisplayColumns("EstadoMinuta").Width = 100
            Me.grdMinuta.Splits(0).DisplayColumns("Municipio").Width = 100
            Me.grdMinuta.Splits(0).DisplayColumns("nEstadoProceso").Width = 80
            Me.grdMinuta.Splits(0).DisplayColumns("EstadoEnvioWeb").Width = 160
            Me.grdMinuta.Splits(0).DisplayColumns("sObservaciones").Width = 250

            Me.grdMinuta.Columns("sNumeroCuenta").Caption = "Número Cuenta Bancaria"
            Me.grdMinuta.Columns("sNombre").Caption = "Nombre del Banco"
            Me.grdMinuta.Columns("sNumeroDeposito").Caption = "Número de Depósito"
            Me.grdMinuta.Columns("dFechaDeposito").Caption = "Fecha Depósito"
            Me.grdMinuta.Columns("nMontoDeposito").Caption = "Monto Depósito C$"
            Me.grdMinuta.Columns("EstadoMinuta").Caption = "Estado Minuta"
            Me.grdMinuta.Columns("Municipio").Caption = "Municipio"
            Me.grdMinuta.Columns("nEstadoProceso").Caption = "Código Envío"
            Me.grdMinuta.Columns("EstadoEnvioWeb").Caption = "Estado de Envío al MHCP"
            Me.grdMinuta.Columns("sObservaciones").Caption = "Observaciones"
            Me.grdMinuta.Columns("nTransferencia").Caption = "Transferencia"
            Me.grdMinuta.Columns("nVirtual").Caption = "Virtual"

            Me.grdMinuta.Splits(0).DisplayColumns("dFechaDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Columns("nMontoDeposito").NumberFormat = "#,##0.00"

            Me.grdMinuta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("EstadoMinuta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("nEstadoProceso").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("EstadoEnvioWeb").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("nTransferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("nVirtual").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdMinuta.Columns("nTransferencia").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdMinuta.Splits(0).DisplayColumns("nTransferencia").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdMinuta.Columns("nVirtual").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdMinuta.Splits(0).DisplayColumns("nVirtual").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdMinuta.Splits(0).DisplayColumns("nTransferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros de Delegación:
            EncuentraParametros()

            '-- Inicializa DataSet:
            XdsMinutaDeposito = New BOSistema.Win.XDataSet

            '-- Limpiar Grid, estructura y Datos:
            Me.grdMinuta.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       tbMinuta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMinuta.
    '-------------------------------------------------------------------------
    Private Sub tbMinuta_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMinuta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarMinuta()
            Case "toolModificar"
                LlamaModificarMinuta()
            Case "toolEliminar"
                LlamaEliminarMinuta()
            Case "toolEnviarMHCP"
                LlamaEnviarMinutaMHCP()
            Case "toolRevertirEnvioMHCP"
                LlamaRevertirEnvioMinutaMHCP()
            Case "toolAplicar"
                LlamaAplicarEnvioMinutaMHCP()
            Case "toolRevertirErrorEnvio"
                LlamaRevertirErrorEnvioMinutaMHCP()
            Case "toolImprimir"
                LlamaImprimirMinuta()
            Case "toolImprimirP"
                LlamaImprimirMinutasNoEnviadas()
            Case "toolRefrescar"

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
                'Máximo 31 días entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                InicializaVariables()
                CargarMinuta()

            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	17/12/2007
    ' Procedure name	:	LlamaImprimirMinuta
    ' Description		:	Este procedimiento se encarga de imprimir Listado de Minutas. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimirMinuta()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(CDate(cdeFechaD.Text), "dd/MM/yyyy") & " Al " & Format(CDate(cdeFechaH.Text), "dd/MM/yyyy") & " '"

            frmVisor.NombreReporte = "RepScnCN15.rpt"
            frmVisor.Text = "Minutas de Depósito"
            If IntPermiteConsultar = 1 Then
                frmVisor.SQLQuery = "Select * From vwSteMinutaDeposito " & _
                                    " WHERE (nSteCuentaBancariaID = " & XdsMinutaDeposito("Minuta").ValueField("nSteCuentaBancariaID") & ") And (dFechaDeposito BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                    " Order by sNumeroCuenta, dFechaDeposito, sNumeroDeposito"
            Else
                frmVisor.SQLQuery = "Select * From vwSteMinutaDeposito " & _
                                    " Where (nSteCuentaBancariaID = " & XdsMinutaDeposito("Minuta").ValueField("nSteCuentaBancariaID") & ") And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                                    " AND (dFechaDeposito BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                    " Order by sNumeroCuenta, dFechaDeposito, sNumeroDeposito"
            End If

            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	06/01/2010
    ' Procedure name	:	LlamaImprimirMinutasNoEnviadas
    ' Description		:	Este procedimiento se encarga de imprimir Listado de Minutas
    '                       En Proceso (No enviadas al MCHP). 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimirMinutasNoEnviadas()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(CDate(cdeFechaD.Text), "dd/MM/yyyy") & " Al " & Format(CDate(cdeFechaH.Text), "dd/MM/yyyy") & " '"

            frmVisor.NombreReporte = "RepScnCN36.rpt"
            frmVisor.Text = "Minutas de Depósito No Enviadas MCHP"
            If IntPermiteConsultar = 1 Then
                frmVisor.SQLQuery = "Select * From vwSteMinutaDeposito " & _
                                    " WHERE (nSteCuentaBancariaID = " & XdsMinutaDeposito("Minuta").ValueField("nSteCuentaBancariaID") & ") And (CodEstadoMinuta = '1') And (dFechaDeposito BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                    " Order by sNumeroCuenta, dFechaDeposito, sNumeroDeposito"
            Else
                frmVisor.SQLQuery = "Select * From vwSteMinutaDeposito " & _
                                    " Where (nSteCuentaBancariaID = " & XdsMinutaDeposito("Minuta").ValueField("nSteCuentaBancariaID") & ") And (CodEstadoMinuta = '1') And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                                    " AND (dFechaDeposito BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                    " Order by sNumeroCuenta, dFechaDeposito, sNumeroDeposito"
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
    ' Fecha:                17/12/2007
    ' Procedure Name:       LlamaAgregarMinuta
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditMinutaDeposito para Agregar una nueva Minuta.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarMinuta()
        Dim ObjFrmScnEditMinuta As New frmSteEditMinutaDeposito
        Try
            ObjFrmScnEditMinuta.ModoFrm = "ADD"
            ObjFrmScnEditMinuta.sColorFrm = Me.sColor
            ObjFrmScnEditMinuta.ShowDialog()

            If ObjFrmScnEditMinuta.IdMinuta <> 0 Then
                CargarMinuta()
                XdsMinutaDeposito("Minuta").SetCurrentByID("nSteMinutaDepositoID", ObjFrmScnEditMinuta.IdMinuta)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditMinuta.Close()
            ObjFrmScnEditMinuta = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       LlamaModificarMinuta
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditMinutaDeposito para Modificar una Minuta.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarMinuta()
        Dim ObjFrmScnEditMinuta As New frmSteEditMinutaDeposito
        Try
            Dim StrSql As String
            ObjFrmScnEditMinuta.IntHabilito = 1

            'Imposible si no existen registros:
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsMinutaDeposito("Minuta").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Minutas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no tiene el estado "En Proceso": 
            StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteMinutaDeposito ON C.nStbValorCatalogoID = SteMinutaDeposito.nStbEstadoMinutaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Minuta no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible modificar si la Cuenta Bancaria esta Cerrada:
            StrSql = "SELECT * FROM SteCuentaBancaria WHERE (nCerrada = 1) AND (nSteCuentaBancariaID = " & XdsMinutaDeposito("Minuta").ValueField("nSteCuentaBancariaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("No es posible Modificar. La Cuenta Bancaria se encuentra Cerrada.", MsgBoxStyle.Information)
                ObjFrmScnEditMinuta.IntHabilito = 0
                Exit Sub
            End If

            'Imposible Modificar si existen Recibos de Caja:
            'StrSql = "SELECT * FROM SccReciboOficialCaja WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("No es posible Modificar. Existen Recibos de Caja asociados.", MsgBoxStyle.Information)
            '    ObjFrmScnEditMinuta.IntHabilito = 0
            '    Exit Sub
            'End If

            'No modificar si la Minuta ya fue asociada a un Pagaré activo
            StrSql = "SELECT  SteReciboPagare.nSteReciboPagareID " & _
                     "FROM SteReciboPagare INNER JOIN StbValorCatalogo ON SteReciboPagare.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SteReciboPagare.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Ya existe Pagaré asociado a esta Minuta.", MsgBoxStyle.Information)
                ObjFrmScnEditMinuta.IntHabilito = 0
                Exit Sub
            End If

            'Imposible Modificar si existen Comprobantes de Ajuste ACTIVOS:
            StrSql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("No es posible Modificar. Existen Comprobantes ACTIVOS asociados.", MsgBoxStyle.Information)
                ObjFrmScnEditMinuta.IntHabilito = 0
                Exit Sub
            End If

            'Imposible modificar si el mes Contable esta Cerrado:
            If PeriodoAbiertoDadaFecha(XdsMinutaDeposito("Minuta").ValueField("dFechaDeposito")) = False Then
                MsgBox("El mes Contable asociado al depósito" & Chr(13) & "se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmScnEditMinuta.ModoFrm = "UPD"
            ObjFrmScnEditMinuta.sColorFrm = Me.sColor
            ObjFrmScnEditMinuta.IdMinuta = XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID")
            ObjFrmScnEditMinuta.nVirtual = XdsMinutaDeposito("Minuta").ValueField("nVirtual")
            ObjFrmScnEditMinuta.ShowDialog()

            If ObjFrmScnEditMinuta.IdMinuta <> 0 Then
                InicializaVariables()
                CargarMinuta()

                'FormatoMinuta()
                XdsMinutaDeposito("Minuta").SetCurrentByID("nSteMinutaDepositoID", ObjFrmScnEditMinuta.IdMinuta)
                Me.grdMinuta.Row = XdsMinutaDeposito("Minuta").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditMinuta.Close()
            ObjFrmScnEditMinuta = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/06/2008
    ' Procedure Name:       LlamaAplicarEnvioMinutaMHCP
    ' Descripción:          Este procedimiento permite marcar un envio de 
    '                       Minuta de Depósito al MHCP como Aplicado dentro 
    '                       de SMCU0-WebService.WScEnvioEncabezado siempre 
    '                       que el estado de la Minuta sea 11.
    '-------------------------------------------------------------------------
    Private Sub LlamaAplicarEnvioMinutaMHCP()
        Dim XdtAplicarEnvioMinuta As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim StrSql As String
            Dim intPosicion As Integer

            'Imposible si no existen Registros:
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsMinutaDeposito("Minuta").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Aplicar Minutas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si la Minuta tiene el estado "En Proceso": 
            StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteMinutaDeposito ON C.nStbValorCatalogoID = SteMinutaDeposito.nStbEstadoMinutaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If (RegistrosAsociados(StrSql)) Then
                MsgBox("Minuta se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Validar si el Estado del Envio no es 11: ENVIO CORRECTO EN ESPERA DE APLICACION POR MHCP.
            StrSql = "SELECT * " & _
                     "FROM [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
                     "Where (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ") and (nEstadoProceso = 11)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("La Minuta no ha sido marcada con: Envío" & Chr(13) & "Correcto en espera de Aplicación.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Aplicación:
            If MsgBox("¿Está seguro de Aplicar el envío de la Minuta al Ministerio" & Chr(13) & "de Hacienda y Crédito Público?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                GuardarAuditoriaTablas(30, 2, "Actualizar SteMinutaDeposito Aplicar Envio MHCP", XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID"), InfoSistema.IDCuenta)
                intPosicion = XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID")
                StrSql = " Update [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
                         " SET dFechaModificacion = getdate(), nEstadoProceso =  3 " & _
                         " WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
                XdtAplicarEnvioMinuta.ExecuteSqlNotTable(StrSql)

                CargarMinuta()
                XdsMinutaDeposito("Minuta").SetCurrentByID("nSteMinutaDepositoID", intPosicion)
                Me.grdMinuta.Row = XdsMinutaDeposito("Minuta").BindingSource.Position
                MsgBox("El registro se actualizó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtAplicarEnvioMinuta.Close()
            XdtAplicarEnvioMinuta = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/06/2008
    ' Procedure Name:       LlamaRevertirErrorEnvioMinutaMHCP
    ' Descripción:          Este procedimiento permite marcar nuevamente un 
    '                       envio de Minuta de Depósito al MHCP como 
    '                       1: LISTO PARA ENVIAR dentro de SMCU0-WebService.WScEnvioEncabezado  
    '                       siempre que el estado de la Minuta sea 8.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevertirErrorEnvioMinutaMHCP()
        Dim XdtRevertirErrorMinuta As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim StrSql As String
            Dim intPosicion As Integer

            'Imposible si no existen Registros:
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsMinutaDeposito("Minuta").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Minutas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si la Minuta tiene el estado "En Proceso": 
            StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteMinutaDeposito ON C.nStbValorCatalogoID = SteMinutaDeposito.nStbEstadoMinutaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If (RegistrosAsociados(StrSql)) Then
                MsgBox("Minuta se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Validar si el Estado del Envio no es 8: ERROR VALIDACION SEGUN MHCP.
            StrSql = "SELECT * " & _
                     "FROM [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
                     "Where (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ") and (nEstadoProceso = 8)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("La Minuta no ha sido marcada con: Error" & Chr(13) & "de Validación según MHCP.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Reintento de Envio:
            If MsgBox("¿Está seguro de volver a marcar la Minuta de Depósito como" & Chr(13) & "Lista para Enviar al Ministerio de Hacienda y Crédito Público?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                intPosicion = XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID")
                StrSql = " Update [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
                         " SET dFechaModificacion = getdate(), nEstadoProceso =  1 " & _
                         " WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"

                GuardarAuditoriaTablas(30, 2, "Actualizar SteMinutaDeposito Revertir error Envio MHCP", XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID"), InfoSistema.IDCuenta)
                XdtRevertirErrorMinuta.ExecuteSqlNotTable(StrSql)

                CargarMinuta()
                XdsMinutaDeposito("Minuta").SetCurrentByID("nSteMinutaDepositoID", intPosicion)
                Me.grdMinuta.Row = XdsMinutaDeposito("Minuta").BindingSource.Position
                MsgBox("El registro se actualizó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtRevertirErrorMinuta.Close()
            XdtRevertirErrorMinuta = Nothing
        End Try
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/08/2008
    ' Procedure Name:       LlamaRevertirEnvioMinutaMHCP
    ' Descripción:          Este procedimiento permite regresar a En Proceso
    '                       Minutas de Depósito ya Enviada al Ministerio de
    '                       Hacienda, permitiendo su posterior modificación
    '                       siempre y cuando esta no exista dentro de las
    '                       tablas del WebService.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevertirEnvioMinutaMHCP()
        Dim XdtEnvioMinutaR As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim StrSql As String
            Dim intPosicion As Integer

            'Imposible si no existen Registros:
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsMinutaDeposito("Minuta").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Minutas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no tiene el estado "Enviar a MHCP": 
            StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteMinutaDeposito ON C.nStbValorCatalogoID = SteMinutaDeposito.nStbEstadoMinutaID " & _
                     "WHERE (C.sCodigoInterno = '2') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Minuta ya se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'REM COMENTARIO TEMPORAL
            'Imposible si la Minuta ya ha pasado el estado SIN PROCESAR:
            If XdsMinutaDeposito("Minuta").ValueField("nEstadoProceso") <> 0 Then
                MsgBox("La Minuta ya ha sido procesada dentro del Servicio Web.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Validar contra WScEnvioEncabezado:
            StrSql = "SELECT * " & _
                     "FROM [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
                     "Where (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ") "
            'REM COMENTARIO TEMPORAL
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("La Minuta ya ha sido procesada dentro del Servicio Web.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Reversion Envio:
            If MsgBox("¿Está seguro de revertir el envío de la Minuta al Ministerio" & Chr(13) & "de Hacienda y Crédito Público?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                intPosicion = XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID")

                GuardarAuditoriaTablas(30, 2, "Actualizar SteMinutaDeposito Revertir Enviar MHCP", XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID"), InfoSistema.IDCuenta)

                StrSql = " Update SteMinutaDeposito " & _
                         " SET nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate(), nStbEstadoMinutaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoMinutaDeposito') " & _
                         " WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
                XdtEnvioMinutaR.ExecuteSqlNotTable(StrSql)
                'Refrescar Datos:
                CargarMinuta()
                XdsMinutaDeposito("Minuta").SetCurrentByID("nSteMinutaDepositoID", intPosicion)
                Me.grdMinuta.Row = XdsMinutaDeposito("Minuta").BindingSource.Position
                'Almacena pista de auditoria:
                Call GuardarAuditoria(5, 25, "Reversión de Envío de Minuta a MHCP No.:  " & XdsMinutaDeposito("Minuta").ValueField("sNumeroDeposito"))
                MsgBox("El registro se actualizó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtEnvioMinutaR.Close()
            XdtEnvioMinutaR = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/04/2008
    ' Procedure Name:       LlamaEnviarMinutaMHCP
    ' Descripción:          Este procedimiento permite marcar una Minuta
    '                       de Depósito como Enviada al Ministerio de
    '                       Hacienda, impidiendo su posterior modificación.
    '-------------------------------------------------------------------------
    Private Sub LlamaEnviarMinutaMHCP()
        Dim XdtEnvioMinuta As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatosV As New BOSistema.Win.XComando
        Try

            Dim StrSql As String

            Dim intPosicion As Integer

            'Imposible si no existen Registros:
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsMinutaDeposito("Minuta").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Minutas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no tiene el estado "En Proceso": 
            StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteMinutaDeposito ON C.nStbValorCatalogoID = SteMinutaDeposito.nStbEstadoMinutaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Minuta no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si existe al menos un Arqueo En Proceso asociado a la Minuta:
            StrSql = "SELECT SteArqueoCaja.nSteMinutaDepositoID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SteArqueoCaja.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Arqueos En Proceso asociados a la Minuta.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si existen Recibos ACTIVOS asociados a la Minuta que no tienen Cierre generado:
            StrSql = "SELECT SccReciboOficialCaja.nSccReciboOficialCajaID " & _
                     "FROM SccReciboOficialCaja INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "INNER JOIN SteMinutaDeposito ON dbo.SccReciboOficialCaja.nSteMinutaDepositoID = SteMinutaDeposito.nSteMinutaDepositoID LEFT OUTER JOIN " & _
                     " (SELECT SccCierreDiarioCaja.dFechaCierre, SccTablaAmortizacionPagos.nSccReciboOficialCajaID " & _
                     "  FROM SccTablaAmortizacionPagos INNER JOIN SccCierreDiarioCajaDetalle ON SccTablaAmortizacionPagos.nSccTablaAmortizacionPagosID = SccCierreDiarioCajaDetalle.nSccTablaAmortizacionPagosID " & _
                     "  INNER JOIN SccCierreDiarioCaja ON SccCierreDiarioCajaDetalle.nSccCierreDiarioCajaID = SccCierreDiarioCaja.nSccCierreDiarioCajaID " & _
                     "  GROUP BY SccCierreDiarioCaja.dFechaCierre, SccTablaAmortizacionPagos.nSccReciboOficialCajaID) AS a ON SccReciboOficialCaja.nSccReciboOficialCajaID = a.nSccReciboOficialCajaID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ") AND (a.nSccReciboOficialCajaID IS NULL)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Recibos Activos asociados a la Minuta que" & Chr(13) & "no tienen Cierre Diario generado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si no existe transaccion contable activa asociada a la Minuta
            '(Comprobante de Recuperación o Comprobante de Ajuste):
            StrSql = "SELECT T.sCodigoInterno AS TipoCD " & _
                     "FROM  StbValorCatalogo AS E INNER JOIN ScnTransaccionContable AS CD ON E.nStbValorCatalogoID = CD.nStbEstadoTransaccionID INNER JOIN StbValorCatalogo AS T ON CD.nStbTipoDocContableID = T.nStbValorCatalogoID " & _
                     "WHERE (E.sCodigoInterno = '2') AND (CD.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("NO existe transacción contable Mayorizada asociada a la Minuta.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Si es Comprobante de Recuperación de Crédito:
            If XcDatosV.ExecuteScalar(StrSql) = "CR" Then
                '1. Imposible si existen Cierres Abiertos cuyos Recibos usan la Minuta:
                StrSql = "SELECT R.nSteMinutaDepositoID " & _
                         "FROM SccCierreDiarioCaja AS CD INNER JOIN StbValorCatalogo AS C ON CD.nStbEstadoCierreID = C.nStbValorCatalogoID INNER JOIN SccCierreDiarioCajaDetalle AS CDD ON CD.nSccCierreDiarioCajaID = CDD.nSccCierreDiarioCajaID " & _
                         "INNER JOIN SccTablaAmortizacionPagos AS TA ON CDD.nSccTablaAmortizacionPagosID = TA.nSccTablaAmortizacionPagosID INNER JOIN SccReciboOficialCaja AS R ON TA.nSccReciboOficialCajaID = R.nSccReciboOficialCajaID  " & _
                         "WHERE (C.sCodigoInterno = '1') AND (R.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Cierres Diarios de Caja En Proceso" & Chr(13) & _
                           "con Recibos asociados a la Minuta.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
                '2. Imposible si no existe al Menos un Cierre Cerrado con Recibos asociados a la Minuta:
                StrSql = "SELECT R.nSteMinutaDepositoID " & _
                         "FROM SccCierreDiarioCaja AS CD INNER JOIN StbValorCatalogo AS C ON CD.nStbEstadoCierreID = C.nStbValorCatalogoID INNER JOIN SccCierreDiarioCajaDetalle AS CDD ON CD.nSccCierreDiarioCajaID = CDD.nSccCierreDiarioCajaID " & _
                         "INNER JOIN SccTablaAmortizacionPagos AS TA ON CDD.nSccTablaAmortizacionPagosID = TA.nSccTablaAmortizacionPagosID INNER JOIN SccReciboOficialCaja AS R ON TA.nSccReciboOficialCajaID = R.nSccReciboOficialCajaID  " & _
                         "WHERE (C.sCodigoInterno = '2') AND (R.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("NO Existe Cierre Diario de Caja Cerrado" & Chr(13) & _
                           "con Recibos asociados a la Minuta.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            Else 'Comprobante de Ajuste:
                '1. El Monto del Comprobante debe corresponder con el de la Minuta: 
                StrSql = "SELECT ISNULL(SUM(ScnTransaccionContableDetalle.nMontoC), 0) AS Total " & _
                         "FROM  StbValorCatalogo AS E INNER JOIN ScnTransaccionContable AS CD ON E.nStbValorCatalogoID = CD.nStbEstadoTransaccionID INNER JOIN StbValorCatalogo AS T ON CD.nStbTipoDocContableID = T.nStbValorCatalogoID " & _
                         "INNER JOIN ScnTransaccionContableDetalle ON CD.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID INNER JOIN ScnCatalogoContable  ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                         "WHERE (E.sCodigoInterno = '2') AND (CD.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ") AND (ScnCatalogoContable.nSteCuentaBancariaID IS NOT NULL) AND (T.sCodigoInterno = 'CA')"
                If XdsMinutaDeposito("Minuta").ValueField("nMontoDeposito") <> XcDatosV.ExecuteScalar(StrSql) Then
                    MsgBox("Monto de la Minuta no corresponde con monto del" & Chr(13) & "Comprobante de Ajuste asociado.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If

            'Confirmar Envio:
            If MsgBox("¿Está seguro de enviar la Minuta al Ministerio" & Chr(13) & "de Hacienda y Crédito Público?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                GuardarAuditoriaTablas(30, 2, "Actualizar SteMinutaDeposito Enviar MHCP", XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID"), InfoSistema.IDCuenta)

                intPosicion = XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID")
                StrSql = " Update SteMinutaDeposito " & _
                         " SET nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate(), nStbEstadoMinutaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoMinutaDeposito') " & _
                         " WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
                XdtEnvioMinuta.ExecuteSqlNotTable(StrSql)

                CargarMinuta()
                XdsMinutaDeposito("Minuta").SetCurrentByID("nSteMinutaDepositoID", intPosicion)
                Me.grdMinuta.Row = XdsMinutaDeposito("Minuta").BindingSource.Position
                MsgBox("El registro se actualizó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtEnvioMinuta.Close()
            XdtEnvioMinuta = Nothing

            XcDatosV.Close()
            XcDatosV = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       LlamaEliminarMinuta
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una Minuta de Depósito existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarMinuta()
        Dim XdtMinuta As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            'Imposible si no existen Registros:
            If Me.grdMinuta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsMinutaDeposito("Minuta").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Eliminar Minutas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no tiene el estado "En Proceso": 
            StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SteMinutaDeposito ON C.nStbValorCatalogoID = SteMinutaDeposito.nStbEstadoMinutaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If (RegistrosAsociados(StrSql) = False) Then
                MsgBox("Minuta no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si existen Recibos de Caja:
            StrSql = "SELECT * FROM SccReciboOficialCaja WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Recibos de Caja asociados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si existen Comprobantes de Ajuste:
            StrSql = "SELECT * FROM  ScnTransaccionContable WHERE (nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Comprobantes asociados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'No modificar si la Minuta ya fue asociada a un Pagaré activo
            StrSql = "SELECT  SteReciboPagare.nSteReciboPagareID " & _
                     "FROM SteReciboPagare INNER JOIN StbValorCatalogo ON SteReciboPagare.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SteReciboPagare.nSteMinutaDepositoID = " & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Ya existe Pagaré asociado a esta Minuta.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible eliminar si el mes Contable esta Cerrado:
            If PeriodoAbiertoDadaFecha(XdsMinutaDeposito("Minuta").ValueField("dFechaDeposito")) = False Then
                MsgBox("El mes Contable asociado al depósito" & Chr(13) & "se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                XdtMinuta.ExecuteSqlNotTable("Delete From SteMinutaDeposito where nSteMinutaDepositoID=" & XdsMinutaDeposito("Minuta").ValueField("nSteMinutaDepositoID"))
                CargarMinuta()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMinuta.Caption = "Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtMinuta.Close()
            XdtMinuta = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Minuta.
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
    ' Fecha:                17/12/2007
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
    ' Fecha:                17/12/2007
    ' Procedure Name:       grdMinuta_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Minuta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdMinuta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMinuta.DoubleClick
        Try
            If Seg.HasPermission("ModificarMinutaDeposito") Then
                LlamaModificarMinuta()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdMinuta_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdMinuta.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       grdMinuta_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdMinuta_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdMinuta.Filter
        Try
            XdsMinutaDeposito("Minuta").FilterLocal(e.Condition)
            Me.grdMinuta.Caption = " Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarMinutaDeposito") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarMinutaDeposito") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarMinutaDeposito") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Enviar Minuta a Hacienda:
            If Seg.HasPermission("EnviarMinutaDepositoMHCP") Then
                Me.toolEnviarMHCP.Enabled = True
            Else
                Me.toolEnviarMHCP.Enabled = False
            End If

            'Revertir Envio de Minuta a Hacienda:
            If Seg.HasPermission("RevertirEnvioMinutaMHCP") Then
                Me.toolRevertirEnvioMHCP.Enabled = True
            Else
                Me.toolRevertirEnvioMHCP.Enabled = False
            End If

            'Aplicar Envio a MHCP:
            If Seg.HasPermission("AplicarEnvioMinutaMHCP") Then
                Me.toolAplicar.Enabled = True
            Else
                Me.toolAplicar.Enabled = False
            End If

            'Revertir Error de Envio (8) a MHCP:
            If Seg.HasPermission("RevertirErrorEnvioMinutaMHCP") Then
                Me.toolRevertirErrorEnvio.Enabled = True
            Else
                Me.toolRevertirErrorEnvio.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirMinutaDeposito") Then
                Me.toolImprimir.Enabled = True
                Me.toolImprimirP.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
                Me.toolImprimirP.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class