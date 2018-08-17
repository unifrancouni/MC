Public Class frmSclEditInformacionFinanciera

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim intSclFichaID As Integer
    Dim intSclGarantiaFiduciariaID As Integer

    Dim intSclReferenciaCrediticiaID As Integer
    Dim intSclReferenciaBancariaID As Integer

    Dim intStbPersonaReferenciaID As Integer

    Dim intTipoPersona As Integer
    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjGarantiaFiduciariadt As BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaDataTable
    Dim ObjGarantiaFiduciariadr As BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton = AccionBoton.BotonNinguno
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos del Comprobante.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el tipo de Persona. El del Credito o el Fiador.
    '1-Es el del credito ,2  es el Fiador.
    Public Property intSclTipoPersona() As Integer
        Get
            intSclTipoPersona = intTipoPersona
        End Get
        Set(ByVal value As Integer)
            intTipoPersona = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Ficha que corresponde al campo
    'nSclFichaSociaID de la tabla SclFichaSocia.
    Public Property intFichaID() As Integer
        Get
            intFichaID = intSclFichaID
        End Get
        Set(ByVal value As Integer)
            intSclFichaID = value
        End Set
    End Property

    Public Property intReferenciaCrediticiaID() As Integer
        Get
            intReferenciaCrediticiaID = intSclReferenciaCrediticiaID
        End Get
        Set(ByVal value As Integer)
            intSclReferenciaCrediticiaID = value
        End Set
    End Property




    Public Property intReferenciaBancariaID() As Integer
        Get
            intReferenciaBancariaID = intSclReferenciaBancariaID
        End Get
        Set(ByVal value As Integer)
            intSclReferenciaBancariaID = value
        End Set
    End Property



    Public Property intPersonalID() As Integer
        Get
            intPersonalID = intStbPersonaReferenciaID
        End Get
        Set(ByVal value As Integer)
            intStbPersonaReferenciaID = value
        End Set
    End Property







    'Propiedad utilizada para obtener el ID del otro crédito que corresponde al campo
    'SclOtroCreditoVigenteID de la tabla SclOtroCreditoVigente.
    Public Property intGarantiaFiduciariaID() As Integer
        Get
            intGarantiaFiduciariaID = intSclGarantiaFiduciariaID
        End Get
        Set(ByVal value As Integer)
            intSclGarantiaFiduciariaID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditGarantiaFiduciaria_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditGarantiaFiduciaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Try
        '    If AccionUsuario <> AccionBoton.BotonNinguno Then

        '        XdsFicha.Close()
        '        XdsFicha = Nothing

        '        ObjGarantiaFiduciariadt.Close()
        '        ObjGarantiaFiduciariadt = Nothing

        '        'ObjOtroCreditodr.Close()
        '        ObjGarantiaFiduciariadr = Nothing
        '    Else
        '        e.Cancel = True
        '        'Regresar la accion del Usuario al estado Inicial
        '        AccionUsuario = AccionBoton.BotonCancelar
        '    End If
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub

    Private Sub frmSclGarantiaFiduciaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()






            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            'If ModoFrm = "UPD" Then

            CargarDatos()

            'Else


            'CargarTipoMoneda(0)
            'End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                If intTipoPersona = 1 Then
                    Me.Text = "Agregar Referencia Bancaria al Credito"
                Else
                    Me.Text = "Agregar Referencia Bancaria al Fiador"
                End If

            Else
                If intTipoPersona = 1 Then
                    Me.Text = "Modificar Referencia Bancaria al Credito"
                Else
                    Me.Text = "Modificar Referencia Bancaria al Fiador"
                End If
            End If

            ObjGarantiaFiduciariadt = New BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaDataTable
            ObjGarantiaFiduciariadr = New BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaRow

            'Obtener los Datos de los combos
            XdsFicha = New BOSistema.Win.XDataSet




   



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub CargarTipoMoneda(ByVal intMonedaID As Integer)
        Try
            Dim Strsql As String = ""

            If intMonedaID = 0 Then
                Strsql = " Select a.nStbMonedaID,a.sCodigoInterno,a.sDescripcion,a.sSimbolo " & _
                         " From StbMoneda a " & _
                         " WHERE a.nActivo = 1 " & _
                         " Order by a.sCodigoInterno "
            Else
                Strsql = " Select a.nStbMonedaID,a.sCodigoInterno,a.sDescripcion,a.sSimbolo " & _
                         " From StbMoneda a " & _
                         " WHERE a.nActivo = 1 or a.nStbMonedaID = " & intMonedaID & _
                         " Order by a.sCodigoInterno "
            End If

            If XdsFicha.ExistTable("TipoMoneda") Then
                XdsFicha("TipoMoneda").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoMoneda")
                XdsFicha("TipoMoneda").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoMoneda.DataSource = XdsFicha("TipoMoneda").Source

            Me.cboTipoMoneda.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            Me.cboTipoMoneda.Splits(0).DisplayColumns("sSimbolo").Visible = False

            Me.cboTipoMoneda.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoMoneda.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoMoneda.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoMoneda.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoMoneda.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoMoneda.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoMoneda.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    
    Private Sub CargarDatos()
        Dim ObjFiadorDT As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Otro Crédito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.


            If intTipoPersona = 1 Then 'Credito


                strSQL = "SELECT     nSclFichaInformacionFinancieraID, nSclFichaSociaID, dFechaCorte, nStbMonedaID, nEfectivo, nBancos, nCuentasPorCobrar, nInventarios, " & _
                         "nOtrosCirculantes, nBienesInmuebles, nMaqEquipoRodante, nBienesMuebles, nOtrosFijos,nOtrosActivos, nProveedores, nCuentasPorPagarCortoPlazo, " & _
                         "nPrestamosPorPagarCortoPlazo, nImpuestosPorPagar, nOtrasCuentasCortoPlazo, nPtmosPorPagarLargoPlazo, nOtrosPasivosLargoPlazo, " & _
                         "nPatrimonio, nIngresosActividadEconomica, nAlquiler, nOtrosIngresos, nCostosProduccionComercio, nGastosOperativos, nAmortizacionDeuda, " & _
                         "  nProvisionMantenimientoReinversion, nAlquileresRentas, nImpuestosSeguros, nGastosFamiliares, nOtrosGastos " & _
                         " FROM dbo.SclFichaInformacionFinanciera Where nSclFichaSociaID=" & Me.intFichaID

            Else ' Fiador


                strSQL = "SELECT     nSclFichaInformacionFinancieraFiadorID, nSclGarantiaFiduciariaID, dFechaCorte, nStbMonedaID, nEfectivo, nBancos, nCuentasPorCobrar, nInventarios, " & _
         "nOtrosCirculantes, nBienesInmuebles, nMaqEquipoRodante, nBienesMuebles, nOtrosFijos, nOtrosActivos,nProveedores, nCuentasPorPagarCortoPlazo, " & _
         "nPrestamosPorPagarCortoPlazo, nImpuestosPorPagar, nOtrasCuentasCortoPlazo, nPtmosPorPagarLargoPlazo, nOtrosPasivosLargoPlazo, " & _
         "nPatrimonio, nIngresosActividadEconomica, nAlquiler, nOtrosIngresos, nCostosProduccionComercio, nGastosOperativos, nAmortizacionDeuda, " & _
         "  nProvisionMantenimientoReinversion, nAlquileresRentas, nImpuestosSeguros, nGastosFamiliares, nOtrosGastos " & _
         " FROM dbo.SclFichaInformacionFinancieraFiador Where nSclGarantiaFiduciariaID=" & Me.intReferenciaCrediticiaID

            End If


            RegTmp.ExecuteSql(strSQL)
            If RegTmp.Count > 0 Then


                ModoFrm = "UPD"

                If Not IsDBNull(RegTmp.ValueField("dFechaCorte")) Then
                    Me.cdeFechaCorte.Value = RegTmp.ValueField("dFechaCorte")
                Else
                    Me.cdeFechaCorte.Value = Me.cdeFechaCorte.ValueIsDbNull
                End If






                'Moneda
                If Not IsDBNull(RegTmp.ValueField("nStbMonedaID")) Then

                    CargarTipoMoneda(RegTmp.ValueField("nStbMonedaID"))
                    If Me.cboTipoMoneda.ListCount > 0 Then
                        Me.cboTipoMoneda.SelectedIndex = 0
                    End If

                    XdsFicha("TipoMoneda").SetCurrentByID("nStbMonedaID", RegTmp.ValueField("nStbMonedaID"))
                    'Me.cboFiador.Enabled = False
                Else
                    Me.cboTipoMoneda.Text = ""
                    Me.cboTipoMoneda.SelectedIndex = -1
                End If





                If Not IsDBNull(RegTmp.ValueField("nEfectivo")) Then
                    Me.nEfectivo.Text = RegTmp.ValueField("nEfectivo")
                Else
                    Me.nEfectivo.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nBancos")) Then
                    Me.nBancos.Text = RegTmp.ValueField("nBancos")
                Else
                    Me.nBancos.Text = ""
                End If
                If Not IsDBNull(RegTmp.ValueField("nCuentasPorCobrar")) Then
                    Me.nCuentasPorCobrar.Text = RegTmp.ValueField("nCuentasPorCobrar")
                Else
                    Me.nCuentasPorCobrar.Text = ""
                End If
                If Not IsDBNull(RegTmp.ValueField("nInventarios")) Then
                    Me.nInventarios.Text = RegTmp.ValueField("nInventarios")
                Else
                    Me.nInventarios.Text = ""
                End If
                If Not IsDBNull(RegTmp.ValueField("nOtrosCirculantes")) Then
                    Me.nOtrosCirculantes.Text = RegTmp.ValueField("nOtrosCirculantes")
                Else
                    Me.nOtrosCirculantes.Text = ""
                End If




                If Not IsDBNull(RegTmp.ValueField("nBienesInmuebles")) Then
                    Me.nBienesInmuebles.Text = RegTmp.ValueField("nBienesInmuebles")
                Else
                    Me.nBienesInmuebles.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nMaqEquipoRodante")) Then
                    Me.nMaqEquipoRodante.Text = RegTmp.ValueField("nMaqEquipoRodante")
                Else
                    Me.nMaqEquipoRodante.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nBienesMuebles")) Then
                    Me.nBienesMuebles.Text = RegTmp.ValueField("nBienesMuebles")
                Else
                    Me.nBienesMuebles.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nOtrosFijos")) Then
                    Me.nOtrosFijos.Text = RegTmp.ValueField("nOtrosFijos")
                Else
                    Me.nOtrosFijos.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nOtrosActivos")) Then
                    Me.nOtrosActivos.Text = RegTmp.ValueField("nOtrosActivos")
                Else
                    Me.nOtrosActivos.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nProveedores")) Then
                    Me.nProveedores.Text = RegTmp.ValueField("nProveedores")
                Else
                    Me.nProveedores.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nCuentasPorPagarCortoPlazo")) Then
                    Me.nCuentasPorPagarCortoPlazo.Text = RegTmp.ValueField("nCuentasPorPagarCortoPlazo")
                Else
                    Me.nCuentasPorPagarCortoPlazo.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nPrestamosPorPagarCortoPlazo")) Then
                    Me.nPrestamosPorPagarCortoPlazo.Text = RegTmp.ValueField("nPrestamosPorPagarCortoPlazo")
                Else
                    Me.nPrestamosPorPagarCortoPlazo.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nImpuestosPorPagar")) Then
                    Me.nImpuestosPorPagar.Text = RegTmp.ValueField("nImpuestosPorPagar")
                Else
                    Me.nImpuestosPorPagar.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nOtrasCuentasCortoPlazo")) Then
                    Me.nOtrasCuentasCortoPlazo.Text = RegTmp.ValueField("nOtrasCuentasCortoPlazo")
                Else
                    Me.nOtrasCuentasCortoPlazo.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nPtmosPorPagarLargoPlazo")) Then
                    Me.nPtmosPorPagarLargoPlazo.Text = RegTmp.ValueField("nPtmosPorPagarLargoPlazo")
                Else
                    Me.nPtmosPorPagarLargoPlazo.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nOtrosPasivosLargoPlazo")) Then
                    Me.nOtrosPasivosLargoPlazo.Text = RegTmp.ValueField("nOtrosPasivosLargoPlazo")
                Else
                    Me.nOtrosPasivosLargoPlazo.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nPatrimonio")) Then
                    Me.nPatrimonio.Text = RegTmp.ValueField("nPatrimonio")
                Else
                    Me.nPatrimonio.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nIngresosActividadEconomica")) Then
                    Me.nIngresosActividadEconomica.Text = RegTmp.ValueField("nIngresosActividadEconomica")
                Else
                    Me.nIngresosActividadEconomica.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nAlquiler")) Then
                    Me.nAlquiler.Text = RegTmp.ValueField("nAlquiler")
                Else
                    Me.nAlquiler.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nOtrosIngresos")) Then
                    Me.nOtrosIngresos.Text = RegTmp.ValueField("nOtrosIngresos")
                Else
                    Me.nOtrosIngresos.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nCostosProduccionComercio")) Then
                    Me.nCostosProduccionComercio.Text = RegTmp.ValueField("nCostosProduccionComercio")
                Else
                    Me.nCostosProduccionComercio.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nGastosOperativos")) Then
                    Me.nGastosOperativos.Text = RegTmp.ValueField("nGastosOperativos")
                Else
                    Me.nGastosOperativos.Text = ""
                End If


                If Not IsDBNull(RegTmp.ValueField("nAmortizacionDeuda")) Then
                    Me.nAmortizacionDeuda.Text = RegTmp.ValueField("nAmortizacionDeuda")
                Else
                    Me.nAmortizacionDeuda.Text = ""
                End If


                If Not IsDBNull(RegTmp.ValueField("nProvisionMantenimientoReinversion")) Then
                    Me.nProvisionMantenimientoReinversion.Text = RegTmp.ValueField("nProvisionMantenimientoReinversion")
                Else
                    Me.nProvisionMantenimientoReinversion.Text = "nProvisionMantenimientoReinversion"
                End If

                If Not IsDBNull(RegTmp.ValueField("nAlquileresRentas")) Then
                    Me.nAlquileresRentas.Text = RegTmp.ValueField("nAlquileresRentas")
                Else
                    Me.nAlquileresRentas.Text = ""
                End If


                If Not IsDBNull(RegTmp.ValueField("nImpuestosSeguros")) Then
                    Me.nImpuestosSeguros.Text = RegTmp.ValueField("nImpuestosSeguros")
                Else
                    Me.nImpuestosSeguros.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nGastosFamiliares")) Then
                    Me.nGastosFamiliares.Text = RegTmp.ValueField("nGastosFamiliares")
                Else
                    Me.nGastosFamiliares.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("nOtrosGastos")) Then
                    Me.nOtrosGastos.Text = RegTmp.ValueField("nOtrosGastos")
                Else
                    Me.nOtrosGastos.Text = ""
                End If

            Else
                CargarTipoMoneda(0)


            End If


            If ModoFrm = "ADD" Then
                If intTipoPersona = 1 Then
                    Me.Text = "Agregar Información Financiera Anual al Credito"
                Else
                    Me.Text = "Agregar Información Financiera Anual al Fiador"
                End If

            Else
                If intTipoPersona = 1 Then
                    Me.Text = "Modificar Información Financiera Anual al Credito"
                Else
                    Me.Text = "Modificar Información Financiera Anual al Fiador"
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFiadorDT.Close()
            ObjFiadorDT = Nothing
        End Try
    End Sub





    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarReferencia()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidaDatosEntrada() As Boolean
        Try
            ValidaDatosEntrada = True
            Me.errGarantiaFiduciaria.Clear()


            'Fecha de Cancelación
            If Me.cdeFechaCorte.ValueIsDbNull Then
                MsgBox("La Fecha de Corte NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cdeFechaCorte, "La Fecha de Corte NO DEBE quedar vacía.")
                Me.cdeFechaCorte.Focus()
                Exit Function
            End If


 

            If Me.cboTipoMoneda.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un tipo de moneda válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboTipoMoneda, "Debe seleccionar un tipo de moneda válido.")
                Me.cboTipoMoneda.Focus()
                Exit Function
            End If





            'If Trim(RTrim(Me.cneMontoPromedio.Text)).ToString.Length = 0 Then
            '    MsgBox("Monto Promedio no debe quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errGarantiaFiduciaria.SetError(Me.cneMontoPromedio, "Monto Promedio no debe quedar vacío")
            '    Me.cneMontoPromedio.Focus()
            '    Exit Function
            'End If

            If IsDBNull(Me.nEfectivo.Value) Then
                MsgBox("Monto Efectivo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nEfectivo, "Monto Efectivo  no puede ser menor que cero.")
                Me.nEfectivo.Focus()
                Exit Function
            End If

            If Me.nEfectivo.Value < 0 Then
                MsgBox("Monto Efectivo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nEfectivo, "Monto Efectivo  no puede ser menor que cero.")
                Me.nEfectivo.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nBancos.Value) Then
                MsgBox("Monto Bancos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nBancos, "Monto Bancos  no puede ser menor que cero.")
                Me.nBancos.Focus()
                Exit Function
            End If

            If Me.nBancos.Value < 0 Then
                MsgBox("Monto Bancos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nBancos, "Monto Bancos  no puede ser menor que cero.")
                Me.nBancos.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nCuentasPorCobrar.Value) Then
                MsgBox("Monto Cuentas Por Cobrar no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nCuentasPorCobrar, "Monto Cuentas por Cobrar  no puede ser menor que cero.")
                Me.nCuentasPorCobrar.Focus()
                Exit Function
            End If

            If Me.nCuentasPorCobrar.Value < 0 Then
                MsgBox("Monto Cuentas Por Cobrar no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nCuentasPorCobrar, "Monto Cuentas por Cobrar  no puede ser menor que cero.")
                Me.nCuentasPorCobrar.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nInventarios.Value) Then
                MsgBox("Monto Inventario no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nInventarios, "Monto Inventario no puede ser menor que cero.")
                Me.nInventarios.Focus()
                Exit Function
            End If

            If Me.nInventarios.Value < 0 Then
                MsgBox("Monto Inventario no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nInventarios, "Monto Inventario no puede ser menor que cero.")
                Me.nInventarios.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nOtrosCirculantes.Value) Then
                MsgBox("Monto Otros Circulantes no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosCirculantes, "Monto Otros Circulantes no  puede ser menor que cero.")
                Me.nOtrosCirculantes.Focus()
                Exit Function
            End If
            If Me.nOtrosCirculantes.Value < 0 Then
                MsgBox("Monto Otros Circulantes no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosCirculantes, "Monto Otros Circulantes no  puede ser menor que cero.")
                Me.nOtrosCirculantes.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nBienesInmuebles.Value) Then
                MsgBox("Monto Bienes Inmuebles no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nBienesInmuebles, "Monto Bienes Inmuebles  no puede ser menor que cero.")
                Me.nBienesInmuebles.Focus()
                Exit Function
            End If

            If Me.nBienesInmuebles.Value < 0 Then
                MsgBox("Monto Bienes Inmuebles no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nBienesInmuebles, "Monto Bienes Inmuebles  no puede ser menor que cero.")
                Me.nBienesInmuebles.Focus()
                Exit Function
            End If



            If IsDBNull(Me.nMaqEquipoRodante.Value) Then
                MsgBox("Monto Maquinaria Equipo Rodante no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nMaqEquipoRodante, "Monto Maquinaria Equipo Rodante no puede ser menor que cero.")
                Me.nMaqEquipoRodante.Focus()
                Exit Function
            End If
            If Me.nMaqEquipoRodante.Value < 0 Then
                MsgBox("Monto Maquinaria Equipo Rodante no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nMaqEquipoRodante, "Monto Maquinaria Equipo Rodante no puede ser menor que cero.")
                Me.nMaqEquipoRodante.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nBienesMuebles.Value) Then
                MsgBox("Monto Bienes Muebles no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nBienesMuebles, "Monto Bienes Muebles no puede ser menor que cero.")
                Me.nBienesMuebles.Focus()
                Exit Function
            End If

            If Me.nBienesMuebles.Value < 0 Then
                MsgBox("Monto Bienes Muebles no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nBienesMuebles, "Monto Bienes Muebles no puede ser menor que cero.")
                Me.nBienesMuebles.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nOtrosFijos.Value) Then
                MsgBox("Monto Otros Fijos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosFijos, "Monto Otros Fijos no puede ser menor que cero.")
                Me.nOtrosFijos.Focus()
                Exit Function
            End If

            If Me.nOtrosFijos.Value < 0 Then
                MsgBox("Monto Otros Fijos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosFijos, "Monto Otros Fijos no puede ser menor que cero.")
                Me.nOtrosFijos.Focus()
                Exit Function
            End If



            If IsDBNull(Me.nOtrosActivos.Value) Then
                MsgBox("Monto Otros Activos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosActivos, "Monto Otros Activos no puede ser menor que cero.")
                Me.nOtrosActivos.Focus()
                Exit Function
            End If

            If Me.nOtrosActivos.Value < 0 Then
                MsgBox("Monto Otros Activos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosActivos, "Monto Otros Activos no puede ser menor que cero.")
                Me.nOtrosActivos.Focus()
                Exit Function
            End If


            If IsDBNull(Me.nProveedores.Value) Then
                MsgBox("Monto Proveedores no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nProveedores, "Monto Proveedores  no puede ser menor que cero.")
                Me.nProveedores.Focus()
                Exit Function
            End If


            If Me.nProveedores.Value < 0 Then
                MsgBox("Monto Proveedores no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nProveedores, "Monto Proveedores  no puede ser menor que cero.")
                Me.nProveedores.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nCuentasPorPagarCortoPlazo.Value) Then
                MsgBox("Monto Cuentas por Pagar Corto Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nCuentasPorPagarCortoPlazo, "Monto Cuentas por Pagar Corto Plazo  no puede ser menor que cero.")
                Me.nCuentasPorPagarCortoPlazo.Focus()
                Exit Function
            End If

            If Me.nCuentasPorPagarCortoPlazo.Value < 0 Then
                MsgBox("Monto Cuentas por Pagar Corto Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nCuentasPorPagarCortoPlazo, "Monto Cuentas por Pagar Corto Plazo  no puede ser menor que cero.")
                Me.nCuentasPorPagarCortoPlazo.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nPrestamosPorPagarCortoPlazo.Value) Then
                MsgBox("Monto Prestamos por Pagar Corto Plazo  no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nPrestamosPorPagarCortoPlazo, "Monto Prestamos por Pagar Corto Plazo  no puede ser menor que cero.")
                Me.nPrestamosPorPagarCortoPlazo.Focus()
                Exit Function
            End If

            If Me.nPrestamosPorPagarCortoPlazo.Value < 0 Then
                MsgBox("Monto Prestamos por Pagar Corto Plazo  no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nPrestamosPorPagarCortoPlazo, "Monto Prestamos por Pagar Corto Plazo  no puede ser menor que cero.")
                Me.nPrestamosPorPagarCortoPlazo.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nImpuestosPorPagar.Value) Then
                MsgBox("Monto Impuesto por Pagar no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nImpuestosPorPagar, "Monto Impuesto por Pagar  no puede ser menor que cero.")
                Me.nImpuestosPorPagar.Focus()
                Exit Function
            End If
            If Me.nImpuestosPorPagar.Value < 0 Then
                MsgBox("Monto Impuesto por Pagar no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nImpuestosPorPagar, "Monto Impuesto por Pagar  no puede ser menor que cero.")
                Me.nImpuestosPorPagar.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nOtrasCuentasCortoPlazo.Value) Then
                MsgBox("Monto Otras Cuentas Corto Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrasCuentasCortoPlazo, "Monto Otras Cuentas Corto Plazo no puede ser menor que cero.")
                Me.nOtrasCuentasCortoPlazo.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nOtrasCuentasCortoPlazo.Value) Then
                MsgBox("Monto Otras Cuentas Corto Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrasCuentasCortoPlazo, "Monto Otras Cuentas Corto Plazo no puede ser menor que cero.")
                Me.nOtrasCuentasCortoPlazo.Focus()
                Exit Function
            End If

            If Me.nOtrasCuentasCortoPlazo.Value < 0 Then
                MsgBox("Monto Otras Cuentas Corto Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrasCuentasCortoPlazo, "Monto Otras Cuentas Corto Plazo no puede ser menor que cero.")
                Me.nOtrasCuentasCortoPlazo.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nPtmosPorPagarLargoPlazo.Value) Then
                MsgBox("Monto Prestamos Por Pagar a Largo Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nPtmosPorPagarLargoPlazo, "Monto Prestamos Por Pagar a Largo Plazo no puede ser menor que cero.")
                Me.nPtmosPorPagarLargoPlazo.Focus()
                Exit Function
            End If


            If Me.nPtmosPorPagarLargoPlazo.Value < 0 Then
                MsgBox("Monto Prestamos Por Pagar a Largo Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nPtmosPorPagarLargoPlazo, "Monto Prestamos Por Pagar a Largo Plazo no puede ser menor que cero.")
                Me.nPtmosPorPagarLargoPlazo.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nOtrosPasivosLargoPlazo.Value) Then
                MsgBox("Monto Otros Pasivos a Largo Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosPasivosLargoPlazo, "Monto Otros Pasivos a Largo Plazo no puede ser menor que cero.")
                Me.nOtrosPasivosLargoPlazo.Focus()
                Exit Function
            End If
            If Me.nOtrosPasivosLargoPlazo.Value < 0 Then
                MsgBox("Monto Otros Pasivos a Largo Plazo no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosPasivosLargoPlazo, "Monto Otros Pasivos a Largo Plazo no puede ser menor que cero.")
                Me.nOtrosPasivosLargoPlazo.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nPatrimonio.Value) Then
                MsgBox("Monto Patrimonio no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nPatrimonio, "Monto Patrimonio no puede ser menor que cero.")
                Me.nPatrimonio.Focus()
                Exit Function
            End If
            If Me.nPatrimonio.Value < 0 Then
                MsgBox("Monto Patrimonio no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nPatrimonio, "Monto Patrimonio no puede ser menor que cero.")
                Me.nPatrimonio.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nIngresosActividadEconomica.Value) Then
                MsgBox("Monto Ingresos Actividad Economica no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nIngresosActividadEconomica, "Monto Ingresos Actividad Economica  no puede ser menor que cero.")
                Me.nIngresosActividadEconomica.Focus()
                Exit Function
            End If
            If Me.nIngresosActividadEconomica.Value < 0 Then
                MsgBox("Monto Ingresos Actividad Economica no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nIngresosActividadEconomica, "Monto Ingresos Actividad Economica  no puede ser menor que cero.")
                Me.nIngresosActividadEconomica.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nAlquiler.Value) Then
                MsgBox("Monto Alquiler no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nAlquiler, "Monto Alquiler  no puede ser menor que cero.")
                Me.nAlquiler.Focus()
                Exit Function
            End If
            If Me.nAlquiler.Value < 0 Then
                MsgBox("Monto Alquiler no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nAlquiler, "Monto Alquiler  no puede ser menor que cero.")
                Me.nAlquiler.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nOtrosIngresos.Value) Then
                MsgBox("Monto Otros Ingresos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosIngresos, "Monto Otros Ingresos  no puede ser menor que cero.")
                Me.nOtrosIngresos.Focus()
                Exit Function
            End If
            If Me.nOtrosIngresos.Value < 0 Then
                MsgBox("Monto Otros Ingresos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosIngresos, "Monto Otros Ingresos  no puede ser menor que cero.")
                Me.nOtrosIngresos.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nCostosProduccionComercio.Value) Then
                MsgBox("Monto Costos Produccion Comercio no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nCostosProduccionComercio, "Monto Costos Produccion Comercio no puede ser menor que cero.")
                Me.nCostosProduccionComercio.Focus()
                Exit Function
            End If
            If Me.nCostosProduccionComercio.Value < 0 Then
                MsgBox("Monto Costos Produccion Comercio no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nCostosProduccionComercio, "Monto Costos Produccion Comercio no puede ser menor que cero.")
                Me.nCostosProduccionComercio.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nGastosOperativos.Value) Then
                MsgBox("Monto Gastos Operativos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nGastosOperativos, "Monto Gastos Operativos no puede ser menor que cero.")
                Me.nGastosOperativos.Focus()
                Exit Function
            End If
            If Me.nGastosOperativos.Value < 0 Then
                MsgBox("Monto Gastos Operativos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nGastosOperativos, "Monto Gastos Operativos no puede ser menor que cero.")
                Me.nGastosOperativos.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nAmortizacionDeuda.Value) Then
                MsgBox("Monto Amortizacion Deuda no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nAmortizacionDeuda, "Monto Amortizacion Deuda  no puede ser menor que cero.")
                Me.nAmortizacionDeuda.Focus()
                Exit Function
            End If
            If Me.nAmortizacionDeuda.Value < 0 Then
                MsgBox("Monto Amortizacion Deuda no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nAmortizacionDeuda, "Monto Amortizacion Deuda  no puede ser menor que cero.")
                Me.nAmortizacionDeuda.Focus()
                Exit Function
            End If

            If IsDBNull(Me.nProvisionMantenimientoReinversion.Value) Then
                MsgBox("Monto Provisión Mantenimiento Reinversion no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nProvisionMantenimientoReinversion, "Monto Provisión Mantenimiento Reinversion no puede ser menor que cero.")
                Me.nProvisionMantenimientoReinversion.Focus()
                Exit Function
            End If
            If Me.nProvisionMantenimientoReinversion.Value < 0 Then
                MsgBox("Monto Provisión Mantenimiento Reinversion no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nProvisionMantenimientoReinversion, "Monto Provisión Mantenimiento Reinversion no puede ser menor que cero.")
                Me.nProvisionMantenimientoReinversion.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nAlquileresRentas.Value) Then
                MsgBox("Monto Alquiler Rentas no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nAlquileresRentas, "Monto Alquiler Rentas  no puede ser menor que cero.")
                Me.nAlquileresRentas.Focus()
                Exit Function
            End If
            If Me.nAlquileresRentas.Value < 0 Then
                MsgBox("Monto Alquiler Rentas no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nAlquileresRentas, "Monto Alquiler Rentas  no puede ser menor que cero.")
                Me.nAlquileresRentas.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nImpuestosSeguros.Value) Then
                MsgBox("Monto Impuestos Seguros no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nImpuestosSeguros, "Monto Impuestos Seguros  no puede ser menor que cero.")
                Me.nImpuestosSeguros.Focus()
                Exit Function
            End If

            If Me.nImpuestosSeguros.Value < 0 Then
                MsgBox("Monto Impuestos Seguros no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nImpuestosSeguros, "Monto Impuestos Seguros  no puede ser menor que cero.")
                Me.nImpuestosSeguros.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nGastosFamiliares.Value) Then
                MsgBox("Monto Gastos Familiares  no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nGastosFamiliares, "Monto Gastos Familiares  no puede ser menor que cero.")
                Me.nGastosFamiliares.Focus()
                Exit Function
            End If
            If Me.nGastosFamiliares.Value < 0 Then
                MsgBox("Monto Gastos Familiares  no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nGastosFamiliares, "Monto Gastos Familiares  no puede ser menor que cero.")
                Me.nGastosFamiliares.Focus()
                Exit Function
            End If
            If IsDBNull(Me.nOtrosGastos.Value) Then
                MsgBox("Monto Otros Gastos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosGastos, "Monto  Otros Gastos no puede ser menor que cero.")
                Me.nOtrosGastos.Focus()
                Exit Function
            End If
            If Me.nOtrosGastos.Value < 0 Then
                MsgBox("Monto Otros Gastos no puede ser menor  que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.nOtrosGastos, "Monto  Otros Gastos no puede ser menor que cero.")
                Me.nOtrosGastos.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub SalvarReferencia()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim StrSql As String
        Dim xResponse As Integer
        Try



            StrSql = "Exec spSclGrabarInformacionFinanciera'" & ModoFrm.ToString() & "'," & Me.intSclTipoPersona & "," & Me.intFichaID & "," & intSclReferenciaBancariaID & "," & intReferenciaCrediticiaID & ",'" & Format(Me.cdeFechaCorte.Value, "yyyy-MM-dd") & "'," & XdsFicha("TipoMoneda").ValueField("nStbMonedaID") & "," & Me.nEfectivo.Value & "," & Me.nBancos.Value & "," & Me.nCuentasPorCobrar.Value & "," & Me.nInventarios.Value & "," & Me.nOtrosCirculantes.Value & "," & Me.nBienesInmuebles.Value & "," & Me.nMaqEquipoRodante.Value & "," & Me.nBienesMuebles.Value & "," & Me.nOtrosFijos.Value & "," & Me.nOtrosActivos.Value & "," & Me.nProveedores.Value & "," & Me.nCuentasPorPagarCortoPlazo.Value & "," & Me.nPrestamosPorPagarCortoPlazo.Value & "," & Me.nImpuestosPorPagar.Value & "," & Me.nOtrasCuentasCortoPlazo.Value & "," & Me.nPtmosPorPagarLargoPlazo.Value & "," & Me.nOtrosPasivosLargoPlazo.Value & "," & Me.nPatrimonio.Value & "," & Me.nIngresosActividadEconomica.Value & "," & Me.nAlquiler.Value & "," & Me.nOtrosIngresos.Value & "," & Me.nCostosProduccionComercio.Value & "," & Me.nGastosOperativos.Value & "," & Me.nAmortizacionDeuda.Value & "," & Me.nProvisionMantenimientoReinversion.Value & "," & Me.nAlquileresRentas.Value & "," & Me.nImpuestosSeguros.Value & "," & Me.nGastosFamiliares.Value & "," & Me.nOtrosGastos.Value & ",'" & InfoSistema.LoginName & "'"
            xResponse = XcDatos.ExecuteScalar(StrSql)


            If xResponse = 0 Then
                MsgBox("Eror al intentar ingresar los datos.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                    intSclReferenciaBancariaID = xResponse
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If

            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

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
                            Me.SalvarReferencia()
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

    'Se indica que hubo modificación en el combo de Institución





 

 
    Private Sub cboTipoMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoMoneda.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaCorte_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCorte.TextChanged
        vbModifico = True
    End Sub

    Private Sub nEfectivo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nEfectivo.TextChanged
        vbModifico = True
        Me.SumaActivoCirculante()
        Me.SumaTotalActivo()
    End Sub

    Private Sub SumaActivoCirculante()
        CneActivoCirculante.Value = IIf(IsDBNull(nEfectivo.Value), 0, nEfectivo.Value) + IIf(IsDBNull(nBancos.Value), 0, nBancos.Value) + IIf(IsDBNull(nCuentasPorCobrar.Value), 0, nCuentasPorCobrar.Value) + IIf(IsDBNull(nInventarios.Value), 0, nInventarios.Value) + IIf(IsDBNull(nOtrosCirculantes.Value), 0, nOtrosCirculantes.Value) + IIf(IsDBNull(nOtrosCirculantes.Value), 0, nOtrosCirculantes.Value)
    End Sub
    Private Sub SumaActivoFijo()
        cneActivoFijo.Value = IIf(IsDBNull(nBienesInmuebles.Value), 0, nBienesInmuebles.Value) + IIf(IsDBNull(nMaqEquipoRodante.Value), 0, nMaqEquipoRodante.Value) + IIf(IsDBNull(nBienesMuebles.Value), 0, nBienesMuebles.Value) + IIf(IsDBNull(nOtrosFijos.Value), 0, nOtrosFijos.Value)
    End Sub
    Private Sub SumaTotalActivo()
        CneTotalActivo.Value = IIf(IsDBNull(nEfectivo.Value), 0, nEfectivo.Value) + IIf(IsDBNull(nBancos.Value), 0, nBancos.Value) + IIf(IsDBNull(nCuentasPorCobrar.Value), 0, nCuentasPorCobrar.Value) + IIf(IsDBNull(nInventarios.Value), 0, nInventarios.Value) + IIf(IsDBNull(nOtrosCirculantes.Value), 0, nOtrosCirculantes.Value) + IIf(IsDBNull(nOtrosCirculantes.Value), 0, nOtrosCirculantes.Value) + IIf(IsDBNull(nBienesInmuebles.Value), 0, nBienesInmuebles.Value) + IIf(IsDBNull(nMaqEquipoRodante.Value), 0, nMaqEquipoRodante.Value) + IIf(IsDBNull(nBienesMuebles.Value), 0, nBienesMuebles.Value) + IIf(IsDBNull(nOtrosFijos.Value), 0, nOtrosFijos.Value) + IIf(IsDBNull(nOtrosActivos.Value), 0, nOtrosActivos.Value)
    End Sub

    Private Sub SumaPasivoCirculante()
        CnePasivoCirculante.Value = IIf(IsDBNull(nProveedores.Value), 0, nProveedores.Value) + IIf(IsDBNull(nCuentasPorPagarCortoPlazo.Value), 0, nCuentasPorPagarCortoPlazo.Value) + IIf(IsDBNull(nPrestamosPorPagarCortoPlazo.Value), 0, nPrestamosPorPagarCortoPlazo.Value) + IIf(IsDBNull(nImpuestosPorPagar.Value), 0, nImpuestosPorPagar.Value) + IIf(IsDBNull(nOtrasCuentasCortoPlazo.Value), 0, nOtrasCuentasCortoPlazo.Value)
    End Sub

    Private Sub SumaPasivoFijo()
        CnePasivoFijo.Value = IIf(IsDBNull(nPtmosPorPagarLargoPlazo.Value), 0, nPtmosPorPagarLargoPlazo.Value) + IIf(IsDBNull(nOtrosPasivosLargoPlazo.Value), 0, nOtrosPasivosLargoPlazo.Value)
    End Sub
    Private Sub SumaTotalPasivo()
        CneTotalPasivo.Value = IIf(IsDBNull(nProveedores.Value), 0, nProveedores.Value) + IIf(IsDBNull(nCuentasPorPagarCortoPlazo.Value), 0, nCuentasPorPagarCortoPlazo.Value) + IIf(IsDBNull(nPrestamosPorPagarCortoPlazo.Value), 0, nPrestamosPorPagarCortoPlazo.Value) + IIf(IsDBNull(nImpuestosPorPagar.Value), 0, nImpuestosPorPagar.Value) + IIf(IsDBNull(nOtrasCuentasCortoPlazo.Value), 0, nOtrasCuentasCortoPlazo.Value) + IIf(IsDBNull(nPtmosPorPagarLargoPlazo.Value), 0, nPtmosPorPagarLargoPlazo.Value) + IIf(IsDBNull(nOtrosPasivosLargoPlazo.Value), 0, nOtrosPasivosLargoPlazo.Value)
    End Sub

    Private Sub SumaPasivoMasCapital()
        CnePasivoMasCapital.Value = IIf(IsDBNull(nProveedores.Value), 0, nProveedores.Value) + IIf(IsDBNull(nCuentasPorPagarCortoPlazo.Value), 0, nCuentasPorPagarCortoPlazo.Value) + IIf(IsDBNull(nPrestamosPorPagarCortoPlazo.Value), 0, nPrestamosPorPagarCortoPlazo.Value) + IIf(IsDBNull(nImpuestosPorPagar.Value), 0, nImpuestosPorPagar.Value) + IIf(IsDBNull(nOtrasCuentasCortoPlazo.Value), 0, nOtrasCuentasCortoPlazo.Value) + IIf(IsDBNull(nPtmosPorPagarLargoPlazo.Value), 0, nPtmosPorPagarLargoPlazo.Value) + IIf(IsDBNull(nOtrosPasivosLargoPlazo.Value), 0, nOtrosPasivosLargoPlazo.Value) + IIf(IsDBNull(nPatrimonio.Value), 0, nPatrimonio.Value)
    End Sub

    Private Sub SumaIngresos()
        CneIngresos.Value = IIf(IsDBNull(nIngresosActividadEconomica.Value), 0, nIngresosActividadEconomica.Value) + IIf(IsDBNull(nAlquiler.Value), 0, nAlquiler.Value) + IIf(IsDBNull(nOtrosIngresos.Value), 0, nOtrosIngresos.Value)
    End Sub
    Private Sub SumaEgresos()
        CneEgresos.Value = IIf(IsDBNull(nCostosProduccionComercio.Value), 0, nCostosProduccionComercio.Value) + IIf(IsDBNull(nGastosOperativos.Value), 0, nGastosOperativos.Value) + IIf(IsDBNull(nAmortizacionDeuda.Value), 0, nAmortizacionDeuda.Value) + IIf(IsDBNull(nProvisionMantenimientoReinversion.Value), 0, nProvisionMantenimientoReinversion.Value) + IIf(IsDBNull(nAlquileresRentas.Value), 0, nAlquileresRentas.Value) + IIf(IsDBNull(nImpuestosSeguros.Value), 0, nImpuestosSeguros.Value) + IIf(IsDBNull(nGastosFamiliares.Value), 0, nGastosFamiliares.Value) + IIf(IsDBNull(nOtrosGastos.Value), 0, nOtrosGastos.Value)
    End Sub
    Private Sub SumaResultado()
        CneResultado.Value = IIf(IsDBNull(nIngresosActividadEconomica.Value), 0, nIngresosActividadEconomica.Value) + IIf(IsDBNull(nAlquiler.Value), 0, nAlquiler.Value) + IIf(IsDBNull(nOtrosIngresos.Value), 0, nOtrosIngresos.Value) - (IIf(IsDBNull(nCostosProduccionComercio.Value), 0, nCostosProduccionComercio.Value) + IIf(IsDBNull(nGastosOperativos.Value), 0, nGastosOperativos.Value) + IIf(IsDBNull(nAmortizacionDeuda.Value), 0, nAmortizacionDeuda.Value) + IIf(IsDBNull(nProvisionMantenimientoReinversion.Value), 0, nProvisionMantenimientoReinversion.Value) + IIf(IsDBNull(nAlquileresRentas.Value), 0, nAlquileresRentas.Value) + IIf(IsDBNull(nImpuestosSeguros.Value), 0, nImpuestosSeguros.Value) + IIf(IsDBNull(nGastosFamiliares.Value), 0, nGastosFamiliares.Value) + IIf(IsDBNull(nOtrosGastos.Value), 0, nOtrosGastos.Value))
    End Sub

    Private Sub nBancos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nBancos.TextChanged
        vbModifico = True
        Me.SumaActivoCirculante()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nCuentasPorCobrar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nCuentasPorCobrar.TextChanged
        vbModifico = True
        Me.SumaActivoCirculante()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nInventarios_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nInventarios.TextChanged
        vbModifico = True
        Me.SumaActivoCirculante()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nOtrosCirculantes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrosCirculantes.TextChanged
        vbModifico = True
        Me.SumaActivoCirculante()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nBienesInmuebles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nBienesInmuebles.TextChanged
        vbModifico = True
        Me.SumaActivoFijo()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nMaqEquipoRodante_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nMaqEquipoRodante.TextChanged
        vbModifico = True
        Me.SumaActivoFijo()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nBienesMuebles_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nBienesMuebles.TextChanged
        vbModifico = True
        Me.SumaActivoFijo()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nOtrosFijos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrosFijos.TextChanged
        vbModifico = True
        Me.SumaActivoFijo()
        Me.SumaTotalActivo()
    End Sub

    Private Sub nOtrosActivos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrosActivos.TextChanged
        vbModifico = True
        Me.SumaTotalActivo()
    End Sub

    Private Sub nProveedores_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nProveedores.TextChanged
        vbModifico = True
        Me.SumaPasivoCirculante()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nCuentasPorPagarCortoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nCuentasPorPagarCortoPlazo.TextChanged
        vbModifico = True
        Me.SumaPasivoCirculante()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nPrestamosPorPagarCortoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nPrestamosPorPagarCortoPlazo.TextChanged
        vbModifico = True
        Me.SumaPasivoCirculante()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nImpuestosPorPagar_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nImpuestosPorPagar.TextChanged
        vbModifico = True
        Me.SumaPasivoCirculante()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nOtrasCuentasCortoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrasCuentasCortoPlazo.TextChanged
        vbModifico = True
        Me.SumaPasivoCirculante()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nPtmosPorPagarLargoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nPtmosPorPagarLargoPlazo.TextChanged
        vbModifico = True
        Me.SumaPasivoFijo()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nOtrosPasivosLargoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrosPasivosLargoPlazo.TextChanged
        vbModifico = True
        Me.SumaPasivoFijo()
        Me.SumaTotalPasivo()
    End Sub

    Private Sub nPatrimonio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nPatrimonio.TextChanged
        vbModifico = True
        Me.SumaPasivoMasCapital()
    End Sub

    Private Sub nIngresosActividadEconomica_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nIngresosActividadEconomica.TextChanged
        vbModifico = True
        Me.SumaIngresos()
        Me.SumaResultado()
    End Sub

    Private Sub nAlquiler_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nAlquiler.TextChanged
        vbModifico = True
        Me.SumaIngresos()
        Me.SumaResultado()
    End Sub

    Private Sub nOtrosIngresos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrosIngresos.TextChanged
        vbModifico = True
        Me.SumaIngresos()
        Me.SumaResultado()
    End Sub

    Private Sub nCostosProduccionComercio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nCostosProduccionComercio.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()
    End Sub

    Private Sub nGastosOperativos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nGastosOperativos.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub

    Private Sub nAmortizacionDeuda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nAmortizacionDeuda.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub

    Private Sub nProvisionMantenimientoReinversion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nProvisionMantenimientoReinversion.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub

    Private Sub nAlquileresRentas_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nAlquileresRentas.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub

    Private Sub nImpuestosSeguros_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nImpuestosSeguros.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub

    Private Sub nGastosFamiliares_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nGastosFamiliares.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub

    Private Sub nOtrosGastos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nOtrosGastos.TextChanged
        vbModifico = True
        Me.SumaEgresos()
        Me.SumaResultado()

    End Sub
End Class