' ------------------------------------------------------------------------
' Project Item Name:    frmSclEditSociaCedula.vb
' Descripci�n:          Este formulario permite ingresar o modificar datos
'                       en el Cat�logo de Conyuges de Socias.
'-------------------------------------------------------------------------
Imports System.io

Public Class frmSclEditSociaCedula
    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSclSocia As Long 'SclSocia.nSclSociaID
    Dim strCedulaSocia As String
    Dim strNombreSocia As String
    Dim StrFecha As String

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean
    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo nSclSociaID de la tabla SclSocia.
    Public Property IdSocia() As Long
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Long)
            IdSclSocia = value
        End Set
    End Property

    Public Property NombreSocia() As String
        Get
            NombreSocia = strNombreSocia
        End Get
        Set(ByVal value As String)
            strNombreSocia = value
        End Set
    End Property

    Public Property CedulaSocia() As String
        Get
            CedulaSocia = strCedulaSocia
        End Get
        Set(ByVal value As String)
            strCedulaSocia = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Procedure Name:       frmSclEditSociaCedula_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclEditSociaCedula_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ---------------------------------------------------------------------------------------------------------------
    ' Procedure Name:       frmSclEditSociaCedula_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan variables y se cargan datos de la Socia 
    '                       en caso de estar en el modo de Modificar.
    '----------------------------------------------------------------------------------------------------------------
    Private Sub frmSclEditSociaCedula_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Dim XdtTmpConsulta As New BOSistema.Win.XDataSet.xDataTable

        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            Seg.RefreshPermissions()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       InicializarVariables
    ' Descripci�n:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            Me.txtSocia.Text = Me.NombreSocia
            Me.mtbNumCedula_Vieja.Text = Me.CedulaSocia
            Me.mtbNumCedula.Select()
            Me.cmdAceptar.Enabled = False
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       CmdAceptar_click
    ' Descripci�n:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                If ValidarCedula() Then
                    SalvarSocia()
                    AccionUsuario = AccionBoton.BotonAceptar
                    Me.Close()
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripci�n:          Esta funci�n permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaDataTable

        Try

            ValidaDatosEntrada = True
            Me.errSocia.Clear()

            'N�mero de C�dula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El N�mero de C�dula de la Socia NO DEBE quedar vac�o.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.mtbNumCedula, "El N�mero de C�dula de la Socia NO DEBE quedar vac�o.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'NO validar N�mero de C�dula si no corresponde a Formato: Y establecer como fecha de nacimiento: 30/05/1964
            If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                StrFecha = "30/05/1964"
            Else
                'Fecha v�lida en n�mero de C�dula:
                StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
                If Not IsDate(StrFecha) Then
                    MsgBox("El N�mero de C�dula debe contener una fecha v�lida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El N�mero de C�dula debe contener una fecha v�lida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

                'Determinar Duplicados en el N�mero de C�dula:
                'If ModoFrm = "UPD" Then
                ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSclSociaID <> " & IdSocia
                'Else
                '    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" ' And nSclSociaID = " & IdSocia
                'End If
                ObjTmpSocia.Retrieve() 'Obtener los datos filtrados.
                If ObjTmpSocia.Count > 0 Then
                    MsgBox("El N�mero de C�dula NO DEBE de repetirse.", MsgBoxStyle.Critical, NombreSistema)
                    'If Not MsgBox("El N�mero de C�dula NO DEBERIA de repetirse." & Chr(13) & "�Desea continuar con esta C�dula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                    'Me.txtNombre1.Text = ""
                    'Me.txtNombre2.Text = ""
                    'Me.txtApellido1.Text = ""
                    'Me.txtApellido2.Text = ""
                    'Me.mtbNumCedula.Text = ""
                    'Me.mtbNumCedula.Focus()
                    ValidaDatosEntrada = False
                    Exit Function
                    'End If
                End If

                'N�mero de C�dula V�lido:
                Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                    Case Cedula.Invalida
                        MsgBox("El N�mero de C�dula de la Socia es inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "El N�mero de C�dula de la Socia es inv�lido.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Case Cedula.LongitudIncorrecta
                        MsgBox("La Longitud del N�mero de C�dula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "La Longitud del N�mero de C�dula de la Socia es incorrecta.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                End Select
            End If

        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjTmpSocia.Close()
            ObjTmpSocia = Nothing
        End Try
    End Function

    ' ----------------------------------------------------------------------------------
    ' Procedure Name:       SalvarSocia
    ' Descripci�n:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-----------------------------------------------------------------------------------
    Private Sub SalvarSocia()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim Ficha_Notificacion As Integer
        Dim StrConsulta As String, strSQL As String
        Dim XdtTmpConsulta As New BOSistema.Win.XDataSet.xDataTable

        Try

            'N�mero de C�dula:
            If Me.CedulaSocia <> Trim(RTrim(Me.mtbNumCedula.Text)) Then
                ' INSERTAR UN NUEVO REGISTRO EN SclSociaCedula
                StrConsulta = " SELECT MAX(FNC.nSclFichaNotificacionID) AS nSclFichaNotificacionID " & _
                              " FROM       dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " & _
                              "            dbo.SclFichaNotificacionDetalle AS FND ON FNC.nSclFichaNotificacionID = FND.nSclFichaNotificacionID INNER JOIN " & _
                              "            dbo.SclGrupoSolidario AS GS ON FNC.nSclGrupoSolidarioID = GS.nSclGrupoSolidarioID INNER JOIN " & _
                              "            dbo.SclGrupoSocia AS GSoc ON GS.nSclGrupoSolidarioID = GSoc.nSclGrupoSolidarioID INNER JOIN " & _
                              "            dbo.SclSocia AS Socia ON GSoc.nSclSociaID = Socia.nSclSociaID " & _
                              " WHERE      Socia.nSclSociaID = " & Me.IdSclSocia
                XdtTmpConsulta.ExecuteSql(StrConsulta)

                If XdtTmpConsulta.Count > 0 Then
                    If Not IsDBNull(XdtTmpConsulta.ValueField("nSclFichaNotificacionID")) Then
                        Ficha_Notificacion = XdtTmpConsulta.ValueField("nSclFichaNotificacionID")
                    Else
                        Ficha_Notificacion = 0
                    End If
                End If

                strSQL = "Insert Into SclSociaCedula " & _
                         "(nSclSociaID, Cedula_Anterior, Cedula_Nueva, nSclFichaNotificacionID, sUsuarioCreacion, dFechaCreacion) " & _
                         " Values (" & Me.IdSclSocia & ", '" & Me.CedulaSocia & "', '" & Trim(RTrim(Me.mtbNumCedula.Text)) & "'" & _
                         " , " & Ficha_Notificacion & ", '" & InfoSistema.LoginName & "', '" & Format(FechaServer(), "yyyy/MM/dd") & "')"
                XcDatos.ExecuteNonQuery(strSQL)

                strSQL = "UPDATE SclSocia Set sNumeroCedula='" & Trim(RTrim(Me.mtbNumCedula.Text)) & "' Where nSclSociaID=" & Me.IdSclSocia
                XcDatos.ExecuteNonQuery(strSQL)

                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
                Me.CedulaSocia = Trim(RTrim(Me.mtbNumCedula.Text))

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub

    ' ----------------------------------------------------------------------------------
    ' Procedure Name:       cmdCancelar_Click
    ' Descripci�n:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-----------------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object
            'Si tenemos permiso para modificar
            If Me.cmdAceptar.Enabled Then

                If vbModifico = True Then
                    res = MsgBox("�Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
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
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mtbNumCedula_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles mtbNumCedula.TextChanged
        Try
            'MsgBox(Len(mtbNumCedula.Text))
            'If (mtbNumCedula.Text) > 11 Then
            cmdAceptar.Enabled = True
            'End If
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Procedure name                :     BlnCedulaValidaPadron
    ' Description                   :     Indica si una Cedula existe en la BD del Padr�n.
    ' -----------------------------------------------------------------------------------------
    Public Function BlnCedulaValidaPadron(ByVal sCedula As String, ByVal ModificarNombreSocia As Boolean, ByVal searchPadron As Boolean) As Boolean
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim XdtTmpConsulta2 As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta2 = New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim StrConsulta As String
            BlnCedulaValidaPadron = False

            If searchPadron And Me.ModoForm.Equals("ADD") Then

                StrConsulta = "SELECT ISNULL(sNombre1, '') AS sNombre1, ISNULL(sNombre2, '') AS sNombre2, ISNULL(sApellido1, '') AS sApellido1, ISNULL(sApellido2, '')  AS sApellido2, sSexo " & _
                                             "FROM [SMCU0-Padron].dbo.SclCatalogoPersona " & _
                                             "WHERE (sNumeroCedula = '" & sCedula & "')"
                XdtTmpConsulta.ExecuteSql(StrConsulta)
                If XdtTmpConsulta.Count > 0 Then
                    BlnCedulaValidaPadron = True
                    'Me.txtNombre1.Text = XdtTmpConsulta.ValueField("sNombre1")
                    'Me.txtNombre2.Text = XdtTmpConsulta.ValueField("sNombre2")
                    'Me.txtApellido1.Text = XdtTmpConsulta.ValueField("sApellido1")
                    'Me.txtApellido2.Text = XdtTmpConsulta.ValueField("sApellido2")
                End If
            Else
                
            End If

        Catch ex As Exception
            Control_Error(ex)
            BlnCedulaValidaPadron = False
        Finally
            XdtTmpConsulta.Close()
            XdtTmpConsulta = Nothing
        End Try
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Procedure name                :     CedulaRepetida
    ' Description                   :     verifica si una c�dula que no est� en el padron,
    '                                     se encuentra repetida.
    ' -----------------------------------------------------------------------------------------
    Public Function CedulaRepetida(ByVal sCedula As String) As String
        Dim XdtTmpConsulta As BOSistema.Win.XDataSet.xDataTable
        XdtTmpConsulta = New BOSistema.Win.XDataSet.xDataTable
        Dim resultado As String = String.Empty
        Try
            Dim StrConsulta As String

            StrConsulta = "select * " & _
                           "from SclSociaConyuge s " & _
                           "where s.sNumeroCedula = '" & sCedula & "'" & _
                           "      and s.nSociaActiva = 1 "

            XdtTmpConsulta.ExecuteSql(StrConsulta)
            If XdtTmpConsulta.Count > 0 Then

                'Ubicar Nombres:
                resultado = XdtTmpConsulta.ValueField("sNombre1") + " "
                resultado += XdtTmpConsulta.ValueField("sNombre2") + " "
                resultado += XdtTmpConsulta.ValueField("sApellido1") + ""
                resultado += XdtTmpConsulta.ValueField("sApellido2")
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpConsulta.Close()
            XdtTmpConsulta = Nothing
        End Try
        Return resultado
    End Function

    ' -----------------------------------------------------------------------------------------
    ' Procedure name                :     cmdBuscar_Click
    ' Description                   :     Busca una Cedula en la BD del Padr�n.
    ' -----------------------------------------------------------------------------------------
    Private Function ValidarCedula() As Boolean
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaDataTable
        Dim ModificarNombreSocia As Boolean = False
        Dim posCedula As Integer, strCedula As String

        Try
            Me.errSocia.Clear()
            ValidarCedula = True
            ''Limpiar Nombres y Apellidos:
            'Me.txtNombre1.Text = ""
            'Me.txtNombre2.Text = ""
            'Me.txtApellido1.Text = ""
            'Me.txtApellido2.Text = ""

            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El N�mero de C�dula NO DEBE quedar vac�o.", MsgBoxStyle.Critical, NombreSistema)
                Me.errSocia.SetError(Me.mtbNumCedula, "El N�mero de C�dula NO DEBE quedar vac�o.")
                Me.mtbNumCedula.Focus()
                'Me.cmdAceptar.Enabled = False
                ValidarCedula = False
                Exit Function
            End If

            ''NO Buscar en el Padr�n si corresponde a Formato:
            'If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
            '    MsgBox("El N�mero de C�dula NO existe en el Padr�n.", MsgBoxStyle.Information, NombreSistema)
            '    Me.cmdAceptar.Enabled = False
            '    Exit Sub
            'End If

            'N�mero de C�dula V�lido:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                Case Cedula.Invalida
                    MsgBox("El N�mero de C�dula es inv�lido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "N�mero de C�dula es invalido.")
                    Me.mtbNumCedula.Focus()
                    'Me.cmdAceptar.Enabled = False
                    ValidarCedula = False
                    Exit Function
                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del N�mero de C�dula es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Longitud del N�mero de C�dula es incorrecta.")
                    Me.mtbNumCedula.Focus()
                    'Me.cmdAceptar.Enabled = False
                    ValidarCedula = False
                    Exit Function
            End Select

            ''If ModoFrm = "UPD" Then
            '' A quitar los -
            'posCedula = InStr(Me.mtbNumCedula.Text, "-") ' 1ra vuelta
            'strCedula = Mid(Me.mtbNumCedula.Text, 1, posCedula - 1) & Mid(Me.mtbNumCedula.Text, posCedula + 1, Len(Me.mtbNumCedula.Text))
            'posCedula = InStr(strCedula, "-") ' 2da vuelta
            'strCedula = Mid(strCedula, 1, posCedula - 1) & Mid(strCedula, posCedula + 1, Len(strCedula))

            ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" ' And nSclSociaID <> " & IdSocia
            'Else
            '    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" ' And nSclSociaID = " & IdSocia
            'End If
            ObjTmpSocia.Retrieve() 'Obtener los datos filtrados.

            If ObjTmpSocia.Count > 0 Then
                'If Not MsgBox("El N�mero de C�dula NO DEBERIA de repetirse." & Chr(13) & "�Desea continuar con esta C�dula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                MsgBox("El N�mero de C�dula NO DEBE de repetirse.", MsgBoxStyle.Critical, NombreSistema)
                'Me.mtbNumCedula.Text = ""
                'Me.mtbNumCedula.Focus()
                'Me.cmdAceptar.Enabled = False
                ValidarCedula = False
                Exit Function
                'End If
            End If

            Seg.RefreshPermissions()

            ModificarNombreSocia = Seg.HasPermission("ModificarNombreSocia")
            Dim Enabled As Boolean = Seg.HasPermission("AgregarCedula")

            ''Buscar C�dula en el Padr�n:
            ''1. Si NO existe habilitar Nombres Else Bloquearlos:
            'If BlnCedulaValidaPadron(Me.mtbNumCedula.Text, ModificarNombreSocia, searchPadron) = True Then
            '    Me.cmdAceptar.Enabled = True
            '    'Me.txtNombre1.Enabled = False ' ModificarNombreSocia
            'Else
            '    '' Si tiene permiso para agregar c�dula permitirle guardar a la socia, sin nececidad que esta
            '    '' se encuentre en el padron

            '    'Dim str As String = String.Empty
            '    'str = IIf(Not Enabled, " Usted no tiene permiso para agregar nuevas c�dulas.", "")

            '    'If searchPadron Then
            '    '    MsgBox(String.Format("La c�dula {0} no existe en el padron. {1} ", Me.mtbNumCedula.Text, str), MsgBoxStyle.Critical, NombreSistema)
            '    '    Me.errSocia.SetError(Me.mtbNumCedula, String.Format("La c�dula {0} no existe en el padron. {1} ", Me.mtbNumCedula.Text, str))
            '    '    Me.mtbNumCedula.Focus()
            '    '    Me.cmdAceptar.Enabled = False
            '    'End If

            '    'cmdAceptar.Enabled = Enabled
            '    ''Me.txtNombre1.Enabled = Enabled

            '    'If Enabled And searchPadron Then
            '    '    Dim socia As String = Me.CedulaRepetida(Me.mtbNumCedula.Text)
            '    '    If String.IsNullOrEmpty(socia) Then
            '    '        If Not MsgBox("El N�mero de C�dula NO existe en el Padr�n." & Chr(13) & "A�n as� desea agregar a la socia con esta C�dula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
            '    '            'Me.txtNombre1.Enabled = False
            '    '            cmdAceptar.Enabled = False
            '    '            'Me.txtNombre1.Select()
            '    '        End If
            '    '    Else
            '    '        MsgBox(String.Format("La socia: {0} ya tiene asignada la c�dula.", socia) & Chr(13) & "Favor indicar otro n�mero de c�dula.", MsgBoxStyle.Information, NombreSistema)
            '    '    End If
            '    'End If
            'End If

            Me.cmdAceptar.Enabled = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

End Class