' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                03/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclBusquedaSocias.vb
' Descripción:          Este formulario permite buscar Socias del Programa
'-------------------------------------------------------------------------
Public Class frmSclBusquedaSocias

    '-- Declaracion de Variables 
    Dim IdSclTipoBusqueda As Integer
    Dim IdSclConsultarDelegacion As Integer
    Dim StrCriterio As String
    Dim cadOrder As String = ""
    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    Dim XContadorReg As Integer
    Dim XContadorTotal As Integer
    Dim IdStbDepartamento As Integer

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

    Public ReadOnly Property ContadorActual() As Integer
        Get
            ContadorActual = XContadorTotal + 1 - (XContadorReg + 1) 'Para devolver 1=Ultimo credito, X=primer credito (Meta de Prosperidad)
        End Get
    End Property

    'Propiedad utilizada para obtener el Tipo de Busqueda:
    '1: Busqueda por Nombre de Socia o Cédula (Desde Catálogo de Socias).
    '2: Fichas de Inscripcion
    '3: Referencias Personales de Socias
    Public Property IdTipoBusqueda() As Integer
        Get
            IdTipoBusqueda = IdSclTipoBusqueda
        End Get

        Set(ByVal value As Integer)
            IdSclTipoBusqueda = value
        End Set
    End Property
    ' Departamento del Grupo Solidario, para la 
    ' busqueda en el caso de la Ficha de Inscripción 
    ' y Verificación.
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = IdStbDepartamento
        End Get
        Set(ByVal value As Integer)
            IdStbDepartamento = value
        End Set
    End Property

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

    'Propiedad utilizada para retornar el Criterio de Búsqueda del usuario:
    Public Property StrCriterioSocia() As String
        Get
            StrCriterioSocia = StrCriterio
        End Get
        Set(ByVal value As String)
            StrCriterio = value
        End Set
    End Property

    Public ReadOnly Property StrOrderBy() As String
        Get
            StrOrderBy = cadOrder
        End Get
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       frmSclBusquedaSocias_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaSocias_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
        'Try
        '    'Declaracion de Variables 
        '    AccionUsuario = AccionBoton.BotonCancelar
        '    'Me.Close()

        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       frmSclBusquedaSocias_Load
    ' Descripción:          Load del formulario donde se inicializan variables.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaSocias_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

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
    ' Fecha:                03/07/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            
            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            Me.mtbNumCedula.MaxLength = 16
            Me.grpBotones.Enabled = False
            Me.ChkTipoBusqueda.Checked = True
            XContadorReg = 0

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
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
    ' Fecha:                03/07/2008
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

            If ChkTipoBusqueda.Checked Then '-- Búsqueda por Cédula:
                'Número de Cédula Obligatorio:
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

                ''Cedula Socia debe existir en Catálogo de Socias:
                'If Me.IdSclTipoBusqueda = 1 Then
                '    If Me.IdSclConsultarDelegacion = 1 Then 'Puede visualizar todas las Delegaciones del Programa. '" Where NombreSocia Like '" & sCadenaFiltro & "'" & _
                '        strSQL = "SELECT nSclSociaID FROM  SclSocia WHERE (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                '    Else 'Solo Filtra las Socias de su Delegación:
                '        strSQL = "SELECT nSclSociaID FROM  SclSocia WHERE (sNumeroCedula = '" & Me.mtbNumCedula.Text & "') and (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                '    End If
                'ElseIf Me.IdSclTipoBusqueda = 2 Then
                '    If Me.IdSclConsultarDelegacion = 1 Then 'Puede visualizar todas las Delegaciones del Programa. '" Where NombreSocia Like '" & sCadenaFiltro & "'" & _
                '        strSQL = " SELECT a.nSclFichaSociaID " & _
                '                 " FROM vwSclFichaInscripcion a " & _
                '                 " WHERE a.nStbDepartamentoID = " & Me.IdDepartamento & _
                '                 " AND (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')"
                '    Else 'Solo Filtra las Socias de su Delegación:
                '        strSQL = " SELECT a.nSclFichaSociaID " & _
                '                 " FROM vwSclFichaInscripcion a " & _
                '                 " WHERE a.nStbDepartamentoID = " & Me.IdDepartamento & _
                '                 " AND (sNumeroCedula = '" & Me.mtbNumCedula.Text & "')" & _
                '                 " AND a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion
                '    End If
                'End If

                'If RegistrosAsociados(strSQL) = False Then
                '    If Me.IdSclConsultarDelegacion = 1 Then 'Puede visualizar todas las Delegaciones del Programa. '" Where NombreSocia Like '" & sCadenaFiltro & "'" & _
                '        MsgBox("No existe socia con este Número de Cédula.", MsgBoxStyle.Critical, NombreSistema)
                '    Else
                '        MsgBox("No existe socia con esta Cédula para su Delegación.", MsgBoxStyle.Critical, NombreSistema)
                '    End If
                '    Me.errSocia.SetError(Me.mtbNumCedula, "No existe socia con este Número de Cédula.")
                '    Me.mtbNumCedula.Focus()
                '    ValidaDatosEntrada = False
                '    Exit Function
                'End If
            Else '-- Búsqueda por Nombres de la Socia:
                'Primer Nombre Obligatorio:
                'If Trim(RTrim(Me.TxtPrimerNombre.Text)).ToString.Length = 0 Then
                '    MsgBox("Debe indicar el primer nombre de la Socia.", MsgBoxStyle.Critical, NombreSistema)
                '    ValidaDatosEntrada = False
                '    Me.errSocia.SetError(Me.TxtPrimerNombre, "Debe indicar el primer nombre de la Socia.")
                '    Me.TxtPrimerNombre.Focus()
                '    Exit Function
                'End If
                'Primer Apellido Obligatorio:
                'If Trim(RTrim(Me.TxtPrimerApellido.Text)).ToString.Length = 0 Then
                '    MsgBox("Debe indicar el primer apellido de la Socia.", MsgBoxStyle.Critical, NombreSistema)
                '    ValidaDatosEntrada = False
                '    Me.errSocia.SetError(Me.TxtPrimerApellido, "Debe indicar el primer apellido de la Socia.")
                '    Me.TxtPrimerApellido.Focus()
                '    Exit Function
                'End If
                ''Al menos uno:
                'If Trim(Me.TxtPrimerNombre.Text) = "" And Trim(Me.TxtSegundoNombre.Text) = "" And Trim(Me.TxtPrimerApellido.Text) = "" And Trim(Me.TxtSegundoApellido.Text) = "" Then
                '    MsgBox("Debe indicar al menos uno de los nombres o apellidos .", MsgBoxStyle.Critical, NombreSistema)
                '    ValidaDatosEntrada = False
                '    Me.errSocia.SetError(Me.TxtPrimerNombre, "Debe indicar al menos uno de los nombres o apellidos .")
                '    Me.TxtPrimerNombre.Focus()
                '    Exit Function
                'End If
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
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       PresentaSocia
    ' Descripción:          Esta función permite mostrar los datos de la socia
    '                       localizada.
    '-------------------------------------------------------------------------
    Private Sub PresentaSocia()
        Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreSocia")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
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
    ' Fecha:                03/07/2008
    ' Procedure Name:       ChkTipoBusqueda_CheckedChanged
    ' Descripción:          En caso de cambio del tipo de busqueda.
    '-------------------------------------------------------------------------
    Private Sub ChkTipoBusqueda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTipoBusqueda.CheckedChanged
        If ChkTipoBusqueda.Checked Then 'Busqueda Por Cédula
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       CmdPrimero_Click
    ' Descripción:          Permite ir al primer registro localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaSocia()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       cmdUltimo_Click
    ' Descripción:          Permite ir al ultimo registro localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaSocia()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       CmdAnterior_Click
    ' Descripción:          Permite ir al registro anterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Está sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaSocia()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       cmdSiguiente_Click
    ' Descripción:          Permite ir al registro posterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Está sobre el último registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaSocia()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       cmdBuscar_Click
    ' Descripción:          Permite establecer busqueda.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try

            Dim cadWhere As String = ""
            Dim strSQL As String = ""
            Me.errSocia.Clear()
            Me.Cursor = Cursors.WaitCursor
            If ValidaDatosEntrada() Then
                If ChkTipoBusqueda.Checked Then '-- Busqueda Por Cédula.
                    cadWhere = "Where sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"
                    '--strSQL = strSQL + cadWhere
                Else '-- Busqueda Por Nombres.
                    'Si se indicó el Primer Nombre:
                    If Trim(Me.TxtPrimerNombre.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "'"
                        Else
                            cadWhere = cadWhere & " And sNombre1='" & Trim(Me.TxtPrimerNombre.Text) & "'"
                        End If
                    End If
                    'Si se indicó el Segundo Nombre:
                    If Trim(Me.TxtSegundoNombre.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "'"
                        Else
                            cadWhere = cadWhere & " And sNombre2='" & Trim(Me.TxtSegundoNombre.Text) & "'"
                        End If
                    End If
                    'Si se indicó el Primer Apellido:
                    If Trim(Me.TxtPrimerApellido.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "'"
                        Else
                            cadWhere = cadWhere & " And sApellido1='" & Trim(Me.TxtPrimerApellido.Text) & "'"
                        End If
                    End If
                    'Si se indicó el Segundo Apellido:
                    If Trim(Me.TxtSegundoApellido.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "'"
                        Else
                            cadWhere = cadWhere & " And sApellido2='" & Trim(Me.TxtSegundoApellido.Text) & "'"
                        End If
                    End If
                End If

                'Usuario unicamente puede Consultar Socias de su Delegación:
                If Me.IdSclConsultarDelegacion <> 1 Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    ElseIf Me.IdSclTipoBusqueda <> 6
                        cadWhere = cadWhere & " And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    End If
                End If

                '**********************************************************************************
                '************************* De acuerdo con el Tipo de Busqueda *********************
                '**********************************************************************************
                If Me.IdSclTipoBusqueda = 1 Then 'Busqueda de Socias (Desde el Catálogo de Socias)
                    strSQL = "Select nSociaActiva, nSclSociaID, nCodigo, NombreSocia, sNumeroCedula, sNombre1, sNombre2, sApellido1, sApellido2 " &
                             "From vwSclSocia "
                ElseIf Me.IdSclTipoBusqueda = 2 Then 'Busqueda de Socias (Desde el Catálogo de Fichas de Inscripción)
                    strSQL = "Select sNombre as NombreSocia, sNumeroCedula, sNombre1, sNombre2, sApellido1, sApellido2 " &
                             "From vwSclFichaInscripcion "
                    cadWhere = cadWhere & " AND nStbDepartamentoID = " & Me.IdDepartamento
                ElseIf Me.IdSclTipoBusqueda = 3 Then 'Busqueda de Socias (Desde pantalla de Referencias Personales)
                    strSQL = "Select nSclSociaID, nCodigo, NombreSocia, sNumeroCedula, sNombre1, sNombre2, sApellido1, sApellido2 " &
                             "From vwSclSociasConReferencias "
                ElseIf Me.IdSclTipoBusqueda = 4 Then 'Busqueda de Socias (Desde el Catálogo de Fichas de Verificación)
                    strSQL = "Select sNombre as NombreSocia, sNumeroCedula, sNombre1, sNombre2, sApellido1, sApellido2 " &
                             "From vwSclFichaVerificacion "
                    cadWhere = cadWhere & " AND nStbDepartamentoID = " & Me.IdDepartamento & " And sCodigoEstadoFicha > '1'"
                ElseIf Me.IdSclTipoBusqueda = 5 Then 'Busqueda socias por creditos aprobados (Para Meta de Prosperidad)
                    strSQL = "SELECT Socia as NombreSocia, sNumeroCedula, sNombre1, sNombre2, sApellido1, sApellido2 FROM vwSclMetaProsperidadCreditoSocia "
                    cadWhere = cadWhere & " AND nStbDepartamentoID = " & Me.IdDepartamento & " And sCodigoEstadoFicha > '1' "
                    cadOrder &= " order by nNoPrestamoSocia desc "
                ElseIf Me.IdSclTipoBusqueda = 6 Then
                    strSQL = " SELECT        nSclSupervisionID, NombreSocia, sNumeroCedula, sNombre1, sNombre2, sApellido1, sApellido2, nSclSociaID, nActivo " &
                             " FROM            (SELECT        dbo.vwSclSupervision.nSclSupervisionID, dbo.vwSclSupervision.nActivo, dbo.vwSclSocia.NombreSocia, dbo.vwSclSocia.sNumeroCedula, dbo.vwSclSocia.sNombre1, " &
                             " dbo.vwSclSocia.sNombre2, dbo.vwSclSocia.sApellido1, dbo.vwSclSocia.sApellido2, dbo.vwSclSupervision.nSclSociaID " &
                             " FROM            dbo.vwSclSupervision INNER JOIN " &
                             " dbo.vwSclSocia ON dbo.vwSclSupervision.nSclSociaID = dbo.vwSclSocia.nSclSociaID) AS I " &
                             " where nActivo=1 And sNumeroCedula='" & mtbNumCedula.Text & "'"
                End If
                'Asigna Criterio de Busqueda:
                If IdTipoBusqueda <> 6 Then
                    strSQL = strSQL & cadWhere
                End If

                XContadorReg = 0
                    XdtDatos.ExecuteSql(strSQL)
                    XContadorTotal = XdtDatos.Count

                    If ChkTipoBusqueda.Checked Then '-- Busqueda Por Cédula.
                        If XdtDatos.Count = 0 Then
                        MsgBox("Socia NO Encontrada.", MsgBoxStyle.Critical, NombreSistema)
                        grpBotones.Enabled = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "Socia NO Encontrada.")
                        Me.mtbNumCedula.Focus()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        Else 'Se encontró Cédula con esta Socia
                            grpBotones.Enabled = True
                            Me.StrCriterioSocia = cadWhere
                            Me.txtNombreSocia.Text = XdtDatos.ValueField("NombreSocia")
                            PresentaSocia() 'LblConteo.Text = ""
                        End If

                    Else 'Busqueda Por Nombres.
                        If XdtDatos.Count = 0 Then
                        MsgBox("No se encontraron socias con ese criterio.", MsgBoxStyle.Critical, NombreSistema)
                        grpBotones.Enabled = False
                        Me.errSocia.SetError(Me.TxtPrimerNombre, "No se encontraron socias con ese criterio.")
                        Me.TxtPrimerNombre.Focus()
                            Me.Cursor = Cursors.Default
                            Exit Sub
                        Else
                            grpBotones.Enabled = True
                            Me.StrCriterioSocia = cadWhere
                            PresentaSocia()
                        End If
                    End If
                End If
                Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class