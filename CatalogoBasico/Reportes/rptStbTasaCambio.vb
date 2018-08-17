Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbTasaCambio
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim xdtTasaCambio As BOSistema.Win.XDataSet.xDataTable

    'Moneda Base
    Dim mIdMonedaBase As Integer
    Dim mMonedaBase As String

    'Moneda Cambio
    Dim mIdMonedaCambio As Integer
    Dim mMonedaCambio As String

    'Fecha Desde
    Dim dFechaDesde As Date

    'Fecha Hasta
    Dim dFechaHasta As Date

    'ID de la Moneda Base
    Public Property IdMonedaBase() As Integer
        Get
            IdMonedaBase = mIdMonedaBase
        End Get
        Set(ByVal value As Integer)
            mIdMonedaBase = value
        End Set
    End Property
    'Fecha Desde
    Public Property FechaDesde() As Date
        Get
            FechaDesde = dFechaDesde
        End Get
        Set(ByVal value As Date)
            dFechaDesde = value
        End Set
    End Property
    'Fecha Hasta
    Public Property FechaHasta() As Date
        Get
            FechaHasta = dFechaHasta
        End Get
        Set(ByVal value As Date)
            dFechaHasta = value
        End Set
    End Property
    'ID de la Moneda Cambio
    Public Property IdMonedaCambio() As Integer
        Get
            IdMonedaCambio = mIdMonedaCambio
        End Get
        Set(ByVal value As Integer)
            mIdMonedaCambio = value
        End Set
    End Property

    'Descripción de la Moneda Base
    Public Property MonedaBase() As String
        Get
            MonedaBase = mMonedaBase
        End Get
        Set(ByVal value As String)
            mMonedaBase = value
        End Set
    End Property

    'Descripción de la Moneda Cambio
    Public Property MonedaCambio() As String
        Get
            MonedaCambio = mMonedaCambio
        End Get
        Set(ByVal value As String)
            mMonedaCambio = value
        End Set
    End Property

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            Me.txtparametro1.Text = "Moneda Base: " & Me.MonedaBase   '& "  " & "Moneda Cambio: " & Me.MonedaCambio
            Me.txtparametro2.Text = "Moneda Cambio: " & Me.MonedaCambio & "  " & "Desde: " & Me.dFechaDesde.Date & "  " & "Hasta: " & Me.dFechaHasta.Date

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
    '                           :   de Tasas de Cambio
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            xdtTasaCambio = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	CargarTasaCambio
    ' Description			   	:	Cargar los datos de Tasas de Cambio
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarTasaCambio()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 

            Strsql = " Select nStbParidadCambiariaID,nStbMonedaBaseID,sMonedaBase,sMonedaCambio, " & _
                     "        dFechaTCambio,nMontoTCambio,sSimboloMonedaBase,sSimboloMonedaCambio, " & _
                     "        nActivo,nOcupado " & _
                     " From vwStbTasaCambioReporte " & _
                     " Where (nStbMonedaBaseID  = " & mIdMonedaBase & ")" & _
                     " And (nStbMonedaCambioID  = " & mIdMonedaCambio & ")" & _
                     " And (dFechaTCambio >= '" & Format(Me.dFechaDesde.Date, "yyyy-MM-dd") & "' and dFechaTCambio <= '" & Format(Me.dFechaHasta.Date, "yyyy-MM-dd") & "')" & _
                     " Order by dFechaTCambio "

            xdtTasaCambio.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub rptStbTasaCambio_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarTasaCambio()

            If xdtTasaCambio.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtTasaCambio.Table

            'Asignar el data field
            Me.txtMonedaBase.DataField = "sMonedaBase"
            Me.txtMonedaCambio.DataField = "sMonedaCambio"
            Me.txtFechaCambio.DataField = "dFechaTCambio"
            Me.txtMontoCambio.DataField = "nMontoTCambio"
            Me.chkactivo.DataField = "nActivo"
            Me.chkOcupado.DataField = "nOcupado"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Me.txtFechaCambio.Text = Format(Me.txtFechaCambio.Value, "dd/MM/yyyy")
    End Sub
End Class
