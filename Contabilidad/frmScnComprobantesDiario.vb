' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                20/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnComprobantesDiario.vb
' Descripción:          Formulario muestra Comprobantes de Diario (CD-ddMMyyyy-Consecutivo): 
'                       1. CD: Comprobante de Diario 
'                              Se permite ADD, UPD, ANL.
'                              Llamado desde la opción Comprobantes de Diario 
'                       2. CR: Comprobante de Recuperación Créditos 
'                              ANTES: SOLO PARA CONSULTA.
'                              AHORA: SE PERMITE ACTUALIZAR LA DESCRIPCION Y
'                              CIERTAS CUENTAS DE LA JORNALIZACION. 
'                              Llamado desde la opción Comprobantes de Crédito 
'                       3. CC: Comprobante de Cierre Anual 
'                              SOLO PARA CONSULTA.
'                              Llamado desde la opción Comprobantes de Diario 
'                       4. CA: Comprobante de Ajuste de Recuperación de Crédito.
'                              Se permite ADD, UPD, ANL.
'                              Llamado desde la opción Comprobantes de Crédito. 
'-------------------------------------------------------------------------
Public Class frmScnComprobantesDiario
    '- Declaración de Variables 
    Dim XdsComprobante As BOSistema.Win.XDataSet
    Dim TipoCD As String
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer
    Dim StrCadena As String

    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    'CR: Credito (CR, CA[manual])
    'CD: Comprobantes (CD[manual], CC)
    Public Property sTipoCD() As String
        Get
            sTipoCD = TipoCD
        End Get
        Set(ByVal value As String)
            TipoCD = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       frmScnComprobantesDiario_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmScnComprobantesDiario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsComprobante.Close()
            XdsComprobante = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       frmScnComprobantesDiario_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnComprobantesDiario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'Me.cdeFechaD.Select()

            If sTipoCD = "CR" Then
                Me.Text = "Mantenimiento de Comprobantes de Crédito/Ajustes"
                'Asigna Tópico de Ayuda Dinamico:
                Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Recuperación y Ajustes")
            Else
                Me.Text = "Mantenimiento de Comprobantes de Diario/Cierres Anuales"
                'Asigna Tópico de Ayuda Dinamico:
                Me.HelpProvider.SetHelpKeyword(Me, "Comprobantes de Diario")
            End If
            InicializaVariables()

            StrCadena = " WHERE (a.nScnTransaccionContableID = 0) " 'Al cargar Grid en Blanco
            CargarComprobante(StrCadena)
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
    ' Fecha:                20/11/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros Delegación
            EncuentraParametros()

            XdsComprobante = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdComprobante.ClearFields()
            Me.grdDetalles.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       CargarComprobante
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarComprobante(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String

            'CD: Comprobante de Diario (CD-ddMMyyyy-Consecutivo).
            'CR: Comprobante de Recuperación Créditos. 
            'CC: Comprobante de Cierre Anual.
            'CA: Comprobante de Ajuste de Recuperación de Crédito
            'Maestro (Encabezado de Comprobantes de Diario):

            Strsql = " SELECT a.* " & _
                     " FROM  vwScnComprobantes as a " & sCadenaFiltro & _
                     " Order by a.sNumeroTransaccion, a.dFechaTransaccion"

            'CR: Credito (CR, CA[manual])
            'If sTipoCD = "CR" Then
            '    If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
            '        Strsql = " SELECT a.* " & _
            '                 " FROM  vwScnComprobantes a " & _
            '                 " WHERE ((a.CodTipoCD = 'CA') OR (a.CodTipoCD = 'CR')) " & _
            '                 " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '                 " Order by a.sNumeroTransaccion, a.dFechaTransaccion"
            '    Else 'Solo Filtra las Transacciones de su Delegación:
            '        Strsql = " SELECT a.* " & _
            '                 " FROM  vwScnComprobantes a " & _
            '                 " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And ((a.CodTipoCD = 'CA') OR (a.CodTipoCD = 'CR')) " & _
            '                 " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '                 " Order by a.sNumeroTransaccion, a.dFechaTransaccion"
            '    End If


            'Else 'CD: Comprobantes (CD[manual], CC)
            '    If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
            '        Strsql = " SELECT a.* " & _
            '                 " FROM  vwScnComprobantes a " & _
            '                 " WHERE ((a.CodTipoCD = 'CD') OR (a.CodTipoCD = 'CC')) " & _
            '                 " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '                 " Order by a.sNumeroTransaccion, a.dFechaTransaccion"
            '    Else 'Solo Filtra las Transacciones de su Delegación:
            '        Strsql = " SELECT a.* " & _
            '                 " FROM  vwScnComprobantes a " & _
            '                 " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") And ((a.CodTipoCD = 'CD') OR (a.CodTipoCD = 'CC')) " & _
            '                 " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '                 " Order by a.sNumeroTransaccion, a.dFechaTransaccion"
            '    End If
            'End If

            If XdsComprobante.ExistTable("Comprobante") Then
                XdsComprobante("Comprobante").ExecuteSql(Strsql)
            Else
                XdsComprobante.NewTable(Strsql, "Comprobante")
                XdsComprobante("Comprobante").Retrieve()
            End If

            'Detalle: Cuentas Contables del Comprobante:
            Strsql = " SELECT a.* " & _
                     " FROM vwScnComprobantesDetalles as a " & sCadenaFiltro & _
                     " Order by a.nDebito desc, a.sCodigoCuenta Option (Force Order)"
            'If sTipoCD = "CR" Then
            '    Strsql = " SELECT a.* " & _
            '             " FROM  vwScnComprobantesDetalles a " & _
            '             " WHERE ((a.CodTipoCD = 'CA') OR (a.CodTipoCD = 'CR')) " & _
            '             " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '             " Order by a.nDebito desc, a.sCodigoCuenta Option (Force Order)"
            'Else 'CD: Comprobantes (CD[manual], CC)
            '    Strsql = " SELECT a.* " & _
            '             " FROM  vwScnComprobantesDetalles a " & _
            '             " WHERE ((a.CodTipoCD = 'CD') OR (a.CodTipoCD = 'CC')) " & _
            '             " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '             " Order by a.nDebito desc, a.sCodigoCuenta Option (Force Order)"
            'End If

            If XdsComprobante.ExistTable("Cuentas") Then
                XdsComprobante("Cuentas").ExecuteSql(Strsql)
            Else
                XdsComprobante.NewTable(Strsql, "Cuentas")
                XdsComprobante("Cuentas").Retrieve()
            End If

            If XdsComprobante.ExistRelation("ComprobanteConCuentas") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsComprobante.NewRelation("ComprobanteConCuentas", "Comprobante", "Cuentas", "nScnTransaccionContableID", "nScnTransaccionContableID")
            End If

            XdsComprobante.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdComprobante.DataSource = XdsComprobante("Comprobante").Source
            Me.grdDetalles.DataSource = XdsComprobante("Cuentas").Source

            'Actualizando el caption de los GRIDS
            Me.grdComprobante.Caption = " Listado de Comprobantes de Diario (" + Me.grdComprobante.RowCount.ToString + " registros)"
            Me.grdDetalles.Caption = " Codificación Contable Comprobante de Diario (" + Me.grdDetalles.RowCount.ToString + " registros)"
            FormatoComprobante()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       FormatoComprobante
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Comprobantes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoComprobante()
        Try

            'Configuracion del Grid Comprobante:
            Me.grdComprobante.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("CodTipoCD").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("CodFuente").Visible = False
            'Codigo del Estado (1 = En Proceso), 2 = Mayorizada, 3 = Anulada:
            Me.grdComprobante.Splits(0).DisplayColumns("CodEstadoCD").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.grdComprobante.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            If sTipoCD = "CD" Then 'Comprobantes Manuales de Diario y Automaticos de Cierre Anual:
                Me.grdComprobante.Splits(0).DisplayColumns("sNumeroDeposito").Visible = False
                Me.grdComprobante.Splits(0).DisplayColumns("dFechaCierre").Visible = False
                Me.grdComprobante.Splits(0).DisplayColumns("nMontoDeposito").Visible = False
            End If

            Me.grdComprobante.Splits(0).DisplayColumns("EstadoCD").Width = 70
            Me.grdComprobante.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 110
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTransaccion").Width = 120
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTipoCambio").Width = 120
            Me.grdComprobante.Splits(0).DisplayColumns("Fuente").Width = 180
            Me.grdComprobante.Splits(0).DisplayColumns("Beneficiario").Width = 200
            Me.grdComprobante.Splits(0).DisplayColumns("sDescripcion").Width = 400
            Me.grdComprobante.Splits(0).DisplayColumns("sNumeroDeposito").Width = 100
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaCierre").Width = 100
            Me.grdComprobante.Splits(0).DisplayColumns("nMontoDeposito").Width = 120

            Me.grdComprobante.Columns("EstadoCD").Caption = "Estado"
            Me.grdComprobante.Columns("sNumeroTransaccion").Caption = "Número"
            Me.grdComprobante.Columns("dFechaTransaccion").Caption = "Fecha Comprobante"
            Me.grdComprobante.Columns("dFechaTipoCambio").Caption = "Fecha Tipo Cambio"
            Me.grdComprobante.Columns("Fuente").Caption = "Fuente de Financiamiento"
            Me.grdComprobante.Columns("Beneficiario").Caption = "Beneficiario / Proveedor"
            Me.grdComprobante.Columns("sDescripcion").Caption = "Descripción"
            Me.grdComprobante.Columns("sNumeroDeposito").Caption = "No. de Minuta"
            Me.grdComprobante.Columns("nMontoDeposito").Caption = "Monto Minuta C$"
            Me.grdComprobante.Columns("dFechaCierre").Caption = "Cierre Cartera"

            Me.grdComprobante.Splits(0).DisplayColumns("EstadoCD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaTipoCambio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("Beneficiario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("dFechaCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdComprobante.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdComprobante.Columns("nMontoDeposito").NumberFormat = "#,##0.00"

            'Configuracion del Grid Codificación Contable:
            Me.grdDetalles.Splits(0).DisplayColumns("nScnTransaccionContableDetalleID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nMontoC").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nMontoD").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("dFechaTransaccion").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("CodTipoCD").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("sNumeroTransaccion").Visible = False

            Me.grdDetalles.Splits(0).DisplayColumns("sCodigoCuenta").Width = 150
            Me.grdDetalles.Splits(0).DisplayColumns("sNombreCuenta").Width = 480
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").Width = 70
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").Width = 80

            Me.grdDetalles.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.grdDetalles.Columns("sNombreCuenta").Caption = "Nombre de la Cuenta"
            Me.grdDetalles.Columns("nDebito").Caption = "Débito"
            Me.grdDetalles.Columns("nDebeC").Caption = "Debe (C$)"
            Me.grdDetalles.Columns("nHaberC").Caption = "Haber (C$)"
            Me.grdDetalles.Columns("nDebeD").Caption = "Debe (US$)"
            Me.grdDetalles.Columns("nHaberD").Caption = "Haber (US$)"

            Me.grdDetalles.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Debito como checkbox y centrado:
            Me.grdDetalles.Columns("nDebito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Formato de campos Numericos:
            Me.grdDetalles.Columns("nDebeC").NumberFormat = "#,##0.00"
            Me.grdDetalles.Columns("nHaberC").NumberFormat = "#,##0.00"
            Me.grdDetalles.Columns("nDebeD").NumberFormat = "#,##0.00"
            Me.grdDetalles.Columns("nHaberD").NumberFormat = "#,##0.00"


            'Estilo para Totales en el Grid Detalles:
            Me.grdDetalles.ColumnFooters = True
            Me.grdDetalles.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            'Córdobas:
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeC").FooterStyle.ForeColor = Color.Blue
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberC").FooterStyle.ForeColor = Color.Blue
            'Dólares:
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nDebeD").FooterStyle.ForeColor = Color.Green
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDetalles.Splits(0).DisplayColumns("nHaberD").FooterStyle.ForeColor = Color.Green
            'Color:
            Me.grdDetalles.FooterStyle.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nDebeC").Style.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nHaberC").Style.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nDebeD").Style.BackColor = Color.WhiteSmoke
            Me.grdDetalles.Splits(0).DisplayColumns.Item("nHaberD").Style.BackColor = Color.WhiteSmoke
            'Calcular montos totales de crédito solicitado y aprobado para el GS:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Débito y Crédito de la Jornalización.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalDebeC As Double = 0
            Dim vTotalHaberC As Double = 0
            Dim vTotalDebeD As Double = 0
            Dim vTotalHaberD As Double = 0

            For index As Integer = 0 To Me.grdDetalles.RowCount - 1
                Me.grdDetalles.Row = index
                vTotalDebeC = vTotalDebeC + Me.grdDetalles.Columns("nDebeC").Value
                vTotalHaberC = vTotalHaberC + Me.grdDetalles.Columns("nHaberC").Value
                vTotalDebeD = vTotalDebeD + Me.grdDetalles.Columns("nDebeD").Value
                vTotalHaberD = vTotalHaberD + Me.grdDetalles.Columns("nHaberD").Value
            Next
            If Me.grdDetalles.RowCount > 0 Then
                Me.grdDetalles.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdDetalles.Columns("nDebeC").FooterText = Format(vTotalDebeC, "C$ #,##0.00")
            Me.grdDetalles.Columns("nHaberC").FooterText = Format(vTotalHaberC, "C$ #,##0.00")
            Me.grdDetalles.Columns("nDebeD").FooterText = Format(vTotalDebeD, "US$ #,##0.00")
            Me.grdDetalles.Columns("nHaberD").FooterText = Format(vTotalHaberD, "US$ #,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       tbComprobante_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbComprobante.
    '-------------------------------------------------------------------------
    Private Sub tbComprobante_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbComprobante.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscarComprobante()
            Case "toolAgregar"
                LlamaAgregarComprobante()
            Case "toolModificar"
                LlamaModificarComprobante()
            Case "toolAnular"
                LlamaAnularComprobante()
                'Case "toolRefrescar"
                '    'Fechas de Corte Validas:
                '    If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                '        MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                '        Exit Sub
                '    End If
                '    If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                '        MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                '        Exit Sub
                '    End If
                '    'Fecha de Corte no mayor a la de Inicio:
                '    If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                '        MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                '        Me.cdeFechaD.Focus()
                '        Exit Sub
                '    End If

                '    REM Máximo 6 días entre la fecha de inicio y corte: Solicitado por Melania 19/Enero/2009:
                '    If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                '        MsgBox("Imposible seleccionar cortes de fecha superiores a 6 días.", MsgBoxStyle.Information)
                '        Me.cdeFechaD.Focus()
                '        Exit Sub
                '    End If

                '    InicializaVariables()
                '    CargarComprobante()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolImprimirCDMinutas"
                LlamaImprimirCdPorMinutas()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       LlamaImprimirCdPorMinutas
    ' Descripción:          Este procedimiento permite Imprimir Listado
    '                       de Comprobantes Contabilizados para la Minuta
    'actual.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirCdPorMinutas()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el comprobante no tiene ID de Minuta:
            strSQL = "SELECT nScnTransaccionContableID FROM ScnTransaccionContable " & _
                     "WHERE (nSteMinutaDepositoID IS NULL) AND (nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("El Comprobante seleccionado no tiene Minuta" & Chr(13) & "de Depósito asociada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepScnCN27.rpt"
            frmVisor.Text = "Comprobantes de Diario Contabilzados por Minuta"
            frmVisor.SQLQuery = " Select * " & _
                                " From vwScnListadoComprobantesPorMinuta " & _
                                " Where nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & _
                                " Order By nSteMinutaDepositoID asc, dfechatransaccion asc"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Comprobante
    '                       actual (No llama a parámetros).
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Formulas("Parametro") = "Podria ser nScnTransaccionContableID "
            frmVisor.NombreReporte = "RepScnCN5.rpt"
            frmVisor.Text = "Comprobante de Diario"
            frmVisor.SQLQuery = "Select * From vwScnComprobantesDiario Where nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       tbCuenta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCuenta.
    '-------------------------------------------------------------------------
    Private Sub tbCuenta_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCuenta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarC"
                LlamaAgregarCodificacion()
            Case "toolModificarC"
                LlamaModificarCodificacion()
            Case "toolAyudaC"
                LlamaAyuda()
        End Select

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaAgregarComprobante
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditComprobante para Agregar un nuevo registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarComprobante()
        Dim ObjFrmScnEditComprobante As New frmScnEditComprobante
        Try

            ObjFrmScnEditComprobante.ModoFrm = "ADD"
            ObjFrmScnEditComprobante.sTipoCD = TipoCD
            ObjFrmScnEditComprobante.ShowDialog()

            'En la adición unicamente se carga el Comprobante recien ingresado:
            If ObjFrmScnEditComprobante.IdComprobante <> 0 Then
                StrCadena = "Where (a.nScnTransaccionContableID = " & ObjFrmScnEditComprobante.IdComprobante & ")"
                CargarComprobante(StrCadena)
                'Se ubica sobre el registro recien agregado:
                XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditComprobante.IdComprobante)
                Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditComprobante.Close()
            ObjFrmScnEditComprobante = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaAgregarCodificacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCodificacion para Agregar una Jornalizacion.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCodificacion()
        Dim ObjFrmScnEditCuentas As New frmScnEditCodificacion
        Try

            Dim Strsql As String
            'No existen Comprobantes registrados:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen Comprobantes grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Comprobantes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            If XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si ya se registro la Codificación:
            If Me.grdDetalles.RowCount > 0 Then
                MsgBox("Ya se ingreso la Codificación Contable.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es Comprobante de Cierre de Cartera:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR" Then
                MsgBox("Imposible Modificación manual de Comprobante" & Chr(13) & "de Cierre Diario de Cartera de Crédito.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es Comprobante de Cierre Anual:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CC" Then
                MsgBox("Imposible Modificación manual de Comprobante" & Chr(13) & "de Cierre Anual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmScnEditCuentas.ModoFrm = "ADD"
            ObjFrmScnEditCuentas.IdComprobante = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditCuentas.ShowDialog()

            'Si se ingreso el registro correctamente:
            If ObjFrmScnEditCuentas.IdComprobante <> 0 Then
                CargarComprobante(StrCadena)
                'Se ubica sobre el CD:
                XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditCuentas.IdComprobante)
                Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCuentas.Close()
            ObjFrmScnEditCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaModificarComprobante
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditComprobante para Modificar un CD existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarComprobante()
        Dim ObjFrmScnEditComprobante As New frmScnEditComprobante
        Try
            Dim Strsql As String
            ObjFrmScnEditComprobante.IntHabilito = 1

            'No existen registros:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Comprobantes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(Strsql)) Or (XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3") Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es Comprobante de Cierre Anual:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CC" Then
                MsgBox("Imposible Modificación manual de Comprobante" & Chr(13) & "de Cierre Anual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM HABILITAR DESPUES DE LAS CORRECCIONES DE CONTABILIDAD:
            'Imposible si es Comprobante de Ajuste/Cartera ya enviado a Hacienda:
            'If (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CA") Or (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR") Then
            '    Strsql = "SELECT * " & _
            '             "FROM [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
            '             "Where (nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & ") and (nEstadoProceso <> 9)"
            '    If RegistrosAsociados(Strsql) Then
            '        MsgBox("Comprobante ya ha sido Enviado a Hacienda.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            REM HABILITAR DESPUES DE LAS CORRECCIONES DE CONTABILIDAD:
            'Imposible si la Minuta asignada esta Enviada a MHCP:
            'If (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CA") Or (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR") Then
            '    Strsql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
            '             "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '             "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & ")"
            '    If RegistrosAsociados(Strsql) = True Then
            '        MsgBox("Imposible Modificar Comprobante." & Chr(13) & "La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
            '        Exit Sub
            '    End If
            'End If

            'Si es Comprobante de Cierre de Cartera: 
            'Solo Habilitar Descripción y Observaciones:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR" Then
                MsgBox("En Comprobantes de Cierre Diario de Cartera únicamente" & Chr(13) & "es posible modificar la Descripción y Observaciones.", MsgBoxStyle.Information)
                ObjFrmScnEditComprobante.IntHabilito = 2
                'Exit Sub
            End If

            ObjFrmScnEditComprobante.ModoFrm = "UPD"
            ObjFrmScnEditComprobante.IdComprobante = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditComprobante.IntCodifica = Me.grdDetalles.RowCount
            ObjFrmScnEditComprobante.dFecha = XdsComprobante("Comprobante").ValueField("dFechaTransaccion")
            ObjFrmScnEditComprobante.sTipoCD = TipoCD
            ObjFrmScnEditComprobante.ShowDialog()

            CargarComprobante(StrCadena)
            XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditComprobante.IdComprobante)
            Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditComprobante.Close()
            ObjFrmScnEditComprobante = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaModificarCodificacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCodificacion para Modificar una Jornalización.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCodificacion()
        Dim ObjFrmScnEditCuentas As New frmScnEditCodificacion
        Try

            Dim StrSql As String
            'No existen Cuentas registradas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Comprobantes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Comprobante esta Anulado:
            If XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If (RegistrosAsociados(StrSql)) Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si Codificación tiene Cuenta de Bancos con Conciliacion Activa:
            StrSql = "SELECT D.nScnTransaccionContableDetalleID " & _
                     "FROM  ScnTransaccionContableDetalle AS D INNER JOIN ScnCatalogoContable AS C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN  SteConciliacionTransacciones AS CT ON D.nScnTransaccionContableDetalleID = CT.nScnTransaccionContableDetalleID INNER JOIN SteConciliacionBancaria AS CB ON CT.nSteConciliacionBancariaID = CB.nSteConciliacionBancariaID INNER JOIN StbValorCatalogo ON CB.nStbEstadoConciliacionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (D.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.nSteCuentaBancariaID IS NOT NULL)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existe Conciliación Bancaria Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es Comprobante de Cierre de Cartera:
            'Info: BLOQUEADO TRAS LIBERAR CDs DE RECUPERACIONES DE CREDITO
            'If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR" Then
            '    MsgBox("Imposible Modificación manual de Comprobante" & Chr(13) & "de Cierre Diario de Cartera de Crédito.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Imposible si es Comprobante de Cierre Anual:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CC" Then
                MsgBox("Imposible Modificación manual de Comprobante" & Chr(13) & "de Cierre Anual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM HABILITAR DESPUES DE LAS CORRECCIONES DE CONTABILIDAD:
            'Imposible si es Comprobante de Ajuste ya enviado a Hacienda:
            'If (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CA") Or (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR") Then
            '    StrSql = "SELECT * " & _
            '             "FROM [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
            '             "Where (nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & ") and (nEstadoProceso <> 9)"
            '    If RegistrosAsociados(StrSql) Then
            '        MsgBox("Comprobante ya ha sido Enviado a Hacienda.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            REM HABILITAR DESPUES DE LAS CORRECCIONES DE CONTABILIDAD:
            'Imposible si la Minuta asignada esta Enviada a MHCP:
            'If (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CA") Or (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR") Then
            '    StrSql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
            '             "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '             "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & ")"
            '    If RegistrosAsociados(StrSql) = True Then
            '        MsgBox("Imposible Modificar Codificación del Comprobante." & Chr(13) & "La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
            '        Exit Sub
            '    End If
            'End If

            ObjFrmScnEditCuentas.ModoFrm = "UPD"
            ObjFrmScnEditCuentas.IdComprobante = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
            ObjFrmScnEditCuentas.ShowDialog()

            CargarComprobante(StrCadena)
            XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", ObjFrmScnEditCuentas.IdComprobante)
            Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCuentas.Close()
            ObjFrmScnEditCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaAnularComprobante
    ' Descripción:          Este procedimiento permite Anular un Comprobante.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularComprobante()


        Dim XcDatos As New BOSistema.Win.XComando
        Dim ComprobanteId As Long
        Try

            Dim Strsql As String
            Dim intPosicion As Integer

            'Imposible si no hay CD registrados:
            If Me.grdComprobante.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es de otra Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsComprobante("Comprobante").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Comprobantes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If


            'No existen Cuentas registradas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Comprobante esta Anulado:
            If XdsComprobante("Comprobante").ValueField("CodEstadoCD") = "3" Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT ScnTransaccionContable.nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (ScnTransaccionContable.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Comprobante se encuentra Anulado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si ya fue Enviado a Hacienda: '11
            If (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CA") Or (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR") Then
                Strsql = "SELECT * " & _
                         "FROM [SMCU0-WebService].dbo.WScEnvioEncabezado " & _
                         "Where (nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & ") and (nEstadoProceso <> 9)"
                If RegistrosAsociados(Strsql) Then
                    MsgBox("Comprobante ya ha sido Enviado a Hacienda.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Minuta asignada esta Enviada a MHCP:
            If (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CA") Or (XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR") Then
                Strsql = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                         "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & XdsComprobante("Comprobante").ValueField("nSteMinutaDepositoID") & ")"
                If RegistrosAsociados(Strsql) = True Then
                    MsgBox("Imposible Anular Comprobante." & Chr(13) & "La Minuta asociada no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If
            End If
            
            'Imposible si es Comprobante de Cierre de Cartera:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CR" Then
                MsgBox("Imposible Anulación manual de Comprobante" & Chr(13) & "de Cierre Diario de Cartera de Crédito. Debe" & Chr(13) & "Anular el Cierre de Cartera.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es Comprobante de Cierre Anual:
            If XdsComprobante("Comprobante").ValueField("CodTipoCD") = "CC" Then
                MsgBox("Imposible Anulación manual de Comprobante" & Chr(13) & "de Cierre Anual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(XdsComprobante("Comprobante").ValueField("dFechaTransaccion")) = False Then
                MsgBox("El mes se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si Codificación tiene Cuenta de Bancos con Conciliacion Activa:
            Strsql = "SELECT D.nScnTransaccionContableDetalleID " & _
                     "FROM  ScnTransaccionContableDetalle AS D INNER JOIN ScnCatalogoContable AS C ON D.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN  SteConciliacionTransacciones AS CT ON D.nScnTransaccionContableDetalleID = CT.nScnTransaccionContableDetalleID INNER JOIN SteConciliacionBancaria AS CB ON CT.nSteConciliacionBancariaID = CB.nSteConciliacionBancariaID INNER JOIN StbValorCatalogo ON CB.nStbEstadoConciliacionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (D.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3') AND (C.nSteCuentaBancariaID IS NOT NULL)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existe Conciliación Bancaria Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible Transacción existe en Tabla de Conciliación Bancaria:
            Strsql = "SELECT C.nSteConciliacionTransaccionID FROM ScnTransaccionContableDetalle AS D INNER JOIN SteConciliacionTransacciones AS C ON D.nScnTransaccionContableDetalleID = C.nScnTransaccionContableDetalleID WHERE (D.nScnTransaccionContableID = " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El Comprobante forma parte de una Conciliación Bancaria.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Anulacion:
            If MsgBox("¿Está seguro de Anular el Comprobante?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Anula Transaccion y revierte saldos contables:
            Strsql = "EXEC spScnAnularTransaccion " & XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID") & "," & InfoSistema.IDCuenta & ", 0"
            ComprobanteId = XcDatos.ExecuteScalar(Strsql)
            If ComprobanteId = 0 Then
                MsgBox("Comprobante NO pudo Anularse.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Comprobante Anulado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                'Almacena Pista de Auditoría:
                Call GuardarAuditoria(4, 24, "Anulación de Comprobante de Diario: " & XdsComprobante("Comprobante").ValueField("sNumeroTransaccion") & ".")
                'Guardar posición actual de la selección
                intPosicion = XdsComprobante("Comprobante").ValueField("nScnTransaccionContableID")
                CargarComprobante(StrCadena)
                'Ubicar la selección en la posición original
                XdsComprobante("Comprobante").SetCurrentByID("nScnTransaccionContableID", intPosicion)
                Me.grdComprobante.Row = XdsComprobante("Comprobante").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite Salir de la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
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
    ' Fecha:                20/11/2007
    ' Procedure Name:       grdComprobante_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un GS existente, al hacer doble click en
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdComprobante_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdComprobante.DoubleClick
        Try
            If sTipoCD = "CR" Then 'Comprobantes de Recuperaciones y Ajustes de Crésito
                If Seg.HasPermission("ModificarComprobanteCC") Then
                    LlamaModificarComprobante()
                End If
            Else
                If Seg.HasPermission("ModificarComprobante") Then
                    LlamaModificarComprobante()
                End If
            End If
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdComprobante_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdComprobante.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       grdComprobante_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdComprobante_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdComprobante.Filter
        Try
            XdsComprobante("Comprobante").FilterLocal(e.Condition)
            Me.grdComprobante.Caption = " Listado de Comprobantes de Diario (" + Me.grdComprobante.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            '-- Acciones comúnes para cualquier tipo de comprobante:
            'Buscar Comprobantes 
            If Seg.HasPermission("BuscarComprobantes") = False Then
                Me.tbComprobante.Items("toolBuscar").Enabled = False
            Else  'Habilita
                Me.tbComprobante.Items("toolBuscar").Enabled = True
            End If
            'Imprimir Listado de Comprobantes Contabilizados Por Minuta
            If Seg.HasPermission("ImprimirComprobantesPorMinutaCN27") = False Then
                Me.tbComprobante.Items("toolImprimirCDMinutas").Enabled = False
            Else  'Habilita
                Me.tbComprobante.Items("toolImprimirCDMinutas").Enabled = True
            End If


            If sTipoCD = "CR" Then 'Comprobantes de Recuperaciones y Ajustes de Crésito
                'Agregar Comprobante:
                If Seg.HasPermission("AgregarComprobanteCC") = False Then
                    Me.tbComprobante.Items("toolAgregar").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolAgregar").Enabled = True
                End If
                'Editar Comprobante:
                If Seg.HasPermission("ModificarComprobanteCC") = False Then
                    Me.tbComprobante.Items("toolModificar").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolModificar").Enabled = True
                End If
                'Anular Comprobante:
                If Seg.HasPermission("AnularComprobanteCC") = False Then
                    Me.tbComprobante.Items("toolAnular").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolAnular").Enabled = True
                End If
                'Imprimir Comprobante:
                If Seg.HasPermission("ImprimirComprobanteCC") = False Then
                    Me.tbComprobante.Items("toolImprimir").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolImprimir").Enabled = True
                End If
                '-- *****************************************************
                'Agregar Cuentas:
                If Seg.HasPermission("AgregarCuentasComprobanteCC") = False Then
                    Me.tbCuenta.Items("toolAgregarC").Enabled = False
                Else  'Habilita
                    Me.tbCuenta.Items("toolAgregarC").Enabled = True
                End If
                'Editar Cuentas:
                If Seg.HasPermission("ModificarCuentasComprobanteCC") = False Then
                    Me.tbCuenta.Items("toolModificarC").Enabled = False
                Else  'Habilita
                    Me.tbCuenta.Items("toolModificarC").Enabled = True
                End If


            Else
                'Agregar Comprobante:
                If Seg.HasPermission("AgregarComprobante") = False Then
                    Me.tbComprobante.Items("toolAgregar").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolAgregar").Enabled = True
                End If
                'Editar Comprobante:
                If Seg.HasPermission("ModificarComprobante") = False Then
                    Me.tbComprobante.Items("toolModificar").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolModificar").Enabled = True
                End If
                'Anular Comprobante:
                If Seg.HasPermission("AnularComprobante") = False Then
                    Me.tbComprobante.Items("toolAnular").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolAnular").Enabled = True
                End If
                'Imprimir Comprobante:
                If Seg.HasPermission("ImprimirComprobante") = False Then
                    Me.tbComprobante.Items("toolImprimir").Enabled = False
                Else  'Habilita
                    Me.tbComprobante.Items("toolImprimir").Enabled = True
                End If
                '-- *****************************************************
                'Agregar Cuentas:
                If Seg.HasPermission("AgregarCuentasComprobante") = False Then
                    Me.tbCuenta.Items("toolAgregarC").Enabled = False
                Else  'Habilita
                    Me.tbCuenta.Items("toolAgregarC").Enabled = True
                End If
                'Editar Cuentas:
                If Seg.HasPermission("ModificarCuentasComprobante") = False Then
                    Me.tbCuenta.Items("toolModificarC").Enabled = False
                Else  'Habilita
                    Me.tbCuenta.Items("toolModificarC").Enabled = True
                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       grdComprobante_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Cuentas con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdComprobante_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdComprobante.RowColChange
        Me.grdDetalles.Caption = " Codificación Contable Comprobante de Diario (" + Me.grdDetalles.RowCount.ToString + " registros)"
        CalcularMontos()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       grdSocias_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Codificación Contable, al hacer doble 
    '                       click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalles.DoubleClick
        Try

            If sTipoCD = "CR" Then 'Comprobantes de Recuperaciones y Ajustes de Crésito
                If Seg.HasPermission("ModificarCuentasComprobanteCC") Then
                    LlamaModificarCodificacion()
                End If
            Else
                If Seg.HasPermission("ModificarCuentasComprobante") Then
                    LlamaModificarCodificacion()
                End If
            End If
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdDetalles_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDetalles.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2007
    ' Procedure Name:       grdDetalles_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalles.Filter
        Try
            XdsComprobante("Cuentas").FilterLocal(e.Condition)
            Me.grdDetalles.Caption = " Codificación Contable Comprobante de Diario (" + Me.grdDetalles.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       LlamaBuscarComprobante
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnBusquedaComprobantes para buscar CDs con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarComprobante()
        Dim ObjFrmScnBusquedaCD As New frmScnBusquedaComprobantes
        Try

            ObjFrmScnBusquedaCD.StrCriterioCD = "0" 'Sin Criterio de Busqueda
            ObjFrmScnBusquedaCD.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmScnBusquedaCD.StrTipoCD = sTipoCD
            ObjFrmScnBusquedaCD.ShowDialog()
            If ObjFrmScnBusquedaCD.StrCriterioCD <> "0" Then
                StrCadena = ObjFrmScnBusquedaCD.StrCriterioCD
                CargarComprobante(StrCadena)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnBusquedaCD.Close()
            ObjFrmScnBusquedaCD = Nothing
        End Try
    End Sub

    Private Sub toolAgregarC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregarC.Click

    End Sub
End Class