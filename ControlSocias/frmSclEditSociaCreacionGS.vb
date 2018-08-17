' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                30/07/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditSociaCreacionGS.vb
' Descripción:          Este formulario permite crear de forma automática
'                       grupos solidarios para crédito individual.
'-------------------------------------------------------------------------
Public Class frmSclEditSociaCreacionGS

    '-- Declaracion de Variables 
    Dim IdSclSocia As Integer
    Dim IdStbBarrio As Integer

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

    'Propiedad utilizada para obtener el ID de Socia.
    Public Property IdSocia() As Integer
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Integer)
            IdSclSocia = value
        End Set
    End Property

    'Propiedad utilizada para obtener ID del Barrio de la Socia:
    Public Property IdBarrio() As Integer
        Get
            IdBarrio = IdStbBarrio
        End Get
        Set(ByVal value As Integer)
            IdStbBarrio = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       frmSclEditSociaCreacionGS_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSociaCreacionGS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       frmSclEditSociaCreacionGS_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos del Formato en caso de estar en el modo
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSociaCreacionGS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarClasificacion()

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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdsClase = New BOSistema.Win.XDataSet
            Control.CheckForIllegalCrossThreadCalls = False
            Me.cboClasificacion.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarSociaGS()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim Strsql As String
        Try

            ValidaDatosEntrada = True
            Me.errFormato.Clear()

            'Indicar clasificación:
            If Me.cboClasificacion.SelectedIndex = -1 Then
                MsgBox("Debe indicar un Tipo de Plan de Negocio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboClasificacion, "Debe indicar un Tipo de Plan de Negocio.")
                Me.cboClasificacion.Focus()
                Exit Function
            End If

            'Verifica si ya existe Grupo Solidario individual ACTIVO para la Socia y el Tipo de Plan de Negocio:
            Strsql = " SELECT SclGrupoSolidario.nSclTipodePlandeNegocioID " & _
                     " FROM SclGrupoSolidario INNER JOIN StbValorCatalogo ON SclGrupoSolidario.nStbEstadoGrupoID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN SclGrupoSocia ON SclGrupoSolidario.nSclGrupoSolidarioID = SclGrupoSocia.nSclGrupoSolidarioID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SclGrupoSolidario.nSclTipodePlandeNegocioID = " & Me.cboClasificacion.Columns("nSclTipodePlandeNegocioID").Value & ") AND (SclGrupoSocia.nSclSociaID = " & Me.IdSclSocia & ")"
            If RegistrosAsociados(Strsql) = True Then
                MsgBox("Ya existe Grupo Solidario con este tipo de Plan de Negocio" & Chr(13) & "para la socia seleccionada.", MsgBoxStyle.Information, NombreSistema)
                ValidaDatosEntrada = False
                Me.errFormato.SetError(Me.cboClasificacion, "Debe indicar otro Tipo de Plan de Negocio.")
                Me.cboClasificacion.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       SalvarSociaGS
    ' Descripción:          Este procedimiento permite crear un nuevo grupo
    '                       solidario de credito individual conforme el tipo
    '                       de plan de negocio indicado.
    '-------------------------------------------------------------------------
    Private Sub SalvarSociaGS()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            Dim intGrupoID As Integer
            Dim intDelegacionSociaID As Integer

            'Garantiza que delegacion del nuevo grupo solidario sea la misma de la socia:
            strSQL = "SELECT nStbDelegacionProgramaID FROM SclSocia WHERE (nSclSociaID = " & Me.IdSclSocia & ")"
            intDelegacionSociaID = XcDatos.ExecuteScalar(strSQL)

            '-- Ejecuta Procedimiento Almacenado: 
            strSQL = " EXEC spSclGrabarGrupoCreditoIndividual " & Me.IdSclSocia & ",0, '" & InfoSistema.LoginName & "', " & intDelegacionSociaID & ", " & Me.IdStbBarrio & "," & Me.cboClasificacion.Columns("nSclTipodePlandeNegocioID").Value
            intGrupoID = XcDatos.ExecuteScalar(strSQL)

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If intGrupoID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("El Grupo Solidario se generó de forma satisfactoria.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/07/2009
    ' Procedure Name:       CargarClasificacion
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       clasificaciones económicas.
    '-------------------------------------------------------------------------
    Private Sub CargarClasificacion()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nSclTipodePlandeNegocioID, a.sDescripcion " & _
                     " FROM SclTipodePlandeNegocio a  " & _
                     " Where (a.nCreditoIndividual = 1 and (a.nCodigo=3  or  a.nCodigo=5))  " & _
                     " Order by a.nSclTipodePlandeNegocioID"

            If XdsClase.ExistTable("Clase") Then
                XdsClase("Clase").ExecuteSql(Strsql)
            Else
                XdsClase.NewTable(Strsql, "Clase")
                XdsClase("Clase").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboClasificacion.DataSource = XdsClase("Clase").Source

            'Ubicarse en el registro recomendado de parámetros:
            XdtValorParametro.Filter = "nStbParametroID = 62"
            XdtValorParametro.Retrieve()
            If XdsClase("Clase").Count > 0 Then
                XdsClase("Clase").SetCurrentByID("nSclTipodePlandeNegocioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo: 
            Me.cboClasificacion.Splits(0).DisplayColumns("nSclTipodePlandeNegocioID").Visible = False
            Me.cboClasificacion.Splits(0).DisplayColumns("sDescripcion").Width = 120
            Me.cboClasificacion.Columns("sDescripcion").Caption = "Tipo de Plan de Negocio"
            Me.cboClasificacion.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub cboClasificacion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboClasificacion.TextChanged
        vbModifico = True
    End Sub
End Class