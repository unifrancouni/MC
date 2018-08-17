' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                05/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditConciliacion.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Conciliación Bancaria.
'-------------------------------------------------------------------------

Public Class frmSteEditConciliacion

    '-- Declaracion de Variables: 
    Dim ModoForm As String
    Dim intConciliacionID As Integer
    Dim IntHabilitar As Integer

    '-- Clases para procesar la informacion de los combos:
    Dim XdsConciliacion As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjConciliaciondt As BOSistema.Win.SteEntTesoreria.SteConciliacionBancariaDataTable
    Dim ObjConciliaciondr As BOSistema.Win.SteEntTesoreria.SteConciliacionBancariaRow

    'Enumerado para controlar acciones sobre el Formulario:
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos:
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Conciliación.
    Public Property intSteConciliacionID() As Integer
        Get
            intSteConciliacionID = intConciliacionID
        End Get
        Set(ByVal value As Integer)
            intConciliacionID = value
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/02/2008
    ' Procedure Name:       frmSteEditConciliacion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                XdsConciliacion.Close()
                XdsConciliacion = Nothing

                ObjConciliaciondt.Close()
                ObjConciliaciondt = Nothing

                ObjConciliaciondr.Close()
                ObjConciliaciondr = Nothing

                XdsDetalle.Close()
                XdsDetalle = Nothing
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
    ' Fecha:                05/02/2008
    ' Procedure Name:       frmSteEditConciliacion_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Conciliación en caso de estar en el 
    '                       modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditConciliacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarCuenta(0)
            'Tres Firmas (Empleados del Programa):
            CargarFirmas(0, 36, "FirmaUno")     'Auxiliar Contable
            CargarFirmas(0, 35, "FirmaDos")     'Contador
            CargarFirmas(0, 28, "FirmaTres")    'Responsable de Gestión de Recursos

            'Si el formulario está en modo edición cargar datos.
            If ModoForm = "UPD" Then
                CargarConciliacion()
                InhabilitarControles()
                'Cargar segunda y tercer pestaña:
                CargarDocumentosContables()
                FormatoDocumentosContables()
                CargarOperacionesBancarias()
                FormatoOperacionesBancarias()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If cdeFechaD.Enabled Then
                Me.cdeFechaD.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/02/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Dim strSQL As String
            Dim strSQLA As String
            '-- Inhabilitar:
            If IntHabilitar = 0 Then
                Me.grpDatosGenerales.Enabled = False
                Me.grpFirmas.Enabled = False
                Me.tbOperacionesBanco.Enabled = False
                Me.tbDocumentoContable.Enabled = False
                Me.CmdAceptar.Enabled = False
            End If

            'Si ya tiene Documentos Contables asociados u Operaciones Bancarias:
            strSQL = "SELECT * FROM SteConciliacionTransacciones WHERE (nSteConciliacionBancariaID = " & Me.intConciliacionID & ")"
            strSQLA = "SELECT * FROM SteConciliacionOtrasOperaciones WHERE (nSteConciliacionBancariaID = " & Me.intConciliacionID & ")"
            If (RegistrosAsociados(strSQL)) Or (RegistrosAsociados(strSQLA)) Then
                Me.cboCuenta.Enabled = False
                Me.cdeFechaH.Enabled = False
                Me.cdeFechaD.Enabled = False
            Else
                Me.cboCuenta.Enabled = True
                Me.cdeFechaH.Enabled = True
                Me.cdeFechaD.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/02/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Conciliación Bancaria"
                Me.tabDocumentos.Enabled = False
                Me.tabOperaciones.Enabled = False
            Else
                Me.Text = "Modificar Conciliación Bancaria"
                Me.tabDocumentos.Enabled = True
                Me.tabOperaciones.Enabled = True
            End If

            Me.tbDocumentoContable.Visible = True
            Me.tbOperacionesBanco.Visible = True

            ObjConciliaciondt = New BOSistema.Win.SteEntTesoreria.SteConciliacionBancariaDataTable
            ObjConciliaciondr = New BOSistema.Win.SteEntTesoreria.SteConciliacionBancariaRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdsConciliacion = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboCuenta.ClearFields()
            Me.cboFirma1.ClearFields()
            Me.cboFirma2.ClearFields()
            Me.cboFirma3.ClearFields()

            'Limpiar los Grids:
            Me.grdOperacionesBancarias.ClearFields()
            Me.grdDocumentosContables.ClearFields()

            'Por defecto se abre en Datos Generales:
            Me.tabConciliacion.SelectedIndex = 0

            If ModoForm = "ADD" Then
                'Inicializar Fecha:
                'Me.cdeFechaD.Value = ModSMUSURA0.FechaServer
                ObjConciliaciondr = ObjConciliaciondt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/02/2008
    ' Procedure Name:       CargarConciliacion
    ' Descripción:          Este procedimiento permite cargar los datos de la
    '                       Conciliación en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarConciliacion()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable

        Try
            Dim strSQL As String = ""

            '-- Buscar Conciliación correspondiente al Id especificado como
            '-- parámetro, en los casos que se esté editando una.
            ObjConciliaciondt.Filter = "nSteConciliacionBancariaID = " & Me.intConciliacionID
            ObjConciliaciondt.Retrieve()
            If ObjConciliaciondt.Count = 0 Then
                Exit Sub
            End If
            ObjConciliaciondr = ObjConciliaciondt.Current

            'Código de Conciliación:
            If Not ObjConciliaciondr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjConciliaciondr.nCodigo
                Me.txtCodigoD.Text = ObjConciliaciondr.nCodigo
                Me.txtCodigoO.Text = ObjConciliaciondr.nCodigo
            Else
                Me.txtCodigo.Text = ""
                Me.txtCodigoD.Text = ""
                Me.txtCodigoO.Text = ""
            End If

            'Estado Conciliación:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjConciliaciondr.nStbEstadoConciliacionID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoD.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoO.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha Desde:
            If Not ObjConciliaciondr.IsFieldNull("dFechaInicio") Then
                Me.cdeFechaD.Value = ObjConciliaciondr.dFechaInicio
            Else
                Me.cdeFechaD.Value = Me.cdeFechaD.ValueIsDbNull
            End If

            'Fecha Hasta:
            If Not ObjConciliaciondr.IsFieldNull("dFechaCorte") Then
                Me.cdeFechaH.Value = ObjConciliaciondr.dFechaCorte
            Else
                Me.cdeFechaH.Value = Me.cdeFechaD.ValueIsDbNull
            End If

            'Primer Firma (Auxiliar Contable):
            If Not ObjConciliaciondr.IsFieldNull("nSrhEmpleadoElaboraId") Then
                If Me.cboFirma1.ListCount > 0 Then
                    Me.cboFirma1.SelectedIndex = 0
                End If
                XdsConciliacion("FirmaUno").SetCurrentByID("nSrhEmpleadoID", ObjConciliaciondr.nSrhEmpleadoElaboraId)
            Else
                Me.cboFirma1.Text = ""
                Me.cboFirma1.SelectedIndex = -1
            End If

            'Segunda Firma (Empleado Contador):
            If Not ObjConciliaciondr.IsFieldNull("nSrhContadorId") Then
                If Me.cboFirma2.ListCount > 0 Then
                    Me.cboFirma2.SelectedIndex = 0
                End If
                XdsConciliacion("FirmaDos").SetCurrentByID("nSrhEmpleadoID", ObjConciliaciondr.nSrhContadorId)
            Else
                Me.cboFirma2.Text = ""
                Me.cboFirma2.SelectedIndex = -1
            End If

            'Tercer Firma (Responsable de Gestión de Recursos):
            If Not ObjConciliaciondr.IsFieldNull("nSrhGestionRecursosId") Then
                If Me.cboFirma3.ListCount > 0 Then
                    Me.cboFirma3.SelectedIndex = 0
                End If
                XdsConciliacion("FirmaTres").SetCurrentByID("nSrhEmpleadoID", ObjConciliaciondr.nSrhGestionRecursosId)
            Else
                Me.cboFirma3.Text = ""
                Me.cboFirma3.SelectedIndex = -1
            End If

            'Cuenta Bancaria:
            If Not ObjConciliaciondr.IsFieldNull("nSteCuentaBancariaID") Then
                If Me.cboCuenta.ListCount > 0 Then
                    Me.cboCuenta.SelectedIndex = 0
                End If
                XdsConciliacion("Cuenta").SetCurrentByID("nSteCuentaBancariaID", ObjConciliaciondr.nSteCuentaBancariaID)
            Else
                Me.cboCuenta.Text = ""
                Me.cboCuenta.SelectedIndex = -1
            End If

            'Saldo Inicial según Banco:
            If Not ObjConciliaciondr.IsFieldNull("nSaldoInicialBanco") Then
                Me.cneMonto.Value = ObjConciliaciondr.nSaldoInicialBanco
            Else
                Me.cneMonto.Value = 0
            End If

            'Observaciones:
            If Not ObjConciliaciondr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjConciliaciondr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
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
    ' Fecha:                05/02/2008
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
                SalvarConciliacion()

                'Habilita las siguientes Pestañas:
                Me.tabDocumentos.Enabled = True
                Me.tabOperaciones.Enabled = True

                'Actualiza Etiqueta del Código de la Conciliación:
                Me.txtCodigo.Text = ObjConciliaciondr.nCodigo
                Me.txtCodigoD.Text = ObjConciliaciondr.nCodigo
                Me.txtCodigoO.Text = ObjConciliaciondr.nCodigo

                'Actualiza Estado:
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjConciliaciondr.nStbEstadoConciliacionID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoD.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoO.Text = ObjEstadoDT.ValueField("sDescripcion")
                End If

                If Me.intConciliacionID <> 0 Then
                    If MsgBox("¿Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        CargarDocumentosContables()
                        FormatoDocumentosContables()
                        CargarOperacionesBancarias()
                        FormatoOperacionesBancarias()
                        Me.tabDocumentos.Show()
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
    ' Fecha:                05/02/2008
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
            Me.errConciliacion.Clear()

            'Fecha de Inicio:
            If (Me.cdeFechaD.ValueIsDbNull) Then
                MsgBox("La Fecha de Inicio NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaD, "La Fecha de Inicio NO DEBE quedar vacía.")
                Me.cdeFechaD.Focus()
                Exit Function
            End If

            'Fecha de Corte:
            If (Me.cdeFechaH.ValueIsDbNull) Then
                MsgBox("La Fecha de Corte NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "La Fecha de Corte NO DEBE quedar vacía.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Fecha Inicio no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Inicio NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaD, "La Fecha de Inicio NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaD.Focus()
                Exit Function
            End If

            'Fecha Inicio no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaD.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Inicio NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaD, "La Fecha de Inicio NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaD.Focus()
                Exit Function
            End If

            'Fecha Corte no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaH.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Corte NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "La Fecha de Corte NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Fecha Corte no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaH.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Corte NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "La Fecha de Corte NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Fecha de Corte > a Fecha de Inicio: 
            If Me.cdeFechaH.Value <= cdeFechaD.Value Then
                MsgBox("Fecha de Corte DEBE ser superior a la de Inicio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "Fecha de Corte DEBE ser superior a la de Inicio.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Saldo Inicial según Banco: 
            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto de Saldo Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cneMonto, "Monto Inválido.")
                Me.cneMonto.Focus()
                Exit Function
            End If
            REM Solicitud Edmundo 01/Dic/2008: Permitir Saldo Inicial en Cero.
            'If CDbl(cneMonto.Value) = 0 Then
            '    MsgBox("Monto de Saldo Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errConciliacion.SetError(Me.cneMonto, "Monto Inválido.")
            '    Me.cneMonto.Focus()
            '    Exit Function
            'End If

            'Cuenta Bancaria:
            If Me.cboCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Cuenta Bancaria válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cboCuenta, "Debe seleccionar una Cuenta Bancaria válida.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'Si es una Adición imposible si existe Conciliación En Proceso para la Cuenta Bancaria:
            strSQL = " SELECT CB.nSteConciliacionBancariaID " & _
                     " FROM  SteConciliacionBancaria AS CB INNER JOIN StbValorCatalogo AS C ON CB.nStbEstadoConciliacionID = C.nStbValorCatalogoID " & _
                     " WHERE (C.sCodigoInterno = '1') AND (CB.nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                     " AND (CB.nSteConciliacionBancariaID <> " & Me.intConciliacionID & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe Conciliación En Proceso para la Cuenta Bancaria." & Chr(13) & "Antes debe Cerrar las Conciliaciones existentes.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cboCuenta, "Existen Conciliaciones En Proceso para Cuenta de Banco.")
                Me.cboCuenta.Focus()
                Exit Function
            End If

            'Si no es la primer Conciliación para la Cuenta Bancaria seleccionada entonces:
            'Fecha de Inicio NO debe ser menor a Fecha de Corte de la Conciliación Anterior:
            strSQL = " SELECT CB.nSteConciliacionBancariaID " & _
                     " FROM  SteConciliacionBancaria AS CB INNER JOIN StbValorCatalogo AS C ON CB.nStbEstadoConciliacionID = C.nStbValorCatalogoID " & _
                     " WHERE (C.sCodigoInterno <> '3') AND (CB.nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                     " AND (CB.nSteConciliacionBancariaID <> " & Me.intConciliacionID & ")"
            If RegistrosAsociados(strSQL) Then
                strSQL = " SELECT SteConciliacionBancaria.dFechaCorte " & _
                         " FROM (SELECT MAX(nSteConciliacionBancariaID) AS Id " & _
                         " FROM (SELECT CB.nSteConciliacionBancariaID, CB.dFechaCorte FROM SteConciliacionBancaria AS CB INNER JOIN StbValorCatalogo AS C ON CB.nStbEstadoConciliacionID = C.nStbValorCatalogoID " & _
                         " WHERE (CB.nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") AND (C.sCodigoInterno <> '3') AND (CB.nSteConciliacionBancariaID <> " & Me.intConciliacionID & ")) AS a) AS b INNER JOIN SteConciliacionBancaria ON b.Id = SteConciliacionBancaria.nSteConciliacionBancariaID"
                dFechaAnterior = XcDatos.ExecuteScalar(strSQL)
                If cdeFechaD.Value <= dFechaAnterior Then
                    MsgBox("Fecha de Inicio DEBE ser superior a fecha" & Chr(13) & "de Corte de la Conciliación Anterior para la" & Chr(13) & "Cuenta Bancaria seleccionada (" & dFechaAnterior & ").", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errConciliacion.SetError(Me.cdeFechaD, "Fecha de Inicio Inválida.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If
            End If

            'Imposible si existe otra Conciliación Activa para
            'la misma Cuenta Bancaria en el mismo Mes / Año:
            strSQL = " SELECT CB.nSteConciliacionBancariaID " & _
                     " FROM  SteConciliacionBancaria AS CB INNER JOIN StbValorCatalogo AS C ON CB.nStbEstadoConciliacionID = C.nStbValorCatalogoID " & _
                     " WHERE (C.sCodigoInterno <> '3') AND (CB.nSteCuentaBancariaID = " & cboCuenta.Columns("nSteCuentaBancariaID").Value & ") " & _
                     " AND (MONTH(CB.dFechaInicio) = " & Month(Me.cdeFechaD.Value) & ") AND (YEAR(CB.dFechaInicio) = " & Year(Me.cdeFechaD.Value) & ") AND (CB.nSteConciliacionBancariaID <> " & Me.intConciliacionID & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existe Conciliación Activa para la Cuenta Bancaria en el mismo mes/año.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaD, "Existe Conciliación Activa para la Cuenta Bancaria en el mismo mes/año.")
                Me.cdeFechaD.Focus()
                Exit Function
            End If

            'Fecha de Inicio no corresponde al primer dia del mes: 
            If (Microsoft.VisualBasic.DateAndTime.Day(Me.cdeFechaD.Value)) <> 1 Then
                MsgBox("Día de Fecha de Inicio no corresponde" & Chr(13) & "al primer día del mes.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaD, "Fecha de Inicio Inválida.")
                Me.cdeFechaD.Focus()
                Exit Function
            End If

            'Fecha de Corte no corresponde al último día del mes:
            If (Microsoft.VisualBasic.DateAndTime.Day(Me.cdeFechaH.Value)) <> IntUltimoDiaMes(Month(Me.cdeFechaH.Value), Year(Me.cdeFechaH.Value)) Then
                MsgBox("Día de Fecha de Corte no corresponde" & Chr(13) & "al último día del mes.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "Fecha de Corte Inválida.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Mes de Fecha de Inicio debe corresponder con la de corte:
            If (Microsoft.VisualBasic.DateAndTime.Month(Me.cdeFechaD.Value)) <> (Microsoft.VisualBasic.DateAndTime.Month(Me.cdeFechaH.Value)) Then
                MsgBox("Mes de fecha de corte no corresponde con" & Chr(13) & "el mes de la fecha de inicio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "Mes de Fecha de Corte Inválido.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Año de fecha de Inicio debe corresponder con la de corte:
            If Year(Me.cdeFechaD.Value) <> Year(Me.cdeFechaH.Value) Then
                MsgBox("Año de fecha de corte no corresponde con" & Chr(13) & "el año de la fecha de inicio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cdeFechaH, "Año de Fecha de Corte Inválido.")
                Me.cdeFechaH.Focus()
                Exit Function
            End If

            'Primer Firma:
            If Me.cboFirma1.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Auxiliar Contable.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cboFirma1, "Debe indicar nombre del Auxiliar Contable.")
                Me.cboFirma1.Focus()
                Exit Function
            End If

            'Segunda Firma:
            If Me.cboFirma2.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Contador.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cboFirma2, "Debe indicar nombre del Contador.")
                Me.cboFirma2.Focus()
                Exit Function
            End If

            'Tercer Firma: 
            If Me.cboFirma3.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Responsable de Gestión de Recursos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errConciliacion.SetError(Me.cboFirma3, "Debe indicar nombre del Responsable de Gestión de Recursos.")
                Me.cboFirma3.Focus()
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
    ' Fecha:                05/02/2008
    ' Procedure Name:       SalvarConciliacion
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Conciliación en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarConciliacion()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            If ModoForm <> "ADD" Then
                GuardarAuditoriaTablas(31, 2, "Actualizar SteConciliacionBancaria", intConciliacionID, InfoSistema.IDCuenta)
            End If



            strSQL = " EXEC spSteGrabarConciliacion " & Me.intConciliacionID & "," & Me.cboCuenta.Columns("nSteCuentaBancariaID").Value & "," _
                     & Me.cboFirma1.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma2.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma3.Columns("nSrhEmpleadoID").Value & "," & cneMonto.Value & ",'" & Trim(RTrim(Me.txtObservaciones.Text)) & "', '" _
                     & Format(Me.cdeFechaD.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaH.Value, "yyyy-MM-dd") & "','" & Me.ModoForm & "'," & InfoSistema.IDCuenta
            Me.intConciliacionID = XcDatos.ExecuteScalar(strSQL)


            If ModoForm = "ADD" Then
                GuardarAuditoriaTablas(31, 1, "Agregar SteConciliacionBancaria", intConciliacionID, InfoSistema.IDCuenta)
            End If




            '-- Buscar la ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjConciliaciondt.Filter = "nSteConciliacionBancariaID = " & Me.intConciliacionID
            ObjConciliaciondt.Retrieve()
            If ObjConciliaciondt.Count = 0 Then
                Exit Sub
            End If
            ObjConciliaciondr = ObjConciliaciondt.Current

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.intConciliacionID = 0 Then
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
    ' Fecha:                05/02/2008
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
            Dim strSQL As String

            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoCredito' "

            If (vbModifico = True) And (ObjConciliaciondr.nStbEstadoConciliacionID = XcDatos.ExecuteScalar(strSQL)) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarConciliacion()
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

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    'En caso que haya habido algún cambio
    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMonto_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMonto.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaD.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaH.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma1.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma2.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma3.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboCuenta_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCuenta.TextChanged
        If Me.cboCuenta.SelectedIndex <> -1 Then
            If Me.cboCuenta.Columns("CodMoneda").Value = "01" Then
                Me.lblSaldo.Text = "Saldo Inicial según Banco (C$):"
            Else
                Me.lblSaldo.Text = "Saldo Inicial según Banco (US$):"
            End If
        End If
        vbModifico = True
    End Sub

#Region "Combos"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       CargarFirmas
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados sugiriendo el empleado registrado en 
    '                       parámetros para primer, segunda y tercer firma:
    '                       intParametroID = 36 (Firma1); StrNombre = FirmaUno
    '                       intParametroID = 35 (Firma2); StrNombre = FirmaDos
    '                       intParametroID = 28 (Firma3); StrNombre = FirmaTres
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intEmpleadoID As Integer, ByVal intParametroID As Integer, ByVal StrNombre As String)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Dim XdtDelegacion As New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
        Try

            Dim Strsql As String

            If intParametroID = 36 Then 'Auxiliar Contable
                Me.cboFirma1.ClearFields()
            ElseIf intParametroID = 35 Then 'Contador
                Me.cboFirma2.ClearFields()
            Else 'Responsable de Gestión de Recursos
                Me.cboFirma3.ClearFields()
            End If

            If intParametroID = 36 Then 'Solamente cargo: Auxiliar Contable
                If intEmpleadoID = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where (a.sCodCargo = '09')  AND (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                             " Order by a.nCodPersona"
                Else
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where ((a.sCodCargo = '09')  AND (a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
                             " Order by a.nCodPersona"
                End If
            Else
                If intEmpleadoID = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where (a.sCodEmpleado = 'E') and (nPersonaActiva = 1) " & _
                             " Order by a.nCodPersona"
                Else
                    Strsql = " Select a.nSrhEmpleadoID, a.nCodPersona, a.sNombre " & _
                             " From vwStbEmpleado a " & _
                             " Where ((a.sCodEmpleado = 'E') and (nPersonaActiva = 1)) " & _
                             " Or (a.nSrhEmpleadoID = " & intEmpleadoID & ") " & _
                             " Order by a.nCodPersona"
                End If
            End If
            
            If XdsConciliacion.ExistTable(StrNombre) Then
                XdsConciliacion(StrNombre).ExecuteSql(Strsql)
            Else
                XdsConciliacion.NewTable(Strsql, StrNombre)
                XdsConciliacion(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos
            If intParametroID = 36 Then
                Me.cboFirma1.DataSource = XdsConciliacion(StrNombre).Source
                Me.cboFirma1.Rebind()
            ElseIf intParametroID = 35 Then
                Me.cboFirma2.DataSource = XdsConciliacion(StrNombre).Source
                Me.cboFirma2.Rebind()
            Else
                Me.cboFirma3.DataSource = XdsConciliacion(StrNombre).Source
                Me.cboFirma3.Rebind()
            End If

            XdtValorParametro.Filter = "nStbParametroID = " & intParametroID
            XdtValorParametro.Retrieve()

            'Ubicarse en el registro recomendado de parámetros:
            If XdsConciliacion(StrNombre).Count > 0 Then
                XdsConciliacion(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Ubicarse de acuerdo con datos de la delegacion:
            XdtDelegacion.Filter = " nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion
            XdtDelegacion.Retrieve()
            If intParametroID = 35 Then 'Contador
                XdsConciliacion(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoRevisaComprobantesID"))
            ElseIf intParametroID = 28 Then 'Responsable de Gestión de Recursos:
                XdsConciliacion(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoAutorizaComprobantesID"))
            End If

            'Confugurar el combo:
            If intParametroID = 36 Then
                Me.cboFirma1.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma1.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma1.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma1.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma1.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma1.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            ElseIf intParametroID = 35 Then
                Me.cboFirma2.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma2.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma2.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma2.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma2.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma2.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Else
                Me.cboFirma3.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").Width = 50
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").Width = 150
                Me.cboFirma3.Columns("nCodPersona").Caption = "Código"
                Me.cboFirma3.Columns("sNombre").Caption = "Nombre Empleado"
                Me.cboFirma3.Splits(0).DisplayColumns("nCodPersona").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
                Me.cboFirma3.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing

            XdtDelegacion.Close()
            XdtDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       CargarCuenta
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cuentas Bancarias en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCuenta(ByVal intCuentaID As Integer)
        Try
            Dim Strsql As String

            Me.cboCuenta.ClearFields()
            If intCuentaID = 0 Then
                Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sNombreCuenta, a.sSiglas, a.sMoneda, a.sTipoCuenta, a.CodMoneda " & _
                         " From vwSteCtaBancaria a " & _
                         " WHERE a.nCerrada = 0 " & _
                         " Order by a.sNumeroCuenta "
            Else
                Strsql = " Select a.nSteCuentaBancariaID, a.sNumeroCuenta, a.sNombreCuenta, a.sSiglas, a.sMoneda, a.sTipoCuenta, a.CodMoneda " & _
                         " From vwSteCtaBancaria a " & _
                         " WHERE (a.nCerrada = 0) " & _
                         " Or a.nSteCuentaBancariaID = " & intCuentaID & _
                         " Order by a.sNumeroCuenta "
            End If

            If XdsConciliacion.ExistTable("Cuenta") Then
                XdsConciliacion("Cuenta").ExecuteSql(Strsql)
            Else
                XdsConciliacion.NewTable(Strsql, "Cuenta")
                XdsConciliacion("Cuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCuenta.DataSource = XdsConciliacion("Cuenta").Source
            Me.cboCuenta.Rebind()

            'Configurar el combo:
            Me.cboCuenta.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False
            Me.cboCuenta.Splits(0).DisplayColumns("CodMoneda").Visible = False '01 = Conciliación en Córdobas

            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 150
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").Width = 250
            Me.cboCuenta.Splits(0).DisplayColumns("sSiglas").Width = 100
            Me.cboCuenta.Splits(0).DisplayColumns("sMoneda").Width = 100
            Me.cboCuenta.Splits(0).DisplayColumns("sTipoCuenta").Width = 100

            Me.cboCuenta.Columns("sNumeroCuenta").Caption = "Número Cuenta"
            Me.cboCuenta.Columns("sNombreCuenta").Caption = "Nombre Cuenta"
            Me.cboCuenta.Columns("sSiglas").Caption = "Banco"
            Me.cboCuenta.Columns("sMoneda").Caption = "Moneda"
            Me.cboCuenta.Columns("sTipoCuenta").Caption = "Tipo Cuenta"

            Me.cboCuenta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sMoneda").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCuenta.Splits(0).DisplayColumns("sTipoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region
#Region "Detalle Documentos Contables"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       CargarDocumentosContables
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       de Documentos Contables de la Conciliación:
    '                       CF = Cheques Flotantes
    '                       DT = Depósitos en Tránsito
    '                       NC = Notas de Crédito.
    '-------------------------------------------------------------------------
    Public Sub CargarDocumentosContables()
        Try
            Dim Strsql As String

            Me.grdDocumentosContables.ClearFields()
            Strsql = " Select a.nSteConciliacionTransaccionID, a.nSteConciliacionBancariaID, a.nScnTransaccionContableDetalleID, " & _
                     " a.TipoOP, a.sNumeroTransaccion, a.dFechaTransaccion, a.nDebito, a.nMontoC, a.nMontoD, a.sDescripcion, a.sCodigoCuenta, a.FF " & _
                     " From vwSteConciliacionDocumentos a " & _
                     " Where (a.nSteConciliacionBancariaID = " & Me.intConciliacionID & ") " & _
                     " ORDER BY a.dFechaTransaccion, a.sNumeroTransaccion"

            If XdsDetalle.ExistTable("Transacciones") Then
                XdsDetalle("Transacciones").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Transacciones")
                XdsDetalle("Transacciones").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdDocumentosContables.DataSource = XdsDetalle("Transacciones").Source
            REM Refresh Grid:
            Me.grdDocumentosContables.Rebind(False)
            Me.grdDocumentosContables.FetchRowStyles = True

            'Actualizando el caption de los GRIDS:
            Me.grdDocumentosContables.Caption = "Documentos Contables (" + Me.grdDocumentosContables.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       FormatoDocumentosContables
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Documentos de la Conciliación.
    '-------------------------------------------------------------------------
    Private Sub FormatoDocumentosContables()
        Try
            'Configuración del Grid: 
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nSteConciliacionTransaccionID").Visible = False
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nSteConciliacionBancariaID").Visible = False
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nScnTransaccionContableDetalleID").Visible = False

            'Pie del Grid para totalizar Monto Total Córdobas y Dólares:
            Me.grdDocumentosContables.ColumnFooters = True
            Me.grdDocumentosContables.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoC").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoC").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoC").FooterStyle.ForeColor = Color.Blue

            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoD").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoD").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoD").FooterStyle.ForeColor = Color.Green

            Me.grdDocumentosContables.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdDocumentosContables.Splits(0).DisplayColumns("TipoOP").Width = 60
            Me.grdDocumentosContables.Splits(0).DisplayColumns("sNumeroTransaccion").Width = 180
            Me.grdDocumentosContables.Splits(0).DisplayColumns("dFechaTransaccion").Width = 80
            Me.grdDocumentosContables.Splits(0).DisplayColumns("sDescripcion").Width = 450
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nDebito").Width = 60
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoC").Width = 90
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoD").Width = 90
            Me.grdDocumentosContables.Splits(0).DisplayColumns("sCodigoCuenta").Width = 200
            Me.grdDocumentosContables.Splits(0).DisplayColumns("FF").Width = 200

            Me.grdDocumentosContables.Columns("TipoOP").Caption = "Operación"
            Me.grdDocumentosContables.Columns("sNumeroTransaccion").Caption = "Número de Documento"
            Me.grdDocumentosContables.Columns("dFechaTransaccion").Caption = "Fecha"
            Me.grdDocumentosContables.Columns("sDescripcion").Caption = "Descripción"
            Me.grdDocumentosContables.Columns("nDebito").Caption = "Débito"
            Me.grdDocumentosContables.Columns("nMontoC").Caption = "Monto C$"
            Me.grdDocumentosContables.Columns("nMontoD").Caption = "Monto US$"
            Me.grdDocumentosContables.Columns("sCodigoCuenta").Caption = "Cuenta Contable"
            Me.grdDocumentosContables.Columns("FF").Caption = "Fuente Fondos"

            Me.grdDocumentosContables.Columns("nDebito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nDebito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("TipoOP").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("dFechaTransaccion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDocumentosContables.Splits(0).DisplayColumns("TipoOP").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("sNumeroTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("dFechaTransaccion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nDebito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("nMontoD").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDocumentosContables.Splits(0).DisplayColumns("FF").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDocumentosContables.Columns("nMontoC").NumberFormat = "#,##0.00"
            Me.grdDocumentosContables.Splits(0).DisplayColumns.Item("nMontoC").Style.BackColor = Color.WhiteSmoke

            Me.grdDocumentosContables.Columns("nMontoD").NumberFormat = "#,##0.00"
            Me.grdDocumentosContables.Splits(0).DisplayColumns.Item("nMontoD").Style.BackColor = Color.WhiteSmoke

            'Calcular montos totales Córdobas y Dólares:
            CalcularMontosCD()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       CalcularMontosCD
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total en Córdobas y Dólares de Documentos. 
    '-------------------------------------------------------------------------
    Private Sub CalcularMontosCD()
        Try
            Dim vTotalC As Double = 0
            Dim vTotalD As Double = 0

            For index As Integer = 0 To Me.grdDocumentosContables.RowCount - 1
                Me.grdDocumentosContables.Row = index
                vTotalC = vTotalC + Me.grdDocumentosContables.Columns("nMontoC").Value
                vTotalD = vTotalD + Me.grdDocumentosContables.Columns("nMontoD").Value
            Next
            If Me.grdDocumentosContables.RowCount > 0 Then
                Me.grdDocumentosContables.Row = 0
            End If
            'Refrescar el FOOTER del GRID:
            Me.grdDocumentosContables.Columns("nMontoC").FooterText = Format(vTotalC, "C$ #,##0.00")
            Me.grdDocumentosContables.Columns("nMontoD").FooterText = Format(vTotalD, "US$ #,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       tbDocumentoContable_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbDocumentoContable.
    '-------------------------------------------------------------------------
    Private Sub tbDocumentoContable_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbDocumentoContable.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarD"
                LlamaAgregarDocumento()
            Case "toolModificarD"
                LlamaModificarDocumentos()
            Case "toolEliminarD"
                LlamaEliminarDocumento()
            Case "toolChequesFlotantes"
                LlamaAgregarChequesFlotantes()
            Case "toolRefrescarD"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdDocumentosContables.ClearFields()
                CargarDocumentosContables()
                FormatoDocumentosContables()
            Case "toolAyudaD"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                05/03/2008
    ' Procedure Name:       LlamaAgregarChequesFlotantes
    ' Descripción:          Este procedimiento permite agregar un Rango de 
    '                       Cheques Flotantes.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarChequesFlotantes()
        Dim ObjFrmSteEditConciliacionCF As New frmSteEditConciliacionCF
        Try

            ObjFrmSteEditConciliacionCF.IdConciliacion = Me.intConciliacionID
            ObjFrmSteEditConciliacionCF.IdDocumento = 0
            ObjFrmSteEditConciliacionCF.ShowDialog()

            'Si se ingreso un nuevo Documento Contable:
            If ObjFrmSteEditConciliacionCF.IdDocumento <> 0 Then
                CargarDocumentosContables()
                FormatoDocumentosContables()
                XdsDetalle("Transacciones").SetCurrentByID("nSteConciliacionTransaccionID", ObjFrmSteEditConciliacionCF.IdDocumento)
                Me.grdOperacionesBancarias.Row = XdsDetalle("Transacciones").BindingSource.Position
                'Inhabilitar:
                InhabilitarControles()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditConciliacionCF.Close()
            ObjFrmSteEditConciliacionCF = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaAgregarDocumento
    ' Descripción:          Este procedimiento permite agregar un Documento
    '                       Contable a la Conciliación.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarDocumento()
        Dim ObjFrmSteEditConciliacionDocumentos As New frmSteEditConciliacionDocumentos
        Try

            ObjFrmSteEditConciliacionDocumentos.IdConciliacion = Me.intConciliacionID
            ObjFrmSteEditConciliacionDocumentos.IdDocumento = 0
            ObjFrmSteEditConciliacionDocumentos.ModoFrm = "ADD"
            ObjFrmSteEditConciliacionDocumentos.ShowDialog()

            'Si se ingreso un nuevo Documento Contable:
            If ObjFrmSteEditConciliacionDocumentos.IdDocumento <> 0 Then
                CargarDocumentosContables()
                FormatoDocumentosContables()
                XdsDetalle("Transacciones").SetCurrentByID("nSteConciliacionTransaccionID", ObjFrmSteEditConciliacionDocumentos.IdDocumento)
                Me.grdOperacionesBancarias.Row = XdsDetalle("Transacciones").BindingSource.Position
                'Inhabilitar:
                InhabilitarControles()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditConciliacionDocumentos.Close()
            ObjFrmSteEditConciliacionDocumentos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaModificarDocumentos
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       para Modificar Documentos Contables.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarDocumentos()
        Dim ObjFrmSteEditDocumentos As New frmSteEditConciliacionDocumentos
        Try

            'Si no existen registros:
            If Me.grdDocumentosContables.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditDocumentos.ModoFrm = "UPD"
            ObjFrmSteEditDocumentos.IdConciliacion = Me.intConciliacionID
            ObjFrmSteEditDocumentos.IdDocumento = XdsDetalle("Transacciones").ValueField("nSteConciliacionTransaccionID")
            ObjFrmSteEditDocumentos.ShowDialog()

            CargarDocumentosContables()
            FormatoDocumentosContables()

            'Se ubica en el Documento correspondiente: 
            XdsDetalle("Transacciones").SetCurrentByID("nSteConciliacionTransaccionID", ObjFrmSteEditDocumentos.IdDocumento)
            Me.grdDocumentosContables.Row = XdsDetalle("Transacciones").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditDocumentos.Close()
            ObjFrmSteEditDocumentos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaEliminarDocumento
    ' Descripción:          Este procedimiento permite eliminar un Documento
    '                       de una Conciliación existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarDocumento()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            If Me.grdDocumentosContables.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el Documento seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(32, 3, "Eliminar SteConciliacionTransacciones", XdsDetalle("Transacciones").ValueField("nSteConciliacionTransaccionID"), InfoSistema.IDCuenta)
                XcDatos.ExecuteNonQuery("Delete From SteConciliacionTransacciones Where nSteConciliacionTransaccionID =" & XdsDetalle("Transacciones").ValueField("nSteConciliacionTransaccionID"))
                CargarDocumentosContables()
                FormatoDocumentosContables()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdDocumentosContables.Caption = "Documentos Contables (" + Me.grdDocumentosContables.RowCount.ToString + " registros)"
            End If

            'Habilitar Controles:
            InhabilitarControles()

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
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
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
    ' Fecha:                04/02/2008
    ' Procedure Name:       grdDocumentosContables_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Documento existente, al hacer doble
    '                       click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDocumentosContables_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDocumentosContables.DoubleClick
        Try
            If IntHabilitar = 1 Then
                LlamaModificarDocumentos()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso de Error:
    Private Sub grdDocumentosContables_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDocumentosContables.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que se filtren registros en la FilterBar.
    Private Sub grdDocumentosContables_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDocumentosContables.Filter
        Try
            XdsDetalle("Transacciones").FilterLocal(e.Condition)
            Me.grdDocumentosContables.Caption = "Documentos Contables (" + Me.grdDocumentosContables.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region

#Region "Detalle Operaciones Bancarias"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       CargarOperacionesBancarias
    ' Descripción:          Este procedimiento permite cargar los datos de las 
    '                       Operaciones registradas por el Banco en forma de 
    '                       Notas de Débito.
    '-------------------------------------------------------------------------
    Public Sub CargarOperacionesBancarias()
        Try
            Dim Strsql As String
            Me.grdOperacionesBancarias.ClearFields()

            Strsql = " Select a.nSteConciliacionOtrasOperacionesID, a.nSteConciliacionBancariaID, " & _
                     " a.dFechaRegistro, a.sConcepto, a.nMonto " & _
                     " From vwSteConciliacionOperaciones a " & _
                     " Where (a.nSteConciliacionBancariaID = " & Me.intConciliacionID & ") " & _
                     " Order By a.dFechaRegistro "

            If XdsDetalle.ExistTable("Operaciones") Then
                XdsDetalle("Operaciones").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Operaciones")
                XdsDetalle("Operaciones").Retrieve()
            End If

            'Asignando a las fuentes de Datos:
            Me.grdOperacionesBancarias.DataSource = XdsDetalle("Operaciones").Source
            'Refresh Grid.
            Me.grdOperacionesBancarias.Rebind(False)
            Me.grdOperacionesBancarias.FetchRowStyles = True
            'Actualizando el caption de los GRIDS:
            Me.grdOperacionesBancarias.Caption = "Operaciones Bancarias (" + Me.grdOperacionesBancarias.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       FormatoOperacionesBancarias
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Operaciones Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoOperacionesBancarias()
        Try

            'Configuracion del Grid: 
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nSteConciliacionOtrasOperacionesID").Visible = False
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nSteConciliacionBancariaID").Visible = False

            'Pie del Grid para totalizar Monto Recibos:
            Me.grdOperacionesBancarias.ColumnFooters = True
            Me.grdOperacionesBancarias.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nMonto").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nMonto").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdOperacionesBancarias.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("dFechaRegistro").Width = 80
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("sConcepto").Width = 500
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nMonto").Width = 90

            Me.grdOperacionesBancarias.Columns("dFechaRegistro").Caption = "Fecha"
            Me.grdOperacionesBancarias.Columns("sConcepto").Caption = "Concepto"

            Me.grdOperacionesBancarias.Columns("nMonto").NumberFormat = "#,##0.00"
            If cboCuenta.Columns("CodMoneda").Value = "01" Then
                Me.grdOperacionesBancarias.Columns("nMonto").Caption = "Monto C$"
                Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nMonto").FooterStyle.ForeColor = Color.Blue
            Else
                Me.grdOperacionesBancarias.Columns("nMonto").Caption = "Monto US$"
                Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nMonto").FooterStyle.ForeColor = Color.Green
            End If

            Me.grdOperacionesBancarias.Splits(0).DisplayColumns.Item("nMonto").Style.BackColor = Color.WhiteSmoke

            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("dFechaRegistro").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("sConcepto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdOperacionesBancarias.Splits(0).DisplayColumns("nMonto").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdOperacionesBancarias.Columns("dFechaRegistro").NumberFormat = "dd/MM/yyyy"

            'Calcular montos totales de Operaciones Bancarias:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Notas de Débito registradas por el Banco.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalMonto As Double = 0

            For index As Integer = 0 To Me.grdOperacionesBancarias.RowCount - 1
                Me.grdOperacionesBancarias.Row = index
                vTotalMonto = vTotalMonto + Me.grdOperacionesBancarias.Columns("nMonto").Value
            Next
            If Me.grdOperacionesBancarias.RowCount > 0 Then
                Me.grdOperacionesBancarias.Row = 0
            End If
            'Refrescar el FOOTER del GRID:
            If cboCuenta.Columns("CodMoneda").Value = "01" Then
                Me.grdOperacionesBancarias.Columns("nMonto").FooterText = Format(vTotalMonto, "C$ #,##0.00")
            Else
                Me.grdOperacionesBancarias.Columns("nMonto").FooterText = Format(vTotalMonto, "US$ #,##0.00")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       tbOperacionesBanco_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbOperacionesBanco.
    '-------------------------------------------------------------------------
    Private Sub tbOperacionesBanco_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbOperacionesBanco.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarO"
                LlamaAgregarOperaciones()
            Case "toolModificarO"
                LlamaModificarOperaciones()
            Case "toolEliminarO"
                LlamaEliminarOperaciones()
            Case "toolRefrescarO"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdOperacionesBancarias.ClearFields()
                CargarOperacionesBancarias()
                FormatoOperacionesBancarias()
            Case "toolAyudaO"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaAgregarOperaciones
    ' Descripción:          Este procedimiento permite ingresar Operaciones 
    '                       Bancarias como parte de la Conciliación.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarOperaciones()
        Dim ObjFrmSteEditOperaciones As New frmSteEditConciliacionOperaciones
        Try

            ObjFrmSteEditOperaciones.IdConciliacion = Me.intConciliacionID
            ObjFrmSteEditOperaciones.IdOperacion = 0
            ObjFrmSteEditOperaciones.ModoFrm = "ADD"
            ObjFrmSteEditOperaciones.ShowDialog()

            'Si se ingreso una nueva Operación Bancaria:
            If ObjFrmSteEditOperaciones.IdOperacion <> 0 Then
                CargarOperacionesBancarias()
                FormatoOperacionesBancarias()
                XdsDetalle("Operaciones").SetCurrentByID("nSteConciliacionOtrasOperacionesID", ObjFrmSteEditOperaciones.IdOperacion)
                Me.grdOperacionesBancarias.Row = XdsDetalle("Operaciones").BindingSource.Position
                'Inhabilitar:
                InhabilitarControles()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditOperaciones.Close()
            ObjFrmSteEditOperaciones = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaModificarOperaciones
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       para Modificar Operaciones Bancarias.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarOperaciones()
        Dim ObjFrmSteEditOperaciones As New frmSteEditConciliacionOperaciones
        Try

            'Si no existen registros:
            If Me.grdOperacionesBancarias.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditOperaciones.ModoFrm = "UPD"
            ObjFrmSteEditOperaciones.IdConciliacion = Me.intConciliacionID
            ObjFrmSteEditOperaciones.IdOperacion = XdsDetalle("Operaciones").ValueField("nSteConciliacionOtrasOperacionesID")
            ObjFrmSteEditOperaciones.ShowDialog()

            CargarOperacionesBancarias()
            FormatoOperacionesBancarias()

            'Se ubica en el recibo correspondiente:
            XdsDetalle("Operaciones").SetCurrentByID("nSteConciliacionOtrasOperacionesID", ObjFrmSteEditOperaciones.IdOperacion)
            Me.grdOperacionesBancarias.Row = XdsDetalle("Operaciones").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditOperaciones.Close()
            ObjFrmSteEditOperaciones = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/02/2008
    ' Procedure Name:       LlamaEliminarOperaciones
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una Operación Bancaria existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarOperaciones()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            If Me.grdOperacionesBancarias.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(33, 3, "Eliminar SteConciliacionTransacciones", XdsDetalle("Operaciones").ValueField("nSteConciliacionOtrasOperacionesID"), InfoSistema.IDCuenta)
                XcDatos.ExecuteNonQuery("Delete From SteConciliacionOtrasOperaciones Where nSteConciliacionOtrasOperacionesID =" & XdsDetalle("Operaciones").ValueField("nSteConciliacionOtrasOperacionesID"))
                CargarOperacionesBancarias()
                FormatoOperacionesBancarias()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdOperacionesBancarias.Caption = "Operaciones Bancarias (" + Me.grdOperacionesBancarias.RowCount.ToString + " registros)"
            End If

            'Habilitar:
            InhabilitarControles()

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
    ' Fecha:                04/02/2008
    ' Procedure Name:       grdOperacionesBancarias_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Operación, al hacer doble click sobre
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdOperacionesBancarias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdOperacionesBancarias.DoubleClick
        Try
            If IntHabilitar = 1 Then
                LlamaModificarOperaciones()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdOperacionesBancarias_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdOperacionesBancarias.Error
        Control_Error(e.Exception)
    End Sub

    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdOperacionesBancarias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdOperacionesBancarias.Filter
        Try
            XdsDetalle("Operaciones").FilterLocal(e.Condition)
            Me.grdOperacionesBancarias.Caption = "Operaciones Bancarias (" + Me.grdOperacionesBancarias.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region
End Class