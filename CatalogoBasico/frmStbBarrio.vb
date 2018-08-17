' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbBarrio.vb
' Descripción:          Este formulario carga los principales datos del
'                       catálogo de barrios.
'-------------------------------------------------------------------------
Public Class frmStbBarrio

    '- Declaración de Variables 
    Dim XdtBarrio As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDepto As BOSistema.Win.XDataSet.xDataTable
    Dim XMaximoCambios As Integer
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbBarrio_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbBarrio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtBarrio.Close()
            XdtBarrio = Nothing

            XdtDepto.Close()
            XdtDepto = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbBarrio_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Barrios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarDepartamento()
            CargarBarrio(0)
            FormatoBarrio()
            Seguridad()
            XMaximoCambios = 2 ' Maximo veces que se puede hacer el traslado.

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDepartamento a " & _
                         " Order by a.sCodigo"

            XdtDepto.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdtDepto.Source

            ''Asignando a las fuentes de datos
            'Me.cboDepartamento.DataSource = XdsFicha("Departamento").Source

            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsFicha("Departamento").Count > 0 Then
            '    XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de los barrios en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarBarrio(ByVal intDeptoID As Integer)
        Try
            Dim Strsql As String = ""

            Me.grdBarrio.ClearFields()

            If intDeptoID = 0 Then
                Strsql = " Select a.nStbBarrioID,a.sCodDepartamento,a.sDepartamento,a.sCodMunicipio,a.sMunicipio, " & _
                         " a.sCodDistrito,a.sDistrito,a.sCodBarrio,a.sBarrio,a.nPertenecePrograma,a.nActivo " & _
                         " From vwStbBarrio a " & _
                         " Where a.nStbDepartamentoID = " & intDeptoID & _
                         " Order by a.sDepartamento,a.sMunicipio,a.sDistrito,a.sBarrio"
            Else
                Strsql = " Select a.nStbBarrioID,a.sCodDepartamento,a.sDepartamento,a.sCodMunicipio,a.sMunicipio, " & _
                         " a.sCodDistrito,a.sDistrito,a.sCodBarrio,a.sBarrio,a.nPertenecePrograma,a.nActivo " & _
                         " From vwStbBarrio a " & _
                         " Where a.nStbDepartamentoID = " & XdtDepto.ValueField("nStbDepartamentoID") & _
                         " Order by a.sDepartamento,a.sMunicipio,a.sDistrito,a.sBarrio"
            End If

            XdtBarrio.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdBarrio.DataSource = XdtBarrio.Source
            Me.grdBarrio.Rebind(False)

            Me.grdBarrio.Caption = " Listado de Barrios (" + Me.grdBarrio.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       FormatoBarrio
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Barrios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoBarrio()
        Try
            'Configuracion del Grid Barrio
            Me.grdBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False

            Me.grdBarrio.Splits(0).DisplayColumns("sCodDepartamento").Width = 60
            Me.grdBarrio.Splits(0).DisplayColumns("sCodMunicipio").Width = 60
            Me.grdBarrio.Splits(0).DisplayColumns("sCodDistrito").Width = 60
            Me.grdBarrio.Splits(0).DisplayColumns("sCodBarrio").Width = 60
            Me.grdBarrio.Splits(0).DisplayColumns("sDepartamento").Width = 120
            Me.grdBarrio.Splits(0).DisplayColumns("sMunicipio").Width = 120
            Me.grdBarrio.Splits(0).DisplayColumns("sDistrito").Width = 120
            Me.grdBarrio.Splits(0).DisplayColumns("sBarrio").Width = 150
            Me.grdBarrio.Splits(0).DisplayColumns("nActivo").Width = 60
            Me.grdBarrio.Splits(0).DisplayColumns("nPertenecePrograma").Width = 110

            Me.grdBarrio.Columns("sCodDepartamento").Caption = "CodDepto"
            Me.grdBarrio.Columns("sCodMunicipio").Caption = "CodMunic"
            Me.grdBarrio.Columns("sCodDistrito").Caption = "CodDistrito"
            Me.grdBarrio.Columns("sCodBarrio").Caption = "CodBarrio"
            Me.grdBarrio.Columns("sDepartamento").Caption = "Departamento"
            Me.grdBarrio.Columns("sMunicipio").Caption = "Municipio"
            Me.grdBarrio.Columns("sDistrito").Caption = "Distrito"
            Me.grdBarrio.Columns("sBarrio").Caption = "Barrio"
            Me.grdBarrio.Columns("nActivo").Caption = "Activo"
            Me.grdBarrio.Columns("nPertenecePrograma").Caption = "Incluido en Programa"

            Me.grdBarrio.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdBarrio.Splits(0).DisplayColumns("nPertenecePrograma").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Columns("nPertenecePrograma").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdBarrio.Splits(0).DisplayColumns("sCodDepartamento").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sCodMunicipio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sCodDistrito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sCodBarrio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdBarrio.Splits(0).DisplayColumns("sCodDepartamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sCodMunicipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sCodDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sCodBarrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sDepartamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sMunicipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("sBarrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdBarrio.Splits(0).DisplayColumns("nPertenecePrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtBarrio = New BOSistema.Win.XDataSet.xDataTable
            XdtDepto = New BOSistema.Win.XDataSet.xDataTable

            Me.Text = "Barrio"

            'Limpiar los Grids, estructura y Datos
            Me.grdBarrio.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       tbBarrio_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbBarrio.
    '-------------------------------------------------------------------------
    Private Sub tbBarrio_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbBarrio.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarBarrio()
            Case "toolModificar"
                LlamaModificarBarrio()
            Case "toolEliminar"
                LlamaEliminarBarrio()
            Case "toolRefrescar"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                'InicializaVariables()
                CargarBarrio(1)
                FormatoBarrio()
                'Case "toolImprimirBarrios"
                '    LlamaImprimir()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolMoverBarrio"
                '14 feb 2011
                LlamaMoverCreditoBarrio()
            Case "toolDeshacerMoverBarrio"
                '15 feb 2011
                LlamaDeshacerMoverCreditoBarrio()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    Private Sub LlamaMoverCreditoBarrio()
        Dim ObjFrmStbEditBarrio As New FrmStbEditBarrioTrasladoCredito
        'Dim DescripcionBarrio As String
        Dim StrSql As String
        Dim XdtTmpBusqueda As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            If Me.grdBarrio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            XMaximoCambios = 2 ' Por el momento solo permitir dos cambios el primero lo puede anular el segundo alli queda. 

            XdtTmpBusqueda = New BOSistema.Win.XDataSet.xDataTable
            StrSql = "SELECT     nSccMovimientoID, nStbBarrioOrigenID, nRevertido FROM         dbo.SccBarriosMovimientosMaestro WHERE     (nStbBarrioOrigenID =" & XdtBarrio.ValueField("nStbBarrioID") & ") And nRevertido= 0 "
            XdtTmpBusqueda.ExecuteSql(StrSql)
            If XdtTmpBusqueda.Table.Rows.Count > 0 Then
                MsgBox("Ese Barrio ya tiene un traslado vigente, tiene que Revertir primero.", MsgBoxStyle.Information)
                Exit Sub
            End If

            StrSql = "SELECT     dbo.StbValorParametro.sValorParametro  FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Numero Maximo de Traslado de Barrios')"
            XdtTmpBusqueda.ExecuteSql(StrSql)


            If XdtTmpBusqueda.Table.Rows.Count > 0 Then
                XMaximoCambios = XdtTmpBusqueda.ValueField("sValorParametro")
            End If

            StrSql = "SELECT     nSccMovimientoID, nStbBarrioOrigenID, nRevertido FROM         dbo.SccBarriosMovimientosMaestro WHERE     (nStbBarrioOrigenID =" & XdtBarrio.ValueField("nStbBarrioID") & ") And nRevertido= 1 "
            XdtTmpBusqueda.ExecuteSql(StrSql)
            If XdtTmpBusqueda.Table.Rows.Count > XMaximoCambios Then
                MsgBox("Ese Barrio ya tiene un traslado vigente,y solamente se permite hacer el cambio " & XMaximoCambios.ToString().Trim() & " veces. ", MsgBoxStyle.Information)
                Exit Sub
            End If


            'If XdtTmpBusqueda.Table.Rows.Count > 0 Then
            '    If XdtTmpBusqueda.Table.Rows.Count < XMaximoCambios Then

            '        MsgBox("Ese Barrio ya tiene un traslado vigente, tiene que Revertir primero.", MsgBoxStyle.Information)
            '        Exit Sub
            '    Else
            '        MsgBox("Ese Barrio ya tiene un traslado vigente,y solamente se permite hacer el cambio " & XMaximoCambios.ToString().Trim() & " veces. ", MsgBoxStyle.Information)
            '        Exit Sub
            '    End If
            'End If

            'If XdtTmpBusqueda.Table.Rows.Count >= 1 Then
            '    MsgBox("Ese Barrio ya ha tenido al menos dos veces traslados vigentes", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmStbEditBarrio.ModoFrm = "MOV"
            ObjFrmStbEditBarrio.intStbBarrioID = XdtBarrio.ValueField("nStbBarrioID")
            ObjFrmStbEditBarrio.ShowDialog()

            CargarBarrio(1)
            FormatoBarrio()
            XdtBarrio.SetCurrentByID("nStbBarrioID", ObjFrmStbEditBarrio.intStbBarrioID)
            Me.grdBarrio.Row = XdtBarrio.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditBarrio.Close()
            ObjFrmStbEditBarrio = Nothing
            XcDatos.Close()
            XcDatos = Nothing
            'XdtTmpBusqueda.Close()
            XdtTmpBusqueda = Nothing

        End Try
    End Sub

    Private Sub LlamaDeshacerMoverCreditoBarrio()
        'Dim ObjFrmStbEditBarrio As New FrmStbEditBarrioTrasladoCredito
        Dim StrSql As String
        Dim DescripcionBarrio As String
        Dim XdtTmpBusqueda As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Dim CodProcedimiento As Integer
        Try
            If Me.grdBarrio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If


            XdtTmpBusqueda = New BOSistema.Win.XDataSet.xDataTable

            StrSql = "SELECT     dbo.StbValorParametro.sValorParametro  FROM         dbo.StbParametro INNER JOIN                       dbo.StbValorParametro ON dbo.StbParametro.nStbParametroID = dbo.StbValorParametro.nStbParametroID WHERE     (dbo.StbParametro.sDescripcionParametro = 'Numero Maximo de Traslado de Barrios')"
            XdtTmpBusqueda.ExecuteSql(StrSql)


            If XdtTmpBusqueda.Table.Rows.Count > 0 Then
                XMaximoCambios = XdtTmpBusqueda.ValueField("sValorParametro")
            End If

            StrSql = "SELECT     nSccMovimientoID, nStbBarrioOrigenID, nRevertido FROM         dbo.SccBarriosMovimientosMaestro WHERE     (nStbBarrioOrigenID =" & XdtBarrio.ValueField("nStbBarrioID") & ") Order By nSccMovimientoID Desc"
            XdtTmpBusqueda.ExecuteSql(StrSql)


            If XdtTmpBusqueda.Table.Rows.Count = 0 Then
                MsgBox("No existe ningun traslado hecho desde este barrio", MsgBoxStyle.Information)
                Exit Sub
            End If

            If XdtTmpBusqueda.ValueField("nRevertido") = 1 Then
                MsgBox("El Traslado ya habia sido revertido anteriormente", MsgBoxStyle.Information)
                Exit Sub
            End If
            StrSql = "SELECT     nSccMovimientoID, nStbBarrioOrigenID, nRevertido FROM         dbo.SccBarriosMovimientosMaestro WHERE     (nStbBarrioOrigenID =" & XdtBarrio.ValueField("nStbBarrioID") & ") And nRevertido= 1 "
            XdtTmpBusqueda.ExecuteSql(StrSql)
            If XdtTmpBusqueda.Table.Rows.Count > XMaximoCambios - 1 Then
                If MsgBox("Ese Barrio ya tiene un traslado vigente,y solamente se permite hacer el cambio " & XMaximoCambios.ToString().Trim() & " veces. " & Chr(13) & "Si revierte ya no podra hacer traslado de nuevo para este barrio.  " & Chr(13) & "Quiere revertir", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If

            DescripcionBarrio = "Departamento:(" & Trim(XdtBarrio.ValueField("sDepartamento")) & ")Municipio:(" & Trim(XdtBarrio.ValueField("sMunicipio")) & ")Barrio:(" & Trim(XdtBarrio.ValueField("sBarrio")) & ") ?"
            If MsgBox("Esta Seguro de Des Hacer el Traslado que se habia hecho del Barrio " & Chr(13) & DescripcionBarrio, MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            StrSql = " EXEC spSccDesHacerTrasladoBarrioCredito  " & XdtBarrio.ValueField("nStbBarrioID") & "," & InfoSistema.IDCuenta
            CodProcedimiento = XcDatos.ExecuteScalar(StrSql)

            If CodProcedimiento = 1 Then
                MsgBox("Se ha deshecho el traslado satisfactoriamente", MsgBoxStyle.Information)

            Else
                MsgBox("Ocurrio un error en el procedimiento de traslado spSccDesHacerTrasladoBarrioCredito", MsgBoxStyle.Information)
            End If



        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
            'XdtTmpBusqueda.Close()
            XdtTmpBusqueda = Nothing

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAgregarBarrio
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditBarrio para Agregar un nuevo barrio.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarBarrio()
        Dim ObjFrmStbEditBarrio As New frmStbEditBarrio

        Try
            ObjFrmStbEditBarrio.ModoFrm = "ADD"
            ObjFrmStbEditBarrio.ShowDialog()

            If ObjFrmStbEditBarrio.intStbBarrioID <> 0 Then
                CargarBarrio(1)
                FormatoBarrio()
                XdtBarrio.SetCurrentByID("nStbBarrioID", ObjFrmStbEditBarrio.intStbBarrioID)
                Me.grdBarrio.Row = XdtBarrio.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditBarrio.Close()
            ObjFrmStbEditBarrio = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaModificarBarrio
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditBarrio para Modificar un barrio existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarBarrio()
        Dim ObjFrmStbEditBarrio As New frmStbEditBarrio

        Try
            If Me.grdBarrio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbEditBarrio.ModoFrm = "UPD"
            ObjFrmStbEditBarrio.intStbBarrioID = XdtBarrio.ValueField("nStbBarrioID")
            ObjFrmStbEditBarrio.ShowDialog()

            CargarBarrio(1)
            FormatoBarrio()
            XdtBarrio.SetCurrentByID("nStbBarrioID", ObjFrmStbEditBarrio.intStbBarrioID)
            Me.grdBarrio.Row = XdtBarrio.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditBarrio.Close()
            ObjFrmStbEditBarrio = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaEliminarBarrio
    ' Descripción:          Este procedimiento permite Eliminar un registro
    '                       de un Barrio existente. Realiza una Eliminación
    '                       física del registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarBarrio()
        Dim XdtBarrioEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdBarrio.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtBarrioEliminar.ExecuteSqlNotTable("Delete From StbBarrio where nStbBarrioID=" & XdtBarrio.ValueField("nStbBarrioID"))
                CargarBarrio(1)
                FormatoBarrio()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdBarrio.Caption = "Listado de Barrios (" + Me.grdBarrio.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtBarrioEliminar.Close()
            XdtBarrioEliminar = Nothing
        End Try

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Ficha de Inscripción.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El listado
    '                       de barrios según los parámetros seleccionados. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmStbParametroBarrio As New frmStbParametroBarrio
        Try
            Dim strSQL As String = ""

            'If Me.grdBarrio.RowCount = 0 Then
            '    MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmStbParametroBarrio.NomRep = 1
            'ObjFrmStbParametroBarrio.Idcd = XdtBarrio.ValueField("nStbBarrioID")
            'ObjFrmStbParametroBarrio.ModoFrm = "IMPRIMIR"
            'ObjFrmStbParametroBarrio.strColor = "Morado"
            ObjFrmStbParametroBarrio.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbParametroBarrio.Close()
            ObjFrmStbParametroBarrio = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdBarrio_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdBarrio_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdBarrio.Filter
        Try
            XdtBarrio.FilterLocal(e.Condition)
            Me.grdBarrio.Caption = " Listado de Barrios (" + Me.grdBarrio.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarBarrio") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar
            If Seg.HasPermission("ModificarBarrio") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarBarrio") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirBarrio") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If
            ' 
            'Hacer Traslado de Barrio a un Nuevo Barrio con sus creditos
            'Anexado Febrero 11 2011
            If Seg.HasPermission("MoverBarrioCredito") Then
                Me.toolMoverBarrio.Enabled = True
            Else
                Me.toolMoverBarrio.Enabled = False
            End If
            If Seg.HasPermission("RevertirMoverBarrioCredito") Then
                Me.toolDeshacerMoverBarrio.Enabled = True
            Else
                Me.toolDeshacerMoverBarrio.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdBarrio_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Barrio existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdBarrio_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdBarrio.DoubleClick
        Try
            If Me.grdBarrio.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarBarrio") Then
                LlamaModificarBarrio()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFicha_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdBarrio.Error
        Control_Error(e.Exception)
    End Sub

 
    Private Sub toolImprimirBarrios_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirBarrios.Click
        LlamaImprimir()
    End Sub

    Private Sub toolImprimirBarriosM_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirBarriosM.Click
        LlamaImprimirMov()
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                02/02/2011
    ' Procedure Name:       LlamaImprimirMov
    ' Descripción:          Este procedimiento permite Imprimir El listado
    '                       de los movimientos en los barrios según los parámetros seleccionados. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirMov()
        Dim ObjFrmStbParametroBarrio As New frmStbParametroBarrio
        Try
            Dim strSQL As String = ""

            'If Me.grdBarrio.RowCount = 0 Then
            '    MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmStbParametroBarrio.NomRep = 3
            'ObjFrmStbParametroBarrio.Idcd = XdtBarrio.ValueField("nStbBarrioID")
            'ObjFrmStbParametroBarrio.ModoFrm = "IMPRIMIR"
            'ObjFrmStbParametroBarrio.strColor = "Morado"
            ObjFrmStbParametroBarrio.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbParametroBarrio.Close()
            ObjFrmStbParametroBarrio = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                17/02/2011
    ' Procedure Name:       LlamaImprimirTraslado
    ' Descripción:          Este procedimiento permite Imprimir El listado
    '                       de los traslados en los barrios según los parámetros seleccionados. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirTraslado()
        Dim ObjFrmStbParametroBarrio As New frmStbParametroBarrio
        Try
            Dim strSQL As String = ""

            'If Me.grdBarrio.RowCount = 0 Then
            '    MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            ObjFrmStbParametroBarrio.NomRep = 4
            'ObjFrmStbParametroBarrio.Idcd = XdtBarrio.ValueField("nStbBarrioID")
            'ObjFrmStbParametroBarrio.ModoFrm = "IMPRIMIR"
            'ObjFrmStbParametroBarrio.strColor = "Morado"
            ObjFrmStbParametroBarrio.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbParametroBarrio.Close()
            ObjFrmStbParametroBarrio = Nothing
        End Try
    End Sub

    Private Sub toolImprimirBarriosUniones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirBarriosUniones.Click
        LlamaImprimirTraslado()
    End Sub
End Class