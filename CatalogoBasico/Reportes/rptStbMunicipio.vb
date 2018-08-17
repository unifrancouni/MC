Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbMunicipio
    'Declaracion de Variables

    Dim objEncabeza As rptEncabezadoV
    Dim xdtMunicipio As BOSistema.Win.XDataSet.xDataTable

    'Estado Depto
    Dim mIdEstadoDepto As Integer
    Dim mEstadoDepto As String

    'Estado Munic
    Dim mIdEstadoMunic As Integer
    Dim mEstadoMunic As String

    'Pertenece Programa Depto
    Dim mIdPerteneceDepto As Integer
    Dim mPerteneceDepto As String

    'Pertenece Programa Munic
    Dim mIdPerteneceMunic As Integer
    Dim mPerteneceMunic As String

    'Departamento
    Dim mIdDepartamento As Integer
    Dim mDepartamento As String

    'ID del Estado(Activo, Inactivo, Todos) del Departamento
    Public Property IdEstadoDepto() As Integer
        Get
            IdEstadoDepto = mIdEstadoDepto
        End Get
        Set(ByVal value As Integer)
            mIdEstadoDepto = value
        End Set
    End Property

    'ID del Estado(Activo, Inactivo, Todos) del Municipio
    Public Property IdEstadoMunic() As Integer
        Get
            IdEstadoMunic = mIdEstadoMunic
        End Get
        Set(ByVal value As Integer)
            mIdEstadoMunic = value
        End Set
    End Property

    'Indica si pertenece el Departamento al programa de Micro Crédito
    Public Property IdPerteneceDepto() As Integer
        Get
            IdPerteneceDepto = mIdPerteneceDepto
        End Get
        Set(ByVal value As Integer)
            mIdPerteneceDepto = value
        End Set
    End Property
    'Descripción de Incluido en el Programa para los Parámetros
    Public Property PerteneceDepto() As String
        Get
            PerteneceDepto = mPerteneceDepto
        End Get
        Set(ByVal value As String)
            mPerteneceDepto = value
        End Set
    End Property

    'Descripción de Incluido en el Programa para los Parámetros
    Public Property PerteneceMunic() As String
        Get
            PerteneceMunic = mPerteneceMunic
        End Get
        Set(ByVal value As String)
            mPerteneceMunic = value
        End Set
    End Property
    'Indica si pertenece el Municipio al programa de Micro Crédito
    Public Property IdPerteneceMunic() As Integer
        Get
            IdPerteneceMunic = mIdPerteneceMunic
        End Get
        Set(ByVal value As Integer)
            mIdPerteneceMunic = value
        End Set
    End Property
    'Descripción del Estado del Departamento para los Parámetros
    Public Property EstadoDepto() As String
        Get
            EstadoDepto = mEstadoDepto
        End Get
        Set(ByVal value As String)
            mEstadoDepto = value
        End Set
    End Property

    'Descripción del Estado del Municipio para los Parámetros
    Public Property EstadoMunic() As String
        Get
            EstadoMunic = mEstadoMunic
        End Get
        Set(ByVal value As String)
            mEstadoMunic = value
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
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            Me.txtparametro1.Text = "Depto.: " & Me.mDepartamento & "  " & "Incluido (Depto): " & Me.mPerteneceDepto
            Me.txtparametro2.Text = "Estado (Depto): " & Me.mEstadoDepto & "  " & "Incluido (Munic): " & Me.mPerteneceMunic & "  " & "Estado (Munic): " & Me.mEstadoMunic

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
            xdtMunicipio = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	CargarMunicipio
    ' Description			   	:	Cargar los datos de Barrios
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarMunicipio()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables 

            Strsql = " Select nStbDepartamentoID,nStbMunicipioID,(sCodigoDepto + ' ' + sNombreDepto) as sNombreDepto, " & _
                     "        sCodigoDepto,sNombreDepto,nActivoDepto,nPerteneceProgramaDepto, " & _
                     "        sCodigoMunic,sNombreMunic,nActivoMunic,nPerteneceProgramaMunic " & _
                     " From vwStbMunicipioReporte " & _
                     " Where (nActivoDepto  = " & mIdEstadoDepto & " Or " & mIdEstadoDepto & " = -19)" & _
                     " And (nPerteneceProgramaDepto  = " & mIdPerteneceDepto & " Or " & mIdPerteneceDepto & " = -19)" & _
                     " And (nStbDepartamentoID  = " & mIdDepartamento & " Or " & mIdDepartamento & " = -19)" & _
                     " And (nActivoMunic  = " & mIdEstadoMunic & " Or " & mIdEstadoMunic & " = -19)" & _
                     " And (nPerteneceProgramaMunic  = " & mIdPerteneceMunic & " Or " & mIdPerteneceMunic & " = -19)" & _
                     " Order by sCodigoDepto,sCodigoMunic "

            xdtMunicipio.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub rptStbMunicipio_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarMunicipio()

            If xdtMunicipio.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtMunicipio.Table

            'Asignar el data field
            Me.txtDepartamento.DataField = "sNombreDepto"
            Me.chkActivoDepto.DataField = "nActivoDepto"
            Me.txtNombre.DataField = "sNombreMunic"
            Me.txtCodigo.DataField = "sCodigoMunic"
            Me.chkactivo.DataField = "nActivoMunic"
            Me.chkIncluidoDepto.DataField = "nPerteneceProgramaDepto"
            Me.chkIncluidoPrograma.DataField = "nPerteneceProgramaMunic"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
