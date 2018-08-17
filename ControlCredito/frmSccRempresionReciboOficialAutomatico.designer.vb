<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccRempresionReciboOficialAutomatico
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccRempresionReciboOficialAutomatico))
        Me.C1Sizer1 = New C1.Win.C1Sizer.C1Sizer
        Me.grpImpresora = New System.Windows.Forms.GroupBox
        Me.btnOk = New System.Windows.Forms.Button
        Me.ListBoxImpresora = New System.Windows.Forms.ListBox
        Me.tbRecibo = New System.Windows.Forms.ToolStrip
        Me.toolRefrescarM = New System.Windows.Forms.ToolStripButton
        Me.toolImprimirM = New System.Windows.Forms.ToolStripButton
        Me.toolSeleccionarImpresora = New System.Windows.Forms.ToolStripButton
        Me.grdRecibo = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.grdSocia = New C1.Win.C1TrueDBGrid.C1TrueDBGrid
        Me.tbSocia = New System.Windows.Forms.ToolStrip
        Me.toolBuscar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.toolCerrar = New System.Windows.Forms.ToolStripButton
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1Sizer1.SuspendLayout()
        Me.grpImpresora.SuspendLayout()
        Me.tbRecibo.SuspendLayout()
        CType(Me.grdRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSocia, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tbSocia.SuspendLayout()
        Me.SuspendLayout()
        '
        'C1Sizer1
        '
        Me.C1Sizer1.Controls.Add(Me.grpImpresora)
        Me.C1Sizer1.Controls.Add(Me.tbRecibo)
        Me.C1Sizer1.Controls.Add(Me.grdRecibo)
        Me.C1Sizer1.Controls.Add(Me.grdSocia)
        Me.C1Sizer1.Controls.Add(Me.tbSocia)
        Me.C1Sizer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.C1Sizer1.GridDefinition = resources.GetString("C1Sizer1.GridDefinition")
        Me.C1Sizer1.ImeMode = System.Windows.Forms.ImeMode.NoControl
        Me.C1Sizer1.Location = New System.Drawing.Point(0, 0)
        Me.C1Sizer1.Name = "C1Sizer1"
        Me.C1Sizer1.Size = New System.Drawing.Size(717, 356)
        Me.C1Sizer1.TabIndex = 2
        Me.C1Sizer1.TabStop = False
        '
        'grpImpresora
        '
        Me.grpImpresora.Controls.Add(Me.btnOk)
        Me.grpImpresora.Controls.Add(Me.ListBoxImpresora)
        Me.grpImpresora.Location = New System.Drawing.Point(215, 30)
        Me.grpImpresora.Name = "grpImpresora"
        Me.grpImpresora.Size = New System.Drawing.Size(317, 182)
        Me.grpImpresora.TabIndex = 16
        Me.grpImpresora.TabStop = False
        Me.grpImpresora.Text = "Seleccionar Impresora"
        Me.grpImpresora.Visible = False
        '
        'btnOk
        '
        Me.btnOk.Location = New System.Drawing.Point(236, 152)
        Me.btnOk.Name = "btnOk"
        Me.btnOk.Size = New System.Drawing.Size(75, 23)
        Me.btnOk.TabIndex = 1
        Me.btnOk.Text = "OK"
        Me.btnOk.UseVisualStyleBackColor = True
        '
        'ListBoxImpresora
        '
        Me.ListBoxImpresora.FormattingEnabled = True
        Me.ListBoxImpresora.Location = New System.Drawing.Point(6, 25)
        Me.ListBoxImpresora.Name = "ListBoxImpresora"
        Me.ListBoxImpresora.Size = New System.Drawing.Size(305, 121)
        Me.ListBoxImpresora.TabIndex = 0
        '
        'tbRecibo
        '
        Me.tbRecibo.AutoSize = False
        Me.tbRecibo.Dock = System.Windows.Forms.DockStyle.None
        Me.tbRecibo.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolRefrescarM, Me.toolImprimirM, Me.toolSeleccionarImpresora})
        Me.tbRecibo.Location = New System.Drawing.Point(4, 187)
        Me.tbRecibo.Name = "tbRecibo"
        Me.tbRecibo.Size = New System.Drawing.Size(300, 25)
        Me.tbRecibo.Stretch = True
        Me.tbRecibo.TabIndex = 15
        Me.tbRecibo.Text = "ToolStrip1"
        '
        'toolRefrescarM
        '
        Me.toolRefrescarM.AutoSize = False
        Me.toolRefrescarM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescarM.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescarM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolRefrescarM.Name = "toolRefrescarM"
        Me.toolRefrescarM.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescarM.Text = "Refrescar"
        Me.toolRefrescarM.ToolTipText = "Refrescar"
        '
        'toolImprimirM
        '
        Me.toolImprimirM.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirM.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirM.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirM.Name = "toolImprimirM"
        Me.toolImprimirM.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirM.Text = "ToolStripButton1"
        Me.toolImprimirM.ToolTipText = "Imprimir Recibo"
        '
        'toolSeleccionarImpresora
        '
        Me.toolSeleccionarImpresora.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSeleccionarImpresora.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolSeleccionarImpresora.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSeleccionarImpresora.Name = "toolSeleccionarImpresora"
        Me.toolSeleccionarImpresora.Size = New System.Drawing.Size(23, 22)
        Me.toolSeleccionarImpresora.Text = "Seleccionar impresora"
        '
        'grdRecibo
        '
        Me.grdRecibo.AllowFilter = False
        Me.grdRecibo.AllowUpdate = False
        Me.grdRecibo.Caption = "Listado de Recibos"
        Me.grdRecibo.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdRecibo.FilterBar = True
        Me.grdRecibo.GroupByAreaVisible = False
        Me.grdRecibo.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdRecibo.Images.Add(CType(resources.GetObject("grdRecibo.Images"), System.Drawing.Image))
        Me.grdRecibo.Location = New System.Drawing.Point(4, 216)
        Me.grdRecibo.Name = "grdRecibo"
        Me.grdRecibo.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdRecibo.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdRecibo.PreviewInfo.ZoomFactor = 75
        Me.grdRecibo.PrintInfo.PageSettings = CType(resources.GetObject("grdRecibo.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdRecibo.Size = New System.Drawing.Size(709, 136)
        Me.grdRecibo.TabIndex = 14
        Me.grdRecibo.Text = "grdModulo"
        Me.grdRecibo.PropBag = resources.GetString("grdRecibo.PropBag")
        '
        'grdSocia
        '
        Me.grdSocia.AllowFilter = False
        Me.grdSocia.AllowUpdate = False
        Me.grdSocia.Caption = "Listado de Socias"
        Me.grdSocia.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSocia.FilterBar = True
        Me.grdSocia.GroupByAreaVisible = False
        Me.grdSocia.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdSocia.Images.Add(CType(resources.GetObject("grdSocia.Images"), System.Drawing.Image))
        Me.grdSocia.Location = New System.Drawing.Point(4, 30)
        Me.grdSocia.Name = "grdSocia"
        Me.grdSocia.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSocia.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSocia.PreviewInfo.ZoomFactor = 75
        Me.grdSocia.PrintInfo.PageSettings = CType(resources.GetObject("grdSocia.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSocia.Size = New System.Drawing.Size(709, 153)
        Me.grdSocia.TabIndex = 13
        Me.grdSocia.Text = "grdSocia"
        Me.grdSocia.PropBag = resources.GetString("grdSocia.PropBag")
        '
        'tbSocia
        '
        Me.tbSocia.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolBuscar, Me.toolRefrescar, Me.ToolStripSeparator1, Me.toolAyuda, Me.toolCerrar})
        Me.tbSocia.Location = New System.Drawing.Point(4, 4)
        Me.tbSocia.Name = "tbSocia"
        Me.tbSocia.Size = New System.Drawing.Size(709, 22)
        Me.tbSocia.Stretch = True
        Me.tbSocia.TabIndex = 12
        Me.tbSocia.Text = "ToolStrip1"
        '
        'toolBuscar
        '
        Me.toolBuscar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.toolBuscar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolBuscar.Name = "toolBuscar"
        Me.toolBuscar.Size = New System.Drawing.Size(23, 19)
        Me.toolBuscar.Text = "Buscar"
        Me.toolBuscar.ToolTipText = "Buscar"
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 19)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 22)
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.Image = Global.SMUSURA0.My.Resources.Resources.help16
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 19)
        Me.toolAyuda.Text = "Ayuda"
        Me.toolAyuda.ToolTipText = "Ayuda"
        '
        'toolCerrar
        '
        Me.toolCerrar.BackColor = System.Drawing.Color.Transparent
        Me.toolCerrar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolCerrar.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolCerrar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolCerrar.Name = "toolCerrar"
        Me.toolCerrar.Size = New System.Drawing.Size(23, 19)
        Me.toolCerrar.Text = "Cerrar"
        Me.toolCerrar.ToolTipText = "Salir"
        '
        'frmSccRempresionReciboOficialAutomatico
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(717, 356)
        Me.Controls.Add(Me.C1Sizer1)
        Me.Name = "frmSccRempresionReciboOficialAutomatico"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "frmSccRempresionReciboOficialAutomatico"
        CType(Me.C1Sizer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1Sizer1.ResumeLayout(False)
        Me.C1Sizer1.PerformLayout()
        Me.grpImpresora.ResumeLayout(False)
        Me.tbRecibo.ResumeLayout(False)
        Me.tbRecibo.PerformLayout()
        CType(Me.grdRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSocia, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tbSocia.ResumeLayout(False)
        Me.tbSocia.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents C1Sizer1 As C1.Win.C1Sizer.C1Sizer
    Friend WithEvents tbRecibo As System.Windows.Forms.ToolStrip
    Friend WithEvents toolRefrescarM As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolImprimirM As System.Windows.Forms.ToolStripButton
    Friend WithEvents grdRecibo As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents grdSocia As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents tbSocia As System.Windows.Forms.ToolStrip
    Friend WithEvents toolBuscar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolCerrar As System.Windows.Forms.ToolStripButton
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents toolSeleccionarImpresora As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpImpresora As System.Windows.Forms.GroupBox
    Friend WithEvents ListBoxImpresora As System.Windows.Forms.ListBox
    Friend WithEvents btnOk As System.Windows.Forms.Button
End Class
