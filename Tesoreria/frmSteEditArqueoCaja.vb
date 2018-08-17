' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                15/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditArqueoCaja.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de un Arqueo de Caja.
'-------------------------------------------------------------------------

Public Class frmSteEditArqueoCaja

    '-- Declaracion de Variables: 
    Dim ModoForm As String
    Dim intArqueoID As Integer
    Dim IntHabilitar As Integer
    Dim IntPermiteEditar As Integer
    Dim nCodigoTalonario As Integer
    Dim nDepartamentoCajaID As Integer
    Dim nMunicipioCajaId As Integer
    '-- Clases para procesar la informacion de los combos:
    Dim XdsArqueo As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjArqueodt As BOSistema.Win.SteEntArqueo.SteArqueoCajaDataTable
    Dim ObjArqueodr As BOSistema.Win.SteEntArqueo.SteArqueoCajaRow

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
            intStePermiteEditar = IntPermiteEditar
        End Get
        Set(ByVal value As Long)
            IntPermiteEditar = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del Arqueo.
    Public Property intSteArqueoID() As Integer
        Get
            intSteArqueoID = intArqueoID
        End Get
        Set(ByVal value As Integer)
            intArqueoID = value
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



    'Propiedad utilizada para el departamento al que pertenece la caja.
    Private Property IdDepartamentoCaja() As Integer
        Get
            IdDepartamentoCaja = nDepartamentoCajaID
        End Get
        Set(ByVal value As Integer)
            nDepartamentoCajaID = value
        End Set
    End Property

    'Propiedad utilizada para el municipio al que pertenece la caja.
    Private Property IdMunicipioCaja() As Integer
        Get
            IdMunicipioCaja = nMunicipioCajaId
        End Get
        Set(ByVal value As Integer)
            nMunicipioCajaId = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       frmSteEditArqueoCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditArqueoCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsArqueo.Close()
                XdsArqueo = Nothing

                ObjArqueodt.Close()
                ObjArqueodt = Nothing

                ObjArqueodr.Close()
                ObjArqueodr = Nothing

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
    ' Fecha:                15/01/2008
    ' Procedure Name:       frmSteEditArqueoCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Arqueo en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditArqueoCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            Me.IntPermiteEditar = Me.IntPermiteEditar
            InicializarVariables()

            'Cargar Combos de Caja:
            'Quitar
            'MsgBox("Antes de  CargarCaja(0) .", MsgBoxStyle.Information)
            CargarCaja(0)
            'MsgBox("Antes de  CargarCajero(0) .", MsgBoxStyle.Information)
            CargarCajero(0)
            'MsgBox("Antes de  CargarMinuta(0) .", MsgBoxStyle.Information)
            CargarMinuta(0)

            'MsgBox("Antes de  CargarFirma1  .", MsgBoxStyle.Information)
            'Tres Firmas (Empleados del Programa):
            CargarFirmas(0, 34, "FirmaUno")     'Tesorero
            'MsgBox("Antes de  CargarFirma2  .", MsgBoxStyle.Information)
            CargarFirmas(0, 35, "FirmaDos")     'Contador
            'MsgBox("Antes de  CargarFirma3  .", MsgBoxStyle.Information)
            CargarFirmas(0, 13, "FirmaTres")    'Responsable de Crédito

            'Si el formulario está en modo edición
            'cargar los datos de la ficha.
            If ModoForm = "UPD" Then
                CargarArqueo()
                InhabilitarControles()
                'Cargar segunda y tercer pestaña:
                CargarEfectivo()
                FormatoEfectivo()
                CargarDocumentos()
                FormatoDocumentos()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

            If cdeFechaA.Enabled Then
                Me.cdeFechaA.Select()
            End If

            ' Anular un recibo del arqueo:
            If Seg.HasPermission("AnularReciboArqueo") Then
                Me.toolAnularR.Enabled = True
            Else
                Me.toolAnularR.Enabled = False
            End If
            ''
            'MsgBox("Antes de  Seguridad  .", MsgBoxStyle.Information)
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            Dim strSQL As String
            '-- Inhabilitar:
            If IntHabilitar = 0 Then
                Me.grpDatosGenerales.Enabled = False
                Me.grpObservaciones.Enabled = False
                Me.grpFirmas.Enabled = False
                Me.tbArqueoDocumentos.Enabled = False
                'Anexado para agregar el boton de anular recibo dentro del arqueo febrero 23 del 2011
                'toolIncorporarR.Enabled = False
                'toolAgregarR.Enabled = False
                'toolModificarR.Enabled = False
                'toolEliminarR.Enabled = False
                'toolEliminarRS.Enabled = False
                'toolRefrescarR.Enabled = False
                'toolAyudaR.Enabled = False
                'Me.toolAnularR.Enabled = False




                Me.tbArqueoEfectivo.Enabled = False
                Me.CmdAceptar.Enabled = False
            End If

            'Si ya tiene Recibos Automaticos asociados:
            strSQL = "SELECT * FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & Me.intArqueoID & ") AND (nSccReciboOficialCajaID IS NOT NULL)"
            If (RegistrosAsociados(strSQL)) Then
                Me.cboCaja.Enabled = False
                Me.cboCajero.Enabled = False
                Me.cdeFechaA.Enabled = False
                Me.chkTrasladoValores.Enabled = False
            Else
                Me.cboCaja.Enabled = True
                Me.cboCajero.Enabled = True
                Me.cdeFechaA.Enabled = True
                Me.chkTrasladoValores.Enabled = True
            End If


            'Si ya tiene Recibos de Caja ACTIVOS (manuales) asociados en CREDITO:
            strSQL = " SELECT a.nCodigo FROM " & _
                                "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario " & _
                                "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " & _
                                "And (nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") AND (nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                                ") AS a INNER JOIN " & _
                                " (SELECT AR.nCodigo, D.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " & _
                                "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                                "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                                "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                                " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) " & _
                                "AS b " & _
                    "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " & _
                    "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " & _
                    "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " & _
                    "AND a.nCodigoTalonario = b.nCodigoTalonario"
            If RegistrosAsociados(strSQL) Then
                Me.cdeFechaA.Enabled = False
                Me.cboCaja.Enabled = False
                Me.cboCajero.Enabled = False
            Else
                Me.cdeFechaA.Enabled = True
                Me.cboCaja.Enabled = True
                Me.cboCajero.Enabled = True
            End If

            'Si ya tiene documentos asociados:
            REM DEBIDO A LA INCLUSION DE CODIGO DE TALONARIO SI SE CAMBIA LA FECHA SE CORRE EL RIESGO
            REM DE QUE LA NUEVA FECHA CORRESPONDA A OTRA SECUENCIA DE TALONARIO:
            strSQL = "SELECT * FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & Me.intArqueoID & ")"
            If RegistrosAsociados(strSQL) Then
                Me.cdeFechaA.Enabled = False
                Me.cboCaja.Enabled = False
                Me.cboCajero.Enabled = False
            Else
                Me.cdeFechaA.Enabled = True
                Me.cboCaja.Enabled = True
                Me.cboCajero.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Arqueo de Caja"
                Me.tabEfectivo.Enabled = False
                Me.tabDocumentos.Enabled = False
            Else
                Me.Text = "Modificar Arqueo de Caja"
                Me.tabEfectivo.Enabled = True
                Me.tabDocumentos.Enabled = True
            End If

            Me.tbArqueoEfectivo.Visible = True
            Me.tbArqueoDocumentos.Visible = True

            ObjArqueodt = New BOSistema.Win.SteEntArqueo.SteArqueoCajaDataTable
            ObjArqueodr = New BOSistema.Win.SteEntArqueo.SteArqueoCajaRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdsArqueo = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboCaja.ClearFields()
            Me.cboCajero.ClearFields()
            Me.cboFirma1.ClearFields()
            Me.cboFirma2.ClearFields()
            Me.cboFirma3.ClearFields()
            Me.cboMinuta.ClearFields()

            'Limpiar los Grids:
            Me.grdArqueoDocumentos.ClearFields()
            Me.grdArqueoEfectivo.ClearFields()

            'Por defecto se abre en Datos Generales:
            Me.tabArqueo.SelectedIndex = 0

            If ModoForm = "ADD" Then
                'Inicializar Fecha:
                Me.cdeFechaA.Value = ModSMUSURA0.FechaServer
                ObjArqueodr = ObjArqueodt.NewRow

                Me.txtObservaciones.MaxLength = ObjArqueodr.GetColumnLenght("sObservaciones")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub



    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CargarArqueo
    ' Descripción:          Este procedimiento permite cargar los datos del Arqueo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarArqueo()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable

        Try
            Dim strSQL As String = ""

            '-- Buscar Arqueo correspondiente al Id especificado como
            '-- parámetro, en los casos que se esté editando uno.
            ObjArqueodt.Filter = "nSteArqueoCajaID = " & Me.intArqueoID
            ObjArqueodt.Retrieve()
            If ObjArqueodt.Count = 0 Then
                Exit Sub
            End If
            ObjArqueodr = ObjArqueodt.Current

            'Código de Arqueo:
            If Not ObjArqueodr.IsFieldNull("nCodigo") Then
                Me.txtCodigo.Text = ObjArqueodr.nCodigo
                Me.txtCodigoAE.Text = ObjArqueodr.nCodigo
                Me.txtCodigoAD.Text = ObjArqueodr.nCodigo
            Else
                Me.txtCodigo.Text = ""
                Me.txtCodigoAE.Text = ""
                Me.txtCodigoAD.Text = ""
            End If

            'Estado Arqueo:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjArqueodr.nStbEstadoArqueoID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoAE.Text = ObjEstadoDT.ValueField("sDescripcion")
                Me.txtEstadoAD.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

            'Fecha de Arqueo:
            If Not ObjArqueodr.IsFieldNull("dFechaArqueo") Then
                Me.cdeFechaA.Value = ObjArqueodr.dFechaArqueo
            Else
                Me.cdeFechaA.Value = Me.cdeFechaA.ValueIsDbNull
            End If

            'Observaciones:
            If Not ObjArqueodr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjArqueodr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Arqueo de Efectivo o de Traslado de Valores:
            If Not ObjArqueodr.IsFieldNull("nTrasladoValores") Then
                Me.chkTrasladoValores.Checked = ObjArqueodr.nTrasladoValores
            End If

            'Primer Firma (Empleado Tesorero):
            If Not ObjArqueodr.IsFieldNull("nSrhTesoreroId") Then
                If Me.cboFirma1.ListCount > 0 Then
                    Me.cboFirma1.SelectedIndex = 0
                End If
                XdsArqueo("FirmaUno").SetCurrentByID("nSrhEmpleadoID", ObjArqueodr.nSrhTesoreroId)
            Else
                Me.cboFirma1.Text = ""
                Me.cboFirma1.SelectedIndex = -1
            End If

            'Segunda Firma (Empleado Contador):
            If Not ObjArqueodr.IsFieldNull("nSrhContadorId") Then
                If Me.cboFirma2.ListCount > 0 Then
                    Me.cboFirma2.SelectedIndex = 0
                End If
                XdsArqueo("FirmaDos").SetCurrentByID("nSrhEmpleadoID", ObjArqueodr.nSrhContadorId)
            Else
                Me.cboFirma2.Text = ""
                Me.cboFirma2.SelectedIndex = -1
            End If

            'Tercer Firma (Responsable de Crédito):
            If Not ObjArqueodr.IsFieldNull("nSrhCreditoId") Then
                If Me.cboFirma3.ListCount > 0 Then
                    Me.cboFirma3.SelectedIndex = 0
                End If
                XdsArqueo("FirmaTres").SetCurrentByID("nSrhEmpleadoID", ObjArqueodr.nSrhCreditoId)
            Else
                Me.cboFirma3.Text = ""
                Me.cboFirma3.SelectedIndex = -1
            End If

            'Número Depósito:
            If Not ObjArqueodr.IsFieldNull("nSteMinutaDepositoID") Then
                CargarMinuta(ObjArqueodr.nSteMinutaDepositoID)
                If cboMinuta.ListCount > 0 Then
                    Me.cboMinuta.SelectedIndex = 0
                End If
                XdsArqueo("Minuta").SetCurrentByID("nSteMinutaDepositoID", ObjArqueodr.nSteMinutaDepositoID)
            Else
                Me.cboMinuta.Text = ""
                Me.cboMinuta.SelectedIndex = -1
            End If

            'Caja:
            If Not ObjArqueodr.IsFieldNull("nSteCajaID") Then
                CargarCaja(ObjArqueodr.nSteCajaID)
                If Me.cboCaja.ListCount > 0 Then
                    Me.cboCaja.SelectedIndex = 0
                End If
                XdsArqueo("Caja").SetCurrentByID("nSteCajaID", ObjArqueodr.nSteCajaID)
            Else
                Me.cboCaja.Text = ""
                Me.cboCaja.SelectedIndex = -1
            End If

            'Cajero:
            If Not ObjArqueodr.IsFieldNull("nSrhCajeroId") Then
                CargarCajero(ObjArqueodr.nSrhCajeroId)
                If Me.cboCajero.ListCount > 0 Then
                    Me.cboCajero.SelectedIndex = 0
                End If
                XdsArqueo("Cajero").SetCurrentByID("nSrhEmpleadoID", ObjArqueodr.nSrhCajeroId)
            Else
                Me.cboCajero.Text = ""
                Me.cboCajero.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjArqueodr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2007
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
                SalvarArqueo()

                'Habilita las siguientes Pestañas:
                Me.tabEfectivo.Enabled = True
                Me.tabDocumentos.Enabled = True

                'Actualiza Etiqueta del Código del Arqueo:
                Me.txtCodigo.Text = ObjArqueodr.nCodigo
                Me.txtCodigoAE.Text = ObjArqueodr.nCodigo
                Me.txtCodigoAD.Text = ObjArqueodr.nCodigo

                'Actualiza Estado:
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjArqueodr.nStbEstadoArqueoID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstado.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoAE.Text = ObjEstadoDT.ValueField("sDescripcion")
                    Me.txtEstadoAD.Text = ObjEstadoDT.ValueField("sDescripcion")
                End If

                If Me.intArqueoID <> 0 Then
                    If MsgBox("¿Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        CargarEfectivo()
                        FormatoEfectivo()
                        CargarDocumentos()
                        FormatoDocumentos()
                        Me.tabEfectivo.Show()
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
    ' Fecha:                15/01/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim MontoMinuta, MontoEfectivo As Double
            Dim strSQL As String = ""
            Dim IdDepartamento As Integer
            ValidaDatosEntrada = True
            Me.errArqueo.Clear()

            'Fecha de Arqueo:
            If (Me.cdeFechaA.ValueIsDbNull) Then
                MsgBox("La Fecha de Arqueo NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFechaA, "La Fecha de Arqueo NO DEBE quedar vacía.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Arqueo no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Arqueo NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFechaA, "La Fecha de Arqueo NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Fecha Arqueo no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Arqueo NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFechaA, "La Fecha de Arqueo NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Imposible si el periodo de la fecha de arqueo esta Cerrado:
            If PeriodoAbiertoDadaFecha(Me.cdeFechaA.Value) = False Then
                MsgBox("La Fecha de Arqueo corresponde a un" & Chr(13) & "período contable cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFechaA, "La Fecha de Arqueo corresponde a un período contable cerrado.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            nCodigoTalonario = IntCodigoTalonario(Format(Me.cdeFechaA.Value, "yyyy-MM-dd"))

            'Caja:
            If Me.cboCaja.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Caja válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                Me.cboCaja.Focus()
                Exit Function
            End If

            'Imposible si la Caja se encuentra Cerrada:
            If Me.cboCaja.Columns("nCerrada").Value = 1 Then
                MsgBox("La Caja seleccionada se encuentra Cerrada.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                Me.cboCaja.Focus()
                Exit Function
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            'Modificación Solicitud Azucena 17/Marzo/2009
            If IntPermiteEditar = 0 Then
                REM REM
                'strSQL = "SELECT nStbMunicipioID FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                'If cboCaja.Columns("nStbMunicipioId").Value <> XcDatos.ExecuteScalar(strSQL) Then
                '    MsgBox("Caja no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                '    ValidaDatosEntrada = False
                '    Me.errArqueo.SetError(Me.cboCaja, "Debe seleccionar una Caja válido.")
                '    Me.cboCaja.Focus()
                '    Exit Function
                'End If
                '1. Caja seleccionada Debe corresponder con la Delegación del usuario:
                If cboCaja.Columns("nStbDelegacionProgramaID").Value <> InfoSistema.IDDelegacion Then
                    MsgBox("Caja no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboCaja, "Debe seleccionar una Caja válida.")
                    Me.cboCaja.Focus()
                    Exit Function
                End If
                '2. Cajero no corresponde a su Delegación:
                If cboCajero.Columns("nStbDelegacionProgramaID").Value <> InfoSistema.IDDelegacion Then
                    MsgBox("Cajero no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                    Me.cboCajero.Focus()
                    Exit Function
                End If
            End If

            'Fecha de Arqueo NO debe ser inferior a la de apertura de la Caja:
            If Me.cdeFechaA.Value < cboCaja.Columns("dFechaApertura").Value Then
                MsgBox("La Fecha de Arqueo NO DEBE ser menor" & Chr(13) & "que la de apertura de la Caja.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFechaA, "Fecha de Arqueo NO DEBE ser menor a la de Apertura de la Caja.")
                Me.cdeFechaA.Focus()
                Exit Function
            End If

            'Cajero:
            If Me.cboCajero.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Cajero válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                Me.cboCajero.Focus()
                Exit Function
            End If

            'Imposible si el Cajero no se encuentra Activo:
            If Me.cboCajero.Columns("nActivo").Value = 0 Then
                MsgBox("El Cajero no se encuentra Activo.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                Me.cboCajero.Focus()
                Exit Function
            End If

            REM REM HABILITAR CUANDO EMPIECEN A FUNCIONAR LAS CAJAS DESCONECTADAS Y AUTOMATICAS.
            REM REM Y LIBERAR LA VALIDACION CAJA - CAJERO QUE ADMITA MAS DE UNA CAJA ACTIVA
            REM REM PARA ESTO ADICIONALMENTE NO SE DEBE GENERAR EL USB DE LAS CAJAS DESCONECTADAS
            REM REM SI EL CAJERO TIENE MAS DE UNA CAJA ACTIVA. NI SE DEBE PERMITIR EN LOS RECIBOS
            REM REM AUTOMATICOS QUE EXISTA MAS DE UNA CAJA ACTIVA.
            'Imposible si el Cajero no tiene la Caja asignada y ACTIVA:
            'strSQL = "SELECT SteCajeroCajas.nSteCajeroCajasID " & _
            '         "FROM  SteCajeroCajas INNER JOIN SteCajero ON SteCajeroCajas.nSteCajeroID = SteCajero.nSteCajeroID " & _
            '         "WHERE (SteCajero.nSrhEmpleadoID = " & cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (SteCajeroCajas.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (SteCajeroCajas.nActiva = 1) AND (SteCajero.nActivo = 1)"
            'If RegistrosAsociados(strSQL) = False Then
            '    MsgBox("El Cajero no tiene esta Caja asignada y ACTIVA.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errArqueo.SetError(Me.cboCajero, "Cajero inválido para la Caja.")
            '    Me.cboCajero.Focus()
            '    Exit Function
            'End If

            'Si se indicó Minuta de Depósito:
            If Me.cboMinuta.SelectedIndex <> -1 Then
                '1:  Minuta no debe estar asociada con otra Fecha de Arqueo:
                strSQL = "SELECT * " & _
                         "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND (nSteArqueoCajaID <> " & Me.intArqueoID & ") AND (dFechaArqueo <> CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                         "And (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') "
                If RegistrosAsociados(strSQL) Then
                    MsgBox("La Minuta ya ha sido asociada con otra Fecha de Arqueo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La Minuta ya ha sido asociada con otra Fecha de Arqueo.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If

                '1.1:  Minuta no debe estar asociada con otro Arqueo:
                strSQL = "SELECT * " &
                         "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " &
                         "WHERE (nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND (nSteArqueoCajaID <> " & Me.intArqueoID & ") " &
                         "And (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') "
                If RegistrosAsociados(strSQL) Then
                    MsgBox("La Minuta ya ha sido asociada a otro Arqueo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La Minuta ya ha sido asociada a otro Arqueo.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '2: La Minuta No debe estar enviada a Hacienda:
                strSQL = "SELECT SteMinutaDeposito.nSteMinutaDepositoID " & _
                         "FROM SteMinutaDeposito INNER JOIN StbValorCatalogo ON SteMinutaDeposito.nStbEstadoMinutaID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '1') AND (SteMinutaDeposito.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ")"
                If RegistrosAsociados(strSQL) = True Then
                    MsgBox("La Minuta de Depósito no se encuentra En Proceso.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La Minuta ya ha sido enviada a Hacienda.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '3: El Municipio de la Minuta debe corresponder con el de la Caja: 
                strSQL = "SELECT * FROM SteMinutaDeposito WHERE (nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND (nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ")"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("El Municipio de la Minuta de Depósito seleccionada" & Chr(13) & "no corresponde con la ubicación de la Caja.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La Minuta ha sido asociada a otro Municipio.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '4: La fecha de la Minuta no debe ser menor que la del Arqueo:
                If (DateDiff("d", Format(cdeFechaA.Value, "yyyy-MM-dd"), Format(Me.cboMinuta.Columns("dFechaDeposito").Value, "yyyy-MM-dd")) < 0) Then
                    MsgBox("Fecha de la Minuta no debe ser menor" & Chr(13) & " que la Fecha del Arqueo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "Fecha de la Minuta no debe ser menor que la Fecha del Arqueo.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '5: No debe haber una diferencia superior a los 10 días entre la fecha  
                '   de la Minuta y la fecha del Arqueo:
                If (DateDiff("d", Format(cdeFechaA.Value, "yyyy-MM-dd"), Format(Me.cboMinuta.Columns("dFechaDeposito").Value, "yyyy-MM-dd")) > 10) Then
                    MsgBox("Fecha del depósito no debe ser más de 10 días" & Chr(13) & "superior a la Fecha del Arqueo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "Fecha de la Minuta Inválida.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '6. Deben Existir Documentos Asociados al Arqueo:
                strSQL = "SELECT * FROM SteArqueoRecibo WHERE (nSteArqueoCajaID = " & Me.intArqueoID & ")"
                If RegistrosAsociados(strSQL) = False Then
                    MsgBox("Imposible asignar Minuta, el Arqueo" & Chr(13) & "no tiene Documentos asociados.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "No Existen Documentos Asociados.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '7. Imposible si Suma de Efectivo es Cero:
                strSQL = "SELECT SUM(nCantidad) AS MontoR FROM SteArqueoDenominacion WHERE  (nSteArqueoCajaID = " & Me.intArqueoID & ") HAVING (SUM(nCantidad) = 0)"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Imposible asignar Minuta." & Chr(13) & "La suma de Efectivo es Cero.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La suma de Efectivo es Cero.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '8. Imposible si suma de Documentos es Cero:
                strSQL = "SELECT  SUM(nValor) AS MontoR FROM SteArqueoRecibo WHERE  (nSteArqueoCajaID = " & Me.intArqueoID & ") HAVING  (SUM(nValor) = 0)"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Imposible asignar Minuta." & Chr(13) & "La suma de Recibos es Cero.", MsgBoxStyle.Information, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La suma de Recibos es Cero.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
                '14/01/2010:
                '9 La Minuta NO debe estar asociada a un Arqueo de Otro Tipo de Programa:
                strSQL = "SELECT * " & _
                         "FROM  SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN SteCaja ON SteArqueoCaja.nSteCajaID = SteCaja.nSteCajaID " & _
                         "WHERE (nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") AND (nSteArqueoCajaID <> " & Me.intArqueoID & ")  " & _
                         "And (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') AND (SteCaja.nStbTipoProgramaID <> " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("La Minuta ya ha sido asociada a otro Programa.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "La Minuta ya ha sido asociada a otro Programa.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If

                'El monto de la minuta debe ser no mas de un centavo diferente del monto en efectivo.
                '10

                strSQL = " Select Sum(a.Total) as Total " & _
                        " From vwSteArqueoDenominaciones a " & _
                        " Where (a.nSteArqueoCajaID = " & Me.intArqueoID & ") "



                MontoEfectivo = XcDatos.ExecuteScalar(strSQL)


                strSQL = "SELECT nMontoDeposito FROM SteMinutaDeposito WHERE nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value

                MontoMinuta = XcDatos.ExecuteScalar(strSQL)

                If Math.Abs(MontoEfectivo - MontoMinuta) > 0.1 Then
                    MsgBox("Monto de la Minuta difiere en mas de un centavo con el monto del efectivo.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboMinuta, "Monto de la Minuta difiere en mas de un centavo con el monto del efectivo.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If

            End If

            'Primer Firma: 
            If Me.cboFirma1.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Tesorero.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboFirma1, "Debe indicar nombre del Tesorero.")
                Me.cboFirma1.Focus()
                Exit Function
            End If

            'Segunda Firma: 
            If Me.cboFirma2.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Contador.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboFirma2, "Debe indicar nombre del Contador.")
                Me.cboFirma2.Focus()
                Exit Function
            End If

            'Tercer Firma:
            If Me.cboFirma3.SelectedIndex = -1 Then
                MsgBox("Debe indicar nombre del Responsable de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboFirma3, "Debe indicar nombre del Responsable de Crédito.")
                Me.cboFirma3.Focus()
                Exit Function
            End If

            'No agregar Arqueo de una Caja que tenga otro Arqueo En Proceso:
            strSQL = "SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ")"
            IdDepartamento = XcDatos.ExecuteScalar(strSQL)
            'strSQL = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
            '         "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SteArqueoCaja.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (SteArqueoCaja.nSteArqueoCajaID <> " & Me.intArqueoID & ")"
            strSQL = "SELECT SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SteArqueoCaja.nSrhCajeroId = " & cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (SteArqueoCaja.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") AND (SteArqueoCaja.nSteArqueoCajaID <> " & Me.intArqueoID & ") " & _
                     "AND (SteArqueoCaja.nTrasladoValores = " & IIf(Me.chkTrasladoValores.Checked = True, 1, 0) & ")"
            If RegistrosAsociados(strSQL) Then
                If IdDepartamento <> 9 Then 'SI ES UNA DELEGACION DEPARTAMENTAL (León = 6)
                    If MsgBox("Ya existe un Arqueo En Proceso de este tipo para esta Caja y Cajero." & Chr(13) & "¿Está seguro de registrar el Arqueo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        ValidaDatosEntrada = False
                        Me.errArqueo.SetError(Me.cboCaja, "Existen Arqueos aún No Cerrados para esta Caja y Cajero.")
                        Me.cboCaja.Focus()
                        Exit Function
                    End If
                Else 'Managua :
                    If Me.chkTrasladoValores.Checked Then
                        MsgBox("Existen Arqueos por Traslado de Valores" & Chr(13) & "aún No Cerrados para esta Caja y Cajero.", MsgBoxStyle.Critical, NombreSistema)
                    Else
                        MsgBox("Existen Arqueos de Efectivo aún No Cerrados" & Chr(13) & "para esta Caja y Cajero.", MsgBoxStyle.Critical, NombreSistema)
                    End If
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboCaja, "Existen Arqueos aún No Cerrados para esta Caja y Cajero.")
                    Me.cboCaja.Focus()
                    Exit Function
                End If
            End If

            'No agregar mas de un Arqueo para el mismo Cajero en la misma Fecha y Caja:
            strSQL = "SELECT  SteArqueoCaja.nSteArqueoCajaID " & _
                     "FROM SteArqueoCaja INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4') AND (SteArqueoCaja.nSteArqueoCajaID <> " & Me.intArqueoID & ") AND (SteArqueoCaja.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) AND (SteArqueoCaja.nSrhCajeroId = " & cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (SteArqueoCaja.nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ") " & _
                     "AND (SteArqueoCaja.nTrasladoValores = " & IIf(Me.chkTrasladoValores.Checked = True, 1, 0) & ")"
            If RegistrosAsociados(strSQL) Then
                If IdDepartamento <> 9 Then 'SI ES UNA DELEGACION DEPARTAMENTAL (León = 6)
                    If MsgBox("Ya existe un Arqueo de este tipo para este Cajero en esta Caja y Fecha." & Chr(13) & "¿Está seguro de registrar el Arqueo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        ValidaDatosEntrada = False
                        Me.errArqueo.SetError(Me.cboCaja, "Existe Arqueo ACTIVO para este Cajero en esta Caja y Fecha.")
                        Me.cboCaja.Focus()
                        Exit Function
                    End If
                Else 'Managua y Otras Delegaciones:
                    If Me.chkTrasladoValores.Checked Then
                        MsgBox("Ya se registró el Arqueo de Traslado de Valores" & Chr(13) & "para este Cajero en esta Caja y Fecha.", MsgBoxStyle.Critical, NombreSistema)
                    Else
                        MsgBox("Ya se registró el Arqueo de Efectivo para este Cajero" & Chr(13) & "en esta Caja y Fecha.", MsgBoxStyle.Critical, NombreSistema)
                    End If
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboCajero, "Existe Arqueo ACTIVO para este Cajero en esta Caja y Fecha.")
                    Me.cboCajero.Focus()
                    Exit Function
                End If
            End If

            'Minuta NO PUEDE estar asociada a un Recibo de Pagaré Activo
            If cboMinuta.SelectedIndex <> -1 Then
                strSQL = "SELECT  SteReciboPagare.nSteReciboPagareID " & _
                         "FROM SteReciboPagare INNER JOIN StbValorCatalogo ON SteReciboPagare.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SteReciboPagare.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Ya existe Pagaré asociado a esta Minuta.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.CmdAceptar.Enabled = True
                    Me.cmdCancelar.Enabled = True
                    Me.errArqueo.SetError(Me.cboMinuta, "Ya existe Pagaré asociado a esta Minuta.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If
            End If

            'A partir del 11 de Agosto 2008 VALIDAR vs. Talonarios:
            Dim dFechaD As Date
            dFechaD = "10/08/2008" 'A partir del 11 de Agosto 2008 VALIDAR vs. Talonarios:
            If CDate(Format(Me.cdeFechaA.Value, "yyyy-MM-dd")) > dFechaD Then
                'Imposible si no hay Entrega registrada para la Fecha y Cajero y que esten 
                'Cerrados en el Departamento, Programa y Periodicidad de Pagos:

                'MsgBox(cboCaja.Columns("nStbDelegacionProgramaID").Value)
                If Val((Me.cboCaja.Columns("nHaceArqueo").Value)) <> "1" Then
                    strSQL = "SELECT RE.nSrhCajeroId " & _
                             "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " & _
                             "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " & _
                             "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                             "AND (RE.nCerrado = 1) " & _
                             "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                             "AND (RE.nStbTipoPlazoPagosID  = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                             "AND (RE.nCodigoTalonario = " & Me.nCodigoTalonario & ")"
                    If RegistrosAsociados(strSQL) = False Then
                        MsgBox("No Existen Entregas de Recibos Oficiales Cerradas" & Chr(13) & "para el Departamento, Programa y Periodicidad de" & Chr(13) & "Pagos de la Caja, Cajero y Fecha de Arqueo.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errArqueo.SetError(Me.cboCajero, "Antes DEBE registrar y Cerrar las Entregas de Recibos.")
                        Me.cboCajero.Focus()
                        Exit Function
                    End If
                End If

                'Imposible si hay Entregas sin Cerrar para la Fecha y Cajero en el Departamento:
                strSQL = "SELECT RE.nSrhCajeroId " & _
                         "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " & _
                         "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " & _
                         "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                         "AND (RE.nCerrado = 0) " & _
                         "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                         "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                         "AND (RE.nCodigoTalonario = " & Me.nCodigoTalonario & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Existen Entregas de Recibos Oficiales asociadas sin Cerrar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboCajero, "Antes DEBE Cerrar las Entregas de Recibos.")
                    Me.cboCajero.Focus()
                    Exit Function
                End If
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
    ' Autor:                Liesel Cruz
    ' Fecha:                24/01/2017
    ' Procedure Name:       ObtenerMunicipioCaja
    ' Descripción:          Esta función permite obtener el id de Municipio de la 
    '                       Caja a la que pertenece el arqueo.

    ' ------------------------------------------------------------------------

    Private Function ObtenerMunicipioCaja() As Integer
        Dim xDatos As New BOSistema.Win.XComando
        'Dim nMunicipioId As Integer
        Dim StrSql As String
        ObtenerMunicipioCaja = 0

        StrSql = "SELECT        U.nStbMunicipioID " & _
                "FROM dbo.SteArqueoCaja AS AC INNER JOIN " & _
                "dbo.SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN " & _
                "dbo.vwStbUbicacionGeografica AS U ON C.nStbBarrioID = U.nStbBarrioID " & _
                "WHERE(C.nSteCajaID = " & ObjArqueodr.nSteCajaID & ") And (AC.nSteArqueoCajaID =" & Me.intArqueoID & ")"
        ObtenerMunicipioCaja = xDatos.ExecuteScalar(StrSql)
        Try

        Catch ex As Exception
            ObtenerMunicipioCaja = 0
            Control_Error(ex)
        Finally
            xDatos.Close()
            xDatos = Nothing
        End Try
    End Function
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/09/2007
    ' Procedure Name:       SalvarArqueo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Ficha en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarArqueo()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim intIdMinuta As Integer

            If Me.cboMinuta.SelectedIndex = -1 Then
                intIdMinuta = -1
            Else
                intIdMinuta = cboMinuta.Columns("nSteMinutaDepositoID").Value
            End If

            If ModoFrm <> "ADD" Then
                GuardarAuditoriaTablas(29, 2, "Actualizar SteArqueoCaja", Me.intArqueoID, InfoSistema.IDCuenta)

            End If

            strSQL = " EXEC spSteGrabarArqueo " & Me.intArqueoID & "," & IIf(Me.chkTrasladoValores.Checked = True, 1, 0) & ", " & Me.cboCaja.Columns("nSteCajaID").Value & "," _
                        & Me.cboCajero.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma1.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma2.Columns("nSrhEmpleadoID").Value & "," & Me.cboFirma3.Columns("nSrhEmpleadoID").Value & ", " & intIdMinuta & ", '" _
                        & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "','" & Me.ModoForm & "'," & InfoSistema.IDCuenta & ",'" & Trim(RTrim(Me.txtObservaciones.Text)) & "'"
            Me.intArqueoID = XcDatos.ExecuteScalar(strSQL)

            '-- Buscar la ficha correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjArqueodt.Filter = "nSteArqueoCajaID = " & Me.intArqueoID
            ObjArqueodt.Retrieve()
            If ObjArqueodt.Count = 0 Then
                Exit Sub
            End If
            ObjArqueodr = ObjArqueodt.Current

            If ModoFrm = "ADD" Then
                GuardarAuditoriaTablas(29, 1, "Agregar SteArqueoCaja", Me.intArqueoID, InfoSistema.IDCuenta)

            End If

            'Si el salvado se realizó de forma satisfactoria 
            'enviar mensaje informando y cerrar el formulario.
            If Me.intArqueoID = 0 Then
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
    ' Fecha:                15/01/2008
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

            If (vbModifico = True) And (ObjArqueodr.nStbEstadoArqueoID = XcDatos.ExecuteScalar(strSQL)) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR:
                        If ValidaDatosEntrada() Then
                            SalvarArqueo()
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

    Private Sub cboFirma1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma1.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma2.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboFirma3_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFirma3.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboCaja_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCaja.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCajero.TextChanged
        vbModifico = True
    End Sub

#Region "Combos"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2007
    ' Procedure Name:       CargarFirmas
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Empleados sugiriendo el empleado registrado en 
    '                       parámetros para primer, segunda y tercer firma:
    '                       intParametroID = 34 (Firma1); StrNombre = FirmaUno
    '                       intParametroID = 35 (Firma2); StrNombre = FirmaDos
    '                       intParametroID = 13 (Firma3); StrNombre = FirmaTres
    '-------------------------------------------------------------------------
    Private Sub CargarFirmas(ByVal intEmpleadoID As Integer, ByVal intParametroID As Integer, ByVal StrNombre As String)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Dim XdtDelegacion As New BOSistema.Win.StbEntDelegacionPrograma.StbDelegacionProgramaDataTable
        Try

            Dim Strsql As String

            If intParametroID = 34 Then
                Me.cboFirma1.ClearFields()
            ElseIf intParametroID = 35 Then 'Contador
                Me.cboFirma2.ClearFields()
            Else
                Me.cboFirma3.ClearFields()
            End If

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

            If XdsArqueo.ExistTable(StrNombre) Then
                XdsArqueo(StrNombre).ExecuteSql(Strsql)
            Else
                XdsArqueo.NewTable(Strsql, StrNombre)
                XdsArqueo(StrNombre).Retrieve()
            End If

            'Asignando a las fuentes de datos

            If intParametroID = 34 Then
                Me.cboFirma1.DataSource = XdsArqueo(StrNombre).Source
                Me.cboFirma1.Rebind()
            ElseIf intParametroID = 35 Then
                Me.cboFirma2.DataSource = XdsArqueo(StrNombre).Source
                Me.cboFirma2.Rebind()
            Else
                Me.cboFirma3.DataSource = XdsArqueo(StrNombre).Source
                Me.cboFirma3.Rebind()
            End If

            XdtValorParametro.Filter = "nStbParametroID = " & intParametroID
            XdtValorParametro.Retrieve()

            'Ubicarse en el registro recomendado de parámetros:
            If XdsArqueo(StrNombre).Count > 0 Then
                XdsArqueo(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            XdtDelegacion.Filter = " nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion
            XdtDelegacion.Retrieve()

            If intParametroID = 34 Then 'Tesorero
                XdsArqueo(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoFirmaTesoreroID"))
            ElseIf intParametroID = 35 Then 'Contador
                XdsArqueo(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoRevisaComprobantesID"))
            ElseIf intParametroID = 13 Then 'Responsable de Crédito (Tercer Firma del Comité de Crédito)
                XdsArqueo(StrNombre).SetCurrentByID("nSrhEmpleadoID", XdtDelegacion.ValueField("nSrhEmpleadoFirmaCComiteID"))
            End If

            'Confugurar el combo:
            If intParametroID = 34 Then
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
    ' Fecha:                15/01/2008
    ' Procedure Name:       CargarCajero
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajeros en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCajero(ByVal intCajeroID As Integer)
        Try
            Dim Strsql As String

            Me.cboCajero.ClearFields()
            REM REUNION LESTER 08/JULIO/2009: And a.sCodCargo = '04': Cajero, '10': Oficial de Crédito, '17': Responsable de Cartera
            If intCajeroID = 0 Then
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo, a.nStbDelegacionProgramaID " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE (a.sCodCargo = '04' or a.sCodCargo = '10' or a.sCodCargo = '17') AND (a.nActivo = 1) AND (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo, a.nStbDelegacionProgramaID " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE (a.sCodCargo = '04' or a.sCodCargo = '10' or a.sCodCargo = '17') AND (a.nActivo = 1) " & _
                             " Order by a.nCodigo "
                End If
            Else
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo, a.nStbDelegacionProgramaID " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE ((a.sCodCargo = '04' or a.sCodCargo = '10' or a.sCodCargo = '17') AND (a.nActivo = 1) And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
                             " Or a.nSrhEmpleadoID = " & intCajeroID & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo, a.nStbDelegacionProgramaID " & _
                             " From vwSclRepresentantePrograma a " & _
                             " WHERE (a.sCodCargo = '04' or a.sCodCargo = '10' or a.sCodCargo = '17') AND (a.nActivo = 1) " & _
                             " Or a.nSrhEmpleadoID = " & intCajeroID & _
                             " Order by a.nCodigo "
                End If
            End If

            If XdsArqueo.ExistTable("Cajero") Then
                XdsArqueo("Cajero").ExecuteSql(Strsql)
            Else
                XdsArqueo.NewTable(Strsql, "Cajero")
                XdsArqueo("Cajero").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCajero.DataSource = XdsArqueo("Cajero").Source
            Me.cboCajero.Rebind()

            Me.cboCajero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboCajero.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboCajero.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            'Configurar el combo: 
            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

            Me.cboCajero.Columns("nCodigo").Caption = "Código"
            Me.cboCajero.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
            'Antes

            If InfoSistema.IDDelegacion <> 12 Then 'No es la de Nueva Segovia, problema de enlace
                If intMinutaID = 0 Then
                    'Si NO tiene permisos de Edición fuera de su Delegación: 
                    If IntPermiteEditar = 0 Then
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
                                 " From vwSteMinutaDeposito a " & _
                                 " Where (a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                                 " Order by a.sNumeroDeposito"
                    Else
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
                                 " From vwSteMinutaDeposito a " & _
                                 " Where (a.nCerrada = 0) And (a.CodEstadoMinuta = '1') " & _
                                 " Order by a.sNumeroDeposito"
                    End If
                Else
                    'Si NO tiene permisos de Edición fuera de su Delegación: 
                    If IntPermiteEditar = 0 Then
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
                                 " From vwSteMinutaDeposito a " & _
                                 " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
                                 " or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                                 " Order by a.sNumeroDeposito"
                    Else
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
                                 " From vwSteMinutaDeposito a " & _
                                 " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1')) or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                                 " Order by a.sNumeroDeposito"
                    End If
                End If



                '--------------------------------------PARA NUEVA SEGOVIA

            Else ' Es la de Nueva Segovia filtrar solo desde el 2012 en adelante las minutas
                If intMinutaID = 0 Then
                    'Si NO tiene permisos de Edición fuera de su Delegación: 
                    If IntPermiteEditar = 0 Then
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
                                 " From vwSteMinutaDepositoArqueoFiltro a " & _
                                 " Where (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                                 " Order by a.sNumeroDeposito"
                    Else
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
                                 " From vwSteMinutaDepositoArqueoFiltro a " & _
                                  " Order by a.sNumeroDeposito"
                    End If
                Else
                    'Si NO tiene permisos de Edición fuera de su Delegación: 
                    If IntPermiteEditar = 0 Then
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
                                 " From vwSteMinutaDepositoArqueoFiltro a " & _
                                 " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
                                 " or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                                 " Order by a.sNumeroDeposito"
                    Else
                        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
                                 " From vwSteMinutaDepositoArqueoFiltro a " & _
                                 " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1')) or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                                 " Order by a.sNumeroDeposito"
                    End If
                End If
            End If
            'If intMinutaID = 0 Then
            '    'Si NO tiene permisos de Edición fuera de su Delegación: 
            '    If IntPermiteEditar = 0 Then
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
            '                 " From vwSteMinutaDeposito a " & _
            '                 " Where (a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
            '                 " Order by a.sNumeroDeposito"
            '    Else
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
            '                 " From vwSteMinutaDeposito a " & _
            '                 " Where (a.nCerrada = 0) And (a.CodEstadoMinuta = '1') " & _
            '                 " Order by a.sNumeroDeposito"
            '    End If
            'Else
            '    'Si NO tiene permisos de Edición fuera de su Delegación: 
            '    If IntPermiteEditar = 0 Then
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
            '                 " From vwSteMinutaDeposito a " & _
            '                 " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1') And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
            '                 " or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
            '                 " Order by a.sNumeroDeposito"
            '    Else
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
            '                 " From vwSteMinutaDeposito a " & _
            '                 " Where ((a.nCerrada = 0) And (a.CodEstadoMinuta = '1')) or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
            '                 " Order by a.sNumeroDeposito"
            '    End If
            'End If


            'Probando



            'If intMinutaID = 0 Then
            '    'Si NO tiene permisos de Edición fuera de su Delegación: 
            '    If IntPermiteEditar = 0 Then
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
            '                 " From ( SELECT     dbo.SteMinutaDeposito.nSteMinutaDepositoID, dbo.SteMinutaDeposito.nSteCuentaBancariaID, dbo.SteCuentaBancaria.sNumeroCuenta, dbo.vwStbPersona.sNombre, dbo.SteMinutaDeposito.sNumeroDeposito, dbo.SteMinutaDeposito.dFechaDeposito, dbo.SteMinutaDeposito.nMontoDeposito, dbo.SteCuentaBancaria.nCerrada, ISNULL(dbo.SteMinutaDeposito.nStbDelegacionProgramaID, 0) AS nStbDelegacionProgramaID, dbo.SteMinutaDeposito.nStbEstadoMinutaID, dbo.StbValorCatalogo.sDescripcion AS EstadoMinuta, dbo.StbValorCatalogo.sCodigoInterno AS CodEstadoMinuta, dbo.StbMunicipio.sCodigo AS CodMunicipio, dbo.StbMunicipio.sNombre AS Municipio, dbo.SteMinutaDeposito.nStbMunicipioID, dbo.SteMinutaDeposito.sObservaciones FROM         dbo.SteMinutaDeposito with(nolock)  INNER JOIN  dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID INNER JOIN dbo.vwStbPersona ON dbo.SteCuentaBancaria.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID INNER JOIN  dbo.StbValorCatalogo ON dbo.SteMinutaDeposito.nStbEstadoMinutaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbMunicipio ON dbo.SteMinutaDeposito.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID  Where (nCerrada = 0) And (dbo.StbValorCatalogo.sCodigoInterno= '1')      ) a " & _
            '                 " Where (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
            '                 " "
            '    Else
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
            '                 " From (  SELECT     dbo.SteMinutaDeposito.nSteMinutaDepositoID, dbo.SteMinutaDeposito.nSteCuentaBancariaID, dbo.SteCuentaBancaria.sNumeroCuenta, dbo.vwStbPersona.sNombre, dbo.SteMinutaDeposito.sNumeroDeposito, dbo.SteMinutaDeposito.dFechaDeposito, dbo.SteMinutaDeposito.nMontoDeposito, dbo.SteCuentaBancaria.nCerrada, ISNULL(dbo.SteMinutaDeposito.nStbDelegacionProgramaID, 0) AS nStbDelegacionProgramaID, dbo.SteMinutaDeposito.nStbEstadoMinutaID, dbo.StbValorCatalogo.sDescripcion AS EstadoMinuta, dbo.StbValorCatalogo.sCodigoInterno AS CodEstadoMinuta, dbo.StbMunicipio.sCodigo AS CodMunicipio, dbo.StbMunicipio.sNombre AS Municipio, dbo.SteMinutaDeposito.nStbMunicipioID, dbo.SteMinutaDeposito.sObservaciones FROM         dbo.SteMinutaDeposito with(nolock)  INNER JOIN  dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID INNER JOIN dbo.vwStbPersona ON dbo.SteCuentaBancaria.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID INNER JOIN  dbo.StbValorCatalogo ON dbo.SteMinutaDeposito.nStbEstadoMinutaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbMunicipio ON dbo.SteMinutaDeposito.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID  Where (nCerrada = 0) And (dbo.StbValorCatalogo.sCodigoInterno= '1')     )a " & _
            '                 " " & _
            '                 " "
            '    End If
            'Else
            '    'Si NO tiene permisos de Edición fuera de su Delegación: 
            '    If IntPermiteEditar = 0 Then
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio, a.sNombre " & _
            '                 " From (SELECT     dbo.SteMinutaDeposito.nSteMinutaDepositoID, dbo.SteMinutaDeposito.nSteCuentaBancariaID, dbo.SteCuentaBancaria.sNumeroCuenta, dbo.vwStbPersona.sNombre, dbo.SteMinutaDeposito.sNumeroDeposito, dbo.SteMinutaDeposito.dFechaDeposito, dbo.SteMinutaDeposito.nMontoDeposito, dbo.SteCuentaBancaria.nCerrada, ISNULL(dbo.SteMinutaDeposito.nStbDelegacionProgramaID, 0) AS nStbDelegacionProgramaID, dbo.SteMinutaDeposito.nStbEstadoMinutaID, dbo.StbValorCatalogo.sDescripcion AS EstadoMinuta, dbo.StbValorCatalogo.sCodigoInterno AS CodEstadoMinuta, dbo.StbMunicipio.sCodigo AS CodMunicipio, dbo.StbMunicipio.sNombre AS Municipio, dbo.SteMinutaDeposito.nStbMunicipioID, dbo.SteMinutaDeposito.sObservaciones FROM         dbo.SteMinutaDeposito with(nolock)  INNER JOIN  dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID INNER JOIN dbo.vwStbPersona ON dbo.SteCuentaBancaria.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID INNER JOIN  dbo.StbValorCatalogo ON dbo.SteMinutaDeposito.nStbEstadoMinutaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbMunicipio ON dbo.SteMinutaDeposito.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID   Where (nCerrada = 0) And (dbo.StbValorCatalogo.sCodigoInterno= '1')     ) a " & _
            '                 " Where ( (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")) " & _
            '                 " or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
            '                 " "
            '    Else
            '        Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta, a.nStbMunicipioID, a.Municipio , a.sNombre" & _
            '                 " From (  SELECT     dbo.SteMinutaDeposito.nSteMinutaDepositoID, dbo.SteMinutaDeposito.nSteCuentaBancariaID, dbo.SteCuentaBancaria.sNumeroCuenta, dbo.vwStbPersona.sNombre, dbo.SteMinutaDeposito.sNumeroDeposito, dbo.SteMinutaDeposito.dFechaDeposito, dbo.SteMinutaDeposito.nMontoDeposito, dbo.SteCuentaBancaria.nCerrada, ISNULL(dbo.SteMinutaDeposito.nStbDelegacionProgramaID, 0) AS nStbDelegacionProgramaID, dbo.SteMinutaDeposito.nStbEstadoMinutaID, dbo.StbValorCatalogo.sDescripcion AS EstadoMinuta, dbo.StbValorCatalogo.sCodigoInterno AS CodEstadoMinuta, dbo.StbMunicipio.sCodigo AS CodMunicipio, dbo.StbMunicipio.sNombre AS Municipio, dbo.SteMinutaDeposito.nStbMunicipioID, dbo.SteMinutaDeposito.sObservaciones FROM         dbo.SteMinutaDeposito with(nolock)  INNER JOIN  dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID INNER JOIN dbo.vwStbPersona ON dbo.SteCuentaBancaria.nStbPersonaID = dbo.vwStbPersona.nStbPersonaID INNER JOIN  dbo.StbValorCatalogo ON dbo.SteMinutaDeposito.nStbEstadoMinutaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN  dbo.StbMunicipio ON dbo.SteMinutaDeposito.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID Where (nCerrada = 0) And (dbo.StbValorCatalogo.sCodigoInterno= '1')      ) a " & _
            '                 " Where ( or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
            '                 " "
            '    End If
            'End If











            If XdsArqueo.ExistTable("Minuta") Then
                XdsArqueo("Minuta").ExecuteSql(Strsql)
            Else
                XdsArqueo.NewTable(Strsql, "Minuta")
                XdsArqueo("Minuta").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboMinuta.DataSource = XdsArqueo("Minuta").Source
            Me.cboMinuta.Rebind()

            Me.cboMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False
            Me.cboMinuta.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False

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

    Private Sub CargarCaja(ByVal intCajaID As Integer)
        Try
            Dim Strsql As String

            Me.cboCaja.ClearFields()
            If intCajaID = 0 Then
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID, a.nCerrada, a.nStbDelegacionProgramaID, a.nStbTipoProgramaID, a.CodPrograma, a.nStbTipoPlazoPagosID, nHaceArqueo  " & _
                             " From vwSteArqueoCaja a " & _
                             " WHERE a.nCerrada = 0 AND (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID, a.nCerrada, a.nStbDelegacionProgramaID, a.nStbTipoProgramaID, a.CodPrograma, a.nStbTipoPlazoPagosID, nHaceArqueo  " & _
                             " From vwSteArqueoCaja a " & _
                             " WHERE a.nCerrada = 0 " & _
                             " Order by a.nCodigo "
                End If
            Else
                'Si NO tiene permisos de Edición fuera de su Delegación: 
                If IntPermiteEditar = 0 Then
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID, a.nCerrada, a.nStbDelegacionProgramaID, a.nStbTipoProgramaID, a.CodPrograma, a.nStbTipoPlazoPagosID, nHaceArqueo  " & _
                             " From vwSteArqueoCaja a " & _
                             " WHERE ((a.nCerrada = 0) AND (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & " )) " & _
                             " Or a.nSteCajaID = " & intCajaID & _
                             " Order by a.nCodigo "
                Else
                    Strsql = " Select a.nSteCajaID, a.nCodigo, a.sDescripcionCaja, a.sLugarPagos, a.dFechaApertura, a.nStbMunicipioID, a.nCerrada, a.nStbDelegacionProgramaID, a.nStbTipoProgramaID, a.CodPrograma, a.nStbTipoPlazoPagosID, nHaceArqueo  " & _
                             " From vwSteArqueoCaja a " & _
                             " WHERE (a.nCerrada = 0) " & _
                             " Or a.nSteCajaID = " & intCajaID & _
                             " Order by a.nCodigo "
                End If
            End If

            If XdsArqueo.ExistTable("Caja") Then
                XdsArqueo("Caja").ExecuteSql(Strsql)
            Else
                XdsArqueo.NewTable(Strsql, "Caja")
                XdsArqueo("Caja").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCaja.DataSource = XdsArqueo("Caja").Source
            Me.cboCaja.Rebind()

            'Configurar el combo
            Me.cboCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nCerrada").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbTipoProgramaID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("CodPrograma").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nStbTipoPlazoPagosID").Visible = False
            Me.cboCaja.Splits(0).DisplayColumns("nHaceArqueo").Visible = False

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 250
            Me.cboCaja.Splits(0).DisplayColumns("sLugarPagos").Width = 150
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").Width = 90

            Me.cboCaja.Columns("nCodigo").Caption = "Código"
            Me.cboCaja.Columns("sDescripcionCaja").Caption = "Descripción Caja"
            Me.cboCaja.Columns("sLugarPagos").Caption = "Lugar de Pagos"
            Me.cboCaja.Columns("dFechaApertura").Caption = "Fecha Apertura"

            Me.cboCaja.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("sLugarPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Splits(0).DisplayColumns("dFechaApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCaja.Columns("dFechaApertura").NumberFormat = "dd/MM/yyyy"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region
#Region "Detalle Efectivo"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CargarEfectivo
    ' Descripción:          Este procedimiento permite cargar los datos 
    '                       de Efectivo del Arqueo en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarEfectivo()
        Try
            Dim Strsql As String

            Me.grdArqueoEfectivo.ClearFields()
            Strsql = " Select a.nSteArqueoDenominacionID, a.nSteArqueoCajaID, a.nBillete, " & _
                     " a.nValor, a.nCantidad, a.Total " & _
                     " From vwSteArqueoDenominaciones a " & _
                     " Where (a.nSteArqueoCajaID = " & Me.intArqueoID & ") " & _
                     " ORDER BY a.nBillete DESC, a.nValor DESC"

            If XdsDetalle.ExistTable("Efectivo") Then
                XdsDetalle("Efectivo").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Efectivo")
                XdsDetalle("Efectivo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdArqueoEfectivo.DataSource = XdsDetalle("Efectivo").Source
            'Refresh Grid.
            Me.grdArqueoEfectivo.Rebind(False)
            Me.grdArqueoEfectivo.FetchRowStyles = True

            'Actualizando el caption de los GRIDS
            Me.grdArqueoEfectivo.Caption = "Arqueo de Efectivo (" + Me.grdArqueoEfectivo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       FormatoEfectivo
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Arqueo de Efectivo en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoEfectivo()
        Try

            'Configuracion del Grid: 
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nSteArqueoDenominacionID").Visible = False
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nSteArqueoCajaID").Visible = False

            'Pie del Grid para totalizar Monto Total de Billetes y Monedas:
            Me.grdArqueoEfectivo.ColumnFooters = True
            Me.grdArqueoEfectivo.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("Total").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("Total").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("Total").FooterStyle.ForeColor = Color.Blue
            Me.grdArqueoEfectivo.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nBillete").Width = 90
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nValor").Width = 150
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nCantidad").Width = 150
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("Total").Width = 150

            Me.grdArqueoEfectivo.Columns("nBillete").Caption = "Billetes"
            Me.grdArqueoEfectivo.Columns("nValor").Caption = "Valor Denominación"
            Me.grdArqueoEfectivo.Columns("nCantidad").Caption = "Cantidad Arqueada"
            Me.grdArqueoEfectivo.Columns("Total").Caption = "Total Denominación C$"

            Me.grdArqueoEfectivo.Columns("nBillete").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nBillete").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nBillete").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("nCantidad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns("Total").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdArqueoEfectivo.Columns("Total").NumberFormat = "#,##0.00"
            Me.grdArqueoEfectivo.Splits(0).DisplayColumns.Item("Total").Style.BackColor = Color.WhiteSmoke

            'Calcular montos totales de Billetes y Monedas:
            CalcularMontosBM()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CalcularMontosBM
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Billetes y Monedas. 
    '-------------------------------------------------------------------------
    Private Sub CalcularMontosBM()
        Try
            Dim vTotalBM As Double = 0

            For index As Integer = 0 To Me.grdArqueoEfectivo.RowCount - 1
                Me.grdArqueoEfectivo.Row = index
                vTotalBM = vTotalBM + Me.grdArqueoEfectivo.Columns("Total").Value
            Next
            If Me.grdArqueoEfectivo.RowCount > 0 Then
                Me.grdArqueoEfectivo.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdArqueoEfectivo.Columns("Total").FooterText = Format(vTotalBM, "C$ #,##0.00")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       tbArqueoEfectivo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbArqueoEfectivo.
    '-------------------------------------------------------------------------
    Private Sub tbArqueoEfectivo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbArqueoEfectivo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarC"
                LlamaAgregarDenominaciones()
            Case "toolModificarC"
                LlamaModificarCantidadEfectivo()
            Case "toolRefrescarE"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdArqueoEfectivo.ClearFields()
                CargarEfectivo()
                FormatoEfectivo()
            Case "toolAyudaE"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/02/2008
    ' Procedure Name:       LlamaAgregarDenominaciones
    ' Descripción:          Este procedimiento permite incluir denominaciones
    '                       aún no incorporadas en el Arqueo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarDenominaciones()
        Dim XdtDenominacion As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            Dim StrSqlV As String

            'Imposible si NO existen Denominaciones aún no contenidas en el Arqueo:
            StrSqlV = "SELECT nSteDenominacionID FROM SteDenominaciones " & _
                      "WHERE (NOT (nSteDenominacionID IN (SELECT nSteDenominacionID FROM SteArqueoDenominacion WHERE (nSteArqueoCajaID = " & Me.intArqueoID & "))))"
            If RegistrosAsociados(StrSqlV) = False Then
                MsgBox("No existen Denominaciones sin incorporar.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar registro:
            If MsgBox("¿Está seguro de incorporar Denominaciones aún" & Chr(13) & "no asignadas en el Arqueo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                StrSql = " INSERT INTO SteArqueoDenominacion (nSteArqueoCajaID, nSteDenominacionID, nCantidad, nUsuarioCreacionID, dFechaCreacion)" & _
                         " SELECT " & Me.intArqueoID & ", a.nSteDenominacionID, 0, " & InfoSistema.IDCuenta & ", getdate()" & _
                         " FROM (" & StrSqlV & ") a "
                XdtDenominacion.ExecuteSqlNotTable(StrSql)
                CargarEfectivo()
                FormatoEfectivo()
                MsgBox("Las Denominaciones se incorporaron satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdArqueoEfectivo.Caption = "Arqueo de Efectivo (" + Me.grdArqueoEfectivo.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDenominacion.Close()
            XdtDenominacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       LlamaModificarCantidadEfectivo
    ' Descripción:          Este procedimiento permite incluir la Cantidad
    '                       para una Denominación.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCantidadEfectivo()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XcDatosEf As New BOSistema.Win.XComando

        Dim XdtDE As New BOSistema.Win.SteEntArqueo.SteArqueoDenominacionDataTable
        Dim XdrDE As New BOSistema.Win.SteEntArqueo.SteArqueoDenominacionRow

        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try

            Dim intPosicion As Integer
            Dim IntIdDenominacion As Integer
            Dim strCantidad As String = ""
            Dim nValor As Double

            'Imposible si no existen Registros grabados:
            If Me.grdArqueoEfectivo.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            XdtDE.Filter = " nSteArqueoDenominacionID = " & XdsDetalle("Efectivo").ValueField("nSteArqueoDenominacionID")
            XdtDE.Retrieve()
            XdrDE = XdtDE.Current

            If Not XdrDE.IsFieldNull("nCantidad") Then
                ObjFrmStbDatoComplemento.txtDato.Text = XdrDE.nCantidad
            End If
            ObjFrmStbDatoComplemento.strPrompt = "Cantidad Arqueada:  "
            ObjFrmStbDatoComplemento.strTitulo = "Cantidad Arqueada "

            ObjFrmStbDatoComplemento.strDato = ""
            ObjFrmStbDatoComplemento.strColor = "Naranja"
            ObjFrmStbDatoComplemento.strMensaje = "No se indicó Cantidad Válida."
            ObjFrmStbDatoComplemento.ShowDialog()

            strCantidad = ObjFrmStbDatoComplemento.strDato

            'Debe indicar Cantidad Numerica:
            If Not IsNumeric(strCantidad) Then
                MsgBox("Cantidad Inválida.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            'Debe indicar Cantidad no menor que cero:
            If CDbl(strCantidad) < 0 Then
                MsgBox("Cantidad Inválida.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Ingresa la Cantidad:
            GuardarAuditoriaTablas(27, 2, "Actualizar SteArqueoDenominacion", XdsDetalle("Efectivo").ValueField("nSteArqueoDenominacionID"), InfoSistema.IDCuenta)

            Strsql = " Update SteArqueoDenominacion " & _
                     " SET nUsuariomodificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nCantidad = " & strCantidad & _
                     " WHERE nSteArqueoDenominacionID = " & XdsDetalle("Efectivo").ValueField("nSteArqueoDenominacionID")
            XcDatos.ExecuteNonQuery(Strsql)

            'Guardar posición actual de la selección
            intPosicion = XdsDetalle("Efectivo").ValueField("nSteArqueoDenominacionID")
            CargarEfectivo()
            FormatoEfectivo()

            'Ubicar la selección en la posición original
            'XdsDetalle("Efectivo").SetCurrentByID("nSteArqueoDenominacionID", intPosicion)
            'Me.grdArqueoEfectivo.Row = XdsDetalle("Efectivo").BindingSource.Position
            'Encuentra Valor actual de la denominación:
            Strsql = "SELECT SteDenominaciones.nValor " & _
                     "FROM SteArqueoDenominacion INNER JOIN SteDenominaciones ON SteArqueoDenominacion.nSteDenominacionID = SteDenominaciones.nSteDenominacionID " & _
                     "WHERE (SteArqueoDenominacion.nSteArqueoDenominacionID = " & intPosicion & ")"
            nValor = XcDatosEf.ExecuteScalar(Strsql)

            'Encuentra Denominación siguiente:
            Strsql = "SELECT AD.nSteArqueoDenominacionID " & _
                     "FROM SteArqueoDenominacion AS AD INNER JOIN SteDenominaciones AS D ON AD.nSteDenominacionID = D.nSteDenominacionID INNER JOIN " & _
                     "(SELECT  ISNULL(MAX(nValor), 0) AS mValor FROM (SELECT AD1.nSteArqueoDenominacionID, D1.nValor " & _
                     "FROM SteArqueoDenominacion AS AD1 INNER JOIN SteDenominaciones AS D1 ON AD1.nSteDenominacionID = D1.nSteDenominacionID " & _
                     "WHERE (AD1.nSteArqueoCajaID = " & Me.intArqueoID & ") AND (D1.nValor < " & nValor & ")) AS b_1) AS b ON D.nValor = b.mValor WHERE (AD.nSteArqueoCajaID = " & Me.intArqueoID & ")"
            If XcDatosEf.ExecuteScalar(Strsql) = 0 Then
                IntIdDenominacion = intPosicion
            Else
                IntIdDenominacion = XcDatosEf.ExecuteScalar(Strsql)
            End If
            'Se ubica en la Denominación correspondiente:
            XdsDetalle("Efectivo").SetCurrentByID("nSteArqueoDenominacionID", IntIdDenominacion)
            Me.grdArqueoEfectivo.Row = XdsDetalle("Efectivo").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing

            XdtDE.Close()
            XdtDE = Nothing

            XdrDE.Close()
            XdrDE = Nothing

            XcDatosEf.Close()
            XcDatosEf = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
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
    ' Fecha:                15/01/2008
    ' Procedure Name:       grdArqueoEfectivo_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un detalle de Efectivo existente, al hacer 
    '                       doble click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdArqueoEfectivo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdArqueoEfectivo.DoubleClick
        Try
            If IntHabilitar = 1 Then
                LlamaModificarCantidadEfectivo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso de Error:
    Private Sub grdArqueoEfectivo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdArqueoEfectivo.Error
        Control_Error(e.Exception)
    End Sub

    'En caso que se filtren registros en la FilterBar.
    Private Sub grdArqueoEfectivo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdArqueoEfectivo.Filter
        Try
            XdsDetalle("Efectivo").FilterLocal(e.Condition)
            Me.grdArqueoEfectivo.Caption = "Arqueo de Efectivo (" + Me.grdArqueoEfectivo.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region

#Region "Detalle Arqueo Documentos"
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CargarDocumentos
    ' Descripción:          Este procedimiento permite cargar los datos de los 
    '                       Recibos en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarDocumentos()
        Try
            Dim Strsql As String
            Me.grdArqueoDocumentos.ClearFields()

            Strsql = " Select a.nSteArqueoReciboID, a.nSteArqueoCajaID, " & _
                     " a.nCodigo, a.nValor, a.EstadoRecibo, a.nManual, a.nSccReciboOficialCajaID " & _
                     " From vwSteArqueoDocumentos a " & _
                     " Where (a.nSteArqueoCajaID = " & Me.intArqueoID & ") " & _
                     " Order By a.nCodigo "

            If XdsDetalle.ExistTable("Documentos") Then
                XdsDetalle("Documentos").ExecuteSql(Strsql)
            Else
                XdsDetalle.NewTable(Strsql, "Documentos")
                XdsDetalle("Documentos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdArqueoDocumentos.DataSource = XdsDetalle("Documentos").Source
            'Refresh Grid.
            Me.grdArqueoDocumentos.Rebind(False)
            Me.grdArqueoDocumentos.FetchRowStyles = True
            'Actualizando el caption de los GRIDS
            Me.grdArqueoDocumentos.Caption = "Arqueo de Documentos (" + Me.grdArqueoDocumentos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       FormatoDocumentos
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Recibos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoDocumentos()
        Try
            'Configuracion del Grid 
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nSteArqueoReciboID").Visible = False
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nSteArqueoCajaID").Visible = False
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nManual").Visible = False
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nSccReciboOficialCajaID").Visible = False

            'Pie del Grid para totalizar Monto Recibos:
            Me.grdArqueoDocumentos.ColumnFooters = True
            Me.grdArqueoDocumentos.Splits(0).FooterStyle.Borders.BorderType = C1.Win.C1TrueDBGrid.BorderTypeEnum.Flat
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nValor").FooterStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Far
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nValor").FooterStyle.VerticalAlignment = C1.Win.C1TrueDBGrid.AlignVertEnum.Bottom
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nValor").FooterStyle.ForeColor = Color.Blue
            Me.grdArqueoDocumentos.FooterStyle.BackColor = Color.WhiteSmoke

            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nCodigo").Width = 150
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nValor").Width = 200
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("EstadoRecibo").Width = 150

            Me.grdArqueoDocumentos.Columns("nCodigo").Caption = "Código Recibo"
            Me.grdArqueoDocumentos.Columns("nValor").Caption = "Monto C$"
            Me.grdArqueoDocumentos.Columns("EstadoRecibo").Caption = "Estado"

            Me.grdArqueoDocumentos.Splits(0).DisplayColumns.Item("nValor").Style.BackColor = Color.WhiteSmoke

            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdArqueoDocumentos.Splits(0).DisplayColumns("EstadoRecibo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdArqueoDocumentos.Columns("nValor").NumberFormat = "#,##0.00"

            'Calcular montos totales de Recibos:
            CalcularMontos()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       CalcularMontos
    ' Descripción:          Este procedimiento permite Calcular el Monto
    '                       Total de Recibos para visualizarlo en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CalcularMontos()
        Try
            Dim vTotalMonto As Double = 0

            For index As Integer = 0 To Me.grdArqueoDocumentos.RowCount - 1
                Me.grdArqueoDocumentos.Row = index
                vTotalMonto = vTotalMonto + Me.grdArqueoDocumentos.Columns("nValor").Value
            Next
            If Me.grdArqueoDocumentos.RowCount > 0 Then
                Me.grdArqueoDocumentos.Row = 0
            End If
            'Refrescar el FOOTER del GRID
            Me.grdArqueoDocumentos.Columns("nValor").FooterText = Format(vTotalMonto, "C$ #,##0.00")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       tbArqueoDocumentos_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbArqueoDocumentos.
    '-------------------------------------------------------------------------
    Private Sub tbArqueoDocumentos_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbArqueoDocumentos.ItemClicked

        Select Case e.ClickedItem.Name
            'Anexado para anular recibos en arqueo que esten anulados en caja anexado el 23 feb 2011
            Case "toolAnularR"
                LlamaAnularRecibo()
                'fin anexo
            Case "toolIncorporarR"
                LlamaIncorporarRecibos()

            Case "toolAgregarR"
                LlamaAgregarRecibos()
            Case "toolModificarR"
                LlamaModificarRecibos()
            Case "toolEliminarR"
                LlamaEliminarRecibos()
            Case "toolEliminarRS"
                LlamaEliminarRecibosRango()
            Case "toolRefrescarR"
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdArqueoDocumentos.ClearFields()
                CargarDocumentos()
                FormatoDocumentos()
            Case "toolAyudaR"
                LlamaAyuda()
            Case "toolIncorporarRecibo"
                ''Incorporar Recibos que se eliminaron
                LlamaIncorporarReciboUnico()
                XdsDetalle = New BOSistema.Win.XDataSet
                Me.grdArqueoDocumentos.ClearFields()
                CargarDocumentos()
                FormatoDocumentos()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                05/10/2012                       
    ' Procedure Name:       LlamaIncorporarReciboUnico
    ' Descripción:          Este procedimiento permite ingresar recibos que con la intención de anularse
    '                       se eliminaron del arqueo
    '-------------------------------------------------------------------------
    Private Sub LlamaIncorporarReciboUnico()
        Dim ObjfrmIncorporarArqueoRecibo As New frmSteIncorporarArqueoRecibo
        ObjfrmIncorporarArqueoRecibo.CodigoArqueo = Integer.Parse(Me.txtCodigo.Text)
        ObjfrmIncorporarArqueoRecibo.FechaRecibo = Date.Parse(Me.cdeFechaA.Text)
        ObjfrmIncorporarArqueoRecibo.ArqueoID = Me.intArqueoID
        ObjfrmIncorporarArqueoRecibo.ShowDialog()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                28/02/2008
    '                       25/11/2008    
    ' Procedure Name:       LlamaIncorporarRecibos
    ' Descripción:          Este procedimiento permite ingresar de forma 
    '                       automática Recibos de Caja para la fecha, caja
    '                       y cajero del Arqueo.
    '-------------------------------------------------------------------------
    Private Sub LlamaIncorporarRecibos()
        Dim XdtRecibos As New BOSistema.Win.XDataSet.xDataTable
        Dim XdtTmpArqueo As New BOSistema.Win.XDataSet.xDataTable
        Dim XdtTraslado As New BOSistema.Win.XDataSet.xDataTable
        Dim XdtRecibosTalonario0 As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatosT As New BOSistema.Win.XComando
        Try

            Dim StrSql As String
            Dim StrSqlV As String
            Dim StrSqlT As String
            Dim IntCodigoCorte As Integer
            Dim IntCodigoT As Integer

            'Imposible si no existe un Cierre Diario de Caja Cerrado
            'para la Caja y Fecha:
            StrSql = "Select * From SteCierreDiarioCaja " & _
                     "WHERE (nCerrada = 1) AND (dFechaCierre = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) AND (nSteCajaID = " & cboCaja.Columns("nSteCajaID").Value & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("No existe Cierre Diario de Caja Aplicado para la Fecha de Arqueo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si es por Traslado de Valores: Recibos Menores o Iguales al
            'codigo de Corte, Si es Efectivo Recibos > al Codigo de Corte.
            'REM: Si no existe un Cierre de Traslado de Valores para la
            'Caja, Cajero y fecha del Arqueo: 
            'Corte Codigo = 0 (todo se carga como efectivo).

            'Verificar si existen Recibos pendientes de Incorporar:
            'Ingresar Recibos:
            '1. Para la fecha del Arqueo.
            '2. Para la Caja del Arqueo.
            '3. Para el Cajero del Arqueo.
            '4. Con campo nManual = 0 (Recibos Automáticos).
            '5. Que no esten contenidos en el Arqueo actual (No han sido previamente Incorporados).
            '6. Recibos del Programa y Plazo de la Caja del Arqueo.
            '7. Recibos con Codigo de Talonario de la Fecha del Arqueo.
            '-- En caso de Recibos anulados grabarlos con monto 0.

            'Busca el registro en Arqueo según ID:
            StrSql = "SELECT dFechaArqueo, nSteCajaID, nSrhCajeroId FROM SteArqueoCaja WHERE (nSteArqueoCajaID = " & Me.intArqueoID & ")"
            XdtTmpArqueo.ExecuteSql(StrSql)

            'Busca el Código de Corte por Traslado de Valores
            'para la Caja, Cajero y Fecha de Cierre.  
            StrSqlT = " Select nCodigoReciboHasta From SteCierreTrasladoValor " & _
                     " Where (nSteCajaID = " & XdtTmpArqueo.ValueField("nSteCajaID") & ") " & _
                     " AND (nSrhEmpleadoCajeroID = " & XdtTmpArqueo.ValueField("nSrhCajeroId") & ") " & _
                     " AND (dFechaArqueo = CONVERT(DATETIME, '" & Format(XdtTmpArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102))"
            XdtTraslado.ExecuteSql(StrSqlT)
            If XdtTraslado.Count > 0 Then
                IntCodigoCorte = XdtTraslado.ValueField("nCodigoReciboHasta")
            Else
                IntCodigoCorte = 0
            End If

            'Si no hay corte por traslado todo es efectivo:
            If (Me.chkTrasladoValores.Checked = True) And (IntCodigoCorte = 0) Then
                MsgBox("Imposible importar por Traslado de Valores" & Chr(13) & "ya que no existe un Cierre de Traslado para" & Chr(13) & "la Caja, Cajero y fecha del Arqueo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Verificar contra la BD el ck de traslado de valores:
            If (XcDatosT.ExecuteScalar("SELECT nTrasladoValores FROM  SteArqueoCaja WHERE  (nSteArqueoCajaID = " & Me.intArqueoID & ")") = 1) And (IntCodigoCorte = 0) Then
                MsgBox("Imposible importar por Traslado de Valores" & Chr(13) & "ya que no existe un Cierre de Traslado para" & Chr(13) & "la Caja, Cajero y fecha del Arqueo." & Chr(13) & Chr(13) & "Antes guarde los datos generales del arqueo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ' INICIO Agregado 18-09-2012  

            Dim queryTalonario As New System.Text.StringBuilder()
            queryTalonario.Append(" SELECT CAST(sValorParametro AS INT)")
            queryTalonario.Append(" FROM StbValorParametro ")
            queryTalonario.Append(" WHERE(nStbValorParametroID = 67)")

            Dim CodigoTalonario As Int32
            CodigoTalonario = XcDatosT.ExecuteScalar(queryTalonario.ToString())

            queryTalonario.Replace(queryTalonario.ToString, "")

            queryTalonario.Append(" SELECT sroc.nSccReciboOficialCajaID")
            queryTalonario.Append(" FROM SccReciboOficialCaja sroc")
            queryTalonario.Append("      INNER JOIN SrhEmpleado se")
            queryTalonario.Append("      ON se.nSrhEmpleadoID = sroc.nSrhEmpleadoCajeroID")
            queryTalonario.Append(" WHERE sroc.dFechaRecibo = '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "'")
            queryTalonario.Append("       AND se.nSrhEmpleadoID = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value)
            queryTalonario.Append("       AND sroc.nSteCajaID = " & Me.cboCaja.Columns("nSteCajaID").Value)
            queryTalonario.Append("       AND sroc.nCodigoTalonario <> " & CodigoTalonario)

            XdtRecibosTalonario0.ExecuteSql(queryTalonario.ToString())
            ''Si existen RECIBOS con un código de talonario distinto al actual, entonces 
            '' actualizarlos al actual
            If XdtRecibosTalonario0.Count > 0 Then
                XdtRecibosTalonario0.ExecuteSql(String.Format("exec spSteActualizaCodigoTalonario '{0}',{1},{2}", Format(Me.cdeFechaA.Value, "yyyy-MM-dd"), Me.cboCajero.Columns("nSrhEmpleadoID").Value, Me.cboCaja.Columns("nSteCajaID").Value))
            End If

            ' FIN  Agregado 18-09-2012  

            'Talonario segun Fecha del Arqueo:
            IntCodigoT = IntCodigoTalonario(Format(XdtTmpArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd"))

            'Verifica si existen Recibos Automáticos pendientes de incorporar en el Arqueo:
            If Me.chkTrasladoValores.Checked = True Then 'Traslado de Valores
                StrSqlV = " SELECT SccReciboOficialCaja.nSccReciboOficialCajaID, SccReciboOficialCaja.nCodigo,  CASE StbValorCatalogo.sCodigoInterno WHEN '3' THEN 0 ELSE SccReciboOficialCaja.nValor END AS nValor, SccReciboOficialCaja.nCodigoTalonario " & _
                          " FROM SccReciboOficialCaja INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                          " INNER JOIN vwSccDetalleCreditosPrograma ON SccReciboOficialCaja.nSccSolicitudChequeID = vwSccDetalleCreditosPrograma.nSccSolicitudChequeID " & _
                          " WHERE (SccReciboOficialCaja.nCodigo <= " & IntCodigoCorte & ") And (SccReciboOficialCaja.dFechaRecibo = CONVERT(DATETIME, '" & Format(XdtTmpArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) AND (SccReciboOficialCaja.nSrhEmpleadoCajeroID = " & XdtTmpArqueo.ValueField("nSrhCajeroId") & ") AND (SccReciboOficialCaja.nManual = 0) " & _
                          " AND (NOT (SccReciboOficialCaja.nSccReciboOficialCajaID IN (SELECT nSccReciboOficialCajaID FROM SteArqueoRecibo WHERE (nSccReciboOficialCajaID IS NOT NULL) AND (nSteArqueoCajaID = " & Me.intArqueoID & ")))) AND (SccReciboOficialCaja.nSteCajaID = " & XdtTmpArqueo.ValueField("nSteCajaID") & ") " & _
                          " AND (vwSccDetalleCreditosPrograma.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                          " AND (vwSccDetalleCreditosPrograma.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                          " AND (SccReciboOficialCaja.nCodigoTalonario = " & IntCodigoT & ")"
            Else 'Efectivo 
                StrSqlV = " SELECT SccReciboOficialCaja.nSccReciboOficialCajaID, SccReciboOficialCaja.nCodigo,  CASE StbValorCatalogo.sCodigoInterno WHEN '3' THEN 0 ELSE SccReciboOficialCaja.nValor END AS nValor, SccReciboOficialCaja.nCodigoTalonario " & _
                          " FROM SccReciboOficialCaja INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                          " INNER JOIN vwSccDetalleCreditosPrograma ON SccReciboOficialCaja.nSccSolicitudChequeID = vwSccDetalleCreditosPrograma.nSccSolicitudChequeID " & _
                          " WHERE (SccReciboOficialCaja.nCodigo > " & IntCodigoCorte & ") And (SccReciboOficialCaja.dFechaRecibo = CONVERT(DATETIME, '" & Format(XdtTmpArqueo.ValueField("dFechaArqueo"), "yyyy-MM-dd") & "', 102)) AND (SccReciboOficialCaja.nSrhEmpleadoCajeroID = " & XdtTmpArqueo.ValueField("nSrhCajeroId") & ") AND (SccReciboOficialCaja.nManual = 0) " & _
                          " AND (NOT (SccReciboOficialCaja.nSccReciboOficialCajaID IN (SELECT nSccReciboOficialCajaID FROM SteArqueoRecibo WHERE (nSccReciboOficialCajaID IS NOT NULL) AND (nSteArqueoCajaID = " & Me.intArqueoID & ")))) AND (SccReciboOficialCaja.nSteCajaID = " & XdtTmpArqueo.ValueField("nSteCajaID") & ") " & _
                          " AND (vwSccDetalleCreditosPrograma.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                          " AND (vwSccDetalleCreditosPrograma.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ")  " & _
                          " AND (SccReciboOficialCaja.nCodigoTalonario = " & IntCodigoT & ")"
            End If
            If RegistrosAsociados(StrSqlV) = False Then
                MsgBox("No existen Recibos importados pendientes de incorporar para" & Chr(13) & "la fecha, tipo de arqueo, programa y plazo de pagos, caja" & Chr(13) & "y cajero indicados.", MsgBoxStyle.Information)
                Exit Sub
                '-- Si existen Recibos verificar que no existan en arqueo de caja activo. 
            Else
                StrSql = "SELECT SteArqueoRecibo.nSteArqueoCajaID " & _
                         "FROM SteArqueoRecibo INNER JOIN SteArqueoCaja ON SteArqueoRecibo.nSteArqueoCajaID = SteArqueoCaja.nSteArqueoCajaID INNER JOIN StbValorCatalogo ON SteArqueoCaja.nStbEstadoArqueoID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (SteArqueoRecibo.nSccReciboOficialCajaID IN " & _
                                                    "(SELECT nSccReciboOficialCajaID " & _
                                                    " FROM " & _
                                                    "(" & StrSqlV & ") as a)) " & _
                         "AND (SteArqueoRecibo.nSteArqueoCajaID <> " & Me.intArqueoID & ") AND (StbValorCatalogo.sCodigoInterno <> '3' AND StbValorCatalogo.sCodigoInterno <> '4')"
                If RegistrosAsociados(StrSql) Then
                    MsgBox("Existen Códigos de Recibos que se encuentran" & Chr(13) & "registrados en un Arqueo de Caja Activo.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If
            End If

            'Confirmar Adición de Recibos: 
            If MsgBox("¿Está seguro de incorporar Recibos aún" & Chr(13) & "no asignados al Arqueo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                StrSql = " INSERT INTO SteArqueoRecibo (nSteArqueoCajaID, nSccReciboOficialCajaID, nCodigo, nValor, nCodigoTalonario, nUsuarioCreacionID, dFechaCreacion)" & _
                         " SELECT " & Me.intArqueoID & ", a.nSccReciboOficialCajaID, a.nCodigo, a.nValor, a.nCodigoTalonario, " & InfoSistema.IDCuenta & ", getdate()" & _
                         " FROM (" & StrSqlV & ") a "
                XdtRecibos.ExecuteSqlNotTable(StrSql)
                CargarDocumentos()
                FormatoDocumentos()
                Me.Cursor = System.Windows.Forms.Cursors.Default
                MsgBox("Los Recibos se incorporaron satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdArqueoDocumentos.Caption = "Arqueo de Documentos (" + Me.grdArqueoDocumentos.RowCount.ToString + " registros)"
            End If

            'Inhabilitar: 
            InhabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtRecibos.Close()
            XdtRecibos = Nothing

            XdtTmpArqueo.Close()
            XdtTmpArqueo = Nothing

            XdtTraslado.Close()
            XdtTraslado = Nothing

            XcDatosT.Close()
            XcDatosT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       LlamaAgregarRecibos
    ' Descripción:          Este procedimiento permite ingresar Recibos de
    '                       Caja como parte del Arqueo de Documentos.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarRecibos()
        Dim ObjFrmSteEditRecibos As New frmSteEditArqueoRecibo
        Dim XcDatosV As New BOSistema.Win.XComando
        Try

            Dim strSQL As String
            Dim CodTalonario As Integer

            ObjFrmSteEditRecibos.IdArqueo = Me.intArqueoID
            ObjFrmSteEditRecibos.IdRecibo = 0
            CodTalonario = IntCodigoTalonario(Format(Me.cdeFechaA.Value, "yyyy-MM-dd"))
            ObjFrmSteEditRecibos.nCodigoTalonario = CodTalonario
            ObjFrmSteEditRecibos.ModoFrm = "ADD"


            strSQL = "SELECT dbo.SteArqueoCaja.nSteArqueoCajaID " &
                      "From dbo.SteArqueoCaja INNER Join " &
                      "dbo.SteCaja On dbo.SteArqueoCaja.nSteCajaID = dbo.SteCaja.nSteCajaID INNER Join " &
                      "dbo.vwStbUbicacionGeografica ON dbo.SteCaja.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER Join " &
                      "dbo.StbMunicipioAtendidoDepartamentoAlterno ON " &
                      "dbo.vwStbUbicacionGeografica.nStbMunicipioID = dbo.StbMunicipioAtendidoDepartamentoAlterno.nStbMunicipioID " &
                       "WHERE(dbo.SteArqueoCaja.nSteArqueoCajaID = " & ObjArqueodr.nSteArqueoCajaID & ")"

            'Verificamos si la caja pertenece a un municipio que es atendido por otro departamento 
            'por lo cual la entrega estaría registrada al departamento que lo atiende y no al de la caja
            If XcDatosV.ExecuteScalar(strSQL) = ObjArqueodr.nSteArqueoCajaID Then

                strSQL = "SELECT        ISNULL(MIN(nCodigoDesde), 0) AS Minimo " &
                     "FROM dbo.SteReciboEntregado AS RE " &
                     "WHERE (nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") And (nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " &
                     "And (dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " &
                     "AND (nCerrado = 1) " &
                     "AND (nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " &
                     "AND (nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " &
                     "AND (nCodigoTalonario = " & CodTalonario & ")"
                ObjFrmSteEditRecibos.nReciboMin = XcDatosV.ExecuteScalar(strSQL)


                strSQL = "SELECT        ISNULL(MAX(nCodigoHasta), 0) AS Minimo " &
                     "FROM dbo.SteReciboEntregado AS RE " &
                     "WHERE (nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") And (nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " &
                     "And (dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " &
                     "AND (nCerrado = 1) " &
                     "AND (nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " &
                     "AND (nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " &
                     "AND (nCodigoTalonario = " & CodTalonario & ")"
                ObjFrmSteEditRecibos.nReciboMax = XcDatosV.ExecuteScalar(strSQL)


            Else
                'Asigna Recibo Minimo: 
                strSQL = "Select IsNull(MIN(RE.nCodigoDesde),0)  As Minimo " &
                     "FROM SteReciboEntregado As RE INNER JOIN StbDepartamento As D On RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio As M On D.nStbDepartamentoID = M.nStbDepartamentoID " &
                     "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") And (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " &
                     "And (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " &
                     "AND (RE.nCerrado = 1) " &
                     "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " &
                     "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " &
                     "AND (RE.nCodigoTalonario = " & CodTalonario & ")"
                ObjFrmSteEditRecibos.nReciboMin = XcDatosV.ExecuteScalar(strSQL)
                'Asigna Recibo Máximo:
                strSQL = "SELECT ISNULL(MAX(RE.nCodigoHasta), 0) AS Maximo " &
                         "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " &
                         "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " &
                         "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " &
                         "AND (RE.nCerrado = 1)  " &
                         "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " &
                         "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " &
                         "AND (RE.nCodigoTalonario = " & CodTalonario & ")"
                ObjFrmSteEditRecibos.nReciboMax = XcDatosV.ExecuteScalar(strSQL)
            End If

            ObjFrmSteEditRecibos.ShowDialog()

            'Si se ingresó un nuevo Arqueo: 
            If ObjFrmSteEditRecibos.IdRecibo <> 0 Then
                CargarDocumentos()
                FormatoDocumentos()
                XdsDetalle("Documentos").SetCurrentByID("nSteArqueoReciboID", ObjFrmSteEditRecibos.IdRecibo)
                Me.grdArqueoDocumentos.Row = XdsDetalle("Documentos").BindingSource.Position
                'Inhabilitar: 
                InhabilitarControles()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditRecibos.Close()
            ObjFrmSteEditRecibos = Nothing

            XcDatosV.Close()
            XcDatosV = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       LlamaModificarRecibos
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       para Modificar Recibos de un Arqueo.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarRecibos()
        Dim ObjFrmSteEditRecibos As New frmSteEditArqueoRecibo
        Dim XcDatosRe As New BOSistema.Win.XComando

        Try

            Dim IntIdRecibo As Integer
            Dim nCod As Integer
            Dim CodTalonario As Integer

            Dim StrSql As String

            'Si no existen registros:
            If Me.grdArqueoDocumentos.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            CodTalonario = IntCodigoTalonario(Format(Me.cdeFechaA.Value, "yyyy-MM-dd"))
            'Asigna Recibo Minimo:
            StrSql = "SELECT IsNull(MIN(RE.nCodigoDesde),0)  AS Minimo " & _
                     "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " & _
                     "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " & _
                     "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "AND (RE.nCerrado = 1) " & _
                     "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                     "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                     "AND (RE.nCodigoTalonario = " & CodTalonario & ")"
            ObjFrmSteEditRecibos.nReciboMin = XcDatosRe.ExecuteScalar(StrSql)
            'Asigna Recibo Máximo:
            StrSql = "SELECT ISNULL(MAX(RE.nCodigoHasta), 0) AS Maximo " & _
                     "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " & _
                     "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " & _
                     "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "AND (RE.nCerrado = 1)  " & _
                     "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                     "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                     "AND (RE.nCodigoTalonario = " & CodTalonario & ")"
            ObjFrmSteEditRecibos.nReciboMax = XcDatosRe.ExecuteScalar(StrSql)

            ObjFrmSteEditRecibos.ModoFrm = "UPD"
            ObjFrmSteEditRecibos.IdArqueo = Me.intArqueoID
            ObjFrmSteEditRecibos.nCodigoTalonario = CodTalonario
            ObjFrmSteEditRecibos.IdRecibo = XdsDetalle("Documentos").ValueField("nSteArqueoReciboID")
            ObjFrmSteEditRecibos.ShowDialog()

            CargarDocumentos()
            FormatoDocumentos()

            'Encuentra Recibo siguiente:
            StrSql = "SELECT nCodigo FROM SteArqueoRecibo WHERE (nSteArqueoReciboID = " & ObjFrmSteEditRecibos.IdRecibo & ")"
            nCod = XcDatosRe.ExecuteScalar(StrSql)

            StrSql = "SELECT ARQ.nSteArqueoReciboID " & _
                     "FROM (SELECT  ISNULL(MIN(nCodigo), 0) AS Cod FROM (SELECT nCodigo FROM SteArqueoRecibo " & _
                     "WHERE (nSteArqueoCajaID = " & Me.intArqueoID & ") AND (nCodigo > " & nCod & ")) AS a) AS b INNER JOIN SteArqueoRecibo AS ARQ ON b.Cod = ARQ.nCodigo " & _
                     "WHERE (ARQ.nSteArqueoCajaID = " & Me.intArqueoID & ")"
            If XcDatosRe.ExecuteScalar(StrSql) = 0 Then
                IntIdRecibo = ObjFrmSteEditRecibos.IdRecibo
            Else
                IntIdRecibo = XcDatosRe.ExecuteScalar(StrSql)
            End If
            'Se ubica en el recibo correspondiente:
            XdsDetalle("Documentos").SetCurrentByID("nSteArqueoReciboID", IntIdRecibo)
            'XdsDetalle("Documentos").SetCurrentByID("nSteArqueoReciboID", ObjFrmSteEditRecibos.IdRecibo)
            Me.grdArqueoDocumentos.Row = XdsDetalle("Documentos").BindingSource.Position
            'Inhabilitar: 
            InhabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditRecibos.Close()
            ObjFrmSteEditRecibos = Nothing

            XcDatosRe.Close()
            XcDatosRe = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/01/2008
    ' Procedure Name:       LlamaEliminarRecibosRango
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Recibo existente dentro de un Rango.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRecibosRango()
        Dim ObjFrmSteEditRecibos As New frmSteEditArqueoRecibo
        Dim XcDatosV As New BOSistema.Win.XComando

        Try

            Dim strSQL As String
            Dim CodTalonario As Integer

            'Si no existen registros:
            If Me.grdArqueoDocumentos.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si se indicó Minuta de Depósito y es el último Recibo:
            If Me.grdArqueoDocumentos.RowCount = 1 Then
                If Me.cboMinuta.SelectedIndex <> -1 Then
                    MsgBox("Ya se asignó Minuta de Depósito." & Chr(13) & "Deben existir Documentos asociados.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            ObjFrmSteEditRecibos.IdArqueo = Me.intArqueoID
            ObjFrmSteEditRecibos.IdRecibo = XdsDetalle("Documentos").ValueField("nSteArqueoReciboID")
            CodTalonario = IntCodigoTalonario(Format(Me.cdeFechaA.Value, "yyyy-MM-dd"))
            ObjFrmSteEditRecibos.nCodigoTalonario = CodTalonario
            ObjFrmSteEditRecibos.ModoFrm = "DEL"

            'Asigna Recibo Minimo:
            strSQL = "SELECT IsNull(MIN(RE.nCodigoDesde),0)  AS Minimo " & _
                     "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " & _
                     "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " & _
                     "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "AND (RE.nCerrado = 1) " & _
                     "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                     "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                     "AND (RE.nCodigoTalonario = " & CodTalonario & ")"
            ObjFrmSteEditRecibos.nReciboMin = XcDatosV.ExecuteScalar(strSQL)
            'Asigna Recibo Máximo:
            strSQL = "SELECT ISNULL(MAX(RE.nCodigoHasta), 0) AS Maximo " & _
                     "FROM SteReciboEntregado AS RE INNER JOIN StbDepartamento AS D ON RE.nStbDepartamentoID = D.nStbDepartamentoID INNER JOIN StbMunicipio AS M ON D.nStbDepartamentoID = M.nStbDepartamentoID " & _
                     "WHERE (RE.nSrhCajeroId = " & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ") AND (M.nStbMunicipioID = " & cboCaja.Columns("nStbMunicipioId").Value & ") " & _
                     "AND (RE.dFechaArqueo = CONVERT(DATETIME, '" & Format(Me.cdeFechaA.Value, "yyyy-MM-dd") & "', 102)) " & _
                     "AND (RE.nCerrado = 1)  " & _
                     "AND (RE.nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                     "AND (RE.nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") " & _
                     "AND (RE.nCodigoTalonario = " & CodTalonario & ")"
            ObjFrmSteEditRecibos.nReciboMax = XcDatosV.ExecuteScalar(strSQL)

            ObjFrmSteEditRecibos.ShowDialog()

            'Si se ingreso un nuevo Arqueo:
            CargarDocumentos()
            FormatoDocumentos()
            'XdsDetalle("Documentos").SetCurrentByID("nSteArqueoReciboID", ObjFrmSteEditRecibos.IdRecibo)
            'Me.grdArqueoDocumentos.Row = XdsDetalle("Documentos").BindingSource.Position

            'Habilitar Controles:
            InhabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditRecibos.Close()
            ObjFrmSteEditRecibos = Nothing

            XcDatosV.Close()
            XcDatosV = Nothing
        End Try
    End Sub
    'Anexado Febrero 23 del 2011 Permite Anular un recibo en el arqueo que previamente este anulado en recuperacion de cartera.
    Private Sub LlamaAnularRecibo()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XcBusca As New BOSistema.Win.XDataSet.xDataTable
        Dim xPosicion As Long
        Try

            Dim StrSql As String
            If Me.grdArqueoDocumentos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If



            If XdsDetalle("Documentos").ValueField("nValor") = 0 Then
                MsgBox("Este Recibo tiene valor Cero." & Chr(13) & "Ya habia sido anulado anteriormente.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If IsDBNull(XdsDetalle("Documentos").ValueField("nSccReciboOficialCajaID")) Then
                MsgBox("No esta asociado a un recibo de caja" & Chr(13) & "Deben existir Documentos asociados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT     dbo.StbValorCatalogo.sCodigoInterno, dbo.SccReciboOficialCaja.nSccReciboOficialCajaID  FROM         dbo.SccReciboOficialCaja INNER JOIN                       dbo.StbValorCatalogo ON dbo.SccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID WHERE     (dbo.SccReciboOficialCaja.nSccReciboOficialCajaID = " & XdsDetalle("Documentos").ValueField("nSccReciboOficialCajaID") & ")"
            XcBusca.ExecuteSql(StrSql)
            If XcBusca.Table.Rows.Count = 0 Then
                MsgBox("No esta asociado a un recibo de caja" & Chr(13) & "Deben existir Documentos asociados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If XcBusca.ValueField("sCodigoInterno") <> "3" Then
                MsgBox("Recibo no ha sido anulado en Recuperacion de Cartera (Caja)" & Chr(13) & "Debe existir Recibo Anulado en Credito.", MsgBoxStyle.Information)
                Exit Sub
            End If


            If MsgBox("¿Está seguro de dar por anulado el recibo seleccionado(Esto pondra en Cero el Monto del Valor para este recibo en este arqueo)?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then


                GuardarAuditoriaTablas(28, 2, "Actualizar SteArqueoRecibo Anular", XdsDetalle("Documentos").ValueField("nSteArqueoReciboID"), InfoSistema.IDCuenta)

                StrSql = "Update dbo.SteArqueoRecibo Set nValor=0,  nUsuariomodificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate()  Where nSteArqueoReciboID=" & XdsDetalle("Documentos").ValueField("nSteArqueoReciboID")
                xPosicion = XdsDetalle("Documentos").ValueField("nSteArqueoReciboID") 'XdsDetalle("Documentos").BindingSource.Position
                XcDatos.ExecuteNonQuery(StrSql)
                CargarDocumentos()
                FormatoDocumentos()
                MsgBox("El recibo se Anulo Satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdArqueoDocumentos.Caption = "Arqueo de Documentos (" + Me.grdArqueoDocumentos.RowCount.ToString + " registros)"
                XdsDetalle("Documentos").SetCurrentByID("nSteArqueoReciboID", xPosicion)
            End If

            'Si se indicó Minuta de Depósito y es el último Recibo:
            'If Me.grdArqueoDocumentos.RowCount = 1 Then
            '    If Me.cboMinuta.SelectedIndex <> -1 Then
            '        MsgBox("Ya se asignó Minuta de Depósito." & Chr(13) & "Deben existir Documentos asociados.", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            'Imposible si el Recibo tiene Recibo Oficial de Caja Activo asociado:            
            'Hacer Distinción entre Recibos Manuales y Automáticos por Caja:

            '-- Recibos Manuales (No hacen distinción por caja):
            'If XdsDetalle("Documentos").ValueField("nManual") = 1 Then
            '    'Desde 15/12/2009: Además que el Recibo Manual sea del TipoPrograma de la Caja del Arqueo:
            '    'Desde Feb 2010: Ademas del Plazo de PAgos y Codigo de Talonario.
            '    'StrSql = " SELECT a.nCodigo FROM (SELECT nCodigo, sSerieDelegacion, nManual, nSteCajaID " & _
            '    '         " FROM vwSccReciboSerie WHERE (sCodigoInterno <> '3') AND (TipoPrograma = " & Me.cboCaja.Columns("CodPrograma").Value & ")) AS a INNER JOIN " & _
            '    '         " (SELECT AR.nCodigo, D.sSerieDelegacion, CASE WHEN AR.nSccReciboOficialCajaID IS NULL THEN 1 ELSE 0 END AS nManual, AC.nSteCajaID " & _
            '    '         " FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
            '    '         " INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
            '    '         " INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
            '    '         " WHERE  (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) AS b " & _
            '    '         " ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion AND a.nManual = b.nManual " & _
            '    '         " WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")"
            '    StrSql = " SELECT a.nCodigo FROM " & _
            '                            "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario " & _
            '                            "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " & _
            '                            "And (nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") AND (nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
            '                            ") AS a INNER JOIN " & _
            '                            " (SELECT AR.nCodigo, D.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " & _
            '                            "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
            '                            "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
            '                            "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
            '                            " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) " & _
            '                            "AS b " & _
            '            "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " & _
            '            "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " & _
            '            "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " & _
            '            "AND a.nCodigoTalonario = b.nCodigoTalonario " & _
            '            "WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")"

            '    '-- Recibos Automáticos (Hacen distinción por caja): 
            'Else
            '    'StrSql = " SELECT a.nCodigo FROM (SELECT nCodigo, sSerieDelegacion, nManual, nSteCajaID " & _
            '    '         " FROM vwSccReciboSerie WHERE (sCodigoInterno <> '3')) AS a INNER JOIN " & _
            '    '         " (SELECT AR.nCodigo, D.sSerieDelegacion, CASE WHEN AR.nSccReciboOficialCajaID IS NULL THEN 1 ELSE 0 END AS nManual, AC.nSteCajaID " & _
            '    '         " FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
            '    '         " INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
            '    '         " INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
            '    '         " WHERE  (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) AS b " & _
            '    '         " ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion AND a.nManual = b.nManual AND a.nSteCajaID = b.nSteCajaID " & _
            '    '         " WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")"
            '    StrSql = "SELECT SccReciboOficialCaja.nSccReciboOficialCajaID " & _
            '             "FROM SccReciboOficialCaja INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
            '             "WHERE (StbValorCatalogo.sCodigoInterno <> '3') " & _
            '             "AND (SccReciboOficialCaja.nSccReciboOficialCajaID = " & XdsDetalle("Documentos").ValueField("nSccReciboOficialCajaID") & ")"
            'End If
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("Existen Recibos Oficiales de Caja ACTIVOS asociados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
            '    XcDatos.ExecuteNonQuery("Delete From SteArqueoRecibo where nSteArqueoReciboID =" & XdsDetalle("Documentos").ValueField("nSteArqueoReciboID"))
            '    CargarDocumentos()
            '    FormatoDocumentos()
            '    MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
            '    Me.grdArqueoDocumentos.Caption = "Arqueo de Documentos (" + Me.grdArqueoDocumentos.RowCount.ToString + " registros)"
            'End If

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
    ' Fecha:                15/01/2008
    ' Procedure Name:       LlamaEliminarRecibos
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Recibo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRecibos()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim nMunicipioParametro As Integer
        Try

            Dim StrSql As String
            If Me.grdArqueoDocumentos.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si se indicó Minuta de Depósito y es el último Recibo:
            If Me.grdArqueoDocumentos.RowCount = 1 Then
                If Me.cboMinuta.SelectedIndex <> -1 Then
                    MsgBox("Ya se asignó Minuta de Depósito." & Chr(13) & "Deben existir Documentos asociados.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si el Recibo tiene Recibo Oficial de Caja Activo asociado:            
            'Hacer Distinción entre Recibos Manuales y Automáticos por Caja:

            '-- Recibos Manuales (No hacen distinción por caja):
            If XdsDetalle("Documentos").ValueField("nManual") = 1 Then


                'Desde 15/12/2009: Además que el Recibo Manual sea del TipoPrograma de la Caja del Arqueo:
                'Desde Feb 2010: Ademas del Plazo de PAgos y Codigo de Talonario.
                'StrSql = " SELECT a.nCodigo FROM (SELECT nCodigo, sSerieDelegacion, nManual, nSteCajaID " & _
                '         " FROM vwSccReciboSerie WHERE (sCodigoInterno <> '3') AND (TipoPrograma = " & Me.cboCaja.Columns("CodPrograma").Value & ")) AS a INNER JOIN " & _
                '         " (SELECT AR.nCodigo, D.sSerieDelegacion, CASE WHEN AR.nSccReciboOficialCajaID IS NULL THEN 1 ELSE 0 END AS nManual, AC.nSteCajaID " & _
                '         " FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                '         " INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                '         " INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                '         " WHERE  (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) AS b " & _
                '         " ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion AND a.nManual = b.nManual " & _
                '         " WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")"

                StrSql = " SELECT        sValorParametro" & _
                        " FROM dbo.StbValorParametro" & _
                        " WHERE (nStbParametroID = 117) "
                nMunicipioParametro = XcDatos.ExecuteScalar(StrSql)


                If Me.ObtenerMunicipioCaja = nMunicipioParametro Then
                    StrSql = " SELECT a.nCodigo FROM " & _
                                    "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario,dFechaRecibo " & _
                                    "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " & _
                                    "And (nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") AND (nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                                    ") AS a INNER JOIN " & _
                                    " (SELECT AR.nCodigo, D.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " & _
                                    "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                                    "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                                    "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                                    " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) " & _
                                    "AS b " & _
                    "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " & _
                    "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " & _
                    "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " & _
                    "AND a.nCodigoTalonario = b.nCodigoTalonario " & _
                    "WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")  AND (a.dFechaRecibo = CONVERT(DATETIME, " & ObjArqueodr.dFechaArqueo & ", 102))"

                Else


                    StrSql = " SELECT a.nCodigo FROM " & _
                                            "(SELECT nCodigo, sSerieDelegacion, nStbTipoProgramaID, nStbTipoPlazoPagosID, nCodigoTalonario " & _
                                            "FROM vwSccReciboSerie WHERE (nManual = 1) AND (sCodigoInterno <> '3') " & _
                                            "And (nStbTipoPlazoPagosID = " & Me.cboCaja.Columns("nStbTipoPlazoPagosID").Value & ") AND (nStbTipoProgramaID = " & Me.cboCaja.Columns("nStbTipoProgramaID").Value & ") " & _
                                            ") AS a INNER JOIN " & _
                                            " (SELECT AR.nCodigo, D.sSerieDelegacion, C.nStbTipoProgramaID, C.nStbTipoPlazoPagosID, AR.nCodigoTalonario " & _
                                            "FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                                            "INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                                            "INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                                            " WHERE (AR.nSccReciboOficialCajaID IS NULL) AND (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) " & _
                                            "AS b " & _
                            "ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion " & _
                            "AND a.nStbTipoProgramaID = b.nStbTipoProgramaID " & _
                            "AND a.nStbTipoPlazoPagosID = b.nStbTipoPlazoPagosID " & _
                            "AND a.nCodigoTalonario = b.nCodigoTalonario " & _
                            "WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")"

                End If
                '-- Recibos Automáticos (Hacen distinción por caja): 
            Else
                'StrSql = " SELECT a.nCodigo FROM (SELECT nCodigo, sSerieDelegacion, nManual, nSteCajaID " & _
                '         " FROM vwSccReciboSerie WHERE (sCodigoInterno <> '3')) AS a INNER JOIN " & _
                '         " (SELECT AR.nCodigo, D.sSerieDelegacion, CASE WHEN AR.nSccReciboOficialCajaID IS NULL THEN 1 ELSE 0 END AS nManual, AC.nSteCajaID " & _
                '         " FROM SteArqueoRecibo AS AR INNER JOIN SteArqueoCaja AS AC ON AR.nSteArqueoCajaID = AC.nSteArqueoCajaID " & _
                '         " INNER JOIN SteCaja AS C ON AC.nSteCajaID = C.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS G ON C.nStbBarrioID = G.nStbBarrioID " & _
                '         " INNER JOIN StbDepartamento AS D ON G.nStbDepartamentoID = D.nStbDepartamentoID " & _
                '         " WHERE  (AR.nSteArqueoCajaID = " & Me.intArqueoID & ")) AS b " & _
                '         " ON a.nCodigo = b.nCodigo AND a.sSerieDelegacion = b.sSerieDelegacion AND a.nManual = b.nManual AND a.nSteCajaID = b.nSteCajaID " & _
                '         " WHERE (a.nCodigo = " & XdsDetalle("Documentos").ValueField("nCodigo") & ")"
                StrSql = "SELECT SccReciboOficialCaja.nSccReciboOficialCajaID " & _
                         "FROM SccReciboOficialCaja INNER JOIN StbValorCatalogo ON SccReciboOficialCaja.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " & _
                         "WHERE (StbValorCatalogo.sCodigoInterno <> '3') " & _
                         "AND (SccReciboOficialCaja.nSccReciboOficialCajaID = " & XdsDetalle("Documentos").ValueField("nSccReciboOficialCajaID") & ")"
            End If
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Recibos Oficiales de Caja ACTIVOS asociados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                GuardarAuditoriaTablas(28, 3, "Eliminar SteArqueoRecibo", XdsDetalle("Documentos").ValueField("nSteArqueoReciboID"), InfoSistema.IDCuenta)
                XcDatos.ExecuteNonQuery("Delete From SteArqueoRecibo where nSteArqueoReciboID =" & XdsDetalle("Documentos").ValueField("nSteArqueoReciboID"))

                CargarDocumentos()
                FormatoDocumentos()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdArqueoDocumentos.Caption = "Arqueo de Documentos (" + Me.grdArqueoDocumentos.RowCount.ToString + " registros)"
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
    ' Fecha:                18/01/2008
    ' Procedure Name:       grdArqueoDocumentos_KeyPress
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo existente, al dar Enter sobre
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdArqueoDocumentos_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdArqueoDocumentos.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                If IntHabilitar = 1 Then
                    LlamaModificarRecibos()
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                23/01/2008
    ' Procedure Name:       grdArqueoEfectivo_KeyPress
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un detalle de Efectivo existente, al dar 
    '                       enter sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdArqueoEfectivo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles grdArqueoEfectivo.KeyPress
        Try
            If e.KeyChar = Convert.ToChar(Keys.Enter) Then
                If IntHabilitar = 1 Then
                    LlamaModificarCantidadEfectivo()
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/01/2008
    ' Procedure Name:       grdArqueoDocumentos_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Recibo existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdArqueoDocumentos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdArqueoDocumentos.DoubleClick
        Try
            If IntHabilitar = 1 Then
                LlamaModificarRecibos()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdArqueoDocumentos_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdArqueoDocumentos.Error
        Control_Error(e.Exception)
    End Sub

    'Sirve para realizar el filtro de la condición introducida en la Barra de Filtro
    Private Sub grdArqueoDocumentos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdArqueoDocumentos.Filter
        Try
            XdsDetalle("Documentos").FilterLocal(e.Condition)
            Me.grdArqueoDocumentos.Caption = "Arqueo de Documentos (" + Me.grdArqueoDocumentos.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#End Region

    Private Sub grdArqueoDocumentos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdArqueoDocumentos.Click

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

    Private Sub cboMinuta_SelectedValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMinuta.SelectedValueChanged

        'Agregado 18 feb 2012 para ver a que banco pertenece la minuta. 



        TxtNombreBanco.Text = ""
        TxtNoCuentaB.Text = ""
        If cboMinuta.SelectedValue <> Nothing Then
            TxtNombreBanco.Text = XdsArqueo("Minuta").ValueField("sNombre")
            TxtNoCuentaB.Text = XdsArqueo("Minuta").ValueField("sNumeroCuenta")

        End If


    End Sub

    Private Sub Seguridad()
        Seg.RefreshPermissions()
        ''Incorporar recibo único al arqueo
        If Seg.HasPermission("IncorporarReciboArqueoUnicoDocumento") Then
            toolIncorporarRecibo.Visible = True
        Else
            toolIncorporarRecibo.Visible = False
        End If
        ''Incorporar recibo al arqueo
        If Seg.HasPermission("IncorporarReciboArqueoDocumento") Then
            Me.toolIncorporarR.Enabled = True
        Else
            Me.toolIncorporarR.Enabled = False
        End If
        ''Agregar recibo al arqueo
        If Seg.HasPermission("AgregarReciboArqueoDocumento") Then
            Me.toolAgregarR.Enabled = True
        Else
            Me.toolAgregarR.Enabled = False
        End If
        ''Modificar recibo en el arqueo
        If Seg.HasPermission("ModificarReciboArqueoDocumento") Then
            Me.toolModificarR.Enabled = True
        Else
            Me.toolModificarR.Enabled = False
        End If
        ''Eliminar recibo del arqueo
        If Seg.HasPermission("EliminarReciboArqueoDocumento") Then
            Me.toolEliminarR.Enabled = True
        Else
            Me.toolEliminarR.Enabled = False
        End If
        ''Eliminar recibos en un rango
        If Seg.HasPermission("EliminarReciboRangoArqueoDocumento") Then
            Me.toolEliminarRS.Enabled = True
        Else
            Me.toolEliminarRS.Enabled = False
        End If
        ''Anular recibo para el arqueo
        If Seg.HasPermission("AnularReciboArqueoDocumento") Then
            Me.toolAnularR.Enabled = True
        Else
            Me.toolAnularR.Enabled = False
        End If
    End Sub


End Class