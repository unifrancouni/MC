' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                02/02/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditImpresionCheques.vb
' Descripción:          Este formulario permite asignar número de chequera
'                       y fecha de cheque a Solicitudes de Cheque Autorizadas
'                       (pendiente de generar Comprobante de Cheque por 
'                       Contabilidad).
'-------------------------------------------------------------------------
Public Class frmSteEditImpresionCheques

    '-- Declaracion de Variables 
    Dim IdSccSolicitudID As Integer
    Dim IdSteCuentaBancariaID As Integer
    Dim dSccFechaSolicitudCk As Date

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjSolicituddt As BOSistema.Win.SccEntCredito.SccSolicitudChequeDataTable
    Dim ObjSolicituddr As BOSistema.Win.SccEntCredito.SccSolicitudChequeRow

    'Enumerado para controlar las acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property IdSolicitud() As Integer
        Get
            IdSolicitud = IdSccSolicitudID
        End Get
        Set(ByVal value As Integer)
            IdSccSolicitudID = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property IdCuentaBancaria() As Integer
        Get
            IdCuentaBancaria = IdSteCuentaBancariaID
        End Get
        Set(ByVal value As Integer)
            IdSteCuentaBancariaID = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property dFechaSolicitudCk() As Date
        Get
            dFechaSolicitudCk = dSccFechaSolicitudCk
        End Get
        Set(ByVal value As Date)
            dSccFechaSolicitudCk = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/02/2009
    ' Procedure Name:       frmSteEditImpresionCheques_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditImpresionCheques_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjSolicituddt.Close()
                ObjSolicituddt = Nothing

                ObjSolicituddr.Close()
                ObjSolicituddr = Nothing

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
    ' Fecha:                02/02/2009
    ' Procedure Name:       frmSteEditImpresionCheques_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditImpresionCheques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            CargarCheque()
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
    ' Fecha:                02/02/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""
            Me.txtNumCheque.Select()

            ObjSolicituddt = New BOSistema.Win.SccEntCredito.SccSolicitudChequeDataTable
            ObjSolicituddr = New BOSistema.Win.SccEntCredito.SccSolicitudChequeRow

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/02/2009
    ' Procedure Name:       CargarCheque
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarCheque()
        Try

            '-- Buscar Documento de Recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjSolicituddt.Filter = "nSccSolicitudChequeID = " & Me.IdSccSolicitudID
            ObjSolicituddt.Retrieve()
            If ObjSolicituddt.Count = 0 Then
                Exit Sub
            End If
            ObjSolicituddr = ObjSolicituddt.Current

            'Número de Cheque:
            If Not ObjSolicituddr.IsFieldNull("nNumeroCheque") Then
                Me.txtNumCheque.Text = ObjSolicituddr.nNumeroCheque
            Else
                Me.txtNumCheque.Text = ""
            End If

            'Fecha del Cheque:
            If Not ObjSolicituddr.IsFieldNull("dFechaCheque") Then
                Me.cdeFechaCheque.Value = ObjSolicituddr.dFechaCheque
            Else
                'Me.cdeFechaCheque.Value = FechaServer()
                'Sugerir Fecha de Solicitud de Cheque + 1 día:
                Me.cdeFechaCheque.Value = DateSerial(Year(Me.dSccFechaSolicitudCk), Month(Me.dSccFechaSolicitudCk), Microsoft.VisualBasic.DateAndTime.Day(Me.dSccFechaSolicitudCk) + 1)
                'Si nueva Fecha es domingo: Solicitud de Cheque + 2 días:
                If Format(Me.cdeFechaCheque.Value, "dddd") = "domingo" Then
                    Me.cdeFechaCheque.Value = DateSerial(Year(Me.dSccFechaSolicitudCk), Month(Me.dSccFechaSolicitudCk), Microsoft.VisualBasic.DateAndTime.Day(Me.dSccFechaSolicitudCk) + 2)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/02/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCheque()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/02/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatosV As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim nNumeroCkSolicitud As Integer
            Dim nNumeroCkAnulado As Integer
            ValidaDatosEntrada = True
            Me.errSolicitud.Clear()

            'Número de Cheque Obligatorio:
            If Trim(RTrim(Me.txtNumCheque.Text)).ToString.Length = 0 Then
                MsgBox("El Número de Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.txtNumCheque, "El Número de Cheque NO DEBE quedar vacío.")
                Me.txtNumCheque.Focus()
                Exit Function
            End If

            'No Duplicar Número de Cheque para la Cuenta Bancaria (IdSteCuentaBancariaID)
            'de Solicitudes de Cheque ACTIVAS (diferentes de anuladas - 5):
            '-- No se excluye el actual pues la asignacion de chequera no se puede modificar
            '-- (antes el usuario debe limpiar la asignación).
            REM Modificación de Número de Cheque de 1001030731048728816 a 1001030731048728616.
            REM Modificación de Número de Cheque de 1001030731048729054 a 1001030731048728854.
            strSQL = "SELECT SteCuentaBancaria.nSteCuentaBancariaID " & _
                     "FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON dbo.SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID INNER JOIN SteCuentaBancaria ON dbo.ScnCatalogoContable.nSteCuentaBancariaID = SteCuentaBancaria.nSteCuentaBancariaID " & _
                     "INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SteCuentaBancaria.nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ") AND (SccSolicitudChequeDetalle.nDebito = 0) AND (SccSolicitudCheque.nNumeroCheque = " & Trim(RTrim(Me.txtNumCheque.Text)) & ") " & _
                     "AND (StbValorCatalogo.sCodigoInterno <> '5')"
            If RegistrosAsociados(strSQL) Then
                MsgBox("El Número de Cheque ya se registró para la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.txtNumCheque, "Número de Cheque Inválido.")
                Me.txtNumCheque.Focus()
                Exit Function
            End If

            'Número del cheque no debe existir en Comprobante generado en Contabilidad para la Cuenta Bancaria:
            strSQL = "SELECT SUBSTRING(ScnTransaccionContable.sNumeroTransaccion, LEN(SteCuentaBancaria.sNumeroCuenta) + 1,  LEN(ScnTransaccionContable.sNumeroTransaccion)) AS Cod " & _
                     "FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID INNER JOIN ScnCatalogoContable " & _
                     "ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID INNER JOIN SteCuentaBancaria ON ScnCatalogoContable.nSteCuentaBancariaID = SteCuentaBancaria.nSteCuentaBancariaID " & _
                     "INNER JOIN StbValorCatalogo AS StbValorCatalogo_1 ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo_1.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = 'CE' OR StbValorCatalogo.sCodigoInterno = 'CK') " & _
                     "AND (ScnCatalogoContable.nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ") AND (ScnTransaccionContableDetalle.nDebito = 0) " & _
                     "AND (SUBSTRING(ScnTransaccionContable.sNumeroTransaccion,  LEN(SteCuentaBancaria.sNumeroCuenta) + 1, LEN(ScnTransaccionContable.sNumeroTransaccion)) = '" & Trim(RTrim(Me.txtNumCheque.Text)) & "') AND (StbValorCatalogo_1.sCodigoInterno <> '3')"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe un Comprobante Contable" & Chr(13) & "con este número de cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.txtNumCheque, "Número de Cheque Inválido.")
                Me.txtNumCheque.Focus()
                Exit Function
            End If

            'Número de cheque no menor que el número inicial de chequera para la Cuenta Bancaria:
            strSQL = "SELECT nNumeroInicialCheque FROM SteCuentaBancaria WHERE (nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ")"
            nNumeroCkSolicitud = XcDatosV.ExecuteScalar(strSQL)
            If CInt(Trim(RTrim(Me.txtNumCheque.Text))) < nNumeroCkSolicitud Then
                MsgBox("El Número de Cheque NO DEBE ser inferior al número inicial de la chequera" & Chr(13) & "indicada en la Cuenta Bancaria (" & nNumeroCkSolicitud & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.txtNumCheque, "Número de Cheque Inválido.")
                Me.txtNumCheque.Focus()
                Exit Function
            End If

            'Número de Cheque no mayor que el número final de chequera para la Cuenta Bancaria:
            strSQL = "SELECT nNumeroFinalCheque FROM SteCuentaBancaria WHERE (nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ")"
            nNumeroCkSolicitud = XcDatosV.ExecuteScalar(strSQL)
            If CInt(Trim(RTrim(Me.txtNumCheque.Text))) > nNumeroCkSolicitud Then
                MsgBox("El Número de Cheque NO DEBE ser superior al número final" & Chr(13) & "de la chequera indicada en la Cuenta Bancaria (" & nNumeroCkSolicitud & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.txtNumCheque, "Número de Cheque Inválido.")
                Me.txtNumCheque.Focus()
                Exit Function
            End If


            'Imposible si el último número de cheque asignado o anulado para esa cuenta bancaria  **CAMBIO MAYO 2016
            'no es el actual menos uno a fin de garantizar secuencia de la chequera
            'evitandose posibles lagunas.
            strSQL = " SELECT   MAX(dbo.SccSolicitudCheque.nNumeroCheque) AS nNumeroCheque" & _
                     " FROM dbo.SccSolicitudChequeDetalle INNER JOIN dbo.SccSolicitudCheque ON dbo.SccSolicitudChequeDetalle.nSccSolicitudChequeID = dbo.SccSolicitudCheque.nSccSolicitudChequeID  " & _
                     " INNER JOIN   dbo.ScnCatalogoContable ON dbo.SccSolicitudChequeDetalle.nScnCatalogoContableID = dbo.ScnCatalogoContable.nScnCatalogoContableID " & _
                     " INNER JOIN dbo.SteCuentaBancaria ON dbo.ScnCatalogoContable.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID " & _
                     " WHERE        (dbo.SteCuentaBancaria.nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ") AND (dbo.SccSolicitudChequeDetalle.nDebito = 0) "

            nNumeroCkSolicitud = XcDatosV.ExecuteScalar(strSQL)


            strSQL = " SELECT  MAX(dbo.SteChequeAnulado.nNumeroCheque) AS nNumeroCK" & _
                    " FROM  dbo.SteChequeAnulado " & _
                    " WHERE  nSteCuentaBancariaID= " & IdSteCuentaBancariaID

            nNumeroCkAnulado = XcDatosV.ExecuteScalar(strSQL)

            If nNumeroCkSolicitud > nNumeroCkAnulado Then
                If nNumeroCkSolicitud <> (CInt(Trim(RTrim(Me.txtNumCheque.Text))) - 1) Then
                    MsgBox("Imposible asignar ese número de cheque." & Chr(13) & "El último numero de cheque asignado es el " & nNumeroCkSolicitud & Chr(13) & "por lo que no habría secuencia numerica en chequera.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntrada = False
                    Exit Function
                End If

            Else
                If nNumeroCkAnulado <> (CInt(Trim(RTrim(Me.txtNumCheque.Text))) - 1) Then
                    MsgBox("Imposible asignar ese número de cheque." & Chr(13) & "El último numero de cheque usado es el " & nNumeroCkAnulado & Chr(13) & "por lo que no habría secuencia numerica en chequera.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            End If

            'Fecha de Cheque Obligatoria:
            If Me.cdeFechaCheque.ValueIsDbNull Then
                MsgBox("La Fecha del Cheque NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE quedar vacía.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha Cheque no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Corte NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Corte NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha Cheque no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Corte NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Corte NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha del Cheque no mayor o menor de Tres días de la Fecha del Servidor (fecha del día):
            REM Solicitado Por Lester Mendieta 05/Oct/2009: Subir Rango a 10 días.
            REM Solicitado Por Lester Mendieta 30/Abr/2010: Subir Rango a 15 días.
            If DateDiff(DateInterval.Day, Me.cdeFechaCheque.Value, FechaServer.Date) > 14 Then
                MsgBox("No deben existir más de 15 días de diferencia entre" & Chr(13) & "fecha del cheque y fecha del día.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If
            If DateDiff(DateInterval.Day, FechaServer.Date, Me.cdeFechaCheque.Value) > 14 Then
                MsgBox("No deben existir más de 15 días de diferencia entre" & Chr(13) & "fecha del cheque y fecha del día.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha del Cheque debe ser mayor que la Fecha de la Solicitud de Cheque:
            If Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") <= Format(Me.dSccFechaSolicitudCk, "yyyy-MM-dd") And ObjSolicituddr.nSccTipoSolicitudChequeID <> 3 Then
                MsgBox("Fecha de Cheque DEBE ser Mayor que la Fecha" & Chr(13) & "de la Solicitud de Cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If


            If Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") < Format(Me.dSccFechaSolicitudCk, "yyyy-MM-dd") And ObjSolicituddr.nSccTipoSolicitudChequeID = 3 Then
                MsgBox("Fecha de Cheque DEBE ser Mayor o Igual que la Fecha" & Chr(13) & "de la Solicitud de Cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha del Cheque no debe estar Cerrada:
            'strSQL = "SELECT nSccSolicitudChequeID FROM SccSolicitudCheque " & _
            '         "WHERE (dFechaCheque = CONVERT(DATETIME, '" & Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") & "', 102)) AND (nChequeCerrado = 1)"
            'If RegistrosAsociados(strSQL) = True Then
            '    MsgBox("La Fecha del Cheque se encuentra Cerrada.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
            '    Me.cdeFechaCheque.Focus()
            '    Exit Function
            'End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatosV.Close()
            XcDatosV = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/02/2009
    ' Procedure Name:       SalvarCheque
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '                       Si es una edición y se cambio el número de cheque
    '                       limpiar cheques superiores en caso de existir.
    '-------------------------------------------------------------------------
    Private Sub SalvarCheque()
        Try

            'Actualiza usuario y fecha de modificación de la Solicitud de Cheque:
            ObjSolicituddr.nUsuarioModificacionID = InfoSistema.IDCuenta
            ObjSolicituddr.dFechaModificacion = FechaServer()

            'Número de Cheque:
            ObjSolicituddr.nNumeroCheque = Trim(RTrim(Me.txtNumCheque.Text))
            'Fecha del Cheque:
            ObjSolicituddr.dFechaCheque = Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")

            'GuardarAuditoriaTablas(1, 2, "Actualizar Solicitud Cheque Impresion  ", ObjSolicituddr.nSccSolicitudChequeID, InfoSistema.IDCuenta)

            ObjSolicituddr.Update()
            'Asignar el Id de la Socia a la variable publica del formulario:
            Me.IdSccSolicitudID = ObjSolicituddr.nSccSolicitudChequeID
            '---------------------------------------------------------

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/02/2009
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
                            SalvarCheque()
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

    Private Sub txtNumCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCheque.KeyPress
        Try
            'Solo numeros: 
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNumCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumCheque.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCheque.TextChanged
        vbModifico = True
    End Sub
End Class