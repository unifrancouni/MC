' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                17/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditMinutaDeposito.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Minutas de Depósito.
'-------------------------------------------------------------------------
Public Class frmSteEditMinutaDeposito

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteMinuta As Integer
    Dim IntHabilitar As Integer
    Dim intDptoId As Integer
    Dim intVirtual As Integer
    Dim listaDetalleMinutas As List(Of MinutaDetalleDeposito)


    '-- Clases para procesar la informacion de los combos
    Dim XdsCuenta As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjMinutaDepositodt As BOSistema.Win.SteEntTesoreria.SteMinutaDepositoDataTable
    Dim ObjMinutaDepositodr As BOSistema.Win.SteEntTesoreria.SteMinutaDepositoRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean
    Dim sColor As String

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property
    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la CtaBancaria.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la CtaBancaria que corresponde al campo
    'SteCtaBancariaID de la tabla SteCtaBancaria.
    Public Property IdMinuta() As Integer
        Get
            IdMinuta = IdSteMinuta
        End Get
        Set(ByVal value As Integer)
            IdSteMinuta = value
        End Set
    End Property

    'Propiedad utilizada para habilitar o no Controles.
    Public Property IntHabilito() As Integer
        Get
            IntHabilito = IntHabilitar
        End Get
        Set(ByVal value As Integer)
            IntHabilitar = value
        End Set
    End Property


    'Propiedad utilizada para habilitar o no Controles.
    Public Property nVirtual() As Integer
        Get
            nVirtual = intVirtual
        End Get
        Set(ByVal value As Integer)
            intVirtual = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       frmSteEditMinutaDeposito_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditMinutaDeposito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjMinutaDepositodt.Close()
                ObjMinutaDepositodt = Nothing

                ObjMinutaDepositodr.Close()
                ObjMinutaDepositodr = Nothing

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
    ' Fecha:                17/12/2007
    ' Procedure Name:       frmSteEditMinutaDeposito_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Minuta.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditMinutaDeposito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            If Me.sColor = "Celeste" Then
                Me.sColor = "CelesteLight"
                Me.HelpProvider.SetHelpKeyword(Me, "Minutas de Depósito")
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Minutas de Depósito (Tesorería)")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            ObjGUI.SetFormLayout(Me, Me.sColor)

            InicializarVariables()
            CargarCuenta(0)
            CargarMunicipio(0)

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoFrm = "UPD" Then
                CargarMinutaDeposito()
                InhabilitarControles()
            Else
                Me.cboCuenta.Select()
            End If
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If Seg.HasPermission("AgregarMinutaDepositoVirtual") Then
                Me.gpboxTipoMinuta.Visible = True
                Me.ckbVirtual.Visible = True
            End If

            If Seg.HasPermission("AgregarMinutaTransferencia") Then
                Me.gpboxTipoMinuta.Visible = True
                Me.ckbVirtual.Visible = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            'En caso de Inhabilitar:
            If IntHabilitar = 0 Then
                Me.cmdAceptar.Enabled = False
                Me.grpDatosGenerales.Enabled = False
            Else
                Me.cboCuenta.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Minuta de Depósito"
            Else
                Me.Text = "Modificar Minuta de Depósito"
            End If

            ObjMinutaDepositodt = New BOSistema.Win.SteEntTesoreria.SteMinutaDepositoDataTable
            ObjMinutaDepositodr = New BOSistema.Win.SteEntTesoreria.SteMinutaDepositoRow
            XdsCuenta = New BOSistema.Win.XDataSet
            listaDetalleMinutas = New List(Of MinutaDetalleDeposito)
            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboCuenta.ClearFields()
            Me.cboMunicipio.ClearFields()
            
            If ModoFrm = "ADD" Then
                ObjMinutaDepositodr = ObjMinutaDepositodt.NewRow
                'Inicializar los Length de los campos
                Me.txtNoDeposito.MaxLength = ObjMinutaDepositodr.GetColumnLenght("sNumeroDeposito")
                Me.txtObservaciones.MaxLength = ObjMinutaDepositodr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       CargarMinutaDeposito
    ' Descripción:          Este procedimiento permite cargar los datos de la 
    '                       Minuta en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarMinutaDeposito()
        Try

            '-- Buscar la Minuta correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjMinutaDepositodt.Filter = "nSteMinutaDepositoID = " & IdMinuta
            ObjMinutaDepositodt.Retrieve()
            If ObjMinutaDepositodt.Count = 0 Then
                Exit Sub
            End If
            ObjMinutaDepositodr = ObjMinutaDepositodt.Current

            'Cuenta Bancaria:
            If Not ObjMinutaDepositodr.IsFieldNull("nSteCuentaBancariaID") Then
                CargarCuenta(ObjMinutaDepositodr.nSteCuentaBancariaID)
                If Me.cboCuenta.ListCount > 0 Then
                    Me.cboCuenta.SelectedIndex = 0
                End If
                XdsCuenta("Cuenta").SetCurrentByID("nSteCuentaBancariaID", ObjMinutaDepositodr.nSteCuentaBancariaID)
            Else
                Me.cboCuenta.Text = ""
                Me.cboCuenta.SelectedIndex = -1
            End If

            'Municipio:
            If Not ObjMinutaDepositodr.IsFieldNull("nStbMunicipioID") Then
                CargarMunicipio(ObjMinutaDepositodr.nStbMunicipioID)
                If Me.cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                End If
                XdsCuenta("Municipio").SetCurrentByID("nStbMunicipioID", ObjMinutaDepositodr.nStbMunicipioID)
            Else
                Me.cboMunicipio.Text = ""
                Me.cboMunicipio.SelectedIndex = -1
            End If

            'Número de Minuta:
            If Not ObjMinutaDepositodr.IsFieldNull("sNumeroDeposito") Then
                Me.txtNoDeposito.Text = ObjMinutaDepositodr.sNumeroDeposito
            Else
                Me.txtNoDeposito.Text = ""
            End If

            'Fecha de Depósito:
            If Not ObjMinutaDepositodr.IsFieldNull("dFechaDeposito") Then
                Me.cdeFechaDeposito.Value = ObjMinutaDepositodr.dFechaDeposito
            Else
                Me.cdeFechaDeposito.Value = FechaServer()
            End If

            'Monto del Depósito:
            If Not ObjMinutaDepositodr.IsFieldNull("nMontoDeposito") Then
                Me.cneMonto.Value = ObjMinutaDepositodr.nMontoDeposito
            Else
                Me.cneMonto.Value = 0
            End If

            'Observaciones:
            If Not ObjMinutaDepositodr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjMinutaDepositodr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Transferencia:
            If Not ObjMinutaDepositodr.IsFieldNull("nTransferencia") And ObjMinutaDepositodr.nTransferencia > 0 Then
                Me.ckbTransferencia.Checked = True
            Else
                Me.ckbTransferencia.Checked = False
            End If

            'Virtual:
            If Me.nVirtual > 0 Then
                Me.ckbVirtual.Checked = True
            Else
                Me.ckbVirtual.Checked = False
            End If

            'Inicializar los Length de los campos
            Me.txtNoDeposito.MaxLength = ObjMinutaDepositodr.GetColumnLenght("sNumeroDeposito")
            Me.txtObservaciones.MaxLength = ObjMinutaDepositodr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarMinutaDeposito()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjCuenta As New BOSistema.Win.SteEntTesoreria.SteMinutaDepositoDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XcTabla As New BOSistema.Win.XDataSet.xDataTable
        'Dim nStbPersonaID As Integer 'Id de la institucion bancaria
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errMinuta.Clear()

            'Cuenta Bancaria:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta Bancaria válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta Bancaria válida.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'Número Minuta: 
            If Trim(RTrim(Me.txtNoDeposito.Text)).ToString.Length = 0 Then
                MsgBox("El Número de la Minuta NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "El Nombre de la Minuta NO DEBE quedar vacío.")
                Me.txtNoDeposito.Focus()
                Exit Function
            End If

            '--gg
            Dim strAux As String
            strAux = Me.txtObservaciones.Text
            strAux = Replace(strAux, "|", " ")
            Me.txtObservaciones.Text = strAux
            ' -- 



            'Determinar duplicados en el Número de Minuta 
            REM 17/10/2008 Ya no para una misma Cuenta Bancaria para evitar errores de duplicidad de minutas en distintas cuentas.
            'If ModoFrm = "UPD" Then
            '    ObjCuenta.Filter = " LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "' And nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & " And nSteMinutaDepositoID <> " & ObjMinutaDepositodr.nSteMinutaDepositoID
            'Else
            '    ObjCuenta.Filter = " LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "' And nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value
            'End If

            'Antes era unica para todo por que solo estaba banpro


            'If ModoFrm = "UPD" Then
            '    ObjCuenta.Filter = " LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "' And nSteMinutaDepositoID <> " & ObjMinutaDepositodr.nSteMinutaDepositoID
            'Else
            '    ObjCuenta.Filter = " LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "'"
            'End If
            'ObjCuenta.Retrieve()
            'If ObjCuenta.Count > 0 Then
            '    MsgBox("Número de Minuta NO DEBE repetirse.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errMinuta.SetError(Me.txtNoDeposito, "Número de Minuta NO DEBE repetirse.")
            '    Me.txtNoDeposito.Focus()
            '    Exit Function
            'End If

            '


            'Cambio Febrero 20 2012 para la incorporacion de bancentro. cuenta corriente
            XcTabla.ExecuteSql("SELECT     nSteCuentaBancariaID, nStbPersonaID FROM dbo.SteCuentaBancaria WHERE     nSteCuentaBancariaID = " & XdsCuenta("Cuenta").ValueField("nSteCuentaBancariaID"))


            If XcTabla.Count <= 0 Then
                MsgBox("Error al buscar la institucion bancaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "Error al buscar la institucion bancaria.")
                Me.txtNoDeposito.Focus()
                Exit Function
            End If


            strSQL = "SELECT     dbo.SteMinutaDeposito.nSteMinutaDepositoID FROM         dbo.SteMinutaDeposito INNER JOIN dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID "

            If ModoFrm = "UPD" Then
                strSQL = strSQL + " Where LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "' And nSteMinutaDepositoID <> " & ObjMinutaDepositodr.nSteMinutaDepositoID & "  And  nStbPersonaID= " & XcTabla.ValueField("nStbPersonaID") & "  And  dFechaDeposito= CONVERT(DATEtime,'" & Me.cdeFechaDeposito.Text & "',103)"

            Else
                strSQL = strSQL + " Where LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "'" & "  And  nStbPersonaID= " & XcTabla.ValueField("nStbPersonaID") & "  And  dFechaDeposito= CONVERT(DATEtime,'" & Me.cdeFechaDeposito.Text & "',103)"
            End If

            If RegistrosAsociados(strSQL) Then
                MsgBox("Número de Minuta NO DEBE repetirse. Para el Banco y Fecha de Depósito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "Número de Minuta NO DEBE repetirse. Para el Banco y Fecha de Depósito.")
                Me.txtNoDeposito.Focus()
                Exit Function
            End If


            'If XcTabla.ValueField("nStbPersonaID") = 1 And Len(txtNoDeposito.Text.Trim) < 8 Then
            '    MsgBox("Error Numero de Minuta para Banpro no puede ser menor de ocho digitos.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errMinuta.SetError(Me.txtNoDeposito, "Error Numero de Minuta para Banpro no puede ser menor de ocho digitos.")
            '    Me.txtNoDeposito.Focus()
            '    Exit Function
            'End If

            strSQL = "SELECT     dbo.SteMinutaDeposito.nSteMinutaDepositoID FROM         dbo.SteMinutaDeposito INNER JOIN dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID "


            If ModoFrm = "UPD" Then
                strSQL = strSQL + " Where LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "' And nSteMinutaDepositoID <> " & ObjMinutaDepositodr.nSteMinutaDepositoID & "  And  nStbPersonaID= " & XcTabla.ValueField("nStbPersonaID")

            Else
                strSQL = strSQL + " Where LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "'" & "  And  nStbPersonaID= " & XcTabla.ValueField("nStbPersonaID")
            End If


            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("Número de Minuta NO DEBE repetirse. Para el Banco.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errMinuta.SetError(Me.txtNoDeposito, "Número de Minuta NO DEBE repetirse. Para el Banco.")
            '    Me.txtNoDeposito.Focus()
            '    Exit Function
            'End If


            'Si la Minuta ya existe en algún Arqueo de Caja (ACTIVO )verificar que 
            'el Municipio coincida con el Municipio de la Caja:



            'Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Municipio en el cual" & Chr(13) & "se realizó el depósito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Si la Minuta ya existe en algún Arqueo de Caja (ACTIVO )verificar que 
            'el Municipio coincida con el Municipio de la Caja:
            strSQL = "SELECT U.nStbMunicipioID " & _
                     "FROM  SteArqueoCaja AS AC INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON C.nStbBarrioID = U.nStbBarrioID INNER JOIN StbValorCatalogo AS VC ON AC.nStbEstadoArqueoID = VC.nStbValorCatalogoID " & _
                     "WHERE (AC.nSteMinutaDepositoID = " & IdSteMinuta & ") AND (U.nStbMunicipioID <> " & cboMunicipio.Columns("nStbMunicipioID").Value & ") AND (VC.sCodigoInterno <> '3')"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existen Arqueos Activos con diferente Municipio" & Chr(13) & "asociado a la Caja respecto al indicado para la" & Chr(13) & "Minuta.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Fecha de Depósito:
            If Me.cdeFechaDeposito.ValueIsDbNull Then
                MsgBox("La Fecha de Depósito NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.cdeFechaDeposito, "La Fecha de Depósito NO DEBE quedar vacía.")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            'Fecha Depósito no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaDeposito.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Depósito NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.cdeFechaDeposito, "La Fecha de Depósito NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            'Fecha Depósito no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaDeposito.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Depósito NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.cdeFechaDeposito, "La Fecha de Depósito NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaDeposito.Focus()
                Exit Function
            End If

            'Monto Depósitado: 
            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto Depósitado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errMinuta.SetError(Me.cneMonto, "Monto Depósitado Inválido.")
                Me.cneMonto.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If
            If CDbl(cneMonto.Value) = 0 Then
                MsgBox("Monto Depósitado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errMinuta.SetError(Me.cneMonto, "Monto Depósitado Inválido.")
                Me.cneMonto.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If



            'Encuentra Dpto:
            strSQL = "SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & XdsCuenta("Municipio").ValueField("nStbMunicipioID") & ")"
            intDptoId = XcDatos.ExecuteScalar(strSQL)
            'Verifica si existe Delegacion para el Dpto:
            strSQL = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " & _
                     "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " & _
                      "WHERE (StbMunicipio.nStbDepartamentoID = " & intDptoId & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Delegación Departamental" & Chr(13) & "para este Municipio.", MsgBoxStyle.Critical, NombreSistema)
                Me.errMinuta.SetError(Me.cboMunicipio, "Delegación Invalida.")
                Me.cboMunicipio.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If
            'Verifica que exista detalle para minuta Virtual

            If Me.ckbVirtual.Checked Then
                'If Me.listaDetalleMinutas Then

                'End If

            End If


        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjCuenta.Close()
            ObjCuenta = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       SalvarMinutaDeposito
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Minuta en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub SalvarMinutaDeposito()
        Dim StrSql As String
        Dim XcEstado As New BOSistema.Win.XComando

        Try

            If ModoFrm = "ADD" Then
                ObjMinutaDepositodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjMinutaDepositodr.dFechaCreacion = FechaServer()
                '-- Delegación de la Minuta:
                'No se ubica en el Update ya que podria estar modificando datos
                'un usuario de otra Delegación si esta tiene Acceso Total para
                'Edición con lo que se alteraría la Delegación de la Solicitud.
                'ObjMinutaDepositodr.nStbDelegacionProgramaID = InfoSistema.IDDelegacion
                StrSql = "SELECT StbDelegacionPrograma.nStbDelegacionProgramaID " &
                         "FROM StbDelegacionPrograma INNER JOIN StbMunicipio ON StbDelegacionPrograma.nStbMunicipioID = StbMunicipio.nStbMunicipioID " &
                         "WHERE (StbMunicipio.nStbDepartamentoID = " & intDptoId & ")"
                ObjMinutaDepositodr.nStbDelegacionProgramaID = XcEstado.ExecuteScalar(StrSql)

                '-- Al agregar se genera por defecto con el Estado En Proceso:
                StrSql = " SELECT a.nStbValorCatalogoID FROM  StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (b.sNombre = 'EstadoMinutaDeposito') AND (a.sCodigoInterno = '1') "
                ObjMinutaDepositodr.nStbEstadoMinutaID = XcEstado.ExecuteScalar(StrSql)
            Else
                ObjMinutaDepositodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjMinutaDepositodr.dFechaModificacion = FechaServer()
            End If

            ObjMinutaDepositodr.nSteCuentaBancariaID = XdsCuenta("Cuenta").ValueField("nSteCuentaBancariaID")
            ObjMinutaDepositodr.nStbMunicipioID = XdsCuenta("Municipio").ValueField("nStbMunicipioID")
            ObjMinutaDepositodr.sNumeroDeposito = Me.txtNoDeposito.Text
            ObjMinutaDepositodr.dFechaDeposito = Format(Me.cdeFechaDeposito.Value, "yyyy-MM-dd")
            ObjMinutaDepositodr.nMontoDeposito = Me.cneMonto.Value

            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjMinutaDepositodr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjMinutaDepositodr.SetFieldNull("sObservaciones")
            End If

            If Me.ckbTransferencia.Checked Then
                ObjMinutaDepositodr.nTransferencia = 1
            End If


            If ModoFrm <> "ADD" Then
                GuardarAuditoriaTablas(30, 2, "Actualizar SteMinutaDeposito", ObjMinutaDepositodr.nSteMinutaDepositoID, InfoSistema.IDCuenta)
            End If

            ObjMinutaDepositodr.Update()

            'Asignar el Id de la Minuta a la 
            'variable publica del formulario
            IdSteMinuta = ObjMinutaDepositodr.nSteMinutaDepositoID
            '--------------------------------


            If ckbVirtual.Checked And listaDetalleMinutas.Count() > 0 Then
                SalvarMinutasDetalle()
            End If


            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                GuardarAuditoriaTablas(30, 1, "Agregar SteMinutaDeposito", ObjMinutaDepositodr.nSteMinutaDepositoID, InfoSistema.IDCuenta)
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Minuta ID: " & Me.IdSteMinuta & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcEstado.Close()
            XcEstado = Nothing
        End Try
    End Sub


    Private Sub SalvarMinutasDetalle()
        Dim idSteMinutaDetalle As Integer
        Dim XcDatos As New BOSistema.Win.XComando
        Dim IdMinutas As New List(Of Integer)
        Try
            For i = 0 To listaDetalleMinutas.Count() - 1
                Dim Strsql As String
                Strsql = "Execute spSteGrabarMinutaDepositoDetalle " & IdSteMinuta & ", " & listaDetalleMinutas(i).IdMinuta & ", " & listaDetalleMinutas(i).sNumeroDeposito & ", " & listaDetalleMinutas(i).nMonto & ", " & listaDetalleMinutas(i).nIDPersona & ",'" & listaDetalleMinutas(i).ModoMinuta & "', " & InfoSistema.IDCuenta
                idSteMinutaDetalle = XcDatos.ExecuteScalar(Strsql)
                IdMinutas.Add(idSteMinutaDetalle)
            Next
            'For i = 0 To IdMinutas.Count - 1
            '    If IdMinutas(i) = 0 Then
            'MsgBox("Las Minutas Detalle no pudo grabarse  grabarse.", MsgBoxStyle.Information, NombreSistema)
            '    Else
            '        'If ModoFrm = "ADD" Then
            MsgBox("Las Minutas Detalle se agregon satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)

            '        'Else
            '        'MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            '        '    Call GuardarAuditoria(2, 25, "Modificación de Entrega de Recibos a Departamentos ID: " & Me.IdSteRecibo & ").")
            '        ''End If
            '    End If
            'Next
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
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
                            SalvarMinutaDeposito()
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
                        Me.IdMinuta = 0
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.IdMinuta = 0
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/05/2008
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Municipios en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()

            If intMunicipioID = 0 Then
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " Where (a.nPertenecePrograma = 1) And (a.nActivo = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " Where ((a.nActivo = 1) And (a.nPertenecePrograma = 1)) " & _
                         " Or (a.nStbMunicipioID = " & intMunicipioID & _
                         " ) Order by a.sCodigo"
            End If
            
            If XdsCuenta.ExistTable("Municipio") Then
                XdsCuenta("Municipio").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "Municipio")
                XdsCuenta("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsCuenta("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsCuenta("Municipio").Count > 0 Then
                XdsCuenta("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/12/2007
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de Cuentas
    '                       Bancarias en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarCuenta(ByVal intCuentaID As Integer)
        Try
            Dim Strsql As String

            If intCuentaID = 0 Then
                Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sInstitucionBancaria " &
                         " From vwSteCtaBancaria a " &
                         " WHERE (a.nCerrada = 0)" &
                         " Order by a.sNumeroCuenta Asc"
            Else
                Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sInstitucionBancaria " &
                         " From vwSteCtaBancaria a " &
                         " WHERE (a.nCerrada = 0) or (a.nSteCuentaBancariaID = " & intCuentaID & ")" &
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

            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            'Configurar el combo
            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 160
            Me.cboCuenta.Splits(0).DisplayColumns("sInstitucionBancaria").Width = 160

            Me.cboCuenta.Columns("sNumeroCuenta").Caption = "No. Cuenta Bancaria"
            Me.cboCuenta.Columns("sInstitucionBancaria").Caption = "Nombre del Banco"

            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sInstitucionBancaria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub DarNumeroMinutaVirtual()
        Dim xdtNumeroDeposito As New BOSistema.Win.XComando
        Dim numeroDeposito As Integer
        Try
            Dim Strsql As String
            Strsql = "SELECT MAX(sNumeroDeposito) AS sNumeroDeposito" &
                    " FROM dbo.SteMinutaDeposito WHERE (nVirtual = 1)"

            numeroDeposito = xdtNumeroDeposito.ExecuteScalar(Strsql)
            Me.txtNoDeposito.Text = numeroDeposito + 1

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    'En caso que ocurra otro Tipo de Error
    Private Sub cboCuenta_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCuenta.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en la Cuenta del Banco
    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Depósito:
    Private Sub cdeFechaDeposito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaDeposito.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoDeposito_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoDeposito.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNoDeposito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoDeposito.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboMunicipio.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        vbModifico = True
    End Sub

    Private Sub ckbVirtual_CheckedChanged(sender As Object, e As EventArgs) Handles ckbVirtual.CheckedChanged

        If ckbVirtual.Checked Then
            ckbTransferencia.Checked = False
            Me.txtNoDeposito.Enabled = False
            Me.CmdAgregarDetalle.Visible = True
            If Not Me.nVirtual > 0 Then
                Me.txtNoDeposito.Clear()
                DarNumeroMinutaVirtual()
            End If


        Else
            Me.txtNoDeposito.Enabled = True
            Me.txtNoDeposito.Clear()
        End If
    End Sub

    Private Sub ckbTransferencia_CheckedChanged(sender As Object, e As EventArgs) Handles ckbTransferencia.CheckedChanged
        ckbVirtual.Checked = False
        Me.cboCuenta.SelectedIndex = 0
        Me.txtNoDeposito.Enabled = True
        Me.cboCuenta.Enabled = True
        Me.CmdAgregarDetalle.Visible = False
    End Sub

    Private Sub CmdAgregarDetalle_Click(sender As Object, e As EventArgs) Handles CmdAgregarDetalle.Click

        If CDbl(cneMonto.Value) = 0 Then
            MsgBox("Ingrese el monto del depósito.", MsgBoxStyle.Critical, NombreSistema)
            Me.errMinuta.SetError(Me.cneMonto, "Monto Depósitado Inválido.")
            Me.cneMonto.Focus()
            Exit Sub
        End If
        Dim ObjFrmScnEditMinutaDetalle As New frmSteEditMinutaDepositoDetalle
        ObjFrmScnEditMinutaDetalle.sColorFrm = Me.sColorFrm
        ObjFrmScnEditMinutaDetalle.nMontoMinutafrm = Me.cneMonto.Value
        ObjFrmScnEditMinutaDetalle.dFechaMinutafrm = Me.cdeFechaDeposito.Value
        ObjFrmScnEditMinutaDetalle.nIdCuentafrm = XdsCuenta("Cuenta").ValueField("nSteCuentaBancariaID")
        ObjFrmScnEditMinutaDetalle.nIdMinutafrm = Me.IdMinuta
        Try
            If ObjMinutaDepositodr.nSteMinutaDepositoID = 0 Then
                ObjFrmScnEditMinutaDetalle.ModoFrm = "ADD"


            ElseIf ObjMinutaDepositodr.nSteMinutaDepositoID <> 0 And listaDetalleMinutas.Count <= 0

                ObjFrmScnEditMinutaDetalle.ModoFrm = "ADD"
                'ObjFrmScnEditMinutaDetalle.nIdMinutafrm = Me.IdMinuta
            Else
                ObjFrmScnEditMinutaDetalle.ModoFrm = "UPD"
                'ObjFrmScnEditMinutaDetalle.nIdMinutafrm = Me.IdMinuta

            End If

            ObjFrmScnEditMinutaDetalle.ShowDialog()
            If ObjFrmScnEditMinutaDetalle.MinutasDetalles.Count <> "0" Then
                Me.listaDetalleMinutas = ObjFrmScnEditMinutaDetalle.MinutasDetalles
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditMinutaDetalle.Close()
            ObjFrmScnEditMinutaDetalle = Nothing
        End Try
    End Sub

End Class