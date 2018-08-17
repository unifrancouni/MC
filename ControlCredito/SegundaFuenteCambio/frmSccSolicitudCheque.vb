
' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                12/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccSolicitudCheque.vb
' Descripción:          Formulario muestra Solicitudes de Cheques.
'-------------------------------------------------------------------------
Public Class frmSccSolicitudCheque
    '- Declaración de Variables 
    Dim XdsSolicitudCheque As BOSistema.Win.XDataSet
    Dim ModoAcc As String
    Dim sColor As String
    Dim TipoChk As Integer
    Dim TipoChkAgregar As Integer
    Dim StrCadena As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    '0: Todos
    '1:Solo Tipo Cheque 1 y 2 Para Socias y Delegadas
    'Para que creditos no vea los cheques de pagos gastos 
    Public Property TipoCheque() As Integer
        Get
            TipoCheque = TipoChk
        End Get
        Set(ByVal value As Integer)
            TipoChk = value
        End Set
    End Property

    Public Property TipoChequeAgregar() As Integer
        Get
            TipoChequeAgregar = TipoChkAgregar
        End Get
        Set(ByVal value As Integer)
            TipoChkAgregar = value
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       frmSccSolicitudCheque_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSccSolicitudCheque_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsSolicitudCheque.Close()
            XdsSolicitudCheque = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       frmSccSolicitudCheque_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Solicitudes de Cheque en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccSolicitudCheque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            If ModoAcc = "ELA" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Registrar Solicitudes de Cheque")
            ElseIf ModoAcc = "REV" Then
                Me.HelpProvider.SetHelpKeyword(Me, "Revisión de Solicitudes de Cheque")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Autorización Solicitudes de Cheque")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'cdeFechaD.Value = FechaServer()
            'cdeFechaH.Value = cdeFechaD.Value

            InicializaVariables()
            StrCadena = " WHERE (a.nSccSolicitudChequeID = 0) " 'Al cargar Grid en Blanco
            CargarSolicitudCheque(StrCadena, 0)
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	10/03/2008
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
    ' Fecha:                12/11/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsSolicitudCheque = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los Grids, estructura y Datos:
            Me.grdSolicitud.ClearFields()
            Me.grdDetalles.ClearFields()

            'Determinar Parámetros de la Delegación del Usuario:
            EncuentraParametros()

            'Según usuario que accesa:
            If ModoAcc = "ELA" Then
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Enviar Solicitud a Contabilidad"
                Me.Text = "Registro de Solicitudes de Cheque"
            ElseIf ModoAcc = "REV" Then
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Revisar Solicitud"
                Me.Text = "Revisión de Solicitudes de Cheque"
            Else
                Me.tbSolicitud.Items("toolRevisar").ToolTipText = "Autorizar Solicitudes Revisadas por Contabilidad"
                Me.Text = "Autorización de Solicitudes de Cheque"
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
    ' Procedure Name:       CargarSolicitudCheque
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Grupos Solidarios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarSolicitudCheque(ByVal sCadenaFiltro As String, ByVal IntBit As Integer)
        Try
            Dim Strsql As String

            'Limpiar los Grids, estructura y Datos:
            Me.grdSolicitud.ClearFields()
            Me.grdDetalles.ClearFields()

            If Me.ModoAccion <> "REV" And Me.ModoAccion <> "AUT" Then

                If Me.TipoCheque = 1 Then 'Filtar para que no vean los cheques de egresos tipo solicitud cheque 3
                    If Trim(sCadenaFiltro) = "" Then
                        sCadenaFiltro = " where a.nSccTipoSolicitudChequeID<=2"
                    Else

                        sCadenaFiltro = sCadenaFiltro + " and a.nSccTipoSolicitudChequeID<=2"
                    End If

                Else
                    If Trim(sCadenaFiltro) = "" Then
                        sCadenaFiltro = " where a.nSccTipoSolicitudChequeID=3"
                    Else

                        sCadenaFiltro = sCadenaFiltro + " and a.nSccTipoSolicitudChequeID=3"
                    End If

                End If

            End If


            'Maestro (Solicitudes de Cheques):
            Strsql = " SELECT CAST(" & IntBit & " as bit) as Selected , a.* " & _
                     " FROM  vwSccSolicitudCheque as a " & sCadenaFiltro & _
                     " Order by nSccSolicitudChequeID " 'Option (Force Order)"

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

            'Detalle: Jornalización de Cuentas de la Solicitud:
            Strsql = " SELECT a.* " & _
                     " FROM vwSccSolicitudChequeDetalles as a " & sCadenaFiltro & _
                     " Order by nDebito desc, sCodigoCuenta "  'Option (Force Order)"
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

            If XdsSolicitudCheque.ExistRelation("SolicitudConDetalles") = False Then
                'Creando la relación entre el Primer Query y el Segundo:
                XdsSolicitudCheque.NewRelation("SolicitudConDetalles", "Solicitud", "Cuentas", "nSccSolicitudChequeID", "nSccSolicitudChequeID")
            End If
            XdsSolicitudCheque.SincronizarRelaciones()

            'Asignando a las fuentes de datos:
            Me.grdSolicitud.DataSource = XdsSolicitudCheque("Solicitud").Source
            REM REBIND
            Me.grdSolicitud.Rebind(False)

            Me.grdDetalles.DataSource = XdsSolicitudCheque("Cuentas").Source
            REM REBIND
            Me.grdDetalles.Rebind(False)

            'Actualizando el caption de los GRIDS:
            Me.grdSolicitud.Caption = " Listado de Solicitudes de Cheques (" + Me.grdSolicitud.RowCount.ToString + " registros)"
            Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
            FormatoSolicitudCheque()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       FormatoSolicitudCheque
    ' Descripción:          Este procedimiento permite configurar datos
    '                       sobre Solicitudes de Cheque en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoSolicitudCheque()
        Try
            Dim ContadorColumna As Integer
            'Configuracion del Grid Solicitudes de Cheques:
            Me.grdSolicitud.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSccTipoSolicitudChequeID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbPersonaBeneficiariaID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSccSolicitudDesembolsoCreditoID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbEstadoSolicitudID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("sCodigoInterno").Visible = False 'Estado Solicitud
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicita").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaRevision").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaAprobacion").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("CodGrupo").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nAutomatica").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdSolicitud.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False



            For ContadorColumna = 0 To Me.grdSolicitud.Splits(0).DisplayColumns.Count - 1
                Me.grdSolicitud.Splits(0).DisplayColumns(ContadorColumna).Locked = True
            Next

            Me.grdSolicitud.Splits(0).DisplayColumns("Selected").Locked = False

            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").Width = 160
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdSolicitud.Splits(0).DisplayColumns("TipoSolicitud").Width = 190
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicitudCheque").Width = 90
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaTipoCambio").Width = 90
            Me.grdSolicitud.Splits(0).DisplayColumns("Beneficiario").Width = 200
            Me.grdSolicitud.Splits(0).DisplayColumns("Cedula").Width = 110
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigoFNC").Width = 80
            Me.grdSolicitud.Splits(0).DisplayColumns("sNumSesion").Width = 80
            Me.grdSolicitud.Splits(0).DisplayColumns("NoCheque").Width = 180
            Me.grdSolicitud.Splits(0).DisplayColumns("NombreGrupo").Width = 150
            Me.grdSolicitud.Splits(0).DisplayColumns("nMonto").Width = 70
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").Width = 300
            Me.grdSolicitud.Splits(0).DisplayColumns("Fuente").Width = 200
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoSolicita").Width = 180
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoRevisa").Width = 180
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAprueba").Width = 180
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaCheque").Width = 90
            Me.grdSolicitud.Splits(0).DisplayColumns("nChequeCerrado").Width = 90

            Me.grdSolicitud.Columns("EstadoSolicitud").Caption = "Estado"
            Me.grdSolicitud.Columns("nCodigo").Caption = "Código"
            Me.grdSolicitud.Columns("TipoSolicitud").Caption = "Tipo Solicitud"
            Me.grdSolicitud.Columns("dFechaSolicitudCheque").Caption = "Fecha Solicitud"
            Me.grdSolicitud.Columns("dFechaTipoCambio").Caption = "Fecha T.C."
            Me.grdSolicitud.Columns("Beneficiario").Caption = "Beneficiario Cheque"
            Me.grdSolicitud.Columns("Cedula").Caption = "Número de Cédula"
            Me.grdSolicitud.Columns("sNumSesion").Caption = "No. Acta"
            Me.grdSolicitud.Columns("NoCheque").Caption = "Número de Cheque"
            Me.grdSolicitud.Columns("nCodigoFNC").Caption = "Código FNC"
            Me.grdSolicitud.Columns("NombreGrupo").Caption = "Grupo Solidario"
            Me.grdSolicitud.Columns("nMonto").Caption = "Monto (C$)"
            Me.grdSolicitud.Columns("sConceptoPago").Caption = "Concepto del Pago"
            Me.grdSolicitud.Columns("Fuente").Caption = "Fuente Fondos"
            Me.grdSolicitud.Columns("EmpleadoSolicita").Caption = "Solicitado Por"
            Me.grdSolicitud.Columns("EmpleadoRevisa").Caption = "Revisado Por"
            Me.grdSolicitud.Columns("EmpleadoAprueba").Caption = "Autorizado Por"
            Me.grdSolicitud.Columns("dFechaCheque").Caption = "Fecha Cheque"
            Me.grdSolicitud.Columns("nChequeCerrado").Caption = "Fecha Cerrada"

            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigoFNC").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("sNumSesion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicitudCheque").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaTipoCambio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaCheque").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nChequeCerrado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSolicitud.Splits(0).DisplayColumns("EstadoSolicitud").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("TipoSolicitud").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaSolicitudCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaTipoCambio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("Beneficiario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("Cedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("NoCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("sNumSesion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nCodigoFNC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("NombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nMonto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("sConceptoPago").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoSolicita").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoRevisa").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("EmpleadoAprueba").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("dFechaCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSolicitud.Splits(0).DisplayColumns("nChequeCerrado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSolicitud.Columns("nMonto").NumberFormat = "#,##0.00"
            Me.grdSolicitud.Columns("nChequeCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            'Configuracion del Grid Detalles de la Solicitud: 
            Me.grdDetalles.Splits(0).DisplayColumns("nSccSolicitudChequeDetalleID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nSccSolicitudChequeID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("dFechaSolicitudCheque").Visible = False

            Me.grdDetalles.Splits(0).DisplayColumns("NombreGrupo").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nCodigoFNC").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("nCodigo").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("Cedula").Visible = False
            Me.grdDetalles.Splits(0).DisplayColumns("sNumSesion").Visible = False

            Me.grdDetalles.Splits(0).DisplayColumns("sCodigoCuenta").Width = 200
            Me.grdDetalles.Splits(0).DisplayColumns("sNombreCuenta").Width = 480
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").Width = 80
            Me.grdDetalles.Splits(0).DisplayColumns("nMonto").Width = 110
            
            Me.grdDetalles.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.grdDetalles.Columns("sNombreCuenta").Caption = "Nombre Cuenta Contable"
            Me.grdDetalles.Columns("nDebito").Caption = "Débito"
            Me.grdDetalles.Columns("nMonto").Caption = "Monto (C$)"

            Me.grdDetalles.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Splits(0).DisplayColumns("nMonto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Debito como checkbox y centrado:
            Me.grdDetalles.Columns("nDebito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDetalles.Splits(0).DisplayColumns("nDebito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDetalles.Columns("nMonto").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       tbSolicitud_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSolicitud.
    '-------------------------------------------------------------------------
    Private Sub tbSolicitud_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSolicitud.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolCheck"
                LlamaCheck(1)
            Case "toolUnchek"
                LlamaCheck(0)
            Case "toolBuscar"
                LlamaBuscarSolicitudes()
            Case "toolAgregar"
                LlamaAgregarSolicitud()
            Case "toolModificar"
                LlamaModificarSolicitud()
            Case "toolAnular"
                LlamaAnularSolicitud()
            Case "toolRevisar" 'autoriza las solicitudes de cheque
                LlamaRevisarSolicitud()
            Case "toolGenerarCK"
                LlamaGenerarCheques()
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
            Case "toolActualizarConcepto"
                LlamaActualizarConcepto()

            Case "toolActualizarFecha"
                LlamaModificarFecha()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaGenerarChecked()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim intPeriodoId As Integer
            Dim ContadorFilas As Integer
            Dim StrSql As String
            Dim Posicion As Long
            Dim Procesados As Integer
            Dim Generar As Boolean


            Dim nNumeroCk As Integer
            Dim nCuentaBancariaID As Integer
            Dim sNumeroCuenta As String

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Generar Comprobantes Contables para los cheques seleccionados." & Chr(13) & " y que esten en Autorizadas ?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If
            Procesados = 0
            Posicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")

            grdSolicitud.MoveFirst()
            For ContadorFilas = 0 To grdSolicitud.RowCount
                If XdsSolicitudCheque("Solicitud").ValueField("Selected") Then
                    Generar = True

                    'StrSql = "SELECT     nSccNotaID, nSccSolicitudChequeID, sCodigoInterno  FROM         dbo.vwSccNotaCreditoDebito  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
                    'XcDatos.ExecuteSql(StrSql)
                    'If XcDatos.ValueField("sCodigoInterno") = "5" Or XcDatos.ValueField("sCodigoInterno") = "4" Or XcDatos.ValueField("sCodigoInterno") = "2" Or XcDatos.ValueField("sCodigoInterno") = "1" Then
                    '    Generar = False
                    'End If
                    ''If XcDatos.ValueField("sCodigoInterno") = "4" Then
                    ''    MsgBox("La Nota ya tiene generada partida contable.", MsgBoxStyle.Information)
                    ''    Exit Sub
                    ''End If
                    ''If XcDatos.ValueField("sCodigoInterno") = "2" Then
                    ''    MsgBox("La Nota se encuentra Revisada no Autorizada.", MsgBoxStyle.Information)
                    ''    Exit Sub
                    ''End If

                    ''If XcDatos.ValueField("sCodigoInterno") = "1" Then
                    ''    MsgBox("La Nota se encuentra en Proceso no Autorizada.", MsgBoxStyle.Information)
                    ''    Exit Sub
                    ''End If
                    ''Debe tener las cuentas contables asociadas
                    'If Generar = True Then
                    '    StrSql = "SELECT     nSccNotaID FROM         dbo.vwSccNotaCreditoDebitoDetalles  WHERE     (nSccNotaID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccNotaID") & " )"
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

                    'If Generar = True Then
                    '    '-- Poner el cursor en estado ocupado
                    '    Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                    '    InsertarNotaVarias(XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), TipoNota(XdsSolicitudCheque("Solicitud").ValueField("nMonto")))

                    '    Procesados = Procesados + 1
                    'End If

                    'Si NO tiene permisos de Edición fuera de su Delegación: 
                    If IntPermiteEditar = 0 Then
                        If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                            Generar = False
                        End If
                    End If

                    'Imposible si no es el Area Contable:
                    If ModoAcc <> "REV" And Generar = True Then
                        Generar = False
                    End If

                    '-- Imposible si ya se genero el Cheque:
                    If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) And Generar = True Then
                        Generar = False
                    End If
                    If Generar = True Then
                        StrSql = "SELECT C.sDescripcion " & _
                                 "FROM  SccSolicitudCheque S INNER JOIN StbValorCatalogo C ON S.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                                 "WHERE (C.sCodigoInterno = '6') AND (S.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                        If RegistrosAsociados(StrSql) Then
                            Generar = False
                        End If
                    End If
                    '-- Imposible si la Solicitud no se encuentra Autorizada:
                    If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 4) And Generar = True Then
                        Generar = False
                    End If
                    If Generar = True Then
                        StrSql = "SELECT C.sDescripcion " & _
                                 "FROM  SccSolicitudCheque S INNER JOIN StbValorCatalogo C ON S.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                                 "WHERE (C.sCodigoInterno = '4') AND (S.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                        If RegistrosAsociados(StrSql) = False Then
                            Generar = False
                        End If
                    End If
                    If Generar = True Then
                        '-- Imposible si no existe Periodo registrado para la Fecha de la Solicitud de Cheque:
                        intPeriodoId = IDPeriodo(XdsSolicitudCheque("Solicitud").ValueField("dFechaSolicitudCheque"))
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
                        REM 
                        '-- Imposible si se creará Sobregiro en las Cuentas indicadas:
                        StrSql = "SELECT c.nScnCatalogoContableID " & _
                                 "FROM SccSolicitudChequeDetalle AS d INNER JOIN ScnCatalogoContable AS c ON d.nScnCatalogoContableID = c.nScnCatalogoContableID " & _
                                 "WHERE (d.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0) AND (c.nSteCuentaBancariaID IS NOT NULL)"
                        If nMontoSaldoRojo(XcDatos.ExecuteScalar(StrSql), 0, XdsSolicitudCheque("Solicitud").ValueField("nMonto")) < 0 Then
                            Generar = False
                        End If

                    End If
                    If Generar = True Then
                        REM ******************************************************************
                        'Imposible si Tesorería no ha cerrado el Cheque:
                        StrSql = "SELECT  nSccSolicitudChequeID FROM SccSolicitudCheque " & _
                                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
                        If RegistrosAsociados(StrSql) = False Then
                            Generar = False
                        End If
                    End If

                    If Generar = True Then
                        'Imposible si Tesorería no ha indicado el número de la Chequera:
                        StrSql = "SELECT  nNumeroCheque FROM SccSolicitudCheque " & _
                                 "WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NOT NULL)"
                        If RegistrosAsociados(StrSql) = False Then
                            Generar = False
                        End If
                    End If
                    If Generar = True Then
                        'Encuentra Número de Ck asignado por Tesorería:
                        nNumeroCk = XcDatos.ExecuteScalar(StrSql)

                        'Imposible si Tesorería lo tiene marcado para impresión:
                        'Si se permite esto la Solicitud desaparece de la pantalla de impresion de chequera pues
                        'pasa al estado Autorizado con Ck Emitido y el registro nunca se limpiaria de la tabla
                        'de impresion SteImpresionCheque.
                        StrSql = "SELECT SsgCuenta.Login " & _
                                 "FROM  SteImpresionCheque INNER JOIN SsgCuenta ON SteImpresionCheque.nUsuarioCreacionID = SsgCuenta.SsgCuentaID " & _
                                 "WHERE (SteImpresionCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                        If RegistrosAsociados(StrSql) Then
                            Generar = False
                        End If
                    End If
                    If Generar = True Then
                        'Imposible si no existe cuenta bancaria corriente como credito en el detalle de la Solicitud de Cheque:
                        StrSql = "SELECT a.nSteCuentaBancariaID " & _
                                 "FROM SteCuentaBancaria AS a INNER JOIN StbValorCatalogo AS b ON a.nStbTipoCuentaID = b.nStbValorCatalogoID INNER JOIN dbo.ScnCatalogoContable AS c ON a.nSteCuentaBancariaID = c.nSteCuentaBancariaID INNER JOIN SccSolicitudChequeDetalle AS d ON c.nScnCatalogoContableID = d.nScnCatalogoContableID " & _
                                 "WHERE (b.sCodigoInterno = '2') AND (d.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0)"
                        If RegistrosAsociados(StrSql) = False Then
                            Generar = False
                        End If
                    End If
                    If Generar = True Then
                        'Encuentra ID de la Cuenta Bancaria:
                        nCuentaBancariaID = XcDatos.ExecuteScalar(StrSql)

                        'Encuentra Numero de Cheque (Numero de Cuenta Bancaria + Numero Chequera):
                        StrSql = "SELECT a.sNumeroCuenta " & _
                                 "FROM SteCuentaBancaria AS a INNER JOIN StbValorCatalogo AS b ON a.nStbTipoCuentaID = b.nStbValorCatalogoID INNER JOIN dbo.ScnCatalogoContable AS c ON a.nSteCuentaBancariaID = c.nSteCuentaBancariaID INNER JOIN SccSolicitudChequeDetalle AS d ON c.nScnCatalogoContableID = d.nScnCatalogoContableID " & _
                                 "WHERE (b.sCodigoInterno = '2') AND (d.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0)"
                        sNumeroCuenta = XcDatos.ExecuteScalar(StrSql) & nNumeroCk

                        'Imposible si cheque a asignar creará un comprobante de cheque ACTIVO duplicado para la Cuenta Bancaria:
                        StrSql = "SELECT nScnTransaccionContableID " & _
                                 "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                                 "WHERE (sNumeroTransaccion = '" & sNumeroCuenta & "') AND (StbValorCatalogo.sCodigoInterno <> '3')"
                        If RegistrosAsociados(StrSql) Then
                            Generar = False
                        End If
                    End If
                    REM ******************************************************************

                    'If MsgBox("¿Está seguro de Generar el Comprobante de Egreso?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    '    Exit Sub
                    'End If

                    '-- Poner el cursor en estado ocupado
                    If Generar = True Then
                        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                        '-- En caso de Solicitudes de Cheque a Socias (TipoSolicitudId = 1) Genera Documento (CK):
                        ' (SIEMPRE: En caso de Anularse el CK la solicitud regresará a Autorizada).
                        If XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1 Then
                            InsertarChequeVarios(XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), "CK", sNumeroCuenta)
                        Else
                            '-- Si no es Solicitud de Cheque a Socias sólo se genera un Cheque individual
                            '-- con los datos de la Solicitud actual.
                            InsertarChequeVarios(XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), "CE", sNumeroCuenta)
                        End If
                        '-- Poner el cursor en un estado de desocupado
                        Me.Cursor = System.Windows.Forms.Cursors.Default
                        Procesados = Procesados + 1
                    End If
                End If
                grdSolicitud.MoveNext()
            Next



            If Procesados > 0 Then
                MsgBox("Se generaron un total de ." & Procesados.ToString().Trim() & " Comprobantes Contables.", MsgBoxStyle.Information)
                CargarSolicitudCheque(StrCadena, 0)
            Else
                MsgBox("No Se generaron Comprobantes Contables.", MsgBoxStyle.Information)
            End If



            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", Posicion)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position







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

    Private Sub LlamaCheck(ByVal Band As Integer)

        Dim Posicion As Long
        Try

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Notas registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM InicializaVariables()
            Posicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudCheque(StrCadena, Band)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", Posicion)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    ObjFrmScnEditSCK.Close()
            '    ObjFrmScnEditSCK = Nothing
        End Try
    End Sub
    Private Sub LlamaActualizarConcepto()
        Dim StrSql As String
        Dim XdtTmpBusqueda As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Dim CodProcedimiento As Integer
        Dim intPosicion As Integer
        Try
            XdtTmpBusqueda = New BOSistema.Win.XDataSet.xDataTable
            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            StrSql = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion, dbo.SccSolicitudCheque.nSccSolicitudChequeID,dbo.SclFichaNotificacionCredito.dFechaPrimerCuota, StbValorCatalogo_1.sCodigoInterno AS sCodigoInternoEstadoCheque  " & _
      "FROM         dbo.SccSolicitudCheque INNER JOIN " & _
    " dbo.SccSolicitudDesembolsoCredito ON " & _
                         " dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                         " dbo.SclFichaNotificacionDetalle ON  " & _
                         " dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN " & _
                         " dbo.SclFichaNotificacionCredito ON  " & _
                         " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
                         " dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN " & _
                         " dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                         " INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo_1.nStbValorCatalogoID " & _
            " WHERE(dbo.SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            XdtTmpBusqueda.ExecuteSql(StrSql)

            If XdtTmpBusqueda.ValueField("sCodigoInterno") <> "3" And XdtTmpBusqueda.ValueField("sCodigoInterno") <> "5" Then
                MsgBox("Solo se permite actualizar el Concepto de Pago para ficha en estado aprobado o verificado ", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Convert.tod()

            If XdtTmpBusqueda.ValueField("sCodigoInternoEstadoCheque") = "5" Then
                MsgBox("Solo se permite actualizar el Concepto de Pago para Solicitudes de Cheques que no esten Anulados ", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (DateDiff("d", Format(FechaServer.Date, "yyyy-MM-dd"), Format(XdtTmpBusqueda.ValueField("dFechaPrimerCuota"), "yyyy-MM-dd")) < 1) Then
                MsgBox("Solo se permite actualizar el Concepto de Pago para ficha con fecha de primer cuota menor o igual a la fecha actual", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Anulación:
            If MsgBox("¿Está seguro de Actualizar el Concepto de pago de la Solicitud de Cheque Numero " & XdsSolicitudCheque("Solicitud").ValueField("NoCheque") & Chr(13) & "A Nombre de : " & XdsSolicitudCheque("Solicitud").ValueField("Beneficiario"), MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If


            GuardarAuditoriaTablas(1, 2, "Actualizar Concepto Cheque", XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)

            StrSql = " EXEC spSccActualizaConceptoCheque  " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            CodProcedimiento = XcDatos.ExecuteScalar(StrSql)

            If CodProcedimiento = 1 Then
                MsgBox("Se ha actualizado el concepto de pago del cheque satisfactoriamente", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
                CargarSolicitudCheque(StrCadena, 0)

                'Ubicar la selección en la posición original:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            Else
                MsgBox("Ocurrio un error en el procedimiento de actualizacion de concepto de cheque spSccActualizaConceptoCheque", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       LlamaRevisarSolicitud
    ' Descripción:          Este procedimiento permite Revisar una Solicitud
    '                       de Cheque.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevisarSolicitud()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            Dim intPosicion As Integer
            Dim intIdEmpleado As Integer

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si es el Area Solicitante: La Solicitud DEBE encontrarse En Proceso
            'y pasará al Estado Enviada a Contabilidad.
            If ModoAcc = "ELA" Then
                If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 1) Then
                    MsgBox("La Solicitud NO se encuentra En Proceso.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                StrSql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE  (StbValorCatalogo.sCodigoInterno = '1') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("La Solicitud NO se encuentra En Proceso.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If MsgBox("¿Está seguro de Enviar la Solicitud a Contabilidad?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            'Si es el Area que Revisa (Contabilidad): La Solicitud DEBE encontrarse Enviada a Contabilidad, con la codificación de cuentas generada.
            'y pasará al Estado: Revisada por Contabilidad
            If ModoAcc = "REV" Then
                'La Solicitud NO se encuentra Enviada a Contabilidad:
                If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 2) Then
                    MsgBox("La Solicitud NO se encuentra como Enviada a Contabilidad.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                StrSql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE  (StbValorCatalogo.sCodigoInterno = '2') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("La Solicitud NO se encuentra como Enviada a Contabilidad.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'No existen Cuentas en el Detalle:
                If Me.grdDetalles.RowCount = 0 Then
                    MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Los detalles de cuentas Contables deben estar cuadrados por Partida Doble:
                StrSql = "SELECT a.Debe - a.Haber AS Partida " & _
                         "FROM (SELECT SUM(CASE nDebito WHEN 1 THEN nMonto ELSE 0 END) AS Debe, SUM(CASE nDebito WHEN 0 THEN nMonto ELSE 0 END) AS Haber " & _
                               "FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")) a"
                If XcDatos.ExecuteScalar(StrSql) <> 0 Then
                    MsgBox("La Solicitud NO se encuentra cuadrada" & Chr(13) & "en movimientos deudores y acreedores.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'La sumatoria de montos deudores debe corresponder con el Total de la Solicitud:
                StrSql = "SELECT SUM(nMonto) AS Monto FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nDebito = 1)"
                Dim nMontoDebito,nMontoCredito As Double
                nMontoDebito = XcDatos.ExecuteScalar(StrSql)
                If nMontoDebito <> XdsSolicitudCheque("Solicitud").ValueField("nMonto") And (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1 Or XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 2) Then

                    MsgBox("Los movimientos contables no coinciden con el" & Chr(13) & "monto total de la Solicitud (C$ " & XdsSolicitudCheque("Solicitud").ValueField("nMonto") & ").", MsgBoxStyle.Information)
                    Exit Sub
                End If


                If XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 3 Then
                    StrSql = "SELECT SUM(nMonto) AS Monto FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nDebito = 0)"
                    nMontoCredito = XcDatos.ExecuteScalar(StrSql)
                    If nMontoDebito <> nMontoCredito Then
                        MsgBox("Los movimientos contables no estan balanceados en debito credito", MsgBoxStyle.Information)
                        Exit Sub
                    End If


                End If



                'Debe existir una Cuenta de Bancos (Corriente) como crédito en la Solicitud:
                StrSql = "SELECT  ScnCatalogoContable.nSteCuentaBancariaID " & _
                         "FROM SccSolicitudChequeDetalle INNER JOIN ScnCatalogoContable ON SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID INNER JOIN SteCuentaBancaria ON ScnCatalogoContable.nSteCuentaBancariaID = SteCuentaBancaria.nSteCuentaBancariaID INNER JOIN StbValorCatalogo ON SteCuentaBancaria.nStbTipoCuentaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SccSolicitudChequeDetalle.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (ScnCatalogoContable.nSteCuentaBancariaID IS NOT NULL) AND (SccSolicitudChequeDetalle.nDebito = 0) AND (StbValorCatalogo.sCodigoInterno = '2')"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("No existe Cuenta Bancaria Corriente como movimiento" & Chr(13) & "acreedor en la Solicitud.", MsgBoxStyle.Information)
                    Exit Sub
                End If


                'Confirmar:
                If MsgBox("¿Está seguro de dar por Revisada la Solicitud?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            'Si es el Area que Autoriza: La Solicitud DEBE encontrarse Revisada por Contabilidad
            'y pasará al estado Autorizada: Todas las Solicitudes Revisadas por Contabilidad se
            'autorizan de manera masiva:
            If ModoAcc = "AUT" Then
                'No existen Solicitudes revisadas por Contabilidad:
                StrSql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM    SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE  (StbValorCatalogo.sCodigoInterno = '3')"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("No existen Solicitudes Revisadas por Contabilidad.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'No existen Cuentas en al menos una Solicitud Revisada por Contabilidad:
                StrSql = "SELECT StbValorCatalogo.sCodigoInterno " & _
                         "FROM  SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (NOT (SccSolicitudCheque.nSccSolicitudChequeID IN (SELECT nSccSolicitudChequeID FROM SccSolicitudChequeDetalle)))"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Solicitudes Revisadas por Contabilidad" & Chr(13) & "sin detalles de Codificación Contable.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Los detalles de cuentas Contables no estan cuadrados por Partida Doble en
                'al menos una Solicitud Revisada por Contabilidad.
                StrSql = "SELECT ISNULL(Debe, 0) - ISNULL(Haber, 0) AS Partida " & _
                         "FROM   (SELECT  SUM(CASE nDebito WHEN 1 THEN SccSolicitudChequeDetalle.nMonto ELSE 0 END) AS Debe, SUM(CASE nDebito WHEN 0 THEN SccSolicitudChequeDetalle.nMonto ELSE 0 END) AS Haber " & _
                         "FROM  SccSolicitudChequeDetalle INNER JOIN SccSolicitudCheque ON SccSolicitudChequeDetalle.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '3')) AS a WHERE (ISNULL(Debe, 0) - ISNULL(Haber, 0) <> 0)"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Solicitudes NO cuadradas en" & Chr(13) & "movimientos deudores y acreedores.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'La sumatoria de montos deudores NO corresponde con el Total de la Solicitud
                'en al menos una Solicitud Revisada por Contabilidad:
                StrSql = "SELECT a.Monto - SCK.nMonto AS Partida " & _
                         "FROM  (SELECT  SUM(SccSolicitudChequeDetalle.nMonto) AS Monto, SccSolicitudChequeDetalle.nSccSolicitudChequeID " & _
                         "FROM SccSolicitudChequeDetalle INNER JOIN SccSolicitudCheque ON SccSolicitudChequeDetalle.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SccSolicitudChequeDetalle.nDebito = 1) AND (StbValorCatalogo.sCodigoInterno = '3') GROUP BY SccSolicitudChequeDetalle.nSccSolicitudChequeID) AS a INNER JOIN SccSolicitudCheque AS SCK ON a.nSccSolicitudChequeID = SCK.nSccSolicitudChequeID WHERE (a.Monto - SCK.nMonto <> 0) AND (SCK.nSccTipoSolicitudChequeID = 1 OR  SCK.nSccTipoSolicitudChequeID = 2)"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Solicitudes con movimientos que NO coinciden con el" & Chr(13) & "monto total de la Solicitud.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Existe al menos una Solicitud Revisada por Contabilidad (Del tipo Cheque a Socia) 
                'que NO tiene una Cuenta de Bancos (Corriente) como crédito:
                StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM  SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE  (StbValorCatalogo.sCodigoInterno = '3') AND (NOT (SccSolicitudCheque.nSccSolicitudChequeID IN " & _
                         "(SELECT DSCK.nSccSolicitudChequeID FROM SccSolicitudChequeDetalle AS DSCK INNER JOIN ScnCatalogoContable AS C ON DSCK.nScnCatalogoContableID = C.nScnCatalogoContableID INNER JOIN " & _
                         "SccSolicitudCheque AS SCK ON DSCK.nSccSolicitudChequeID = SCK.nSccSolicitudChequeID INNER JOIN StbValorCatalogo AS Catalogo ON SCK.nStbEstadoSolicitudID = Catalogo.nStbValorCatalogoID INNER JOIN " & _
                         "SteCuentaBancaria AS CTAB ON C.nSteCuentaBancariaID = CTAB.nSteCuentaBancariaID INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON CTAB.nStbTipoCuentaID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                         "WHERE (C.nSteCuentaBancariaID IS NOT NULL) AND (DSCK.nDebito = 0) AND (Catalogo.sCodigoInterno = '3') AND (StbValorCatalogo_1.sCodigoInterno = '2'))))"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Solicitudes SIN Cuenta Bancaria Corriente" & Chr(13) & "como movimiento acreedor.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Confirmar Autorización:
                If MsgBox("¿Está seguro de Autorizar TODAS las Solicitudes Revisadas por Contabilidad?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            intIdEmpleado = XcDatos.ExecuteScalar("SELECT objEmpleadoID FROM SsgCuenta WHERE (SsgCuentaID = " & InfoSistema.IDCuenta & ")")
            'Autoriza todas las Solicitudes que se encuentran Revisadas por Contabilidad:
            If ModoAcc = "AUT" Then
                'StrSql = " Update SccSolicitudCheque " & _
                '         " SET nSrhEmpleadoApruebaID = " & intIdEmpleado & ", dFechaAprobacion = getdate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '4' And b.sNombre = 'EstadoSolicitudCheque')" & _
                '         " WHERE nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoSolicitudCheque')"

                StrSql = "Exec SpAUDITSccSolicitudChequeAUTORIZA 'Update','Actualizar  Autorizar Solicitud Revisada por Contabilidad'," & intIdEmpleado & "," & InfoSistema.IDCuenta & ",1"
                '-- Revisa la Solicitud Actual:
            ElseIf ModoAcc = "REV" Then
                GuardarAuditoriaTablas(1, 2, "Actualizar Solicitud Revisada por Contabilidad", XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)
                StrSql = " Update SccSolicitudCheque " & _
                         " SET nSrhEmpleadoRevisaID = " & intIdEmpleado & ", dFechaRevision = getdate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoSolicitudCheque')" & _
                         " WHERE nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            Else '-- Enviar a Contabilidad:

                GuardarAuditoriaTablas(1, 2, "Actualizar Solicitud Cheque Envio a Contabilidad", XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)

                StrSql = " Update SccSolicitudCheque " & _
                         " SET dFechaSolicita = getdate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoSolicitudCheque')" & _
                         " WHERE nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            End If
            XcDatos.ExecuteNonQuery(StrSql)

            'Almacena Pista de Auditoría:
            If ModoAcc = "AUT" Then
                MsgBox("Solicitud(es) de Cheque(s) Autorizada(s) Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(4, 23, "Autorización de Solicitudes Revisadas por Contabilidad.")
            Else
                MsgBox("Solicitud de Cheque Revisada Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(4, 23, "Revisión de Solicitud de Cheque: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
            End If

            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudCheque(StrCadena, 0)

            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/11/2007
    ' Procedure Name:       LlamaGenerarCheques
    ' Descripción:          Este procedimiento permite Generar Cheques de la
    '                       Solicitud de Desembolso asociada a la Solicitud de
    '                       Cheque actual. El Cheque además se mayoriza en Saldos.
    '-------------------------------------------------------------------------
    Private Sub LlamaGenerarCheques()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim intPeriodoId As Integer

            Dim nNumeroCk As Integer
            Dim nCuentaBancariaID As Integer
            Dim sNumeroCuenta As String

            Dim StrSql As String

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si no es el Area Contable:
            If ModoAcc <> "REV" Then
                MsgBox("Unicamente el área Contable puede generar Cheques.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si ya se genero el Cheque:
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) Then
                MsgBox("Ya se generó el Comprobante para esta Solicitud.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT C.sDescripcion " & _
                     "FROM  SccSolicitudCheque S INNER JOIN StbValorCatalogo C ON S.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '6') AND (S.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Ya se generó el Comprobante para esta Solicitud.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si la Solicitud no se encuentra Autorizada:
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 4) Then
                MsgBox("La Solicitud no se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT C.sDescripcion " & _
                     "FROM  SccSolicitudCheque S INNER JOIN StbValorCatalogo C ON S.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '4') AND (S.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("La Solicitud no se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si no existe Periodo registrado para la Fecha de la Solicitud de Cheque:
            intPeriodoId = IDPeriodo(XdsSolicitudCheque("Solicitud").ValueField("dFechaSolicitudCheque"))
            If intPeriodoId = 0 Then
                MsgBox("No existe un período Contable creado para" & Chr(13) & "la fecha de la Solicitud de Cheque.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Imposible si el Periodo se encuentra Cerrado:
            If PeriodoAbierto(intPeriodoId) = False Then
                MsgBox("El período Contable correspondiente a la fecha de la" & Chr(13) & "Solicitud de Cheque se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM 
            '-- Imposible si se creará Sobregiro en las Cuentas indicadas:
            StrSql = "SELECT c.nScnCatalogoContableID " & _
                     "FROM SccSolicitudChequeDetalle AS d INNER JOIN ScnCatalogoContable AS c ON d.nScnCatalogoContableID = c.nScnCatalogoContableID " & _
                     "WHERE (d.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0) AND (c.nSteCuentaBancariaID IS NOT NULL)"
            If nMontoSaldoRojo(XcDatos.ExecuteScalar(StrSql), 0, XdsSolicitudCheque("Solicitud").ValueField("nMonto")) < 0 Then
                MsgBox("El movimiento crearía sobregiro bancario.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If


            REM ******************************************************************
            'Imposible si Tesorería no ha cerrado el Cheque:
            StrSql = "SELECT  nSccSolicitudChequeID FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nChequeCerrado = 1)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("Tesorería aún no ha Aplicado Solicitud de Cheque.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si Tesorería no ha indicado el número de la Chequera:
            StrSql = "SELECT  nNumeroCheque FROM SccSolicitudCheque " & _
                     "WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (nNumeroCheque IS NOT NULL)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("Aún no ha sido asignado el número de cheque por Tesorería.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Encuentra Número de Ck asignado por Tesorería:
            nNumeroCk = XcDatos.ExecuteScalar(StrSql)

            'Imposible si Tesorería lo tiene marcado para impresión:
            'Si se permite esto la Solicitud desaparece de la pantalla de impresion de chequera pues
            'pasa al estado Autorizado con Ck Emitido y el registro nunca se limpiaria de la tabla
            'de impresion SteImpresionCheque.
            StrSql = "SELECT SsgCuenta.Login " & _
                     "FROM  SteImpresionCheque INNER JOIN SsgCuenta ON SteImpresionCheque.nUsuarioCreacionID = SsgCuenta.SsgCuentaID " & _
                     "WHERE (SteImpresionCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible generar Comprobante de Cheque." & Chr(13) & Chr(13) & "Solicitud de cheque aún se encuentra Marcada para" & Chr(13) & "Impresión por el usuario: " & XcDatos.ExecuteScalar(StrSql) & ".", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si no existe cuenta bancaria corriente como credito en el detalle de la Solicitud de Cheque:
            StrSql = "SELECT a.nSteCuentaBancariaID " & _
                     "FROM SteCuentaBancaria AS a INNER JOIN StbValorCatalogo AS b ON a.nStbTipoCuentaID = b.nStbValorCatalogoID INNER JOIN dbo.ScnCatalogoContable AS c ON a.nSteCuentaBancariaID = c.nSteCuentaBancariaID INNER JOIN SccSolicitudChequeDetalle AS d ON c.nScnCatalogoContableID = d.nScnCatalogoContableID " & _
                     "WHERE (b.sCodigoInterno = '2') AND (d.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0)"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existe crédito a cuenta bancaria corriente.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Encuentra ID de la Cuenta Bancaria:
            nCuentaBancariaID = XcDatos.ExecuteScalar(StrSql)

            'Encuentra Numero de Cheque (Numero de Cuenta Bancaria + Numero Chequera):
            StrSql = "SELECT a.sNumeroCuenta " & _
                     "FROM SteCuentaBancaria AS a INNER JOIN StbValorCatalogo AS b ON a.nStbTipoCuentaID = b.nStbValorCatalogoID INNER JOIN dbo.ScnCatalogoContable AS c ON a.nSteCuentaBancariaID = c.nSteCuentaBancariaID INNER JOIN SccSolicitudChequeDetalle AS d ON c.nScnCatalogoContableID = d.nScnCatalogoContableID " & _
                     "WHERE (b.sCodigoInterno = '2') AND (d.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (d.nDebito = 0)"
            sNumeroCuenta = XcDatos.ExecuteScalar(StrSql) & nNumeroCk

            'Imposible si cheque a asignar creará un comprobante de cheque ACTIVO duplicado para la Cuenta Bancaria:
            StrSql = "SELECT nScnTransaccionContableID " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (sNumeroTransaccion = '" & sNumeroCuenta & "') AND (StbValorCatalogo.sCodigoInterno <> '3')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El Número de Cheque asignado por Tesorería ya existe para la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If
            REM ******************************************************************

            If MsgBox("¿Está seguro de Generar el Comprobante de Egreso?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- Poner el cursor en estado ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            '-- En caso de Solicitudes de Cheque a Socias (TipoSolicitudId = 1) Genera Documento (CK):
            ' (SIEMPRE: En caso de Anularse el CK la solicitud regresará a Autorizada).
            If XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1 Then
                InsertarCheque(XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), "CK", sNumeroCuenta)
            Else
                '-- Si no es Solicitud de Cheque a Socias sólo se genera un Cheque individual
                '-- con los datos de la Solicitud actual.
                '--InsertarCheque(XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), "CE", sNumeroCuenta)
                'Cambio hecho 4 de septiembre del 2014 para CK los cheques de delegadas y pagos a proveedores
                InsertarCheque(XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), "CE", sNumeroCuenta)


            End If
            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub InsertarChequeVarios(ByVal IdSolicitudCK As Long, ByVal StrTipoDoc As String, ByVal StrNumeroCheque As String)
        Dim XdtTmpParametros As BOSistema.Win.XDataSet.xDataTable
        XdtTmpParametros = New BOSistema.Win.XDataSet.xDataTable

        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim StrSql As String
            Dim intPosicion As Integer
            Dim ComprobanteId As Long

            '-- Para generación de un único Cheque de la Solicitud Actual:
            If StrTipoDoc = "CE" Then
                StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
                         "FROM   SccSolicitudCheque " & _
                         "WHERE  (nSccSolicitudChequeID = " & IdSolicitudCK & ")"
            Else
                StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, 0 as nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
                         "FROM   SccSolicitudCheque " & _
                         "WHERE  (nSccSolicitudChequeID = " & IdSolicitudCK & ")"
            End If
            XdtTmpParametros.ExecuteSql(StrSql)

            'Agregar bitacora de tabla solicitud cheque
            GuardarAuditoriaTablas(1, 2, "Actualizar Generar Comprobante Contable Solicitud Cheque", XdtTmpParametros.ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)

            '---------------------------
            '-- 1. Insertar Encabezado de Comprobante para la Solicitud de Cheque Actual:
            '-- 2. Insertar Detalles del Comprobante  para la Solicitud de Cheque Actual:
            '-- 3. Actualiza Estado de Solicitud a "Autorizada con Cheque Emitido":
            '-- 4. Mayoriza el Comprobante en Saldos.
            'Comprobante se genera con la Fecha de la Solicitud de Cheque 07/04/2008:
            StrSql = " EXEC spSccGenerarComprobanteCK " & XdtTmpParametros.ValueField("nSccSolicitudChequeID") & "," & XdtTmpParametros.ValueField("nScnFuenteFinanciamientoID") & ", " & XdtTmpParametros.ValueField("nStbDelegacionProgramaID") & ", '" _
                     & Trim(RTrim(XdtTmpParametros.ValueField("sConceptoPago"))) & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "'," _
                     & XdtTmpParametros.ValueField("nStbPersonaBeneficiariaID") & "," & InfoSistema.IDCuenta & ", '" & StrTipoDoc & "', '" & StrNumeroCheque & "'"
            ComprobanteId = XcDatos.ExecuteScalar(StrSql)
            '--------------------------------------------


            'If ComprobanteId = 0 Then
            '    MsgBox("El Comprobante de cheque NO pudo generarse.", MsgBoxStyle.Information, NombreSistema)
            'Else
            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Generación automática de Comprobante de Cheque. Solicitud de Cheque No.: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
            ''Guardar posición actual de la selección:
            'intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            'CargarSolicitudCheque(StrCadena, 0)
            ''Ubicar la selección en la posición original:
            'XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            'Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            ''Indicar generación exitosa
            'MsgBox("Comprobante de cheque generado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
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
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/11/2007
    ' Procedure Name:       InsertarCheque
    ' Descripción:          Este procedimiento permite insertar Cheques y 
    '                       mayorizar los mismos sobre los saldos contables. 
    '-------------------------------------------------------------------------
    Private Sub InsertarCheque(ByVal IdSolicitudCK As Long, ByVal StrTipoDoc As String, ByVal StrNumeroCheque As String)
        Dim XdtTmpParametros As BOSistema.Win.XDataSet.xDataTable
        XdtTmpParametros = New BOSistema.Win.XDataSet.xDataTable

        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim StrSql As String
            Dim intPosicion As Integer
            Dim ComprobanteId As Long

            '-- Para generación de un único Cheque de la Solicitud Actual:
            If StrTipoDoc = "CE" Then
                StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
                         "FROM   SccSolicitudCheque " & _
                         "WHERE  (nSccSolicitudChequeID = " & IdSolicitudCK & ")"
            Else
                StrSql = "SELECT nSccSolicitudChequeID, nScnFuenteFinanciamientoID, 0 as nStbPersonaBeneficiariaID, dFechaSolicitudCheque, dFechaTipoCambio, sConceptoPago, nStbDelegacionProgramaID " & _
                         "FROM   SccSolicitudCheque " & _
                         "WHERE  (nSccSolicitudChequeID = " & IdSolicitudCK & ")"
            End If
            XdtTmpParametros.ExecuteSql(StrSql)



            'Agregar bitacora de tabla solicitud cheque
            GuardarAuditoriaTablas(1, 2, "Actualizar Generar Comprobante Contable Solicitud Cheque", XdtTmpParametros.ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)

            '---------------------------
            '-- 1. Insertar Encabezado de Comprobante para la Solicitud de Cheque Actual:
            '-- 2. Insertar Detalles del Comprobante  para la Solicitud de Cheque Actual:
            '-- 3. Actualiza Estado de Solicitud a "Autorizada con Cheque Emitido":
            '-- 4. Mayoriza el Comprobante en Saldos.
            'Comprobante se genera con la Fecha de la Solicitud de Cheque 07/04/2008:
            StrSql = " EXEC spSccGenerarComprobanteCK " & XdtTmpParametros.ValueField("nSccSolicitudChequeID") & "," & XdtTmpParametros.ValueField("nScnFuenteFinanciamientoID") & ", " & XdtTmpParametros.ValueField("nStbDelegacionProgramaID") & ", '" _
                     & Trim(RTrim(XdtTmpParametros.ValueField("sConceptoPago"))) & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "','" & Format(XdtTmpParametros.ValueField("dFechaSolicitudCheque"), "yyyy-MM-dd") & "'," _
                     & XdtTmpParametros.ValueField("nStbPersonaBeneficiariaID") & "," & InfoSistema.IDCuenta & ", '" & StrTipoDoc & "', '" & StrNumeroCheque & "'"
            ComprobanteId = XcDatos.ExecuteScalar(StrSql)
            '--------------------------------------------

            If ComprobanteId = 0 Then
                MsgBox("El Comprobante de cheque NO pudo generarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                'Almacena Pista de Auditoría:
                Call GuardarAuditoria(4, 23, "Generación automática de Comprobante de Cheque. Solicitud de Cheque No.: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
                'Guardar posición actual de la selección:
                intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
                CargarSolicitudCheque(StrCadena, 0)
                'Ubicar la selección en la posición original:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
                'Indicar generación exitosa
                MsgBox("Comprobante de cheque generado Exitosamente.", MsgBoxStyle.Information, NombreSistema)
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Formato
    '                       de Solicitud de Cheque siempre que se encuentre:
    '                       REVISADAS, AUTORIZADA, ANULADA o AUTORIZADA CON CK EMITIDO.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()

        Dim ObjFrmSclParametroFNC As New frmSclParametroFNC
        Try
            Dim strSQL As String = ""

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si la Solicitud no se encuentra Autorizada o Anulada:
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) < 4) Then
                MsgBox("La Solicitud aún NO ha sido Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si es Solicitud a Socias no deben existir ninguna Solicitud diferente de Anulada o Autorizada:
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID")) = 1) Then
                strSQL = "SELECT FNC.nCodigo " & _
                         "FROM SccSolicitudCheque as SCK INNER JOIN SccSolicitudDesembolsoCredito as SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN " & _
                         "SclFichaNotificacionDetalle as DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN SclFichaNotificacionCredito as FNC ON  DFNC.nSclFichaNotificacionID = FNC.nSclFichaNotificacionID INNER JOIN StbValorCatalogo as C ON SCK.nStbEstadoSolicitudID = C.nStbValorCatalogoID " & _
                         "WHERE (C.sCodigoInterno < '4') AND (FNC.nCodigo = " & XdsSolicitudCheque("Solicitud").ValueField("nCodigoFNC") & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen Socias con Solicitud aún NO Autorizada en el Grupo.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Solicitud no se encuentra Revisada por Contabilidad (Con o Sin CK) o Anulada:
            'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) < 3) Then
            '    MsgBox("La Solicitud aún NO ha sido Revisada por Contabilidad.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Formato de Solicitud de Cheque:
            ObjFrmSclParametroFNC.NomRep = 11
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID")) = 1) Then
                ObjFrmSclParametroFNC.intSclFormatoID = XdsSolicitudCheque("Solicitud").ValueField("nSclFichaNotificacionID")
                ObjFrmSclParametroFNC.intSccTipoID = 1
            Else
                ObjFrmSclParametroFNC.intSclFormatoID = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
                ObjFrmSclParametroFNC.intSccTipoID = 0
            End If
            ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
            ObjFrmSclParametroFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       tbCuenta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCuenta.
    '-------------------------------------------------------------------------
    Private Sub tbCuenta_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCuenta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarJ"
                LlamaAgregarJornalizacion()
            Case "toolModificarJ"
                LlamaModificarJornalizacion()
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
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si no es el Area Contable es Imposible eliminar Jornalizacion:
            If ModoAccion <> "REV" Then
                MsgBox("Unicamente el Area Contable puede eliminar Cuentas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'No existen Cuentas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si el Area que Revisa (Contabilidad), la Solicitud DEBE encontrarse:
            '1.	Con el Estado Enviada a Contabilidad, (YA generada la Codificación Contable).
            '2.	La Solicitud se encuentre con el estado Revisada por Contabilidad (al encontrar inconsistencias por el área que autoriza).
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 1) Then
                MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 4) Or (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) Then
                MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '4' or StbValorCatalogo.sCodigoInterno = '6') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si es Solicitud de Cheque a Socias elimina todas las cuentas:
            If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
                StrMsg = "¿Está seguro de Eliminar la Codificación Contable automática?"
            Else 'En caso contrario solo elimina la cuenta seleccionada.
                StrMsg = "¿Está seguro de Eliminar la Cuenta seleccionada?"
            End If

            If MsgBox(StrMsg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")

                'Si es Solicitud de Cheque a Socias elimina todas las cuentas:
                If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
                    XdtCuenta.ExecuteSqlNotTable("Delete From SccSolicitudChequeDetalle where nSccSolicitudChequeID=" & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"))
                Else 'En caso contrario solo elimina la cuenta seleccionada.
                    GuardarAuditoriaTablas(2, 3, "Eliminar Solicitud Cheque Detalle ", XdsSolicitudCheque("Cuentas").ValueField("nSccSolicitudChequeDetalleID"), InfoSistema.IDCuenta)
                    XdtCuenta.ExecuteSqlNotTable("Delete From SccSolicitudChequeDetalle where nSccSolicitudChequeDetalleID=" & XdsSolicitudCheque("Cuentas").ValueField("nSccSolicitudChequeDetalleID"))
                End If

                CargarSolicitudCheque(StrCadena, 0)
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
                MsgBox("Codificación eliminada satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena pista de auditoria:
                Call GuardarAuditoria(4, 23, "Eliminación de cuenta de Solicitud de Cheque: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
                Me.grdSolicitud.Caption = " Listado de Solicitudes de Cheque (" + Me.grdSolicitud.RowCount.ToString + " registros)"
                Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtCuenta.Close()
            XdtCuenta = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       LlamaBuscarSolicitudes
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccBusquedaSolicitudesCheque.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarSolicitudes()
        Dim ObjFrmSccBusquedaS As New frmSccBusquedaSolicitudesCheque
        Try

            ObjFrmSccBusquedaS.StrCriterioSolicitud = "0" 'Sin Criterio de Busqueda
            ObjFrmSccBusquedaS.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSccBusquedaS.TipoCheque = Me.TipoCheque '0 Busca todos,1 no presenta los de proveedores .
            ObjFrmSccBusquedaS.sColorFrm = Me.sColor

            ObjFrmSccBusquedaS.ModoAccion = Me.ModoAccion

            ObjFrmSccBusquedaS.ShowDialog()
            If ObjFrmSccBusquedaS.StrCriterioSolicitud <> "0" Then
                StrCadena = ObjFrmSccBusquedaS.StrCriterioSolicitud
                CargarSolicitudCheque(StrCadena, 0)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccBusquedaS.Close()
            ObjFrmSccBusquedaS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaAgregarSolicitud
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSolicitudCheque para Agregar una nueva 
    '                       Solicitud.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarSolicitud()
        Dim ObjFrmSclEditSCK As New frmSccEditSolicitudCheque
        Try

            'Si no es el Area Solicitante Imposible Agregar Solicitud: 
            If ModoAcc <> "ELA" Then
                MsgBox("Unicamente el Area Solicitante puede registrar" & Chr(13) & "Solicitudes de Cheque.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditSCK.sColorFrm = "Verde"
            ObjFrmSclEditSCK.ModoFrm = "ADD"
            ObjFrmSclEditSCK.TipoChequeAgregar = TipoChequeAgregar
            ObjFrmSclEditSCK.ShowDialog()

            'En la adición se carga unicamente la Solicitud de Cheque recien ingresada:
            If ObjFrmSclEditSCK.IdSolicitudCheque <> 0 Then
                StrCadena = "Where (a.nSccSolicitudChequeID = " & ObjFrmSclEditSCK.IdSolicitudCheque & ")"
                CargarSolicitudCheque(StrCadena, 0)
                'Se ubica sobre el registro recien agregado:
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSclEditSCK.IdSolicitudCheque)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
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

            StrSql = "SELECT TP.nScnFuenteFinanciamientoID, TP.nScnCatalogoContableID, TP.nDebito " & _
                     "FROM  ScnTransaccionParametros TP INNER JOIN StbValorCatalogo CA ON TP.nStbTipoDocContableID = CA.nStbValorCatalogoID " & _
                     "WHERE (TP.nScnFuenteFinanciamientoID = " & XdsSolicitudCheque("Solicitud").ValueField("nScnFuenteFinanciamientoID") & ") AND (CA.sCodigoInterno = 'CK') "


            XdtTmpParametros.ExecuteSql(StrSql)
            IntRegistros = XdtTmpParametros.Count

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transaccion:
            Trans.BeginTrans()

            While IntRegistros > 0
                'Insertar Cuenta en los Detalles de la Solicitud:
                StrSql = "Insert Into SccSolicitudChequeDetalle " & _
                         "(nSccSolicitudChequeID, nScnCatalogoContableID, nDebito, nMonto, nUsuarioCreacionID, dFechaCreacion) " & _
                         " Values (" & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ", " & XdtTmpParametros.ValueField("nScnCatalogoContableID") & _
                         ", " & XdtTmpParametros.ValueField("nDebito") & ", " & XdsSolicitudCheque("Solicitud").ValueField("nMonto") & ", " & InfoSistema.IDCuenta & "," & "GetDate())"
                Trans.ExecuteSql(StrSql)
                '---------------------------
                XdtTmpParametros.Source.MoveNext()
                IntRegistros = IntRegistros - 1
            End While

            '-- Finaliza Transaccion:
            Trans.Commit()

            GuardarAuditoriaTablas(101, 1, "Agregar Solicitud Cheque Detalle", XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Generación automática de Codificación Contable de Solicitud de Cheque: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")
            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudCheque(StrCadena, 0)
            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
            Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaAgregarJornalizacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditCuentasSolicitudCheque para Agregar 
    '                       una Distribucion de Cuentas Contables (Cuadrada).
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarJornalizacion()
        Dim ObjFrmSclEditCuentas As New frmSccEditCuentasSolicitudCheque

        Try
            Dim strSQL As String

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si no es el Area que Revisa imposible Agregar Jornalizacion:
            If ModoAcc <> "REV" Then
                MsgBox("Unicamente el Area Contable puede Agregar Jornalización.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si el Area que Revisa (Contabilidad), la Solicitud DEBE encontrarse:
            '1.	Con el Estado Enviada a Contabilidad, .
            '2.	Con el estado Revisada por Contabilidad (en caso de haberse encontrado inconsistencias reportadas por el área responsable de la autorización).
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 1) Then
                MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
                Exit Sub
            End If
            strSQL = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            strSQL = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If


            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 4) Or (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) Then
                MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            strSQL = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '4' or StbValorCatalogo.sCodigoInterno = '6') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Solicitud es de pago de CK a Socias: 
            If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
                'Si ya se efectuó la Distribución automática:
                If Me.grdDetalles.RowCount > 0 Then
                    MsgBox("Ya se generó la Codificación Contable.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Si ya se registro la Distribución en la Base de Datos (Concurrencia):
                strSQL = "SELECT * FROM  SccSolicitudChequeDetalle WHERE  (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Ya se generó la Codificación Contable.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Imposible si no existen Parámetros para la Fuente y de tipo Deudor:
                strSQL = "Select TP.nScnFuenteFinanciamientoID " & _
                         "FROM  ScnTransaccionParametros TP INNER JOIN StbValorCatalogo CA ON TP.nStbTipoDocContableID = CA.nStbValorCatalogoID " & _
                         "WHERE  (TP.nScnFuenteFinanciamientoID = " & XdsSolicitudCheque("Solicitud").ValueField("nScnFuenteFinanciamientoID") & ") AND (CA.sCodigoInterno = 'CK') AND (TP.nDebito = 1)"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("No se han indicado los parámetros Contables" & Chr(13) & "para la fuente de financiamiento.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Imposible si no existen Parámetros para la Fuente y de tipo Acreedor:
                strSQL = "Select TP.nScnFuenteFinanciamientoID " & _
                         "FROM  ScnTransaccionParametros TP INNER JOIN StbValorCatalogo CA ON TP.nStbTipoDocContableID = CA.nStbValorCatalogoID " & _
                         "WHERE  (TP.nScnFuenteFinanciamientoID = " & XdsSolicitudCheque("Solicitud").ValueField("nScnFuenteFinanciamientoID") & ") AND (CA.sCodigoInterno = 'CK') AND (TP.nDebito = 0)"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("No se han indicado los parámetros Contables" & Chr(13) & "para la fuente de financiamiento.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Se registran automaticamente las cuentas:
                InsertarDetallesSolicitud()

                '-- En caso contrario se envia a la pantalla para adición manual.
            Else
                ObjFrmSclEditCuentas.ModoFrm = "ADD"
                ObjFrmSclEditCuentas.IdSolicitud = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
                ObjFrmSclEditCuentas.ShowDialog()

                'Si se ingreso el registro correctamente:
                If ObjFrmSclEditCuentas.IdCuenta <> 0 Then
                    CargarSolicitudCheque(StrCadena, 0)
                    XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSclEditCuentas.IdSolicitud)
                    Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditCuentas.Close()
            ObjFrmSclEditCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaModificarSolicitud
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSolicitudCheque para Modificar una existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarSolicitud()
        Dim ObjFrmScnEditSCK As New frmSccEditSolicitudCheque
        Dim StrSql As String
        Try

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            If ModoAcc = "ELA" Then
                ObjFrmScnEditSCK.sColorFrm = "Verde"
            Else
                ObjFrmScnEditSCK.sColorFrm = "CelesteLight"
            End If

            ObjFrmScnEditSCK.IntHabilito = 1

            'Si no es el Area Solicitante o Contable Imposible Modificar Solicitud:
            If ModoAcc = "AUT" Then
                MsgBox("Unicamente el Area Solicitante y Contable puede modificar" & Chr(13) & "los datos generales de la Solicitud.", MsgBoxStyle.Information)
                ObjFrmScnEditSCK.IntHabilito = 0
            Else
                'Imposible si la Solicitud se encuentra Anulada:
                StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If (RegistrosAsociados(StrSql)) Or ((CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5)) Then
                    MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                    ObjFrmScnEditSCK.IntHabilito = 0
                    'Exit Sub
                Else
                    'Si es el Area Solicitante La Solicitud DEBE encontrarse:
                    '1.	Con el Estado En Proceso.
                    '2.	Con el Estado Enviada a Contabilidad, siempre que el área Contable aún NO haya generado la Codificación Contable.
                    StrSql = "SELECT * FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                    If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) > 2) Or (RegistrosAsociados(StrSql)) Then
                        MsgBox("La Solicitud ya ha sido Codificada" & Chr(13) & "por el Area Contable.", MsgBoxStyle.Information)
                        ObjFrmScnEditSCK.IntHabilito = 0
                    End If
                    StrSql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                             "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                             "WHERE (StbValorCatalogo.sCodigoInterno > '2') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                    If RegistrosAsociados(StrSql) Then
                        MsgBox("La Solicitud ya ha sido Revisada" & Chr(13) & "por el Area Contable.", MsgBoxStyle.Information)
                        ObjFrmScnEditSCK.IntHabilito = 0
                    End If
                End If
            End If

            ObjFrmScnEditSCK.ModoFrm = "UPD"
            ObjFrmScnEditSCK.IdSolicitudCheque = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            ObjFrmScnEditSCK.ShowDialog()

            REM InicializaVariables()
            CargarSolicitudCheque(StrCadena, 0)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", ObjFrmScnEditSCK.IdSolicitudCheque)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

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
    Private Sub LlamaModificarJornalizacion()
        Dim ObjFrmSclEditCuentas As New frmSccEditCuentasSolicitudCheque
        Try

            Dim StrSql As String

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si no es el Area que revisa es Imposible modificar Jornalizacion:
            If ModoAccion <> "REV" Then
                MsgBox("Unicamente el Area Contable puede Modificar la Jornalización.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'No existen Cuentas:
            If Me.grdDetalles.RowCount = 0 Then
                MsgBox("No Existe Codificación Contable registrada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si el Area que Revisa (Contabilidad), la Solicitud DEBE encontrarse:
            '1.	Con el Estado Enviada a Contabilidad, (YA generada la Codificación Contable).
            '2.	La Solicitud se encuentre con el estado Revisada por Contabilidad (al encontrar inconsistencias por el área que autoriza).
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 1) Then
                MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Solicitud se encuentra En Proceso." & Chr(13) & "Aún no ha sido Enviada a Contabilidad.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                    "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                    "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 4) Or (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 6) Then
                MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '4' or StbValorCatalogo.sCodigoInterno = '6') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Solicitud se encuentra Autorizada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si es Solicitud de Entrega de Cheque a Socias:
            If (XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1) Then
                MsgBox("No es posible modificación manual de Codificación" & Chr(13) & "Contable para Solicitudes de entrega de Cheque a" & Chr(13) & "Socias.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditCuentas.ModoFrm = "UPD"
            ObjFrmSclEditCuentas.IdSolicitud = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            ObjFrmSclEditCuentas.IdCuenta = XdsSolicitudCheque("Cuentas").ValueField("nSccSolicitudChequeDetalleID")
            ObjFrmSclEditCuentas.ShowDialog()

            CargarSolicitudCheque(StrCadena, 0)
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", ObjFrmSclEditCuentas.IdSolicitud)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

            XdsSolicitudCheque("Cuentas").SetCurrentByID("nSccSolicitudChequeDetalleID", ObjFrmSclEditCuentas.IdCuenta)
            Me.grdDetalles.Row = XdsSolicitudCheque("Cuentas").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditCuentas.Close()
            ObjFrmSclEditCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/11/2007
    ' Procedure Name:       LlamaAnularSolicitud
    ' Descripción:          Este procedimiento permite Anular un Grupo
    '                       Solidario existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularSolicitud()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando

        Try

            Dim intPosicion As Integer

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If


            'La solicitud se encuentra Anulada:
            If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Strsql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible Anular Solicitudes de Cheque a Socias, estas se deben Anular
            'de forma automática desde la FNC:
            If XdsSolicitudCheque("Solicitud").ValueField("nSccTipoSolicitudChequeID") = 1 Then
                MsgBox("Las Solicitudes de Cheque a Socias unicamente pueden" & Chr(13) & "Anularse desde la correspondiente Ficha de Notificación" & Chr(13) & "de Crédito.", MsgBoxStyle.Information)
                Exit Sub
                '-- Imposible Anular Solicitud <> Cheque a Socias si 
                '-- tiene relacionado un Cheque (<> ANULADO).                
            Else
                Strsql = "SELECT StbValorCatalogo.sCodigoInterno AS Cod " & _
                         "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE  (ScnTransaccionContable.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3')"
                If RegistrosAsociados(Strsql) Then
                    MsgBox("Existe cheque Activo para la Solicitud.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si es el Area Solicitante La Solicitud DEBE encontrarse:
            '1.	Con el Estado En Proceso:
            '2.	Con el Estado Enviada a Contabilidad, siempre que el área Contable aún NO haya generado la Codificación Contable (en caso de haberse encontrado inconsistencias reportadas por el área Contable):
            If ModoAccion = "ELA" Then
                Strsql = "SELECT * FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) > 2) Or (RegistrosAsociados(Strsql)) Then
                    MsgBox("El Area Solicitante únicamente puede Anular Solicitudes" & Chr(13) & "En Proceso o Enviadas a Contabilidad sin Códificación Contable registrada.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                Strsql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno > '2') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If RegistrosAsociados(Strsql) Then
                    MsgBox("El Area Solicitante únicamente puede Anular Solicitudes" & Chr(13) & "En Proceso o Enviadas a Contabilidad sin Códificación Contable registrada.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si es el Area que Revisa (Contabilidad), la Solicitud debe encontrarse:
            '1.	Con el Estado Enviada a Contabilidad, siempre y cuando SE haya generado la Codificación Contable.
            '2.	La Solicitud se encuentre con el estado Revisada por Contabilidad (en caso de haberse encontrado inconsistencias reportadas por el área responsable de la autorización).
            If ModoAccion = "REV" Then
                If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 2) And (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 3) Then
                    MsgBox("El Area Contable únicamente puede Anular Solicitudes" & Chr(13) & "Enviadas a Contabilidad o Revisadas por esta.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                Strsql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                       "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                       "WHERE  (StbValorCatalogo.sCodigoInterno = '2' or StbValorCatalogo.sCodigoInterno = '3') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If RegistrosAsociados(Strsql) = False Then
                    MsgBox("El Area Contable únicamente puede Anular Solicitudes" & Chr(13) & "Enviadas a Contabilidad o Revisadas por esta.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si es el Area que Autoriza, la Solicitud debe encontrarse AUTORIZADA:
            If ModoAccion = "AUT" Then
                If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) <> 4) Then
                    MsgBox("Unicamente puede Anular Solicitudes Autorizadas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                Strsql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                        "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                        "WHERE  (StbValorCatalogo.sCodigoInterno = '4') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If RegistrosAsociados(Strsql) = False Then
                    MsgBox("Unicamente puede Anular Solicitudes Autorizadas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Confirmar Anulación:
            If MsgBox("¿Está seguro de Anular la Solicitud seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Agregado para bitacora de cambios 
            'Solicitud de Cheque 
            GuardarAuditoriaTablas(1, 2, "Anular Solicitud Cheque", XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID"), InfoSistema.IDCuenta)
            'Anula la Solicitud Actual:



            Strsql = " Update SccSolicitudCheque " & _
                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '5' And b.sNombre = 'EstadoSolicitudCheque')" & _
                     " WHERE nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            XcDatos.ExecuteNonQuery(Strsql)

            MsgBox("Solicitud de Cheque Anulada Exitosamente.", MsgBoxStyle.Information, NombreSistema)

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 23, "Anulación de Solicitud de Cheque: " & XdsSolicitudCheque("Solicitud").ValueField("nCodigo") & ".")

            'Guardar posición actual de la selección:
            intPosicion = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
            CargarSolicitudCheque(StrCadena, 0)

            'Ubicar la selección en la posición original:
            XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", intPosicion)
            Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                12/11/2007
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
    Private Sub grdSolicitud_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSolicitud.DoubleClick
        Try
            If Seg.HasPermission("ModificarSCK") Then
                LlamaModificarSolicitud()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdSolicitud_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSolicitud.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       grdGS_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSolicitud_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSolicitud.Filter
        Try
            XdsSolicitudCheque("Solicitud").FilterLocal(e.Condition)
            Me.grdSolicitud.Caption = " Listado de Solicitudes de Cheque (" + Me.grdSolicitud.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar Solicitudes:
            If Seg.HasPermission("BuscarSCK") = False Then
                Me.tbSolicitud.Items("toolBuscar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolBuscar").Enabled = True
            End If
            'Agregar Solicitud:
            If Seg.HasPermission("AgregarSCK") = False Then
                Me.tbSolicitud.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAgregar").Enabled = True
            End If
            'Editar Solicitud:
            If Seg.HasPermission("ModificarSCK") = False Then
                Me.tbSolicitud.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolModificar").Enabled = True
            End If
            'Anular Solicitud:
            If Seg.HasPermission("AnularSCK") = False Then
                Me.tbSolicitud.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolAnular").Enabled = True
            End If
            'Revisar Solicitud:
            If Seg.HasPermission("RevisarSCK") = False Then
                Me.tbSolicitud.Items("toolRevisar").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolRevisar").Enabled = True
            End If
            'Generar Cheques:
            If Seg.HasPermission("GenerarCKS") = False Then
                Me.tbSolicitud.Items("toolGenerarCK").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolGenerarCK").Enabled = True
            End If
            'Generar Cheques en grupo:
            If Seg.HasPermission("GenerarBloqueCKS") = False Then
                Me.tbSolicitud.Items("toolGenerarChecked").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolGenerarChecked").Enabled = True
            End If
            'Imprimir Formato de Solicitud de Cheque:
            If Seg.HasPermission("ImprimirSCK") = False Then
                Me.tbSolicitud.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbSolicitud.Items("toolImprimir").Enabled = True
            End If

            'Agregar Jornalización:
            If Seg.HasPermission("AgregarCuentasSCK") = False Then
                Me.tbCuenta.Items("toolAgregarJ").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolAgregarJ").Enabled = True
            End If
            'Editar Jornalización:
            If Seg.HasPermission("ModificarCuentasSCK") = False Then
                Me.tbCuenta.Items("toolModificarJ").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolModificarJ").Enabled = True
            End If
            'Eliminar Jornalización:
            If Seg.HasPermission("EliminarCuentasSCK") = False Then
                Me.tbCuenta.Items("toolEliminarJ").Enabled = False
            Else  'Habilita
                Me.tbCuenta.Items("toolEliminarJ").Enabled = True
            End If

            'Actualizar Concepto de Pago:
            If Seg.HasPermission("ActualizarConceptoPagoCheque") = False Then
                Me.toolActualizarConcepto.Enabled = False
            Else  'Habilita
                Me.toolActualizarConcepto.Enabled = True
            End If

            If Seg.HasPermission("ModificarSCK_Fecha") = False Then
                Me.toolActualizarFecha.Enabled = False
            Else  'Habilita
                Me.toolActualizarFecha.Enabled = True
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       grdDetalles_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Detalles con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdSolicitud.RowColChange
        Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/11/2007
    ' Procedure Name:       grdDetalles_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Detalle existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDetalles.DoubleClick
        Try
            If Seg.HasPermission("ModificarCuentasSCK") Then
                LlamaModificarJornalizacion()
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
    ' Fecha:                12/11/2007
    ' Procedure Name:       grdDetalles_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdDetalles_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDetalles.Filter
        Try
            XdsSolicitudCheque("Cuentas").FilterLocal(e.Condition)
            Me.grdDetalles.Caption = " Detalles de Solicitud de Cheque (" + Me.grdDetalles.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaModificarFecha()
        Dim ObjFrmScnEditSCK As New frmSccEditSolicitudCheque_Fecha
        Dim StrSql As String
        Try

            'Imposible si no existen Solicitudes:
            If Me.grdSolicitud.RowCount = 0 Then
                MsgBox("No existen Solicitudes de Cheque registradas" & Chr(13) & "en el rango de Fechas indicado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsSolicitudCheque("Solicitud").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Solicitudes de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            If ModoAcc = "ELA" Then
                ObjFrmScnEditSCK.sColorFrm = "Verde"
            Else
                ObjFrmScnEditSCK.sColorFrm = "CelesteLight"
            End If

            ObjFrmScnEditSCK.IntHabilito = 1

            'Si no es el Area Solicitante o Contable Imposible Modificar Solicitud:
            'If ModoAcc = "AUT" Then
            'MsgBox("Unicamente el Area Solicitante y Contable puede modificar" & Chr(13) & "los datos generales de la Solicitud.", MsgBoxStyle.Information)
            'ObjFrmScnEditSCK.IntHabilito = 0
            'Else
                'Imposible si la Solicitud se encuentra Anulada:
                StrSql = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " & _
                     "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '5') AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                If (RegistrosAsociados(StrSql)) Or ((CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) = 5)) Then
                    MsgBox("La Solicitud se encuentra Anulada.", MsgBoxStyle.Information)
                    ObjFrmScnEditSCK.IntHabilito = 0
                Exit Sub
                Else
                    'Si es el Area Solicitante La Solicitud DEBE encontrarse:
                    '1.	Con el Estado En Proceso.
                    '2.	Con el Estado Enviada a Contabilidad, siempre que el área Contable aún NO haya generado la Codificación Contable.
                'StrSql = "SELECT * FROM SccSolicitudChequeDetalle WHERE (nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                'If (CInt(XdsSolicitudCheque("Solicitud").ValueField("sCodigoInterno")) > 2) Or (RegistrosAsociados(StrSql)) Then
                '    MsgBox("La Solicitud ya ha sido Codificada" & Chr(13) & "por el Area Contable.", MsgBoxStyle.Information)
                '    ObjFrmScnEditSCK.IntHabilito = 0
                'End If
                StrSql = "SELECT  SccSolicitudCheque.nSccSolicitudChequeID " & _
                         "FROM SccSolicitudCheque INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno<> '4') AND StbValorCatalogo.sCodigoInterno<> '6' AND (SccSolicitudCheque.nSccSolicitudChequeID = " & XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID") & ")"
                    If RegistrosAsociados(StrSql) Then
                    MsgBox("La Solicitud No se encuentra Autorizada o Autorizada con cheque emitido", MsgBoxStyle.Information)
                    ObjFrmScnEditSCK.IntHabilito = 0
                    Exit Sub
                    End If
                End If
                'End If

                ObjFrmScnEditSCK.ModoFrm = "UPD"
                ObjFrmScnEditSCK.IdSolicitudCheque = XdsSolicitudCheque("Solicitud").ValueField("nSccSolicitudChequeID")
                ObjFrmScnEditSCK.ShowDialog()

                REM InicializaVariables()
                CargarSolicitudCheque(StrCadena, 0)
                XdsSolicitudCheque("Solicitud").SetCurrentByID("nSccSolicitudChequeID", ObjFrmScnEditSCK.IdSolicitudCheque)
                Me.grdSolicitud.Row = XdsSolicitudCheque("Solicitud").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditSCK.Close()
            ObjFrmScnEditSCK = Nothing
        End Try
    End Sub
    Private Sub toolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click

    End Sub
End Class