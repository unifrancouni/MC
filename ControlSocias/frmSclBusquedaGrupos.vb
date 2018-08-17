' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                08/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclBusquedaGrupos.vb
' Descripción:          Este formulario permite buscar Grupos del Programa
'-------------------------------------------------------------------------
Public Class frmSclBusquedaGrupos

    '-- Declaracion de Variables 
    Dim IdSclTipoBusqueda As Integer
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

    'Propiedad utilizada para obtener el Tipo de Busqueda:
    '1: Busqueda por Nombre de Grupo o Cédula Socia (Desde Catálogo de Grupos).
    Public Property IdTipoBusqueda() As Integer
        Get
            IdTipoBusqueda = IdSclTipoBusqueda
        End Get
        Set(ByVal value As Integer)
            IdSclTipoBusqueda = value
        End Set
    End Property

    'Propiedad utilizada para determinar si el usuario puede consultar
    'Grupos de otra delegacion.
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
    Public Property StrCriterioGrupo() As String
        Get
            StrCriterioGrupo = StrCriterio
        End Get
        Set(ByVal value As String)
            StrCriterio = value
        End Set
    End Property

    ' Departamento del Grupo Solidario.
    Public Property IdDepartamento() As Integer
        Get
            IdDepartamento = IdStbDepartamento
        End Get
        Set(ByVal value As Integer)
            IdStbDepartamento = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       frmSclBusquedaGrupos_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaGrupos_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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
    ' Fecha:                08/07/2008
    ' Procedure Name:       frmSclBusquedaSocias_Load
    ' Descripción:          Load del formulario donde se inicializan variables.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaGrupos_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            'Ruta de Archivo de Ayuda:
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
    ' Fecha:                08/07/2008
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

            If Me.IdSclTipoBusqueda = 2 Or Me.IdSclTipoBusqueda = 4 Then
                Me.ChkTipoBusqueda.Enabled = False
                Me.LblConteo.Visible = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
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
    ' Fecha:                08/07/2008
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Me.errGrupo.Clear()

            If ChkTipoBusqueda.Checked Then '-- Búsqueda por Cédula Socia:
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupo.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
            Else '-- Búsqueda por Nombre del Grupo Solidario:
                If Trim(RTrim(Me.TxtNombreGrupo.Text)).ToString.Length = 0 Then
                    MsgBox("Debe indicar nombre del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errGrupo.SetError(Me.TxtNombreGrupo, "Debe indicar nombre del Grupo Solidario.")
                    Me.TxtNombreGrupo.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       PresentaGrupoSolidario
    ' Descripción:          Esta función permite mostrar los datos del grupo
    '                       localizado.
    '-------------------------------------------------------------------------
    Private Sub PresentaGrupoSolidario()
        Me.txtGrupoSolidario.Text = XdtDatos.Table.Rows(XContadorReg).Item("sDescripcion")
        Me.txtNombreCoordinadora.Text = XdtDatos.Table.Rows(XContadorReg).Item("NombreCoordinadora")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
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
    ' Fecha:                08/07/2008
    ' Procedure Name:       ChkTipoBusqueda_CheckedChanged
    ' Descripción:          En caso de cambio del tipo de busqueda.
    '-------------------------------------------------------------------------
    Private Sub ChkTipoBusqueda_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ChkTipoBusqueda.CheckedChanged
        If ChkTipoBusqueda.Checked Then 'Busqueda Por Cédula
            Me.TxtNombreGrupo.Text = ""
            Me.grpBotones.Enabled = False
            Me.mtbNumCedula.Enabled = True
            Me.GrpNombreCompleto.Enabled = False
            Me.mtbNumCedula.Select()
        Else
            Me.grpBotones.Enabled = True
            Me.mtbNumCedula.Enabled = False
            Me.GrpNombreCompleto.Enabled = True
            mtbNumCedula.Text = ""
            Me.TxtNombreGrupo.Select()
        End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       CmdPrimero_Click
    ' Descripción:          Permite ir al primer registro localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaGrupoSolidario()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       cmdUltimo_Click
    ' Descripción:          Permite ir al ultimo registro localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaGrupoSolidario()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       CmdAnterior_Click
    ' Descripción:          Permite ir al registro anterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Esta sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaGrupoSolidario()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       cmdSiguiente_Click
    ' Descripción:          Permite ir al registro posterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Esta sobre el ultimo registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaGrupoSolidario()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       cmdBuscar_Click
    ' Descripción:          Permite establecer busqueda.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try

            Dim cadWhere As String = ""
            Dim strSQL As String = ""
            Me.errGrupo.Clear()

            If ValidaDatosEntrada() Then
                If ChkTipoBusqueda.Checked Then '-- Busqueda Por Cédula. "Where sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"
                    cadWhere = " Where (nSclGrupoSolidarioID IN (SELECT GS.nSclGrupoSolidarioID FROM SclGrupoSocia AS GS INNER JOIN SclSocia AS S ON GS.nSclSociaID = S.nSclSociaID  WHERE  (S.sNumeroCedula = '" & Me.mtbNumCedula.Text & "')))"
                Else '-- Busqueda Por Nombre Grupo Solidario.
                    If Trim(Me.TxtNombreGrupo.Text) <> "" Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = " Where sDescripcion ='" & Trim(Me.TxtNombreGrupo.Text) & "'"
                        Else
                            cadWhere = cadWhere & " And sDescripcion ='" & Trim(Me.TxtNombreGrupo.Text) & "'"
                        End If
                    End If
                End If

                'Usuario unicamente puede Consultar Grupos de su Delegación:
                If Me.IdSclConsultarDelegacion <> 1 Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    Else
                        cadWhere = cadWhere & " And (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                    End If
                End If

                '**********************************************************************************
                '************************* De acuerdo con el Tipo de Busqueda *********************
                '**********************************************************************************
                If Me.IdSclTipoBusqueda = 1 Then 'Busqueda de Socias (Desde el Catálogo de Socias)
                    strSQL = "Select nSclGrupoSolidarioID, sDescripcion, NombreCoordinadora " & _
                             "From vwSclGrupoSolidario "
                    cadWhere = cadWhere & " AND nStbDepartamentoID = " & Me.IdStbDepartamento
                ElseIf Me.IdSclTipoBusqueda = 2 Then
                    strSQL = "Select nSclGrupoSolidarioID, sNombreGrupo as sDescripcion,'' as NombreCoordinadora " & _
                             "From vwSclFichaInscripcion "
                    cadWhere = cadWhere & " AND nStbDepartamentoID = " & Me.IdStbDepartamento
                ElseIf Me.IdSclTipoBusqueda = 4 Then
                    strSQL = "Select nSclGrupoSolidarioID, sNombreGrupo as sDescripcion,'' as NombreCoordinadora " & _
                             "From vwSclFichaVerificacion "
                    cadWhere = cadWhere & " AND nStbDepartamentoID = " & Me.IdDepartamento & " And sCodigoEstadoFicha > '1'"
                End If

                'Asigna Criterio de Busqueda:
                strSQL = strSQL & cadWhere

                XContadorReg = 0
                XdtDatos.ExecuteSql(strSQL)
                If ChkTipoBusqueda.Checked Then '-- Busqueda Por Cédula.
                    If XdtDatos.Count = 0 Then
                        MsgBox("Socia NO encontrada en un Grupo Solidario" & Chr(13) & "de este Departamento.", MsgBoxStyle.Critical, NombreSistema)
                        grpBotones.Enabled = False
                        Me.errGrupo.SetError(Me.mtbNumCedula, "Socia NO encontrada en un Grupo Solidario de este Departamento.")
                        Me.mtbNumCedula.Focus()
                        Exit Sub
                    Else 'Se encontró Cédula con esta Socia
                        grpBotones.Enabled = True
                        Me.StrCriterioGrupo = cadWhere
                        'Me.txtNombreSocia.Text = XdtDatos.ValueField("NombreCoordinadora")
                        PresentaGrupoSolidario()
                    End If

                Else 'Busqueda Por Nombre Grupo Solidario.
                    If XdtDatos.Count = 0 Then
                        MsgBox("Grupo Solidario NO encontrado en ese Departamento.", MsgBoxStyle.Critical, NombreSistema)
                        grpBotones.Enabled = False
                        Me.errGrupo.SetError(Me.TxtNombreGrupo, "Grupo Solidario NO encontrado en ese Departamento.")
                        Me.TxtNombreGrupo.Focus()
                        Exit Sub
                    Else
                        grpBotones.Enabled = True
                        Me.StrCriterioGrupo = cadWhere
                        PresentaGrupoSolidario()
                    End If
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class