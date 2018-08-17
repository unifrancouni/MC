Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbPersonaJuridica

    Dim objEncabezado As rptEncabezadoH
    Dim XdtPersonaJuridica As BOSistema.Win.XDataSet.xDataTable

    Dim mIdEstado As Integer
    Dim mEstado As String

    Dim mIdOrdenamiento As Integer
    Dim mOrdenamiento As String

    Dim mIdTipoPersona As Integer
    Dim mTipoPersona As String

    'Indica el tipo de Ordenamiento a realizar
    'sobre la fuente de datos ----------------
    Public Property IdOrdenamiento() As Integer
        Get
            IdOrdenamiento = mIdOrdenamiento
        End Get
        Set(ByVal value As Integer)
            mIdOrdenamiento = value
        End Set
    End Property
    Public Property Ordenamiento() As String
        Get
            Ordenamiento = mOrdenamiento
        End Get
        Set(ByVal value As String)
            mOrdenamiento = value
        End Set
    End Property
    Public Property IdEstado() As Integer
        Get
            IdEstado = mIdEstado
        End Get
        Set(ByVal value As Integer)
            mIdEstado = value
        End Set
    End Property
    Public Property Estado() As String
        Get
            Estado = mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property
    Public Property IdTipoPersona() As Integer
        Get
            IdTipoPersona = mIdTipoPersona
        End Get
        Set(ByVal value As Integer)
            mIdTipoPersona = value
        End Set
    End Property
    Public Property TipoPersona() As String
        Get
            TipoPersona = mTipoPersona
        End Get
        Set(ByVal value As String)
            mTipoPersona = value
        End Set
    End Property
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        'Declaracion de Variables 

        Try
            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            Me.txtParametro1.Text = "Tipo de Persona: " & UCase(Me.TipoPersona)
            Me.txtParametro2.Text = "Estado: " & mEstado & "   " & "Ordenado por: " & Me.Ordenamiento

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	04/01/2007
    ' Procedure name		   	:	CargarPersonaJuridíca
    ' Description			   	:	Cargar los datos de Persona Jurídica
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarPersonaJuridica()

        'Declaracion de Variables 
        Dim Strsql As String
        Dim StrOrden As String

        Try
            'Inicializa Variables 
            Strsql = ""
            StrOrden = ""
            '------------------------
            Strsql = " Select nStbPersonaID, " & _
                     "        nCodigo, " & _
                     "        sApellido1RS, " & _
                     "        sNumRUC," & _
                     "        sRepresentanteLegal, " & _
                     "        dFechaNacApertura, " & _
                     "        sDireccion," & _
                     "        sTelefono, " & _
                     "        sFax, " & _
                     "        nOtorgaCredito, " & _
                     "        nPersonaActiva " & _
                     " From   StbPersona " & _
                     " Where (nPersonaActiva  = " & mIdEstado & " Or " & mIdEstado & " = -19) " & _
                     " And nStbTipoPersonaID = " & Me.mIdTipoPersona

            '-- El ordenamiento es por CODIGO
            If mIdOrdenamiento = 1 Then
                StrOrden = " Order By nCodigo ASC"
                '-- El ordenamiento es por RAZON SOCIAL
            Else
                StrOrden = " Order By sApellido1RS ASC"
            End If
            XdtPersonaJuridica.ExecuteSql(Strsql & StrOrden)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	04/01/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar los objetos 
    '                           :   de Persona Jurídica
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            XdtPersonaJuridica = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptScnPersonaJuridica_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarPersonaJuridica()

            If xdtpersonaJuridica.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtpersonaJuridica.Table

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabezado = New rptEncabezadoH
            Me.SubReporte.Report = objEncabezado

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
