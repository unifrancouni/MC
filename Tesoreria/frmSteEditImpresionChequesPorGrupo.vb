Public Class frmSteEditImpresionChequesPorGrupo
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

    Private _idGrupo As Integer
    Public Property IdGrupo() As Integer
        Get
            IdGrupo = _idGrupo
        End Get
        Set(ByVal value As Integer)
            _idGrupo = value
        End Set
    End Property

    Private _CantidadSocias As Integer
    Private Property CantidadSocia() As Integer
        Get
            CantidadSocia = _CantidadSocias
        End Get
        Set(ByVal value As Integer)
            _CantidadSocias = value
        End Set
    End Property


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

    Private Sub frmSteEditImpresionCheques_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:


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

    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""
            Me.txtNumChequeInicial.Select()
          
            ObjSolicituddt = New BOSistema.Win.SccEntCredito.SccSolicitudChequeDataTable
            ObjSolicituddr = New BOSistema.Win.SccEntCredito.SccSolicitudChequeRow

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


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
                Me.txtNumChequeInicial.Text = ObjSolicituddr.nNumeroCheque
            Else
                Me.txtNumChequeInicial.Text = ""
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

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            SalvarCheque()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatosV As New BOSistema.Win.XComando
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            Dim nNumeroCk As Integer

            ValidaDatosEntrada = True
            '  Me.errSolicitud.Clear()

            'Número de Cheque Inicial Obligatorio:
            If Trim(RTrim(Me.txtNumChequeInicial.Text)).ToString.Length = 0 Then
                MsgBox("El Número Inicial de Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.txtNumChequeInicial, "El Número de Cheque NO DEBE quedar vacío.")
                Me.txtNumChequeInicial.Focus()
                Exit Function
            End If
            'Número de Cheque Final Obligatorio:
            
            'No Duplicar Número de Cheque para la Cuenta Bancaria (IdSteCuentaBancariaID)
            'de Solicitudes de Cheque ACTIVAS (diferentes de anuladas - 5):
            '-- No se excluye el actual pues la asignacion de chequera no se puede modificar
            '-- (antes el usuario debe limpiar la asignación).
            REM Modificación de Número de Cheque de 1001030731048728816 a 1001030731048728616.
            REM Modificación de Número de Cheque de 1001030731048729054 a 1001030731048728854.
            strSQL = "SELECT SteCuentaBancaria.nSteCuentaBancariaID " & _
                     "FROM SccSolicitudCheque INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID INNER JOIN ScnCatalogoContable ON dbo.SccSolicitudChequeDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID INNER JOIN SteCuentaBancaria ON dbo.ScnCatalogoContable.nSteCuentaBancariaID = SteCuentaBancaria.nSteCuentaBancariaID " & _
                     "INNER JOIN StbValorCatalogo ON SccSolicitudCheque.nStbEstadoSolicitudID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SteCuentaBancaria.nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ") AND (SccSolicitudChequeDetalle.nDebito = 0) AND (SccSolicitudCheque.nNumeroCheque = " & Trim(RTrim(Me.txtNumChequeInicial.Text)) & ") " & _
                     "AND (StbValorCatalogo.sCodigoInterno <> '5')"
            If RegistrosAsociados(strSQL) Then
                MsgBox("El Número de Cheque ya se registró para la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.txtNumCheque, "Número de Cheque Inválido.")
                Me.txtNumChequeInicial.Focus()
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
                     "AND (SUBSTRING(ScnTransaccionContable.sNumeroTransaccion,  LEN(SteCuentaBancaria.sNumeroCuenta) + 1, LEN(ScnTransaccionContable.sNumeroTransaccion)) = '" & Trim(RTrim(Me.txtNumChequeInicial.Text)) & "') AND (StbValorCatalogo_1.sCodigoInterno <> '3')"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe un Comprobante Contable" & Chr(13) & "con este número de cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.txtNumChequeInicial, "Número de Cheque Inválido.")
                Me.txtNumChequeInicial.Focus()
                Exit Function
            End If

            

            'Número de cheque no menor que el número inicial de chequera para la Cuenta Bancaria:
            strSQL = "SELECT nNumeroInicialCheque FROM SteCuentaBancaria WHERE (nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ")"
            nNumeroCk = XcDatosV.ExecuteScalar(strSQL)
            If CInt(Trim(RTrim(Me.txtNumChequeInicial.Text))) < nNumeroCk Then
                MsgBox("El Número de Cheque NO DEBE ser inferior al número inicial de la chequera" & Chr(13) & "indicada en la Cuenta Bancaria (" & nNumeroCk & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.txtNumChequeInicial, "Número de Cheque Inválido.")
                Me.txtNumChequeInicial.Focus()
                Exit Function
            End If
       
            'Número de Cheque no mayor que el número final de chequera para la Cuenta Bancaria:
            strSQL = "SELECT nNumeroFinalCheque FROM SteCuentaBancaria WHERE (nSteCuentaBancariaID = " & IdSteCuentaBancariaID & ")"
            nNumeroCk = XcDatosV.ExecuteScalar(strSQL)
            If CInt(Trim(RTrim(Me.txtNumChequeInicial.Text))) > nNumeroCk Then
                MsgBox("El Número de Cheque NO DEBE ser superior al número final" & Chr(13) & "de la chequera indicada en la Cuenta Bancaria (" & nNumeroCk & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.txtNumChequeInicial, "Número de Cheque Inválido.")
                Me.txtNumChequeInicial.Focus()
                Exit Function
            End If

            'Mostrar Numero de Cheque Final

            XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
            strSQL = "select dbo.ObtenerUltimoNumeroDeCheque(" & IdGrupo & ", " & Trim(RTrim(Me.txtNumChequeInicial.Text)) & ", " & IdCuentaBancaria & " )"
            XdtTmpConsulta.ExecuteSql(strSQL)
            Me.txtNumChequeFinal.Text = XdtTmpConsulta.Table.Rows(0).Item(0).ToString()

            'Fecha de Cheque Obligatoria:
            If Me.cdeFechaCheque.ValueIsDbNull Then
                MsgBox("La Fecha del Cheque NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE quedar vacía.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha Cheque no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Corte NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Corte NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha Cheque no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Corte NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.cdeFechaCheque, "La Fecha del Corte NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha del Cheque no mayor o menor de Tres días de la Fecha del Servidor (fecha del día):
            REM Solicitado Por Lester Mendieta 05/Oct/2009: Subir Rango a 10 días.
            REM Solicitado Por Lester Mendieta 30/Abr/2010: Subir Rango a 15 días.
            If DateDiff(DateInterval.Day, Me.cdeFechaCheque.Value, FechaServer.Date) > 14 Then
                MsgBox("No deben existir más de 15 días de diferencia entre" & Chr(13) & "fecha del cheque y fecha del día.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If
            If DateDiff(DateInterval.Day, FechaServer.Date, Me.cdeFechaCheque.Value) > 14 Then
                MsgBox("No deben existir más de 15 días de diferencia entre" & Chr(13) & "fecha del cheque y fecha del día.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha del Cheque debe ser mayor que la Fecha de la Solicitud de Cheque:
            If Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") <= Format(Me.dSccFechaSolicitudCk, "yyyy-MM-dd") Then
                MsgBox("Fecha de Cheque DEBE ser Mayor que la Fecha" & Chr(13) & "de la Solicitud de Cheque.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                'Me.errSolicitud.SetError(Me.cdeFechaCheque, "Fecha del Cheque inválida.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If
            cmdAceptar.Enabled = True
        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatosV.Close()
            XcDatosV = Nothing
        End Try
    End Function


    Private Sub SalvarCheque()


        Dim strSQL As String = ""

        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Try
            strSQL = "execute SpSccAsignarNumeroDeChequesProGrupoSolidario @IdGrupo=  " & IdGrupo & ",@IdSolicitudSocia=" & IdSolicitud & ", @IdCuentBancaria= " & IdCuentaBancaria & ", @NumChequeInicial = " & Trim(RTrim(Me.txtNumChequeInicial.Text)) & " , @FechaCheque= ' " & Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") & "' , @UsuraioModificaionId=" & InfoSistema.IDCuenta & ""
            XdtTmpConsulta.ExecuteSql(strSQL)

            Me.grdSolicitudes.DataSource = XdtTmpConsulta.Source
            Me.Formato()

            Me.cmdAceptar.Enabled = False
        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub Formato()
        Try

            'Me.grdSolicitudes.Splits(0).DisplayColumns("socia").Width = 100
            'Me.grdSolicitudes.Splits(0).DisplayColumns("NumeroCheque").Width = 50
            'Me.grdSolicitudes.Splits(0).DisplayColumns("Monto").Width = 100


            Me.grdSolicitudes.Columns("socia").Caption = "Nombre Socia"
            Me.grdSolicitudes.Columns("NumeroCheque").Caption = "Número Cheque"
            Me.grdSolicitudes.Columns("Monto").Caption = "Monto C$"


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub bVerificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bVerificar.Click
        ValidaDatosEntrada()
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

End Class