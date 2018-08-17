Public Class frmSccBusquedaNotasDebitoCredito
    '-- Declaracion de Variables 
    Dim IdSclConsultarDelegacion As Integer
    Dim nTipoBusqueda As Integer
    Dim StrCriterio As String
    Dim StrCriterio2 As String
    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    Dim XContadorReg As Integer
    Dim sColor As String

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Public Property snTipoBusqueda() As Integer
        Get
            snTipoBusqueda = nTipoBusqueda
        End Get
        Set(ByVal value As Integer)
            nTipoBusqueda = value
        End Set
    End Property
    'Propiedad utilizada para determinar si el usuario puede consultar
    'Solicitudes de otra delegacion.
    '1 = Puede visualizar todas las Delegaciones del Programa. 
    Public Property IdConsultarDelegacion() As Integer
        Get
            IdConsultarDelegacion = IdSclConsultarDelegacion
        End Get
        Set(ByVal value As Integer)
            IdSclConsultarDelegacion = value
        End Set
    End Property

    'Propiedad utilizada para retornar el Criterio de Búsqueda del usuario:
    Public Property StrCriterioSolicitud() As String
        Get
            StrCriterioSolicitud = StrCriterio
        End Get
        Set(ByVal value As String)
            StrCriterio = value
        End Set
    End Property
    'Propiedad utilizada para retornar el Criterio 2 de Búsqueda del usuario:
    Public Property StrCriterioSolicitud2() As String
        Get
            StrCriterioSolicitud2 = StrCriterio2
        End Get
        Set(ByVal value As String)
            StrCriterio2 = value
        End Set
    End Property

    'Color a mostrarse en el formulario (enviado desde la Solicitud de Cheque):
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property

    Private Sub CargarMeses()
        CboMeses.AddItem("Todos")
        CboMeses.AddItem("Enero")
        CboMeses.AddItem("Febrero")
        CboMeses.AddItem("Marzo")
        CboMeses.AddItem("Abril")
        CboMeses.AddItem("Mayo")
        CboMeses.AddItem("Junio")
        CboMeses.AddItem("Julio")
        CboMeses.AddItem("Agosto")
        CboMeses.AddItem("Septiembre")
        CboMeses.AddItem("Octubre")
        CboMeses.AddItem("Noviembre")
        CboMeses.AddItem("Diciembre")
        CboMeses.SelectedIndex = 0
    End Sub
    Private Sub frmSccBusquedaNotasDebitoCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtDatos.Close()
                XdtDatos = Nothing

            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial:
                AccionUsuario = AccionBoton.BotonCancelar
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSccBusquedaNotasDebitoCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarMeses()
            Me.mtbNumCedula.Select()
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub InicializarVariables()
        Try

            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            Me.mtbNumCedula.MaxLength = 16
            Me.mtbNumeroSesion.MaxLength = 11



            Me.grpBotones.Enabled = False
            XContadorReg = 0
            HabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try

            AccionUsuario = AccionBoton.BotonAceptar
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Dim nContador As Integer = 0
            Me.errSolicitud.Clear()

            '-- Búsqueda por Cédula:
            If Me.radCedula.Checked = True Then
                'Número de Cédula Obligatorio:
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Nombres de la Socia:
                'ElseIf Me.RadSocia.Checked = True Then
                '    If Trim(Me.TxtPrimerNombre.Text) = "" Then
                '        nContador = nContador + 1
                '    End If
                '    If Trim(Me.TxtSegundoNombre.Text) = "" Then
                '        nContador = nContador + 1
                '    End If
                '    If Trim(Me.TxtPrimerApellido.Text) = "" Then
                '        nContador = nContador + 1
                '    End If
                '    If Trim(Me.TxtSegundoApellido.Text) = "" Then
                '        nContador = nContador + 1
                '    End If
                '    If nContador > 2 Then
                '        MsgBox("Debe indicar al menos Dos Criterios de búsqueda.", MsgBoxStyle.Critical, NombreSistema)
                '        ValidaDatosEntrada = False
                '        Me.errSolicitud.SetError(Me.TxtPrimerNombre, "Debe indicar al menos DOS Criterios de búsqueda.")
                '        Me.TxtPrimerNombre.Focus()
                '        Exit Function
                '    End If

                '-- Búsqueda por Nombre del Grupo Solidario:
            ElseIf Me.RadGrupo.Checked = True Then
                If Trim(RTrim(Me.TxtNombreGrupo.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar nombre del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.TxtNombreGrupo, "Debe indicar nombre del Grupo Solidario.")
                    Me.TxtNombreGrupo.Focus()
                    Exit Function
                End If

                '-- Búsqueda Código de Ficha de Notificación de Crédito:
            ElseIf Me.RadCodigoFNC.Checked = True Then
                If Trim(RTrim(Me.txtCodigoFNC.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar Código de Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.txtCodigoFNC, "Debe indicar Código de Ficha.")
                    Me.txtCodigoFNC.Focus()
                    Exit Function
                End If
                If Not IsNumeric(Me.txtCodigoFNC.Text) Then
                    MsgBox("Debe indicar Código de Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.txtCodigoFNC, "Debe indicar Código de Ficha.")
                    Me.txtCodigoFNC.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Código de Solicitud de Cheque:
            ElseIf Me.RadCodigo.Checked = True Then
                If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar Código de la Nota de Debito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.txtCodigo, "Debe indicar Código de la Solicitud de Cheque.")
                    Me.txtCodigo.Focus()
                    Exit Function
                End If
                If Not IsNumeric(Me.txtCodigo.Text) Then
                    MsgBox("Debe indicar Código de la Nota de Debito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.txtCodigo, "Código de Solicitud de Cheque inválido.")
                    Me.txtCodigo.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Número de Sesión:
            ElseIf Me.radSesion.Checked = True Then
                If Not IsNumeric(Mid(Me.mtbNumeroSesion.Text, 1, 1)) Then
                    MsgBox("Debe indicar Número de Resolución.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.mtbNumeroSesion, "Debe indicar Número de Resolución.")
                    Me.mtbNumeroSesion.Focus()
                    Exit Function
                End If
                'Longitud válida para el Número de Sesión:
                If Len(Me.mtbNumeroSesion.Text) <> 11 Then
                    MsgBox("Debe indicar un No. de Sesión del Crédito válido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.mtbNumeroSesion, "Debe indicar un No. de Sesión del Crédito Válido.")
                    Me.mtbNumeroSesion.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Fechas de Corte:
            ElseIf Me.RadFechas.Checked = True Then
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cdeFechaD, "Debe indicar fechas de corte Válidas.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cdeFechaD, "Debe indicar fechas de corte Válidas.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cdeFechaD, "Fecha de Inicio no debe ser mayor que la Fecha de Corte.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                'Máximo 6 días entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 6 días.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.cdeFechaD, "Imposible seleccionar cortes de fecha superiores a 6 días.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If




            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function


    Private Sub PresentaSolicitud()
        Try
            If nTipoBusqueda = 1 Then
                '-- Para cualquier tipo de Búsqueda: 
                Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("Socia")
                Me.txtCodigo.Text = XdtDatos.Table.Rows(XContadorReg).Item("nCodigo")
                If IsNumeric(XdtDatos.Table.Rows(XContadorReg).Item("nCodigoFNC")) Then
                    Me.txtGrupoSolidario.Text = XdtDatos.Table.Rows(XContadorReg).Item("CodGrupo")
                    Me.TxtNombreGrupo.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreGrupo")
                    Me.txtCodigoFNC.Text = XdtDatos.Table.Rows(XContadorReg).Item("nCodigoFNC")
                    Me.mtbNumeroSesion.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNumSesion")
                End If
            Else
                Me.txtCodigo.Text = XdtDatos.Table.Rows(XContadorReg).Item("nCodigo")
                Me.txtNombreSocia.Text = "Busqueda Por Nota"
            End If
            LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            AccionUsuario = AccionBoton.BotonCancelar
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub HabilitarControles()
        Try

            '-- Limpiar todos los datos:
            Me.errSolicitud.Clear()
            Me.mtbNumCedula.Text = ""
            Me.txtNombreSocia.Text = ""
            'Me.TxtPrimerNombre.Text = ""
            'Me.TxtSegundoNombre.Text = ""
            'Me.TxtPrimerApellido.Text = ""
            'Me.TxtSegundoApellido.Text = ""
            Me.mtbNumeroSesion.Text = ""
            Me.TxtNombreGrupo.Text = ""
            Me.txtGrupoSolidario.Text = ""
            Me.txtCodigo.Text = ""
            Me.txtCodigoFNC.Text = ""
            Me.grpBotones.Enabled = False

            '-- Búsqueda por Cédula:
            If Me.radCedula.Checked = True Then
                Me.GrpCedulaSocia.Enabled = True
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.GrpCodigos.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.grpAño.Enabled = False

                Me.mtbNumCedula.Select()

                '-- Búsqueda por Nombre Grupo Solidario:
            ElseIf Me.RadGrupo.Checked = True Then
                Me.GrpGrupoSolidario.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpCodigos.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.TxtNombreGrupo.Enabled = True
                Me.grpAño.Enabled = False
                Me.TxtNombreGrupo.Select()

                '-- Búsqueda por Código de Ficha:
            ElseIf Me.RadCodigoFNC.Checked = True Then
                Me.GrpCodigos.Enabled = True
                Me.txtCodigoFNC.Enabled = True
                Me.txtCodigo.Enabled = False
                Me.mtbNumeroSesion.Enabled = False
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.grpAño.Enabled = False
                Me.txtCodigoFNC.Select()

                '-- Búsqueda por Código de Solicitud:
            ElseIf Me.RadCodigo.Checked = True Then
                Me.GrpCodigos.Enabled = True
                Me.txtCodigo.Enabled = True
                Me.txtCodigoFNC.Enabled = False
                Me.mtbNumeroSesion.Enabled = False
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.grpAño.Enabled = False

                Me.txtCodigo.Select()

                '-- Búsqueda por Número de Sesión:
            ElseIf Me.radSesion.Checked = True Then
                Me.GrpCodigos.Enabled = True
                Me.txtCodigo.Enabled = False
                Me.txtCodigoFNC.Enabled = False
                Me.mtbNumeroSesion.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.grpAño.Enabled = False
                Me.mtbNumeroSesion.Select()

            ElseIf Me.RadCodigoGrupo.Checked = True Then


                '-- Búsqueda por Fechas de Corte:
                'ElseIf Me.RadFechas.Checked = True Then

                '    Me.GrpCedulaSocia.Enabled = False
                '    'Me.GrpNombreCompleto.Enabled = False
                '    Me.GrpGrupoSolidario.Enabled = False
                '    Me.GrpCodigos.Enabled = False

                Me.GrpGrupoSolidario.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpCodigos.Enabled = False
                txtGrupoSolidario.Enabled = True
                Me.TxtNombreGrupo.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.grpAño.Enabled = False
                Me.txtGrupoSolidario.Select()
                '-- Búsqueda por Fechas de Corte:
            ElseIf Me.RadFechas.Checked = True Then
                Me.GrpGrupoSolidario.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpCodigos.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.TxtNombreGrupo.Enabled = False
                Me.GrpFechasCorte.Enabled = True
                Me.grpAño.Enabled = False
                Me.cdeFechaD.Select()
            ElseIf Me.rdoAño.Checked Then
                Me.GrpCodigos.Enabled = True
                Me.txtCodigo.Enabled = False
                Me.txtCodigoFNC.Enabled = False
                Me.mtbNumeroSesion.Enabled = False
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                txtGrupoSolidario.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.grpAño.Enabled = True
                Me.ndAño.Select()

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CmdPrimero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaSolicitud()
    End Sub

    Private Sub cmdUltimo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSolicitud()
    End Sub

    Private Sub CmdAnterior_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSolicitud()
    End Sub

    Private Sub cmdSiguiente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSolicitud()
    End Sub

    Private Sub cmdBuscar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim cadWhere As String = ""
            Dim cadWhere2 As String = ""
            Dim strSQL As String = ""

            Me.errSolicitud.Clear()
            nTipoBusqueda = 0
            If ValidaDatosEntrada() Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                '**********************************************************************************
                '************************* De acuerdo con el Tipo de Busqueda *********************
                '**********************************************************************************
                '-- 1. Búsqueda Por Cédula.
                If Me.radCedula.Checked Then
                    cadWhere = " WHERE (a.sNumeroCedula = '" & Me.mtbNumCedula.Text & "') "
                    cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where sNumeroCedula='" & Me.mtbNumCedula.Text & "'))"
                    nTipoBusqueda = 1
                    '-- 2. Búsqueda Por Número de Sesión. 
                ElseIf Me.radSesion.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.sNumSesion= '" & Me.mtbNumeroSesion.Text & "') "
                    Else
                        cadWhere = cadWhere & " And (a.sNumSesion='" & Me.mtbNumeroSesion.Text & "') "
                    End If
                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where sNumSesion='" & Me.mtbNumeroSesion.Text & "'))"


                    Else
                        cadWhere2 = cadWhere2 & " And (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where sNumSesion='" & Me.mtbNumeroSesion.Text & "'))"
                    End If
                    nTipoBusqueda = 1
                    ' cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where sNumeroCedula='" & Me.mtbNumCedula.Text & "'))"
                    '    '-- 2. Búsqueda Por Nombres.
                    'ElseIf Me.RadGrupo.Checked Then
                    '    'Si se indicó el Primer Nombre:
                    '    If Trim(Me.TxtPrimerNombre.Text) <> "" Then
                    '        If Trim(cadWhere) = "" Then
                    '            cadWhere = " Where (a.sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "')"
                    '        Else
                    '            cadWhere = cadWhere & " And (a.sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "')"
                    '        End If
                    '    End If
                    '    'Si se indicó el Segundo Nombre:
                    '    If Trim(Me.TxtSegundoNombre.Text) <> "" Then
                    '        If Trim(cadWhere) = "" Then
                    '            cadWhere = " Where (a.sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "')"
                    '        Else
                    '            cadWhere = cadWhere & " And (a.sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "')"
                    '        End If
                    '    End If
                    '    'Si se indicó el Primer Apellido:
                    '    If Trim(Me.TxtPrimerApellido.Text) <> "" Then
                    '        If Trim(cadWhere) = "" Then
                    '            cadWhere = " Where (a.sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "')"
                    '        Else
                    '            cadWhere = cadWhere & " And (a.sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "')"
                    '        End If
                    '    End If
                    '    'Si se indicó el Segundo Apellido:
                    '    If Trim(Me.TxtSegundoApellido.Text) <> "" Then
                    '        If Trim(cadWhere) = "" Then
                    '            cadWhere = " Where (a.sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "')"
                    '        Else
                    '            cadWhere = cadWhere & " And (a.sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "')"
                    '        End If
                    '    End If

                    '-- 3. Búsqueda Por Nombre del Grupo Solidario. 
                ElseIf Me.RadGrupo.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.NombreGrupo= '" & Trim(Me.TxtNombreGrupo.Text) & "') "
                    Else
                        cadWhere = cadWhere & " And (a.NombreGrupo='" & Trim(Me.TxtNombreGrupo.Text) & "') "
                    End If
                    nTipoBusqueda = 1

                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where NombreGrupo='" & Me.TxtNombreGrupo.Text & "'))"
                    Else
                        cadWhere2 = cadWhere2 & " AND (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where NombreGrupo='" & Me.TxtNombreGrupo.Text & "'))"
                    End If

                    '-- 3. Búsqueda Por codigo del Grupo Solidario. 
                ElseIf Me.RadCodigoGrupo.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.CodGrupo= '" & Trim(Me.txtGrupoSolidario.Text) & "') "
                    Else
                        cadWhere = cadWhere & " And (a.CodGrupo='" & Trim(Me.txtGrupoSolidario.Text) & "') "
                    End If
                    '" WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where NombreGrupo='" & Me.txtGrupoSolidario.Text & "'))"
                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where CodGrupo='" & Me.txtGrupoSolidario.Text & "'))"
                    Else
                        cadWhere2 = cadWhere2 & " AND (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where CodGrupo='" & Me.txtGrupoSolidario.Text & "'))"
                    End If
                    nTipoBusqueda = 1
                    '-- 4. Búsqueda Por Código de la Ficha.
                ElseIf Me.RadCodigoFNC.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nCodigoFNC= " & Trim(Me.txtCodigoFNC.Text) & ") "
                    Else
                        cadWhere = cadWhere & " And (a.nCodigoFNC= " & Trim(Me.txtCodigoFNC.Text) & ") "
                    End If
                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where nCodigoFNC='" & Me.txtCodigoFNC.Text & "'))"
                    Else
                        cadWhere2 = cadWhere2 & cadWhere2 = " AND (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where nCodigoFNC='" & Me.txtCodigoFNC.Text & "'))"
                    End If
                    nTipoBusqueda = 1

                    '-- 5. Búsqueda Por Código de Nota.
                ElseIf Me.RadCodigo.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where ( Cast(a.nCodigo as int)= " & Trim(Me.txtCodigo.Text) & ") "
                    Else
                        cadWhere = cadWhere & " And ( cast(a.nCodigo as int)= " & Trim(Me.txtCodigo.Text) & ") "
                    End If

                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where nCodigoFNC='" & Me.txtCodigoFNC.Text & "'))"
                    Else
                        cadWhere2 = cadWhere2 & " AND (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where nCodigoFNC='" & Me.txtCodigoFNC.Text & "'))"
                    End If
                    nTipoBusqueda = 2
                    '-- 6. Búsqueda Por Fechas de Corte:
                ElseIf Me.RadFechas.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.dFechaNota BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                    Else
                        cadWhere = cadWhere & " AND (a.dFechaNota BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                    End If
                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " Where (a.dFechaNota BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                    Else
                        cadWhere2 = cadWhere2 & " AND (a.dFechaNota BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                    End If
                    nTipoBusqueda = 2

                ElseIf Me.rdoAño.Checked Then

                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where ( a.nAnio =  " & Convert.ToInt32(Me.ndAño.Value) & " )"
                    Else
                        cadWhere = " AND ( a.nAnio =  " & Convert.ToInt32(Me.ndAño.Value) & " )"
                    End If



                    If Trim(cadWhere2) = "" Then
                        cadWhere2 = " Where ( a.nAnio =  " & Convert.ToInt32(Me.ndAño.Value) & " )"
                    Else
                        cadWhere2 = " AND ( a.nAnio =  " & Convert.ToInt32(Me.ndAño.Value) & " )"
                    End If




                    If CboMeses.SelectedIndex > 0 Then

                        If Trim(cadWhere) = "" Then
                            cadWhere = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where Year(dFechaPago)=" & Convert.ToInt32(Me.ndAño.Value) & "  and month(dFechaPago)=" & CboMeses.SelectedIndex & "))"

                        Else
                            cadWhere = cadWhere & " AND (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where Year(dFechaPago)=" & Convert.ToInt32(Me.ndAño.Value) & "  and month(dFechaPago)=" & CboMeses.SelectedIndex & "))"
                        End If


                        If Trim(cadWhere2) = "" Then
                            cadWhere2 = " WHERE (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where Year(dFechaPago)=" & Convert.ToInt32(Me.ndAño.Value) & "  and month(dFechaPago)=" & CboMeses.SelectedIndex & "))"

                        Else
                            cadWhere2 = cadWhere2 & " AND (a.nSccNotaID IN (Select nSccNotaID From vwSccNotaCreditoDebitoDetallesFichas Where Year(dFechaPago)=" & Convert.ToInt32(Me.ndAño.Value) & "  and month(dFechaPago)=" & CboMeses.SelectedIndex & "))"
                        End If
                        



                    End If


       

                    nTipoBusqueda = 2
                End If

                REM
                'Si Usuario unicamente puede Consultar Solicitudes de su Delegación:
                'If Me.IdSclConsultarDelegacion <> 1 Then
                '    If Trim(cadWhere) = "" Then
                '        cadWhere = " Where (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") "
                '    Else
                '        cadWhere = cadWhere & " And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") "
                '    End If
                'End If
                REM 

                'Asigna Consulta de la Nota :               
                If nTipoBusqueda = 1 Then
                    strSQL = " SELECT * " & _
                             " FROM vwSccNotaCreditoDebitoDetallesFichas AS a "
                Else
                    strSQL = " SELECT * " & _
                             " FROM vwSccNotaCreditoDebitoNotaN  AS a "
                End If
                'Asigna Criterio de Búsqueda:
                strSQL = strSQL & cadWhere

                XContadorReg = 0
                XdtDatos.ExecuteSql(strSQL)

                'En caso de NO encontrar registros:
                If XdtDatos.Count = 0 Then
                    MsgBox("Nota NO Encontrada.", MsgBoxStyle.Information, NombreSistema)
                    grpBotones.Enabled = False
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Else 'Se encontraron registros:
                    grpBotones.Enabled = True
                    Me.StrCriterioSolicitud = Replace(cadWhere, "nCodigo", "nCodigoN")
                    Me.StrCriterioSolicitud2 = cadWhere2
                    PresentaSolicitud()
                End If
                Me.Cursor = System.Windows.Forms.Cursors.Default
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtSocia.Close()
            XdtSocia = Nothing
        End Try
    End Sub

    Private Sub cmdBuscar_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles cmdBuscar.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub radCedula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCedula.Click
        HabilitarControles()
    End Sub

    Private Sub RadCodigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigo.Click
        HabilitarControles()
    End Sub

    Private Sub RadCodigoFNC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigoFNC.Click
        HabilitarControles()
    End Sub

    Private Sub radSesion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSesion.CheckedChanged

    End Sub

    Private Sub radSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radSesion.Click
        HabilitarControles()
    End Sub

    Private Sub RadGrupo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadGrupo.CheckedChanged

    End Sub

    Private Sub RadGrupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrupo.Click
        HabilitarControles()
    End Sub

    Private Sub RadCodigoGrupo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadCodigoGrupo.CheckedChanged

    End Sub

    Private Sub RadCodigoGrupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigoGrupo.Click
        HabilitarControles()
    End Sub

    Private Sub RadFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadFechas.CheckedChanged
        HabilitarControles()
    End Sub

    Private Sub rdoAño_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rdoAño.CheckedChanged
        HabilitarControles()
    End Sub
End Class