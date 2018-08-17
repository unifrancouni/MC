<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmVisorReporte
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.VisorReportes = New DataDynamics.ActiveReports.Viewer.Viewer
        Me.SuspendLayout()
        '
        'VisorReportes
        '
        Me.VisorReportes.BackColor = System.Drawing.SystemColors.Control
        Me.VisorReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.VisorReportes.Document = New DataDynamics.ActiveReports.Document.Document("ARNet Document")
        Me.VisorReportes.Location = New System.Drawing.Point(0, 0)
        Me.VisorReportes.Name = "VisorReportes"
        Me.VisorReportes.ReportViewer.BackColor = System.Drawing.SystemColors.Control
        Me.VisorReportes.ReportViewer.CurrentPage = 0
        Me.VisorReportes.ReportViewer.MultiplePageCols = 2
        Me.VisorReportes.ReportViewer.MultiplePageRows = 3
        Me.VisorReportes.ReportViewer.ViewType = DataDynamics.ActiveReports.Viewer.ViewType.Normal
        Me.VisorReportes.Size = New System.Drawing.Size(701, 470)
        Me.VisorReportes.TabIndex = 1
        Me.VisorReportes.TableOfContents.Text = "Table Of Contents"
        Me.VisorReportes.TableOfContents.Width = 200
        Me.VisorReportes.TabTitleLength = 35
        Me.VisorReportes.Toolbar.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        '
        'frmVisorReporte
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(701, 470)
        Me.Controls.Add(Me.VisorReportes)
        Me.Name = "frmVisorReporte"
        Me.Text = "FrmSteVisorReporte"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VisorReportes As DataDynamics.ActiveReports.Viewer.Viewer
End Class
