<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSteEditImpresionChequesPorGrupo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSteEditImpresionChequesPorGrupo))
        Me.grpGenerales = New System.Windows.Forms.GroupBox()
        Me.txtNumChequeFinal = New System.Windows.Forms.TextBox()
        Me.bVerificar = New System.Windows.Forms.Button()
        Me.cdeFechaCheque = New C1.Win.C1Input.C1DateEdit()
        Me.lblFechaCheque = New System.Windows.Forms.Label()
        Me.txtNumChequeInicial = New System.Windows.Forms.TextBox()
        Me.lblNumeroChequeFinal = New System.Windows.Forms.Label()
        Me.lblNumeroChequeInicial = New System.Windows.Forms.Label()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        Me.grdSolicitudes = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.grpGenerales.SuspendLayout()
        CType(Me.cdeFechaCheque, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'grpGenerales
        '
        Me.grpGenerales.Controls.Add(Me.txtNumChequeFinal)
        Me.grpGenerales.Controls.Add(Me.bVerificar)
        Me.grpGenerales.Controls.Add(Me.cdeFechaCheque)
        Me.grpGenerales.Controls.Add(Me.lblFechaCheque)
        Me.grpGenerales.Controls.Add(Me.txtNumChequeInicial)
        Me.grpGenerales.Controls.Add(Me.lblNumeroChequeFinal)
        Me.grpGenerales.Controls.Add(Me.lblNumeroChequeInicial)
        Me.grpGenerales.Location = New System.Drawing.Point(33, 12)
        Me.grpGenerales.Name = "grpGenerales"
        Me.grpGenerales.Size = New System.Drawing.Size(437, 140)
        Me.grpGenerales.TabIndex = 2
        Me.grpGenerales.TabStop = False
        Me.grpGenerales.Text = "Datos Generales"
        '
        'txtNumChequeFinal
        '
        Me.txtNumChequeFinal.BackColor = System.Drawing.SystemColors.Info
        Me.txtNumChequeFinal.Enabled = False
        Me.txtNumChequeFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNumChequeFinal.Location = New System.Drawing.Point(151, 65)
        Me.txtNumChequeFinal.Name = "txtNumChequeFinal"
        Me.txtNumChequeFinal.ReadOnly = True
        Me.txtNumChequeFinal.Size = New System.Drawing.Size(126, 20)
        Me.txtNumChequeFinal.TabIndex = 36
        Me.txtNumChequeFinal.Tag = "LAYOUT:FLAT"
        '
        'bVerificar
        '
        Me.bVerificar.Image = Global.SMUSURA0.My.Resources.Resources.AprobarPartida16
        Me.bVerificar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.bVerificar.Location = New System.Drawing.Point(287, 27)
        Me.bVerificar.Name = "bVerificar"
        Me.bVerificar.Size = New System.Drawing.Size(22, 25)
        Me.bVerificar.TabIndex = 5
        Me.bVerificar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.bVerificar.UseVisualStyleBackColor = True
        '
        'cdeFechaCheque
        '
        Me.cdeFechaCheque.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCheque.Location = New System.Drawing.Point(151, 98)
        Me.cdeFechaCheque.Name = "cdeFechaCheque"
        Me.cdeFechaCheque.Size = New System.Drawing.Size(127, 20)
        Me.cdeFechaCheque.TabIndex = 123
        Me.cdeFechaCheque.Tag = Nothing
        Me.cdeFechaCheque.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'lblFechaCheque
        '
        Me.lblFechaCheque.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaCheque.Location = New System.Drawing.Point(13, 98)
        Me.lblFechaCheque.Name = "lblFechaCheque"
        Me.lblFechaCheque.Size = New System.Drawing.Size(113, 19)
        Me.lblFechaCheque.TabIndex = 122
        Me.lblFechaCheque.Text = "Fecha del Cheque:"
        '
        'txtNumChequeInicial
        '
        Me.txtNumChequeInicial.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtNumChequeInicial.Location = New System.Drawing.Point(151, 24)
        Me.txtNumChequeInicial.Name = "txtNumChequeInicial"
        Me.txtNumChequeInicial.Size = New System.Drawing.Size(126, 20)
        Me.txtNumChequeInicial.TabIndex = 46
        '
        'lblNumeroChequeFinal
        '
        Me.lblNumeroChequeFinal.AutoSize = True
        Me.lblNumeroChequeFinal.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroChequeFinal.Location = New System.Drawing.Point(13, 65)
        Me.lblNumeroChequeFinal.Name = "lblNumeroChequeFinal"
        Me.lblNumeroChequeFinal.Size = New System.Drawing.Size(124, 13)
        Me.lblNumeroChequeFinal.TabIndex = 45
        Me.lblNumeroChequeFinal.Text = "Número de ChequeFinal:"
        '
        'lblNumeroChequeInicial
        '
        Me.lblNumeroChequeInicial.AutoSize = True
        Me.lblNumeroChequeInicial.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNumeroChequeInicial.Location = New System.Drawing.Point(13, 27)
        Me.lblNumeroChequeInicial.Name = "lblNumeroChequeInicial"
        Me.lblNumeroChequeInicial.Size = New System.Drawing.Size(132, 13)
        Me.lblNumeroChequeInicial.TabIndex = 44
        Me.lblNumeroChequeInicial.Text = "Número de Cheque Inicial:"
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Enabled = False
        Me.cmdAceptar.Image = CType(resources.GetObject("cmdAceptar.Image"), System.Drawing.Image)
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(320, 158)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 25)
        Me.cmdAceptar.TabIndex = 1
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(397, 158)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(73, 25)
        Me.cmdCancelar.TabIndex = 3
        Me.cmdCancelar.Text = "Cerrar"
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'grdSolicitudes
        '
        Me.grdSolicitudes.AllowFilter = False
        Me.grdSolicitudes.AllowUpdate = False
        Me.grdSolicitudes.DataView = C1.Win.C1TrueDBGrid.DataViewEnum.GroupBy
        Me.grdSolicitudes.FilterBar = True
        Me.grdSolicitudes.GroupByCaption = "Socias del Grupo"
        Me.grdSolicitudes.Images.Add(CType(resources.GetObject("grdSolicitudes.Images"), System.Drawing.Image))
        Me.grdSolicitudes.Location = New System.Drawing.Point(12, 207)
        Me.grdSolicitudes.Name = "grdSolicitudes"
        Me.grdSolicitudes.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdSolicitudes.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdSolicitudes.PreviewInfo.ZoomFactor = 75.0R
        Me.grdSolicitudes.PrintInfo.PageSettings = CType(resources.GetObject("grdSolicitudes.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdSolicitudes.Size = New System.Drawing.Size(458, 159)
        Me.grdSolicitudes.TabIndex = 4
        Me.grdSolicitudes.Text = "grdArqueo"
        Me.grdSolicitudes.PropBag = resources.GetString("grdSolicitudes.PropBag")
        '
        'frmSteEditImpresionChequesPorGrupo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(493, 390)
        Me.Controls.Add(Me.grdSolicitudes)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.grpGenerales)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Name = "frmSteEditImpresionChequesPorGrupo"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asignación de números de cheques por grupo."
        Me.grpGenerales.ResumeLayout(False)
        Me.grpGenerales.PerformLayout()
        CType(Me.cdeFechaCheque, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdSolicitudes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents grpGenerales As System.Windows.Forms.GroupBox
    Friend WithEvents lblNumeroChequeFinal As System.Windows.Forms.Label
    Friend WithEvents lblNumeroChequeInicial As System.Windows.Forms.Label
    Friend WithEvents txtNumChequeInicial As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaCheque As System.Windows.Forms.Label
    Friend WithEvents cdeFechaCheque As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents grdSolicitudes As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents bVerificar As System.Windows.Forms.Button
    Friend WithEvents txtNumChequeFinal As System.Windows.Forms.TextBox
End Class
