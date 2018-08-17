Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbPersonaNatural
    'Declaración de Variables

    Dim objEncabezado As rptEncabezadoH
    Dim xdtpersonaNatural As BOSistema.Win.XDataSet.xDataTable

    Dim mIdEstado As Integer
    Dim mEstado As String

    Dim mIdOrden As Integer
    Dim mOrden As String

    Dim mIdTipoPersona As Integer
    Dim mTipoPersona As String


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
    'Indica el tipo de Ordenamiento a realizar
    'sobre la fuente de datos ----------------
    Public Property IdOrden() As Integer
        Get
            IdOrden = mIdOrden
        End Get
        Set(ByVal value As Integer)
            mIdOrden = value
        End Set
    End Property

    Public Property Orden() As String
        Get
            Orden = mOrden
        End Get
        Set(ByVal value As String)
            mOrden = value
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

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        'Declaracion de Variables 

        Try

            Me.txtUsuario.Text = InfoSistema.UsrName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")
            Me.lblTitulo.Text = Me.TipoPersona

            If Me.TipoPersona = "Empleado" Then
                Me.lblCodigoFormato.Text = "CB10"
            End If

            Me.txtParametro1.Text = "Tipo de Persona: " & UCase(Me.TipoPersona)
            Me.txtParametro2.Text = "Estado: " & mEstado & "   " & "Ordenado por: " & mOrden

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

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	15/12/2006
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar los objetos 
    '                           :   de Persona Natural
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            xdtpersonaNatural = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	18/12/2006
    ' Procedure name		   	:	CargarPersonaNatural
    ' Description			   	:	Cargar los datos de Persona Natural
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarPersonaNatural()

        'Declaracion de Variables 
        Dim Strsql As String
        Dim StrOrden As String
        Dim strExcluir As String = ""

        Try
            'Inicializa Variables 
            Strsql = ""
            StrOrden = ""

            '------------------------
            Strsql = " Select nStbPersonaID, " & _
                         "        nCodigo, " & _
                         "        sNombre1 + ' ' + sNombre2 + ' ' + sApellido1RS + ' ' + sApellido2 as Nombre, " & _
                         "        sNumCedula," & _
                         "        sSexo, " & _
                         "        dFechaNacApertura," & _
                         "        sDireccion, " & _
                         "        sTelefono, " & _
                         "        sFax, " & _
                         "        nPersonaActiva " & _
                         " From StbPersona " & _
                         " Where (nPersonaActiva  = " & mIdEstado & " Or " & mIdEstado & " = -19)" & _
                         " And nStbTipoPersonaID = " & Me.IdTipoPersona

            '-- El ordenamiento es por CODIGO
            If mIdOrden = 0 Then
                StrOrden = " Order By nCodigo ASC"
            ElseIf mIdOrden = 1 Then
                StrOrden = " Order By sNumCedula ASC"
            ElseIf mIdOrden = 2 Then
                StrOrden = " Order By sNombre1,sNombre2,sApellido1RS,sApellido2 ASC"
            End If
            xdtpersonaNatural.ExecuteSql(Strsql & strExcluir & StrOrden)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptScnAfectacionporRegistroG_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarPersonaNatural()

            If xdtpersonaNatural.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtpersonaNatural.Table

            'Asignar el data field
            Me.txtCodigo.DataField = "nCodigo"
            Me.txtNombreyA.DataField = "Nombre"
            Me.txtCedula.DataField = "sNumCedula"
            Me.txtSexo.DataField = "sSexo"
            Me.txtFechaN.DataField = "dFechaNacApertura"
            Me.txtDomicilio.DataField = "sDireccion"
            Me.txtTelefono.DataField = "sTelefono"
            Me.txtFx.DataField = "sFAX"
            Me.ChkActivo.DataField = "nPersonaActiva"
            '------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
