<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditMinutaBancoEnLinea
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditMinutaBancoEnLinea))
        Me.ToolStripButton7 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.toolAgregar = New System.Windows.Forms.ToolStripButton
        Me.toolModificar = New System.Windows.Forms.ToolStripButton
        Me.toolEliminar = New System.Windows.Forms.ToolStripButton
        Me.toolRefrescar = New System.Windows.Forms.ToolStripButton
        Me.toolAyuda = New System.Windows.Forms.ToolStripButton
        Me.grpLugarPagos = New System.Windows.Forms.GroupBox
        Me.lblArqueoTraslado = New System.Windows.Forms.Label
        Me.chkDepositos = New System.Windows.Forms.CheckBox
        Me.txtPestana = New System.Windows.Forms.TextBox
        Me.lblPestana = New System.Windows.Forms.Label
        Me.CmdBuscar = New System.Windows.Forms.Button
        Me.txtArchivoAbierto = New System.Windows.Forms.TextBox
        Me.lblFechaH = New System.Windows.Forms.Label
        Me.lblFechaD = New System.Windows.Forms.Label
        Me.cdeFechaH = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaD = New C1.Win.C1Input.C1DateEdit
        Me.txtCuenta = New System.Windows.Forms.TextBox
        Me.lblCuenta = New System.Windows.Forms.Label
        Me.lblArchivo = New System.Windows.Forms.Label
        Me.CmdImportar = New System.Windows.Forms.Button
        Me.cmdSalir = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.ArchivoLocacion = New System.Windows.Forms.OpenFileDialog
        Me.grpLugarPagos.SuspendLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripButton7
        '
        Me.ToolStripButton7.Name = "ToolStripButton7"
        Me.ToolStripButton7.Size = New System.Drawing.Size(6, 25)
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'toolAgregar
        '
        Me.toolAgregar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAgregar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolAgregar.Name = "toolAgregar"
        Me.toolAgregar.Size = New System.Drawing.Size(23, 22)
        Me.toolAgregar.Text = "Agregar"
        Me.toolAgregar.ToolTipText = "Agregar"
        '
        'toolModificar
        '
        Me.toolModificar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolModificar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolModificar.Name = "toolModificar"
        Me.toolModificar.Size = New System.Drawing.Size(23, 22)
        Me.toolModificar.Text = "Modificar"
        Me.toolModificar.ToolTipText = "Modificar"
        '
        'toolEliminar
        '
        Me.toolEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolEliminar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolEliminar.Name = "toolEliminar"
        Me.toolEliminar.Size = New System.Drawing.Size(23, 22)
        Me.toolEliminar.Text = "Eliminar"
        '
        'toolRefrescar
        '
        Me.toolRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolRefrescar.ImageTransparentColor = System.Drawing.Color.Transparent
        Me.toolRefrescar.Name = "toolRefrescar"
        Me.toolRefrescar.Size = New System.Drawing.Size(23, 22)
        Me.toolRefrescar.Text = "Refrescar"
        '
        'toolAyuda
        '
        Me.toolAyuda.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.toolAyuda.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.toolAyuda.Name = "toolAyuda"
        Me.toolAyuda.Size = New System.Drawing.Size(23, 22)
        Me.toolAyuda.Text = "Ayuda"
        Me.toolAyuda.ToolTipText = "Ayuda"
        '
        'grpLugarPagos
        '
        Me.grpLugarPagos.Controls.Add(Me.lblArqueoTraslado)
        Me.grpLugarPagos.Controls.Add(Me.chkDepositos)
        Me.grpLugarPagos.Controls.Add(Me.txtPestana)
        Me.grpLugarPagos.Controls.Add(Me.lblPestana)
        Me.grpLugarPagos.Controls.Add(Me.CmdBuscar)
        Me.grpLugarPagos.Controls.Add(Me.txtArchivoAbierto)
        Me.grpLugarPagos.Controls.Add(Me.lblFechaH)
        Me.grpLugarPagos.Controls.Add(Me.lblFechaD)
        Me.grpLugarPagos.Controls.Add(Me.cdeFechaH)
        Me.grpLugarPagos.Controls.Add(Me.cdeFechaD)
        Me.grpLugarPagos.Controls.Add(Me.txtCuenta)
        Me.grpLugarPagos.Controls.Add(Me.lblCuenta)
        Me.grpLugarPagos.Controls.Add(Me.lblArchivo)
        Me.grpLugarPagos.Location = New System.Drawing.Point(12, 12)
        Me.grpLugarPagos.Name = "grpLugarPagos"
        Me.grpLugarPagos.Size = New System.Drawing.Size(474, 187)
        Me.grpLugarPagos.TabIndex = 18
        Me.grpLugarPagos.TabStop = False
        Me.grpLugarPagos.Text = "Seleccione Delegación "
        '
        'lblArqueoTraslado
        '
        Me.lblArqueoTraslado.AutoSize = True
        Me.lblArqueoTraslado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblArqueoTraslado.Location = New System.Drawing.Point(237, 64)
        Me.lblArqueoTraslado.Name = "lblArqueoTraslado"
        Me.lblArqueoTraslado.Size = New System.Drawing.Size(98, 13)
        Me.lblArqueoTraslado.TabIndex = 48
        Me.lblArqueoTraslado.Text = "Importar Depósitos:"
        '
        'chkDepositos
        '
        Me.chkDepositos.AutoSize = True
        Me.chkDepositos.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.chkDepositos.Checked = True
        Me.chkDepositos.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkDepositos.FlatAppearance.BorderColor = System.Drawing.Color.Black
        Me.chkDepositos.ImageAlign = System.Drawing.ContentAlignment.TopLeft
        Me.chkDepositos.Location = New System.Drawing.Point(341, 64)
        Me.chkDepositos.Name = "chkDepositos"
        Me.chkDepositos.Size = New System.Drawing.Size(15, 17)
        Me.chkDepositos.TabIndex = 47
        Me.chkDepositos.Tag = ""
        Me.chkDepositos.Text = " "
        Me.chkDepositos.TextAlign = System.Drawing.ContentAlignment.TopRight
        Me.chkDepositos.UseVisualStyleBackColor = True
        '
        'txtPestana
        '
        Me.txtPestana.Location = New System.Drawing.Point(123, 120)
        Me.txtPestana.Name = "txtPestana"
        Me.txtPestana.Size = New System.Drawing.Size(273, 20)
        Me.txtPestana.TabIndex = 2
        Me.txtPestana.Text = "sheet1"
        '
        'lblPestana
        '
        Me.lblPestana.AutoSize = True
        Me.lblPestana.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblPestana.Location = New System.Drawing.Point(21, 120)
        Me.lblPestana.Name = "lblPestana"
        Me.lblPestana.Size = New System.Drawing.Size(101, 13)
        Me.lblPestana.TabIndex = 46
        Me.lblPestana.Text = "Nombre Hoja No. 1:"
        '
        'CmdBuscar
        '
        Me.CmdBuscar.Image = Global.SMUSURA0.My.Resources.Resources.search
        Me.CmdBuscar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdBuscar.Location = New System.Drawing.Point(398, 147)
        Me.CmdBuscar.Name = "CmdBuscar"
        Me.CmdBuscar.Size = New System.Drawing.Size(66, 24)
        Me.CmdBuscar.TabIndex = 5
        Me.CmdBuscar.Text = "Buscar Archivo"
        Me.CmdBuscar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdBuscar.UseVisualStyleBackColor = True
        '
        'txtArchivoAbierto
        '
        Me.txtArchivoAbierto.BackColor = System.Drawing.SystemColors.Info
        Me.txtArchivoAbierto.Enabled = False
        Me.txtArchivoAbierto.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtArchivoAbierto.Location = New System.Drawing.Point(123, 150)
        Me.txtArchivoAbierto.Name = "txtArchivoAbierto"
        Me.txtArchivoAbierto.ReadOnly = True
        Me.txtArchivoAbierto.Size = New System.Drawing.Size(273, 20)
        Me.txtArchivoAbierto.TabIndex = 4
        Me.txtArchivoAbierto.Tag = "LAYOUT:FLAT"
        '
        'lblFechaH
        '
        Me.lblFechaH.AutoSize = True
        Me.lblFechaH.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaH.Location = New System.Drawing.Point(21, 62)
        Me.lblFechaH.Name = "lblFechaH"
        Me.lblFechaH.Size = New System.Drawing.Size(71, 13)
        Me.lblFechaH.TabIndex = 44
        Me.lblFechaH.Text = "Fecha Hasta:"
        '
        'lblFechaD
        '
        Me.lblFechaD.AutoSize = True
        Me.lblFechaD.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaD.Location = New System.Drawing.Point(21, 28)
        Me.lblFechaD.Name = "lblFechaD"
        Me.lblFechaD.Size = New System.Drawing.Size(74, 13)
        Me.lblFechaD.TabIndex = 43
        Me.lblFechaD.Text = "Fecha Desde:"
        '
        'cdeFechaH
        '
        Me.cdeFechaH.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaH.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaH.Location = New System.Drawing.Point(123, 62)
        Me.cdeFechaH.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaH.MaskInfo.EmptyAsNull = True
        Me.cdeFechaH.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaH.Name = "cdeFechaH"
        Me.cdeFechaH.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaH.TabIndex = 1
        Me.cdeFechaH.Tag = Nothing
        Me.cdeFechaH.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaD
        '
        Me.cdeFechaD.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaD.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaD.Location = New System.Drawing.Point(123, 28)
        Me.cdeFechaD.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaD.MaskInfo.EmptyAsNull = True
        Me.cdeFechaD.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaD.Name = "cdeFechaD"
        Me.cdeFechaD.Size = New System.Drawing.Size(102, 20)
        Me.cdeFechaD.TabIndex = 0
        Me.cdeFechaD.Tag = Nothing
        Me.cdeFechaD.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtCuenta
        '
        Me.txtCuenta.BackColor = System.Drawing.SystemColors.Info
        Me.txtCuenta.Enabled = False
        Me.txtCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCuenta.Location = New System.Drawing.Point(123, 94)
        Me.txtCuenta.Name = "txtCuenta"
        Me.txtCuenta.ReadOnly = True
        Me.txtCuenta.Size = New System.Drawing.Size(273, 20)
        Me.txtCuenta.TabIndex = 3
        Me.txtCuenta.Tag = "LAYOUT:FLAT"
        '
        'lblCuenta
        '
        Me.lblCuenta.AutoSize = True
        Me.lblCuenta.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuenta.Location = New System.Drawing.Point(21, 94)
        Me.lblCuenta.Name = "lblCuenta"
        Me.lblCuenta.Size = New System.Drawing.Size(89, 13)
        Me.lblCuenta.TabIndex = 39
        Me.lblCuenta.Text = "Cuenta Bancaria:"
        '
        'lblArchivo
        '
        Me.lblArchivo.AutoSize = True
        Me.lblArchivo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblArchivo.Location = New System.Drawing.Point(21, 153)
        Me.lblArchivo.Name = "lblArchivo"
        Me.lblArchivo.Size = New System.Drawing.Size(75, 13)
        Me.lblArchivo.TabIndex = 37
        Me.lblArchivo.Text = "Archivo Excel:"
        '
        'CmdImportar
        '
        Me.CmdImportar.Image = CType(resources.GetObject("CmdImportar.Image"), System.Drawing.Image)
        Me.CmdImportar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdImportar.Location = New System.Drawing.Point(318, 205)
        Me.CmdImportar.Name = "CmdImportar"
        Me.CmdImportar.Size = New System.Drawing.Size(76, 25)
        Me.CmdImportar.TabIndex = 0
        Me.CmdImportar.Text = "Importar"
        Me.CmdImportar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdImportar.UseVisualStyleBackColor = True
        '
        'cmdSalir
        '
        Me.cmdSalir.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdSalir.Image = Global.SMUSURA0.My.Resources.Resources.Puerta161
        Me.cmdSalir.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdSalir.Location = New System.Drawing.Point(400, 205)
        Me.cmdSalir.Name = "cmdSalir"
        Me.cmdSalir.Size = New System.Drawing.Size(76, 25)
        Me.cmdSalir.TabIndex = 1
        Me.cmdSalir.Text = "Salir"
        Me.cmdSalir.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSalir.UseVisualStyleBackColor = True
        '
        'DataGridView1
        '
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Location = New System.Drawing.Point(12, 236)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(474, 122)
        Me.DataGridView1.TabIndex = 51
        Me.DataGridView1.Visible = False
        '
        'frmSteEditMinutaBancoEnLinea
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 238)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.grpLugarPagos)
        Me.Controls.Add(Me.cmdSalir)
        Me.Controls.Add(Me.CmdImportar)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.HelpProvider.SetHelpKeyword(Me, "Registro de Socias")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSteEditMinutaBancoEnLinea"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Importar Archivo Excel"
        Me.grpLugarPagos.ResumeLayout(False)
        Me.grpLugarPagos.PerformLayout()
        CType(Me.cdeFechaH, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents toolAgregar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolModificar As System.Windows.Forms.ToolStripButton
    Friend WithEvents toolEliminar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripButton7 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolRefrescar As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents toolAyuda As System.Windows.Forms.ToolStripButton
    Friend WithEvents grpLugarPagos As System.Windows.Forms.GroupBox
    Friend WithEvents txtCuenta As System.Windows.Forms.TextBox
    Friend WithEvents lblCuenta As System.Windows.Forms.Label
    Friend WithEvents cmdSalir As System.Windows.Forms.Button
    Friend WithEvents CmdImportar As System.Windows.Forms.Button
    Friend WithEvents lblArchivo As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents lblFechaH As System.Windows.Forms.Label
    Friend WithEvents lblFechaD As System.Windows.Forms.Label
    Friend WithEvents cdeFechaH As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaD As C1.Win.C1Input.C1DateEdit
    Friend WithEvents txtArchivoAbierto As System.Windows.Forms.TextBox
    Friend WithEvents CmdBuscar As System.Windows.Forms.Button
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents ArchivoLocacion As System.Windows.Forms.OpenFileDialog
    Friend WithEvents lblPestana As System.Windows.Forms.Label
    Friend WithEvents txtPestana As System.Windows.Forms.TextBox
    Friend WithEvents lblArqueoTraslado As System.Windows.Forms.Label
    Friend WithEvents chkDepositos As System.Windows.Forms.CheckBox
End Class
