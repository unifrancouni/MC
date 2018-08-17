Public Class frmSccReportesDirectoAImpresora

    '-----------------------------
    '--------- Atributos ---------
    Dim _formatoId As Int32
    Dim _codigoFicha As String
    Dim _cedulaSocia As String
    Dim _sociadId As Int32
    Dim _estadoFicha As String
    Dim _nombreGrupo As String
    Dim _codigoGrupo As String
    Dim _estadoSDC As String
    Dim snumSesion As String
    Dim _fondo As Integer
    Const Parametro_Impresion As String = "77"

    Dim DataDefault As BOSistema.Win.XDataSet.xDataTable
    Dim fondos As BOSistema.Win.XDataSet.xDataTable

    '-----------------------------
    '------- Propiedades ---------
    Public Property EstadoSDC()
        Get
            Return _estadoSDC
        End Get
        Set(ByVal value)
            _estadoSDC = value
        End Set
    End Property

    Public Property NumSesion()
        Get
            Return snumSesion
        End Get
        Set(ByVal value)
            snumSesion = value
        End Set
    End Property

    Public Property intSclFormatoID()
        Get
            Return _formatoId
        End Get
        Set(ByVal value)
            _formatoId = value
        End Set
    End Property

    Public Property CodigoFichaNotificacion()
        Get
            Return _codigoFicha
        End Get
        Set(ByVal value)
            _codigoFicha = value
        End Set
    End Property

    Public Property CedulaSocia()
        Get
            Return _cedulaSocia
        End Get
        Set(ByVal value)
            _cedulaSocia = value
        End Set
    End Property

    Public Property SociaId()
        Get
            Return _sociadId
        End Get
        Set(ByVal value)
            _sociadId = value
        End Set
    End Property

    Public Property EstadoFicha()
        Get
            Return _estadoFicha
        End Get
        Set(ByVal value)
            _estadoFicha = value
        End Set
    End Property

    Public Property NombreGrupo()
        Get
            Return _nombreGrupo
        End Get
        Set(ByVal value)
            _nombreGrupo = value
        End Set
    End Property

    Public Property CodigoGrupo()
        Get
            Return _codigoGrupo
        End Get
        Set(ByVal value)
            _codigoGrupo = value
        End Set
    End Property

    Public Property Fondo() As Integer
        Get
            Return _fondo
        End Get
        Set(ByVal value As Integer)
            _fondo = value
        End Set
    End Property


    '-----------------------------
    '------- Métodos     ---------
    Private Sub InicializarGrid(ByVal list As List(Of ReportesAImpresora))

        Dim row As Integer = 0
        Dim source As Data.DataTable = ObtenerImpresorasInstaladas()

        For Each _ReportesAImpresora As ReportesAImpresora In list

            Me.grdReports.Rows.Add()
            Me.grdReports.Rows(row).Cells(0).Value = _ReportesAImpresora.Imprimir
            Me.grdReports.Rows(row).Cells(1).Value = _ReportesAImpresora.Nombre
            Me.grdReports.Rows(row).Cells(2).Value = True
            Me.grdReports.Rows(row).Cells(3).Value = _ReportesAImpresora.CantidadCopias
            Me.grdReports.Rows(row).Cells(4).Value = _ReportesAImpresora.Intercalar
            DirectCast(Me.grdReports.Rows(row).Cells(5), DataGridViewComboBoxCell).DataSource = source
            DirectCast(Me.grdReports.Rows(row).Cells(5), DataGridViewComboBoxCell).DisplayMember = "Valor"
            DirectCast(Me.grdReports.Rows(row).Cells(5), DataGridViewComboBoxCell).ValueMember = "Id"
            'Seleccionar la impresora por defecto
            For i As Integer = 0 To source.Rows.Count - 1
                DirectCast(Me.grdReports.Rows(row).Cells(5), DataGridViewComboBoxCell).Value = source.Rows(0)(0).ToString
            Next
            ' Asignamos un Id para poder identificar el reporte
            Me.grdReports.Rows(row).Cells(6).Value = _ReportesAImpresora.Id
            row += 1

        Next

    End Sub

    Public Function ObtenerImpresorasInstaladas() As Data.DataTable
        Dim print As New PrintDialog
        Dim source As New Data.DataTable
        source.Columns.Add("Id", Type.GetType("System.String"))
        source.Columns.Add("Valor", Type.GetType("System.String"))
        For Each impresora As String In Printing.PrinterSettings.InstalledPrinters
            Dim row As Data.DataRow = source.NewRow
            row("Id") = impresora
            row("valor") = impresora
            print.PrinterSettings.PrinterName = impresora
            ' La impresora por defecto siempre estará seleccionada de primero
            If print.PrinterSettings.IsDefaultPrinter Then
                source.Rows.InsertAt(row, 0)
            Else
                source.Rows.Add(row)
            End If
        Next
        Return source
    End Function

    Private Sub ObtenerParametros()
        Try
            DataDefault = New BOSistema.Win.XDataSet.xDataTable
            ' 1. CS4  - Sólo una
            ' 2. CS6  - 1 a doble cara
            ' 3. CS5  - Sólo una
            ' 4. CS11 - FONDOS PROPIOS 
            ' 5. CS11 - EXTERNOS
            ' 6. CS10 - FONDOS PROPIOS 
            ' 7. CS10 - EXTERNOS 
            ' 
            Dim query As String = "SELECT ROW_NUMBER () OVER (ORDER BY [nStbValorParametroID]) No," + Chr(13) _
                                 + "      [nStbValorParametroID]" + Chr(13) _
                                 + "     ,[nStbParametroID]" + Chr(13) _
                                 + "     ,[sValorParametro]" + Chr(13) _
                                 + " FROM [StbValorParametro] " + Chr(13) _
                                 + " WHERE nStbParametroID = " + Parametro_Impresion

            DataDefault.ExecuteSql(query)

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub ConsultarFondo()
        Try
            fondos = New BOSistema.Win.XDataSet.xDataTable
            Dim query As String = "Select DISTINCT" + Chr(13) _
                                         + "       dbo.ScnFuenteFinanciamiento.sCodigo, dbo.ScnFuenteFinanciamiento.sNombre, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID, " + Chr(13) _
                                         + "       dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " + Chr(13) _
                                         + " FROM  dbo.ScnFuenteFinanciamiento INNER JOIN" + Chr(13) _
                                         + "       dbo.SccSolicitudDesembolsoCredito ON " + Chr(13) _
                                         + "       dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID = dbo.SccSolicitudDesembolsoCredito.nScnFuenteFinanciamientoID INNER JOIN" + Chr(13) _
                                         + "       dbo.SclFichaNotificacionDetalle ON " + Chr(13) _
                                         + "       dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID" + Chr(13) _
                                         + " WHERE  (dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = " + intSclFormatoID.ToString + ") "
            If Me.intSclFormatoID = 0 Then
                MsgBox("Debe seleccionar una Ficha", MsgBoxStyle.Information)
                Me.Close()
                Exit Sub
            End If
            fondos.ExecuteSql(query)
            Me.Fondo = Convert.ToInt32(fondos.ValueField("nScnFuenteFinanciamientoID"))

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ObtenerValorParametro(ByVal parametro As Integer) As Integer
        Dim cantidadParametros As Int32 = DataDefault.Table.Rows.Count
        If parametro >= 1 And parametro <= cantidadParametros Then
            Return Convert.ToInt32(DataDefault.Table().Rows(parametro - 1)("sValorParametro"))
        End If
    End Function

    '-----------------------------
    '------- Eventos     ---------
    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        If Not DataDefault Is Nothing Then
            Me.DataDefault = Nothing
        End If
        If Not Me.fondos Is Nothing Then
            Me.fondos = Nothing
        End If
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim objfrmSclParametroFNC As New frmSclParametroFNC
        Dim objfrmSclFichaNotificacionCredito As New frmSclFichaNotificacionCredito
        objfrmSclParametroFNC.intSclFormatoID = Me.intSclFormatoID
        objfrmSclParametroFNC.CodigoFicha = Me.CodigoFichaNotificacion
        objfrmSclParametroFNC.CodigoEstadoFicha = Me.EstadoFicha
        objfrmSclParametroFNC.NombreGrupo = Me.NombreGrupo

        'Imprimir solo aquellos reportes que fueron seleccionados
        For Each row As DataGridViewRow In Me.grdReports.Rows

            If DirectCast(row.Cells("imprimir"), DataGridViewCheckBoxCell).Value Then

                Dim cantidadCopias As Integer = CInt(DirectCast(row.Cells("Cantidad"), DataGridViewTextBoxCell).Value)
                Dim intercalar As Boolean = Convert.ToBoolean(DirectCast(row.Cells("intercalar"), DataGridViewCheckBoxCell).Value)
                Dim simpresora As String = DirectCast(row.Cells("impresora"), DataGridViewComboBoxCell).Value.ToString
                Dim defecto As Boolean = DirectCast(row.Cells("defecto"), DataGridViewCheckBoxCell).Value
                Dim idReporte As Integer = CInt(DirectCast(row.Cells("id"), DataGridViewTextBoxCell).Value)

                Select Case idReporte
                    Case 1
                        If defecto Then
                            cantidadCopias = Me.ObtenerValorParametro(1)
                        End If
                        objfrmSclParametroFNC.RptFichaNotificacionCredito(Me.intSclFormatoID, cantidadCopias, intercalar, simpresora, True)
                    Case 2
                        If defecto Then
                            cantidadCopias = Me.ObtenerValorParametro(2)
                        End If
                        objfrmSclFichaNotificacionCredito.LlamaImprimirPagareGrupoSolidario(Me.EstadoFicha, Me.intSclFormatoID, cantidadCopias, intercalar, simpresora, True, True)
                    Case 3
                        If defecto Then
                            cantidadCopias = Me.ObtenerValorParametro(3)
                        End If
                        objfrmSclParametroFNC.LlamarRepFichaComiteCredito(cantidadCopias, intercalar, simpresora)
                    Case 4
                        If defecto Then
                            If Me.Fondo = 8 Or Me.Fondo = 10 Then ' FONDOS PROPIOS O PDIBA
                                cantidadCopias = Me.ObtenerValorParametro(4)
                            ElseIf Me.Fondo = 6 Or Me.Fondo = 9 Then ' CARUNA
                                cantidadCopias = Me.ObtenerValorParametro(5)
                            End If
                        End If
                        objfrmSclParametroFNC.RepCargarRepSolicitudDesembolso(cantidadCopias, intercalar, simpresora)
                    Case 5
                        If defecto Then
                            If Me.Fondo = 8 Or Me.Fondo = 10 Then ' FONDOS PROPIOS  O PDIBA
                                cantidadCopias = Me.ObtenerValorParametro(6)
                            ElseIf Me.Fondo = 6 Or Me.Fondo = 9 Then ' CARUNA
                                cantidadCopias = Me.ObtenerValorParametro(7)
                            End If
                        End If
                        objfrmSclFichaNotificacionCredito.ImprimirTablaAmortizacion(Me.intSclFormatoID, simpresora, cantidadCopias, intercalar, True)
                    Case 6
                        If defecto Then
                            If Me.Fondo = 8 Or Me.Fondo = 10 Then ' FONDOS PROPIOS  O PDIBA
                                cantidadCopias = Me.ObtenerValorParametro(8)
                            ElseIf Me.Fondo = 6 Or Me.Fondo = 9 Then ' CARUNA
                                cantidadCopias = Me.ObtenerValorParametro(9)
                            End If
                        End If
                        objfrmSclFichaNotificacionCredito.ImprimirPlanillaEfectivo(1, Me.intSclFormatoID, Me.NumSesion, Me.EstadoSDC, simpresora, cantidadCopias, intercalar, Me.CodigoGrupo, True)
                End Select
            End If

        Next
        'Una vez impresos los reportes, cerrar la ventana
        Me.Close()

    End Sub

    Private Sub frmSccReportesDirectoAImpresora_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath

            ObjGUI.SetFormLayout(Me, "Verde")

            'Iniciacilzar la lista con los reportes y agregarlas al GridView
            Dim listReportes As New List(Of ReportesAImpresora)
            listReportes.Add(New ReportesAImpresora(1, False, "FICHA DE NOTIFICACION DE CREDITO", 1, False))
            listReportes.Add(New ReportesAImpresora(2, False, "PAGARE GRUPO SOLIDARIO", 1, False))
            listReportes.Add(New ReportesAImpresora(3, False, "FICHA DE COMITE DE CREDITO", 1, False))
            listReportes.Add(New ReportesAImpresora(4, False, "SOLICITUDES DE DESEMBOLSO", 1, False))
            listReportes.Add(New ReportesAImpresora(5, False, "TABLAS DE AMORTIZACION", 1, False))
            listReportes.Add(New ReportesAImpresora(6, False, "ENTREGA DE CREDITO POR GRUPO SOLIDARIO", 1, False))
            Me.InicializarGrid(listReportes)

            ' Obtenemos los parametros por defecto de impresión
            Me.ObtenerParametros()
            ' Obtener el fondo al que pertenece 
            Me.ConsultarFondo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try


    End Sub

    Private Sub grdReports_CellEndEdit(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles grdReports.CellEndEdit
        'Validación de cantidad de copias 
        If Not Char.IsNumber(grdReports.Rows(e.RowIndex).Cells(3).Value.ToString) Then
            grdReports.Rows(e.RowIndex).Cells(3).Value = 1
        Else
            If CInt(grdReports.Rows(e.RowIndex).Cells(3).Value) <= 0 Then
                grdReports.Rows(e.RowIndex).Cells(3).Value = 1
            End If
        End If
    End Sub

    Private Sub frmSccReportesDirectoAImpresora_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        If Not DataDefault Is Nothing Then
            Me.DataDefault = Nothing
        End If
        If Not Me.fondos Is Nothing Then
            Me.fondos = Nothing
        End If
    End Sub

End Class


