Public Class frmLoadProgress

    <System.Diagnostics.DebuggerNonUserCodeAttribute()> _
    Private Sub BackgroundWorkerLoad_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorkerLoad.DoWork
        Dim frmView As New frmCRVisorReporte
        frmView.Formulas("Usuario") = "'BLANK'"
        frmView.NombreReporte = "RepStbLoadBlank.rpt"
        frmView.Size = New Size(0, 0)
        frmView.StartPosition = FormStartPosition.Manual
        frmView.Location = New Point(Screen.PrimaryScreen.Bounds.Height + 300, Screen.PrimaryScreen.Bounds.Width + 300)
        frmView.MaximizeBox = False
        frmView.MinimizeBox = False
        frmView.ControlBox = False
        frmView.ShowInTaskbar = False
        frmView.ShowIcon = False
        BackgroundWorkerLoad.ReportProgress(40)
        frmView.Show()
        System.Threading.Thread.Sleep(1500)
        frmView.Refresh()
        BackgroundWorkerLoad.ReportProgress(80)
        System.Threading.Thread.Sleep(1500)
        frmView.Close()
        frmView.Dispose()
        frmView = Nothing
        BackgroundWorkerLoad.ReportProgress(100)
        System.Threading.Thread.Sleep(500)
        'KillConnReports = False
    End Sub

    Private Sub frmLoadProgress_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Dispose()
        GC.Collect()
    End Sub

    Private Sub frmLoadProgress_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If Not (Me.Owner Is Nothing) Then
            Me.StartPosition = FormStartPosition.Manual
            Me.Location = New Point(Me.Owner.Size.Width - 340, Me.Owner.Size.Height - 100)
        End If

        BackgroundWorkerLoad.WorkerReportsProgress = True
        BackgroundWorkerLoad.RunWorkerAsync()
    End Sub

    Private Sub BackgroundWorkerLoad_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles BackgroundWorkerLoad.ProgressChanged
        Me.ProgressBarLoad.Value = e.ProgressPercentage
        Me.ProgressBarLoad.PerformStep()
    End Sub

    Private Sub BackgroundWorkerLoad_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorkerLoad.RunWorkerCompleted
        Me.Close()
    End Sub
End Class