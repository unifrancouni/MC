' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                21/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditGarantiaFiduciaria.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de otro Crédito Vigente.
'-------------------------------------------------------------------------
Public Class frmSclEditGarantiaFiduciaria
    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim strColorFrm As String
    Dim intSclFichaID As Integer
    Dim intSclGarantiaFiduciariaID As Integer

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
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdsFicha.Close()
                XdsFicha = Nothing

                ObjGarantiaFiduciariadt.Close()
                ObjGarantiaFiduciariadt = Nothing

                'ObjOtroCreditodr.Close()
                ObjGarantiaFiduciariadr = Nothing
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
    ' Procedure Name:       frmSclGarantiaFiduciaria_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos del Otro Crédito en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclGarantiaFiduciaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarFiador(0)
            CargarParentesco()
            CargarTipoPlazoIngresos()
            CargarTipoPlazoObligaciones()

            'Si el formulario está en modo edición
            'cargar los datos del Comprobante.
            If ModoFrm = "UPD" Then
                CargarGarantiaFiduciaria()
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
                Me.Text = "Agregar Garantía Fiduciaria"
            Else
                Me.Text = "Modificar Garantía Fiduciaria"
            End If

            ObjGarantiaFiduciariadt = New BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaDataTable
            ObjGarantiaFiduciariadr = New BOSistema.Win.SclEntSocia.SclGarantiaFiduciariaRow

            'Obtener los Datos de los combos
            XdsFicha = New BOSistema.Win.XDataSet

            Me.cboTipoPlazoObligaciones.Enabled = False
            Me.cboTipoPlazoIngresos.Enabled = False

            'Limpiar los combos
            Me.cboFiador.ClearFields()
            Me.cboTipoPlazoIngresos.ClearFields()
            Me.cboTipoPlazoObligaciones.ClearFields()

            Me.cneMontoIngresos.Value = 0
            Me.cneObligaciones.Value = 0

            Me.cboFiador.Select()

            If ModoFrm = "ADD" Then

                ObjGarantiaFiduciariadr = ObjGarantiaFiduciariadt.NewRow

                'Inicializar los Length de los campos
                Me.txtDireccionTrabajo.MaxLength = ObjGarantiaFiduciariadr.GetColumnLenght("sDireccionTrabajo")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarGarantiaFiduciaria
    ' Descripción:          Este procedimiento permite cargar los Datos de 
    '                       Otro Crédito asociado anteriormente a la Ficha.
    '-------------------------------------------------------------------------
    Private Sub CargarGarantiaFiduciaria()
        Dim ObjFiadorDT As New BOSistema.Win.StbEntCatalogo.StbPersonaDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Otro Crédito correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjGarantiaFiduciariadt.Filter = "nSclGarantiaFiduciariaID = " & Me.intGarantiaFiduciariaID
            ObjGarantiaFiduciariadt.Retrieve()
            If ObjGarantiaFiduciariadt.Count = 0 Then
                Exit Sub
            End If
            ObjGarantiaFiduciariadr = ObjGarantiaFiduciariadt.Current

            'Fiador
            If Not ObjGarantiaFiduciariadr.IsFieldNull("nStbFiadorID") Then
                If Me.cboFiador.ListCount > 0 Then
                    Me.cboFiador.SelectedIndex = 0
                End If
                XdsFicha("Fiador").SetCurrentByID("nStbPersonaID", ObjGarantiaFiduciariadr.nStbFiadorID)
            Else
                Me.cboFiador.Text = ""
                Me.cboFiador.SelectedIndex = -1
            End If

            'Datos adicionales que se presentan del Fiador
            ObjFiadorDT.Filter = " nStbPersonaID = " & ObjGarantiaFiduciariadr.nStbFiadorID
            ObjFiadorDT.Retrieve()
            If ObjFiadorDT.Count > 0 Then
                Me.txtCedula.Text = ObjFiadorDT.ValueField("sNumCedula")
                Me.txtCelular.Text = ObjFiadorDT.ValueField("sCelular")
                Me.txtTelefono.Text = ObjFiadorDT.ValueField("sTelefono")
                Me.txtDireccionDomicilio.Text = ObjFiadorDT.ValueField("sDireccion")
            End If

            'Parentesco
            If Not ObjGarantiaFiduciariadr.IsFieldNull("nStbParentescoFiadorID") Then
                If Me.cboParentesco.ListCount > 0 Then
                    Me.cboParentesco.SelectedIndex = 0
                End If
                XdsFicha("Parentesco").SetCurrentByID("nStbValorCatalogoID", ObjGarantiaFiduciariadr.nStbParentescoFiadorID)
            Else
                Me.cboParentesco.Text = ""
                Me.cboParentesco.SelectedIndex = -1
            End If

            'Dirección Trabajo
            If Not ObjGarantiaFiduciariadr.IsFieldNull("sDireccionTrabajo") Then
                Me.txtDireccionTrabajo.Text = ObjGarantiaFiduciariadr.sDireccionTrabajo
            Else
                Me.txtDireccionTrabajo.Text = ""
            End If

            'Ingresos
            If Not ObjGarantiaFiduciariadr.IsFieldNull("nMontoIngresos") Then
                Me.cneMontoIngresos.Value = ObjGarantiaFiduciariadr.nMontoIngresos
            Else
                Me.cneMontoIngresos.Value = 0
            End If

            'Tipo de Plazo Ingresos
            If Not ObjGarantiaFiduciariadr.IsFieldNull("nStbTipoPlazoIngresosID") Then
                If Me.cboTipoPlazoIngresos.ListCount > 0 Then
                    Me.cboTipoPlazoIngresos.SelectedIndex = 0
                End If
                XdsFicha("TipoPlazoIngresos").SetCurrentByID("nStbValorCatalogoID", ObjGarantiaFiduciariadr.nStbTipoPlazoIngresosID)
            Else
                Me.cboTipoPlazoIngresos.Text = ""
                Me.cboTipoPlazoIngresos.SelectedIndex = -1
            End If

            'Obligaciones
            If Not ObjGarantiaFiduciariadr.IsFieldNull("nMontoObligaciones") Then
                Me.cneObligaciones.Value = ObjGarantiaFiduciariadr.nMontoObligaciones
            Else
                Me.cneObligaciones.Value = 0
            End If

            'Tipo Plazo Obligaciones
            If Not ObjGarantiaFiduciariadr.IsFieldNull("nStbTipoPlazoObligacionesID") Then
                If Me.cboTipoPlazoObligaciones.ListCount > 0 Then
                    Me.cboTipoPlazoObligaciones.SelectedIndex = 0
                End If
                XdsFicha("TipoPlazoObligaciones").SetCurrentByID("nStbValorCatalogoID", ObjGarantiaFiduciariadr.nStbTipoPlazoObligacionesID)
            Else
                Me.cboTipoPlazoObligaciones.Text = ""
                Me.cboTipoPlazoObligaciones.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos
            Me.txtDireccionTrabajo.MaxLength = ObjGarantiaFiduciariadr.GetColumnLenght("sDireccionTrabajo")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFiadorDT.Close()
            ObjFiadorDT = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarFiador
    ' Descripción:          Este procedimiento permite cargar el listado de Persona
    '                       Natural en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarFiador(ByVal intFiadorID As Integer)
        Try
            Dim Strsql As String

            If intFiadorID = 0 Then
                Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                         " From vwStbPersonaNatural a " & _
                         " WHERE a.nPersonaActiva = 1 AND " & _
                         " a.nStbPersonaID NOT IN (Select nStbFiadorID FROM vwSclFiadorFichaActiva) " & _
                         " Order by a.sFiador Asc"
            Else
                Strsql = " Select a.nStbPersonaID,a.sFiador,a.sNumCedula " & _
                         " From vwStbPersonaNatural a " & _
                         " WHERE ((a.nPersonaActiva = 1) AND (a.nStbPersonaID NOT IN (Select nStbFiadorID FROM vwSclFiadorFichaActiva))) " & _
                         " or a.nStbPersonaID = " & intFiadorID & _
                         " Order by a.sFiador Asc"
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

            Me.cboFiador.Columns("sFiador").Caption = "Nombre del Fiador"
            Me.cboFiador.Columns("sNumCedula").Caption = "No.Cédula"

            Me.cboFiador.Splits(0).DisplayColumns("sFiador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFiador.Splits(0).DisplayColumns("sNumCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoPlazoIngresos
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazoIngresos()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("TipoPlazoIngresos") Then
                XdsFicha("TipoPlazoIngresos").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoPlazoIngresos")
                XdsFicha("TipoPlazoIngresos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazoIngresos.DataSource = XdsFicha("TipoPlazoIngresos").Source

            XdtValorParametro.Filter = "nStbParametroID = 5"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("TipoPlazoIngresos").Count > 0 Then
                XdsFicha("TipoPlazoIngresos").SetCurrentByID("nStbValorCatalogoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboTipoPlazoIngresos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazoIngresos.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPlazoIngresos.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazoIngresos.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoPlazoIngresos.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazoIngresos.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazoIngresos.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazoIngresos.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarTipoPlazoObligaciones
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarTipoPlazoObligaciones()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoPlazo') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("TipoPlazoObligaciones") Then
                XdsFicha("TipoPlazoObligaciones").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "TipoPlazoObligaciones")
                XdsFicha("TipoPlazoObligaciones").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTipoPlazoObligaciones.DataSource = XdsFicha("TipoPlazoObligaciones").Source

            XdtValorParametro.Filter = "nStbParametroID = 5"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsFicha("TipoPlazoObligaciones").Count > 0 Then
                XdsFicha("TipoPlazoObligaciones").SetCurrentByID("nStbValorCatalogoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboTipoPlazoObligaciones.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoPlazoObligaciones.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoPlazoObligaciones.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoPlazoObligaciones.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboTipoPlazoObligaciones.Columns("sCodigoInterno").Caption = "Código"
            Me.cboTipoPlazoObligaciones.Columns("sDescripcion").Caption = "Descripción"

            Me.cboTipoPlazoObligaciones.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoPlazoObligaciones.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarParentesco
    ' Descripción:          Este procedimiento permite cargar el listado de Tipos
    '                       de Plazo en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarParentesco()
        Try
            Dim Strsql As String = ""

            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                     " From StbValorCatalogo a INNER JOIN " & _
                     " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'Parentesco') b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE a.nActivo = 1 " & _
                     " Order by a.sCodigoInterno "

            If XdsFicha.ExistTable("Parentesco") Then
                XdsFicha("Parentesco").ExecuteSql(Strsql)
            Else
                XdsFicha.NewTable(Strsql, "Parentesco")
                XdsFicha("Parentesco").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboParentesco.DataSource = XdsFicha("Parentesco").Source

            Me.cboParentesco.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboParentesco.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboParentesco.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboParentesco.Splits(0).DisplayColumns("sDescripcion").Width = 140

            Me.cboParentesco.Columns("sCodigoInterno").Caption = "Código"
            Me.cboParentesco.Columns("sDescripcion").Caption = "Descripción"

            Me.cboParentesco.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboParentesco.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
                SalvarGarantiaFiduciaria()
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

            'Fiador
            If Me.cboFiador.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Fiador válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.txtDireccionTrabajo, "Debe seleccionar un Fiador válido.")
                Me.txtDireccionTrabajo.Focus()
                Exit Function
            End If

            'Parentesco
            If Me.cboParentesco.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Parentesco válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboParentesco, "Debe seleccionar un Parentesco válido.")
                Me.cboParentesco.Focus()
                Exit Function
            End If

            'Monto Ingresos
            If Me.cneMontoIngresos.ValueIsDbNull Then
                MsgBox("El Monto Ingresos NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneMontoIngresos, "El Monto Ingresos NO DEBE quedar vacío.")
                Me.cneMontoIngresos.Focus()
                Exit Function
            End If

            'Monto Ingresos
            If Me.cneMontoIngresos.Value = 0 Then
                MsgBox("El Monto Ingresos NO DEBE ser Cero.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneMontoIngresos, "El Monto Ingresos NO DEBE ser Cero.")
                Me.cneMontoIngresos.Focus()
                Exit Function
            End If

            'Tipo Plazo Ingresos
            If Me.cboTipoPlazoIngresos.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboTipoPlazoIngresos, "Debe seleccionar un Tipo de Plazo válido.")
                Me.cboTipoPlazoIngresos.Focus()
                Exit Function
            End If

            'Monto Obligaciones
            If Me.cneObligaciones.ValueIsDbNull Then
                MsgBox("El Monto Obligaciones NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cneObligaciones, "El Saldo NO DEBE quedar vacío.")
                Me.cneObligaciones.Focus()
                Exit Function
            End If

            'Dirección Trabajo
            If Trim(RTrim(Me.txtDireccionTrabajo.Text)).ToString.Length = 0 Then
                MsgBox("Dirección del Trabajo NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.txtDireccionTrabajo, "Dirección del Trabajo NO DEBE quedar vacío.")
                Me.txtDireccionTrabajo.Focus()
                Exit Function
            End If

            'Tipo Plazo Obligaciones
            If Me.cboTipoPlazoObligaciones.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Tipo de Plazo válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errGarantiaFiduciaria.SetError(Me.cboTipoPlazoObligaciones, "Debe seleccionar un Tipo de Plazo válido.")
                Me.cboTipoPlazoObligaciones.Focus()
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
    Private Sub SalvarGarantiaFiduciaria()
        Try
            If ModoFrm = "ADD" Then
                ObjGarantiaFiduciariadr.nUsuarioCreacionID = InfoSistema.IDCuenta
                ObjGarantiaFiduciariadr.dFechaCreacion = FechaServer()
            Else
                ObjGarantiaFiduciariadr.nUsuarioModificacionID = InfoSistema.IDCuenta
                ObjGarantiaFiduciariadr.dFechaModificacion = FechaServer()
            End If

            If Me.cboFiador.SelectedIndex = -1 Then
                ObjGarantiaFiduciariadr.SetFieldNull("nStbFiadorID")
            Else
                ObjGarantiaFiduciariadr.nStbFiadorID = XdsFicha("Fiador").ValueField("nStbPersonaID")
            End If

            ObjGarantiaFiduciariadr.nStbTipoPlazoIngresosID = XdsFicha("TipoPlazoIngresos").ValueField("nStbValorCatalogoID")
            ObjGarantiaFiduciariadr.nStbTipoPlazoObligacionesID = XdsFicha("TipoPlazoObligaciones").ValueField("nStbValorCatalogoID")
            ObjGarantiaFiduciariadr.nStbParentescoFiadorID = XdsFicha("Parentesco").ValueField("nStbValorCatalogoID")
            ObjGarantiaFiduciariadr.nSclFichaSociaID = Me.intFichaID
            ObjGarantiaFiduciariadr.nMontoIngresos = Me.cneMontoIngresos.Value
            ObjGarantiaFiduciariadr.nMontoObligaciones = Me.cneObligaciones.Value

            If LTrim(RTrim(Me.txtDireccionTrabajo.Text)) = "" Then
                ObjGarantiaFiduciariadr.SetFieldNull("sDireccionTrabajo")
            Else
                ObjGarantiaFiduciariadr.sDireccionTrabajo = Me.txtDireccionTrabajo.Text
            End If

            ObjGarantiaFiduciariadr.Update()

            'Asignar el Id del Comprobante a la 
            'variable publica del formulario
            Me.intGarantiaFiduciariaID = ObjGarantiaFiduciariadr.nSclGarantiaFiduciariaID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
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
                            SalvarGarantiaFiduciaria()
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

    Private Sub txtDireccionTrabajo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDireccionTrabajo.KeyPress
        Try
            If TextoValido(e.KeyChar) = False Then
                e.Handled = True
                e.KeyChar = Microsoft.VisualBasic.ChrW(0)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtDireccionTrabajo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDireccionTrabajo.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneMontoSolicitado_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneMontoIngresos.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoIngresos_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazoIngresos.TextChanged
        vbModifico = True
    End Sub

    Private Sub cneObligaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cneObligaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoPlazoObligaciones_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboTipoPlazoObligaciones.TextChanged
        vbModifico = True
    End Sub

    Private Sub cboTipoMoneda_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboParentesco.TextChanged
        vbModifico = True
    End Sub

End Class