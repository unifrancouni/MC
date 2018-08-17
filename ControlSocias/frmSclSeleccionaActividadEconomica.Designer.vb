<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclSeleccionaActividadEconomica
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclSeleccionaActividadEconomica))
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpSeleccionado = New System.Windows.Forms.GroupBox
        Me.chkDesmarcar = New System.Windows.Forms.CheckBox
        Me.chkMarcar = New System.Windows.Forms.CheckBox
        Me.cmdSeleccionar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grdActividadEconomica = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grpSeleccionado.SuspendLayout()
        CType(Me.grdActividadEconomica, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpSeleccionado
        '
        Me.grpSeleccionado.Controls.Add(Me.chkDesmarcar)
        Me.grpSeleccionado.Controls.Add(Me.chkMarcar)
        Me.grpSeleccionado.Location = New System.Drawing.Point(277, 252)
        Me.grpSeleccionado.Name = "grpSeleccionado"
        Me.grpSeleccionado.Size = New System.Drawing.Size(246, 48)
        Me.grpSeleccionado.TabIndex = 12
        Me.grpSeleccionado.TabStop = False
        Me.grpSeleccionado.Text = "Opciones de Selección"
        '
        'chkDesmarcar
        '
        Me.chkDesmarcar.AutoSize = True
        Me.chkDesmarcar.Location = New System.Drawing.Point(133, 19)
        Me.chkDesmarcar.Name = "chkDesmarcar"
        Me.chkDesmarcar.Size = New System.Drawing.Size(101, 17)
        Me.chkDesmarcar.TabIndex = 1
        Me.chkDesmarcar.Text = "Desmarcar todo"
        Me.chkDesmarcar.UseVisualStyleBackColor = True
        '
        'chkMarcar
        '
        Me.chkMarcar.AutoSize = True
        Me.chkMarcar.Location = New System.Drawing.Point(27, 19)
        Me.chkMarcar.Name = "chkMarcar"
        Me.chkMarcar.Size = New System.Drawing.Size(83, 17)
        Me.chkMarcar.TabIndex = 0
        Me.chkMarcar.Text = "Marcar todo"
        Me.chkMarcar.UseVisualStyleBackColor = True
        '
        'cmdSeleccionar
        '
        Me.cmdSeleccionar.Image = CType(resources.GetObject("cmdSeleccionar.Image"), System.Drawing.Image)
        Me.cmdSeleccionar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSeleccionar.Location = New System.Drawing.Point(371, 306)
        Me.cmdSeleccionar.Name = "cmdSeleccionar"
        Me.cmdSeleccionar.Size = New System.Drawing.Size(73, 27)
        Me.cmdSeleccionar.TabIndex = 10
        Me.cmdSeleccionar.Text = "Aceptar"
        Me.cmdSeleccionar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdSeleccionar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(450, 306)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 27)
        Me.cmdCancelar.TabIndex = 11
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grdActividadEconomica
        '
        Me.grdActividadEconomica.AllowFilter = False
        Me.grdActividadEconomica.Caption = "Listado de Actividades Económicas"
        Me.grdActividadEconomica.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdActividadEconomica.FilterBar = True
        Me.grdActividadEconomica.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdActividadEconomica.Images.Add(CType(resources.GetObject("grdActividadEconomica.Images"), System.Drawing.Image))
        Me.grdActividadEconomica.Location = New System.Drawing.Point(8, 8)
        Me.grdActividadEconomica.Name = "grdActividadEconomica"
        Me.grdActividadEconomica.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdActividadEconomica.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdActividadEconomica.PreviewInfo.ZoomFactor = 75
        Me.grdActividadEconomica.PrintInfo.PageSettings = CType(resources.GetObject("grdActividadEconomica.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdActividadEconomica.Size = New System.Drawing.Size(515, 238)
        Me.grdActividadEconomica.TabIndex = 9
        Me.grdActividadEconomica.Text = "grdClientes"
        Me.grdActividadEconomica.PropBag = resources.GetString("grdActividadEconomica.PropBag")
        '
        'frmSclSeleccionaActividadEconomica
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(535, 343)
        Me.Controls.Add(Me.grpSeleccionado)
        Me.Controls.Add(Me.cmdSeleccionar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grdActividadEconomica)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "frmSclSeleccionaActividadEconomica"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmSclSeleccionaActividadEconomica"
        Me.grpSeleccionado.ResumeLayout(False)
        Me.grpSeleccionado.PerformLayout()
        CType(Me.grdActividadEconomica, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grdActividadEconomica As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents cmdSeleccionar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents grpSeleccionado As System.Windows.Forms.GroupBox
    Friend WithEvents chkDesmarcar As System.Windows.Forms.CheckBox
    Friend WithEvents chkMarcar As System.Windows.Forms.CheckBox
End Class
