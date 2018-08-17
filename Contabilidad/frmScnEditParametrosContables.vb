' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                03/12/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEditParametrosContables.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de parámetros contables.
'-------------------------------------------------------------------------
Public Class frmScnEditParametrosContables

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdScnParametro As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdtFuente As BOSistema.Win.XDataSet.xDataTable
    Dim XdtCuenta As BOSistema.Win.XDataSet.xDataTable
    Dim XdsDocumento As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjParametrodt As BOSistema.Win.ScnEntContabilidad.ScnTransaccionParametrosDataTable
    Dim ObjParametrodr As BOSistema.Win.ScnEntContabilidad.ScnTransaccionParametrosRow

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
    ' Procedure Name:       frmScnEditParametrosContables_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del parámetro en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmScnEditParametrosContables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFuente(0)
            CargarTipoDocumento()
            CargarTipoAfectacion()

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

            ObjParametrodt = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionParametrosDataTable
            ObjParametrodr = New BOSistema.Win.ScnEntContabilidad.ScnTransaccionParametrosRow

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboCuenta.ClearFields()
            Me.cboTipoDocumento.ClearFields()
            Me.cboTipoAfectacion.ClearFields()

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
            ObjParametrodt.Filter = "nScnTransaccionParametroID = " & IdParametro
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
            If Not ObjParametrodr.IsFieldNull("nStbTipoDocContableID") Then
                CargarTipoDocumento()
                If XdsDocumento("TipoDocumento").Count > 0 Then
                    Me.cboTipoDocumento.SelectedIndex = 0
                End If
                XdsDocumento("TipoDocumento").SetCurrentByID("nStbValorCatalogoID", ObjParametrodr.nStbTipoDocContableID)
            Else 'Estado civil esta en Null.
                Me.cboTipoDocumento.Text = ""
                Me.cboTipoDocumento.SelectedIndex = -1
            End If

            'Cargar Combo de Tipo de Afectación:
            If Not ObjParametrodr.IsFieldNull("nStbTipoAfectacionID") Then
                CargarTipoAfectacion()
                If XdsDocumento("TipoAfectacion").Count > 0 Then
                    Me.cboTipoAfectacion.SelectedIndex = 0
                End If
                XdsDocumento("TipoAfectacion").SetCurrentByID("nStbValorCatalogoID", ObjParametrodr.nStbTipoAfectacionID)
            Else
                Me.cboTipoAfectacion.Text = ""
                Me.cboTipoAfectacion.SelectedIndex = -1
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
            Dim StrSql As String

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
            If cboTipoAfectacion.Columns("sCodigoInterno").Value <> "10" Then
                If Me.cboCuenta.Columns("nCuentaDetalle").Value = 0 Then
                    MsgBox("Debe seleccionar una Cuenta Detalle.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errParametro.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta Detalle.")
                    Me.cboCuenta.Focus()
                    Exit Function
                End If
            End If

            'Tipo de Documento:
            If Me.cboTipoDocumento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Tipo de Documento.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboTipoDocumento, "Debe seleccionar Tipo de Documento.")
                Me.cboTipoDocumento.Focus()
                Exit Function
            End If

            'Tipo de Afectación:
            If Me.cboTipoAfectacion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Tipo de Afectación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboTipoAfectacion, "Debe seleccionar Tipo de Afectación.")
                Me.cboTipoAfectacion.Focus()
                Exit Function
            End If

            'Encontrar Duplicados:
            StrSql = "SELECT * FROM ScnTransaccionParametros " & _
                     "WHERE (nScnTransaccionParametroID <> " & Me.IdScnParametro & ") AND (nScnCatalogoContableID = " & cboCuenta.Columns("nScnCatalogoContableID").Value & ") AND (nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
                     "AND (nStbTipoDocContableID = " & cboTipoDocumento.Columns("nStbValorCatalogoID").Value & ") AND (nStbTipoAfectacionID = " & cboTipoAfectacion.Columns("nStbValorCatalogoID").Value & ") AND (nDebito = " & IIf(chkDebe.Checked, 1, 0) & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El parámetro ya existe con los valores indicados.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errParametro.SetError(Me.cboFuente, "El parámetro ya existe con los valores indicados.")
                Me.cboFuente.Focus()
                Exit Function
            End If

            'Si el Tipo de Afectación es Cuenta Bancaria el Tipo de Cuenta Contable debe ser de Bancos:
            If Me.cboTipoAfectacion.Columns("sCodigoInterno").Value = "5" Then
                If Me.cboCuenta.Columns("nSteCuentaBancariaID").Value = "0" Then
                    MsgBox("De acuerdo con el Tipo de Afectación la" & Chr(13) & "Cuenta Contable DEBE ser de Bancos.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errParametro.SetError(Me.cboCuenta, "Cuenta Contable DEBE ser de Bancos.")
                    Me.cboCuenta.Focus()
                    Exit Function
                End If
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
            'Tipo de Documento:
            ObjParametrodr.nStbTipoDocContableID = Me.cboTipoDocumento.Columns("nStbValorCatalogoID").Value
            'Tipo de Afectación:
            ObjParametrodr.nStbTipoAfectacionID = Me.cboTipoAfectacion.Columns("nStbValorCatalogoID").Value
            'Debito:
            If Me.chkDebe.Checked Then
                ObjParametrodr.nDebito = 1
            Else
                ObjParametrodr.nDebito = 0
            End If

            ObjParametrodr.Update()
            'Asignar el Id de la Socia a la variable publica del formulario
            IdScnParametro = ObjParametrodr.nScnTransaccionParametroID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(4, 24, "Modificación de Parámetro Contable ID:" & Me.IdScnParametro & ".")
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
    Private Sub CargarTipoDocumento()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (a.sCodigoInterno IN ('CK', 'CR', 'CC', 'CD','NC','ND','PR')) AND (b.sNombre = 'TipoDocumentoContable')" & _
                         " ORDER BY a.sCodigoInterno"

            If XdsDocumento.ExistTable("TipoDocumento") Then
                XdsDocumento("TipoDocumento").ExecuteSql(Strsql)
            Else
                XdsDocumento.NewTable(Strsql, "TipoDocumento")
                XdsDocumento("TipoDocumento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoDocumento.DataSource = XdsDocumento("TipoDocumento").Source

            Me.cboTipoDocumento.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoDocumento.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoDocumento.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoDocumento.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoDocumento.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoDocumento.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoDocumento.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoDocumento.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
    Private Sub CargarTipoAfectacion()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoAfectacion')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsDocumento.ExistTable("TipoAfectacion") Then
                XdsDocumento("TipoAfectacion").ExecuteSql(Strsql)
            Else
                XdsDocumento.NewTable(Strsql, "TipoAfectacion")
                XdsDocumento("TipoAfectacion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoAfectacion.DataSource = XdsDocumento("TipoAfectacion").Source

            Me.cboTipoAfectacion.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoAfectacion.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoAfectacion.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoAfectacion.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoAfectacion.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoAfectacion.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoAfectacion.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoAfectacion.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
                             " WHERE (a.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") " & _
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
    Private Sub cboTipoDocumento_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboTipoDocumento.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que ocurra otro Tipo de Error:
    Private Sub cboTipoAfectacion_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboTipoAfectacion.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Tipo Documento:
    Private Sub cboTipoDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.TextChanged
        vbModifico = True
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

    Private Sub cboTipoAfectacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoAfectacion.TextChanged
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
End Class