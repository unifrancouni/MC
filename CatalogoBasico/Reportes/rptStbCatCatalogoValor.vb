Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptStbCatCatalogoValor
    'Declaracion de Variables ----------
    Dim ObjEncabeza As rptEncabezadoV
    Dim XdtCatalogosValores As BOSistema.Win.XDataSet.xDataTable

    Dim mIdEstado As Integer
    Dim mEstadoEstado As String

    Dim mIdCatalogo As Long
    Dim mCatalogo As String
    Public Property IdEstado() As Integer
        Get
            IdEstado = mIdEstado
        End Get
        Set(ByVal value As Integer)
            mIdEstado = value
        End Set
    End Property
    Public Property EstadoEstado() As String
        Get
            EstadoEstado = mEstadoEstado
        End Get
        Set(ByVal value As String)
            mEstadoEstado = value
        End Set
    End Property
    Public Property IdCatalogo() As Long
        Get
            IdCatalogo = midcatalogo
        End Get
        Set(ByVal value As Long)
            midcatalogo = value
        End Set
    End Property
    Public Property Catalogo() As String
        Get
            Catalogo = mCatalogo
        End Get
        Set(ByVal value As String)
            mCatalogo = value
        End Set
    End Property

    Private Sub rptStbCatCatalogoValor_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            Try
                '-----------------------------
                InicializarVariables()
                EstableceMargenesRptLetter(Me)
                CargarDatosEncabezado()
                CargarCatalogosValores()                
                '-----------------------------
                If XdtCatalogosValores.Count = 0 Then                    
                    MsgBox("No hay datos para mostrar en el reporte.", MsgBoxStyle.Exclamation, NombreSistema)
                    Me.Cancel()
                    Exit Sub
                End If

                'Se setea la fuente de datos al reporte
                Me.DataSource = XdtCatalogosValores.Table

            Catch ex As Exception
                Control_Error(ex)
            End Try
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	InicializarVariables
    ' Description			   	:	Este procedimiento permite inicializar las variables generales.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            XdtCatalogosValores = New BOSistema.Win.XDataSet.xDataTable
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub EncabezadoReporte_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles EncabezadoReporte.Format
        Try
            ObjEncabeza = New rptEncabezadoV
            Me.SubReporteEncabezado.Report = ObjEncabeza

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	CargarDatosEncabezado
    ' Description			   	:	Cargar los datos de encabezado del reporte de Catálogos y sus Valores.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarDatosEncabezado()

        'Declaracion de Variables 
        'Dim ObjModulodt As BOSiafi.Win.SsgEntSeguridad.SsgModuloDataTable

        Try
            'ObjModulodt = New BOSiafi.Win.SsgEntSeguridad.SsgModuloDataTable
            'ObjModulodt.Filter = "Upper(Ltrim(Rtrim(CodInterno))) = 'SPR'"
            'ObjModulodt.Retrieve()
            'If ObjModulodt.Count > 0 Then
            '    Me.txtSub.Text = ObjModulodt("Nombre")
            'End If

            'Me.txtUnidad.Text = InfoSistema.CodigoUnidadLocal & " - " & InfoSistema.UnidadSaludLocal
            Me.txtUsuario.Text = InfoSistema.LoginName
            Me.txthora.Text = Now.ToLongTimeString
            Me.txtfecha.Text = Format(Now.Date, "dd/MM/yyyy")
            'Me.txtReporte.Text = "rptStbCatCatalogoValor"

            '- Parámetros del Reporte
            Me.txtParametros.Text = "Parámetros: Estado Catálogo: " & mEstadoEstado
            Me.txtParametros1.Text = "Catálogo: " & mCatalogo

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    ObjModulodt = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	31 de Diciembre del 2006
    ' Procedure name		   	:	CargarCatalogosValores
    ' Description			   	:	Cargar la lista de los Catalogos y sus valores
    ' -----------------------------------------------------------------------------------------
    Public Sub CargarCatalogosValores()

        'Declaracion de Variables 
        Dim Strsql As String

        Try            
            Strsql = " Select nStbCatalogoID       As StbCatalogoID, " & _
                     "        sNombre              As NombreCatalogo," & _
                     "        sDescripcion         As DescripcionCatalogo," & _
                     "        nActivo              As ActivoCatalogo, " & _
                     "        nStbValorCatalogoID  As StbValorCatalogoID, " & _
                     "        sCodigoInterno       As CodigoValorCatalogo, " & _
                     "        ValorDescripcion    As DescripcionValorCatalogo, " & _
                     "        ValorActivo         As ActivoValorCatalogo " & _
                     " From   vwStbCatalogos " & _
                     " Where  (nStbCatalogoID = " & mIdCatalogo & " Or " & mIdCatalogo & "= -19) And " & _
                     "        (nActivo        = " & mIdEstado & " Or " & mIdEstado & " = -19)"
            '------------------------
            XdtCatalogosValores.ExecuteSql(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class
