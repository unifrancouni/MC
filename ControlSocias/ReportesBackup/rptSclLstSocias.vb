'------------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                01/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclLstSocias.vb
' Descripción:          Formulario para impresión del Listado de Socias del Programa.
'------------------------------------------------------------------------------------

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclLstSocias

    Dim objEncabezado As rptEncabezadoH
    Dim XdtSocia As BOSistema.Win.XDataSet.xDataTable

    Dim mIdEstado As Integer
    Dim mIdSocia As Long
    Dim mEstado As String
    Dim mNombreSocia As String
    Dim mIdOrdenamiento As Integer
    Dim mIdDelegacion As Integer

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

    Public Property IdDelegacion() As Long
        Get
            IdDelegacion = mIdDelegacion
        End Get
        Set(ByVal value As Long)
            mIdDelegacion = value
        End Set
    End Property

    Public Property IdSocia() As Long
        Get
            IdSocia = mIdSocia
        End Get
        Set(ByVal value As Long)
            mIdSocia = value
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

    Public Property NombreSocia() As String
        Get
            NombreSocia = mNombreSocia
        End Get
        Set(ByVal value As String)
            mNombreSocia = value
        End Set
    End Property

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        Try

            Me.txtUsuario.Text = InfoSistema.UsrName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            If mIdOrdenamiento = 1 Then
                Me.txtparametro1.Text = "Ordenado por: Código."
            ElseIf mIdOrdenamiento = 2 Then
                Me.txtparametro1.Text = "Ordenado por: Nombre."
                '-- El ordenamiento es por Cédula
            ElseIf mIdOrdenamiento = 3 Then
                Me.txtparametro1.Text = "Ordenado por: Cédula."
            End If

            If mIdSocia = 0 Then 'Todas las Socias
                Me.txtparametro2.Text = "Socia: TODAS. Estado: " & mEstado
            Else
                Me.txtparametro2.Text = "Socia: " & mNombreSocia
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	01/10/2007
    ' Procedure name		   	:	CargarSocias
    ' Description			   	:	Cargar los datos de Socias del Programa.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarSocias()

        'Declaracion de Variables 
        Dim Strsql As String
        Dim StrCriterio As String
        Dim StrOrden As String

        Try
            'Inicializa Variables 
            Strsql = ""
            StrOrden = ""
            '------------------------
            Strsql = " Select nSclSociaID, " & _
                     "        nCodigo, " & _
                     "        Nombre, " & _
                     "        sNumeroCedula," & _
                     "        sDireccionSocia, " & _
                     "        sTelefonoSocia, " & _
                     "        nAlfabetizada," & _
                     "        nSociaActiva, " & _
                     "        Primaria, " & _
                     "        Secundaria " & _
                     " From   vwSclLstSociasRep "

            If mIdSocia = 0 Then 'Todas las socias
                If mIdEstado <> -19 Then
                    StrCriterio = " Where (nSociaActiva  = " & mIdEstado & ")"
                Else
                    StrCriterio = " "
                End If

            Else
                StrCriterio = " Where (nSclSociaID  = " & mIdSocia & ")"
            End If

            If mIdDelegacion <> 0 Then 'Solo imprimir Socias de la Delegacion del Usuario.
                If StrCriterio = " " Then
                    StrCriterio = " Where (nStbDelegacionProgramaID  = " & mIdDelegacion & ")"
                Else
                    StrCriterio = StrCriterio & " and (nStbDelegacionProgramaID  = " & mIdDelegacion & ")"
                End If
            End If

            '-- El ordenamiento es por CODIGO
            If mIdOrdenamiento = 1 Then
                StrOrden = " Order By nCodigo ASC"
                '-- El ordenamiento es por Nombre
            ElseIf mIdOrdenamiento = 2 Then
                StrOrden = " Order By Nombre ASC"
                '-- El ordenamiento es por Cédula
            ElseIf mIdOrdenamiento = 3 Then
                StrOrden = " Order By sNumeroCedula ASC"
            End If
            XdtSocia.ExecuteSql(Strsql & StrCriterio & StrOrden)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	01/10/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar los objetos 
    '                           :   de Socias del Programa.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            XdtSocia = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSclLstSocias_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            XdtSocia.Close()
            XdtSocia = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSclLstSocias_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarSocias()

            If XdtSocia.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = XdtSocia.Table

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
