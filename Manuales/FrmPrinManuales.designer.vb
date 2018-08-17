<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPrinManuales
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmPrinManuales))
        Me.C1MainMenu1 = New C1.Win.C1Command.C1MainMenu
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder
        Me.mnuManuales = New C1.Win.C1Command.C1Command
        Me.mnuAyuda = New C1.Win.C1Command.C1Command
        Me.mnuSalir = New C1.Win.C1Command.C1Command
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink
        Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink
        Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'C1MainMenu1
        '
        Me.C1MainMenu1.CommandHolder = Me.C1CommandHolder1
        Me.C1MainMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink2, Me.C1CommandLink3, Me.C1CommandLink4})
        Me.C1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.C1MainMenu1.Name = "C1MainMenu1"
        Me.C1MainMenu1.Size = New System.Drawing.Size(632, 18)
        Me.C1MainMenu1.Text = "C1MainMenu1"
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Commands.Add(Me.mnuManuales)
        Me.C1CommandHolder1.Commands.Add(Me.mnuAyuda)
        Me.C1CommandHolder1.Commands.Add(Me.mnuSalir)
        Me.C1CommandHolder1.Owner = Me
        '
        'mnuManuales
        '
        Me.mnuManuales.Name = "mnuManuales"
        Me.mnuManuales.Text = "Manuales"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Text = "Ayuda"
        '
        'mnuSalir
        '
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Text = "Salir"
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Command = Me.mnuManuales
        '
        'C1CommandLink3
        '
        Me.C1CommandLink3.Command = Me.mnuAyuda
        Me.C1CommandLink3.SortOrder = 1
        '
        'C1CommandLink4
        '
        Me.C1CommandLink4.Command = Me.mnuSalir
        Me.C1CommandLink4.SortOrder = 2
        '
        'FrmPrinManuales
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SMUSURA0.My.Resources.Resources.Escudo_Nicaragua_transparente
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(632, 453)
        Me.Controls.Add(Me.C1MainMenu1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "FrmPrinManuales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmPrinManuales"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1MainMenu1 As C1.Win.C1Command.C1MainMenu
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents mnuManuales As C1.Win.C1Command.C1Command
    Friend WithEvents mnuAyuda As C1.Win.C1Command.C1Command
    Friend WithEvents mnuSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink

End Class
