' ------------------------------------------------------------------------
' Autor:                Lic. Alberto Blandón Silva
' Fecha:                25/03/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbReporte.vb
' Descripción:          Este formulario muestra Catálogo de Reportes.
'-------------------------------------------------------------------------
Public Class frmStbReporte

    '- Declaración de Variables 
    Dim XdsReporte As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       frmStbReporte_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbReporte_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsReporte.Close()
            XdsReporte = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       frmStbReporte_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Cuentas Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbReporte_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarReporte()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       CargarReporte
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre los Reportes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarReporte()
        Try
            Dim Strsql As String

            Strsql = "SELECT   StbReporte.nStbReporteID, StbReporte.nCodigo, StbReporte.sTitulo, StbReporte.sDescripcion, StbReporte.sNombreArchivoRpt, " & _
                    " SsgModulo.Nombre" & _
                    " FROM  StbReporte INNER JOIN " & _
                    " SsgModulo ON StbReporte.nSsgModuloID = SsgModulo.SsgModuloID" & _
                    " order by SsgModulo.Nombre,StbReporte.nCodigo"

            If XdsReporte.ExistTable("Reporte") Then
                XdsReporte("Reporte").ExecuteSql(Strsql)
            Else
                XdsReporte.NewTable(Strsql, "Reporte")
                XdsReporte("Reporte").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdReporte.DataSource = XdsReporte("Reporte").Source

            'Actualizando el caption de los GRIDS
            Me.grdReporte.Caption = " Listado de Reporte (" + Me.grdReporte.RowCount.ToString + " registros)"
            FormatoReporte()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       FormatoReporte
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre los Reportes en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoReporte()
        Try
            'Configuracion del Grid Reportes
            Me.grdReporte.Splits(0).DisplayColumns("nStbReporteID").Visible = False

            Me.grdReporte.Splits(0).DisplayColumns("nCodigo").Width = 40
            Me.grdReporte.Splits(0).DisplayColumns("sTitulo").Width = 300
            Me.grdReporte.Splits(0).DisplayColumns("sDescripcion").Width = 220
            Me.grdReporte.Splits(0).DisplayColumns("sNombreArchivoRpt").Width = 120
            Me.grdReporte.Splits(0).DisplayColumns("Nombre").Width = 100
            

            Me.grdReporte.Columns("nCodigo").Caption = "Código"
            Me.grdReporte.Columns("sTitulo").Caption = "Titulo"
            Me.grdReporte.Columns("sDescripcion").Caption = "Descripción"
            Me.grdReporte.Columns("sNombreArchivoRpt").Caption = "Archivo"
            Me.grdReporte.Columns("Nombre").Caption = "Modulo"
            
            Me.grdReporte.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.grdReporte.Splits(0).DisplayColumns("sTitulo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.

            Me.grdReporte.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReporte.Splits(0).DisplayColumns("sTitulo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReporte.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReporte.Splits(0).DisplayColumns("sNombreArchivoRpt").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReporte.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsReporte = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdReporte.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       tbReporte_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbReporte.
    '-------------------------------------------------------------------------
    Private Sub tbReporte_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReporte.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarReporte()
            Case "toolModificar"
                LlamaModificarReporte()
            Case "toolEliminar"
                LlamaEliminarReporte()
            Case "toolRefrescar"
                InicializaVariables()
                CargarReporte()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       LlamaAgregarReporte
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditReporte para Agregar un nuevo Reporte.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarReporte()
        Dim ObjFrmScnEditReporte As New frmStbEditReporte
        Try
            ObjFrmScnEditReporte.ModoFrm = "ADD"
            ObjFrmScnEditReporte.ShowDialog()

            If ObjFrmScnEditReporte.IdReporte <> 0 Then
                CargarReporte()
                XdsReporte("Reporte").SetCurrentByID("nStbReporteID", ObjFrmScnEditReporte.IdReporte)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditReporte.Close()
            ObjFrmScnEditReporte = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       LlamaModificarReporte
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditReporte para Modificar un Reporte existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarReporte()
        Dim ObjFrmScnEditReporte As New frmStbEditReporte
        Try
            If Me.grdReporte.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmScnEditReporte.ModoFrm = "UPD"
            ObjFrmScnEditReporte.IdReporte = XdsReporte("Reporte").ValueField("nStbReporteID")
            ObjFrmScnEditReporte.ShowDialog()

            If ObjFrmScnEditReporte.IdReporte <> 0 Then
                InicializaVariables()
                CargarReporte()
                Me.grdReporte.Row = XdsReporte("Reporte").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditReporte.Close()
            ObjFrmScnEditReporte = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       LlamaEliminarReporte
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Reporte existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarReporte()
        Dim XdtReporte As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdReporte.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtReporte.ExecuteSqlNotTable("Delete From StbReporte where nStbReporteID=" & XdsReporte("Reporte").ValueField("nStbReporteID"))
                CargarReporte()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdReporte.Caption = "Listado de Reportes (" + Me.grdReporte.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtReporte.Close()
            XdtReporte = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón silva
    ' Fecha:                25/03/2009
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
    ' Autor:                Lic. Alberto S. Blandón Silva.
    ' Fecha:                06/04/2009
    ' Procedure Name:       grdReporte_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Cuenta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdReporte_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdReporte.DoubleClick
        Try
            If Seg.HasPermission("ModificarReporte") Then
                LlamaModificarReporte()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdReporte_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdReporte.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva
    ' Fecha:                25/03/2009
    ' Procedure Name:       grdReporte_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdReporte_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdReporte.Filter
        Try
            XdsReporte("Reporte").FilterLocal(e.Condition)
            Me.grdReporte.Caption = " Listado de Reportes (" + Me.grdReporte.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Lic. Alberto Blandón Silva.
    ' Fecha:                25/03/2009
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarReporte") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarReporte") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarReporte") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirReporte") Then
                Me.ToolImprimir.Enabled = True
            Else
                Me.ToolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Lic. Alberto Blandón Silva
    ' Date			    :	25/03/2009
    ' Procedure name	:	ImprimirReporte
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de 
    '                   :   Reportes
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirReporte()
        Dim ObjfrmStbParametroReporte As New frmStbParametroListadoRpt
        Try
            ObjfrmStbParametroReporte.NomRep = frmStbParametroListadoRpt.EnumReportes.ListadodeReportes
            ObjfrmStbParametroReporte.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmStbParametroReporte.Close()
            ObjfrmStbParametroReporte = Nothing
        End Try
    End Sub

    Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImprimir.Click
        Try
            ImprimirReporte()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEliminar.Click

    End Sub

    Private Sub toolAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregar.Click

    End Sub

    Private Sub toolModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModificar.Click

    End Sub
End Class