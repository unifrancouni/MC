' ------------------------------------------------------------------------
' Project Item Name:    frmSclEditSociaCedula.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       en el Catálogo de Conyuges de Socias.
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
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
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
    ' Descripción:          Evento Load del formulario donde se inicializan variables y se cargan datos de la Socia 
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
    ' Descripción:          Este procedimiento permite Inicializar variables
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
    ' Descripción:          Este evento permite validar los datos ingresado y
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
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaDataTable

        Try

            ValidaDatosEntrada = True
            Me.errSocia.Clear()

            'Número de Cédula Obligatorio:
            If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                Exit Function
            End If

            'NO validar Número de Cédula si no corresponde a Formato: Y establecer como fecha de nacimiento: 30/05/1964
            If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
                StrFecha = "30/05/1964"
            Else
                'Fecha válida en número de Cédula:
                StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
                If Not IsDate(StrFecha) Then
                    MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula debe contener una fecha válida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

                'Determinar Duplicados en el Número de Cédula:
                'If ModoFrm = "UPD" Then
                ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And nSclSociaID <> " & IdSocia
                'Else
                '    ObjTmpSocia.Filter = " sNumeroCedula = '" & Me.mtbNumCedula.Text & "'" ' And nSclSociaID = " & IdSocia
                'End If
                ObjTmpSocia.Retrieve() 'Obtener los datos filtrados.
                If ObjTmpSocia.Count > 0 Then
                    MsgBox("El Número de Cédula NO DEBE de repetirse.", MsgBoxStyle.Critical, NombreSistema)
                    'If Not MsgBox("El Número de Cédula NO DEBERIA de repetirse." & Chr(13) & "¿Desea continuar con esta Cédula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
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

                'Número de Cédula Válido:
                Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                    Case Cedula.Invalida
                        MsgBox("El Número de Cédula de la Socia es inválido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia es inválido.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Case Cedula.LongitudIncorrecta
                        MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "La Longitud del Número de Cédula de la Socia es incorrecta.")
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
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados de la Socia en la Base de Datos.
    '-----------------------------------------------------------------------------------
    Private Sub SalvarSocia()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim Ficha_Notificacion As Integer
        Dim StrConsulta As String, strSQL As String
        Dim XdtTmpConsulta As New BOSistema.Win.XDataSet.xDataTable

        Try

            'Número de Cédula:
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
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
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
                    res = MsgBox("¿Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
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
    ' Description                   :     Indica si una Cedula existe en la BD del Padrón.
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
    ' Description                   :     verifica si una cédula que no está en el padron,
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
    ' Description                   :     Busca una Cedula en la BD del Padrón.
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
                MsgBox("El Número de Cédula NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula NO DEBE quedar vacío.")
                Me.mtbNumCedula.Focus()
                'Me.cmdAceptar.Enabled = False
                ValidarCedula = False
                Exit Function
            End If

            ''NO Buscar en el Padrón si corresponde a Formato:
            'If Me.mtbNumCedula.Text = "999-999999-9999Z" Then
            '    MsgBox("El Número de Cédula NO existe en el Padrón.", MsgBoxStyle.Information, NombreSistema)
            '    Me.cmdAceptar.Enabled = False
            '    Exit Sub
            'End If

            'Número de Cédula Válido:
            Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                Case Cedula.Invalida
                    MsgBox("El Número de Cédula es inválido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Número de Cédula es invalido.")
                    Me.mtbNumCedula.Focus()
                    'Me.cmdAceptar.Enabled = False
                    ValidarCedula = False
                    Exit Function
                Case Cedula.LongitudIncorrecta
                    MsgBox("La Longitud del Número de Cédula es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errSocia.SetError(Me.mtbNumCedula, "Longitud del Número de Cédula es incorrecta.")
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
                'If Not MsgBox("El Número de Cédula NO DEBERIA de repetirse." & Chr(13) & "¿Desea continuar con esta Cédula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                MsgBox("El Número de Cédula NO DEBE de repetirse.", MsgBoxStyle.Critical, NombreSistema)
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

            ''Buscar Cédula en el Padrón:
            ''1. Si NO existe habilitar Nombres Else Bloquearlos:
            'If BlnCedulaValidaPadron(Me.mtbNumCedula.Text, ModificarNombreSocia, searchPadron) = True Then
            '    Me.cmdAceptar.Enabled = True
            '    'Me.txtNombre1.Enabled = False ' ModificarNombreSocia
            'Else
            '    '' Si tiene permiso para agregar cédula permitirle guardar a la socia, sin nececidad que esta
            '    '' se encuentre en el padron

            '    'Dim str As String = String.Empty
            '    'str = IIf(Not Enabled, " Usted no tiene permiso para agregar nuevas cédulas.", "")

            '    'If searchPadron Then
            '    '    MsgBox(String.Format("La cédula {0} no existe en el padron. {1} ", Me.mtbNumCedula.Text, str), MsgBoxStyle.Critical, NombreSistema)
            '    '    Me.errSocia.SetError(Me.mtbNumCedula, String.Format("La cédula {0} no existe en el padron. {1} ", Me.mtbNumCedula.Text, str))
            '    '    Me.mtbNumCedula.Focus()
            '    '    Me.cmdAceptar.Enabled = False
            '    'End If

            '    'cmdAceptar.Enabled = Enabled
            '    ''Me.txtNombre1.Enabled = Enabled

            '    'If Enabled And searchPadron Then
            '    '    Dim socia As String = Me.CedulaRepetida(Me.mtbNumCedula.Text)
            '    '    If String.IsNullOrEmpty(socia) Then
            '    '        If Not MsgBox("El Número de Cédula NO existe en el Padrón." & Chr(13) & "Aún así desea agregar a la socia con esta Cédula?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
            '    '            'Me.txtNombre1.Enabled = False
            '    '            cmdAceptar.Enabled = False
            '    '            'Me.txtNombre1.Select()
            '    '        End If
            '    '    Else
            '    '        MsgBox(String.Format("La socia: {0} ya tiene asignada la cédula.", socia) & Chr(13) & "Favor indicar otro número de cédula.", MsgBoxStyle.Information, NombreSistema)
            '    '    End If
            '    'End If
            'End If

            Me.cmdAceptar.Enabled = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

End Class