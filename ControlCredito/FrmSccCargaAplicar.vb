Imports System.Data.SqlClient
Public Class FrmSccCargaAplicar
    Dim xNoEnvio As Long
    Dim xnSteCajaId As Integer
    Dim sColor As String
    Dim sCaja As String
    Dim XMaximoGrupos As Integer
    Dim XdtCajeros As BOSistema.Win.XDataSet.xDataTable
    'Dim XdtAnulados As BOSistema.Win.XDataSet.xDataTable
    Dim XdsRecibo As BOSistema.Win.XDataSet

    Public Property sNombreCaja() As String
        Get
            sNombreCaja = sCaja
        End Get
        Set(ByVal value As String)
            sCaja = value
        End Set
    End Property

    'Color a mostrarse en el formulario
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property


    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Numero del envio
    Public Property NoEnvio() As Long
        Get
            NoEnvio = xNoEnvio
        End Get
        Set(ByVal value As Long)
            xNoEnvio = value
        End Set
    End Property
    'Caja del envio
    Public Property nSteCajaId() As Integer
        Get
            nSteCajaId = xnSteCajaId
        End Get
        Set(ByVal value As Integer)
            xnSteCajaId = value
        End Set
    End Property
    Private Sub InicializarVariables()
        Try

            XdtCajeros = New BOSistema.Win.XDataSet.xDataTable
            XdsRecibo = New BOSistema.Win.XDataSet
            'XdtAnulados = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FrmSccCargaAplicar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Dim strSQL As String
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)
            InicializarVariables()
            'RegTmp.ExecuteSql("	SELECT CAST(sValorParametro AS int) as AnioAct FROM dbo.StbValorParametro  WHERE     (nStbParametroID = 82)")

            Me.txtSteCajaId.Text = Me.nSteCajaId
            Me.txtNombreCaja.Text = Me.sNombreCaja
            Me.txtEnvioNo.Text = Me.NoEnvio


            'Ver si no tiene Recibos en Marcados como error que no han sido confirmados por tesoreria 
            strSQL = "Select  AplicadoEnCentral from dbo.SttProcesarEnvioES Where AplicadoEnCentral=1 And nSteCajaID=" & Me.nSteCajaId & " And  NoEnvio=" & Me.NoEnvio

            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya ha sido dada por aplicada anteriormente" & Chr(13) & "No puede volver a aplicar.", MsgBoxStyle.Critical, NombreSistema)

                CmdAceptar.Enabled = False
                tbMarcadosError.Enabled = False
                CargarConflictos(0)
            Else
                CargarConflictos(1)
            End If


            CargarCajeros()
            CargarAnuladosConfirmar()
            CargarPermisoArqueoRecuperacion()

            tabArqueo.SelectedIndex = 0


            'Ver si es el ultimo para permitir modificar en los arqueos por incorporacion
            strSQL = "SELECT     NoEnvio FROM         (SELECT     MAX(NoEnvio) AS NoEnvio   FROM          dbo.SttProcesarEnvioES  WHERE      (nSteCajaId = " & Me.nSteCajaId & ")) AS Lista WHERE     (NoEnvio = " & Me.NoEnvio & ")"

            If Not RegistrosAsociados(strSQL) Then
                tbArqueoRecuperacion.Enabled = False
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub CargarConflictos(ByVal Tipo As Integer)
        Dim StrSql As String


        'Debe darse el recepcionado del anulado es decir confirmar. en central los anulados
        'If Tipo = 1 Then
        '    StrSql = "SELECT     nSccSolicitudChequeID, NombreSocia, sNumeroCedula, Tipo, TipoDesc  FROM dbo.vwSttSociasProblemasRecibosEnCentralYLocal " & _
        '             " WHERE  nSteCajaIDLocal =  " & Me.nSteCajaId & _
        '             " GROUP BY nSccSolicitudChequeID, NombreSocia, sNumeroCedula, Tipo, TipoDesc " & _
        '             " UNION " & _
        '             "SELECT     nSccSolicitudChequeID, NombreSocia, sNumeroCedula, Tipo, TipoDesc  FROM dbo.vwSttSociasProblemasRecibosEnCentralYLocalPrimerReciboLuegodeEnvio " & _
        '             " WHERE  nSteCajaIDLocal =  " & Me.nSteCajaId & _
        '             " GROUP BY nSccSolicitudChequeID, NombreSocia, sNumeroCedula, Tipo, TipoDesc "


        'Else
        StrSql = "SELECT     nSccSolicitudChequeID, NombreSocia, sNumeroCedula, DesAnulado FROM dbo.vwSttSociasProblemasRecibosEnCentralYLocalAgregados " & _
                 " WHERE  nSteCajaIDLocal =  " & Me.nSteCajaId & " AND EnvioNumero = " & Me.NoEnvio  ' & _
        '" GROUP BY nSccSolicitudChequeID, NombreSocia, sNumeroCedula, Tipo, TipoDesc,sDescripcion"
        'End If





        If XdsRecibo.ExistTable("Conflicto") Then
            XdsRecibo("Conflicto").ExecuteSql(StrSql)
        Else
            XdsRecibo.NewTable(StrSql, "Conflicto")
            XdsRecibo("Conflicto").Retrieve()
        End If


        'Me.XdtAnulados.ExecuteSql(StrSql)

        Me.grdConflictos.DataSource = XdsRecibo("Conflicto").Source
        If Me.grdConflictos.RowCount > 0 Then
            'Me.chkEsDebito.Enabled = False
            'Me.cboFuente.Enabled = False
            'Me.cboDelegacion.Enabled = False
        Else
            'Me.chkEsDebito.Enabled = True
            ' Me.cboFuente.Enabled = True
            'Me.cboDelegacion.Enabled = True
        End If
        grdConflictos.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False


        grdConflictos.Splits(0).DisplayColumns("NombreSocia").Width = 250
        grdConflictos.Splits(0).DisplayColumns("sNumeroCedula").Width = 150





        Me.grdConflictos.Columns("NombreSocia").Caption = "NombreSocia"
        Me.grdConflictos.Columns("sNumeroCedula").Caption = "Cedula"

        Me.grdConflictos.Columns("DesAnulado").Caption = "Estado Recibo Central"






        Me.grdConflictos.Caption = " Totales Casos Socias Tipos con Conflcitos para este envío(" + Me.grdConflictos.RowCount.ToString + " registros)"


    End Sub

    Private Sub CargarCajeros()
        Dim StrSql As String

        'OJO LUEGO PONER CONDICION CON LAS EXEPCIONES PARA CUANDO TENGA REGISTROS INGRESADOS EN CENTRAL y EN LOCAL'
        'OJO SttLocalSccConflictosRecibos en 1 Indica que esa socia tiene recibos ingresados en central y tambien en la local, al mismo tiempo
        'No deberia pasar. Pero si pasa, entonces esto no permitir que pasen a central, hasta que se resuelva el conflicto
        'Se podria genera
        'Estos en conflictos no se pasaran.
        '



        '        StrSql = "SELECT     dbo.SrhEmpleado.nSrhEmpleadoID, dbo.vwStbPersona.sNombre, dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, " & _
        '                     " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nPrincipal) AS nPrincipal, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nMantenimientoValor) " & _
        '                     " AS nMantenimientoValor, SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesCorrientes) AS nInteresesCorrientes, " & _
        '                     " SUM(dbo.SttLocalSccReciboOficialCajaDetalle.nInteresesMoratorios) AS nInteresesMoratorios, SUM(dbo.SttLocalSccReciboOficialCaja.nValor)  AS nValor " & _
        '                     " FROM         dbo.SttLocalSccReciboOficialCaja INNER JOIN " & _
        '                     " dbo.SttLocalSccReciboOficialCajaDetalle ON " & _
        '                     " dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID = dbo.SttLocalSccReciboOficialCajaDetalle.nSccReciboOficialCajaID INNER JOIN " & _
        '                     " dbo.SrhEmpleado ON dbo.SttLocalSccReciboOficialCaja.nSrhEmpleadoCajeroID = dbo.SrhEmpleado.nSrhEmpleadoID INNER JOIN " & _
        '                     " dbo.vwStbPersona ON dbo.SrhEmpleado.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID INNER Join dbo.StbValorCatalogo ON dbo.SttLocalSccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
        '                     " WHERE  (dbo.StbValorCatalogo.sCodigoInterno <> '3') AND   (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.nSteCajaId & ") AND (dbo.SttLocalSccReciboOficialCaja.EnvioNumero = " & Me.NoEnvio & ") " & _
        '" GROUP BY dbo.vwStbPersona.sNombre, dbo.SrhEmpleado.nSrhEmpleadoID, dbo.SttLocalSccReciboOficialCaja.dFechaRecibo "
        StrSql = "exec spSteBuscarTrasladoValor " & Me.nSteCajaId & "," & Me.NoEnvio
        Me.XdtCajeros.ExecuteSql(StrSql)
        Me.GrdTotalesCajeros.DataSource = XdtCajeros.Source
        If Me.GrdTotalesCajeros.RowCount > 0 Then
            'Me.chkEsDebito.Enabled = False
            'Me.cboFuente.Enabled = False
            'Me.cboDelegacion.Enabled = False
        Else
            'Me.chkEsDebito.Enabled = True
            ' Me.cboFuente.Enabled = True
            'Me.cboDelegacion.Enabled = True
        End If
        GrdTotalesCajeros.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False



        GrdTotalesCajeros.Splits(0).DisplayColumns("sNombre").Width = 150
        GrdTotalesCajeros.Splits(0).DisplayColumns("dFechaRecibo").Width = 80
        GrdTotalesCajeros.Splits(0).DisplayColumns("nPrincipal").Width = 80
        GrdTotalesCajeros.Splits(0).DisplayColumns("nMantenimientoValor").Width = 100
        GrdTotalesCajeros.Splits(0).DisplayColumns("nInteresesCorrientes").Width = 100
        GrdTotalesCajeros.Splits(0).DisplayColumns("nInteresesMoratorios").Width = 100
        GrdTotalesCajeros.Splits(0).DisplayColumns("nValor").Width = 120
        GrdTotalesCajeros.Splits(0).DisplayColumns("nSteCierreTrasladoValorID").Width = 120

        Me.GrdTotalesCajeros.Columns("sNombre").Caption = "Cajero"
        Me.GrdTotalesCajeros.Columns("dFechaRecibo").Caption = "Fecha Recibo"
        Me.GrdTotalesCajeros.Columns("nPrincipal").Caption = "Principal C$"
        Me.GrdTotalesCajeros.Columns("nMantenimientoValor").Caption = "Mantenimiento C$"
        Me.GrdTotalesCajeros.Columns("nInteresesCorrientes").Caption = "Corrientes C$"
        Me.GrdTotalesCajeros.Columns("nInteresesMoratorios").Caption = "Moratorios C$"
        Me.GrdTotalesCajeros.Columns("nValor").Caption = "Total C$"
        Me.GrdTotalesCajeros.Columns("nSteCierreTrasladoValorID").Caption = "ID Traslado"

        Me.GrdTotalesCajeros.Columns("nPrincipal").NumberFormat = "#,##0.00"
        Me.GrdTotalesCajeros.Columns("nMantenimientoValor").NumberFormat = "#,##0.00"
        Me.GrdTotalesCajeros.Columns("nInteresesCorrientes").NumberFormat = "#,##0.00"
        Me.GrdTotalesCajeros.Columns("nInteresesMoratorios").NumberFormat = "#,##0.00"
        Me.GrdTotalesCajeros.Columns("nValor").NumberFormat = "#,##0.00"

        Me.GrdTotalesCajeros.Caption = " Totales Por Cajeros Por Fechas para este envío(" + Me.GrdTotalesCajeros.RowCount.ToString + " registros)"


    End Sub

    Private Sub CargarAnuladosConfirmar()
        Dim StrSql As String


        'Debe darse el recepcionado del anulado es decir confirmar. en central los anulados

        StrSql = "SELECT  dbo.SttLocalSccReciboOficialCaja.sMotivoAnulacion,  dbo.SttLocalSccReciboOficialCaja.sMotivoAnulacionConfirmaCentral,        dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID, dbo.StbValorCatalogo.sCodigoInterno, " & _
                    "  CASE WHEN nAplicado = 0 THEN 'Marcado como error' ELSE dbo.StbValorCatalogo.sDescripcion END AS sEstado, " & _
                    "  dbo.SttLocalSccReciboOficialCaja.nAplicado, dbo.vwSclSocia.nSclSociaID, dbo.vwSclSocia.NombreSocia, dbo.vwSclSocia.sNumeroCedula,  " & _
                    "  dbo.SclGrupoSolidario.sCodigo, dbo.SclGrupoSolidario.sDescripcion AS sGrupo, dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, " & _
                    " dbo.SttLocalSccReciboOficialCaja.EnvioNumero , dbo.SttLocalSccReciboOficialCaja.nCodigo, dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, dbo.SttLocalSccReciboOficialCaja.nValor, dbo.SttLocalSccReciboOficialCaja.sConceptoPago " & _
                    " FROM         dbo.SttLocalSccReciboOficialCaja INNER JOIN " & _
                    "  dbo.SccSolicitudCheque ON dbo.SttLocalSccReciboOficialCaja.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN " & _
                    "  dbo.SccSolicitudDesembolsoCredito ON " & _
                    "  dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                     " dbo.SclFichaNotificacionDetalle ON " & _
                     " dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN " & _
                     " dbo.SclFichaNotificacionCredito ON " & _
                     " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                     " dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                     " dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID INNER JOIN " & _
                     " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID AND " & _
                     " dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
                     " dbo.StbValorCatalogo ON dbo.SttLocalSccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                     " dbo.vwSclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.vwSclSocia.nSclSociaID " & _
                     " WHERE     (dbo.StbValorCatalogo.sCodigoInterno = '3') AND (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.nSteCajaId & ") AND " & _
                     " (dbo.SttLocalSccReciboOficialCaja.EnvioNumero =" & Me.NoEnvio & " ) "



        If XdsRecibo.ExistTable("Recibo") Then
            XdsRecibo("Recibo").ExecuteSql(StrSql)
        Else
            XdsRecibo.NewTable(StrSql, "Recibo")
            XdsRecibo("Recibo").Retrieve()
        End If


        'Me.XdtAnulados.ExecuteSql(StrSql)

        Me.grdAnuladosConfirmar.DataSource = XdsRecibo("Recibo").Source
        If Me.grdAnuladosConfirmar.RowCount > 0 Then
            'Me.chkEsDebito.Enabled = False
            'Me.cboFuente.Enabled = False
            'Me.cboDelegacion.Enabled = False
        Else
            'Me.chkEsDebito.Enabled = True
            ' Me.cboFuente.Enabled = True
            'Me.cboDelegacion.Enabled = True
        End If
        grdAnuladosConfirmar.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False
        grdAnuladosConfirmar.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
        grdAnuladosConfirmar.Splits(0).DisplayColumns("nAplicado").Visible = False
        grdAnuladosConfirmar.Splits(0).DisplayColumns("nSclSociaID").Visible = False
        grdAnuladosConfirmar.Splits(0).DisplayColumns("nSteCajaIDLocal").Visible = False
        grdAnuladosConfirmar.Splits(0).DisplayColumns("EnvioNumero").Visible = False


        grdAnuladosConfirmar.Splits(0).DisplayColumns("sMotivoAnulacion").Width = 150
        grdAnuladosConfirmar.Splits(0).DisplayColumns("sMotivoAnulacionConfirmaCentral").Width = 150

        grdAnuladosConfirmar.Splits(0).DisplayColumns("sEstado").Width = 120
        grdAnuladosConfirmar.Splits(0).DisplayColumns("NombreSocia").Width = 200
        grdAnuladosConfirmar.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
        grdAnuladosConfirmar.Splits(0).DisplayColumns("sCodigo").Width = 100
        grdAnuladosConfirmar.Splits(0).DisplayColumns("sGrupo").Width = 150
        grdAnuladosConfirmar.Splits(0).DisplayColumns("nCodigo").Width = 60
        grdAnuladosConfirmar.Splits(0).DisplayColumns("dFechaRecibo").Width = 90
        grdAnuladosConfirmar.Splits(0).DisplayColumns("nValor").Width = 100
        grdAnuladosConfirmar.Splits(0).DisplayColumns("sConceptoPago").Width = 180

        Me.grdAnuladosConfirmar.Columns("sMotivoAnulacion").Caption = "Motivo Anulacion en Local"
        Me.grdAnuladosConfirmar.Columns("sMotivoAnulacionConfirmaCentral").Caption = "Motivo Anulacion en Central"
        Me.grdAnuladosConfirmar.Columns("sEstado").Caption = "Estado"
        Me.grdAnuladosConfirmar.Columns("NombreSocia").Caption = "Nombre"
        Me.grdAnuladosConfirmar.Columns("sNumeroCedula").Caption = "Cédula"
        Me.grdAnuladosConfirmar.Columns("sCodigo").Caption = "Código Grupo"
        Me.grdAnuladosConfirmar.Columns("sGrupo").Caption = "Nombre Grupo"
        Me.grdAnuladosConfirmar.Columns("nCodigo").Caption = "No Recibo"
        Me.grdAnuladosConfirmar.Columns("dFechaRecibo").Caption = "Fecha Recibo"
        Me.grdAnuladosConfirmar.Columns("nValor").Caption = "Total C$"
        Me.grdAnuladosConfirmar.Columns("sConceptoPago").Caption = "Concepto de Pago"






        Me.grdAnuladosConfirmar.Caption = " Totales Recibos marcados como error localmente para este envío(" + Me.grdAnuladosConfirmar.RowCount.ToString + " registros)"


    End Sub

    Private Sub CargarPermisoArqueoRecuperacion()
        Dim StrSql As String


        'Debe darse el recepcionado del anulado es decir confirmar. en central los anulados
        StrSql = "Select  nSttCentralArqueoRecuperacionID, dFechaArqueo, CASE WHEN nObligado = 1 THEN 'SI' ELSE 'NO' END AS DesObligado, nObligado FROM         dbo.SttCentralArqueoRecuperacion  WHERE     (EnvioNumero = " & Me.NoEnvio & ") AND (nSteCajaID = " & Me.nSteCajaId & ")"




        If XdsRecibo.ExistTable("ArqueoRecuperacion") Then
            XdsRecibo("ArqueoRecuperacion").ExecuteSql(StrSql)
        Else
            XdsRecibo.NewTable(StrSql, "ArqueoRecuperacion")
            XdsRecibo("ArqueoRecuperacion").Retrieve()
        End If


        'Me.XdtAnulados.ExecuteSql(StrSql)

        Me.grdArqueosActivar.DataSource = XdsRecibo("ArqueoRecuperacion").Source
        If Me.grdArqueosActivar.RowCount > 0 Then
            'Me.chkEsDebito.Enabled = False
            'Me.cboFuente.Enabled = False
            'Me.cboDelegacion.Enabled = False
        Else
            'Me.chkEsDebito.Enabled = True
            ' Me.cboFuente.Enabled = True
            'Me.cboDelegacion.Enabled = True
        End If
        grdArqueosActivar.Splits(0).DisplayColumns("nSttCentralArqueoRecuperacionID").Visible = False
        grdArqueosActivar.Splits(0).DisplayColumns("nObligado").Visible = False



        grdArqueosActivar.Splits(0).DisplayColumns("DesObligado").Width = 90
        grdArqueosActivar.Splits(0).DisplayColumns("dFechaArqueo").Width = 90



        Me.grdArqueosActivar.Columns("DesObligado").Caption = "Obligar Arqueo"

        Me.grdArqueosActivar.Columns("dFechaArqueo").Caption = "Fecha Arqueo"







        Me.grdArqueosActivar.Caption = " Totales Registros Arqueos Recuperacion para este envío(" + Me.grdArqueosActivar.RowCount.ToString + " registros)"


    End Sub
    Private Sub LlamaAceptarAnulado(ByVal Tipo As Integer)
        Dim XdtReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
        Dim XdrReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            'Dim intPosicionSocia As Integer  'Posicion del registro seleccionado, ID de la Ficha
            Dim intPosicionRecibo As Integer
            Dim strCausaAnulacion As String = ""
            Dim intReciboID As Integer



            ''Solicita al Usuario la Causa de la Anulación
            'XdtReciboAnular.Filter = " nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            'XdtReciboAnular.Retrieve()
            'XdrReciboAnular = XdtReciboAnular.Current

            If Tipo = 1 Then


                ObjFrmStbDatoComplemento.strPrompt = "Confirme Causa de la Anulación? "
                ObjFrmStbDatoComplemento.strTitulo = "Anulación del Recibo Oficial de Caja"
                ObjFrmStbDatoComplemento.intAncho = 250  'XdrReciboAnular.GetColumnLenght("sMotivoAnulacion")
                ObjFrmStbDatoComplemento.strDato = ""
                ObjFrmStbDatoComplemento.strColor = "Verde"
                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                ObjFrmStbDatoComplemento.ShowDialog()

                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                'Valida que se ingrese la Causa de la Anulación
                If strCausaAnulacion = "" Then

                    MsgBox("El Recibo NO PUEDE ser dado por Anulado. Debe ingresar Causa de Anulación.", MsgBoxStyle.Critical, "SMUSURA0")
                    Exit Sub
                End If
            End If
            Strsql = " EXEC spSttConfirmarAnularRecibo " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & " , " & Tipo & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'"

            intReciboID = XcDatos.ExecuteScalar(Strsql)

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If intReciboID = 0 Then
                If Tipo = 1 Then
                    MsgBox("La Aceptacion de Anulación del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    MsgBox("La Aceptacion de Marcado como Error del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                End If


            Else
                If Tipo = 1 Then
                    MsgBox("El registro seleccionado se ha aceptado como Anulado " & Chr(10) & _
                                            "de forma satisfactoria.", MsgBoxStyle.Information)
                Else
                    MsgBox("El registro seleccionado se ha aceptado como Marcado como error " & Chr(10) & _
                                            "de forma satisfactoria.", MsgBoxStyle.Information)
                End If

                'Guardar posición actual de la selección


                intPosicionRecibo = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") '  XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

                CargarAnuladosConfirmar()


                XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", intPosicionRecibo)
                Me.grdAnuladosConfirmar.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtReciboAnular.Close()
            XdtReciboAnular = Nothing

            XdrReciboAnular.Close()
            XdrReciboAnular = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing
        End Try
    End Sub

    Private Sub LlamaAceptarArqueo(ByVal Tipo As Integer)

        Try
            Dim Strsql As String
            'Dim intPosicionSocia As Integer  'Posicion del registro seleccionado, ID de la Ficha
            Dim intPosicionRecibo As Integer
            'Dim strCausaAnulacion As String
            Dim intReciboID As Integer
            Dim XcDatos As New BOSistema.Win.XComando


            ''Solicita al Usuario la Causa de la Anulación
            'XdtReciboAnular.Filter = " nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            'XdtReciboAnular.Retrieve()
            'XdrReciboAnular = XdtReciboAnular.Current

            'If Tipo = 1 Then


            '    ObjFrmStbDatoComplemento.strPrompt = "Confirme Causa de la Anulación? "
            '    ObjFrmStbDatoComplemento.strTitulo = "Anulación del Recibo Oficial de Caja"
            '    ObjFrmStbDatoComplemento.intAncho = 250  'XdrReciboAnular.GetColumnLenght("sMotivoAnulacion")
            '    ObjFrmStbDatoComplemento.strDato = ""
            '    ObjFrmStbDatoComplemento.strColor = "Verde"
            '    ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
            '    ObjFrmStbDatoComplemento.ShowDialog()

            '    strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

            '    'Valida que se ingrese la Causa de la Anulación
            '    If strCausaAnulacion = "" Then

            '        MsgBox("El Recibo NO PUEDE ser dado por Anulado. Debe ingresar Causa de Anulación.", MsgBoxStyle.Critical, "SMUSURA0")
            '        Exit Sub
            '    End If
            'End If
            Strsql = " Update   dbo.SttCentralArqueoRecuperacion Set nObligado=" & Tipo & " Where  nSttCentralArqueoRecuperacionID =" & XdsRecibo("ArqueoRecuperacion").ValueField("nSttCentralArqueoRecuperacionID")

            intReciboID = XcDatos.ExecuteScalar(Strsql)

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            'If intReciboID = 0 Then
            '    If Tipo = 1 Then
            '        MsgBox("La Aceptacion de Anulación del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
            '    Else
            '        MsgBox("La Aceptacion de Marcado como Error del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
            '    End If


            'Else
            '    If Tipo = 1 Then
            '        MsgBox("El registro seleccionado se ha aceptado como Anulado " & Chr(10) & _
            '                                "de forma satisfactoria.", MsgBoxStyle.Information)
            '    Else
            '        MsgBox("El registro seleccionado se ha aceptado como Marcado como error " & Chr(10) & _
            '                                "de forma satisfactoria.", MsgBoxStyle.Information)
            '    End If

            '    'Guardar posición actual de la selección


            '    intPosicionRecibo = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") '  XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            '    CargarAnuladosConfirmar()


            '    XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", intPosicionRecibo)
            '    Me.grdAnuladosConfirmar.Row = XdsRecibo("Recibo").BindingSource.Position
            'End If



            intPosicionRecibo = XdsRecibo("ArqueoRecuperacion").ValueField("nSttCentralArqueoRecuperacionID") '  XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")


            CargarPermisoArqueoRecuperacion()



            XdsRecibo("ArqueoRecuperacion").SetCurrentByID("nSttCentralArqueoRecuperacionID", intPosicionRecibo)
            Me.grdAnuladosConfirmar.Row = XdsRecibo("ArqueoRecuperacion").BindingSource.Position


        Catch ex As Exception
            Control_Error(ex)
        Finally


        End Try
    End Sub

    Private Sub FrmSccCargaAplicar_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        Try
            XdsRecibo.Close()
            XdsRecibo = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function EjecutarComandoPasar(ByVal connectionString As String, ByVal queryString As String) As String
        'Dim queryString As String = _
        '    "SELECT OrderID, CustomerID FROM dbo.Orders;"
        Dim XResult As String
        Using connection As New SqlConnection(connectionString)
            Dim command As New SqlCommand(queryString, connection)
            connection.Open()
            'command.ResetCommandTimeout()
            command.CommandTimeout = 0
            Dim reader As SqlDataReader = command.ExecuteReader()
            Try
                reader.Read()
                XResult = reader(0)
            Finally
                ' Always call Close when done reading.+
                reader.Close()
            End Try
        End Using
        Return XResult
    End Function
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim IdUsuario As Integer
        Dim XError As String
        Dim Conex As New DSSistema.DSSistema
        'Dim conexion As New SqlConnection()
        Dim myConnectionString As String = "User ID=" & Conex.DbUserName & ";password=" & Conex.DbUserPassword & ";Initial Catalog=" & Conex.DbName & ";Data Source=" & Conex.ServerName & ";Connection Timeout=120"

        Dim XcTmp As New BOSistema.Win.XComando

        Try
            If ValidaDatosEntrada() Then

                If MsgBox("Esta seguro de dar por aplicado la carga de recibos", MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then



                    IdUsuario = XcTmp.ExecuteScalar("SELECT SsgCuentaID FROM SsgCuenta WHERE (Login = '" & InfoSistema.LoginName & "')")
                    'XError = EjecutarComandoPasar(myConnectionString, "EXEC spSttBorrarBaseTemporalLocal")


                    'conexion.ConnectionString = myConnectionString

                    'conexion.Open()



                    'XError = XcTmp.ExecuteScalar(" Exec spSttActualizacionBasesLocalesRecibosAplicar " & Me.nSteCajaId & "," & Me.NoEnvio & "," & IdUsuario)
                    'XError = conexion.ex.ExecuteScalar(" Exec spSttActualizacionBasesLocalesRecibosAplicar " & Me.nSteCajaId & "," & Me.NoEnvio & "," & IdUsuario)

                    XError = EjecutarComandoPasar(myConnectionString, " Exec spSttActualizacionBasesLocalesRecibosAplicar " & Me.nSteCajaId & "," & Me.NoEnvio & "," & IdUsuario)
                    If Trim(XError) <> "" Then
                        MsgBox(XError, MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    Else
                        MsgBox("Se hizo la aplicacion en Central exitosamente" & Chr(13) & "Proceder a hacer arqueos de la caja para poder volver enviar el archivo actualizado a la base Local", MsgBoxStyle.Critical, NombreSistema)
                        EjecutarComandoPasar(myConnectionString, " Exec sp_Iniciar_JOB_ConsultaPagoCuota ")
                        Me.CmdAceptar.Enabled = False
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Gamaliel Mejia
    ' Fecha:                13/02/2012
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Dim xObligarRevisarConflictoConCajaLocal As Integer

        Try

            Dim strSQL As String = ""


            ValidaDatosEntrada = True


            ' Ver si no ha sido aplicada ya anteriormente



            'Ver si no tiene Recibos en Marcados como error que no han sido confirmados por tesoreria 
            strSQL = "Select  AplicadoEnCentral from dbo.SttProcesarEnvioES Where AplicadoEnCentral=1 And nSteCajaID=" & Me.nSteCajaId & " And  NoEnvio=" & Me.NoEnvio

            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya ha sido dada por aplicada anteriormente" & Chr(13) & "No puede volver a aplicar.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If


            'Debe darse el recepcionado del anulado es decir confirmar. en central los anulados

            strSQL = "SELECT  dbo.SttLocalSccReciboOficialCaja.sMotivoAnulacion,  dbo.SttLocalSccReciboOficialCaja.sMotivoAnulacionConfirmaCentral,        dbo.SttLocalSccReciboOficialCaja.nSccReciboOficialCajaID, dbo.StbValorCatalogo.sCodigoInterno, " & _
                        "  CASE WHEN nAplicado = 0 THEN 'Marcado como error' ELSE dbo.StbValorCatalogo.sDescripcion END AS sEstado, " & _
                        "  dbo.SttLocalSccReciboOficialCaja.nAplicado, dbo.vwSclSocia.nSclSociaID, dbo.vwSclSocia.NombreSocia, dbo.vwSclSocia.sNumeroCedula,  " & _
                        "  dbo.SclGrupoSolidario.sCodigo, dbo.SclGrupoSolidario.sDescripcion AS sGrupo, dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal, " & _
                        " dbo.SttLocalSccReciboOficialCaja.EnvioNumero , dbo.SttLocalSccReciboOficialCaja.nCodigo, dbo.SttLocalSccReciboOficialCaja.dFechaRecibo, dbo.SttLocalSccReciboOficialCaja.nValor, dbo.SttLocalSccReciboOficialCaja.sConceptoPago " & _
                        " FROM         dbo.SttLocalSccReciboOficialCaja INNER JOIN " & _
                        "  dbo.SccSolicitudCheque ON dbo.SttLocalSccReciboOficialCaja.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN " & _
                        "  dbo.SccSolicitudDesembolsoCredito ON " & _
                        "  dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                         " dbo.SclFichaNotificacionDetalle ON " & _
                         " dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN " & _
                         " dbo.SclFichaNotificacionCredito ON " & _
                         " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                         " dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN " & _
                         " dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioID INNER JOIN " & _
                         " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID AND " & _
                         " dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN " & _
                         " dbo.StbValorCatalogo ON dbo.SttLocalSccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN " & _
                         " dbo.vwSclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.vwSclSocia.nSclSociaID " & _
                         " WHERE   dbo.SttLocalSccReciboOficialCaja.nAplicado=0 And   (dbo.StbValorCatalogo.sCodigoInterno = '3') AND (dbo.SttLocalSccReciboOficialCaja.nSteCajaIDLocal = " & Me.nSteCajaId & ") AND " & _
                         " (dbo.SttLocalSccReciboOficialCaja.EnvioNumero =" & Me.NoEnvio & " ) "




            If RegistrosAsociados(strSQL) Then
                MsgBox("Existen recibos marcados como error que no han sido confirmados" & Chr(13) & "Favor Revisar.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If



            strSQL = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 86)"
            xObligarRevisarConflictoConCajaLocal = XcDatos.ExecuteScalar(strSQL) 'Si es 1 entonces valida que la caja local este recepcionada y aplicada, sin generar el siguiente archivo de envio.


            'strSQL = " SELECT     NoEnvio, nSteCajaId, EstadoEnvio, SsgCuentaID, FechaGenera, AplicadoEnCentral  FROM         dbo.SttProcesarEnvioES WHERE     (nSteCajaId = " & IdSteCaja & ") AND (NoEnvio > 0) AND (AplicadoEnCentral = 0) "
            If xObligarRevisarConflictoConCajaLocal = 1 Then

                strSQL = " SELECT     nSccSolicitudChequeID FROM dbo.vwSttSociasProblemasRecibosEnCentralYLocalAgregados WHERE     (EstadoAnulado=0) AND (nSteCajaIDLocal = " & Me.nSteCajaId & ") AND (EnvioNumero = " & Me.NoEnvio & ")"

                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen recibos con conflictos en la central que no han sido anulados" & Chr(13) & "Primero deben ser anulados, Luego de hacer la carga de recibos, es necesario incorporar los manuales correspondientes, antes de hacer el envio a la base local. " & Chr(13) & " Favor Revisar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Exit Function
                End If




            End If




        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    Private Sub toolModificarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub tbArqueoRecuperacion_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbArqueoRecuperacion.ItemClicked
        Select Case e.ClickedItem.Name
            Case "ToolDesActivarArqueo"
                LlamaAceptarArqueo(0)

            Case "ToolActivarArqueo"
                LlamaAceptarArqueo(1)
        End Select
    End Sub

    Private Sub tbMarcadosError_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMarcadosError.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolModificarQ"
                LlamaAceptarAnulado(0)

            Case "toolModificarC"
                LlamaAceptarAnulado(1)
        End Select
    End Sub
End Class