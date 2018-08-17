' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                21/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditOtroCredito.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de otro Crédito Vigente.
'-------------------------------------------------------------------------
Public Class frmSccEditDetalleRecibo
    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim intSccReciboOficialCajaID As Integer
    Dim intSccReciboOficialCajaDetalleID As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsReciboDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjReciboDetalledt As BOSistema.Win.SccEntCartera.SccReciboOficialCajaDetalleDataTable
    Dim ObjReciboDetalledr As BOSistema.Win.SccEntCartera.SccReciboOficialCajaDetalleRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Comprobante.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Ficha que corresponde al campo
    'nSclFichaSociaID de la tabla SclFichaSocia.
    Public Property intReciboOficialCajaID() As Integer
        Get
            intReciboOficialCajaID = intSccReciboOficialCajaID
        End Get
        Set(ByVal value As Integer)
            intSccReciboOficialCajaID = value
        End Set
    End Property
    'Propiedad utilizada para obtener el ID del otro crédito que corresponde al campo
    'SclOtroCreditoVigenteID de la tabla SclOtroCreditoVigente.
    Public Property intReciboOficialCajaDetalleID() As Integer
        Get
            intReciboOficialCajaDetalleID = intSccReciboOficialCajaDetalleID
        End Get
        Set(ByVal value As Integer)
            intSccReciboOficialCajaDetalleID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditOtroCredito_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditOtroCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsReciboDetalle.Close()
                XdsReciboDetalle = Nothing

                ObjReciboDetalledt.Close()
                ObjReciboDetalledt = Nothing

                ObjReciboDetalledr.Close()
                ObjReciboDetalledr = Nothing
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
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSccEditDetalleRecibo_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Otro Crédito en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditDetalleRecibo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            If ModoFrm = "UPD" Then
                CargarReciboDetalle()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Detalle Recibo"
            Else
                Me.Text = "Modificar Detalle Recibo"
            End If

            ObjReciboDetalledt = New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDetalleDataTable
            ObjReciboDetalledr = New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDetalleRow

            'Obtener los Datos de los combos
            XdsReciboDetalle = New BOSistema.Win.XDataSet

            'Limpiar los combos
            Me.cnePrincipal.Value = 0
            Me.cneMantenimientoValor.Value = 0
            Me.cneInteresesCorrientes.Value = 0
            Me.cneInteresesMoratorios.Value = 0
            Me.cneSaldoActual.Value = 0

            If ModoFrm = "ADD" Then

                ObjReciboDetalledr = ObjReciboDetalledt.NewRow

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarOtroCredito
    ' Descripción:          Este procedimiento permite cargar los Datos de 
    '                       Otro Crédito asociado anteriormente a la Ficha.
    '-------------------------------------------------------------------------
    Private Sub CargarReciboDetalle()
        Try
            Dim strSQL As String = ""

            '-- Buscar el Otro Crédito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjReciboDetalledt.Filter = "nSccReciboOficialCajaDetalleID = " & Me.intReciboOficialCajaDetalleID
            ObjReciboDetalledt.Retrieve()
            If ObjReciboDetalledt.Count = 0 Then
                Exit Sub
            End If
            ObjReciboDetalledr = ObjReciboDetalledt.Current

            'Número de la Cuota
            If Not ObjReciboDetalledr.IsFieldNull("nNumeroCuota") Then
                Me.txtNumCuota.Text = ObjReciboDetalledr.nNumeroCuota
            Else
                Me.txtNumCuota.Text = ""
            End If

            'Monto Principal
            If Not ObjReciboDetalledr.IsFieldNull("nPrincipal") Then
                Me.cnePrincipal.Value = ObjReciboDetalledr.nPrincipal
            Else
                Me.cnePrincipal.Value = 0
            End If

            'Mantenimiento Valor
            If Not ObjReciboDetalledr.IsFieldNull("nMantenimientoValor") Then
                Me.cneMantenimientoValor.Value = ObjReciboDetalledr.nMantenimientoValor
            Else
                Me.cneMantenimientoValor.Value = 0
            End If

            'Intereses Corrientes
            If Not ObjReciboDetalledr.IsFieldNull("nInteresesCorrientes") Then
                Me.cneInteresesCorrientes.Value = ObjReciboDetalledr.nInteresesCorrientes
            Else
                Me.cneInteresesCorrientes.Value = 0
            End If

            'Intereses Moratorios
            If Not ObjReciboDetalledr.IsFieldNull("nInteresesMoratorios") Then
                Me.cneInteresesMoratorios.Value = ObjReciboDetalledr.nInteresesMoratorios
            Else
                Me.cneInteresesMoratorios.Value = 0
            End If

            'Saldo Actual
            If Not ObjReciboDetalledr.IsFieldNull("nSaldoActual") Then
                Me.cneSaldoActual.Value = ObjReciboDetalledr.nSaldoActual
            Else
                Me.cneSaldoActual.Value = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarReciboDetalle()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Número de Cuota
            If Trim(RTrim(Me.txtNumCuota.Text)).ToString.Length = 0 Then
                MsgBox("El Número de Cuota NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNumCuota, "El Número de Cuota NO DEBE quedar vacío.")
                Me.txtNumCuota.Focus()
                Exit Function
            End If

            'Interés Moratorio
            If Me.cneInteresesMoratorios.ValueIsDbNull Then
                MsgBox("El Interés Moratorio NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cneInteresesMoratorios, "El Interés Moratorio NO DEBE quedar vacío.")
                Me.cneInteresesMoratorios.Focus()
                Exit Function
            End If

            'Interés Corriente
            If Me.cneInteresesCorrientes.ValueIsDbNull Then
                MsgBox("El Interés Corriente NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cneInteresesCorrientes, "El Interés Corriente NO DEBE quedar vacío.")
                Me.cneInteresesCorrientes.Focus()
                Exit Function
            End If

            'Mantenimiento Valor
            If Me.cneMantenimientoValor.ValueIsDbNull Then
                MsgBox("El Mantenimiento al Valor NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cneMantenimientoValor, "El Mantenimiento al Valor NO DEBE quedar vacío.")
                Me.cneMantenimientoValor.Focus()
                Exit Function
            End If

            'Principal
            If Me.cnePrincipal.ValueIsDbNull Then
                MsgBox("El Principal NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cnePrincipal, "El Principal NO DEBE quedar vacío.")
                Me.cnePrincipal.Focus()
                Exit Function
            End If

            'Saldo
            If Me.cneSaldoActual.ValueIsDbNull Then
                MsgBox("El Saldo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cneSaldoActual, "El Saldo NO DEBE quedar vacío.")
                Me.cneSaldoActual.Focus()
                Exit Function
            End If

            'Total Pagado
            If CDbl(Me.txtTotalPagado.Text) = 0 Then
                MsgBox("El Total Pagado NO DEBE ser Cero (0).", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cnePrincipal, "El Total Pagado NO DEBE ser Cero (0).")
                Me.cnePrincipal.Focus()
                Exit Function
            End If

            strSQL = " SELECT nValor FROM SccReciboOficialCaja " & _
                     " WHERE nSccReciboOficialCajaID = " & Me.intSccReciboOficialCajaID

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                'Total Pagado Vs Valor del Recibo
                If (CDbl(Me.txtTotalPagado.Text) > XdtDatos.ValueField("nValor") + 0.01) Or (CDbl(Me.txtTotalPagado.Text) < XdtDatos.ValueField("nValor") - 0.01) Then
                    MsgBox("El Total Pagado NO DEBE ser Diferente al Valor del Recibo.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errRecibo.SetError(Me.cnePrincipal, "El Total Pagado NO DEBE ser Diferente al Valor del Recibo.")
                    Me.cnePrincipal.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarReciboDetalle
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Comprobante en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReciboDetalle()
        Try
            If ModoFrm = "ADD" Then
                ObjReciboDetalledr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjReciboDetalledr.dFechaCreacion = FechaServer()
            Else
                ObjReciboDetalledr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjReciboDetalledr.dFechaModificacion = FechaServer()
            End If

            ObjReciboDetalledr.nSccReciboOficialCajaID = Me.intSccReciboOficialCajaID
            ObjReciboDetalledr.nPrincipal = Me.cnePrincipal.Value
            ObjReciboDetalledr.nMantenimientoValor = Me.cneMantenimientoValor.Value
            ObjReciboDetalledr.nNumeroCuota = Me.txtNumCuota.Text
            ObjReciboDetalledr.nInteresesCorrientes = Me.cneInteresesCorrientes.Value
            ObjReciboDetalledr.nInteresesMoratorios = Me.cneInteresesMoratorios.Value
            ObjReciboDetalledr.nSaldoActual = Me.cneSaldoActual.Value

            ObjReciboDetalledr.Update()

            'Asignar el Id del Comprobante a la 
            'variable publica del formulario
            Me.intReciboOficialCajaDetalleID = ObjReciboDetalledr.nSccReciboOficialCajaDetalleID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
                            SalvarReciboDetalle()
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

    Private Sub cnePrincipal_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cnePrincipal.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMantenimientoValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMantenimientoValor.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneInteresesCorrientes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneInteresesCorrientes.TextChanged
        vbModifico = True
    End Sub

    Private Sub cnePrincipal_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cnePrincipal.ValueChanged
        If (Not Me.cnePrincipal.ValueIsDbNull) And (Not Me.cneMantenimientoValor.ValueIsDbNull) And (Not Me.cneInteresesCorrientes.ValueIsDbNull) And (Not Me.cneInteresesMoratorios.ValueIsDbNull) Then
            Me.txtTotalPagado.Text = Format(Me.cnePrincipal.Value + Me.cneMantenimientoValor.Value + Me.cneInteresesCorrientes.Value + Me.cneInteresesMoratorios.Value, "C$ #,##0.00")
        End If
    End Sub

    Private Sub cneMantenimientoValor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneMantenimientoValor.ValueChanged
        If (Not Me.cnePrincipal.ValueIsDbNull) And (Not Me.cneMantenimientoValor.ValueIsDbNull) And (Not Me.cneInteresesCorrientes.ValueIsDbNull) And (Not Me.cneInteresesMoratorios.ValueIsDbNull) Then
            Me.txtTotalPagado.Text = Format(Me.cnePrincipal.Value + Me.cneMantenimientoValor.Value + Me.cneInteresesCorrientes.Value + Me.cneInteresesMoratorios.Value, "C$ #,##0.00")
        End If
    End Sub

    Private Sub cneInteresesCorrientes_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneInteresesCorrientes.ValueChanged
        If (Not Me.cnePrincipal.ValueIsDbNull) And (Not Me.cneMantenimientoValor.ValueIsDbNull) And (Not Me.cneInteresesCorrientes.ValueIsDbNull) And (Not Me.cneInteresesMoratorios.ValueIsDbNull) Then
            Me.txtTotalPagado.Text = Format(Me.cnePrincipal.Value + Me.cneMantenimientoValor.Value + Me.cneInteresesCorrientes.Value + Me.cneInteresesMoratorios.Value, "C$ #,##0.00")
        End If
    End Sub

    Private Sub cneInteresesMoratorios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneInteresesMoratorios.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneInteresesMoratorios_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneInteresesMoratorios.ValueChanged
        If (Not Me.cnePrincipal.ValueIsDbNull) And (Not Me.cneMantenimientoValor.ValueIsDbNull) And (Not Me.cneInteresesCorrientes.ValueIsDbNull) And (Not Me.cneInteresesMoratorios.ValueIsDbNull) Then
            Me.txtTotalPagado.Text = Format(Me.cnePrincipal.Value + Me.cneMantenimientoValor.Value + Me.cneInteresesCorrientes.Value + Me.cneInteresesMoratorios.Value, "C$ #,##0.00")
        End If
    End Sub

    Private Sub txtNumCuota_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumCuota.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNumCuota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNumCuota.TextChanged
        vbModifico = True
    End Sub
End Class