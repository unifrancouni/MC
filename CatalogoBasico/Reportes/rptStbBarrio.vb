Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbBarrio
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim xdtBarrio As BOSistema.Win.XDataSet.xDataTable

    'Estado
    Dim mIdEstado As Integer
    Dim mEstado As String

    'Pertenece Programa
    Dim mIdPertenece As Integer
    Dim mPertenece As String

    'Municipio
    Dim mIdMunicipio As Integer
    Dim mMunicipio As String

    'Departamento
    Dim mIdDepartamento As Integer
    Dim mDepartamento As String

    'Distrito
    Dim mIdDistrito As Integer
    Dim mDistrito As String

    'ID del Estado(Activo, Inactivo, Todos) del Barrio
    Public Property IdEstado() As Integer
        Get
            IdEstado = mIdEstado
        End Get
        Set(ByVal value As Integer)
            mIdEstado = value
        End Set
    End Property
    'Indica si pertenece al programa de Micro Crédito
    Public Property IdPertenece() As Integer
        Get
            IdPertenece = mIdPertenece
        End Get
        Set(ByVal value As Integer)
            mIdPertenece = value
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
    'Descripción de Incluido en el Programa para los Parámetros
    Public Property Pertenece() As String
        Get
            Pertenece = mPertenece
        End Get
        Set(ByVal value As String)
            mPertenece = value
        End Set
    End Property
    'ID del Departamento seleccionado o bien Todos (-19)
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = mIdDepartamento
        End Get
        Set(ByVal value As Integer)
            mIdDepartamento = value
        End Set
    End Property
    'Descripción del Departamento seleccionado para los Parámetros
    Public Property Departamento() As String
        Get
            Departamento = mDepartamento
        End Get
        Set(ByVal value As String)
            mDepartamento = value
        End Set
    End Property
    'ID del Municipio seleccionado o bien Todos
    Public Property IdMunicipio() As Integer
        Get
            IdMunicipio = mIdMunicipio
        End Get
        Set(ByVal value As Integer)
            mIdMunicipio = value
        End Set
    End Property
    'Descripción del Municipio seleccionado para los Parámetros
    Public Property Municipio() As String
        Get
            Municipio = mMunicipio
        End Get
        Set(ByVal value As String)
            mMunicipio = value
        End Set
    End Property
    'ID del Distrito seleccionado o bien Todos
    Public Property IdDistrito() As Integer
        Get
            IdDistrito = mIdDistrito
        End Get
        Set(ByVal value As Integer)
            mIdDistrito = value
        End Set
    End Property
    'Descripción del Distrito seleccionado para los parámetros
    Public Property Distrito() As String
        Get
            Distrito = mDistrito
        End Get
        Set(ByVal value As String)
            mDistrito = value
        End Set
    End Property
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            Me.txtparametro1.Text = "Depto.: " & Me.mDepartamento & "  " & "Munic.: " & Me.mMunicipio
            Me.txtparametro2.Text = "Distrito: " & Me.mDistrito & "  " & "Incluido: " & mPertenece & "  " & "Estado: " & mEstado

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
            xdtBarrio = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	CargarBarrio
    ' Description			   	:	Cargar los datos de Barrios
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarBarrio()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 
            Strsql = ""

            Strsql = " Select nStbBarrioID,nStbDepartamentoID,nStbMunicipioID, " & _
                     "        sDepartamento, " & _
                     "        sMunicipio, " & _
                     "        sDistrito," & _
                     "        sCodigoBarrio, " & _
                     "        sBarrio, " & _
                     "        nActivo as ActivoBarrio, " & _
                     "        nPertenecePrograma" & _
                     " From vwStbBarrioReporte " & _
                     " Where (nActivo  = " & mIdEstado & " Or " & mIdEstado & " = -19)" & _
                     " And (nPertenecePrograma  = " & mIdPertenece & " Or " & mIdPertenece & " = -19)" & _
                     " And (nStbMunicipioID  = " & mIdMunicipio & " Or " & mIdMunicipio & " = -19)" & _
                     " And (nStbDepartamentoID  = " & mIdDepartamento & " Or " & mIdDepartamento & " = -19)" & _
                     " And (nStbDistritoID  = " & mIdDistrito & " Or " & mIdDistrito & " = -19)" & _
                     " Order by sDepartamento,sMunicipio,sDistrito,sCodigoBarrio "

            xdtBarrio.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub rptStbBarrio_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarBarrio()

            If xdtBarrio.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtBarrio.Table

            'Asignar el data field
            Me.txtMunicipio.DataField = "sMunicipio"
            Me.txtDepartamento.DataField = "sDepartamento"
            Me.txtDistrito.DataField = "sDistrito"
            Me.txtNombre.DataField = "sBarrio"
            Me.txtCodigo.DataField = "sCodigoBarrio"
            Me.chkactivo.DataField = "ActivoBarrio"
            Me.chkIncluidoPrograma.DataField = "nPertenecePrograma"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
