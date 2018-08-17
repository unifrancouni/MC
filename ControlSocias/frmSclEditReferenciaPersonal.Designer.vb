<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSclEditReferenciaPersonal
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
        Me.components = New System.ComponentModel.Container
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSclEditReferenciaPersonal))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style
        Me.lblDireccionDomicilio = New System.Windows.Forms.Label
        Me.grpGarantiaFiduciaria = New System.Windows.Forms.GroupBox
        Me.txtDireccionDomicilio = New System.Windows.Forms.TextBox
        Me.lblCelular = New System.Windows.Forms.Label
        Me.txtCelular = New System.Windows.Forms.TextBox
        Me.lblTelefono = New System.Windows.Forms.Label
        Me.txtTelefono = New System.Windows.Forms.TextBox
        Me.lblCedula = New System.Windows.Forms.Label
        Me.txtCedula = New System.Windows.Forms.TextBox
        Me.txtDireccionTrabajo = New System.Windows.Forms.TextBox
        Me.lblDireccionTrabajo = New System.Windows.Forms.Label
        Me.cboFiador = New C1.Win.C1List.C1Combo
        Me.lblFiador = New System.Windows.Forms.Label
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        Me.errGarantiaFiduciaria = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.CmdAceptar = New System.Windows.Forms.Button
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.grpGarantiaFiduciaria.SuspendLayout()
        CType(Me.cboFiador, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.errGarantiaFiduciaria, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblDireccionDomicilio
        '
        Me.lblDireccionDomicilio.AutoSize = True
        Me.lblDireccionDomicilio.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDireccionDomicilio.Location = New System.Drawing.Point(12, 105)
        Me.lblDireccionDomicilio.Name = "lblDireccionDomicilio"
        Me.lblDireccionDomicilio.Size = New System.Drawing.Size(114, 13)
        Me.lblDireccionDomicilio.TabIndex = 130
        Me.lblDireccionDomicilio.Text = "Dirección del Domicilio"
        '
        'grpGarantiaFiduciaria
        '
        Me.grpGarantiaFiduciaria.Controls.Add(Me.lblDireccionDomicilio)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.txtDireccionDomicilio)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.lblCelular)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.txtCelular)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.lblTelefono)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.txtTelefono)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.lblCedula)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.txtCedula)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.txtDireccionTrabajo)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.lblDireccionTrabajo)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.cboFiador)
        Me.grpGarantiaFiduciaria.Controls.Add(Me.lblFiador)
        Me.grpGarantiaFiduciaria.Location = New System.Drawing.Point(12, 1)
        Me.grpGarantiaFiduciaria.Name = "grpGarantiaFiduciaria"
        Me.grpGarantiaFiduciaria.Size = New System.Drawing.Size(620, 182)
        Me.grpGarantiaFiduciaria.TabIndex = 3
        Me.grpGarantiaFiduciaria.TabStop = False
        Me.grpGarantiaFiduciaria.Text = "Datos Garantía Fiduciaria"
        '
        'txtDireccionDomicilio
        '
        Me.txtDireccionDomicilio.BackColor = System.Drawing.SystemColors.Info
        Me.txtDireccionDomicilio.Enabled = False
        Me.txtDireccionDomicilio.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDireccionDomicilio.Location = New System.Drawing.Point(167, 98)
        Me.txtDireccionDomicilio.Name = "txtDireccionDomicilio"
        Me.txtDireccionDomicilio.ReadOnly = True
        Me.txtDireccionDomicilio.ShortcutsEnabled = False
        Me.txtDireccionDomicilio.Size = New System.Drawing.Size(447, 20)
        Me.txtDireccionDomicilio.TabIndex = 129
        Me.txtDireccionDomicilio.Tag = "LAYOUT:FLAT"
        '
        'lblCelular
        '
        Me.lblCelular.AutoSize = True
        Me.lblCelular.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCelular.Location = New System.Drawing.Point(376, 79)
        Me.lblCelular.Name = "lblCelular"
        Me.lblCelular.Size = New System.Drawing.Size(42, 13)
        Me.lblCelular.TabIndex = 128
        Me.lblCelular.Text = "Celular:"
        '
        'txtCelular
        '
        Me.txtCelular.BackColor = System.Drawing.SystemColors.Info
        Me.txtCelular.Enabled = False
        Me.txtCelular.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCelular.Location = New System.Drawing.Point(457, 72)
        Me.txtCelular.Name = "txtCelular"
        Me.txtCelular.ReadOnly = True
        Me.txtCelular.ShortcutsEnabled = False
        Me.txtCelular.Size = New System.Drawing.Size(157, 20)
        Me.txtCelular.TabIndex = 127
        Me.txtCelular.Tag = "LAYOUT:FLAT"
        '
        'lblTelefono
        '
        Me.lblTelefono.AutoSize = True
        Me.lblTelefono.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblTelefono.Location = New System.Drawing.Point(12, 79)
        Me.lblTelefono.Name = "lblTelefono"
        Me.lblTelefono.Size = New System.Drawing.Size(52, 13)
        Me.lblTelefono.TabIndex = 126
        Me.lblTelefono.Text = "Teléfono:"
        '
        'txtTelefono
        '
        Me.txtTelefono.BackColor = System.Drawing.SystemColors.Info
        Me.txtTelefono.Enabled = False
        Me.txtTelefono.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelefono.Location = New System.Drawing.Point(167, 72)
        Me.txtTelefono.Name = "txtTelefono"
        Me.txtTelefono.ReadOnly = True
        Me.txtTelefono.ShortcutsEnabled = False
        Me.txtTelefono.Size = New System.Drawing.Size(157, 20)
        Me.txtTelefono.TabIndex = 125
        Me.txtTelefono.Tag = "LAYOUT:FLAT"
        '
        'lblCedula
        '
        Me.lblCedula.AutoSize = True
        Me.lblCedula.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblCedula.Location = New System.Drawing.Point(12, 53)
        Me.lblCedula.Name = "lblCedula"
        Me.lblCedula.Size = New System.Drawing.Size(98, 13)
        Me.lblCedula.TabIndex = 124
        Me.lblCedula.Text = "Número de Cédula:"
        '
        'txtCedula
        '
        Me.txtCedula.BackColor = System.Drawing.SystemColors.Info
        Me.txtCedula.Enabled = False
        Me.txtCedula.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCedula.Location = New System.Drawing.Point(167, 46)
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.ReadOnly = True
        Me.txtCedula.ShortcutsEnabled = False
        Me.txtCedula.Size = New System.Drawing.Size(157, 20)
        Me.txtCedula.TabIndex = 123
        Me.txtCedula.Tag = "LAYOUT:FLAT"
        '
        'txtDireccionTrabajo
        '
        Me.txtDireccionTrabajo.Location = New System.Drawing.Point(167, 143)
        Me.txtDireccionTrabajo.MaxLength = 100
        Me.txtDireccionTrabajo.Name = "txtDireccionTrabajo"
        Me.txtDireccionTrabajo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.txtDireccionTrabajo.Size = New System.Drawing.Size(447, 20)
        Me.txtDireccionTrabajo.TabIndex = 2
        '
        'lblDireccionTrabajo
        '
        Me.lblDireccionTrabajo.AutoSize = True
        Me.lblDireccionTrabajo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDireccionTrabajo.Location = New System.Drawing.Point(12, 143)
        Me.lblDireccionTrabajo.Name = "lblDireccionTrabajo"
        Me.lblDireccionTrabajo.Size = New System.Drawing.Size(156, 13)
        Me.lblDireccionTrabajo.TabIndex = 55
        Me.lblDireccionTrabajo.Text = "Dirección Trabajo y/o Negocio:"
        '
        'cboFiador
        '
        Me.cboFiador.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboFiador.AutoCompletion = True
        Me.cboFiador.Caption = ""
        Me.cboFiador.CaptionHeight = 17
        Me.cboFiador.CaptionStyle = Style1
        Me.cboFiador.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboFiador.ColumnCaptionHeight = 17
        Me.cboFiador.ColumnFooterHeight = 17
        Me.cboFiador.ContentHeight = 15
        Me.cboFiador.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboFiador.DisplayMember = "sFiador"
        Me.cboFiador.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboFiador.DropDownWidth = 310
        Me.cboFiador.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboFiador.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboFiador.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboFiador.EditorHeight = 15
        Me.cboFiador.EvenRowStyle = Style2
        Me.cboFiador.ExtendRightColumn = True
        Me.cboFiador.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboFiador.FooterStyle = Style3
        Me.cboFiador.GapHeight = 2
        Me.cboFiador.HeadingStyle = Style4
        Me.cboFiador.HighLightRowStyle = Style5
        Me.cboFiador.Images.Add(CType(resources.GetObject("cboFiador.Images"), System.Drawing.Image))
        Me.cboFiador.ItemHeight = 15
        Me.cboFiador.LimitToList = True
        Me.cboFiador.Location = New System.Drawing.Point(167, 19)
        Me.cboFiador.MatchEntryTimeout = CType(2000, Long)
        Me.cboFiador.MaxDropDownItems = CType(5, Short)
        Me.cboFiador.MaxLength = 32767
        Me.cboFiador.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboFiador.Name = "cboFiador"
        Me.cboFiador.OddRowStyle = Style6
        Me.cboFiador.PartialRightColumn = False
        Me.cboFiador.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboFiador.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboFiador.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboFiador.SelectedStyle = Style7
        Me.cboFiador.Size = New System.Drawing.Size(276, 21)
        Me.cboFiador.Style = Style8
        Me.cboFiador.SuperBack = True
        Me.cboFiador.TabIndex = 0
        Me.cboFiador.PropBag = resources.GetString("cboFiador.PropBag")
        '
        'lblFiador
        '
        Me.lblFiador.AutoSize = True
        Me.lblFiador.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFiador.Location = New System.Drawing.Point(11, 27)
        Me.lblFiador.Name = "lblFiador"
        Me.lblFiador.Size = New System.Drawing.Size(69, 13)
        Me.lblFiador.TabIndex = 38
        Me.lblFiador.Text = "Referente(a):"
        '
        'errGarantiaFiduciaria
        '
        Me.errGarantiaFiduciaria.ContainerControl = Me
        '
        'CmdAceptar
        '
        Me.CmdAceptar.Image = CType(resources.GetObject("CmdAceptar.Image"), System.Drawing.Image)
        Me.CmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.CmdAceptar.Location = New System.Drawing.Point(486, 189)
        Me.CmdAceptar.Name = "CmdAceptar"
        Me.CmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.CmdAceptar.TabIndex = 4
        Me.CmdAceptar.Text = "Aceptar"
        Me.CmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(563, 189)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 5
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmSclEditReferenciaPersonal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 229)
        Me.Controls.Add(Me.grpGarantiaFiduciaria)
        Me.Controls.Add(Me.CmdAceptar)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSclEditReferenciaPersonal"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Referencia Personal"
        Me.grpGarantiaFiduciaria.ResumeLayout(False)
        Me.grpGarantiaFiduciaria.PerformLayout()
        CType(Me.cboFiador, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.errGarantiaFiduciaria, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblDireccionDomicilio As System.Windows.Forms.Label
    Friend WithEvents grpGarantiaFiduciaria As System.Windows.Forms.GroupBox
    Friend WithEvents txtDireccionDomicilio As System.Windows.Forms.TextBox
    Friend WithEvents lblCelular As System.Windows.Forms.Label
    Friend WithEvents txtCelular As System.Windows.Forms.TextBox
    Friend WithEvents lblTelefono As System.Windows.Forms.Label
    Friend WithEvents txtTelefono As System.Windows.Forms.TextBox
    Friend WithEvents lblCedula As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents txtDireccionTrabajo As System.Windows.Forms.TextBox
    Friend WithEvents lblDireccionTrabajo As System.Windows.Forms.Label
    Friend WithEvents cboFiador As C1.Win.C1List.C1Combo
    Friend WithEvents lblFiador As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents CmdAceptar As System.Windows.Forms.Button
    Friend WithEvents errGarantiaFiduciaria As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
End Class
