<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbFirmaEmpleado
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
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.btnBuscarFirma = New System.Windows.Forms.Button
        Me.stxtRutaFirma = New System.Windows.Forms.TextBox
        Me.grpVistaPrevia = New System.Windows.Forms.GroupBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnAceptar = New System.Windows.Forms.Button
        Me.btnCancelar = New System.Windows.Forms.Button
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpVistaPrevia.SuspendLayout()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.PictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBox.Location = New System.Drawing.Point(10, 78)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(286, 161)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'btnBuscarFirma
        '
        Me.btnBuscarFirma.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.btnBuscarFirma.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBuscarFirma.Location = New System.Drawing.Point(222, 45)
        Me.btnBuscarFirma.Name = "btnBuscarFirma"
        Me.btnBuscarFirma.Size = New System.Drawing.Size(74, 27)
        Me.btnBuscarFirma.TabIndex = 1
        Me.btnBuscarFirma.Text = "Buscar"
        Me.btnBuscarFirma.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnBuscarFirma.UseVisualStyleBackColor = True
        '
        'stxtRutaFirma
        '
        Me.stxtRutaFirma.BackColor = System.Drawing.SystemColors.Info
        Me.stxtRutaFirma.Enabled = False
        Me.stxtRutaFirma.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold)
        Me.stxtRutaFirma.Location = New System.Drawing.Point(63, 19)
        Me.stxtRutaFirma.Name = "stxtRutaFirma"
        Me.stxtRutaFirma.Size = New System.Drawing.Size(233, 21)
        Me.stxtRutaFirma.TabIndex = 2
        '
        'grpVistaPrevia
        '
        Me.grpVistaPrevia.Controls.Add(Me.Label1)
        Me.grpVistaPrevia.Controls.Add(Me.PictureBox)
        Me.grpVistaPrevia.Controls.Add(Me.btnBuscarFirma)
        Me.grpVistaPrevia.Controls.Add(Me.stxtRutaFirma)
        Me.grpVistaPrevia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.grpVistaPrevia.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpVistaPrevia.Location = New System.Drawing.Point(7, 12)
        Me.grpVistaPrevia.Name = "grpVistaPrevia"
        Me.grpVistaPrevia.Size = New System.Drawing.Size(306, 251)
        Me.grpVistaPrevia.TabIndex = 3
        Me.grpVistaPrevia.TabStop = False
        Me.grpVistaPrevia.Text = "Vista Previa"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 25)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(46, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Código"
        '
        'btnAceptar
        '
        Me.btnAceptar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.btnAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAceptar.Location = New System.Drawing.Point(151, 269)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(79, 27)
        Me.btnAceptar.TabIndex = 3
        Me.btnAceptar.Text = "Actualizar"
        Me.btnAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnCancelar
        '
        Me.btnCancelar.Image = Global.SMUSURA0.My.Resources.Resources._error
        Me.btnCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnCancelar.Location = New System.Drawing.Point(239, 269)
        Me.btnCancelar.Name = "btnCancelar"
        Me.btnCancelar.Size = New System.Drawing.Size(74, 27)
        Me.btnCancelar.TabIndex = 4
        Me.btnCancelar.Text = "Cancelar"
        Me.btnCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnCancelar.UseVisualStyleBackColor = True
        '
        'OpenFileDialog
        '
        Me.OpenFileDialog.FileName = "OpenFileDialog1"
        Me.OpenFileDialog.Filter = "JPEG files| *.jpg"
        Me.OpenFileDialog.Title = "Seleccione la imagen de firma"
        '
        'frmStbFirmaEmpleado
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(321, 304)
        Me.Controls.Add(Me.btnCancelar)
        Me.Controls.Add(Me.btnAceptar)
        Me.Controls.Add(Me.grpVistaPrevia)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "frmStbFirmaEmpleado"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "frmStbFirmaEmpleado"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpVistaPrevia.ResumeLayout(False)
        Me.grpVistaPrevia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents btnBuscarFirma As System.Windows.Forms.Button
    Friend WithEvents stxtRutaFirma As System.Windows.Forms.TextBox
    Friend WithEvents grpVistaPrevia As System.Windows.Forms.GroupBox
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnCancelar As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
End Class
