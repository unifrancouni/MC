<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScnParametrosMinutas
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScnParametrosMinutas))
        Me.errParametro = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.cmdAceptar = New System.Windows.Forms.Button
        Me.grpdatos = New System.Windows.Forms.GroupBox
        Me.grpTipoCuadre = New System.Windows.Forms.GroupBox
        Me.RadNoCuadradas = New System.Windows.Forms.RadioButton
        Me.RadCuadradas = New System.Windows.Forms.RadioButton
        Me.RadTodas = New System.Windows.Forms.RadioButton
        Me.CdeFechaFinal = New C1.Win.C1Input.C1DateEdit
        Me.cdeFechaInicial = New C1.Win.C1Input.C1DateEdit
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.cmdCancelar = New System.Windows.Forms.Button
        Me.HelpProvider = New System.Windows.Forms.HelpProvider
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpdatos.SuspendLayout()
        Me.grpTipoCuadre.SuspendLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'errParametro
        '
        Me.errParametro.ContainerControl = Me
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(308, 153)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(69, 27)
        Me.cmdAceptar.TabIndex = 14
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'grpdatos
        '
        Me.grpdatos.Controls.Add(Me.grpTipoCuadre)
        Me.grpdatos.Controls.Add(Me.CdeFechaFinal)
        Me.grpdatos.Controls.Add(Me.cdeFechaInicial)
        Me.grpdatos.Controls.Add(Me.Label3)
        Me.grpdatos.Controls.Add(Me.Label4)
        Me.grpdatos.Location = New System.Drawing.Point(12, 12)
        Me.grpdatos.Name = "grpdatos"
        Me.grpdatos.Size = New System.Drawing.Size(442, 135)
        Me.grpdatos.TabIndex = 13
        Me.grpdatos.TabStop = False
        Me.grpdatos.Text = "Filtro de Datos Por"
        '
        'grpTipoCuadre
        '
        Me.grpTipoCuadre.Controls.Add(Me.RadNoCuadradas)
        Me.grpTipoCuadre.Controls.Add(Me.RadCuadradas)
        Me.grpTipoCuadre.Controls.Add(Me.RadTodas)
        Me.grpTipoCuadre.Location = New System.Drawing.Point(6, 67)
        Me.grpTipoCuadre.Name = "grpTipoCuadre"
        Me.grpTipoCuadre.Size = New System.Drawing.Size(430, 49)
        Me.grpTipoCuadre.TabIndex = 42
        Me.grpTipoCuadre.TabStop = False
        '
        'RadNoCuadradas
        '
        Me.RadNoCuadradas.AutoSize = True
        Me.RadNoCuadradas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadNoCuadradas.Location = New System.Drawing.Point(209, 19)
        Me.RadNoCuadradas.Name = "RadNoCuadradas"
        Me.RadNoCuadradas.Size = New System.Drawing.Size(93, 17)
        Me.RadNoCuadradas.TabIndex = 2
        Me.RadNoCuadradas.Text = "No Cuadradas"
        Me.RadNoCuadradas.UseVisualStyleBackColor = True
        '
        'RadCuadradas
        '
        Me.RadCuadradas.AutoSize = True
        Me.RadCuadradas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadCuadradas.Location = New System.Drawing.Point(99, 19)
        Me.RadCuadradas.Name = "RadCuadradas"
        Me.RadCuadradas.Size = New System.Drawing.Size(76, 17)
        Me.RadCuadradas.TabIndex = 1
        Me.RadCuadradas.Text = "Cuadradas"
        Me.RadCuadradas.UseVisualStyleBackColor = True
        '
        'RadTodas
        '
        Me.RadTodas.AutoSize = True
        Me.RadTodas.Checked = True
        Me.RadTodas.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.RadTodas.Location = New System.Drawing.Point(6, 19)
        Me.RadTodas.Name = "RadTodas"
        Me.RadTodas.Size = New System.Drawing.Size(55, 17)
        Me.RadTodas.TabIndex = 0
        Me.RadTodas.TabStop = True
        Me.RadTodas.Text = "Todas"
        Me.RadTodas.UseVisualStyleBackColor = True
        '
        'CdeFechaFinal
        '
        Me.CdeFechaFinal.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.CdeFechaFinal.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.CdeFechaFinal.Location = New System.Drawing.Point(292, 27)
        Me.CdeFechaFinal.MaskInfo.AutoTabWhenFilled = True
        Me.CdeFechaFinal.MaskInfo.EmptyAsNull = True
        Me.CdeFechaFinal.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.CdeFechaFinal.Name = "CdeFechaFinal"
        Me.CdeFechaFinal.Size = New System.Drawing.Size(130, 20)
        Me.CdeFechaFinal.TabIndex = 5
        Me.CdeFechaFinal.Tag = Nothing
        Me.CdeFechaFinal.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'cdeFechaInicial
        '
        Me.cdeFechaInicial.EditFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.EditFormat.Inherit = CType((((C1.Win.C1Input.FormatInfoInheritFlags.NullText Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
                    Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaInicial.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaInicial.Location = New System.Drawing.Point(88, 27)
        Me.cdeFechaInicial.MaskInfo.AutoTabWhenFilled = True
        Me.cdeFechaInicial.MaskInfo.EmptyAsNull = True
        Me.cdeFechaInicial.MaskInfo.Inherit = CType((C1.Win.C1Input.MaskInfoInheritFlags.CaseSensitive Or C1.Win.C1Input.MaskInfoInheritFlags.ErrorMessage), C1.Win.C1Input.MaskInfoInheritFlags)
        Me.cdeFechaInicial.Name = "cdeFechaInicial"
        Me.cdeFechaInicial.Size = New System.Drawing.Size(123, 20)
        Me.cdeFechaInicial.TabIndex = 4
        Me.cdeFechaInicial.Tag = Nothing
        Me.cdeFechaInicial.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(224, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 41
        Me.Label3.Text = "Fecha Final:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(15, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(70, 13)
        Me.Label4.TabIndex = 40
        Me.Label4.Text = "Fecha Inicial:"
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(383, 153)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 27)
        Me.cmdCancelar.TabIndex = 15
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'frmScnParametrosMinutas
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(469, 192)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.grpdatos)
        Me.Controls.Add(Me.cmdCancelar)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmScnParametrosMinutas"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reporte de Minutas"
        CType(Me.errParametro, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpdatos.ResumeLayout(False)
        Me.grpdatos.PerformLayout()
        Me.grpTipoCuadre.ResumeLayout(False)
        Me.grpTipoCuadre.PerformLayout()
        CType(Me.CdeFechaFinal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaInicial, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents errParametro As System.Windows.Forms.ErrorProvider
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpdatos As System.Windows.Forms.GroupBox
    Friend WithEvents CdeFechaFinal As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaInicial As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents RadTodas As System.Windows.Forms.RadioButton
    Friend WithEvents RadNoCuadradas As System.Windows.Forms.RadioButton
    Friend WithEvents RadCuadradas As System.Windows.Forms.RadioButton
    Friend WithEvents grpTipoCuadre As System.Windows.Forms.GroupBox
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
End Class
