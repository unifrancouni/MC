' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                08/10/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclBusquedaFichas.vb
' Descripción:          Este formulario permite buscar Fichas de Notificación
'                       del Programa
'-------------------------------------------------------------------------
Public Class frmSclBusquedaFichas

    '-- Declaracion de Variables 
    Dim IdSclConsultarDelegacion As Integer
    Dim StrCriterio As String

    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    Dim XContadorReg As Integer
    Dim IdStbDepartamento As Integer

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

    ' Departamento de la Ficha de Notificación
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = IdStbDepartamento
        End Get
        Set(ByVal value As Integer)
            IdStbDepartamento = value
        End Set
    End Property

    'Propiedad utilizada para determinar si el usuario puede consultar
    'Fichas de otra delegacion.
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
    Public Property StrCriterioFicha() As String

        Get
            StrCriterioFicha = StrCriterio
        End Get
        Set(ByVal value As String)
            StrCriterio = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       frmSclBusquedaFichas_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaFichas_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Fecha:                08/10/2008
    ' Procedure Name:       frmSclBusquedaFichas_Load
    ' Descripción:          Load del formulario donde se inicializan variables.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaFichas_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            'Ruta del Archivo de Ayuda:
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
    ' Fecha:                08/10/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
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
    ' Fecha:                08/10/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Dim nContador As Integer = 0
            Me.errSocia.Clear()

            '-- Búsqueda por Cédula:
            If Me.radCedula.Checked = True Then
                'Número de Cédula Obligatorio:
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
                
                '-- Búsqueda por Nombres de la Socia:
            ElseIf Me.RadSocia.Checked = True Then
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
                If nContador > 2 Then
                    MsgBox("Debe indicar al menos Dos Criterios de búsqueda.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.TxtPrimerNombre, "Debe indicar al menos DOS Criterios de búsqueda.")
                    Me.TxtPrimerNombre.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Nombre del Grupo Solidario:
            ElseIf Me.RadGrupo.Checked = True Then
                If Trim(RTrim(Me.TxtNombreGrupo.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar nombre del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.TxtNombreGrupo, "Debe indicar nombre del Grupo Solidario.")
                    Me.TxtNombreGrupo.Focus()
                    Exit Function
                End If

                '-- Búsqueda Código de Ficha de Notificación de Crédito:
            ElseIf Me.RadCodigoFNC.Checked = True Then
                If Trim(RTrim(Me.txtCodigoFNC.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar Código de la Ficha.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.txtCodigoFNC, "Debe indicar Código de Ficha.")
                    Me.txtCodigoFNC.Focus()
                    Exit Function
                End If
                If Not IsNumeric(Me.txtCodigoFNC.Text) Then
                    MsgBox("Debe indicar Código de la Ficha.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.txtCodigoFNC, "Debe indicar Código de Ficha.")
                    Me.txtCodigoFNC.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Número de Resolución de Crédito:
            ElseIf Me.RadSesion.Checked = True Then
                If Not IsNumeric(Mid(Me.mtbNumeroSesion.Text, 1, 1)) Then
                    MsgBox("Debe indicar Número de Resolución.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumeroSesion, "Debe indicar Número de Resolución.")
                    Me.mtbNumeroSesion.Focus()
                    Exit Function
                End If
                'Longitud válida para el Número de Sesión:
                If Len(Me.mtbNumeroSesion.Text) <> 11 Then
                    MsgBox("Debe indicar un No. de Sesión del Crédito válido.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumeroSesion, "Debe indicar un No. de Sesión del Crédito Válido.")
                    Me.mtbNumeroSesion.Focus()
                    Exit Function
                End If

                '-- Búsqueda Código (ID) de Grupo Solidario:
            ElseIf Me.RadCodigoGrupo.Checked = True Then
                If Trim(RTrim(Me.txtCodigoGrupo.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar Código del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.txtCodigoGrupo, "Debe indicar Código del Grupo Solidario.")
                    Me.txtCodigoGrupo.Focus()
                    Exit Function
                End If
                If Not IsNumeric(Me.txtCodigoGrupo.Text) Then
                    MsgBox("Debe indicar Código del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.txtCodigoGrupo, "Debe indicar Código del Grupo Solidario.")
                    Me.txtCodigoGrupo.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       PresentaFicha
    ' Descripción:          Esta función permite mostrar los datos de la Ficha
    '                       localizada.
    '-------------------------------------------------------------------------
    Private Sub PresentaFicha()
        '-- Para cualquier tipo de Búsqueda: 
        Me.txtGrupoSolidario.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNombreGS")
        Me.txtNombreCoordinadora.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreCoordinadora")
        Me.txtCodigoFNC.Text = XdtDatos.Table.Rows(XContadorReg).Item("nCodigo")
        Me.mtbNumeroSesion.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNumSesion")
        Me.txtCodigoGrupo.Text = XdtDatos.Table.Rows(XContadorReg).Item("nSclGrupoSolidarioID")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
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
    ' Fecha:                08/10/2008
    ' Procedure Name:       HabilitarControles
    ' Descripción:          Esta función permite mostrar los datos de la 
    '                       busqueda indicada.
    '-------------------------------------------------------------------------
    Private Sub HabilitarControles()
        Try

            '-- Limpiar todos los datos:
            Me.errSocia.Clear()
            Me.mtbNumCedula.Text = ""
            Me.TxtPrimerNombre.Text = ""
            Me.TxtSegundoNombre.Text = ""
            Me.TxtPrimerApellido.Text = ""
            Me.TxtSegundoApellido.Text = ""
            Me.txtNombreSocia.Text = ""
            Me.TxtNombreGrupo.Text = ""
            Me.txtGrupoSolidario.Text = ""
            Me.txtNombreCoordinadora.Text = ""
            Me.mtbNumeroSesion.Text = ""
            Me.txtCodigoFNC.Text = ""
            Me.txtCodigoGrupo.Text = ""
            Me.grpBotones.Enabled = False

            '-- Búsqueda por Cédula Socia:
            If Me.radCedula.Checked = True Then
                Me.GrpCedulaSocia.Enabled = True
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.GrpSesion.Enabled = False
                Me.mtbNumCedula.Select()

                '-- Búsqueda por Nombres Socia:
            ElseIf Me.RadSocia.Checked = True Then
                Me.GrpNombreCompleto.Enabled = True
                Me.TxtPrimerNombre.Select()
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.GrpSesion.Enabled = False

                '-- Búsqueda por Nombre Grupo Solidario:
            ElseIf Me.RadGrupo.Checked = True Then
                Me.GrpGrupoSolidario.Enabled = True
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpSesion.Enabled = False
                Me.TxtNombreGrupo.Select()

                '-- Búsqueda por Código de Ficha:
            ElseIf Me.RadCodigoFNC.Checked = True Then
                Me.GrpSesion.Enabled = True
                Me.txtCodigoFNC.Enabled = True
                Me.txtCodigoGrupo.Enabled = False
                Me.mtbNumeroSesion.Enabled = False
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.txtCodigoFNC.Select()

                '-- Búsqueda por Código de Grupo Solidario:
            ElseIf Me.RadCodigoGrupo.Checked = True Then
                Me.GrpSesion.Enabled = True
                Me.txtCodigoFNC.Enabled = False
                Me.txtCodigoGrupo.Enabled = True
                Me.mtbNumeroSesion.Enabled = False
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.txtCodigoGrupo.Select()

                '-- Búsqueda por Resolución de Crédito:
            ElseIf Me.RadSesion.Checked = True Then
                Me.GrpSesion.Enabled = True
                Me.mtbNumeroSesion.Enabled = True
                Me.txtCodigoFNC.Enabled = False
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpGrupoSolidario.Enabled = False
                Me.mtbNumeroSesion.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       CmdPrimero_Click
    ' Descripción:          Permite ir al primer registro localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaFicha()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       cmdUltimo_Click
    ' Descripción:          Permite ir al ultimo registro localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaFicha()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       CmdAnterior_Click
    ' Descripción:          Permite ir al registro anterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaFicha()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       cmdSiguiente_Click
    ' Descripción:          Permite ir al registro posterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaFicha()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       cmdBuscar_Click
    ' Descripción:          Permite establecer busqueda.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Try

            Dim cadWhere As String = ""
            Dim strSQL As String = ""
            Me.errSocia.Clear()

            If ValidaDatosEntrada() Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                '**********************************************************************************
                '************************* De acuerdo con el Tipo de Busqueda *********************
                '**********************************************************************************
                '-- 1. Búsqueda Por Cédula de Socia.
                If Me.radCedula.Checked Then
                    cadWhere = "WHERE (a.nSclFichaNotificacionID IN (SELECT DFNC.nSclFichaNotificacionID " & _
                               "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SclFichaSocia AS FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID " & _
                               "WHERE (S.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')))"

                    '-- 2. Búsqueda Por Nombres de la Coordinadora.
                ElseIf Me.RadSocia.Checked Then
                    'Si se indicó el Primer Nombre:
                    If Trim(Me.TxtPrimerNombre.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where (a.sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "')"
                        Else
                            cadWhere = cadWhere & " And (a.sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "')"
                        End If
                    End If
                    'Si se indicó el Segundo Nombre:
                    If Trim(Me.TxtSegundoNombre.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where (a.sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "')"
                        Else
                            cadWhere = cadWhere & " And (a.sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "')"
                        End If
                    End If
                    'Si se indicó el Primer Apellido:
                    If Trim(Me.TxtPrimerApellido.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where (a.sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "')"
                        Else
                            cadWhere = cadWhere & " And (a.sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "')"
                        End If
                    End If
                    'Si se indicó el Segundo Apellido:
                    If Trim(Me.TxtSegundoApellido.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where (a.sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "')"
                        Else
                            cadWhere = cadWhere & " And (a.sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "')"
                        End If
                    End If

                    '-- 3. Búsqueda Por Nombre del Grupo Solidario.
                ElseIf Me.RadGrupo.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.sNombreGS= '" & Trim(Me.TxtNombreGrupo.Text) & "')"
                    Else
                        cadWhere = cadWhere & " And (a.sNombreGS='" & Trim(Me.TxtNombreGrupo.Text) & "')"
                    End If

                    '-- 4. Búsqueda Por Código de la FNC.
                ElseIf Me.RadCodigoFNC.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nCodigo= " & Trim(Me.txtCodigoFNC.Text) & ")"
                    Else
                        cadWhere = cadWhere & " And (a.nCodigo= " & Trim(Me.txtCodigoFNC.Text) & ")"
                    End If

                    '-- 5. Búsqueda Por Número de la Resolución.
                ElseIf Me.RadSesion.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.sNumSesion= '" & Trim(Me.mtbNumeroSesion.Text) & "')"
                    Else
                        cadWhere = cadWhere & " And (a.sNumSesion='" & Trim(Me.mtbNumeroSesion.Text) & "')"
                    End If

                    '-- 6. Búsqueda Por Código de Grupo.
                ElseIf Me.RadCodigoGrupo.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nSclGrupoSolidarioID= " & Trim(Me.txtCodigoGrupo.Text) & ")"
                    Else
                        cadWhere = cadWhere & " And (a.nSclGrupoSolidarioID= " & Trim(Me.txtCodigoGrupo.Text) & ")"
                    End If

                End If

                'Si Usuario unicamente puede Consultar Fichas de su Delegación:
                If Me.IdSclConsultarDelegacion <> 1 Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    Else
                        cadWhere = cadWhere & " And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    End If
                End If

                'Para cualquier tipo de búsqueda Ubicar Fichas del Departamento:
                If Trim(cadWhere) = "" Then
                    cadWhere = " Where (a.nStbDepartamentoID = " & Me.IdStbDepartamento & ")"
                Else
                    cadWhere = cadWhere & " And (a.nStbDepartamentoID = " & Me.IdStbDepartamento & ")"
                End If

                'Unicamente Mostrar Fichas Activas:
                If Me.radFichasActivas.Checked Then 'Unicamente las Fichas Activas
                    cadWhere = cadWhere & " And (a.sCodEstado <> '5' AND a.sCodEstado <> '4')"
                End If

                'Asigna Consulta de la Ficha de Notificación:               
                strSQL = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
                         " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
                         " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio " & _
                         " FROM vwSclFichaNotificacionCredito AS a "
                'Asigna Criterio de Búsqueda:
                strSQL = strSQL & cadWhere

                XContadorReg = 0
                XdtDatos.ExecuteSql(strSQL)

                'En caso de NO encontrar registros:
                If XdtDatos.Count = 0 Then
                    MsgBox("Ficha NO Encontrada en Este Departamento.", MsgBoxStyle.Information, NombreSistema)
                    grpBotones.Enabled = False
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Else 'Se encontraron registros:
                    grpBotones.Enabled = True
                    Me.StrCriterioFicha = cadWhere
                    '-- Búsqueda por Cédula:
                    If Me.radCedula.Checked Then
                        strSQL = " SELECT sNombre1 + ' ' + sNombre2 + ' ' + sApellido1 + ' ' + sApellido2 as NombreSocia " & _
                                 " FROM SclSocia WHERE (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                        XdtSocia.ExecuteSql(strSQL)
                        Me.txtNombreSocia.Text = XdtSocia.ValueField("NombreSocia")
                    End If
                    PresentaFicha()
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

    'Private Sub radCedula_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radCedula.CheckedChanged
    '    HabilitarControles()
    'End Sub
    Private Sub radCedula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCedula.Click
        HabilitarControles()
    End Sub

    Private Sub RadSocia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadSocia.Click
        HabilitarControles()
    End Sub

    Private Sub RadGrupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadGrupo.Click
        HabilitarControles()
    End Sub

    Private Sub RadCodigoFNC_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigoFNC.Click
        HabilitarControles()
    End Sub

    Private Sub RadSesion_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadSesion.Click
        HabilitarControles()
    End Sub

    Private Sub txtCodigoGrupo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigoGrupo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub RadCodigoGrupo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadCodigoGrupo.Click
        HabilitarControles()
    End Sub
End Class