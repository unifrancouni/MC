Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbCargo
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim xdtCargo As BOSistema.Win.XDataSet.xDataTable

    'Estado
    Dim mIdEstado As Integer
    Dim mEstado As String

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

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try
            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            Me.txtparametro1.Text = "Estado: " & mEstado

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
            xdtCargo = New BOSistema.Win.XDataSet.xDataTable

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
    Public Sub CargarCargo()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""
            '------------------------

            Strsql = " Select nSrhCargoID, " & _
                     "        sCodigo, " & _
                     "        sNombreCargo, " & _
                     "        nActivo " & _
                     " From SrhCargo " & _
                     " Where (nActivo  = " & mIdEstado & " Or " & mIdEstado & " = -19)" & _
                     " Order by sCodigo "

            xdtCargo.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub rptStbCargo_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarCargo()

            If xdtCargo.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtCargo.Table

            'Asignar el data field
            Me.txtNombre.DataField = "sNombreCargo"
            Me.txtCodigo.DataField = "sCodigo"
            Me.chkactivo.DataField = "nActivo"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
