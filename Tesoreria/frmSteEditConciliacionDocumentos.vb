' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                06/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditConciliacionDocumentos.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Documentos para una Conciliación Bancaria.
'-------------------------------------------------------------------------
Public Class frmSteEditConciliacionDocumentos

    '-- Declaracion de Variables: 
    Dim ModoForm As String 'ADD/UPD/DEL
    Dim IdSteConciliacion As Integer
    Dim IdSteDocumento As Integer
    Dim IdSteCuentaBanco As Integer
    Dim dSteFechaI As Date
    Dim dSteFechaF As Date

    '-- Clases para procesar la informacion de los combos
    Dim XdsTransacciones As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas):
    Dim ObjDocumentodt As BOSistema.Win.SteEntTesoreria.SteConciliacionTransaccionesDataTable
    Dim ObjDocumentodr As BOSistema.Win.SteEntTesoreria.SteConciliacionTransaccionesRow

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Conciliación.
    Public Property IdConciliacion() As Integer
        Get
            IdConciliacion = IdSteConciliacion
        End Get
        Set(ByVal value As Integer)
            IdSteConciliacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Transacción.
    Public Property IdDocumento() As Integer
        Get
            IdDocumento = IdSteDocumento
        End Get
        Set(ByVal value As Integer)
            IdSteDocumento = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       frmSteEditConciliacionDocumentos_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacionDocumentos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjDocumentodt.Close()
                ObjDocumentodt = Nothing

                ObjDocumentodr.Close()
                ObjDocumentodr = Nothing

                XdsTransacciones.Close()
                XdsTransacciones = Nothing

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
    ' Fecha:                06/02/2008
    ' Procedure Name:       frmSteEditConciliacionDocumentos_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacionDocumentos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarFuenteFondos(0)
            CargarTipoDocumento()
            CargarTipoOperacion()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarDocumento()
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
    ' Fecha:                06/02/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim XcFechas As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If ModoForm = "ADD" Then
                Me.Text = "Agregar Documentos de Conciliación Bancaria"
            Else
                Me.Text = "Modificar Documentos de Conciliación Bancaria"
            End If

            ObjDocumentodt = New BOSistema.Win.SteEntTesoreria.SteConciliacionTransaccionesDataTable
            ObjDocumentodr = New BOSistema.Win.SteEntTesoreria.SteConciliacionTransaccionesRow

            XdsTransacciones = New BOSistema.Win.XDataSet

            'Encuentra Fechas de la Conciliación:
            strSQL = "SELECT dFechaInicio FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            dSteFechaI = XcFechas.ExecuteScalar(strSQL)
            strSQL = "SELECT dFechaCorte FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            dSteFechaF = XcFechas.ExecuteScalar(strSQL)




    

            cdeFechaD.Value = Format(CDate(dSteFechaF), "yyyy-MM-dd")

            'Restar 6 meses
            cdeFechaD.Value = DateAdd(DateInterval.Month, -6, cdeFechaD.Value)

            'Cuenta Bancaria de la Conciliación:
            strSQL = "SELECT nSteCuentaBancariaID FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            IdSteCuentaBanco = XcFechas.ExecuteScalar(strSQL)

            'Limpiar los combos:
            Me.cboFuente.ClearFields()
            Me.cboTipoDocumento.ClearFields()
            Me.cboTipoOperacion.ClearFields()
            Me.cboDocumento.ClearFields()
            Me.cboDetalle.ClearFields()

            If ModoFrm = "ADD" Then
                ObjDocumentodr = ObjDocumentodt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcFechas.Close()
            XcFechas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       CargarDocumento
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarDocumento()
        Dim XcTransaccion As New BOSistema.Win.XComando
        Try

            Dim Strsql As String

            '-- Buscar Documento de Recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjDocumentodt.Filter = "nSteConciliacionTransaccionID = " & Me.IdSteDocumento
            ObjDocumentodt.Retrieve()
            If ObjDocumentodt.Count = 0 Then
                Exit Sub
            End If
            ObjDocumentodr = ObjDocumentodt.Current

            'Fuente de Fondos:
            If Not ObjDocumentodr.IsFieldNull("nScnTransaccionContableDetalleID") Then
                'Determinar Id de Fuente:
                Strsql = "SELECT T.nScnFuenteFinanciamientoID FROM ScnTransaccionContableDetalle AS D INNER JOIN ScnTransaccionContable AS T ON D.nScnTransaccionContableID = T.nScnTransaccionContableID WHERE (D.nScnTransaccionContableDetalleID = " & ObjDocumentodr.nScnTransaccionContableDetalleID & ")"
                CargarFuenteFondos(XcTransaccion.ExecuteScalar(Strsql))
                If cboFuente.ListCount > 0 Then
                    Me.cboFuente.SelectedIndex = 0
                End If
                XdsTransacciones("Fuente").SetCurrentByID("nScnFuenteFinanciamientoID", XcTransaccion.ExecuteScalar(Strsql))
            Else
                Me.cboFuente.Text = ""
                Me.cboFuente.SelectedIndex = -1
            End If

            'Tipo de Documento:
            If Not ObjDocumentodr.IsFieldNull("nScnTransaccionContableDetalleID") Then
                'Determinar Id de Tipo de Documento:
                Strsql = "SELECT T.nStbTipoDocContableID FROM ScnTransaccionContableDetalle AS D INNER JOIN ScnTransaccionContable AS T ON D.nScnTransaccionContableID = T.nScnTransaccionContableID WHERE (D.nScnTransaccionContableDetalleID = " & ObjDocumentodr.nScnTransaccionContableDetalleID & ")"
                CargarTipoDocumento()
                If cboTipoDocumento.ListCount > 0 Then
                    Me.cboTipoDocumento.SelectedIndex = 0
                End If
                XdsTransacciones("TipoDocumento").SetCurrentByID("nStbValorCatalogoID", XcTransaccion.ExecuteScalar(Strsql))
            Else
                Me.cboTipoDocumento.Text = ""
                Me.cboTipoDocumento.SelectedIndex = -1
            End If

            'Transacción:
            If Not ObjDocumentodr.IsFieldNull("nScnTransaccionContableDetalleID") Then
                'Determinar Id de Transacción Contable:
                Strsql = "SELECT nScnTransaccionContableID FROM ScnTransaccionContableDetalle WHERE (nScnTransaccionContableDetalleID = " & ObjDocumentodr.nScnTransaccionContableDetalleID & ")"
                CargarTransaccion(0, XcTransaccion.ExecuteScalar(Strsql))
                If cboDocumento.ListCount > 0 Then
                    Me.cboDocumento.SelectedIndex = 0
                End If
                XdsTransacciones("Transaccion").SetCurrentByID("nScnTransaccionContableID", XcTransaccion.ExecuteScalar(Strsql))
            Else
                Me.cboDocumento.Text = ""
                Me.cboDocumento.SelectedIndex = -1
            End If

            'Detalle de Transacción:
            If Not ObjDocumentodr.IsFieldNull("nScnTransaccionContableDetalleID") Then
                CargarDetalle(0)
                If XdsTransacciones("Detalles").Count > 0 Then
                    Me.cboDetalle.SelectedIndex = 0
                End If
                XdsTransacciones("Detalles").SetCurrentByID("nScnTransaccionContableDetalleID", ObjDocumentodr.nScnTransaccionContableDetalleID)
            Else
                Me.cboDetalle.Text = ""
                Me.cboDetalle.SelectedIndex = -1
            End If

            'Tipo de Operación:
            If Not ObjDocumentodr.IsFieldNull("nStbOperacionID") Then
                CargarTipoOperacion()
                If XdsTransacciones("TipoOperacion").Count > 0 Then
                    Me.cboTipoOperacion.SelectedIndex = 0
                End If
                XdsTransacciones("TipoOperacion").SetCurrentByID("nStbValorCatalogoID", ObjDocumentodr.nStbOperacionID)
            Else
                Me.cboTipoOperacion.Text = ""
                Me.cboTipoOperacion.SelectedIndex = -1
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcTransaccion.Close()
            XcTransaccion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarDocumento()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            ValidaDatosEntrada = True
            Me.errDocumento.Clear()
            Dim StrSql As String

            'Fuente de Fondos:
            If Me.cboFuente.SelectedIndex = -1 Then
                MsgBox("Debe indicar Fuente de Financiamiento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboFuente, "Debe indicar Fuente de Financiamiento.")
                Me.cboFuente.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Tipo de Documento:
            If Me.cboTipoDocumento.SelectedIndex = -1 Then
                MsgBox("Debe indicar Tipo de Transacción Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboTipoDocumento, "Debe indicar Tipo de Transacción Contable.")
                Me.cboTipoDocumento.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Documento:
            If Me.cboDocumento.SelectedIndex = -1 Then
                MsgBox("Debe indicar Número de Transacción Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboDocumento, "Debe indicar Número de Transacción Contable.")
                Me.cboDocumento.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Detalle Documento:
            If Me.cboDetalle.SelectedIndex = -1 Then
                MsgBox("Debe indicar Detalle de Transacción Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboDetalle, "Debe indicar Detalle de Transacción Contable.")
                Me.cboDetalle.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Tipo de Operación:
            If Me.cboTipoOperacion.SelectedIndex = -1 Then
                MsgBox("Debe indicar Tipo de Operación Contable.", MsgBoxStyle.Critical, NombreSistema)
                Me.errDocumento.SetError(Me.cboTipoOperacion, "Debe indicar Tipo de Operación Contable.")
                Me.cboTipoOperacion.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Si operación es Cheque Flotante solo aceptar Cheques:
            If Me.cboTipoOperacion.Columns("sCodigoInterno").Value = "CF" Then
                If cboTipoDocumento.Columns("sCodigoInterno").Value <> "CK" And cboTipoDocumento.Columns("sCodigoInterno").Value <> "CE" Then
                    MsgBox("Si indica como Tipo de Operación: Cheque Flotante, debe seleccionar" & Chr(13) & "un cheque en el tipo de documento contable.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errDocumento.SetError(Me.cboTipoOperacion, "Tipo de Operación Inválida.")
                    Me.cboTipoOperacion.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            Else
                REM Solicitado por Jimmy Correo(12/1/2010) Cheques Flotantes pueden pasar al sig. mes
                'Solo si no es Cks Flotantes validar => Imposible duplicar el Detalle de la Transacción:
                StrSql = "SELECT SteConciliacionTransacciones.nScnTransaccionContableDetalleID " & _
                         "FROM SteConciliacionTransacciones INNER JOIN SteConciliacionBancaria ON SteConciliacionTransacciones.nSteConciliacionBancariaID = SteConciliacionBancaria.nSteConciliacionBancariaID INNER JOIN StbValorCatalogo ON SteConciliacionBancaria.nStbEstadoConciliacionID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (SteConciliacionTransacciones.nScnTransaccionContableDetalleID = " & cboDetalle.Columns("nScnTransaccionContableDetalleID").Value & ") AND (SteConciliacionTransacciones.nSteConciliacionTransaccionID <> " & IdDocumento & ")"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("El movimiento ya ha sido ingresado en una" & Chr(13) & "Conciliación Bancaria ACTIVA.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errDocumento.SetError(Me.cboDetalle, "Debe indicar Detalle de Transacción Contable Válido.")
                    Me.cboDetalle.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            End If

            'Si operación es Depósito en Tránsito NO aceptar Cheques:
            If Me.cboTipoOperacion.Columns("sCodigoInterno").Value = "DT" Then
                If cboTipoDocumento.Columns("sCodigoInterno").Value = "CK" Or cboTipoDocumento.Columns("sCodigoInterno").Value = "CE" Then
                    MsgBox("Si indica como Tipo de Operación: Depósito en Tránsito, NO debe" & Chr(13) & "seleccionar un cheque en el tipo de documento contable.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errDocumento.SetError(Me.cboTipoOperacion, "Tipo de Operación Inválida.")
                    Me.cboTipoOperacion.Focus()
                    ValidaDatosEntrada = False
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
    ' Fecha:                06/02/2008
    ' Procedure Name:       SalvarDocumento
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarDocumento()
        Try

            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjDocumentodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjDocumentodr.dFechaCreacion = FechaServer()
            Else
                ObjDocumentodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjDocumentodr.dFechaModificacion = FechaServer()
            End If

            'Conciliación Bancaria:
            ObjDocumentodr.nSteConciliacionBancariaID = Me.IdConciliacion

            'Detalle de Transacción:
            If Me.cboDetalle.SelectedIndex = -1 Then
                ObjDocumentodr.SetFieldNull("nScnTransaccionContableDetalleID")
            Else
                ObjDocumentodr.nScnTransaccionContableDetalleID = Me.cboDetalle.Columns("nScnTransaccionContableDetalleID").Value
            End If

            'Tipo de Operación: 
            If Me.cboTipoOperacion.SelectedIndex = -1 Then
                ObjDocumentodr.SetFieldNull("nStbOperacionID")
            Else
                ObjDocumentodr.nStbOperacionID = Me.cboTipoOperacion.Columns("nStbValorCatalogoID").Value
            End If

            If ModoForm <> "ADD" Then
                GuardarAuditoriaTablas(32, 2, "Actualizar SteConciliacionTransacciones", ObjDocumentodr.nSteConciliacionTransaccionID, InfoSistema.IDCuenta)
            End If

            ObjDocumentodr.Update()
            IdSteDocumento = ObjDocumentodr.nSteConciliacionTransaccionID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                GuardarAuditoriaTablas(32, 2, "Agregar SteConciliacionTransacciones", ObjDocumentodr.nSteConciliacionTransaccionID, InfoSistema.IDCuenta)
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Documento de Conciliación ID: " & Me.IdSteDocumento & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
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
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarDocumento()
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
    ' Fecha:                06/02/2008
    ' Procedure Name:       CargarTransaccion
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTransaccion(ByVal intLimpiarID As Integer, ByVal intTransaccionID As Integer)
        Try
            Dim Strsql As String





            'Limpiar Combo:
            Me.cboDocumento.ClearFields()

            If intLimpiarID = 0 Then
                If intTransaccionID = 0 Then
                    Strsql = " SELECT ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                             " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                             " WHERE (ScnTransaccionContable.nStbTipoDocContableID = " & cboTipoDocumento.Columns("nStbValorCatalogoId").Value & ") AND (ScnTransaccionContable.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2') AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBanco & ") " & _
                             " GROUP BY ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion  " & _
                             " HAVING  " & IIf(chkFiltroFecha.Checked, "(ScnTransaccionContable.dFechaTransaccion >= CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102))  AND ", "") & "(ScnTransaccionContable.dFechaTransaccion <= CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) Order By  ScnTransaccionContable.sNumeroTransaccion"
                    '" HAVING (ScnTransaccionContable.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(Me.dSteFechaI, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) Order By  ScnTransaccionContable.sNumeroTransaccion"
                Else
                    Strsql = " SELECT  ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                             " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                             " WHERE ((ScnTransaccionContable.nStbTipoDocContableID = " & cboTipoDocumento.Columns("nStbValorCatalogoId").Value & ") AND (ScnTransaccionContable.nScnFuenteFinanciamientoID = " & cboFuente.Columns("nScnFuenteFinanciamientoID").Value & ") AND (StbValorCatalogo.sCodigoInterno = '2') AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBanco & ") " & _
                             " ) Or (ScnTransaccionContable.nScnTransaccionContableID = " & intTransaccionID & _
                             " ) GROUP BY ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                             " HAVING " & IIf(chkFiltroFecha.Checked, "(ScnTransaccionContable.dFechaTransaccion >= CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102))  AND ", "") & " (ScnTransaccionContable.dFechaTransaccion <= CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) Order By  ScnTransaccionContable.sNumeroTransaccion"
                    '" HAVING (ScnTransaccionContable.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(Me.dSteFechaI, "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(Me.dSteFechaF, "yyyy-MM-dd") & "', 102)) Order By  ScnTransaccionContable.sNumeroTransaccion"
                End If
            Else
                Strsql = " SELECT  ScnTransaccionContable.nScnTransaccionContableID, ScnTransaccionContable.sNumeroTransaccion, ScnTransaccionContable.dFechaTransaccion,  ScnTransaccionContable.sDescripcion " & _
                         " FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID  INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                         " WHERE ScnTransaccionContable.nScnTransaccionContableID = 0" & _
                         " Order by ScnTransaccionContable.sNumeroTransaccion"
            End If

            If XdsTransacciones.ExistTable("Transaccion") Then
                XdsTransacciones("Transaccion").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "Transaccion")
                XdsTransacciones("Transaccion").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDocumento.DataSource = XdsTransacciones("Transaccion").Source
            Me.cboDocumento.Rebind()

            'Configurar el combo:
            Me.cboDocumento.Splits(0).DisplayColumns("nScnTransaccionContableID").Visible = False
            Me.cboDocumento.Splits(0).DisplayColumns("dFechaTransaccion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDocumento.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 130
            Me.cboDocumento.Splits(0).DisplayColumns("dFechaTransaccion").Width = 80
            Me.cboDocumento.Splits(0).DisplayColumns("sDescripcion").Width = 350

            Me.cboDocumento.Columns("sNumeroTransaccion").Caption = "Número Documento"
            Me.cboDocumento.Columns("dFechaTransaccion").Caption = "Fecha"
            Me.cboDocumento.Columns("sDescripcion").Caption = "Concepto"

            Me.cboDocumento.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDocumento.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDocumento.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDocumento.Columns("dFechaTransaccion").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       CargarDetalle
    ' Descripción:          Este procedimiento permite cargar los detalles
    '                       de Cuentas Bancarias asociados a la Transacción.
    '-------------------------------------------------------------------------
    Private Sub CargarDetalle(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboDetalle.ClearFields()

            If intLimpiarID = 0 Then
                Strsql = " SELECT ScnTransaccionContableDetalle.nScnTransaccionContableDetalleID, ScnTransaccionContableDetalle.nMontoC, ScnTransaccionContableDetalle.nMontoD,  ScnTransaccionContableDetalle.nDebito, CASE dbo.ScnTransaccionContableDetalle.nDebito WHEN 1 THEN 'Sí' ELSE 'No' END AS Debito " & _
                         " FROM  ScnTransaccionContableDetalle INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                         " WHERE (ScnTransaccionContableDetalle.nScnTransaccionContableID = " & cboDocumento.Columns("nScnTransaccionContableID").Value & ") AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBanco & ") " & _
                         " Order by ScnTransaccionContableDetalle.nScnTransaccionContableID"
            Else
                Strsql = " SELECT ScnTransaccionContableDetalle.nScnTransaccionContableDetalleID, ScnTransaccionContableDetalle.nMontoC, ScnTransaccionContableDetalle.nMontoD,  ScnTransaccionContableDetalle.nDebito, CASE dbo.ScnTransaccionContableDetalle.nDebito WHEN 1 THEN 'Sí' ELSE 'No' END AS Debito " & _
                     " FROM  ScnTransaccionContableDetalle INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                     " WHERE (ScnTransaccionContableDetalle.nScnTransaccionContableID = 0) " & _
                     " Order by ScnTransaccionContableDetalle.nScnTransaccionContableID"
            End If

            If XdsTransacciones.ExistTable("Detalles") Then
                XdsTransacciones("Detalles").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "Detalles")
                XdsTransacciones("Detalles").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDetalle.DataSource = XdsTransacciones("Detalles").Source
            Me.cboDetalle.Rebind()

            'Configurar el combo:
            Me.cboDetalle.Splits(0).DisplayColumns("nScnTransaccionContableDetalleID").Visible = False
            Me.cboDetalle.Splits(0).DisplayColumns("nDebito").Visible = False

            Me.cboDetalle.Splits(0).DisplayColumns("Debito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDetalle.Splits(0).DisplayColumns("nMontoC").Width = 100
            Me.cboDetalle.Splits(0).DisplayColumns("nMontoD").Width = 100
            Me.cboDetalle.Splits(0).DisplayColumns("Debito").Width = 80

            Me.cboDetalle.Columns("nMontoC").Caption = "Monto C$"
            Me.cboDetalle.Columns("nMontoD").Caption = "Monto US$"
            Me.cboDetalle.Columns("Debito").Caption = "Débito"

            Me.cboDetalle.Splits(0).DisplayColumns("nMontoC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDetalle.Splits(0).DisplayColumns("nMontoD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDetalle.Splits(0).DisplayColumns("Debito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDetalle.Columns("nMontoC").NumberFormat = "#,##0.00"
            Me.cboDetalle.Columns("nMontoD").NumberFormat = "#,##0.00"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       CargarFuenteFondos
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarFuenteFondos(ByVal intFuenteID As Integer)
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

            If XdsTransacciones.ExistTable("Fuente") Then
                XdsTransacciones("Fuente").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "Fuente")
                XdsTransacciones("Fuente").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboFuente.DataSource = XdsTransacciones("Fuente").Source
            Me.cboFuente.Rebind()

            Me.cboFuente.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("nActiva").Visible = False
            Me.cboFuente.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/02/2008
    ' Procedure Name:       CargarFuenteFondos
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Fuentes de Financiamiento.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoDocumento()
        Try
            Dim Strsql As String = ""
            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'TipoDocumentoContable') AND (a.sCodigoInterno <> 'CC')" & _
                         " ORDER BY a.sCodigoInterno"

            If XdsTransacciones.ExistTable("TipoDocumento") Then
                XdsTransacciones("TipoDocumento").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "TipoDocumento")
                XdsTransacciones("TipoDocumento").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTipoDocumento.DataSource = XdsTransacciones("TipoDocumento").Source
            Me.cboTipoDocumento.Rebind()

            Me.cboTipoDocumento.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoDocumento.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
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
    ' Fecha:                06/02/2008
    ' Procedure Name:       CargarTipoOperacion
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Operaciones.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoOperacion()
        Try
            Dim Strsql As String = ""
            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'OperacionConciliacion')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsTransacciones.ExistTable("TipoOperacion") Then
                XdsTransacciones("TipoOperacion").ExecuteSql(Strsql)
            Else
                XdsTransacciones.NewTable(Strsql, "TipoOperacion")
                XdsTransacciones("TipoOperacion").Retrieve()
            End If

            'Asignando a las Fuentes de Datos: 
            Me.cboTipoOperacion.DataSource = XdsTransacciones("TipoOperacion").Source
            Me.cboTipoOperacion.Rebind()

            Me.cboTipoOperacion.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoOperacion.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el Combo:
            Me.cboTipoOperacion.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoOperacion.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoOperacion.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoOperacion.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoOperacion.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoOperacion.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboFuente_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFuente.TextChanged
        If (Me.cboTipoDocumento.SelectedIndex <> -1) And (Me.cboFuente.SelectedIndex <> -1) Then
            CargarTransaccion(0, 0)
        Else
            CargarTransaccion(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboTipoDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoDocumento.TextChanged
        If (Me.cboTipoDocumento.SelectedIndex <> -1) And (Me.cboFuente.SelectedIndex <> -1) Then
            CargarTransaccion(0, 0)
        Else
            CargarTransaccion(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDocumento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDocumento.TextChanged
        If (Me.cboDocumento.SelectedIndex <> -1) Then
            CargarDetalle(0)
        Else
            CargarDetalle(1)
        End If
        vbModifico = True
    End Sub

    Private Sub cboDetalle_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDetalle.TextChanged
        If (Me.cboDetalle.SelectedIndex <> -1) Then
            txtMontoD.Text = cboDetalle.Columns("nMontoD").Value
        Else
            txtMontoD.Text = ""
        End If
        vbModifico = True
    End Sub

    Private Sub cboTipoOperacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoOperacion.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkFiltroFecha_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkFiltroFecha.CheckedChanged
      
    End Sub

    Private Sub cdeFechaD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaD.TextChanged
    End Sub
End Class