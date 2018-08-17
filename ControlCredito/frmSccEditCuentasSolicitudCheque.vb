' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                08/11/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditCuentasSolicitudCheque.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de los Detalles de una determinada Solicitud de Cheque.
'-------------------------------------------------------------------------
Public Class frmSccEditCuentasSolicitudCheque

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSccCuenta As Long
    Dim IdSccSolicitud As Long

    '-- Clases para procesar la informacion de los combos
    Dim XdtCuenta As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset
    Dim ObjDetalledt As BOSistema.Win.SccEntCredito.SccSolicitudChequeDetalleDataTable
    Dim ObjDetalledr As BOSistema.Win.SccEntCredito.SccSolicitudChequeDetalleRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Detalle de la Solicitud de Cheque.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Detalle de la Solicitud.
    Public Property IdCuenta() As Long
        Get
            IdCuenta = IdSccCuenta
        End Get
        Set(ByVal value As Long)
            IdSccCuenta = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Solicitud.
    Public Property IdSolicitud() As Long
        Get
            IdSolicitud = IdSccSolicitud
        End Get
        Set(ByVal value As Long)
            IdSccSolicitud = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       frmSccEditCuentasSolicitudCheque_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global. 
    '-------------------------------------------------------------------------
    Private Sub frmSccEditCuentasSolicitudCheque_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtCuenta.Close()
                XdtCuenta = Nothing

                ObjDetalledt.Close()
                ObjDetalledt = Nothing

                ObjDetalledr.Close()
                ObjDetalledr = Nothing

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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       frmSccEditCuentasSolicitudCheque_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditCuentasSolicitudCheque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarCuenta()

            'Si el formulario está en modo edición
            'cargar los datos de la Cuenta.
            If ModoFrm = "UPD" Then
                CargarDetalle()
            End If

            Me.cboCuenta.Select()
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Detalle"
            Else
                Me.Text = "Modificar Detalle"
            End If

            ObjDetalledt = New BOSistema.Win.SccEntCredito.SccSolicitudChequeDetalleDataTable
            ObjDetalledr = New BOSistema.Win.SccEntCredito.SccSolicitudChequeDetalleRow
            XdtCuenta = New BOSistema.Win.XDataSet.xDataTable

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboCuenta.ClearFields()

            If ModoFrm = "ADD" Then
                ObjDetalledr = ObjDetalledt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       CargarDetalle
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       del Detalle de Solicitud de Cheque.
    '-------------------------------------------------------------------------
    Public Sub CargarDetalle()

        Dim XdtSclFicha As New BOSistema.Win.XDataSet.xDataTable
        XdtSclFicha = New BOSistema.Win.XDataSet.xDataTable

        Try

            'En caso que se esté editando una filtrar para esta:
            ObjDetalledt.Filter = "nSccSolicitudChequeDetalleID = " & IdSccCuenta
            ObjDetalledt.Retrieve()
            If ObjDetalledt.Count = 0 Then
                Exit Sub
            End If
            ObjDetalledr = ObjDetalledt.Current

            'Cargar Combo de Cuenta:
            If Not ObjDetalledr.IsFieldNull("nScnCatalogoContableID") Then
                CargarCuenta()
                If XdtCuenta.Count > 0 Then
                    Me.cboCuenta.SelectedIndex = 0
                End If
                XdtCuenta.SetCurrentByID("nScnCatalogoContableID", ObjDetalledr.nScnCatalogoContableID)
            Else
                Me.cboCuenta.Text = ""
                Me.cboCuenta.SelectedIndex = -1
            End If

            'Cargar Tipo de Movimiento:
            Me.chkDebe.Checked = ObjDetalledr.nDebito

            'Cargar Monto en Córdobas del Movimiento:
            If Not ObjDetalledr.IsFieldNull("nMonto") Then
                Me.cneMonto.Value = ObjDetalledr.nMonto
            Else
                Me.cneMonto.Value = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtSclFicha.Close()
            XdtSclFicha = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarDetalle()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean

        Dim ObjDatosDT As New BOSistema.Win.SccEntCredito.SccSolicitudChequeDetalleDataTable

        Try
            ValidaDatosEntrada = True
            Me.errDetalle.Clear()

            'Seleccionar Cuenta:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDetalle.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta válida.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'La Cuenta debe ser de Detalle:
            If Me.cboCuenta.Columns("nCuentaDetalle").Value = 0 Then
                MsgBox("Debe seleccionar una Cuenta Detalle.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDetalle.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta Detalle.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'Validar si la Cuenta seleccionada ya forma parte de la Solicitud Actual:
            If ModoFrm = "UPD" Then
                ObjDatosDT.Filter = " nScnCatalogoContableID = " & cboCuenta.Columns("nScnCatalogoContableID").Value & " And nSccSolicitudChequeID = " & Me.IdSccSolicitud & " And nSccSolicitudChequeDetalleID <> " & Me.IdSccCuenta
            Else
                ObjDatosDT.Filter = " nScnCatalogoContableID = " & cboCuenta.Columns("nScnCatalogoContableID").Value & " And nSccSolicitudChequeID = " & Me.IdSccSolicitud
            End If
            ObjDatosDT.Retrieve()
            If ObjDatosDT.Count > 0 Then
                MsgBox("La Cuenta ya forma parte de la Solicitud.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDetalle.SetError(Me.cboCuenta, "La Cuenta ya forma parte de la Solicitud.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'Validar si se ingreso un Monto:
            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDetalle.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If
            If CDbl(cneMonto.Value) = 0 Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDetalle.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjDatosDT.Close()
            ObjDatosDT = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       SalvarDetalle
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Detalle de Solicitud de Cheque.
    '-------------------------------------------------------------------------
    Public Sub SalvarDetalle()
        Try

            If ModoForm = "ADD" Then
                ObjDetalledr.NewRow()
                ObjDetalledr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjDetalledr.dFechaCreacion = FechaServer()
            Else
                ObjDetalledr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjDetalledr.dFechaModificacion = FechaServer()
            End If

            ObjDetalledr.nSccSolicitudChequeID = Me.IdSccSolicitud
            ObjDetalledr.nScnCatalogoContableID = cboCuenta.Columns("nScnCatalogoContableID").Value
            If Me.chkDebe.Checked Then
                ObjDetalledr.nDebito = 1
            Else
                ObjDetalledr.nDebito = 0
            End If
            ObjDetalledr.nMonto = Me.cneMonto.Value



            If ModoForm <> "ADD" Then  '1 Solicitud Cheque Modificar 
                GuardarAuditoriaTablas(2, 2, "Actualizar Solicitud Cheque Detalle", ObjDetalledr.nSccSolicitudChequeDetalleID, InfoSistema.IDCuenta)
            End If



            ObjDetalledr.Update()




            If ModoForm = "ADD" Then '1 Solicitud Cheque agregar 
                GuardarAuditoriaTablas(2, 1, "Agregar Solicitud Cheque Detalle", ObjDetalledr.nSccSolicitudChequeDetalleID, InfoSistema.IDCuenta)

            End If

            'Asignar el Id del Detalle a la 
            'variable publica del formulario:
            IdSccCuenta = ObjDetalledr.nSccSolicitudChequeDetalleID

            If Me.IdSccCuenta = 0 Then
                MsgBox("El registro NO PUDO Grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                'Si el salvado se realizó de forma satisfactoria
                'enviar mensaje informando y cerrar el formulario.
                If ModoForm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/11/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede salvar o quedarse en el formulario.
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
                            SalvarDetalle()
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
    ' Fecha:                08/11/2007
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cuentas Contables en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarCuenta()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String = ""
            Dim StrsqlF As String = ""

            StrsqlF = "SELECT  nScnFuenteFinanciamientoID FROM SccSolicitudCheque WHERE (nSccSolicitudChequeID = " & Me.IdSccSolicitud & ")"
            Strsql = " SELECT a.nScnCatalogoContableID, a.sCodigoCuenta, LTRIM(a.sNombreCuenta) as sNombreCuenta, a.nCuentaDetalle " & _
                     " FROM ScnCatalogoContable a " & _
                     " WHERE (a.nScnFuenteFinanciamientoID = " & XcDatos.ExecuteScalar(StrsqlF) & ") " & _
                     " ORDER BY a.sCodigoCuenta"

            XdtCuenta.ExecuteSql(Strsql)
            Me.cboCuenta.DataSource = XdtCuenta.Source

            Me.cboCuenta.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("nCuentaDetalle").Visible = False

            'Configurar el combo
            Me.cboCuenta.Splits(0).DisplayColumns("sCodigoCuenta").Width = 110
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").Width = 280

            Me.cboCuenta.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.cboCuenta.Columns("sNombreCuenta").Caption = "Cuenta Contable"

            Me.cboCuenta.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboCuenta_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCuenta.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación la Cuenta
    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        vbModifico = True
        txtCuenta.Text = cboCuenta.Columns("sNombreCuenta").Value
    End Sub

    'Se indica que hubo modificación en el Tipo de Movimiento:
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
            Me.chkDebe.BackColor = Me.grpDetalle.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
    End Sub
End Class