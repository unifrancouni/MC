' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                29/04/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteCajeros.vb
' Descripción:          Formulario muestra Catálogo de Cajeros del
'                       Programa asignandoles la Caja a atender.
'-------------------------------------------------------------------------
Public Class frmSteCajeros
    '- Declaración de Variables 
    Dim XdsCajero As BOSistema.Win.XDataSet
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       frmSteCajeros_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteCajeros_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsCajero.Close()
            XdsCajero = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	17/03/2009
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
    ' Fecha:                29/04/2008
    ' Procedure Name:       frmSteCajeros_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se cargan los Grids.
    '-------------------------------------------------------------------------
    Private Sub frmSteCajeros_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarCajero()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdsCajero = New BOSistema.Win.XDataSet
            EncuentraParametros()

            'Limpiar los Grids, estructura y Datos:
            Me.grdCajeros.ClearFields()
            Me.grdCajas.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       CargarCajero
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Cajeros y Cajas en los Grids.
    '-------------------------------------------------------------------------
    Private Sub CargarCajero()
        Try
            Dim Strsql As String

            'Maestro (Cajeros):
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT a.nSteCajeroID, a.nActivo, a.nCodigo, a.sNombre, a.nSrhEmpleadoID, a.sUsuarioCreacion, a.nStbDelegacionProgramaID " & _
                         " FROM vwSteCajero a " & _
                         " Order by a.nCodigo"
            Else 'Solo Filtra los Cajeros de su Delegación:
                Strsql = " SELECT a.nSteCajeroID, a.nActivo, a.nCodigo, a.sNombre, a.nSrhEmpleadoID, a.sUsuarioCreacion, a.nStbDelegacionProgramaID " & _
                " FROM vwSteCajeroPorDelegacion a " & _
                         " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                         " Order by a.nCodigo"
            End If

            If XdsCajero.ExistTable("Cajero") Then
                XdsCajero("Cajero").ExecuteSql(Strsql)
            Else
                XdsCajero.NewTable(Strsql, "Cajero")
                XdsCajero("Cajero").Retrieve()
            End If

            'Detalle (Cajas atendidas por el Cajero):
            Strsql = " SELECT b.nSteCajeroCajasID, b.nSteCajaID, b.nActiva, b.nCodigo, b.sDescripcionCaja, b.Login, b.nSteCajeroID " & _
                     " FROM vwSteCajeroCajas b " & _
                     " Order by b.nSteCajeroCajasID"
            If XdsCajero.ExistTable("Cajas") Then
                XdsCajero("Cajas").ExecuteSql(Strsql)
            Else
                XdsCajero.NewTable(Strsql, "Cajas")
                XdsCajero("Cajas").Retrieve()
            End If

            'Creando la relación entre el Primer Query y el Segundo:
            If XdsCajero.ExistRelation("CajeroConCajas") = False Then
                XdsCajero.NewRelation("CajeroConCajas", "Cajero", "Cajas", "nSteCajeroID", "nSteCajeroID")
            End If
            XdsCajero.SincronizarRelaciones()

            'Asignando a las fuentes de datos:
            Me.grdCajeros.DataSource = XdsCajero("Cajero").Source
            Me.grdCajas.DataSource = XdsCajero("Cajas").Source

            'Actualizando el caption de los GRIDS:
            Me.grdCajeros.Caption = " Listado de Cajeros del Programa (" + Me.grdCajeros.RowCount.ToString + " registros)"
            Me.grdCajas.Caption = " Listado de Cajas asignadas al Cajero (" + Me.grdCajas.RowCount.ToString + " registros)"
            FormatoCajeros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       FormatoCajeros
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Cajeros y Cajas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCajeros()
        Try

            '-- Configuración del Grid Cajeros:
            Me.grdCajeros.Splits(0).DisplayColumns("nSteCajeroID").Visible = False
            Me.grdCajeros.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.grdCajeros.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdCajeros.Splits(0).DisplayColumns("nActivo").Width = 90
            Me.grdCajeros.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.grdCajeros.Splits(0).DisplayColumns("sNombre").Width = 400
            Me.grdCajeros.Splits(0).DisplayColumns("sUsuarioCreacion").Width = 150

            Me.grdCajeros.Columns("nActivo").Caption = "Cajero Activo"
            Me.grdCajeros.Columns("nCodigo").Caption = "Código"
            Me.grdCajeros.Columns("sNombre").Caption = "Nombre del Cajero"
            Me.grdCajeros.Columns("sUsuarioCreacion").Caption = "Ingresado Por"

            Me.grdCajeros.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajeros.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajeros.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajeros.Splits(0).DisplayColumns("sUsuarioCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            
            'Estado Cajero Activo como checkbox y centrado:
            Me.grdCajeros.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdCajeros.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajeros.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            '-- Configuración del Grid Cajas:
            Me.grdCajas.Splits(0).DisplayColumns("nSteCajeroCajasID").Visible = False
            Me.grdCajas.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.grdCajas.Splits(0).DisplayColumns("nSteCajeroID").Visible = False

            Me.grdCajas.Splits(0).DisplayColumns("nActiva").Width = 90
            Me.grdCajas.Splits(0).DisplayColumns("nCodigo").Width = 80
            Me.grdCajas.Splits(0).DisplayColumns("sDescripcionCaja").Width = 400
            Me.grdCajas.Splits(0).DisplayColumns("Login").Width = 150

            Me.grdCajas.Columns("nActiva").Caption = "Caja Activa"
            Me.grdCajas.Columns("nCodigo").Caption = "Código"
            Me.grdCajas.Columns("sDescripcionCaja").Caption = "Descripción de la Caja"
            Me.grdCajas.Columns("Login").Caption = "Ingresada Por"
            
            Me.grdCajas.Splits(0).DisplayColumns("nActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajas.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajas.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajas.Splits(0).DisplayColumns("Login").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            
            'Estado Caja Activa como checkbox y centrado:
            Me.grdCajas.Columns("nActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdCajas.Splits(0).DisplayColumns("nActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCajas.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       tbCajero_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCajero.
    '-------------------------------------------------------------------------
    Private Sub tbCajero_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCajero.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCajero()
            Case "toolModificar"
                LlamaModificarCajero()
            Case "toolAnular"
                LlamaInactivarCajero()
            Case "toolRefrescar"
                InicializaVariables()
                CargarCajero()
            Case "toolImprimir"
                LlamaImprimir(0)
            Case "toolImprimirL"
                LlamaImprimir(1)
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/05/2008
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir:
    '                       0: Listado de Cajeros.
    '                       1: Listado de Cajas asignadas por Cajero.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir(ByVal IntReporte As Integer)
        Dim frmVisor As New frmCRVisorReporte
        Try

            Dim strSQL As String = ""
            If Me.grdCajeros.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            If IntReporte = 0 Then
                frmVisor.NombreReporte = "RepSteTE13.rpt"
                frmVisor.Text = "Listado de Cajeros del Programa"
                frmVisor.SQLQuery = "Select * From vwSteCajero Order by nCodigo"
            Else
                frmVisor.NombreReporte = "RepSteTE14.rpt"
                frmVisor.Text = "Listado de Cajas asignadas por Cajeros"
                frmVisor.SQLQuery = "Select * From vwSteCajeroCajasRpt Order by nCodigo, nActiva"
            End If
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       tbCaja_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCaja.
    '-------------------------------------------------------------------------
    Private Sub tbCaja_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCaja.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarC"
                LlamaAgregarCaja()
            Case "toolInactivarC"
                LlamaInactivarCaja()
            Case "toolAyudaC"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       LlamaAgregarCajero
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCajeros para Agregar un nuevo Cajero.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCajero()
        Dim ObjFrmSteEditCajero As New frmSteEditCajeros
        Try

            ObjFrmSteEditCajero.ModoFrm = "ADD"
            ObjFrmSteEditCajero.intStePermiteEditar = IntPermiteEditar
            ObjFrmSteEditCajero.IntCajero = 1
            ObjFrmSteEditCajero.ShowDialog()

            If ObjFrmSteEditCajero.IdCajero <> 0 Then
                CargarCajero()
                'Se ubica sobre el registro recien agregado:
                XdsCajero("Cajero").SetCurrentByID("nSteCajeroID", ObjFrmSteEditCajero.IdCajero)
                Me.grdCajeros.Row = XdsCajero("Cajero").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCajero.Close()
            ObjFrmSteEditCajero = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       LlamaAgregarCajas
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCajeros para Agregar una Caja a un
    '                       determinado Cajero.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCaja()
        Dim ObjFrmSteEditCajeroCajas As New frmSteEditCajeros
        Try
            Dim strsql As String
            'No existen Cajeros registrados:
            If Me.grdCajeros.RowCount = 0 Then
                MsgBox("No Existen Cajeros registrados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si el Cajero se encuentra Inactivo:
            If XdsCajero("Cajero").ValueField("nActivo") <> 1 Then
                MsgBox("El Cajero no se encuentra Activo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible agregar más de una Caja activa al Cajero:
            strsql = "SELECT * FROM SteCajeroCajas WHERE (nActiva = 1) AND (nSteCajeroID = " & XdsCajero("Cajero").ValueField("nSteCajeroID") & ")"
            If RegistrosAsociados(strsql) Then
                MsgBox("El Cajero solamente puede tener asignada una Caja Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditCajeroCajas.ModoFrm = "ADD"
            ObjFrmSteEditCajeroCajas.intStePermiteEditar = IntPermiteEditar
            ObjFrmSteEditCajeroCajas.IdCajero = XdsCajero("Cajero").ValueField("nSteCajeroID")
            ObjFrmSteEditCajeroCajas.IntCajero = 0
            ObjFrmSteEditCajeroCajas.ShowDialog()

            'Si se ingresó el registro correctamente:
            If ObjFrmSteEditCajeroCajas.IdCaja <> 0 Then
                CargarCajero()
                'Se ubica sobre el Cajero:
                XdsCajero("Cajero").SetCurrentByID("nSteCajeroID", ObjFrmSteEditCajeroCajas.IdCajero)
                Me.grdCajeros.Row = XdsCajero("Cajero").BindingSource.Position
                'Se ubica sobre la Caja recien ingresada:
                XdsCajero("Cajas").SetCurrentByID("nSteCajeroCajasID", ObjFrmSteEditCajeroCajas.IdCaja)
                Me.grdCajas.Row = XdsCajero("Cajas").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCajeroCajas.Close()
            ObjFrmSteEditCajeroCajas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       LlamaModificarCajero
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCajeros para Modificar un Cajero existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCajero()
        Dim ObjFrmSteEditCajero As New frmSteEditCajeros
        Try
            Dim StrSql As String
            'No existen registros:
            If Me.grdCajeros.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Cajero no esta Activo: 
            If XdsCajero("Cajero").ValueField("nActivo") <> 1 Then
                MsgBox("Cajero no se encuentra Activo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el Cajero ya tiene Cajas asociadas:
            StrSql = "SELECT * FROM SteCajeroCajas WHERE (nSteCajeroID = " & XdsCajero("Cajero").ValueField("nSteCajeroID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("El Cajero ya tiene Cajas asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditCajero.ModoFrm = "UPD"
            ObjFrmSteEditCajero.intStePermiteEditar = IntPermiteEditar
            ObjFrmSteEditCajero.IntCajero = 1
            ObjFrmSteEditCajero.IdCajero = XdsCajero("Cajero").ValueField("nSteCajeroID")
            ObjFrmSteEditCajero.ShowDialog()
            CargarCajero()
            XdsCajero("Cajero").SetCurrentByID("nSteCajeroID", ObjFrmSteEditCajero.IdCajero)
            Me.grdCajeros.Row = XdsCajero("Cajero").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCajero.Close()
            ObjFrmSteEditCajero = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       LlamaInactivarCaja
    ' Descripción:          Este procedimiento permite Inactivar una Caja
    '                       previamente asignada a un Cajero.
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivarCaja()
        Dim XdtInactivarCaja As New BOSistema.Win.XDataSet.xDataTable
        Dim StrSql As String = ""
        Try
            Dim intPosicion As Integer
            Dim intPosicionS As Integer

            'No existen Cajas registradas:
            If Me.grdCajas.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Cajero no esta Activo: 
            If XdsCajero("Cajero").ValueField("nActivo") <> 1 Then
                MsgBox("Cajero no se encuentra Activo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Caja ya se encuentra Inactiva: 
            If XdsCajero("Cajas").ValueField("nActiva") = 0 Then
                MsgBox("Caja no se encuentra Activa.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Cambio: 
            If MsgBox("¿Está seguro de Inactivar la Caja" & Chr(13) & _
                      "para el Cajero seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            intPosicion = XdsCajero("Cajero").ValueField("nSteCajeroID")
            intPosicionS = XdsCajero("Cajas").ValueField("nSteCajeroCajasID")

            'Inactivar Caja:
            StrSql = "UPDATE SteCajeroCajas " & _
                     "SET nActiva = 0, dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "' " & _
                     "WHERE (nSteCajeroCajasID = " & XdsCajero("Cajas").ValueField("nSteCajeroCajasID") & ") And (nSteCajeroID = " & XdsCajero("Cajero").ValueField("nSteCajeroID") & ")"
            XdtInactivarCaja.ExecuteSqlNotTable(StrSql)

            'Refrescar Datos: 
            CargarCajero()
            XdsCajero("Cajero").SetCurrentByID("nSteCajeroID", intPosicion)
            Me.grdCajeros.Row = XdsCajero("Cajero").BindingSource.Position
            XdsCajero("Cajas").SetCurrentByID("nSteCajeroCajasID", intPosicionS)
            Me.grdCajas.Row = XdsCajero("Cajas").BindingSource.Position
            MsgBox("La Caja se inactivó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            Call GuardarAuditoria(5, 25, "Inactivación de Caja ID: " & XdsCajero("Cajas").ValueField("nSteCajeroCajasID") & " asignada a Cajero ID: " & XdsCajero("Cajero").ValueField("nSteCajeroID") & ").")
            
        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdtInactivarCaja.Close()
            XdtInactivarCaja = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       LlamaInactivarCajero
    ' Descripción:          Este procedimiento permite Inactivar un Cajero
    '                       existente, puede deberse a un cambio de cargo de
    '                       la persona o al retiro del empleado del Programa.
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivarCajero()
        Dim XdtInactivarCajero As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String
        Try

            Dim intPosicion As Integer

            'Imposible si no hay Cajeros registrados:
            If Me.grdCajeros.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Cajero esta Inactivo:
            If XdsCajero("Cajero").ValueField("nActivo") <> 1 Then
                MsgBox("Cajero no se encuentra Activo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Strsql = "SELECT sDescripcionCaja " &
                       "From dbo.vwSteCajeroCajas " &
                        "WHERE (nActiva = 1) AND (nSteCajeroID = " & XdsCajero("Cajero").ValueField("nSteCajeroID") & ")"

            If RegistrosAsociados(Strsql) Then
                MsgBox("Imposible Inactivar al Cajero. Tiene caja activa asociada, Desactive la caja para el cajero", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Cambio: 
            If MsgBox("¿Está seguro de Inactivar el Cajero seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            intPosicion = XdsCajero("Cajero").ValueField("nSteCajeroID")

            'Inactivar Cajero:

            GuardarAuditoriaTablas(11, 2, "Modificar SteCajero Inactivar", XdsCajero("Cajero").ValueField("nSteCajeroID"), InfoSistema.IDCuenta)

            Strsql = "UPDATE SteCajero " & _
                     "SET nActivo = 0, dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "' " & _
                     "WHERE (nSteCajeroID = " & XdsCajero("Cajero").ValueField("nSteCajeroID") & ")"
            XdtInactivarCajero.ExecuteSqlNotTable(Strsql)

            'Guardar posición actual de la selección:
            intPosicion = XdsCajero("Cajero").ValueField("nSteCajeroID")
            CargarCajero()
            XdsCajero("Cajero").SetCurrentByID("nSteCajeroID", intPosicion)
            Me.grdCajeros.Row = XdsCajero("Cajero").BindingSource.Position
            MsgBox("El Cajero se inactivó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdtInactivarCajero.Close()
            XdtInactivarCajero = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite Salir de la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
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
    ' Fecha:                29/04/2008
    ' Procedure Name:       grdCajeros_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Cajero, al hacer doble click en el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCajeros_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCajeros.DoubleClick
        Try
            If Seg.HasPermission("ModificarCajero") Then
                LlamaModificarCajero()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdCajeros_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCajeros.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       grdCajeros_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCajeros_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCajeros.Filter
        Try
            XdsCajero("Cajero").FilterLocal(e.Condition)
            Me.grdCajeros.Caption = " Listado de Cajeros del Programa (" + Me.grdCajeros.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            '-- Agregar Cajero:
            If Seg.HasPermission("AgregarCajero") = False Then
                Me.tbCajero.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbCajero.Items("toolAgregar").Enabled = True
            End If

            'Editar Cajero:
            If Seg.HasPermission("ModificarCajero") = False Then
                Me.tbCajero.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbCajero.Items("toolModificar").Enabled = True
            End If

            'Inactivar Cajero:
            If Seg.HasPermission("InactivarCajero") = False Then
                Me.tbCajero.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbCajero.Items("toolAnular").Enabled = True
            End If

            'Imprimir Listado Cajeros:
            If Seg.HasPermission("ImprimirListadoCajeros") = False Then
                Me.tbCajero.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbCajero.Items("toolImprimir").Enabled = True
            End If

            'Imprimir Listado Cajas asignadas por Cajeros:
            If Seg.HasPermission("ImprimirListadoCajasPorCajero") = False Then
                Me.tbCajero.Items("toolImprimirL").Enabled = False
            Else  'Habilita
                Me.tbCajero.Items("toolImprimirL").Enabled = True
            End If

            '-- Agregar Caja al Cajero:
            If Seg.HasPermission("AgregarCajeroCajas") = False Then
                Me.tbCaja.Items("toolAgregarC").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolAgregarC").Enabled = True
            End If

            'Inactivar Caja al Cajero:
            If Seg.HasPermission("InactivarCajeroCajas") = False Then
                Me.tbCaja.Items("toolInactivarC").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolInactivarC").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       grdCajeros_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Cajas con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdCajeros_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdCajeros.RowColChange
        Me.grdCajas.Caption = " Listado de Cajas asignadas al Cajero (" + Me.grdCajas.RowCount.ToString + " registros)"
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdCajas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCajas.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                29/04/2008
    ' Procedure Name:       grdCajas_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCajas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCajas.Filter
        Try
            XdsCajero("Cajas").FilterLocal(e.Condition)
            Me.grdCajas.Caption = " Listado de Cajas asignadas al Cajero (" + Me.grdCajas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregar.Click

    End Sub
End Class