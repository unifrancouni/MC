' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                28/07/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditCatalogoContable.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo Contable.
'-------------------------------------------------------------------------
Public Class frmScnEditCatalogoContable

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdScnCatContable As Integer
    Dim IdScnCatContablePadre As Integer
    Dim intScnEstructuraContableID As Integer
    Dim intScnFuenteFinanciamientoID As Integer = 0

    '-- Clases para procesar la informacion de los combos
    Dim XdsCatContable As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjCatContabledt As BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
    Dim ObjCatContabledr As BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de Doc. Soporte.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Catálogo Contable que corresponde al campo
    'nScnCatalogoContableID de la tabla ScnCatalogoContable.
    Public Property IdCatContable() As Integer
        Get
            IdCatContable = IdScnCatContable
        End Get
        Set(ByVal value As Integer)
            IdScnCatContable = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Catálogo Contable que corresponde al campo
    'nScnCatalogoContableID de la tabla ScnCatalogoContable.
    Public Property IdCatContablePadre() As Integer
        Get
            IdCatContablePadre = IdScnCatContablePadre
        End Get
        Set(ByVal value As Integer)
            IdScnCatContablePadre = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmScnEditEstructuraContable_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCatalogoContable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjCatContabledt.Close()
                ObjCatContabledt = Nothing

                ObjCatContabledr.Close()
                ObjCatContabledr = Nothing

                XdsCatContable.Close()
                XdsCatContable = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmScnEditCatalogoContable_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Doc. Soporte en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditCatalogoContable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarFteFinanciamiento(0)
            CargarCtaBancaria(0)

            If intScnFuenteFinanciamientoID > 0 Then
                If Me.cboFteFinanciamiento.ListCount > 0 Then
                    Me.cboFteFinanciamiento.SelectedIndex = 0
                End If
                XdsCatContable("FteFinanciamiento").SetCurrentByID("nScnFuenteFinanciamientoID", intScnFuenteFinanciamientoID)
                Me.cboFteFinanciamiento.Enabled = False
            End If

            'Si el formulario está en modo edición
            'cargar los datos del Doc. Soporte.
            If ModoFrm = "UPD" Then
                CargarCatContable()
                ObtenerSiModifica()
            End If

            Me.txtCodigoCuenta.Select()

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub ObtenerSiModifica()
        Dim ObjTmpCatContable As New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
        Try
            ObjTmpCatContable.Filter = " nCuentaPadreID = " & Me.IdCatContable

            ObjTmpCatContable.Retrieve()

            If ObjTmpCatContable.Count > 0 Then
                Me.txtCodigoCuenta.Enabled = False
                Me.txtNombreCuenta.Enabled = True
                Me.cboFteFinanciamiento.Enabled = False
                Me.radDebe.Enabled = False
                Me.radHaber.Enabled = False
                Me.radBalance.Enabled = False
                Me.radIngresos.Enabled = False
                Me.radEgresos.Enabled = False
                Me.chkDetalle.Enabled = False
                Me.cboCtaBancaria.Enabled = False
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpCatContable.Close()
            ObjTmpCatContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            Dim nNivelPadre As Integer

            If ModoFrm = "ADD" Then
                Me.radDebe.Checked = True
                Me.radBalance.Checked = True

                Me.Text = "Agregar Cuenta del Catálogo Contable"
                If Me.IdCatContablePadre = 0 Then
                    Me.txtNivelCuenta.Text = 1
                    Me.chkDetalle.Enabled = False
                    Me.cboCtaBancaria.Enabled = False

                    strSQL = " SELECT nScnEstructuraContableID,nDigitosNivel FROM ScnEstructuraContable " & _
                             " WHERE nNivel = 1"

                    XdtDatos.ExecuteSql(strSQL)

                    If XdtDatos.Count > 0 Then
                        Me.txtDigitosNivel.Text = XdtDatos.ValueField("nDigitosNivel")
                        intScnEstructuraContableID = XdtDatos.ValueField("nScnEstructuraContableID")
                    End If
                ElseIf Me.IdCatContablePadre > 0 Then
                    Me.chkDetalle.Enabled = True
                    Me.cboCtaBancaria.Enabled = False

                    strSQL = " SELECT a.nScnEstructuraContableID,a.nDigitosNivel,a.nNivel,b.sCodigoCuenta,b.nScnFuenteFinanciamientoID,b.sTipoCuenta,b.nCuentaDeudora " & _
                             " FROM ScnEstructuraContable a INNER JOIN ScnCatalogoContable b " & _
                             " ON a.nScnEstructuraContableID = b.nScnEstructuraContableID " & _
                             " WHERE b.nScnCatalogoContableID = " & Me.IdCatContablePadre

                    XdtDatos.ExecuteSql(strSQL)

                    If XdtDatos.Count > 0 Then
                        nNivelPadre = XdtDatos.ValueField("nNivel")
                        intScnFuenteFinanciamientoID = XdtDatos.ValueField("nScnFuenteFinanciamientoID")
                        Me.txtCodCuentaPadre.Text = XdtDatos.ValueField("sCodigoCuenta")

                        'Tipo de Cuenta
                        If Not XdtDatos.ValueField("nCuentaDeudora") Is DBNull.Value Then
                            If XdtDatos.ValueField("nCuentaDeudora") = 1 Then
                                Me.radDebe.Checked = True
                                Me.radHaber.Checked = False
                            Else
                                Me.radDebe.Checked = False
                                Me.radHaber.Checked = True
                            End If
                        End If

                        'Clase de Cuenta
                        If Not XdtDatos.ValueField("sTipoCuenta") Is DBNull.Value Then
                            If XdtDatos.ValueField("sTipoCuenta") = "B" Then
                                Me.radBalance.Checked = True
                                Me.radIngresos.Checked = False
                                Me.radEgresos.Checked = False
                                Me.radOrden.Checked = False
                            ElseIf XdtDatos.ValueField("sTipoCuenta") = "I" Then
                                Me.radBalance.Checked = False
                                Me.radIngresos.Checked = True
                                Me.radEgresos.Checked = False
                                Me.radOrden.Checked = False
                            ElseIf XdtDatos.ValueField("sTipoCuenta") = "E" Then
                                Me.radBalance.Checked = False
                                Me.radIngresos.Checked = False
                                Me.radEgresos.Checked = True
                                Me.radOrden.Checked = False
                            ElseIf XdtDatos.ValueField("sTipoCuenta") = "O" Then
                                Me.radBalance.Checked = False
                                Me.radIngresos.Checked = False
                                Me.radEgresos.Checked = False
                                Me.radOrden.Checked = True

                            End If
                        End If

                        Me.cboFteFinanciamiento.Enabled = False
                        Me.radBalance.Enabled = False
                        Me.radIngresos.Enabled = False
                        Me.radEgresos.Enabled = False
                        Me.radDebe.Enabled = False
                        Me.radHaber.Enabled = False

                        strSQL = " SELECT nScnEstructuraContableID,nDigitosNivel,nNivel FROM ScnEstructuraContable " & _
                                 " WHERE nNivel = " & nNivelPadre + 1

                        XdtDatos.ExecuteSql(strSQL)

                        If XdtDatos.Count > 0 Then
                            Me.txtNivelCuenta.Text = XdtDatos.ValueField("nNivel")
                            Me.txtDigitosNivel.Text = XdtDatos.ValueField("nDigitosNivel")
                            intScnEstructuraContableID = XdtDatos.ValueField("nScnEstructuraContableID")
                        End If
                    End If

                End If
            Else
                Me.Text = "Modificar Cuenta del Catálogo Contable"

                Me.cboFteFinanciamiento.Enabled = False
                Me.radBalance.Enabled = False
                Me.radIngresos.Enabled = False
                Me.radEgresos.Enabled = False
                Me.radDebe.Enabled = False
                Me.radHaber.Enabled = False
            End If

            ObjCatContabledt = New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
            ObjCatContabledr = New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableRow

            XdsCatContable = New BOSistema.Win.XDataSet

            If ModoFrm = "ADD" Then

                ObjCatContabledr = ObjCatContabledt.NewRow

                'Inicializar los Length de los campos
                Me.txtNombreCuenta.MaxLength = ObjCatContabledr.GetColumnLenght("sNombreCuenta")
                Me.txtCodigoCuenta.MaxLength = Int(Me.txtDigitosNivel.Text)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarEstructura
    ' Descripción:          Este procedimiento permite cargar los datos del Doc. Soporte
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCatContable()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Doc. Soporte corerspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjCatContabledt.Filter = "nScnCatalogoContableID = " & Me.IdScnCatContable
            ObjCatContabledt.Retrieve()

            If ObjCatContabledt.Count = 0 Then
                Exit Sub
            End If
            ObjCatContabledr = ObjCatContabledt.Current

            'Nivel 
            strSQL = " SELECT right(b.sCodigoCuenta,a.nDigitosNivel) as sCodCuenta,b.sCodigoCuenta,a.nScnEstructuraContableID,a.nDigitosNivel,a.nNivel " & _
                     " FROM ScnEstructuraContable a INNER JOIN ScnCatalogoContable b " & _
                     " ON a.nScnEstructuraContableID = b.nScnEstructuraContableID " & _
                     " WHERE b.nScnCatalogoContableID = " & Me.IdCatContable

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                Me.txtCodCuentaPadre.Text = Mid(XdtDatos.ValueField("sCodigoCuenta"), 1, Len(XdtDatos.ValueField("sCodigoCuenta")) - XdtDatos.ValueField("nDigitosNivel") - 1)
                Me.txtCodigoCuenta.Text = XdtDatos.ValueField("sCodCuenta")
                Me.txtNivelCuenta.Text = XdtDatos.ValueField("nNivel")
                Me.txtDigitosNivel.Text = XdtDatos.ValueField("nDigitosNivel")
                intScnEstructuraContableID = XdtDatos.ValueField("nScnEstructuraContableID")

                If XdtDatos.ValueField("nNivel") = 1 Then
                    Me.chkDetalle.Enabled = False
                    Me.cboCtaBancaria.Enabled = False

                    strSQL = " SELECT nScnCatalogoContableID FROM ScnCatalogoContable " & _
                             " WHERE nCuentaPadreID = " & Me.IdCatContable

                    XdtDatos.ExecuteSql(strSQL)

                    If XdtDatos.Count = 0 Then
                        Me.cboFteFinanciamiento.Enabled = True
                        Me.radBalance.Enabled = True
                        Me.radIngresos.Enabled = True
                        Me.radEgresos.Enabled = True
                        Me.radDebe.Enabled = True
                        Me.radHaber.Enabled = True
                    End If
                End If
            End If

            'Nombre de la Cuenta
            If Not ObjCatContabledr.IsFieldNull("sNombreCuenta") Then
                Me.txtNombreCuenta.Text = ObjCatContabledr.sNombreCuenta
            Else
                Me.txtNombreCuenta.Text = ""
            End If

            'Fuente de Financiamiento
            If Not ObjCatContabledr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFteFinanciamiento(ObjCatContabledr.nScnFuenteFinanciamientoID)
                If Me.cboFteFinanciamiento.ListCount > 0 Then
                    Me.cboFteFinanciamiento.SelectedIndex = 0
                End If
                XdsCatContable("FteFinanciamiento").SetCurrentByID("nScnFuenteFinanciamientoID", ObjCatContabledr.nScnFuenteFinanciamientoID)
            Else
                Me.cboFteFinanciamiento.Text = ""
                Me.cboFteFinanciamiento.SelectedIndex = -1
            End If

            'Cuenta Bancaria
            If Not ObjCatContabledr.IsFieldNull("nSteCuentaBancariaID") Then
                CargarCtaBancaria(ObjCatContabledr.nSteCuentaBancariaID)
                If Me.cboCtaBancaria.ListCount > 0 Then
                    Me.cboCtaBancaria.SelectedIndex = 0
                End If
                XdsCatContable("CtaBancaria").SetCurrentByID("nSteCuentaBancariaID", ObjCatContabledr.nSteCuentaBancariaID)
            Else
                Me.cboCtaBancaria.Text = ""
                Me.cboCtaBancaria.SelectedIndex = -1
            End If

            'Tipo de Cuenta
            If Not ObjCatContabledr.IsFieldNull("nCuentaDeudora") Then
                If ObjCatContabledr.nCuentaDeudora = 1 Then
                    Me.radDebe.Checked = True
                    Me.radHaber.Checked = False
                Else
                    Me.radDebe.Checked = False
                    Me.radHaber.Checked = True
                End If
            End If

            'Clase de Cuenta
            If Not ObjCatContabledr.IsFieldNull("sTipoCuenta") Then
                If ObjCatContabledr.sTipoCuenta = "B" Then
                    Me.radBalance.Checked = True
                    Me.radIngresos.Checked = False
                    Me.radEgresos.Checked = False
                    Me.radOrden.Checked = False
                ElseIf ObjCatContabledr.sTipoCuenta = "I" Then
                    Me.radBalance.Checked = False
                    Me.radIngresos.Checked = True
                    Me.radEgresos.Checked = False
                    Me.radOrden.Checked = False
                ElseIf ObjCatContabledr.sTipoCuenta = "E" Then
                    Me.radBalance.Checked = False
                    Me.radIngresos.Checked = False
                    Me.radEgresos.Checked = True
                    Me.radOrden.Checked = False
                ElseIf ObjCatContabledr.sTipoCuenta = "O" Then
                    Me.radBalance.Checked = False
                    Me.radIngresos.Checked = False
                    Me.radEgresos.Checked = False
                    Me.radOrden.Checked = True
                End If
            End If

            'Cuenta de Detalle
            If Not ObjCatContabledr.IsFieldNull("nCuentaDetalle") Then
                If ObjCatContabledr.nCuentaDetalle = 1 Then
                    Me.chkDetalle.Checked = True
                    Me.cboCtaBancaria.Enabled = True
                Else
                    Me.chkDetalle.Checked = False
                    Me.cboCtaBancaria.Enabled = False
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtNombreCuenta.MaxLength = ObjCatContabledr.GetColumnLenght("sNombreCuenta")
            Me.txtCodigoCuenta.MaxLength = Int(Me.txtDigitosNivel.Text)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarFteFinanciamiento(ByVal intFteFinanciamientoID As Integer)
        Try
            Dim Strsql As String

            If intFteFinanciamientoID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID,a.sCodigo,a.sNombre as sDescripcion " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where a.nActiva = 1" & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID,a.sCodigo,a.sNombre as sDescripcion " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) or a.nScnFuenteFinanciamientoID = " & intFteFinanciamientoID & _
                         " Order by a.sCodigo"
            End If

            If XdsCatContable.ExistTable("FteFinanciamiento") Then
                XdsCatContable("FteFinanciamiento").ExecuteSql(Strsql)
            Else
                XdsCatContable.NewTable(Strsql, "FteFinanciamiento")
                XdsCatContable("FteFinanciamiento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboFteFinanciamiento.DataSource = XdsCatContable("FteFinanciamiento").Source

            Me.cboFteFinanciamiento.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            Me.cboFteFinanciamiento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFteFinanciamiento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboFteFinanciamiento.Splits(0).DisplayColumns("sDescripcion").Width = 80

            Me.cboFteFinanciamiento.Columns("sCodigo").Caption = "Código"
            Me.cboFteFinanciamiento.Columns("sDescripcion").Caption = "Descripción"

            Me.cboFteFinanciamiento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFteFinanciamiento.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCtaBancaria(ByVal intCtaBancariaID As Integer)
        Try
            Dim Strsql As String

            If intCtaBancariaID = 0 Then
                Strsql = " Select a.nSteCuentaBancariaID,a.sNumeroCuenta,a.sNombreCuenta as sDescripcion " & _
                         " From SteCuentaBancaria a " & _
                         " Where a.nCerrada = 0 " & _
                         " Order by a.sNumeroCuenta"
            Else
                Strsql = " Select a.nSteCuentaBancariaID,a.sNumeroCuenta,a.sNombreCuenta as sDescripcion " & _
                         " From SteCuentaBancaria a " & _
                         " Where (a.nCerrada = 0 ) or a.nSteCuentaBancariaID = " & intCtaBancariaID & _
                         " Order by a.sNumeroCuenta"
            End If

            If XdsCatContable.ExistTable("CtaBancaria") Then
                XdsCatContable("CtaBancaria").ExecuteSql(Strsql)
            Else
                XdsCatContable.NewTable(Strsql, "CtaBancaria")
                XdsCatContable("CtaBancaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCtaBancaria.DataSource = XdsCatContable("CtaBancaria").Source

            Me.cboCtaBancaria.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            Me.cboCtaBancaria.Splits(0).DisplayColumns("sNumeroCuenta").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboCtaBancaria.Splits(0).DisplayColumns("sNumeroCuenta").Width = 100
            Me.cboCtaBancaria.Splits(0).DisplayColumns("sDescripcion").Width = 80

            Me.cboCtaBancaria.Columns("sNumeroCuenta").Caption = "Número"
            Me.cboCtaBancaria.Columns("sDescripcion").Caption = "Nombre"

            Me.cboCtaBancaria.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCtaBancaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCatContable()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpCatContable As New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strCodCuenta As String
            Dim strSQL As String = ""

            ValidaDatosEntrada = True
            Me.errCatContable.Clear()

            'Código de Cuenta
            If Trim(RTrim(Me.txtCodigoCuenta.Text)).ToString.Length = 0 Then
                MsgBox("El Código de la Cuenta NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCatContable.SetError(Me.txtCodigoCuenta, "El Código de la Cuenta NO DEBE quedar vacío.")
                Me.txtCodigoCuenta.Focus()
                Exit Function
            End If

            'Nombre de Cuenta
            If Trim(RTrim(Me.txtNombreCuenta.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre de la Cuenta NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCatContable.SetError(Me.txtNombreCuenta, "El Nombre de la Cuenta NO DEBE quedar vacío.")
                Me.txtNombreCuenta.Focus()
                Exit Function
            End If

            'Fuente de Financiamiento
            If Me.cboFteFinanciamiento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Fuente de Financiamiento válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCatContable.SetError(Me.cboFteFinanciamiento, "Debe seleccionar una Fuente de Financiamiento válida.")
                Me.cboFteFinanciamiento.Focus()
                Exit Function
            End If

            'Cuenta Contable
            strCodCuenta = LTrim(RTrim(Me.txtCodCuentaPadre.Text)) + "-" + StrDup(CInt(Me.txtDigitosNivel.Text) - Len(LTrim(RTrim(Me.txtCodigoCuenta.Text))), "0") + LTrim(RTrim(Me.txtCodigoCuenta.Text))

            'Determinar duplicados en el Código de la Cuenta
            If ModoFrm = "UPD" Then
                ObjTmpCatContable.Filter = " sCodigoCuenta = '" & strCodCuenta & "'" & " And nScnCatalogoContableID <> " & Me.IdScnCatContable
            Else
                ObjTmpCatContable.Filter = " sCodigoCuenta = '" & strCodCuenta & "'"
            End If

            ObjTmpCatContable.Retrieve()

            If ObjTmpCatContable.Count > 0 Then
                MsgBox("El Código de la Cuenta NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCatContable.SetError(Me.txtCodigoCuenta, "El Código de la Cuenta NO DEBE repetirse. ")
                Me.txtCodigoCuenta.SelectAll()
                Me.txtCodigoCuenta.Focus()
                Exit Function
            End If

            'Determinar duplicados en la Descripción de la Cuenta
            If ModoFrm = "UPD" Then
                ObjTmpCatContable.Filter = " sNombreCuenta = '" & Me.txtNombreCuenta.Text & "' And nScnFuenteFinanciamientoID = " & XdsCatContable("FteFinanciamiento").ValueField("nScnFuenteFinanciamientoID") & " And nScnCatalogoContableID <> " & Me.IdScnCatContable
            Else
                ObjTmpCatContable.Filter = " sNombreCuenta = '" & Me.txtNombreCuenta.Text & "' And nScnFuenteFinanciamientoID = " & XdsCatContable("FteFinanciamiento").ValueField("nScnFuenteFinanciamientoID")
            End If

            ObjTmpCatContable.Retrieve()

            If ObjTmpCatContable.Count > 0 Then
                MsgBox("La Descripción de la Cuenta NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCatContable.SetError(Me.txtNombreCuenta, "La Descripción de la Cuenta NO DEBE repetirse. ")
                Me.txtNombreCuenta.SelectAll()
                Me.txtNombreCuenta.Focus()
                Exit Function
            End If

            If ModoFrm = "UPD" And Me.chkDetalle.Checked = True Then
                ObjTmpCatContable.Filter = " nCuentaPadreID = " & Me.IdCatContable

                ObjTmpCatContable.Retrieve()

                If ObjTmpCatContable.Count > 0 Then
                    MsgBox("Imposible actualizar a Cuenta Detalle." & Chr(10) & _
                            "Existen Cuentas Hijas registradas.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCatContable.SetError(Me.chkDetalle, "Imposible actualizar a Cuenta Detalle." & Chr(10) & _
                            "Existen Cuentas Hijas registradas.")
                    Me.chkDetalle.Focus()
                    Exit Function
                End If
            End If

            'Imposible cambiar de cuenta bancaria a No Bancaria si ya hay transacciones Contables
            If ModoFrm = "UPD" And Not ObjCatContabledr.IsFieldNull("nSteCuentaBancariaID") Then
                If Me.cboCtaBancaria.SelectedIndex = -1 Then
                    strSQL = " SELECT nScnTransaccionContableDetalleID FROM ScnTransaccionContableDetalle " & _
                             " WHERE nScnCatalogoContableID = " & Me.IdCatContable

                    XdtDatos.ExecuteSql(strSQL)
                    If XdtDatos.Count > 0 Then
                        MsgBox("Imposible quitar la relación con la Cuenta Bancaria." & Chr(10) & _
                                "Existen Transacciones Contables asociadas a la Cuenta Contable.", MsgBoxStyle.Critical, "SMUSURA0")
                        ValidaDatosEntrada = False
                        Me.errCatContable.SetError(Me.cboCtaBancaria, "Imposible quitar la relación con la Cuenta Bancaria." & Chr(10) & _
                                "Existen Transacciones Contables asociadas a la Cuenta Contable.")
                        Me.cboCtaBancaria.Focus()
                        Exit Function
                    End If
                End If
            End If

            'Imposible cambiar una cuenta a No Detalle
            If ModoFrm = "UPD" And Me.chkDetalle.Checked = False Then

                strSQL = " SELECT nScnTransaccionContableDetalleID FROM ScnTransaccionContableDetalle " & _
                         " WHERE nScnCatalogoContableID = " & Me.IdCatContable

                XdtDatos.ExecuteSql(strSQL)
                If XdtDatos.Count > 0 Then
                    MsgBox("Imposible cambiar la cuenta a No Detalle." & Chr(10) & _
                            "Existen Transacciones Contables asociadas a la Cuenta Contable.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errCatContable.SetError(Me.cboCtaBancaria, "Imposible cambiar la Cuenta a No Detalle." & Chr(10) & _
                            "Existen Transacciones Contables asociadas a la Cuenta Contable.")
                    Me.cboCtaBancaria.Focus()
                    Exit Function
                End If

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjTmpCatContable.Close()
            ObjTmpCatContable = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       SalvarCargo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Cargo en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCatContable()
        Try
            Dim strSQL As String = ""

            If ModoFrm = "ADD" Then
                ObjCatContabledr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCatContabledr.dFechaCreacion = FechaServer()
                ObjCatContabledr.nSaldoInicialC = 0
                ObjCatContabledr.nSaldoInicialD = 0

                'Cuenta Padre
                If Me.IdCatContablePadre > 0 Then
                    ObjCatContabledr.nCuentaPadreID = Me.IdCatContablePadre
                Else
                    ObjCatContabledr.SetFieldNull("nCuentaPadreID")
                End If
            Else
                ObjCatContabledr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCatContabledr.dFechaModificacion = FechaServer()
            End If

            'Tipo de Cuenta (Cuenta Deudora)
            If Me.radDebe.Checked = True Then
                ObjCatContabledr.nCuentaDeudora = 1
            ElseIf Me.radDebe.Checked = False Then
                ObjCatContabledr.nCuentaDeudora = 0
            End If

            'Clase de Cuenta (Balance->B, Egresos->E, Ingresos->I)
            If Me.radBalance.Checked = True Then
                ObjCatContabledr.sTipoCuenta = "B"
            ElseIf Me.radIngresos.Checked = True Then
                ObjCatContabledr.sTipoCuenta = "I"
            ElseIf Me.radEgresos.Checked = True Then
                ObjCatContabledr.sTipoCuenta = "E"
            ElseIf Me.radOrden.Checked = True Then
                ObjCatContabledr.sTipoCuenta = "O"
            End If

            'Cuenta de Detalle
            If Me.chkDetalle.Checked = True Then
                ObjCatContabledr.nCuentaDetalle = 1
            ElseIf Me.chkDetalle.Checked = False Then
                ObjCatContabledr.nCuentaDetalle = 0
            End If

            ObjCatContabledr.sNombreCuenta = Me.txtNombreCuenta.Text

            ObjCatContabledr.nScnFuenteFinanciamientoID = XdsCatContable("FteFinanciamiento").ValueField("nScnFuenteFinanciamientoID")
            ObjCatContabledr.nPermiteSobregiro = 0
            ObjCatContabledr.nScnEstructuraContableID = intScnEstructuraContableID

            'Cuenta Bancaria
            If Me.cboCtaBancaria.SelectedIndex <> -1 Then
                ObjCatContabledr.nSteCuentaBancariaID = XdsCatContable("CtaBancaria").ValueField("nSteCuentaBancariaID")
            Else
                ObjCatContabledr.SetFieldNull("nSteCuentaBancariaID")
            End If

            'Código de la Cuenta
            ObjCatContabledr.sCodigoCuenta = LTrim(RTrim(Me.txtCodCuentaPadre.Text)) + "-" + StrDup(CInt(Me.txtDigitosNivel.Text) - Len(LTrim(RTrim(Me.txtCodigoCuenta.Text))), "0") + LTrim(RTrim(Me.txtCodigoCuenta.Text))
            'ltrim(rtrim(strdup('0', @nLimite - len(@CodSIAFI)) + @CodSIAFI))
            ObjCatContabledr.Update()

            'Asignar el Id del Nivel a la 
            'variable publica del formulario
            Me.IdScnCatContable = ObjCatContabledr.nScnCatalogoContableID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Call GuardarAuditoria(2, 24, "Modificación de Cuenta Contable Id.:" & Me.IdScnCatContable & ".")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If vbModifico = True Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarCatContable()
                            AccionUsuario = AccionBoton.BotonAceptar
                            Me.Close()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case vbNo
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.Close()

                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permite Letras A - Z, número 0-9, BackSpace y la Barra espaciadora
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombreCuenta.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "/" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "." Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en la Descripción del Documento Soporte
    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombreCuenta.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFteFinanciamiento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFteFinanciamiento.TextChanged
        If Me.cboFteFinanciamiento.ListCount > 0 And Me.IdCatContablePadre = 0 And Me.ModoFrm = "ADD" Then
            Me.txtCodCuentaPadre.Text = XdsCatContable("FteFinanciamiento").ValueField("sCodigo")
        End If
        vbModifico = True
    End Sub

    Private Sub txtCodigoCuenta_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoCuenta.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtCodigoCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigoCuenta.TextChanged
        vbModifico = True
    End Sub

    Private Sub radHaber_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radHaber.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub radDebe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDebe.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub radBalance_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radBalance.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub radIngresos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radIngresos.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub radEgresos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radEgresos.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub cboCtaBancaria_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCtaBancaria.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDetalle.CheckedChanged
        If Me.chkDetalle.Checked = True Then
            Me.cboCtaBancaria.Enabled = True
        Else
            Me.cboCtaBancaria.Enabled = False
            Me.cboCtaBancaria.SelectedIndex = -1
        End If
        vbModifico = True
    End Sub

    Private Sub chkDetalle_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDetalle.GotFocus
        Try
            Me.chkDetalle.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkDetalle_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDetalle.LostFocus
        Try
            Me.chkDetalle.BackColor = Me.grpCuentaDetalle.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class