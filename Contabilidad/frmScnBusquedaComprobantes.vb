' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                17/02/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnBusquedaComprobantes.vb
' Descripci�n:          Este formulario permite buscar Comprobantes
'                       de Diario del Programa
'-------------------------------------------------------------------------
Public Class frmScnBusquedaComprobantes

    '-- Declaracion de Variables 
    Dim IdSclConsultarDelegacion As Integer
    Dim StrCriterio As String
    Dim StrTipo As String
    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    Dim XdtMinutaDeposito As BOSistema.Win.XDataSet.xDataTable

    Dim XContadorReg As Integer


    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

    'Propiedad utilizada para determinar si el usuario puede consultar
    'Comprobantes de otra delegacion.
    '1 = Puede visualizar todas las Delegaciones del Programa. 
    Public Property IdConsultarDelegacion() As Integer
        Get
            IdConsultarDelegacion = IdSclConsultarDelegacion
        End Get
        Set(ByVal value As Integer)
            IdSclConsultarDelegacion = value
        End Set
    End Property

    'Propiedad utilizada para retornar el Criterio de B�squeda del usuario:
    Public Property StrCriterioCD() As String
        Get
            StrCriterioCD = StrCriterio
        End Get
        Set(ByVal value As String)
            StrCriterio = value
        End Set
    End Property

    'Propiedad utilizada para retornar el Tipo de Comprobante:
    'CR: Credito (CR, CA[manual])
    'CD: Comprobantes (CD[manual], CC)
    Public Property StrTipoCD() As String
        Get
            StrTipoCD = StrTipo
        End Get
        Set(ByVal value As String)
            StrTipo = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       frmScnBusquedaComprobantes_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnBusquedaComprobantes_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtDatos.Close()
                XdtDatos = Nothing

                XdtMinutaDeposito.Close()
                XdtMinutaDeposito = Nothing

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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       frmScnBusquedaComprobantes_Load
    ' Descripci�n:          Load del formulario donde se inicializan variables.
    '-------------------------------------------------------------------------
    Private Sub frmScnBusquedaComprobantes_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarMinuta(0)
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       InicializarVariables
    ' Descripci�n:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            XdtMinutaDeposito = New BOSistema.Win.XDataSet.xDataTable
            Me.grpBotones.Enabled = False
            XContadorReg = 0
            Me.cboMinuta.ClearFields()

            Me.cdeFechaD.Value = CDate(FechaServer())
            Me.cdeFechaH.Value = CDate(FechaServer())

            If Me.StrTipo = "CR" Then
                Me.radMinuta.Checked = True
                Me.cboMinuta.Select()
            Else
                Me.radFechas.Checked = True
                Me.cdeFechaD.Select()
            End If

            HabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       CmdAceptar_click
    ' Descripci�n:          Este evento permite validar los datos ingresado y
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripci�n:          Esta funci�n permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Try
            Dim strSQL As String = ""
            ValidaDatosEntrada = True
            Dim nContador As Integer = 0
            Me.errBusqueda.Clear()

            '-- B�squeda por Minuta de Dep�sito:
            If Me.radMinuta.Checked = True Then
                'N�mero de Minuta Obligatorio:
                If Me.cboMinuta.SelectedIndex = -1 Then
                    MsgBox("Debe indicar Minuta de Dep�sito.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errBusqueda.SetError(Me.cboMinuta, "Debe indicar Minuta de Dep�sito.")
                    Me.cboMinuta.Focus()
                    Exit Function
                End If

                '-- B�squeda por Fechas de Corte:
            ElseIf Me.radFechas.Checked = True Then

                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte V�lidas.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errBusqueda.SetError(Me.cdeFechaD, "Debe indicar fechas de corte V�lidas.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte V�lidas.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errBusqueda.SetError(Me.cdeFechaD, "Debe indicar fechas de corte V�lidas.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errBusqueda.SetError(Me.cdeFechaD, "Fecha de Inicio no debe ser mayor que la Fecha de Corte.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                'M�ximo 6 d�as entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 6 d�as.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errBusqueda.SetError(Me.cdeFechaD, "Imposible seleccionar cortes de fecha superiores a 6 d�as.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                '-- B�squeda por N�mero de Comprobante:
            ElseIf Me.radNumero.Checked = True Then
                'N�mero de Minuta Obligatorio:
                If Me.txtNumeroCD.Text = "" Then
                    MsgBox("Debe indicar N�mero de Comprobante.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errBusqueda.SetError(Me.txtNumeroCD, "Debe indicar N�mero de Comprobante.")
                    Me.txtNumeroCD.Focus()
                    Exit Function
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       PresentaComprobante
    ' Descripci�n:          Esta funci�n permite mostrar los datos del
    '                       Comprobante de Diario localizado.
    '-------------------------------------------------------------------------
    Private Sub PresentaComprobante()
        '-- Para cualquier tipo de B�squeda: 
        Me.txtNumero.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNumeroTransaccion")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       cmdCancelar_Click
    ' Descripci�n:          Este evento permite Confirmar que el Usuario desea
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       HabilitarControles
    ' Descripci�n:          Esta funci�n permite mostrar los datos de la 
    '                       busqueda indicada.
    '-------------------------------------------------------------------------
    Private Sub HabilitarControles()
        Try

            '-- Limpiar todos los datos:
            Me.errBusqueda.Clear()
            Me.cboMinuta.Text = ""
            'Me.cdeFechaD.Text = ""
            'Me.cdeFechaH.Text = ""
            Me.txtNumeroCD.Text = ""
            Me.grpBotones.Enabled = False

            '-- B�squeda por Minuta de Dep�sito:
            If Me.radMinuta.Checked = True Then
                Me.GrpMinuta.Enabled = True
                Me.GrpFechasCorte.Enabled = False
                Me.grpNumero.Enabled = False
                Me.cboMinuta.Select()

                '-- B�squeda por Fechas de Corte:
            ElseIf Me.radFechas.Checked = True Then
                Me.GrpMinuta.Enabled = False
                Me.GrpFechasCorte.Enabled = True
                Me.grpNumero.Enabled = False
                Me.cdeFechaD.Select()

                '-- B�squeda por N�mero de Comprobante:
            ElseIf Me.radNumero.Checked = True Then
                Me.GrpMinuta.Enabled = False
                Me.GrpFechasCorte.Enabled = False
                Me.grpNumero.Enabled = True
                Me.txtNumeroCD.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       CmdPrimero_Click
    ' Descripci�n:          Permite ir al primer registro localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaComprobante()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       cmdUltimo_Click
    ' Descripci�n:          Permite ir al ultimo registro localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaComprobante()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       CmdAnterior_Click
    ' Descripci�n:          Permite ir al registro anterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdAnterior_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAnterior.Click
        If XContadorReg = 0 Then
            MsgBox("Est� sobre el primer registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg - 1
        PresentaComprobante()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       cmdSiguiente_Click
    ' Descripci�n:          Permite ir al registro posterior al actual localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdSiguiente_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSiguiente.Click
        If XContadorReg >= Me.XdtDatos.Table.Rows.Count - 1 Then
            MsgBox("Est� sobre el �ltimo registro.", MsgBoxStyle.Critical, NombreSistema)
            Exit Sub
        End If
        XContadorReg = XContadorReg + 1
        PresentaComprobante()
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       CargarMinuta
    ' Descripci�n:          Este procedimiento permite cargar el listado de 
    '                       Minutas de Dep�sito.
    '-------------------------------------------------------------------------
    Private Sub CargarMinuta(ByVal intMinutaID As Integer)
        Try
            Dim Strsql As String = ""

            If intMinutaID = 0 Then
                Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta " & _
                         " From vwSteMinutaDeposito a " & _
                         " Where (a.nCerrada = 0) " & _
                         " Order by a.sNumeroDeposito"
            Else
                Strsql = " Select a.nSteMinutaDepositoID, a.sNumeroDeposito, a.dFechaDeposito, a.sNumeroCuenta " & _
                         " From vwSteMinutaDeposito a " & _
                         " Where (a.nCerrada = 0) or (a.nSteMinutaDepositoID = " & intMinutaID & ") " & _
                         " Order by a.sNumeroDeposito"
            End If

            XdtMinutaDeposito.ExecuteSql(Strsql)
            Me.cboMinuta.DataSource = XdtMinutaDeposito.Source

            Me.cboMinuta.Splits(0).DisplayColumns("nSteMinutaDepositoID").Visible = False

            'Configurar el combo
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").Width = 90
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Width = 90
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroCuenta").Width = 100

            Me.cboMinuta.Columns("sNumeroDeposito").Caption = "No. Minuta"
            Me.cboMinuta.Columns("dFechaDeposito").Caption = "Fecha Dep�sito"
            Me.cboMinuta.Columns("sNumeroCuenta").Caption = "Cuenta Bancaria"

            Me.cboMinuta.Columns("dFechaDeposito").NumberFormat = "dd/MM/yyyy"
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("dFechaDeposito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMinuta.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                17/02/2009
    ' Procedure Name:       cmdBuscar_Click
    ' Descripci�n:          Permite establecer busqueda.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
        Try

            Dim cadWhere As String = ""
            Dim strSQL As String = ""
            Me.errBusqueda.Clear()

            If ValidaDatosEntrada() Then
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                '**********************************************************************************
                '************************* De acuerdo con el Tipo de Busqueda *********************
                '**********************************************************************************
                '-- Asignar inicialmente el Tipo de Comprobante:
                If Me.StrTipo = "CR" Then
                    cadWhere = " WHERE ((a.CodTipoCD = 'CA') OR (a.CodTipoCD = 'CR')) "
                Else
                    cadWhere = " WHERE ((a.CodTipoCD = 'CD') OR (a.CodTipoCD = 'CC')) "
                End If

                '-- 1. B�squeda Por Minuta de Dep�sito.
                If Me.radMinuta.Checked Then
                    cadWhere = cadWhere & " AND (a.nSteMinutaDepositoID = " & cboMinuta.Columns("nSteMinutaDepositoID").Value & ") "

                    '-- 2. B�squeda Por Fechas de Corte.
                ElseIf Me.radFechas.Checked Then
                    cadWhere = cadWhere & " AND (a.dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "


                    '-- 3. B�squeda Por N�mero de Comprobante:
                ElseIf Me.radNumero.Checked Then
                    cadWhere = cadWhere & " AND (a.sNumeroTransaccion = '" & Me.txtNumeroCD.Text & "') "
                End If

                REM
                'Si Usuario unicamente puede Consultar Comprobantes de su Delegaci�n:
                If Me.IdSclConsultarDelegacion <> 1 Then
                    cadWhere = cadWhere & " And (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
                End If

                'Asigna Consulta del Comprobante de Diario:               
                strSQL = " SELECT a.* " & _
                         " FROM vwScnComprobantes a "
                'Asigna Criterio de B�squeda:
                strSQL = strSQL & cadWhere

                XContadorReg = 0
                XdtDatos.ExecuteSql(strSQL)

                'En caso de NO encontrar registros:
                If XdtDatos.Count = 0 Then
                    MsgBox("NO se encontraron Comprobantes.", MsgBoxStyle.Information, NombreSistema)
                    grpBotones.Enabled = False
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Else 'Se encontraron registros:
                    grpBotones.Enabled = True
                    Me.StrCriterioCD = cadWhere
                    PresentaComprobante()
                End If
                Me.Cursor = System.Windows.Forms.Cursors.Default
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub radMinuta_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radMinuta.Click
        HabilitarControles()
    End Sub

    Private Sub radFechas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFechas.Click
        HabilitarControles()
    End Sub

    Private Sub radNumero_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radNumero.Click
        HabilitarControles()
    End Sub
End Class