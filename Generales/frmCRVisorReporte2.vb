Imports CrystalDecisions.Shared
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Windows.Forms
Imports CrystalLibrary

Public Class frmCRVisorReporte2

    Dim listaParametros As SortedList(Of String, Object)
    Dim listaFormulas As SortedList(Of String, Object)
    Dim registroSeleccion As String
    Dim consultaSQL As String
    Dim reporteNombre As String
    Dim reportLoad As Boolean = False

    Dim CrystalHelper As CrystalLibrary.CrystalConnector
    Dim DSConnect As New DSSistema.DSSistema

    Public Property Parametros(ByVal nombreParametro As String) As Object
        Get
            If listaParametros.ContainsKey(nombreParametro) Then
                Return listaParametros(nombreParametro)
            Else
                Return ""
            End If
        End Get

        Set(ByVal value As Object)
            If listaParametros.ContainsKey(nombreParametro) Then
                listaParametros(nombreParametro) = value
            Else
                listaParametros.Add(nombreParametro, value)
            End If
        End Set
    End Property

    Public Property Formulas(ByVal nombreFormula As String) As Object
        Get
            If listaFormulas.ContainsKey(nombreFormula) Then
                Return listaFormulas(nombreFormula)
            Else
                Return ""
            End If
        End Get
        Set(ByVal value As Object)
            If listaFormulas.ContainsKey(nombreFormula) Then
                listaFormulas(nombreFormula) = value
            Else
                listaFormulas.Add(nombreFormula, value)
            End If
        End Set
    End Property

    Public Property RegistrosSeleccion() As String

        Get
            Return registroSeleccion
        End Get
        Set(ByVal value As String)
            registroSeleccion = value
        End Set
    End Property

    Public Property SQLQuery() As String
        Get
            Return consultaSQL
        End Get
        Set(ByVal value As String)
            consultaSQL = value
        End Set
    End Property

    Public Property NombreReporte() As String
        Get
            Return reporteNombre
        End Get
        Set(ByVal value As String)
            reporteNombre = value
        End Set
    End Property

    Private Function GetHostIPAddress(ByVal HostName As String) As String
        Try
            GetHostIPAddress = System.Net.Dns.GetHostEntry(HostName).AddressList(0).ToString()
        Catch ex As Exception
            GetHostIPAddress = ""
        End Try
    End Function

    Private Sub ConfigureCrystalReports()
        Dim i As Integer
        'Dim sIPAddress As String

        Me.Cursor = Cursors.WaitCursor
        'btnExport.Enabled = False
        'btnExport.ImageIndex = 0

        For i = 1 To listaParametros.Count
            CrystalHelper.SetParameter(listaParametros.Keys(i - 1), listaParametros.Values(i - 1))
        Next

        For i = 1 To listaFormulas.Count
            CrystalHelper.SetFormula(listaFormulas.Keys(i - 1), listaFormulas.Values(i - 1))
        Next

        If Strings.Len(registroSeleccion) > 0 Then
            CrystalHelper.SetRecordSelection(registroSeleccion)
        End If

        'CrystalHelper.ServerName = DSConnect.ServerName
        'sIPAddress = GetHostIPAddress(DSConnect.ServerName)
        'CrystalHelper.ServerName = IIf(Len(sIPAddress) > 0, sIPAddress, DSConnect.ServerName)
        CrystalHelper.ServerName = "10.99.240.20"
        CrystalHelper.DatabaseName = DSConnect.DbName
        CrystalHelper.UserId = DSConnect.DbUserName
        CrystalHelper.Password = DSConnect.DbUserPassword

        If Strings.Len(consultaSQL) > 0 Then
            CrystalHelper.SQLQuery = consultaSQL
        End If

        If My.Computer.FileSystem.FileExists(My.Application.Info.DirectoryPath & "\Reportes\" & reporteNombre) = True Then
            CrystalHelper.ReportFile = My.Application.Info.DirectoryPath & "\Reportes\" & reporteNombre
            CrystalHelper.Open()

            'btnExport.Enabled = True
            'btnExport.ImageIndex = 1

            CRVReportes.ReportSource = CrystalHelper.ReportSource
            CrystalConnector.ViewerTabs(CRVReportes, False)

            reportLoad = True
        Else
            MsgBox("Archivo del reporte no encontrado", MsgBoxStyle.Critical, "Visor Reportes")
        End If

        Me.Cursor = Cursors.Default
    End Sub

    Private Sub frmCRVisorReporte_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        If KillConnReports = True Then

            Dim rd As CrystalDecisions.CrystalReports.Engine.ReportDocument

            Dim tbl As CrystalDecisions.CrystalReports.Engine.Table

            rd = DirectCast(CRVReportes.ReportSource, CrystalDecisions.CrystalReports.Engine.ReportDocument)

            For Each tbl In rd.Database.Tables
                tbl.Dispose()
            Next

            rd.Database.Dispose()
            rd.Close()
            rd.Dispose()

            CrystalHelper.Close()
            CrystalHelper.Dispose()
            CrystalHelper = Nothing
            DSConnect.Close()
            DSConnect.Dispose()
            DSConnect = Nothing

            'CRVReportes.Dispose()
            'CRVReportes = Nothing

            'If (Me.Modal) Then
            '    Me.Dispose()
            'End If

            'GC.Collect()
        End If
        KillConnReports = True
    End Sub

    Private Sub frmCRVisorReporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        CrystalHelper = New CrystalLibrary.CrystalConnector
        ConfigureCrystalReports()

        If Seg.HasPermission("_PermiteExportarReportes") Then
            CRVReportes.ShowExportButton = True
        End If

    End Sub

    Private Sub CRVReportes_ReportRefresh(ByVal source As Object, ByVal e As CrystalDecisions.Windows.Forms.ViewerEventArgs) Handles CRVReportes.ReportRefresh
        CrystalHelper.Close()
        CrystalHelper.ReportFile = Nothing
        ConfigureCrystalReports()
        e.Handled = True
    End Sub

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Me.listaParametros = New SortedList(Of String, Object)
        Me.listaFormulas = New SortedList(Of String, Object)
        Me.registroSeleccion = ""
        Me.consultaSQL = ""
        Me.reporteNombre = ""
    End Sub

    'Private Sub btnExport_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.MouseEnter
    '    btnExport.FlatAppearance.BorderColor = Color.Black
    'End Sub

    'Private Sub btnExport_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnExport.MouseLeave
    '    btnExport.FlatAppearance.BorderColor = Color.Gainsboro
    'End Sub

    'Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
    '    btnFinal.Focus()
    '    If CrystalHelper.ReportSource.IsLoaded = True And reportLoad = True Then
    '        DialogExport.Title = "Exportar informe"
    '        DialogExport.Filter = CrystalConnector.ExportFilter
    '        DialogExport.OverwritePrompt = True
    '        DialogExport.InitialDirectory = MyCurrentDocs
    '        If DialogExport.ShowDialog(Me) = Windows.Forms.DialogResult.OK Then
    '            CrystalHelper.Export(DialogExport.FileName)
    '        End If
    '        MsgBox("Reporte exportado Exitosamente.", MsgBoxStyle.Information)

    '    End If
    'End Sub
End Class
