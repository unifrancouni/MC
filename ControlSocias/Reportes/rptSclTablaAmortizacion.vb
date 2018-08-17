Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclTablaAmortizacion
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim xdtTablaAmortizacion As BOSistema.Win.XDataSet.xDataTable

    'Estado
    Dim mIdFichaNotificacion As Integer
    'Dim mEstado As String

    'Pertenece Programa
    'Dim mIdPertenece As Integer
    'Dim mPertenece As String

    'ID del Estado(Activo, Inactivo, Todos) del Barrio
    Public Property IdFichaNotificacion() As Integer
        Get
            IdFichaNotificacion = mIdFichaNotificacion
        End Get
        Set(ByVal value As Integer)
            mIdFichaNotificacion = value
        End Set
    End Property
    ''Indica si pertenece al programa de Micro Crédito
    'Public Property IdPertenece() As Integer
    '    Get
    '        IdPertenece = mIdPertenece
    '    End Get
    '    Set(ByVal value As Integer)
    '        mIdPertenece = value
    '    End Set
    'End Property
    ''Descripción de Incluido en el Programa para los Parámetros
    'Public Property Pertenece() As String
    '    Get
    '        Pertenece = mPertenece
    '    End Get
    '    Set(ByVal value As String)
    '        mPertenece = value
    '    End Set
    'End Property
    ''Descripción del Estado del Barrio para los Parámetros
    'Public Property Estado() As String
    '    Get
    '        Estado = mEstado
    '    End Get
    '    Set(ByVal value As String)
    '        mEstado = value
    '    End Set
    'End Property

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            'Me.txtparametro1.Text = "Incluido: " & mPertenece & "  " & "Estado: " & mEstado

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabeza = New rptEncabezadoV
            Me.SubReporte.Report = objEncabeza
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar los objetos 
    '                           :   de Barrio
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            xdtTablaAmortizacion = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	CargarDistrito
    ' Description			   	:	Cargar los datos de Distritos
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarTablaAmortizacion()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""
            '------------------------

            Strsql = " Select a.nSclFichaSociaID, " & _
                     "        a.nPlazoAprobado,a.nMontoCreditoAprobado, " & _
                     "        a.dFechaPrimerCuota,a.dFechaUltimaCuota, " & _
                     "        a.dFechaHoraEntregaCk,a.nNumCuota, " & _
                     "        a.dFechaPago,a.nAmortizacion,a.sGrupoSolidario, " & _
                     "        a.nMantValor,a.nIntereses,a.nCuota,a.nSaldo,a.sNombreApellidos, " & _
                     "        (Select max(dFechaPago) From SccTablaAmortizacion Where nSclFichaNotificacionDetalleID = a.nSclFichaNotificacionDetalleID) as dFechaFin " & _
                     " From vwSclTablaAmortizacionRep a " & _
                     " Where a.nSclFichaNotificacionID = " & Me.IdFichaNotificacion & _
                     " Order by a.nSclFichaSociaID,a.nNumCuota"

            '" Where (sCodigo <> '0' ) And (nActivo  = " & mIdEstado & " Or " & mIdEstado & " = -19)" & _
            '" And (nPertenecePrograma  = " & mIdPertenece & " Or " & mIdPertenece & " = -19)" & _
            '" Order by sCodigo "

            xdtTablaAmortizacion.ExecuteSql(Strsql)

            XdtValorParametro.Filter = " nStbValorParametroID = 1"
            XdtValorParametro.Retrieve()

            If XdtValorParametro.Count > 0 Then
                Me.txtTasaInteres.Text = XdtValorParametro.ValueField("sValorParametro") & " %"
            End If

            XdtValorParametro.Filter = " nStbValorParametroID = 2"
            XdtValorParametro.Retrieve()

            If XdtValorParametro.Count > 0 Then
                Me.txtTasaMantValor.Text = XdtValorParametro.ValueField("sValorParametro") & " %"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    Private Sub rptStbDistrito_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarTablaAmortizacion()

            If xdtTablaAmortizacion.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtTablaAmortizacion.Table

            'Asignar el data field
            Me.txtNombreApellidos.DataField = "sNombreApellidos"
            Me.txtFechaDesembolso.DataField = "dFechaHoraEntregaCK"
            Me.txtFechaPrimerPago.DataField = "dFechaPrimerCuota"
            Me.txtFechaVencimiento.DataField = "dFechafIN"
            Me.txtPlazo.DataField = "nPlazoAprobado"
            Me.txtMontoCor.DataField = "nMontoCreditoAprobado"
            Me.txtNumCuota.DataField = "nNumCuota"
            Me.txtFechaPago.DataField = "dFechaPago"
            Me.txtAmortizacion.DataField = "nAmortizacion"
            Me.txtMantValor.DataField = "nMantValor"
            Me.txtIntereses.DataField = "nIntereses"
            Me.txtCuotaSemanal.DataField = "nCuota"
            Me.txtSaldo.DataField = "nSaldo"
            Me.txtGrupoSolidario.DataField = "sGrupoSolidario"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Me.txtCuotas.Text = Me.txtPlazo.Value * 4
        Me.txtNombreApellidos.Text = UCase(Me.txtNombreApellidos.Value)
        Me.txtGrupoSolidario.Text = UCase(Me.txtGrupoSolidario.Value)
        Me.txtFechaPrimerPago.Text = Format(Me.txtFechaPrimerPago.Value, "dd/MM/yyyy")
        Me.txtFechaVencimiento.Text = Format(Me.txtFechaVencimiento.Value, "dd/MM/yyyy")
        Me.txtFechaDesembolso.Text = Format(Me.txtFechaDesembolso.Value, "dd/MM/yyyy")
        Me.txtMontoCor.Text = Format(Me.txtMontoCor.Value, "C$ #,##0.00")

        If Me.txtMontoCor.Value = 1850 Then
            Me.txtMontoDol.Text = "$ 100.00"
        ElseIf Me.txtMontoCor.Value = 2750 Then
            Me.txtMontoDol.Text = "$ 150.00"
        ElseIf Me.txtMontoCor.Value = 3700 Then
            Me.txtMontoDol.Text = "$ 200.00"
        ElseIf Me.txtMontoCor.Value = 4600 Then
            Me.txtMontoDol.Text = "$ 250.00"
        ElseIf Me.txtMontoCor.Value = 5500 Then
            Me.txtMontoDol.Text = "$ 300.00"
        End If

    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtFechaPago.Text = Format(Me.txtFechaPago.Value, "dd/MM/yyyy")
        Me.txtSaldo.Text = Format(Me.txtSaldo.Value, "#,##0.00")
    End Sub
End Class
