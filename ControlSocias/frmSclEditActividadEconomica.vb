' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                30/06/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditActividadEconomica.vb
' Descripci�n:          Este formulario permite ingresar o modificar datos
'                       de Actividades Econ�micas.
'-------------------------------------------------------------------------
Public Class frmSclEditActividadEconomica

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSclActividad As Integer
    Dim IdStbActividad As Integer

    '-- Crear un data table de tipo Xdataset
    Dim ObjActividaddt As BOSistema.Win.SclEntFicha.SclClasificacionEconomicaDataTable
    Dim ObjActividaddr As BOSistema.Win.SclEntFicha.SclClasificacionEconomicaRow

    'Nombre de actividad para validaciones
    Dim strNombre As String

    '-- Crear un data table de tipo Xdataset para Combos:
    Dim XdsClase As BOSistema.Win.XDataSet

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

    'Propiedad utilizada para obtener el ID de Clasificaci�n Econ�mica.
    Public Property IdActividad() As Integer
        Get
            IdActividad = IdSclActividad
        End Get
        Set(ByVal value As Integer)
            IdSclActividad = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de Actividad Econ�mica.
    Public Property IdActividadE() As Integer
        Get
            IdActividadE = IdStbActividad
        End Get
        Set(ByVal value As Integer)
            IdStbActividad = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       frmSclEditActividadEconomica_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditActividadEconomica_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                ObjActividaddt.Close()
                ObjActividaddt = Nothing

                ObjActividaddr.Close()
                ObjActividaddr = Nothing

                XdsClase.Close()
                XdsClase = Nothing

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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       frmSclEditActividadEconomica_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Formato en caso de estar en el modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditActividadEconomica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarClasificacion(0)

            'Si el formulario est� en modo edici�n
            'cargar los datos del Formulario.
            If ModoForm <> "ADD" Then
                CargarActividad()
                InhabilitarControles()
            End If

            Me.cboClasificacion.Select()
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       InhabilitarControles
    ' Descripci�n:          Este procedimiento permite Inhabilitar Controles.
    '-------------------------------------------------------------------------
    Private Sub InhabilitarControles()
        Try
            If ObjActividaddr.nActiva <> 1 Then
                Me.CmdAceptar.Enabled = False
                Me.grpDatos.Enabled = False
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       InicializarVariables
    ' Descripci�n:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoForm = "ADD" Then
                Me.Text = "Agregar Actividad Econ�mica"
            ElseIf ModoForm = "UPD" Then
                Me.Text = "Modificar Actividad Econ�mica"
            End If

            ObjActividaddt = New BOSistema.Win.SclEntFicha.SclClasificacionEconomicaDataTable
            ObjActividaddr = New BOSistema.Win.SclEntFicha.SclClasificacionEconomicaRow
            XdsClase = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboClasificacion.ClearFields()
            
            If ModoForm = "ADD" Then
                ObjActividaddr = ObjActividaddt.NewRow
                'Inicializar los Length de los campos
                'Me.txtDescripcion.MaxLength = ObjActividaddr.GetColumnLenght("sDescripcion")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       CargarActividad
    ' Descripci�n:          Este procedimiento permite cargar los datos de la 
    '                       Actividad en caso de estar en Modo Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarActividad()
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim Strsql As String
        Try
            '-- Buscar el correspondiente al Id especificado
            '-- como par�metro, en los casos que se est� editando.
            ObjActividaddt.Filter = "nSclClasificacionEconomicaID = " & IdSclActividad
            ObjActividaddt.Retrieve()
            If ObjActividaddt.Count = 0 Then
                Exit Sub
            End If
            ObjActividaddr = ObjActividaddt.Current

            '-- Cargar Datos de la Actividad: Codigo y Descripci�n:
            'Cargar Combo de Departamentos:
            If Not ObjActividaddr.IsFieldNull("nStbActividadEconomicaID") Then
                'Determinar Codigo de la Actividad:
                Strsql = " SELECT sCodigoInterno FROM StbValorCatalogo WHERE (nStbValorCatalogoID = " & ObjActividaddr.nStbActividadEconomicaID & ")"
                txtCodigo.Text = XcUbicacion.ExecuteScalar(Strsql)
                'Determinar descripci�n (Nombre):
                Strsql = " SELECT sDescripcion FROM StbValorCatalogo WHERE (nStbValorCatalogoID = " & ObjActividaddr.nStbActividadEconomicaID & ")"
                txtNombre.Text = XcUbicacion.ExecuteScalar(Strsql)
                Me.strNombre = XcUbicacion.ExecuteScalar(Strsql)
                'Determinar descripci�n:
                Strsql = " SELECT sDescripcionActividad FROM SclClasificacionEconomica WHERE (nStbActividadEconomicaID = " & ObjActividaddr.nStbActividadEconomicaID & ")"
                txtDescripcion.Text = XcUbicacion.ExecuteScalar(Strsql).ToString


                'Determinar NVT
                Strsql = " SELECT nNVT FROM SclClasificacionEconomica WHERE (nStbActividadEconomicaID = " & ObjActividaddr.nStbActividadEconomicaID & ")"
                ckNVT.Checked = CBool(XcUbicacion.ExecuteScalar(Strsql))
                'Determinar VT
                Strsql = " SELECT nVT FROM SclClasificacionEconomica WHERE (nStbActividadEconomicaID = " & ObjActividaddr.nStbActividadEconomicaID & ")"
                ckVT.Checked = CBool(XcUbicacion.ExecuteScalar(Strsql))
                'Determinar T
                Strsql = " SELECT nT FROM SclClasificacionEconomica WHERE (nStbActividadEconomicaID = " & ObjActividaddr.nStbActividadEconomicaID & ")"
                ckT.Checked = CBool(XcUbicacion.ExecuteScalar(Strsql))
            End If

            'Cargar Combo de Clasificaci�n Econ�mica:
            If Not ObjActividaddr.IsFieldNull("nStbTipoActividadEconomicaID") Then
                CargarClasificacion(ObjActividaddr.nStbTipoActividadEconomicaID)
                If cboClasificacion.ListCount > 0 Then
                    Me.cboClasificacion.SelectedIndex = 0
                End If
                XdsClase("Clase").SetCurrentByID("nStbValorCatalogoID", ObjActividaddr.nStbTipoActividadEconomicaID)
            Else
                Me.cboClasificacion.Text = ""
                Me.cboClasificacion.SelectedIndex = -1
            End If

            'Inicializar los Length de los campos:
            'Me.txtDescripcion.MaxLength = ObjActividaddr.GetColumnLenght("sDescripcion")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripci�n:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarActividad()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripci�n:          Esta funci�n permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim Strsql As String
        Try

            ValidaDatosEntrada = True
            Me.errFormato.Clear()

            'Indicar clasificaci�n:
            If Me.cboClasificacion.SelectedIndex = -1 Then
                MsgBox("Debe indicar una clasificaci�n econ�mica de la actividad.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboClasificacion, "Debe indicar una clasificaci�n.")
                Me.cboClasificacion.Focus()
                Exit Function
            End If

            'Indicar ACTIVIDAD:
            If Trim(txtNombre.Text).Length = 0 Then
                MsgBox("Debe indicar un Nombre de la actividad.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.txtNombre, "Debe indicar un Nombre.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Indicar DESCRIPCION:
            If Trim(txtDescripcion.Text).Length = 0 Then
                MsgBox("Debe indicar una descripci�n de la actividad.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.txtDescripcion, "Debe indicar una descripci�n.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'No duplicar nombre de una Actividad ACTIVA o INACTIVA:
            If ModoForm = "UPD" Then
                Strsql = "SELECT  StbValorCatalogo.sDescripcion " &
                     "FROM StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID  " &
                     "WHERE (StbValorCatalogo.nActivo = 1) AND (StbCatalogo.sNombre = 'TipoNegocio') AND (StbValorCatalogo.sDescripcion = '" & Trim(txtNombre.Text) & "') AND (StbValorCatalogo.nStbValorCatalogoID <> " & Me.IdStbActividad & ")"
            Else
                Strsql = "SELECT  StbValorCatalogo.sDescripcion " &
                     "FROM StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID  " &
                     "WHERE (StbCatalogo.sNombre = 'TipoNegocio') AND (StbValorCatalogo.sDescripcion = '" & Trim(txtNombre.Text) & "') AND (StbValorCatalogo.nStbValorCatalogoID <> " & Me.IdStbActividad & ")"
            End If

            If RegistrosAsociados(Strsql) Then
                MsgBox("Ya existe Actividad activa o inactiva registrada con este nombre.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.txtNombre, "Debe indicar una descripci�n V�lida.")
                Me.txtNombre.Focus()
                Exit Function
            End If

            'Verificar que no est� siendo utilizada en SclFichaSocia
            Dim strsql2 As String = ""
            strsql2 = "Select * From SclFichaSocia where nStbActividadEconomicaID=" & Me.IdStbActividad
            If Me.strNombre <> Me.txtNombre.Text Then
                If RegistrosAsociados(strsql2) Then
                    MsgBox("No puede cambiar el nombre porque ya est� siendo usado en un cr�dito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFormato.SetError(Me.txtNombre, "No puede cambiar el nombre.")
                    Me.txtNombre.Focus()
                    Exit Function
                End If
                strsql2 = "Select * From SclFichaSocia where nStbActividadEconomicaVerificadaID=" & Me.IdStbActividad
                If RegistrosAsociados(strsql2) Then
                    MsgBox("No puede cambiar el nombre porque ya est� siendo usado en un cr�dito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errFormato.SetError(Me.txtNombre, "No puede cambiar el nombre.")
                    Me.txtNombre.Focus()
                    Exit Function
                End If
            End If
        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       SalvarActividad
    ' Descripci�n:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarActividad()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            '-- Ejecuta Procedimiento Almacenado:
            strSQL = " EXEC spSclGrabarActividadEconomica " & Me.IdSclActividad & ", " & Me.IdStbActividad & " ," & Me.cboClasificacion.Columns("nStbValorCatalogoID").Value & ", " & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "','" & LTrim(RTrim(Me.txtNombre.Text)) & "','" & LTrim(RTrim(Me.txtDescripcion.Text)) & "','" & Me.ModoForm & "'" _
                & ", " & IIf(ckNVT.Checked, 1, 0) & ", " & IIf(ckVT.Checked, 1, 0) & ", " & IIf(ckT.Checked, 1, 0)

            Me.IdSclActividad = XcDatos.ExecuteScalar(strSQL)

            'Si el salvado se realiz� de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If Me.IdSclActividad = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Exclamation, NombreSistema)
            Else
                If ModoForm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                    Call GuardarAuditoria(2, 15, "Modificaci�n de Clasificaci�n Econ�mica ID:" & Me.IdSclActividad & ".")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                30/06/2009
    ' Procedure Name:       CargarClasificacion
    ' Descripci�n:          Este procedimiento permite cargar el listado de 
    '                       clasificaciones econ�micas.
    '-------------------------------------------------------------------------
    Private Sub CargarClasificacion(ByVal intClasificacionID As Integer)
        Try
            Dim Strsql As String
            If intClasificacionID = 0 Then
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " Where (b.sNombre = 'TipoActividadEconomica') and (a.nActivo = 1)  " & _
                         " Order by a.sCodigoInterno"
            Else
                Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " & _
                         " FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " Where ((b.sNombre = 'TipoActividadEconomica') and (a.nActivo = 1))  " & _
                         " or (a.nStbValorCatalogoID = " & intClasificacionID & ") " & _
                         " Order by a.sCodigoInterno"
            End If

            If XdsClase.ExistTable("Clase") Then
                XdsClase("Clase").ExecuteSql(Strsql)
            Else
                XdsClase.NewTable(Strsql, "Clase")
                XdsClase("Clase").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboClasificacion.DataSource = XdsClase("Clase").Source

            'Configurar el combo: 
            Me.cboClasificacion.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboClasificacion.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboClasificacion.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboClasificacion.Splits(0).DisplayColumns("sDescripcion").Width = 80
            Me.cboClasificacion.Columns("sCodigoInterno").Caption = "C�digo"
            Me.cboClasificacion.Columns("sDescripcion").Caption = "Descripci�n"
            Me.cboClasificacion.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboClasificacion.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasificacion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNombre.TextChanged
        vbModifico = True
    End Sub
End Class