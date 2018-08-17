' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditReciboPagare.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Socias.
'-------------------------------------------------------------------------
Public Class frmSteEditReciboPagare

    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdStePagare As Integer
    Dim IdSteReciboPagare As Integer
    Dim IdCajero As Integer
    Dim blnModificar As Boolean = True
    Dim IntPermiteEditar As Integer
    Dim nSaldoPagare As Double

    Dim blnPrimeraVez As Boolean = True

    ''-- Clases para procesar la informacion de los combos
    Dim XdsRecibo As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjRecibodt As BOSistema.Win.SteEntCaja.SteReciboPagareDataTable
    Dim ObjRecibodr As BOSistema.Win.SteEntCaja.SteReciboPagareRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdPagare() As Integer
        Get
            IdPagare = IdStePagare
        End Get
        Set(ByVal value As Integer)
            IdStePagare = value
        End Set
    End Property

    Public Property IdReciboPagare() As Integer
        Get
            IdReciboPagare = IdSteReciboPagare
        End Get
        Set(ByVal value As Integer)
            IdSteReciboPagare = value
        End Set
    End Property
    'Propiedad utilizada para obtener Permisos de edición fuera de la Delegación.
    Public Property intStePermiteEditar() As Long
        Get
            intStePermiteEditar = IntPermiteEditar
        End Get
        Set(ByVal value As Long)
            IntPermiteEditar = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSteEditReciboPagare_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboPagare_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjRecibodt.Close()
                ObjRecibodt = Nothing

                ObjRecibodr.Close()
                ObjRecibodr = Nothing

                XdsRecibo.Close()
                XdsRecibo = Nothing
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
    ' Autor:                
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSteEditReciboPagare_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboPagare_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Me.cdeFecha.Value = Me.cdeFecha.ValueIsDbNull
            InicializarVariables()
            CargarMinuta(0)

            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then

                CargarRecibo()
                ObtenerSiModifica()
                PresentacionControles()

                'InhabilitarControles()

            End If

            Me.cdeFecha.Enabled = False
            Me.txtMontoAdeudado.Enabled = False
            'Me.cneValor.Enabled = False
            Me.txtNumRecibo.Enabled = False

            Me.txtConcepto.Select()

            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

            blnPrimeraVez = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub ObtenerSiModifica()
        Try
            blnModificar = False

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       PresentacionControles
    ' Descripción:          Este procedimiento permite habilitar o inhabilitar
    '                       controles dependiendo del estado de la ficha.
    '-------------------------------------------------------------------------
    Private Sub PresentacionControles()
        Try

            Me.CmdAceptar.Enabled = True

            If blnModificar = False Then
                InhabilitarControles()
                Exit Sub
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Me.cmdAceptar.Enabled = False
            Me.txtConcepto.Enabled = False
            Me.txtNumRecibo.Enabled = False
            Me.cboMinuta.Enabled = False
            Me.cdeFecha.Enabled = False
            'Me.cneValor.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            'La fecha debe ser la fecha del día
            Me.cdeFecha.Value = FechaServer.Date
            'Me.cdeFecha.Enabled = False

            strSQL = "SELECT sNombreCajero,nSaldo,nSrhCajeroID FROM vwSteDatosReciboPagare " & _
                     "WHERE nStePagareID = " & Me.IdStePagare

            XdtDatos.ExecuteSql(strSQL)

            Me.txtRecibimosDe.Text = XdtDatos.ValueField("sNombreCajero")
            Me.txtMontoAdeudado.Text = Format(XdtDatos.ValueField("nSaldo"), "#,##0.00")
            Me.nSaldoPagare = XdtDatos.ValueField("nSaldo")
            Me.cneValor.Value = XdtDatos.ValueField("nSaldo")
            IdCajero = XdtDatos.ValueField("nSrhCajeroID")

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Recibo por faltante del Cajero"
            Else
                Me.Text = "Modificar Recibo por faltante del Cajero"
            End If

            Control.CheckForIllegalCrossThreadCalls = False

            Me.txtRecibimosDe.Enabled = False
            Me.txtCantidadDe.Enabled = False

            ObjRecibodt = New BOSistema.Win.SteEntCaja.SteReciboPagareDataTable
            ObjRecibodr = New BOSistema.Win.SteEntCaja.SteReciboPagareRow

            XdsRecibo = New BOSistema.Win.XDataSet

            If ModoFrm = "ADD" Then
                ObjRecibodr = ObjRecibodt.NewRow
                'Inicializar los Length de los campos (Strings?)
                Me.txtConcepto.MaxLength = ObjRecibodr.GetColumnLenght("sConceptoPago")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarRecibo
    ' Descripción:          Este procedimiento permite cargar los datos del Catálogo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarRecibo()
        Try
            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjRecibodt.Filter = "nSteReciboPagareID = " & Me.IdSteReciboPagare
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then 'No hay socias registradas (ADD).
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current 'Recibo actual.

            'Número de Recibo
            If Not ObjRecibodr.IsFieldNull("nNumRecibo") Then
                Me.txtNumRecibo.Text = ObjRecibodr.nNumRecibo
            Else
                Me.txtNumRecibo.Text = ""
            End If

            'Fecha de Recibo 
            If Not ObjRecibodr.IsFieldNull("dFechaRecibo") Then
                Me.cdeFecha.Value = ObjRecibodr.dFechaRecibo
            Else
                Me.cdeFecha.Value = Me.cdeFecha.ValueIsDbNull
            End If

            'Concepto de Pago
            If Not ObjRecibodr.IsFieldNull("sConceptoPago") Then
                Me.txtConcepto.Text = ObjRecibodr.sConceptoPago
            Else
                Me.txtConcepto.Text = ""
            End If

            'Valor
            If Not ObjRecibodr.IsFieldNull("nValor") Then
                Me.cneValor.Value = ObjRecibodr.nValor
            Else
                Me.cneValor.Value = 0
            End If

            'Minuta
            If Not ObjRecibodr.IsFieldNull("nSteMinutaDepositoID") Then
                CargarMinuta(ObjRecibodr.nSteMinutaDepositoID)
                If Me.cboMinuta.ListCount > 0 Then
                    Me.cboMinuta.SelectedIndex = 0
                    XdsRecibo("Minuta").SetCurrentByID("nSrhEmpleadoID", ObjRecibodr.nSteMinutaDepositoID)
                End If
            Else
                Me.cboMinuta.Text = ""
                Me.cboMinuta.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos
            Me.txtConcepto.MaxLength = ObjRecibodr.GetColumnLenght("sConceptoPago")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                21/01/2008
    ' Procedure Name:       CargarMinuta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Minutas de Depósito con el Estado En Proceso y
    '                       para Cuentas Bancarias Activas (a.nCerrada = 0).
    '-------------------------------------------------------------------------
    Private Sub CargarMinuta(ByVal intMinutaID As Integer)
        Try
            Dim Strsql As String = ""

            If intMinutaID = 0 Then
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.nMontoDeposito " & _
                             " From vwSteMinutaDeposito a " & _
                             " Where (a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                             " Order by a.sNumeroDeposito"
                Else
                    Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.nMontoDeposito " & _
                             " From vwSteMinutaDeposito a " & _
                             " Where (a.nCerrada = 0) And (a.CodEstadoMinuta = '1') " & _
                             " Order by a.sNumeroDeposito"
                End If
            Else
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio " & _
                             " From vwSteMinutaDeposito a " & _
                             " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
                             " or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                             " Order by a.sNumeroDeposito"
                Else
                    Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio " & _
                             " From vwSteMinutaDeposito a " & _
                             " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1')) or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                             " Order by a.sNumeroDeposito"
                End If
            End If

            If XdsRecibo.ExistTable("Minuta") Then
                XdsRecibo("Minuta").ExecuteSql(Strsql)
            Else
                XdsRecibo.NewTable(Strsql, "Minuta")
                XdsRecibo("Minuta").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboMinuta.DataSource = XdsRecibo("Minuta").Source
            Me.cboMinuta.Rebind()

            Me.cboMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.cboMinuta.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMinuta.Splits(0).DisplayColumns("nMontoDeposito").Visible = False

            'Configurar el combo:
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").Width = 70
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Width = 85
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 110
            Me.cboMinuta.Splits(0).DisplayColumns("Municipio").Width = 100

            Me.cboMinuta.Columns("sNumeroDeposito").Caption = "No. Minuta"
            Me.cboMinuta.Columns("dFechaDeposito").Caption = "Fecha Depósito"
            Me.cboMinuta.Columns("sNumeroCuenta").Caption = "Cuenta Bancaria"
            Me.cboMinuta.Columns("Municipio").Caption = "Municipio"

            Me.cboMinuta.Columns("dFechaDeposito").NumberFormat = "dd/MM/yyyy"
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            Me.cmdAceptar.Enabled = False
            Me.cmdCancelar.Enabled = False
            If ValidaDatosEntrada() Then
                SalvarRecibo()

                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        'Dim ObjTmpRecibo As New BOSistema.Win.SccEntCartera.SccReciboOficialCajaDataTable
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""
            Dim dFechaRecibo As Date
            Dim dFechaInicio As Date
            Dim nValorArqueo As Double = 0
            Dim nValorRecibo As Double = 0

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Fecha de Recibo
            If Me.cdeFecha.ValueIsDbNull Then
                MsgBox("La Fecha de Recibo NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "La Fecha de Recibo NO DEBE quedar vacía.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            dFechaRecibo = Me.cdeFecha.Value

            strSQL = "SELECT dFechaInicio,nSaldo,nStbMunicipioID FROM vwSteDatosReciboPagare " & _
                     "WHERE nStePagareID = " & Me.IdStePagare

            XdtDatos.ExecuteSql(strSQL)

            dFechaInicio = XdtDatos.ValueField("dFechaInicio")

            'Fecha del Recibo no menor que la Fecha del Pagaré
            If dFechaRecibo.Date < dFechaInicio.Date Then
                MsgBox("Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Menor que la Fecha del Pagaré (" & dFechaInicio.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Menor que la Fecha del Pagaré (" & dFechaInicio.Date & ").")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fecha del Recibo no mayor que la Fecha del Servidor
            If dFechaRecibo.Date > FechaServer.Date Then
                MsgBox("Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cdeFecha, "Fecha de Recibo (" & dFechaRecibo.Date & ") NO DEBE ser Mayor que la Fecha del Servidor (" & FechaServer.Date & ").")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Valor
            If Me.cneValor.ValueIsDbNull Then
                MsgBox("El Valor del Recibo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cneValor, "El Valor del Recibo NO DEBE quedar vacío.")
                Me.cneValor.Focus()
                Exit Function
            End If

            'Valor
            If Me.cneValor.Value = 0 Then
                MsgBox("El Valor del Recibo NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cneValor, "El Valor del Recibo NO DEBE ser Cero.")
                Me.cneValor.Focus()
                Exit Function
            End If

            REM Por Solicitud de Lester Correo: 22 Julio 2009
            'Valor del Recibo debe ser mayor o igual al Monto adeudado en el Pagaré
            'If Me.cneValor.Value < Me.nSaldoPagare Then
            '    MsgBox("Valor del Recibo DEBE ser mayor o igual al Saldo del Pagaré.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.cmdAceptar.Enabled = True
            '    Me.cmdCancelar.Enabled = True
            '    Me.errRecibo.SetError(Me.cneValor, "Valor del Recibo DEBE ser mayor o igual al Saldo del Pagaré.")
            '    Me.cneValor.Focus()
            '    Exit Function
            'End If

            'Concepto de Pago
            If Trim(RTrim(Me.txtConcepto.Text)).ToString.Length = 0 Then
                MsgBox("El Concepto de Pago NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.txtConcepto, "El Concepto de Pago NO DEBE quedar vacío.")
                Me.txtConcepto.Focus()
                Exit Function
            End If

            'Cajera
            If Me.cboMinuta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Minuta de Depósito válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboMinuta, "Debe seleccionar una Minuta de Depósito válida.")
                Me.cboMinuta.Focus()
                Exit Function
            End If

            REM Bloqueado por Solicitud de Lester Correo: 16/Junio/2009:
            'El Municipio de la Minuta debe corresponder con el de la Caja: 
            'strSQL = "SELECT * FROM SteMinutaDeposito WHERE (nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND (nStbMunicipioID = " & XdtDatos.ValueField("nStbMunicipioID") & ")"
            'If RegistrosAsociados(strSQL) = False Then
            '    MsgBox("El Municipio de la Minuta de Depósito seleccionada" & Chr(13) & "no corresponde con la ubicación de la Caja.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.cmdAceptar.Enabled = True
            '    Me.cmdCancelar.Enabled = True
            '    Me.errRecibo.SetError(Me.cboMinuta, "La Minuta ha sido asociada a otro Municipio.")
            '    Me.cboMinuta.Focus()
            '    Exit Function
            'End If

            'La fecha de la Minuta no debe ser menor que la Fecha Inicio del Pagaré
            If (DateDiff("d", Format(dFechaInicio.Date, "yyyy-MM-dd"), Format(Me.cboMinuta.Columns("dFechaDeposito").Value, "yyyy-MM-dd")) < 0) Then
                MsgBox("Fecha de la Minuta no debe ser menor" & Chr(13) & " que la Fecha Inicio del Pagaré.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboMinuta, "Debe seleccionar una Minuta de Depósito válida.")
                Me.cboMinuta.Focus()
                Exit Function
            End If

            'El Monto de la Minuta DEBE SER igual al monto del recibo
            If (Me.cneValor.Value <> Me.cboMinuta.Columns("nMontoDeposito").Value) Then
                MsgBox("Monto de la Minuta DEBE SER igual" & Chr(13) & " que el Valor del Recibo.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboMinuta, "Debe seleccionar una Minuta de Depósito válida.")
                Me.cboMinuta.Focus()
                Exit Function
            End If

            'No agregar Recibo si la Minuta ya fue asociada a un Arqueo activo
            strSQL = "SELECT  SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') AND (SteArqueoCaja.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya existe Arqueo asociado a esta Minuta.", MsgBoxStyle.Information)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboMinuta, "Ya existe Arqueo asociado a esta Minuta.")
                Me.cboMinuta.Focus()
                Exit Function
            End If

            'No agregar Recibo si la Minuta ya fue asociada a un Pagaré activo
            strSQL = "SELECT  SteReciboPagare.nSteReciboPagareID " & _
                     "FROM SteReciboPagare INNER JOIN StbValorCatalogo ON SteReciboPagare.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SteReciboPagare.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya existe Pagaré asociado a esta Minuta.", MsgBoxStyle.Information)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboMinuta, "Ya existe Pagaré asociado a esta Minuta.")
                Me.cboMinuta.Focus()
                Exit Function
            End If

            'Imposible si el mes se encuentra cerrado:
            If PeriodoAbiertoDadaFecha(dFechaRecibo.Date) = False Then
                MsgBox("El Mes Contable se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosEntrada = False
                Me.cmdAceptar.Enabled = True
                Me.cmdCancelar.Enabled = True
                Me.errRecibo.SetError(Me.cboMinuta, "El Mes Contable se encuentra Cerrado.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
            Me.cmdCancelar.Enabled = True
        Finally
            'ObjTmpRecibo.Close()
            'ObjTmpRecibo = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarRecibo()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            Dim dFechaRecibo As Date
            Dim intReciboTmpID As Integer

            dFechaRecibo = Me.cdeFecha.Value

            'If ModoFrm = "ACR" Then
            '    strSQL = " EXEC spSccAnularReciboConRegeneracion " & Me.IdSccReciboOficialCaja & "," & Me.IdSccSolicitudCheque & "," & Me.txtNumRecibo.Text & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & XdsRecibo("Representante").ValueField("nSrhEmpleadoID") & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta & ",'" & Me.sMotivoAnulacion & "'"
            'Else
            strSQL = " EXEC spSteGrabarReciboPagare " & Me.IdSteReciboPagare & "," & Me.IdStePagare & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & Me.IdCajero & "," & XdsRecibo("Minuta").ValueField("nSteMinutaDepositoID") & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta
            'End If

            'Asignar el Id de la Socia a la variable publica del formulario
            intReciboTmpID = XcDatos.ExecuteScalar(strSQL)
            'Me.IdSccReciboOficialCaja = XcDatos.ExecuteScalar(strSQL)
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If intReciboTmpID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    Me.IdSteReciboPagare = intReciboTmpID

                    '-- Buscar la ficha correspondiente al Id especificado
                    '-- como parámetro, en los casos que se esté editando una.
                    ObjRecibodt.Filter = "nSteReciboPagareID = " & Me.IdSteReciboPagare
                    ObjRecibodt.Retrieve()
                    If ObjRecibodt.Count = 0 Then
                        Exit Sub
                    End If
                    ObjRecibodr = ObjRecibodt.Current

                    'Número de Recibo
                    If Not ObjRecibodr.IsFieldNull("nNumRecibo") Then
                        Me.txtNumRecibo.Text = ObjRecibodr.nNumRecibo
                    Else
                        Me.txtNumRecibo.Text = ""
                    End If

                    'MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                    LlamaImprimirTicketPagare(Me.IdSteReciboPagare, 1, True)


                    'MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                    Call GuardarAuditoria(2, 25, "Modificación de Pagaré Cajeros ID: " & Me.IdSteReciboPagare & ").")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
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
                            SalvarRecibo()
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

    'Solo se permite Números, () , - BackSpace y la Barra espaciadora
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

    'Se indica que hubo modificación en la Dirección
    Private Sub txtConcepto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtConcepto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneValor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneValor.TextChanged
        'Me.txtCantidadDe.Text = ModSMUSURA0.NroEnLetras(Me.cneValor.Value)
    End Sub

    Private Sub cneValor_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cneValor.ValueChanged
        If Not Me.cneValor.ValueIsDbNull Then
            If Me.cneValor.Value > 0 Then
                Me.txtCantidadDe.Text = ModSMUSURA0.NroEnLetras(Me.cneValor.Value, True, "Córdoba", "Córdobas")
            End If
        End If
    End Sub

    Private Sub txtNumRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNumRecibo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub cdeFecha_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFecha.TextChanged

        vbModifico = True

    End Sub

End Class