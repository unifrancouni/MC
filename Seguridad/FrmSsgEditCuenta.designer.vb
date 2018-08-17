<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmSsgEditCuenta
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
        Me.components = New System.ComponentModel.Container()
        Dim Style1 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style2 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style3 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style4 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style5 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmSsgEditCuenta))
        Dim Style6 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style7 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style8 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style9 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style10 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style11 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style12 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style13 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style14 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style15 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style16 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style17 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style18 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style19 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style20 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style21 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style22 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style23 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Dim Style24 As C1.Win.C1List.Style = New C1.Win.C1List.Style()
        Me.tabCuentaRol = New C1.Win.C1Command.C1DockingTab()
        Me.C1DockingTabPage1 = New C1.Win.C1Command.C1DockingTabPage()
        Me.grpDatosCuenta = New System.Windows.Forms.GroupBox()
        Me.lblBloqueada = New System.Windows.Forms.Label()
        Me.btnDesbloquear = New System.Windows.Forms.Button()
        Me.txtPaswordAnterior = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtConfirmacion = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.chkActivo = New System.Windows.Forms.CheckBox()
        Me.cdeFechaExpiracion = New C1.Win.C1Input.C1DateEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblFechaInicia = New System.Windows.Forms.Label()
        Me.cdeFechaCreacion = New C1.Win.C1Input.C1DateEdit()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.LblClave = New System.Windows.Forms.Label()
        Me.lblNombre = New System.Windows.Forms.Label()
        Me.txtLogin = New System.Windows.Forms.TextBox()
        Me.grpDatosEmpleado = New System.Windows.Forms.GroupBox()
        Me.lblDelegacion = New System.Windows.Forms.Label()
        Me.cboDelegacion = New C1.Win.C1List.C1Combo()
        Me.chkActivoEmpleado = New System.Windows.Forms.CheckBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtCedula = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtFechaFinEmp = New System.Windows.Forms.TextBox()
        Me.txtFechaInicioEmp = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboEmpleado = New C1.Win.C1List.C1Combo()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtNombreEmp = New System.Windows.Forms.TextBox()
        Me.tabPRoles = New C1.Win.C1Command.C1DockingTabPage()
        Me.BtnDesMarcarTodoRoles = New System.Windows.Forms.Button()
        Me.BtnMarcarTodoRoles = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.grpConcesionRoles = New System.Windows.Forms.GroupBox()
        Me.cboUsuarios = New C1.Win.C1List.C1Combo()
        Me.rdoConceder = New System.Windows.Forms.RadioButton()
        Me.rdoDenegar = New System.Windows.Forms.RadioButton()
        Me.txtLoginOfTransfer = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.grdRoles = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.C1DockingTabPage2 = New C1.Win.C1Command.C1DockingTabPage()
        Me.cmdAccionesUsuario = New System.Windows.Forms.Button()
        Me.cmdRolesxAcción = New System.Windows.Forms.Button()
        Me.btnMarcarTodo = New System.Windows.Forms.Button()
        Me.btnDesmarcarTodo = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.trvAccionesPosibles = New System.Windows.Forms.TreeView()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.HelpProvider = New System.Windows.Forms.HelpProvider()
        Me.cmdAceptar = New System.Windows.Forms.Button()
        Me.cmdCancelar = New System.Windows.Forms.Button()
        CType(Me.tabCuentaRol, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabCuentaRol.SuspendLayout()
        Me.C1DockingTabPage1.SuspendLayout()
        Me.grpDatosCuenta.SuspendLayout()
        CType(Me.cdeFechaExpiracion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cdeFechaCreacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.grpDatosEmpleado.SuspendLayout()
        CType(Me.cboDelegacion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.cboEmpleado, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tabPRoles.SuspendLayout()
        Me.grpConcesionRoles.SuspendLayout()
        CType(Me.cboUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.grdRoles, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.C1DockingTabPage2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'tabCuentaRol
        '
        Me.tabCuentaRol.Controls.Add(Me.C1DockingTabPage1)
        Me.tabCuentaRol.Controls.Add(Me.tabPRoles)
        Me.tabCuentaRol.Controls.Add(Me.C1DockingTabPage2)
        Me.tabCuentaRol.Location = New System.Drawing.Point(7, 12)
        Me.tabCuentaRol.Name = "tabCuentaRol"
        Me.tabCuentaRol.SelectedIndex = 2
        Me.tabCuentaRol.Size = New System.Drawing.Size(548, 365)
        Me.tabCuentaRol.TabIndex = 12
        '
        'C1DockingTabPage1
        '
        Me.C1DockingTabPage1.Controls.Add(Me.grpDatosCuenta)
        Me.C1DockingTabPage1.Controls.Add(Me.grpDatosEmpleado)
        Me.C1DockingTabPage1.Image = CType(resources.GetObject("C1DockingTabPage1.Image"), System.Drawing.Image)
        Me.C1DockingTabPage1.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage1.Name = "C1DockingTabPage1"
        Me.C1DockingTabPage1.Size = New System.Drawing.Size(546, 339)
        Me.C1DockingTabPage1.TabIndex = 0
        Me.C1DockingTabPage1.Text = "Cuenta de Usuario"
        '
        'grpDatosCuenta
        '
        Me.grpDatosCuenta.Controls.Add(Me.lblBloqueada)
        Me.grpDatosCuenta.Controls.Add(Me.btnDesbloquear)
        Me.grpDatosCuenta.Controls.Add(Me.txtPaswordAnterior)
        Me.grpDatosCuenta.Controls.Add(Me.Label10)
        Me.grpDatosCuenta.Controls.Add(Me.Label7)
        Me.grpDatosCuenta.Controls.Add(Me.txtConfirmacion)
        Me.grpDatosCuenta.Controls.Add(Me.Label6)
        Me.grpDatosCuenta.Controls.Add(Me.chkActivo)
        Me.grpDatosCuenta.Controls.Add(Me.cdeFechaExpiracion)
        Me.grpDatosCuenta.Controls.Add(Me.Label5)
        Me.grpDatosCuenta.Controls.Add(Me.lblFechaInicia)
        Me.grpDatosCuenta.Controls.Add(Me.cdeFechaCreacion)
        Me.grpDatosCuenta.Controls.Add(Me.txtPassword)
        Me.grpDatosCuenta.Controls.Add(Me.LblClave)
        Me.grpDatosCuenta.Controls.Add(Me.lblNombre)
        Me.grpDatosCuenta.Controls.Add(Me.txtLogin)
        Me.grpDatosCuenta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosCuenta.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosCuenta.Location = New System.Drawing.Point(12, 192)
        Me.grpDatosCuenta.Name = "grpDatosCuenta"
        Me.grpDatosCuenta.Size = New System.Drawing.Size(443, 133)
        Me.grpDatosCuenta.TabIndex = 9
        Me.grpDatosCuenta.TabStop = False
        Me.grpDatosCuenta.Text = "Datos de la Cuenta"
        '
        'lblBloqueada
        '
        Me.lblBloqueada.AutoEllipsis = True
        Me.lblBloqueada.AutoSize = True
        Me.lblBloqueada.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBloqueada.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.lblBloqueada.Location = New System.Drawing.Point(228, 89)
        Me.lblBloqueada.Name = "lblBloqueada"
        Me.lblBloqueada.Size = New System.Drawing.Size(205, 15)
        Me.lblBloqueada.TabIndex = 19
        Me.lblBloqueada.Text = "Cuenta Bloqueada por intentos"
        Me.lblBloqueada.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        Me.lblBloqueada.Visible = False
        '
        'btnDesbloquear
        '
        Me.btnDesbloquear.Location = New System.Drawing.Point(335, 108)
        Me.btnDesbloquear.Name = "btnDesbloquear"
        Me.btnDesbloquear.Size = New System.Drawing.Size(94, 23)
        Me.btnDesbloquear.TabIndex = 17
        Me.btnDesbloquear.Text = "Desbloquear"
        Me.btnDesbloquear.UseVisualStyleBackColor = True
        Me.btnDesbloquear.Visible = False
        '
        'txtPaswordAnterior
        '
        Me.txtPaswordAnterior.Location = New System.Drawing.Point(107, 45)
        Me.txtPaswordAnterior.Name = "txtPaswordAnterior"
        Me.txtPaswordAnterior.Size = New System.Drawing.Size(105, 20)
        Me.txtPaswordAnterior.TabIndex = 1
        Me.txtPaswordAnterior.UseSystemPasswordChar = True
        '
        'Label10
        '
        Me.Label10.AutoEllipsis = True
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label10.Location = New System.Drawing.Point(4, 48)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(95, 13)
        Me.Label10.TabIndex = 16
        Me.Label10.Text = "Password Anterior:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label7
        '
        Me.Label7.AutoEllipsis = True
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(4, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(71, 13)
        Me.Label7.TabIndex = 14
        Me.Label7.Text = "Confirmación:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtConfirmacion
        '
        Me.txtConfirmacion.Location = New System.Drawing.Point(107, 98)
        Me.txtConfirmacion.Name = "txtConfirmacion"
        Me.txtConfirmacion.Size = New System.Drawing.Size(105, 20)
        Me.txtConfirmacion.TabIndex = 3
        Me.txtConfirmacion.UseSystemPasswordChar = True
        '
        'Label6
        '
        Me.Label6.AutoEllipsis = True
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(228, 72)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "Activo:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'chkActivo
        '
        Me.chkActivo.AutoSize = True
        Me.chkActivo.Location = New System.Drawing.Point(316, 72)
        Me.chkActivo.Name = "chkActivo"
        Me.chkActivo.Size = New System.Drawing.Size(15, 14)
        Me.chkActivo.TabIndex = 6
        Me.chkActivo.UseVisualStyleBackColor = True
        '
        'cdeFechaExpiracion
        '
        Me.cdeFechaExpiracion.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaExpiracion.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaExpiracion.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaExpiracion.Location = New System.Drawing.Point(317, 45)
        Me.cdeFechaExpiracion.Name = "cdeFechaExpiracion"
        Me.cdeFechaExpiracion.Size = New System.Drawing.Size(112, 20)
        Me.cdeFechaExpiracion.TabIndex = 5
        Me.cdeFechaExpiracion.Tag = Nothing
        Me.cdeFechaExpiracion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'Label5
        '
        Me.Label5.AutoEllipsis = True
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label5.Location = New System.Drawing.Point(228, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(92, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Fecha Expiración:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblFechaInicia
        '
        Me.lblFechaInicia.AutoEllipsis = True
        Me.lblFechaInicia.AutoSize = True
        Me.lblFechaInicia.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFechaInicia.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblFechaInicia.Location = New System.Drawing.Point(228, 20)
        Me.lblFechaInicia.Name = "lblFechaInicia"
        Me.lblFechaInicia.Size = New System.Drawing.Size(85, 13)
        Me.lblFechaInicia.TabIndex = 8
        Me.lblFechaInicia.Text = "Fecha Creación:"
        Me.lblFechaInicia.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cdeFechaCreacion
        '
        Me.cdeFechaCreacion.DisplayFormat.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCreacion.DisplayFormat.Inherit = CType(((((C1.Win.C1Input.FormatInfoInheritFlags.CustomFormat Or C1.Win.C1Input.FormatInfoInheritFlags.NullText) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.EmptyAsNull) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimStart) _
            Or C1.Win.C1Input.FormatInfoInheritFlags.TrimEnd), C1.Win.C1Input.FormatInfoInheritFlags)
        Me.cdeFechaCreacion.FormatType = C1.Win.C1Input.FormatTypeEnum.ShortDate
        Me.cdeFechaCreacion.Location = New System.Drawing.Point(317, 17)
        Me.cdeFechaCreacion.Name = "cdeFechaCreacion"
        Me.cdeFechaCreacion.Size = New System.Drawing.Size(112, 20)
        Me.cdeFechaCreacion.TabIndex = 4
        Me.cdeFechaCreacion.Tag = Nothing
        Me.cdeFechaCreacion.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        '
        'txtPassword
        '
        Me.txtPassword.Location = New System.Drawing.Point(107, 72)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(105, 20)
        Me.txtPassword.TabIndex = 2
        Me.txtPassword.UseSystemPasswordChar = True
        '
        'LblClave
        '
        Me.LblClave.AutoEllipsis = True
        Me.LblClave.AutoSize = True
        Me.LblClave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LblClave.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.LblClave.Location = New System.Drawing.Point(4, 75)
        Me.LblClave.Name = "LblClave"
        Me.LblClave.Size = New System.Drawing.Size(56, 13)
        Me.LblClave.TabIndex = 5
        Me.LblClave.Text = "Password:"
        Me.LblClave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblNombre
        '
        Me.lblNombre.AutoSize = True
        Me.lblNombre.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblNombre.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblNombre.Location = New System.Drawing.Point(6, 22)
        Me.lblNombre.Name = "lblNombre"
        Me.lblNombre.Size = New System.Drawing.Size(36, 13)
        Me.lblNombre.TabIndex = 4
        Me.lblNombre.Text = "Login:"
        '
        'txtLogin
        '
        Me.txtLogin.Location = New System.Drawing.Point(107, 19)
        Me.txtLogin.Name = "txtLogin"
        Me.txtLogin.Size = New System.Drawing.Size(105, 20)
        Me.txtLogin.TabIndex = 0
        '
        'grpDatosEmpleado
        '
        Me.grpDatosEmpleado.Controls.Add(Me.lblDelegacion)
        Me.grpDatosEmpleado.Controls.Add(Me.cboDelegacion)
        Me.grpDatosEmpleado.Controls.Add(Me.chkActivoEmpleado)
        Me.grpDatosEmpleado.Controls.Add(Me.Label9)
        Me.grpDatosEmpleado.Controls.Add(Me.Label8)
        Me.grpDatosEmpleado.Controls.Add(Me.txtCedula)
        Me.grpDatosEmpleado.Controls.Add(Me.Label4)
        Me.grpDatosEmpleado.Controls.Add(Me.txtFechaFinEmp)
        Me.grpDatosEmpleado.Controls.Add(Me.txtFechaInicioEmp)
        Me.grpDatosEmpleado.Controls.Add(Me.Label3)
        Me.grpDatosEmpleado.Controls.Add(Me.Label1)
        Me.grpDatosEmpleado.Controls.Add(Me.cboEmpleado)
        Me.grpDatosEmpleado.Controls.Add(Me.Label2)
        Me.grpDatosEmpleado.Controls.Add(Me.txtNombreEmp)
        Me.grpDatosEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.grpDatosEmpleado.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.grpDatosEmpleado.Location = New System.Drawing.Point(12, 10)
        Me.grpDatosEmpleado.Name = "grpDatosEmpleado"
        Me.grpDatosEmpleado.Size = New System.Drawing.Size(443, 164)
        Me.grpDatosEmpleado.TabIndex = 8
        Me.grpDatosEmpleado.TabStop = False
        Me.grpDatosEmpleado.Text = "Datos del Empleado"
        '
        'lblDelegacion
        '
        Me.lblDelegacion.AutoSize = True
        Me.lblDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDelegacion.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.lblDelegacion.Location = New System.Drawing.Point(7, 134)
        Me.lblDelegacion.Name = "lblDelegacion"
        Me.lblDelegacion.Size = New System.Drawing.Size(64, 13)
        Me.lblDelegacion.TabIndex = 15
        Me.lblDelegacion.Text = "Delegación:"
        '
        'cboDelegacion
        '
        Me.cboDelegacion.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboDelegacion.AutoCompletion = True
        Me.cboDelegacion.AutoDropDown = True
        Me.cboDelegacion.Caption = ""
        Me.cboDelegacion.CaptionHeight = 17
        Me.cboDelegacion.CaptionStyle = Style1
        Me.cboDelegacion.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboDelegacion.ColumnCaptionHeight = 17
        Me.cboDelegacion.ColumnFooterHeight = 17
        Me.cboDelegacion.ContentHeight = 15
        Me.cboDelegacion.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboDelegacion.DisplayMember = "sNombreDelegacion"
        Me.cboDelegacion.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboDelegacion.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDelegacion.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboDelegacion.EditorHeight = 15
        Me.cboDelegacion.EvenRowStyle = Style2
        Me.cboDelegacion.ExtendRightColumn = True
        Me.cboDelegacion.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboDelegacion.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboDelegacion.FooterStyle = Style3
        Me.cboDelegacion.GapHeight = 2
        Me.cboDelegacion.HeadingStyle = Style4
        Me.cboDelegacion.HighLightRowStyle = Style5
        Me.cboDelegacion.Images.Add(CType(resources.GetObject("cboDelegacion.Images"), System.Drawing.Image))
        Me.cboDelegacion.ItemHeight = 15
        Me.cboDelegacion.LimitToList = True
        Me.cboDelegacion.Location = New System.Drawing.Point(108, 126)
        Me.cboDelegacion.MatchEntryTimeout = CType(2000, Long)
        Me.cboDelegacion.MaxDropDownItems = CType(5, Short)
        Me.cboDelegacion.MaxLength = 32767
        Me.cboDelegacion.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboDelegacion.Name = "cboDelegacion"
        Me.cboDelegacion.OddRowStyle = Style6
        Me.cboDelegacion.PartialRightColumn = False
        Me.cboDelegacion.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboDelegacion.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboDelegacion.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboDelegacion.SelectedStyle = Style7
        Me.cboDelegacion.Size = New System.Drawing.Size(322, 21)
        Me.cboDelegacion.Style = Style8
        Me.cboDelegacion.SuperBack = True
        Me.cboDelegacion.TabIndex = 6
        Me.cboDelegacion.ValueMember = "StbDelegacionID"
        Me.cboDelegacion.PropBag = resources.GetString("cboDelegacion.PropBag")
        '
        'chkActivoEmpleado
        '
        Me.chkActivoEmpleado.AutoSize = True
        Me.chkActivoEmpleado.BackColor = System.Drawing.SystemColors.Info
        Me.chkActivoEmpleado.Location = New System.Drawing.Point(108, 100)
        Me.chkActivoEmpleado.Name = "chkActivoEmpleado"
        Me.chkActivoEmpleado.Size = New System.Drawing.Size(15, 14)
        Me.chkActivoEmpleado.TabIndex = 4
        Me.chkActivoEmpleado.UseVisualStyleBackColor = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label9.Location = New System.Drawing.Point(8, 100)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 13)
        Me.Label9.TabIndex = 13
        Me.Label9.Text = "Activo:"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label8.Location = New System.Drawing.Point(6, 77)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(43, 13)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Cédula:"
        '
        'txtCedula
        '
        Me.txtCedula.BackColor = System.Drawing.SystemColors.Info
        Me.txtCedula.Enabled = False
        Me.txtCedula.Location = New System.Drawing.Point(107, 74)
        Me.txtCedula.MaxLength = 100
        Me.txtCedula.Name = "txtCedula"
        Me.txtCedula.Size = New System.Drawing.Size(104, 20)
        Me.txtCedula.TabIndex = 2
        Me.txtCedula.Tag = "LAYOUT:FLAT"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label4.Location = New System.Drawing.Point(228, 100)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(76, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "Fecha Egreso:"
        '
        'txtFechaFinEmp
        '
        Me.txtFechaFinEmp.BackColor = System.Drawing.SystemColors.Info
        Me.txtFechaFinEmp.Enabled = False
        Me.txtFechaFinEmp.Location = New System.Drawing.Point(317, 100)
        Me.txtFechaFinEmp.MaxLength = 100
        Me.txtFechaFinEmp.Name = "txtFechaFinEmp"
        Me.txtFechaFinEmp.Size = New System.Drawing.Size(112, 20)
        Me.txtFechaFinEmp.TabIndex = 5
        Me.txtFechaFinEmp.Tag = "LAYOUT:FLAT"
        '
        'txtFechaInicioEmp
        '
        Me.txtFechaInicioEmp.BackColor = System.Drawing.SystemColors.Info
        Me.txtFechaInicioEmp.Enabled = False
        Me.txtFechaInicioEmp.Location = New System.Drawing.Point(317, 74)
        Me.txtFechaInicioEmp.MaxLength = 100
        Me.txtFechaInicioEmp.Name = "txtFechaInicioEmp"
        Me.txtFechaInicioEmp.Size = New System.Drawing.Size(112, 20)
        Me.txtFechaInicioEmp.TabIndex = 3
        Me.txtFechaInicioEmp.Tag = "LAYOUT:FLAT"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label3.Location = New System.Drawing.Point(228, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(78, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Fecha Ingreso:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(73, Byte), Integer), CType(CType(35, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(6, 29)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Empleado:"
        '
        'cboEmpleado
        '
        Me.cboEmpleado.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboEmpleado.AutoCompletion = True
        Me.cboEmpleado.AutoDropDown = True
        Me.cboEmpleado.Caption = ""
        Me.cboEmpleado.CaptionHeight = 17
        Me.cboEmpleado.CaptionStyle = Style9
        Me.cboEmpleado.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboEmpleado.ColumnCaptionHeight = 17
        Me.cboEmpleado.ColumnFooterHeight = 17
        Me.cboEmpleado.ContentHeight = 15
        Me.cboEmpleado.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboEmpleado.DisplayMember = "NombreEmpleado"
        Me.cboEmpleado.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboEmpleado.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpleado.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboEmpleado.EditorHeight = 15
        Me.cboEmpleado.EvenRowStyle = Style10
        Me.cboEmpleado.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboEmpleado.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboEmpleado.FooterStyle = Style11
        Me.cboEmpleado.GapHeight = 2
        Me.cboEmpleado.HeadingStyle = Style12
        Me.cboEmpleado.HighLightRowStyle = Style13
        Me.cboEmpleado.Images.Add(CType(resources.GetObject("cboEmpleado.Images"), System.Drawing.Image))
        Me.cboEmpleado.ItemHeight = 15
        Me.cboEmpleado.LimitToList = True
        Me.cboEmpleado.Location = New System.Drawing.Point(107, 21)
        Me.cboEmpleado.MatchEntryTimeout = CType(2000, Long)
        Me.cboEmpleado.MaxDropDownItems = CType(5, Short)
        Me.cboEmpleado.MaxLength = 32767
        Me.cboEmpleado.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboEmpleado.Name = "cboEmpleado"
        Me.cboEmpleado.OddRowStyle = Style14
        Me.cboEmpleado.PartialRightColumn = False
        Me.cboEmpleado.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboEmpleado.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboEmpleado.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboEmpleado.SelectedStyle = Style15
        Me.cboEmpleado.Size = New System.Drawing.Size(322, 21)
        Me.cboEmpleado.Style = Style16
        Me.cboEmpleado.SuperBack = True
        Me.cboEmpleado.TabIndex = 0
        Me.cboEmpleado.ValueMember = "SrhEmpleadoID"
        Me.cboEmpleado.PropBag = resources.GetString("cboEmpleado.PropBag")
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label2.Location = New System.Drawing.Point(6, 51)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(94, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Nombre Completo:"
        '
        'txtNombreEmp
        '
        Me.txtNombreEmp.BackColor = System.Drawing.SystemColors.Info
        Me.txtNombreEmp.Enabled = False
        Me.txtNombreEmp.Location = New System.Drawing.Point(107, 48)
        Me.txtNombreEmp.MaxLength = 100
        Me.txtNombreEmp.Name = "txtNombreEmp"
        Me.txtNombreEmp.Size = New System.Drawing.Size(322, 20)
        Me.txtNombreEmp.TabIndex = 1
        Me.txtNombreEmp.Tag = "LAYOUT:FLAT"
        '
        'tabPRoles
        '
        Me.tabPRoles.Controls.Add(Me.BtnDesMarcarTodoRoles)
        Me.tabPRoles.Controls.Add(Me.BtnMarcarTodoRoles)
        Me.tabPRoles.Controls.Add(Me.btnGuardar)
        Me.tabPRoles.Controls.Add(Me.grpConcesionRoles)
        Me.tabPRoles.Controls.Add(Me.grdRoles)
        Me.tabPRoles.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.tabPRoles.Location = New System.Drawing.Point(1, 25)
        Me.tabPRoles.Name = "tabPRoles"
        Me.tabPRoles.Size = New System.Drawing.Size(546, 339)
        Me.tabPRoles.TabIndex = 1
        Me.tabPRoles.Text = "Roles"
        '
        'BtnDesMarcarTodoRoles
        '
        Me.BtnDesMarcarTodoRoles.Location = New System.Drawing.Point(464, 262)
        Me.BtnDesMarcarTodoRoles.Name = "BtnDesMarcarTodoRoles"
        Me.BtnDesMarcarTodoRoles.Size = New System.Drawing.Size(71, 36)
        Me.BtnDesMarcarTodoRoles.TabIndex = 15
        Me.BtnDesMarcarTodoRoles.Text = "DesMarcar Todo"
        Me.BtnDesMarcarTodoRoles.UseVisualStyleBackColor = True
        '
        'BtnMarcarTodoRoles
        '
        Me.BtnMarcarTodoRoles.Location = New System.Drawing.Point(387, 262)
        Me.BtnMarcarTodoRoles.Name = "BtnMarcarTodoRoles"
        Me.BtnMarcarTodoRoles.Size = New System.Drawing.Size(71, 36)
        Me.BtnMarcarTodoRoles.TabIndex = 14
        Me.BtnMarcarTodoRoles.Text = "Marcar Todo"
        Me.BtnMarcarTodoRoles.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.btnGuardar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGuardar.Location = New System.Drawing.Point(387, 306)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(71, 28)
        Me.btnGuardar.TabIndex = 13
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'grpConcesionRoles
        '
        Me.grpConcesionRoles.Controls.Add(Me.cboUsuarios)
        Me.grpConcesionRoles.Controls.Add(Me.rdoConceder)
        Me.grpConcesionRoles.Controls.Add(Me.rdoDenegar)
        Me.grpConcesionRoles.Controls.Add(Me.txtLoginOfTransfer)
        Me.grpConcesionRoles.Controls.Add(Me.Label12)
        Me.grpConcesionRoles.Controls.Add(Me.Label11)
        Me.grpConcesionRoles.Location = New System.Drawing.Point(5, 258)
        Me.grpConcesionRoles.Name = "grpConcesionRoles"
        Me.grpConcesionRoles.Size = New System.Drawing.Size(373, 78)
        Me.grpConcesionRoles.TabIndex = 9
        Me.grpConcesionRoles.TabStop = False
        Me.grpConcesionRoles.Text = "Concesión de Roles"
        '
        'cboUsuarios
        '
        Me.cboUsuarios.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cboUsuarios.AutoCompletion = True
        Me.cboUsuarios.Caption = ""
        Me.cboUsuarios.CaptionHeight = 17
        Me.cboUsuarios.CaptionStyle = Style17
        Me.cboUsuarios.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cboUsuarios.ColumnCaptionHeight = 17
        Me.cboUsuarios.ColumnFooterHeight = 17
        Me.cboUsuarios.ContentHeight = 15
        Me.cboUsuarios.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cboUsuarios.DisplayMember = "sNombre"
        Me.cboUsuarios.DropdownPosition = C1.Win.C1List.DropdownPositionEnum.LeftDown
        Me.cboUsuarios.DropDownWidth = 369
        Me.cboUsuarios.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cboUsuarios.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboUsuarios.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cboUsuarios.EditorHeight = 15
        Me.cboUsuarios.EvenRowStyle = Style18
        Me.cboUsuarios.ExtendRightColumn = True
        Me.cboUsuarios.FlatStyle = C1.Win.C1List.FlatModeEnum.Standard
        Me.cboUsuarios.FooterStyle = Style19
        Me.cboUsuarios.GapHeight = 2
        Me.cboUsuarios.HeadingStyle = Style20
        Me.cboUsuarios.HighLightRowStyle = Style21
        Me.cboUsuarios.Images.Add(CType(resources.GetObject("cboUsuarios.Images"), System.Drawing.Image))
        Me.cboUsuarios.ItemHeight = 15
        Me.cboUsuarios.LimitToList = True
        Me.cboUsuarios.Location = New System.Drawing.Point(65, 21)
        Me.cboUsuarios.MatchEntryTimeout = CType(2000, Long)
        Me.cboUsuarios.MaxDropDownItems = CType(5, Short)
        Me.cboUsuarios.MaxLength = 32767
        Me.cboUsuarios.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cboUsuarios.Name = "cboUsuarios"
        Me.cboUsuarios.OddRowStyle = Style22
        Me.cboUsuarios.PartialRightColumn = False
        Me.cboUsuarios.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cboUsuarios.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cboUsuarios.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cboUsuarios.SelectedStyle = Style23
        Me.cboUsuarios.Size = New System.Drawing.Size(218, 21)
        Me.cboUsuarios.Style = Style24
        Me.cboUsuarios.SuperBack = True
        Me.cboUsuarios.TabIndex = 6
        Me.cboUsuarios.ValueMember = "nSrhEmpleadoID"
        Me.cboUsuarios.PropBag = resources.GetString("cboUsuarios.PropBag")
        '
        'rdoConceder
        '
        Me.rdoConceder.AutoSize = True
        Me.rdoConceder.Checked = True
        Me.rdoConceder.Location = New System.Drawing.Point(289, 25)
        Me.rdoConceder.Name = "rdoConceder"
        Me.rdoConceder.Size = New System.Drawing.Size(71, 17)
        Me.rdoConceder.TabIndex = 5
        Me.rdoConceder.TabStop = True
        Me.rdoConceder.Text = "Conceder"
        Me.rdoConceder.UseVisualStyleBackColor = True
        '
        'rdoDenegar
        '
        Me.rdoDenegar.AutoSize = True
        Me.rdoDenegar.Location = New System.Drawing.Point(289, 48)
        Me.rdoDenegar.Name = "rdoDenegar"
        Me.rdoDenegar.Size = New System.Drawing.Size(66, 17)
        Me.rdoDenegar.TabIndex = 4
        Me.rdoDenegar.TabStop = True
        Me.rdoDenegar.Text = "Denegar"
        Me.rdoDenegar.UseVisualStyleBackColor = True
        '
        'txtLoginOfTransfer
        '
        Me.txtLoginOfTransfer.BackColor = System.Drawing.SystemColors.Info
        Me.txtLoginOfTransfer.Enabled = False
        Me.txtLoginOfTransfer.Location = New System.Drawing.Point(65, 48)
        Me.txtLoginOfTransfer.Name = "txtLoginOfTransfer"
        Me.txtLoginOfTransfer.Size = New System.Drawing.Size(218, 20)
        Me.txtLoginOfTransfer.TabIndex = 3
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(26, 55)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Login"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 27)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(43, 13)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Usuario"
        '
        'grdRoles
        '
        Me.grdRoles.ExtendRightColumn = True
        Me.grdRoles.FilterBar = True
        Me.grdRoles.GroupByCaption = "Drag a column header here to group by that column"
        Me.grdRoles.Images.Add(CType(resources.GetObject("grdRoles.Images"), System.Drawing.Image))
        Me.grdRoles.Location = New System.Drawing.Point(3, 13)
        Me.grdRoles.MarqueeStyle = C1.Win.C1TrueDBGrid.MarqueeEnum.HighlightRow
        Me.grdRoles.Name = "grdRoles"
        Me.grdRoles.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.grdRoles.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.grdRoles.PreviewInfo.ZoomFactor = 75.0R
        Me.grdRoles.PrintInfo.PageSettings = CType(resources.GetObject("grdRoles.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.grdRoles.Size = New System.Drawing.Size(540, 238)
        Me.grdRoles.TabIndex = 8
        Me.grdRoles.PropBag = resources.GetString("grdRoles.PropBag")
        '
        'C1DockingTabPage2
        '
        Me.C1DockingTabPage2.Controls.Add(Me.cmdAccionesUsuario)
        Me.C1DockingTabPage2.Controls.Add(Me.cmdRolesxAcción)
        Me.C1DockingTabPage2.Controls.Add(Me.btnMarcarTodo)
        Me.C1DockingTabPage2.Controls.Add(Me.btnDesmarcarTodo)
        Me.C1DockingTabPage2.Controls.Add(Me.GroupBox1)
        Me.C1DockingTabPage2.Image = Global.SMUSURA0.My.Resources.Resources.HojaLapiz16
        Me.C1DockingTabPage2.Location = New System.Drawing.Point(1, 25)
        Me.C1DockingTabPage2.Name = "C1DockingTabPage2"
        Me.C1DockingTabPage2.Size = New System.Drawing.Size(546, 339)
        Me.C1DockingTabPage2.TabIndex = 2
        Me.C1DockingTabPage2.Text = "Permisos"
        '
        'cmdAccionesUsuario
        '
        Me.cmdAccionesUsuario.Location = New System.Drawing.Point(15, 313)
        Me.cmdAccionesUsuario.Name = "cmdAccionesUsuario"
        Me.cmdAccionesUsuario.Size = New System.Drawing.Size(118, 23)
        Me.cmdAccionesUsuario.TabIndex = 13
        Me.cmdAccionesUsuario.Text = "Acciones x Usuario"
        Me.cmdAccionesUsuario.UseVisualStyleBackColor = True
        '
        'cmdRolesxAcción
        '
        Me.cmdRolesxAcción.Location = New System.Drawing.Point(141, 313)
        Me.cmdRolesxAcción.Name = "cmdRolesxAcción"
        Me.cmdRolesxAcción.Size = New System.Drawing.Size(102, 23)
        Me.cmdRolesxAcción.TabIndex = 3
        Me.cmdRolesxAcción.Text = "Roles x Acción"
        Me.cmdRolesxAcción.UseVisualStyleBackColor = True
        '
        'btnMarcarTodo
        '
        Me.btnMarcarTodo.Location = New System.Drawing.Point(249, 313)
        Me.btnMarcarTodo.Name = "btnMarcarTodo"
        Me.btnMarcarTodo.Size = New System.Drawing.Size(102, 23)
        Me.btnMarcarTodo.TabIndex = 2
        Me.btnMarcarTodo.Text = "Marcar Todo"
        Me.btnMarcarTodo.UseVisualStyleBackColor = True
        '
        'btnDesmarcarTodo
        '
        Me.btnDesmarcarTodo.Location = New System.Drawing.Point(357, 313)
        Me.btnDesmarcarTodo.Name = "btnDesmarcarTodo"
        Me.btnDesmarcarTodo.Size = New System.Drawing.Size(102, 23)
        Me.btnDesmarcarTodo.TabIndex = 1
        Me.btnDesmarcarTodo.Text = "Desmarcar Todo"
        Me.btnDesmarcarTodo.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.trvAccionesPosibles)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(528, 307)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Acciones Posibles"
        '
        'trvAccionesPosibles
        '
        Me.trvAccionesPosibles.CheckBoxes = True
        Me.trvAccionesPosibles.Dock = System.Windows.Forms.DockStyle.Fill
        Me.trvAccionesPosibles.Location = New System.Drawing.Point(3, 16)
        Me.trvAccionesPosibles.Name = "trvAccionesPosibles"
        Me.trvAccionesPosibles.Size = New System.Drawing.Size(522, 288)
        Me.trvAccionesPosibles.TabIndex = 0
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'cmdAceptar
        '
        Me.cmdAceptar.Image = Global.SMUSURA0.My.Resources.Resources.Aceptar16
        Me.cmdAceptar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdAceptar.Location = New System.Drawing.Point(337, 382)
        Me.cmdAceptar.Name = "cmdAceptar"
        Me.cmdAceptar.Size = New System.Drawing.Size(71, 28)
        Me.cmdAceptar.TabIndex = 9
        Me.cmdAceptar.Text = "Aceptar"
        Me.cmdAceptar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdAceptar.UseVisualStyleBackColor = True
        '
        'cmdCancelar
        '
        Me.cmdCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancelar.Image = CType(resources.GetObject("cmdCancelar.Image"), System.Drawing.Image)
        Me.cmdCancelar.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdCancelar.Location = New System.Drawing.Point(413, 382)
        Me.cmdCancelar.Name = "cmdCancelar"
        Me.cmdCancelar.Size = New System.Drawing.Size(71, 28)
        Me.cmdCancelar.TabIndex = 10
        Me.cmdCancelar.Text = "Cancelar"
        Me.cmdCancelar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.cmdCancelar.UseVisualStyleBackColor = True
        '
        'FrmSsgEditCuenta
        '
        Me.AcceptButton = Me.cmdAceptar
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancelar
        Me.ClientSize = New System.Drawing.Size(567, 421)
        Me.Controls.Add(Me.cmdCancelar)
        Me.Controls.Add(Me.cmdAceptar)
        Me.Controls.Add(Me.tabCuentaRol)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.HelpProvider.SetHelpKeyword(Me, "Mantenimiento de Usuarios")
        Me.HelpProvider.SetHelpNavigator(Me, System.Windows.Forms.HelpNavigator.KeywordIndex)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FrmSsgEditCuenta"
        Me.HelpProvider.SetShowHelp(Me, True)
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmEditCuenta"
        CType(Me.tabCuentaRol, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabCuentaRol.ResumeLayout(False)
        Me.C1DockingTabPage1.ResumeLayout(False)
        Me.grpDatosCuenta.ResumeLayout(False)
        Me.grpDatosCuenta.PerformLayout()
        CType(Me.cdeFechaExpiracion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cdeFechaCreacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.grpDatosEmpleado.ResumeLayout(False)
        Me.grpDatosEmpleado.PerformLayout()
        CType(Me.cboDelegacion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.cboEmpleado, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tabPRoles.ResumeLayout(False)
        Me.grpConcesionRoles.ResumeLayout(False)
        Me.grpConcesionRoles.PerformLayout()
        CType(Me.cboUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.grdRoles, System.ComponentModel.ISupportInitialize).EndInit()
        Me.C1DockingTabPage2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents tabCuentaRol As C1.Win.C1Command.C1DockingTab
    Friend WithEvents C1DockingTabPage1 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grpDatosCuenta As System.Windows.Forms.GroupBox
    Friend WithEvents LblClave As System.Windows.Forms.Label
    Friend WithEvents lblNombre As System.Windows.Forms.Label
    Friend WithEvents txtLogin As System.Windows.Forms.TextBox
    Friend WithEvents grpDatosEmpleado As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tabPRoles As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents grdRoles As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboEmpleado As C1.Win.C1List.C1Combo
    Friend WithEvents txtNombreEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtFechaFinEmp As System.Windows.Forms.TextBox
    Friend WithEvents txtFechaInicioEmp As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents lblFechaInicia As System.Windows.Forms.Label
    Friend WithEvents cdeFechaCreacion As C1.Win.C1Input.C1DateEdit
    Friend WithEvents cdeFechaExpiracion As C1.Win.C1Input.C1DateEdit
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkActivo As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancelar As System.Windows.Forms.Button
    Friend WithEvents cmdAceptar As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtConfirmacion As System.Windows.Forms.TextBox
    Friend WithEvents chkActivoEmpleado As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtCedula As System.Windows.Forms.TextBox
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents lblDelegacion As System.Windows.Forms.Label
    Friend WithEvents cboDelegacion As C1.Win.C1List.C1Combo
    Friend WithEvents txtPaswordAnterior As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents HelpProvider As System.Windows.Forms.HelpProvider
    Friend WithEvents C1DockingTabPage2 As C1.Win.C1Command.C1DockingTabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents trvAccionesPosibles As System.Windows.Forms.TreeView
    Friend WithEvents btnDesmarcarTodo As System.Windows.Forms.Button
    Friend WithEvents btnMarcarTodo As System.Windows.Forms.Button
    Friend WithEvents grpConcesionRoles As System.Windows.Forms.GroupBox
    Friend WithEvents rdoConceder As System.Windows.Forms.RadioButton
    Friend WithEvents rdoDenegar As System.Windows.Forms.RadioButton
    Friend WithEvents txtLoginOfTransfer As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents cboUsuarios As C1.Win.C1List.C1Combo
    Friend WithEvents cmdRolesxAcción As System.Windows.Forms.Button
    Friend WithEvents cmdAccionesUsuario As System.Windows.Forms.Button
    Friend WithEvents BtnMarcarTodoRoles As System.Windows.Forms.Button
    Friend WithEvents BtnDesMarcarTodoRoles As System.Windows.Forms.Button
    Friend WithEvents lblBloqueada As System.Windows.Forms.Label
    Friend WithEvents btnDesbloquear As System.Windows.Forms.Button
End Class
