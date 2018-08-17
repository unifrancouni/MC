' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                29/06/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclActividadEconomica.vb
' Descripción:          Este formulario carga las actividades
'                       economicas de las socias del Programa.
'-------------------------------------------------------------------------
Public Class frmSclActividadEconomica

    '- Declaración de Variables 
    Dim XdtActividad As BOSistema.Win.XDataSet.xDataTable

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       frmSclActividadEconomica_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclActividadEconomica_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtActividad.Close()
            XdtActividad = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       frmSclActividadEconomica_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado de en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclActividadEconomica_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

            CargarActividad()
            FormatoActividad()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       CargarActividad
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarActividad()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nSclClasificacionEconomicaID, a.nStbActividadEconomicaID, a.nStbTipoActividadEconomicaID, " & _
                     " a.nActiva, a.CodigoA, a.Actividad, a.CodigoClase, a.ClaseActividad, a.sDescripcionActividad " & _
                     " FROM vwSclClasificacionEconomica AS a " & _
                     " Order by a.nStbActividadEconomicaID"

            XdtActividad.ExecuteSql(Strsql)

            'Asignando fuente de datos al Grid:
            Me.grdActividades.DataSource = XdtActividad.Source
            Me.grdActividades.Caption = " Listado de Actividades Económicas (" + Me.grdActividades.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       FormatoActividad
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoActividad()
        Try
            'Configuracion del Grid 
            Me.grdActividades.Splits(0).DisplayColumns("nSclClasificacionEconomicaID").Visible = False
            Me.grdActividades.Splits(0).DisplayColumns("nStbActividadEconomicaID").Visible = False
            Me.grdActividades.Splits(0).DisplayColumns("nStbTipoActividadEconomicaID").Visible = False
            Me.grdActividades.Splits(0).DisplayColumns("CodigoClase").Visible = False

            Me.grdActividades.Splits(0).DisplayColumns("nActiva").Width = 50
            Me.grdActividades.Splits(0).DisplayColumns("CodigoA").Width = 90
            Me.grdActividades.Splits(0).DisplayColumns("Actividad").Width = 600
            Me.grdActividades.Splits(0).DisplayColumns("ClaseActividad").Width = 100
            Me.grdActividades.Splits(0).DisplayColumns("sDescripcionActividad").Width = 200

            Me.grdActividades.Columns("nActiva").Caption = "Activa"
            Me.grdActividades.Columns("CodigoA").Caption = "Código"
            Me.grdActividades.Columns("Actividad").Caption = "Actividad Económica"
            Me.grdActividades.Columns("ClaseActividad").Caption = "Clasificación"
            Me.grdActividades.Columns("sDescripcionActividad").Caption = "Descripción"

            Me.grdActividades.Splits(0).DisplayColumns("nActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividades.Splits(0).DisplayColumns("CodigoA").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividades.Splits(0).DisplayColumns("Actividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividades.Splits(0).DisplayColumns("ClaseActividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdActividades.Splits(0).DisplayColumns("nActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividades.Columns("nActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtActividad = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = "Listado de Actividades Económicas"
            'Limpiar Grid, estructura y Datos
            Me.grdActividades.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       tbActividades_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbActividades.
    '-------------------------------------------------------------------------
    Private Sub tbActividades_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbActividades.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarActividad()
            Case "toolModificar"
                LlamaModificarActividad()
            Case "toolInactivar"
                LlamaInactivar()
            Case "toolRefrescar"
                InicializaVariables()
                CargarActividad()
                FormatoActividad()

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
    ' Fecha:                29/06/2009
    ' Procedure Name:       LlamaInactivar
    ' Descripción:          Este procedimiento permite inactivar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivar()
        Dim Trans As BOSistema.Win.Transact
        Dim StrSql As String = ""
        Trans = Nothing

        Try

            Dim intPosicion As Integer
            'Imposible si no hay registros:
            If Me.grdActividades.RowCount = 0 Then
                MsgBox("No Existen registros grabadas.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'Registro esta Inactivo:
            StrSql = "SELECT * FROM SclClasificacionEconomica WHERE (nActiva = 0) AND (nSclClasificacionEconomicaID = " & XdtActividad.ValueField("nSclClasificacionEconomicaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El registro esta Inactivo.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'Registro esta Inactivo:
            StrSql = "select top 1 * from vwSclActividadEconomicaOcupada WHERE (nSclClasificacionEconomicaID = " & XdtActividad.ValueField("nSclClasificacionEconomicaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("No se puede anular una actividad que haya sido utilizada en al menos un crédito.", MsgBoxStyle.Critical)
                Exit Sub
            End If

            'Confirmar:
            If MsgBox("¿Está seguro de inactivar la actividad seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            Trans.BeginTrans()

            'Inactiva Clasificación Económica:
            StrSql = " Update SclClasificacionEconomica " & _
                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), nActiva = 0 " & _
                     " WHERE nSclClasificacionEconomicaID = " & XdtActividad.ValueField("nSclClasificacionEconomicaID")
            Trans.ExecuteSql(StrSql)
            'Inactiva Tipo de Negocio en Valor Catálogo:
            StrSql = " Update StbValorCatalogo " & _
                     " SET UsuarioModificacion = '" & InfoSistema.LoginName & "', fechamodificacion = getdate(), nActivo = 0 " & _
                     " WHERE nStbValorCatalogoID = " & XdtActividad.ValueField("nStbActividadEconomicaID")
            Trans.ExecuteSql(StrSql)
            'Finaliza Transacción:
            Trans.Commit()

            'Guardar Pista de Auditoria:
            Call GuardarAuditoria(5, 15, "Inactivación de Clasificación Económica ID: " & XdtActividad.ValueField("nSclClasificacionEconomicaID"))

            'Ubicar la selección en la posición original
            intPosicion = XdtActividad.ValueField("nSclClasificacionEconomicaID")
            CargarActividad()
            XdtActividad.SetCurrentByID("nSclClasificacionEconomicaID", intPosicion)
            Me.grdActividades.Row = XdtActividad.BindingSource.Position

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            Trans = Nothing
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       LlamaAgregarActividad
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditActividadEconomica para Agregar una nueva.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarActividad()
        Dim ObjFrmSclEditActividad As New frmSclEditActividadEconomica
        Try

            ObjFrmSclEditActividad.ModoFrm = "ADD"
            ObjFrmSclEditActividad.ShowDialog()

            'Si se ingreso un nuevo Formato:
            If ObjFrmSclEditActividad.IdActividad <> 0 Then
                CargarActividad()
                XdtActividad.SetCurrentByID("nSclClasificacionEconomicaID", ObjFrmSclEditActividad.IdActividad)
                Me.grdActividades.Row = XdtActividad.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditActividad.Close()
            ObjFrmSclEditActividad = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       LlamaModificarActividad
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditActividadEconomica para Modificar una.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarActividad()
        Dim ObjFrmSclEditActividad As New frmSclEditActividadEconomica
        Try
            Dim Strsql As String
            'Si no existen registros:
            If Me.grdActividades.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Verifica si esta Inactiva:
            Strsql = "SELECT * FROM SclClasificacionEconomica WHERE (nActiva = 0) AND (nSclClasificacionEconomicaID = " & XdtActividad.ValueField("nSclClasificacionEconomicaID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El registro esta Inactivo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditActividad.ModoFrm = "UPD"
            ObjFrmSclEditActividad.IdActividad = XdtActividad.ValueField("nSclClasificacionEconomicaID")
            ObjFrmSclEditActividad.IdActividadE = XdtActividad.ValueField("nStbActividadEconomicaID")
            ObjFrmSclEditActividad.ShowDialog()

            CargarActividad()
            XdtActividad.SetCurrentByID("nSclClasificacionEconomicaID", ObjFrmSclEditActividad.IdActividad)
            Me.grdActividades.Row = XdtActividad.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditActividad.Close()
            ObjFrmSclEditActividad = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
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
    ' Fecha:                29/06/2009
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
    ' Fecha:                03/07/2009
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir listado
    '                       de Actividades Económicas.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            'Si no existen registros:
            If Me.grdActividades.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.NombreReporte = "RepSclCS31.rpt"
            frmVisor.Text = "Listado de Actividades Económicas"
            frmVisor.SQLQuery = " Select * From vwSclClasificacionEconomica "
            '" Order by nStbActividadEconomicaID "
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       grdActividades_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdActividades_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdActividades.Filter
        Try
            XdtActividad.FilterLocal(e.Condition)
            Me.grdActividades.Caption = " Listado de Actividades Económicas (" + Me.grdActividades.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/06/2009
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar:
            If Seg.HasPermission("AgregarActividadEconomica") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar:
            If Seg.HasPermission("ModificarActividadEconomica") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Inactivar:
            If Seg.HasPermission("InactivarActividadEconomica") Then
                Me.toolInactivar.Enabled = True
            Else
                Me.toolInactivar.Enabled = False
            End If

            '-- Imprimir:
            If Seg.HasPermission("ImprimirListadoActividadesEconomicasCS31") Then
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
    ' Fecha:                29/06/2009
    ' Procedure Name:       grdActividades_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Actividad existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdActividades_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdActividades.DoubleClick
        Try
            If Me.grdActividades.RowCount = 0 Then
                Exit Sub
            End If
            If Seg.HasPermission("ModificarActividadEconomica") Then
                LlamaModificarActividad()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdActividades_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdActividades.Error
        Control_Error(e.Exception)
    End Sub
End Class