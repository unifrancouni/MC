' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                26/01/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteImpresionCheques.vb
' Descripción:          Este formulario carga Solicitudes de Cheque Autorizadas
'                       sin cheque emitido a fin de permitir al área de Tesorería
'                       la asignación de números de cheque.
'-------------------------------------------------------------------------
Public Class frmSteImpresionCheques

    '- Declaración de Variables 
    Dim XdsSolicitudes As BOSistema.Win.XDataSet
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim TipoChk As Integer

    '1 Es Cheque de Gastos Solicitud de Cheque (Pagos Proveedores)
    '0 Es Cheque de Pago a Delegadas Solicitud de Cheque (Otros Cheques)
    Public Property TipoCheque() As Integer
        Get
            TipoCheque = TipoChk
        End Get
        Set(ByVal value As Integer)
            TipoChk = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       frmSteImpresionCheques_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------


    Private Sub frmSteImpresionCheques_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsSolicitudes.Close()
            XdsSolicitudes = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       frmSteImpresionCheques_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Solicitudes Autorizadas  en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteImpresionCheques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaD.Value = FechaServer()
            'cdeFechaH.Value = FechaServer()

            InicializaVariables()
            CargarSolicitudesAutorizadas()
            FormatoSolicitudes()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/01/2009
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
    ' Fecha:                26/01/2009
    ' Procedure Name:       CargarSolicitudesAutorizadas
    ' Descripción:          Este procedimiento permite cargar las Solicitudes
    '                       de cheque autorizadas y sin Cheque emitido.
    '-------------------------------------------------------------------------
    Public Sub CargarSolicitudesAutorizadas()
        Try
            Dim Strsql As String = ""

            '-- Poner el cursor en un estado de desocupado.
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor


            If Me.TipoCheque = 0 Then
                If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                    Strsql = "EXEC SpSteFormaImpresionCheques 0, " & IIf(Me.radChequesPendientes.Checked, 1, 0) & ", " & InfoSistema.IDCuenta & ", '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
                Else 'Solo Filtra las Solicitudes de Cheque de la Delegación del Usuario:
                    Strsql = "EXEC SpSteFormaImpresionCheques " & InfoSistema.IDDelegacion & ", " & IIf(Me.radChequesPendientes.Checked, 1, 0) & ", " & InfoSistema.IDCuenta & ", '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
                End If


            Else
                If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                    Strsql = "EXEC SpSteFormaImpresionChequesProveedor 0, " & IIf(Me.radChequesPendientes.Checked, 1, 0) & ", " & InfoSistema.IDCuenta & ", '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
                Else 'Solo Filtra las Solicitudes de Cheque de la Delegación del Usuario:
                    Strsql = "EXEC SpSteFormaImpresionChequesProveedor " & InfoSistema.IDDelegacion & ", " & IIf(Me.radChequesPendientes.Checked, 1, 0) & ", " & InfoSistema.IDCuenta & ", '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
                End If

            End If

            If XdsSolicitudes.ExistTable("Solicitud") Then
                XdsSolicitudes("Solicitud").ExecuteSql(Strsql)
            Else
                XdsSolicitudes.NewTable(Strsql, "Solicitud")
                XdsSolicitudes("Solicitud").Retrieve()
            End If

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

            'Asignando a las fuentes de datos al Grid:
            Me.grdSolicitudes.DataSource = XdsSolicitudes("Solicitud").Source
            Me.grdSolicitudes.Rebind(False)
            Me.grdSolicitudes.FetchRowStyles = True
            Me.grdSolicitudes.Caption = " Listado de Solicitudes de Cheque Autorizadas (" + Me.grdSolicitudes.RowCount.ToString + " registros)"
            FormatoSolicitudes()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       FormatoSolicitudes
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre las Solicitudes de Cheque en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoSolicitudes()
        Try

            'Configuración del Grid: 
            Me.grdSolicitudes.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nCodigo").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("Fuente").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("sNumSesion").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nCodigoFNC").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nAutomatica").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nSteImpresionChequeID").Visible = False
            Me.grdSolicitudes.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            'Me.grdSolicitudes.Splits(0).DisplayColumns("sCodigoInterno").Visible = False

            Me.grdSolicitudes.Splits(0).DisplayColumns("MarcadoParaImpresion").Width = 50
            Me.grdSolicitudes.Splits(0).DisplayColumns("dFechaSolicitudCheque").Width = 80
            Me.grdSolicitudes.Splits(0).DisplayColumns("NombreGrupo").Width = 150
            Me.grdSolicitudes.Splits(0).DisplayColumns("Beneficiario").Width = 300
            Me.grdSolicitudes.Splits(0).DisplayColumns("Cedula").Width = 100
            Me.grdSolicitudes.Splits(0).DisplayColumns("nMonto").Width = 80
            Me.grdSolicitudes.Splits(0).DisplayColumns("nNumeroCheque").Width = 85
            Me.grdSolicitudes.Splits(0).DisplayColumns("dFechaCheque").Width = 80
            Me.grdSolicitudes.Splits(0).DisplayColumns("nChequeImpreso").Width = 60
            Me.grdSolicitudes.Splits(0).DisplayColumns("ImpresoPor").Width = 130
            Me.grdSolicitudes.Splits(0).DisplayColumns("nChequeCerrado").Width = 90
            Me.grdSolicitudes.Splits(0).DisplayColumns("sNumeroCuenta").Width = 120

            Me.grdSolicitudes.Columns("MarcadoParaImpresion").Caption = "Imprimir"
            Me.grdSolicitudes.Columns("dFechaSolicitudCheque").Caption = "Fecha Solicitud"
            Me.grdSolicitudes.Columns("NombreGrupo").Caption = "Grupo Solidario"
            Me.grdSolicitudes.Columns("Beneficiario").Caption = "Nombre Socia"
            Me.grdSolicitudes.Columns("Cedula").Caption = "Cédula"
            Me.grdSolicitudes.Columns("nMonto").Caption = "Monto C$"
            Me.grdSolicitudes.Columns("nNumeroCheque").Caption = "Número Cheque"
            Me.grdSolicitudes.Columns("dFechaCheque").Caption = "Fecha Cheque"
            Me.grdSolicitudes.Columns("nChequeImpreso").Caption = "Impreso"
            Me.grdSolicitudes.Columns("ImpresoPor").Caption = "Impreso Por"
            Me.grdSolicitudes.Columns("nChequeCerrado").Caption = "Aplicado"
            Me.grdSolicitudes.Columns("sNumeroCuenta").Caption = "Cuenta Bancaria"

            If Me.TipoCheque = 1 Then

                Me.grdSolicitudes.Columns("Beneficiario").Caption = "Beneficiario"
                Me.grdSolicitudes.Splits(0).DisplayColumns("NombreGrupo").Visible = False
            End If

            Me.grdSolicitudes.Splits(0).DisplayColumns("MarcadoParaImpresion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("dFechaSolicitudCheque").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("dFechaCheque").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("nChequeImpreso").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("nChequeCerrado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSolicitudes.Columns("MarcadoParaImpresion").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdSolicitudes.Columns("nChequeImpreso").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdSolicitudes.Columns("nChequeCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdSolicitudes.Splits(0).DisplayColumns("MarcadoParaImpresion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("dFechaSolicitudCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("NombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("Beneficiario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("Cedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("nMonto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("nNumeroCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("dFechaCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("nChequeImpreso").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("ImpresoPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("nChequeCerrado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitudes.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdSolicitudes.Columns("dFechaSolicitudCheque").NumberFormat = "dd/MM/yyyy"
            Me.grdSolicitudes.Columns("dFechaCheque").NumberFormat = "dd/MM/yyyy"
            Me.grdSolicitudes.Columns("nMonto").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdsSolicitudes = New BOSistema.Win.XDataSet
            Control.CheckForIllegalCrossThreadCalls = False



            '1 Es Cheque de Gastos Solicitud de Cheque (Pagos Proveedores)
            '0 Es Cheque de Pago a Delegadas Solicitud de Cheque (Otros Cheques)

            If Me.TipoCheque = 0 Then
                Me.Text = "Impresión de Cheques Socias"
            Else
                Me.Text = "Impresión de Cheques Proveedores"
                PorGrupo.Enabled = False
            End If


            'Limpiar los Grids, estructura y Datos
            Me.grdSolicitudes.ClearFields()

            '-- Encuentra parámetros de Delegación.
            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       tbImpresionCheques_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbImpresionCheques.
    '-------------------------------------------------------------------------
    Private Sub tbImpresionCheques_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbImpresionCheques.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolModificar"
                LlamaAsignarChequera()
            Case "toolLimpiarCheque"
                LlamaLimpiarCheque()
            Case "toolLimpiarChequeACTUAL"
                LlamaLimpiarChequeACTUAL()
            Case "toolMarcar"
                LlamaMarcarChequeParaImprimir()
            Case "toolDesmarcar"
                LlamaDesmarcarChequeParaImprimir()
            Case "toolCerrarDia"
                LlamaCerrarDiaChequera()
            Case "toolReabrirDia"
                LlamaReabrirDiaChequera()
            Case "toolImprimir"
                LlamaImprimirCheques()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
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
                CargarSolicitudesAutorizadas()
                FormatoSolicitudes()
            Case "toolSalir"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/01/2009
    ' Procedure Name:       LlamaLimpiarCheque
    ' Descripción:          Este evento permite limpiar número de cheque y
    '                       fecha del cheque para el cheque actual y cheques
    '                       superiores en caso de existir para la Cuenta
    '                       Bancaria.
    '-------------------------------------------------------------------------
    Private Sub LlamaLimpiarCheque()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.
            Dim nTotalChequesLimpiar As Integer

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Chequera no esta asignada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") " & _
                     "AND (nNumeroCheque IS NULL)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("No se ha asignado el número de cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Solicitud Cheque Actual se encuentra Aplicada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Solicitud de Cheque se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si solicitud actual tiene el Cheque generado en Contabilidad:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable AS a " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se generó el Comprobante de Egresos en Contabilidad.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Validar si alguna de las Solicitudes de cheques superiores esta Aplicada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nChequeCerrado = 1) AND (nSccSolicitudChequeID IN (SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                                                    " FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                                                    " WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") AND (SccSolicitudCheque.nNumeroCheque IS NOT NULL AND SccSolicitudCheque.nNumeroCheque >= " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ") AND (SccSolicitudChequeDetalle.nDebito = 0)))"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se Aplicó la Solicitud de Cheque para" & Chr(13) & "número(s) superior(es) de chequera en la Cuenta Bancaria.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Validar si alguno de los cheques superiores tiene cheque generado en Contabilidad
            'para la Cuenta Bancaria:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable AS a " & _
                     "WHERE nSccSolicitudChequeID IN (SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                                                  " FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                                                  " WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") AND (SccSolicitudCheque.nNumeroCheque IS NOT NULL AND SccSolicitudCheque.nNumeroCheque >= " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ") AND (SccSolicitudChequeDetalle.nDebito = 0))"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se generó el Comprobante de Egresos en Contabilidad para" & Chr(13) & "número(s) superior(es) de chequera en la Cuenta Bancaria.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible limpiar chequera si alguno de los cheques superiores de la Cuenta 
            'Bancaria esta marcado para(impresión) por cualquier usuario:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SteImpresionCheque " & _
                     "WHERE nSccSolicitudChequeID IN (SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                                                  " FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                                                  " WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") AND (SccSolicitudCheque.nNumeroCheque IS NOT NULL AND SccSolicitudCheque.nNumeroCheque >= " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ") AND (SccSolicitudChequeDetalle.nDebito = 0))"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen cheques marcados para impresión.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Advertir cuantos cheques superiores incluyendo el cheque actual se limpiaran 
            'para la Cuenta Bancaria:
            StrSql = "SELECT  COUNT(SccSolicitudCheque.nSccSolicitudChequeID) AS TotalCks " & _
                     "FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                     "WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") AND (SccSolicitudCheque.nNumeroCheque IS NOT NULL AND SccSolicitudCheque.nNumeroCheque >= " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ") AND (SccSolicitudChequeDetalle.nDebito = 0)"
            nTotalChequesLimpiar = XcDatos.ExecuteScalar(StrSql)
            If nTotalChequesLimpiar > 1 Then
                If MsgBox("Se limpiaran un total de " & nTotalChequesLimpiar & " solicitudes con cheque asignado" & Chr(13) & "siendo necesaria la reasignación de la chequera." & Chr(13) & "¿Está seguro que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            'Limpiar Número(s) de Cheque(s) en SccSolicitudCheque para el cheque actual y superiores
            'de la Cuenta Bancaria del cheque actual.
            StrSql = " Update SccSolicitudCheque " & _
                     " SET nNumeroCheque = NULL, dFechaCheque = NULL, " & _
                     "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
                     " WHERE nSccSolicitudChequeID IN (SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                                                  " FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                                                  " WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") AND (SccSolicitudCheque.nNumeroCheque IS NOT NULL AND SccSolicitudCheque.nNumeroCheque >= " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ") AND (SccSolicitudChequeDetalle.nDebito = 0))"
            XcDatos.ExecuteNonQuery(StrSql)
            Call GuardarAuditoria(5, 25, "Limpieza de Chequera Cuenta Bancaria: " & XdsSolicitudes("Solicitud").ValueField("sNumeroCuenta") & ". Total de Cheques: " & nTotalChequesLimpiar & ".")

            '-- Refrescar Datos
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            'Ubicar la selección en la posición original:
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position
            MsgBox("Se eliminó asignación de chequera para " & nTotalChequesLimpiar & " cheque(s).", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/02/2009
    ' Procedure Name:       LlamaLimpiarChequeACTUAL
    ' Descripción:          Este evento permite limpiar número de cheque y
    '                       fecha del cheque para el cheque actual.
    '-------------------------------------------------------------------------
    Private Sub LlamaLimpiarChequeACTUAL()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Chequera no esta asignada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("No se ha asignado el número de cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible Solicitud Cheque Ya se encuentra Aplicada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Solicitud de Cheque se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si solicitud actual tiene el Cheque generado en Contabilidad:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable AS a " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se generó el Comprobante de Egresos en Contabilidad.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si ya se encuentra marcado para imprimir por usuario actual u otro usuario:
            StrSql = "SELECT SsgCuenta.Login " & _
                     "FROM SteImpresionCheque INNER JOIN SsgCuenta ON SteImpresionCheque.nUsuarioCreacionID = SsgCuenta.SsgCuentaID " & _
                     "WHERE (SteImpresionCheque.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El cheque se encuentra marcado para impresión" & Chr(13) & "por el usuario: " & XcDatos.ExecuteScalar(StrSql) & ".", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar:
            If MsgBox("Se limpiará asignación de chequera del cheque actual." & Chr(13) & "¿Está seguro que desea continuar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- Limpiar Número(s) de Cheque(s) en SccSolicitudCheque para el cheque actual y superiores
            'de la Cuenta Bancaria del cheque actual.
            StrSql = " Update SccSolicitudCheque " & _
                     " SET nNumeroCheque = NULL, dFechaCheque = NULL, " & _
                     "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
                     " WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            XcDatos.ExecuteNonQuery(StrSql)

            '-- Refrescar Datos
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            'Ubicar la selección en la posición original:
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position
            MsgBox("Se eliminó asignación de chequera para la solicitud de cheque.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/01/2009
    ' Procedure Name:       LlamaDesmarcarChequeParaImprimir
    ' Descripción:          Este evento permite desmarcar un cheque para
    '                       su envio a Impresion.
    '-------------------------------------------------------------------------
    Private Sub LlamaDesmarcarChequeParaImprimir()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            Dim intPosicion As Integer
            Dim IntUltimoCkMarcado As Integer

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Chequera no esta asignada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("No se ha asignado el número de cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If


            'Imposible si no se encuentra marcado para imprimir por usuario actual:
            StrSql = "SELECT SteImpresionCheque.* " & _
                     "FROM SteImpresionCheque " & _
                     "WHERE (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ") and (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("El cheque no se encuentra marcado para impresión" & Chr(13) & "por el usuario actual.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si no es el último cheque marcado para impresión por el usuario actual:
            StrSql = "SELECT SteImpresionCheque.nSteImpresionChequeID " & _
                     "FROM SteImpresionCheque INNER JOIN SccSolicitudCheque ON SteImpresionCheque.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "WHERE  (SteImpresionCheque.nUsuarioCreacionID = " & InfoSistema.IDCuenta & ") " 'HAVING (MAX(SccSolicitudCheque.nNumeroCheque) < " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ")
            If RegistrosAsociados(StrSql) Then
                StrSql = "SELECT MAX(SccSolicitudCheque.nNumeroCheque) AS UltimoCK " & _
                         "FROM SteImpresionCheque INNER JOIN SccSolicitudCheque ON SteImpresionCheque.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "WHERE  (SteImpresionCheque.nUsuarioCreacionID = " & InfoSistema.IDCuenta & ") " 'HAVING (MAX(SccSolicitudCheque.nNumeroCheque) < " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ")
                IntUltimoCkMarcado = XcDatos.ExecuteScalar(StrSql)
                If IntUltimoCkMarcado <> CInt(XdsSolicitudes("Solicitud").ValueField("nNumeroCheque")) Then
                    MsgBox("Existen cheques superiores marcados para impresión.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If

            'Valida si tiene el Cheque generado en Contabilidad:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable AS a " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se generó el Comprobante de Egresos en Contabilidad.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Elimina Id de Solicitud de Cheque en tabla temporal de impresión para usuario actual:
            StrSql = "Delete From SteImpresionCheque  " & _
                     "Where (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") " & _
                     "And (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ")"
            XcDatos.ExecuteNonQuery(StrSql)

            '-- Refrescar Datos
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            'Ubicar la selección en la posición original:
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position


        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/01/2009
    ' Procedure Name:       LlamaMarcarChequeParaImprimir
    ' Descripción:          Este evento permite marcar un cheque para
    '                       su envio a Impresion.
    '                       El Cheque ya debe tener Numero y Fecha asignada.
    '-------------------------------------------------------------------------
    Private Sub LlamaMarcarChequeParaImprimir()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.
            Dim IntUltimoCkMarcado As Integer
            Dim IntTotalCkMarcados As Integer

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If


            'Valida si el cheque ya está marcado para impresion
            If XdsSolicitudes("Solicitud").ValueField("MarcadoParaImpresion") Then
                MsgBox("El cheque ya se encuentra marcado para impresión.", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Imposible si la Chequera no esta asignada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("No se ha asignado el número de cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible marcar más de nueve cheques para impresión por usuario actual:
            StrSql = "SELECT COUNT(nSccSolicitudChequeID) AS TotalCK " & _
                     "FROM SteImpresionCheque " & _
                     "WHERE (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ")"
            IntTotalCkMarcados = XcDatos.ExecuteScalar(StrSql)
            If IntTotalCkMarcados = 15 And RadTres.Checked Then
                MsgBox("Imposible marcar más de quince cheques para impresión en formato de tres por pagina.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            If IntTotalCkMarcados = 20 And RadCuatro.Checked Then
                MsgBox("Imposible marcar más de veinte cheques para impresión en formato de cuatro por pagina.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If


            'Valida si tiene el Cheque generado en Contabilidad:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable AS a " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se generó el Comprobante de Egresos.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If



            'Imposible si ya se encuentra marcado para imprimir por usuario actual u otro usuario:
            StrSql = "SELECT SsgCuenta.Login " & _
                     "FROM SteImpresionCheque INNER JOIN SsgCuenta ON SteImpresionCheque.nUsuarioCreacionID = SsgCuenta.SsgCuentaID " & _
                     "WHERE (SteImpresionCheque.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El cheque ya se encuentra marcado para impresión" & Chr(13) & "por el usuario: " & XcDatos.ExecuteScalar(StrSql) & ".", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si el último cheque marcado para impresión por el usuario actual
            'no es el actual menos uno a fin de garantizar secuencia de la chequera
            'evitandose posibles lagunas.
            StrSql = "SELECT SteImpresionCheque.nSteImpresionChequeID " & _
                     "FROM SteImpresionCheque INNER JOIN SccSolicitudCheque ON SteImpresionCheque.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "WHERE  (SteImpresionCheque.nUsuarioCreacionID = " & InfoSistema.IDCuenta & ") " 'HAVING (MAX(SccSolicitudCheque.nNumeroCheque) < " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ")
            If RegistrosAsociados(StrSql) Then
                StrSql = "SELECT MAX(SccSolicitudCheque.nNumeroCheque) AS UltimoCK " & _
                         "FROM SteImpresionCheque INNER JOIN SccSolicitudCheque ON SteImpresionCheque.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "WHERE  (SteImpresionCheque.nUsuarioCreacionID = " & InfoSistema.IDCuenta & ") " 'HAVING (MAX(SccSolicitudCheque.nNumeroCheque) < " & XdsSolicitudes("Solicitud").ValueField("nNumeroCheque") & ")
                IntUltimoCkMarcado = XcDatos.ExecuteScalar(StrSql)
                If IntUltimoCkMarcado <> (CInt(XdsSolicitudes("Solicitud").ValueField("nNumeroCheque")) - 1) Then
                    MsgBox("Imposible marcar para impresión." & Chr(13) & "El último cheque marcado para impresión es el " & IntUltimoCkMarcado & Chr(13) & "por lo que no habría secuencia numerica en chequera.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If

            '-- Inserta Id de Solicitud de Cheque en tabla temporal de impresión:
            StrSql = "Insert Into SteImpresionCheque  " & _
                     "(nSccSolicitudChequeID, nUsuarioCreacionID, dFechaCreacion) " & _
                     " Values (" & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ", " & InfoSistema.IDCuenta & ", GetDate())"
            XcDatos.ExecuteNonQuery(StrSql)

            '-- Refrescar Datos
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            'Ubicar la selección en la posición original:
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position

            '-- Si el Total de Cheques marcados por el usuario es tres
            'Consultar si desea enviarlos a impresión:
            'Imposible marcar más de nueve cheques para impresión por usuario actual:
            StrSql = "SELECT COUNT(nSccSolicitudChequeID) AS TotalCK " & _
                     "FROM SteImpresionCheque " & _
                     "WHERE (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ")"
            IntTotalCkMarcados = XcDatos.ExecuteScalar(StrSql)
            REM Solicitado Por Lester 09/10/2009 pasar de 3 a 9 cheques:
            REM Solicitado Por Lester 22/10/2009 pasar de 9 a 15 cheques:

            'No se permite la impresion de cheques antes de la generación del comprobante 

            'If IntTotalCkMarcados = 15 And RadTres.Checked Then
            '    If MsgBox("Desea imprimir los Cheques seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
            '        LlamaImprimirCheques()
            '    End If
            'End If

            'If IntTotalCkMarcados = 20 And RadCuatro.Checked Then
            '    If MsgBox("Desea imprimir los Cheques seleccionados?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
            '        LlamaImprimirCheques()
            '    End If
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/01/2009
    ' Procedure Name:       LlamaImprimirCheques
    ' Descripción:          Este procedimiento permite imprimir los cheques
    '                       físicos indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirCheques()
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatos As New BOSistema.Win.XComando

        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing
        Try
            Dim strSQL As String = ""
            Dim intPosicion As Long

            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si no existen Cheques marcados para impresion por usuario actual:
            strSQL = "SELECT SteImpresionCheque.* " & _
                     "FROM SteImpresionCheque " & _
                     "WHERE (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existen cheques marcados para impresión.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Si se envian mas de tres cheques deben ser multiplos de tres:
            '¿No es necesario? Aunque sean 4 o 5 se detendra en el cheque final
            'strSQL = "SELECT COUNT(nSccSolicitudChequeID) AS TotalCK " & _
            '        "FROM SteImpresionCheque WHERE (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ")"
            'If XcDatos.ExecuteScalar(strSQL) > 3 Then
            'End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("nUsuarioID") = "'" & InfoSistema.IDCuenta & "'"
            '-- Parametros Procedimiento almacenado [SpSteGridImpresionCheques]:  
            If IntPermiteConsultar = 1 Then
                frmVisor.Parametros("@nStbDelegacionProgramaID") = 0
            Else
                frmVisor.Parametros("@nStbDelegacionProgramaID") = InfoSistema.IDDelegacion
            End If
            frmVisor.Parametros("@nChequesPendientesImprimir") = IIf(Me.radChequesPendientes.Checked, 1, 0)
            frmVisor.Parametros("@nUsuarioID") = InfoSistema.IDCuenta
            frmVisor.Parametros("@FechaInicial") = Format(CDate(cdeFechaD.Text), "yyyy-MM-dd")
            frmVisor.Parametros("@FechaFinal") = Format(CDate(cdeFechaH.Text), "yyyy-MM-dd")

            If RadTres.Checked Then
                frmVisor.NombreReporte = "RepSteTE32.rpt"
            Else
                frmVisor.NombreReporte = "RepSteTE324Cheques.rpt"
            End If

            frmVisor.Text = "Impresión de Chequera Física"
            frmVisor.ShowDialog()

            'Consultar con el usuario si desea marcar los cheques como impresos:
            'If MsgBox("Desea marcar estos cheques como impresos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
            'Para cada uno de los cheques marcados para impresión por el usuario:
            'Inicio la Transacción:
            Trans = New BOSistema.Win.Transact
            Trans.BeginTrans()
            '-- 1. Marcar campo nChequeImpreso en 1 en la tabla SccSolicitudCheque
            '      y grabar usuario que imprimio en nUsuarioImprimioChequeID. 
            '      Esto para cada una de las Solicitudes de cheque marcadas para
            '      impresión por el usuario actual. 
            strSQL = " Update SccSolicitudCheque " & _
                     " SET nChequeImpreso = 1, nChequeProcesadoImpresion= 1, nUsuarioImprimioChequeID = " & InfoSistema.IDCuenta & ", " & _
                     "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
                     " WHERE nSccSolicitudChequeID IN (SELECT SteImpresionCheque.nSccSolicitudChequeID " & _
                                                  " FROM SteImpresionCheque  " & _
                                                  " WHERE (SteImpresionCheque.nUsuarioCreacionID = " & InfoSistema.IDCuenta & "))"
            Trans.ExecuteSql(strSQL)
            '-- 2. Eliminar de SteImpresionCheque todos los cheques marcados para
            '--    impresion por el usuario actual. 
            strSQL = "Delete From SteImpresionCheque  " & _
                     "Where (nUsuarioCreacionID = " & InfoSistema.IDCuenta & ")"
            Trans.ExecuteSql(strSQL)

            '-- Finaliza Transacción:
            Trans.Commit()
            'End If

            '-- Refrescar Datos:
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            'Ubicar la selección en la posición original:
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            frmVisor = Nothing
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/11/2009
    ' Procedure Name:       LlamaCerrarDiaChequera
    ' Descripción:          Este procedimiento permite Cerrar un Día de
    '                       Entrega de Cheques a fin de permitir a Contabilidad
    '                       General la generación automática de Comprobantes de
    '                       Egreso.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrarDiaChequera()
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim StrSql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.
            Dim intPeriodoId As Integer
            Dim nCuentaBancariaID As Integer
            Dim nNumeroCk As Integer
            Dim sNumeroCuenta As String

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Chequera no ha sido asignada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Aún no se ha asignado Número de Cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            '-- Imposible si la Solicitud no se encuentra Autorizada:
            If (CInt(XdsSolicitudes("Solicitud").ValueField("sCodigoInterno")) <> 4) Then
                MsgBox("La Solicitud no se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT C.sDescripcion " & _
                     "FROM  SccSolicitudCheque S INNER JOIN StbValorCatalogo C ON S.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '4') AND (S.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("La Solicitud no se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si no está marcado para impresión:
           
            StrSql = "SELECT SsgCuenta.Login " & _
                     "FROM  SteImpresionCheque INNER JOIN SsgCuenta ON SteImpresionCheque.nUsuarioCreacionID = SsgCuenta.SsgCuentaID " & _
                     "WHERE (SteImpresionCheque.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible generar Comprobante de Cheque." & Chr(13) & Chr(13) & "Solicitud de cheque aún se encuentra Marcada para" & Chr(13) & "Impresión por el usuario: " & XcDatos.ExecuteScalar(StrSql) & ".", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si ya se genero el Cheque:
            If (CInt(XdsSolicitudes("Solicitud").ValueField("sCodigoInterno")) = 6) Then
                MsgBox("Ya se generó el Comprobante para esta Solicitud.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT C.sDescripcion " & _
                     "FROM  SccSolicitudCheque S INNER JOIN StbValorCatalogo C ON S.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '6') AND (S.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Ya se generó el Comprobante para esta Solicitud.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si se creará Sobregiro en las Cuentas indicadas:
            StrSql = "SELECT c.nScnCatalogoContableID " & _
                  "FROM SccSolicitudChequeDetalle AS d INNER JOIN ScnCatalogoContable AS c ON d.nScnCatalogoContableID = c.nScnCatalogoContableID " & _
                  "WHERE (d.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0) AND (c.nSteCuentaBancariaID IS NOT NULL)"
            If nMontoSaldoRojo(XcDatos.ExecuteScalar(StrSql), 0, XdsSolicitudes("Solicitud").ValueField("nMonto")) < 0 Then
                MsgBox("El movimiento crearía sobregiro bancario.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            '-- Imposible si no existe Periodo registrado para la Fecha de la Solicitud de Cheque:
            intPeriodoId = IDPeriodo(XdsSolicitudes("Solicitud").ValueField("dFechaSolicitudCheque"))
            If intPeriodoId = 0 Then
                MsgBox("No existe un período Contable creado para" & Chr(13) & "la fecha de la Solicitud de Cheque.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si el Periodo se encuentra Cerrado:
            If PeriodoAbierto(intPeriodoId) = False Then
                MsgBox("El período Contable correspondiente a la fecha de la" & Chr(13) & "Solicitud de Cheque se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If



            ''Imposible Solicitud Cheque Ya se encuentra Aplicada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Solicitud de Cheque se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If


            'Imposible si no existe cuenta bancaria corriente como credito en el detalle de la Solicitud de Cheque:
            StrSql = "SELECT a.nSteCuentaBancariaID " & _
                     "FROM SteCuentaBancaria AS a INNER JOIN StbValorCatalogo AS b ON a.nStbTipoCuentaID = b.nStbValorCatalogoID INNER JOIN dbo.ScnCatalogoContable AS c ON a.nSteCuentaBancariaID = c.nSteCuentaBancariaID INNER JOIN SccSolicitudChequeDetalle AS d ON c.nScnCatalogoContableID = d.nScnCatalogoContableID " & _
                     "WHERE (b.sCodigoInterno = '2') AND (d.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existe crédito a cuenta bancaria corriente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Encuentra ID de la Cuenta Bancaria:
            nCuentaBancariaID = XcDatos.ExecuteScalar(StrSql)

            'Encuentra Numero de Cheque (Numero de Cuenta Bancaria + Numero Chequera):
            StrSql = "SELECT a.sNumeroCuenta " & _
                     "FROM SteCuentaBancaria AS a INNER JOIN StbValorCatalogo AS b ON a.nStbTipoCuentaID = b.nStbValorCatalogoID INNER JOIN dbo.ScnCatalogoContable AS c ON a.nSteCuentaBancariaID = c.nSteCuentaBancariaID INNER JOIN SccSolicitudChequeDetalle AS d ON c.nScnCatalogoContableID = d.nScnCatalogoContableID " & _
                     "WHERE (b.sCodigoInterno = '2') AND (d.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0)"
            sNumeroCuenta = XcDatos.ExecuteScalar(StrSql) & nNumeroCk

            'Imposible si cheque a asignar creará un comprobante de cheque ACTIVO duplicado para la Cuenta Bancaria:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (sNumeroTransaccion = '" & sNumeroCuenta & "') AND (StbValorCatalogo.sCodigoInterno <> '3')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El Número de Cheque asignado ya existe para la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Confirmar Acción:
            If MsgBox("¿Esta seguro de Aplicar la Solicitud  para" & Chr(13) & "la Cuenta Bancaria seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- Cerrar Solicitudes de Cheques Autorizadas para la Cuenta Bancaria:
            StrSql = " Update SccSolicitudCheque " & _
                     " SET nChequeCerrado = 1, " & _
                     "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
                     " WHERE nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")

            'XcDatos.Execute(StrSql)


            StrSql = "Exec SpAUDITSccSolicitudChequeCERRARAUTORIZA 'Update','Actualizar  Cerrar Solicitud Autorizada'," & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & "," & InfoSistema.IDCuenta & ",1"

            XcDatos.ExecuteNonQuery(StrSql)
            Call GuardarAuditoria(5, 25, "Aplicación de Cheques Físicos Cuenta Bancaria: " & XdsSolicitudes("Solicitud").ValueField("sNumeroCuenta") & ".")

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

            '-- Refrescar Datos 
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position
            MsgBox("Se aplicó la Solicitud de Cheque.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    REM CIERRE POR DIA ANTES DE AYUDA DE MEMORIA No. 31: 23/11/2009
    'Private Sub LlamaCerrarDiaChequera()
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Try
    '        Dim StrSql As String
    '        Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

    '        'Si no existen registros:
    '        If Me.grdSolicitudes.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO tiene permisos de Edición fuera de su Delegación: 
    '        If IntPermiteEditar = 0 Then
    '            If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
    '                MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '        End If

    '        'Imposible si la Chequera no ha sido asignada:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("Aún no se ha asignado la Fecha del Cheque.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si la Fecha del Cheque para la Solicitud Ya se encuentra Cerrada:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("La Fecha del Cheque se encuentra Cerrada.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible Cerrar Día si existen días anteriores sin Cerrar:
    '        'Solicitudes NO ANULADAS:
    '        REM Correo Lester 19/11/2009 VALIDAR UNICAMENTE SI ES FONDO PRESUPUESTO
    '        REM o SIN CERRAR PARA EL FONDO.
    '        StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
    '                 "WHERE (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1)"
    '        If RegistrosAsociados(StrSql) Then
    '            StrSql = "SELECT nSccSolicitudChequeID " & _
    '                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                     "WHERE (nNumeroCheque IS NOT NULL) AND (nChequeCerrado = 0) " & _
    '                     "AND (dFechaCheque < CONVERT(DATETIME, '" & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "yyyy-MM-dd") & "', 102)) AND (StbValorCatalogo.sCodigoInterno <> '5')"
    '            If RegistrosAsociados(StrSql) = True Then
    '                MsgBox("Existen Fechas de Cheque anteriores sin Cerrar.", MsgBoxStyle.Information, NombreSistema)
    '                Exit Sub
    '            End If
    '        End If

    '        'Confirmar Acción:
    '        If MsgBox("¿Esta seguro de Cerrar la Fecha de Cheques: " & XdsSolicitudes("Solicitud").ValueField("dFechaCheque") & "?" & _
    '           Chr(13) & "No se permitirá la generación de nuevos cheques para esta fecha.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '        '-- Cerrar Fecha Cheques:
    '        StrSql = " Update SccSolicitudCheque " & _
    '                 " SET nChequeCerrado = 1, " & _
    '                 "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
    '                 " WHERE (dFechaCheque = CONVERT(DATETIME, '" & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "yyyy-MM-dd") & "', 102))"
    '        XcDatos.ExecuteNonQuery(StrSql)
    '        Call GuardarAuditoria(5, 25, "Cierre de Fecha de Cheques: " & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "dd/MM/yyyy") & ".")

    '        '-- Refrescar Datos
    '        intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
    '        CargarSolicitudesAutorizadas()
    '        XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
    '        Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position
    '        MsgBox("Se cerró la Fecha de Cheques: " & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "dd/MM/yyyy") & ".", MsgBoxStyle.Information, NombreSistema)

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/11/2009
    ' Procedure Name:       LlamaReabrirDiaChequera
    ' Descripción:          Este procedimiento permite Reaperturar un Día de
    '                       Entrega de Cheques siempre que Contabilidad aún no
    '                       haya generado Comprobantes de Egreso.
    '-------------------------------------------------------------------------

    Private Sub LlamaReabrirDiaChequera()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Número Cheque Desde: 
            If Trim(RTrim(Me.txtCkDesde.Text)).ToString.Length = 0 Then
                MsgBox("El Número Inicial de Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtCkDesde.Focus()
                Exit Sub
            End If

            'Número Cheque Hasta: 
            If Trim(RTrim(Me.txtCkHasta.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Cheque Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtCkHasta.Focus()
                Exit Sub
            End If

            'Número Cheque Desde > 0: 
            If CInt(Me.txtCkDesde.Text) = 0 Then
                MsgBox("Número de Cheque Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtCkDesde.Focus()
                Exit Sub
            End If

            '4. Número Cheque Hasta: 
            If CInt(Me.txtCkHasta.Text) = 0 Then
                MsgBox("Número de Cheque Final Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtCkHasta.Focus()
                Exit Sub
            End If

            'Número de Cheque (Hasta) mayor: 
            If CInt(Me.txtCkHasta.Text) < CInt(Me.txtCkDesde.Text) Then
                MsgBox("El No. del Cheque Final NO DEBE ser Menor que el No. Inicial.", MsgBoxStyle.Critical, NombreSistema)
                Me.txtCkHasta.Focus()
                Exit Sub
            End If

            'Imposible si no hay Chequera aplicada
            'para la Cta Bancaria en cheques del rango indicado:
            StrSql = " SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     " FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                     " WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") " & _
                     " AND (SccSolicitudCheque.nChequeCerrado  = 1) AND (SccSolicitudCheque.nNumeroCheque BETWEEN " & Trim(RTrim(Me.txtCkDesde.Text)) & " and " & Trim(RTrim(Me.txtCkHasta.Text)) & ")"
            'StrSql = "SELECT nSccSolicitudChequeID " & _
            '         "FROM SccSolicitudCheque " & _
            '         "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existen cheques aplicados en el rango" & Chr(13) & "para la cuenta bancaria.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
           
            'Imposible si Contabilidad ya genero Comprobantes de Egreso para alguna de las  
            'Solicitudes aplicadas en el rango de cheques de la cuenta de bancos:
            StrSql = " SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     " FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                     " INNER JOIN ScnTransaccionContable ON SccSolicitudCheque.nSccSolicitudChequeID = ScnTransaccionContable.nSccSolicitudChequeID " & _
                     " WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ") " & _
                     " AND (SccSolicitudCheque.nChequeCerrado  = 1) AND (SccSolicitudCheque.nNumeroCheque BETWEEN " & Trim(RTrim(Me.txtCkDesde.Text)) & " and " & Trim(RTrim(Me.txtCkHasta.Text)) & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Existen Comprobantes de Egreso generados" & Chr(13) & "por Contabilidad para la Fecha del Cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar Acción:
            If MsgBox("¿Esta seguro de Revertir la Aplicación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- Revertir Aplicacion de Cheques en el Rango para la Cuenta Bancaria:
            StrSql = " Update SccSolicitudCheque " & _
                     " SET nChequeCerrado = 0, " & _
                     "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
                     " WHERE (nChequeCerrado = 1) AND (nNumeroCheque BETWEEN " & Trim(RTrim(Me.txtCkDesde.Text)) & " AND " & Trim(RTrim(Me.txtCkHasta.Text)) & ")" & _
                     " AND (nStbEstadoSolicitudID IN  (SELECT StbValorCatalogo.nStbValorCatalogoID " & _
                                                      " FROM StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID " & _
                                                      "WHERE (StbCatalogo.sNombre = 'EstadoSolicitudCheque') AND (StbValorCatalogo.sCodigoInterno = '4'))) " & _
                     " AND (nSccSolicitudChequeID IN (SELECT SccSolicitudChequeDetalle.nSccSolicitudChequeID " & _
                     "                                FROM SccSolicitudChequeDetalle INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                     "                                WHERE (ScnCatalogoContable.nSteCuentaBancariaID = " & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ")))"
            'StrSql = " Update SccSolicitudCheque " & _
            '         " SET nChequeCerrado = 0, " & _
            '         "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
            '         " WHERE (dFechaCheque = CONVERT(DATETIME, '" & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "yyyy-MM-dd") & "', 102))"


            StrSql = "Exec SpAUDITSccSolicitudChequeCERRARREVIERTE 'Update','Actualizar  Reabrir Solicitud Cerrado Cheque'," & XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID") & ",'" & Trim(RTrim(Me.txtCkDesde.Text)) & "','" & Trim(RTrim(Me.txtCkHasta.Text)) & "'," & InfoSistema.IDCuenta & ",1"

            XcDatos.ExecuteNonQuery(StrSql)
            Call GuardarAuditoria(5, 25, "Reversión de Aplicación Cheques Cuenta Bancaria: " & XdsSolicitudes("Solicitud").ValueField("sNumeroCuenta") & ".")

            '-- Refrescar Datos:
            intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudesAutorizadas()
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position
            MsgBox("Se revirtió aplicación de cheques en el rango.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    REM REAPERTURA DE CIERRE POR FECHA ANTES DE AYUDA DE MEMORIA No. 31: 23/11/2009
    'Private Sub LlamaReabrirDiaChequera()
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Try
    '        Dim StrSql As String
    '        Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

    '        'Si no existen registros:
    '        If Me.grdSolicitudes.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO tiene permisos de Edición fuera de su Delegación: 
    '        If IntPermiteEditar = 0 Then
    '            If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
    '                MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '        End If

    '        'Número Cheque Desde: 
    '        If Trim(RTrim(Me.txtCkDesde.Text)).ToString.Length = 0 Then
    '            MsgBox("El Número Inicial de Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
    '            Me.txtCkDesde.Focus()
    '            Exit Sub
    '        End If

    '        'Número Cheque Hasta: 
    '        If Trim(RTrim(Me.txtCkHasta.Text)).ToString.Length = 0 Then
    '            MsgBox("El Número del Cheque Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
    '            Me.txtCkHasta.Focus()
    '            Exit Sub
    '        End If

    '        'Número Cheque Desde > 0: 
    '        If CInt(Me.txtCkDesde.Text) = 0 Then
    '            MsgBox("Número de Cheque Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
    '            Me.txtCkDesde.Focus()
    '            Exit Sub
    '        End If

    '        '4. Número Cheque Hasta: 
    '        If CInt(Me.txtCkHasta.Text) = 0 Then
    '            MsgBox("Número de Cheque Final Inválido.", MsgBoxStyle.Critical, NombreSistema)
    '            Me.txtCkHasta.Focus()
    '            Exit Sub
    '        End If

    '        'Número de Cheque (Hasta) mayor: 
    '        If CInt(Me.txtCkHasta.Text) < CInt(Me.txtCkDesde.Text) Then
    '            MsgBox("El No. del Cheque Final NO DEBE ser Menor que el No. Inicial.", MsgBoxStyle.Critical, NombreSistema)
    '            Me.txtCkHasta.Focus()
    '            Exit Sub
    '        End If

    '        'Imposible si la Chequera no ha sido asignada:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NULL)"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("Aún no se ha asignado la Fecha del Cheque.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si la Fecha del Cheque para la Solicitud no se encuentra Cerrada:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 0)"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("La Fecha del Cheque no se encuentra Cerrada.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si Contabilidad ya genero Comprobantes de Egreso en esa Fecha de Cheque:
    '        StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
    '                 "FROM  SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                 "WHERE (StbValorCatalogo.sCodigoInterno = '6') " & _
    '                 "AND (SccSolicitudCheque.dFechaCheque = CONVERT(DATETIME, '" & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "yyyy-MM-dd") & "', 102))"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("Existen Comprobantes de Egreso generados" & Chr(13) & "por Contabilidad para la Fecha del Cheque.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible Reaperturar Día si existen días posteriores Cerrados:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nNumeroCheque IS NOT NULL) AND (nChequeCerrado = 1) " & _
    '                 "AND (dFechaCheque > CONVERT(DATETIME, '" & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "yyyy-MM-dd") & "', 102))"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("Existen Fechas de Cheque posteriores Cerradas.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Confirmar Acción:
    '        If MsgBox("¿Esta seguro de Reabrir la Fecha de Cheques: " & XdsSolicitudes("Solicitud").ValueField("dFechaCheque") & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '        '-- Cerrar Fecha Cheques:
    '        StrSql = " Update SccSolicitudCheque " & _
    '                 " SET nChequeCerrado = 0, " & _
    '                 "     nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate() " & _
    '                 " WHERE (dFechaCheque = CONVERT(DATETIME, '" & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "yyyy-MM-dd") & "', 102))"
    '        XcDatos.ExecuteNonQuery(StrSql)
    '        Call GuardarAuditoria(5, 25, "Reapertura de Fecha de Cheques: " & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "dd/MM/yyyy") & ".")

    '        '-- Refrescar Datos
    '        intPosicion = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
    '        CargarSolicitudesAutorizadas()
    '        XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
    '        Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position
    '        MsgBox("Se reaperturo la Fecha de Cheques: " & Format(XdsSolicitudes("Solicitud").ValueField("dFechaCheque"), "dd/MM/yyyy") & ".", MsgBoxStyle.Information, NombreSistema)

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    Private Sub LlamaAsignarChequera()
        Dim ObjFrmSteEditCheque As New frmSteEditImpresionCheques
        Dim ObjFrmSteEditChequePorGrupo As New frmSteEditImpresionChequesPorGrupo
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim StrSql As String
            Dim IntIdSolicitud As Integer

            'Si no existen registros:
            If Me.grdSolicitudes.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Chequera ya esta asignada Antes debe limpiar el número:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NOT NULL)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se asignó el número de cheque." & Chr(13) & "Si desea reasignar el número antes" & Chr(13) & "debe limpiar el número de cheque.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si la Solicitud de Cheque esta aplicada:
            StrSql = "SELECT nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("La Solicitud de Cheque se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Valida si no tiene el Cheque generado en Contabilidad:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable AS a " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = True Then
                MsgBox("Ya se generó el Comprobante de Egresos ", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            If Me.PorGrupo.Checked = True Then
                'Me.PorGrupo.Checked = False
                ObjFrmSteEditChequePorGrupo.IdSolicitud = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
                ObjFrmSteEditChequePorGrupo.IdCuentaBancaria = XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID")
                ObjFrmSteEditChequePorGrupo.dFechaSolicitudCk = XdsSolicitudes("Solicitud").ValueField("dFechaSolicitudCheque")
                ObjFrmSteEditChequePorGrupo.IdGrupo = XdsSolicitudes("Solicitud").ValueField("nSclGrupoSolidarioID")
                ObjFrmSteEditChequePorGrupo.ShowDialog()
                IntIdSolicitud = ObjFrmSteEditChequePorGrupo.IdSolicitud
            Else
                ObjFrmSteEditCheque.IdSolicitud = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
                ObjFrmSteEditCheque.IdCuentaBancaria = XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID")
                ObjFrmSteEditCheque.dFechaSolicitudCk = XdsSolicitudes("Solicitud").ValueField("dFechaSolicitudCheque")

                ObjFrmSteEditCheque.ShowDialog()
                IntIdSolicitud = ObjFrmSteEditCheque.IdSolicitud
            End If


            ''Encuentra Solicitud siguiente:
            'StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
            '         "FROM SccSolicitudCheque INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
            '         "INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID  " & _
            '         "INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID " & _
            '         "INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID  " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '4') " & _
            '         "AND (SccSolicitudCheque.dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '         "AND (ScnCatalogoContable.nSteCuentaBancariaID IS NOT NULL) " & _
            '         "AND (SccSolicitudChequeDetalle.nDebito = 0)  " & _
            '         "AND (SccSolicitudCheque.nSccSolicitudChequeID > " & ObjFrmSteEditCheque.IdSolicitud & ") "
            ''Solo ver cheques pendientes de imprimir:
            'If Me.radChequesPendientes.Checked Then
            '    StrSql = StrSql + " AND (SccSolicitudCheque.nChequeImpreso = 0)"
            'End If
            ''Solo ver la Delegacion del usuario:
            'If IntPermiteConsultar = 0 Then
            '    StrSql = StrSql + " AND (ISNULL(SccSolicitudCheque.nStbDelegacionProgramaID, 0) = " & InfoSistema.IDDelegacion & ")"
            'End If
            'StrSql = StrSql + " ORDER BY SccSolicitudCheque.nSccSolicitudChequeID OPTION (FORCE ORDER)"
            'If XcDatos.ExecuteScalar(StrSql) = 0 Then
            '    'Si no hay Solicitud superior en el Grid se queda en la actual (última):
            '    IntIdSolicitud = ObjFrmSteEditCheque.IdSolicitud
            'Else
            '    'Pasa a la Solicitud siguiente del Grid:
            '    IntIdSolicitud = XcDatos.ExecuteScalar(StrSql)
            'End If

            'Se queda en la Solicitud actual:

            '-- Refrescar Datos:
            CargarSolicitudesAutorizadas()
            FormatoSolicitudes()
            'Se ubica en Solicitud correspondiente:
            XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", IntIdSolicitud)
            Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCheque.Close()
            ObjFrmSteEditCheque = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       LlamaAsignarChequera
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditImpresionCheques para asignar un número
    '                       de chequera y fecha del cheque a una Solicitud de 
    '                       cheque autorizadas sin comprobante de cheque emitido.
    '-------------------------------------------------------------------------
    'Private Sub LlamaAsignarChequera()
    '    Dim ObjFrmSteEditCheque As New frmSteEditImpresionCheques
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Try
    '        Dim StrSql As String
    '        Dim IntIdSolicitud As Integer

    '        'Si no existen registros:
    '        If Me.grdSolicitudes.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO tiene permisos de Edición fuera de su Delegación: 
    '        If IntPermiteEditar = 0 Then
    '            If InfoSistema.IDDelegacion <> XdsSolicitudes("Solicitud").ValueField("nStbDelegacionProgramaID") Then
    '                MsgBox("Imposible Modificar Cheques de otra Delegación.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '        End If

    '        'Imposible si la Chequera ya esta asignada Antes debe limpiar el número:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NOT NULL)"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("Ya se asignó el número de cheque." & Chr(13) & "Si desea reasignar el número antes" & Chr(13) & "debe limpiar el número de cheque.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si la Solicitud de Cheque esta aplicada:
    '        StrSql = "SELECT nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("La Solicitud de Cheque se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Valida si no tiene el Cheque generado en Contabilidad:
    '        StrSql = "SELECT nScnTransaccionContableID " & _
    '                 "FROM ScnTransaccionContable AS a " & _
    '                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
    '        If RegistrosAsociados(StrSql) = True Then
    '            MsgBox("Ya se generó el Comprobante de Egresos en Contabilidad.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        ObjFrmSteEditCheque.IdSolicitud = XdsSolicitudes("Solicitud").ValueField("nSccSolicitudChequeID")
    '        ObjFrmSteEditCheque.IdCuentaBancaria = XdsSolicitudes("Solicitud").ValueField("nSteCuentaBancariaID")
    '        ObjFrmSteEditCheque.dFechaSolicitudCk = XdsSolicitudes("Solicitud").ValueField("dFechaSolicitudCheque")

    '        ObjFrmSteEditCheque.ShowDialog()

    '        ''Encuentra Solicitud siguiente:
    '        'StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
    '        '         "FROM SccSolicitudCheque INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
    '        '         "INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID  " & _
    '        '         "INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID " & _
    '        '         "INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID  " & _
    '        '         "WHERE (StbValorCatalogo.sCodigoInterno = '4') " & _
    '        '         "AND (SccSolicitudCheque.dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
    '        '         "AND (ScnCatalogoContable.nSteCuentaBancariaID IS NOT NULL) " & _
    '        '         "AND (SccSolicitudChequeDetalle.nDebito = 0)  " & _
    '        '         "AND (SccSolicitudCheque.nSccSolicitudChequeID > " & ObjFrmSteEditCheque.IdSolicitud & ") "
    '        ''Solo ver cheques pendientes de imprimir:
    '        'If Me.radChequesPendientes.Checked Then
    '        '    StrSql = StrSql + " AND (SccSolicitudCheque.nChequeImpreso = 0)"
    '        'End If
    '        ''Solo ver la Delegacion del usuario:
    '        'If IntPermiteConsultar = 0 Then
    '        '    StrSql = StrSql + " AND (ISNULL(SccSolicitudCheque.nStbDelegacionProgramaID, 0) = " & InfoSistema.IDDelegacion & ")"
    '        'End If
    '        'StrSql = StrSql + " ORDER BY SccSolicitudCheque.nSccSolicitudChequeID OPTION (FORCE ORDER)"
    '        'If XcDatos.ExecuteScalar(StrSql) = 0 Then
    '        '    'Si no hay Solicitud superior en el Grid se queda en la actual (última):
    '        '    IntIdSolicitud = ObjFrmSteEditCheque.IdSolicitud
    '        'Else
    '        '    'Pasa a la Solicitud siguiente del Grid:
    '        '    IntIdSolicitud = XcDatos.ExecuteScalar(StrSql)
    '        'End If

    '        'Se queda en la Solicitud actual:
    '        IntIdSolicitud = ObjFrmSteEditCheque.IdSolicitud
    '        '-- Refrescar Datos:
    '        CargarSolicitudesAutorizadas()
    '        FormatoSolicitudes()
    '        'Se ubica en Solicitud correspondiente:
    '        XdsSolicitudes("Solicitud").SetCurrentByID("nSccSolicitudChequeID", IntIdSolicitud)
    '        Me.grdSolicitudes.Row = XdsSolicitudes("Solicitud").BindingSource.Position

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmSteEditCheque.Close()
    '        ObjFrmSteEditCheque = Nothing

    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
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
    ' Fecha:                26/01/2009
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
    ' Fecha:                26/01/2009
    ' Procedure Name:       grdSolicitudes_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSolicitudes_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSolicitudes.Filter
        Try
            XdsSolicitudes("Solicitud").FilterLocal(e.Condition)
            Me.grdSolicitudes.Caption = " Listado de Solicitudes de Cheque Autorizadas (" + Me.grdSolicitudes.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Asignar Numero de Cheque y Fecha de Cheque:
            If Seg.HasPermission("AsignarNumeroFechaCheque") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If
            'Limpiar cheque actual y cheques superiores si existen:
            If Seg.HasPermission("LimpiarNumeroFechaCheque") Then
                Me.toolLimpiarCheque.Enabled = True
            Else
                Me.toolLimpiarCheque.Enabled = False
            End If
            'Limpiar UNICAMENTE el cheque actual:
            If Seg.HasPermission("LimpiarNumeroFechaChequeActual") Then
                Me.toolLimpiarChequeACTUAL.Enabled = True
            Else
                Me.toolLimpiarChequeACTUAL.Enabled = False
            End If
            'Marcar Cheques para su posterior impresion:
            If Seg.HasPermission("MarcarChequeParaImpresion") Then
                Me.toolMarcar.Enabled = True
            Else
                Me.toolMarcar.Enabled = False
            End If
            'Desmarcar Cheques para impresion:
            If Seg.HasPermission("DesmarcarChequeParaImpresion") Then
                Me.toolDesmarcar.Enabled = True
            Else
                Me.toolDesmarcar.Enabled = False
            End If
            'Cerrar Día de Cheques:
            If Seg.HasPermission("CerrarDiaChequera") Then
                Me.toolCerrarDia.Enabled = True
            Else
                Me.toolCerrarDia.Enabled = False
            End If
            'Reabrir Día de Cheques:
            If Seg.HasPermission("ReabrirDiaChequera") Then
                Me.toolReabrirDia.Enabled = True
            Else
                Me.toolReabrirDia.Enabled = False
            End If
            ' Impresión de Chequera Física (vwSteChequesFisicos):
            If Seg.HasPermission("ImprimirChequesFisicosTE32") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       grdSolicitudes_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una asignacion de cheque al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdSolicitudes_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSolicitudes.DoubleClick
        Try
            If Me.grdSolicitudes.RowCount = 0 Then
                Exit Sub
            End If

            If IntPermiteEditar = 1 Then
                If Seg.HasPermission("AsignarNumeroFechaCheque") Then
                    LlamaAsignarChequera()
                End If
            End If
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/01/2009
    ' Procedure Name:       grdSolicitudes_KeyPress
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un detalle de Efectivo existente, al dar 
    '                       enter sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdSolicitudes_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdSolicitudes.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                If IntPermiteEditar = 1 Then
                    If Seg.HasPermission("AsignarNumeroFechaCheque") Then
                        LlamaAsignarChequera()
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdSolicitudes_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSolicitudes.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub txtCkDesde_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCkDesde.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtCkHasta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCkHasta.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

End Class