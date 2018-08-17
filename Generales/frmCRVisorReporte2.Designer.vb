<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class frmCRVisorReporte2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmCRVisorReporte2))
        Me.CRVReportes = New CrystalDecisions.Windows.Forms.CrystalReportViewer()
        Me.btnFinal = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'CRVReportes
        '
        Me.CRVReportes.ActiveViewIndex = -1
        Me.CRVReportes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.CRVReportes.Cursor = System.Windows.Forms.Cursors.Default
        Me.CRVReportes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CRVReportes.Location = New System.Drawing.Point(0, 0)
        Me.CRVReportes.Name = "CRVReportes"
        Me.CRVReportes.ShowGroupTreeButton = False
        Me.CRVReportes.ShowExportButton = False
        Me.CRVReportes.Size = New System.Drawing.Size(874, 583)
        Me.CRVReportes.TabIndex = 0
        Me.CRVReportes.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None
        '
        'btnFinal
        '
        Me.btnFinal.BackColor = System.Drawing.Color.Gainsboro
        Me.btnFinal.FlatAppearance.BorderColor = System.Drawing.Color.Gainsboro
        Me.btnFinal.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DarkTurquoise
        Me.btnFinal.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkTurquoise
        Me.btnFinal.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFinal.ForeColor = System.Drawing.Color.WhiteSmoke
        Me.btnFinal.Location = New System.Drawing.Point(864, 12)
        Me.btnFinal.Name = "btnFinal"
        Me.btnFinal.Size = New System.Drawing.Size(5, 5)
        Me.btnFinal.TabIndex = 2
        Me.btnFinal.TabStop = False
        Me.btnFinal.UseVisualStyleBackColor = False
        '
        'frmCRVisorReporte2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(874, 583)
        Me.Controls.Add(Me.btnFinal)
        Me.Controls.Add(Me.CRVReportes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmCRVisorReporte2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmCRVisorReporte"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CRVReportes As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents btnFinal As System.Windows.Forms.Button

End Class
