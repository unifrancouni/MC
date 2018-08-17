Public Class frmSrhEditProveedorTransaccionParametro

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdScnParametro As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdtFuente As BOSistema.Win.XDataSet.xDataTable
    Dim XdtCuenta As BOSistema.Win.XDataSet.xDataTable
    Dim XdsDocumento As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjParametrodt As BOSistema.Win.SteEntProveedor.SrhProveedorTransaccionParametroDataTable
    Dim ObjParametrodr As BOSistema.Win.SteEntProveedor.SrhProveedorTransaccionParametroRow



    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdParametro() As Integer
        Get
            IdParametro = IdScnParametro
        End Get
        Set(ByVal value As Integer)
            IdScnParametro = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       frmScnEditParametrosContables_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditParametrosContables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjParametrodt.Close()
                ObjParametrodt = Nothing

                ObjParametrodr.Close()
                ObjParametrodr = Nothing

                XdtFuente.Close()
                XdtFuente = Nothing

                XdsDocumento.Close()
                XdsDocumento = Nothing
                XdtCuenta.Close()
                XdtCuenta = Nothing

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Parámetro Contable"
            Else
                Me.Text = "Modificar Parámetro Contable"
            End If

            XdtFuente = New BOSistema.Win.XDataSet.xDataTable
            XdtCuenta = New BOSistema.Win.XDataSet.xDataTable
            XdsDocumento = New BOSistema.Win.XDataSet

            ObjParametrodt = New BOSistema.Win.SteEntProveedor.SrhProveedorTransaccionParametroDataTable
            ObjParametrodr = New BOSistema.Win.SteEntProveedor.SrhProveedorTransaccionParametroRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboCuenta.ClearFields()
            Me.cboProveedor.ClearFields()
            Me.cboTipoRenglon.ClearFields()

            If ModoFrm = "ADD" Then
                ObjParametrodr = ObjParametrodt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       CargarParametro
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarParametro()
        Try

            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjParametrodt.Filter = "nSrhProveedorTransaccionParametroID = " & IdParametro
            ObjParametrodt.Retrieve()
            If ObjParametrodt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjParametrodr = ObjParametrodt.Current 'Socia actual.

            'Fuente de Financiamiento:
            If Not ObjParametrodr.IsFieldNull("nScnFuenteFinanciamientoID") Then
                CargarFuente(ObjParametrodr.nScnFuenteFinanciamientoID)
                If cboFuente.ListCount > 0 Then
                    Me.cboFuente.SelectedIndex = 0
                End If
                XdtFuente.SetCurrentByID("nScnFuenteFinanciamientoID", ObjParametrodr.nScnFuenteFinanciamientoID)
            Else
                Me.cboFuente.Text = ""
                Me.cboFuente.SelectedIndex = -1
            End If

            'Cuenta Contable:
            If Not ObjParametrodr.IsFieldNull("nScnCatalogoContableID") Then
                CargarCuenta(0, ObjParametrodr.nScnCatalogoContableID)
                If XdtCuenta.Count > 0 Then
                    Me.cboCuenta.SelectedIndex = 0
                End If
                XdtCuenta.SetCurrentByID("nScnCatalogoContableID", ObjParametrodr.nScnCatalogoContableID)
            Else
                Me.cboCuenta.Text = ""
                Me.cboCuenta.SelectedIndex = -1
            End If

            'Cargar Combo de Tipo de Documento:
            If Not ObjParametrodr.IsFieldNull("nStbPersonaID") Then
                CargarProveedor()
                If XdsDocumento("Proveedor").Count > 0 Then
                    Me.cboProveedor.SelectedIndex = 0
                End If
                XdsDocumento("Proveedor").SetCurrentByID("nStbPersonaID", ObjParametrodr.nStbPersonaID)
            Else 'Estado civil esta en Null.
                Me.cboProveedor.Text = ""
                Me.cboProveedor.SelectedIndex = -1
            End If

            'Cargar Combo de Tipo de Renglón:
            If Not ObjParametrodr.IsFieldNull("nStbTipoRenglonID") Then
                CargarTipoRenglon()
                If XdsDocumento("TipoRenglon").Count > 0 Then
                    Me.cboTipoRenglon.SelectedIndex = 0
                End If
                XdsDocumento("TipoRenglon").SetCurrentByID("nStbTipoRenglonID", ObjParametrodr.nStbTipoRenglonID)
            Else
                Me.cboTipoRenglon.Text = ""
                Me.cboTipoRenglon.SelectedIndex = -1
            End If

            'Cargar Tipo Movimiento:
            If Not ObjParametrodr.IsFieldNull("nDebito") Then
                Me.chkDebe.Checked = ObjParametrodr.nDebito
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarParametro()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try

            ValidaDatosEntrada = True
            Me.errParametro.Clear()

            'Fuente de Fondos:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Fuente de Fondos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboFuente, "Debe seleccionar Fuente de Fondos.")
                Me.cboFuente.Focus()
                Exit Function
            End If

            'Cuenta Contable:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Cuenta Contable.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboCuenta, "Debe seleccionar Cuenta Contable.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'La Cuenta DEBE ser de Detalle (excepto Patrimonio):
            'If cboTipoRenglon.Columns("sCodigoInterno").Value <> "10" Then
            If Me.cboCuenta.Columns("nCuentaDetalle").Value = 0 Then
                MsgBox("Debe seleccionar una Cuenta Detalle.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta Detalle.")
                Me.cboCuenta.Focus()
                Exit Function
            End If
            'End If

            'Tipo de Documento:
            If Me.cboProveedor.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Proveedor.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboProveedor, "Debe seleccionar Proveedor.")
                Me.cboProveedor.Focus()
                Exit Function
            End If

            'Tipo de Afectación:
            If Me.cboTipoRenglon.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Tipo de Renglón.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboTipoRenglon, "Debe seleccionar Tipo de Renglón.")
                Me.cboTipoRenglon.Focus()
                Exit Function
            End If

            'Encontrar Duplicados:
            Dim StrSql As String = "SELECT * FROM SrhProveedorTransaccionParametro " & _
                     "WHERE (nSrhProveedorTransaccionParametroID <> " & Me.IdScnParametro & ") AND (nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
                     "AND (nStbPersonaID = " & cboProveedor.Columns("nStbPersonaID").Value & ") AND (nStbTipoRenglonID = " & cboTipoRenglon.Columns("nStbTipoRenglonID").Value & ") AND (nDebito = " & IIf(chkDebe.Checked, 1, 0) & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El parámetro ya existe con los valores indicados.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboFuente, "El parámetro ya existe con los valores indicados.")
                Me.cboFuente.Focus()
                Exit Function
            End If
        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       SalvarParametro
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarParametro()
        Try
            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjParametrodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjParametrodr.dFechaCreacion = FechaServer()
            Else
                ObjParametrodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjParametrodr.dFechaModificacion = FechaServer()
            End If

            'Fuente de Fondos:
            ObjParametrodr.nScnFuenteFinanciamientoID = Me.cboFuente.Columns("nScnFuenteFinanciamientoID").Value
            'Cuenta Contable:
            ObjParametrodr.nScnCatalogoContableID = Me.cboCuenta.Columns("nScnCatalogoContableID").Value
            'Proveedor:
            ObjParametrodr.nStbPersonaID = Me.cboProveedor.Columns("nStbPersonaID").Value
            'Tipo de Renglón:
            ObjParametrodr.nStbTipoRenglonID = Me.cboTipoRenglon.Columns("nStbTipoRenglonID").Value
            'Debito:
            If Me.chkDebe.Checked Then
                ObjParametrodr.nDebito = 1
            Else
                ObjParametrodr.nDebito = 0
            End If

            ObjParametrodr.Update()
            'Asignar el Id de la Socia a la variable publica del formulario
            IdScnParametro = ObjParametrodr.nSrhProveedorTransaccionParametroID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                'Call GuardarAuditoria(4, 24, "Modificación de Parámetro Contable ID:" & Me.IdScnParametro & ".")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
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
                res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarParametro()
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       CargarTipoDocumento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Documentos Contables.
    '-------------------------------------------------------------------------
    Private Sub CargarProveedor()
        Try
            Dim Strsql As String = ""

            Strsql = "SELECT     dbo.StbPersona.nStbPersonaID, dbo.StbPersona.sNombre1 " & _
                     "FROM         dbo.StbPersona INNER JOIN " & _
                     "dbo.SrhProveedor ON dbo.StbPersona.nStbPersonaID = dbo.SrhProveedor.nStbPersonaID " & _
                     "WHERE(dbo.SrhProveedor.nActivo = 1)"

            If XdsDocumento.ExistTable("Proveedor") Then
                XdsDocumento("Proveedor").ExecuteSql(Strsql)
            Else
                XdsDocumento.NewTable(Strsql, "Proveedor")
                XdsDocumento("Proveedor").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboProveedor.DataSource = XdsDocumento("Proveedor").Source

            Me.cboProveedor.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            'Me.cboTipoDocumento.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            'Me.cboTipoDocumento.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            'Me.cboTipoDocumento.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboProveedor.Columns("sNombre1").Caption = "Nombre Proveedor"
            'Me.cboTipoDocumento.Columns("sDescripcion").Caption = "Descripción"

            Me.cboProveedor.Splits(0).DisplayColumns("sNombre1").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ' Me.cboTipoDocumento.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       CargarTipoAfectacion
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Afectaciones Contables.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoRenglon()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT     dbo.StbValorCatalogo.nStbValorCatalogoID as nStbTipoRenglonID, dbo.StbValorCatalogo.sDescripcion " & _
                    "FROM         dbo.StbValorCatalogo INNER JOIN " & _
                    "dbo.StbCatalogo ON dbo.StbValorCatalogo.nStbCatalogoID = dbo.StbCatalogo.nStbCatalogoID " & _
                    "WHERE     (dbo.StbCatalogo.sNombre = 'TipoTransaccionProveedores') "

            If XdsDocumento.ExistTable("TipoRenglon") Then
                XdsDocumento("TipoRenglon").ExecuteSql(Strsql)
            Else
                XdsDocumento.NewTable(Strsql, "TipoRenglon")
                XdsDocumento("TipoRenglon").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoRenglon.DataSource = XdsDocumento("TipoRenglon").Source

            Me.cboTipoRenglon.Splits(0).DisplayColumns("nStbTipoRenglonID").Visible = False
            'Me.cboTipoRenglon.Splits(0).DisplayColumns("sCodigoInterno").Visible = False

            'Me.cboTipoAfectacion.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            'Me.cboTipoAfectacion.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            'Me.cboTipoAfectacion.Splits(0).DisplayColumns("sDescripcion").Width = 100

            'Me.cboTipoAfectacion.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoRenglon.Columns("sDescripcion").Caption = "Descripción"

            'Me.cboTipoAfectacion.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoRenglon.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cuentas Contables en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCuenta(ByVal intLimpiarID As Integer, ByVal intCuentaID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboCuenta.ClearFields()

            If intLimpiarID = 0 Then
                If intCuentaID = 0 Then
                    Strsql = " SELECT a.nScnCatalogoContableID, a.sCodigoCuenta, LTRIM(a.sNombreCuenta) as sNombreCuenta, a.nCuentaDetalle, ISNULL(nSteCuentaBancariaID, 0) AS nSteCuentaBancariaID " & _
                             " FROM ScnCatalogoContable a " & _
                             " WHERE (a.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") AND nCuentaDetalle=1 " & _
                             " ORDER BY a.sCodigoCuenta"
                Else
                    Strsql = " SELECT a.nScnCatalogoContableID, a.sCodigoCuenta, LTRIM(a.sNombreCuenta) as sNombreCuenta, a.nCuentaDetalle, ISNULL(nSteCuentaBancariaID, 0) AS nSteCuentaBancariaID " & _
                             " FROM ScnCatalogoContable a " & _
                             " WHERE (a.nScnCatalogoContableID = " & intCuentaID & ") OR (a.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
                             " ORDER BY a.sCodigoCuenta"
                End If
            Else 'Limpiar Combo:
                Strsql = " SELECT a.nScnCatalogoContableID, a.sCodigoCuenta, LTRIM(a.sNombreCuenta) as sNombreCuenta, a.nCuentaDetalle, ISNULL(nSteCuentaBancariaID, 0) AS nSteCuentaBancariaID " & _
                         " FROM ScnCatalogoContable a " & _
                         " WHERE (a.nScnCatalogoContableID = 0) " & _
                         " ORDER BY a.sCodigoCuenta"
            End If

            XdtCuenta.ExecuteSql(Strsql)
            Me.cboCuenta.DataSource = XdtCuenta.Source
            Me.cboCuenta.Rebind()

            Me.cboCuenta.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("nCuentaDetalle").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            'Configurar el combo
            Me.cboCuenta.Splits(0).DisplayColumns("sCodigoCuenta").Width = 110
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").Width = 280

            Me.cboCuenta.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.cboCuenta.Columns("sNombreCuenta").Caption = "Cuenta Contable"

            Me.cboCuenta.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/11/2007
    ' Procedure Name:       CargarFuente
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuente(ByVal intFuenteID As Integer)
        Try
            Dim Strsql As String = ""

            If intFuenteID = 0 Then
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nScnFuenteFinanciamientoID, a.sCodigo, a.sNombre, a.nActiva " & _
                         " From ScnFuenteFinanciamiento a " & _
                         " Where (a.nActiva = 1) Or (a.nScnFuenteFinanciamientoID = " & intFuenteID & ") " & _
                         " Order by a.sCodigo"
            End If

            XdtFuente.ExecuteSql(Strsql)
            Me.cboFuente.DataSource = XdtFuente.Source

            Me.cboFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Width = 47
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboFuente.Columns("sCodigo").Caption = "Código"
            Me.cboFuente.Columns("sNombre").Caption = "Descripción"

            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuente.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboFuente_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFuente.Error
        Control_Error(e.Exception)
    End Sub

    'En caso de ocurrir otro tipo de error:
    Private Sub cboCuenta_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCuenta.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error:
    Private Sub cboTipoDocumento_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboProveedor.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error:
    Private Sub cboTipoAfectacion_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboTipoRenglon.Error
        Control_Error(e.Exception)
    End Sub



    'Indicar que hubo modificación
    Private Sub chkDebe_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDebe.CheckedChanged
        vbModifico = True
    End Sub

    'Para controlar la ubicación del foco en el checkbox
    Private Sub chkDebe_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDebe.GotFocus
        Try
            Me.chkDebe.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Para controlar cuando el checkbox pierde el foco
    Private Sub chkDebe_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkDebe.LostFocus
        Try
            Me.chkDebe.BackColor = Me.grpDatosGe.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboTipoAfectacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoRenglon.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        If Me.cboFuente.SelectedIndex <> -1 Then
            CargarCuenta(0, 0)
        Else
            CargarCuenta(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        vbModifico = True
        If Me.cboCuenta.SelectedIndex <> -1 Then
            txtCuenta.Text = cboCuenta.Columns("sNombreCuenta").Value
        Else
            txtCuenta.Text = ""
        End If
    End Sub

    Private Sub frmSrhEditProveedorTransaccionParametro_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFuente(0)
            CargarProveedor()
            CargarTipoRenglon()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarParametro()
            End If

            Me.cboFuente.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub cboProveedor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboProveedor.TextChanged
        vbModifico = True
    End Sub
End Class