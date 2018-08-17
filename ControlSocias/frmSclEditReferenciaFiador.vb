' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                21/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditReferencia.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Referencia Crediticia.
'-------------------------------------------------------------------------
Public Class frmSclEditReferenciaFiador
    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim intSclFichaID As Integer
    Dim intSclReferenciaID As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjReferenciadt As BOSistema.Win.SclEntFicha.SclReferenciaCrediticiaDataTable
    Dim ObjReferenciadr As BOSistema.Win.SclEntFicha.SclReferenciaCrediticiaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Dim intSclReferenciaCrediticiaFiadorID As Integer



    Dim intSclGarantiaFiduciariaID As Integer

    Dim intSclReferenciaCrediticiaID As Integer
    Dim intSclReferenciaPersonalID As Integer

    Dim intStbPersonaReferenciaID As Integer

    Dim intTipoPersona As Integer
    '-- Clases para procesar la informacion de los combos


    '-- Crear un data table de tipo Xdataset
    Dim ObjGarantiaFiduciariadt As BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaDataTable
    Dim ObjGarantiaFiduciariadr As BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaRow














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
    'Propiedad utilizada para obtener el ID del otro crédito que corresponde al campo
    'nSclReferenciaCrediticiaID de la tabla SclReferenciaCrediticia.
    Public Property intReferenciaID() As Integer
        Get
            intReferenciaID = intSclReferenciaID
        End Get
        Set(ByVal value As Integer)
            intSclReferenciaID = value
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



    Public Property intReferenciaCrediticiaFiadorID() As Integer
        Get
            intReferenciaCrediticiaFiadorID = intSclReferenciaCrediticiaFiadorID
        End Get
        Set(ByVal value As Integer)
            intSclReferenciaCrediticiaFiadorID = value
        End Set
    End Property



    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       frmSclEditReferencia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditReferencia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsFicha.Close()
                XdsFicha = Nothing

                ObjReferenciadt.Close()
                ObjReferenciadt = Nothing

                'ObjOtroCreditodr.Close()
                ObjReferenciadr = Nothing
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditReferencia_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de una Referencia en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditReferencia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarInstitucion(0)
            CargarTipoPlazo()
            CargarTipoMoneda(0)

            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            If ModoFrm = "UPD" Then
                CargarReferencia()
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
                Me.Text = "Agregar Referencia Crediticia Fiador"
            Else
                Me.Text = "Modificar Referencia Crediticia Fiador"
            End If

            ObjReferenciadt = New BOSistema.Win.SclEntFicha.SclReferenciaCrediticiaDataTable
            ObjReferenciadr = New BOSistema.Win.SclEntFicha.SclReferenciaCrediticiaRow

            'Obtener los Datos de los combos
            XdsFicha = New BOSistema.Win.XDataSet

            'Limpiar los combos
            Me.cboInstitucion.ClearFields()
            Me.cboTipoPlazo.ClearFields()

            Me.txtPlazo.Text = 0
            Me.cneMontoSolicitado.Value = 0

            Me.cboInstitucion.Select()

            If ModoFrm = "ADD" Then

                ObjReferenciadr = ObjReferenciadt.NewRow

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    
    Private Sub CargarReferencia()
        Try
            Dim strSQL As String = ""
            Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable

            ''-- Buscar la Referencia correspondiente al Id especificado
            ''-- como parámetro, en los casos que se esté editando una.
            'ObjReferenciadt.Filter = "nSclReferenciaCrediticiaID = " & Me.intReferenciaID
            'ObjReferenciadt.Retrieve()
            'If ObjReferenciadt.Count = 0 Then
            '    Exit Sub
            'End If
            'ObjReferenciadr = ObjReferenciadt.Current

            RegTmp.ExecuteSql("SELECT     nSclReferenciaCrediticiaFiadorID, nSclGarantiaFiduciariaID, nStbPersonaCreditoID, nMontoObtenido, nStbTipoPlazoID, nStbMonedaID, nPlazo, dFechaSolicitud, dFechaCancelacion, sGarantia, sUsuarioCreacion, dFechaCreacion, sUsuarioModificacion, dFechaModificacion FROM         dbo.SclReferenciaCrediticiaFiador Where nSclReferenciaCrediticiaFiadorID=" & Me.intSclReferenciaCrediticiaFiadorID)
            If RegTmp.Count > 0 Then

                'Institución
                If Not IsDBNull(RegTmp.ValueField("nStbPersonaCreditoID")) Then
                    If Me.cboInstitucion.ListCount > 0 Then
                        Me.cboInstitucion.SelectedIndex = 0
                    End If
                    XdsFicha("Institucion").SetCurrentByID("nStbPersonaID", RegTmp.ValueField("nStbPersonaCreditoID"))
                Else
                    Me.cboInstitucion.Text = ""
                    Me.cboInstitucion.SelectedIndex = -1
                End If

                'Tipo de Moneda
                If Not IsDBNull(RegTmp.ValueField("nStbMonedaID")) Then
                    CargarTipoMoneda(RegTmp.ValueField("nStbMonedaID"))
                    If Me.cboTipoMoneda.ListCount > 0 Then
                        Me.cboTipoMoneda.SelectedIndex = 0
                    End If
                    XdsFicha("TipoMoneda").SetCurrentByID("nStbMonedaID", RegTmp.ValueField("nStbMonedaID"))
                Else
                    Me.cboTipoMoneda.Text = ""
                    Me.cboTipoMoneda.SelectedIndex = -1
                End If

                'Monto Obtenido
                If Not IsDBNull(RegTmp.ValueField("nMontoObtenido")) Then
                    Me.cneMontoSolicitado.Value = RegTmp.ValueField("nMontoObtenido")
                Else
                    Me.cneMontoSolicitado.Value = 0
                End If

                'Plazo
                If Not IsDBNull(RegTmp.ValueField("nPlazo")) Then
                    Me.txtPlazo.Text = RegTmp.ValueField("nPlazo")
                Else
                    Me.txtPlazo.Text = 0
                End If

                'Tipo de Plazo
                If Not IsDBNull(RegTmp.ValueField("nStbTipoPlazoID")) Then
                    If Me.cboTipoPlazo.ListCount > 0 Then
                        Me.cboTipoPlazo.SelectedIndex = 0
                    End If
                    XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", RegTmp.ValueField("nStbTipoPlazoID"))
                Else
                    Me.cboTipoPlazo.Text = ""
                    Me.cboTipoPlazo.SelectedIndex = -1
                End If

                'Fecha de Solicitud 
                If Not IsDBNull(RegTmp.ValueField("dFechaSolicitud")) Then
                    Me.cdeFechaSolicitud.Value = RegTmp.ValueField("dFechaSolicitud")
                Else
                    Me.cdeFechaSolicitud.Value = Me.cdeFechaSolicitud.ValueIsDbNull
                End If

                'Fecha de Cancelación
                If Not IsDBNull(RegTmp.ValueField("dFechaCancelacion")) Then
                    Me.cdeFechaCancelacion.Value = RegTmp.ValueField("dFechaCancelacion")
                Else
                    Me.cdeFechaCancelacion.Value = Me.cdeFechaCancelacion.ValueIsDbNull
                End If




                Me.TxtGarantia.Text = RegTmp.ValueField("sGarantia")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarInstitucion
    ' Descripción:          Este procedimiento permite cargar el listado de Instituciones
    '                       Financieras en el combo para su selección.
    '-------------------------------------------------------------------------
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
                         " From vwScnDocSoporte a " & _
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

    Private Sub CargarTipoPlazo()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("TipoPlazo") Then
                XdsFicha("TipoPlazo").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoPlazo")
                XdsFicha("TipoPlazo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazo.DataSource = XdsFicha("TipoPlazo").Source

            Me.cboTipoPlazo.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoPlazo.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazo.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazo.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazo.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoMoneda
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Moneda en el combo para su selección.
    '-------------------------------------------------------------------------
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
            Dim dFechaSolicitud As Date
            Dim dFechaCancelacion As Date

            ValidaDatosEntrada = True
            Me.errReferencia.Clear()

            'Institución
            If Me.cboInstitucion.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Institución válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cboInstitucion, "Debe seleccionar una Institución válida.")
                Me.cboInstitucion.Focus()
                Exit Function
            End If

            'Tipo Moneda
            If Me.cboTipoMoneda.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Moneda válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cboTipoMoneda, "Debe seleccionar un Tipo de Moneda válido.")
                Me.cboTipoMoneda.Focus()
                Exit Function
            End If

            'Monto Obtenido
            If Me.cneMontoSolicitado.ValueIsDbNull Then
                MsgBox("El Monto Obtenido NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cneMontoSolicitado, "El Monto Obtenido NO DEBE quedar vacío.")
                Me.cneMontoSolicitado.Focus()
                Exit Function
            End If

            'Monto Obtenido
            If Me.cneMontoSolicitado.Value = 0 Then
                MsgBox("El Monto Obtenido NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cneMontoSolicitado, "El Monto Obtenido NO DEBE ser Cero.")
                Me.cneMontoSolicitado.Focus()
                Exit Function
            End If

            'Plazo
            If Trim(RTrim(Me.txtPlazo.Text)).ToString.Length = 0 Then
                MsgBox("El Plazo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.txtPlazo, "El Plazo NO DEBE quedar vacío.")
                Me.txtPlazo.Focus()
                Exit Function
            End If

            'Plazo
            If Me.txtPlazo.Text = "0" Then
                MsgBox("El Plazo NO DEBE ser cero (0).", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.txtPlazo, "El Plazo NO DEBE ser cero (0).")
                Me.txtPlazo.Focus()
                Exit Function
            End If

            'Tipo Plazo
            If Me.cboTipoPlazo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cboTipoPlazo, "Debe seleccionar un Tipo de Plazo válido.")
                Me.cboTipoPlazo.Focus()
                Exit Function
            End If

            'Fecha de Solicitud
            If Me.cdeFechaSolicitud.ValueIsDbNull Then
                MsgBox("La Fecha de Solicitud NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud NO DEBE quedar vacía.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

            'Fecha de Cancelación
            If Me.cdeFechaCancelacion.ValueIsDbNull Then
                MsgBox("La Fecha de Cancelación NO DEBE quedar vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cdeFechaCancelacion, "La Fecha de Cancelación NO DEBE quedar vacía.")
                Me.cdeFechaCancelacion.Focus()
                Exit Function
            End If

            dFechaSolicitud = Me.cdeFechaSolicitud.Value
            dFechaCancelacion = Me.cdeFechaCancelacion.Value

            'Fecha de Solicitud vs Fecha de Cancelación
            If dFechaCancelacion < dFechaSolicitud Then
                MsgBox("La Fecha de Solicitud DEBE SER menor o igual que la Fecha de Cancelación.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errReferencia.SetError(Me.cdeFechaSolicitud, "La Fecha de Solicitud DEBE SER menor o igual que la Fecha de Cancelación.")
                Me.cdeFechaSolicitud.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       SalvarReferencia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Comprobante en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarReferencia()
        Try
            Dim XcDatos As New BOSistema.Win.XComando
            Dim StrSql As String = ""

          
            Dim xResponse As Integer





            StrSql = "Exec spSclGrabarReferenciaFinancieraFiador'" & ModoFrm.ToString() & "'," & Me.intSclReferenciaCrediticiaFiadorID & "," & intReferenciaCrediticiaID & "," & XdsFicha("Institucion").ValueField("nStbPersonaID") & "," & Me.cneMontoSolicitado.Value & "," & XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID") & "," & XdsFicha("TipoMoneda").ValueField("nStbMonedaID") & "," & Convert.ToInt16(Me.txtPlazo.Text) & ",'" & Format(Me.cdeFechaSolicitud.Value, "yyyy-MM-dd") & "','" & Format(Me.cdeFechaCancelacion.Value, "yyyy-MM-dd") & "','" & Trim(Me.TxtGarantia.Text) & "','" & InfoSistema.LoginName & "'"


            xResponse = XcDatos.ExecuteScalar(StrSql)


            If xResponse = 0 Then
                MsgBox("Eror al intentar ingresar los datos.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                    'intSclReferenciaComercialID()
                    intSclReferenciaCrediticiaFiadorID = xResponse

                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If

            End If




            'If ModoFrm = "ADD" Then
            '    ObjReferenciadr.sUsuarioCreacion = InfoSistema.LoginName
            '    ObjReferenciadr.dFechaCreacion = FechaServer()
            'Else
            '    ObjReferenciadr.sUsuarioModificacion = InfoSistema.LoginName
            '    ObjReferenciadr.dFechaModificacion = FechaServer()
            'End If

            'ObjReferenciadr.nPlazo = Me.txtPlazo.Text
            'ObjReferenciadr.nStbMonedaID = XdsFicha("TipoMoneda").ValueField("nStbMonedaID")
            'ObjReferenciadr.nStbTipoPlazoID = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
            'ObjReferenciadr.nStbPersonaCreditoID = XdsFicha("Institucion").ValueField("nStbPersonaID")
            'ObjReferenciadr.nSclFichaSociaID = Me.intFichaID
            'ObjReferenciadr.nMontoObtenido = Me.cneMontoSolicitado.Value
            'ObjReferenciadr.dFechaSolicitud = Me.cdeFechaSolicitud.Value
            'ObjReferenciadr.dFechaCancelacion = Me.cdeFechaCancelacion.Value

            'ObjReferenciadr.Update()

            ''Asignar el Id del Comprobante a la 
            ''variable publica del formulario
            'Me.intReferenciaID = ObjReferenciadr.nSclReferenciaCrediticiaID
            'StrSql = "Update SclReferenciaCrediticia Set sGarantia='" & Trim(Me.TxtGarantia.Text) & "' Where nSclReferenciaCrediticiaID=" & Me.intReferenciaID
            'XcDatos.ExecuteScalar(StrSql)

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
                            SalvarReferencia()
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
    Private Sub cboInstitucion_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboInstitucion.Error
        Control_Error(e.Exception)
    End Sub
    'Se indica que hubo modificación en el combo de Institución
    Private Sub cboInstitucion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboInstitucion.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMontoSolicitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMontoSolicitado.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtPlazo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPlazo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPlazo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaSolicitud_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaSolicitud.TextChanged
        vbModifico = True
    End Sub

    Private Sub cdeFechaCancelacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cdeFechaCancelacion.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoMoneda.TextChanged
        If Me.cboTipoMoneda.SelectedIndex <> -1 Then

            'Monto Obtenido
            Me.cneMontoSolicitado.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"
            Me.cneMontoSolicitado.DisplayFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,###,##0.00"
            Me.cneMontoSolicitado.EditFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"
        Else

            'Monto Obtenido
            Me.cneMontoSolicitado.CustomFormat = "###,###,###,##0.00"
            Me.cneMontoSolicitado.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
            Me.cneMontoSolicitado.EditFormat.CustomFormat = "###,###,###,##0.00"
        End If
    End Sub
End Class