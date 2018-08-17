' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                04/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditSociaGS.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de las Socias de un Grupo Solidario.
'-------------------------------------------------------------------------
Public Class frmSclEditSociaGS

    '-- Declaracion de Variables 
    Dim ModoForm As String
    Dim IdSclSocia As Long
    Dim IdSclGrupoSolidario As Long
    Dim XContadorReg As Integer
    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable

    '-- Indicar por defecto Primer integrante como la Coordinadora del GS
    Dim nSclNumeroSocias As Integer

    '-- Clases para procesar la informacion de los combos
    Dim XdtSocia As BOSistema.Win.XDataSet.xDataTable

    '-- Crear un data table de tipo Xdataset
    Dim ObjGrupoSociadt As BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
    Dim ObjGrupoSociadr As BOSistema.Win.SclEntSocia.SclGrupoSociaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclGrupoSociaID de la tabla SclGrupoSocia.
    Public Property IdSocia() As Long
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Long)
            IdSclSocia = value
        End Set
    End Property

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property NumSocias() As String
        Get
            NumSocias = nSclNumeroSocias
        End Get
        Set(ByVal value As String)
            nSclNumeroSocias = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del GS que corresponde al campo
    'nSclGrupoSolidarioID de la tabla SclGrupoSolidario.
    Public Property IdGrupoSolidario() As Long
        Get
            IdGrupoSolidario = IdSclGrupoSolidario
        End Get
        Set(ByVal value As Long)
            IdSclGrupoSolidario = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       frmSclEditSociaGS_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global. 
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSociaGS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                
                XdtSocia.Close()
                XdtSocia = Nothing

                ObjGrupoSociadt.Close()
                ObjGrupoSociadt = Nothing

                ObjGrupoSociadr.Close()
                ObjGrupoSociadr = Nothing

                XdtDatos.Close()
                XdtDatos = Nothing

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
    ' Fecha:                04/09/2007
    ' Procedure Name:       frmSclEditSociaGS_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSociaGS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            'CargarSocia(0)

            'Si el formulario está en modo edición
            'cargar los datos de la SociaGS.
            If ModoFrm = "UPD" Then
                CargarSociaGS()
            End If

            Me.mtbNumCedula.Select()
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
    ' Fecha:                04/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Socia"
            Else
                Me.Text = "Modificar Socia"
            End If

            'Primer socia del Grupo:
            If nSclNumeroSocias = 0 Then Me.chkCoordinadora.Checked = True

            ObjGrupoSociadt = New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
            ObjGrupoSociadr = New BOSistema.Win.SclEntSocia.SclGrupoSociaRow
            XdtSocia = New BOSistema.Win.XDataSet.xDataTable

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            'Me.cboSocia.ClearFields()
            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            Me.grpBotones.Enabled = False
            XContadorReg = 0

            If ModoFrm = "ADD" Then
                ObjGrupoSociadr = ObjGrupoSociadt.NewRow
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       CargarSociaGS
    ' Descripción:          Este procedimiento permite cargar los datos de la Socia
    '                       seleccionada en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Public Sub CargarSociaGS()

        Dim XdtSclFicha As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        XdtSclFicha = New BOSistema.Win.XDataSet.xDataTable

        Try

            Dim strSQL As String

            'En caso que se esté editando una filtrar para esta socia:
            ObjGrupoSociadt.Filter = "nSclGrupoSociaID = " & IdSclSocia
            ObjGrupoSociadt.Retrieve()
            If ObjGrupoSociadt.Count = 0 Then
                Exit Sub
            End If
            ObjGrupoSociadr = ObjGrupoSociadt.Current

            'Cargar Socia:
            If Not ObjGrupoSociadr.IsFieldNull("nSclSociaID") Then
                'Cédula:
                strSQL = "SELECT sNumeroCedula FROM SclSocia " & _
                         "WHERE (nSclSociaID = " & ObjGrupoSociadr.nSclSociaID & ")"
                Me.mtbNumCedula.Text = XcDatos.ExecuteScalar(strSQL)
                'Nombre:
                strSQL = "SELECT SclSocia.sNombre1 + ' ' + dbo.SclSocia.sNombre2 + ' ' + dbo.SclSocia.sApellido1 + ' ' + dbo.SclSocia.sApellido2 as Nombre " & _
                         "FROM SclSocia WHERE (nSclSociaID = " & ObjGrupoSociadr.nSclSociaID & ")"
                Me.txtNombreSocia.Text = XcDatos.ExecuteScalar(strSQL)
                Me.txtNombreSocia.Tag = ObjGrupoSociadr.nSclSociaID
            End If

            'Cargar Coordinadora:
            Me.chkCoordinadora.Checked = ObjGrupoSociadr.nCoordinador

            ''Activar / Desactivar combo de socias:
            ''Validar registros relacionados en la tabla SclFichaSocia con 
            ''Estado <> En Proceso (sCodigoInterno = 1 en StbValorCatalogo):
            ''En estos casos no se permite cambiar el nombre de la socia sino
            ''unicamente desde la pantalla de cambio de grupo:
            'Strsql = " SELECT a.nSclGrupoSociaID " & _
            '         " FROM   SclFichaSocia a INNER JOIN StbValorCatalogo b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID  " & _
            '         " WHERE  (a.nSclGrupoSociaID = " & IdSclSocia & ") AND (b.sCodigoInterno <> '1')"
            'XdtSclFicha.ExecuteSql(Strsql)
            'If XdtSclFicha.Count > 0 Then
            '    cboSocia.Enabled = False
            'Else
            '    cboSocia.Enabled = True
            'End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtSclFicha.Close()
            XdtSclFicha = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarSocia()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean

        Dim ObjDatosDT As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable
        Dim XdtSclFicha As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        XdtSclFicha = New BOSistema.Win.XDataSet.xDataTable

        Try
            ValidaDatosEntrada = True
            Me.errModulo.Clear()

            'Seleccionar Socia:
            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'Cedula Socia debe existir en Catálogo de Socias:
            Strsql = "SELECT nSclSociaID FROM  SclSocia WHERE (nSociaActiva =1) and (nDispuestaFormarGS = 1) and (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("No existe socia ACTIVA con este Número de Cédula.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "No existe socia con este Número de Cédula.")
                Me.mtbNumCedula.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Debe haberse localizado una Socia o cargarse la actual:
            If (Me.txtNombreSocia.Text = "") Or (Me.txtNombreSocia.Tag = 0) Then
                MsgBox("Debe buscar la Socia a Ingresar.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "Debe buscar la Socia a Ingresar.")
                Me.mtbNumCedula.Focus()
                ValidaDatosEntrada = False
                Exit Function
            End If

            'Verificar si la Delegación de la Socia es la misma del GS: 
            REM Unicamente Validar si la Delegación es Managua, Chinandega o León (28/10/2009):
            REM Esto debido a modificaciones de adicion de la delegacion con base en el GS y no en el Usuario.
            Strsql = "SELECT nSclGrupoSolidarioID FROM SclGrupoSolidario " & _
                     "WHERE (nStbDelegacionProgramaID = 1 OR nStbDelegacionProgramaID = 2 OR nStbDelegacionProgramaID = 8) AND (nSclGrupoSolidarioID = " & Me.IdSclGrupoSolidario & ")"
            If RegistrosAsociados(Strsql) Then
                Strsql = " SELECT SclSocia.nSclSociaID " & _
                                     " FROM SclSocia INNER JOIN SclGrupoSolidario ON SclSocia.nStbDelegacionProgramaID = SclGrupoSolidario.nStbDelegacionProgramaID " & _
                                     " WHERE (SclSocia.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (SclGrupoSolidario.nSclGrupoSolidarioID = " & Me.IdSclGrupoSolidario & ")"
                If RegistrosAsociados(Strsql) = False Then
                    MsgBox("La Delegación de la Socia no corresponde" & Chr(13) & "con la del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errModulo.SetError(Me.mtbNumCedula, "Debe seleccionar una Socia válida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
            End If

            'Validar si la socia seleccionada ya forma parte del GS actual:
            If ModoForm = "UPD" Then
                ObjDatosDT.Filter = " nSclSociaID = " & Me.txtNombreSocia.Tag & " And nSclGrupoSolidarioID = " & Me.IdSclGrupoSolidario & " And nSclGrupoSociaID <> " & Me.IdSclSocia
            Else
                ObjDatosDT.Filter = " nSclSociaID = " & Me.txtNombreSocia.Tag & " And nSclGrupoSolidarioID = " & Me.IdSclGrupoSolidario
            End If
            ObjDatosDT.Retrieve()
            If ObjDatosDT.Count > 0 Then
                MsgBox("La socia ya forma parte del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.mtbNumCedula, "La socia ya forma parte del Grupo Solidario.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'Validar si Socia se encuentra en Otro GS En Proceso:
            If ModoFrm = "UPD" Then
                Strsql = " SELECT a.nSclSociaID " & _
                         " FROM  SclGrupoSocia a INNER JOIN SclGrupoSolidario b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo c ON b.nStbEstadoGrupoID = c.nStbValorCatalogoID  " & _
                         " WHERE (a.nSclGrupoSociaID <> " & IdSclSocia & ") AND (a.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (c.sCodigoInterno = '1')"
            Else
                Strsql = " SELECT a.nSclSociaID " & _
                         " FROM  SclGrupoSocia a INNER JOIN SclGrupoSolidario b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo c ON b.nStbEstadoGrupoID = c.nStbValorCatalogoID  " & _
                         " WHERE (a.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (c.sCodigoInterno = '1')"
            End If
            XdtSclFicha.ExecuteSql(Strsql)
            If XdtSclFicha.Count > 0 Then
                MsgBox("La socia ya forma parte de otro Grupo Solidario En Proceso.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.mtbNumCedula, "La socia ya forma parte de otro Grupo Solidario En Proceso.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            REM 10/10/2008 ABOLIDA por Beyra: Que unicamente se bloquee cuando se Aprueba la FNC.
            'La Socia no debe tener malas referencias Activas asignadas:
            'Strsql = " SELECT nSclReferenciaSociaID FROM SclReferenciaSocia " & _
            '         " WHERE (nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (nActiva = 1)"
            'If RegistrosAsociados(Strsql) Then
            '    MsgBox("La socia tiene malas referencias personales asociadas.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errModulo.SetError(Me.mtbNumCedula, "La socia tiene malas referencias personales asociadas.")
            '    Me.mtbNumCedula.Focus()
            '    Exit Function
            'End If

            'Validar si la socia seleccionada se encuentra en una Ficha Activa
            '(<> Rechazada (6), <> Anulada (4) y Cancelada (7)) en este u otro GS:
            Strsql = " SELECT  a.nSclGrupoSociaID " & _
                     " FROM    SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID  " & _
                     " WHERE   (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & Me.txtNombreSocia.Tag & ")"
            REM Y QUE LA FUENTE ES DE FONDOS PRESUPUESTARIOS: ABOLIDA A PARTIR DE 02/Ene/2009 por asignaciones dobles de prestamos a socias
            REM para lo cual se adiciono boton de cancelar manualmente las Fichas de Inscripcion del Grupo Solidario.
            'Strsql = " SELECT  a.nSclGrupoSociaID " & _
            '         " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
            '         " INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
            '         " INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
            '         " INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoFNC ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoFNC.nStbValorCatalogoID " & _
            '         " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND ((EstadoFNC.sCodigoInterno <> '4') AND (EstadoFNC.sCodigoInterno <> '5'))"
            XdtSclFicha.ExecuteSql(Strsql)
            If XdtSclFicha.Count > 0 Then
                MsgBox("La socia tiene Fichas registradas aún no Canceladas.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.mtbNumCedula, "La socia tiene Fichas registradas aún no Canceladas.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'Validar si la Socia forma parte de un grupo donde NO fue Rechazada O ANULADA y donde existe al menos 
            'una Ficha (Activa) (<> Rechazada (6), <> Anulada (4) y Cancelada (7)) en este u otro GS:

            ' Antes si no reestablecer

            Strsql = " SELECT c.nSclGrupoSolidarioID, SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sNumeroCedula " & _
                     " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN SclSocia ON c.nSclSociaID = SclSocia.nSclSociaID " & _
                     " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') " & _
                     " AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (SclGrupoSocia.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4')))"





            'Probar con Sheila  

            '            Strsql = " SELECT     c.nSclGrupoSolidarioID, dbo.SclSocia.sNombre1 + ' ' + dbo.SclSocia.sNombre2 + ' ' + dbo.SclSocia.sApellido1 + ' ' + dbo.SclSocia.sApellido2 AS Socia, " & _
            '                    "   dbo.SclSocia.sNumeroCedula, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion,  " & _
            '          "   dbo.SclFichaNotificacionDetalle.nCreditoRechazado " & _
            '" FROM         dbo.SclFichaSocia AS a INNER JOIN " & _
            '  "                     dbo.StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN " & _
            '                      " dbo.SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN " & _
            '                      " dbo.SclSocia ON c.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN " & _
            '                      " dbo.SclFichaNotificacionDetalle ON a.nSclFichaSociaID = dbo.SclFichaNotificacionDetalle.nSclFichaSociaID INNER JOIN " & _
            '                      " dbo.SclFichaNotificacionCredito ON  " & _
            '                      " dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN " & _
            '                      " dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID " & _
            '" WHERE     (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclGrupoSolidarioID IN " & _
            '  "                         (SELECT     dbo.SclGrupoSocia.nSclGrupoSolidarioID " & _
            '    "                         FROM          dbo.SclGrupoSocia INNER JOIN  dbo.SclFichaSocia ON dbo.SclGrupoSocia.nSclGrupoSociaID = dbo.SclFichaSocia.nSclGrupoSociaID INNER JOIN  dbo.StbValorCatalogo AS StbValorCatalogo_1 ON    dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID    " & _
            '     "                    WHERE      (dbo.SclGrupoSocia.nSclSociaID = 10489) AND (StbValorCatalogo_1.sCodigoInterno <> '6') AND   " & _
            '      "                                             (StbValorCatalogo_1.sCodigoInterno <> '4'))) AND (dbo.StbValorCatalogo.sCodigoInterno <> '3' AND " & _
            '              "         dbo.StbValorCatalogo.sCodigoInterno <> '4' AND dbo.StbValorCatalogo.sCodigoInterno <> '5') "


















            REM Y QUE LA FUENTE ES DE FONDOS PRESUPUESTARIOS. PARA FNC <> ANULADAS (4 y 5). ABOLIDA A PARTIR DE 02/Ene/2009 por asignaciones dobles de prestamos a socias
            REM para lo cual se adiciono boton de cancelar manualmente las Fichas de Inscripcion del Grupo Solidario.
            'Strsql = " SELECT c.nSclGrupoSolidarioID, SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sNumeroCedula " & _
            '         " FROM  SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID " & _
            '         " INNER JOIN SclSocia ON c.nSclSociaID = SclSocia.nSclSociaID INNER JOIN SclFichaNotificacionDetalle ON a.nSclFichaSociaID = SclFichaNotificacionDetalle.nSclFichaSociaID  INNER JOIN SccSolicitudDesembolsoCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID " & _
            '         " INNER JOIN SccSolicitudCheque ON SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID  INNER JOIN ScnFuenteFinanciamiento ON SccSolicitudCheque.nScnFuenteFinanciamientoID = ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID " & _
            '         " INNER JOIN SclFichaNotificacionCredito ON SclFichaNotificacionDetalle.nSclFichaNotificacionID = SclFichaNotificacionCredito.nSclFichaNotificacionID INNER JOIN StbValorCatalogo AS EstadoCredito ON SclFichaNotificacionCredito.nStbEstadoCreditoID = EstadoCredito.nStbValorCatalogoID " & _
            '         " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') " & _
            '         " AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         " WHERE (SclGrupoSocia.nSclSociaID = " & Me.txtNombreSocia.Tag & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4'))) AND (ScnFuenteFinanciamiento.nFondoPresupuestario = 1) AND (EstadoCredito.sCodigoInterno <> '4' AND EstadoCredito.sCodigoInterno <> '5')"
            XdtSclFicha.ExecuteSql(Strsql)
            If XdtSclFicha.Count > 0 Then
                'If RegistrosAsociados(Strsql) Then
                MsgBox("La socia forma parte de un Grupo Solidario" & Chr(13) & "en el cual existe la Socia con Fichas aún no" & Chr(13) & "Canceladas: " & Chr(13) & Chr(13) & "Cédula: " & XdtSclFicha.ValueField("sNumeroCedula") & Chr(13) & "Nombre: " & XdtSclFicha.ValueField("Socia") & ".", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.mtbNumCedula, "Otra(s) Integrante(s) del Grupo Solidario tiene(n) Fichas aún no Canceladas.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjDatosDT.Close()
            ObjDatosDT = Nothing

            XdtSclFicha.Close()
            XdtSclFicha = Nothing
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       SalvarSocia
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub SalvarSocia()
        Try
            Dim StrSql As String

            If ModoFrm = "ADD" Then
                ObjGrupoSociadr.NewRow()
                ObjGrupoSociadr.sUsuarioCreacion = InfoSistema.LoginName
                ObjGrupoSociadr.dFechaCreacion = FechaServer()
                ObjGrupoSociadr.nCreditoRechazado = 0
            Else
                ObjGrupoSociadr.sUsuarioModificacion = InfoSistema.LoginName
                ObjGrupoSociadr.dFechaModificacion = FechaServer()
            End If

            ObjGrupoSociadr.nSclSociaID = Me.txtNombreSocia.Tag
            'ObjGrupoSociadr.nSclSociaID = cboSocia.Columns("nSclSociaID").Value 'XdtSocia.ValueField("nSclSociaID")
            ObjGrupoSociadr.nSclGrupoSolidarioID = Me.IdSclGrupoSolidario

            'Confirma si no se ha ingresado una coordinadora:
            If ModoForm = "ADD" Then
                StrSql = "SELECT nSclGrupoSociaID FROM SclGrupoSocia WHERE (nSclGrupoSolidarioID = " & Me.IdSclGrupoSolidario & ") AND (nCoordinador = 1)"
                If RegistrosAsociados(StrSql) = False Then 'No existe Coordinadora.
                    ObjGrupoSociadr.nCoordinador = 1
                Else
                    ObjGrupoSociadr.nCoordinador = 0
                End If
            End If

            'If Me.chkCoordinadora.Checked Then
            '    ObjGrupoSociadr.nCoordinador = 1
            'Else
            '    ObjGrupoSociadr.nCoordinador = 0
            'End If
            ObjGrupoSociadr.Update()

            'Asignar el Id del Grupo Socia a la 
            'variable publica del formulario:
            IdSclSocia = ObjGrupoSociadr.nSclGrupoSociaID

            If Me.IdSclSocia = 0 Then
                MsgBox("El registro NO PUDO Grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                'Si el salvado se realizó de forma satisfactoria0
                'enviar mensaje informando y cerrar el formulario.
                If ModoFrm = "ADD" Then
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
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
                            SalvarSocia()
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       CargarSocia
    ' Descripción:          Este procedimiento permite cargar el listado de Socias
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    'Public Sub CargarSocia(ByVal IDSocia As Integer)
    '    Try
    '        Dim Strsql As String = ""
    '        If IDSocia = 0 Then
    '            Strsql = " SELECT a.nSclSociaID, a.sNumeroCedula, a.NombreSocia " & _
    '                     " FROM vwSclSocia a " & _
    '                     " WHERE (a.nSociaActiva =1) and (a.nDispuestaFormarGS = 1) " & _
    '                     " ORDER BY a.sNumeroCedula"

    '        Else
    '            'And (a.nStbBarrioID In (Select nStbBarrioVerificadoID From SclGrupoSolidario Where nSclGrupoSolidarioID = " & Me.IdSclGrupoSolidario & ")) " & _
    '            Strsql = " SELECT a.nSclSociaID, a.sNumeroCedula, a.NombreSocia " & _
    '                     " FROM vwSclSocia a " & _
    '                     " WHERE (nSclSociaID = " & IDSocia & ")  " & _
    '                     " Or ((a.nSociaActiva =1) and (a.nDispuestaFormarGS = 1)) " & _
    '                     " ORDER BY a.sNumeroCedula"
    '        End If

    '        XdtSocia.ExecuteSql(Strsql)
    '        Me.cboSocia.DataSource = XdtSocia.Source

    '        Me.cboSocia.Splits(0).DisplayColumns("nSclSociaID").Visible = False
    '        Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '        'Configurar el combo
    '        Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 110
    '        Me.cboSocia.Splits(0).DisplayColumns("NombreSocia").Width = 280

    '        Me.cboSocia.Columns("sNumeroCedula").Caption = "Cédula"
    '        Me.cboSocia.Columns("NombreSocia").Caption = "Nombre Socia"

    '        Me.cboSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
    '        Me.cboSocia.Splits(0).DisplayColumns("NombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    'Se indica que hubo modificación en el Estado de Activo
    Private Sub chkCoordinadora_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkCoordinadora.CheckedChanged
        vbModifico = True
    End Sub

    'Para controlar la ubicación del foco en el checkbox
    Private Sub chkCoordinadora_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCoordinadora.GotFocus
        Try
            Me.chkCoordinadora.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Para controlar cuando el checkbox pierde el foco
    Private Sub chkCoordinadora_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkCoordinadora.LostFocus
        Try
            Me.chkCoordinadora.BackColor = Me.grpSocia.BackColor
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try
            Dim Strsql As String
            Me.errModulo.Clear()

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Sub
            End If

            'Cedula Socia debe existir en Catálogo de Socias:
            Strsql = "SELECT nSclSociaID FROM  SclSocia WHERE (nSociaActiva =1) and (nDispuestaFormarGS = 1) and (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("No existe socia ACTIVA con este Número de Cédula.", MsgBoxStyle.Critical, NombreSistema)
                Me.errModulo.SetError(Me.mtbNumCedula, "No existe socia ACTIVA con este Número de Cédula.")
                Me.mtbNumCedula.Focus()
                Me.txtNombreSocia.Text = ""
                Me.txtNombreSocia.Tag = 0
                Exit Sub
            End If

            XContadorReg = 0
            Strsql = " SELECT a.nSclSociaID, a.sNumeroCedula, a.NombreSocia " & _
                     " FROM vwSclSocia a " & _
                     " WHERE (a.nSociaActiva =1) and (a.nDispuestaFormarGS = 1) " & _
                     " AND (a.sNumeroCedula = '" & Me.mtbNumCedula.Text & "') " & _
                     " ORDER BY a.NombreSocia"
            XdtDatos.ExecuteSql(Strsql)
            If XdtDatos.Count > 1 Then
                grpBotones.Enabled = True
            Else
                grpBotones.Enabled = False
            End If
            PresentaSocia()
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub PresentaSocia()
        Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreSocia")
        Me.txtNombreSocia.Tag = XdtDatos.Table.Rows(XContadorReg).Item("nSclSociaID")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaSocia()
    End Sub

    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSocia()
    End Sub

    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Esta sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSocia()
    End Sub

    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Esta sobre el ultimo registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSocia()
    End Sub

    Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
        vbModifico = True
        Me.txtNombreSocia.Text = ""
        Me.txtNombreSocia.Tag = 0
    End Sub
End Class