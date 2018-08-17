Public Class FrmSccNotaDebitoCredito
    '- Declaración de Variables 
    Dim nTipoBusqueda As Integer
    Dim XdsSolicitudCheque As BOSistema.Win.XDataSet
    Dim ModoAcc As String
    Dim sColor As String
    Dim StrCadena As String
    Dim StrCadena2 As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    'Color a mostrarse en el formulario
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property
    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    'ELA: Elaborar
    'REV: Revisar
    'AUT: Autorizar
    Public Property ModoAccion() As String
        Get
            ModoAccion = ModoAcc
        End Get
        Set(ByVal value As String)
            ModoAcc = value
        End Set
    End Property


    Private Sub FrmSccNotaDebitoCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsSolicitudCheque.Close()
            XdsSolicitudCheque = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSccNotaDebitoCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            'If ModoAcc = "ELA" Then
            '    Me.HelpProvider.SetHelpKeyword(Me, "Registrar Solicitudes de Cheque")
            'ElseIf ModoAcc = "REV" Then
            '    Me.HelpProvider.SetHelpKeyword(Me, "Revisión de Solicitudes de Cheque")
            'Else
            '    Me.HelpProvider.SetHelpKeyword(Me, "Autorización Solicitudes de Cheque")
            'End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaD.Value = FechaServer()
            'cdeFechaH.Value = cdeFechaD.Value

            InicializaVariables()
            StrCadena = " WHERE (a.nSccNotaID = 0) " 'Al cargar Grid en Blanco
            StrCadena2 = " WHERE (a.nSccNotaID = 0) " 'Al cargar Grid en Blanco
            CargarSolicitudCheque(StrCadena, 0, StrCadena2)
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
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

    Private Sub InicializaVariables()
        Try
            XdsSolicitudCheque = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los Grids, estructura y Datos:
            Me.grdDetalleFichas.ClearFields()
            Me.grdDetallesCuentas.ClearFields()

            'Determinar Parámetros de la Delegación del Usuario:
            EncuentraParametros()

            'Según usuario que accesa:
            'If ModoAcc = "ELA" Then
            '    Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Enviar Solicitud a Contabilidad"
            '    Me.Text = "Registro de Solicitudes de Cheque"
            'ElseIf ModoAcc = "REV" Then
            '    Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Revisar Solicitud"
            '    Me.Text = "Revisión de Solicitudes de Cheque"
            'Else
            '    Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Autorizar Solicitudes Revisadas por Contabilidad"
            '    Me.Text = "Autorización de Solicitudes de Cheque"
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CargarSolicitudCheque(ByVal sCadenaFiltro As String, ByVal IntBit As Integer, ByVal sCadenaFiltro2 As String)
        Try
            Dim Strsql As String

            'Limpiar los Grids, estructura y Datos:
            Me.grdDetalleFichas.ClearFields()
            Me.grdDetallesCuentas.ClearFields()
            Me.grdNotas.ClearFields()


            'Maestro (Solicitudes de Cheques):
            'Strsql = " SELECT CAST(" & IntBit & " as bit) as Selected ,a.*" & _
            '         " FROM  vwSccNotaCreditoDebito as a " & sCadenaFiltro2 & _
            '         " Order by nSccNotaID  " 'Option (Force Order)"
            If nTipoBusqueda = 1 Then
                Strsql = " SELECT CAST(" & IntBit & " as bit) as Selected ,a.*" & _
                         " FROM  vwSccNotaCreditoDebito as a INNER JOIN    " & _
                         "(SELECT     a.nSccNotaID  FROM          dbo.vwSccNotaCreditoDebitoDetallesFichas as a " & sCadenaFiltro & _
                         "GROUP BY a.nSccNotaID) AS Fichas ON a.nSccNotaID = Fichas.nSccNotaID  " & _
                         " Order by nSccNotaID  " 'Option (Force Order)"
            Else
                Strsql = " SELECT CAST(" & IntBit & " as bit) as Selected ,a.*" & _
                         " FROM  vwSccNotaCreditoDebito as a " & sCadenaFiltro & _
                         " Order by nSccNotaID  " 'Option (Force Order)"

            End If


            'If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
            '    'Strsql = "EXEC SpSccGridSolicitudCheque 1, 0, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
            '    Strsql = " SELECT * " & _
            '             " FROM vwSccSolicitudCheque " & _
            '             " WHERE (dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '             " Order by nSccSolicitudChequeID Option (Force Order)"
            'Else 'Solo Filtra las Solicitudes de Cheque de su Delegación:
            '    'Strsql = "EXEC SpSccGridSolicitudCheque 1, " & InfoSistema.IDDelegacion & ", '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
            '    Strsql = " SELECT * " & _
            '             " FROM vwSccSolicitudCheque " & _
            '             " WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '             " Order by nSccSolicitudChequeID Option (Force Order)"
            'End If

            If XdsSolicitudCheque.ExistTable("Solicitud") Then
                XdsSolicitudCheque("Solicitud").ExecuteSql(Strsql)
            Else
                XdsSolicitudCheque.NewTable(Strsql, "Solicitud")
                XdsSolicitudCheque("Solicitud").Retrieve()
            End If

            'Detalle: Fichas
            Strsql = " SELECT a.* " & _
                     " FROM vwSccNotaCreditoDebitoDetallesFichas  as a " & sCadenaFiltro & " Order By CodGrupo,Socia"



            If XdsSolicitudCheque.ExistTable("Fichas") Then
                XdsSolicitudCheque("Fichas").ExecuteSql(Strsql)
            Else
                XdsSolicitudCheque.NewTable(Strsql, "Fichas")
                XdsSolicitudCheque("Fichas").Retrieve()
            End If
            If XdsSolicitudCheque.ExistRelation("SolicitudConDetallesFichas") = False Then
                'Creando la relación entre el Primer Query y el Segundo:
                XdsSolicitudCheque.NewRelation("SolicitudConDetallesFichas", "Solicitud", "Fichas", "nSccNotaID", "nSccNotaID")
            End If
            XdsSolicitudCheque.SincronizarRelaciones()
            'Detalle: Jornalización de Cuentas de la Solicitud:

            'Strsql = " SELECT CAST(" & IntBit & " as bit) as Selected ,a.*" & _
            '         " FROM  vwSccNotaCreditoDebito as a INNER JOIN    " & _
            '         "(SELECT     nSccNotaID  FROM          dbo.vwSccNotaCreditoDebitoDetallesFichas " & sCadenaFiltro & _
            '         " GROUP BY nSccNotaID) AS Fichas ON dbo.SccNotaCreditoDebito.nSccNotaID = Fichas.nSccNotaID  " & _
            '         " Order by nSccNotaID  " 'Option (Force Order)"
            If Me.nTipoBusqueda = 1 Then
                Strsql = " SELECT a.* " & _
                         " FROM vwSccNotaCreditoDebitoDetallesCuentas as a Inner Join " & _
                         "(SELECT     nSccNotaID  FROM          dbo.vwSccNotaCreditoDebitoDetallesFichas as a " & sCadenaFiltro & _
                         " GROUP BY nSccNotaID) AS Fichas ON a.nSccNotaID = Fichas.nSccNotaID  "
            Else
                Strsql = " SELECT a.* " & _
                         " FROM vwSccNotaCreditoDebitoDetallesCuentas as a " & sCadenaFiltro & _
                         " Order by nDebito desc, sCodigoCuenta "  'Option (Force Order)"

            End If
            'Strsql = " SELECT a.* " & _
            '         " FROM vwSccNotaCreditoDebitoDetallesCuentas as a " & sCadenaFiltro2 & _
            '         " Order by nDebito desc, sCodigoCuenta "  'Option (Force Order)"
            ''Strsql = "EXEC SpSccGridSolicitudCheque 0, 0, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "'"
            'Strsql = " SELECT * " & _
            '         " FROM vwSccSolicitudChequeDetalles " & _
            '         " WHERE (dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '         " Order by nDebito desc, sCodigoCuenta Option (Force Order)"
            If XdsSolicitudCheque.ExistTable("Cuentas") Then
                XdsSolicitudCheque("Cuentas").ExecuteSql(Strsql)
            Else
                XdsSolicitudCheque.NewTable(Strsql, "Cuentas")
                XdsSolicitudCheque("Cuentas").Retrieve()
            End If

            If XdsSolicitudCheque.ExistRelation("SolicitudConDetallesCuentas") = False Then
                'Creando la relación entre el Primer Query y el Segundo:
                XdsSolicitudCheque.NewRelation("SolicitudConDetallesCuentas", "Solicitud", "Cuentas", "nSccNotaID", "nSccNotaID")
            End If
            XdsSolicitudCheque.SincronizarRelaciones()
            'Asignando a las fuentes de datos:
            Me.grdNotas.DataSource = XdsSolicitudCheque("Solicitud").Source
            REM REBIND
            Me.grdNotas.Rebind(False)
            'Asignando a las fuentes de datos:
            Me.grdDetalleFichas.DataSource = XdsSolicitudCheque("Fichas").Source
            REM REBIND
            Me.grdDetalleFichas.Rebind(False)

            Me.grdDetallesCuentas.DataSource = XdsSolicitudCheque("Cuentas").Source
            REM REBIND
            Me.grdDetallesCuentas.Rebind(False)

            ''Actualizando el caption de los GRIDS:
            'Me.grdNotas.Caption = " Listado  de Notas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"
            'Me.grdDetallesCuentas.Caption = " Detalles de Notas Cuentas Contables (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            'Me.grdDetalleFichas.Caption = " Detalles de Notas Fichas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"

            Me.grdDetallesCuentas.Caption = " Detalles de Notas Cuentas Contables (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            Me.grdDetalleFichas.Caption = " Listado de Fichas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"

            Me.grdNotas.Caption = " Listado  de Notas (" + Me.grdNotas.RowCount.ToString + " registros)"
            FormatoSolicitudCheque()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoSolicitudCheque()
        Try
            Dim ContadorColumna As Integer

            'Configuracion del maestro de Notas

            'Me.grdNotas.Splits(0).DisplayColumns("nSccNotaID").Visible = False
            Me.grdNotas.Splits(0).DisplayColumns("nstbDelegacionProgramaId").Visible = False
            Me.grdNotas.Splits(0).DisplayColumns("nScnFuenteFinanciamientoId").Visible = False

            Me.grdNotas.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
            Me.grdNotas.Splits(0).DisplayColumns("dFechaTipoCambio").Visible = False
            Me.grdNotas.Splits(0).DisplayColumns("nAnio").Visible = False

            Me.grdNotas.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.grdNotas.Splits(0).DisplayColumns("nMonto").Width = 80
            Me.grdNotas.Splits(0).DisplayColumns("dFechaNota").Width = 100
            Me.grdNotas.Splits(0).DisplayColumns("dFechaTipoCambio").Width = 100
            Me.grdNotas.Splits(0).DisplayColumns("sDescripcion").Width = 100
            Me.grdNotas.Splits(0).DisplayColumns("sConceptoNota").Width = 200
            Me.grdNotas.Splits(0).DisplayColumns("sNombreFuente").Width = 200
            Me.grdNotas.Splits(0).DisplayColumns("sNombreDelegacion").Width = 200

            Me.grdNotas.Columns("nSccNotaID").Caption = "Nota ID."

            Me.grdNotas.Columns("nCodigo").Caption = "Codigo."
            Me.grdNotas.Columns("dFechaNota").Caption = "Fecha Nota"
            Me.grdNotas.Columns("dFechaTipoCambio").Caption = "Fecha de Cambio"
            Me.grdNotas.Columns("nMonto").Caption = "Monto C$"
            Me.grdNotas.Columns("sDescripcion").Caption = "Estado"
            Me.grdNotas.Columns("sNombreFuente").Caption = "Fuente"
            Me.grdNotas.Columns("sNombreDelegacion").Caption = "Delegacion"
            Me.grdNotas.Columns("sConceptoNota").Caption = "Concepto"


            Me.grdNotas.Columns("nMonto").NumberFormat = "#,##0.00"
            Me.grdNotas.Splits(0).DisplayColumns("Selected").Width = 80

            'Configuracion del Grid Notas de Debitos Creditos:
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nMonto").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nAnio").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nSccNotaDetalleFichaId").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("dFechaPago").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("dFechaNota").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sDescripcion").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sConceptoNota").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("CodGrupo").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("dFechaTipoCambio").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nSccNotaID").Visible = False
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nCodigo").Visible = False
            ' Me.grdDetalleFichas.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Width = 80
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nMontoFicha").Width = 80
            Me.grdDetalleFichas.Splits(0).DisplayColumns("Socia").Width = 120


            Me.grdDetalleFichas.Splits(0).DisplayColumns("NombreGrupo").Width = 120
            Me.grdDetalleFichas.Splits(0).DisplayColumns("Socia").Width = 200
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sNumeroCedula").Width = 110
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nCodigoFNC").Width = 80
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sNumSesion").Width = 80
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sDescripcion").Width = 80




            For ContadorColumna = 0 To Me.grdNotas.Splits(0).DisplayColumns.Count - 1
                Me.grdNotas.Splits(0).DisplayColumns(ContadorColumna).Locked = True
            Next

            Me.grdNotas.Splits(0).DisplayColumns("Selected").Locked = False




            Me.grdDetalleFichas.Columns("nSccNotaID").Caption = "Nota ID"
            Me.grdDetalleFichas.Columns("nSclFichaNotificacionDetalleID").Caption = "Ficha ID"
            Me.grdDetalleFichas.Columns("nMontoFicha").Caption = "Monto C$"
            Me.grdDetalleFichas.Columns("Socia").Caption = "Socia"
            Me.grdDetalleFichas.Columns("nCodigoFNC").Caption = "Codigo FNC"
            Me.grdDetalleFichas.Columns("sNumeroCedula").Caption = "Número de Cédula"
            Me.grdDetalleFichas.Columns("sNumSesion").Caption = "No. Acta"
            Me.grdDetalleFichas.Columns("nCodigo").Caption = "No. Nota"
            Me.grdDetalleFichas.Columns("sDescripcion").Caption = "Estado"
            Me.grdDetalleFichas.Columns("NombreGrupo").Caption = "Nombre del Grupo"

            Me.grdNotas.Columns("Selected").Caption = "Seleccionado"

            'Me.grdDetalleFichas.Columns("dFechaNota").Caption = "Fecha Nota"

            Me.grdDetalleFichas.Splits(0).DisplayColumns("nCodigoFNC").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sNumSesion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            Me.grdDetalleFichas.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleFichas.Splits(0).DisplayColumns("sNumSesion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nCodigoFNC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleFichas.Splits(0).DisplayColumns("NombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalleFichas.Splits(0).DisplayColumns("nMontoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDetalleFichas.Columns("nMontoFicha").NumberFormat = "#,##0.00"
            ' Me.grdDetalleFichas.Splits(0).DisplayColumns("Selected").Width = 80


            'Configuracion del Grid Detalles : 

            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nCodigo").Visible = False
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("dFechaNota").Visible = False
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nSccNotaID").Visible = False
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nSccNotaDetalleId").Visible = False

            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("Socia").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("CodGrupo").Visible = False
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("NombreGrupo").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("nCodigoFNC").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("nCodigo").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("sNumeroCedula").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("sNumSesion").Visible = False
            'Me.grdDetallesCuentas.Splits(0).DisplayColumns("dFechaNota").Visible = False

            Me.grdDetallesCuentas.Splits(0).DisplayColumns("sCodigoCuenta").Width = 200
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("sNombreCuenta").Width = 480
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nDebito").Width = 80
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nMonto").Width = 110

            Me.grdDetallesCuentas.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.grdDetallesCuentas.Columns("sNombreCuenta").Caption = "Nombre Cuenta Contable"
            Me.grdDetallesCuentas.Columns("nDebito").Caption = "Débito"
            Me.grdDetallesCuentas.Columns("nMonto").Caption = "Monto (C$)"

            Me.grdDetallesCuentas.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nDebito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nMonto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Debito como checkbox y centrado:
            Me.grdDetallesCuentas.Columns("nDebito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDetallesCuentas.Splits(0).DisplayColumns("nDebito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetallesCuentas.Columns("nMonto").NumberFormat = "#,##0.00"
            CalcularMontos()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbSolicitud_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSolicitud.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolCheck"
                LlamaCheck(1)
            Case "toolUnchek"
                LlamaCheck(0)

            Case "toolBuscar"
                LlamaBuscar()
            Case "toolAgregar"
                LlamaAgregar()
            Case "toolModificar"
                LlamaModificar()
            Case "toolAnular"
                LlamaAnular()
            Case "toolRevisar"
                LlamaRevisar()
            Case "toolGenerar"
                LlamaGenerar()
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
                '    CargarSolicitudCheque()
            Case "toolGenerarChecked"
                LlamaGenerarChecked()
            Case "toolAutorizar"
                LlamaAutorizar()
            Case "ToolAutorizarChecked"
                LlamaAutorizarChecked()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolImprimirC"
                LlamaImprimirC()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaImprimirC()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
            Dim StrSql, StrPath As String
            Dim StrCodigoIngresa, StrCodigoContador, StrCodigoDirectora As String
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No Existen notas grabadas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT     nSccNotaID, sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(StrSql)
            If XcDatos.ValueField("sCodigoInterno") <> "3" And XcDatos.ValueField("sCodigoInterno") <> "4" And XcDatos.ValueField("sCodigoInterno") <> "5" Then

                MsgBox("Solo se puede imprimir en Autorizado, Generado Comprobante o Anulado.", MsgBoxStyle.Information)
                Exit Sub

            End If


            frmVisor.CRVReportes.SelectionFormula = " {VwSccNotaDebitoCuentasReporte.nSccNotaID}=" & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSccCC74.rpt"
            StrPath = ""

            StrPath = StrPathFirmaDigital()

            StrCodigoIngresa = ""
            StrCodigoContador = ""
            StrCodigoDirectora = ""
            StrSql = "SELECT     CodEmpDirectora, CodEmpIngresa, CodEmpContador             FROM dbo.vwSccNotaDebitoCuentasReporte  WHERE(nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            XcDatos.ExecuteSql(StrSql)
            If XcDatos.Count > 0 Then

                StrCodigoIngresa = XcDatos.ValueField("CodEmpIngresa")
                StrCodigoContador = XcDatos.ValueField("CodEmpContador")
                StrCodigoDirectora = XcDatos.ValueField("CodEmpDirectora")
                frmVisor.Formulas("DirFirmaElaborado") = "'" & StrPath & "F" & StrCodigoIngresa & ".jpg'"
                frmVisor.Formulas("DirFirmaRevisado") = "'" & StrPath & "F" & StrCodigoContador & ".jpg'"
                frmVisor.Formulas("DirFirmaAutorizado") = "'" & StrPath & "F" & StrCodigoDirectora & ".jpg'"

            End If
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub LlamaAutorizar()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XcComando As New BOSistema.Win.XComando

        Try

            Dim intPosicion As Integer

            'Imposible si no existen Solicitudes:
            'If Me.grdNotas.RowCount = 0 Then
            '    MsgBox("No existen Notas  registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If


            'Strsql = "SELECT     nSccNotaID, sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            'XcDatos.ExecuteSql(Strsql)
            'If XcDatos.ValueField("sCodigoInterno") = "5" Then
            '    MsgBox("La Nota se encuentra Anulada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'If XcDatos.ValueField("sCodigoInterno") = "4" Then
            '    MsgBox("La Nota ya tiene generada partida contable.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'If XcDatos.ValueField("sCodigoInterno") = "3" Then
            '    MsgBox("La Nota se encuentra Autorizada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'If XcDatos.ValueField("sCodigoInterno") = "1" Then
            '    MsgBox("La Nota se encuentra en Proceso no Revisada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If




            'Debe tener al menos un detalla de ficha
            Strsql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(Strsql)
            If XcDatos.Count < 1 Then
                MsgBox("La Nota no tiene los detalles de las fichas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ''Debe tener las cuentas contables asociadas
            'Strsql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesCuentas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            'XcDatos.ExecuteSql(Strsql)
            'If XcDatos.Count < 2 Then
            '    MsgBox("La Nota no tiene los detalles de las cuentas contables.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Confirmar Revision:
            If MsgBox("¿Está seguro de Dar por Autorizado la Nota  No." & Trim(XdsSolicitudCheque("Solicitud").ValueField("nCodigo")) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            ''Anula la Nota Actual:
            Strsql = " Update SccNotaCreditoDebito " & _
                     " SET nUsuarioAutoriza='" & InfoSistema.IDCuenta & "',dFechaAutoriza = getdate(), nStbEstadoNotaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoNotaDebitoCredito')" & _
                     " WHERE nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            XcComando.ExecuteNonQuery(Strsql)

            MsgBox("Nota dada por Autorizada Exitosamente.", MsgBoxStyle.Information, NombreSistema)

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Autorizacion de Nota: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")

            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            CargarSolicitudCheque(StrCadena, 0, StrCadena2)

            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
            Me.grdNotas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaRevisar()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XcComando As New BOSistema.Win.XComando

        Try

            Dim intPosicion As Integer

            'Imposible si no existen Solicitudes:
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No existen Notas  registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If


            Strsql = "SELECT     nSccNotaID,  sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(Strsql)
            If XcDatos.ValueField("sCodigoInterno") = "5" Then
                MsgBox("La Nota se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XcDatos.ValueField("sCodigoInterno") = "4" Then
                MsgBox("La Nota ya tiene generada partida contable.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XcDatos.ValueField("sCodigoInterno") = "3" Then
                MsgBox("La Nota se encuentra Autorizada", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XcDatos.ValueField("sCodigoInterno") = "2" Then
                MsgBox("La Nota ya se encuentra Revisada", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Debe tener al menos un detalla de ficha
            Strsql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(Strsql)
            If XcDatos.Count < 1 Then
                MsgBox("La Nota no tiene los detalles de las fichas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Debe tener las cuentas contables asociadas
            'Strsql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesCuentas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            'XcDatos.ExecuteSql(Strsql)
            'If XcDatos.Count < 2 Then
            '    MsgBox("La Nota no tiene los detalles de las cuentas contables.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Confirmar Revision:
            If MsgBox("¿Está seguro de Dar por Revisado la Nota  No." & Trim(XdsSolicitudCheque("Solicitud").ValueField("nCodigo")) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            ''Anula la Nota Actual:
            Strsql = " Update SccNotaCreditoDebito " & _
                     " SET nUsuarioRevisa='" & InfoSistema.IDCuenta & "',dFechaRevisa=getdate(), nStbEstadoNotaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoNotaDebitoCredito')" & _
                     " WHERE nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            XcComando.ExecuteNonQuery(Strsql)

            MsgBox("Nota dada por Revisada Exitosamente.", MsgBoxStyle.Information, NombreSistema)

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Revision de Nota: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")

            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            CargarSolicitudCheque(StrCadena, 0, StrCadena2)

            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
            Me.grdNotas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaGenerar()
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim intPeriodoId As Integer


            Dim StrSql As String

            'Imposible si no existen Registros:
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            StrSql = "SELECT     nSccNotaID, sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(StrSql)
            If XcDatos.ValueField("sCodigoInterno") = "5" Then
                MsgBox("La Nota se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XcDatos.ValueField("sCodigoInterno") = "4" Then
                MsgBox("La Nota ya tiene generada partida contable.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XcDatos.ValueField("sCodigoInterno") = "2" Then
                MsgBox("La Nota se encuentra Revisada no Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If XcDatos.ValueField("sCodigoInterno") = "1" Then
                MsgBox("La Nota se encuentra en Proceso no Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If



            'Debe tener al menos un detalla de ficha
            StrSql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesFichas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(StrSql)
            If XcDatos.Count < 1 Then
                MsgBox("La Nota no tiene los detalles de las fichas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Debe tener las cuentas contables asociadas
            StrSql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesCuentas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(StrSql)
            If XcDatos.Count < 2 Then
                MsgBox("La Nota no tiene los detalles de las cuentas contables.", MsgBoxStyle.Information)
                Exit Sub
            End If





            '-- Imposible si no existe Periodo registrado para la Fecha de la Solicitud de Cheque:
            intPeriodoId = IDPeriodo(XdsSolicitudCheque("Solicitud").ValueField("dFechaNota"))
            If intPeriodoId = 0 Then
                MsgBox("No existe un período Contable creado para" & Chr(13) & "la fecha de la Nota.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si el Periodo se encuentra Cerrado:
            If PeriodoAbierto(intPeriodoId) = False Then
                MsgBox("El período Contable correspondiente a la fecha de la" & Chr(13) & "Nota se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If


            If MsgBox("¿Está seguro de Generar el Comprobante de la Nota No." & Trim(XdsSolicitudCheque("Solicitud").ValueField("nCodigo")) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- Poner el cursor en estado ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            InsertarNota(XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID"), TipoNota(XdsSolicitudCheque("Solicitud").ValueField("nMonto")))

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaAutorizarChecked()
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            'Dim intPeriodoId As Integer
            Dim ContadorFilas As Integer
            Dim StrSql As String
            Dim Posicion As Long
            Dim Procesados As Integer
            Dim Generar As Boolean
            Dim nEstadoAutorizada As Integer
            'Imposible si no existen Registros:
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de dar por autorizadas para las notas seleccionadas ." & Chr(13) & " y que estan revisadas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If
            nEstadoAutorizada = 0
            Procesados = 0
            Posicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")

            StrSql = "SELECT     dbo.StbValorCatalogo.nStbValorCatalogoID  FROM         dbo.StbCatalogo INNER JOIN  dbo.StbValorCatalogo ON dbo.StbCatalogo.nStbCatalogoID = dbo.StbValorCatalogo.nStbCatalogoID WHERE     (dbo.StbCatalogo.sNombre = 'EstadoNotaDebitoCredito') AND (dbo.StbValorCatalogo.sCodigoInterno = '3')"
            XcDatos.ExecuteSql(StrSql)
            If XcDatos.Count > 0 Then

                nEstadoAutorizada = XcDatos.ValueField("nStbValorCatalogoID")
            Else
                MsgBox("No existe definido el codigo de autorizado en las notas de debito, revisar el catalogo de valores ", MsgBoxStyle.Information)
                Exit Sub
            End If


            grdNotas.MoveFirst()
            For ContadorFilas = 0 To grdNotas.RowCount
                If XdsSolicitudCheque("Solicitud").ValueField("Selected") Then
                    Generar = True

                    StrSql = "SELECT     nSccNotaID,  sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                    XcDatos.ExecuteSql(StrSql)
                    If XcDatos.ValueField("sCodigoInterno") = "5" Or XcDatos.ValueField("sCodigoInterno") = "4" Or XcDatos.ValueField("sCodigoInterno") = "3" Or XcDatos.ValueField("sCodigoInterno") = "1" Then
                        Generar = False
                    End If
                    'If XcDatos.ValueField("sCodigoInterno") = "4" Then
                    '    MsgBox("La Nota ya tiene generada partida contable.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If
                    'If XcDatos.ValueField("sCodigoInterno") = "2" Then
                    '    MsgBox("La Nota se encuentra Revisada no Autorizada.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If

                    'If XcDatos.ValueField("sCodigoInterno") = "1" Then
                    '    MsgBox("La Nota se encuentra en Proceso no Autorizada.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If
                    'Debe tener las cuentas contables asociadas
                    'If Generar = True Then
                    '    StrSql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesCuentas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                    '    XcDatos.ExecuteSql(StrSql)
                    '    If XcDatos.Count < 2 Then
                    '        Generar = False
                    '    End If

                    'End If
                    'If Generar = True Then
                    '    '-- Imposible si no existe Periodo registrado para la Fecha de la Solicitud de Cheque:
                    '    intPeriodoId = IDPeriodo(XdsSolicitudCheque("Solicitud").ValueField("dFechaNota"))
                    '    If intPeriodoId = 0 Then
                    '        Generar = False
                    '    End If
                    'End If

                    'If Generar = True Then
                    '    '-- Imposible si el Periodo se encuentra Cerrado:
                    '    If PeriodoAbierto(intPeriodoId) = False Then
                    '        Generar = False
                    '    End If
                    'End If

                    If Generar = True Then
                        '-- Poner el cursor en estado ocupado
                        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                        StrSql = "Update dbo.SccNotaCreditoDebito Set  nStbEstadoNotaID = " & nEstadoAutorizada & " WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                        XcDatos.ExecuteSql(StrSql)
                        Procesados = Procesados + 1
                    End If


                End If
                Me.grdNotas.MoveNext()
            Next



            If Procesados > 0 Then
                MsgBox("Se Autorizaron un total de ." & Procesados.ToString().Trim() & " Notas .", MsgBoxStyle.Information)
                CargarSolicitudCheque(StrCadena, 0, StrCadena2)
            Else
                MsgBox("No Se Autorizaron notas.", MsgBoxStyle.Information)
            End If



            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", Posicion)
            Me.grdDetalleFichas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position







            'Debe tener las cuentas contables asociadas










            'If MsgBox("¿Está seguro de Generar el Comprobante de la Nota No." & Trim(XdsSolicitudCheque("Solicitud").ValueField("nCodigo")) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
            '    Exit Sub
            'End If


            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub LlamaGenerarChecked()
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim intPeriodoId As Integer
            Dim ContadorFilas As Integer
            Dim StrSql As String
            Dim Posicion As Long
            Dim Procesados As Integer
            Dim Generar As Boolean

            'Imposible si no existen Registros:
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de Generar Comprobantes Contables para las notas seleccionadas." & Chr(13) & " y que esten en Autorizadas ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If
            Procesados = 0
            Posicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")

            grdNotas.MoveFirst()
            For ContadorFilas = 0 To grdNotas.RowCount
                If XdsSolicitudCheque("Solicitud").ValueField("Selected") Then
                    Generar = True

                    StrSql = "SELECT     nSccNotaID,  sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                    XcDatos.ExecuteSql(StrSql)
                    If XcDatos.ValueField("sCodigoInterno") = "5" Or XcDatos.ValueField("sCodigoInterno") = "4" Or XcDatos.ValueField("sCodigoInterno") = "2" Or XcDatos.ValueField("sCodigoInterno") = "1" Then
                        Generar = False
                    End If
                    'If XcDatos.ValueField("sCodigoInterno") = "4" Then
                    '    MsgBox("La Nota ya tiene generada partida contable.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If
                    'If XcDatos.ValueField("sCodigoInterno") = "2" Then
                    '    MsgBox("La Nota se encuentra Revisada no Autorizada.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If

                    'If XcDatos.ValueField("sCodigoInterno") = "1" Then
                    '    MsgBox("La Nota se encuentra en Proceso no Autorizada.", MsgBoxStyle.Information)
                    '    Exit Sub
                    'End If
                    'Debe tener las cuentas contables asociadas
                    If Generar = True Then
                        StrSql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetallesCuentas  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                        XcDatos.ExecuteSql(StrSql)
                        If XcDatos.Count < 2 Then
                            Generar = False
                        End If

                    End If
                    If Generar = True Then
                        '-- Imposible si no existe Periodo registrado para la Fecha de la Solicitud de Cheque:
                        intPeriodoId = IDPeriodo(XdsSolicitudCheque("Solicitud").ValueField("dFechaNota"))
                        If intPeriodoId = 0 Then
                            Generar = False
                        End If
                    End If

                    If Generar = True Then
                        '-- Imposible si el Periodo se encuentra Cerrado:
                        If PeriodoAbierto(intPeriodoId) = False Then
                            Generar = False
                        End If
                    End If

                    If Generar = True Then
                        '-- Poner el cursor en estado ocupado
                        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                        InsertarNotaVarias(XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID"), TipoNota(XdsSolicitudCheque("Solicitud").ValueField("nMonto")))

                        Procesados = Procesados + 1
                    End If


                End If
                Me.grdNotas.MoveNext()
            Next



            If Procesados > 0 Then
                MsgBox("Se generaron un total de ." & Procesados.ToString().Trim() & " Comprobantes Contables.", MsgBoxStyle.Information)
                CargarSolicitudCheque(StrCadena, 0, StrCadena2)
            Else
                MsgBox("No Se generaron Comprobantes Contables.", MsgBoxStyle.Information)
            End If



            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", Posicion)
            Me.grdDetalleFichas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position







            'Debe tener las cuentas contables asociadas










            'If MsgBox("¿Está seguro de Generar el Comprobante de la Nota No." & Trim(XdsSolicitudCheque("Solicitud").ValueField("nCodigo")) & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
            '    Exit Sub
            'End If


            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub InsertarNota(ByVal NotaID As Long, ByVal StrTipoDoc As String)
        Dim XdtTmpParametros As BOSistema.Win.XDataSet.xDataTable
        XdtTmpParametros = New BOSistema.Win.XDataSet.xDataTable

        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim StrSql As String
            Dim intPosicion As Integer
            Dim ComprobanteId As Long

            '-- Para generación de un único Cheque de la Solicitud Actual:
            'If StrTipoDoc = "CE" Then
            'StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
            '         "FROM   SccSolicitudCheque " & _
            '         "WHERE  (nSccSolicitudChequeID = " & NotaID & ")"


            StrSql = "SELECT     dbo.vwSccNotaCreditoDebito.nSccNotaID, dbo.vwSccNotaCreditoDebito.nCodigo, dbo.vwSccNotaCreditoDebito.nScnFuenteFinanciamientoID, dbo.vwSccNotaCreditoDebito.nStbDelegacionProgramaID, dbo.vwSccNotaCreditoDebito.dFechaNota,dbo.vwSccNotaCreditoDebito.dFechaTipoCambio, dbo.vwSccNotaCreditoDebito.sConceptoNota FROM         dbo.vwSccNotaCreditoDebito Where nSccNotaID=" & NotaID
            'Else
            '    StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, 0 as nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
            '             "FROM   SccSolicitudCheque " & _
            '             "WHERE  (nSccSolicitudChequeID = " & IdSolicitudCK & ")"
            'End If
            XdtTmpParametros.ExecuteSql(StrSql)

            '---------------------------
            '-- 1. Insertar Encabezado de Comprobante :
            '-- 2. Insertar Detalles del Comprobante  :
            '-- 3. Actualiza Estado de Solicitud a "Generado Comprobante":
            '-- 4. Mayoriza el Comprobante en Saldos.

            StrSql = "Exec spSccGenerarComprobanteNota " & NotaID & ",'" & XdtTmpParametros.ValueField("nCodigo") & "','" & Trim(StrTipoDoc) & "'," & XdtTmpParametros.ValueField("nScnFuenteFinanciamientoID") & ", " & XdtTmpParametros.ValueField("nStbDelegacionProgramaID") & ", '" & _
            Trim(RTrim(XdtTmpParametros.ValueField("sConceptoNota"))) & "','" & Format(XdtTmpParametros.ValueField("dFechaNota"), "yyyy-MM-dd") & "','" & Format(XdtTmpParametros.ValueField("dFechaTipoCambio"), "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta

            'StrSql = " EXEC spSccGenerarComprobanteCK " & XdtTmpParametros.ValueField("nSccSolicitudChequeID") & "," & XdtTmpParametros.ValueField("nScnFuenteFinanciamientoID") & ", " & XdtTmpParametros.ValueField("nStbDelegacionProgramaID") & ", '" _
            '         & Trim(RTrim(XdtTmpParametros.ValueField("sConceptoPago"))) & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "'," _
            '         & XdtTmpParametros.ValueField("nStbPersonaBeneficiariaID") & "," & InfoSistema.IDCuenta & ", '" & StrTipoDoc & "', '" & StrNumeroCheque & "'"
            ComprobanteId = XcDatos.ExecuteScalar(StrSql)
            '--------------------------------------------

            If ComprobanteId = 0 Then
                MsgBox("El Comprobante de Nota NO pudo generarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                'Almacena Pista de Auditoría:
                Call GuardarAuditoria(4, 23, "Generación automática de Comprobante de Nota. Nota No.: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
                'Guardar posición actual de la selección:
                intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
                CargarSolicitudCheque(StrCadena, 0, StrCadena2)
                'Ubicar la selección en la posición original:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
                Me.grdNotas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
                'Indicar generación exitosa
                MsgBox("Comprobante de nota generado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpParametros.Close()
            XdtTmpParametros = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub InsertarNotaVarias(ByVal NotaID As Long, ByVal StrTipoDoc As String)
        Dim XdtTmpParametros As BOSistema.Win.XDataSet.xDataTable
        XdtTmpParametros = New BOSistema.Win.XDataSet.xDataTable

        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim StrSql As String
            'Dim intPosicion As Integer
            Dim ComprobanteId As Long

            '-- Para generación de un único Cheque de la Solicitud Actual:
            'If StrTipoDoc = "CE" Then
            'StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
            '         "FROM   SccSolicitudCheque " & _
            '         "WHERE  (nSccSolicitudChequeID = " & NotaID & ")"


            StrSql = "SELECT     dbo.vwSccNotaCreditoDebito.nSccNotaID, dbo.vwSccNotaCreditoDebito.nCodigo, dbo.vwSccNotaCreditoDebito.nScnFuenteFinanciamientoID, dbo.vwSccNotaCreditoDebito.nStbDelegacionProgramaID, dbo.vwSccNotaCreditoDebito.dFechaNota,dbo.vwSccNotaCreditoDebito.dFechaTipoCambio, dbo.vwSccNotaCreditoDebito.sConceptoNota FROM         dbo.vwSccNotaCreditoDebito  Where nSccNotaID=" & NotaID
            'Else
            '    StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, 0 as nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
            '             "FROM   SccSolicitudCheque " & _
            '             "WHERE  (nSccSolicitudChequeID = " & IdSolicitudCK & ")"
            'End If
            XdtTmpParametros.ExecuteSql(StrSql)

            '---------------------------
            '-- 1. Insertar Encabezado de Comprobante :
            '-- 2. Insertar Detalles del Comprobante  :
            '-- 3. Actualiza Estado de Solicitud a "Generado Comprobante":
            '-- 4. Mayoriza el Comprobante en Saldos.

            StrSql = "Exec spSccGenerarComprobanteNota " & NotaID & "," & XdtTmpParametros.ValueField("nCodigo") & ",'" & Trim(StrTipoDoc) & "'," & XdtTmpParametros.ValueField("nScnFuenteFinanciamientoID") & ", " & XdtTmpParametros.ValueField("nStbDelegacionProgramaID") & ", '" & _
            Trim(RTrim(XdtTmpParametros.ValueField("sConceptoNota"))) & "','" & Format(XdtTmpParametros.ValueField("dFechaNota"), "yyyy-MM-dd") & "','" & Format(XdtTmpParametros.ValueField("dFechaTipoCambio"), "yyyy-MM-dd") & "'," & InfoSistema.IDCuenta

            'StrSql = " EXEC spSccGenerarComprobanteCK " & XdtTmpParametros.ValueField("nSccSolicitudChequeID") & "," & XdtTmpParametros.ValueField("nScnFuenteFinanciamientoID") & ", " & XdtTmpParametros.ValueField("nStbDelegacionProgramaID") & ", '" _
            '         & Trim(RTrim(XdtTmpParametros.ValueField("sConceptoPago"))) & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "'," _
            '         & XdtTmpParametros.ValueField("nStbPersonaBeneficiariaID") & "," & InfoSistema.IDCuenta & ", '" & StrTipoDoc & "', '" & StrNumeroCheque & "'"
            ComprobanteId = XcDatos.ExecuteScalar(StrSql)
            '--------------------------------------------

            'If ComprobanteId = 0 Then
            '    MsgBox("El Comprobante de Nota NO pudo generarse.", MsgBoxStyle.Information, NombreSistema)
            'Else
            '    'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Generación automática de Comprobante de Nota. Nota No.: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
            'Guardar posición actual de la selección:
            'intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            'CargarSolicitudCheque(StrCadena, 0)
            ''Ubicar la selección en la posición original:
            'XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
            'Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            ''Indicar generación exitosa
            'MsgBox("Comprobante de nota generado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpParametros.Close()
            XdtTmpParametros = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub LlamaImprimir()

        Dim ObjFrmSclParametroFNC As New FrmSccParametroNotaCredito
        Try
            Dim strSQL As String = ""

            'Imposible si no existen Solicitudes:
            'If Me.grdSolicitud.RowCount = 0 Then
            '    MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmSclParametroFNC.ShowDialog()

            ''Imposible si la Solicitud no se encuentra Autorizada o Anulada:
            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) < 4) Then
            '    MsgBox("La Solicitud aún NO ha sido Autorizada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ''Si es Solicitud a Socias no deben existir ninguna Solicitud diferente de Anulada o Autorizada:
            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID")) = 1) Then
            '    strSQL = "SELECT FNC.nCodigo " & _
            '             "FROM SccSolicitudCheque as SCK INNER JOIN SccSolicitudDesembolsoCredito as SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
            '             "SclFichaNotificacionDetalle as DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN SclFichaNotificacionCredito as FNC ON  DFNC.nSclFichaNotificacionID = FNC.nSclFichaNotificacionID INNER JOIN StbValorCatalogo as C ON SCK.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
            '             "WHERE (C.sCodigoInterno < '4') AND (FNC.nCodigo = " & XdsSolicitudCheque("Solicitud").ValueField("nCodigoFNC") & ")"
            '    If RegistrosAsociados(strSQL) Then
            '        MsgBox("Existen Socias con Solicitud aún NO Autorizada en el Grupo.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            ''Imposible si la Solicitud no se encuentra Revisada por Contabilidad (Con o Sin CK) o Anulada:
            ''If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) < 3) Then
            ''    MsgBox("La Solicitud aún NO ha sido Revisada por Contabilidad.", MsgBoxStyle.Information)
            ''    Exit Sub
            ''End If

            ''Formato de Solicitud de Cheque:
            'ObjFrmSclParametroFNC.NomRep = 11
            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID")) = 1) Then
            '    ObjFrmSclParametroFNC.intSclFormatoID = XdsSolicitudCheque("Solicitud").ValueField("nSclFichaNotificacionID")
            '    ObjFrmSclParametroFNC.intSccTipoID = 1
            'Else
            '    ObjFrmSclParametroFNC.intSclFormatoID = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            '    ObjFrmSclParametroFNC.intSccTipoID = 0
            'End If
            'ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
            'ObjFrmSclParametroFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbCuenta_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCuenta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarJ"
                LlamaAgregarJornalizacion()
                'Case "toolModificarJ"
                '    LlamaModificarJornalizacion()
            Case "toolEliminarJ"
                LlamaEliminarJornalizacion()
            Case "toolAyudaS"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaEliminarJornalizacion
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una cuenta contable.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarJornalizacion()

        Dim XdtCuenta As New BOSistema.Win.XDataSet.xDataTable

        Try

            Dim intPosicion As Integer
            Dim StrMsg As String
            Dim StrSql As String

            'Imposible si no existen Solicitudes:
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ''Si NO tiene permisos de Edición fuera de su Delegación: 
            'If IntPermiteEditar = 0 Then
            '    If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
            '        MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            ''Si no es el Area Contable es Imposible eliminar Jornalizacion:
            'If ModoAccion <> "REV" Then
            '    MsgBox("Unicamente el Area Contable puede eliminar Cuentas.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'No existen Cuentas:
            If Me.grdDetallesCuentas.RowCount = 0 Then
                MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si el Area que Revisa (Contabilidad), la Solicitud DEBE encontrarse:
            '1.	Con el Estado Enviada a Contabilidad, (YA generada la Codificación Contable).
            '2.	La Solicitud se encuentre con el estado Revisada por Contabilidad (al encontrar inconsistencias por el área que autoriza).
            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 1) Then
            '    MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If


            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                                "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                                "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota se Encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub

            End If

            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '4') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota se Encuentra con Partida Generada.", MsgBoxStyle.Information)
                Exit Sub

            End If
            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota se Encuentra Autorizada", MsgBoxStyle.Information)
                Exit Sub

            End If



            'StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
            '         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
            '    MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
            '         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 4) Or (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) Then
            '    MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
            '         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '4' or StbValorCatalogo.sCodigoInterno = '6') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Si es Solicitud de Cheque a Socias elimina todas las cuentas:
            'If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
            StrMsg = "¿Está seguro de Eliminar la Codificación Contable automática?"
            'Else 'En caso contrario solo elimina la cuenta seleccionada.
            '    StrMsg = "¿Está seguro de Eliminar la Cuenta seleccionada?"
            'End If

            If MsgBox(StrMsg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")

                'Si es Solicitud de Cheque a Socias elimina todas las cuentas:
                'If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
                XdtCuenta.ExecuteSqlNotTable("Delete From SccNotaCreditoDebitoDetalleCuentas where nSccNotaID=" & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID"))
                'Else 'En caso contrario solo elimina la cuenta seleccionada.
                '    XdtCuenta.ExecuteSqlNotTable("Delete From SccSolicitudChequeDetalle where nSccSolicitudChequeDetalleID=" & XdsSolicitudCheque("Cuentas").ValueField("nSccSolicitudChequeDetalleID"))
                'End If

                CargarSolicitudCheque(StrCadena, 0, StrCadena2)
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
                Me.grdNotas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
                MsgBox("Codificación eliminada satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena pista de auditoria:
                Call GuardarAuditoria(4, 23, "Eliminación de cuenta de Nota : " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
                'Me.grdDetalleFichas.Caption = " Listado de Notas  (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"
                'Me.grdDetallesCuentas.Caption = " Detalles de Notas  (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"

                Me.grdDetalleFichas.Caption = " Listado  de Notas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"
                Me.grdDetallesCuentas.Caption = " Detalles de Notas Cuentas Contables (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
                Me.grdDetalleFichas.Caption = " Detalles de Notas Fichas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtCuenta.Close()
            XdtCuenta = Nothing
        End Try
    End Sub


    Private Sub LlamaBuscar()
        Dim ObjFrmSccBusquedaS As New frmSccBusquedaNotasDebitoCredito
        Try

            ObjFrmSccBusquedaS.StrCriterioSolicitud = "0" 'Sin Criterio de Busqueda
            ObjFrmSccBusquedaS.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSccBusquedaS.sColorFrm = Me.sColor
            ObjFrmSccBusquedaS.ShowDialog()
            If ObjFrmSccBusquedaS.StrCriterioSolicitud <> "0" Then
                StrCadena = ObjFrmSccBusquedaS.StrCriterioSolicitud
                StrCadena2 = ObjFrmSccBusquedaS.StrCriterioSolicitud2
                nTipoBusqueda = ObjFrmSccBusquedaS.snTipoBusqueda
                CargarSolicitudCheque(StrCadena, 0, StrCadena2)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccBusquedaS.Close()
            ObjFrmSccBusquedaS = Nothing
        End Try
    End Sub


    Private Sub LlamaAgregar()
        Dim ObjFrmSclEditSCK As New FrmSccEditNotaDebitoCredito
        Try

            ''Si no es el Area Solicitante Imposible Agregar Solicitud: 
            'If ModoAcc <> "ELA" Then
            '    MsgBox("Unicamente el Area Solicitante puede registrar" & Chr(13) & "Solicitudes de Cheque.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmSclEditSCK.sColorFrm = "Verde"
            ObjFrmSclEditSCK.ModoFrm = "ADD"
            ObjFrmSclEditSCK.ShowDialog()


            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCK.IdNota <> 0 Then
                StrCadena = "Where (a.nSccNotaID = " & ObjFrmSclEditSCK.IdNota & ")"
                CargarSolicitudCheque(StrCadena, 0, StrCadena2)
                'Se ubica sobre el registro recien agregado:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", ObjFrmSclEditSCK.IdNota)
                Me.grdDetalleFichas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            End If



        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSCK.Close()
            ObjFrmSclEditSCK = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       InsertarDetallesSolicitud
    ' Descripción:          Este procedimiento permite insertar Codificación Contable 
    '                       sugerida en Parámetros. 
    '-------------------------------------------------------------------------
    Private Sub InsertarDetallesSolicitud()
        Dim XdtTmpParametros As BOSistema.Win.XDataSet.xDataTable
        XdtTmpParametros = New BOSistema.Win.XDataSet.xDataTable

        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing

        Try
            Dim StrSql As String
            Dim IntRegistros As Integer
            Dim intPosicion As Integer
            Dim TipoNota As String


            If XdsSolicitudCheque("Solicitud").ValueField("nMonto") < 0 Then 'Si es menor de cero entonces es de Debito
                TipoNota = "ND"
            Else 'Sino es de credito
                TipoNota = "NC"
            End If
            StrSql = "SELECT TP.nScnFuenteFinanciamientoID, TP.nScnCatalogoContableID, TP.nDebito " & _
                     "FROM  ScnTransaccionParametros TP INNER JOIN StbValorCatalogo CA ON TP.nStbTipoDocContableID = CA.nStbValorCatalogoID " & _
                     "WHERE (TP.nScnFuenteFinanciamientoID = " & XdsSolicitudCheque("Solicitud").ValueField("nScnFuenteFinanciamientoID") & ") AND (CA.sCodigoInterno = '" & Trim(TipoNota) & "') "
            XdtTmpParametros.ExecuteSql(StrSql)
            IntRegistros = XdtTmpParametros.Count

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transaccion:
            Trans.BeginTrans()

            While IntRegistros > 0
                'Insertar Cuenta en los Detalles de la Solicitud:
                StrSql = "Insert Into SccNotaCreditoDebitoDetalleCuentas " & _
                         "(nSccNotaID, nScnCatalogoContableID, nDebito, nMonto, nUsuarioCreacionID, dFechaCreacion) " & _
                         " Values (" & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ", " & XdtTmpParametros.ValueField("nScnCatalogoContableID") & _
                         ", " & XdtTmpParametros.ValueField("nDebito") & ", " & System.Math.Abs(XdsSolicitudCheque("Solicitud").ValueField("nMonto")) & ", " & InfoSistema.IDCuenta & "," & "GetDate())"
                Trans.ExecuteSql(StrSql)
                '---------------------------
                XdtTmpParametros.Source.MoveNext()
                IntRegistros = IntRegistros - 1
            End While

            '-- Finaliza Transaccion:
            Trans.Commit()

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Generación automática de Codificación Contable de Nota Debito-Credito: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            CargarSolicitudCheque(StrCadena, 0, StrCadena2)
            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
            Me.grdNotas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            'Me.grdDetallesCuentas.Caption = " Detalles de Notas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            Me.grdDetalleFichas.Caption = " Listado  de Notas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"
            Me.grdDetallesCuentas.Caption = " Detalles de Notas Cuentas Contables (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            Me.grdDetalleFichas.Caption = " Detalles de Notas Fichas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            MsgBox("Codificación Contable generada Exitosamente.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing
            XdtTmpParametros.Close()
            XdtTmpParametros = Nothing
        End Try
    End Sub
    'Importante si es Nota de Debito o Credito cambiar si es negativo monto o positivo
    Private Function TipoNota(ByVal Monto As String) As String
        Return (IIf(XdsSolicitudCheque("Solicitud").ValueField("nMonto") < 0, "ND", "NC"))
    End Function
    Private Sub LlamaAgregarJornalizacion()
        Dim ObjFrmSclEditCuentas As New frmSccEditCuentasSolicitudCheque
        Dim xMontoNota As Double
        Dim xMontoDetalle As Double
        Dim XdtTmpParametros As BOSistema.Win.XDataSet.xDataTable
        XdtTmpParametros = New BOSistema.Win.XDataSet.xDataTable
        Dim XdtTmpComando As New BOSistema.Win.XComando
        Try
            Dim strSQL As String

            'Imposible si no existen Solicitudes:
            If Me.grdDetalleFichas.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If




            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 4) Then
                MsgBox("La Nota ya ha generado comprobante contable.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            strSQL = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '4') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Nota ya ha generado comprobante contable.", MsgBoxStyle.Information)
                Exit Sub
            End If
            strSQL = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Nota se Encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 3) Then
                MsgBox("La Nota se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            strSQL = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Nota se Encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Si la Solicitud es de pago de CK a Socias: Nota debito
            'If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
            'Si ya se efectuó la Distribución automática:
            If Me.grdDetallesCuentas.RowCount > 0 Then
                MsgBox("Ya se generó la Codificación Contable.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Si ya se registro la Distribución en la Base de Datos (Concurrencia):
            strSQL = "SELECT * FROM  SccNotaCreditoDebitoDetalleCuentas WHERE  (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya se generó la Codificación Contable.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si no existen Parámetros para la Fuente y de tipo Deudor:
            strSQL = "Select TP.nScnFuenteFinanciamientoID " & _
                     "FROM  ScnTransaccionParametros TP INNER JOIN StbValorCatalogo CA ON TP.nStbTipoDocContableID = CA.nStbValorCatalogoID " & _
                     "WHERE  (TP.nScnFuenteFinanciamientoID = " & XdsSolicitudCheque("Solicitud").ValueField("nScnFuenteFinanciamientoID") & ") AND (CA.sCodigoInterno = '" & TipoNota(XdsSolicitudCheque("Solicitud").ValueField("nMonto")) & "') AND (TP.nDebito = 1)"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No se han indicado los parámetros Contables" & Chr(13) & "para la fuente de financiamiento.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si no existen Parámetros para la Fuente y de tipo Acreedor:
            strSQL = "Select TP.nScnFuenteFinanciamientoID " & _
                     "FROM  ScnTransaccionParametros TP INNER JOIN StbValorCatalogo CA ON TP.nStbTipoDocContableID = CA.nStbValorCatalogoID " & _
                     "WHERE  (TP.nScnFuenteFinanciamientoID = " & XdsSolicitudCheque("Solicitud").ValueField("nScnFuenteFinanciamientoID") & ") AND (CA.sCodigoInterno = '" & TipoNota(XdsSolicitudCheque("Solicitud").ValueField("nMonto")) & "') AND (TP.nDebito = 0)"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No se han indicado los parámetros Contables" & Chr(13) & "para la fuente de financiamiento.", MsgBoxStyle.Information)
                Exit Sub
            End If



            'Ver si hay diferencias de monto entre el detalle y el encabezado
            strSQL = "SELECT     SUM(nMonto) AS MontoF  FROM         dbo.SccNotaCreditoDebitoDetalleFichas " & _
                     " WHERE(nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            xMontoNota = 0
            xMontoDetalle = 0
            XdtTmpParametros.ExecuteSql(strSQL)
            If XdtTmpParametros.Count > 0 Then
                xMontoDetalle = XdtTmpParametros.ValueField("MontoF")
            End If

            strSQL = " SELECT     nMonto  FROM         dbo.SccNotaCreditoDebito WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"


            XdtTmpParametros.ExecuteSql(strSQL)
            If XdtTmpParametros.Count > 0 Then
                xMontoNota = XdtTmpParametros.ValueField("nMonto")
            End If
            If System.Math.Abs(xMontoNota - xMontoDetalle) > 0 Then
                MsgBox("El monto del encabezado de nota no estaba de acuerdo al indicado en el detalle." & Chr(13) & "Se actualizara automaticamente. ", MsgBoxStyle.Information)
                strSQL = " Update dbo.SccNotaCreditoDebito Set  nMonto= " & xMontoDetalle & "   WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                XdsSolicitudCheque("Solicitud").ValueField("nMonto") = xMontoDetalle

                XdtTmpComando.Execute(strSQL)
            End If










            'Se registran automaticamente las cuentas:
            InsertarDetallesSolicitud()

            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditCuentas.Close()
            ObjFrmSclEditCuentas = Nothing
        End Try
    End Sub
    Private Sub LlamaCheck(ByVal Band As Integer)

        Dim Posicion As Long
        Try

            'Imposible si no existen Solicitudes:
            If Me.grdDetalleFichas.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM InicializaVariables()
            Posicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            CargarSolicitudCheque(StrCadena, Band, StrCadena2)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", Posicion)
            Me.grdDetalleFichas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    ObjFrmScnEditSCK.Close()
            '    ObjFrmScnEditSCK = Nothing
        End Try
    End Sub



    Private Sub LlamaModificar()
        Dim ObjFrmScnEditSCK As New FrmSccEditNotaDebitoCredito
        Dim StrSql As String
        Try

            'Imposible si no existen Solicitudes:
            If Me.grdNotas.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            'If IntPermiteEditar = 0 Then
            '    If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
            '        MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            '-If ModoAcc = "ELA" Then
            ObjFrmScnEditSCK.sColorFrm = "Verde"
            'Else
            'ObjFrmScnEditSCK.sColorFrm = "CelesteLight"
            'End If

            ObjFrmScnEditSCK.IntHabilito = 1


            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota se Encuentra Anulada.", MsgBoxStyle.Information)
                'Exit Sub
                ObjFrmScnEditSCK.IntHabilito = 0
            End If

            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '4') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota se Encuentra con Partida Generada.", MsgBoxStyle.Information)
                'Exit Sub
                ObjFrmScnEditSCK.IntHabilito = 0
            End If
            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN StbValorCatalogo ON SccNotaCreditoDebito.nStbEstadoNotaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota se Encuentra Autorizada", MsgBoxStyle.Information)
                'Exit Sub
                ObjFrmScnEditSCK.IntHabilito = 0
            End If

            StrSql = "SELECT SccNotaCreditoDebito.nSccNotaID " & _
                     "FROM SccNotaCreditoDebito INNER JOIN SccNotaCreditoDebitoDetalleCuentas ON SccNotaCreditoDebito.nSccNotaID = SccNotaCreditoDebitoDetalleCuentas.nSccNotaID " & _
                     "WHERE (SccNotaCreditoDebito.nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Nota tiene Asociada Cuentas Contables.", MsgBoxStyle.Information)
                'Exit Sub
                ObjFrmScnEditSCK.IntHabilito = 0
            End If

            'Solo en proceso se puede modificar



            ''Si no es el Area Solicitante o Contable Imposible Modificar Solicitud:
            'If ModoAcc = "AUT" Then
            '    MsgBox("Unicamente el Area Solicitante y Contable puede modificar" & Chr(13) & "los datos generales de la Solicitud.", MsgBoxStyle.Information)
            '    ObjFrmScnEditSCK.IntHabilito = 0
            'Else
            '    'Imposible si la Solicitud se encuentra Anulada:
            '    StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
            '         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            '    If (RegistrosAsociados(StrSql)) Or ((CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5)) Then
            '        MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
            '        ObjFrmScnEditSCK.IntHabilito = 0
            '        'Exit Sub
            '    Else
            '        'Si es el Area Solicitante La Solicitud DEBE encontrarse:
            '        '1.	Con el Estado En Proceso.
            '        '2.	Con el Estado Enviada a Contabilidad, siempre que el área Contable aún NO haya generado la Codificación Contable.
            '        StrSql = "SELECT * FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            '        If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) > 2) Or (RegistrosAsociados(StrSql)) Then
            '            MsgBox("La Solicitud ya ha sido Codificada" & Chr(13) & "por el Area Contable.", MsgBoxStyle.Information)
            '            ObjFrmScnEditSCK.IntHabilito = 0
            '        End If
            '        StrSql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
            '                 "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
            '                 "WHERE (StbValorCatalogo.sCodigoInterno > '2') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            '        If RegistrosAsociados(StrSql) Then
            '            MsgBox("La Solicitud ya ha sido Revisada" & Chr(13) & "por el Area Contable.", MsgBoxStyle.Information)
            '            ObjFrmScnEditSCK.IntHabilito = 0
            '        End If
            '    End If
            'End If

            ObjFrmScnEditSCK.ModoFrm = "UPD"
            ObjFrmScnEditSCK.IdNota = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            ObjFrmScnEditSCK.ShowDialog()

            REM InicializaVariables()
            CargarSolicitudCheque(StrCadena, 0, StrCadena2)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", ObjFrmScnEditSCK.IdNota)
            Me.grdNotas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditSCK.Close()
            ObjFrmScnEditSCK = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaModificarJornalizacion
    ' Descripción:          Este procedimiento permite modificar la Jornalizacion
    '                       actual de la Solicitud de Cheque.
    '-------------------------------------------------------------------------
    'Private Sub LlamaModificarJornalizacion()
    '    Dim ObjFrmSclEditCuentas As New frmSccEditCuentasSolicitudCheque
    '    Try

    '        Dim StrSql As String

    '        'Imposible si no existen Solicitudes:
    '        If Me.grdSolicitud.RowCount = 0 Then
    '            MsgBox("No existen Notas Registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO tiene permisos de Edición fuera de su Delegación: 
    '        'If IntPermiteEditar = 0 Then
    '        '    If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
    '        '        MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
    '        '        Exit Sub
    '        '    End If
    '        'End If

    '        'Si no es el Area que revisa es Imposible modificar Jornalizacion:
    '        'If ModoAccion <> "REV" Then
    '        '    MsgBox("Unicamente el Area Contable puede Modificar la Jornalización.", MsgBoxStyle.Information)
    '        '    Exit Sub
    '        'End If

    '        'No existen Cuentas:
    '        If Me.grdDetalles.RowCount = 0 Then
    '            MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si el Area que Revisa (Contabilidad), la Solicitud DEBE encontrarse:
    '        '1.	Con el Estado Enviada a Contabilidad, (YA generada la Codificación Contable).
    '        '2.	La Solicitud se encuentre con el estado Revisada por Contabilidad (al encontrar inconsistencias por el área que autoriza).
    '        If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 1) Then
    '            MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If
    '        StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                 "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
    '        If RegistrosAsociados(StrSql) Then
    '            MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
    '            MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If
    '        StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
    '                "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
    '        If RegistrosAsociados(StrSql) Then
    '            MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 4) Or (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) Then
    '            MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If
    '        StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
    '                 "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                 "WHERE (StbValorCatalogo.sCodigoInterno = '4' or StbValorCatalogo.sCodigoInterno = '6') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
    '        If RegistrosAsociados(StrSql) Then
    '            MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Imposible si es Solicitud de Entrega de Cheque a Socias:
    '        If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
    '            MsgBox("No es posible modificación manual de Codificación" & Chr(13) & "Contable para Solicitudes de entrega de Cheque a" & Chr(13) & "Socias.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        ObjFrmSclEditCuentas.ModoFrm = "UPD"
    '        ObjFrmSclEditCuentas.IdSolicitud = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
    '        ObjFrmSclEditCuentas.IdCuenta = XdsSolicitudCheque("Cuentas").ValueField("nSccSolicitudChequeDetalleID")
    '        ObjFrmSclEditCuentas.ShowDialog()

    '        CargarSolicitudCheque(StrCadena)
    '        XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSclEditCuentas.IdSolicitud)
    '        Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

    '        XdsSolicitudCheque("Cuentas").SetCurrentByID("nSccSolicitudChequeDetalleID", ObjFrmSclEditCuentas.IdCuenta)
    '        Me.grdDetalles.Row = XdsSolicitudCheque("Cuentas").BindingSource.Position

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjFrmSclEditCuentas.Close()
    '        ObjFrmSclEditCuentas = Nothing
    '    End Try
    'End Sub


    Private Sub LlamaAnular()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim XcComando As New BOSistema.Win.XComando

        Try

            Dim intPosicion As Integer

            'Imposible si no existen Solicitudes:
            'If Me.grdDetalleFichas.RowCount = 0 Then
            '    MsgBox("No existen Notas  registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ''Si NO tiene permisos de Edición fuera de su Delegación: 
            'If IntPermiteEditar = 0 Then
            '    If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
            '        MsgBox("Imposible Anular Solicitudes de otra Delegación.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If


            'La solicitud se encuentra Anulada:

            Strsql = "SELECT     nSccNotaID,  sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
            XcDatos.ExecuteSql(Strsql)
            If XcDatos.ValueField("sCodigoInterno") = "5" Then
                MsgBox("La Nota se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XcDatos.ValueField("sCodigoInterno") = "4" Then
                MsgBox("La Nota tiene generada partida contable. No se puede Anular.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Anulación:
            If MsgBox("¿Está seguro de Anular la Nota seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            ''Anula la Nota Actual:
            Strsql = " Update SccNotaCreditoDebito " & _
                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nStbEstadoNotaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '5' And b.sNombre = 'EstadoNotaDebitoCredito')" & _
                     " WHERE nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            XcComando.ExecuteNonQuery(Strsql)

            MsgBox("Nota Anulada Exitosamente.", MsgBoxStyle.Information, NombreSistema)

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Anulación de Nota: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")

            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID")
            CargarSolicitudCheque(StrCadena, 0, StrCadena2)

            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccNotaID", intPosicion)
            Me.grdDetalleFichas.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
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
    ' Fecha:                12/11/2007
    ' Procedure Name:       grdSolicitud_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Solicitud, al hacer doble click en
    '                       el registro deseado.
    '-------------------------------------------------------------------------

    Private Sub grdSolicitud_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalleFichas.DoubleClick
        Try
            If Seg.HasPermission("ModificarSCK") Then
                LlamaModificar()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdSolicitud_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDetalleFichas.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdSolicitud_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalleFichas.Filter
        Try
            XdsSolicitudCheque("Fichas").FilterLocal(e.Condition)
            Me.grdDetalleFichas.Caption = " Listado de Fichas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar :
            If Seg.HasPermission("BuscarNotasCD") = False Then
                Me.tbSolicitud.Items("toolBuscar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolBuscar").Enabled = True
            End If
            'Agregar :
            If Seg.HasPermission("AgregarNotasCD") = False Then
                Me.tbSolicitud.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAgregar").Enabled = True
            End If
            'Editar :
            If Seg.HasPermission("ModificarNotasCD") = False Then
                Me.tbSolicitud.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolModificar").Enabled = True
            End If
            'Anular :
            If Seg.HasPermission("AnularNotasCD") = False Then
                Me.tbSolicitud.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAnular").Enabled = True
            End If
            'Revisar :
            If Seg.HasPermission("RevisarNotasCD") = False Then
                Me.tbSolicitud.Items("toolRevisar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolRevisar").Enabled = True
            End If

            'Revisar :
            If Seg.HasPermission("AutorizarNotasCD") = False Then
                Me.toolAutorizar.Enabled = False
                Me.ToolAutorizarChecked.Enabled = False
            Else  'Habilita
                Me.toolAutorizar.Enabled = True
                Me.ToolAutorizarChecked.Enabled = True
            End If

            'Generar comprobante un registro :
            If Seg.HasPermission("GenerarNotasCD") = False Then
                Me.toolGenerar.Enabled = False
                Me.toolGenerarChecked.Enabled = False
            Else  'Habilita
                Me.toolGenerar.Enabled = True
                Me.toolGenerarChecked.Enabled = True
            End If
            'generar comprobantes seleccionados
            If Seg.HasPermission("GenerarNotasBloqueCD") = False Then
                Me.toolGenerarChecked.Enabled = False
            Else  'Habilita
                Me.toolGenerarChecked.Enabled = True
            End If
            'Imprimir :
            If Seg.HasPermission("ImprimirNotasCD") = False Then
                Me.toolImprimir.Enabled = False
                Me.toolImprimirC.Enabled = False
            Else  'Habilita
                Me.toolImprimir.Enabled = True
                Me.toolImprimirC.Enabled = True
            End If

            'Agregar Jornalización:
            If Seg.HasPermission("AgregarCuentasNotasCD") = False Then
                Me.tbCuenta.Items("toolAgregarJ").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolAgregarJ").Enabled = True
            End If

            'Eliminar Jornalización:
            If Seg.HasPermission("EliminarCuentasNotasCD") = False Then
                Me.toolEliminarJ.Enabled = False
            Else  'Habilita
                Me.toolEliminarJ.Enabled = True
            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdDetalles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetallesCuentas.DoubleClick
        Try
            'If Seg.HasPermission("ModificarCuentasSCK") Then
            '    LlamaModificarJornalizacion()
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdDetalles_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDetallesCuentas.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdDetalles_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetallesCuentas.Filter
        Try
            XdsSolicitudCheque("Cuentas").FilterLocal(e.Condition)
            ' Me.grdDetallesCuentas.Caption = " Detalles de Notas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"

            ' Me.grdDetalleFichas.Caption = " Listado  de Notas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"
            Me.grdDetallesCuentas.Caption = " Detalles de Notas Cuentas Contables (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
            ' Me.grdDetalleFichas.Caption = " Detalles de Notas Fichas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdDetallesCuentas_FilterButtonClick(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles grdDetallesCuentas.FilterButtonClick

    End Sub

    Private Sub grdDetalles_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdDetallesCuentas.RowColChange
        'Me.grdDetallesCuentas.Caption = " Detalles de Notas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
        ' Me.grdDetalleFichas.Caption = " Listado  de Notas (" + Me.grdDetalleFichas.RowCount.ToString + " registros)"
        Me.grdDetallesCuentas.Caption = " Detalles de Notas Cuentas Contables (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
        'Me.grdDetalleFichas.Caption = " Detalles de Notas Fichas (" + Me.grdDetallesCuentas.RowCount.ToString + " registros)"
    End Sub



    Private Sub grdNotas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdNotas.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdNotas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdNotas.Filter
        Try
            XdsSolicitudCheque("Solicitud").FilterLocal(e.Condition)
            Me.grdNotas.Caption = " Listado  de Notas (" + Me.grdNotas.RowCount.ToString + " registros)"
            Me.CalcularMontos()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub grdNotas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdNotas.Click

    End Sub

    Private Sub grdDetalleFichas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetalleFichas.Click

    End Sub

    Private Sub grdDetallesCuentas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdDetallesCuentas.Click

    End Sub

    Private Sub grdDetalleFichas_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalleFichas.FilterChange

    End Sub

    Private Sub CalcularMontos()
        Try
            Dim vTotal As Double = 0
            
            For index As Integer = 0 To Me.grdNotas.RowCount - 1
                Me.grdNotas.Row = index
                vTotal = vTotal + Me.grdNotas.Columns("nMonto").Value
            
            Next
            If Me.grdNotas.RowCount > 0 Then
                Me.grdNotas.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdNotas.Columns("nMonto").FooterText = Format(vTotal, "C$ #,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class