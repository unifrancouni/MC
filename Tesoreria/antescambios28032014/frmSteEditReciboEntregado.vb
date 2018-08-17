' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                04/08/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditReciboEntregado.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Recibos Entregados.
'-------------------------------------------------------------------------
Public Class frmSteEditReciboEntregado

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim StrDepartamento As String
    Dim IdSteRecibo As Integer
    Dim IdSteDepartamento As Integer
    Dim nCodigoTalonario As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsCuenta As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjRecibodt As BOSistema.Win.SteEntArqueo.SteReciboEntregadoDataTable
    Dim ObjRecibodr As BOSistema.Win.SteEntArqueo.SteReciboEntregadoRow

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

    'Propiedad utilizada para obtener el Nombre del Departamento:
    Public Property sNombreDepartamento() As String
        Get
            sNombreDepartamento = StrDepartamento
        End Get
        Set(ByVal value As String)
            StrDepartamento = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/08/2008
    ' Procedure Name:       frmSteEditReciboEntregado_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboEntregado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Fecha:                04/08/2008
    ' Procedure Name:       frmSteEditReciboEntregado_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se cargan datos.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboEntregado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarCajero(0)
            CargarTipoPrograma()
            CargarTipoPlazoPagos()
            Me.txtDepartamento.Text = Me.StrDepartamento

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoFrm = "UPD" Then
                CargarReciboEntregado()
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
    ' Fecha:                04/08/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Entrega de Recibos"
            Else
                Me.Text = "Modificar Entrega de Recibos"
            End If

            ObjRecibodt = New BOSistema.Win.SteEntArqueo.SteReciboEntregadoDataTable
            ObjRecibodr = New BOSistema.Win.SteEntArqueo.SteReciboEntregadoRow
            XdsCuenta = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos:
            Me.cboCajero.ClearFields()
            Me.cboTipoPrograma.ClearFields()
            Me.cboTipoPlazoPagos.ClearFields()

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
    ' Fecha:                04/08/2008
    ' Procedure Name:       CargarReciboEntregado
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Recibo en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarReciboEntregado()
        Try

            '-- Buscar el recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjRecibodt.Filter = "nSteReciboEntregadoID = " & IdRecibo
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

            'Cargar Combo de Tipo de Programa:
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

            'Número de Recibo Desde:
            If Not ObjRecibodr.IsFieldNull("nCodigoDesde") Then
                Me.txtNoReciboD.Text = ObjRecibodr.nCodigoDesde
            Else
                Me.txtNoReciboD.Text = ""
            End If

            'Número de Recibo Hasta:
            If Not ObjRecibodr.IsFieldNull("nCodigoHasta") Then
                Me.txtNoReciboH.Text = ObjRecibodr.nCodigoHasta
            Else
                Me.txtNoReciboH.Text = ""
            End If

            'Fecha de Arqueo:
            If Not ObjRecibodr.IsFieldNull("dFechaArqueo") Then
                Me.cdeFechaArqueo.Value = ObjRecibodr.dFechaArqueo
            Else
                Me.cdeFechaArqueo.Value = FechaServer()
            End If

            'Observaciones:
            If Not ObjRecibodr.IsFieldNull("sObservaciones") Then
                Me.txtObservaciones.Text = ObjRecibodr.sObservaciones
            Else
                Me.txtObservaciones.Text = ""
            End If

            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjRecibodr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/08/2008
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarReciboEntregado()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/08/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
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

            'Fecha de Arqueo:
            If Me.cdeFechaArqueo.ValueIsDbNull Then
                MsgBox("La Fecha prevista para el Arqueo NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaArqueo, "La Fecha del Arqueo NO DEBE quedar vacía.")
                Me.cdeFechaArqueo.Focus()
                Exit Function
            End If

            'Fecha Arqueo no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaArqueo.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaArqueo, "La Fecha NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaArqueo.Focus()
                Exit Function
            End If

            'Fecha Arqueo no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaArqueo.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaArqueo, "La Fecha NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaArqueo.Focus()
                Exit Function
            End If

            '-- Encuentra Secuencia de Talonario de acuerdo con Fecha de Entrega a Cajero (Arqueo):
            nCodigoTalonario = IntCodigoTalonario(Format(Me.cdeFechaArqueo.Value, "yyyy-MM-dd"))

            'Número Recibo Desde: 
            If Trim(RTrim(Me.txtNoReciboD.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo Inicial NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboD, "El Número del Recibo Inicial NO DEBE quedar vacío.")
                Me.txtNoReciboD.Focus()
                Exit Function
            End If

            'Número Recibo Hasta: 
            If Trim(RTrim(Me.txtNoReciboH.Text)).ToString.Length = 0 Then
                MsgBox("El Número del Recibo Final NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboH, "El Número del Recibo Final NO DEBE quedar vacío.")
                Me.txtNoReciboH.Focus()
                Exit Function
            End If

            'Número Recibo Desde: 
            If CInt(Me.txtNoReciboD.Text) = 0 Then
                MsgBox("Número de Recibo Inicial Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboD, "Número de Recibo Inicial Inválido.")
                Me.txtNoReciboD.Focus()
                Exit Function
            End If

            'Número Recibo Hasta: 
            If CInt(Me.txtNoReciboH.Text) = 0 Then
                MsgBox("Número de Recibo Final Inválido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboH, "Número de Recibo Final Inválido.")
                Me.txtNoReciboH.Focus()
                Exit Function
            End If

            'Número de Recibo (Hasta) mayor: 
            If CInt(Me.txtNoReciboH.Text) < CInt(Me.txtNoReciboD.Text) Then
                MsgBox("El No. del Recibo Final NO DEBE ser Menor que el No. del Recibo Inicial.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboH, "El Número del Recibo Final NO DEBE ser Menor.")
                Me.txtNoReciboH.Focus()
                Exit Function
            End If

            'Rango no superior a 500 Recibos:
            If (CInt(Me.txtNoReciboH.Text) - CInt(Me.txtNoReciboD.Text)) > 500 Then
                MsgBox("El Rango no debe superar los 500 Recibos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboH, "El Rango no debe superar los 500 Recibos.")
                Me.txtNoReciboH.Focus()
                Exit Function
            End If

            'El Código del Recibo (rango) no debe estar Contenido dentro de un Arqueo ACTIVO 
            'para el Depto Y adicionalmente tipo de Programa y Plazo de Pagos
            'así como para el Codigo de Talonario de acuerdo con la fecha de entrega al Cajero.
            strSQL = " SELECT AR.nCodigo " & _
                     " FROM SteArqueoCaja AS AC INNER JOIN SteArqueoRecibo AS AR ON AC.nSteArqueoCajaID = AR.nSteArqueoCajaID INNER JOIN StbValorCatalogo AS C ON AC.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
                     " INNER JOIN SteCaja AS CA ON AC.nSteCajaID = CA.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON CA.nStbBarrioID = U.nStbBarrioID " & _
                     " WHERE (C.sCodigoInterno <> '3') AND (U.nStbDepartamentoID = " & Me.IdSteDepartamento & ") " & _
                     " AND (AR.nCodigo between " & Trim(RTrim(Me.txtNoReciboD.Text)) & " and " & Trim(RTrim(Me.txtNoReciboH.Text)) & ") " & _
                     " AND (C.sCodigoInterno <> '4') AND (CA.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                     " AND (CA.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     " AND (AR.nCodigoTalonario = " & Me.nCodigoTalonario & ") " & _
                     " AND (AR.nSccReciboOficialCajaID IS NULL)"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Existen Recibos del rango en un Arqueo de Caja ACTIVO.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoReciboD, "Existen Recibos del rango en un Arqueo de Caja ACTIVO.")
                Me.txtNoReciboD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible duplicar un Código para: Igual fecha, cajero y departamento:
            'Y adicionalmente tipo de Programa y Plazo de Pagos
            strSQL = "Exec SpSteRevisaReciboExiste '" & Format(Me.cdeFechaArqueo.Value, "yyyy-MM-dd") & "', " & Me.txtNoReciboD.Text & ", " & Me.txtNoReciboH.Text & ", -1, " & cboCajero.Columns("nSrhEmpleadoID").Value & ", " & Me.IdSteDepartamento & "," & Me.IdSteRecibo & ", " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & "," & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & "," & Me.nCodigoTalonario
            If RegistrosAsociados(strSQL) Then
                MsgBox("El rango de recibos indicado (o parte de este) ya ha sido" & Chr(13) & "asignado para este cajero en esta fecha, Departamento," & Chr(13) & "Periodicidad de Pagos y Programa.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoReciboD, "Rango Inválido.")
                Me.txtNoReciboD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible asignar el mismo rango (o parte del rango) a otro Cajero en el mismo Departamento:
            'Y para el mismo Tipo de Programa y Periodicidad de Pagos:
            strSQL = "Exec SpSteRevisaReciboCajero " & Me.txtNoReciboD.Text & ", " & Me.txtNoReciboH.Text & ", " & cboCajero.Columns("nSrhEmpleadoID").Value & ", " & Me.IdSteDepartamento & ", " & Me.IdSteRecibo & "," & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & "," & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & "," & Me.nCodigoTalonario
            If XcDatos.ExecuteScalar(strSQL) > 0 Then
                MsgBox("El rango de recibos indicado (o parte de este) ya ha sido" & Chr(13) & "asignado a otro cajero en este Departamento, Programa" & Chr(13) & "y Periodicidad.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoReciboD, "Rango Inválido.")
                Me.txtNoReciboD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            '-- VALIDACIONES CONTRA LAS ENTREGAS REALIZADAS A LAS DELEGACIONES:
            'Imposible si el Rango no existe en una Entrega CERRADA de Recibos a Delegaciones:
            'Y para el mismo Tipo de Programa y Periodicidad:
            strSQL = "SELECT  SteReciboEntregadoDpto.nCerrado " & _
                     "FROM SteReciboEntregadoDpto INNER JOIN SteReciboEntregadoDptoDetalle ON SteReciboEntregadoDpto.nSteReciboEntregadoDptoID = SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID " & _
                     "WHERE (SteReciboEntregadoDpto.nStbDepartamentoID = " & Me.IdSteDepartamento & ") AND (SteReciboEntregadoDpto.nCerrado = 1) " & _
                     "AND (SteReciboEntregadoDptoDetalle.nCodigo BETWEEN " & Me.txtNoReciboD.Text & " AND " & Me.txtNoReciboH.Text & ") AND (SteReciboEntregadoDpto.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (SteReciboEntregadoDpto.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (SteReciboEntregadoDpto.nCodigoTalonario = " & Me.nCodigoTalonario & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("No existe una Entrega Cerrada para el Departamento," & Chr(13) & "Programa y Periodicidad de Pagos.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoReciboD, "Rango Inválido.")
                Me.txtNoReciboD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si el total de recibos en el rango es diferente de las existencias en el Departamento:
            'Y adicionalmente para el mismo Tipo de Programa
            strSQL = "SELECT COUNT(SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoDetalleID) AS TotalRecibos " & _
                     "FROM SteReciboEntregadoDpto INNER JOIN SteReciboEntregadoDptoDetalle ON SteReciboEntregadoDpto.nSteReciboEntregadoDptoID = SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID " & _
                     "WHERE (SteReciboEntregadoDpto.nStbDepartamentoID = " & Me.IdSteDepartamento & ") AND (SteReciboEntregadoDpto.nCerrado = 1) " & _
                     "AND (SteReciboEntregadoDptoDetalle.nCodigo BETWEEN " & Me.txtNoReciboD.Text & " AND " & Me.txtNoReciboH.Text & ") AND (SteReciboEntregadoDpto.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (SteReciboEntregadoDpto.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (SteReciboEntregadoDpto.nCodigoTalonario = " & Me.nCodigoTalonario & ")"
            If XcDatos.ExecuteScalar(strSQL) <> (((CInt(Me.txtNoReciboH.Text) - CInt(Me.txtNoReciboD.Text)) + 1)) Then
                MsgBox("Parte del rango de recibos indicado no existe en" & Chr(13) & "una entrega Cerrada para el Departamento," & Chr(13) & "Programa y Periodicidad.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.txtNoReciboD, "Rango Inválido.")
                Me.txtNoReciboD.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Imposible si la Fecha Prevista del Arqueo es menor que la Fecha de Entrega al Dpto:
            'Y para el mismo Tipo de Programa y Periodicidad:
            strSQL = "SELECT SteReciboEntregadoDpto.dFechaEntrega " & _
                     "FROM SteReciboEntregadoDpto INNER JOIN SteReciboEntregadoDptoDetalle ON SteReciboEntregadoDpto.nSteReciboEntregadoDptoID = SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID " & _
                     "WHERE (SteReciboEntregadoDpto.nStbDepartamentoID = " & Me.IdSteDepartamento & ") AND (SteReciboEntregadoDpto.nCerrado = 1) " & _
                     "AND (SteReciboEntregadoDptoDetalle.nCodigo BETWEEN " & Me.txtNoReciboD.Text & " AND " & Me.txtNoReciboH.Text & ") AND (SteReciboEntregadoDpto.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (SteReciboEntregadoDpto.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                     "AND (SteReciboEntregadoDpto.nCodigoTalonario = " & Me.nCodigoTalonario & ")"
            If DateDiff("d", XcDatos.ExecuteScalar(strSQL), Me.cdeFechaArqueo.Value) < 0 Then
                MsgBox("Fecha de Arqueo No debe ser inferior a la Fecha" & Chr(13) & "de Entrega de los Talonarios al Departamento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errRecibo.SetError(Me.cdeFechaArqueo, "Fecha Inválida.")
                Me.cdeFechaArqueo.Focus()
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
    ' Fecha:                04/08/2008
    ' Procedure Name:       SalvarReciboEntregado
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub SalvarReciboEntregado()
        Dim XcEstado As New BOSistema.Win.XComando
        Try

            If ModoForm = "ADD" Then
                ObjRecibodr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjRecibodr.dFechaCreacion = FechaServer()
                ObjRecibodr.nCerrado = 0
            Else
                ObjRecibodr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjRecibodr.dFechaModificacion = FechaServer()
            End If

            'Datos Obligatorios:
            ObjRecibodr.nSrhCajeroId = XdsCuenta("Cajero").ValueField("nSrhEmpleadoID")
            ObjRecibodr.nStbDepartamentoID = Me.IdSteDepartamento
            ObjRecibodr.nCodigoDesde = Trim(RTrim(Me.txtNoReciboD.Text))
            ObjRecibodr.nCodigoHasta = Trim(RTrim(Me.txtNoReciboH.Text))
            ObjRecibodr.dFechaArqueo = Format(Me.cdeFechaArqueo.Value, "yyyy-MM-dd")
            ObjRecibodr.nStbTipoProgramaID = Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value
            ObjRecibodr.nCodigoTalonario = Me.nCodigoTalonario
            ObjRecibodr.nStbTipoPlazoPagosID = Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value

            'Observaciones:
            If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
                ObjRecibodr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
            Else
                ObjRecibodr.SetFieldNull("sObservaciones")
            End If

            ObjRecibodr.Update()

            'Asignar el Id del Recibo a la 
            'variable publica del formulario
            IdSteRecibo = ObjRecibodr.nSteReciboEntregadoID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoForm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(2, 25, "Modificación de Entrega de Recibos a Cajeros ID: " & Me.IdSteRecibo & ").")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcEstado.Close()
            XcEstado = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/08/2008
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
                            SalvarReciboEntregado()
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
    ' Fecha:                17/12/2009
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
    ' Fecha:                08/02/2010
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

            'Asignando a las fuentes de datos:
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
    ' Fecha:                04/08/2008
    ' Procedure Name:       CargarCajero
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajeros en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCajero(ByVal intCajeroID As Integer)
        Try
            Dim Strsql As String

            Me.cboCajero.ClearFields() 'And a.sCodCargo = '04'
            REM REUNION LESTER 08/JULIO/2009: And a.sCodCargo = '04': Cajero, '10': Oficial de Crédito, '17': Responsable de Cartera
            If intCajeroID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE (a.sCodCargo = '04' or a.sCodCargo = '10' or a.sCodCargo = '17') AND (a.nActivo = 1) " & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE ((a.sCodCargo = '04' or a.sCodCargo = '10' or a.sCodCargo = '17') AND (a.nActivo = 1)) " & _
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
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

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
    Private Sub cdeFechaRecibo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaArqueo.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoReciboD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoReciboD.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNoReciboD_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoReciboD.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtNoReciboH_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoReciboH.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtNoReciboH_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNoReciboH.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtObservaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPrograma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPrograma.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoPagos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazoPagos.TextChanged
        vbModifico = True
    End Sub
End Class