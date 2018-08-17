' ------------------------------------------------------------------------
' Autor:                Yesenia Gutierrez
' Fecha:                24/09/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteEditReciboEntregadoDpto.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de Recibos Entregados a Delegaciones.
'-------------------------------------------------------------------------
Public Class frmSteEditReciboEntregadoDpto

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim StrDepartamento As String
    Dim IdSteRecibo As Integer
    Dim IdSteDepartamento As Integer
    Dim intTalonarioID As Integer
    Dim nIdMunicipio As String
    Dim nCodigoTalonario As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsCuenta As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjRecibodt As BOSistema.Win.SteEntArqueo.SteReciboEntregadoDptoDataTable
    Dim ObjRecibodr As BOSistema.Win.SteEntArqueo.SteReciboEntregadoDptoRow

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
    ' Fecha:                24/09/2008
    ' Procedure Name:       frmSteEditReciboEntregadoDpto_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboEntregadoDpto_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Fecha:                24/09/2008
    ' Procedure Name:       frmSteEditReciboEntregadoDpto_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se cargan datos.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditReciboEntregadoDpto_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarEmpleado(0)
            CargarTipoPrograma()
            CargarTipoPlazoPagos()
            Me.txtDepartamento.Text = Me.StrDepartamento

            'Si el formulario está en modo edición
            'cargar los datos de la CtaBancaria.
            If ModoForm = "UPD" Then
                CargarReciboEntregado()
            Else
                Me.cboRecibidoPor.Select()
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
    ' Fecha:                24/09/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Entrega de Recibos a Delegaciones"
            Else
                Me.Text = "Modificar Entrega de Recibos a Delegaciones"
            End If

            ObjRecibodt = New BOSistema.Win.SteEntArqueo.SteReciboEntregadoDptoDataTable
            ObjRecibodr = New BOSistema.Win.SteEntArqueo.SteReciboEntregadoDptoRow
            XdsCuenta = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False


            'Limpiar los combos:
            Me.cboRecibidoPor.ClearFields()
            Me.cboTipoPrograma.ClearFields()
            Me.cboTipoPlazoPagos.ClearFields()

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
    ' Fecha:                24/09/2008
    ' Procedure Name:       CargarReciboEntregado
    ' Descripción:          Este procedimiento permite cargar los datos del 
    '                       Recibo en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarReciboEntregado()
        Try

            '-- Buscar el recibo correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjRecibodt.Filter = "nSteReciboEntregadoDptoID = " & IdRecibo
            ObjRecibodt.Retrieve()
            If ObjRecibodt.Count = 0 Then
                Exit Sub
            End If
            ObjRecibodr = ObjRecibodt.Current

            'Empleado Recibe:
            If Not ObjRecibodr.IsFieldNull("nSrhEmpleadoRecibeId") Then
                CargarEmpleado(ObjRecibodr.nSrhEmpleadoRecibeId)
                If Me.cboRecibidoPor.ListCount > 0 Then
                    Me.cboRecibidoPor.SelectedIndex = 0
                End If
                XdsCuenta("Empleado").SetCurrentByID("nSrhEmpleadoID", ObjRecibodr.nSrhEmpleadoRecibeId)
            Else
                Me.cboRecibidoPor.Text = ""
                Me.cboRecibidoPor.SelectedIndex = -1
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

            'Fecha de Entrega:
            If Not ObjRecibodr.IsFieldNull("dFechaEntrega") Then
                Me.cdeFechaEntrega.Value = ObjRecibodr.dFechaEntrega
            Else
                Me.cdeFechaEntrega.Value = FechaServer()
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
            'End If


            'Inicializar los Length de los campos
            Me.txtObservaciones.MaxLength = ObjRecibodr.GetColumnLenght("sObservaciones")

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/09/2008
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
    ' Fecha:                24/09/2008
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

            'Empleado Recibe:
            If Me.cboRecibidoPor.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Empleado válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboRecibidoPor, "Debe seleccionar un Empleado válido.")
                Me.cboRecibidoPor.Focus()
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

            'Fecha de Entrega:
            If Me.cdeFechaEntrega.ValueIsDbNull Then
                MsgBox("La Fecha de Entrega NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaEntrega, "La Fecha de Entrega NO DEBE quedar vacía.")
                Me.cdeFechaEntrega.Focus()
                Exit Function
            End If

            'Fecha Entrega no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFechaEntrega.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaEntrega, "La Fecha NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFechaEntrega.Focus()
                Exit Function
            End If

            'Fecha Entrega no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.cdeFechaEntrega.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cdeFechaEntrega, "La Fecha NO DEBE ser mayor a la de corte en parámetros.")
                Me.cdeFechaEntrega.Focus()
                Exit Function
            End If

            '-- Encuentra Secuencia de Talonario de acuerdo con Fecha de Entrega:
            nCodigoTalonario = IntCodigoTalonario(Format(Me.cdeFechaEntrega.Value, "yyyy-MM-dd"))

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

            'Rango no superior a 5000 Recibos:
            If ((CInt(Me.txtNoReciboH.Text) - CInt(Me.txtNoReciboD.Text)) + 1) > 5000 Then
                MsgBox("El Rango no debe superar los 5000 Recibos.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.txtNoReciboH, "El Rango no debe superar los 5000 Recibos.")
                Me.txtNoReciboH.Focus()
                Exit Function
            End If

            REM REM INICIALMENTE NO ES VIABLE NO DEJARIA REGISTRAR NADA
            'El Código del Recibo (rango) no debe estar Contenido dentro de un Arqueo ACTIVO para el Depto:
            'strSQL = " SELECT AR.nCodigo " & _
            '         " FROM SteArqueoCaja AS AC INNER JOIN SteArqueoRecibo AS AR ON AC.nSteArqueoCajaID = AR.nSteArqueoCajaID INNER JOIN StbValorCatalogo AS C ON AC.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
            '         " INNER JOIN SteCaja AS CA ON AC.nSteCajaID = CA.nSteCajaID INNER JOIN vwStbUbicacionGeografica AS U ON CA.nStbBarrioID = U.nStbBarrioID " & _
            '         " WHERE (C.sCodigoInterno <> '3') AND (U.nStbDepartamentoID = " & Me.IdSteDepartamento & ") AND (AR.nCodigo between " & Trim(RTrim(Me.txtNoReciboD.Text)) & " and " & Trim(RTrim(Me.txtNoReciboH.Text)) & ") AND (C.sCodigoInterno <> '4')"
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("Existen Recibos del rango en un Arqueo de Caja ACTIVO.", MsgBoxStyle.Critical, NombreSistema)
            '    Me.errRecibo.SetError(Me.txtNoReciboD, "Existen Recibos del rango en un Arqueo de Caja ACTIVO.")
            '    Me.txtNoReciboD.Focus()
            '    ValidaDatosEntrada = False
            '    Exit Function
            'End If

            'Imposible duplicar un Código para un Departamento, Tipo de Programa y Periodicidad 
            'de(Pagos) así como el Código de Talonario de acuerdo con la fecha de Entrega:
            '(Si la Fecha de Entrega es mayor que el corte de fechas usar codigo de Talonario actual
            'en caso contrario codigo de Talonario anterior).

            Dim dFechaMinimo As Date
            Dim sFechaMinimo As String = ""
            Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
            'Obtener la fecha del enredo talonario manual 3 1ro de diciembre del 2014
            strSQL = " Select sValorParametro " & _
          " FROM StbValorParametro " & _
          " WHERE (nStbValorParametroID = 114) "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                sFechaMinimo = XdtDatos.ValueField("sValorParametro")
            End If



            dFechaMinimo = Mid(sFechaMinimo, 1, 2) + "/" + Mid(sFechaMinimo, 3, 2) + "/" + Mid(sFechaMinimo, 5, 4)


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

                strSQL = " SELECT SteReciboEntregadoDptoDetalle.nCodigo " & _
                    " FROM SteReciboEntregadoDptoDetalle INNER JOIN SteReciboEntregadoDpto ON SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID = SteReciboEntregadoDpto.nSteReciboEntregadoDptoID " & _
                    " WHERE (SteReciboEntregadoDpto.nStbDepartamentoID = " & Me.IdSteDepartamento & ") " & _
                    " AND (SteReciboEntregadoDptoDetalle.nCodigo BETWEEN " & Trim(RTrim(Me.txtNoReciboD.Text)) & " AND " & Trim(RTrim(Me.txtNoReciboH.Text)) & ") " & _
                    " AND (SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID <> " & Me.IdSteRecibo & ") " & _
                    " AND (SteReciboEntregadoDpto.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                    " AND (SteReciboEntregadoDpto.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                    " AND (SteReciboEntregadoDpto.nCodigoTalonario = " & nCodigoTalonario & ")" & _
                    "AND (dFechaEntrega > CONVERT(DATETIME, '" & Format(dFechaMinimo, "yyyy-MM-dd") & "', 102))" & _
                    " AND (dbo.SteReciboEntregadoDpto.nStbMunicipioID = " & IdMunicipio & ")"
                '& _
                '"AND (dbo.SteReciboEntregadoDpto.nStbMunicipioID =" & Me. & ")"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Ya se registraron Recibos del rango en el Departamento" & Chr(13) & "aplicados al municipio Bluefields para este Tipo de Programa y Periodicidad de Pagos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtNoReciboD, "Existen Recibos del rango en el Departamento y Programa.")
                    Me.txtNoReciboD.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                End If
            Else
                strSQL = " SELECT SteReciboEntregadoDptoDetalle.nCodigo " & _
                    " FROM SteReciboEntregadoDptoDetalle INNER JOIN SteReciboEntregadoDpto ON SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID = SteReciboEntregadoDpto.nSteReciboEntregadoDptoID " & _
                    " WHERE (SteReciboEntregadoDpto.nStbDepartamentoID = " & Me.IdSteDepartamento & ") " & _
                    " AND (SteReciboEntregadoDptoDetalle.nCodigo BETWEEN " & Trim(RTrim(Me.txtNoReciboD.Text)) & " AND " & Trim(RTrim(Me.txtNoReciboH.Text)) & ") " & _
                    " AND (SteReciboEntregadoDptoDetalle.nSteReciboEntregadoDptoID <> " & Me.IdSteRecibo & ") " & _
                    " AND (SteReciboEntregadoDpto.nStbTipoProgramaID = " & Me.cboTipoPrograma.Columns("nStbValorCatalogoID").Value & ") " & _
                    " AND (SteReciboEntregadoDpto.nStbTipoPlazoPagosID = " & Me.cboTipoPlazoPagos.Columns("nStbValorCatalogoID").Value & ") " & _
                    " AND (SteReciboEntregadoDpto.nCodigoTalonario = " & nCodigoTalonario & ")" & _
                       "AND (dFechaEntrega > CONVERT(DATETIME, '" & Format(dFechaMinimo, "yyyy-MM-dd") & "', 102))"
                If RegistrosAsociados(strSQL) Then
                    MsgBox("Ya se registraron Recibos del rango en el Departamento" & Chr(13) & "para este Tipo de Programa y Periodicidad de Pagos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errRecibo.SetError(Me.txtNoReciboD, "Existen Recibos del rango en el Departamento y Programa.")
                    Me.txtNoReciboD.Focus()
                    ValidaDatosEntrada = False
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/09/2008
    ' Procedure Name:       SalvarReciboEntregado
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReciboEntregado()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
			
			If ModoFrm <> "ADD" Then
                GuardarAuditoriaTablas(21, 2, "Modificar SteReciboEntregadoDpto", IdSteRecibo, InfoSistema.IDCuenta)
            End If


            If Me.IdSteDepartamento = 17 And cbAplicaMunicipioAlterno.Checked Then

                strSQL = " EXEC spSteGrabarTalonarioDelegacion " & Me.IdSteRecibo & "," & InfoSistema.IDCuenta & ", '" & ModoForm & "', " & _
                    "" & XdsCuenta("Empleado").ValueField("nSrhEmpleadoID") & ", " & Me.IdSteDepartamento & "," & nCodigoTalonario & ", " & Trim(RTrim(Me.txtNoReciboD.Text)) & ", " & Trim(RTrim(Me.txtNoReciboH.Text)) & ", " & _
                    "'" & Format(Me.cdeFechaEntrega.Value, "yyyy-MM-dd") & "', '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', " & XdsCuenta("TipoPrograma").ValueField("nStbValorCatalogoID") & "," & XdsCuenta("TipoPlazoPagos").ValueField("nStbValorCatalogoID") & "," & Me.IdMunicipio

            Else

                strSQL = " EXEC spSteGrabarTalonarioDelegacion " & Me.IdSteRecibo & "," & InfoSistema.IDCuenta & ", '" & ModoForm & "', " & _
                         "" & XdsCuenta("Empleado").ValueField("nSrhEmpleadoID") & ", " & Me.IdSteDepartamento & "," & nCodigoTalonario & ", " & Trim(RTrim(Me.txtNoReciboD.Text)) & ", " & Trim(RTrim(Me.txtNoReciboH.Text)) & ", " & _
                         "'" & Format(Me.cdeFechaEntrega.Value, "yyyy-MM-dd") & "', '" & Trim(RTrim(Me.txtObservaciones.Text)) & "', " & XdsCuenta("TipoPrograma").ValueField("nStbValorCatalogoID") & "," & XdsCuenta("TipoPlazoPagos").ValueField("nStbValorCatalogoID")

            End If
           

            Me.IdSteRecibo = XcDatos.ExecuteScalar(strSQL)
            If ModoFrm = "ADD" Then
                GuardarAuditoriaTablas(21, 1, "Agregar SteReciboEntregadoDpto", IdSteRecibo, InfoSistema.IDCuenta)


            End If

            '-- Buscar Talonario correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando uno.
            ObjRecibodt.Filter = "nSteReciboEntregadoDptoID = " & Me.IdSteRecibo
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
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)

                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                    Call GuardarAuditoria(2, 25, "Modificación de Entrega de Recibos a Departamentos ID: " & Me.IdSteRecibo & ").")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    'Public Sub SalvarReciboEntregado()
    '    Dim XcEstado As New BOSistema.Win.XComando

    '    Try

    '        If ModoForm = "ADD" Then
    '            ObjRecibodr.nUsuarioCreacionID = InfoSistema.IDCuenta
    '            ObjRecibodr.dFechaCreacion = FechaServer()
    '            ObjRecibodr.nCerrado = 0
    '        Else
    '            ObjRecibodr.nUsuarioModificacionID = InfoSistema.IDCuenta
    '            ObjRecibodr.dFechaModificacion = FechaServer()
    '        End If

    '        'Datos Obligatorios:
    '        ObjRecibodr.nSrhEmpleadoRecibeId = XdsCuenta("Empleado").ValueField("nSrhEmpleadoID")
    '        ObjRecibodr.nStbDepartamentoID = Me.IdSteDepartamento
    '        ObjRecibodr.nCodigoDesde = Trim(RTrim(Me.txtNoReciboD.Text))
    '        ObjRecibodr.nCodigoHasta = Trim(RTrim(Me.txtNoReciboH.Text))
    '        ObjRecibodr.dFechaEntrega = Format(Me.cdeFechaEntrega.Value, "yyyy-MM-dd")

    '        'Observaciones:
    '        If Trim(RTrim(Me.txtObservaciones.Text)).ToString.Length <> 0 Then
    '            ObjRecibodr.sObservaciones = Trim(RTrim(Me.txtObservaciones.Text))
    '        Else
    '            ObjRecibodr.SetFieldNull("sObservaciones")
    '        End If

    '        ObjRecibodr.Update()

    '        'Asignar el Id del Recibo a la 
    '        'variable publica del formulario
    '        IdSteRecibo = ObjRecibodr.nSteReciboEntregadoDptoID
    '        '--------------------------------

    '        'Si el salvado se realizó de forma satisfactoria
    '        'enviar mensaje informando y cerrar el formulario.
    '        If ModoForm = "ADD" Then
    '            MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
    '        Else
    '            MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcEstado.Close()
    '        XcEstado = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/09/2008
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
    ' Fecha:                24/09/2008
    ' Procedure Name:       CargarEmpleado
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Cajeros en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarEmpleado(ByVal intEmpleadoID As Integer)
        Try
            Dim Strsql As String

            Me.cboRecibidoPor.ClearFields() 'And a.sCodCargo = '14': Tesorero, '15': Delegada Departamental
            If intEmpleadoID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE (a.nActivo = 1) And (a.sCodCargo = '14' or a.sCodCargo = '15') " & _
                         " Order by a.nCodigo "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                         " From vwSclRepresentantePrograma a " & _
                         " WHERE ((a.nActivo = 1) And (a.sCodCargo = '14' or a.sCodCargo = '15')) " & _
                         " Or a.nSrhEmpleadoID = " & intEmpleadoID & _
                         " Order by a.nCodigo "
            End If

            If XdsCuenta.ExistTable("Empleado") Then
                XdsCuenta("Empleado").ExecuteSql(Strsql)
            Else
                XdsCuenta.NewTable(Strsql, "Empleado")
                XdsCuenta("Empleado").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboRecibidoPor.DataSource = XdsCuenta("Empleado").Source
            Me.cboRecibidoPor.Rebind()

            Me.cboRecibidoPor.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboRecibidoPor.Splits(0).DisplayColumns("nActivo").Visible = False

            'Configurar el combo: 
            Me.cboRecibidoPor.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboRecibidoPor.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

            Me.cboRecibidoPor.Columns("nCodigo").Caption = "Código"
            Me.cboRecibidoPor.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboRecibidoPor.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboRecibidoPor.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboRecibidoPor_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboRecibidoPor.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en la Cuenta del Banco
    Private Sub cboRecibidoPor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboRecibidoPor.TextChanged
        vbModifico = True
    End Sub

    'Se indica que hubo modificación en la Fecha de Depósito:
    Private Sub cdeFechaEntrega_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaEntrega.TextChanged
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