<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccReportesDirectoAImpresora
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
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.grdReports = New System.Windows.Forms.DataGridView
        Me.Button1 = New System.Windows.Forms.Button
        Me.Button2 = New System.Windows.Forms.Button
        Me.imprimir = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Reporte = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.defecto = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.Cantidad = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.intercalar = New System.Windows.Forms.DataGridViewCheckBoxColumn
        Me.impresora = New System.Windows.Forms.DataGridViewComboBoxColumn
        Me.id = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1.SuspendLayout()
        CType(Me.grdReports, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.grdReports)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(678, 231)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccione los reportes a mostrar"
        '
        'grdReports
        '
        Me.grdReports.AllowUserToAddRows = False
        Me.grdReports.AllowUserToDeleteRows = False
        Me.grdReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.grdReports.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.imprimir, Me.Reporte, Me.defecto, Me.Cantidad, Me.intercalar, Me.impresora, Me.id})
        Me.grdReports.Dock = System.Windows.Forms.DockStyle.Fill
        Me.grdReports.Location = New System.Drawing.Point(3, 16)
        Me.grdReports.Name = "grdReports"
        Me.grdReports.Size = New System.Drawing.Size(672, 212)
        Me.grdReports.TabIndex = 4
        '
        'Button1
        '
        Me.Button1.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.Button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button1.Location = New System.Drawing.Point(539, 249)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(70, 29)
        Me.Button1.TabIndex = 2
        Me.Button1.Text = "Imprimir"
        Me.Button1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.Button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Button2.Location = New System.Drawing.Point(615, 249)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(75, 29)
        Me.Button2.TabIndex = 3
        Me.Button2.Text = "Cancelar"
        Me.Button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Button2.UseVisualStyleBackColor = True
        '
        'imprimir
        '
        Me.imprimir.HeaderText = "Imprimir"
        Me.imprimir.Name = "imprimir"
        Me.imprimir.Width = 55
        '
        'Reporte
        '
        Me.Reporte.HeaderText = "Reporte"
        Me.Reporte.Name = "Reporte"
        Me.Reporte.ReadOnly = True
        Me.Reporte.Width = 200
        '
        'defecto
        '
        Me.defecto.HeaderText = "Defecto"
        Me.defecto.Name = "defecto"
        Me.defecto.Width = 55
        '
        'Cantidad
        '
        DataGridViewCellStyle2.Format = "####"
        Me.Cantidad.DefaultCellStyle = DataGridViewCellStyle2
        Me.Cantidad.HeaderText = "Copias"
        Me.Cantidad.Name = "Cantidad"
        Me.Cantidad.Width = 50
        '
        'intercalar
        '
        Me.intercalar.HeaderText = "Intercalar"
        Me.intercalar.Name = "intercalar"
        Me.intercalar.Width = 65
        '
        'impresora
        '
        Me.impresora.FlatStyle = System.Windows.Forms.FlatStyle.Popup
        Me.impresora.HeaderText = "Impresora"
        Me.impresora.Name = "impresora"
        Me.impresora.Width = 200
        '
        'id
        '
        Me.id.HeaderText = "Id"
        Me.id.Name = "id"
        Me.id.Visible = False
        '
        'frmSccReportesDirectoAImpresora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(702, 283)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmSccReportesDirectoAImpresora"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Reportes Directos A Impresora"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.grdReports, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents grdReports As System.Windows.Forms.DataGridView
    Friend WithEvents imprimir As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Reporte As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents defecto As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Cantidad As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents intercalar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents impresora As System.Windows.Forms.DataGridViewComboBoxColumn
    Friend WithEvents id As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
