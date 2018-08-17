' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                18/02/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSccBusquedaSolicitudesCheque.vb
' Descripción:          Este formulario permite buscar Solicitudes de
'                       Cheque del Programa.
'-------------------------------------------------------------------------
Public Class frmSccBusquedaSolicitudesCheque

    '-- Declaracion de Variables 
    Dim IdSclConsultarDelegacion As Integer
    Dim TipoChk As Integer
    Dim StrCriterio As String
    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    Dim XContadorReg As Integer
    Dim sColor As String
    Dim ModoAcc As String
    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

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

    'Color a mostrarse en el formulario (enviado desde la Solicitud de Cheque):
    Public Property sColorFrm() As String
        Get
            sColorFrm = sColor
        End Get
        Set(ByVal value As String)
            sColor = value
        End Set
    End Property


    '0: Todos
    '1:Solo Tipo Cheque 1 y 2 Para Socias y Delegadas
    'Para que creditos no vea los cheques de pagos gastos 
    Public Property TipoCheque() As Integer
        Get
            TipoCheque = TipoChk
        End Get
        Set(ByVal value As Integer)
            TipoChk = value
        End Set
    End Property
    'Propiedad utilizada para identificar si el formulario responde a 
    'Elborar, Revisar o Autorizar una determinada Solicitud de Cheque:
    'ELA: Elaborar
    'REV: Revisar
    'AUT: Autorizar
    Public Property ModoAccion() As String
        Get
            ModoAccion = ModoAcc
        End Get
        Set(ByVal value As String)
            ModoAcc = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       frmSccBusquedaSolicitudesCheque_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccBusquedaSolicitudesCheque_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       frmSccBusquedaSolicitudesCheque_Load
    ' Descripción:          Load del formulario donde se inicializan variables.
    '-------------------------------------------------------------------------
    Private Sub frmSccBusquedaSolicitudesCheque_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, sColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            Me.mtbNumCedula.Select()
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            Me.mtbNumCedula.MaxLength = 16
            Me.mtbNumeroSesion.MaxLength = 11

            Me.cdeFechaD.Value = CDate(FechaServer())
            Me.cdeFechaH.Value = CDate(FechaServer())

            Me.grpBotones.Enabled = False
            XContadorReg = 0
            HabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try

            AccionUsuario = AccionBoton.BotonAceptar
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
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
                    MsgBox("Debe indicar Código de la Solicitud de Cheque.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSolicitud.SetError(Me.txtCodigo, "Debe indicar Código de la Solicitud de Cheque.")
                    Me.txtCodigo.Focus()
                    Exit Function
                End If
                If Not IsNumeric(Me.txtCodigo.Text) Then
                    MsgBox("Debe indicar Código de la Solicitud de Cheque.", MsgBoxStyle.Critical, NombreSistema)
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       PresentaSolicitud
    ' Descripción:          Esta función permite mostrar los datos de la Ficha
    '                       localizada.
    '-------------------------------------------------------------------------
    Private Sub PresentaSolicitud()
        Try
            '-- Para cualquier tipo de Búsqueda: 
            Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("Beneficiario")
            Me.txtCodigo.Text = XdtDatos.Table.Rows(XContadorReg).Item("nCodigo")
            If IsNumeric(XdtDatos.Table.Rows(XContadorReg).Item("nCodigoFNC")) Then
                Me.txtGrupoSolidario.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreGrupo")
                Me.txtCodigoFNC.Text = XdtDatos.Table.Rows(XContadorReg).Item("nCodigoFNC")
                Me.mtbNumeroSesion.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNumSesion")
            End If
            LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            AccionUsuario = AccionBoton.BotonCancelar
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       HabilitarControles
    ' Descripción:          Esta función permite mostrar los datos de la 
    '                       busqueda indicada.
    '-------------------------------------------------------------------------
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
                Me.GrpFechasCorte.Enabled = False
                Me.mtbNumCedula.Select()

                '-- Búsqueda por Nombre Grupo Solidario:
            ElseIf Me.RadGrupo.Checked = True Then
                Me.GrpGrupoSolidario.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpCodigos.Enabled = False
                Me.GrpFechasCorte.Enabled = False
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
                Me.GrpFechasCorte.Enabled = False
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
                Me.GrpFechasCorte.Enabled = False
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
                Me.GrpFechasCorte.Enabled = False
                Me.mtbNumeroSesion.Select()

                '-- Búsqueda por Fechas de Corte:
            ElseIf Me.RadFechas.Checked = True Then
                Me.GrpFechasCorte.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                'Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.GrpCodigos.Enabled = False
                Me.cdeFechaD.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       CmdPrimero_Click
    ' Descripción:          Permite ir al primer registro localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaSolicitud()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       cmdUltimo_Click
    ' Descripción:          Permite ir al ultimo registro localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSolicitud()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       CmdAnterior_Click
    ' Descripción:          Permite ir al registro anterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSolicitud()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       cmdSiguiente_Click
    ' Descripción:          Permite ir al registro posterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSolicitud()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2009
    ' Procedure Name:       cmdBuscar_Click
    ' Descripción:          Permite establecer busqueda.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim cadWhere As String = ""
            Dim strSQL As String = ""
            Me.errSolicitud.Clear()

            If ValidaDatosEntrada() Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                '**********************************************************************************
                '************************* De acuerdo con el Tipo de Busqueda *********************
                '**********************************************************************************
                '-- 1. Búsqueda Por Cédula.
                If Me.radCedula.Checked Then
                    cadWhere = " WHERE (a.Cedula = '" & Me.mtbNumCedula.Text & "') "

                    '-- 2. Búsqueda Por Número de Sesión. 
                ElseIf Me.radSesion.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.sNumSesion= '" & Me.mtbNumeroSesion.Text & "') "
                    Else
                        cadWhere = cadWhere & " And (a.sNumSesion='" & Me.mtbNumeroSesion.Text & "') "
                    End If

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

                    '-- 4. Búsqueda Por Código de la FNC.
                ElseIf Me.RadCodigoFNC.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nCodigoFNC= " & Trim(Me.txtCodigoFNC.Text) & ") "
                    Else
                        cadWhere = cadWhere & " And (a.nCodigoFNC= " & Trim(Me.txtCodigoFNC.Text) & ") "
                    End If

                    '-- 5. Búsqueda Por Código de Solicitud.
                ElseIf Me.RadCodigo.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nCodigo= " & Trim(Me.txtCodigo.Text) & ") "
                    Else
                        cadWhere = cadWhere & " And (a.nCodigo= " & Trim(Me.txtCodigo.Text) & ") "
                    End If

                    '-- 6. Búsqueda Por Fechas de Corte:
                ElseIf Me.RadFechas.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                    Else
                        cadWhere = cadWhere & " AND (a.dFechaSolicitudCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                    End If
                End If

                REM
                'Si Usuario unicamente puede Consultar Solicitudes de su Delegación:
                If Me.IdSclConsultarDelegacion <> 1 Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") "
                    Else
                        cadWhere = cadWhere & " And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") "
                    End If
                End If
                REM 

                'Asigna Consulta de la Ficha de Notificación:               
                strSQL = " SELECT * " & _
                         " FROM vwSccSolicitudCheque AS a "
                '0 Busca todos,1 no presenta los de proveedores .


                If Me.ModoAccion <> "REV" And Me.ModoAccion <> "AUT" Then




                    If Me.TipoCheque = 1 Then 'Filtar para que no vean los cheques de egresos tipo solicitud cheque 3
                        If Trim(cadWhere) = "" Then
                            cadWhere = " where a.nSccTipoSolicitudChequeID<=2"
                        Else

                            cadWhere = cadWhere + " and a.nSccTipoSolicitudChequeID<=2"
                        End If
                    Else
                        If Trim(cadWhere) = "" Then
                            cadWhere = " where a.nSccTipoSolicitudChequeID=3"
                        Else

                            cadWhere = cadWhere + " and a.nSccTipoSolicitudChequeID=3"
                        End If

                    End If

                End If

                'Asigna Criterio de Búsqueda:
                strSQL = strSQL & cadWhere


                XContadorReg = 0
                XdtDatos.ExecuteSql(strSQL)

                'En caso de NO encontrar registros:
                If XdtDatos.Count = 0 Then
                    MsgBox("Solicitud NO Encontrada.", MsgBoxStyle.Information, NombreSistema)
                    grpBotones.Enabled = False
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Else 'Se encontraron registros:
                    grpBotones.Enabled = True
                    Me.StrCriterioSolicitud = cadWhere
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

    Private Sub txtCodigoFNC_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoFNC.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub radCedula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCedula.Click
        HabilitarControles()
    End Sub

    Private Sub RadSocia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrupo.Click
        HabilitarControles()
    End Sub

    Private Sub RadCodigoFNC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigoFNC.Click
        HabilitarControles()
    End Sub

    Private Sub RadCodigo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigo.Click
        HabilitarControles()
    End Sub

    Private Sub RadFechas_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadFechas.CheckedChanged
        HabilitarControles()
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub radSesion_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radSesion.CheckedChanged
        HabilitarControles()
    End Sub
End Class