' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                25/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditReciboAnulado.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Recibos Anulados.
'-------------------------------------------------------------------------
Public Class frmSteEditReciboAnulado

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteRecibo As Integer
    Dim IdSteDepartamento As Integer
    Dim nCodigoTalonario As Integer
    Dim nIdMunicipio As String

    '-- Clases para procesar la informacion de los combos
    Dim XdsCuenta As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjRecibodt As BOSistema.Win.SteEntArqueo.SteReciboAnuladoDataTable
    Dim ObjRecibodr As BOSistema.Win.SteEntArqueo.SteReciboAnuladoRow

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

    'Propiedad utilizada para obtener el ID del Recibo.
    Public Property IdRecibo() As Integer
        Get
            IdRecibo = IdSteRecibo
        End Get
        Set(ByVal value As Integer)
            IdSteRecibo = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Departamento.
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = IdSteDepartamento
        End Get
        Set(ByVal value As Integer)
            IdSteDepartamento = value
        End Set
    End Property


    'Propiedad utilizada para obtener el ID del Municipio.
    Public Property IdMunicipio() As String
        Get
            IdMunicipio = nIdMunicipio
        End Get
        Set(ByVal value As String)
            nIdMunicipio = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       frmSteEditReciboAnulado_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboAnulado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjRecibodt.Close()
                ObjRecibodt = Nothing

                ObjRecibodr.Close()
                ObjRecibodr = Nothing

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
    ' Fecha:                25/07/2008
    ' Procedure Name:       frmSteEditReciboAnulado_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Minuta.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboAnulado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarCajero(0)
            CargarDepartamento(0)
            CargarTipoPrograma()
            CargarTipoPlazoPagos()

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoFrm = "UPD" Or ModoFrm = "DEL" Then
                CargarReciboAnulado()
            Else
                Me.cboCajero.Select()
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
    ' Fecha:                25/07/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Recibo de Caja Anulado"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Recibo de Caja Anulado"
                REM Se debe bloquear sino en la edición podrian dañarse los datos de recibos  
                REM del otro Programa en caso de error deberá eliminarse y volver a ingresar.
                Me.cboTipoPrograma.Enabled = False
                Me.cboTipoPlazoPagos.Enabled = False
                REM Bloquear pues en caso de cambio de Fecha puede dañarse la secuencia de codigo 
                REM del(talonario).
                Me.cdeFechaRecibo.Enabled = False
            Else
                Me.Text = "Eliminar Recibos de Caja Anulados"
                Me.cboCajero.Enabled = False
                Me.cboDepartamento.Enabled = False
                Me.cboTipoPrograma.Enabled = False
                Me.cboTipoPlazoPagos.Enabled = False
                Me.cdeFechaRecibo.Enabled = False
                Me.cneMonto.Enabled = False
                Me.txtObservaciones.Enabled = False
            End If

            ObjRecibodt = New BOSistema.Win.SteEntArqueo.SteReciboAnuladoDataTable
            ObjRecibodr = New BOSistema.Win.SteEntArqueo.SteReciboAnuladoRow
            XdsCuenta = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboCajero.ClearFields()
            Me.cboDepartamento.ClearFields()
            Me.cboTipoPrograma.ClearFields()
            Me.cboTipoPlazoPagos.ClearFields()
            Me.cneMonto.Value = 0

            If Me.IdSteDepartamento = 17 Then
                cbAplicaMunicipioAlterno.Visible = True
            End If

            If ModoForm = "ADD" Then
                ObjRecibodr = ObjRecibodt.NewRow
                Me.txtObservaciones.MaxLength = ObjRecibodr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       CargarReciboAnulado
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Recibo en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarReciboAnulado()
        Try

            '-- Buscar el recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjRecibodt.Filter = "nSteReciboAnuladoID = " & IdRecibo
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current

            'Cajero:
            If Not ObjRecibodr.IsFieldNull("nSrhCajeroId") Then
                CargarCajero(ObjRecibodr.nSrhCajeroId)
                If Me.cboCajero.ListCount > 0 Then
                    Me.cboCajero.SelectedIndex = 0
                End If
                XdsCuenta("Cajero").SetCurrentByID("nSrhEmpleadoID", ObjRecibodr.nSrhCajeroId)
            Else
                Me.cboCajero.Text = ""
                Me.cboCajero.SelectedIndex = -1
            End If

            'Departamento:
            If Not ObjRecibodr.IsFieldNull("nStbDepartamentoID") Then
                CargarDepartamento(ObjRecibodr.nStbDepartamentoId)
                If Me.cboDepartamento.ListCount > 0 Then
                    Me.cboDepartamento.SelectedIndex = 0
                End If
                XdsCuenta("Departamento").SetCurrentByID("nStbDepartamentoID", ObjRecibodr.nStbDepartamentoId)
            Else
                Me.cboDepartamento.Text = ""
                Me.cboDepartamento.SelectedIndex = -1
            End If

            'Cargar Tipo de Programa:
            If Not ObjRecibodr.IsFieldNull("nStbTipoProgramaID") Then
                CargarTipoPrograma()
                If Me.cboTipoPrograma.ListCount > 0 Then
                    Me.cboTipoPrograma.SelectedIndex = 0
                End If
                XdsCuenta("TipoPrograma").SetCurrentByID("nStbValorCatalogoID", ObjRecibodr.nStbTipoProgramaID)
            Else
                Me.cboTipoPrograma.Text = ""
                Me.cboTipoPrograma.SelectedIndex = -1
            End If

            'Tipo Plazo Pagos Socias:
            If Not ObjRecibodr.IsFieldNull("nStbTipoPlazoPagosID") Then
                CargarTipoPlazoPagos()
                If Me.cboTipoPlazoPagos.ListCount > 0 Then
                    Me.cboTipoPlazoPagos.SelectedIndex = 0
                End If
                XdsCuenta("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", ObjRecibodr.nStbTipoPlazoPagosID)
            Else
                Me.cboTipoPlazoPagos.Text = ""
                Me.cboTipoPlazoPagos.SelectedIndex = -1
            End If

            'Número de Recibo:
            If Not ObjRecibodr.IsFieldNull("nCodigo") Then
                Me.txtNoRecibo.Text = ObjRecibodr.nCodigo
                Me.txtHastaRecibo.Text = ObjRecibodr.nCodigo
            Else
                Me.txtNoRecibo.Text = ""
                Me.txtHastaRecibo.Text = ""
            End If

            'Fecha de Recibo:
            If Not ObjRecibodr.IsFieldNull("dFechaRecibo") Then
                Me.cdeFechaRecibo.Value = ObjRecibodr.dFechaRecibo
            Else
                Me.cdeFechaRecibo.Value = FechaServer()
            End If

            'Monto del Recibo:
            If Not ObjRecibodr.IsFieldNull("nValor") Then
                Me.cneMonto.Value = ObjRecibodr.nValor
            Else
                Me.cneMonto.Value = 0
            End If

            'Observaciones:
            If Not ObjRecibodr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjRecibodr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'cbAplicaMunicipioAlterno:
            'If Me.IdSteDepartamento = 17 Then
            If Not ObjRecibodr.IsFieldNull("nStbMunicipioID") Then
                If ObjRecibodr.nStbMunicipioID > 0 Then
                    Me.cbAplicaMunicipioAlterno.Checked = True
                End If
            Else
                Me.cbAplicaMunicipioAlterno.Checked = False
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjRecibodr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarReciboAnulado()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Cajero:
            If Me.cboCajero.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Cajero válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                Me.cboCajero.Focus()
                Exit Function
            End If

            'Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Tipo de Programa:
            If Me.cboTipoPrograma.SelectedIndex = -1 Then
                MsgBox("Debe indicar el Tipo de Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboTipoPrograma, "Debe indicar el Tipo de Programa.")
                Me.cboTipoPrograma.Focus()
                Exit Function
            End If

            'Plazo de periodicidad de pagos:
            If Me.cboTipoPlazoPagos.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo para Pagos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                Me.cboTipoPlazoPagos.Focus()
                Exit Function
            End If

            'El Plazo debe existir dentro del Programa seleccionado:
            strSQL = "SELECT nStbTipoProgramaID FROM SclTipodePlandeNegocio " & _
                     "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe esta Periodicidad de Pagos en el Tipo de Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboTipoPlazoPagos, "Tipo de Plazo para Pagos inválido.")
                Me.cboTipoPlazoPagos.Focus()
                Exit Function
            End If

            'Fecha de Recibo:
            If Me.cdeFechaRecibo.ValueIsDbNull Then
                MsgBox("La Fecha del Recibo NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaRecibo, "La Fecha del Recibo NO DEBE quedar vacía.")
                Me.cdeFechaRecibo.Focus()
                Exit Function
            End If

            'Fecha Recibo no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaRecibo.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Recibo NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaRecibo, "La Fecha del Recibo NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaRecibo.Focus()
                Exit Function
            End If

            'Fecha Recibo no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaRecibo.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Recibo NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaRecibo, "La Fecha del Recibo NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaRecibo.Focus()
                Exit Function
            End If

            nCodigoTalonario = IntCodigoTalonario(Format(Me.cdeFechaRecibo.Value, "yyyy-MM-dd"))

            'Número Recibo Inicial: 
            If Trim(RTrim(Me.txtNoRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoRecibo, "El Número del Recibo NO DEBE quedar vacío.")
                Me.txtNoRecibo.Focus()
                Exit Function
            End If

            'Número Recibo Final: 
            If Trim(RTrim(Me.txtHastaRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtHastaRecibo, "El Número del Recibo Final NO DEBE quedar vacío.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'Número de Recibo (Hasta) mayor: 
            If CInt(Me.txtHastaRecibo.Text) < CInt(Me.txtNoRecibo.Text) Then
                MsgBox("El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo Inicial.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtHastaRecibo, "El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo Inicial.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then

                Dim XdtValor As New BOSistema.Win.XComando
                Dim nMunicipio As String

                'Dim nMunicipio As Integer
                'Obtener la fecha del enredo talonario manual 3 1ro de diciembre del 2014
                strSQL = " SELECT        sValorParametro" & _
                " FROM dbo.StbValorParametro" & _
                " WHERE (nStbParametroID = 117) "

                nMunicipio = XdtValor.ExecuteScalar(strSQL)
                Me.nIdMunicipio = nMunicipio
            End If
            'En caso de Adición:
            If ModoForm = "ADD" Then
                'El Código del Recibo ANULADO no debe de repetirse dentro de un mismo 
                'Departamento, Programa y Plazo así como Código de Talonario acorde a la fecha del recibo:
                strSQL = "SELECT SteReciboAnulado.* FROM SteReciboAnulado " & _
                         "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                         "AND (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") AND (nCodigo between " & Trim(RTrim(Me.txtNoRecibo.Text)) & " and " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then

                    strSQL = strSQL & " AND  (nStbMunicipioID = " & Me.IdMunicipio & ")"
                End If
                If RegistrosAsociados(strSQL) Then
                    MsgBox("El(los) Recibo(s) Anulado(s) ya se ha(n) registrado" & Chr(13) & "en este Departamento, Programa y Periodicidad.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtNoRecibo, "Existen Recibos Anulados en el Departamento y Programa.")
                    Me.txtNoRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            Else 'Edición / Eliminar Rangos:
                '-- El(los) Recibo(s) deben estar contenidos como Anulados dentro del Departamento, Programa y Periodicidad de Pagos:
                strSQL = "Select * From SteReciboAnulado " & _
                         "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                         "AND (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") " & _
                         "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNoRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then

                    strSQL = strSQL & " AND  (nStbMunicipioID = " & Me.IdMunicipio & ")"
                End If

                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("No existen Recibos Anulados con los Códigos" & Chr(13) & "indicados en el Departamento, Programa," & Chr(13) & "Periodicidad y Secuencia de Talonario.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtHastaRecibo, "No existen Recibos Anulados con los Códigos indicados en el Departamento y Programa.")
                    Me.txtHastaRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                '-- Codigo Inicial debe existir en el Departamento, Programa y Periodicidad:
                strSQL = "Select * From SteReciboAnulado " & _
                         "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                         "AND (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") " & _
                         "AND (nCodigo = " & Trim(RTrim(Me.txtNoRecibo.Text)) & ")"
                If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then
                    strSQL = strSQL & " AND  (nStbMunicipioID = " & Me.IdMunicipio & ")"
                End If
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Recibo Inicial No existe en el Departamento y Programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtNoRecibo, "El Recibo Inicial No existe en el Departamento y Programa.")
                    Me.txtNoRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
                '-- Codigo Final debe existir en el Departamento, Programa y Periodicidad:
                strSQL = "Select * From SteReciboAnulado " & _
                         "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                         "AND (nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") " & _
                         "AND (nCodigo = " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"

                If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then
                    strSQL = strSQL & " AND  (nStbMunicipioID = " & Me.IdMunicipio & ")"
                End If

                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Recibo Final No existe en el Departamento y Programa.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtHastaRecibo, "El Recibo Final No existe en el Departamento y Programa.")
                    Me.txtHastaRecibo.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            End If

            'El Código del Recibo no debe estar Contenido dentro de un Arqueo ACTIVO para el Depto
            'Tipo de programa y Periodicidad de Pagos de la Caja asi como codigo de talonario:
            strSQL = " SELECT AC.nCodigo " & _
                     " FROM dbo.SteArqueoCaja AS AC INNER JOIN dbo.SteArqueoRecibo AS AR ON AC.nSteArqueoCajaID = AR.nSteArqueoCajaID INNER JOIN dbo.StbValorCatalogo AS C ON AC.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
                     " INNER JOIN dbo.SteCaja AS CA ON AC.nSteCajaID = CA.nSteCajaID INNER JOIN dbo.vwStbUbicacionGeografica AS U ON CA.nStbBarrioID = U.nStbBarrioID " & _
                     " WHERE (AR.nSccReciboOficialCajaID IS NULL) And (C.sCodigoInterno <> '3') " & _
                     " AND (U.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") " & _
                     " AND (CA.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                     " AND (CA.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     " AND (AR.nCodigo between " & Trim(RTrim(Me.txtNoRecibo.Text)) & " and " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") AND (C.sCodigoInterno <> '4') " & _
                     " AND (AR.nCodigoTalonario = " & nCodigoTalonario & ")"

            If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then
                strSQL = strSQL & " AND  (U.nStbMunicipioID  = " & Me.IdMunicipio & ")"
            End If

            If RegistrosAsociados(strSQL) Then
                MsgBox("Recibo(s) existe(n) en un Arqueo de Caja ACTIVO.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoRecibo, "Recibos existen en un Arqueo de Caja ACTIVO.")
                Me.txtNoRecibo.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'El Código del Recibo no debe estar Contenido dentro de un Recibo Oficial Activo para el Depto
            'y tipo de programa asociado a la Solicitud de Cheque del recibo.
            strSQL = " SELECT SccReciboOficialCaja.nSccReciboOficialCajaID " & _
                     " FROM SccReciboOficialCaja INNER JOIN dbo.StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " INNER JOIN vwSccDetalleCreditosPrograma ON SccReciboOficialCaja.nSccSolicitudChequeID = vwSccDetalleCreditosPrograma.nSccSolicitudChequeID " & _
                     " WHERE (nManual = 1) AND (SccReciboOficialCaja.nStbDepartamentoID = " & cboDepartamento.Columns("nStbDepartamentoID").Value & ") " & _
                     " AND (vwSccDetalleCreditosPrograma.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                     " AND (vwSccDetalleCreditosPrograma.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     " AND (StbValorCatalogo.sCodigoInterno <> '3') AND (SccReciboOficialCaja.nCodigo between " & Trim(RTrim(Me.txtNoRecibo.Text)) & " and " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " & _
                     " AND  (SccReciboOficialCaja.nCodigoTalonario = " & nCodigoTalonario & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe(n) Recibo(s) Oficial(es) de Caja ACTIVO con este Código.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoRecibo, "Existen Recibos Oficiales de Caja ACTIVO con este Código.")
                Me.txtNoRecibo.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Monto Recibo: 
            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/08/2008
    ' Procedure Name:       InsertarRecibos
    ' Descripción:          Este procedimiento permite insertar Recibos 
    '                       en el Rango. 
    '-------------------------------------------------------------------------
    Private Sub InsertarRecibos()
        Dim Trans As BOSistema.Win.Transact
        Dim XcDatos As New BOSistema.Win.XComando
        Trans = Nothing

        Try
            Dim StrSql As String
            Dim intReciboD As Integer
            Dim intReciboH As Integer

            intReciboD = Trim(RTrim(Me.txtNoRecibo.Text))
            intReciboH = Trim(RTrim(Me.txtHastaRecibo.Text))

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transacción:
            Trans.BeginTrans()

            For i As Integer = intReciboD To intReciboH

                If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then
                    StrSql = "Insert Into SteReciboAnulado " & _
                       "(nUsuarioCreacionID, dFechaCreacion, nCodigo, nSrhCajeroId, nStbDepartamentoId, nStbTipoProgramaID, nStbTipoPlazoPagosID, nValor, nCodigoTalonario, sObservaciones, dFechaRecibo, nStbMunicipioID) " & _
                       " Values (" & InfoSistema.IDCuenta & ", getdate(), " & i & _
                       ", " & XdsCuenta("Cajero").ValueField("nSrhEmpleadoID") & ", " & XdsCuenta("Departamento").ValueField("nStbDepartamentoId") & ", " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ", " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ", " & Me.cneMonto.Value & ", " & _
                       nCodigoTalonario & ", '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', '" & Format(Me.cdeFechaRecibo.Value, "yyyy-MM-dd") & "', " & Me.IdMunicipio & ")"

                Else
                    '---------------------------
                    'Insertar Recibo:
                    StrSql = "Insert Into SteReciboAnulado " & _
                             "(nUsuarioCreacionID, dFechaCreacion, nCodigo, nSrhCajeroId, nStbDepartamentoId, nStbTipoProgramaID, nStbTipoPlazoPagosID, nValor, nCodigoTalonario, sObservaciones, dFechaRecibo) " & _
                             " Values (" & InfoSistema.IDCuenta & ", getdate(), " & i & _
                             ", " & XdsCuenta("Cajero").ValueField("nSrhEmpleadoID") & ", " & XdsCuenta("Departamento").ValueField("nStbDepartamentoId") & ", " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ", " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ", " & Me.cneMonto.Value & ", " & _
                             nCodigoTalonario & ", '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', '" & Format(Me.cdeFechaRecibo.Value, "yyyy-MM-dd") & "')"

                End If
                Trans.ExecuteSql(StrSql)
                '---------------------------
            Next

            '-- Finaliza Transacción:
            Trans.Commit()

            Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
            Dim StrConsulta As String
            Dim IdSteReciboAnulado As Integer

            StrConsulta = "SELECT MAX(nSteReciboAnuladoID) as Cant FROM SteReciboAnulado"
            XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
            XdtTmpConsulta.ExecuteSql(StrConsulta)

            If XdtTmpConsulta.Count > 0 Then
                IdSteReciboAnulado = XdtTmpConsulta.ValueField("Cant")
            End If

            'GuardarAuditoriaTablas(19, 1, "Agregar Recibo Anulado", IdSteReciboAnulado, InfoSistema.IDCuenta)

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
    ' Fecha:                15/08/2008
    ' Procedure Name:       SalvarReciboAnulado
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReciboAnulado()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            'En caso de Adición:
            If ModoForm = "ADD" Then
                InsertarRecibos()
            ElseIf ModoForm = "UPD" Then 'Edición: 

                strSQL = "Exec SpAUDITSteReciboAnuladoPorRango 'Update', 'Actualizar SteReciboAnulado'," & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & "," & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & "," & nCodigoTalonario & "," & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & "," & Trim(RTrim(Me.txtNoRecibo.Text)) & "," & Trim(RTrim(Me.txtHastaRecibo.Text)) & "," & InfoSistema.IDCuenta & ",1"
                'GuardarAuditoriaTablas(19, 2, "Modificar Recibos Anulados", IdSteRecibo, InfoSistema.IDCuenta)
                XcDatos.ExecuteNonQuery(strSQL)


                If Me.IdSteDepartamento = 17 And Me.cbAplicaMunicipioAlterno.Checked = False Then


                    strSQL = "Update SteReciboAnulado " & _
                             "SET nValor = " & Me.cneMonto.Value & ", " & _
                             "    sObservaciones = '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', " & _
                             "    nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", " & _
                             "    nSrhCajeroId = " & XdsCuenta("Cajero").ValueField("nSrhEmpleadoID") & ", " & _
                             "    dFechaModificacion = getdate() " & _
                              ", nStbMunicipioID= NULL" & _
                             "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                             "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                             "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                             "AND (nStbDepartamentoId = " & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNoRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                    XcDatos.ExecuteNonQuery(strSQL)
                Else



                    strSQL = "Update SteReciboAnulado " & _
                             "SET nValor = " & Me.cneMonto.Value & ", " & _
                             "    sObservaciones = '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', " & _
                             "    nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", " & _
                             "    nSrhCajeroId = " & XdsCuenta("Cajero").ValueField("nSrhEmpleadoID") & ", " & _
                             "    dFechaModificacion = getdate() " & _
                             "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                             "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                             "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                             "AND (nStbDepartamentoId = " & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNoRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                    XcDatos.ExecuteNonQuery(strSQL)
                End If
            Else

               
                strSQL = "Exec SpAUDITSteReciboAnuladoPorRango 'Delete', 'Eliminar SteReciboAnulado'," & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & "," & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & "," & nCodigoTalonario & "," & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & "," & Trim(RTrim(Me.txtNoRecibo.Text)) & "," & Trim(RTrim(Me.txtHastaRecibo.Text)) & "," & InfoSistema.IDCuenta & ",1"
                If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then
                    strSQL = "Delete From SteReciboAnulado " & _
                               "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                               "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                               "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                               "AND (nStbDepartamentoId = " & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                               "AND (nStbMunicipioID= " & Me.nIdMunicipio & ") " & _
                               "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNoRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"


                Else
                    XcDatos.ExecuteNonQuery(strSQL)
                    strSQL = "Delete From SteReciboAnulado " & _
                             "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                             "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                             "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                             "AND (nStbDepartamentoId = " & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                             "AND (nCodigo BETWEEN " & Trim(RTrim(Me.txtNoRecibo.Text)) & " AND " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                End If
                XcDatos.ExecuteNonQuery(strSQL)
                'GuardarAuditoriaTablas(19, 3, "Eliminar Recibos Anulados", IdSteRecibo, InfoSistema.IDCuenta)


            End If

            'Localizar número de recibo:
            If ModoForm <> "DEL" Then
                strSQL = "SELECT nSteReciboAnuladoID FROM SteReciboAnulado " & _
                         "WHERE (nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                         "AND (nCodigoTalonario = " & nCodigoTalonario & ") " & _
                         "AND (nStbDepartamentoId = " & Me.cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                         "AND (nCodigo = " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ")"
                Me.IdSteRecibo = XcDatos.ExecuteScalar(strSQL)
                '--------------------------------

                '-- Buscar el Recibo correspondiente al Id especificado
                '-- como parámetro, en los casos que se esté editando.
                ObjRecibodt.Filter = "nSteReciboAnuladoID = " & Me.IdSteRecibo
                ObjRecibodt.Retrieve()
                If ObjRecibodt.Count = 0 Then
                    Exit Sub
                End If
                ObjRecibodr = ObjRecibodt.Current

                'Si el salvado se realizó de forma satisfactoria
                'enviar mensaje informando y cerrar el formulario.
                If Me.IdSteRecibo = 0 Then
                    MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
                Else
                    Call GuardarAuditoria(2, 25, "Modificación de Recibos Anulados ID: " & Me.IdSteRecibo & ").")
                End If
            Else
                MsgBox("Los Recibos indicados han sido Eliminados.", MsgBoxStyle.Information, NombreSistema)
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
    ' Fecha:                25/07/2008
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
                            SalvarReciboAnulado()
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
                        Me.IdRecibo = 0
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.IdRecibo = 0
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/01/2010
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
    ' Fecha:                05/02/2010
    ' Procedure Name:       CargarTipoPlazoPagos
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección de periodicidad
    '                       de pagos de las socias.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazoPagos()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""
            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsCuenta.ExistTable("TipoPlazoPagos") Then
                XdsCuenta("TipoPlazoPagos").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "TipoPlazoPagos")
                XdsCuenta("TipoPlazoPagos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazoPagos.DataSource = XdsCuenta("TipoPlazoPagos").Source

            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarse en Periodicidad Semanal:
            XdtValorParametro.Filter = "nStbParametroID = 6"
            XdtValorParametro.Retrieve()
            If XdsCuenta("TipoPlazoPagos").Count > 0 Then
                XdsCuenta("TipoPlazoPagos").SetCurrentByID("nStbValorCatalogoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sDescripcion").Width = 70

            Me.cboTipoPlazoPagos.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazoPagos.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazoPagos.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboDepartamento.ClearFields()

            If intDepartamentoID = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where ((a.nActivo = 1) AND (a.nPertenecePrograma = 1)) or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
                         " Order by a.sCodigo"
            End If

            If XdsCuenta.ExistTable("Departamento") Then
                XdsCuenta("Departamento").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "Departamento")
                XdsCuenta("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDepartamento.DataSource = XdsCuenta("Departamento").Source
            Me.cboDepartamento.Rebind()

            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro:
            If XdsCuenta("Departamento").Count > 0 Then
                'XdsCuenta("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
                XdsCuenta("Departamento").SetCurrentByID("nStbDepartamentoID", Me.IdSteDepartamento)
            End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 60
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 240

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/07/2008
    ' Procedure Name:       CargarCajero
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajeros en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCajero(ByVal intCajeroID As Integer)
        Try
            Dim Strsql As String

            Me.cboCajero.ClearFields() 'And a.sCodCargo = '04'
            If intCajeroID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE (a.nActivo = 1) " & _
                         " Or a.nSrhEmpleadoID = " & intCajeroID & _
                         " Order by a.nCodigo "
            End If

            If XdsCuenta.ExistTable("Cajero") Then
                XdsCuenta("Cajero").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "Cajero")
                XdsCuenta("Cajero").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCajero.DataSource = XdsCuenta("Cajero").Source
            Me.cboCajero.Rebind()

            Me.cboCajero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboCajero.Splits(0).DisplayColumns("nActivo").Visible = False

            'Configurar el combo: 
            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 240

            Me.cboCajero.Columns("nCodigo").Caption = "Código"
            Me.cboCajero.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboCajero_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCajero.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en la Cuenta del Banco
    Private Sub cboCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCajero.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Depósito:
    Private Sub cdeFechaRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoRecibo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNoRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboDepartamento_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboDepartamento.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtHastaRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaRecibo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtHastaRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHastaRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPrograma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPrograma.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazoPagos.TextChanged
        vbModifico = True
    End Sub
End Class