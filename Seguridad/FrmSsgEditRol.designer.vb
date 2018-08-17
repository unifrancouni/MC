<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsgEditRol
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSsgEditRol))
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.c1Sizer = New C1.Win.C1Sizer.C1Sizer
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.tabRolAccion = New C1.Win.C1Command.C1DockingTab
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage
        Me.grpDatosRol = New System.Windows.Forms.GroupBox
        Me.lblDescripcion = New System.Windows.Forms.Label
        Me.lblNombre = New System.Windows.Forms.Label
        Me.txtDescripcion = New System.Windows.Forms.TextBox
        Me.txtNombre = New System.Windows.Forms.TextBox
        Me.grpDatosAplicacion = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtNombreA = New System.Windows.Forms.TextBox
        Me.txtCodInternoA = New System.Windows.Forms.TextBox
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grdAcciones = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1Sizer, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.c1Sizer.SuspendLayout()
        CType(Me.tabRolAccion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabRolAccion.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        Me.grpDatosRol.SuspendLayout()
        Me.grpDatosAplicacion.SuspendLayout()
        Me.C1DockingTabPage2.SuspendLayout()
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'c1Sizer
        '
        Me.c1Sizer.Controls.Add(Me.cmdCancelar)
        Me.c1Sizer.Controls.Add(Me.cmdAceptar)
        Me.c1Sizer.Controls.Add(Me.tabRolAccion)
        Me.c1Sizer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1Sizer.GridDefinition = resources.GetString("c1Sizer.GridDefinition")
        Me.c1Sizer.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.c1Sizer.Location = New System.Drawing.Point(0, 0)
        Me.c1Sizer.Name = "c1Sizer"
        Me.c1Sizer.Size = New System.Drawing.Size(663, 427)
        Me.c1Sizer.TabIndex = 0
        Me.c1Sizer.TabStop = False
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(588, 396)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 14
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(511, 396)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 16
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'tabRolAccion
        '
        Me.tabRolAccion.Controls.Add(Me.C1DockingTabPage1)
        Me.tabRolAccion.Controls.Add(Me.C1DockingTabPage2)
        Me.tabRolAccion.Location = New System.Drawing.Point(4, 4)
        Me.tabRolAccion.Name = "tabRolAccion"
        Me.tabRolAccion.SelectedIndex = 1
        Me.tabRolAccion.Size = New System.Drawing.Size(655, 388)
        Me.tabRolAccion.TabIndex = 15
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.grpDatosRol)
        Me.C1DockingTabPage1.Controls.Add(Me.grpDatosAplicacion)
        Me.C1DockingTabPage1.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(653, 362)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Rol"
        '
        'grpDatosRol
        '
        Me.grpDatosRol.Controls.Add(Me.lblDescripcion)
        Me.grpDatosRol.Controls.Add(Me.lblNombre)
        Me.grpDatosRol.Controls.Add(Me.txtDescripcion)
        Me.grpDatosRol.Controls.Add(Me.txtNombre)
        Me.grpDatosRol.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosRol.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosRol.Location = New System.Drawing.Point(14, 97)
        Me.grpDatosRol.Name = "grpDatosRol"
        Me.grpDatosRol.Size = New System.Drawing.Size(621, 248)
        Me.grpDatosRol.TabIndex = 9
        Me.grpDatosRol.TabStop = False
        Me.grpDatosRol.Text = "Datos del Rol"
        '
        'lblDescripcion
        '
        Me.lblDescripcion.AutoSize = True
        Me.lblDescripcion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescripcion.ForeColor = System.Drawing.SystemColors.ControlText
        Me.lblDescripcion.Location = New System.Drawing.Point(6, 45)
        Me.lblDescripcion.Name = "lblDescripcion"
        Me.lblDescripcion.Size = New System.Drawing.Size(66, 13)
        Me.lblDescripcion.TabIndex = 5
        Me.lblDescripcion.Text = "Descripción:"
        Me.lblDescripcion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.lblNombre.Location = New System.Drawing.Point(6, 22)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(47, 13)
        Me.lblNombre.TabIndex = 4
        Me.lblNombre.Text = "Nombre:"
        '
        'txtDescripcion
        '
        Me.txtDescripcion.Location = New System.Drawing.Point(106, 45)
        Me.txtDescripcion.MaxLength = 255
        Me.txtDescripcion.Multiline = True
        Me.txtDescripcion.Name = "txtDescripcion"
        Me.txtDescripcion.Size = New System.Drawing.Size(304, 87)
        Me.txtDescripcion.TabIndex = 2
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(106, 19)
        Me.txtNombre.MaxLength = 50
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(304, 20)
        Me.txtNombre.TabIndex = 1
        '
        'grpDatosAplicacion
        '
        Me.grpDatosAplicacion.Controls.Add(Me.Label2)
        Me.grpDatosAplicacion.Controls.Add(Me.Label3)
        Me.grpDatosAplicacion.Controls.Add(Me.txtNombreA)
        Me.grpDatosAplicacion.Controls.Add(Me.txtCodInternoA)
        Me.grpDatosAplicacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosAplicacion.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosAplicacion.Location = New System.Drawing.Point(14, 13)
        Me.grpDatosAplicacion.Name = "grpDatosAplicacion"
        Me.grpDatosAplicacion.Size = New System.Drawing.Size(621, 78)
        Me.grpDatosAplicacion.TabIndex = 8
        Me.grpDatosAplicacion.TabStop = False
        Me.grpDatosAplicacion.Text = "Datos de la Aplicación"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label2.Location = New System.Drawing.Point(6, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(47, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Código:"
        '
        'txtNombreA
        '
        Me.txtNombreA.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreA.Enabled = False
        Me.txtNombreA.Location = New System.Drawing.Point(106, 48)
        Me.txtNombreA.MaxLength = 100
        Me.txtNombreA.Name = "txtNombreA"
        Me.txtNombreA.Size = New System.Drawing.Size(304, 20)
        Me.txtNombreA.TabIndex = 1
        Me.txtNombreA.Tag = "LAYOUT:FLAT"
        '
        'txtCodInternoA
        '
        Me.txtCodInternoA.BackColor = System.Drawing.SystemColors.Info
        Me.txtCodInternoA.Enabled = False
        Me.txtCodInternoA.Location = New System.Drawing.Point(106, 22)
        Me.txtCodInternoA.MaxLength = 10
        Me.txtCodInternoA.Name = "txtCodInternoA"
        Me.txtCodInternoA.Size = New System.Drawing.Size(100, 20)
        Me.txtCodInternoA.TabIndex = 0
        Me.txtCodInternoA.Tag = "LAYOUT:FLAT"
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.C1Sizer1)
        Me.C1DockingTabPage2.Image = Global.SMUSURA0.My.Resources.Resources.Beneficiario16
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(653, 362)
        Me.C1DockingTabPage2.TabIndex = 1
        Me.C1DockingTabPage2.Text = "Acciones"
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grdAcciones)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(653, 362)
        Me.C1Sizer1.TabIndex = 4
        Me.C1Sizer1.TabStop = False
        '
        'grdAcciones
        '
        Me.grdAcciones.AllowFilter = False
        Me.grdAcciones.ExtendRightColumn = True
        Me.grdAcciones.FilterBar = True
        Me.grdAcciones.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdAcciones.Images.Add(CType(resources.GetObject("grdAcciones.Images"), System.Drawing.Image))
        Me.grdAcciones.Location = New System.Drawing.Point(4, 4)
        Me.grdAcciones.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdAcciones.Name = "grdAcciones"
        Me.grdAcciones.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdAcciones.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdAcciones.PreviewInfo.ZoomFactor = 75
        Me.grdAcciones.PrintInfo.PageSettings = CType(resources.GetObject("grdAcciones.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdAcciones.Size = New System.Drawing.Size(645, 354)
        Me.grdAcciones.TabIndex = 4
        Me.grdAcciones.PropBag = resources.GetString("grdAcciones.PropBag")
        '
        'FrmSsgEditRol
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(663, 427)
        Me.Controls.Add(Me.c1Sizer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Roles")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSsgEditRol"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmSsgEditRol"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1Sizer, System.ComponentModel.ISupportInitialize).EndInit()
        Me.c1Sizer.ResumeLayout(False)
        CType(Me.tabRolAccion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabRolAccion.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.grpDatosRol.ResumeLayout(False)
        Me.grpDatosRol.PerformLayout()
        Me.grpDatosAplicacion.ResumeLayout(False)
        Me.grpDatosAplicacion.PerformLayout()
        Me.C1DockingTabPage2.ResumeLayout(False)
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        CType(Me.grdAcciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents c1Sizer As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tabRolAccion As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grpDatosRol As System.Windows.Forms.GroupBox
    Friend WithEvents lblDescripcion As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents grpDatosAplicacion As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtNombreA As System.Windows.Forms.TextBox
    Friend WithEvents txtCodInternoA As System.Windows.Forms.TextBox
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents grdAcciones As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
