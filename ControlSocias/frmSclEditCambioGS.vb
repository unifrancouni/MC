' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclEditCambioGS.vb
' Descripción:          Este formulario permite cambiar de grupo solidario 
'                       a una Ficha de Inscripcion (En Proceso, Pendiente 
'                       de Verificar o Verificada) para una determinada
'                       Socia del Progrma.
'-------------------------------------------------------------------------
Public Class frmSclEditCambioGS

    '-- Declaracion de Variables 
    Dim ModoForm As String

    '-- Llaves
    Dim IdSclSocia As Long
    Dim IdSclGrupoSolidario As Long

    '-- Datos del GS Actual
    Dim StrSclCodGrupo As String

    Dim StrSclNombreGrupo As String
    Dim StrSclCodFicha As String
    Dim StrSclNombreSocia As String
    Dim StrSclCedulaSocia As String

    '-- Clases para procesar la informacion del combo
    Dim XdtGrupoDestino As BOSistema.Win.XDataSet.xDataTable

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

    'Propiedad utilizada para obtener el Código del GS actual:
    Public Property StrCodGrupo() As String
        Get
            StrCodGrupo = StrSclCodGrupo
        End Get
        Set(ByVal value As String)
            StrSclCodGrupo = value
        End Set
    End Property

    'Propiedad utilizada para obtener el Nombre del GS actual:
    Public Property StrNombreGrupo() As String
        Get
            StrNombreGrupo = StrSclNombreGrupo
        End Get
        Set(ByVal value As String)
            StrSclNombreGrupo = value
        End Set
    End Property

    'Propiedad utilizada para obtener el Código de la Ficha:
    Public Property StrCodFicha() As String
        Get
            StrCodFicha = StrSclCodFicha
        End Get
        Set(ByVal value As String)
            StrSclCodFicha = value
        End Set
    End Property

    'Propiedad utilizada para obtener el Nombre de la Socia:
    Public Property StrNombreSocia() As String
        Get
            StrNombreSocia = StrSclNombreSocia
        End Get
        Set(ByVal value As String)
            StrSclNombreSocia = value
        End Set
    End Property

    'Propiedad utilizada para obtener Cédula de la Socia:
    Public Property StrCedulaSocia() As String
        Get
            StrCedulaSocia = StrSclCedulaSocia
        End Get
        Set(ByVal value As String)
            StrSclCedulaSocia = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmSclEditCambioGS_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global. 
    '-------------------------------------------------------------------------
    Private Sub frmSclEditCambioGS_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtGrupoDestino.Close()
                XdtGrupoDestino = Nothing

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
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmSclEditCambioGS_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se cargan datos de la Socia en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditCambioGS_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            'Ruta de Archvio de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarGrupoDestino()

            'Si el formulario está en modo edición
            'cargar los datos de la SociaGS
            CargarSociaGS()

            Me.cboGrupoDestino.Select()
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
    ' Fecha:                12/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Public Sub InicializarVariables()
        Try

            XdtGrupoDestino = New BOSistema.Win.XDataSet.xDataTable
            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar combo de GS Destino:
            Me.cboGrupoDestino.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
    ' Procedure Name:       CargarSociaGS
    ' Descripción:          Este procedimiento permite cargar los datos del GS actual
    '                       de la socia seleccionada.
    '-------------------------------------------------------------------------
    Public Sub CargarSociaGS()

        Try

            'Cargar Datos del Grupo Actual Inhabilitados:
            Me.txtCodigoGrupo.Text = StrSclCodGrupo
            Me.txtNombreGrupo.Text = StrSclNombreGrupo
            Me.txtCodigoFicha.Text = StrSclCodFicha
            Me.txtNombreSocia.Text = StrSclNombreSocia
            Me.txtCedulaSocia.Text = StrSclCedulaSocia

        Catch ex As Exception
            Control_Error(ex)
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
                SalvarCambioGrupo()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean

        Try
            ValidaDatosEntrada = True
            Me.errModulo.Clear()

            'Seleccionar Grupo Destino:
            If Me.cboGrupoDestino.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Grupo Destino.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errModulo.SetError(Me.cboGrupoDestino, "Debe seleccionar un Grupo Destino.")
                Me.cboGrupoDestino.Focus()
                Exit Function
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
    ' Procedure Name:       SalvarCambioGrupo
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-------------------------------------------------------------------------
    Public Sub SalvarCambioGrupo()

        Dim Trans As BOSistema.Win.Transact
        Dim ObjTmpFichaSocia As New BOSistema.Win.XDataSet
        Dim StrSql As String = ""
        Dim IdMaxSocias As String

        Trans = Nothing
        Try

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor

            'Encuentra número máximo de socias con fichas generadas en GS Destino:
            StrSql = " SELECT MAX(SUBSTRING(SclFichaSocia.sCodigo, 17, 2)) as maxCodigo " & _
                     " FROM  SclFichaSocia INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID " & _
                     " WHERE  (SclGrupoSocia.nSclGrupoSolidarioID = " & cboGrupoDestino.Columns("nSclGrupoSolidarioID").Value & ")"
            If ObjTmpFichaSocia.ExistTable("FichaSocia") Then
                ObjTmpFichaSocia("FichaSocia").ExecuteSql(StrSql)
            Else
                ObjTmpFichaSocia.NewTable(StrSql, "FichaSocia")
                ObjTmpFichaSocia("FichaSocia").Retrieve()
            End If
            If Not ObjTmpFichaSocia("FichaSocia").ValueField("maxCodigo") Is DBNull.Value Then
                IdMaxSocias = Format(ObjTmpFichaSocia("FichaSocia").ValueField("maxCodigo") + 1, "00")
            Else
                IdMaxSocias = "01"
            End If

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact

            'Inicio la Transaccion:
            Trans.BeginTrans()

            'Actualiza el campo; SclGrupoSocia.nSclGrupoSolidarioID con
            'el ID correspondiente del Grupo Destino:
            StrSql = "UPDATE SclGrupoSocia " & _
                     "SET nSclGrupoSolidarioID = " & cboGrupoDestino.Columns("nSclGrupoSolidarioID").Value & _
                     ", dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                     "WHERE (nSclGrupoSociaID = " & IdSclSocia & ")"
            Trans.ExecuteSql(StrSql)
            'Recalcula el nuevo Código de la(s) Ficha(s) y actualiza este en 
            'el campo: SclFichaSocia.sCodigo: Debe existir solo una Activa y
            'otras posibles fichas anuladas:
            StrSql = " Update SclFichaSocia " & _
                     " SET sCodigo = '" & cboGrupoDestino.Columns("sCodigo").Value & "-' + '" & IdMaxSocias & "' + Right(sCodigo,3)" & _
                     " WHERE (nSclGrupoSociaID = " & IdSclSocia & ")"
            Trans.ExecuteSql(StrSql)
            'Finaliza Transacción:
            Trans.Commit()
            MsgBox("El grupo fue modificado satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)

            'Guardar Pista de Auditoria:
            Call GuardarAuditoria(5, 15, "Modificación de Grupo Solidario a Socia " & StrNombreSocia & " (Cédula: " & StrCedulaSocia & ") de " & StrCodGrupo & " a " & cboGrupoDestino.Text)

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            Trans = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2007
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
                            SalvarCambioGrupo()
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
    ' Fecha:                12/09/2007
    ' Procedure Name:       CargarGrupoDestino
    ' Descripción:          Este procedimiento permite cargar el listado de GSs
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Public Sub CargarGrupoDestino()
        Try
            Dim Strsql As String = ""
            Strsql = " SELECT a.nSclGrupoSolidarioID, a.sCodigo, vwStbUbicacionGeografica.CodigoUbicacion, a.sDescripcion " & _
                     " FROM   SclGrupoSolidario AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoGrupoID = b.nStbValorCatalogoID INNER JOIN vwStbUbicacionGeografica ON a.nStbBarrioVerificadoID = vwStbUbicacionGeografica.nStbBarrioID " & _
                     " WHERE (a.nSclGrupoSolidarioID <> " & IdSclGrupoSolidario & ") AND (b.sCodigoInterno = '1') " & _
                     " ORDER BY a.sCodigo"

            XdtGrupoDestino.ExecuteSql(Strsql)
            Me.cboGrupoDestino.DataSource = XdtGrupoDestino.Source

            Me.cboGrupoDestino.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.cboGrupoDestino.Splits(0).DisplayColumns("CodigoUbicacion").Visible = False
            Me.cboGrupoDestino.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboGrupoDestino.Splits(0).DisplayColumns("sCodigo").Width = 80
            Me.cboGrupoDestino.Splits(0).DisplayColumns("sDescripcion").Width = 250

            Me.cboGrupoDestino.Columns("sCodigo").Caption = "Código"
            Me.cboGrupoDestino.Columns("sDescripcion").Caption = "Nombre Grupo Solidario"

            Me.cboGrupoDestino.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboGrupoDestino.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub cboGrupoDestino_Error(ByVal sender As Object, ByVal e As C1.Win.C1List.ErrorEventArgs) Handles cboGrupoDestino.Error
        Control_Error(e.Exception)
    End Sub

    'Se indica que hubo modificación en el Módulo
    Private Sub cboGrupoDestino_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboGrupoDestino.TextChanged
        vbModifico = True
        txtNombreGS.Text = cboGrupoDestino.Columns("sDescripcion").Value
    End Sub
End Class