' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                21/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditOtroCredito.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de otro Crédito Vigente.
'-------------------------------------------------------------------------
Public Class frmSclEditOtroCredito
    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim sTipoFichaFrm As String
    Dim intSclFichaID As Integer
    Dim intSclOtroCreditoID As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdsFicha As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjOtroCreditodt As BOSistema.Win.SclEntFicha.SclOtroCreditoVigenteDataTable
    Dim ObjOtroCreditodr As BOSistema.Win.SclEntFicha.SclOtroCreditoVigenteRow

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
    'Propiedad utilizada para indicar el tipo de ficha
    Public Property sTipoFicha() As String
        Get
            sTipoFicha = sTipoFichaFrm
        End Get
        Set(ByVal value As String)
            sTipoFichaFrm = value
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
    'SclOtroCreditoVigenteID de la tabla SclOtroCreditoVigente.
    Public Property intOtroCreditoID() As Integer
        Get
            intOtroCreditoID = intSclOtroCreditoID
        End Get
        Set(ByVal value As Integer)
            intSclOtroCreditoID = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmSclEditOtroCredito_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditOtroCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsFicha.Close()
                XdsFicha = Nothing

                ObjOtroCreditodt.Close()
                ObjOtroCreditodt = Nothing

                'ObjOtroCreditodr.Close()
                ObjOtroCreditodr = Nothing
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
    ' Procedure Name:       frmSclOtroCredito_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Otro Crédito en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclOtroCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarInstitucion(0)
            CargarTipoPlazo()
            CargarPeriodicidad()
            CargarTipoMoneda(0)

            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            If ModoFrm = "UPD" Then
                CargarOtroCredito()
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
                Me.Text = "Agregar Otro Crédito"
            Else
                Me.Text = "Modificar Otro Crédito"
            End If

            ObjOtroCreditodt = New BOSistema.Win.SclEntFicha.SclOtroCreditoVigenteDataTable
            ObjOtroCreditodr = New BOSistema.Win.SclEntFicha.SclOtroCreditoVigenteRow

            'Obtener los Datos de los combos
            XdsFicha = New BOSistema.Win.XDataSet

            If Me.sTipoFicha = "INSCRIPCION" Then
                Me.lblActivo.Visible = False
                Me.chkActivo.Visible = False
            ElseIf Me.sTipoFicha = "VERIFICACION" Then
                Me.lblActivo.Visible = True
                Me.chkActivo.Visible = True
            End If

            'Limpiar los combos
            Me.cboInstitucion.ClearFields()
            Me.cboTipoPlazo.ClearFields()

            Me.cneMontoSolicitado.Value = 0
            Me.cneSaldo.Value = 0
            Me.cneCuota.Value = 0
            Me.chkActivo.Checked = True

            Me.cboInstitucion.Select()

            If ModoFrm = "ADD" Then

                ObjOtroCreditodr = ObjOtroCreditodt.NewRow

                'Inicializar los Length de los campos
                Me.txtOtroPrestamista.MaxLength = ObjOtroCreditodr.GetColumnLenght("sOtroPrestamista")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarOtroCredito
    ' Descripción:          Este procedimiento permite cargar los Datos de 
    '                       Otro Crédito asociado anteriormente a la Ficha.
    '-------------------------------------------------------------------------
    Private Sub CargarOtroCredito()
        Try
            Dim strSQL As String = ""

            '-- Buscar el Otro Crédito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjOtroCreditodt.Filter = "nSclOtroCreditoVigenteID = " & Me.intOtroCreditoID
            ObjOtroCreditodt.Retrieve()
            If ObjOtroCreditodt.Count = 0 Then
                Exit Sub
            End If
            ObjOtroCreditodr = ObjOtroCreditodt.Current

            If Me.sTipoFicha = "INSCRIPCION" Then
                'Institución
                If Not ObjOtroCreditodr.IsFieldNull("nStbPersonaCreditoID") Then
                    If Me.cboInstitucion.ListCount > 0 Then
                        Me.cboInstitucion.SelectedIndex = 0
                    End If
                    XdsFicha("Institucion").SetCurrentByID("nStbPersonaID", ObjOtroCreditodr.nStbPersonaCreditoID)
                Else
                    Me.cboInstitucion.Text = ""
                    Me.cboInstitucion.SelectedIndex = -1
                End If

                'Otro Prestamista
                If Not ObjOtroCreditodr.IsFieldNull("sOtroPrestamista") Then
                    Me.txtOtroPrestamista.Text = ObjOtroCreditodr.sOtroPrestamista
                Else
                    Me.txtOtroPrestamista.Text = ""
                End If

                'Tipo de Moneda
                If Not ObjOtroCreditodr.IsFieldNull("nStbMonedaID") Then
                    CargarTipoMoneda(ObjOtroCreditodr.nStbMonedaID)
                    If Me.cboTipoMoneda.ListCount > 0 Then
                        Me.cboTipoMoneda.SelectedIndex = 0
                    End If
                    XdsFicha("TipoMoneda").SetCurrentByID("nStbMonedaID", ObjOtroCreditodr.nStbMonedaID)
                Else
                    Me.cboTipoMoneda.Text = ""
                    Me.cboTipoMoneda.SelectedIndex = -1
                End If

                'Monto Solicitado
                If Not ObjOtroCreditodr.IsFieldNull("nMontoDeuda") Then
                    Me.cneMontoSolicitado.Value = ObjOtroCreditodr.nMontoDeuda
                Else
                    Me.cneMontoSolicitado.Value = 0
                End If

                'Plazo
                If Not ObjOtroCreditodr.IsFieldNull("nPlazo") Then
                    Me.txtPlazo.Text = ObjOtroCreditodr.nPlazo
                Else
                    Me.txtPlazo.Text = 0
                End If

                'Tipo de Plazo
                If Not ObjOtroCreditodr.IsFieldNull("nStbTipoPlazoID") Then
                    If Me.cboTipoPlazo.ListCount > 0 Then
                        Me.cboTipoPlazo.SelectedIndex = 0
                    End If
                    XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", ObjOtroCreditodr.nStbTipoPlazoID)
                Else
                    Me.cboTipoPlazo.Text = ""
                    Me.cboTipoPlazo.SelectedIndex = -1
                End If

                'Saldo
                If Not ObjOtroCreditodr.IsFieldNull("nSaldo") Then
                    Me.cneSaldo.Value = ObjOtroCreditodr.nSaldo
                Else
                    Me.cneSaldo.Value = 0
                End If

                'Cuota que entrega
                If Not ObjOtroCreditodr.IsFieldNull("nMontoCuota") Then
                    Me.cneCuota.Value = ObjOtroCreditodr.nMontoCuota
                Else
                    Me.cneCuota.Value = 0
                End If

                'Periodicidad con que paga
                If Not ObjOtroCreditodr.IsFieldNull("nStbPlazoPeriodicidadID") Then
                    If Me.cboPeriodicidad.ListCount > 0 Then
                        Me.cboPeriodicidad.SelectedIndex = 0
                    End If
                    XdsFicha("Periodicidad").SetCurrentByID("nStbValorCatalogoID", ObjOtroCreditodr.nStbPlazoPeriodicidadID)
                Else
                    Me.cboPeriodicidad.Text = ""
                    Me.cboPeriodicidad.SelectedIndex = -1
                End If

            ElseIf Me.sTipoFicha = "VERIFICACION" Then

                'Institución
                If Not ObjOtroCreditodr.IsFieldNull("nStbPersonaCreditoVerificadaID") Then
                    If Me.cboInstitucion.ListCount > 0 Then
                        Me.cboInstitucion.SelectedIndex = 0
                    End If
                    XdsFicha("Institucion").SetCurrentByID("nStbPersonaID", ObjOtroCreditodr.nStbPersonaCreditoVerificadaID)
                Else
                    Me.cboInstitucion.Text = ""
                    Me.cboInstitucion.SelectedIndex = -1
                End If

                'Otro Prestamista
                If Not ObjOtroCreditodr.IsFieldNull("sOtroPrestamistaVerificado") Then
                    Me.txtOtroPrestamista.Text = ObjOtroCreditodr.sOtroPrestamistaVerificado
                Else
                    Me.txtOtroPrestamista.Text = ""
                End If

                'Tipo de Moneda
                If Not ObjOtroCreditodr.IsFieldNull("nStbMonedaVerificadaID") Then
                    CargarTipoMoneda(ObjOtroCreditodr.nStbMonedaVerificadaID)
                    If Me.cboTipoMoneda.ListCount > 0 Then
                        Me.cboTipoMoneda.SelectedIndex = 0
                    End If
                    XdsFicha("TipoMoneda").SetCurrentByID("nStbMonedaID", ObjOtroCreditodr.nStbMonedaVerificadaID)
                Else
                    Me.cboTipoMoneda.Text = ""
                    Me.cboTipoMoneda.SelectedIndex = -1
                End If

                'Monto Solicitado
                If Not ObjOtroCreditodr.IsFieldNull("nMontoDeudaVerificado") Then
                    Me.cneMontoSolicitado.Value = ObjOtroCreditodr.nMontoDeudaVerificado
                Else
                    Me.cneMontoSolicitado.Value = 0
                End If

                'Plazo
                If Not ObjOtroCreditodr.IsFieldNull("nPlazoVerificado") Then
                    Me.txtPlazo.Text = ObjOtroCreditodr.nPlazoVerificado
                Else
                    Me.txtPlazo.Text = 0
                End If

                'Tipo de Plazo
                If Not ObjOtroCreditodr.IsFieldNull("nStbTipoPlazoVerificadoID") Then
                    If Me.cboTipoPlazo.ListCount > 0 Then
                        Me.cboTipoPlazo.SelectedIndex = 0
                    End If
                    XdsFicha("TipoPlazo").SetCurrentByID("nStbValorCatalogoID", ObjOtroCreditodr.nStbTipoPlazoVerificadoID)
                Else
                    Me.cboTipoPlazo.Text = ""
                    Me.cboTipoPlazo.SelectedIndex = -1
                End If

                'Saldo
                If Not ObjOtroCreditodr.IsFieldNull("nSaldoVerificado") Then
                    Me.cneSaldo.Value = ObjOtroCreditodr.nSaldoVerificado
                Else
                    Me.cneSaldo.Value = 0
                End If

                'Cuota que entrega
                If Not ObjOtroCreditodr.IsFieldNull("nMontoCuotaVerificado") Then
                    Me.cneCuota.Value = ObjOtroCreditodr.nMontoCuotaVerificado
                Else
                    Me.cneCuota.Value = 0
                End If

                'Periodicidad con que paga
                If Not ObjOtroCreditodr.IsFieldNull("nStbPlazoPeriodicidadVerificadaID") Then
                    If Me.cboPeriodicidad.ListCount > 0 Then
                        Me.cboPeriodicidad.SelectedIndex = 0
                    End If
                    XdsFicha("Periodicidad").SetCurrentByID("nStbValorCatalogoID", ObjOtroCreditodr.nStbPlazoPeriodicidadVerificadaID)
                Else
                    Me.cboPeriodicidad.Text = ""
                    Me.cboPeriodicidad.SelectedIndex = -1
                End If
            End If

            'Activo
            If Not ObjOtroCreditodr.IsFieldNull("nActivo") Then
                Me.chkActivo.Checked = ObjOtroCreditodr.nActivo
                If Me.chkActivo.Checked = False Then
                    Me.cboInstitucion.Enabled = False
                    Me.txtOtroPrestamista.Enabled = False
                    Me.cneMontoSolicitado.Enabled = False
                    Me.txtPlazo.Enabled = False
                    Me.cneSaldo.Enabled = False
                    Me.cneCuota.Enabled = False
                    Me.cboPeriodicidad.Enabled = False
                    Me.cboTipoMoneda.Enabled = False
                    Me.cboTipoPlazo.Enabled = False
                End If
            End If

            'Inicializar los Length de los campos
            Me.txtOtroPrestamista.MaxLength = ObjOtroCreditodr.GetColumnLenght("sOtroPrestamista")

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

            Me.cboInstitucion.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboInstitucion.Splits(0).DisplayColumns("sRazonSocial").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboInstitucion.Splits(0).DisplayColumns("sNumRUC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoPlazo
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
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
    ' Procedure Name:       CargarPeriodicidad
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarPeriodicidad()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("Periodicidad") Then
                XdsFicha("Periodicidad").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Periodicidad")
                XdsFicha("Periodicidad").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboPeriodicidad.DataSource = XdsFicha("Periodicidad").Source

            Me.cboPeriodicidad.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboPeriodicidad.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboPeriodicidad.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboPeriodicidad.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboPeriodicidad.Columns("sCodigoInterno").Caption = "Código"
            Me.cboPeriodicidad.Columns("sDescripcion").Caption = "Descripción"

            Me.cboPeriodicidad.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboPeriodicidad.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
                SalvarOtroCredito()
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
            Me.errOtroCredito.Clear()

            'Institución
            If Me.cboInstitucion.SelectedIndex = -1 Then
                'Otro Prestamista
                If Trim(RTrim(Me.txtOtroPrestamista.Text)).ToString.Length = 0 Then
                    MsgBox("Otro prestamista NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errOtroCredito.SetError(Me.txtOtroPrestamista, "Otro prestamista NO DEBE quedar vacío.")
                    Me.txtOtroPrestamista.Focus()
                    Exit Function
                End If
            End If

            'Tipo Moneda
            If Me.cboTipoMoneda.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Moneda válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cboTipoMoneda, "Debe seleccionar un Tipo de Moneda válido.")
                Me.cboTipoMoneda.Focus()
                Exit Function
            End If

            'Monto Solicitado
            If Me.cneMontoSolicitado.ValueIsDbNull Then
                MsgBox("El Monto Solicitado NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE quedar vacío.")
                Me.cneMontoSolicitado.Focus()
                Exit Function
            End If

            'Monto Solicitado
            If Me.cneMontoSolicitado.Value = 0 Then
                MsgBox("El Monto Solicitado NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneMontoSolicitado, "El Monto Solicitado NO DEBE ser Cero.")
                Me.cneMontoSolicitado.Focus()
                Exit Function
            End If

            'Plazo
            If Trim(RTrim(Me.txtPlazo.Text)).ToString.Length = 0 Then
                MsgBox("El Plazo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.txtPlazo, "El Plazo NO DEBE quedar vacío.")
                Me.txtPlazo.Focus()
                Exit Function
            End If

            'Plazo
            If Me.txtPlazo.Text = "0" Then
                MsgBox("El Plazo NO DEBE ser cero (0).", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.txtPlazo, "El Plazo NO DEBE ser cero (0).")
                Me.txtPlazo.Focus()
                Exit Function
            End If

            'Tipo Plazo
            If Me.cboTipoPlazo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cboTipoPlazo, "Debe seleccionar un Tipo de Plazo válido.")
                Me.cboTipoPlazo.Focus()
                Exit Function
            End If

            'Saldo
            If Me.cneSaldo.ValueIsDbNull Then
                MsgBox("El Saldo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneSaldo, "El Saldo NO DEBE quedar vacío.")
                Me.cneSaldo.Focus()
                Exit Function
            End If

            'Saldo
            If Me.cneSaldo.Value = 0 Then
                MsgBox("El Saldo NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneSaldo, "El Saldo NO DEBE ser Cero.")
                Me.cneSaldo.Focus()
                Exit Function
            End If

            'Monto Cuota
            If Me.cneCuota.ValueIsDbNull Then
                MsgBox("El Monto de la Cuota NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneCuota, "El Monto de la Cuota NO DEBE quedar vacío.")
                Me.cneCuota.Focus()
                Exit Function
            End If

            'Monto Cuota
            If Me.cneCuota.Value = 0 Then
                MsgBox("El Monto de la Cuota NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneCuota, "El Monto de la Cuota NO DEBE ser Cero.")
                Me.cneCuota.Focus()
                Exit Function
            End If

            'Monto Cuota vs Monto Obtenido
            If Me.cneCuota.Value > Me.cneMontoSolicitado.Value Then
                MsgBox("El Monto de la Cuota DEBE ser menor o igual al Monto Solicitado.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cneCuota, "El Monto de la Cuota DEBE ser menor o igual al Monto Solicitado.")
                Me.cneCuota.Focus()
                Exit Function
            End If

            'Saldo vs Monto Obtenido
            'If Me.cneSaldo.Value > Me.cneMontoSolicitado.Value Then
            '    MsgBox("El Saldo DEBE ser menor o igual al Monto Solicitado.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errOtroCredito.SetError(Me.cneSaldo, "El Saldo DEBE ser menor o igual al Monto Solicitado.")
            '    Me.cneSaldo.Focus()
            '    Exit Function
            'End If

            'Tipo Periodicidad
            If Me.cboPeriodicidad.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Periodicidad válida.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errOtroCredito.SetError(Me.cboPeriodicidad, "Debe seleccionar un Tipo de Periodicidad válida.")
                Me.cboPeriodicidad.Focus()
                Exit Function
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarOtroCredito
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Comprobante en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarOtroCredito()
        Try
            If ModoFrm = "ADD" Then
                ObjOtroCreditodr.sUsuarioCreacion = InfoSistema.LoginName
                ObjOtroCreditodr.dFechaCreacion = FechaServer()
            Else
                ObjOtroCreditodr.sUsuarioModificacion = InfoSistema.LoginName
                ObjOtroCreditodr.dFechaModificacion = FechaServer()
            End If

            If Me.sTipoFicha = "INSCRIPCION" Then
                If Me.cboInstitucion.SelectedIndex = -1 Then
                    ObjOtroCreditodr.SetFieldNull("nStbPersonaCreditoID")
                    ObjOtroCreditodr.SetFieldNull("nStbPersonaCreditoVerificadaID")
                Else
                    ObjOtroCreditodr.nStbPersonaCreditoID = XdsFicha("Institucion").ValueField("nStbPersonaID")
                    ObjOtroCreditodr.nStbPersonaCreditoVerificadaID = XdsFicha("Institucion").ValueField("nStbPersonaID")
                End If

                ObjOtroCreditodr.nPlazo = Me.txtPlazo.Text
                ObjOtroCreditodr.nPlazoVerificado = Me.txtPlazo.Text
                ObjOtroCreditodr.nStbMonedaID = XdsFicha("TipoMoneda").ValueField("nStbMonedaID")
                ObjOtroCreditodr.nStbMonedaVerificadaID = XdsFicha("TipoMoneda").ValueField("nStbMonedaID")
                ObjOtroCreditodr.nStbTipoPlazoID = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
                ObjOtroCreditodr.nStbTipoPlazoVerificadoID = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
                ObjOtroCreditodr.nStbPlazoPeriodicidadID = XdsFicha("Periodicidad").ValueField("nStbValorCatalogoID")
                ObjOtroCreditodr.nStbPlazoPeriodicidadVerificadaID = XdsFicha("Periodicidad").ValueField("nStbValorCatalogoID")
                ObjOtroCreditodr.nSclFichaSociaID = Me.intFichaID
                ObjOtroCreditodr.nSaldo = Me.cneSaldo.Value
                ObjOtroCreditodr.nSaldoVerificado = Me.cneSaldo.Value
                ObjOtroCreditodr.nMontoCuota = Me.cneCuota.Value
                ObjOtroCreditodr.nMontoCuotaVerificado = Me.cneCuota.Value
                ObjOtroCreditodr.nMontoDeuda = Me.cneMontoSolicitado.Value
                ObjOtroCreditodr.nMontoDeudaVerificado = Me.cneMontoSolicitado.Value
                ObjOtroCreditodr.nActivo = 1
                ObjOtroCreditodr.nAltaVerificacion = 0

                If LTrim(RTrim(Me.txtOtroPrestamista.Text)) = "" Then
                    ObjOtroCreditodr.SetFieldNull("sOtroPrestamista")
                    ObjOtroCreditodr.SetFieldNull("sOtroPrestamistaVerificado")
                Else
                    ObjOtroCreditodr.sOtroPrestamista = Me.txtOtroPrestamista.Text
                    ObjOtroCreditodr.sOtroPrestamistaVerificado = Me.txtOtroPrestamista.Text
                End If
            ElseIf Me.sTipoFicha = "VERIFICACION" Then

                If ModoFrm = "ADD" Then
                    If Me.cboInstitucion.SelectedIndex = -1 Then
                        ObjOtroCreditodr.SetFieldNull("nStbPersonaCreditoID")
                        ObjOtroCreditodr.SetFieldNull("nStbPersonaCreditoVerificadaID")
                    Else
                        ObjOtroCreditodr.nStbPersonaCreditoID = XdsFicha("Institucion").ValueField("nStbPersonaID")
                        ObjOtroCreditodr.nStbPersonaCreditoVerificadaID = XdsFicha("Institucion").ValueField("nStbPersonaID")
                    End If

                    ObjOtroCreditodr.nPlazo = Me.txtPlazo.Text
                    ObjOtroCreditodr.nPlazoVerificado = Me.txtPlazo.Text
                    ObjOtroCreditodr.nStbMonedaID = XdsFicha("TipoMoneda").ValueField("nStbMonedaID")
                    ObjOtroCreditodr.nStbMonedaVerificadaID = XdsFicha("TipoMoneda").ValueField("nStbMonedaID")
                    ObjOtroCreditodr.nStbTipoPlazoID = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
                    ObjOtroCreditodr.nStbTipoPlazoVerificadoID = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
                    ObjOtroCreditodr.nStbPlazoPeriodicidadID = XdsFicha("Periodicidad").ValueField("nStbValorCatalogoID")
                    ObjOtroCreditodr.nStbPlazoPeriodicidadVerificadaID = XdsFicha("Periodicidad").ValueField("nStbValorCatalogoID")
                    ObjOtroCreditodr.nSclFichaSociaID = Me.intFichaID
                    ObjOtroCreditodr.nSaldo = Me.cneSaldo.Value
                    ObjOtroCreditodr.nSaldoVerificado = Me.cneSaldo.Value
                    ObjOtroCreditodr.nMontoCuota = Me.cneCuota.Value
                    ObjOtroCreditodr.nMontoCuotaVerificado = Me.cneCuota.Value
                    ObjOtroCreditodr.nMontoDeuda = Me.cneMontoSolicitado.Value
                    ObjOtroCreditodr.nMontoDeudaVerificado = Me.cneMontoSolicitado.Value
                    If Me.chkActivo.Checked = True Then
                        ObjOtroCreditodr.nActivo = 1
                    Else
                        ObjOtroCreditodr.nActivo = 0
                    End If
                    ObjOtroCreditodr.nAltaVerificacion = 1

                    If LTrim(RTrim(Me.txtOtroPrestamista.Text)) = "" Then
                        ObjOtroCreditodr.SetFieldNull("sOtroPrestamista")
                        ObjOtroCreditodr.SetFieldNull("sOtroPrestamistaVerificado")
                    Else
                        ObjOtroCreditodr.sOtroPrestamista = Me.txtOtroPrestamista.Text
                        ObjOtroCreditodr.sOtroPrestamistaVerificado = Me.txtOtroPrestamista.Text
                    End If

                Else    'cuando estamos en modo UPD (modificar)

                    If Me.cboInstitucion.SelectedIndex = -1 Then
                        ObjOtroCreditodr.SetFieldNull("nStbPersonaCreditoVerificadaID")
                    Else
                        ObjOtroCreditodr.nStbPersonaCreditoVerificadaID = XdsFicha("Institucion").ValueField("nStbPersonaID")
                    End If

                    ObjOtroCreditodr.nPlazoVerificado = Me.txtPlazo.Text
                    ObjOtroCreditodr.nStbMonedaVerificadaID = XdsFicha("TipoMoneda").ValueField("nStbMonedaID")
                    ObjOtroCreditodr.nStbTipoPlazoVerificadoID = XdsFicha("TipoPlazo").ValueField("nStbValorCatalogoID")
                    ObjOtroCreditodr.nStbPlazoPeriodicidadVerificadaID = XdsFicha("Periodicidad").ValueField("nStbValorCatalogoID")
                    ObjOtroCreditodr.nSclFichaSociaID = Me.intFichaID
                    ObjOtroCreditodr.nSaldoVerificado = Me.cneSaldo.Value
                    ObjOtroCreditodr.nMontoCuotaVerificado = Me.cneCuota.Value
                    ObjOtroCreditodr.nMontoDeudaVerificado = Me.cneMontoSolicitado.Value
                    If Me.chkActivo.Checked = True Then
                        ObjOtroCreditodr.nActivo = 1
                    Else
                        ObjOtroCreditodr.nActivo = 0
                    End If

                    If LTrim(RTrim(Me.txtOtroPrestamista.Text)) = "" Then
                        ObjOtroCreditodr.SetFieldNull("sOtroPrestamistaVerificado")
                    Else
                        ObjOtroCreditodr.sOtroPrestamistaVerificado = Me.txtOtroPrestamista.Text
                    End If
                End If
            End If
			
			If ModoFrm <> "ADD" Then
				GuardarAuditoriaTablas(15, 2, "Modificar Otro Credito Vigente", intOtroCreditoID, InfoSistema.IDCuenta)
			End If

            ObjOtroCreditodr.Update()

            'Asignar el Id del Comprobante a la 
            'variable publica del formulario
            Me.intOtroCreditoID = ObjOtroCreditodr.nSclOtroCreditoVigenteID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                GuardarAuditoriaTablas(15, 1, "Agregar Otro Credito Vigente", intOtroCreditoID, InfoSistema.IDCuenta)
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If

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
                            SalvarOtroCredito()
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
        If Me.cboInstitucion.SelectedIndex <> -1 Then
            Me.txtOtroPrestamista.Enabled = False
            Me.txtOtroPrestamista.Text = ""
        Else
            Me.txtOtroPrestamista.Enabled = True
        End If
        vbModifico = True
    End Sub

    Private Sub txtOtroPrestamista_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtroPrestamista.KeyPress
        Try
            If TextoValido(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtOtroPrestamista_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtOtroPrestamista.TextChanged
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

    Private Sub cneSaldo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneSaldo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneCuota_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneCuota.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboPeriodicidad_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboPeriodicidad.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub chkActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.GotFocus
        Try
            Me.chkActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.LostFocus
        Try
            Me.chkActivo.BackColor = Me.grpOtroCredito.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboTipoMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoMoneda.TextChanged

        If Me.cboTipoMoneda.SelectedIndex <> -1 Then

            'Monto Solicitado
            Me.cneMontoSolicitado.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"
            Me.cneMontoSolicitado.DisplayFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,###,##0.00"
            Me.cneMontoSolicitado.EditFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"

            'Cuota
            Me.cneCuota.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"
            Me.cneCuota.DisplayFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,###,##0.00"
            Me.cneCuota.EditFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"

            'Saldo
            Me.cneSaldo.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"
            Me.cneSaldo.DisplayFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,###,##0.00"
            Me.cneSaldo.EditFormat.CustomFormat = XdsFicha("TipoMoneda").ValueField("sSimbolo") & " " & "###,###,###,##0.00"
        Else

            'Monto Solicitado
            Me.cneMontoSolicitado.CustomFormat = "###,###,###,##0.00"
            Me.cneMontoSolicitado.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
            Me.cneMontoSolicitado.EditFormat.CustomFormat = "###,###,###,##0.00"

            'Cuota
            Me.cneCuota.CustomFormat = "###,###,###,##0.00"
            Me.cneCuota.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
            Me.cneCuota.EditFormat.CustomFormat = "###,###,###,##0.00"

            'Saldo
            Me.cneSaldo.CustomFormat = "###,###,###,##0.00"
            Me.cneSaldo.DisplayFormat.CustomFormat = "###,###,###,###,##0.00"
            Me.cneSaldo.EditFormat.CustomFormat = "###,###,###,##0.00"
        End If
    End Sub
End Class