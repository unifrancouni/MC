'CREATE PROCEDURE spGrabarCierreCartera
'	  @nSccGeneracionCierreID int
'	, @dFechaCierreUltima date
'	, @nMes int
'	, @nAnio int
'	, @sCodigoInterno int -- Código del Estado

Imports C1.Win.C1TrueDBGrid
Imports System.Data.SqlClient

Public Class frmSccCierreCredito
    '- Declaración de Variables 
    Dim cmd As New BOSistema.Win.XComando
    Dim xdt As BOSistema.Win.XDataSet
    Dim dt As New BOSistema.Win.XDataSet.xDataTable


    '-- Parametros 
    Dim dFechaInicio As Date
    Dim dFechaFin As Date


#Region "Conexion"
    Dim con As SqlConnection

    Private Sub ExecuteNonQuery(ByVal strSQL As String)
        Conectar()

        Try
            Dim cmd As New SqlCommand(strSQL, con)
            cmd.CommandTimeout = 3600
            cmd.ExecuteNonQuery()
        Catch ex As SqlException
            Control_Error(ex)
        End Try

        Desconectar()
    End Sub

    Private Sub Conectar()
        con = New SqlConnection
        con.ConnectionString = "Data source=UCERO-PROD; User ID=UsAcceso; password=usuracero; Initial Catalog=SMUSURA0"
        Try
            con.Open()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Desconectar()
        Try
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region



    Private Sub frmSccCierreCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            'InicializaVariables()
            CargarCierre()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub CargarCierre()
        Try
            dt.ExecuteSql("SELECT nSccGeneracionCierreID, dFechaCierreUltima, nMes, nAnio, sCodigoInterno, sDescripcion FROM dbo.vwSccCierreCartera")
            grdCierres.DataSource = dt.Source
            FormatoCierre()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoCierre()
        Try

            'Configuracion del Grid
            Me.grdCierres.Splits(0).DisplayColumns("nSccGeneracionCierreID").Visible = False
            Me.grdCierres.Splits(0).DisplayColumns("dFechaCierreUltima").Visible = True
            Me.grdCierres.Splits(0).DisplayColumns("nMes").Visible = True
            Me.grdCierres.Splits(0).DisplayColumns("nAnio").Visible = True
            Me.grdCierres.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
            Me.grdCierres.Splits(0).DisplayColumns("sDescripcion").Visible = True

            Me.grdCierres.Splits(0).DisplayColumns("dFechaCierreUltima").Width = 150
            Me.grdCierres.Splits(0).DisplayColumns("nMes").Width = 100
            Me.grdCierres.Splits(0).DisplayColumns("nAnio").Width = 100
            Me.grdCierres.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.grdCierres.Columns("dFechaCierreUltima").Caption = "Fecha última de cierre"
            Me.grdCierres.Columns("nMes").Caption = "Mes de Cierre"
            Me.grdCierres.Columns("nAnio").Caption = "Año de Cierre"
            Me.grdCierres.Columns("sDescripcion").Caption = "Estado"

            Me.grdCierres.Splits(0).DisplayColumns("dFechaCierreUltima").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierres.Splits(0).DisplayColumns("nMes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierres.Splits(0).DisplayColumns("nAnio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCierres.Splits(0).DisplayColumns("dFechaCierreUltima").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierres.Splits(0).DisplayColumns("nMes").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierres.Splits(0).DisplayColumns("nAnio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCierres.Splits(0).DisplayColumns("sDescripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCierres.Columns("dFechaCierreUltima").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaImprimir()
        'Dim frmVisor As New frmCRVisorReporte
        'Try
        '    Dim strSQL As String = ""
        '    If Me.grdEjercicio.RowCount = 0 Then
        '        MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
        '        Exit Sub
        '    End If

        '    frmVisor.WindowState = FormWindowState.Maximized
        '    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
        '    frmVisor.NombreReporte = "RepScnCN10.rpt"
        '    frmVisor.Text = "Ejercicios Contables"
        '    frmVisor.SQLQuery = "Select * From vwScnEjerciciosContablesRep Order by nScnEjercicioContableID, nScnPeriodoContableID"
        '    frmVisor.ShowDialog()

        'Catch ex As Exception
        '    Control_Error(ex)
        'Finally
        '    frmVisor = Nothing
        'End Try

    End Sub

    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ''Imprimir Listado:
            'If Seg.HasPermission("ImprimirListadoEjercicios") = False Then
            '    Me.tbEjercicio.Items("toolImprimirL").Enabled = False
            'Else  'Habilita
            '    Me.tbEjercicio.Items("toolImprimirL").Enabled = True
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub AgregarCierre()
        Dim cmd As New BOSistema.Win.XComando
        Dim maximaFecha As Date
        Dim strSQL As String
        Dim obj As Object

        Try
            Me.Cursor = Cursors.WaitCursor

            If Not ValidarDatosEntrada(1) Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strSQL = "SELECT max(dFechaCierreUltima) FROM dbo.vwSccCierreCartera where sCodigoInterno<>'4'"
            obj = cmd.ExecuteScalar(strSQL)
            If Not IsDBNull(obj) Then
                maximaFecha = CDate(obj)
            Else
                maximaFecha = CDate("2014-12-31")
            End If
            maximaFecha = CDate(maximaFecha.Year & "-" & maximaFecha.Month & " - 01")
            maximaFecha = DateAdd(DateInterval.Month, 2, maximaFecha)
            maximaFecha = DateAdd(DateInterval.Day, -1, maximaFecha)

            Dim anio As Integer, mes As Integer
            anio = Year(maximaFecha)
            mes = Month(maximaFecha)
            strSQL = "EXEC spGrabarCierreCartera NULL, " _
                 & "'" & Format(maximaFecha, "yyyy-MM-dd") & "'" & ", " & mes & ", " & anio & ", '1'"
            cmd.ExecuteNonQuery(strSQL)
            MsgBox("Se agregó el registro de cierre para el mes de: " & mes & "/" & anio, vbInformation, "SMUSURA0")
            CargarCierre()

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub GenerarCierre(Optional ByVal nSccGeneracionCierreID As Integer = 0)
        Dim cmd As New BOSistema.Win.XComando
        Dim strSQL As String

        Try
            Me.Cursor = Cursors.WaitCursor

            If nSccGeneracionCierreID = 0 Then
                If dt.Count > 0 Then
                    nSccGeneracionCierreID = dt.ValueField("nSccGeneracionCierreID")
                Else
                    MsgBox("No se seleccionó registro.", vbCritical, "Error")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If Not ValidarDatosEntrada(2, nSccGeneracionCierreID) Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strSQL = "EXEC spGrabarCierreCartera " & nSccGeneracionCierreID & ", " _
                 & "'" & Format(dt.ValueField("dFechaCierreUltima"), "yyyy-MM-dd") & "'" & ", " & 0 & ", " & 0 & ", '2'" '0 y 0 porque no importan el mes y el año, el procedimiento toma solo el '2' y la FechaUltima
            ExecuteNonQuery(strSQL)

            MsgBox("Se ha generado correctamente la cartera.", vbInformation, "Bien!")

            CargarCierre()

            dt.SetCurrentByID("nSccGeneracionCierreID", nSccGeneracionCierreID)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub AnularCierre(Optional ByVal nSccGeneracionCierreID As Integer = 0)
        Dim cmd As New BOSistema.Win.XComando
        Dim strSQL As String

        Try
            Me.Cursor = Cursors.WaitCursor

            If nSccGeneracionCierreID = 0 Then
                If dt.Count > 0 Then
                    nSccGeneracionCierreID = dt.ValueField("nSccGeneracionCierreID")
                Else
                    MsgBox("No se seleccionó registro.", vbCritical, "Error")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If Not ValidarDatosEntrada(4, nSccGeneracionCierreID) Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            strSQL = "EXEC spGrabarCierreCartera " & nSccGeneracionCierreID & ", " _
                 & "'2016-01-01'" & ", " & 0 & ", " & 0 & ", '4'" '2016-01-01, 0 y 0 porque no importan el mes y el año, el procedimiento toma solo el '4'
            ExecuteNonQuery(strSQL)

            MsgBox("Se ha anulado correctamente la cartera.", vbInformation, "Bien!")

            CargarCierre()

            dt.SetCurrentByID("nSccGeneracionCierreID", nSccGeneracionCierreID)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub ConfirmarCierre(Optional ByVal nSccGeneracionCierreID As Integer = 0)
        Dim cmd As New BOSistema.Win.XComando
        Dim strSQL As String

        Try
            Me.Cursor = Cursors.WaitCursor

            If nSccGeneracionCierreID = 0 Then
                If dt.Count > 0 Then
                    nSccGeneracionCierreID = dt.ValueField("nSccGeneracionCierreID")
                Else
                    MsgBox("No se seleccionó registro.", vbCritical, "Error")
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If
            End If

            If Not ValidarDatosEntrada(3, nSccGeneracionCierreID) Then
                Me.Cursor = Cursors.Default
                Exit Sub
            End If

            Dim fecha As Date = dt.ValueField("dFechaCierreUltima")

            strSQL = "EXEC spGrabarCierreCartera " & nSccGeneracionCierreID & ", " _
                 & "'2016-01-01'" & ", " & fecha.Month & ", " & fecha.Year & ", '3'" '2016-01-01 no importa la fecha, el procedimiento toma solo el '3' , mes y año
            ExecuteNonQuery(strSQL) 'No ejecutar si no lleva el mes y el año

            MsgBox("Se ha confirmado correctamente la cartera.", vbInformation, "Bien!")

            CargarCierre()

            dt.SetCurrentByID("nSccGeneracionCierreID", nSccGeneracionCierreID)

            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Function ValidarDatosEntrada(ByVal codigo As Integer, Optional nSccGeneracionCierreID As Integer = 0) As Boolean
        Dim obj As Object
        Dim strSQL As String

        Try
            Select Case codigo
                Case 1
                    strSQL = "SELECT max(dFechaCierreUltima) FROM dbo.vwSccCierreCartera where sCodigoInterno<>'4'"
                    obj = cmd.ExecuteScalar(strSQL)
                    If Not IsDBNull(obj) Then
                        strSQL = "SELECT sCodigoInterno FROM dbo.vwSccCierreCartera where sCodigoInterno<>'4' and dFechaCierreUltima='" & Format(CDate(obj), "yyyy-MM-dd") & "'"
                        obj = cmd.ExecuteScalar(strSQL)

                        If CStr(obj) <> "3" Then
                            MsgBox("El último período no se ha cerrado.", vbCritical, "Error")
                            Return False
                        End If
                    End If
                Case 2
                    strSQL = "SELECT sCodigoInterno FROM dbo.vwSccCierreCartera where nSccGeneracionCierreID=" & nSccGeneracionCierreID
                    obj = cmd.ExecuteScalar(strSQL)
                    If obj = Nothing Then
                        MsgBox("No se ha seleccionado un período.", vbCritical, "Error")
                        Return False
                    End If
                    If CStr(obj) <> "1" Then
                        MsgBox("El período seleccionado no está en proceso.", vbCritical, "Error")
                        Return False
                    End If
                Case 3
                    strSQL = "SELECT sCodigoInterno FROM dbo.vwSccCierreCartera where nSccGeneracionCierreID=" & nSccGeneracionCierreID
                    obj = cmd.ExecuteScalar(strSQL)
                    If obj = Nothing Then
                        MsgBox("No se ha seleccionado un período.", vbCritical, "Error")
                        Return False
                    End If
                    If CStr(obj) <> "2" Then
                        MsgBox("El período seleccionado no está generado.", vbCritical, "Error")
                        Return False
                    End If
                Case 4
                    strSQL = "SELECT max(dFechaCierreUltima) FROM dbo.vwSccCierreCartera where sCodigoInterno<>'4'"
                    obj = cmd.ExecuteScalar(strSQL)
                    If Not IsDBNull(obj) Then
                        strSQL = "SELECT nSccGeneracionCierreID FROM dbo.vwSccCierreCartera where sCodigoInterno<>'4' and dFechaCierreUltima='" & Format(CDate(obj), "yyyy-MM-dd") & "'"
                        obj = cmd.ExecuteScalar(strSQL)

                        If CInt(obj) <> nSccGeneracionCierreID Then
                            MsgBox("El que se debe anular es el ultimo período.", vbCritical, "Error")
                            Return False
                        End If
                    End If

                    strSQL = "SELECT sCodigoInterno FROM dbo.vwSccCierreCartera where nSccGeneracionCierreID=" & nSccGeneracionCierreID
                    obj = cmd.ExecuteScalar(strSQL)
                    If obj = Nothing Then
                        MsgBox("No se ha seleccionado un período.", vbCritical, "Error")
                        Return False
                    End If
                    If CStr(obj) = "4" Then
                        MsgBox("El período seleccionado ya está anulado.", vbCritical, "Error")
                        Return False
                    End If
            End Select
            Return True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub tbEjercicio_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbEjercicio.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarCierre"
                AgregarCierre()
            Case "toolGenerarCierre"
                GenerarCierre()
            Case "toolConfirmarCierre"
                ConfirmarCierre()
            Case "toolAnularCierre"
                AnularCierre()
            Case "toolRefrescar"
                CargarCierre()
            Case "toolSalir"
                Me.Close()
        End Select
    End Sub

    Private Sub grdCierres_Filter(sender As Object, e As FilterEventArgs) Handles grdCierres.Filter
        Try
            dt.FilterLocal(e.Condition)
            'Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdCierres_Error(sender As Object, e As ErrorEventArgs) Handles grdCierres.[Error]
        Control_Error(e.Exception)
    End Sub

End Class