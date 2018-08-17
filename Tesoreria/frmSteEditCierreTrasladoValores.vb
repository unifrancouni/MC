
' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                20/11/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditCierreTrasladoValores.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Cierres Diarios de Traslados de Valores.
'-------------------------------------------------------------------------
Public Class frmSteEditCierreTrasladoValores

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSteCierre As Integer
    Dim IntStePermiteEditar As Integer
    Dim IntSteCajaID As Integer
    Dim IntSrhCajeroID As Integer
    Dim sColor As String

    '-- Clases para procesar la informacion de los combos
    Dim XdsCaja As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjCierredt As BOSistema.Win.SteEntTesoreria.SteCierreTrasladoValorDataTable
    Dim ObjCierredr As BOSistema.Win.SteEntTesoreria.SteCierreTrasladoValorRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

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
    Public Property IdCierre() As Integer
        Get
            IdCierre = IdSteCierre
        End Get
        Set(ByVal value As Integer)
            IdSteCierre = value
        End Set
    End Property

    'Propiedad utilizada para obtener si el Usuario puede adicionar cierres de otra delegacion.
    Public Property IntPermiteEditar() As Integer
        Get
            IntPermiteEditar = IntStePermiteEditar
        End Get
        Set(ByVal value As Integer)
            IntStePermiteEditar = value
        End Set
    End Property

    'Id de Caja:
    Public Property IntCajaID() As Integer
        Get
            IntCajaID = IntSteCajaID
        End Get
        Set(ByVal value As Integer)
            IntSteCajaID = value
        End Set
    End Property

    'Id de Empleado asociado al Cajero:
    Public Property IntCajeroID() As Integer
        Get
            IntCajeroID = IntSrhCajeroID
        End Get
        Set(ByVal value As Integer)
            IntSrhCajeroID = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2008
    ' Procedure Name:       frmSteEditCierreTrasladoValores_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCierreTrasladoValores_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                ObjCierredt.Close()
                ObjCierredt = Nothing

                ObjCierredr.Close()
                ObjCierredr = Nothing

                XdsCaja.Close()
                XdsCaja = Nothing
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
    ' Fecha:                20/11/2008
    ' Procedure Name:       frmSteEditCierreTrasladoValores_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditCierreTrasladoValores_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Si el ID de la Caja es diferente de Cero (La Pantalla es invocada por un Cajero):
            'Bloquear Caja y Fecha de Corte:
            If Me.IntSteCajaID <> 0 Then
                'Inhabilitar Caja y Cargar Caja del Cajero:
                Me.cboCaja.Enabled = False
                CargarCaja(Me.IntCajaID)
                If Me.cboCaja.ListCount > 0 Then
                    Me.cboCaja.SelectedIndex = 0
                End If
                XdsCaja("Caja").SetCurrentByID("nSteCajaID", Me.IntCajaID)
                'Inhabilitar Cajero y Cargar Cajero:
                Me.cboEmpleadoCajero.Enabled = False
                CargarEmpleadoCajero(Me.IntCajeroID)
                If Me.cboEmpleadoCajero.ListCount > 0 Then
                    Me.cboEmpleadoCajero.SelectedIndex = 0
                End If
                XdsCaja("Cajeros").SetCurrentByID("nSrhEmpleadoID", Me.IntCajeroID)
                'Inhabilitar Fecha y mostrar Fecha del Servidor:
                Me.cdeFechaCierre.Enabled = False
                Me.cdeFechaCierre.Value = FechaServer.Date
                Me.txtHastaRecibo.Select()
            Else 'Pantalla es invocada desde el MDI por Responsable de Gestion de Recursos.
                Me.cboCaja.Enabled = True
                Me.cboEmpleadoCajero.Enabled = True
                Me.cdeFechaCierre.Enabled = True
                CargarCaja(0)
                Me.cboCaja.Select()
                CargarEmpleadoCajero(0)
            End If

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoForm = "UPD" Then
                CargarCierreDiario()
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
    ' Fecha:                20/11/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Cierre de Traslado de Valores"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Cierre de Traslado de Valores"
            End If

            ObjCierredt = New BOSistema.Win.SteEntTesoreria.SteCierreTrasladoValorDataTable
            ObjCierredr = New BOSistema.Win.SteEntTesoreria.SteCierreTrasladoValorRow
            XdsCaja = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboCaja.ClearFields()
            Me.cboEmpleadoCajero.ClearFields()
            If ModoForm = "ADD" Then
                ObjCierredr = ObjCierredt.NewRow
                Me.txtObservaciones.MaxLength = ObjCierredr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2008
    ' Procedure Name:       CargarCierreDiario
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Cierre Diario de Caja.
    '-------------------------------------------------------------------------
    Public Sub CargarCierreDiario()
        Try

            '-- Buscar el recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjCierredt.Filter = "nSteCierreTrasladoValorID = " & IdCierre
            ObjCierredt.Retrieve()
            If ObjCierredt.Count = 0 Then
                Exit Sub
            End If
            ObjCierredr = ObjCierredt.Current

            'Caja: 
            If Not ObjCierredr.IsFieldNull("nSteCajaID") Then
                CargarCaja(ObjCierredr.nSteCajaID)
                If Me.cboCaja.ListCount > 0 Then
                    Me.cboCaja.SelectedIndex = 0
                End If
                XdsCaja("Caja").SetCurrentByID("nSteCajaID", ObjCierredr.nSteCajaID)
            Else
                Me.cboCaja.Text = ""
                Me.cboCaja.SelectedIndex = -1
            End If

            'Cajero: 
            If Not ObjCierredr.IsFieldNull("nSrhEmpleadoCajeroID") Then
                CargarEmpleadoCajero(ObjCierredr.nSrhEmpleadoCajeroID)
                If Me.cboEmpleadoCajero.ListCount > 0 Then
                    Me.cboEmpleadoCajero.SelectedIndex = 0
                End If
                XdsCaja("Cajeros").SetCurrentByID("nSrhEmpleadoID", ObjCierredr.nSrhEmpleadoCajeroID)
            Else
                Me.cboEmpleadoCajero.Text = ""
                Me.cboEmpleadoCajero.SelectedIndex = -1
            End If

            'Código de Recibo Oficial de Caja de Corte:
            If Not ObjCierredr.IsFieldNull("nCodigoReciboHasta") Then
                Me.txtHastaRecibo.Text = ObjCierredr.nCodigoReciboHasta
            Else
                Me.txtHastaRecibo.Text = ""
            End If

            'Fecha de Cierre:
            If Not ObjCierredr.IsFieldNull("dFechaArqueo") Then
                Me.cdeFechaCierre.Value = ObjCierredr.dFechaArqueo
            Else
                Me.cdeFechaCierre.Value = FechaServer()
            End If

            'Observaciones:
            If Not ObjCierredr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjCierredr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjCierredr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarCierreDiario()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""
            Dim IdGrupoSolidario As Integer
            ValidaDatosEntrada = True
            Me.errCierre.Clear()

            'Caja:
            If Me.cboCaja.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Caja válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                Me.cboCaja.Focus()
                Exit Function
            End If

            'Imposible si la Caja no es de su Delegación y no tiene permisos de edición:
            If Me.IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> cboCaja.Columns("nStbDelegacionProgramaID").Value Then
                    MsgBox("Imposible Cerrar Caja de otra Delegación.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errCierre.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                    Me.cboCaja.Focus()
                    Exit Function
                End If
            End If

            'Cajero:
            If Me.cboEmpleadoCajero.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Cajero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cboEmpleadoCajero, "Debe seleccionar una Cajero.")
                Me.cboEmpleadoCajero.Focus()
                Exit Function
            End If

            'Fecha de Cierre:
            If Me.cdeFechaCierre.ValueIsDbNull Then
                MsgBox("La Fecha del Corte NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "La Fecha del Corte NO DEBE quedar vacía.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Fecha Cierre no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Corte NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "La Fecha del Corte NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Fecha Cierre no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha del Corte NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "La Fecha del Corte NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Fecha del Cierre no mayor que la Fecha del Servidor:
            If CDate(Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")) > FechaServer.Date Then
                MsgBox("Fecha de Corte NO DEBE ser Mayor que la Fecha del día.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.cdeFechaCierre, "Fecha de Corte NO DEBE ser Mayor que la Fecha del día.")
                Me.cdeFechaCierre.Focus()
                Exit Function
            End If

            'Número de Recibo (Hasta):
            If Trim(RTrim(Me.txtHastaRecibo.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.txtHastaRecibo, "El Número del Recibo NO DEBE quedar vacío.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'El Código de Recibo Hasta debe existir como un Recibo Automático 
            'para la Caja, Cajero y Fecha:
            strSQL = "SELECT * FROM SccReciboOficialCaja " & _
                     "WHERE (dFechaRecibo = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "AND (nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (nCodigo = " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " & _
                     "AND (nManual = 0) AND (nSrhEmpleadoCajeroID = " & cboEmpleadoCajero.Columns("nSrhEmpleadoID").Value & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("NO existe recibo automático con el código indicado" & Chr(13) & "para la Caja, Cajero y Fecha de Corte.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errCierre.SetError(Me.txtHastaRecibo, "El Número del Recibo NO es valido.")
                Me.txtHastaRecibo.Focus()
                Exit Function
            End If

            'En caso de encontrar el Recibo determinar el ID del Grupo Solidario:
            strSQL = " SELECT SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
                     " FROM SccReciboOficialCaja INNER JOIN SccSolicitudCheque ON SccReciboOficialCaja.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN SccSolicitudDesembolsoCredito ON SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID " & _
                     " INNER JOIN SclFichaNotificacionDetalle ON SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     " WHERE (SccReciboOficialCaja.dFechaRecibo = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) " & _
                     " AND (SccReciboOficialCaja.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (SccReciboOficialCaja.nCodigo = " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " & _
                     " AND (SccReciboOficialCaja.nManual = 0) AND (SccReciboOficialCaja.nSrhEmpleadoCajeroID = " & cboEmpleadoCajero.Columns("nSrhEmpleadoID").Value & ")"
            IdGrupoSolidario = XcDatos.ExecuteScalar(strSQL)

            'Imposible si existen codigos superiores al indicado en el grupo solidario:
            strSQL = " SELECT SccReciboOficialCaja.nCodigo " & _
                     " FROM SccReciboOficialCaja INNER JOIN SccSolicitudCheque ON SccReciboOficialCaja.nSccSolicitudChequeID = SccSolicitudCheque.nSccSolicitudChequeID INNER JOIN SccSolicitudDesembolsoCredito ON SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID " & _
                     " INNER JOIN SclFichaNotificacionDetalle ON SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     " WHERE (SccReciboOficialCaja.dFechaRecibo = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) AND (SccReciboOficialCaja.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") " & _
                     " AND (SccReciboOficialCaja.nCodigo > " & Trim(RTrim(Me.txtHastaRecibo.Text)) & ") " & _
                     " AND (SccReciboOficialCaja.nManual = 0)  AND (SccReciboOficialCaja.nSrhEmpleadoCajeroID = " & cboEmpleadoCajero.Columns("nSrhEmpleadoID").Value & ") " & _
                     " AND (SclFichaNotificacionCredito.nSclGrupoSolidarioID = " & IdGrupoSolidario & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existen Recibos de Caja superiores para socias" & Chr(13) & "del grupo solidario asociado al Código indicado.", MsgBoxStyle.Critical, NombreSistema)
                Me.errCierre.SetError(Me.txtHastaRecibo, "Código de Corte Inválido.")
                Me.txtHastaRecibo.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'No debe repetirse un Cierre de Traslado de Valores para la misma Caja, Cajero y Fecha:
            strSQL = " SELECT * From SteCierreTrasladoValor " & _
                     " WHERE (nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") " & _
                     " AND (dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) " & _
                     " AND (nSrhEmpleadoCajeroID = " & cboEmpleadoCajero.Columns("nSrhEmpleadoID").Value & ") " & _
                     " AND (nSteCierreTrasladoValorID <> " & Me.IdSteCierre & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya existe un Cierre para la Caja, Cajero y Fecha.", MsgBoxStyle.Critical, NombreSistema)
                Me.errCierre.SetError(Me.cboCaja, "Existe un Cierre para la Caja, Cajero y Fecha.")
                Me.cboCaja.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            REM Si al Cajero se le olvido efectuar el corte antes debera reaperturarse el dia y Anular los arqueos (SIN regeneracion): (19/06/2009)
            'Imposible si existe un Cierre Diario de Caja Cerrado para la Caja y Fecha:
            strSQL = "Select * From SteCierreDiarioCaja " & _
                     "WHERE (nCerrada = 1) AND (dFechaCierre = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102)) AND (nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ")"
            If RegistrosAsociados(strSQL) = True Then
                MsgBox("Ya Existe Cierre Diario de Caja Aplicado para la Fecha de Arqueo.", MsgBoxStyle.Information)
                Me.errCierre.SetError(Me.cboCaja, "Ya Existe Cierre Diario de Caja Aplicado para la Fecha de Arqueo.")
                Me.cboCaja.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si existe un Arqueo ACTIVO para el Cajero y Fecha:
            strSQL = "SELECT SteArqueoCaja.nSteCajaID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') AND (SteArqueoCaja.nSrhCajeroId  = " & cboEmpleadoCajero.Columns("nSrhEmpleadoID").Value & ") AND (SteArqueoCaja.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Ya Existe Arqueo Activo para el Cajero y Fecha.", MsgBoxStyle.Information)
                Me.errCierre.SetError(Me.cboEmpleadoCajero, "Ya Existe Arqueo Activo para el Cajero y Fecha.")
                Me.cboEmpleadoCajero.Focus()
                ValidaDatosEntrada = False
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
    ' Fecha:                20/11/2008
    ' Procedure Name:       SalvarCierreDiario
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarCierreDiario()
        Try

            If ModoForm = "ADD" Then
                ObjCierredr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjCierredr.dFechaCreacion = FechaServer()
            Else
                ObjCierredr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjCierredr.dFechaModificacion = FechaServer()
            End If

            ObjCierredr.nSteCajaID = XdsCaja("Caja").ValueField("nSteCajaID")
            ObjCierredr.nSrhEmpleadoCajeroID = XdsCaja("Cajeros").ValueField("nSrhEmpleadoID")
            ObjCierredr.dFechaArqueo = Format(Me.cdeFechaCierre.Value, "yyyy-MM-dd")
            ObjCierredr.nCodigoReciboHasta = Trim(RTrim(Me.txtHastaRecibo.Text))

            '-- Indicador de Cierre Aplicado: 
            '1 = Caja central (COCIBOLCA) o cierres enviados por cajero.
            '0 = Proceso de carga por el Cajero para cajas desconectadas.
            ObjCierredr.nAplicado = 1

            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjCierredr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjCierredr.SetFieldNull("sObservaciones")
            End If

            ObjCierredr.Update()

            'Asignar Id a la variable
            'publica del formulario
            IdSteCierre = ObjCierredr.nSteCierreTrasladoValorID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Cierre por Traslado Valores ID: " & Me.IdSteCierre & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2008
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
                            SalvarCierreDiario()
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
                        Me.IdCierre = 0
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.IdCierre = 0
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/02/2009
    ' Procedure Name:       CargarEmpleadoCajero
    ' Descripción:          Este procedimiento permite cargar el listado de Empleados
    '                       Cajeros en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarEmpleadoCajero(ByVal intCajeroID As Integer)
        Try
            Dim Strsql As String

            Me.cboEmpleadoCajero.ClearFields()
            If intCajeroID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE a.nActivo = 1 And a.sCodCargo = '04' " & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE (a.nActivo = 1 And a.sCodCargo = '04') " & _
                         " Or a.nSrhEmpleadoID = " & intCajeroID & _
                         " Order by a.nCodigo "
            End If

            If XdsCaja.ExistTable("Cajeros") Then
                XdsCaja("Cajeros").ExecuteSql(Strsql)
            Else
                XdsCaja.NewTable(Strsql, "Cajeros")
                XdsCaja("Cajeros").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboEmpleadoCajero.DataSource = XdsCaja("Cajeros").Source
            Me.cboEmpleadoCajero.Rebind()
            Me.cboEmpleadoCajero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            'Configurar el combo
            Me.cboEmpleadoCajero.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboEmpleadoCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

            Me.cboEmpleadoCajero.Columns("nCodigo").Caption = "Código"
            Me.cboEmpleadoCajero.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboEmpleadoCajero.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboEmpleadoCajero.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                20/11/2008
    ' Procedure Name:       CargarCaja
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajas en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCaja(ByVal intCajaID As Integer)
        Try
            Dim Strsql As String

            Me.cboCaja.ClearFields()
            If intCajaID = 0 Then
                Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.nStbDelegacionProgramaID, a.dFechaApertura, a.nCerrada " & _
                         " From SteCaja a " & _
                         " WHERE a.nCerrada = 0 " & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.nStbDelegacionProgramaID, a.dFechaApertura, a.nCerrada  " & _
                         " From SteCaja a " & _
                         " WHERE (a.nCerrada = 0) " & _
                         " Or a.nSteCajaID = " & intCajaID & _
                         " Order by a.nCodigo "
            End If

            If XdsCaja.ExistTable("Caja") Then
                XdsCaja("Caja").ExecuteSql(Strsql)
            Else
                XdsCaja.NewTable(Strsql, "Caja")
                XdsCaja("Caja").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCaja.DataSource = XdsCaja("Caja").Source
            Me.cboCaja.Rebind()

            'Configurar el combo
            Me.cboCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nCerrada").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 250
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").Width = 90

            Me.cboCaja.Columns("nCodigo").Caption = "Código"
            Me.cboCaja.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.cboCaja.Columns("dFechaApertura").Caption = "Fecha Apertura"

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Columns("dFechaApertura").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboCaja_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboCaja.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en la Caja
    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Cierre:
    Private Sub cdeFechaCierre_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCierre.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtHastaRecibo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHastaRecibo.KeyPress
        Try
            If Numeros(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtHastaRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHastaRecibo.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboEmpleadoCajero_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboEmpleadoCajero.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cboEmpleadoCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboEmpleadoCajero.TextChanged
        vbModifico = True
    End Sub
End Class