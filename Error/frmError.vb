Public Class frmError
    Inherits System.Windows.Forms.Form

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents lblError As System.Windows.Forms.Label
    Friend WithEvents cmdDetalles As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents txtError As System.Windows.Forms.TextBox

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmError))
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.lblError = New System.Windows.Forms.Label
        Me.cmdDetalles = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.txtError = New System.Windows.Forms.TextBox
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PictureBox
        '
        Me.PictureBox.Image = CType(resources.GetObject("PictureBox.Image"), System.Drawing.Image)
        Me.PictureBox.Location = New System.Drawing.Point(4, 4)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(32, 32)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 0
        Me.PictureBox.TabStop = False
        '
        'lblError
        '
        Me.lblError.Location = New System.Drawing.Point(44, 12)
        Me.lblError.Name = "lblError"
        Me.lblError.Size = New System.Drawing.Size(272, 48)
        Me.lblError.TabIndex = 1
        Me.lblError.Text = "Ha ocurrido un error en la aplicacion"
        '
        'cmdDetalles
        '
        Me.cmdDetalles.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdDetalles.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdDetalles.Location = New System.Drawing.Point(319, 37)
        Me.cmdDetalles.Name = "cmdDetalles"
        Me.cmdDetalles.Size = New System.Drawing.Size(75, 23)
        Me.cmdDetalles.TabIndex = 10
        Me.cmdDetalles.Text = "&Detalles >>"
        Me.cmdDetalles.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cmdAceptar
        '
        Me.cmdAceptar.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdAceptar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(319, 9)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 23)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtError
        '
        Me.txtError.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtError.Location = New System.Drawing.Point(4, 88)
        Me.txtError.Multiline = True
        Me.txtError.Name = "txtError"
        Me.txtError.ReadOnly = True
        Me.txtError.Size = New System.Drawing.Size(392, 168)
        Me.txtError.TabIndex = 17
        '
        'frmError
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(398, 67)
        Me.Controls.Add(Me.txtError)
        Me.Controls.Add(Me.cmdDetalles)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.lblError)
        Me.Controls.Add(Me.PictureBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmError"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Error en la aplicacion"
        CType(Me.PictureBox, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

#End Region

    Private Sub cmdDetalles_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDetalles.Click
        If Me.Height = 288 Then
            Me.Height = 112
            cmdDetalles.Text = "Detalles >>"
        Else
            Me.Height = 288
            cmdDetalles.Text = "Ocultar <<"
        End If

        Me.cmdAceptar.Focus()
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Me.Close()
    End Sub
End Class
