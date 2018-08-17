' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                09/10/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccEditArregloPago.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de un Arreglo de Pago.
'-------------------------------------------------------------------------
Public Class frmSccEditArregloPago

    '-- Declaracion de Variables: 
    Dim ModoForm As String
    Dim intSccArregloID As Integer
    Dim IntPermiteEditarDelegacion As Integer

    '-- Clases para procesar la informacion de los combos:
    Dim XdsArreglo As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjArreglodt As BOSistema.Win.SccEntCartera.SccArregloPagoDataTable
    Dim ObjArreglodr As BOSistema.Win.SccEntCartera.SccArregloPagoRow

    'Enumerado para controlar acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Arqueo:
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener Permisos de edición fuera de la Delegación.
    Public Property intStePermiteEditar() As Long
        Get
            intStePermiteEditar = IntPermiteEditarDelegacion
        End Get
        Set(ByVal value As Long)
            IntPermiteEditarDelegacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arreglo de Pago.
    Public Property intArregloID() As Integer
        Get
            intArregloID = intSccArregloID
        End Get
        Set(ByVal value As Integer)
            intSccArregloID = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/10/2009
    ' Procedure Name:       frmSccEditArregloPago_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditArregloPago_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsArreglo.Close()
                XdsArreglo = Nothing

                ObjArreglodt.Close()
                ObjArreglodt = Nothing

                ObjArreglodr.Close()
                ObjArreglodr = Nothing

                XdsDetalle.Close()
                XdsDetalle = Nothing
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
    ' Fecha:                09/10/2009
    ' Procedure Name:       frmSccEditArregloPago_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Arqueo en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSccEditArregloPago_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarTecnico(0)

            'Si el formulario está en modo edición
            'cargar los datos de la ficha.
            If ModoForm = "UPD" Then
                CargarArregloPago()
                InhabilitarControles()
                'Cargar segunda y tercer pestaña:
                CargarCuotasArreglo()
                FormatoCuotasArreglo()
                CargarAbonosSocias()
                FormatoAbonosSocias()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If cdeFechaA.Enabled Then
                Me.cdeFechaA.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/10/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas si Arreglo de Pago no se encuentra
    '                       En Proceso.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Dim strSQL As String
            '-- Si esta Anulado Bloquear Todo:
            strSQL = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM SccArregloPago INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SccArregloPago.nSccArregloPagoID = " & Me.intSccArregloID & ")"
            If RegistrosAsociados(strSQL) Then
                Me.grpDatosGenerales.Enabled = False
                Me.grpObservaciones.Enabled = False
                Me.CmdAceptar.Enabled = False
                Me.tbCuotas.Enabled = False
                Me.tbAbonos.Enabled = False
                Me.grdCuotas.Enabled = False
                Me.grdAbonos.Enabled = False
            End If

            '-- Si esta Aplicado Solo Modificar Abonos:
            strSQL = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM SccArregloPago INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SccArregloPago.nSccArregloPagoID = " & Me.intSccArregloID & ")"
            If RegistrosAsociados(strSQL) Then
                Me.grpDatosGenerales.Enabled = False
                Me.grpObservaciones.Enabled = False
                Me.CmdAceptar.Enabled = False
                Me.tbCuotas.Enabled = False
                Me.grdCuotas.Enabled = False
                Me.tbAbonos.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/10/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Arreglo de Pago"
                Me.tabCuotas.Enabled = False
                Me.tabAbonos.Enabled = False
            Else
                Me.Text = "Modificar Arreglo de Pago"
                Me.tabCuotas.Enabled = True
                Me.tabAbonos.Enabled = True
            End If

            Me.tbCuotas.Visible = True
            Me.tbAbonos.Visible = True

            ObjArreglodt = New BOSistema.Win.SccEntCartera.SccArregloPagoDataTable
            ObjArreglodr = New BOSistema.Win.SccEntCartera.SccArregloPagoRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdsArreglo = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboTecnico.ClearFields()

            'Limpiar los Grids:
            Me.grdAbonos.ClearFields()
            Me.grdCuotas.ClearFields()

            'Por defecto se abre en Datos Generales:
            Me.tabArregloPago.SelectedIndex = 0

            If ModoForm = "ADD" Then
                'Inicializar Fecha:
                Me.cdeFechaA.Value = ModSMUSURA0.FechaServer
                ObjArreglodr = ObjArreglodt.NewRow
                Me.txtObservaciones.MaxLength = ObjArreglodr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/10/2009
    ' Procedure Name:       CargarArregloPago
    ' Descripción:          Este procedimiento permite cargar los datos del Arreglo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarArregloPago()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim XcDatosB As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            '-- Buscar Arreglo correspondiente al Id especificado como
            '-- parámetro, en los casos que se esté editando uno.
            ObjArreglodt.Filter = "nSccArregloPagoID = " & Me.intSccArregloID
            ObjArreglodt.Retrieve()
            If ObjArreglodt.Count = 0 Then
                Exit Sub
            End If
            ObjArreglodr = ObjArreglodt.Current

            'Detalle de FNC:
            Me.txtFichaNotificacionDetalleID.Text = ObjArreglodr.nSclFichaNotificacionDetalleID

            'Número de Arreglo:
            If Not ObjArreglodr.IsFieldNull("nNumeroArregloPago") Then
                Me.txtNumero.Text = ObjArreglodr.nNumeroArregloPago
                Me.txtNumeroC.Text = ObjArreglodr.nNumeroArregloPago
                Me.txtNumeroA.Text = ObjArreglodr.nNumeroArregloPago
            Else
                Me.txtNumero.Text = ""
                Me.txtNumeroC.Text = ""
                Me.txtNumeroA.Text = ""
            End If

            'Estado Arreglo Pago:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjArreglodr.nStbEstadoArregloPagoID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoC.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoA.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha de Arreglo:
            If Not ObjArreglodr.IsFieldNull("dFechaArregloPago") Then
                Me.cdeFechaA.Value = ObjArreglodr.dFechaArregloPago
            Else
                Me.cdeFechaA.Value = Me.cdeFechaA.ValueIsDbNull
            End If

            'Localiza Monto Adeudado Real del Estado de Cuenta asociado al Detalle de Ficha:
            strSQL = " EXEC spSccGeneraEstadodeCuentaPrestamoMonto " & Me.txtFichaNotificacionDetalleID.Text & ", '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "'"
            Me.txtMontoEC.Text = CDbl(XcDatosB.ExecuteScalar(strSQL))

            'Monto de Arreglo:
            If Not ObjArreglodr.IsFieldNull("nMontoArregloPago") Then
                Me.cneMonto.Text = ObjArreglodr.nMontoArregloPago
            End If

            'Técnico:
            If Not ObjArreglodr.IsFieldNull("nSrhTecnicoID") Then
                CargarTecnico(ObjArreglodr.nSrhTecnicoID)
                If Me.cboTecnico.ListCount > 0 Then
                    Me.cboTecnico.SelectedIndex = 0
                End If
                XdsArreglo("Tecnico").SetCurrentByID("nSrhEmpleadoID", ObjArreglodr.nSrhTecnicoID)
            Else
                Me.cboTecnico.Text = ""
                Me.cboTecnico.SelectedIndex = -1
            End If

            'Observaciones:
            If Not ObjArreglodr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjArreglodr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            '-- Localizar informacion de la Socia:
            '1. Cédula Socia:
            strSQL = " SELECT S.sNumeroCedula " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjArreglodr.nSclFichaNotificacionDetalleID & ")"
            Me.mtbNumCedula.Text = XcUbicacion.ExecuteScalar(strSQL)
            '2. Nombre Socia:
            strSQL = " SELECT S.sNombre1 + ' ' + S.sNombre2 + ' ' + S.sApellido1 + ' ' + S.sApellido2 as Socia " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjArreglodr.nSclFichaNotificacionDetalleID & ")"
            Me.txtNombreSocia.Text = XcUbicacion.ExecuteScalar(strSQL)
            '3. Nombre Grupo Solidario:
            strSQL = " SELECT SclGrupoSolidario.sDescripcion " & _
                     " FROM SclFichaNotificacionDetalle AS DFN INNER JOIN SclFichaSocia AS FS ON DFN.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID INNER JOIN SclGrupoSolidario ON GS.nSclGrupoSolidarioID = SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     " WHERE (DFN.nSclFichaNotificacionDetalleID = " & ObjArreglodr.nSclFichaNotificacionDetalleID & ")"
            Me.txtNombreGrupo.Text = XcUbicacion.ExecuteScalar(strSQL)
            '4. Número de Crédito asociado al detalle de ficha de notificación:
            strSQL = "SELECT ISNULL(COUNT(SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), 0) AS UltimoDetalle " & _
                         "FROM SclSocia INNER JOIN SclGrupoSocia ON SclSocia.nSclSociaID = SclGrupoSocia.nSclSociaID INNER JOIN SclFichaNotificacionCredito INNER JOIN SclFichaNotificacionDetalle " & _
                         "ON SclFichaNotificacionCredito.nSclFichaNotificacionID = SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) " & _
                         "AND (CONVERT(Varchar(10), SclFichaNotificacionCredito.dFechaNotificacion, 112) <= CONVERT(Varchar(10), '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 112)) " & _
                         "AND (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            Me.txtNoCredito.Text = XcUbicacion.ExecuteScalar(strSQL)

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjArreglodr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing

            XcUbicacion.Close()
            XcUbicacion = Nothing

            XcDatosB.Close()
            XcDatosB = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       cmdBuscar_Click
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       la Socia correspondiente al número de cédula 
    '                       indicado.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim XcDatosB As New BOSistema.Win.XComando
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim StrFecha As String
            Dim Strsql As String = ""
            Me.errArreglo.Clear()

            'Limpiar Datos Socia:
            Me.txtNombreSocia.Text = ""
            Me.txtNombreGrupo.Text = ""
            Me.txtNoCredito.Text = ""
            Me.txtFichaNotificacionDetalleID.Text = "0"

            'Imposible si no se ha indicado Fecha válida:
            If Not IsDate(Me.cdeFechaA.Value) Then
                MsgBox("Debe indicar una Fecha válida.", MsgBoxStyle.Information, NombreSistema)
                Me.cdeFechaA.Focus()
                Exit Sub
            End If

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Fecha Valida en la Cédula:
            StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
            If Not IsDate(StrFecha) Then
                MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Número de Cédula Válido:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                Case Cedula.Invalida
                    MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.mtbNumCedula.Focus()
                    Exit Sub
                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    Me.mtbNumCedula.Focus()
                    Exit Sub
            End Select

            'Localizar el Ultimo Detalle de FNC APROBADA para la Cedula y menor o igual a la fecha de arreglo de pago indicada:
            Strsql = "SELECT ISNULL(MAX(SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), 0) AS UltimoDetalle " & _
                     "FROM SclSocia INNER JOIN SclGrupoSocia ON SclSocia.nSclSociaID = SclGrupoSocia.nSclSociaID INNER JOIN SclFichaNotificacionCredito INNER JOIN SclFichaNotificacionDetalle " & _
                     "ON SclFichaNotificacionCredito.nSclFichaNotificacionID = SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) " & _
                     "AND (CONVERT(Varchar(10), SclFichaNotificacionCredito.dFechaNotificacion, 112) <= CONVERT(Varchar(10), '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 112)) " & _
                     "AND (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            Me.txtFichaNotificacionDetalleID.Text = XcDatosB.ExecuteScalar(Strsql)

            'Localiza Monto Adeudado Real del Estado de Cuenta asociado al Detalle de Ficha:
            Strsql = " EXEC spSccGeneraEstadodeCuentaPrestamoMonto " & Me.txtFichaNotificacionDetalleID.Text & ", '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "'"
            Me.txtMontoEC.Text = CDbl(XcDatosB.ExecuteScalar(Strsql))

            'Si no se encontro Ficha:
            If Me.txtFichaNotificacionDetalleID.Text = "0" Then
                MsgBox("No se encontro Crédito Aprobado para la Socia indicada" & Chr(13) & _
                       "con fecha menor o igual a " & Format(Me.cdeFechaA.Value, "dd/MM/yyyy") & ".", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Si Monto Adeudado por la Socia es Cero:
            If CDbl(Me.txtMontoEC.Text) <= 0 Then
                MsgBox("La Socia no tiene Monto adeudado" & Chr(13) & "a la Fecha indicada.", MsgBoxStyle.Critical, NombreSistema)
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Ubicar Datos Socia con base en el detalle de Ficha de Notificacion Localizado: 
            Strsql = "SELECT SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sDireccionSocia, SclGrupoSolidario.sDescripcion AS GrupoSolidario, SclFichaNotificacionDetalle.nMontoCreditoAprobado, StbValorCatalogo.sDescripcion AS Actividad " & _
                     "FROM  SclFichaNotificacionDetalle INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID " & _
                     "INNER JOIN SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN SclGrupoSolidario ON SclGrupoSocia.nSclGrupoSolidarioID = SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbActividadEconomicaVerificadaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = " & Me.txtFichaNotificacionDetalleID.Text & ")"
            If RegistrosAsociados(Strsql) Then
                '1. Ubicar Info de Socia:
                XdtSocia.ExecuteSql(Strsql)
                Me.txtNombreSocia.Text = XdtSocia.ValueField("Socia")
                Me.txtNombreGrupo.Text = XdtSocia.ValueField("GrupoSolidario")

                '2. Calcula No. de Créditos otorgados a la fecha de la Ficha:
                Strsql = "SELECT ISNULL(COUNT(SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), 0) AS UltimoDetalle " & _
                         "FROM SclSocia INNER JOIN SclGrupoSocia ON SclSocia.nSclSociaID = SclGrupoSocia.nSclSociaID INNER JOIN SclFichaNotificacionCredito INNER JOIN SclFichaNotificacionDetalle " & _
                         "ON SclFichaNotificacionCredito.nSclFichaNotificacionID = SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) " & _
                         "AND (CONVERT(Varchar(10), SclFichaNotificacionCredito.dFechaNotificacion, 112) <= CONVERT(Varchar(10), '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 112)) " & _
                         "AND (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                Me.txtNoCredito.Text = XcDatosB.ExecuteScalar(Strsql)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosB.Close()
            XcDatosB = Nothing

            XdtSocia.Close()
            XdtSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then

                'Guarda Encabezado:
                SalvarArregloPago()

                'Habilita las siguientes Pestañas:
                Me.tabCuotas.Enabled = True
                Me.tabAbonos.Enabled = True

                'Actualiza Etiqueta del Código del Arreglo de Pago:
                Me.txtNumero.Text = ObjArreglodr.nNumeroArregloPago
                Me.txtNumeroC.Text = ObjArreglodr.nNumeroArregloPago
                Me.txtNumeroA.Text = ObjArreglodr.nNumeroArregloPago

                'Actualiza Estado:
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjArreglodr.nStbEstadoArregloPagoID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoC.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoA.Text = ObjEstadoDT.ValueField("sDescripcion")
                End If

                If Me.intSccArregloID <> 0 Then
                    If MsgBox("¿Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        CargarCuotasArreglo()
                        FormatoCuotasArreglo()
                        CargarAbonosSocias()
                        FormatoAbonosSocias()
                        Me.tabCuotas.Show()
                    End If
                Else
                    AccionUsuario = AccionBoton.BotonAceptar
                    Me.Close()
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim strSQL As String = ""
            Dim dFechaAnterior As Date

            ValidaDatosEntrada = True
            Me.errArreglo.Clear()

            'Fecha de Areglo de Pago:
            If (Me.cdeFechaA.ValueIsDbNull) Then
                MsgBox("La Fecha de Arreglo de Pago NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "La Fecha de Arreglo de Pago NO DEBE quedar vacía.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Areglo de Pago no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Arreglo de Pago NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "La Fecha de Arreglo de Pago NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Areglo de Pago no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Arreglo de Pago NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "La Fecha de Arreglo de Pago NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha no mayor que Fecha Server:
            If Format(Me.cdeFechaA.Value, "yyyy-MM-dd") > FechaServer().Date Then
                MsgBox("Fecha NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "Fecha NO DEBE ser Mayor que la Fecha Actual (" & FechaServer.Date & ").")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Indicar Técnico:
            If Me.cboTecnico.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del técnico.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cboTecnico, "Debe indicar nombre del Técnico.")
                Me.cboTecnico.Focus()
                Exit Function
            End If

            'Indicar Socia:
            If (Me.txtNombreSocia.Text = "") Or (Trim(txtNombreSocia.Text).Length = 0) Then
                MsgBox("Debe buscar una Socia válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.mtbNumCedula, "Debe buscar una Socia válida.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If
            If (Me.mtbNumCedula.Text = "   -      -") Then
                MsgBox("Debe buscar una Socia válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.mtbNumCedula, "Debe buscar una Socia válida.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If
            If (Me.txtFichaNotificacionDetalleID.Text = "") Or (Trim(txtFichaNotificacionDetalleID.Text).Length = 0) Or (Me.txtFichaNotificacionDetalleID.Text = "0") Then
                MsgBox("Debe buscar una Socia válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.mtbNumCedula, "Debe buscar una Socia válida.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'Imposible si ya se registro Arreglo de Pago para la Fecha y Credito de la Socia:
            strSQL = " SELECT SccArregloPago.nSccArregloPagoID " & _
                     " FROM SccArregloPago INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (SccArregloPago.nSccArregloPagoID <> " & Me.intSccArregloID & ") " & _
                     " AND (SccArregloPago.nSclFichaNotificacionDetalleID = " & Me.txtFichaNotificacionDetalleID.Text & ") AND (SccArregloPago.dFechaArregloPago = CONVERT(DATETIME, '" & Format(CDate(cdeFechaA.Text), "yyyy-MM-dd") & "', 102)) "
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe Arreglo de Pago ACTIVO para esta Socia" & Chr(13) & "en esta fecha.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "Arreglo de Pago registrado para la fecha y socia.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Imposible si no se indicó un Monto Válido:
            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cneMonto, "Monto  Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If
            If CDbl(cneMonto.Value) = 0 Then
                MsgBox("Monto Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If

            'Imposible si el Monto es Inferior al Adeudado por la Socia:
            If CDbl(cneMonto.Value) < CDbl(Me.txtMontoEC.Text) Then
                MsgBox("Monto no debe ser inferior al Saldo Pendiente" & Chr(13) & "según cartera correspondiente a: C$ " & Me.txtMontoEC.Text, MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If

            'Si ya se registro alguna Cuota: 
            'Monto del Arreglo de Pago no debe ser < Q la suma de las cuotas detalladas:
            strSQL = "SELECT nSccArregloPagoID FROM SccArregloPagoDetalle GROUP BY nSccArregloPagoID " & _
                     "HAVING (ISNULL(SUM(nMontoCuota), 0) > " & CDbl(cneMonto.Value) & ") AND (nSccArregloPagoID = " & Me.intSccArregloID & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Monto de Arreglo de Pago No puede ser inferior" & Chr(13) & "que el total de cuotas registradas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If

            'Determinar si socia tiene Arreglos de Pago ACTIVOS:
            strSQL = " SELECT  SccArregloPago.nSccArregloPagoID " & _
                     " FROM SccArregloPago INNER JOIN SclFichaNotificacionDetalle ON SccArregloPago.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID " & _
                     " INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID " & _
                     " INNER JOIN SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "') AND (SccArregloPago.nSccArregloPagoID <> " & Me.intSccArregloID & ") AND (StbValorCatalogo.sCodigoInterno <> '3')"
            If RegistrosAsociados(strSQL) Then
                '-- 1. Fecha no menor que fecha del ultimo arreglo de la Socia:
                strSQL = " SELECT SccArregloPago.dFechaArregloPago FROM SccArregloPago INNER JOIN " & _
                         " (SELECT MAX(SccArregloPago.nSccArregloPagoID) AS IdArreglo " & _
                         " FROM SccArregloPago INNER JOIN SclFichaNotificacionDetalle ON SccArregloPago.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID  INNER JOIN SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID " & _
                         " INNER JOIN SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID INNER JOIN SclSocia ON dbo.SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN StbValorCatalogo ON dbo.SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         " WHERE (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "') AND (StbValorCatalogo.sCodigoInterno <> '3')  HAVING  (MAX(SccArregloPago.nSccArregloPagoID) <> " & Me.intSccArregloID & ")) as a ON SccArregloPago.nSccArregloPagoID = a.IdArreglo"
                dFechaAnterior = XcDatos.ExecuteScalar(strSQL)
                If Format(Me.cdeFechaA.Value, "yyyy-MM-dd") <= Format(dFechaAnterior, "yyyy-MM-dd") Then
                    MsgBox("Fecha debe ser superior a la fecha del último" & Chr(13) & "arreglo de pago de la socia (" & dFechaAnterior & ").", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArreglo.SetError(Me.cdeFechaA, "Fecha Inválida.")
                    Me.cdeFechaA.Focus()
                    Exit Function
                End If
            End If

            'Si es ADD: Socia no debe tener Arreglos de Pago En Proceso:
            If Me.ModoForm = "ADD" Then
                strSQL = "SELECT SccArregloPago.nSccArregloPagoID " & _
                         "FROM SccArregloPago INNER JOIN SclFichaNotificacionDetalle ON SccArregloPago.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID " & _
                         "INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID INNER JOIN SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclSocia.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Socia tiene Arreglos de Pago En Proceso.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArreglo.SetError(Me.mtbNumCedula, "Socia Inválida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
            End If

            'Si ya se registro alguna Cuota Fecha del Arreglo no debe ser mayor que 
            'fecha de alguna cuota:
            strSQL = "SELECT nSccArregloPagoDetalleID FROM SccArregloPagoDetalle " & _
                     "WHERE (nSccArregloPagoID = " & Me.intSccArregloID & ") AND (dFechaCuota < CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Fecha de Arreglo de Pago No debe ser superior" & Chr(13) & "a la fecha de sus cuotas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "Fecha Inválida.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Si ya se registro algun Abono Fecha del Arreglo no debe ser mayor que 
            'fecha de alguna cuota:
            strSQL = "SELECT nSccArregloPagoAbonoID FROM SccArregloPagoAbono " & _
                     "WHERE  (nSccArregloPagoID = " & Me.intSccArregloID & ") AND (dFechaAbono < CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Fecha de Arreglo de Pago No debe ser superior" & Chr(13) & "a la fecha de los abonos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArreglo.SetError(Me.cdeFechaA, "Fecha Inválida.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       SalvarArregloPago
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarArregloPago()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            strSQL = " EXEC spSccGrabarArregloPago " & Me.intSccArregloID & ", " & Me.txtFichaNotificacionDetalleID.Text & ", " & Me.cboTecnico.Columns("nSrhEmpleadoID").Value & ",'" _
                     & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', " & Me.cneMonto.Value & " , '" & Me.ModoForm & "'," & InfoSistema.IDCuenta & ", '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', '" & Me.mtbNumCedula.Text & "'"
            Me.intSccArregloID = XcDatos.ExecuteScalar(strSQL)

            '-- Buscar Arreglo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando.
            ObjArreglodt.Filter = "nSccArregloPagoID = " & Me.intSccArregloID
            ObjArreglodt.Retrieve()
            If ObjArreglodt.Count = 0 Then
                Exit Sub
            End If
            ObjArreglodr = ObjArreglodt.Current

            'Si el salvado se realizó de forma satisfactoria 
            'enviar mensaje informando y cerrar el formulario.
            If Me.intSccArregloID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
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
    ' Fecha:                13/10/2009
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Declaracion de Variables 
            Dim res As Object

            If (vbModifico = True) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarArregloPago()
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
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cdeFechaA_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaA.TextChanged
        vbModifico = True
    End Sub

    Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTecnico_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTecnico.TextChanged
        vbModifico = True
    End Sub

#Region "Combos"

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/07/2009
    ' Procedure Name:       CargarTecnico
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Técnicos del Programa.
    '-------------------------------------------------------------------------
    Private Sub CargarTecnico(ByVal intTecnicoID As Integer)
        Try
            Dim Strsql As String

            Me.cboTecnico.ClearFields() '17: Responsable Cartera, '10': Oficiales de Crédito.

            If intTecnicoID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where (a.sCodCargo = '17') or (a.sCodCargo = '10')  " & _
                     " Order by a.sNombreEmpleado "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where ((a.sCodCargo = '17') or (a.sCodCargo = '10') ) " & _
                     " or (a.nSrhEmpleadoID = " & intTecnicoID & ") " & _
                     " Order by a.sNombreEmpleado "
            End If

            If XdsArreglo.ExistTable("Tecnico") Then
                XdsArreglo("Tecnico").ExecuteSql(Strsql)
            Else
                XdsArreglo.NewTable(Strsql, "Tecnico")
                XdsArreglo("Tecnico").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTecnico.DataSource = XdsArreglo("Tecnico").Source
            Me.cboTecnico.Rebind()

            Me.cboTecnico.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Visible = False

            'Configurar el combo: 
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").Width = 210
            Me.cboTecnico.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region
#Region "Detalle Cuotas Arreglo Pago"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       CargarCuotasArreglo
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       de cuotas acordadas con la socia en el momento
    '                       de realizar arreglo de pago.
    '-------------------------------------------------------------------------
    Public Sub CargarCuotasArreglo()
        Try
            Dim Strsql As String

            Me.grdCuotas.ClearFields()
            Strsql = " Select a.nSccArregloPagoDetalleID, a.nSccArregloPagoID, a.dFechaCuota, " & _
                     " a.nMontoCuota, a.sObservaciones, a.RegistradaPor, a.ActualizadoPor " & _
                     " From vwSccArregloPagoCuotas a " & _
                     " Where (a.nSccArregloPagoID = " & Me.intSccArregloID & ") " & _
                     " ORDER BY a.dFechaCuota"

            If XdsDetalle.ExistTable("Cuotas") Then
                XdsDetalle("Cuotas").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Cuotas")
                XdsDetalle("Cuotas").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdCuotas.DataSource = XdsDetalle("Cuotas").Source
            'Refresh Grid.
            Me.grdCuotas.Rebind(False)
            Me.grdCuotas.FetchRowStyles = True

            'Actualizando el caption de los GRIDS
            Me.grdCuotas.Caption = "Cuotas Arreglo de Pago (" + Me.grdCuotas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       FormatoCuotasArreglo
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Detalles del Arreglo de Pago.
    '-------------------------------------------------------------------------
    Private Sub FormatoCuotasArreglo()
        Try

            'Configuracion del Grid: 
            Me.grdCuotas.Splits(0).DisplayColumns("nSccArregloPagoDetalleID").Visible = False
            Me.grdCuotas.Splits(0).DisplayColumns("nSccArregloPagoID").Visible = False

            'Pie del Grid para totalizar Monto Total de Cuotas:
            Me.grdCuotas.ColumnFooters = True
            Me.grdCuotas.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdCuotas.Splits(0).DisplayColumns("nMontoCuota").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdCuotas.Splits(0).DisplayColumns("nMontoCuota").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdCuotas.Splits(0).DisplayColumns("nMontoCuota").FooterStyle.ForeColor = Color.Blue
            Me.grdCuotas.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdCuotas.Splits(0).DisplayColumns("dFechaCuota").Width = 90
            Me.grdCuotas.Splits(0).DisplayColumns("nMontoCuota").Width = 100
            Me.grdCuotas.Splits(0).DisplayColumns("sObservaciones").Width = 350
            Me.grdCuotas.Splits(0).DisplayColumns("RegistradaPor").Width = 150
            Me.grdCuotas.Splits(0).DisplayColumns("ActualizadoPor").Width = 150

            Me.grdCuotas.Columns("dFechaCuota").Caption = "Fecha Cuota"
            Me.grdCuotas.Columns("nMontoCuota").Caption = "Monto Cuota C$"
            Me.grdCuotas.Columns("sObservaciones").Caption = "Observaciones"
            Me.grdCuotas.Columns("RegistradaPor").Caption = "Registrado Por"
            Me.grdCuotas.Columns("ActualizadoPor").Caption = "Actualizado Por"

            Me.grdCuotas.Splits(0).DisplayColumns("dFechaCuota").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCuotas.Splits(0).DisplayColumns("dFechaCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCuotas.Splits(0).DisplayColumns("nMontoCuota").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCuotas.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCuotas.Splits(0).DisplayColumns("RegistradaPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCuotas.Splits(0).DisplayColumns("ActualizadoPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCuotas.Columns("nMontoCuota").NumberFormat = "#,##0.00"
            Me.grdCuotas.Columns("dFechaCuota").NumberFormat = "dd/MM/yyyy"
            Me.grdCuotas.Splits(0).DisplayColumns.Item("nMontoCuota").Style.BackColor = Color.WhiteSmoke

            'Calcular montos totales de cuotas acordadas en el arreglo de pago:
            CalcularMontosCuotas()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       CalcularMontosCuotas
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Cuotas del Arreglo de Pago. 
    '-------------------------------------------------------------------------
    Private Sub CalcularMontosCuotas()
        Try
            Dim vTotalBM As Double = 0

            For index As Integer = 0 To Me.grdCuotas.RowCount - 1
                Me.grdCuotas.Row = index
                vTotalBM = vTotalBM + Me.grdCuotas.Columns("nMontoCuota").Value
            Next
            If Me.grdCuotas.RowCount > 0 Then
                Me.grdCuotas.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdCuotas.Columns("nMontoCuota").FooterText = Format(vTotalBM, "C$ #,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       tbCuotas_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCuotas.
    '-------------------------------------------------------------------------
    Private Sub tbCuotas_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCuotas.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarC"
                LlamaAgregarCuotas()
            Case "toolModificarC"
                LlamaModificarCuotas()
            Case "toolEliminarC"
                LlamaEliminarCuotas()
            Case "toolRefrescarC"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdCuotas.ClearFields()
                CargarCuotasArreglo()
                FormatoCuotasArreglo()
            Case "toolAyudaC"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       LlamaAgregarCuotas
    ' Descripción:          Este procedimiento permite incluir cuotas
    '                       en el Arreglo de Pago.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCuotas()
        Dim ObjFrmSccEditCuotas As New frmSccEditArregloPagoCuotasAbonos
        Try

            ObjFrmSccEditCuotas.IdArreglo = Me.intArregloID
            ObjFrmSccEditCuotas.IdRegistro = 0
            ObjFrmSccEditCuotas.ModoFrm = "ADD"
            ObjFrmSccEditCuotas.TipoRegistro = "Cuota"
            ObjFrmSccEditCuotas.ShowDialog()

            'Si se ingresó un nuevo Arreglo: 
            If ObjFrmSccEditCuotas.IdRegistro <> 0 Then
                CargarCuotasArreglo()
                FormatoCuotasArreglo()
                XdsDetalle("Cuotas").SetCurrentByID("nSccArregloPagoDetalleID", ObjFrmSccEditCuotas.IdRegistro)
                Me.grdCuotas.Row = XdsDetalle("Cuotas").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditCuotas.Close()
            ObjFrmSccEditCuotas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       LlamaModificarCuotas
    ' Descripción:          Este procedimiento permite modificar cuotas
    '                       del Arreglo de Pago En Proceso.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCuotas()
        Dim ObjFrmSccEditCuotas As New frmSccEditArregloPagoCuotasAbonos
        Try

            'Si no existen registros:
            If Me.grdCuotas.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSccEditCuotas.IdArreglo = Me.intArregloID
            ObjFrmSccEditCuotas.IdRegistro = XdsDetalle("Cuotas").ValueField("nSccArregloPagoDetalleID")
            ObjFrmSccEditCuotas.ModoFrm = "UPD"
            ObjFrmSccEditCuotas.TipoRegistro = "Cuota"
            ObjFrmSccEditCuotas.ShowDialog()

            CargarCuotasArreglo()
            FormatoCuotasArreglo()

            'Se ubica en el recibo correspondiente:
            XdsDetalle("Cuotas").SetCurrentByID("nSccArregloPagoDetalleID", ObjFrmSccEditCuotas.IdRegistro)
            Me.grdCuotas.Row = XdsDetalle("Cuotas").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditCuotas.Close()
            ObjFrmSccEditCuotas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       LlamaEliminarCuotas
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una cuota existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCuotas()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            'Imposible si no existen registros:
            If Me.grdCuotas.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si no esta En Proceso:
            StrSql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM SccArregloPago INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SccArregloPago.nSccArregloPagoID = " & Me.intArregloID & ") AND (StbValorCatalogo.sCodigoInterno <> '1')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Arreglo de Pago no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si existen cuotas con fecha superior:
            StrSql = "SELECT nSccArregloPagoDetalleID FROM SccArregloPagoDetalle " & _
                     "WHERE (nSccArregloPagoID = " & Me.intArregloID & ") AND (dFechaCuota > CONVERT(DATETIME, '" & Format(XdsDetalle("Cuotas").ValueField("dFechaCuota"), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Cuotas con fecha superior.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XcDatos.ExecuteNonQuery("Delete From SccArregloPagoDetalle where nSccArregloPagoDetalleID =" & XdsDetalle("Cuotas").ValueField("nSccArregloPagoDetalleID"))
                CargarCuotasArreglo()
                FormatoCuotasArreglo()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdCuotas.Caption = "Cuotas Arreglo de Pago (" + Me.grdCuotas.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. 
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       grdCuotas_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una cuota a arreglo de pago.
    '-------------------------------------------------------------------------
    Private Sub grdCuotas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCuotas.DoubleClick
        Try
            LlamaModificarCuotas()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso de Error:
    Private Sub grdCuotas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCuotas.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que se filtren registros en la FilterBar.
    Private Sub grdCuotas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCuotas.Filter
        Try
            XdsDetalle("Cuotas").FilterLocal(e.Condition)
            Me.grdCuotas.Caption = "Cuotas Arreglo de Pago (" + Me.grdCuotas.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region

#Region "Detalle Abonos Socias"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       CargarAbonosSocias
    ' Descripción:          Este procedimiento permite cargar los datos de los 
    '                       abonos efectuados por las socias.
    '-------------------------------------------------------------------------
    Public Sub CargarAbonosSocias()
        Try
            Dim Strsql As String
            Me.grdAbonos.ClearFields()

            Strsql = " Select a.nSccArregloPagoAbonoID, a.nSccArregloPagoID, a.dFechaAbono, " & _
                     " a.nMontoAbono, a.sObservaciones, a.RegistradaPor, a.ActualizadoPor " & _
                     " From vwSccArregloPagoAbonos a " & _
                     " Where (a.nSccArregloPagoID = " & Me.intArregloID & ") " & _
                     " ORDER BY a.dFechaAbono"

            If XdsDetalle.ExistTable("Abonos") Then
                XdsDetalle("Abonos").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Abonos")
                XdsDetalle("Abonos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdAbonos.DataSource = XdsDetalle("Abonos").Source
            'Refresh Grid.
            Me.grdAbonos.Rebind(False)
            Me.grdAbonos.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdAbonos.Caption = "Abonos Realizados (" + Me.grdAbonos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       FormatoAbonosSocias
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre abonos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoAbonosSocias()
        Try

            'Configuracion del Grid 
            Me.grdAbonos.Splits(0).DisplayColumns("nSccArregloPagoAbonoID").Visible = False
            Me.grdAbonos.Splits(0).DisplayColumns("nSccArregloPagoID").Visible = False

            'Pie del Grid para totalizar Monto Recibos:
            Me.grdAbonos.ColumnFooters = True
            Me.grdAbonos.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdAbonos.Splits(0).DisplayColumns("nMontoAbono").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdAbonos.Splits(0).DisplayColumns("nMontoAbono").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdAbonos.Splits(0).DisplayColumns("nMontoAbono").FooterStyle.ForeColor = Color.Blue
            Me.grdAbonos.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdAbonos.Splits(0).DisplayColumns("dFechaAbono").Width = 90
            Me.grdAbonos.Splits(0).DisplayColumns("nMontoAbono").Width = 100
            Me.grdAbonos.Splits(0).DisplayColumns("sObservaciones").Width = 350
            Me.grdAbonos.Splits(0).DisplayColumns("RegistradaPor").Width = 150
            Me.grdAbonos.Splits(0).DisplayColumns("ActualizadoPor").Width = 150

            Me.grdAbonos.Columns("dFechaAbono").Caption = "Fecha Abono"
            Me.grdAbonos.Columns("nMontoAbono").Caption = "Monto Abonado C$"
            Me.grdAbonos.Columns("sObservaciones").Caption = "Observaciones"
            Me.grdAbonos.Columns("RegistradaPor").Caption = "Registrado Por"
            Me.grdAbonos.Columns("ActualizadoPor").Caption = "Actualizado Por"

            Me.grdAbonos.Splits(0).DisplayColumns.Item("nMontoAbono").Style.BackColor = Color.WhiteSmoke

            Me.grdAbonos.Splits(0).DisplayColumns("dFechaAbono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdAbonos.Splits(0).DisplayColumns("nMontoAbono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdAbonos.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdAbonos.Splits(0).DisplayColumns("RegistradaPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdAbonos.Splits(0).DisplayColumns("ActualizadoPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdAbonos.Columns("nMontoAbono").NumberFormat = "#,##0.00"
            Me.grdAbonos.Columns("dFechaAbono").NumberFormat = "dd/MM/yyyy"
            Me.grdAbonos.Splits(0).DisplayColumns("dFechaAbono").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Calcular montos totales de Abonos Efectuados:
            CalcularMontosAbonos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       CalcularMontosAbonos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Abonos para visualizarlo en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontosAbonos()
        Try
            Dim vTotalMonto As Double = 0

            For index As Integer = 0 To Me.grdAbonos.RowCount - 1
                Me.grdAbonos.Row = index
                vTotalMonto = vTotalMonto + Me.grdAbonos.Columns("nMontoAbono").Value
            Next
            If Me.grdAbonos.RowCount > 0 Then
                Me.grdAbonos.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdAbonos.Columns("nMontoAbono").FooterText = Format(vTotalMonto, "C$ #,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       tbAbonos_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbAbonos.
    '-------------------------------------------------------------------------
    Private Sub tbAbonos_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbAbonos.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregarA"
                LlamaAgregarAbonos()
            Case "toolModificarA"
                LlamaModificarAbonos()
            Case "toolEliminarA"
                LlamaEliminarAbonos()
            Case "toolRefrescarA"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdAbonos.ClearFields()
                CargarAbonosSocias()
                FormatoAbonosSocias()
            Case "toolAyudaA"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       LlamaAgregarAbonos
    ' Descripción:          Este procedimiento permite ingresar Recibos de
    '                       Caja como parte del Arqueo de Documentos.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarAbonos()
        Dim ObjFrmSccEditCuotas As New frmSccEditArregloPagoCuotasAbonos
        Try

            Dim Strsql As String
            'Imposible si arreglo de pago no esta Aplicado:
            Strsql = "SELECT SccArregloPago.nSccArregloPagoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SccArregloPago ON C.nStbValorCatalogoID = SccArregloPago.nStbEstadoArregloPagoID " & _
                     "WHERE (C.sCodigoInterno = '2') AND (SccArregloPago.nSccArregloPagoID = " & Me.intSccArregloID & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Arreglo de Pago NO se encuentra Aplicado.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSccEditCuotas.IdArreglo = Me.intArregloID
            ObjFrmSccEditCuotas.IdRegistro = 0
            ObjFrmSccEditCuotas.ModoFrm = "ADD"
            ObjFrmSccEditCuotas.TipoRegistro = "Abono"
            ObjFrmSccEditCuotas.ShowDialog()

            'Si se ingresó un nuevo registro: 
            If ObjFrmSccEditCuotas.IdRegistro <> 0 Then
                CargarAbonosSocias()
                FormatoAbonosSocias()
                XdsDetalle("Abonos").SetCurrentByID("nSccArregloPagoAbonoID", ObjFrmSccEditCuotas.IdRegistro)
                Me.grdAbonos.Row = XdsDetalle("Abonos").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditCuotas.Close()
            ObjFrmSccEditCuotas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       LlamaModificarAbonos
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       para Modificar Abonos.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarAbonos()
        Dim ObjFrmSccEditCuotas As New frmSccEditArregloPagoCuotasAbonos
        Try

            'Si no existen registros:
            If Me.grdAbonos.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSccEditCuotas.IdArreglo = Me.intArregloID
            ObjFrmSccEditCuotas.IdRegistro = XdsDetalle("Abonos").ValueField("nSccArregloPagoAbonoID")
            ObjFrmSccEditCuotas.ModoFrm = "UPD"
            ObjFrmSccEditCuotas.TipoRegistro = "Abono"
            ObjFrmSccEditCuotas.ShowDialog()

            CargarAbonosSocias()
            FormatoAbonosSocias()
            'Se ubica en el registro correspondiente:
            XdsDetalle("Abonos").SetCurrentByID("nSccArregloPagoAbonoID", ObjFrmSccEditCuotas.IdRegistro)
            Me.grdAbonos.Row = XdsDetalle("Abonos").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditCuotas.Close()
            ObjFrmSccEditCuotas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       LlamaEliminarAbonos
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Abono existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarAbonos()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            'Imposible si no existen registros:
            If Me.grdAbonos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si no esta En Proceso:
            'StrSql = "SELECT SccArregloPago.nSccArregloPagoID " & _
            '         "FROM SccArregloPago INNER JOIN StbValorCatalogo ON SccArregloPago.nStbEstadoArregloPagoID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (SccArregloPago.nSccArregloPagoID = " & Me.intArregloID & ") AND (StbValorCatalogo.sCodigoInterno <> '1')"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("Arreglo de Pago no se encuentra En Proceso.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Imposible si existen abonos con fecha superior:
            StrSql = "SELECT nSccArregloPagoAbonoID FROM SccArregloPagoAbono " & _
                     "WHERE (nSccArregloPagoID = " & Me.intArregloID & ") AND (dFechaAbono > CONVERT(DATETIME, '" & Format(XdsDetalle("Abonos").ValueField("dFechaAbono"), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Abonos con fecha superior.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XcDatos.ExecuteNonQuery("Delete From SccArregloPagoAbono where nSccArregloPagoAbonoID =" & XdsDetalle("Abonos").ValueField("nSccArregloPagoAbonoID"))
                CargarAbonosSocias()
                FormatoAbonosSocias()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdAbonos.Caption = "Abonos Realizados (" + Me.grdAbonos.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       grdAbonos_KeyPress
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Abono existente, al dar Enter sobre
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdAbonos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdAbonos.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                LlamaModificarAbonos()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       grdCuotas_KeyPress
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un detalle existente, al dar enter sobre
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCuotas_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdCuotas.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                LlamaModificarCuotas()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                13/10/2009
    ' Procedure Name:       grdAbonos_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Abono existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdAbonos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdAbonos.DoubleClick
        Try
            LlamaModificarAbonos()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdAbonos_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdAbonos.Error
        Control_Error(e.Exception)
    End Sub

    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdAbonos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdAbonos.Filter
        Try
            XdsDetalle("Abonos").FilterLocal(e.Condition)
            Me.grdAbonos.Caption = "Abonos Realizados (" + Me.grdAbonos.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region
End Class