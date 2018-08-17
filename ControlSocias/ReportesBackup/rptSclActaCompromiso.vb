'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                26/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclParametroFNC.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Acta de Compromiso		     
'----------------------------------------------------------------------------

Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class rptSclActaCompromiso

    'Declaracion de Variables
    Dim objEncabeza As rptEncabezadoV
    Dim xdtFormato As BOSistema.Win.XDataSet.xDataTable

    'Datos del Grupo Solidario
    Dim mIdGrupo As Integer
    Dim mCodigoGrupo As String
    Dim mNombreGrupo As String
    Dim mEstado As String

    'Descripción del Estado del Barrio para los Parámetros
    Public Property Estado() As String
        Get
            Estado = mEstado
        End Get
        Set(ByVal value As String)
            mEstado = value
        End Set
    End Property

    'Descripción del Estado del Barrio para los Parámetros
    Public Property NombreGrupo() As String
        Get
            NombreGrupo = mNombreGrupo
        End Get
        Set(ByVal value As String)
            mNombreGrupo = value
        End Set
    End Property

    'ID del Grupo Solidario:
    Public Property IdGrupo() As Integer
        Get
            IdGrupo = mIdGrupo
        End Get
        Set(ByVal value As Integer)
            mIdGrupo = value
        End Set
    End Property

    'Descripción del Grupo Solidario para los Parámetros:
    Public Property CodigoGrupo() As String
        Get
            CodigoGrupo = mCodigoGrupo
        End Get
        Set(ByVal value As String)
            mCodigoGrupo = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/09/2007
    ' Procedure Name:       PageHeader1_Format
    ' Descripción:          Permite asignar Formato del PageHeader.
    '-------------------------------------------------------------------------
    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        Try

            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txtHora.Text = Now.ToLongTimeString
            Me.txtFecha.Text = Format(Now.Date, "dd/MM/yyyy")

            '-- Indica Parámetros:
            Me.txtparametro1.Text = "Estado Grupo Solidario: " & Me.mEstado
            Me.txtparametro2.Text = "Grupo Solidario: " & Me.mCodigoGrupo & "  " & mNombreGrupo

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/09/2007
    ' Procedure Name:       EncabezadoReporte_Format
    ' Descripción:          Asigna Sub-reporte para Encabezado.
    '-------------------------------------------------------------------------
    Private Sub EncabezadoReporte_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            objEncabeza = New rptEncabezadoV
            Me.SubReporte.Report = objEncabeza
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Permite inicializar los objetos. 
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            xdtFormato = New BOSistema.Win.XDataSet.xDataTable

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	CargarActaCompromiso
    ' Description			   	:	Cargar los datos del Acta de Compromiso del Grupo Solidario.
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarActaCompromiso()

        'Declaracion de Variables 
        Dim Strsql As String
        Try
            'Inicializa Variables: 
            Strsql = ""
            Strsql = " Select row_number() OVER (ORDER BY nCoordinador DESC, sNumeroCedula) AS Item, " & _
                     "        nSclGrupoSolidarioID, nCoordinador, " & _
                     "        sCodigo, " & _
                     "        NombreGrupo, " & _
                     "        NombreSocia," & _
                     "        sNumeroCedula, " & _
                     "        NombreCoordinadora, " & _
                     "        Departamento, " & _
                     "        Municipio, " & _
                     "        Distrito, " & _
                     "        Barrio " & _
                     " From vwSclActaCompromisoRep " & _
                     " WHERE (nCreditoRechazado = 0) AND (nSclGrupoSolidarioID = " & mIdGrupo & ") " & _
                     " GROUP BY nSclGrupoSolidarioID, nCoordinador, sCodigo, NombreGrupo, NombreSocia, " & _
                     " sNumeroCedula, NombreCoordinadora, Departamento, Municipio, Distrito, Barrio " & _
                     " Order by nCoordinador DESC, sNumeroCedula  "

            xdtFormato.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub rptSclActaCompromiso_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Try
            xdtFormato.Close()
            xdtFormato = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	26/09/2007
    ' Procedure name		   	:	rptSclActaCompromiso_ReportStart
    ' Description			   	:	Inicialización del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub rptSclActaCompromiso_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try

            InicializarVariables()
            EstableceMargenesRptLetter(Me)
            CargarActaCompromiso()

            If xdtFormato.Count = 0 Then
                MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                Me.Cancel()
                Exit Sub
            End If

            'Se setea la fuente de datos al reporte
            Me.DataSource = xdtFormato.Table

            'Asignar el data field
            Me.txtNombre.DataField = "NombreSocia"
            Me.txtCedula.DataField = "sNumeroCedula"
            Me.txtItem.DataField = "Item"
            Me.txtDepartamento.DataField = "Departamento"
            Me.txtMunicipio.DataField = "Municipio"
            Me.txtDistrito.DataField = "Distrito"
            Me.txtBarrio.DataField = "Barrio"
            'Me.txtFechaF.DataField = "FechaFirma"  REM De ser necesario: Incluir combos con FNC o Ninguna para impresión de la Fecha de Firma.
            Me.lblCoordinadora.Text = xdtFormato.ValueField("NombreCoordinadora")    '"NombreCoordinadora"
            '------------------------
            'Text Encabezado:
            lblEncabezado.Text = "Por medio de la presente, el GRUPO SOLIDARIO: " & mCodigoGrupo & " - " & mNombreGrupo & ", expresamos nuestro acuerdo " & _
                                 "de participar en el Programa Micro Crédito Usura Cero bajo la modalidad de Crédito Solidario, " & _
                                 "comprometiéndonos a cumplir con todos los requisitos establecidos en el Programa y designando " & _
                                 "a la Compañera " & Me.lblCoordinadora.Text & ", coordinadora de este Grupo."


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class