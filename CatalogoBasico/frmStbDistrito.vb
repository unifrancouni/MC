' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbDistrito.vb
' Descripción:          Este formulario carga los principales datos del
'                       catálogo de Distritos.
'-------------------------------------------------------------------------
Public Class frmStbDistrito
    '- Declaración de Variables 
    Dim XdtDistrito As BOSistema.Win.XDataSet.xDataTable

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbDistrito_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbDistrito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtDistrito.Close()
            XdtDistrito = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbDistrito_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Barrios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbDistrito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarDistrito()
            FormatoDistrito()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de los distritos en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarDistrito()
        Try
            Dim Strsql As String = ""


            Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre,a.nPertenecePrograma,a.nActivo " & _
                     " From StbDistrito a " & _
                     " Where sCodigo <> '0' " & _
                     " Order by a.sCodigo"

            XdtDistrito.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdDistrito.DataSource = XdtDistrito.Source

            Me.grdDistrito.Caption = " Listado de Distritos (" + Me.grdDistrito.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       FormatoDistrito
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Distritos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoDistrito()
        Try
            'Configuracion del Grid Distrito
            Me.grdDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False

            Me.grdDistrito.Splits(0).DisplayColumns("sCodigo").Width = 120
            Me.grdDistrito.Splits(0).DisplayColumns("sNombre").Width = 150
            Me.grdDistrito.Splits(0).DisplayColumns("nActivo").Width = 60
            Me.grdDistrito.Splits(0).DisplayColumns("nPertenecePrograma").Width = 130

            Me.grdDistrito.Columns("sCodigo").Caption = "Código"
            Me.grdDistrito.Columns("sNombre").Caption = "Nombre del Distrito"
            Me.grdDistrito.Columns("nActivo").Caption = "Activo"
            Me.grdDistrito.Columns("nPertenecePrograma").Caption = "Incluido en Programa"

            Me.grdDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDistrito.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDistrito.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdDistrito.Splits(0).DisplayColumns("nPertenecePrograma").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDistrito.Columns("nPertenecePrograma").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDistrito.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDistrito.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDistrito.Splits(0).DisplayColumns("nPertenecePrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
            XdtDistrito = New BOSistema.Win.XDataSet.xDataTable

            Me.Text = "Distrito"

            'Limpiar los Grids, estructura y Datos
            Me.grdDistrito.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       tbDistrito_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbDistrito.
    '-------------------------------------------------------------------------
    Private Sub tbDistrito_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbDistrito.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarDistrito()
            Case "toolModificar"
                LlamaModificarDistrito()
            Case "toolEliminar"
                LlamaEliminarDistrito()
            Case "toolRefrescar"
                InicializaVariables()
                CargarDistrito()
                FormatoDistrito()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAgregarDistrito
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditDistrito para Agregar un nuevo barrio.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarDistrito()
        Dim ObjFrmStbEditDistrito As New frmStbEditDistrito
        Try
            ObjFrmStbEditDistrito.ModoFrm = "ADD"
            ObjFrmStbEditDistrito.ShowDialog()

            If ObjFrmStbEditDistrito.IdDistrito <> 0 Then
                CargarDistrito()
                XdtDistrito.SetCurrentByID("nStbDistritoID", ObjFrmStbEditDistrito.IdDistrito)
                Me.grdDistrito.Row = XdtDistrito.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmSclEditFichaInscripcion.Close()
            ObjFrmStbEditDistrito = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaModificarDistrito
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditBarrio para Modificar un barrio existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarDistrito()
        Dim ObjFrmStbEditDistrito As New frmStbEditDistrito
        Try
            If Me.grdDistrito.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbEditDistrito.ModoFrm = "UPD"
            ObjFrmStbEditDistrito.IdDistrito = XdtDistrito.ValueField("nStbDistritoID")
            ObjFrmStbEditDistrito.ShowDialog()

            CargarDistrito()
            XdtDistrito.SetCurrentByID("nStbDistritoID", ObjFrmStbEditDistrito.IdDistrito)
            Me.grdDistrito.Row = XdtDistrito.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmSclEditFichaInscripcion.Close()
            ObjFrmStbEditDistrito = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaEliminarDistrito
    ' Descripción:          Este procedimiento permite Eliminar un registro
    '                       de un Distrito existente. Realiza una Eliminación
    '                       física del registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarDistrito()
        Dim XdtDistritoEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdDistrito.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtDistritoEliminar.ExecuteSqlNotTable("Delete From StbDistrito where nStbDistritoID=" & XdtDistrito.ValueField("nStbDistritoID"))
                CargarDistrito()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdDistrito.Caption = "Listado de Distritos (" + Me.grdDistrito.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtDistritoEliminar.Close()
            XdtDistritoEliminar = Nothing
        End Try

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Distritos.
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
    '                       de distritos según los parámetros seleccionados. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmStbParametroDistrito As New frmStbParametroDistrito
        Try
            Dim strSQL As String = ""

            If Me.grdDistrito.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbParametroDistrito.NomRep = 1
            'ObjFrmStbParametroBarrio.Idcd = XdtBarrio.ValueField("nStbBarrioID")
            'ObjFrmStbParametroBarrio.ModoFrm = "IMPRIMIR"
            'ObjFrmStbParametroBarrio.strColor = "Morado"
            ObjFrmStbParametroDistrito.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdDistrito_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdDistrito_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDistrito.Filter
        Try
            XdtDistrito.FilterLocal(e.Condition)
            Me.grdDistrito.Caption = " Listado de Distritos (" + Me.grdDistrito.RowCount.ToString + " registros)"
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
            If Seg.HasPermission("AgregarDistrito") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar
            If Seg.HasPermission("ModificarDistrito") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarDistrito") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirDistrito") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdDistrito_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Distrito existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDistrito_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDistrito.DoubleClick
        Try
            If Me.grdDistrito.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarDistrito") Then
                LlamaModificarDistrito()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdDistrito_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDistrito.Error
        Control_Error(e.Exception)
    End Sub
End Class