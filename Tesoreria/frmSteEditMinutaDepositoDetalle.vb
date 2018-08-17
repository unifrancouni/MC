Public Class frmSteEditMinutaDepositoDetalle
    Dim XdsMinutasDetalle As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjMinutaDepositodr As BOSistema.Win.SteEntTesoreria.SteMinutaDepositoRow
    Dim XdtPersonas As BOSistema.Win.XDataSet
    Public MinutasDetalles As List(Of MinutaDetalleDeposito)
    Dim Minuta As New MinutaDetalleDeposito

    Dim sColor As String
    Dim ModoForm As String
    Dim IdSteMinuta As Integer
    Dim IntHabilitar As Integer
    Dim intDptoId As Integer
    Dim nMontoMinuta As Double
    Dim dFechaMinuta As Date
    Dim IdCuentaBancaria As Integer
    Dim smodoMinuta As String
    Dim iMinutaDetalle As MinutaDetalleDeposito

    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
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

    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    Public Property nMontoMinutafrm() As Double
        Get
            nMontoMinutafrm = smodoMinuta
        End Get
        Set(ByVal value As Double)
            smodoMinuta = value
        End Set
    End Property

    Public Property dFechaMinutafrm() As Date
        Get
            dFechaMinutafrm = dFechaMinuta
        End Get
        Set(ByVal value As Date)
            dFechaMinuta = value
        End Set
    End Property

    Public Property nIdCuentafrm() As Integer
        Get
            nIdCuentafrm = IdCuentaBancaria
        End Get
        Set(ByVal value As Integer)
            IdCuentaBancaria = value
        End Set
    End Property

    Public Property nIdMinutafrm() As Integer
        Get
            nIdMinutafrm = IdSteMinuta
        End Get
        Set(ByVal value As Integer)
            IdSteMinuta = value
        End Set
    End Property

    Private Property ModoMinuta() As String
        Get
            ModoMinuta = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    Private Property ItemModificando() As MinutaDetalleDeposito
        Get
            ItemModificando = iMinutaDetalle
        End Get
        Set(ByVal value As MinutaDetalleDeposito)
            iMinutaDetalle = value
        End Set
    End Property

    Private Sub InicializaVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Detalle de Minuta Virtual"
            Else
                Me.Text = "Modificar Detalle de Minuta Virtual"
            End If
            '-- Inicializa DataSet:
            XdsMinutasDetalle = New BOSistema.Win.XDataSet

            XdtPersonas = New BOSistema.Win.XDataSet
            MinutasDetalles = New List(Of MinutaDetalleDeposito)
            Minuta = New MinutaDetalleDeposito
            '-- Limpiar Grid, estructura y Datos:
            Me.grdMinuta.ClearFields()
            Me.cboPersonaJuridica.ClearFields()
            Me.cneMonto.Focus()

            'If ModoFrm = "ADD" Then
            '    'Inicializar los Length de los campos
            '    Me.txtNoDeposito.MaxLength = ObjMinutaDepositodr.GetColumnLenght("sNumeroDeposito")
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSteEditMinutaDepositoDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.sColor)

            InicializaVariables()
            CargarPersona(0)
            CargarMinuta()
            If ModoFrm = "UPD" Then
                InhabilitarControles()
            Else
                Me.cboPersonaJuridica.Select()
            End If
            'vbModifico = False
            'AccionUsuario = AccionBoton.BotonCancelar
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub InhabilitarControles()
        Try
            'En caso de Inhabilitar:
            If IntHabilitar = 0 Then
                'Me.CmdAceptar.Enabled = False
                'Me.grpDatosGenerales.Enabled = False
            Else
                Me.cboPersonaJuridica.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarPersona(ByVal intPersonaID As Integer)
        Try
            Dim Strsql As String
            If intPersonaID = 0 Then

                Strsql = " SELECT B.nStbPersonaID, B.nCodigo, B.sNombre1 AS sNombreInstitucion " &
                     " From dbo.StbValorCatalogo AS A INNER Join" &
                     "  dbo.StbPersona As B On A.nStbValorCatalogoID = B.nStbTipoPersonaID LEFT OUTER Join" &
                     " dbo.SrhProveedor AS C ON B.nStbPersonaID = C.nStbPersonaID INNER Join" &
                     " dbo.StbCatalogo AS D ON A.nStbCatalogoID = D.nStbCatalogoID LEFT OUTER Join" &
                     " dbo.StbPersonaDatoFiscal AS E ON B.nStbPersonaID = E.nStbPersonaID" &
                     " Where(a.sCodigoInterno = 'J') AND (D.sNombre = 'TipoPersona') AND (B.nPersonaActiva = 1)"
            Else
                Strsql = " SELECT B.nStbPersonaID, B.nCodigo, B.sNombre1 AS sNombreInstitucion" &
                     " From dbo.StbValorCatalogo AS A INNER Join" &
                     "  dbo.StbPersona As B On A.nStbValorCatalogoID = B.nStbTipoPersonaID LEFT OUTER Join" &
                     " dbo.SrhProveedor AS C ON B.nStbPersonaID = C.nStbPersonaID INNER Join" &
                     " dbo.StbCatalogo AS D ON A.nStbCatalogoID = D.nStbCatalogoID LEFT OUTER Join" &
                     " dbo.StbPersonaDatoFiscal AS E ON B.nStbPersonaID = E.nStbPersonaID" &
                     " Where(a.sCodigoInterno = 'J') AND (D.sNombre = 'TipoPersona') AND (B.nPersonaActiva = 1) OR (B.nStbPersonaID= " & intPersonaID & ")"

            End If
            XdtPersonas.ExecuteSql(Strsql)


            If XdtPersonas.ExistTable("Persona") Then
                XdtPersonas("Persona").ExecuteSql(Strsql)
            Else
                XdtPersonas.NewTable(Strsql, "Persona")
                XdtPersonas("Persona").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboPersonaJuridica.DataSource = XdtPersonas("Persona").Source
            Me.cboPersonaJuridica.Rebind()

            'Ubicarse en el primer registro
            If XdtPersonas("Persona").Count > 0 Then
                '  XdtPersonas("Persona").SetCurrentByID("nStbPersonaID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboPersonaJuridica.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            'Me.cboPersonaJuridica.Splits(0).DisplayColumns("nPersonaActiva ").Visible = False

            Me.cboPersonaJuridica.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboPersonaJuridica.Splits(0).DisplayColumns("nCodigo").Width = 43
            Me.cboPersonaJuridica.Splits(0).DisplayColumns("sNombreInstitucion").Width = 100

            Me.cboPersonaJuridica.Columns("nCodigo").Caption = "Código"
            Me.cboPersonaJuridica.Columns("sNombreInstitucion").Caption = "Descripción"

            Me.cboPersonaJuridica.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboPersonaJuridica.Splits(0).DisplayColumns("sNombreInstitucion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub CargarMinuta()
        Dim i
        Dim MinutaDetalle As MinutaDetalleDeposito
        Try
            Dim Strsql As String
            Strsql = "Select    dbo.SteMinutaDepositoDetalle.nSteMinutaDepositoDetalleID,dbo.SteMinutaDepositoDetalle.sNumeroDeposito, dbo.SteMinutaDepositoDetalle.nMontoDeposito, dbo.SteMinutaDepositoDetalle.nStbPersonaJuridicaID " &
                     " FROM dbo.SteMinutaDeposito INNER JOIN  dbo.SteMinutaDepositoDetalle On dbo.SteMinutaDeposito.nSteMinutaDepositoID = dbo.SteMinutaDepositoDetalle.nSteMinutaDepositoID " &
                    " Where (dbo.SteMinutaDeposito.nSteMinutaDepositoID = " & nIdMinutafrm & ") And (dbo.SteMinutaDeposito.nVirtual = 1)"


            XdsMinutasDetalle.ExecuteSql(Strsql)


            If XdsMinutasDetalle.ExistTable("Minuta") Then
                XdsMinutasDetalle("Minuta").ExecuteSql(Strsql)
            Else
                XdsMinutasDetalle.NewTable(Strsql, "Minuta")
                XdsMinutasDetalle("Minuta").Retrieve()
            End If
            'Asignando a las fuentes de datos: 
            Me.grdMinuta.DataSource = XdsMinutasDetalle("Minuta").Source

            'Actualizando el caption de los GRIDS:
            Me.grdMinuta.Caption = " Listado de Minutas de Depósito (" + Me.grdMinuta.RowCount.ToString + " registros)"

            For i = 0 To XdsMinutasDetalle("Minuta").Table.Rows.Count - 1
                MinutaDetalle = New MinutaDetalleDeposito
                MinutaDetalle.IdMinuta = XdsMinutasDetalle("Minuta").Table.Rows(i).Item("nSteMinutaDepositoDetalleID")
                MinutaDetalle.nIDPersona = XdsMinutasDetalle("Minuta").Table.Rows(i).Item("nStbPersonaJuridicaID")
                MinutaDetalle.nMonto = XdsMinutasDetalle("Minuta").Table.Rows(i).Item("nMontoDeposito")
                MinutaDetalle.sNumeroDeposito = XdsMinutasDetalle("Minuta").Table.Rows(i).Item("sNumeroDeposito")
                MinutaDetalle.ModoMinuta = "UPD"
                MinutasDetalles.Add(MinutaDetalle)
            Next
            FormatoMinuta()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoMinuta()
        Try
            Me.grdMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoDetalleID").Visible = False
            Me.grdMinuta.Splits(0).DisplayColumns("nStbPersonaJuridicaID").Visible = False


            Me.grdMinuta.Splits(0).DisplayColumns("sNumeroDeposito").Width = 155

            Me.grdMinuta.Columns("sNumeroDeposito").Caption = "Número de Depósito"
            Me.grdMinuta.Columns("nMontoDeposito").Caption = "Monto Depósito C$"

            Me.grdMinuta.Columns("nMontoDeposito").NumberFormat = "#,##0.00"

            Me.grdMinuta.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMinuta.Splits(0).DisplayColumns("nMontoDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjCuenta As New BOSistema.Win.SteEntTesoreria.SteMinutaDepositoDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Dim MontoDetalleActual As Double = 0
        Dim i As Integer
        'Dim nStbPersonaID As Integer 'Id de la institucion bancaria
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            'Número Minuta: 
            If Trim(RTrim(Me.txtNoDeposito.Text)).ToString.Length = 0 Then
                MsgBox("El Número de la Minuta NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "El Nombre de la Minuta NO DEBE quedar vacío.")
                Me.txtNoDeposito.Focus()
                Exit Function
            End If
            strSQL = "SELECT  dbo.SteMinutaDeposito.nSteMinutaDepositoID FROM  dbo.SteMinutaDeposito INNER JOIN dbo.SteCuentaBancaria ON dbo.SteMinutaDeposito.nSteCuentaBancariaID = dbo.SteCuentaBancaria.nSteCuentaBancariaID "

            If ModoFrm = "UPD" Then
                strSQL = strSQL + " Where LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "' And nSteMinutaDepositoID <> " & nIdMinutafrm & "  And  dbo.SteMinutaDeposito.nSteCuentaBancariaID= " & nIdCuentafrm & "  And  dFechaDeposito= CONVERT(DATEtime,'" & Me.dFechaMinutafrm.Date & "',103)"
            Else
                strSQL = strSQL + " Where LTrim(RTrim(sNumeroDeposito)) = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "'" & "  And  dbo.SteMinutaDeposito.nSteCuentaBancariaID = " & nIdCuentafrm & "  And  dFechaDeposito= CONVERT(DATEtime,'" & Me.dFechaMinutafrm.Date & "',103)"
            End If

            If RegistrosAsociados(strSQL) Then
                MsgBox("Número de Minuta NO DEBE repetirse. Para el Banco y Fecha de Depósito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "Número de Minuta NO DEBE repetirse. Para el Banco y Fecha de Depósito.")
                Me.txtNoDeposito.Focus()
                Exit Function
            End If


            If MinutasDetalles.Count > 0 Then
                strSQL = "SELECT dbo.SteMinutaDepositoDetalle.sNumeroDeposito, dbo.SteMinutaDeposito.dFechaDeposito, dbo.SteMinutaDeposito.nSteCuentaBancariaID FROM dbo.SteMinutaDepositoDetalle INNER JOIN dbo.SteMinutaDeposito ON dbo.SteMinutaDepositoDetalle.nSteMinutaDepositoID = dbo.SteMinutaDeposito.nSteMinutaDepositoID"

                If ModoMinuta = "UPD" Then
                    strSQL = strSQL + " Where  (LTRIM(RTRIM(dbo.SteMinutaDepositoDetalle.sNumeroDeposito))  = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "') And dbo.SteMinutaDepositoDetalle.nSteMinutaDepositoDetalleID <> " & Me.ItemModificando.IdMinuta & "  And  dbo.SteMinutaDeposito.nSteCuentaBancariaID = " & nIdCuentafrm & "  And  dFechaDeposito= CONVERT(DATEtime,'" & Me.dFechaMinutafrm.Date & "',103)"
                Else
                    strSQL = strSQL + " Where  (LTRIM(RTRIM(dbo.SteMinutaDepositoDetalle.sNumeroDeposito))  = '" & LTrim(RTrim(Me.txtNoDeposito.Text)) & "') And  dbo.SteMinutaDeposito.nSteCuentaBancariaID = " & nIdCuentafrm & "  And  dFechaDeposito= CONVERT(DATEtime,'" & Me.dFechaMinutafrm.Date & "',103)"

                End If

                If RegistrosAsociados(strSQL) Then
                    MsgBox("Número de Minuta NO DEBE repetirse. Para el Banco y Fecha de Depósito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errMinuta.SetError(Me.txtNoDeposito, "Número de Minuta NO DEBE repetirse. Para el Banco y Fecha de Depósito.")
                    Me.txtNoDeposito.Focus()
                    Exit Function
                End If
            End If

            'Fecha Depósito no menor que la fecha de inicio del Programa:
            If BlnFechaInferiorParametros(Format(Me.dFechaMinutafrm, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Depósito NO DEBE ser menor" & Chr(13) & "que la fecha de inicio del Programa.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Fecha Depósito no mayor que la fecha de corte en parámetros:
            If BlnFechaSuperiorParametros(Format(Me.dFechaMinutafrm, "yyyy-MM-dd")) Then
                MsgBox("La Fecha de Depósito NO DEBE ser mayor que" & Chr(13) & "la fecha de corte indicada en parámetros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Exit Function
            End If

            'If ModoMinuta = "UPD" Then
            For i = 0 To MinutasDetalles.Count() - 1
                    If Not MinutasDetalles(i).IdMinuta.Equals(ItemModificando.IdMinuta) Then
                        MontoDetalleActual = MontoDetalleActual + MinutasDetalles(i).nMonto
                    End If

                Next
            'End If
            If Me.nMontoMinutafrm - MontoDetalleActual - cneMonto.Value < 0 Then
                MsgBox("Monto Depósitado Inválido. Sobrepasa el valor total de la minuta.", MsgBoxStyle.Critical, NombreSistema)
                Me.errMinuta.SetError(Me.cneMonto, "Monto Depósitado Inválido.")
                Me.cneMonto.Focus()
                ValidaDatosEntrada = False
                Exit Function
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

    Private Function ValidaCamposEntrada() As Boolean

        Try
            ValidaCamposEntrada = True
            'Número Minuta: 
            If Trim(RTrim(Me.txtNoDeposito.Text)).ToString.Length = 0 Then
                MsgBox("El Número de la Minuta NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaCamposEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "El Nombre de la Minuta NO DEBE quedar vacío.")
                Me.txtNoDeposito.Focus()
                Exit Function
            End If

            If Not IsNumeric(cneMonto.Value) Then
                MsgBox("Monto Depósitado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errMinuta.SetError(Me.cneMonto, "Monto Depósitado Inválido.")
                Me.cneMonto.Focus()
                ValidaCamposEntrada = False
                Exit Function
            End If
            If CDbl(cneMonto.Value) = 0 Then
                MsgBox("Monto Depósitado Inválido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errMinuta.SetError(Me.cneMonto, "Monto Depósitado Inválido.")
                Me.cneMonto.Focus()
                ValidaCamposEntrada = False
                Exit Function
            End If

            If Me.cboPersonaJuridica.SelectedIndex < 0 Then
                MsgBox("Debe seleccionar el lugar donde se realizó el depósito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaCamposEntrada = False
                Me.errMinuta.SetError(Me.txtNoDeposito, "Debe seleccionar el lugar donde se realiz[o el depósito.")
                Me.cboPersonaJuridica.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaCamposEntrada = False
            Control_Error(ex)
        End Try
    End Function


    Private Sub tbMinuta_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbMinuta.ItemClicked
        Me.grdMinuta.Enabled = False
        Me.tbMinuta.Enabled = False
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                Me.ModoMinuta = "ADD"
                LlamaAgregarMinutaDetalle()
            Case "toolModificar"
                Me.ModoMinuta = "UPD"
                LlamaModificarMinutaDetalle()
            Case "toolEliminar"
                LlamaEliminarMinutaDetalle()
        End Select
    End Sub

    Private Sub LlamaAgregarMinutaDetalle()
        Try
            If ValidaCamposEntrada() Then
                Minuta.IdMinuta = 0
                Minuta.nMonto = cneMonto.Value
                Minuta.sNumeroDeposito = LTrim(RTrim(Me.txtNoDeposito.Text))
                Minuta.nIDPersona = XdtPersonas("Persona").ValueField("nStbPersonaID")
                Minuta.ModoMinuta = "ADD"
                Me.MinutasDetalles.Add(Minuta)
                Me.ItemModificando = Minuta
                If ValidaDatosEntrada() Then
                    AgregarMinutaDeposito()
                Else
                    Me.MinutasDetalles.Remove(Minuta)
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    Private Sub LlamaModificarMinutaDetalle()
        Try
            Me.txtNoDeposito.Text = XdsMinutasDetalle("Minuta").ValueField("sNumeroDeposito")
            cneMonto.Value = XdsMinutasDetalle("Minuta").ValueField("nMontoDeposito")

            If XdsMinutasDetalle("Minuta").ValueField("nStbPersonaJuridicaID") > 0 Then
                CargarPersona(XdsMinutasDetalle("Minuta").ValueField("nStbPersonaJuridicaID"))
            Else
                Me.cboPersonaJuridica.Text = ""
                Me.cboPersonaJuridica.SelectedIndex = -1
            End If


            Dim index As Integer = XdsMinutasDetalle("Minuta").Table.Rows.IndexOf(XdsMinutasDetalle("Minuta").Current)
            Me.ItemModificando = MinutasDetalles.Item(index)

            If Me.cboPersonaJuridica.ListCount > 0 Then
                Me.cboPersonaJuridica.SelectedIndex = 0
            End If
            XdtPersonas("Persona").SetCurrentByID("nStbPersonaID", ItemModificando.nIDPersona)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaEliminarMinutaDetalle()
        'XdsMinutasDetalle("Minuta").
    End Sub

    Private Sub AgregarMinutaDeposito()
        Try
            XdsMinutasDetalle("Minuta").AddRow()
            XdsMinutasDetalle("Minuta")("nSteMinutaDepositoDetalleID") = Minuta.IdMinuta
            XdsMinutasDetalle("Minuta")("nStbPersonaJuridicaID") = Minuta.nIDPersona
            XdsMinutasDetalle("Minuta")("sNumeroDeposito") = Minuta.sNumeroDeposito
            XdsMinutasDetalle("Minuta")("nMontoDeposito") = Minuta.nMonto
            XdsMinutasDetalle("Minuta").UpdateLocal()



            cneMonto.Clear()
            txtNoDeposito.Clear()
            cboPersonaJuridica.SelectedIndex = 0

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub ModificarMinutaDeposito()
        Try
            If ValidaDatosEntrada() Then
                Dim Minuta As New MinutaDetalleDeposito
                Minuta.IdMinuta = Me.ItemModificando.IdMinuta
                Minuta.nMonto = cneMonto.Value
                Minuta.sNumeroDeposito = LTrim(RTrim(Me.txtNoDeposito.Text))
                Minuta.nIDPersona = XdtPersonas("Persona").ValueField("nStbPersonaID")
                Minuta.ModoMinuta = "UPD"
                MinutasDetalles.Remove(ItemModificando)
                MinutasDetalles.Add(Minuta)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        Try
            If Me.ModoMinuta = "UPD" Then
                ModificarMinutaDeposito()
            End If
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class