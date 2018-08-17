<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmScnProcesoCDR
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnProcesoCDR))
        Me.tbProcesoCDR = New System.Windows.Forms.ToolStrip()
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton()
        Me.toolGenerarCDR = New System.Windows.Forms.ToolStripButton()
        Me.toolAsignar = New System.Windows.Forms.ToolStripButton()
        Me.toolAutorizar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator()
        Me.toolSalir = New System.Windows.Forms.ToolStripButton()
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit()
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.grdListadoGeneracionesCDR = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip()
        Me.lblUltimaEjecucionJob = New System.Windows.Forms.ToolStripStatusLabel()
        Me.toolImprimirCDR = New System.Windows.Forms.ToolStripButton()
        Me.tbProcesoCDR.SuspendLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdListadoGeneracionesCDR, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.StatusStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'tbProcesoCDR
        '
        Me.tbProcesoCDR.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.toolRefrescar, Me.toolGenerarCDR, Me.toolAsignar, Me.toolAutorizar, Me.toolImprimirCDR, Me.ToolStripButton7, Me.toolSalir})
        Me.tbProcesoCDR.Location = New System.Drawing.Point(0, 0)
        Me.tbProcesoCDR.Name = "tbProcesoCDR"
        Me.tbProcesoCDR.Size = New System.Drawing.Size(894, 25)
        Me.tbProcesoCDR.Stretch = True
        Me.tbProcesoCDR.TabIndex = 13
        Me.tbProcesoCDR.Text = "ToolStrip1"
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.Image = Global.SMUSURA0.My.Resources.Resources.Refrescar16
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolGenerarCDR
        '
        Me.toolGenerarCDR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolGenerarCDR.Image = Global.SMUSURA0.My.Resources.Resources.Procesar
        Me.toolGenerarCDR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolGenerarCDR.Name = "toolGenerarCDR"
        Me.toolGenerarCDR.Size = New System.Drawing.Size(23, 22)
        Me.toolGenerarCDR.Text = "Generar CDR"
        '
        'toolAsignar
        '
        Me.toolAsignar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAsignar.Image = Global.SMUSURA0.My.Resources.Resources.ProgTrimestral16
        Me.toolAsignar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAsignar.Name = "toolAsignar"
        Me.toolAsignar.Size = New System.Drawing.Size(23, 22)
        Me.toolAsignar.Text = "Revisar CDR (Contabilidad)"
        '
        'toolAutorizar
        '
        Me.toolAutorizar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAutorizar.Image = Global.SMUSURA0.My.Resources.Resources.AprobarPartida16
        Me.toolAutorizar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAutorizar.Name = "toolAutorizar"
        Me.toolAutorizar.Size = New System.Drawing.Size(23, 22)
        Me.toolAutorizar.Text = "Autorizar CDR (Finanzas)"
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'toolSalir
        '
        Me.toolSalir.BackColor = System.Drawing.Color.Transparent
        Me.toolSalir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta16
        Me.toolSalir.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolSalir.Name = "toolSalir"
        Me.toolSalir.Size = New System.Drawing.Size(23, 22)
        Me.toolSalir.Text = "Cerrar"
        Me.toolSalir.ToolTipText = "Salir"
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(434, 1)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(123, 20)
        Me.CdeFechaFinal.TabIndex = 63
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.Visible = False
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(243, 1)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(123, 20)
        Me.cdeFechaInicial.TabIndex = 62
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.Visible = False
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(393, 4)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "Hasta:"
        Me.Label2.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(199, 4)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(41, 13)
        Me.Label1.TabIndex = 64
        Me.Label1.Text = "Desde:"
        Me.Label1.Visible = False
        '
        'grdListadoGeneracionesCDR
        '
        Me.grdListadoGeneracionesCDR.AllowColMove = False
        Me.grdListadoGeneracionesCDR.AllowColSelect = False
        Me.grdListadoGeneracionesCDR.AllowSort = False
        Me.grdListadoGeneracionesCDR.AllowUpdate = False
        Me.grdListadoGeneracionesCDR.AllowUpdateOnBlur = False
        Me.grdListadoGeneracionesCDR.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.grdListadoGeneracionesCDR.Caption = "Listado de Períodos Contables"
        Me.grdListadoGeneracionesCDR.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdListadoGeneracionesCDR.EditDropDown = False
        Me.grdListadoGeneracionesCDR.FilterBar = True
        Me.grdListadoGeneracionesCDR.GroupByCaption = "Arrastre aquí una columna para agrupar"
        Me.grdListadoGeneracionesCDR.Images.Add(CType(resources.GetObject("grdListadoGeneracionesCDR.Images"), System.Drawing.Image))
        Me.grdListadoGeneracionesCDR.Location = New System.Drawing.Point(0, 28)
        Me.grdListadoGeneracionesCDR.MultiSelect = C1.Win.C1TrueDBGrid.MultiSelectEnum.None
        Me.grdListadoGeneracionesCDR.Name = "grdListadoGeneracionesCDR"
        Me.grdListadoGeneracionesCDR.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdListadoGeneracionesCDR.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdListadoGeneracionesCDR.PreviewInfo.ZoomFactor = 75.0R
        Me.grdListadoGeneracionesCDR.PrintInfo.PageSettings = CType(resources.GetObject("grdListadoGeneracionesCDR.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdListadoGeneracionesCDR.Size = New System.Drawing.Size(894, 380)
        Me.grdListadoGeneracionesCDR.TabIndex = 14
        Me.grdListadoGeneracionesCDR.Text = "grdSolicitud"
        Me.grdListadoGeneracionesCDR.PropBag = resources.GetString("grdListadoGeneracionesCDR.PropBag")
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.lblUltimaEjecucionJob})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 411)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(894, 22)
        Me.StatusStrip1.TabIndex = 66
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'lblUltimaEjecucionJob
        '
        Me.lblUltimaEjecucionJob.Name = "lblUltimaEjecucionJob"
        Me.lblUltimaEjecucionJob.Size = New System.Drawing.Size(150, 17)
        Me.lblUltimaEjecucionJob.Text = "Lista de períodos contables"
        '
        'toolImprimirCDR
        '
        Me.toolImprimirCDR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolImprimirCDR.Image = Global.SMUSURA0.My.Resources.Resources.impresora16
        Me.toolImprimirCDR.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolImprimirCDR.Name = "toolImprimirCDR"
        Me.toolImprimirCDR.Size = New System.Drawing.Size(23, 22)
        Me.toolImprimirCDR.Text = "Imprimir Listado de Socias en CDR"
        '
        'frmScnProcesoCDR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(894, 433)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CdeFechaFinal)
        Me.Controls.Add(Me.cdeFechaInicial)
        Me.Controls.Add(Me.grdListadoGeneracionesCDR)
        Me.Controls.Add(Me.tbProcesoCDR)
        Me.Name = "frmScnProcesoCDR"
        Me.Text = "Listado de Períodos Contables"
        Me.tbProcesoCDR.ResumeLayout(False)
        Me.tbProcesoCDR.PerformLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdListadoGeneracionesCDR, System.ComponentModel.ISupportInitialize).EndInit()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents tbProcesoCDR As ToolStrip
    Friend WithEvents ToolStripButton7 As ToolStripSeparator
    Friend WithEvents toolAsignar As ToolStripButton
    Friend WithEvents toolGenerarCDR As ToolStripButton
    Friend WithEvents toolRefrescar As ToolStripButton
    Friend WithEvents toolSalir As ToolStripButton
    Friend WithEvents grdListadoGeneracionesCDR As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents toolAutorizar As ToolStripButton
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents lblUltimaEjecucionJob As ToolStripStatusLabel
    Friend WithEvents toolImprimirCDR As ToolStripButton
End Class
