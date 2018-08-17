Public Class frmSclEditReferenciaBancaria
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
            If ModoFrm = "UPD" Then

                CargarDatos()

            Else

                CargarFiador(0)
                CargarInstitucion(0)
                CargarTipoCuenta()
                CargarTipoMoneda(0)
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



            'Limpiar los combos
            Me.cboFiador.ClearFields()


            Me.cboFiador.Select()



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub




    'Private Sub CargarCatalogo(ByVal intTipoCatalogo As Integer)
    '    Try
    '        Dim Strsql As String
    '        Dim NombreCatalogo As String

    '        If intTipoCatalogo = 1 Then

    '        Else
    '            If intTipoCatalogo = 2 Then
    '            Else
    '                If intTipoCatalogo = 3 Then

    '                End If

    '            End If

    '        End If


    '        Select Case intTipoCatalogo
    '            Case 1
    '                NombreCatalogo = "BANCOS"

    '            Case 2
    '                ' does something here.
    '                NombreCatalogo = "TipoCuentaBancaria"
    '            Case 3

    '            Case Else
    '                ' does some processing... 
    '                Exit Select
    '        End Select

    '        If intFiadorID = 0 Then

    '            If intTipoPersona = 1 Then
    '                Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
    '                         " From vwStbPersonaNatural a " & _
    '                         " WHERE a.nPersonaActiva = 1 AND " & _
    '                         " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFichaActiva Where nSclFichaSociaID= " & Me.intFichaID & ") " & _
    '                         " Order by a.sFiador Asc"

    '            Else
    '                Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
    '                         " From vwStbPersonaNatural a " & _
    '                         " WHERE a.nPersonaActiva = 1 AND " & _
    '                         " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFiadorFichaActiva Where nSclGarantiaFiduciariaID=" & intReferenciaCrediticiaID & ") " & _
    '                         " Order by a.sFiador Asc"
    '            End If



    '        Else



    '            If intTipoPersona = 1 Then
    '                Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
    '                         " From vwStbPersonaNatural a " & _
    '                         " WHERE a.nPersonaActiva = 1 AND " & _
    '                         " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFichaActiva) " & _
    '                         " or a.nStbPersonaID = " & intFiadorID & _
    '                         " Order by a.sFiador Asc"

    '            Else
    '                Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
    '                         " From vwStbPersonaNatural a " & _
    '                         " WHERE a.nPersonaActiva = 1 AND " & _
    '                         " a.nStbPersonaID NOT IN (Select nStbPersonaReferenciaID FROM vwSclReferenciaPersonalFiadorFichaActiva Where nSclGarantiaFiduciariaID=" & intReferenciaCrediticiaID & " ) " & _
    '                          " or a.nStbPersonaID = " & intFiadorID & _
    '                         " Order by a.sFiador Asc"
    '            End If








    '            'Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
    '            '         " From vwStbPersonaNatural a " & _
    '            '         " WHERE ((a.nPersonaActiva = 1) AND (a.nStbPersonaID NOT IN (Select nStbFiadorID FROM vwSclFiadorFichaActiva))) " & _
    '            '         " or a.nStbPersonaID = " & intFiadorID & _
    '            '         " Order by a.sFiador Asc"
    '        End If

    '        If XdsFicha.ExistTable("Fiador") Then
    '            XdsFicha("Fiador").ExecuteSql(Strsql)
    '        Else
    '            XdsFicha.NewTable(Strsql, "Fiador")
    '            XdsFicha("Fiador").Retrieve()
    '        End If

    '        'Asignando a las fuentes de datos
    '        Me.cboFiador.DataSource = XdsFicha("Fiador").Source

    '        Me.cboFiador.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
    '        'Me.cboInstitucion.Splits(0).DisplayColumns("Sigla").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Configurar el combo
    '        Me.cboFiador.Splits(0).DisplayColumns("sFiador").Width = 160
    '        Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").Width = 120

    '        Me.cboFiador.Columns("sFiador").Caption = "Nombre del Referente"
    '        Me.cboFiador.Columns("sNumCedula").Caption = "No.Cédula"

    '        Me.cboFiador.Splits(0).DisplayColumns("sFiador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
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

    Private Sub CargarInstitucion(ByVal intInstitucionID As Integer)
        Try
            Dim Strsql As String

            If intInstitucionID = 0 Then
                Strsql = " Select a.nStbPersonaID,a.sSiglas,a.sNombre1 AS sRazonSocial,a.sNumRUC " & _
                         " From StbPersona a " & _
                         " WHERE (a.nOtorgaCredito = 1 And a.nPersonaActiva = 1)" & _
                         " Order by a.sSiglas Asc"
            Else
                Strsql = " Select a.nStbPersonaID,a.sSiglas,a.sNombre1 as sRazonSocial,a.sNumRUC " & _
                         " From StbPersona a " & _
                         " WHERE (a.nOtorgaCredito = 1 And a.nPersonaActiva = 1) or a.nStbPersonaID = " & intInstitucionID & _
                         " Order by a.sSiglas Asc"
            End If

            If XdsFicha.ExistTable("Institucion") Then
                XdsFicha("Institucion").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Institucion")
                XdsFicha("Institucion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboInstitucion.DataSource = XdsFicha("Institucion").Source

            Me.cboInstitucion.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            'Me.cboInstitucion.Splits(0).DisplayColumns("Sigla").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboInstitucion.Splits(0).DisplayColumns("sSiglas").Width = 70
            Me.cboInstitucion.Splits(0).DisplayColumns("sRazonSocial").Width = 120
            Me.cboInstitucion.Splits(0).DisplayColumns("sNumRUC").Width = 100

            Me.cboInstitucion.Columns("sSiglas").Caption = "Siglas"
            Me.cboInstitucion.Columns("sRazonSocial").Caption = "Razón Social"
            Me.cboInstitucion.Columns("sNumRUC").Caption = "No.RUC"

            Me.cboInstitucion.Splits(0).DisplayColumns("Siglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboInstitucion.Splits(0).DisplayColumns("sRazonSocial").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboInstitucion.Splits(0).DisplayColumns("No.RUC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarTipoCuenta()
        Try
            Dim Strsql As String

            'If intTipoCuentaID = 0 Then
            '    Strsql = " Select a.nStbPersonaID,a.sSiglas,a.sNombre1 AS sRazonSocial,a.sNumRUC " & _
            '             " From StbPersona a " & _
            '             " WHERE (a.nOtorgaCredito = 1 And a.nPersonaActiva = 1)" & _
            '             " Order by a.sSiglas Asc"
            'Else
            '    Strsql = " Select a.nStbPersonaID,a.sSiglas,a.sNombre1 as sRazonSocial,a.sNumRUC " & _
            '             " From StbPersona a " & _
            '             " WHERE (a.nOtorgaCredito = 1 And a.nPersonaActiva = 1) or a.nStbPersonaID = " & intTipoCuentaID & _
            '             " Order by a.sSiglas Asc"
            'End If

            Strsql = "SELECT     dbo.StbValorCatalogo.nStbValorCatalogoID, dbo.StbValorCatalogo.sCodigoInterno, " & _
                     " dbo.StbValorCatalogo.sDescripcion FROM         dbo.StbValorCatalogo INNER JOIN  dbo.StbCatalogo ON dbo.StbValorCatalogo.nStbCatalogoID = dbo.StbCatalogo.nStbCatalogoID " & _
                    " WHERE     (dbo.StbCatalogo.sNombre = 'TipoCuentaBancaria')"



            If XdsFicha.ExistTable("TipoCuenta") Then
                XdsFicha("TipoCuenta").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoCuenta")
                XdsFicha("TipoCuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoCuenta.DataSource = XdsFicha("TipoCuenta").Source

            Me.cboTipoCuenta.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            'Me.cboTipoCuenta.Splits(0).DisplayColumns("Sigla").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sCodigoInterno").Width = 70
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sDescripcion").Width = 200


            Me.cboTipoCuenta.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoCuenta.Columns("sDescripcion").Caption = "Descripcion"


            Me.cboTipoCuenta.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoCuenta.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


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
                strSQL = "SELECT     nSclReferenciaBancariaID, nSclFichaSociaID, nStbBancoID, nStbTipoCuentaID, nStbMonedaID, nMontoPromedio, dFechaReferencia, nStbPersonaReferenciaID, nAnionRelacion, sUsuarioCreacion, dFechaCreacion, sUsuarioModificacion, dFechaModificacion FROM         dbo.SclReferenciaBancaria Where nSclReferenciaBancariaID=" & Me.intReferenciaBancariaID
                'strSQL = "Select nSclReferenciaPersonalID,nSclFichaSociaID,nStbPersonaReferenciaID,sDireccion    From SclReferenciaPersonal Where  nSclReferenciaPersonalID=" & Me.intReferenciaPersonalID
            Else ' Fiador

                'strSQL = "Select nSclReferenciaCrediticiaPersonalID,nSclGarantiaFiduciariaID,nStbPersonaReferenciaID,sDireccion    From SclReferenciaCrediticiaPersonal  Where  nSclReferenciaCrediticiaPersonalID=" & Me.intReferenciaPersonalID
                strSQL = "SELECT     nSclReferenciaBancariaFiadorID, nSclGarantiaFiduciariaID, nStbBancoID, nStbTipoCuentaID, nStbMonedaID, nMontoPromedio, dFechaReferencia, nStbPersonaReferenciaID, nAnionRelacion, sUsuarioCreacion, dFechaCreacion, sUsuarioModificacion, dFechaModificacion FROM         dbo.SclReferenciaBancariaFiador Where nSclReferenciaBancariaFiadorID=" & Me.intReferenciaBancariaID

            End If


            RegTmp.ExecuteSql(strSQL)
            If RegTmp.Count > 0 Then






            End If


            'ObjGarantiaFiduciariadt.Filter = "nSclGarantiaFiduciariaID = " & Me.intGarantiaFiduciariaID
            'ObjGarantiaFiduciariadt.Retrieve()
            'If ObjGarantiaFiduciariadt.Count = 0 Then
            '    Exit Sub
            'End If
            'ObjGarantiaFiduciariadr = ObjGarantiaFiduciariadt.Current

            'Fiador
            If Not IsDBNull(RegTmp.ValueField("nStbPersonaReferenciaID")) Then

                CargarFiador(RegTmp.ValueField("nStbPersonaReferenciaID"))
                If Me.cboFiador.ListCount > 0 Then
                    Me.cboFiador.SelectedIndex = 0
                End If
                XdsFicha("Fiador").SetCurrentByID("nStbPersonaID", RegTmp.ValueField("nStbPersonaReferenciaID"))
                'Me.cboFiador.Enabled = False
            Else
                Me.cboFiador.Text = ""
                Me.cboFiador.SelectedIndex = -1
            End If

            'Datos adicionales que se presentan del Fiador
            ObjFiadorDT.Filter = " nStbPersonaID = " & RegTmp.ValueField("nStbPersonaReferenciaID")
            ObjFiadorDT.Retrieve()
            If ObjFiadorDT.Count > 0 Then
                Me.txtCedula.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sNumCedula")), "", ObjFiadorDT.ValueField("sNumCedula"))
                Me.txtCelular.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sCelular")), "", ObjFiadorDT.ValueField("sCelular"))
                Me.txtTelefono.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sTelefono")), "", ObjFiadorDT.ValueField("sTelefono"))
                Me.txtDireccionDomicilio.Text = IIf(IsDBNull(ObjFiadorDT.ValueField("sDireccion")), "", ObjFiadorDT.ValueField("sDireccion"))
            End If

            'Banco
            If Not IsDBNull(RegTmp.ValueField("nStbBancoID")) Then
                
                CargarInstitucion(RegTmp.ValueField("nStbBancoID"))
                If Me.cboInstitucion.ListCount > 0 Then
                    Me.cboInstitucion.SelectedIndex = 0
                End If

                XdsFicha("Institucion").SetCurrentByID("nStbPersonaID", RegTmp.ValueField("nStbBancoID"))
                'Me.cboFiador.Enabled = False
            Else
                Me.cboInstitucion.Text = ""
                Me.cboInstitucion.SelectedIndex = -1
            End If



            'Banco
            If Not IsDBNull(RegTmp.ValueField("nStbTipoCuentaID")) Then

                CargarTipoCuenta()
                If Me.cboTipoCuenta.ListCount > 0 Then
                    Me.cboTipoCuenta.SelectedIndex = 0
                End If

                XdsFicha("TipoCuenta").SetCurrentByID("nStbValorCatalogoID", RegTmp.ValueField("nStbTipoCuentaID"))
                'Me.cboFiador.Enabled = False
            Else
                Me.cboTipoCuenta.Text = ""
                Me.cboTipoCuenta.SelectedIndex = -1
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





            If Not IsDBNull(RegTmp.ValueField("nMontoPromedio")) Then
                Me.cneMontoPromedio.Text = RegTmp.ValueField("nMontoPromedio")
            Else
                Me.cneMontoPromedio.Text = ""
            End If

            'Fecha de referencia
            If Not IsDBNull(RegTmp.ValueField("dFechaReferencia")) Then
                Me.cdeFechaReferencia.Value = RegTmp.ValueField("dFechaReferencia")
            Else
                Me.cdeFechaReferencia.Value = Me.cdeFechaReferencia.ValueIsDbNull
            End If
            ''
            If Not IsDBNull(RegTmp.ValueField("nAnionRelacion")) Then
                Me.cneAnioRelacion.Text = RegTmp.ValueField("nAnionRelacion")
            Else
                Me.cneAnioRelacion.Text = ""
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFiadorDT.Close()
            ObjFiadorDT = Nothing
        End Try
    End Sub

    Private Sub CargarFiador(ByVal intFiadorID As Integer)
        Try
            Dim Strsql As String

            If intFiadorID = 0 Then

                If intTipoPersona = 1 Then
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1  " & _
                             " Order by a.sFiador Asc"

                Else
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1  " & _
                             " Order by a.sFiador Asc"
                End If



            Else



                If intTipoPersona = 1 Then
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1  " & _
                             " or a.nStbPersonaID = " & intFiadorID & _
                             " Order by a.sFiador Asc"

                Else
                    Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                             " From vwStbPersonaNatural a " & _
                             " WHERE a.nPersonaActiva = 1  " & _
                              " or a.nStbPersonaID = " & intFiadorID & _
                             " Order by a.sFiador Asc"
                End If








                'Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                '         " From vwStbPersonaNatural a " & _
                '         " WHERE ((a.nPersonaActiva = 1) AND (a.nStbPersonaID NOT IN (Select nStbFiadorID FROM vwSclFiadorFichaActiva))) " & _
                '         " or a.nStbPersonaID = " & intFiadorID & _
                '         " Order by a.sFiador Asc"
            End If

            If XdsFicha.ExistTable("Fiador") Then
                XdsFicha("Fiador").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Fiador")
                XdsFicha("Fiador").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboFiador.DataSource = XdsFicha("Fiador").Source

            Me.cboFiador.Splits(0).DisplayColumns("nStbPersonaID").Visible = False
            'Me.cboInstitucion.Splits(0).DisplayColumns("Sigla").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFiador.Splits(0).DisplayColumns("sFiador").Width = 160
            Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").Width = 120

            Me.cboFiador.Columns("sFiador").Caption = "Nombre del Referente"
            Me.cboFiador.Columns("sNumCedula").Caption = "No.Cédula"

            Me.cboFiador.Splits(0).DisplayColumns("sFiador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            ValidaDatosEntrada = True
            Me.errGarantiaFiduciaria.Clear()





            If Me.cboInstitucion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Banco válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboInstitucion, "Debe seleccionar un Banco válido.")
                Me.cboInstitucion.Focus()
                Exit Function
            End If

            If Me.cboTipoCuenta.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Cuenta válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboTipoCuenta, "Debe seleccionar un Tipo de Cuenta válido.")
                Me.cboTipoCuenta.Focus()
                Exit Function
            End If

            If Me.cboTipoMoneda.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un tipo de moneda válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboTipoMoneda, "Debe seleccionar un tipo de moneda válido.")
                Me.cboTipoMoneda.Focus()
                Exit Function
            End If



            'Fiador
            If Me.cboFiador.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un persona de referencia válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboFiador, "Debe seleccionar un persona de referencia válida.")
                Me.cboFiador.Focus()
                Exit Function
            End If



            If Trim(RTrim(Me.cneMontoPromedio.Text)).ToString.Length = 0 Then
                MsgBox("Monto Promedio no debe quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneMontoPromedio, "Monto Promedio no debe quedar vacío")
                Me.cneMontoPromedio.Focus()
                Exit Function
            End If

            If Me.cneMontoPromedio.Value = 0 Then
                MsgBox("Monto Promedio no puede ser menor o igual que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneMontoPromedio, "Monto Promedio no puede ser menor o igual que cero.")
                Me.cneMontoPromedio.Focus()
                Exit Function
            End If

            If Trim(RTrim(Me.cneAnioRelacion.Text)).ToString.Length = 0 Then
                MsgBox("Años de relación no debe quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneAnioRelacion, "Años de relación no debe quedar vacío.")
                Me.cneAnioRelacion.Focus()
                Exit Function
            End If

            If Me.cneAnioRelacion.Value = 0 Then
                MsgBox("Años de relación no puede ser menor o igual que cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneAnioRelacion, "Años de relación no puede ser menor o igual que cero.")
                Me.cneAnioRelacion.Focus()
                Exit Function
            End If



            'Fecha de Cancelación
            If Me.cdeFechaReferencia.ValueIsDbNull Then
                MsgBox("La Fecha de Referencia NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cdeFechaReferencia, "La Fecha de Referencia NO DEBE quedar vacía.")
                Me.cdeFechaReferencia.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarGarantiaFiduciaria
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Comprobante en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReferencia()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim StrSql As String
        Dim xResponse As Integer
        Try



            StrSql = "Exec spSclGrabarReferenciaBancaria'" & ModoFrm.ToString() & "'," & Me.intSclTipoPersona & "," & Me.intFichaID & "," & intSclReferenciaBancariaID & "," & intReferenciaCrediticiaID & "," & XdsFicha("Fiador").ValueField("nStbPersonaID") & "," & XdsFicha("Institucion").ValueField("nStbPersonaID") & "," & XdsFicha("TipoCuenta").ValueField("nStbValorCatalogoID") & "," & XdsFicha("TipoMoneda").ValueField("nStbMonedaID") & "," & Me.cneMontoPromedio.Value & ",'" & Format(Me.cdeFechaReferencia.Value, "yyyy-MM-dd") & "'," & Me.cneAnioRelacion.Value & ",'" & InfoSistema.LoginName & "'"


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



            'If ModoFrm = "ADD" Then
            '    ObjGarantiaFiduciariadr.nUsuarioCreacionID = InfoSistema.IDCuenta
            '    ObjGarantiaFiduciariadr.dFechaCreacion = FechaServer()
            'Else
            '    ObjGarantiaFiduciariadr.nUsuarioModificacionID = InfoSistema.IDCuenta
            '    ObjGarantiaFiduciariadr.dFechaModificacion = FechaServer()
            'End If

            'If Me.cboFiador.SelectedIndex = -1 Then
            '    ObjGarantiaFiduciariadr.SetFieldNull("nStbFiadorID")
            'Else
            '    ObjGarantiaFiduciariadr.nStbFiadorID = XdsFicha("Fiador").ValueField("nStbPersonaID")
            'End If

            'ObjGarantiaFiduciariadr.nStbTipoPlazoIngresosID = XdsFicha("TipoPlazoIngresos").ValueField("nStbValorCatalogoID")
            'ObjGarantiaFiduciariadr.nStbTipoPlazoObligacionesID = XdsFicha("TipoPlazoObligaciones").ValueField("nStbValorCatalogoID")
            'ObjGarantiaFiduciariadr.nStbParentescoFiadorID = XdsFicha("Parentesco").ValueField("nStbValorCatalogoID")
            'ObjGarantiaFiduciariadr.nSclFichaSociaID = Me.intFichaID
            ''ObjGarantiaFiduciariadr.nMontoIngresos = Me.cneMontoIngresos.Value
            ''ObjGarantiaFiduciariadr.nMontoObligaciones = Me.cneObligaciones.Value

            'If LTrim(RTrim(Me.txtDireccionTrabajo.Text)) = "" Then
            '    ObjGarantiaFiduciariadr.SetFieldNull("sDireccionTrabajo")
            'Else
            '    ObjGarantiaFiduciariadr.sDireccionTrabajo = Me.txtDireccionTrabajo.Text
            'End If

            'ObjGarantiaFiduciariadr.Update()

            ''Asignar el Id del Comprobante a la 
            ''variable publica del formulario-
            'Me.intGarantiaFiduciariaID = ObjGarantiaFiduciariadr.nSclGarantiaFiduciariaID
            ''--------------------------------

            ''Si el salvado se realizó de forma satisfactoria
            ''enviar mensaje informando y cerrar el formulario.
            'If ModoFrm = "ADD" Then
            '    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            'Else
            '    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
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
    'En caso que ocurra otro Tipo de Error
    Private Sub cboFiador_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboFiador.Error
        Control_Error(e.Exception)
    End Sub
    'Se indica que hubo modificación en el combo de Institución



    

    Private Sub cneMontoSolicitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoIngresos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cneObligaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoObligaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboTipoMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboFiador_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboFiador.TextChanged
        Dim ObjFiadorDT As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Try

            If Me.cboFiador.SelectedIndex <> -1 Then
                'Datos adicionales que se presentan del Fiador
                ObjFiadorDT.Filter = " nStbPersonaID = " & XdsFicha("Fiador").ValueField("nStbPersonaID")
                ObjFiadorDT.Retrieve()
                If ObjFiadorDT.Count > 0 Then
                    Me.txtCedula.Text = ObjFiadorDT.ValueField("sNumCedula")
                    If Not ObjFiadorDT.ValueField("sCelular") Is DBNull.Value Then
                        Me.txtCelular.Text = ObjFiadorDT.ValueField("sCelular")
                    Else
                        Me.txtCelular.Text = ""
                    End If
                    If Not ObjFiadorDT.ValueField("sTelefono") Is DBNull.Value Then
                        Me.txtTelefono.Text = ObjFiadorDT.ValueField("sTelefono")
                    Else
                        Me.txtTelefono.Text = ""
                    End If
                    Me.txtDireccionDomicilio.Text = ObjFiadorDT.ValueField("sDireccion")
                End If
            Else
                Me.txtCedula.Text = ""
                Me.txtCelular.Text = ""
                Me.txtTelefono.Text = ""
                Me.txtDireccionDomicilio.Text = ""
            End If

            vbModifico = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFiadorDT.Close()
            ObjFiadorDT = Nothing
        End Try
    End Sub
End Class