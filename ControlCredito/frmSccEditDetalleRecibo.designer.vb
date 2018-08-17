<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSccEditDetalleRecibo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSccEditDetalleRecibo))
        Me.grpOtroCredito = New System.Windows.Forms.GroupBox
        Me.txtTotalPagado = New System.Windows.Forms.TextBox
        Me.lblEdad = New System.Windows.Forms.Label
        Me.cneSaldoActual = New C1.Win.C1Input.C1NumericEdit
        Me.Label3 = New System.Windows.Forms.Label
        Me.cneInteresesMoratorios = New C1.Win.C1Input.C1NumericEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNumCuota = New System.Windows.Forms.TextBox
        Me.lblNumRecibo = New System.Windows.Forms.Label
        Me.cneInteresesCorrientes = New C1.Win.C1Input.C1NumericEdit
        Me.lblCuota = New System.Windows.Forms.Label
        Me.cneMantenimientoValor = New C1.Win.C1Input.C1NumericEdit
        Me.Label1 = New System.Windows.Forms.Label
        Me.cnePrincipal = New C1.Win.C1Input.C1NumericEdit
        Me.lblMontoSolicitado = New System.Windows.Forms.Label
        Me.errRecibo = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.grpOtroCredito.SuspendLayout()
        CType(Me.cneSaldoActual, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneInteresesMoratorios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneInteresesCorrientes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cneMantenimientoValor, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cnePrincipal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpOtroCredito
        '
        Me.grpOtroCredito.Controls.Add(Me.txtTotalPagado)
        Me.grpOtroCredito.Controls.Add(Me.lblEdad)
        Me.grpOtroCredito.Controls.Add(Me.cneSaldoActual)
        Me.grpOtroCredito.Controls.Add(Me.Label3)
        Me.grpOtroCredito.Controls.Add(Me.cneInteresesMoratorios)
        Me.grpOtroCredito.Controls.Add(Me.Label2)
        Me.grpOtroCredito.Controls.Add(Me.txtNumCuota)
        Me.grpOtroCredito.Controls.Add(Me.lblNumRecibo)
        Me.grpOtroCredito.Controls.Add(Me.cneInteresesCorrientes)
        Me.grpOtroCredito.Controls.Add(Me.lblCuota)
        Me.grpOtroCredito.Controls.Add(Me.cneMantenimientoValor)
        Me.grpOtroCredito.Controls.Add(Me.Label1)
        Me.grpOtroCredito.Controls.Add(Me.cnePrincipal)
        Me.grpOtroCredito.Controls.Add(Me.lblMontoSolicitado)
        Me.grpOtroCredito.Location = New System.Drawing.Point(12, 12)
        Me.grpOtroCredito.Name = "grpOtroCredito"
        Me.grpOtroCredito.Size = New System.Drawing.Size(449, 247)
        Me.grpOtroCredito.TabIndex = 0
        Me.grpOtroCredito.TabStop = False
        Me.grpOtroCredito.Text = "Datos Detalle Recibo Oficial de Caja"
        '
        'txtTotalPagado
        '
        Me.txtTotalPagado.BackColor = System.Drawing.SystemColors.Info
        Me.txtTotalPagado.Enabled = False
        Me.txtTotalPagado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalPagado.Location = New System.Drawing.Point(156, 177)
        Me.txtTotalPagado.Name = "txtTotalPagado"
        Me.txtTotalPagado.ReadOnly = True
        Me.txtTotalPagado.ShortcutsEnabled = False
        Me.txtTotalPagado.Size = New System.Drawing.Size(156, 20)
        Me.txtTotalPagado.TabIndex = 6
        Me.txtTotalPagado.Tag = "LAYOUT:FLAT"
        Me.txtTotalPagado.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblEdad
        '
        Me.lblEdad.AutoSize = True
        Me.lblEdad.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblEdad.Location = New System.Drawing.Point(11, 184)
        Me.lblEdad.Name = "lblEdad"
        Me.lblEdad.Size = New System.Drawing.Size(74, 13)
        Me.lblEdad.TabIndex = 123
        Me.lblEdad.Text = "Total Pagado:"
        '
        'cneSaldoActual
        '
        Me.cneSaldoActual.AcceptsTab = True
        Me.cneSaldoActual.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneSaldoActual.DataType = GetType(Double)
        Me.cneSaldoActual.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneSaldoActual.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneSaldoActual.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneSaldoActual.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneSaldoActual.EditFormat.EmptyAsNull = False
        Me.cneSaldoActual.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneSaldoActual.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneSaldoActual.EmptyAsNull = True
        Me.cneSaldoActual.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneSaldoActual.Location = New System.Drawing.Point(156, 209)
        Me.cneSaldoActual.MaskInfo.AutoTabWhenFilled = True
        Me.cneSaldoActual.MaxLength = 999999999
        Me.cneSaldoActual.Name = "cneSaldoActual"
        Me.cneSaldoActual.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneSaldoActual.Size = New System.Drawing.Size(156, 20)
        Me.cneSaldoActual.TabIndex = 7
        Me.cneSaldoActual.Tag = Nothing
        Me.cneSaldoActual.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneSaldoActual.UseColumnStyles = False
        Me.cneSaldoActual.Value = 0
        Me.cneSaldoActual.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(11, 216)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(70, 13)
        Me.Label3.TabIndex = 122
        Me.Label3.Text = "Saldo Actual:"
        '
        'cneInteresesMoratorios
        '
        Me.cneInteresesMoratorios.AcceptsTab = True
        Me.cneInteresesMoratorios.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneInteresesMoratorios.DataType = GetType(Double)
        Me.cneInteresesMoratorios.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneInteresesMoratorios.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneInteresesMoratorios.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneInteresesMoratorios.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneInteresesMoratorios.EditFormat.EmptyAsNull = False
        Me.cneInteresesMoratorios.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneInteresesMoratorios.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneInteresesMoratorios.EmptyAsNull = True
        Me.cneInteresesMoratorios.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneInteresesMoratorios.Location = New System.Drawing.Point(156, 145)
        Me.cneInteresesMoratorios.MaskInfo.AutoTabWhenFilled = True
        Me.cneInteresesMoratorios.MaxLength = 999999999
        Me.cneInteresesMoratorios.Name = "cneInteresesMoratorios"
        Me.cneInteresesMoratorios.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneInteresesMoratorios.Size = New System.Drawing.Size(156, 20)
        Me.cneInteresesMoratorios.TabIndex = 5
        Me.cneInteresesMoratorios.Tag = Nothing
        Me.cneInteresesMoratorios.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneInteresesMoratorios.UseColumnStyles = False
        Me.cneInteresesMoratorios.Value = 0
        Me.cneInteresesMoratorios.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(11, 152)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(105, 13)
        Me.Label2.TabIndex = 120
        Me.Label2.Text = "Intereses Moratorios:"
        '
        'txtNumCuota
        '
        Me.txtNumCuota.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumCuota.Location = New System.Drawing.Point(156, 19)
        Me.txtNumCuota.Name = "txtNumCuota"
        Me.txtNumCuota.Size = New System.Drawing.Size(126, 20)
        Me.txtNumCuota.TabIndex = 1
        '
        'lblNumRecibo
        '
        Me.lblNumRecibo.AutoSize = True
        Me.lblNumRecibo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumRecibo.Location = New System.Drawing.Point(11, 26)
        Me.lblNumRecibo.Name = "lblNumRecibo"
        Me.lblNumRecibo.Size = New System.Drawing.Size(93, 13)
        Me.lblNumRecibo.TabIndex = 118
        Me.lblNumRecibo.Text = "Número de Cuota:"
        '
        'cneInteresesCorrientes
        '
        Me.cneInteresesCorrientes.AcceptsTab = True
        Me.cneInteresesCorrientes.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneInteresesCorrientes.DataType = GetType(Double)
        Me.cneInteresesCorrientes.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cneInteresesCorrientes.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneInteresesCorrientes.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneInteresesCorrientes.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneInteresesCorrientes.EditFormat.EmptyAsNull = False
        Me.cneInteresesCorrientes.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneInteresesCorrientes.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneInteresesCorrientes.EmptyAsNull = True
        Me.cneInteresesCorrientes.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneInteresesCorrientes.Location = New System.Drawing.Point(156, 113)
        Me.cneInteresesCorrientes.MaskInfo.AutoTabWhenFilled = True
        Me.cneInteresesCorrientes.MaxLength = 999999999
        Me.cneInteresesCorrientes.Name = "cneInteresesCorrientes"
        Me.cneInteresesCorrientes.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneInteresesCorrientes.Size = New System.Drawing.Size(156, 20)
        Me.cneInteresesCorrientes.TabIndex = 4
        Me.cneInteresesCorrientes.Tag = Nothing
        Me.cneInteresesCorrientes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneInteresesCorrientes.UseColumnStyles = False
        Me.cneInteresesCorrientes.Value = 0
        Me.cneInteresesCorrientes.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblCuota
        '
        Me.lblCuota.AutoSize = True
        Me.lblCuota.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCuota.Location = New System.Drawing.Point(11, 120)
        Me.lblCuota.Name = "lblCuota"
        Me.lblCuota.Size = New System.Drawing.Size(103, 13)
        Me.lblCuota.TabIndex = 116
        Me.lblCuota.Text = "Intereses Corrientes:"
        '
        'cneMantenimientoValor
        '
        Me.cneMantenimientoValor.AcceptsTab = True
        Me.cneMantenimientoValor.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMantenimientoValor.DataType = GetType(Double)
        Me.cneMantenimientoValor.DisplayFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMantenimientoValor.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMantenimientoValor.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMantenimientoValor.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cneMantenimientoValor.EditFormat.EmptyAsNull = False
        Me.cneMantenimientoValor.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMantenimientoValor.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cneMantenimientoValor.EmptyAsNull = True
        Me.cneMantenimientoValor.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cneMantenimientoValor.Location = New System.Drawing.Point(156, 81)
        Me.cneMantenimientoValor.MaskInfo.AutoTabWhenFilled = True
        Me.cneMantenimientoValor.MaxLength = 999999999
        Me.cneMantenimientoValor.Name = "cneMantenimientoValor"
        Me.cneMantenimientoValor.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cneMantenimientoValor.Size = New System.Drawing.Size(156, 20)
        Me.cneMantenimientoValor.TabIndex = 3
        Me.cneMantenimientoValor.Tag = Nothing
        Me.cneMantenimientoValor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cneMantenimientoValor.UseColumnStyles = False
        Me.cneMantenimientoValor.Value = 0
        Me.cneMantenimientoValor.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(11, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(106, 13)
        Me.Label1.TabIndex = 114
        Me.Label1.Text = "Mantenimiento Valor:"
        '
        'cnePrincipal
        '
        Me.cnePrincipal.AcceptsTab = True
        Me.cnePrincipal.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cnePrincipal.DataType = GetType(Double)
        Me.cnePrincipal.DisplayFormat.CustomFormat = "C$ ###,###,###,###,##0.00"
        Me.cnePrincipal.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cnePrincipal.DisplayFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cnePrincipal.EditFormat.CustomFormat = "C$ ###,###,###,##0.00"
        Me.cnePrincipal.EditFormat.EmptyAsNull = False
        Me.cnePrincipal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cnePrincipal.EditFormat.Inherit = CType(((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cnePrincipal.EmptyAsNull = True
        Me.cnePrincipal.FormatType = C1.Win.C1Input.FormatTypeEnum.CustomFormat
        Me.cnePrincipal.Location = New System.Drawing.Point(156, 51)
        Me.cnePrincipal.MaskInfo.AutoTabWhenFilled = True
        Me.cnePrincipal.MaxLength = 999999999
        Me.cnePrincipal.Name = "cnePrincipal"
        Me.cnePrincipal.NumericInputKeys = C1.Win.C1Input.NumericInputKeyFlags.None
        Me.cnePrincipal.Size = New System.Drawing.Size(156, 20)
        Me.cnePrincipal.TabIndex = 2
        Me.cnePrincipal.Tag = Nothing
        Me.cnePrincipal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.cnePrincipal.UseColumnStyles = False
        Me.cnePrincipal.Value = 0
        Me.cnePrincipal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.None
        '
        'lblMontoSolicitado
        '
        Me.lblMontoSolicitado.AutoSize = True
        Me.lblMontoSolicitado.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblMontoSolicitado.Location = New System.Drawing.Point(11, 58)
        Me.lblMontoSolicitado.Name = "lblMontoSolicitado"
        Me.lblMontoSolicitado.Size = New System.Drawing.Size(50, 13)
        Me.lblMontoSolicitado.TabIndex = 42
        Me.lblMontoSolicitado.Text = "Principal:"
        '
        'errRecibo
        '
        Me.errRecibo.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(311, 265)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 1
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(388, 265)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 2
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSccEditDetalleRecibo
        '
        Me.AcceptButton = Me.CmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(475, 302)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.grpOtroCredito)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Recibo Oficial de Caja Manual")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmSccEditDetalleRecibo"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Detalle Recibo Oficial de Caja"
        Me.grpOtroCredito.ResumeLayout(False)
        Me.grpOtroCredito.PerformLayout()
        CType(Me.cneSaldoActual, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneInteresesMoratorios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneInteresesCorrientes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cneMantenimientoValor, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cnePrincipal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errRecibo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents grpOtroCredito As System.Windows.Forms.GroupBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errRecibo As System.Windows.Forms.ErrorProvider
    Friend WithEvents cnePrincipal As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblMontoSolicitado As System.Windows.Forms.Label
    Friend WithEvents cneMantenimientoValor As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cneInteresesCorrientes As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents lblCuota As System.Windows.Forms.Label
    Friend WithEvents txtNumCuota As System.Windows.Forms.TextBox
    Friend WithEvents lblNumRecibo As System.Windows.Forms.Label
    Friend WithEvents cneSaldoActual As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cneInteresesMoratorios As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtTotalPagado As System.Windows.Forms.TextBox
    Friend WithEvents lblEdad As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
