'----------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                01/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    rptSclLstGrupoSolidario.vb
' Descripción:          Formulario para impresión del Listado de Grupos Solidarios.
'----------------------------------------------------------------------------------

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclLstGrupoSolidario

    Dim objEncabezado As rptEncabezadoH
    Dim XdtGrupo As BOSistema.Win.XDataSet.xDataTable

    Dim mIdEstado As Integer
    Dim mIdGrupo As Long
    Dim mEstado As String
    Dim mNombreGrupo As String
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

    Public Property IdGrupo() As Long
        Get
            IdGrupo = mIdGrupo
        End Get
        Set(ByVal value As Long)
            mIdGrupo = value
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

    Public Property NombreGrupo() As String
        Get
            NombreGrupo = mNombreGrupo
        End Get
        Set(ByVal value As String)
            mNombreGrupo = value
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
            End If

            If mIdGrupo = 0 Then 'Todos los Grupos
                Me.txtparametro2.Text = "Grupo Solidario: TODOS. Estado: " & mEstado
            Else
                Me.txtparametro2.Text = "Nombre Grupo: " & mNombreGrupo
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	01/10/2007
    ' Procedure name		   	:	CargarGrupo
    ' Description			   	:	Cargar los datos de Grupos del Programa.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarGrupo()

        'Declaracion de Variables 
        Dim Strsql As String
        Dim StrCriterio As String
        Dim StrOrden As String

        Try
            'Inicializa Variables 
            Strsql = ""
            StrOrden = ""
            '------------------------
            Strsql = " Select nSclGrupoSolidarioID, " & _
                     "        sCodigo, " & _
                     "        sDescripcion, " & _
                     "        nStbEstadoGrupoID," & _
                     "        Estado, " & _
                     "        Departamento, " & _
                     "        Municipio," & _
                     "        Distrito, " & _
                     "        Barrio, " & _
                     "        Mercado, " & _
                     "        CodigoSocia, " & _
                     "        NombreSocia, " & _
                     "        sNumeroCedula, " & _
                     "        sDireccionSocia, " & _
                     "        nCoordinador " & _
                     " From   vwSclLstGrupoSolidarioRep "

            If mIdGrupo = 0 Then 'Todos los Grupos
                If mIdEstado <> -19 Then
                    StrCriterio = " Where (nStbEstadoGrupoID  = " & mIdEstado & ")"
                Else
                    StrCriterio = " "
                End If
            Else
                StrCriterio = " Where (nSclGrupoSolidarioID  = " & mIdGrupo & ")"
            End If

            If mIdDelegacion <> 0 Then 'Solo imprimir Grupos de la Delegacion del Usuario.
                If StrCriterio = " " Then
                    StrCriterio = " Where (nStbDelegacionProgramaID  = " & mIdDelegacion & ")"
                Else
                    StrCriterio = StrCriterio & " and (nStbDelegacionProgramaID  = " & mIdDelegacion & ")"
                End If
            End If

            '-- El ordenamiento es por CODIGO
            If mIdOrdenamiento = 1 Then
                StrOrden = " Order By sCodigo ASC, nCoordinador DESC, CodigoSocia "
                '-- El ordenamiento es por Nombre
            ElseIf mIdOrdenamiento = 2 Then
                StrOrden = " Order By sDescripcion ASC, nCoordinador DESC, CodigoSocia "
            End If
                XdtGrupo.ExecuteSql(Strsql & StrCriterio & StrOrden)

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
            XdtGrupo = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSclLstGrupoSolidario_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            XdtGrupo.Close()
            XdtGrupo = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSclLstSocias_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarGrupo()

            If XdtGrupo.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = XdtGrupo.Table

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
