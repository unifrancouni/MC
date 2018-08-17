'Imports SE = System.Environment
'Imports sql = System.Data.SqlClient
Public Class frmStbEditTasaCambio

    'Variables Globales del Formulario  --------------------
    Dim ModoForm, Strsql As String
    Dim ObjParidadDt As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable
    Dim ObjParidadDr As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaRow
    Dim ObjMonedaBase As New BOSistema.Win.StbEntCatalogo.StbMonedaDataTable
    Dim ObjMonedaCambio As New BOSistema.Win.StbEntCatalogo.StbMonedaDataTable
    Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable

    Dim IdParidad1 As Long
    Dim IdMonedaBase1 As Integer
    Dim IdMonedaCambio1 As Integer
    Dim IdFechaInicio1 As Date
    Dim IdFecha As Date
    Dim vbUsuarioModifica As Boolean = False
    Dim Activo As Boolean
    Dim Yavalido As Boolean = False

    Dim XdsMonedaBase As New BOSistema.Win.XDataSet
    Dim XdsMonedaCambio As New BOSistema.Win.XDataSet
    ' --------------------------------------------------------------------------------------
    'Acciones del Usuario en el Formulario
    '-----------------------------------------------------
    Public Enum AcciondelBoton
        Aceptar = 1
        Cancelar = 2
        Ninguno = 3
    End Enum
    Public AccionUsuario As AcciondelBoton
    '-- Id de la Paridad
    Property IdParidad() As Long
        Get
            IdParidad = IdParidad1
        End Get
        Set(ByVal value As Long)
            IdParidad1 = value
        End Set
    End Property
    Property IdMonedaBase() As Integer
        Get
            IdMonedaBase = IdMonedaBase1
        End Get
        Set(ByVal value As Integer)
            IdMonedaBase1 = value
        End Set
    End Property
    Property IdMonedaCambio() As Integer
        Get
            IdMonedaCambio = IdMonedaCambio1
        End Get
        Set(ByVal value As Integer)
            IdMonedaCambio1 = value
        End Set
    End Property
    Property IdFechaInicio() As Date
        Get
            IdFechaInicio = IdFechaInicio1
        End Get
        Set(ByVal value As Date)
            IdFechaInicio1 = value
        End Set
    End Property
    Private Sub frmSteParidadCambiariaEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AcciondelBoton.Ninguno Then

                ObjParidadDt.Close()
                ObjParidadDt = Nothing

                ObjParidadDr.Close()
                ObjParidadDr = Nothing

                XdsMonedaBase.Close()
                XdsMonedaBase = Nothing

                XdsMonedaCambio.Close()
                XdsMonedaCambio = Nothing

                XdtValorParametro.Close()
                XdtValorParametro = Nothing

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AcciondelBoton.Cancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    09/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiariaEdit.vb
    '-- Descripción      :    Esta propiedad permitirá saber si el formulario está en modo Edición o Agregado.
    '----------------------------------------------------------------------------------------------------------
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    Private Sub FrmSteParidadCambiariaEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            IniciarVariables()
            LlenarComboMonedaBase()
            LlenarComboMonedaCambio()

            If ModoForm = "ADD" Then
                'LlamarAgregarDatos()
                Me.ChKOcupado.Checked = False
                Me.ChKOcupado.Enabled = False
                Me.ChKActivo.Checked = True
                Me.ChKActivo.Enabled = False
            Else
                CargarDatos()
                Me.CboMonedaBase.Enabled = False
                Me.cboMonedaCambio.Enabled = False
            End If
            vbUsuarioModifica = False
            Me.CboMonedaBase.Select()
            Me.CboMonedaBase.Focus()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-----------------------------------------------------------------------
    '-- Autor                  :    
    '-- Fecha de Implementacion:    Managua, 09 de Octubre del 2006
    '-- Solution Name          :    SlnTablasBasicas
    '-- Project Name           :    PrjTablasBásicas
    '-- Project Item Name      :    FrmSteParidadCambiariaEdit
    '-- Descripcion            :    Cargar los datos del registro seleccionado en el formulario.
    '------------------------------------------------------------------------
    Private Sub CargarDatos()
        Try

            'Buscar la Tasa de Cambios

            Me.cdeFechaInicio.Enabled = False
            Me.cdeFechaFin.Enabled = False
            Me.CdeFechaGrabar.Enabled = False
            '  Me.cneMontoTasaCambio.CustomFormat = "#,###0.0000"

            ObjParidadDt.Filter = "nStbParidadCambiariaID = " & IdParidad1
            ObjParidadDt.Retrieve()
            If ObjParidadDt.Count > 0 Then
                ObjParidadDr = ObjParidadDt.Current

                'Cargar los datos de la Tasa de Cambio
                Me.CdeFechaGrabar.Value = ObjParidadDr.dFechaTCambio
                Me.cdeFechaInicio.Value = ObjParidadDr.dFechaTCambio
                Me.cdeFechaFin.Value = ObjParidadDr.dFechaTCambio
                Me.cneMontoTasaCambio.Value = ObjParidadDr.nMontoTCambio

                If Not ObjParidadDr.IsFieldNull("nStbMonedaBaseID") Then
                    If XdsMonedaBase("MonedaBase").Count > 0 Then
                        Me.CboMonedaBase.SelectedIndex = 0
                    End If
                    XdsMonedaBase("MonedaBase").SetCurrentByID("nStbMonedaID", ObjParidadDr.nStbMonedaBaseID)
                Else
                    Me.CboMonedaBase.Text = ""
                    Me.CboMonedaBase.SelectedIndex = -1
                End If

                LlenarComboMonedaCambio()
                If Not ObjParidadDr.IsFieldNull("nStbMonedaCambioID") Then
                    If XdsMonedaCambio("MonedaCambio").Count > 0 Then
                        Me.cboMonedaCambio.SelectedIndex = 0
                    End If                                              '
                    XdsMonedaCambio("MonedaCambio").SetCurrentByID("nStbMonedaID", ObjParidadDr.nStbMonedaCambioID)
                Else
                    Me.cboMonedaCambio.Text = ""
                    Me.cboMonedaCambio.SelectedIndex = -1
                End If

                If ObjParidadDr.nOcupado = 1 Then
                    Me.ChKOcupado.Checked = True
                    Me.ChKOcupado.Enabled = False
                    Me.ChKActivo.Enabled = False
                    Me.cneMontoTasaCambio.Enabled = False
                Else
                    Me.ChKOcupado.Checked = False
                    Me.ChKOcupado.Enabled = False
                End If

                If ObjParidadDr.nActivo = 1 Then
                    Me.ChKActivo.Checked = True
                Else
                    Me.ChKActivo.Checked = False
                End If


            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Public Sub IniciarVariables()
        Try
            '-- Instanciar la clase
            ObjParidadDr = New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaRow
            ObjParidadDt = New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable

            XdsMonedaBase = New BOSistema.Win.XDataSet
            XdsMonedaCambio = New BOSistema.Win.XDataSet

            'Me.cneMontoTasaCambio.EditMask = "#0.0000"
            Me.CdeFechaGrabar.Enabled = False
            '-- Limpiar los campos
            If ModoForm = "ADD" Then
                vbUsuarioModifica = True
            Else
                vbUsuarioModifica = False
            End If
            '------------------------------------ 
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Public Sub LlenarComboMonedaBase()
        Try
            'ObjMonedaBase.Filter = " Activo = 1"
            ''ObjMonedaBase.OrderBy = "Activo, CodigoInterno"
            'ObjMonedaBase.Retrieve("Descripcion")
            'Me.CboMonedaBase.DataSource = ObjMonedaBase.Source()

            Strsql = "SELECT nStbMonedaID, sCodigoInterno, sDescripcion " & _
                     "FROM StbMoneda " & _
                     "WHERE(nActivo = 1)"

            If XdsMonedaBase.ExistTable("MonedaBase") Then
                XdsMonedaBase("MonedaBase").ExecuteSql(Strsql)
            Else
                XdsMonedaBase.NewTable(Strsql, "MonedaBase")
                XdsMonedaBase("MonedaBase").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboMonedaBase.DataSource = XdsMonedaBase("MonedaBase").Source 'Xdtcuentabancarias.Source

            Me.CboMonedaBase.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            Me.CboMonedaBase.Columns("sDescripcion").Caption = "Moneda"

            Me.CboMonedaBase.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarse en el registro recomendado de parámetros:
            'Moneda Base = Dólares.
            XdtValorParametro.Filter = "nStbParametroID = 17"
            XdtValorParametro.Retrieve()
            If XdsMonedaBase("MonedaBase").Count > 0 Then
                Me.CboMonedaBase.SelectedIndex = 0
            End If
            XdsMonedaBase("MonedaBase").SetCurrentByID("nStbMonedaID", XdtValorParametro.ValueField("sValorParametro"))

            'Configurar el combo
            Me.CboMonedaBase.Splits(0).DisplayColumns("sCodigoInterno").Width = 40
            Me.CboMonedaBase.Columns("sCodigoInterno").Caption = "Código"
            Me.CboMonedaBase.Splits(0).DisplayColumns("sDescripcion").Width = 150

            'Ubicarse en el primer registro
            'If ObjMonedaBase.Count > 0 Then
            '    Me.CboMonedaBase.SelectedIndex = 0
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Public Sub LlenarComboMonedaCambio()
        Try
            'ObjMonedaCambio.Filter = " Activo = 1 and SteMonedaID<>" & Me.CboMonedaBase.Columns(0).Value & ""
            '' ObjMonedaCambio.OrderBy = "Activo, CodigoInterno"
            'ObjMonedaCambio.Retrieve("Descripcion")

            Strsql = "SELECT nStbMonedaID, sCodigoInterno, sDescripcion " & _
                     "FROM StbMoneda " & _
                     "WHERE (nActivo = 1) and nStbMonedaID <>" & Me.CboMonedaBase.Columns(0).Value & ""

            If XdsMonedaCambio.ExistTable("MonedaCambio") Then
                XdsMonedaCambio("MonedaCambio").ExecuteSql(Strsql)
            Else
                XdsMonedaCambio.NewTable(Strsql, "MonedaCambio")
                XdsMonedaCambio("MonedaCambio").Retrieve()
            End If

            Me.cboMonedaCambio.DataSource = XdsMonedaCambio("MonedaCambio").Source 'ObjMonedaCambio.Source()

            Me.cboMonedaCambio.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            Me.cboMonedaCambio.Columns("sDescripcion").Caption = "Moneda"

            Me.cboMonedaCambio.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarse en el registro recomendado de parámetros:
            'Moneda Cambio = Córdobas (Moneda Nacional).
            XdtValorParametro.Filter = "nStbParametroID = 18"
            XdtValorParametro.Retrieve()
            If XdsMonedaCambio("MonedaCambio").Count > 0 Then
                Me.cboMonedaCambio.SelectedIndex = 0
            End If
            XdsMonedaCambio("MonedaCambio").SetCurrentByID("nStbMonedaID", XdtValorParametro.ValueField("sValorParametro"))

            'Configurar el combo:
            Me.cboMonedaCambio.Splits(0).DisplayColumns("sCodigoInterno").Width = 40
            Me.cboMonedaCambio.Columns("sCodigoInterno").Caption = "Código"
            Me.cboMonedaCambio.Splits(0).DisplayColumns("sDescripcion").Width = 150

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    09/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiariaEdit.vb
    '-- Descripción      :    Busca el número siguiente para el campo CodigoInterno del nuevo registro.
    '----------------------------------------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ModoForm = "UPD" Then
                If FncValidaParametros() Then
                    SalvarDatos()
                    AccionUsuario = AcciondelBoton.Cancelar
                    Me.Close()
                End If
                ' Me.Close()
            Else
                If FncValidaParametros() Then
                    If Me.cdeFechaInicio.Value = Me.cdeFechaFin.Value Or Me.cdeFechaFin.Value = IdFecha Then
                        'If FncValidaParametros() Then
                        SalvarDatos()
                        AccionUsuario = AcciondelBoton.Cancelar
                        Me.Close()
                        'End If
                    Else
                        If Format(Me.cdeFechaFin.Value, "dd/MM/yyyy") = Format(IdFecha, "dd/MM/yyyy") Then
                            SalvarDatos()
                            AccionUsuario = AcciondelBoton.Cancelar
                            Me.Close()
                            Exit Sub
                        End If
                        'Do While Me.cdeFechaFin.Value >= IdFecha
                        If Me.cdeFechaFin.Value >= IdFecha Then
                            'Buscar la Tasa de Cambios
                            Me.CboMonedaBase.Enabled = False
                            Me.cboMonedaCambio.Enabled = False
                            Me.cdeFechaInicio.Enabled = False
                            Me.cdeFechaFin.Enabled = False
                            Me.CdeFechaGrabar.Enabled = False

                            If Me.cneMontoTasaCambio.Value = 0 Then
                                MsgBox("La Tasa de Cambio No debe estar vacía", MsgBoxStyle.Critical, "SMUSURA0")
                                errTasaCambio.SetError(Me.cneMontoTasaCambio, "Introduzca una Tasa de Cambio Válida mayor de 0 !!!")
                                Me.cneMontoTasaCambio.Focus()
                                Exit Sub
                            End If
                            SalvarDatos()
                            AccionUsuario = AcciondelBoton.Cancelar
                            IdFecha = Me.IdFecha.AddDays(1)
                            Me.CdeFechaGrabar.Value = IdFecha
                            Me.cdeFechaInicio.Value = IdFecha
                            Me.cneMontoTasaCambio.Value = 0
                            Me.cneMontoTasaCambio.Focus()

                        Else
                            Me.Close()
                        End If
                    End If
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    09/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadEdit.vb
    '-- Descripcion      :    Se validan los parametros de entrada 
    '------------------------------------------------------------------------
    Private Function FncValidaParametros() As Boolean
        Try
            '-- Declaracion de Variables 
            Dim ObjParidad As BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable
            Dim VbResultado As Boolean
            errTasaCambio.Clear()

            VbResultado = False
            ObjParidad = New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable

            '-- 1. Verificando que exista un valor válido para Moneda Base y Moneda Cambio

            If Me.CboMonedaBase.SelectedIndex = -1 Then
                MsgBox("No se definió un valor válido para Moneda Base", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.CboMonedaBase, "Moneda Base No puede estar vacía")
                Me.CboMonedaBase.Focus()
                GoTo SALIR
            End If

            If Me.cboMonedaCambio.SelectedIndex = -1 Then
                MsgBox("No se definió un valor válido para Moneda Cambio", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cboMonedaCambio, "Moneda Cambio No puede estar vacía")
                Me.cboMonedaCambio.Focus()
                GoTo SALIR
            End If

            If XdsMonedaBase("MonedaBase").ValueField("nStbMonedaId") = XdsMonedaCambio("MonedaCambio").ValueField("nStbMonedaId") Then  'ObjMonedaBase.ValueField("SteMonedaId") = ObjMonedaCambio.ValueField("SteMonedaId")
                MsgBox("La Moneda Base y la Moneda Cambio No pueden ser iguales", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cboMonedaCambio, "Seleccione una Moneda Cambio Diferente a la Moneda Base")
                Me.cboMonedaCambio.Focus()
                GoTo SALIR
            End If

            If Me.cdeFechaInicio.ValueIsDbNull Then
                MsgBox("La Fecha de Inicio No Debe estar Vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cdeFechaInicio, "Seleccione una Fecha de Inicio !!!")
                Me.cdeFechaInicio.Focus()
                GoTo SALIR
            End If

            If Me.cdeFechaFin.ValueIsDbNull Then
                MsgBox("La Fecha Final No Debe estar Vacía.", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cdeFechaFin, "Seleccione una Fecha Fin ó de Cierre !!!")
                Me.cdeFechaFin.Focus()
                GoTo SALIR
            End If

            If Me.cdeFechaFin.Value < Me.cdeFechaInicio.Value Then
                MsgBox("La Fecha Fin No Debe ser Menor que la Fecha de Inicio.", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cdeFechaFin, "Seleccione una Fecha Final Válida, Menor a la Fecha de Inicio !!!")
                Me.cdeFechaFin.Enabled = True
                Me.cdeFechaFin.Focus()
                GoTo SALIR
            End If

            If ModoForm = "ADD" Then
                ObjParidadDt.Filter = "dFechaTCambio = '" & Format(Me.CdeFechaGrabar.Value, "yyyy-MM-dd") & "'" & "And nActivo = 1" & _
                                     "And nStbMonedaBaseId = " & Me.XdsMonedaBase("MonedaBase").ValueField("nStbMonedaId") & _
                                     "And nStbMonedaCambioID = " & Me.XdsMonedaCambio("MonedaCambio").ValueField("nStbMonedaId")
                'Me.ObjMonedaBase.ValueField("SteMonedaId")
            Else
                ObjParidadDt.Filter = "nStbMonedaBaseId = " & Me.XdsMonedaBase("MonedaBase").ValueField("nStbMonedaId") & "" & _
                                      "And nStbMonedaCambioId = " & Me.XdsMonedaCambio("MonedaCambio").ValueField("nStbMonedaId") & _
                                      "And nActivo = 1 And dFechaTcambio = ' " & Format(Me.CdeFechaGrabar.Value, "yyyy-MM-dd") & "'" & _
                                      "And nStbParidadCambiariaId <> " & Me.IdParidad1
            End If

            ObjParidadDt.Retrieve()
            If ObjParidadDt.Count > 0 Then
                MsgBox("Ya Existe la tasa de cambio para la fecha de inicio,selecciona otra fecha.", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cdeFechaInicio, "Ya Existe la tasa de cambio para la fecha de inicio,selecciona otra fecha !!!")
                Me.cdeFechaInicio.Enabled = True
                Me.cdeFechaInicio.Focus()
                GoTo SALIR
            End If


            If Me.cneMontoTasaCambio.Value = 0 Then
                MsgBox("La Tasa de Cambio no debe ser cero", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cneMontoTasaCambio, "Introduzca una Tasa de Cambio Válida mayor de 0 !!!")
                Me.cneMontoTasaCambio.Focus()
                Exit Try
            End If

            If ModoFrm = "UPD" Then
                ObjParidadDt.Filter = "nStbMonedaBaseId = " & Me.IdMonedaBase & "And nStbMonedaCambioId = " & Me.IdMonedaCambio & " And nActivo = 1 And dFechaTCambio = '" & Format(Me.CdeFechaGrabar.Value, "yyyy-MM-dd") & "'" & _
                                      "And nStbParidadCambiariaId <> " & Me.IdParidad
            Else
                ObjParidadDt.Filter = "nStbMonedaBaseId = " & Me.IdMonedaBase & "And nStbMonedaCambioId = " & Me.IdMonedaCambio & " And nActivo = 1 And dFechaTCambio = '" & Format(Me.CdeFechaGrabar.Value, "yyyy-MM-dd") & "'"
            End If

            ObjParidadDt.Retrieve()
            If ObjParidadDt.Count > 0 Then
                MsgBox("Tasa de Cambio ya Existe, Favor Revise los Datos", MsgBoxStyle.Critical, "SMUSURA0")
                errTasaCambio.SetError(Me.cdeFechaInicio, "Seleccione una Tasa de Cambio Diferente a las ya Existente !!!")
                Me.cdeFechaInicio.Focus()
                GoTo SALIR
            End If

            VbResultado = True
            Yavalido = True
SALIR:
            Return (VbResultado)
            ObjParidad = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    09/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiaria.vb
    '-- Descripcion      :    Salvar los datos de la Tasa Cambiaria.
    '------------------------------------------------------------------------
    Private Sub SalvarDatos()
        Dim Num = 0
        'Dim ObjParidadDr As New BOSistema.Win.StbEntCatalogo.SteParidadCambiariaRow
        Try
            'Asignar los datos al DataRow 

            If ModoFrm = "ADD" Then
                ObjParidadDr.NewRow()
                ObjParidadDr.sUsuarioCreacion = InfoSistema.LoginName
                ObjParidadDr.dFechaCreacion = FechaServer()
            Else
                ObjParidadDt.Filter = "nStbParidadCambiariaID = " & IdParidad1
                ObjParidadDt.Retrieve()
                If ObjParidadDt.Count > 0 Then
                    ObjParidadDr = ObjParidadDt.Current
                    ObjParidadDr.sUsuarioModificacion = InfoSistema.LoginName
                    ObjParidadDr.dFechaModificacion = FechaServer()
                End If
            End If

            ObjParidadDr.dFechaTCambio = Me.CdeFechaGrabar.Value
            ObjParidadDr.nMontoTCambio = Me.cneMontoTasaCambio.Value
            ObjParidadDr.nStbMonedaBaseID = Me.XdsMonedaBase("MonedaBase").ValueField("nStbMonedaId") 'Me.ObjMonedaBase.ValueField("SteMonedaId")
            ObjParidadDr.nStbMonedaCambioID = Me.XdsMonedaCambio("MonedaCambio").ValueField("nStbMonedaId") 'Me.ObjMonedaCambio.ValueField("SteMonedaId")


            If ModoForm = "ADD" Then
                ObjParidadDr.nActivo = 1
                ObjParidadDr.nOcupado = 0
            Else
                If Me.ChKActivo.Checked = True Then
                    ObjParidadDr.nActivo = 1
                Else
                    ObjParidadDr.nActivo = 0
                End If
                If ObjParidadDr.nOcupado = 1 Then
                    ObjParidadDr.nOcupado = 1
                Else
                    ObjParidadDr.nOcupado = 0
                End If
            End If
            ObjParidadDr.Update()


            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            ' Variables 
            Dim respuesta As Object

            If vbUsuarioModifica = True Then
                respuesta = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case respuesta
                    Case vbYes
                        If Me.Yavalido = False Then
                            If FncValidaParametros() Then
                                SalvarDatos()
                                AccionUsuario = AcciondelBoton.Aceptar
                                Me.Close()
                            Else
                                AccionUsuario = AcciondelBoton.Ninguno
                            End If
                        Else
                            SalvarDatos()
                            AccionUsuario = AcciondelBoton.Aceptar
                            Me.Close()
                        End If
                    Case vbNo
                        AccionUsuario = AcciondelBoton.Cancelar
                        Me.Close()
                    Case vbCancel
                        AccionUsuario = AcciondelBoton.Ninguno
                End Select
            Else
                AccionUsuario = AcciondelBoton.Cancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub cdeFechaInicio_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdeFechaInicio.LostFocus
        If Not Me.cdeFechaInicio.Value Is DBNull.Value Then
            Me.CdeFechaGrabar.Value = Format(Me.cdeFechaInicio.Value, "dd/MM/yyyy")
            IdFecha = Me.cdeFechaInicio.Value
        End If
    End Sub
    Private Sub ChKActivo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChKActivo.Click
        If ChKActivo.Checked Then
            Activo = True
        Else
            Activo = False
        End If
    End Sub

    Private Sub ChKActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChKActivo.GotFocus
        Try
            Me.ChKActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ChKActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChKActivo.LostFocus

        Try
            Me.ChKActivo.BackColor = GrpDatosaGrabar.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ChKActivo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ChKActivo.TextChanged
        vbUsuarioModifica = True
    End Sub
    Private Sub CboMonedaBase_Close(ByVal sender As Object, ByVal e As System.EventArgs) Handles CboMonedaBase.Close
        LlenarComboMonedaCambio()
    End Sub

    Private Sub cdeFechaFin_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdeFechaFin.GotFocus
        If Not Me.cdeFechaInicio.Value Is DBNull.Value Then
            Me.CdeFechaGrabar.Value = Format(Me.cdeFechaInicio.Value, "dd/MM/yyyy")
            IdFecha = Me.cdeFechaInicio.Value
        End If
    End Sub

    Private Sub cdeFechaInicio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cdeFechaInicio.TextChanged
        If Not Me.cdeFechaInicio.Value Is DBNull.Value Then
            Me.CdeFechaGrabar.Value = Format(Me.cdeFechaInicio.Value, "dd/MM/yyyy")
            IdFecha = Me.cdeFechaInicio.Value
        End If
    End Sub

End Class

