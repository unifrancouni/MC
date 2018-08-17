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

Public Class rptSclLstGrupoPago

    Dim objEncabezado As rptEncabezadoH
    Dim XdtGrupo As BOSistema.Win.XDataSet.xDataTable

    Dim mIdLugarPago As Integer
    Dim mLugarPago As String

    Dim mIdDepartamento As Integer
    Dim mDepartamento As String

    Dim mIdMunicipio As Integer
    Dim mMunicipio As String

    Dim mIdDistrito As Integer
    Dim mDistrito As String

    Dim mIdDiaPago As Integer
    Dim mDiaPago As String


    Dim mIdPrograma As Integer
    Dim mPrograma As String

    Dim intIncluyeSocias As Integer

    Public Property IdPrograma() As Integer
        Get
            IdPrograma = mIdPrograma
        End Get
        Set(ByVal value As Integer)
            mIdPrograma = value
        End Set
    End Property

    'Indica el tipo de Ordenamiento a realizar
    'sobre la fuente de datos ----------------
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = mIdDepartamento
        End Get
        Set(ByVal value As Integer)
            mIdDepartamento = value
        End Set
    End Property

    Public Property IncluyeSocias() As Integer
        Get
            IncluyeSocias = intIncluyeSocias
        End Get
        Set(ByVal value As Integer)
            intIncluyeSocias = value
        End Set
    End Property


    Public Property IdMunicipio() As Integer
        Get
            IdMunicipio = mIdMunicipio
        End Get
        Set(ByVal value As Integer)
            mIdMunicipio = value
        End Set
    End Property

    Public Property IdDistrito() As Integer
        Get
            IdDistrito = mIdDistrito
        End Get
        Set(ByVal value As Integer)
            mIdDistrito = value
        End Set
    End Property

    Public Property IdLugarPago() As Integer
        Get
            IdLugarPago = mIdLugarPago
        End Get
        Set(ByVal value As Integer)
            mIdLugarPago = value
        End Set
    End Property

    Public Property IdDiaPago() As Integer
        Get
            IdDiaPago = mIdDiaPago
        End Get
        Set(ByVal value As Integer)
            mIdDiaPago = value
        End Set
    End Property

    Public Property Departamento() As String
        Get
            Departamento = mDepartamento
        End Get
        Set(ByVal value As String)
            mDepartamento = value
        End Set
    End Property

    Public Property Municipio() As String
        Get
            Municipio = mMunicipio
        End Get
        Set(ByVal value As String)
            mMunicipio = value
        End Set
    End Property
    Public Property Distrito() As String
        Get
            Distrito = mDistrito
        End Get
        Set(ByVal value As String)
            mDistrito = value
        End Set
    End Property
    Public Property LugarPago() As String
        Get
            LugarPago = mLugarPago
        End Get
        Set(ByVal value As String)
            mLugarPago = value
        End Set
    End Property
    Public Property DiaPago() As String
        Get
            DiaPago = mDiaPago
        End Get
        Set(ByVal value As String)
            mDiaPago = value
        End Set
    End Property

    Public Property Programa() As String
        Get
            Programa = mPrograma
        End Get
        Set(ByVal value As String)
            mPrograma = value
        End Set
    End Property

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format

        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            Me.txtparametro1.Text = "Depto.: " & Me.mDepartamento & "  " & "Munic.: " & Me.mMunicipio + " Programa: " + Me.Programa
            Me.txtparametro2.Text = "Distrito: " & Me.mDistrito & "  " & "Lugar de Pago: " & Me.mLugarPago & "  " & "Día de Pago: " & Me.mDiaPago

            'If mIdOrdenamiento = 1 Then
            '    Me.txtparametro1.Text = "Ordenado por: Código."
            'ElseIf mIdOrdenamiento = 2 Then
            '    Me.txtparametro1.Text = "Ordenado por: Nombre."
            'End If

            'If mIdGrupo = 0 Then 'Todos los Grupos
            '    Me.txtparametro2.Text = "Grupo Solidario: TODOS. Estado: " & mEstado
            'Else
            '    Me.txtparametro2.Text = "Nombre Grupo: " & mNombreGrupo
            'End If

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
        'Dim StrCriterio As String
        'Dim StrOrden As String

        Try
            'Inicializa Variables 
            Strsql = ""
            'StrOrden = ""
            '------------------------
            Strsql = " Select nSclGrupoSolidarioID, " & _
                     "        sCodigo, " & _
                     "        sDescripcion, " & _
                     "        nStbEstadoGrupoID," & _
                     "        Estado, " & _
                     "        Departamento,sLugarPago,sDiaPago, " & _
                     "        Municipio," & _
                     "        Distrito, " & _
                     "        Barrio, " & _
                     "        Mercado,nSociasGrupo, " & _
                     "        CodigoSocia, " & _
                     "        NombreSocia, " & _
                     "        sNumeroCedula, " & _
                     "        sDireccionSocia, " & _
                     "        sTelefonoSocia, " & _
                     "        nCoordinador " & _
                     " From   vwSclGrupoPagoRep " & _
                     " Where nCreditoRechazado = 0 " & _
                     " And (intLugarPagoID  = " & mIdLugarPago & " Or " & mIdLugarPago & " = -19)" & _
                     " And nStbEstadoCreditoID IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('2') And b.sNombre = 'EstadoCredito') " & _
                     " And (intDiaPagoID  = " & mIdDiaPago & " Or " & mIdDiaPago & " = -19)" & _
                     " And (nStbMunicipioID  = " & mIdMunicipio & " Or " & mIdMunicipio & " = -19)" & _
                     " And (nStbDepartamentoID  = " & mIdDepartamento & " Or " & mIdDepartamento & " = -19)" & _
                     " And (nStbDistritoID  = " & mIdDistrito & " Or " & mIdDistrito & " = -19)" & _
                     " And (nCoordinador  = " & Me.intIncluyeSocias & " Or " & intIncluyeSocias & " = -19)" & _
                     " And (CodPrograma  = '" & Me.IdPrograma & "')" & _
                     " Order by nStbDepartamentoID,nStbMunicipioID,nStbDistritoID,intLugarPagoID,intDiaPagoID,sDescripcion,nSclGrupoSolidarioID "

            'If mIdGrupo = 0 Then 'Todos los Grupos
            '    If mIdEstado <> -19 Then
            '        StrCriterio = " Where (nStbEstadoGrupoID  = " & mIdEstado & ")"
            '    Else
            '        StrCriterio = " "
            '    End If
            'Else
            '    StrCriterio = " Where (nSclGrupoSolidarioID  = " & mIdGrupo & ")"
            'End If

            ''-- El ordenamiento es por CODIGO
            'If mIdOrdenamiento = 1 Then
            '    StrOrden = " Order By sCodigo ASC, nCoordinador DESC, CodigoSocia "
            '    '-- El ordenamiento es por Nombre
            'ElseIf mIdOrdenamiento = 2 Then
            '    StrOrden = " Order By sDescripcion ASC, nCoordinador DESC, CodigoSocia "
            'End If
            XdtGrupo.ExecuteSql(Strsql)

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

            If Me.intIncluyeSocias = 1 Then
                Me.txtTotalSocias2.Visible = True
                Me.txtTotalSocias.Visible = False
            Else
                Me.txtTotalSocias2.Visible = False
                Me.txtTotalSocias.Visible = True
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

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        'If Me.intIncluyeSocias = 1 Then
        '    Me.txtTotalSocias.SummaryFunc = SummaryFunc.DSum
        'Else
        '    Me.txtTotalSocias.SummaryFunc = SummaryFunc.DCount
        'End If
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

    End Sub
End Class
