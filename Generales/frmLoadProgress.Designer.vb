<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLoadProgress
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BackgroundWorkerLoad = New System.ComponentModel.BackgroundWorker
        Me.ProgressBarLoad = New System.Windows.Forms.ProgressBar
        Me.LabelLoad = New System.Windows.Forms.Label
        Me.SuspendLayout()
        '
        'BackgroundWorkerLoad
        '
        Me.BackgroundWorkerLoad.WorkerReportsProgress = True
        '
        'ProgressBarLoad
        '
        Me.ProgressBarLoad.Location = New System.Drawing.Point(12, 26)
        Me.ProgressBarLoad.Name = "ProgressBarLoad"
        Me.ProgressBarLoad.Size = New System.Drawing.Size(276, 21)
        Me.ProgressBarLoad.TabIndex = 1
        '
        'LabelLoad
        '
        Me.LabelLoad.AutoSize = True
        Me.LabelLoad.Font = New System.Drawing.Font("Courier New", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelLoad.Location = New System.Drawing.Point(12, 9)
        Me.LabelLoad.Name = "LabelLoad"
        Me.LabelLoad.Size = New System.Drawing.Size(175, 14)
        Me.LabelLoad.TabIndex = 0
        Me.LabelLoad.Text = "Cargando Componentes ..."
        '
        'frmLoadProgress
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(300, 60)
        Me.ControlBox = False
        Me.Controls.Add(Me.LabelLoad)
        Me.Controls.Add(Me.ProgressBarLoad)
        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLoadProgress"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BackgroundWorkerLoad As System.ComponentModel.BackgroundWorker
    Friend WithEvents ProgressBarLoad As System.Windows.Forms.ProgressBar
    Friend WithEvents LabelLoad As System.Windows.Forms.Label
End Class
