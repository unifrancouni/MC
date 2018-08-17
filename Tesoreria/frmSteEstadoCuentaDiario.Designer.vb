<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEstadoCuentaDiario
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEstadoCuentaDiario))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.txtRange = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.lblArchivo = New System.Windows.Forms.Label
        Me.txtArchivo = New System.Windows.Forms.TextBox
        Me.lblHoja = New System.Windows.Forms.Label
        Me.txtNombreHoja = New System.Windows.Forms.TextBox
        Me.tbResultados = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.dgvResultado = New System.Windows.Forms.DataGridView
        Me.cmdCargar = New System.Windows.Forms.Button
        Me.cmdGenerar = New System.Windows.Forms.Button
        Me.btnBuscar = New System.Windows.Forms.Button
        Me.btnExportar = New System.Windows.Forms.Button
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbResultados.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(3, 3)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(652, 234)
        Me.DataGridView1.TabIndex = 0
        '
        'txtRange
        '
        Me.txtRange.Location = New System.Drawing.Point(306, 38)
        Me.txtRange.Name = "txtRange"
        Me.txtRange.Size = New System.Drawing.Size(100, 20)
        Me.txtRange.TabIndex = 2
        Me.txtRange.Text = "A1:E45"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(249, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(39, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Rango"
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog"
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblArchivo.Location = New System.Drawing.Point(15, 13)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(43, 13)
        Me.lblArchivo.TabIndex = 4
        Me.lblArchivo.Text = "Archivo"
        '
        'txtArchivo
        '
        Me.txtArchivo.BackColor = System.Drawing.SystemColors.Info
        Me.txtArchivo.Enabled = False
        Me.txtArchivo.Location = New System.Drawing.Point(64, 6)
        Me.txtArchivo.Name = "txtArchivo"
        Me.txtArchivo.Size = New System.Drawing.Size(342, 20)
        Me.txtArchivo.TabIndex = 5
        '
        'lblHoja
        '
        Me.lblHoja.AutoSize = True
        Me.lblHoja.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblHoja.Location = New System.Drawing.Point(19, 42)
        Me.lblHoja.Name = "lblHoja"
        Me.lblHoja.Size = New System.Drawing.Size(29, 13)
        Me.lblHoja.TabIndex = 9
        Me.lblHoja.Text = "Hoja"
        '
        'txtNombreHoja
        '
        Me.txtNombreHoja.Location = New System.Drawing.Point(64, 36)
        Me.txtNombreHoja.Name = "txtNombreHoja"
        Me.txtNombreHoja.Size = New System.Drawing.Size(143, 20)
        Me.txtNombreHoja.TabIndex = 8
        Me.txtNombreHoja.Text = "sheet1"
        '
        'tbResultados
        '
        Me.tbResultados.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbResultados.Controls.Add(Me.TabPage1)
        Me.tbResultados.Controls.Add(Me.TabPage2)
        Me.tbResultados.Location = New System.Drawing.Point(12, 65)
        Me.tbResultados.Name = "tbResultados"
        Me.tbResultados.SelectedIndex = 0
        Me.tbResultados.Size = New System.Drawing.Size(666, 266)
        Me.tbResultados.TabIndex = 10
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.DataGridView1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(658, 240)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Documento de Excel"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.dgvResultado)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(658, 240)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Resultado"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'dgvResultado
        '
        Me.dgvResultado.AllowUserToAddRows = False
        Me.dgvResultado.AllowUserToDeleteRows = False
        Me.dgvResultado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvResultado.Dock = System.Windows.Forms.DockStyle.Fill
        Me.dgvResultado.Location = New System.Drawing.Point(3, 3)
        Me.dgvResultado.MultiSelect = False
        Me.dgvResultado.Name = "dgvResultado"
        Me.dgvResultado.ReadOnly = True
        Me.dgvResultado.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvResultado.Size = New System.Drawing.Size(652, 234)
        Me.dgvResultado.TabIndex = 0
        '
        'cmdCargar
        '
        Me.cmdCargar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cmdCargar.Image = CType(resources.GetObject("cmdCargar.Image"), System.Drawing.Image)
        Me.cmdCargar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCargar.Location = New System.Drawing.Point(412, 34)
        Me.cmdCargar.Name = "cmdCargar"
        Me.cmdCargar.Size = New System.Drawing.Size(64, 25)
        Me.cmdCargar.TabIndex = 11
        Me.cmdCargar.Text = "Cargar"
        Me.cmdCargar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCargar.UseVisualStyleBackColor = True
        '
        'cmdGenerar
        '
        Me.cmdGenerar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdGenerar.Enabled = False
        Me.cmdGenerar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.cmdGenerar.Image = CType(resources.GetObject("cmdGenerar.Image"), System.Drawing.Image)
        Me.cmdGenerar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdGenerar.Location = New System.Drawing.Point(519, 337)
        Me.cmdGenerar.Name = "cmdGenerar"
        Me.cmdGenerar.Size = New System.Drawing.Size(80, 25)
        Me.cmdGenerar.TabIndex = 12
        Me.cmdGenerar.Text = "Comparar"
        Me.cmdGenerar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdGenerar.UseVisualStyleBackColor = True
        '
        'btnBuscar
        '
        Me.btnBuscar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.btnBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscar.Location = New System.Drawing.Point(412, 2)
        Me.btnBuscar.Name = "btnBuscar"
        Me.btnBuscar.Size = New System.Drawing.Size(64, 25)
        Me.btnBuscar.TabIndex = 13
        Me.btnBuscar.Text = "Buscar"
        Me.btnBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscar.UseVisualStyleBackColor = True
        '
        'btnExportar
        '
        Me.btnExportar.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnExportar.Enabled = False
        Me.btnExportar.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.btnExportar.Image = CType(resources.GetObject("btnExportar.Image"), System.Drawing.Image)
        Me.btnExportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExportar.Location = New System.Drawing.Point(605, 337)
        Me.btnExportar.Name = "btnExportar"
        Me.btnExportar.Size = New System.Drawing.Size(73, 25)
        Me.btnExportar.TabIndex = 14
        Me.btnExportar.Text = "Generar"
        Me.btnExportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnExportar.UseVisualStyleBackColor = True
        '
        'frmSteEstadoCuentaDiario
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(690, 370)
        Me.Controls.Add(Me.btnExportar)
        Me.Controls.Add(Me.btnBuscar)
        Me.Controls.Add(Me.cmdGenerar)
        Me.Controls.Add(Me.cmdCargar)
        Me.Controls.Add(Me.tbResultados)
        Me.Controls.Add(Me.lblHoja)
        Me.Controls.Add(Me.txtNombreHoja)
        Me.Controls.Add(Me.txtArchivo)
        Me.Controls.Add(Me.lblArchivo)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtRange)
        Me.Name = "frmSteEstadoCuentaDiario"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Comparación EC Banco-Sistema "
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbResultados.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        CType(Me.dgvResultado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents txtRange As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents txtArchivo As System.Windows.Forms.TextBox
    Friend WithEvents lblHoja As System.Windows.Forms.Label
    Friend WithEvents txtNombreHoja As System.Windows.Forms.TextBox
    Friend WithEvents tbResultados As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents dgvResultado As System.Windows.Forms.DataGridView
    Friend WithEvents cmdCargar As System.Windows.Forms.Button
    Friend WithEvents cmdGenerar As System.Windows.Forms.Button
    Friend WithEvents btnBuscar As System.Windows.Forms.Button
    Friend WithEvents btnExportar As System.Windows.Forms.Button
End Class
