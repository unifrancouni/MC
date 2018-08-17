' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                10/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclFormatoPromocionCapacitacion.vb
' Descripción:          Este formulario carga los principales datos del
'                       Formato Consolidado de Socias Recepcionadas,
'                       verificadas y capacitadas.
'-------------------------------------------------------------------------
Public Class frmSclFormatoPromocionCapacitacion

    '- Declaración de Variables 
    Dim XdtFormato As BOSistema.Win.XDataSet.xDataTable
    Dim XdsEmpleado As BOSistema.Win.XDataSet

    'Parámetros Delegación:
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       frmSclFormatoPromocionCapacitacion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclFormatoPromocionCapacitacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFormato.Close()
            XdtFormato = Nothing

            XdsEmpleado.Close()
            XdsEmpleado = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       frmSclFormatoPromocionCapacitacion_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado de en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclFormatoPromocionCapacitacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            Me.cboTecnico.Select()

            InicializaVariables()

            'Cargar Tecnicos:
            XdsEmpleado = New BOSistema.Win.XDataSet
            CargarTecnico()

            CargarFormato()
            FormatoLista()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       CargarFormato
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarFormato()
        Try
            Dim Strsql As String = ""

            If Me.cboTecnico.SelectedIndex = -1 Then
                Strsql = " SELECT a.nSclFormatoPromocionID, a.nSrhTecnicoID, a.nActivo, a.Barrio, a.sMercado, a.dFechaActividad, " & _
                         " a.nFichasRecepcionadas, a.nFichasVerificadas, a.nPrimerCapacitacion, a.nSegundaCapacitacion, a.nSeguimientoPostCredito, a.nStbDelegacionProgramaID " & _
                         " FROM vwSclFormatoPromocion AS a " & _
                         " WHERE (a.nSclFormatoPromocionID = 0)"
            Else
                If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                    Strsql = " SELECT a.nSclFormatoPromocionID, a.nSrhTecnicoID, a.nActivo, a.Barrio, a.sMercado, a.dFechaActividad, " & _
                             " a.nFichasRecepcionadas, a.nFichasVerificadas, a.nPrimerCapacitacion, a.nSegundaCapacitacion, a.nSeguimientoPostCredito, a.nStbDelegacionProgramaID " & _
                             " FROM vwSclFormatoPromocion AS a " & _
                             " WHERE (a.nSrhTecnicoID = " & cboTecnico.Columns("nSrhEmpleadoID").Value & ") and (a.dFechaActividad BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                             " Order by a.dFechaActividad, a.Barrio"

                Else 'Solo Filtra los Formatos de su Delegación: 
                    Strsql = " SELECT a.nSclFormatoPromocionID, a.nSrhTecnicoID, a.nActivo, a.Barrio, a.sMercado, a.dFechaActividad, " & _
                             " a.nFichasRecepcionadas, a.nFichasVerificadas, a.nPrimerCapacitacion, a.nSegundaCapacitacion, a.nSeguimientoPostCredito, a.nStbDelegacionProgramaID " & _
                             " FROM vwSclFormatoPromocion AS a " & _
                             " WHERE (a.nSrhTecnicoID = " & cboTecnico.Columns("nSrhEmpleadoID").Value & ") and (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (a.dFechaActividad BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                             " Order by a.dFechaActividad, a.Barrio"

                End If
            End If

            XdtFormato.ExecuteSql(Strsql)

            'Asignando fuente de datos al Grid:
            Me.grdFormato.DataSource = XdtFormato.Source
            Me.grdFormato.Caption = " Listado de Formatos de Promoción y Capacitación (" + Me.grdFormato.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       FormatoLista
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoLista()
        Try

            'Configuracion del Grid FNC
            Me.grdFormato.Splits(0).DisplayColumns("nSclFormatoPromocionID").Visible = False
            Me.grdFormato.Splits(0).DisplayColumns("nSrhTecnicoID").Visible = False
            Me.grdFormato.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdFormato.Splits(0).DisplayColumns("nActivo").Width = 50
            Me.grdFormato.Splits(0).DisplayColumns("Barrio").Width = 150
            Me.grdFormato.Splits(0).DisplayColumns("sMercado").Width = 150
            Me.grdFormato.Splits(0).DisplayColumns("dFechaActividad").Width = 80
            Me.grdFormato.Splits(0).DisplayColumns("nFichasRecepcionadas").Width = 120
            Me.grdFormato.Splits(0).DisplayColumns("nFichasVerificadas").Width = 120
            Me.grdFormato.Splits(0).DisplayColumns("nPrimerCapacitacion").Width = 130
            Me.grdFormato.Splits(0).DisplayColumns("nSegundaCapacitacion").Width = 130
            Me.grdFormato.Splits(0).DisplayColumns("nSeguimientoPostCredito").Width = 130

            Me.grdFormato.Columns("nActivo").Caption = "Activo"
            Me.grdFormato.Columns("Barrio").Caption = "Barrio"
            Me.grdFormato.Columns("sMercado").Caption = "Mercado"
            Me.grdFormato.Columns("dFechaActividad").Caption = "Fecha"
            Me.grdFormato.Columns("nFichasRecepcionadas").Caption = "Fichas Recepcionadas"
            Me.grdFormato.Columns("nFichasVerificadas").Caption = "Fichas Verificadas"
            Me.grdFormato.Columns("nPrimerCapacitacion").Caption = "Capacitación 1era Fase"
            Me.grdFormato.Columns("nSegundaCapacitacion").Caption = "Capacitación 2da Fase"
            Me.grdFormato.Columns("nSeguimientoPostCredito").Caption = "Seguimiento Post Crédito"

            Me.grdFormato.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("sMercado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("dFechaActividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("nFichasRecepcionadas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("nFichasVerificadas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("nPrimerCapacitacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("nSegundaCapacitacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Splits(0).DisplayColumns("nSeguimientoPostCredito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            
            'Formatos:
            Me.grdFormato.Columns("dFechaActividad").NumberFormat = "dd/MM/yyyy"
            Me.grdFormato.Splits(0).DisplayColumns("dFechaActividad").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            Me.grdFormato.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFormato.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtFormato = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = "Formato de Promoción y Capacitación"
            'Limpiar Grid, estructura y Datos
            Me.grdFormato.ClearFields()

            'Encuentra parámetros de Consulta / Edición Sucursales:
            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       tbFormato_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbFicha.
    '-------------------------------------------------------------------------
    Private Sub tbFormato_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFormato.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarFormato()
            Case "toolModificar"
                LlamaModificarFormato()
            Case "toolInactivar"
                LlamaInactivar()
            Case "toolRefrescar"
                'Debe indicar un Técnico:
                If Me.cboTecnico.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Técnico válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.cboTecnico.Focus()
                    Exit Sub
                End If
                'Fechas de Corte Validas:
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                'If DateDiff(DateInterval.Day, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 30 Then
                '    MsgBox("Imposible seleccionar cortes de fecha superiores a 31 días.", MsgBoxStyle.Information)
                '    Me.cdeFechaD.Focus()
                '    Exit Sub
                'End If

                InicializaVariables()
                CargarFormato()
                FormatoLista()

            Case "toolImprimir"
                LlamaImprimir()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       LlamaInactivar
    ' Descripción:          Este procedimiento permite inactivar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivar()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XdtFormatoPC As New BOSistema.Win.SclEntSocia.SclFormatoPromocionDataTable
        Dim XdrFormatoPC As New BOSistema.Win.SclEntSocia.SclFormatoPromocionRow
        Dim Strsql As String

        Try

            Dim intPosicion As Integer
            Dim strCausaAnulacion As String = ""

            'Imposible si no hay registros:
            If Me.grdFormato.RowCount = 0 Then
                MsgBox("No Existen registros grabadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFormato.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Inactivar registros de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Registro esta Inactivo:
            Strsql = "SELECT * FROM SclFormatoPromocion WHERE (nActivo = 0) AND (nSclFormatoPromocionID = " & XdtFormato.ValueField("nSclFormatoPromocionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El registro esta Inactivo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Solicita al Usuario la Causa de la Anulación
            XdtFormatoPC.Filter = " nSclFormatoPromocionID = " & XdtFormato.ValueField("nSclFormatoPromocionID")
            XdtFormatoPC.Retrieve()
            XdrFormatoPC = XdtFormatoPC.Current

            ObjFrmStbDatoComplemento.strPrompt = "¿Motivo de Anulación? "
            ObjFrmStbDatoComplemento.strTitulo = "Inactivar Actividad"
            ObjFrmStbDatoComplemento.intAncho = XdrFormatoPC.GetColumnLenght("sMotivoInactivacion")
            ObjFrmStbDatoComplemento.strDato = ""
            ObjFrmStbDatoComplemento.strColor = "RojoLight"
            ObjFrmStbDatoComplemento.strMensaje = "El motivo de la Anulación NO DEBE quedar vacío"
            ObjFrmStbDatoComplemento.ShowDialog()

            strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

            'Valida que se ingrese la Causa de la Anulación
            If strCausaAnulacion = "" Then
                MsgBox("El motivo NO PUEDE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            Strsql = " Update SclFormatoPromocion " & _
                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), sMotivoInactivacion = '" & strCausaAnulacion & "', nActivo = 0 " & _
                     " WHERE nSclFormatoPromocionID = " & XdtFormato.ValueField("nSclFormatoPromocionID")
            XcDatos.ExecuteNonQuery(Strsql)
            MsgBox("Registro ha sido Inactivado.", MsgBoxStyle.Information, NombreSistema)
            Call GuardarAuditoria(5, 15, "Inactivación Formato de Promoción y Capacitación ID: " & XdtFormato.ValueField("nSclFormatoPromocionID") & ").")

            'Guardar posición actual de la selección
            intPosicion = XdtFormato.ValueField("nSclFormatoPromocionID")
            CargarFormato()

            'Ubicar la selección en la posición original
            XdtFormato.SetCurrentByID("nSclFormatoPromocionID", intPosicion)
            Me.grdFormato.Row = XdtFormato.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing

            XdtFormatoPC.Close()
            XdtFormatoPC = Nothing

            XdrFormatoPC.Close()
            XdrFormatoPC = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       LlamaAgregarFormato
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFormatoPromocion para Agregar uno nuevo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarFormato()
        Dim ObjFrmSclEditFormato As New frmSclEditFormatoPromocion
        Try

            'Debe indicar un Técnico:
            If Me.cboTecnico.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Técnico válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.cboTecnico.Focus()
                Exit Sub
            End If

            ObjFrmSclEditFormato.ModoFrm = "ADD"
            ObjFrmSclEditFormato.intSclPermiteEditarDelegacion = IntPermiteEditar
            ObjFrmSclEditFormato.IdTecnico = cboTecnico.Columns("nSrhEmpleadoID").Value
            ObjFrmSclEditFormato.sNombreTecnico = Me.cboTecnico.Text
            ObjFrmSclEditFormato.ShowDialog()

            'Si se ingreso un nuevo Formato:
            If ObjFrmSclEditFormato.IdFormato <> 0 Then
                CargarFormato()
                XdtFormato.SetCurrentByID("nSclFormatoPromocionID", ObjFrmSclEditFormato.IdFormato)
                Me.grdFormato.Row = XdtFormato.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFormato.Close()
            ObjFrmSclEditFormato = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       LlamaModificarFormato
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFormatoPromocion para Modificar uno.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarFormato()
        Dim ObjFrmSclEditFormato As New frmSclEditFormatoPromocion
        Try
            Dim Strsql As String
            'Si no existen registros:
            If Me.grdFormato.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFormato.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Formatos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Debe indicar un Técnico:
            If Me.cboTecnico.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Técnico válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.cboTecnico.Focus()
                Exit Sub
            End If

            'Verifica si esta Inactiva:
            Strsql = "SELECT * FROM SclFormatoPromocion WHERE (nActivo = 0) AND (nSclFormatoPromocionID = " & XdtFormato.ValueField("nSclFormatoPromocionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El registro esta Inactivo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditFormato.ModoFrm = "UPD"
            ObjFrmSclEditFormato.intSclPermiteEditarDelegacion = IntPermiteEditar
            ObjFrmSclEditFormato.IdTecnico = XdtFormato.ValueField("nSrhTecnicoID")
            ObjFrmSclEditFormato.sNombreTecnico = Me.cboTecnico.Text
            ObjFrmSclEditFormato.IdFormato = XdtFormato.ValueField("nSclFormatoPromocionID")
            ObjFrmSclEditFormato.ShowDialog()

            CargarFormato()
            XdtFormato.SetCurrentByID("nSclFormatoPromocionID", ObjFrmSclEditFormato.IdFormato)
            Me.grdFormato.Row = XdtFormato.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFormato.Close()
            ObjFrmSclEditFormato = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Formato
    '                       de Promoción y Capacitación.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmSclParametroRpt As New frmSclParametrosPromocion
        Try
            
            ObjFrmSclParametroRpt.NomRep = 1
            ObjFrmSclParametroRpt.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametroRpt.Close()
            ObjFrmSclParametroRpt = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       grdFormato_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFormato_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFormato.Filter
        Try
            XdtFormato.FilterLocal(e.Condition)
            Me.grdFormato.Caption = " Listado de Formatos de Promoción y Capacitación (" + Me.grdFormato.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar:
            If Seg.HasPermission("AgregarFormatoPromocion") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar:
            If Seg.HasPermission("ModificarFormatoPromocion") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Inactivar:
            If Seg.HasPermission("InactivarFormatoPromocion") Then
                Me.toolInactivar.Enabled = True
            Else
                Me.toolInactivar.Enabled = False
            End If

            '-- Imprimir:
            'Formato de Promoción y Capacitación:
            If Seg.HasPermission("ImprimirFormatoPromocion") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       grdFormato_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Ficha existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdFormato_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFormato.DoubleClick
        Try
            If Me.grdFormato.RowCount = 0 Then
                Exit Sub
            End If
            If Seg.HasPermission("ModificarFormatoPromocion") Then
                LlamaModificarFormato()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFormato_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdFormato.Error
        Control_Error(e.Exception)
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	10/07/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Delegación.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2008
    ' Procedure Name:       CargarTecnico
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Técnicos del Programa.
    '-------------------------------------------------------------------------
    Private Sub CargarTecnico()
        Try
            Dim Strsql As String

            Me.cboTecnico.ClearFields() '01: Verificador, 03: Director Promocion, 12: Tecnico de Promocion.
            Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where (a.sCodCargo = '01') or (a.sCodCargo = '03') or (a.sCodCargo = '10') or (a.sCodCargo = '12') " & _
                     " Order by a.sNombreEmpleado "

            If XdsEmpleado.ExistTable("Tecnico") Then
                XdsEmpleado("Tecnico").ExecuteSql(Strsql)
            Else
                XdsEmpleado.NewTable(Strsql, "Tecnico")
                XdsEmpleado("Tecnico").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTecnico.DataSource = XdsEmpleado("Tecnico").Source
            Me.cboTecnico.Rebind()

            Me.cboTecnico.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Visible = False

            'Configurar el combo: 
            'Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").Width = 210

            'Me.cboTecnico.Columns("nCodigo").Caption = "Código"
            Me.cboTecnico.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            'Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboTecnico_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboTecnico.TextChanged
        InicializaVariables()
        CargarFormato()
        FormatoLista()
    End Sub
End Class