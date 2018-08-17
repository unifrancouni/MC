' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                23/03/2010
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditChequeAnulado.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Cheques Anulados.
'-------------------------------------------------------------------------
Public Class frmSteEditChequeAnulado

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteCheque As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsCuenta As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjChequedt As BOSistema.Win.SccEntCredito.SteChequeAnuladoDataTable
    Dim ObjChequedr As BOSistema.Win.SccEntCredito.SteChequeAnuladoRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Cheque.
    Public Property IdCheque() As Integer
        Get
            IdCheque = IdSteCheque
        End Get
        Set(ByVal value As Integer)
            IdSteCheque = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       frmSteEditChequeAnulado_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditChequeAnulado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjChequedt.Close()
                ObjChequedt = Nothing

                ObjChequedr.Close()
                ObjChequedr = Nothing

                XdsCuenta.Close()
                XdsCuenta = Nothing
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
    ' Fecha:                23/03/2010
    ' Procedure Name:       frmSteEditChequeAnulado_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Minuta.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditChequeAnulado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarCuenta(0)
            CargarTipoPrograma()

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoForm = "UPD" Or ModoForm = "DEL" Then
                CargarChequeAnulado()
            Else
                Me.cboCuenta.Select()
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Cheque Anulado"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Cheque Anulado"
                Me.cboCuenta.Enabled = False
                Me.cboTipoPrograma.Enabled = False
            Else
                Me.Text = "Eliminar Cheques Anulados"
                Me.cboCuenta.Enabled = False
                Me.cboTipoPrograma.Enabled = False
                Me.cdeFechaCheque.Enabled = False
                Me.txtObservaciones.Enabled = False
            End If

            ObjChequedt = New BOSistema.Win.SccEntCredito.SteChequeAnuladoDataTable
            ObjChequedr = New BOSistema.Win.SccEntCredito.SteChequeAnuladoRow
            XdsCuenta = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboCuenta.ClearFields()
            Me.cboTipoPrograma.ClearFields()

            If ModoForm = "ADD" Then
                ObjChequedr = ObjChequedt.NewRow
                Me.txtObservaciones.MaxLength = ObjChequedr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       CargarChequeAnulado
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Cheque en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarChequeAnulado()
        Try

            '-- Buscar el recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjChequedt.Filter = "nSteChequeAnuladoID = " & IdCheque
            ObjChequedt.Retrieve()
            If ObjChequedt.Count = 0 Then
                Exit Sub
            End If
            ObjChequedr = ObjChequedt.Current

            'Cuenta:
            If Not ObjChequedr.IsFieldNull("nSteCuentaBancariaID") Then
                CargarCuenta(ObjChequedr.nSteCuentaBancariaID)
                If Me.cboCuenta.ListCount > 0 Then
                    Me.cboCuenta.SelectedIndex = 0
                End If
                XdsCuenta("Cuenta").SetCurrentByID("nSteCuentaBancariaID", ObjChequedr.nSteCuentaBancariaID)
            Else
                Me.cboCuenta.Text = ""
                Me.cboCuenta.SelectedIndex = -1
            End If

            'Cargar Tipo de Programa:
            If Not ObjChequedr.IsFieldNull("nStbTipoProgramaID") Then
                CargarTipoPrograma()
                If Me.cboTipoPrograma.ListCount > 0 Then
                    Me.cboTipoPrograma.SelectedIndex = 0
                End If
                XdsCuenta("TipoPrograma").SetCurrentByID("nStbValorCatalogoID", ObjChequedr.nStbTipoProgramaID)
            Else
                Me.cboTipoPrograma.Text = ""
                Me.cboTipoPrograma.SelectedIndex = -1
            End If

            'Número de Cheque:
            If Not ObjChequedr.IsFieldNull("nNumeroCheque") Then
                Me.txtNoCheque.Text = ObjChequedr.nNumeroCheque
                Me.txtHastaCheque.Text = ObjChequedr.nNumeroCheque
            Else
                Me.txtNoCheque.Text = ""
                Me.txtHastaCheque.Text = ""
            End If

            'Fecha de Cheque:
            If Not ObjChequedr.IsFieldNull("dFechaCheque") Then
                Me.cdeFechaCheque.Value = ObjChequedr.dFechaCheque
            Else
                Me.cdeFechaCheque.Value = FechaServer()
            End If

            'Observaciones:
            If Not ObjChequedr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjChequedr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjChequedr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarChequeAnulado()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errCheque.Clear()

            'Cuenta:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta Bancaria válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta Bancaria válida.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'Tipo de Programa:
            If Me.cboTipoPrograma.SelectedIndex = -1 Then
                MsgBox("Debe indicar el Tipo de Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.cboTipoPrograma, "Debe indicar el Tipo de Programa.")
                Me.cboTipoPrograma.Focus()
                Exit Function
            End If

            'Fecha de Cheque:
            If Me.cdeFechaCheque.ValueIsDbNull Then
                MsgBox("La Fecha del Cheque NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE quedar vacía.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha Cheque no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Cheque NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Fecha Cheque no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Cheque NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.cdeFechaCheque, "La Fecha del Cheque NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCheque.Focus()
                Exit Function
            End If

            'Número Cheque Inicial: 
            If Trim(RTrim(Me.txtNoCheque.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Cheque NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.txtNoCheque, "El Número del Cheque NO DEBE quedar vacío.")
                Me.txtNoCheque.Focus()
                Exit Function
            End If

            'Número Cheque Final: 
            If Trim(RTrim(Me.txtHastaCheque.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Cheque Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.txtHastaCheque, "El Número del Cheque Final NO DEBE quedar vacío.")
                Me.txtHastaCheque.Focus()
                Exit Function
            End If

            'Número de Cheque (Hasta) mayor: 
            If CInt(Me.txtHastaCheque.Text) < CInt(Me.txtNoCheque.Text) Then
                MsgBox("El No. del Cheque Final NO DEBE ser Menor que el No. del Cheque Inicial.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCheque.SetError(Me.txtHastaCheque, "El No. del Cheque Final NO DEBE ser Menor que el No. del Cheque Inicial.")
                Me.txtHastaCheque.Focus()
                Exit Function
            End If

            'En caso de Adición:
            If ModoForm = "ADD" Then
                'El Número del Cheque ANULADO no debe de repetirse dentro de una misma 
                'Cuenta Bancaria y Programa. 
                strSQL = "SELECT SteChequeAnulado.* FROM SteChequeAnulado " & _
                         "WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque between " & Trim(RTrim(Me.txtNoCheque.Text)) & " and " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("El(los) Cheque(s) Anulado(s) ya se ha(n) registrado" & Chr(13) & "en esta Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errCheque.SetError(Me.txtNoCheque, "Existen Cheques Anulados en la Cuenta.")
                    Me.txtNoCheque.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                'El Código del Cheque no debe estar Contenido como Comprobante de Cheque Mayorizado:
                strSQL = " SELECT sNumeroTransaccion " &
                         " FROM  (SELECT ScnTransaccionContable.sNumeroTransaccion, SteCuentaBancaria.sNumeroCuenta,  " &
                         "        LEN(ScnTransaccionContable.sNumeroTransaccion) AS Ln " &
                         "        FROM ScnTransaccionContable INNER JOIN StbValorCatalogo ON ScnTransaccionContable.nStbEstadoTransaccionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnTransaccionContableDetalle ON ScnTransaccionContable.nScnTransaccionContableID = ScnTransaccionContableDetalle.nScnTransaccionContableID " &
                         "        INNER JOIN ScnCatalogoContable ON ScnTransaccionContableDetalle.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID INNER JOIN SteCuentaBancaria ON ScnCatalogoContable.nSteCuentaBancariaID = SteCuentaBancaria.nSteCuentaBancariaID " &
                         "        WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SteCuentaBancaria.nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " &
                         "       ) AS b " &
                         " WHERE (CAST(SUBSTRING(sNumeroTransaccion, " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) & " + 1, " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) + Len(Me.txtNoCheque.Text) & "- " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) & ") AS int) BETWEEN " & Trim(RTrim(Me.txtNoCheque.Text)) & " AND " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                '" WHERE (CAST(SUBSTRING(sNumeroTransaccion, " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) & " + 1, Ln - " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) & ") AS int) BETWEEN " & Trim(RTrim(Me.txtNoCheque.Text)) & " AND " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                '" AND (CAST(SUBSTRING(ScnTransaccionContable.sNumeroTransaccion, " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) & " + 1, LEN(ScnTransaccionContable.sNumeroTransaccion) - " & Len(Me.cboCuenta.Columns("sNumeroCuenta").Value) & ") AS int) BETWEEN " & Trim(RTrim(Me.txtNoCheque.Text)) & " AND " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Cheque(s) existe(n) en un Comprobante Contable ACTIVO.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errCheque.SetError(Me.txtNoCheque, "Cheques existen en un Comprobante ACTIVO.")
                    Me.txtNoCheque.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            Else 'Edición / Eliminar Rangos:
                '-- El(los) Cheque(s) deben estar contenidos como Anulados dentro de la Cuenta:
                strSQL = "Select * From SteChequeAnulado " & _
                         "WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque BETWEEN " & Trim(RTrim(Me.txtNoCheque.Text)) & " AND " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("No existen Cheques Anulados con los Códigos" & Chr(13) & "indicados en la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errCheque.SetError(Me.txtHastaCheque, "No existen Cheques Anulados con los Códigos indicados.")
                    Me.txtHastaCheque.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                '-- Codigo Inicial debe existir en la Cuenta:
                strSQL = "Select * From SteChequeAnulado " & _
                         "WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque = " & Trim(RTrim(Me.txtNoCheque.Text)) & ")"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Cheque Inicial No existe en la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errCheque.SetError(Me.txtNoCheque, "El Cheque Inicial No existe en la Cuenta Bancaria.")
                    Me.txtNoCheque.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                '-- Codigo Final debe existir en la Cuenta:
                strSQL = "Select * From SteChequeAnulado " & _
                         "WHERE (nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque = " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Cheque Final No existe en la Cuenta Bancaria.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errCheque.SetError(Me.txtHastaCheque, "El Cheque Final No existe en la Cuenta Bancaria.")
                    Me.txtHastaCheque.Focus()
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
    ' Fecha:                23/03/2010
    ' Procedure Name:       InsertarCheques
    ' Descripción:          Este procedimiento permite insertar Cheques 
    '                       en el Rango. 
    '-------------------------------------------------------------------------
    Private Sub InsertarCheques()
        Dim Trans As BOSistema.Win.Transact
        Dim XcDatos As New BOSistema.Win.XComando
        Trans = Nothing

        Try
            Dim StrSql As String
            Dim intChequeD As Integer
            Dim intChequeH As Integer

            intChequeD = Trim(RTrim(Me.txtNoCheque.Text))
            intChequeH = Trim(RTrim(Me.txtHastaCheque.Text))

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transacción:
            Trans.BeginTrans()

            For i As Integer = intChequeD To intChequeH
                '---------------------------
                'Insertar Cheque:
                StrSql = "Insert Into SteChequeAnulado " & _
                         "(nUsuarioCreacionID, dFechaCreacion, nNumeroCheque, nSteCuentaBancariaID, nStbTipoProgramaID, sObservaciones, dFechaCheque) " & _
                         " Values (" & InfoSistema.IDCuenta & ", getdate(), " & i & _
                         ", " & XdsCuenta("Cuenta").ValueField("nSteCuentaBancariaID") & _
                         ", " & XdsCuenta("TipoPrograma").ValueField("nStbValorCatalogoID") & ", '" & _
                         Trim(RTrim(Me.txtObservaciones.Text)) & "', '" & Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") & "')"
                Trans.ExecuteSql(StrSql)
                '---------------------------
            Next

            '-- Finaliza Transacción:
            Trans.Commit()

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       SalvarChequeAnulado
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarChequeAnulado()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'En caso de Adición:
            If ModoForm = "ADD" Then
                InsertarCheques()
            ElseIf ModoForm = "UPD" Then 'Edición: 
                strSQL = "Update SteChequeAnulado " & _
                         "SET sObservaciones = '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', " & _
                         "    nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", " & _
                         "    dFechaCheque = '" & Format(Me.cdeFechaCheque.Value, "yyyy-MM-dd") & "', " & _
                         "    dFechaModificacion = getdate() " & _
                         "WHERE (nSteCuentaBancariaID = " & Me.cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque BETWEEN " & Trim(RTrim(Me.txtNoCheque.Text)) & " AND " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                XcDatos.ExecuteNonQuery(strSQL)
            Else
                strSQL = "Delete From SteChequeAnulado " & _
                         "WHERE (nSteCuentaBancariaID = " & Me.cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque BETWEEN " & Trim(RTrim(Me.txtNoCheque.Text)) & " AND " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                XcDatos.ExecuteNonQuery(strSQL)
            End If

            'Localizar número de Cheque:
            If ModoForm <> "DEL" Then
                strSQL = "SELECT nSteChequeAnuladoID FROM SteChequeAnulado " & _
                         "WHERE (nSteCuentaBancariaID = " & Me.cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                         "AND (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nNumeroCheque = " & Trim(RTrim(Me.txtHastaCheque.Text)) & ")"
                Me.IdSteCheque = XcDatos.ExecuteScalar(strSQL)
                '--------------------------------

                '-- Buscar el Cheque correspondiente al Id especificado
                '-- como parámetro, en los casos que se esté editando.
                ObjChequedt.Filter = "nSteChequeAnuladoID = " & Me.IdSteCheque
                ObjChequedt.Retrieve()
                If ObjChequedt.Count = 0 Then
                    Exit Sub
                End If
                ObjChequedr = ObjChequedt.Current

                'Si el salvado se realizó de forma satisfactoria
                'enviar mensaje informando y cerrar el formulario.
                If Me.IdSteCheque = 0 Then
                    MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
                End If
            Else
                MsgBox("Los Cheques indicados han sido Eliminados.", MsgBoxStyle.Information, NombreSistema)
            End If
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
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
                            SalvarChequeAnulado()
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
                        Me.IdCheque = 0
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.IdCheque = 0
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/04/2010
    ' Procedure Name:       CargarTipoPrograma
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tipos de Programas.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPrograma()
        Try
            Dim Strsql As String = ""

            'Limpiar Combo:
            Me.cboTipoPrograma.ClearFields()

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'TipoDePrograma') " & _
                     " ORDER BY a.sCodigoInterno"

            If XdsCuenta.ExistTable("TipoPrograma") Then
                XdsCuenta("TipoPrograma").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "TipoPrograma")
                XdsCuenta("TipoPrograma").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTipoPrograma.DataSource = XdsCuenta("TipoPrograma").Source
            Me.cboTipoPrograma.Rebind()

            'Configurar el combo:
            Me.cboTipoPrograma.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPrograma.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboTipoPrograma.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboTipoPrograma.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboTipoPrograma.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPrograma.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPrograma.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPrograma.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/03/2010
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de Cuentas
    '                       Bancarias en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarCuenta(ByVal intCuentaID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If intCuentaID = 0 Then
                Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sInstitucionBancaria " & _
                         " From vwSteCtaBancaria a " & _
                         " WHERE (a.nCerrada = 0)" & _
                         " Order by a.sNumeroCuenta Asc"
            Else
                Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sInstitucionBancaria " & _
                         " From vwSteCtaBancaria a " & _
                         " WHERE (a.nCerrada = 0) or (a.nSteCuentaBancariaID = " & intCuentaID & ")" & _
                         " Order by a.sNumeroCuenta Asc"
            End If

            If XdsCuenta.ExistTable("Cuenta") Then
                XdsCuenta("Cuenta").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "Cuenta")
                XdsCuenta("Cuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCuenta.DataSource = XdsCuenta("Cuenta").Source
            Me.cboCuenta.Rebind()

            'Buscar Cuenta Bancaria predeterminada en Parámetros:
            XdtValorParametro.Filter = "nStbParametroID = 68"
            XdtValorParametro.Retrieve()
            'Ubicarse en el primer registro:
            If XdsCuenta("Cuenta").Count > 0 Then
                XdsCuenta("Cuenta").SetCurrentByID("nSteCuentaBancariaID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo
            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 160
            Me.cboCuenta.Splits(0).DisplayColumns("sInstitucionBancaria").Width = 160

            Me.cboCuenta.Columns("sNumeroCuenta").Caption = "No. Cuenta Bancaria"
            Me.cboCuenta.Columns("sInstitucionBancaria").Caption = "Nombre del Banco"

            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sInstitucionBancaria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    'Se indica que hubo modificación en la Fecha de Depósito:
    Private Sub cdeFechaCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCheque.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoCheque.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNoCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoCheque.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtHastaCheque_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaCheque.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtHastaCheque_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHastaCheque.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboCuenta_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCuenta.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub
End Class