' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                08/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditConciliacionOperaciones.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Operaciones Bancarias.
'-------------------------------------------------------------------------
Public Class frmSteEditConciliacionOperaciones

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/UPD/DEL
    Dim IdSteConciliacion As Integer
    Dim IdSteOperacion As Integer

    Dim dSteFechaI As Date
    Dim dSteFechaF As Date

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjOperaciondt As BOSistema.Win.SteEntTesoreria.SteConciliacionOtrasOperacionesDataTable
    Dim ObjOperaciondr As BOSistema.Win.SteEntTesoreria.SteConciliacionOtrasOperacionesRow

    'Enumerado para controlar las acciones sobre el Formulario
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

    'Propiedad utilizada para obtener el ID de la Conciliación.
    Public Property IdConciliacion() As Integer
        Get
            IdConciliacion = IdSteConciliacion
        End Get
        Set(ByVal value As Integer)
            IdSteConciliacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Operación Bancaria.
    Public Property IdOperacion() As Integer
        Get
            IdOperacion = IdSteOperacion
        End Get
        Set(ByVal value As Integer)
            IdSteOperacion = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       frmSteEditConciliacionOperaciones_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacionOperaciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjOperaciondt.Close()
                ObjOperaciondt = Nothing

                ObjOperaciondr.Close()
                ObjOperaciondr = Nothing

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
    ' Fecha:                08/02/2008
    ' Procedure Name:       frmSteEditConciliacionOperaciones_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos en caso de estar en el modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacionOperaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoForm <> "ADD" Then
                CargarOperacion()
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
    ' Fecha:                08/02/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            If ModoForm = "ADD" Then
                Me.Text = "Agregar Operación Bancaria"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Operación Bancaria"
            End If

            Me.cdeFechaO.Select()
            ObjOperaciondt = New BOSistema.Win.SteEntTesoreria.SteConciliacionOtrasOperacionesDataTable
            ObjOperaciondr = New BOSistema.Win.SteEntTesoreria.SteConciliacionOtrasOperacionesRow

            If ModoFrm = "ADD" Then
                ObjOperaciondr = ObjOperaciondt.NewRow
                'Inicializar los Length de los campos (Strings)
                Me.txtConcepto.MaxLength = ObjOperaciondr.GetColumnLenght("sConcepto")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       CargarOperacion
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarOperacion()
        Try

            '-- Buscar Documento de Recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjOperaciondt.Filter = "nSteConciliacionOtrasOperacionesID = " & Me.IdSteOperacion
            ObjOperaciondt.Retrieve()
            If ObjOperaciondt.Count = 0 Then
                Exit Sub
            End If
            ObjOperaciondr = ObjOperaciondt.Current

            'Fecha:
            If Not ObjOperaciondr.IsFieldNull("dFechaRegistro") Then
                Me.cdeFechaO.Value = ObjOperaciondr.dFechaRegistro
            Else
                Me.cdeFechaO.Value = Me.cdeFechaO.ValueIsDbNull
            End If

            'Concepto:
            If Not ObjOperaciondr.IsFieldNull("sConcepto") Then
                Me.txtConcepto.Text = ObjOperaciondr.sConcepto
            Else
                Me.txtConcepto.Text = ""
            End If

            'Monto:
            If Not ObjOperaciondr.IsFieldNull("nMonto") Then
                Me.cneValor.Value = ObjOperaciondr.nMonto
            Else
                Me.cneValor.Value = 0
            End If

            'Inicializar los Length de los campos (Strings)
            Me.txtConcepto.MaxLength = ObjOperaciondr.GetColumnLenght("sConcepto")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarOperacion()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcFechas As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errOperacion.Clear()

            'Fecha de Registro:
            If (Me.cdeFechaO.ValueIsDbNull) Then
                MsgBox("La Fecha de la Operación Bancaria NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cdeFechaO, "La Fecha de la Operación Bancaria NO DEBE quedar vacía.")
                Me.cdeFechaO.Focus()
                Exit Function
            End If

            'Fecha Operación no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaO.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de la Operación Bancaria NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cdeFechaO, "La Fecha de Operación NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaO.Focus()
                Exit Function
            End If

            'Fecha Operación no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaO.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de la Operación Bancaria NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cdeFechaO, "La Fecha de Operación NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaO.Focus()
                Exit Function
            End If

            'Encuentra Fechas de la Conciliación:
            strSQL = "SELECT dFechaInicio FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            dSteFechaI = XcFechas.ExecuteScalar(strSQL)
            strSQL = "SELECT dFechaCorte FROM SteConciliacionBancaria WHERE (nSteConciliacionBancariaID = " & Me.IdConciliacion & ")"
            dSteFechaF = XcFechas.ExecuteScalar(strSQL)

            'Fecha no > que Fecha de Corte de la Conciliación:
            If Me.cdeFechaO.Value > dSteFechaF Then
                MsgBox("La Fecha de la Operación Bancaria NO DEBE ser superior a" & Chr(13) & "la Fecha de Corte de la Conciliación (" & dSteFechaF & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cdeFechaO, "Fecha de Operación Bancaria Inválida.")
                Me.cdeFechaO.Focus()
                Exit Function
            End If

            'Fecha no < que Fecha de Inicio de la Conciliación:
            If Me.cdeFechaO.Value < dSteFechaI Then
                MsgBox("La Fecha de la Operación Bancaria NO DEBE ser inferior a" & Chr(13) & "la Fecha de Inicio de la Conciliación (" & dSteFechaI & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cdeFechaO, "Fecha de Operación Bancaria Inválida.")
                Me.cdeFechaO.Focus()
                Exit Function
            End If

            'Monto:
            If Not IsNumeric(cneValor.Value) Then
                MsgBox("Monto de Operación Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cneValor, "Monto de Operación Inválido.")
                Me.cneValor.Focus()
                Exit Function
            End If
            If CDbl(cneValor.Value) = 0 Then
                MsgBox("Monto de Operación Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.cneValor, "Monto de Operación Inválido.")
                Me.cneValor.Focus()
                Exit Function
            End If

            'Concepto:
            If Trim(RTrim(Me.txtConcepto.Text)).ToString.Length = 0 Then
                MsgBox("Debe indicar Concepto de la Operación Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errOperacion.SetError(Me.txtConcepto, "Debe indicar Concepto de la Operación Bancaria.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcFechas.Close()
            XcFechas = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       SalvarOperacion
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarOperacion()
        Try
            'Actualiza usuario y fecha de creación:
            If ModoForm = "ADD" Then
                ObjOperaciondr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjOperaciondr.dFechaCreacion = FechaServer()
            Else
                ObjOperaciondr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjOperaciondr.dFechaModificacion = FechaServer()
            End If

            'ID de Conciliación:
            ObjOperaciondr.nSteConciliacionBancariaID = IdConciliacion
            'Nota de Débito:
            ObjOperaciondr.nNotaDebito = 1

            'Fecha de Registro:
            ObjOperaciondr.dFechaRegistro = Me.cdeFechaO.Value

            'Concepto:
            If Trim(RTrim(Me.txtConcepto.Text)).ToString.Length <> 0 Then
                ObjOperaciondr.sConcepto = Trim(RTrim(Me.txtConcepto.Text))
            Else
                ObjOperaciondr.SetFieldNull("sConcepto")
            End If

            'Monto:
            ObjOperaciondr.nMonto = Me.cneValor.Value


            If ModoForm <> "ADD" Then
                GuardarAuditoriaTablas(33, 2, "Actualizar SteConciliacionOtrasOperaciones", ObjOperaciondr.nSteConciliacionOtrasOperacionesID, InfoSistema.IDCuenta)
            End If

            ObjOperaciondr.Update()
            IdSteOperacion = ObjOperaciondr.nSteConciliacionOtrasOperacionesID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                GuardarAuditoriaTablas(33, 1, "Agregar SteConciliacionOtrasOperaciones", ObjOperaciondr.nSteConciliacionOtrasOperacionesID, InfoSistema.IDCuenta)
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Operación de Conciliación ID: " & Me.IdSteOperacion & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/02/2008
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
                            SalvarOperacion()
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

    Private Sub cdeFechaO_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaO.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValor.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtConcepto_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtConcepto.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.TextChanged
        vbModifico = True
    End Sub
End Class