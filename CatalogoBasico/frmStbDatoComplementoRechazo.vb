' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                07/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbDatoComplemento.vb
' Descripción:          Este formulario permite ingresar un dato Complementario.
'-------------------------------------------------------------------------
Public Class frmStbDatoComplementoRechazo
    Dim strPromptFrm As String
    Dim strTituloFrm As String
    Dim strMensajeFrm As String
    Dim strColorFrm As String
    Dim intAncholbl As Integer
    Dim strDatoFrm As String
    Dim intDatoMotivoFrm As Integer

    Dim strPropositoFrm As String
    Dim IdStbDatoComplemento As Long
    Dim XdsEscolaridad As BOSistema.Win.XDataSet
    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Permite recibir como parámetro el Prompt del dato a solicitar al usuario
    Public Property strPrompt() As String
        Get
            strPrompt = strPromptFrm
        End Get
        Set(ByVal value As String)
            strPromptFrm = value
        End Set
    End Property

    'Permite recibir como parámetro el Prompt del dato a solicitar al usuario
    Public Property strProposito() As String
        Get
            strProposito = strPropositoFrm
        End Get
        Set(ByVal value As String)
            strPropositoFrm = value
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

    'Permite recibir como parámetro el título del formulario
    Public Property strTitulo() As String
        Get
            strTitulo = strTituloFrm
        End Get
        Set(ByVal value As String)
            strTituloFrm = value
        End Set
    End Property

    'Permite recibir como parámetro el mensaje del Error
    Public Property strMensaje() As String
        Get
            strMensaje = strMensajeFrm
        End Get
        Set(ByVal value As String)
            strMensajeFrm = value
        End Set
    End Property

    'Permite recibir como parámetro el Prompt del dato a solicitar al usuario
    Public Property intAncho() As Integer
        Get
            intAncho = intAncholbl
        End Get
        Set(ByVal value As Integer)
            intAncholbl = value
        End Set
    End Property

    'Permite asignar el dato ingresado por el Usuario
    Public Property strDato() As String
        Get
            strDato = strDatoFrm
        End Get
        Set(ByVal value As String)
            strDatoFrm = value
        End Set
    End Property

    'Permite asignar el dato ingresado por el Usuario
    Public Property intDatoMotivo() As Integer
        Get
            intDatoMotivo = intDatoMotivoFrm
        End Get
        Set(ByVal value As Integer)
            intDatoMotivoFrm = value
        End Set
    End Property




    'Propiedad utilizada para obtener el ID de la tabla en la cual se actualizará
    'el dato complementario.
    Public Property IdDatoComplemento() As Long
        Get
            IdDatoComplemento = IdStbDatoComplemento
        End Get
        Set(ByVal value As Long)
            IdStbDatoComplemento = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                07/09/2007
    ' Procedure Name:       frmStbDatoComplemento_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbDatoComplemento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                XdsEscolaridad.Close()
                XdsEscolaridad = Nothing
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
    ' Fecha:                07/09/2007
    ' Procedure Name:       frmStbDatoComplemento_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y se cargan datos del Complemento en caso de estar en el modo 
    '                       de Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbDatoComplemento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)
            intDatoMotivo = 0
            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            CargarCarreraTecnica()
            Me.txtDato.Select()
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
    ' Fecha:                07/09/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Me.lblPrompt.Text = Me.strPromptFrm
            Me.Text = Me.strTituloFrm
            Me.txtDato.MaxLength = Me.intAncholbl
            XdsEscolaridad = New BOSistema.Win.XDataSet
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                07/09/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarDato()
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                07/09/2007
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try

            ValidaDatosEntrada = True

            'Debe indicar el dato complementario:
            'If Trim(RTrim(Me.txtDato.Text)).ToString.Length = 0 Then
            '    MsgBox(strMensaje, MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosEntrada = False
            '    Me.errDato.SetError(Me.txtDato, strMensaje)
            '    Me.txtDato.Focus()
            '    Exit Function
            'End If
            If cboCarreraTecnica.SelectedIndex = -1 Then
                MsgBox(strMensaje, MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errDato.SetError(Me.txtDato, strMensaje)
                Me.txtDato.Focus()
                Exit Function
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                07/09/2007
    ' Procedure Name:       SalvarDato
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Dato Complemento en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarDato()
        Try
            Me.strDatoFrm = Me.txtDato.Text
            Me.intDatoMotivo = Me.cboCarreraTecnica.Columns("nStbValorCatalogoID").Value
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                07/09/2007
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If (vbModifico = True) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            AccionUsuario = AccionBoton.BotonAceptar
                            Me.Close()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case vbNo
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.strDato = ""
                        intDatoMotivo = 0
                        Me.Close()

                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else

                intDatoMotivo = 0
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Solo se permiten caracteres indicados en función TextoValido
    Private Sub txtDato_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDato.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Se indica que hubo modificación en el dato
    Private Sub txtDato_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDato.TextChanged
        vbModifico = True
    End Sub


    Private Sub CargarCarreraTecnica()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'CausasRechazoCredito') " & _
                         " ORDER BY a.sCodigoInterno"

            If XdsEscolaridad.ExistTable("CarreraTecnica") Then
                XdsEscolaridad("CarreraTecnica").ExecuteSql(Strsql)
            Else
                XdsEscolaridad.NewTable(Strsql, "CarreraTecnica")
                XdsEscolaridad("CarreraTecnica").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCarreraTecnica.DataSource = XdsEscolaridad("CarreraTecnica").Source

            Me.cboCarreraTecnica.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").Width = 200

            Me.cboCarreraTecnica.Columns("sCodigoInterno").Caption = "Código"
            Me.cboCarreraTecnica.Columns("sDescripcion").Caption = "Descripción"

            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Me.cboCarreraTecnica.Width = 600
            'Ubicarlo en el primer registro:
            If Me.cboCarreraTecnica.ListCount > 0 Then
                Me.cboCarreraTecnica.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class