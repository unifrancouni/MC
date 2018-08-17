' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                10/07/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclBusquedaFichasSeguimiento.vb
' Descripción:          Este formulario permite buscar Fichas de Seguimiento
'                       del Programa
'-------------------------------------------------------------------------
Public Class frmSclBusquedaFichasSeguimiento

    '-- Declaracion de Variables 
    Dim IdSclConsultarDelegacion As Integer
    Dim StrCriterio As String
    Dim IdSclTipoBusqueda As Integer

    Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
    Dim XdtTecnico As BOSistema.Win.XDataSet.xDataTable
    Dim XContadorReg As Integer

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton

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

    'Propiedad utilizada para obtener el Tipo de Busqueda:
    '1: Busqueda de Fichas de Seguimiento.
    '2: Busqueda de Arreglos de Pago (Socias)
    Public Property IdTipoBusqueda() As Integer
        Get
            IdTipoBusqueda = IdSclTipoBusqueda
        End Get

        Set(ByVal value As Integer)
            IdSclTipoBusqueda = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
    ' Procedure Name:       frmSclBusquedaFichasSeguimiento_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaFichasSeguimiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then

                XdtDatos.Close()
                XdtDatos = Nothing

                XdtTecnico.Close()
                XdtTecnico = Nothing

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
    ' Fecha:                10/07/2009
    ' Procedure Name:       frmSclBusquedaFichasSeguimiento_Load
    ' Descripción:          Load del formulario donde se inicializan variables.
    '-------------------------------------------------------------------------
    Private Sub frmSclBusquedaFichasSeguimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath

            If Me.IdSclTipoBusqueda = 1 Then
                ObjGUI.SetFormLayout(Me, "RojoLight")
            Else
                ObjGUI.SetFormLayout(Me, "Verde")
            End If


            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarTecnico(0)
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
    ' Fecha:                10/07/2009
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdtDatos = New BOSistema.Win.XDataSet.xDataTable
            XdtTecnico = New BOSistema.Win.XDataSet.xDataTable
            Me.mtbNumCedula.MaxLength = 16
            Me.grpBotones.Enabled = False
            Me.cboTecnico.ClearFields()
            XContadorReg = 0
            HabilitarControles()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
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
    ' Fecha:                10/07/2009
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

                '-- Búsqueda por Nombre del Tecnico:
            ElseIf Me.RadTecnico.Checked = True Then
                If Me.cboTecnico.SelectedIndex = -1 Then
                    MsgBox("Debe indicar nombre del técnico.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cboTecnico, "Debe indicar nombre del Técnico.")
                    Me.cboTecnico.Focus()
                    Exit Function
                End If

                '-- Búsqueda por Fechas de Corte:
            ElseIf Me.RadFechas.Checked = True Then
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cdeFechaD, "Debe indicar fechas de corte Válidas.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cdeFechaD, "Debe indicar fechas de corte Válidas.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cdeFechaD, "Fecha de Inicio no debe ser mayor que la Fecha de Corte.")
                    Me.cdeFechaD.Focus()
                    Exit Function
                End If

                'Máximo un mes días entre la fecha de inicio y corte:
                If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cdeFechaD, "Imposible seleccionar cortes de fecha superiores a 31 días.")
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
    ' Fecha:                10/07/2009
    ' Procedure Name:       PresentaFicha
    ' Descripción:          Esta función permite mostrar los datos de la Ficha
    '                       localizada.
    '-------------------------------------------------------------------------
    Private Sub PresentaFicha()
        '-- Para cualquier tipo de Búsqueda: 
        Me.txtNombreSocia.Text = XdtDatos.Table.Rows(XContadorReg).Item("Socia")
        Me.mtbNumCedula.Text = XdtDatos.Table.Rows(XContadorReg).Item("sNumeroCedula")
        LblConteo.Text = XContadorReg + 1 & " De " & XdtDatos.Table.Rows.Count & " Registros "
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
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
    ' Fecha:                10/07/2009
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
            Me.cboTecnico.Text = ""
            Me.grpBotones.Enabled = False

            '-- Búsqueda por Cédula Socia:
            If Me.radCedula.Checked = True Then
                Me.GrpCedulaSocia.Enabled = True
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpTecnico.Enabled = False
                Me.GrpFechas.Enabled = False
                Me.mtbNumCedula.Select()

                '-- Búsqueda por Nombres Socia:
            ElseIf Me.RadSocia.Checked = True Then
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = True
                Me.GrpTecnico.Enabled = False
                Me.GrpFechas.Enabled = False
                Me.TxtPrimerNombre.Select()

                '-- Búsqueda por Nombre Técnico:
            ElseIf Me.RadTecnico.Checked = True Then
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpTecnico.Enabled = True
                Me.GrpFechas.Enabled = False
                Me.cboTecnico.Select()

                '-- Búsqueda por Fechas de Corte:
            ElseIf Me.RadFechas.Checked = True Then
                Me.GrpCedulaSocia.Enabled = False
                Me.GrpNombreCompleto.Enabled = False
                Me.GrpTecnico.Enabled = False
                Me.GrpFechas.Enabled = True
                Me.cdeFechaD.Select()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
    ' Procedure Name:       CmdPrimero_Click
    ' Descripción:          Permite ir al primer registro localizado.
    '-------------------------------------------------------------------------
    Private Sub CmdPrimero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdPrimero.Click
        XContadorReg = 0
        PresentaFicha()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
    ' Procedure Name:       cmdUltimo_Click
    ' Descripción:          Permite ir al ultimo registro localizado.
    '-------------------------------------------------------------------------
    Private Sub cmdUltimo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUltimo.Click
        XContadorReg = Me.XdtDatos.Table.Rows.Count - 1
        PresentaFicha()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
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
    ' Fecha:                10/07/2009
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
    ' Fecha:                10/07/2009
    ' Procedure Name:       cmdBuscar_Click
    ' Descripción:          Permite establecer busqueda.
    '-------------------------------------------------------------------------
    Private Sub cmdBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBuscar.Click
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
                    cadWhere = "Where a.sNumeroCedula = '" & Me.mtbNumCedula.Text & "'"

                    '-- 2. Búsqueda Por Nombres de la Socia.
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

                    '-- 3. Búsqueda Por Nombre del Tecnico.
                ElseIf Me.RadTecnico.Checked Then
                    If Trim(cadWhere) = "" Then
                        cadWhere = " Where (a.nSrhTecnicoID= " & Me.cboTecnico.Columns("nSrhEmpleadoID").Value & ")"
                    Else
                        cadWhere = cadWhere & " And (a.nSrhTecnicoID=" & Me.cboTecnico.Columns("nSrhEmpleadoID").Value & ")"
                    End If

                    '-- 4. Búsqueda Por Fechas de Corte.
                ElseIf Me.RadFechas.Checked Then
                    If Me.IdSclTipoBusqueda = 1 Then
                        If Trim(cadWhere) = "" Then
                            cadWhere = cadWhere & " Where (a.dFechaFicha BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                        Else
                            cadWhere = cadWhere & " AND (a.dFechaFicha BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                        End If
                    Else
                        If Trim(cadWhere) = "" Then
                            cadWhere = cadWhere & " Where (a.dFechaArregloPago BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                        Else
                            cadWhere = cadWhere & " AND (a.dFechaArregloPago BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) "
                        End If
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

                'Asigna Consulta de la Ficha:       
                If Me.IdSclTipoBusqueda = 1 Then
                    strSQL = " SELECT a.nSclFichaSeguimientoID, a.nSrhTecnicoID, a.nStbDelegacionProgramaID, a.nSclFichaNotificacionDetalleID, a.nSclSociaID, " & _
                             " a.dFechaFicha, a.Socia, a.sNumeroCedula, a.GrupoSolidario, a.NombreTecnico,  a.sNombre1, " & _
                             " a.sNombre2, a.sApellido1, a.sApellido2 " & _
                             " FROM vwSclFichaSeguimiento AS a "
                ElseIf Me.IdSclTipoBusqueda = 2 Then
                    strSQL = " SELECT a.nSccArregloPagoID, a.nStbDelegacionProgramaID, a.nSrhTecnicoID, " & _
                             " a.dFechaArregloPago, a.sNumeroCedula, a.Socia, a.GrupoSolidario, " & _
                             " a.sNombre1, a.sNombre2, a.sApellido1, a.sApellido2 " & _
                             " FROM vwSccArregloPago AS a "
                End If
                'Asigna Criterio de Búsqueda:
                strSQL = strSQL & cadWhere

                XContadorReg = 0
                XdtDatos.ExecuteSql(strSQL)

                'En caso de NO encontrar registros:
                If XdtDatos.Count = 0 Then
                    MsgBox("Registros NO Encontrados.", MsgBoxStyle.Information, NombreSistema)
                    grpBotones.Enabled = False
                    Me.Cursor = System.Windows.Forms.Cursors.Default
                    Exit Sub
                Else 'Se encontraron registros:
                    grpBotones.Enabled = True
                    Me.StrCriterioFicha = cadWhere
                    PresentaFicha()
                End If
                Me.Cursor = System.Windows.Forms.Cursors.Default
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub radCedula_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radCedula.Click
        HabilitarControles()
    End Sub

    Private Sub RadSocia_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadSocia.Click
        HabilitarControles()
    End Sub

    Private Sub RadTecnico_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadTecnico.Click
        HabilitarControles()
    End Sub

    Private Sub RadFechas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadFechas.Click
        HabilitarControles()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
    ' Procedure Name:       CargarTecnico
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Tecnicos.
    '-------------------------------------------------------------------------
    Private Sub CargarTecnico(ByVal intTecnicoID As Integer)
        Try
            Dim Strsql As String

            Me.cboTecnico.ClearFields() '01: Verificador, 03: Director Promocion, 12: Tecnico de Promocion, '15': Delegadas Departamentales, '10': Oficiales de Crédito.

            If intTecnicoID = 0 Then
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where (a.sCodCargo = '01') or (a.sCodCargo = '03') or (a.sCodCargo = '12') or (a.sCodCargo = '10') or (a.sCodCargo = '15') " & _
                     " Order by a.sNombreEmpleado "
            Else
                Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where ((a.sCodCargo = '01') or (a.sCodCargo = '03') or (a.sCodCargo = '12') or (a.sCodCargo = '10') or (a.sCodCargo = '15')) " & _
                     "  or (a.nSrhEmpleadoID = " & intTecnicoID & ") " & _
                     " Order by a.sNombreEmpleado "
            End If

            XdtTecnico.ExecuteSql(Strsql)
            'Asignando a las fuentes de datos:
            Me.cboTecnico.DataSource = XdtTecnico.Source
            Me.cboTecnico.Rebind()

            Me.cboTecnico.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Visible = False

            'Configurar el combo: 
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").Width = 210
            Me.cboTecnico.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class