<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmStbEditCatalogo
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmStbEditCatalogo))
        Me.grpDatosAplicacion = New System.Windows.Forms.GroupBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.ChkReservado = New System.Windows.Forms.CheckBox
        Me.chkActivo = New System.Windows.Forms.CheckBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.grpValores = New System.Windows.Forms.GroupBox
        Me.cmdAgregarValor = New System.Windows.Forms.Button
        Me.GrdValores = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpDatosAplicacion.SuspendLayout()
        Me.grpValores.SuspendLayout()
        CType(Me.GrdValores, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpDatosAplicacion
        '
        Me.grpDatosAplicacion.Controls.Add(Me.Label4)
        Me.grpDatosAplicacion.Controls.Add(Me.Label1)
        Me.grpDatosAplicacion.Controls.Add(Me.txtDescripcion)
        Me.grpDatosAplicacion.Controls.Add(Me.txtNombre)
        Me.grpDatosAplicacion.Controls.Add(Me.ChkReservado)
        Me.grpDatosAplicacion.Controls.Add(Me.chkActivo)
        Me.grpDatosAplicacion.Controls.Add(Me.Label2)
        Me.grpDatosAplicacion.Controls.Add(Me.Label3)
        Me.grpDatosAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosAplicacion.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosAplicacion.Location = New System.Drawing.Point(12, 12)
        Me.grpDatosAplicacion.Name = "grpDatosAplicacion"
        Me.grpDatosAplicacion.Size = New System.Drawing.Size(336, 123)
        Me.grpDatosAplicacion.TabIndex = 0
        Me.grpDatosAplicacion.TabStop = False
        Me.grpDatosAplicacion.Text = "Datos del Catálogo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(240, 96)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 13)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Reservado:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 96)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Activo:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(85, 49)
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(235, 42)
        Me.txtDescripcion.TabIndex = 3
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(85, 23)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(235, 20)
        Me.txtNombre.TabIndex = 1
        '
        'ChkReservado
        '
        Me.ChkReservado.AutoSize = True
        Me.ChkReservado.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.ChkReservado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ChkReservado.Location = New System.Drawing.Point(306, 95)
        Me.ChkReservado.Name = "ChkReservado"
        Me.ChkReservado.Size = New System.Drawing.Size(15, 14)
        Me.ChkReservado.TabIndex = 5
        Me.ChkReservado.UseVisualStyleBackColor = True
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkActivo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkActivo.Location = New System.Drawing.Point(84, 95)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(15, 14)
        Me.chkActivo.TabIndex = 4
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Descripción:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Nombre:"
        '
        'grpValores
        '
        Me.grpValores.Controls.Add(Me.cmdAgregarValor)
        Me.grpValores.Controls.Add(Me.GrdValores)
        Me.grpValores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpValores.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpValores.Location = New System.Drawing.Point(12, 141)
        Me.grpValores.Name = "grpValores"
        Me.grpValores.Size = New System.Drawing.Size(336, 222)
        Me.grpValores.TabIndex = 1
        Me.grpValores.TabStop = False
        Me.grpValores.Text = "Valores del Catálogo"
        '
        'cmdAgregarValor
        '
        Me.cmdAgregarValor.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdAgregarValor.Image = Global.SMUSURA0.My.Resources.Resources.Agregar16
        Me.cmdAgregarValor.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAgregarValor.Location = New System.Drawing.Point(210, 15)
        Me.cmdAgregarValor.Name = "cmdAgregarValor"
        Me.cmdAgregarValor.Size = New System.Drawing.Size(111, 28)
        Me.cmdAgregarValor.TabIndex = 0
        Me.cmdAgregarValor.Text = "Agregar valor "
        Me.cmdAgregarValor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAgregarValor.UseVisualStyleBackColor = True
        '
        'GrdValores
        '
        Me.GrdValores.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GrdValores.GroupByCaption = "Drag a column header here to group by that column"
        Me.GrdValores.Images.Add(CType(resources.GetObject("GrdValores.Images"), System.Drawing.Image))
        Me.GrdValores.Location = New System.Drawing.Point(17, 49)
        Me.GrdValores.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.Simple
        Me.GrdValores.Name = "GrdValores"
        Me.GrdValores.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.GrdValores.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.GrdValores.PreviewInfo.ZoomFactor = 75
        Me.GrdValores.PrintInfo.PageSettings = CType(resources.GetObject("GrdValores.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.GrdValores.Size = New System.Drawing.Size(304, 162)
        Me.GrdValores.TabIndex = 1
        Me.GrdValores.Text = "C1TrueDBGrid1"
        Me.GrdValores.PropBag = resources.GetString("GrdValores.PropBag")
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(192, 369)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(75, 28)
        Me.cmdAceptar.TabIndex = 2
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(273, 369)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(75, 28)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmStbEditCatalogo
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(359, 404)
        Me.Controls.Add(Me.grpValores)
        Me.Controls.Add(Me.grpDatosAplicacion)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de  Catálogos Generales")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmStbEditCatalogo"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " "
        Me.grpDatosAplicacion.ResumeLayout(False)
        Me.grpDatosAplicacion.PerformLayout()
        Me.grpValores.ResumeLayout(False)
        CType(Me.GrdValores, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpDatosAplicacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents grpValores As System.Windows.Forms.GroupBox
    Private WithEvents GrdValores As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Private WithEvents cmdAgregarValor As System.Windows.Forms.Button
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ChkReservado As System.Windows.Forms.CheckBox
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
