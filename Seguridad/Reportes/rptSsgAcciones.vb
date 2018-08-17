Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptSsgAcciones
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim xdtAccion As BOSistema.Win.XDataSet.xDataTable

    ''Estado
    'Dim mIdEstado As Integer
    'Dim mEstado As String

    ''Pertenece Programa
    'Dim mIdPertenece As Integer
    'Dim mPertenece As String

    ''ID del Estado(Activo, Inactivo, Todos) del Barrio
    'Public Property IdEstado() As Integer
    '    Get
    '        IdEstado = mIdEstado
    '    End Get
    '    Set(ByVal value As Integer)
    '        mIdEstado = value
    '    End Set
    'End Property
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
            xdtAccion = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	CargarAccion
    ' Description			   	:	Cargar los datos de Acciones
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarAccion()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""
            '------------------------

            Strsql = " Select SsgModuloID, " & _
                     "        sModulo, " & _
                     "        sServicioUsuario, " & _
                     "        sAccion, " & _
                     "        0 as nPermiso" & _
                     " From vwStbListadoOpciones " & _
                     " Where CodInterno <> 'SSG' " & _
                     " Order by sModulo desc,sServicioUsuario desc,sAccion "

            xdtAccion.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub rptSsgAcciones_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarAccion()

            If xdtAccion.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtAccion.Table

            'Asignar el data field
            Me.txtAccion.DataField = "sAccion"
            Me.txtServicioUsuario.DataField = "sServicioUsuario"
            Me.chkPermiso.DataField = "nPermiso"
            Me.txtModulo.DataField = "sModulo"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
