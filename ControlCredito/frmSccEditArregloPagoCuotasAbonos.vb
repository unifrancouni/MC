' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                14/10/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditArregloPagoCuotasAbonos.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de cuotas y abonos de arreglos de pago de socias.
'-------------------------------------------------------------------------
Public Class frmSccEditArregloPagoCuotasAbonos

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/UPD/DEL
    Dim IdSccArreglo As Integer
    Dim IdSccRegistro As Integer
    Dim StrTipoRegistro As String 'Cuotas/Abonos
    
    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjCuotadt As BOSistema.Win.SccEntCartera.SccArregloPagoDetalleDataTable
    Dim ObjCuotadr As BOSistema.Win.SccEntCartera.SccArregloPagoDetalleRow

    Dim ObjAbonodt As BOSistema.Win.SccEntCartera.SccArregloPagoAbonoDataTable
    Dim ObjAbonodr As BOSistema.Win.SccEntCartera.SccArregloPagoAbonoRow

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

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de Cuotas o Abonos.
    Public Property TipoRegistro() As String
        Get
            TipoRegistro = StrTipoRegistro
        End Get
        Set(ByVal value As String)
            StrTipoRegistro = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arreglo de Pago.
    Public Property IdArreglo() As Integer
        Get
            IdArreglo = IdSccArreglo
        End Get
        Set(ByVal value As Integer)
            IdSccArreglo = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Detalle o el Abono.
    Public Property IdRegistro() As Integer
        Get
            IdRegistro = IdSccRegistro
        End Get
        Set(ByVal value As Integer)
            IdSccRegistro = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/10/2009
    ' Procedure Name:       frmSccEditArregloPagoCuotasAbonos_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditArregloPagoCuotasAbonos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjCuotadt.Close()
                ObjCuotadt = Nothing

                ObjCuotadr.Close()
                ObjCuotadr = Nothing

                ObjAbonodt.Close()
                ObjAbonodt = Nothing

                ObjAbonodr.Close()
                ObjAbonodr = Nothing

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
    ' Fecha:                14/10/2009
    ' Procedure Name:       frmSccEditArregloPagoCuotasAbonos_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditArregloPagoCuotasAbonos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            Me.cdeFechaA.Select()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm <> "ADD" Then
                CargarCuotaAbono()
            End If

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
    ' Fecha:                14/10/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            ObjCuotadt = New BOSistema.Win.SccEntCartera.SccArregloPagoDetalleDataTable
            ObjCuotadr = New BOSistema.Win.SccEntCartera.SccArregloPagoDetalleRow

            ObjAbonodt = New BOSistema.Win.SccEntCartera.SccArregloPagoAbonoDataTable
            ObjAbonodr = New BOSistema.Win.SccEntCartera.SccArregloPagoAbonoRow


            If ModoForm = "ADD" Then
                If Me.StrTipoRegistro = "Cuota" Then
                    Me.Text = "Agregar Cuota de Arreglo de Pago"
                    ObjCuotadr = ObjCuotadt.NewRow
                    Me.txtObservaciones.MaxLength = ObjCuotadr.GetColumnLenght("sObservaciones")
                Else
                    Me.Text = "Agregar Abono de Arreglo de Pago"
                    ObjAbonodr = ObjAbonodt.NewRow
                    Me.txtObservaciones.MaxLength = ObjAbonodr.GetColumnLenght("sObservaciones")
                End If
            ElseIf ModoForm = "UPD" Then
                If Me.StrTipoRegistro = "Cuota" Then
                    Me.Text = "Modificar Cuota de Arreglo de Pago"
                Else
                    Me.Text = "Modificar Abono de Arreglo de Pago"
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/10/2009
    ' Procedure Name:       CargarCuotaAbono
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       en caso de estar en el Modo de Modificar ya
    '                       sea cuotas o abonos de un arreglo de pago.
    '-------------------------------------------------------------------------
    Private Sub CargarCuotaAbono()
        Try

            '-- Buscar Cuota correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            If Me.StrTipoRegistro = "Cuota" Then
                ObjCuotadt.Filter = "nSccArregloPagoDetalleID = " & Me.IdSccRegistro
                ObjCuotadt.Retrieve()
                If ObjCuotadt.Count = 0 Then
                    Exit Sub
                End If
                ObjCuotadr = ObjCuotadt.Current

                'Fecha:
                If Not ObjCuotadr.IsFieldNull("dFechaCuota") Then
                    Me.cdeFechaA.Value = ObjCuotadr.dFechaCuota
                Else
                    Me.cdeFechaA.Value = Me.cdeFechaA.ValueIsDbNull
                End If
                'Monto:
                If ModoForm = "UPD" Then
                    If Not ObjCuotadr.IsFieldNull("nMontoCuota") Then
                        Me.cneValor.Value = ObjCuotadr.nMontoCuota
                    Else
                        Me.cneValor.Value = 0
                    End If
                End If
                'Observaciones:
                If Not ObjCuotadr.IsFieldNull("sObservaciones") Then
                    Me.txtObservaciones.Text = ObjCuotadr.sObservaciones
                Else
                    Me.txtObservaciones.Text = ""
                End If

                'Inicializar los Length de los campos:
                Me.txtObservaciones.MaxLength = ObjCuotadr.GetColumnLenght("sObservaciones")

                '-- Buscar Abono correspondiente al Id especificado
                '-- como parámetro, en los casos que se esté editando.
            Else
                ObjAbonodt.Filter = "nSccArregloPagoAbonoID = " & Me.IdSccRegistro
                ObjAbonodt.Retrieve()
                If ObjAbonodt.Count = 0 Then
                    Exit Sub
                End If
                ObjAbonodr = ObjAbonodt.Current

                'Fecha:
                If Not ObjAbonodr.IsFieldNull("dFechaAbono") Then
                    Me.cdeFechaA.Value = ObjAbonodr.dFechaAbono
                Else
                    Me.cdeFechaA.Value = Me.cdeFechaA.ValueIsDbNull
                End If
                'Monto:
                If ModoForm = "UPD" Then
                    If Not ObjAbonodr.IsFieldNull("nMontoAbono") Then
                        Me.cneValor.Value = ObjAbonodr.nMontoAbono
                    Else
                        Me.cneValor.Value = 0
                    End If
                End If
                'Observaciones:
                If Not ObjAbonodr.IsFieldNull("sObservaciones") Then
                    Me.txtObservaciones.Text = ObjAbonodr.sObservaciones
                Else
                    Me.txtObservaciones.Text = ""
                End If

                'Inicializar los Length de los campos:
                Me.txtObservaciones.MaxLength = ObjAbonodr.GetColumnLenght("sObservaciones")
            End If
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/10/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarRegistro()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/10/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatosV As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim MontoA As Double

            ValidaDatosEntrada = True
            Me.errError.Clear()

            'Fecha de Areglo de Pago:
            If (Me.cdeFechaA.ValueIsDbNull) Then
                MsgBox("Fecha NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errError.SetError(Me.cdeFechaA, "Fecha Inválida.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Areglo de Pago no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("Fecha NO DEBE ser menor que fecha de" & Chr(13) & "inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errError.SetError(Me.cdeFechaA, "Fecha Inválida.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Areglo de Pago no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("Fecha NO DEBE ser mayor que la fecha de" & Chr(13) & "corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errError.SetError(Me.cdeFechaA, "Fecha Inválida.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha no menor que la del Arreglo de Pago:
            strSQL = "SELECT dFechaArregloPago FROM SccArregloPago " & _
                     "WHERE (nSccArregloPagoID = " & Me.IdSccArreglo & ") " & _
                     "AND (dFechaArregloPago > CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Fecha NO DEBE ser menor que fecha" & Chr(13) & "del Arreglo de Pago.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errError.SetError(Me.cdeFechaA, "Fecha Inválida.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Monto Valido:
            If Not IsNumeric(cneValor.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errError.SetError(Me.cneValor, "Monto Inválido.")
                Me.cneValor.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If
            If CDbl(cneValor.Value) = 0 Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errError.SetError(Me.cneValor, "Monto Inválido.")
                Me.cneValor.Focus()
                Exit Function
            End If

            'Encuentra Monto Total del Arreglo de Pago:
            strSQL = "SELECT  nMontoArregloPago FROM SccArregloPago WHERE (nSccArregloPagoID = " & Me.IdSccArreglo & ")"
            MontoA = XcDatosV.ExecuteScalar(strSQL)

            'Suma de montos registrados como cuotas/abonos no deben superar el monto
            'total del arreglo de pago:
            If Me.StrTipoRegistro = "Cuota" Then
                strSQL = "SELECT ISNULL(SUM(nMontoCuota), 0) AS TotalC FROM SccArregloPagoDetalle " & _
                         "WHERE (nSccArregloPagoID = " & Me.IdSccArreglo & ") AND (nSccArregloPagoDetalleID <> " & Me.IdSccRegistro & ")"
                If (CDbl(cneValor.Value) + CDbl(XcDatosV.ExecuteScalar(strSQL))) > MontoA Then
                    MsgBox("Suma de Cuotas no debe ser superior al monto" & Chr(13) & "total del Arreglo de Pago (C$ " & MontoA & ").", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errError.SetError(Me.cneValor, "Monto Inválido.")
                    Me.cneValor.Focus()
                    Exit Function
                End If
                REM EN CAPACITACION SE BLOQUEO PARA ABONOS PUES POR MORA
                REM LAS SOCIAS PODRIAN ABONAR MAS DE LO PACTADO EN EL 
                REM ARREGLO DE PAGO.
                'Else
                '    strSQL = "SELECT ISNULL(SUM(nMontoAbono), 0) AS TotalC FROM SccArregloPagoAbono " & _
                '             "WHERE (nSccArregloPagoID = " & Me.IdSccArreglo & ") AND (nSccArregloPagoAbonoID <> " & Me.IdSccRegistro & ")"
            End If

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
    ' Fecha:                14/10/2009
    ' Procedure Name:       SalvarRegistro
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarRegistro()
        Try

            '-- Ingreso de Cuotas de Arreglo de Pago:
            If Me.StrTipoRegistro = "Cuota" Then
                If ModoForm = "ADD" Then
                    ObjCuotadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                    ObjCuotadr.dFechaCreacion = FechaServer()
                Else
                    ObjCuotadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                    ObjCuotadr.dFechaModificacion = FechaServer()
                End If
                'Id de Arreglo de Pago: 
                ObjCuotadr.nSccArregloPagoID = Me.IdSccArreglo
                'Fecha:
                ObjCuotadr.dFechaCuota = Format(Me.cdeFechaA.Value, "yyyy-MM-dd")
                'Monto:
                ObjCuotadr.nMontoCuota = Me.cneValor.Value
                'Observaciones:
                If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                    ObjCuotadr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
                Else
                    ObjCuotadr.SetFieldNull("sObservaciones")
                End If
                ObjCuotadr.Update()
                'Asignar el Id de la Caja a variable publica:
                IdSccRegistro = ObjCuotadr.nSccArregloPagoDetalleID

                '------------------------------------------
                '-- Ingreso de Abonos de Arreglo de Pago:
                '------------------------------------------
            Else
                If ModoForm = "ADD" Then
                    ObjAbonodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                    ObjAbonodr.dFechaCreacion = FechaServer()
                Else
                    ObjAbonodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                    ObjAbonodr.dFechaModificacion = FechaServer()
                End If
                'Id de Arreglo de Pago: 
                ObjAbonodr.nSccArregloPagoID = Me.IdSccArreglo
                'Fecha:
                ObjAbonodr.dFechaAbono = Format(Me.cdeFechaA.Value, "yyyy-MM-dd")
                'Monto:
                ObjAbonodr.nMontoAbono = Me.cneValor.Value
                'Observaciones:
                If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                    ObjAbonodr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
                Else
                    ObjAbonodr.SetFieldNull("sObservaciones")
                End If
                ObjAbonodr.Update()
                'Asignar el Id de la Caja a variable publica:
                IdSccRegistro = ObjAbonodr.nSccArregloPagoAbonoID
            End If

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/10/2009
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
                            SalvarRegistro()
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

    Private Sub cneValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValor.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaA.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub
End Class