Public Class frmSccReImpresionRecibos

    '-- Declaracion de Variables 
    'Dim ModoForm As String 'ADD/MOD
    Dim IdSclFichaNotificacion As Integer 'SclSocia.nSclSociaID
    Dim IDSclPersonaLugarPagosID As Integer
    Dim IdSclConsultarDelegacion As Integer
    Dim IdnStbTipoProgramaID As Integer
    Dim IdnStbTipoPlazoPagosID As Integer
    Dim XdtDatos As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDatos2 As BOSistema.Win.XDataSet.xDataTable
    Dim XContadorReg As Integer
    Dim IDSccTipoRecibo As Integer

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

    'Propiedad utilizada para determinar si el usuario puede consultar
    'socias de otra delegacion.
    '1 = Puede visualizar todas las Delegaciones del Programa. 
    Public Property IdConsultarDelegacion() As Integer
        Get
            IdConsultarDelegacion = IdSclConsultarDelegacion
        End Get
        Set(ByVal value As Integer)
            IdSclConsultarDelegacion = value
        End Set
    End Property
    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdPersonaLugarPagosID() As Integer
        Get
            IdPersonaLugarPagosID = IDSclPersonaLugarPagosID
        End Get
        Set(ByVal value As Integer)
            IDSclPersonaLugarPagosID = value
        End Set
    End Property
    'Tipo de Ingreso del Recibo (Manual o Automático)
    Public Property IdTipoRecibo() As Integer
        Get
            IdTipoRecibo = IDSccTipoRecibo
        End Get
        Set(ByVal value As Integer)
            IDSccTipoRecibo = value
        End Set
    End Property

    Public Property IdFichaNotificacion() As Integer
        Get
            IdFichaNotificacion = IdSclFichaNotificacion
        End Get
        Set(ByVal value As Integer)
            IdSclFichaNotificacion = value
        End Set
    End Property
    Public Property nStbTipoProgramaID() As Integer
        Get
            nStbTipoProgramaID = IdnStbTipoProgramaID
        End Get
        Set(ByVal value As Integer)
            IdnStbTipoProgramaID = value
        End Set
    End Property
    Public Property nStbTipoPlazoPagosID() As Integer
        Get
            nStbTipoPlazoPagosID = IdnStbTipoPlazoPagosID
        End Get
        Set(ByVal value As Integer)
            IdnStbTipoPlazoPagosID = value
        End Set
    End Property

    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        'Me.XdtDatos.Table.Rows(0)("ddd")
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = 0
        PresentaSocia()
    End Sub

    Private Sub PresentaSocia()
        Me.IdFichaNotificacion = XdtDatos.Table.Rows(XContadorReg).Item("nSclFichaNotificacionID")
        Me.txtGrupoSolidario.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNombreGrupo")
        Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNombreSocia")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "

    End Sub

    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSocia()
    End Sub

    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSocia()
    End Sub

    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSocia()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try

            ValidaDatosEntrada()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidaDatosEntrada() As Boolean

        Try
            Dim strSQL As String = ""
            Dim cadWhere As String = ""
            Dim nContador As Integer = 0
            ValidaDatosEntrada = True
            Me.errSocia.Clear()

            If ChkTipoBusqueda.Checked Then
                'Número de Cédula Obligatorio:
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

            Else

                If Trim(Me.TxtPrimerNombre.Text) = "" Then
                    nContador = nContador + 1
                End If

                If Trim(Me.TxtSegundoNombre.Text) = "" Then
                    nContador = nContador + 1
                End If

                If Trim(Me.TxtPrimerApellido.Text) = "" Then
                    nContador = nContador + 1
                End If

                If Trim(Me.TxtSegundoApellido.Text) = "" Then
                    nContador = nContador + 1
                End If

                'If Trim(Me.TxtPrimerNombre.Text) = "" And Trim(Me.TxtSegundoNombre.Text) = "" And Trim(Me.TxtPrimerApellido.Text) = "" And Trim(Me.TxtSegundoApellido.Text) = "" Then
                If nContador > 2 Then
                    MsgBox("Debe indicar al menos Dos Criterios de búsqueda.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.TxtPrimerNombre, "Debe indicar al menos DOS Criterios de búsqueda.")
                    Me.TxtPrimerNombre.Focus()
                    Exit Function
                End If
            End If


            If ChkTipoBusqueda.Checked Then

                strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                         " From vwSclSociaCedula " & _
                         " Where sCodFuente <> '93' And sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"
            Else

                If Trim(Me.TxtPrimerNombre.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "'"
                    End If
                End If

                If Trim(Me.TxtSegundoNombre.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "'"
                    End If
                End If

                If Trim(Me.TxtPrimerApellido.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "'"
                    End If
                End If

                If Trim(Me.TxtSegundoApellido.Text) <> "" Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "'"
                    Else
                        cadWhere = cadWhere & " And sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "'"
                    End If
                End If

                'Que no sea CARUNA
                If Trim(cadWhere) = "" Then
                    cadWhere = " Where sCodFuente <> '93' "
                Else
                    cadWhere = cadWhere & " And sCodfuente <> '93' "
                End If

                strSQL = " Select nSclFichaNotificacionID,sNombreGrupo,sNombreSocia,nStbPersonaLugarPagosID " & _
                                         " From vwSclSociaCedulaConCancelados " & cadWhere

            End If

            XContadorReg = 0

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                If ChkTipoBusqueda.Checked Then
                    grpBotones.Enabled = False
                    If XdtDatos.Count = 0 Then
                        MsgBox("Socia NO Encontrada.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "Socia NO Encontrada.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Else
                        Me.IdFichaNotificacion = XdtDatos.ValueField("nSclFichaNotificacionID")
                        Me.txtGrupoSolidario.Text = XdtDatos.ValueField("sNombreGrupo")
                        Me.txtNombreSocia.Text = XdtDatos.ValueField("sNombreSocia")
                        LblConteo.Text = ""
                    End If

                End If
                grpBotones.Enabled = True
                PresentaSocia()
            Else
                MsgBox("No se encontraron socias con ese criterio.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.TxtPrimerNombre, "No se encontraron socias con ese criterio.")
                Me.TxtPrimerNombre.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)

        Finally

        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            AccionUsuario = AccionBoton.BotonAceptar
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try

            Me.IdFichaNotificacion = 0
            AccionUsuario = AccionBoton.BotonCancelar
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ChkTipoBusqueda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTipoBusqueda.CheckedChanged
        If ChkTipoBusqueda.Checked Then
            Me.TxtPrimerNombre.Text = ""
            Me.TxtSegundoNombre.Text = ""
            Me.TxtPrimerApellido.Text = ""
            Me.TxtSegundoApellido.Text = ""
            Me.grpBotones.Enabled = False
            Me.mtbNumCedula.Enabled = True
            Me.GrpNombreCompleto.Enabled = False
            Me.mtbNumCedula.Select()

        Else
            Me.grpBotones.Enabled = True
            Me.mtbNumCedula.Enabled = False
            Me.GrpNombreCompleto.Enabled = True
            mtbNumCedula.Text = ""
            Me.TxtPrimerNombre.Select()
        End If
    End Sub


    Private Sub InicializarVariables()
        Try
            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            XdtDatos2 = New BOSistema.Win.XDataSet.xDataTable
            Me.mtbNumCedula.MaxLength = 16
            Me.grpBotones.Enabled = False
            Me.ChkTipoBusqueda.Checked = True
            'End If
            XContadorReg = 0
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub frmSccReImpresionRecibos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            'Ruta Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            If Me.IdTipoRecibo = 2 Then  'Manual
                Me.ChkTipoBusqueda.Checked = False
                Me.TxtPrimerNombre.Select()
            Else
                Me.mtbNumCedula.Select()
            End If

            AccionUsuario = AccionBoton.BotonCancelar
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
End Class