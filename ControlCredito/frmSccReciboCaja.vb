' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Su�rez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccReciboCaja.vb
' Descripci�n:          Este formulario muestra un maestro - detalle, en el 
'                       maestro las Socias a las cuales se les ha otorgado
'                       pr�stamo y en el detalle los recibos de pago que se
'                       han ingresado por socia.
'-------------------------------------------------------------------------
Public Class frmSccReciboCaja

    '- Declaraci�n de Variables 
    Dim XdsRecibo As BOSistema.Win.XDataSet
    Dim nAccesoTotalLectura As Short
    Dim nAccesoTotalEdicion As Short
    Dim IdSclTipoRecibo As Integer
    Dim IDPersonaLugarPagosID As Integer

    Public Property IdTipoRecibo() As Integer
        Get
            IdTipoRecibo = IdSclTipoRecibo
        End Get

        Set(ByVal value As Integer)
            IdSclTipoRecibo = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmSccReciboCaja_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccReciboCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsRecibo.Close()
            XdsRecibo = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmSccReciboCaja_Load
    ' Descripci�n:          Evento Load del formulario donde inicializo variables
    '                       y cargo maestro - detalle en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccReciboCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicaci�n.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            If Me.IdTipoRecibo = 2 Then 'Manual
                'Me.tbCaracterInicio.Visible = False
                Me.Text = "Mantenimiento Recibo Oficial de Caja Manual"
                CargarRecibo("", 0)
                'A solicitud de credito el 01 de octubre del 2014 para ver en recibos manuales
                'Me.toolImprimirEC.Visible = False


            ElseIf Me.IdTipoRecibo = 3 Then 'Recibos Cancelados
                Me.Text = "Consulta Pr�stamos Cancelados"
                CargarRecibo("", 0)
            Else
                'Me.tbCaracterInicio.Visible = False
                Me.Text = "Mantenimiento Recibo Oficial de Caja Autom�tico"
                CargarRecibo("", 0)
                Me.toolImprimirEC.Visible = False
            End If
            Seguridad()

            Me.toolRefrescar.Enabled = False
            Me.toolRefrescar.Visible = False
            Me.toolRefrescarM.Visible = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarRecibo
    ' Descripci�n:          Este procedimiento permite cargar 
    '                       los datos sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo(ByVal sCadenaFiltro As String, ByVal IdFichaNotificacion As Integer)
        Try
            Dim Strsql As String = ""

            Me.grdSocia.ClearFields()
            'Me.grdRecibo.ClearFields()

            If Me.IdTipoRecibo = 3 Then
                If IdFichaNotificacion <> 0 Then
                    Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID ,a.sCodigoTipoPlanNegocio,a.CodigoPrograma,sCodTipoPlazoPago  " & _
                             " From vwSccGrupoSociaChequeEmitido a " & _
                             " Where a.sEstado = 'Cancelada' And a.nSclFichaNotificacionID = " & IdFichaNotificacion & _
                             " Order by a.nSclGrupoSolidarioID"
                Else
                    Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID ,a.sCodigoTipoPlanNegocio,a.CodigoPrograma,sCodTipoPlazoPago   " & _
                             " From vwSccGrupoSociaChequeEmitido a " & _
                             " Where a.nSclFichaNotificacionID = 0 "

                    'Else
                    '    If nAccesoTotalLectura = 1 Then
                    '        Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
                    '                 " From vwSccGrupoSociaChequeEmitido a " & _
                    '                 " Where a.nStbEstadoSolicitudID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4','6') And b.sNombre = 'EstadoSolicitudCheque') " & _
                    '                 " And a.sEstado = 'Cancelada' And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
                    '                 " Order by a.nSclGrupoSolidarioID"
                    '    Else
                    '        Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
                    '                 " From vwSccGrupoSociaChequeEmitido a " & _
                    '                 " Where a.nStbEstadoSolicitudID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4','6') And b.sNombre = 'EstadoSolicitudCheque') " & _
                    '                 " And a.sEstado = 'Cancelada' And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
                    '                 " AND a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & _
                    '                 " Order by a.nSclGrupoSolidarioID"
                    'End If
                End If
            Else
                If IdFichaNotificacion <> 0 Then
                    Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID,a.sCodigoTipoPlanNegocio,a.CodigoPrograma,a.sCodTipoPlazoPago " & _
                             " From vwSccGrupoSociaChequeEmitido a " & _
                             " Where a.sEstado = 'Aprobada' And a.nSclFichaNotificacionID = " & IdFichaNotificacion & _
                             " Order by a.nSclGrupoSolidarioID"
                Else
                    Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID,a.sCodigoTipoPlanNegocio,a.CodigoPrograma,a.sCodTipoPlazoPago " & _
                             " From vwSccGrupoSociaChequeEmitido a " & _
                             " Where a.nSclFichaNotificacionID = 0 "

                    'Else
                    '    If nAccesoTotalLectura = 1 Then
                    '        Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
                    '                 " From vwSccGrupoSociaChequeEmitido a " & _
                    '                 " Where a.nStbEstadoSolicitudID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4','6') And b.sNombre = 'EstadoSolicitudCheque') " & _
                    '                 " And a.sEstado = 'Aprobada' And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
                    '                 " Order by a.nSclGrupoSolidarioID"
                    '    Else
                    '        Strsql = " Select a.nSccSolicitudChequeID,a.sDistrito,a.nSclGrupoSolidarioID as sCodigoGrupo,a.sNombreGrupo,a.sNombreSocia,a.sEstado,a.sNumeroCedula,a.nSclFichaNotificacionDetalleID,a.sFuente,a.nSclFichaNotificacionID,a.nStbDelegacionProgramaID " & _
                    '                 " From vwSccGrupoSociaChequeEmitido a " & _
                    '                 " Where a.nStbEstadoSolicitudID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4','6') And b.sNombre = 'EstadoSolicitudCheque') " & _
                    '                 " And a.sEstado = 'Aprobada' And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
                    '                 " AND a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & _
                    '                 " Order by a.nSclGrupoSolidarioID"
                    '    End If
                End If
            End If

            If XdsRecibo.ExistTable("Socia") Then
                XdsRecibo("Socia").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Socia")
                XdsRecibo("Socia").Retrieve()
            End If

            'Strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo, a.nStbEstadoReciboID, a.login " & _
            '         " From vwSccReciboSocia a " & _
            '         " Order by a.nCodigo"

            'If XdsRecibo.ExistTable("Recibo") Then
            '    XdsRecibo("Recibo").ExecuteSql(Strsql)
            'Else
            '    XdsRecibo.NewTable(Strsql, "Recibo")
            '    XdsRecibo("Recibo").Retrieve()
            'End If

            'If XdsRecibo.ExistRelation("SociaConRecibo") = False Then
            '    'Creando la relaci�n entre el Primer Query y el Segundo
            '    XdsRecibo.NewRelation("SociaConRecibo", "Socia", "Recibo", "nSccSolicitudChequeID", "nSccSolicitudChequeID")
            'End If

            'XdsRecibo.SincronizarRelaciones()
            ''XdsRecibo("Socia").FilterLocal("[sNombreGrupo] Like 'a*'")

            ''Asignando a las fuentes de datos
            Me.grdSocia.DataSource = XdsRecibo("Socia").Source
            Me.grdSocia.Rebind(False)
            'Me.grdRecibo.DataSource = XdsRecibo("Recibo").Source
            'Me.grdRecibo.Rebind(True)

            'Actualizando el caption de los GRIDS
            Me.grdSocia.Caption = " Listado de Socias (" + Me.grdSocia.RowCount.ToString + " registros)"
            'Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

            FormatoRecibo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       FormatoDepartamento
    ' Descripci�n:          Este procedimiento permite configurar 
    '                       los datos sobre Departamentos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoRecibo()
        Try
            'Configuracion del Grid Socia
            Me.grdSocia.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").Width = 150
            Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").Width = 330
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 110

            Me.grdSocia.Splits(0).DisplayColumns("sFuente").Width = 150
            Me.grdSocia.Splits(0).DisplayColumns("sDistrito").Width = 60
            Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").Width = 60
            Me.grdSocia.Splits(0).DisplayColumns("sEstado").Width = 60

            Me.grdSocia.Columns("sNombreGrupo").Caption = "Nombre del Grupo Solidario"
            Me.grdSocia.Columns("sNombreSocia").Caption = "Nombre de la Socia"
            Me.grdSocia.Columns("sNumeroCedula").Caption = "N�mero C�dula"
            Me.grdSocia.Columns("sFuente").Caption = "Fuente de Financiamiento"
            Me.grdSocia.Columns("sDistrito").Caption = "Distrito"
            Me.grdSocia.Columns("sCodigoGrupo").Caption = "Grupo"
            Me.grdSocia.Columns("sEstado").Caption = "Estado"

            Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sFuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sCodigoGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sEstado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Recibo
            'Me.grdRecibo.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False
            'Me.grdRecibo.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            'Me.grdRecibo.Splits(0).DisplayColumns("nStbEstadoReciboID").Visible = False

            'Me.grdRecibo.ColumnFooters = True
            'Me.grdRecibo.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").FooterStyle.ForeColor = Color.Blue

            'Me.grdRecibo.Splits(0).DisplayColumns("nCodigo").Width = 100
            'Me.grdRecibo.Splits(0).DisplayColumns("sConceptoPago").Width = 200
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").Width = 100
            'Me.grdRecibo.Splits(0).DisplayColumns("sEstadoRecibo").Width = 110
            'Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").Width = 110
            'Me.grdRecibo.Splits(0).DisplayColumns("login").Width = 110

            'Me.grdRecibo.FooterStyle.BackColor = Color.WhiteSmoke

            'Me.grdRecibo.Columns("nCodigo").Caption = "C�digo"
            'Me.grdRecibo.Columns("sConceptoPago").Caption = "Concepto del Pago"
            'Me.grdRecibo.Columns("nValor").Caption = "Valor"
            'Me.grdRecibo.Columns("sEstadoRecibo").Caption = "Estado"
            'Me.grdRecibo.Columns("dFechaRecibo").Caption = "Fecha"
            'Me.grdRecibo.Columns("login").Caption = "Ingresado Por"

            'Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdRecibo.Splits(0).DisplayColumns.Item("nValor").Style.BackColor = Color.WhiteSmoke

            'Me.grdRecibo.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdRecibo.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdRecibo.Splits(0).DisplayColumns("sEstadoRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdRecibo.Splits(0).DisplayColumns("login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdRecibo.Columns("nValor").NumberFormat = "#,##0.00"

            'CalcularMontos()

            
            Me.grdSocia.Splits(0).DisplayColumns("sCodigoTipoPlanNegocio").Visible = False
            ' Me.grdSocia.Splits(0).DisplayColumns("sCodTipoPlazoPago").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("CodigoPrograma").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("sCodTipoPlazoPago").Visible = False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FormatoDetalleRecibo()
        Try
            'Configuracion del Grid Socia
            'Me.grdSocia.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            'Me.grdSocia.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False

            'Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").Width = 150
            'Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").Width = 350
            'Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 110
            'Me.grdSocia.Splits(0).DisplayColumns("sFuente").Width = 110
            'Me.grdSocia.Splits(0).DisplayColumns("sDistrito").Width = 60

            'Me.grdSocia.Columns("sNombreGrupo").Caption = "Nombre del Grupo Solidario"
            'Me.grdSocia.Columns("sNombreSocia").Caption = "Nombre de la Socia"
            'Me.grdSocia.Columns("sNumeroCedula").Caption = "N�mero C�dula"
            'Me.grdSocia.Columns("sFuente").Caption = "Fuente de Financiamiento"
            'Me.grdSocia.Columns("sDistrito").Caption = "Distrito"

            'Me.grdSocia.Splits(0).DisplayColumns("sNombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sNombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sFuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdSocia.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Recibo
            Me.grdRecibo.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = True
            Me.grdRecibo.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nStbEstadoReciboID").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nManual").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nAplicado").Visible = False
            Me.grdRecibo.Splits(0).DisplayColumns("nCodigoTalonario").Visible = False

            'Me.grdRecibo.ColumnFooters = True
            'Me.grdRecibo.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            'Me.grdRecibo.Splits(0).DisplayColumns("nValor").FooterStyle.ForeColor = Color.Blue

            Me.grdRecibo.Splits(0).DisplayColumns("nCodigo").Width = 100
            Me.grdRecibo.Splits(0).DisplayColumns("sConceptoPago").Width = 200
            Me.grdRecibo.Splits(0).DisplayColumns("nValor").Width = 100
            Me.grdRecibo.Splits(0).DisplayColumns("sEstadoRecibo").Width = 110
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").Width = 110
            Me.grdRecibo.Splits(0).DisplayColumns("login").Width = 110

            'Me.grdRecibo.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdRecibo.Columns("nCodigo").Caption = "C�digo"
            Me.grdRecibo.Columns("sConceptoPago").Caption = "Concepto del Pago"
            Me.grdRecibo.Columns("nValor").Caption = "Valor"
            Me.grdRecibo.Columns("sEstadoRecibo").Caption = "Estado"
            Me.grdRecibo.Columns("dFechaRecibo").Caption = "Fecha"
            Me.grdRecibo.Columns("login").Caption = "Ingresado Por"

            Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.grdRecibo.Splits(0).DisplayColumns.Item("nValor").Style.BackColor = Color.WhiteSmoke

            Me.grdRecibo.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("sEstadoRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("dFechaRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdRecibo.Splits(0).DisplayColumns("login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdRecibo.Columns("nValor").NumberFormat = "#,##0.00"

            'CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CalcularMontos
    ' Descripci�n:          Este procedimiento permite Calcular el Monto
    '                       Total para visualizarlo en el Grid de Otros Cr�ditos.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalValor As Double = 0

            For index As Integer = 0 To Me.grdRecibo.RowCount - 1
                Me.grdRecibo.Row = index
                If Me.grdRecibo.Columns("sEstadoRecibo").Value <> "Anulado" Then
                    vTotalValor = vTotalValor + Me.grdRecibo.Columns("nValor").Value
                End If
            Next
            If Me.grdRecibo.RowCount > 0 Then
                Me.grdRecibo.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdRecibo.Columns("nValor").FooterText = Format(vTotalValor, "#,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            XdsRecibo = New BOSistema.Win.XDataSet

            'Me.toolBuscar.Visible = False
            Me.toolModificar.Visible = False
            Me.toolEliminar.Visible = False
            Me.toolSeparador1.Visible = False

            Control.CheckForIllegalCrossThreadCalls = False

            strSQL = " SELECT nAccesoTotalLectura,nAccesoTotalEdicion " & _
                     " FROM StbDelegacionPrograma " & _
                     " WHERE nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion

            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nAccesoTotalLectura = XdtDatos.ValueField("nAccesoTotalLectura")
                nAccesoTotalEdicion = XdtDatos.ValueField("nAccesoTotalEdicion")
            End If

            If Me.IdTipoRecibo = 1 Then 'Autom�tico
                strSQL = " SELECT nStbPersonaLugarPagosID " & _
                         " FROM vwSclCajaCajero " & _
                         " WHERE ssgCuentaID = " & InfoSistema.IDCuenta & _
                         " AND nActiva = 1 "
                XdtDatos.ExecuteSql(strSQL)
                If XdtDatos.Count > 0 Then
                    IDPersonaLugarPagosID = XdtDatos.ValueField("nStbPersonaLugarPagosID")
                End If

                Me.toolAgregarM.Visible = False
                Me.toolModificarM.Visible = False
                Me.toolEliminarM.Visible = False
                Me.toolSeparadorManual.Visible = False
                Me.toolSeparadorAutomatico.Visible = False

                Me.toolAgregarReciboSobrante.Visible = False
                Me.toolModificarReciboSobrante.Visible = False

                Me.toolAgregarAutomatico.Visible = True
                Me.toolModificarAutomatico.Visible = True
                Me.toolEliminarAutomatico.Visible = True
            ElseIf Me.IdTipoRecibo = 2 Then
                Me.toolAgregarAutomatico.Visible = False
                Me.toolModificarAutomatico.Visible = False
                'Me.toolEliminarAutomatico.Visible = False

                Me.toolAgregarM.Visible = True
                Me.toolModificarM.Visible = True
                Me.toolEliminarM.Visible = True
                'Me.toolSeparadorManual.Visible = False

                Me.toolAgregarReciboSobrante.Visible = True
                Me.toolModificarReciboSobrante.Visible = True
            Else
                Me.toolAgregarAutomatico.Visible = False
                Me.toolModificarAutomatico.Visible = False
                Me.toolEliminarAutomatico.Visible = False

                Me.toolAgregarM.Visible = False
                Me.toolModificarM.Visible = False
                Me.toolEliminarM.Visible = False
                Me.toolSeparadorManual.Visible = False
                Me.toolSeparadorAutomatico.Visible = False

                Me.toolAgregarReciboSobrante.Visible = False
                Me.toolModificarReciboSobrante.Visible = False

            End If

            'Limpiar los Grids, estructura y Datos
            Me.grdSocia.ClearFields()
            Me.grdRecibo.ClearFields()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbSocia_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSocia.
    '-------------------------------------------------------------------------
    Private Sub tbSocia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocia.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscar()
            Case "toolRefrescar"
                'InicializaVariables()
                'Dim intPosicionSocia As Integer

                CargarRecibo("A%", 0)

                LlamaRefrescarRecibo()

                Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"
                'CalcularMontos()

                'intPosicionSocia = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
                'XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", intPosicionSocia)
                'Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position
            Case "toolImprimir"
                'LlamaImprimirListadoRecibo()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Su�rez Tijerino
    '' Fecha:                12/09/2007
    '' Procedure Name:       tbCaracterInicio_ItemClicked
    '' Descripci�n:          Este evento permite manejar las opciones del control
    ''                       toolStrip llamado tbSocia.
    ''-------------------------------------------------------------------------
    'Private Sub tbCaracterInicio_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    '    Try
    '        Select Case e.ClickedItem.Name
    '            Case "toolA"
    '                LlamarCargaRecibo("A%")
    '            Case "toolB"
    '                LlamarCargaRecibo("B%")
    '            Case "toolC"
    '                LlamarCargaRecibo("C%")
    '            Case "toolD"
    '                LlamarCargaRecibo("D%")
    '            Case "toolE"
    '                LlamarCargaRecibo("E%")
    '            Case "toolF"
    '                LlamarCargaRecibo("F%")
    '            Case "toolG"
    '                LlamarCargaRecibo("G%")
    '            Case "toolH"
    '                LlamarCargaRecibo("H%")
    '            Case "toolI"
    '                LlamarCargaRecibo("I%")
    '            Case "toolJ"
    '                LlamarCargaRecibo("J%")
    '            Case "toolK"
    '                LlamarCargaRecibo("K%")
    '            Case "toolL"
    '                LlamarCargaRecibo("L%")
    '            Case "toolM"
    '                LlamarCargaRecibo("M%")
    '            Case "toolN"
    '                LlamarCargaRecibo("N%")
    '            Case "tool�"
    '                LlamarCargaRecibo("�%")
    '            Case "toolO"
    '                LlamarCargaRecibo("O%")
    '            Case "toolP"
    '                LlamarCargaRecibo("P%")
    '            Case "toolQ"
    '                LlamarCargaRecibo("Q%")
    '            Case "toolR"
    '                LlamarCargaRecibo("R%")
    '            Case "toolS"
    '                LlamarCargaRecibo("S%")
    '            Case "toolT"
    '                LlamarCargaRecibo("T%")
    '            Case "toolU"
    '                LlamarCargaRecibo("U%")
    '            Case "toolV"
    '                LlamarCargaRecibo("V%")
    '            Case "toolW"
    '                LlamarCargaRecibo("W%")
    '            Case "toolX"
    '                LlamarCargaRecibo("X%")
    '            Case "toolY"
    '                LlamarCargaRecibo("Y%")
    '            Case "toolZ"
    '                LlamarCargaRecibo("Z%")
    '            Case "tool1"
    '                LlamarCargaRecibo("1%")
    '            Case "tool2"
    '                LlamarCargaRecibo("2%")
    '            Case "tool3"
    '                LlamarCargaRecibo("3%")
    '            Case "tool4"
    '                LlamarCargaRecibo("4%")
    '            Case "tool5"
    '                LlamarCargaRecibo("5%")
    '            Case "tool6"
    '                LlamarCargaRecibo("6%")
    '            Case "tool7"
    '                LlamarCargaRecibo("7%")
    '            Case "tool8"
    '                LlamarCargaRecibo("8%")
    '            Case "tool9"
    '                LlamarCargaRecibo("9%")
    '        End Select
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    Private Sub LlamarCargaRecibo(ByVal sCadenaFiltro As String)
        Try
            CargarRecibo(sCadenaFiltro, 0)

            LlamaRefrescarRecibo()

            Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

            'CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbRecibo_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMunicipio.
    '-------------------------------------------------------------------------
    Private Sub tbRecibo_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbRecibo.ItemClicked

        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim xObligarConCajaLocal As Integer
        Dim XcDatos As New BOSistema.Win.XComando
        Dim strSQL As String
        Dim IdEnvioCajaActual As Integer
        Dim IdCaja As Integer
        'Agregado febrero 4 del 2013 para que no ingresen recibos de cajas locales
        'solo se pueden agregar cuando se haya aplicado en central y no se haya generado el siguiente archivo de envio.
        'OJO

        If e.ClickedItem.Name <> "toolAyudaM" And e.ClickedItem.Name <> "toolModificarM" And e.ClickedItem.Name <> "toolModificarReciboSobrante" Then

            If e.ClickedItem.Name <> "toolAgregarM" Then
                If Me.grdRecibo.RowCount = 0 Then
                    MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            strSQL = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 84)"
            xObligarConCajaLocal = XcDatos.ExecuteScalar(strSQL) 'Si es 1 entonces valida que la caja local este recepcionada y aplicada, sin generar el siguiente archivo de envio.


            'strSQL = " SELECT     NoEnvio, nSteCajaId, EstadoEnvio, SsgCuentaID, FechaGenera, AplicadoEnCentral  FROM         dbo.SttProcesarEnvioES WHERE     (nSteCajaId = " & IdSteCaja & ") AND (NoEnvio > 0) AND (AplicadoEnCentral = 0) "
            If xObligarConCajaLocal = 1 Then

                strSQL = " SELECT     nSclFichaNotificacionID ,nSteCajaIDLocal FROM         dbo.SttCentralFichaNotificacionCreditoEnviadas  WHERE     (nActiva = 1) AND (nSclFichaNotificacionID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionID") & ") Order by nSttCentralFichaNotificacionCreditoEnviadas desc"
                XdtDatos.ExecuteSql(strSQL)

                If XdtDatos.Count > 0 Then

                    IdCaja = XdtDatos.ValueField("nSteCajaIDLocal")

                    If e.ClickedItem.Name = "toolEliminarM" Or e.ClickedItem.Name = "toolEliminarAutomatico" Then



                        strSQL = "SELECT     TOP (1) NoEnvio  as NoEnvio FROM         dbo.SttProcesarEnvioES  WHERE     (nSteCajaId = " & IdCaja & ") ORDER BY NoEnvio DESC"
                        XdtDatos.ExecuteSql(strSQL)
                        If XdtDatos.Count = 0 Then
                            MsgBox("No puede Agregar, Modificar o Anular Recibos. Por que Esa Ficha se encuentra en una base local enviada ." & Chr(13) & " Recuerde ingresar los recibos una vez aceptada la carga y antes de generar el siguiente envio.  ", MsgBoxStyle.Information)
                            Exit Sub
                        End If
                        IdEnvioCajaActual = XdtDatos.ValueField("NoEnvio")


                        strSQL = " SELECT     nSccReciboOficialCajaId  FROM         dbo.SttLocalSccConflictosRecibos WHERE nSccSolicitudChequeID=" & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID") & " And nstecajaidlocal=" & IdCaja & " And EnvioNumero=  " & IdEnvioCajaActual & " And ((nTipoConflicto=2  and  nSccReciboOficialCajaId  < " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaId") & " )  or (nTipoConflicto=1 And nSccReciboOficialCajaId = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaId") & "))"
                        XdtDatos.ExecuteSql(strSQL)
                        If XdtDatos.Count = 0 Then
                            MsgBox("No puede Agregar, Modificar o Anular Recibos. Por que Esa Ficha se encuentra en una base local enviada ." & Chr(13) & " Recuerde ingresar los recibos una vez aceptada la carga y antes de generar el siguiente envio.  ", MsgBoxStyle.Information)
                            Exit Sub
                        End If


                    Else
                        MsgBox("No puede Agregar, Modificar . Por que Esa Ficha se encuentra en una base local enviada ." & Chr(13) & " Recuerde ingresar los recibos una vez aceptada la carga y antes de generar el siguiente envio.  ", MsgBoxStyle.Information)
                        Exit Sub
                    End If





                End If
            End If
        End If
        Select Case e.ClickedItem.Name
            Case "toolAgregarM"
                LlamaAgregarRecibo(0)
            Case "toolModificarM"
                LlamaModificarRecibo(0)
            Case "toolEliminarM"
                LlamaEliminarRecibo(0)
            Case "toolAgregarAutomatico"
                LlamaAgregarReciboAutomatico(0)
            Case "toolModificarAutomatico"
                LlamaModificarReciboAutomatico(0)
            Case "toolEliminarAutomatico"
                LlamaEliminarReciboAutomatico(1)
            Case "toolAgregarReciboSobrante"
                LlamaAgregarRecibo(1)
            Case "toolModificarReciboSobrante"
                LlamaModificarRecibo(1)
            Case "toolRefrescarM"
                LlamaRefrescarRecibo()

            Case "toolImprimirM"
                'LlamaImprimirTicket(grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID"), 1, True)

                'LlamaImprimirRecibo()
                'Case "toolAnularConRegeneracion"
                '    LlamaAnularConRegeneracion()
            Case "toolAyudaM"
                LlamaAyuda()
        End Select
    End Sub
    'Private Sub LlamaImprimirRecibo()
    '    Try
    '        If Me.grdRecibo.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        LlamaImprimirTicket(grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID"), 1, True)

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    Private Sub LlamaRefrescarRecibo()
        Try
            'Dim intPosicionSocia As Integer
            'Dim intPosicionRecibo As Integer
            Dim strsql As String = ""

            'intPosicionSocia = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            'intPosicionRecibo = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'InicializaVariables()
            'CargarRecibo()
            Me.grdRecibo.ClearFields()

            If Me.grdSocia.RowCount = 0 Then
                strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo,a.nStbEstadoReciboID,a.login,a.nManual,a.nAplicado, a.NCodigoTalonario " & _
                 " From vwSccReciboSocia a Where a.nSccSolicitudChequeID = 0" & _
                 " Order by a.nCodigoRecibo ASC,a.sEstadoRecibo ASC " & _
                 " OPTION (FORCE ORDER)"
            Else
                strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo,a.nStbEstadoReciboID,a.login,a.nManual,a.nAplicado,a.NCodigoTalonario " & _
                 " From vwSccReciboSocia a Where a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID") & _
                 " Order by a.nCodigoRecibo ASC,a.sEstadoRecibo ASC " & _
                 " OPTION (FORCE ORDER)"
            End If

            If XdsRecibo.ExistTable("Recibo") Then
                XdsRecibo("Recibo").ExecuteSql(strsql)
            Else
                XdsRecibo.NewTable(strsql, "Recibo")
                XdsRecibo("Recibo").Retrieve()
            End If

            'If XdsRecibo.ExistRelation("SociaConRecibo") = False Then
            '    'Creando la relaci�n entre el Primer Query y el Segundo
            '    XdsRecibo.NewRelation("SociaConRecibo", "Socia", "Recibo", "nSccSolicitudChequeID", "nSccSolicitudChequeID")
            'End If

            'XdsRecibo.SincronizarRelaciones()

            ' Me.grdRecibo.ClearFields()
            Me.grdRecibo.DataSource = XdsRecibo("Recibo").Source

            Me.grdRecibo.Rebind(False)

            FormatoDetalleRecibo()


            'XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", intPosicionSocia)
            'Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

            'XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", intPosicionRecibo)
            'Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSccEditRecibo para Agregar un nuevo Recibo para una
    '                       determinadoa Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscar()
        Dim ObjFrmSclEditCedula As New frmSclEditCedula
        'Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            'Dim strSQL As String = ""
            Dim IdFichaNotificacion As Integer


            'If Me.grdSocia.RowCount = 0 Then
            '    MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
            '         " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
            '         " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count <= 0 Then
            '    MsgBox("No puede Agregar Recibos. Todas las Cuotas est�n Pagadas.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ''Validar que la Solicitud de Cheque no haya cambiado a Anulada
            'strSQL = " Select a.nSccSolicitudChequeID " & _
            '         " From SccSolicitudCheque a " & _
            '         " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
            '         " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    MsgBox("No puede Agregar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ''Determinar la Caja
            'strSQL = " SELECT b.nSteCajaID FROM SclFichaNotificacionCredito a " & _
            '         " INNER JOIN SteCaja b " & _
            '         " ON a.nStbPersonaLugarPagosID = b.nStbPersonaLugarPagosID " & _
            '         " WHERE a.nSclFichaNotificacionID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionID")

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count <= 0 Then
            '    MsgBox("Debe existir Caja para el Lugar de Pago correspondiente.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'ObjFrmSccEditReciboCaja.ModoFrm = "ADD"
            'ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            'ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            'ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            ObjFrmSclEditCedula.IdPersonaLugarPagosID = Me.IDPersonaLugarPagosID
            ObjFrmSclEditCedula.IdConsultarDelegacion = Me.nAccesoTotalLectura
            ObjFrmSclEditCedula.IdTipoRecibo = Me.IdSclTipoRecibo
            ObjFrmSclEditCedula.ShowDialog()
            IdFichaNotificacion = ObjFrmSclEditCedula.IdFichaNotificacion

            If ObjFrmSclEditCedula.IdFichaNotificacion <> 0 Then
                CargarRecibo("", IdFichaNotificacion)
                'CargarRecibo()
                'LlamaRefrescarRecibo()
                'XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
                'Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

                'XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
                'Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

            LlamaRefrescarRecibo()
            Me.tbRecibo.Enabled = True

            'Me.tbRecibo.Enabled = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditCedula.Close()
            ObjFrmSclEditCedula = Nothing

            'XdtDatos.Close()
            'XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSccEditRecibo para Agregar un nuevo Recibo para una
    '                       determinadoa Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibo(ByVal IdEspecial As Short)
        Dim ObjFrmSccEditReciboCaja As New frmSccEditReciboCajaManual
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            If Me.grdSocia.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Agregar Recibos. Todas las Cuotas est�n Pagadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            strSQL = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Agregar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Determinar la Caja
            strSQL = " SELECT b.nSteCajaID FROM SclFichaNotificacionCredito a " & _
                     " INNER JOIN SteCaja b " & _
                     " ON a.nStbPersonaLugarPagosID = b.nStbPersonaLugarPagosID " & _
                     " WHERE a.nSclFichaNotificacionID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("Debe existir Caja para el Lugar de Pago correspondiente.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSccEditReciboCaja.ModoFrm = "ADD"
            ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            ObjFrmSccEditReciboCaja.sCodigoTipoPlanNegocio = XdsRecibo("Socia").ValueField("sCodigoTipoPlanNegocio")
            ObjFrmSccEditReciboCaja.sTipoPrograma = XdsRecibo("Socia").ValueField("CodigoPrograma")
            ObjFrmSccEditReciboCaja.sCodigoPlazo = XdsRecibo("Socia").ValueField("sCodTipoPlazoPago")

            ObjFrmSccEditReciboCaja.ShowDialog()

            If ObjFrmSccEditReciboCaja.IdReciboOficialCaja <> 0 Then
                'CargarRecibo()
                LlamaRefrescarRecibo()
                XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
                Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

                XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditReciboCaja.Close()
            ObjFrmSccEditReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSccEditRecibo para Agregar un nuevo Recibo para una
    '                       determinadoa Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarReciboAutomatico(ByVal IdEspecial As Short)
        Dim ObjFrmSccEditReciboCaja As New frmSccEditReciboCajaAutomatico
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            If Me.grdSocia.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Agregar Recibos. Todas las Cuotas est�n Pagadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            strSQL = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Agregar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmSccEditReciboCaja.ModoFrm = "ADD"
            ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            ObjFrmSccEditReciboCaja.ShowDialog()

            If ObjFrmSccEditReciboCaja.IdReciboOficialCaja <> 0 Then
                'CargarRecibo()
                LlamaRefrescarRecibo()
                XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
                Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

                XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditReciboCaja.Close()
            ObjFrmSccEditReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSccEditReciboCaja para Modificar un Recibo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibo(ByVal IdEspecial As Short)
        Dim ObjFrmSccEditReciboCaja As New frmSccEditReciboCajaManual
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se verificar si el Estado del Recibo es Anulado
            strSQL = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja' "
            'If XcDatos.ExecuteScalar(Strsql) = XdsRecibo("Recibo").ValueField("nStbEstadoReciboID") Then
            '    MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

            If XcDatos.ExecuteScalar(strSQL) = "3" Then
                MsgBox("El Recibo tiene Estado Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Valida que no se modifique si est� Cancelado
            strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Modificar Recibos. Cr�dito Cancelado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If nAccesoTotalEdicion = 0 Then
                If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("No puede Modificar datos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'No permito modificar si el Recibo fue generado autom�ticamente
            If XdsRecibo("Recibo").ValueField("nManual") = 0 Or XdsRecibo("Recibo").ValueField("nAplicado") = 0 Then
                MsgBox("Recibo generado por el Sistema. No puede ser Modificado.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If Me.IdSclTipoRecibo = 2 Then
                If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaRecibo")) = False Then
                    MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                    'ValidaDatosAnular = False
                    Exit Sub
                End If
            End If

            'Permito mostrar los datos en la modificaci�n, pero no modificarlos
            'si hay recibos con fecha posterior. Mando aqui mensaje de advertencia.
            strSQL = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Modificado. Existen Recibos con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
                'Exit Sub
            End If

            'Validar que el Recibo no est� contenido en un Cierre
            strSQL = " Select nSccCierreDiarioCajaID From vwSccReciboEstadoCierre " & _
                     " Where nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("Recibo NO puede ser modificado, por estar contenido en un Cierre Diario de Caja", MsgBoxStyle.Critical, "SMUSURA0")
                'Exit Sub
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            strSQL = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Modificar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            strSQL = " Select nSccCierreDiarioCajaID From vwSccReciboEstadoCierre " & _
                     " Where sEstadoCierre = 'Cerrado' And nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No se puede Modificar, por estar incluido en un Cierre Diario de Caja" & Chr(10) & _
                        "en Estado Cerrado, es decir que tiene Transacci�n Contable.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSccEditReciboCaja.ModoFrm = "UPD"
            ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            ObjFrmSccEditReciboCaja.sCodigoTipoPlanNegocio = XdsRecibo("Socia").ValueField("sCodigoTipoPlanNegocio")
            ObjFrmSccEditReciboCaja.sTipoPrograma = XdsRecibo("Socia").ValueField("CodigoPrograma")
            ObjFrmSccEditReciboCaja.sCodigoPlazo = XdsRecibo("Socia").ValueField("sCodTipoPlazoPago")

            ObjFrmSccEditReciboCaja.ShowDialog()

            'CargarRecibo()
            LlamaRefrescarRecibo()
            XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
            Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

            XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
            Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditReciboCaja.Close()
            ObjFrmSccEditReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSccEditReciboCaja para Modificar un Recibo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarReciboAutomatico(ByVal IdEspecial As Short)
        Dim ObjFrmSccEditReciboCaja As New frmSccEditReciboCajaAutomatico
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Se verificar si el Estado del Recibo es Anulado
            strSQL = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja' "
            'If XcDatos.ExecuteScalar(Strsql) = XdsRecibo("Recibo").ValueField("nStbEstadoReciboID") Then
            '    MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

            If XcDatos.ExecuteScalar(strSQL) = "3" Then
                MsgBox("El Recibo tiene Estado Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Permito mostrar los datos en la modificaci�n, pero no modificarlos
            'si hay recibos con fecha posterior. Mando aqui mensaje de advertencia.
            strSQL = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Modificado. Existen Recibos con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
                'Exit Sub
            End If

            ''Validar que el Recibo no est� contenido en un Cierre
            'strSQL = " Select nSccCierreDiarioCajaID From vwSccReciboEstadoCierre " & _
            '         " Where nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    MsgBox("Recibo NO puede ser modificado, por estar contenido en un Cierre Diario de Caja", MsgBoxStyle.Critical, "SMUSURA0")
            '    'Exit Sub
            'End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            strSQL = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Modificar Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'strSQL = " Select nSccCierreDiarioCajaID From vwSccReciboEstadoCierre " & _
            '         " Where sEstadoCierre = 'Cerrado' And nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'XdtDatos.ExecuteSql(strSQL)

            'If XdtDatos.Count > 0 Then
            '    MsgBox("No se puede Modificar, por estar incluido en un Cierre Diario de Caja" & Chr(10) & _
            '            "en Estado Cerrado, es decir que tiene Transacci�n Contable.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Valida que no se modifique si est� Cancelado
            strSQL = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Modificar Recibos. Cr�dito Cancelado.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            ObjFrmSccEditReciboCaja.ModoFrm = "UPD"
            ObjFrmSccEditReciboCaja.IdEspecial = IdEspecial
            ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
            ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
            ObjFrmSccEditReciboCaja.ShowDialog()

            'CargarRecibo()
            LlamaRefrescarRecibo()
            XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
            Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

            XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
            Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditReciboCaja.Close()
            ObjFrmSccEditReciboCaja = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaModificarRecibo
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSccEditReciboCaja para Modificar un Recibo existente.
    '-------------------------------------------------------------------------
    'Private Sub LlamaAnularConRegeneracion()
    '    Dim XdtReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
    '    Dim XdrReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow
    '    Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento

    '    Dim ObjFrmSccEditReciboCaja As New frmSccEditReciboCaja
    '    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    '    Try
    '        Dim strSQL As String = ""
    '        Dim strCausaAnulacion As String

    '        If Me.grdRecibo.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Valido que no existan Recibos Cerrados con fecha posterior. 
    '        strSQL = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
    '                 " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
    '                 " AND nStbEstadoReciboID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoReciboOficialCaja') " & _
    '                 " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

    '        XdtDatos.ExecuteSql(strSQL)

    '        If XdtDatos.Count > 0 Then
    '            MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos Cerrados con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
    '            Exit Sub
    '        End If

    '        If ValidaDatosAnularConRegeneracion() Then

    '            If MsgBox("�Est� seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

    '                'Solicita al Usuario la Causa de la Anulaci�n
    '                XdtReciboAnular.Filter = " nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
    '                XdtReciboAnular.Retrieve()
    '                XdrReciboAnular = XdtReciboAnular.Current

    '                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulaci�n? "
    '                ObjFrmStbDatoComplemento.strTitulo = "Anulaci�n del Recibo Oficial de Caja"
    '                ObjFrmStbDatoComplemento.intAncho = XdrReciboAnular.GetColumnLenght("sMotivoAnulacion")
    '                ObjFrmStbDatoComplemento.strDato = ""
    '                ObjFrmStbDatoComplemento.strColor = "Verde"
    '                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulaci�n NO DEBE quedar vac�a"
    '                ObjFrmStbDatoComplemento.ShowDialog()

    '                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

    '                'Valida que se ingrese la Causa de la Anulaci�n
    '                If strCausaAnulacion = "" Then
    '                    MsgBox("El Recibo NO PUEDE ser Anulado. Debe ingresar Causa de Anulaci�n.", MsgBoxStyle.Critical, "SMUSURA0")
    '                    Exit Sub
    '                End If

    '                ObjFrmSccEditReciboCaja.ModoFrm = "ACR"
    '                ObjFrmSccEditReciboCaja.MotivoAnulacion = strCausaAnulacion
    '                ObjFrmSccEditReciboCaja.IdSolicitudCheque = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
    '                ObjFrmSccEditReciboCaja.IdReciboOficialCaja = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
    '                ObjFrmSccEditReciboCaja.ShowDialog()

    '                'CargarRecibo()
    '                LlamaRefrescarRecibo()

    '                XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSccEditReciboCaja.IdSolicitudCheque)
    '                Me.grdSocia.Row = XdsRecibo("Socia").BindingSource.Position

    '                XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", ObjFrmSccEditReciboCaja.IdReciboOficialCaja)
    '                Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
    '            End If
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmSccEditReciboCaja.Close()
    '        ObjFrmSccEditReciboCaja = Nothing

    '        XdtDatos.Close()
    '        XdtDatos = Nothing

    '        XdtReciboAnular.Close()
    '        XdtReciboAnular = Nothing

    '        XdrReciboAnular.Close()
    '        XdrReciboAnular = Nothing

    '        ObjFrmStbDatoComplemento = Nothing
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaEliminarMunicipio
    ' Descripci�n:          Este procedimiento permite eliminar un registro
    '                       de un Municipio asociado a un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRecibo(ByVal nOpcionAutomatico As Short)
        Dim XdtReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
        Dim XdrReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            Dim intPosicionSocia As Integer  'Posicion del registro seleccionado, ID de la Ficha
            Dim intPosicionRecibo As Integer
            Dim strCausaAnulacion As String
            Dim intReciboID As Integer

            If ValidaDatosAnular(nOpcionAutomatico) Then
                If MsgBox("�Est� seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                    'Solicita al Usuario la Causa de la Anulaci�n
                    XdtReciboAnular.Filter = " nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
                    XdtReciboAnular.Retrieve()
                    XdrReciboAnular = XdtReciboAnular.Current

                    ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulaci�n? "
                    ObjFrmStbDatoComplemento.strTitulo = "Anulaci�n del Recibo Oficial de Caja"
                    ObjFrmStbDatoComplemento.intAncho = XdrReciboAnular.GetColumnLenght("sMotivoAnulacion")
                    ObjFrmStbDatoComplemento.strDato = ""
                    ObjFrmStbDatoComplemento.strColor = "Verde"
                    ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulaci�n NO DEBE quedar vac�a"
                    ObjFrmStbDatoComplemento.ShowDialog()

                    strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                    'Valida que se ingrese la Causa de la Anulaci�n
                    If strCausaAnulacion = "" Then

                        MsgBox("El Recibo NO PUEDE ser Anulado. Debe ingresar Causa de Anulaci�n.", MsgBoxStyle.Critical, "SMUSURA0")
                        Exit Sub
                    End If

                    Strsql = " EXEC spSccAnularRecibo " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'," & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

                    intReciboID = XcDatos.ExecuteScalar(Strsql)

                    'Si el salvado se realiz� de forma satisfactoria
                    'enviar mensaje informando y cerrar el formulario.
                    If intReciboID = 0 Then

                        'Strsql = " Update SccTablaAmortizacion " & _
                        '   " SET nStbEstadoPagoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoPagoAmortizacion') " & _
                        '   " WHERE nSccTablaAmortizacionID IN (SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacionPagos Where nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & ")"

                        'Trans.ExecuteSql(Strsql)

                        ''Actualizar el Estado del Recibo a Anulado.
                        'Strsql = " Update SccReciboOficialCaja " & _
                        '        "  SET nStbEstadoReciboID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja')," & _
                        '        "      sMotivoAnulacion = '" & strCausaAnulacion & "'," & _
                        '        "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & "," & _
                        '        "      dFechaModificacion = getdate()" & _
                        '        "  WHERE nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

                        MsgBox("La Anulaci�n del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                    Else
                        MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                                "de forma satisfactoria.", MsgBoxStyle.Information)
                        'Guardar posici�n actual de la selecci�n
                        intPosicionSocia = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
                        intPosicionRecibo = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

                        'CargarRecibo()
                        LlamaRefrescarRecibo()

                        XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", intPosicionSocia)
                        Me.grdRecibo.Row = XdsRecibo("Socia").BindingSource.Position

                        XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", intPosicionRecibo)
                        Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
                    End If
                End If
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosAnular
    ' Descripci�n:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de Anular un
    '                       Recibo.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAnular(ByVal nOpcionAutomatico As Short) As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim IntCodigoTalonario As Integer
        Try
            ValidaDatosAnular = True

            Dim Strsql As String
            Dim dFechaServidor As Date
            Dim dFechaRecibo As Date

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'No permito anular si el Recibo fue generado autom�ticamente
            If XdsRecibo("Recibo").ValueField("nManual") = 0 Or XdsRecibo("Recibo").ValueField("nAplicado") = 0 Then
                MsgBox("Recibo generado por el Sistema. No puede ser Anulado.", MsgBoxStyle.Information)
                ValidaDatosAnular = False
                Exit Function
            End If

            

            If nOpcionAutomatico = 1 Then
                dFechaServidor = FechaServer.Date
                dFechaRecibo = XdsRecibo("Recibo").ValueField("dFechaRecibo")

                If dFechaServidor.Date <> dFechaRecibo.Date Then
                    MsgBox("Fecha del Recibo a Anular DEBE ser Igual a la Fecha Actual.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosAnular = False
                    Exit Function
                End If
            Else
                'If nAccesoTotalEdicion = 0 Then
                '    If InfoSistema.IDDelegacion <> XdsRecibo("Recibo").ValueField("nStbDelegacionProgramaID") Then
                '        MsgBox("No puede Modificar datos de otra Delegaci�n.", MsgBoxStyle.Information)
                '        ValidaDatosAnular = False
                '        Exit Function
                '    End If
                'End If

                'Imposible si el mes se encuentra cerrado:
                If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaRecibo")) = False Then
                    MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                    ValidaDatosAnular = False
                    Exit Function
                End If

                'Validar que el recibo no pertenezca a un Arqueo que no est� anulado
                Strsql = " Select a.nSccReciboOficialCajaID " & _
                         " From SteArqueoRecibo a INNER JOIN SteArqueoCaja b " & _
                         " ON a.nSteArqueoCajaID = b.nSteArqueoCajaID " & _
                         " Where b.nStbEstadoArqueoID <> (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoArqueoCaja') " & _
                         " And a.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

                XdtDatos.ExecuteSql(Strsql)

                If XdtDatos.Count > 0 Then
                    MsgBox("No puede Anular este Recibo. Pertenece a un Arqueo activo.", MsgBoxStyle.Information)
                    ValidaDatosAnular = False
                    Exit Function
                End If
            End If

            'Se verificar si el Estado del Recibo es Anulado
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja' "
            'If XcDatos.ExecuteScalar(Strsql) = XdsRecibo("Recibo").ValueField("nStbEstadoReciboID") Then
            '    MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

            If XcDatos.ExecuteScalar(Strsql) = "3" Then
                MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Cerrado
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoReciboOficialCaja' "
            'If XcDatos.ExecuteScalar(Strsql) = XdsRecibo("Recibo").ValueField("nStbEstadoReciboID") Then
            '    MsgBox("El Recibo NO PUEDE ser Anulado, porque actualmente tiene estado Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

            If XcDatos.ExecuteScalar(Strsql) = "2" Then
                MsgBox("El Recibo NO PUEDE ser Anulado, porque actualmente tiene estado Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            ''Validar que el recibo no pertenezca a un Arqueo que no est� anulado
            'Strsql = " Select a.nSccReciboOficialCajaID " & _
            '         " From SteArqueoRecibo a INNER JOIN SteArqueoCaja b " & _
            '         " ON a.nSteArqueoCajaID = b.nSteArqueoCajaID " & _
            '         " Where b.nStbEstadoArqueoID <> (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoArqueoCaja') " & _
            '         " And a.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            'XdtDatos.ExecuteSql(Strsql)

            'If XdtDatos.Count > 0 Then
            '    MsgBox("No puede Anular este Recibo. Pertenece a un Arqueo activo.", MsgBoxStyle.Information)
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            Strsql = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Anular Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                ValidaDatosAnular = False
                Exit Function
            End If

            'No permito Anular si hay recibos con fecha posterior
            Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'No permito Anular si hay recibos posteriores
            Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE nSccReciboOficialCajaID > " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos posteriores.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Valida que no se modifique si est� Cancelado
            Strsql = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
                     " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
                     " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            XdtDatos.ExecuteSql(Strsql)

            'REM COMENTARIO TEMPORAL
            If XdtDatos.Count <= 0 Then
                MsgBox("No puede Anular Recibos. Cr�dito Cancelado.", MsgBoxStyle.Information)
                ValidaDatosAnular = False
                Exit Function
            End If

            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 67)"
            IntCodigoTalonario = XcDatos.ExecuteScalar(Strsql)
            If XdsRecibo("Recibo").ValueField("nCodigoTalonario") < IntCodigoTalonario - 1 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Es menor que el penultimo tipo de talonario en el sistema ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosAnular = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaEliminarMunicipio
    ' Descripci�n:          Este procedimiento permite eliminar un registro
    '                       de un Municipio asociado a un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarReciboAutomatico(ByVal nOpcionAutomatico As Short)
        Dim XdtReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
        Dim XdrReciboAnular As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaRow
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            Dim intPosicionSocia As Integer  'Posicion del registro seleccionado, ID de la Ficha
            Dim intPosicionRecibo As Integer
            Dim strCausaAnulacion As String
            Dim intReciboID As Integer

            If ValidaDatosAnularReciboAutomatico(nOpcionAutomatico) Then
                If MsgBox("�Est� seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                    'Solicita al Usuario la Causa de la Anulaci�n
                    XdtReciboAnular.Filter = " nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")
                    XdtReciboAnular.Retrieve()
                    XdrReciboAnular = XdtReciboAnular.Current

                    ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulaci�n? "
                    ObjFrmStbDatoComplemento.strTitulo = "Anulaci�n del Recibo Oficial de Caja"
                    ObjFrmStbDatoComplemento.intAncho = XdrReciboAnular.GetColumnLenght("sMotivoAnulacion")
                    ObjFrmStbDatoComplemento.strDato = ""
                    ObjFrmStbDatoComplemento.strColor = "Verde"
                    ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulaci�n NO DEBE quedar vac�a"
                    ObjFrmStbDatoComplemento.ShowDialog()

                    strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                    'Valida que se ingrese la Causa de la Anulaci�n
                    If strCausaAnulacion = "" Then

                        MsgBox("El Recibo NO PUEDE ser Anulado. Debe ingresar Causa de Anulaci�n.", MsgBoxStyle.Critical, "SMUSURA0")
                        Exit Sub
                    End If

                    Strsql = " EXEC spSccAnularRecibo " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & "," & InfoSistema.IDCuenta & ",'" & strCausaAnulacion & "'," & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

                    intReciboID = XcDatos.ExecuteScalar(Strsql)

                    'Si el salvado se realiz� de forma satisfactoria
                    'enviar mensaje informando y cerrar el formulario.
                    If intReciboID = 0 Then

                        MsgBox("La Anulaci�n del Recibo NO PUDO realizarse.", MsgBoxStyle.Information, "SMUSURA0")
                    Else
                        MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                                "de forma satisfactoria.", MsgBoxStyle.Information)
                        'Guardar posici�n actual de la selecci�n
                        intPosicionSocia = XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")
                        intPosicionRecibo = XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

                        LlamaRefrescarRecibo()

                        XdsRecibo("Socia").SetCurrentByID("nSccSolicitudChequeID", intPosicionSocia)
                        Me.grdRecibo.Row = XdsRecibo("Socia").BindingSource.Position

                        XdsRecibo("Recibo").SetCurrentByID("nSccReciboOficialCajaID", intPosicionRecibo)
                        Me.grdRecibo.Row = XdsRecibo("Recibo").BindingSource.Position
                    End If
                End If
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosAnular
    ' Descripci�n:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de Anular un
    '                       Recibo.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAnularReciboAutomatico(ByVal nOpcionAutomatico As Short) As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            ValidaDatosAnularReciboAutomatico = True

            Dim Strsql As String
            Dim dFechaServidor As Date
            Dim dFechaRecibo As Date

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            dFechaServidor = FechaServer.Date
            dFechaRecibo = XdsRecibo("Recibo").ValueField("dFechaRecibo")

            ''No permito Anular si hay Cierre de Caja para el d�a actual
            'Strsql = " SELECT nSteCierreDiarioCajaID FROM SteCierreDiarioCaja " & _
            '         " WHERE convert(datetime,dFechaCierre,105) = convert(datetime,'" & dFechaServidor.Date & "',105)" & _
            '         " AND nSteCajaID = " & IdSteCaja & _
            '         " AND nCerrada = 1 "

            'XdtDatos.ExecuteSql(Strsql)

            'If XdtDatos.Count > 0 Then
            '    MsgBox("Caja Cerrada.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosAnularReciboAutomatico = False
            '    Exit Function
            'End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsRecibo("Recibo").ValueField("dFechaRecibo")) = False Then
                MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            'No permito anular en esta opci�n si el Recibo fue generado manualmente
            If XdsRecibo("Recibo").ValueField("nManual") = 1 Or XdsRecibo("Recibo").ValueField("nAplicado") = 0 Then
                MsgBox("Recibo ingresado de forma Manual. No puede ser Anulado.", MsgBoxStyle.Information)
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            If dFechaServidor.Date = dFechaRecibo.Date Then
                MsgBox("Fecha del Recibo a Anular DEBE SER MENOR a la Fecha Actual.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Anulado
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            If XcDatos.ExecuteScalar(Strsql) = "3" Then
                MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Cerrado
            Strsql = " Select a.sCodigoInterno FROM StbValorCatalogo a " & _
                     " INNER JOIN SccReciboOficialCaja b " & _
                     " ON b.nStbEstadoReciboID = a.nStbValorCatalogoID " & _
                     " WHERE b.nSccReciboOficialCajaID = " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID")

            If XcDatos.ExecuteScalar(Strsql) = "2" Then
                MsgBox("El Recibo NO PUEDE ser Anulado, porque actualmente tiene estado Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            'Validar que la Solicitud de Cheque no haya cambiado a Anulada
            Strsql = " Select a.nSccSolicitudChequeID " & _
                     " From SccSolicitudCheque a " & _
                     " Where a.nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('5') And b.sNombre = 'EstadoSolicitudCheque') " & _
                     " And a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("No puede Anular Recibos. Solicitud Anulada.", MsgBoxStyle.Information)
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            'No permito Anular si hay recibos con fecha posterior
            Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE convert(datetime,dFechaRecibo,105) > convert(datetime,'" & XdsRecibo("Recibo").ValueField("dFechaRecibo") & "',105)" & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos con Fecha posterior.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If

            'No permito Anular si hay recibos posteriores
            Strsql = " SELECT nSccReciboOficialCajaID FROM SccReciboOficialCaja " & _
                     " WHERE nSccReciboOficialCajaID > " & XdsRecibo("Recibo").ValueField("nSccReciboOficialCajaID") & _
                     " AND nStbEstadoReciboID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja') " & _
                     " AND nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID")

            XdtDatos.ExecuteSql(Strsql)

            If XdtDatos.Count > 0 Then
                MsgBox("El Recibo NO PUEDE ser Anulado. Existen Recibos posteriores.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularReciboAutomatico = False
                Exit Function
            End If


            ''Valida que no se modifique si est� Cancelado
            'Strsql = " SELECT nSccTablaAmortizacionID FROM SccTablaAmortizacion " & _
            '         " WHERE nStbEstadoPagoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('1','2') And b.sNombre = 'EstadoPagoAmortizacion') " & _
            '         " AND nSclFichaNotificacionDetalleID = " & XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")

            'XdtDatos.ExecuteSql(Strsql)

            'If XdtDatos.Count <= 0 Then
            '    MsgBox("No puede Anular Recibos. Cr�dito Cancelado.", MsgBoxStyle.Information)
            '    ValidaDatosAnular = False
            '    Exit Function
            'End If

        Catch ex As Exception
            ValidaDatosAnularReciboAutomatico = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosAnular
    ' Descripci�n:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de Anular un
    '                       Recibo.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAnularConRegeneracion() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        'Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            ValidaDatosAnularConRegeneracion = True

            Dim Strsql As String

            If Me.grdRecibo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularConRegeneracion = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Anulado
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoReciboOficialCaja' "
            If XcDatos.ExecuteScalar(Strsql) = XdsRecibo("Recibo").ValueField("nStbEstadoReciboID") Then
                MsgBox("El Recibo ya tiene Estado Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularConRegeneracion = False
                Exit Function
            End If

            'Se verificar si el Estado del Recibo es Cerrado
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoReciboOficialCaja' "
            If XcDatos.ExecuteScalar(Strsql) = XdsRecibo("Recibo").ValueField("nStbEstadoReciboID") Then
                MsgBox("El Recibo NO PUEDE ser Anulado, porque actualmente tiene estado Cerrado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnularConRegeneracion = False
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            'XdtDatos.Close()
            'XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripci�n:          Este procedimiento permite cerrar la opci�n de Departamento.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripci�n:          Este procedimiento permite presentar la Ayuda en
    '                       L�nea al usuario. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdSocia_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSocia.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdSocia_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSocia.Filter
        Try
            'If Strings.Right(e.Condition, 3) = "#*'" Then
            XdsRecibo("Socia").FilterLocal(e.Condition)

            Me.tbRecibo.Enabled = False

            'If e.Condition <> "" Then
            'LlamaRefrescarRecibo()
            'End If
            Me.grdSocia.Caption = " Listado de Socias (" + Me.grdSocia.RowCount.ToString + " registros)"
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       Seguridad
    ' Descripci�n:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()

        Try
            Seg.RefreshPermissions()
            ''Temporal
            ''Exit Sub

            ''Temporal()
            ' Agregar
            If Seg.HasPermission("AgregarRecibo") Then
                Me.toolAgregarM.Enabled = True
            Else
                Me.toolAgregarM.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarRecibo") Then
                Me.toolModificarM.Enabled = True
            Else
                Me.toolModificarM.Enabled = False
            End If

            ' Agregar Recibo Con Sobrante
            If Seg.HasPermission("AgregarReciboConSobrante") Then
                Me.toolAgregarReciboSobrante.Enabled = True
            Else
                Me.toolAgregarReciboSobrante.Enabled = False
            End If

            'Editar Recibo Con Sobrante
            If Seg.HasPermission("ModificarReciboConSobrante") Then
                Me.toolModificarReciboSobrante.Enabled = True
            Else
                Me.toolModificarReciboSobrante.Enabled = False
            End If

            'Anular
            If Seg.HasPermission("AnularRecibo") Then
                Me.toolEliminarM.Enabled = True
            Else
                Me.toolEliminarM.Enabled = False
            End If

            ' Agregar Recibo Autom�tico
            If Seg.HasPermission("AgregarReciboAutomatico") Then
                Me.toolAgregarAutomatico.Enabled = True
            Else
                Me.toolAgregarAutomatico.Enabled = False
            End If

            'Modificar Recibo Autom�tico
            If Seg.HasPermission("ModificarReciboAutomatico") Then
                Me.toolModificarAutomatico.Enabled = True
            Else
                Me.toolModificarAutomatico.Enabled = False
            End If

            'Anular Recibo Autom�tico
            If Seg.HasPermission("AnularReciboAutomaticoEspecial") Then
                Me.toolEliminarAutomatico.Enabled = True
            Else
                Me.toolEliminarAutomatico.Enabled = False
            End If

            'Buscar
            If Seg.HasPermission("BuscarGrupoSocia") Then
                Me.toolBuscar.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirRecibo") Then
                Me.toolImprimirM.Enabled = True
            Else
                Me.toolImprimirM.Enabled = False
            End If

            'Imprimir Consulta de Recibos
            If Seg.HasPermission("ImprimirReporteCC20") Then
                Me.mnuConsultaDeRecibosToolStripMenuItem.Enabled = True
            Else
                Me.mnuConsultaDeRecibosToolStripMenuItem.Enabled = False
            End If

            'Imprimir Estado Cuenta
            If Seg.HasPermission("ImprimirEstadoCuenta") Then
                Me.mnuEstadoDeCuentaToolStripMenuItem.Enabled = True
            Else
                Me.mnuEstadoDeCuentaToolStripMenuItem.Enabled = False
            End If

            'Imprimir Estado de Cuenta Resumen Por Grupo:
            If Seg.HasPermission("ImprimirEstadoCuentaResumen") Then
                Me.toolImprimirEC.Enabled = True
            Else
                Me.toolImprimirEC.Enabled = False
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdSocia_RowColChange
    ' Descripci�n:          Este evento permite actualizar el t�tulo del grid
    '                       de Recibos con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdSocia.RowColChange
        Dim strsql As String = ""

        'strsql = " Select a.nSccReciboOficialCajaID,a.nSccSolicitudChequeID,a.nCodigo,a.sConceptoPago,a.nValor,a.sEstadoRecibo,a.dFechaRecibo, a.nStbEstadoReciboID, a.login " & _
        ' " From vwSccReciboSocia a Where a.nSccSolicitudChequeID = " & XdsRecibo("Socia").ValueField("nSccSolicitudChequeID") & _
        ' " Order by a.nCodigo"

        'If XdsRecibo.ExistTable("Recibo") Then
        '    XdsRecibo("Recibo").ExecuteSql(Strsql)
        'Else
        '    XdsRecibo.NewTable(Strsql, "Recibo")
        '    XdsRecibo("Recibo").Retrieve()
        'End If

        ''If XdsRecibo.ExistRelation("SociaConRecibo") = False Then
        ''    'Creando la relaci�n entre el Primer Query y el Segundo
        ''    XdsRecibo.NewRelation("SociaConRecibo", "Socia", "Recibo", "nSccSolicitudChequeID", "nSccSolicitudChequeID")
        ''End If

        ''XdsRecibo.SincronizarRelaciones()
        ' ''XdsRecibo("Socia").FilterLocal("[sNombreGrupo] Like 'a*'")

        ' ''Asignando a las fuentes de datos
        ''Me.grdSocia.DataSource = XdsRecibo("Socia").Source
        ''Me.grdSocia.Rebind(True)

        'Me.grdRecibo.DataSource = XdsRecibo("Recibo").Source
        'Me.grdRecibo.Rebind(True)

        LlamaRefrescarRecibo()
        Me.tbRecibo.Enabled = True

        Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"
        'CalcularMontos()

    End Sub

    Private Sub grdRecibo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdRecibo.DoubleClick
        Try
            If Me.IdTipoRecibo = 2 Then 'Manual
                If Seg.HasPermission("ModificarRecibo") And Me.tbRecibo.Enabled = True Then
                    LlamaModificarRecibo(0)
                End If
            Else
                If Seg.HasPermission("ModificarReciboAutomatico") And Me.tbRecibo.Enabled = True Then
                    LlamaModificarReciboAutomatico(0)
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdRecibo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdRecibo.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdRecibo_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdRecibo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdRecibo.Filter
        Try
            XdsRecibo("Recibo").FilterLocal(e.Condition)
            Me.grdRecibo.Caption = " Listado de Recibos (" + Me.grdRecibo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Private Sub LlamaImprimirRecibo()
    '    Dim frmVisor As New frmCRVisorReporte
    '    Try
    '        frmVisor.WindowState = FormWindowState.Maximized
    '        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
    '        'frmVisor.Formulas("Parametro") = "Podria ser nScnTransaccionContableID "
    '        frmVisor.NombreReporte = "RepSccCC8.rpt"
    '        frmVisor.Text = "Recibo Oficial de Caja"
    '        If grdRecibo.RowCount > 0 Then
    '            frmVisor.SQLQuery = "Select * From vwSccReciboOficialCajaDetalle Where nSccReciboOficialCajaID = " & grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID") & " Order by nSccReciboOficialCajaID,nNumeroCuota "
    '            frmVisor.ShowDialog()
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        frmVisor = Nothing
    '    End Try
    'End Sub
    Private Sub LlamaImprimirConsultaRecibo()
        Dim ObjFrmFNC As New FrmSccParametrosRecibosPorNumero
        Try
            'If My.Application.OpenForms.Count > 2 Then
            '    Exit Sub
            'End If

            ObjFrmFNC.NomRep = 1
            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub
    Private Sub LlamaImprimirListadoRecibo()
        Dim ObjFrmFNC As New FrmSccParametrosListadoRecibos
        Try
            'If My.Application.OpenForms.Count > 2 Then
            '    Exit Sub
            'End If

            ObjFrmFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    'Private Sub mnuListadoDeRecibosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuListadoDeRecibosToolStripMenuItem.Click
    '    LlamaImprimirRecibo()
    'End Sub

    Private Sub mnuConsultaDeRecibosToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuConsultaDeRecibosToolStripMenuItem.Click
        LlamaImprimirConsultaRecibo()
    End Sub
    Private Sub mnuEstadoDeCuentaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuEstadoDeCuentaToolStripMenuItem.Click
        Try
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            LlamaImprimirEstadoCuenta()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaImprimirEstadoCuenta()
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Parametros("@FechaCorte") = Format(Now, "yyyy-MM-dd 00:00:00")
            frmVisor.Parametros("@FichaNotificacionDetalleId") = XdsRecibo("Socia").ValueField("nSclFichaNotificacionDetalleID")
            frmVisor.NombreReporte = "RepSccCC16.rpt"
            frmVisor.Text = "Estado de Cuenta"
            frmVisor.ShowDialog()
            'If grdRecibo.RowCount > 0 Then
            '    frmVisor.SQLQuery = "Select * From vwSccReciboOficialCajaDetalle Where nSccReciboOficialCajaID = " & grdRecibo.Item(grdRecibo.Row, "nSccReciboOficialCajaID") & " Order by nSccReciboOficialCajaID,nNumeroCuota "
            '    frmVisor.ShowDialog()
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub toolImprimirEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirEC.Click
        Dim ObjFrmSccParametroEC As New frmSccParametroEC
        Try
            Dim strSQL As String = ""
            '-- Imposible si no existen registros:
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ''-- Imposible si la FNC Se encuentra Rechazada:
            'If (XdtFicha.ValueField("sCodEstado") = 3) Then
            '    MsgBox("El Cr�dito se encuentra DENEGADO.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If

            ''-- Imposible si el Estado es En Proceso: 
            'If (XdtFicha.ValueField("sCodEstado") = 1) Then
            '    MsgBox("La Ficha de Notificaci�n se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If

            ObjFrmSccParametroEC.NomRep = 1
            ObjFrmSccParametroEC.intSclFormatoID = XdsRecibo("Socia").ValueField("nSclFichaNotificacionID")
            ObjFrmSccParametroEC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
            ObjFrmSccParametroEC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
            ObjFrmSccParametroEC.Close()
            ObjFrmSccParametroEC = Nothing
        End Try
    End Sub

  
  
    
   
    Private Sub toolAgregarM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregarM.Click

    End Sub

    Private Sub C1Sizer1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Sizer1.Click

    End Sub
End Class