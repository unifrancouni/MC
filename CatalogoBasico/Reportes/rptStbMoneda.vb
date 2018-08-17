Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 


Public Class rptStbMoneda

    'Estado
    Dim mIdEstado As Integer
    Dim mEstado As String

    Dim ObjEncabeza As rptEncabezadoV
    Dim xdtMoneda As BOSistema.Win.XDataSet.xDataTable

    'ID del Estado(Activo, Inactivo, Todos) del Barrio
    Public Property IdEstado() As Integer
        Get
            IdEstado = mIdEstado
        End Get
        Set(ByVal value As Integer)
            mIdEstado = value
        End Set
    End Property

    'Descripción del Estado del Barrio para los Parámetros
    Public Property Estado() As String
        Get
            Estado = mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property
    Private Sub RptSteReporteMoneda_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try

            InicializarVariables()
            EstableceMargenesRptLetter(Me)

            'Seteo el reporte de moneda

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.TxtCodigo.DataField = "sCodigoInterno"
            Me.TxtDescripción.DataField = "sDescripcion"
            Me.TxtSimbolo.DataField = "sSimbolo"
            Me.ChkNacionalidad.DataField = "nNacional"
            Me.txtFecha.Text = Format(Now.Date, "dd-MM-yyyy")
            Me.txtHora.Text = Now.ToLongTimeString

            Me.txtParametro1.Text = "Estado: " & mEstado

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	21/11/2006
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar los objetos empleados en el reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            Dim strsql As String

            XdtMoneda = New BOSistema.Win.XDataSet.xDataTable

            strsql = "SELECT sCodigoInterno, sSimbolo, sDescripcion, nNacional, nActivo " & _
                     "FROM StbMoneda " & _
                     "Where (nActivo  = " & mIdEstado & " Or " & mIdEstado & " = -19)" & _
                     "ORDER BY sCodigoInterno"

            XdtMoneda.ExecuteSql(strsql)
            Me.DataSource = XdtMoneda.Table

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            ObjEncabeza = New rptEncabezadoV
            Me.SubRptEncabezado.Report = ObjEncabeza
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
