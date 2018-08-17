' ------------------------------------------------------------------------
' Project Item Name:    frmSteEditArqueoEfectivo.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de un Arqueo de Caja.
'-------------------------------------------------------------------------
Public Class frmSteEditArqueoEfectivo

    '-- Declaracion de Variables: 
    Dim ModoForm As String
    Dim intArqueoID As Integer
    Dim IntHabilitar As Integer
    Dim IntPermiteEditar As Integer
    Dim nCodigoTalonario As Integer

    '-- Clases para procesar la informacion de los combos:
    Dim XdsArqueo As BOSistema.Win.XDataSet
    Dim XdsDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjArqueodt As BOSistema.Win.SteEntArqueo.SteArqueo_ReciboAutomático_CajaDataTable
    Dim ObjArqueodr As BOSistema.Win.SteEntArqueo.SteArqueo_ReciboAutomático_CajaRow

    Dim intCajero As Integer

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

    ' ------------------------------------------------------------------------
    ' Procedure Name:       frmSteEditArqueoEfectivo_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditArqueoEfectivo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                If vbModifico = True Then
                    cmdCancelar_Click(sender, e)
                Else
                    XdsArqueo.Close()
                    XdsArqueo = Nothing

                    ObjArqueodt.Close()
                    ObjArqueodt = Nothing

                    ObjArqueodr.Close()
                    ObjArqueodr = Nothing

                    XdsDetalle.Close()
                    XdsDetalle = Nothing
                End If
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
    ' Procedure Name:       frmSteEditArqueoEfectivo_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Arqueo en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSteEditArqueoEfectivo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            InicializarVariables()
            vbModifico = False

            If CajaActual_Cajero(intCajero) = 0 Then ' Determinar la caja que el cajero loggeado tiene asignada
                MsgBox("El cajero actual no tiene asignada una caja.", MsgBoxStyle.Critical, NombreSistema)
                cmdCancelar_Click(sender, e)
            End If

            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       InhabilitarControles
    ' Descripción:          Este procedimiento permite Inhabilitar Controles
    '                       de las Carpetas.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            If IntHabilitar = 0 Then

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ----------------------------------------------------------------------------------------------------------------------
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables y controles.
    '-----------------------------------------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable

        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Arqueo de Caja"
            Else
                Me.Text = "Modificar Arqueo de Caja"
            End If

            ObjArqueodt = New BOSistema.Win.SteEntArqueo.SteArqueo_ReciboAutomático_CajaDataTable
            ObjArqueodr = New BOSistema.Win.SteEntArqueo.SteArqueo_ReciboAutomático_CajaRow

            XdsDetalle = New BOSistema.Win.XDataSet
            XdsArqueo = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False
            Me.grdArqueoEfectivo.ClearFields()

            intCajero = CajeroActual() ' Cajero actualmente loggeado en el Sistema

            ObjComando = New BOSistema.Win.XDataSet.xDataTable
            ObjComando.ExecuteSql("SELECT nSteArqueoCajaID FROM SteArqueo_ReciboAutomático_Caja Where nSrhCajeroId=" & intCajero & " AND dFechaArqueo>=CAST(getdate() AS date) and dFechaArqueo<=CAST(getdate() AS date)")
            If ObjComando.Count > 0 Then
                ModoForm = "UPD"
            Else
                ModoForm = "ADD"
            End If

            If ModoForm = "ADD" Then
                'Inicializar Fecha:
                ObjArqueodr = ObjArqueodt.NewRow
                Me.cdeFecha.Value = ModSMUSURA0.FechaServer
                Me.txtEstadoAE.Text = "Nuevo"
                Me.cboCajero.ClearFields()
                Me.cboCajero.Enabled = False
                Me.txtCodigoAE.Text = nCódigo() ' Valor actual del campo nCodigo en SteArqueo_ReciboAutomático_Caja
                intArqueoID = UltimoIdentity()  ' Valor del último Identity insertado en SteArqueo_ReciboAutomático_Caja
                CargarCajero(intCajero)         ' Cargar en el cboCajero el nombre del Cajero Actual
                Me.cboCajero.Text = NombreCajero(intCajero)  ' Colocar en el text del cboCajero el nombre del Cajero Actual
            Else
                Me.intArqueoID = ObjComando("nSteArqueoCajaID")
                CargarArqueo()
                CargarEfectivo()
                FormatoEfectivo()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Function nCódigo() As Integer
        'Declaracion de Variables 
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Try
            ObjComando = New BOSistema.Win.XDataSet.xDataTable
            ObjComando.ExecuteSql("SELECT COUNT(nCodigo) + 1 AS nCodigo FROM SteArqueo_ReciboAutomático_Caja")
            If ObjComando.Count > 0 Then
                Return ObjComando("nCodigo")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjComando = Nothing
        End Try
    End Function

    Public Function UltimoIdentity() As Integer
        'Declaracion de Variables 
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Try
            ObjComando = New BOSistema.Win.XDataSet.xDataTable
            ObjComando.ExecuteSql("select IDENT_CURRENT('SteArqueo_ReciboAutomático_Caja') + 1 as Código")
            If ObjComando.Count > 0 Then
                Return ObjComando("Código")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjComando = Nothing
        End Try
    End Function

    Public Function CajeroActual() As Integer
        Dim strSQL As String

        'Declaracion de Variables
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Try
            ObjComando = New BOSistema.Win.XDataSet.xDataTable
            'Determinar el Cajero
            strSQL = " SELECT objEmpleadoID FROM SsgCuenta " & _
                     " WHERE SsgCuentaID = " & InfoSistema.IDCuenta
            ObjComando.ExecuteSql(strSQL)
            If ObjComando.Count > 0 Then
                Return ObjComando("objEmpleadoID")
            Else
                Return Nothing
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjComando = Nothing
        End Try
    End Function

    Public Function NombreCajero(ByVal intCajeroID As Integer) As String
        Dim strSQL As String = ""
        Dim nc As String = ""

        'Declaracion de Variables
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Try
            ObjComando = New BOSistema.Win.XDataSet.xDataTable
            'Determinar el Cajero
            NombreCajero = ""
            strSQL = " Select sNombreEmpleado From vwSclRepresentantePrograma a " &
                        " WHERE a.nSrhEmpleadoID = " & intCajeroID & " Order by a.nCodigo"
            ObjComando.ExecuteSql(strSQL)
            If ObjComando.Count > 0 Then
                nc = ObjComando("sNombreEmpleado")
            Else
                nc = ""
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjComando = Nothing
        End Try
        Return nc
    End Function

    Public Function CajaActual_Cajero(ByVal intCajeroID As Integer) As Integer
        Dim strSQL As String

        'Declaracion de Variables
        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
        Try
            ObjComando = New BOSistema.Win.XDataSet.xDataTable
            CajaActual_Cajero = False
            strSQL = "SELECT nSteCajeroID, nSteCajaID, nActiva FROM dbo.SteCajeroCajas " & _
                     "WHERE (nSteCajeroID ='" & intCajeroID & "') AND (nActiva = 1)"
            ObjComando.ExecuteSql(strSQL)
            If ObjComando.Count > 0 Then
                CajaActual_Cajero = ObjComando("nSteCajaID")
            Else
                CajaActual_Cajero = 0
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjComando = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Procedure Name:       CargarArqueo
    ' Descripción:          Este procedimiento permite cargar los datos del Arqueo
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarArqueo()
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable

        Try
            Dim strSQL As String = ""

            ObjArqueodt.Filter = "nSteArqueoCajaID = " & Me.intArqueoID
            ObjArqueodt.Retrieve()
            If ObjArqueodt.Count = 0 Then
                Exit Sub
            End If
            ObjArqueodr = ObjArqueodt.Current

            'Código de Arqueo:
            If Not ObjArqueodr.IsFieldNull("nCodigo") Then
                Me.txtCodigoAE.Text = ObjArqueodr.nCodigo
            Else
                Me.txtCodigoAE.Text = ""
            End If

            'Fecha
            If Not ObjArqueodr.IsFieldNull("dFechaArqueo") Then
                Me.cdeFecha.Value = ObjArqueodr.dFechaArqueo
            Else
                Me.cdeFecha.Value = ""
            End If

            'Cajero
            If Not ObjArqueodr.IsFieldNull("nSrhCajeroId") Then
                CargarCajero(ObjArqueodr.nSrhCajeroId) ' Cargar en el cboCajero el nombre del Cajero Actual
                Me.cboCajero.Text = NombreCajero(ObjArqueodr.nSrhCajeroId)
                Me.cboCajero.Enabled = False
            Else
                Me.cboCajero.Text = ""
            End If

            'Estado Arqueo:
            ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjArqueodr.nStbEstadoArqueoID
            ObjEstadoDT.Retrieve()
            If ObjEstadoDT.Count > 0 Then
                Me.txtEstadoAE.Text = ObjEstadoDT.ValueField("sDescripcion")
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjEstadoDT.Close()
            ObjEstadoDT = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
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
                                " WHERE a.nSrhEmpleadoID = " & intCajeroID & " Order by a.nCodigo"
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

    ' -----------------------------------------------------------------------------------------------------------------------
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y devuelve True en caso de estar todo bien.
    '------------------------------------------------------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errArqueo.Clear()

            'Fecha de Arqueo:
            If (Me.cdeFecha.ValueIsDbNull) Then
                MsgBox("La Fecha de Arqueo NO DEBE quedar vacía.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFecha, "La Fecha de Arqueo NO DEBE quedar vacía.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Fecha Arqueo no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.cdeFecha.Value, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Arqueo NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFecha, "La Fecha de Arqueo NO DEBE ser menor a la de inicio del Programa.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            'Imposible si el periodo de la fecha de arqueo esta Cerrado:
            If PeriodoAbiertoDadaFecha(Me.cdeFecha.Value) = False Then
                MsgBox("La Fecha de Arqueo corresponde a un" & Chr(13) & "período contable cerrado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cdeFecha, "La Fecha de Arqueo corresponde a un período contable cerrado.")
                Me.cdeFecha.Focus()
                Exit Function
            End If

            nCodigoTalonario = IntCodigoTalonario(Format(Me.cdeFecha.Value, "yyyy-MM-dd"))

            'Cajero:
            If Me.cboCajero.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Cajero válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                Me.cboCajero.Focus()
                Exit Function
            End If

            If IntPermiteEditar = 0 Then
                ' Cajero no corresponde a su Delegación:
                If cboCajero.Columns("nStbDelegacionProgramaID").Value <> InfoSistema.IDDelegacion Then
                    MsgBox("Cajero no corresponde a su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errArqueo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                    Me.cboCajero.Focus()
                    Exit Function
                End If
            End If

            'Imposible si el Cajero no se encuentra Activo:
            If Me.cboCajero.Columns("nActivo").Value = 0 Then
                MsgBox("El Cajero no se encuentra Activo.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errArqueo.SetError(Me.cboCajero, "Debe seleccionar un Cajero válido.")
                Me.cboCajero.Focus()
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
    ' Procedure Name:       SalvarArqueo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Ficha en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarArqueo()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            strSQL = " EXEC spSteGrabarArqueo_Efectivo '" & Me.intArqueoID & "','" & CajaActual_Cajero(intCajero) & "','" & Me.cboCajero.Columns("nSrhEmpleadoID").Value & "','" & _
                        Format(Me.cdeFecha.Value, "yyyy-MM-dd") & "','" & Me.ModoForm & "'," & InfoSistema.IDCuenta & ""
            Me.intArqueoID = XcDatos.ExecuteScalar(strSQL)

            ' Buscar la ficha correspondiente al Id especificado como parámetro, en los casos que se esté editando una.
            ObjArqueodt.Filter = "nSteArqueoCajaID = " & Me.intArqueoID
            ObjArqueodt.Retrieve()

            If ObjArqueodt.Count = 0 Then Exit Sub
            ObjArqueodr = ObjArqueodt.Current

            'Si el salvado se realizó de forma satisfactoria enviar mensaje informando y cerrar el formulario.
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

#Region "Detalle Efectivo"
    ' ------------------------------------------------------------------------
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
                     " From vwSteArqueoDenominaciones_Recibo a " & _
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

            CalcularMontosBM()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
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
                      "WHERE (NOT (nSteDenominacionID IN (SELECT nSteDenominacionID FROM SteArqueo_ReciboAutomático_Denominación WHERE (nSteArqueoCajaID = " & Me.intArqueoID & "))))"
            If RegistrosAsociados(StrSqlV) = False Then
                MsgBox("No existen Denominaciones sin incorporar.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar registro:
            If MsgBox("¿Está seguro de incorporar Denominaciones " & Chr(13) & "al Arqueo?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                StrSql = " INSERT INTO SteArqueo_ReciboAutomático_Denominación (nSteArqueoCajaID, nSteDenominacionID, nCantidad, nUsuarioCreacionID, dFechaCreacion)" & _
                         " SELECT " & Me.intArqueoID & ", a.nSteDenominacionID, 0, " & InfoSistema.IDCuenta & ", getdate()" & _
                         " FROM (" & StrSqlV & ") a "
                XdtDenominacion.ExecuteSqlNotTable(StrSql)
                CargarEfectivo()
                FormatoEfectivo()
                MsgBox("Las Denominaciones se incorporaron satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdArqueoEfectivo.Caption = "Arqueo de Efectivo (" + Me.grdArqueoEfectivo.RowCount.ToString + " registros)"
            End If

            vbModifico = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDenominacion.Close()
            XdtDenominacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       LlamaModificarCantidadEfectivo
    ' Descripción:          Este procedimiento permite incluir la Cantidad
    '                       para una Denominación.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCantidadEfectivo()

        Dim Strsql As String
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XcDatosEf As New BOSistema.Win.XComando

        Dim XdtDE As New BOSistema.Win.SteEntArqueo.SteArqueo_ReciboAutomático_DenominaciónDataTable
        Dim XdrDE As New BOSistema.Win.SteEntArqueo.SteArqueo_ReciboAutomático_DenominaciónRow

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
            ObjFrmStbDatoComplemento.strColor = "Verde"
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
            Strsql = " Update SteArqueo_ReciboAutomático_Denominación " & _
                     " SET nUsuariomodificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nCantidad = " & strCantidad & _
                     " WHERE nSteArqueoDenominacionID = " & XdsDetalle("Efectivo").ValueField("nSteArqueoDenominacionID")
            XcDatos.ExecuteNonQuery(Strsql)

            'Guardar posición actual de la selección
            intPosicion = XdsDetalle("Efectivo").ValueField("nSteArqueoDenominacionID")
            CargarEfectivo()
            FormatoEfectivo()

            'Ubicar la selección en la posición original
            'Encuentra Valor actual de la denominación:
            Strsql = "SELECT SteDenominaciones.nValor " & _
                     "FROM SteArqueo_ReciboAutomático_Denominación INNER JOIN SteDenominaciones ON SteArqueo_ReciboAutomático_Denominación.nSteDenominacionID = SteDenominaciones.nSteDenominacionID " & _
                     "WHERE (SteArqueo_ReciboAutomático_Denominación.nSteArqueoDenominacionID = " & intPosicion & ")"
            nValor = XcDatosEf.ExecuteScalar(Strsql)

            'Encuentra Denominación siguiente:
            Strsql = "SELECT AD.nSteArqueoDenominacionID " & _
                     "FROM SteArqueo_ReciboAutomático_Denominación AS AD INNER JOIN SteDenominaciones AS D ON AD.nSteDenominacionID = D.nSteDenominacionID INNER JOIN " & _
                     "(SELECT  ISNULL(MAX(nValor), 0) AS mValor FROM (SELECT AD1.nSteArqueoDenominacionID, D1.nValor " & _
                     "FROM SteArqueo_ReciboAutomático_Denominación AS AD1 INNER JOIN SteDenominaciones AS D1 ON AD1.nSteDenominacionID = D1.nSteDenominacionID " & _
                     "WHERE (AD1.nSteArqueoCajaID = " & Me.intArqueoID & ") AND (D1.nValor < " & nValor & ")) AS b_1) AS b ON D.nValor = b.mValor WHERE (AD.nSteArqueoCajaID = " & Me.intArqueoID & ")"
            If XcDatosEf.ExecuteScalar(Strsql) = 0 Then
                IntIdDenominacion = intPosicion
            Else
                IntIdDenominacion = XcDatosEf.ExecuteScalar(Strsql)
            End If

            'Se ubica en la Denominación correspondiente:
            XdsDetalle("Efectivo").SetCurrentByID("nSteArqueoDenominacionID", IntIdDenominacion)
            Me.grdArqueoEfectivo.Row = XdsDetalle("Efectivo").BindingSource.Position

            vbModifico = False

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

    ' ------------------------------------------------------------------------
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

    Private Sub txtObservaciones_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtObservaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim ObjEstadoDT As New BOSistema.Win.StbEntCatalogo.StbValorCatalogoDataTable
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then
                'Guarda Encabezado:
                SalvarArqueo()
                'Habilita las siguientes Pestañas:
                Me.tabEfectivo.Enabled = True
                'Actualiza Etiqueta del Código del Arqueo:
                Me.txtCodigoAE.Text = ObjArqueodr.nCodigo
                'Actualiza Estado:
                ObjEstadoDT.Filter = " nStbValorCatalogoID = " & ObjArqueodr.nStbEstadoArqueoID
                ObjEstadoDT.Retrieve()
                If ObjEstadoDT.Count > 0 Then
                    Me.txtEstadoAE.Text = ObjEstadoDT.ValueField("sDescripcion")
                End If
                If Me.intArqueoID <> 0 Then
                    If MsgBox("¿Desea Continuar Ingresando Datos?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                        AccionUsuario = AccionBoton.BotonAceptar
                        Me.Close()
                    Else
                        ModoFrm = "UPD"
                        CargarEfectivo()
                        FormatoEfectivo()
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

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            'Declaracion de Variables 
            Dim res As Object
            Dim strSQL As String

            strSQL = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoCredito' "

            If (vbModifico = True) Then
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
                        ' Eliminar los registros del detalle
                        Dim ObjComando As BOSistema.Win.XDataSet.xDataTable
                        ObjComando = New BOSistema.Win.XDataSet.xDataTable
                        ObjComando.ExecuteSql("Delete from SteArqueo_ReciboAutomático_Denominación Where nSteArqueoCajaID='" & intArqueoID & "'")
                        vbModifico = False
                        Me.Close()
                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                vbModifico = False
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Private Sub cboCajero_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboCajero.TextChanged
        vbModifico = True
    End Sub

End Class