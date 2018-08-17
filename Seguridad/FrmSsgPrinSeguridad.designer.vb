<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsgPrinSeguridad
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSsgPrinSeguridad))
        Me.C1MainMenu1 = New C1.Win.C1Command.C1MainMenu
        Me.C1CommandHolder1 = New C1.Win.C1Command.C1CommandHolder
        Me.mnuSeguridad = New C1.Win.C1Command.C1Command
        Me.mnuAyuda = New C1.Win.C1Command.C1Command
        Me.mnuVentana = New C1.Win.C1Command.C1Command
        Me.mnuSalir = New C1.Win.C1Command.C1Command
        Me.mnuReportes = New C1.Win.C1Command.C1CommandMenu
        Me.C1CommandLink9 = New C1.Win.C1Command.C1CommandLink
        Me.mnuReporteSSG1 = New C1.Win.C1Command.C1Command
        Me.C1CommandLink6 = New C1.Win.C1Command.C1CommandLink
        Me.mnuReporteSSG2 = New C1.Win.C1Command.C1Command
        Me.C1CommandLink7 = New C1.Win.C1Command.C1CommandLink
        Me.mnuReporteSSG3 = New C1.Win.C1Command.C1Command
        Me.C1CommandLink8 = New C1.Win.C1Command.C1CommandLink
        Me.mnuReporteSSG4 = New C1.Win.C1Command.C1Command
        Me.C1CommandLink1 = New C1.Win.C1Command.C1CommandLink
        Me.C1CommandLink2 = New C1.Win.C1Command.C1CommandLink
        Me.C1CommandLink4 = New C1.Win.C1Command.C1CommandLink
        Me.C1CommandLink3 = New C1.Win.C1Command.C1CommandLink
        Me.C1CommandLink5 = New C1.Win.C1Command.C1CommandLink
        Me.staGeneral = New System.Windows.Forms.StatusStrip
        Me.staFecha = New System.Windows.Forms.ToolStripStatusLabel
        Me.staHora = New System.Windows.Forms.ToolStripStatusLabel
        Me.staUnidadSalud = New System.Windows.Forms.ToolStripStatusLabel
        Me.staServidor = New System.Windows.Forms.ToolStripStatusLabel
        Me.staBaseDatos = New System.Windows.Forms.ToolStripStatusLabel
        Me.staLogin = New System.Windows.Forms.ToolStripStatusLabel
        Me.C1CommandLink10 = New C1.Win.C1Command.C1CommandLink
        Me.mnuReporteSSG5 = New C1.Win.C1Command.C1Command
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.staGeneral.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1MainMenu1
        '
        Me.C1MainMenu1.CommandHolder = Me.C1CommandHolder1
        Me.C1MainMenu1.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink1, Me.C1CommandLink2, Me.C1CommandLink4, Me.C1CommandLink3})
        Me.C1MainMenu1.Dock = System.Windows.Forms.DockStyle.Top
        Me.C1MainMenu1.Location = New System.Drawing.Point(0, 0)
        Me.C1MainMenu1.Name = "C1MainMenu1"
        Me.C1MainMenu1.Size = New System.Drawing.Size(675, 18)
        Me.C1MainMenu1.Text = "C1MainMenu1"
        '
        'C1CommandHolder1
        '
        Me.C1CommandHolder1.Commands.Add(Me.mnuSeguridad)
        Me.C1CommandHolder1.Commands.Add(Me.mnuAyuda)
        Me.C1CommandHolder1.Commands.Add(Me.mnuVentana)
        Me.C1CommandHolder1.Commands.Add(Me.mnuSalir)
        Me.C1CommandHolder1.Commands.Add(Me.mnuReportes)
        Me.C1CommandHolder1.Commands.Add(Me.mnuReporteSSG2)
        Me.C1CommandHolder1.Commands.Add(Me.mnuReporteSSG3)
        Me.C1CommandHolder1.Commands.Add(Me.mnuReporteSSG4)
        Me.C1CommandHolder1.Commands.Add(Me.mnuReporteSSG1)
        Me.C1CommandHolder1.Commands.Add(Me.mnuReporteSSG5)
        Me.C1CommandHolder1.Owner = Me
        '
        'mnuSeguridad
        '
        Me.mnuSeguridad.Icon = CType(resources.GetObject("mnuSeguridad.Icon"), System.Drawing.Icon)
        Me.mnuSeguridad.Name = "mnuSeguridad"
        Me.mnuSeguridad.Text = "&Seguridad"
        Me.mnuSeguridad.ToolTipText = "Subsistema de Seguridad"
        '
        'mnuAyuda
        '
        Me.mnuAyuda.Name = "mnuAyuda"
        Me.mnuAyuda.Text = "&Ayuda"
        Me.mnuAyuda.ToolTipText = "Ayuda"
        '
        'mnuVentana
        '
        Me.mnuVentana.Name = "mnuVentana"
        Me.mnuVentana.Text = "&Ventana"
        Me.mnuVentana.ToolTipText = "Ventana"
        '
        'mnuSalir
        '
        Me.mnuSalir.Name = "mnuSalir"
        Me.mnuSalir.Text = "Salir"
        Me.mnuSalir.ToolTipText = "Salir"
        '
        'mnuReportes
        '
        Me.mnuReportes.CommandLinks.AddRange(New C1.Win.C1Command.C1CommandLink() {Me.C1CommandLink9, Me.C1CommandLink6, Me.C1CommandLink7, Me.C1CommandLink8, Me.C1CommandLink10})
        Me.mnuReportes.Name = "mnuReportes"
        Me.mnuReportes.Text = "Reportes"
        '
        'C1CommandLink9
        '
        Me.C1CommandLink9.Command = Me.mnuReporteSSG1
        '
        'mnuReporteSSG1
        '
        Me.mnuReporteSSG1.Name = "mnuReporteSSG1"
        Me.mnuReporteSSG1.Text = "Listado de Acciones del Sistema SSG1"
        '
        'C1CommandLink6
        '
        Me.C1CommandLink6.Command = Me.mnuReporteSSG2
        Me.C1CommandLink6.SortOrder = 1
        '
        'mnuReporteSSG2
        '
        Me.mnuReporteSSG2.Name = "mnuReporteSSG2"
        Me.mnuReporteSSG2.Text = "Listado de Usuarios SSG2"
        '
        'C1CommandLink7
        '
        Me.C1CommandLink7.Command = Me.mnuReporteSSG3
        Me.C1CommandLink7.SortOrder = 2
        '
        'mnuReporteSSG3
        '
        Me.mnuReporteSSG3.Name = "mnuReporteSSG3"
        Me.mnuReporteSSG3.Text = "Listado de Roles x Usuario SSG3"
        '
        'C1CommandLink8
        '
        Me.C1CommandLink8.Command = Me.mnuReporteSSG4
        Me.C1CommandLink8.SortOrder = 3
        '
        'mnuReporteSSG4
        '
        Me.mnuReporteSSG4.Name = "mnuReporteSSG4"
        Me.mnuReporteSSG4.Text = "Listado de Acciones x Rol SSG4"
        '
        'C1CommandLink1
        '
        Me.C1CommandLink1.Command = Me.mnuSeguridad
        Me.C1CommandLink1.Text = "Seguridad"
        '
        'C1CommandLink2
        '
        Me.C1CommandLink2.Command = Me.mnuAyuda
        Me.C1CommandLink2.SortOrder = 1
        Me.C1CommandLink2.Text = "Ayuda"
        '
        'C1CommandLink4
        '
        Me.C1CommandLink4.Command = Me.mnuSalir
        Me.C1CommandLink4.SortOrder = 2
        '
        'C1CommandLink3
        '
        Me.C1CommandLink3.Command = Me.mnuReportes
        Me.C1CommandLink3.SortOrder = 3
        '
        'staGeneral
        '
        Me.staGeneral.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.staFecha, Me.staHora, Me.staUnidadSalud, Me.staServidor, Me.staBaseDatos, Me.staLogin})
        Me.staGeneral.Location = New System.Drawing.Point(0, 417)
        Me.staGeneral.Name = "staGeneral"
        Me.staGeneral.Size = New System.Drawing.Size(675, 22)
        Me.staGeneral.TabIndex = 17
        '
        'staFecha
        '
        Me.staFecha.BackColor = System.Drawing.SystemColors.Control
        Me.staFecha.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.staFecha.Name = "staFecha"
        Me.staFecha.Size = New System.Drawing.Size(55, 17)
        Me.staFecha.Text = "staFecha"
        '
        'staHora
        '
        Me.staHora.BackColor = System.Drawing.SystemColors.Control
        Me.staHora.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.staHora.Name = "staHora"
        Me.staHora.Size = New System.Drawing.Size(49, 17)
        Me.staHora.Text = "staHora"
        Me.staHora.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.staHora.Visible = False
        '
        'staUnidadSalud
        '
        Me.staUnidadSalud.AutoSize = False
        Me.staUnidadSalud.BackColor = System.Drawing.SystemColors.Control
        Me.staUnidadSalud.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.staUnidadSalud.Name = "staUnidadSalud"
        Me.staUnidadSalud.Size = New System.Drawing.Size(415, 17)
        Me.staUnidadSalud.Spring = True
        Me.staUnidadSalud.Text = "staUnidadSalud"
        '
        'staServidor
        '
        Me.staServidor.BackColor = System.Drawing.SystemColors.Control
        Me.staServidor.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.staServidor.Name = "staServidor"
        Me.staServidor.Size = New System.Drawing.Size(66, 17)
        Me.staServidor.Text = "staServidor"
        Me.staServidor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'staBaseDatos
        '
        Me.staBaseDatos.BackColor = System.Drawing.SystemColors.Control
        Me.staBaseDatos.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right
        Me.staBaseDatos.Name = "staBaseDatos"
        Me.staBaseDatos.Size = New System.Drawing.Size(77, 17)
        Me.staBaseDatos.Text = "staBaseDatos"
        Me.staBaseDatos.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'staLogin
        '
        Me.staLogin.BackColor = System.Drawing.SystemColors.Control
        Me.staLogin.Name = "staLogin"
        Me.staLogin.Size = New System.Drawing.Size(47, 17)
        Me.staLogin.Text = "staLogin"
        Me.staLogin.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'C1CommandLink10
        '
        Me.C1CommandLink10.Command = Me.mnuReporteSSG5
        Me.C1CommandLink10.SortOrder = 4
        Me.C1CommandLink10.Text = "Listado de Actualizacion x Tabla SSG5"
        '
        'mnuReporteSSG5
        '
        Me.mnuReporteSSG5.Name = "mnuReporteSSG5"
        Me.mnuReporteSSG5.Text = "mnuReporteSSG5"
        '
        'FrmSsgPrinSeguridad
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SMUSURA0.My.Resources.Resources.Escudo_Nicaragua_transparente
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(675, 439)
        Me.Controls.Add(Me.staGeneral)
        Me.Controls.Add(Me.C1MainMenu1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.Name = "FrmSsgPrinSeguridad"
        Me.Text = "Seguridad"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.C1CommandHolder1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.staGeneral.ResumeLayout(False)
        Me.staGeneral.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents C1MainMenu1 As C1.Win.C1Command.C1MainMenu
    Friend WithEvents C1CommandHolder1 As C1.Win.C1Command.C1CommandHolder
    Friend WithEvents C1CommandLink1 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuSeguridad As C1.Win.C1Command.C1Command
    Friend WithEvents mnuAyuda As C1.Win.C1Command.C1Command
    Friend WithEvents mnuVentana As C1.Win.C1Command.C1Command
    Friend WithEvents mnuSalir As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink2 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink5 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink4 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents staGeneral As System.Windows.Forms.StatusStrip
    Friend WithEvents staFecha As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents staHora As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents staUnidadSalud As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents staServidor As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents staBaseDatos As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents staLogin As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents mnuReportes As C1.Win.C1Command.C1CommandMenu
    Friend WithEvents C1CommandLink9 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuReporteSSG1 As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink6 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuReporteSSG2 As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink7 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuReporteSSG3 As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink8 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuReporteSSG4 As C1.Win.C1Command.C1Command
    Friend WithEvents C1CommandLink3 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents C1CommandLink10 As C1.Win.C1Command.C1CommandLink
    Friend WithEvents mnuReporteSSG5 As C1.Win.C1Command.C1Command

End Class
