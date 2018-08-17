' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                05/07/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbCargo.vb
' Descripción:          Este formulario muestra Catálogo de Cargos.
'-------------------------------------------------------------------------
Public Class frmStbCargo

    '- Declaración de Variables 
    Dim XdsCargo As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmStbCargo_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbCargo_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsCargo.Close()
            XdsCargo = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmStbCargo_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Cuentas Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbCargo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try

            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarCargo()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       CargarCargo
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCargo()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSrhCargoID,a.sCodigo,a.sNombreCargo,a.nActivo " & _
                     " From SrhCargo a " & _
                     " Order by a.sCodigo "

            If XdsCargo.ExistTable("Cargo") Then
                XdsCargo("Cargo").ExecuteSql(Strsql)
            Else
                XdsCargo.NewTable(Strsql, "Cargo")
                XdsCargo("Cargo").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdCargo.DataSource = XdsCargo("Cargo").Source

            'Actualizando el caption de los GRIDS
            Me.grdCargo.Caption = " Listado de Cargos (" + Me.grdCargo.RowCount.ToString + " registros)"
            FormatoCargo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       FormatoCargo
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCargo()
        Try
            'Configuracion del Grid Cargos
            Me.grdCargo.Splits(0).DisplayColumns("nSrhCargoID").Visible = False

            Me.grdCargo.Splits(0).DisplayColumns("sCodigo").Width = 80
            Me.grdCargo.Splits(0).DisplayColumns("sNombreCargo").Width = 300
            Me.grdCargo.Splits(0).DisplayColumns("nActivo").Width = 60

            Me.grdCargo.Columns("sCodigo").Caption = "Código"
            Me.grdCargo.Columns("sNombreCargo").Caption = "Descripción"
            Me.grdCargo.Columns("nActivo").Caption = "Activo"

            Me.grdCargo.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCargo.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdCargo.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCargo.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCargo.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCargo.Splits(0).DisplayColumns("sNombreCargo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsCargo = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdCargo.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       tbCargo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCargo.
    '-------------------------------------------------------------------------
    Private Sub tbCargo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCargo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCargo()
            Case "toolModificar"
                LlamaModificarCargo()
            Case "toolEliminar"
                LlamaEliminarCargo()
            Case "toolRefrescar"
                InicializaVariables()
                CargarCargo()

            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaAgregarCargo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Agregar un nuevo Cargo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCargo()
        Dim ObjFrmScnEditCargo As New frmStbEditCargo
        Try
            ObjFrmScnEditCargo.ModoFrm = "ADD"
            ObjFrmScnEditCargo.ShowDialog()

            If ObjFrmScnEditCargo.IdCargo <> 0 Then
                CargarCargo()
                XdsCargo("Cargo").SetCurrentByID("nSrhCargoID", ObjFrmScnEditCargo.IdCargo)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCargo.Close()
            ObjFrmScnEditCargo = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaModificarCargo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Modificar un cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCargo()
        Dim ObjFrmScnEditCargo As New frmStbEditCargo
        Try
            If Me.grdCargo.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmScnEditCargo.ModoFrm = "UPD"
            ObjFrmScnEditCargo.IdCargo = XdsCargo("Cargo").ValueField("nSrhCargoID")
            ObjFrmScnEditCargo.ShowDialog()

            If ObjFrmScnEditCargo.IdCargo <> 0 Then
                InicializaVariables()
                CargarCargo()
                XdsCargo("Cargo").SetCurrentByID("nSrhCargoID", ObjFrmScnEditCargo.IdCargo)
                Me.grdCargo.Row = XdsCargo("Cargo").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCargo.Close()
            ObjFrmScnEditCargo = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaEliminarCargo
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCargo()
        Dim XdtCargo As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdCargo.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtCargo.ExecuteSqlNotTable("Delete From SrhCargo where nSrhCargoID=" & XdsCargo("Cargo").ValueField("nSrhCargoID"))
                CargarCargo()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdCargo.Caption = "Listado de Cargos (" + Me.grdCargo.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtCargo.Close()
            XdtCargo = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de CtaBancaria.
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
    ' Fecha:                05/07/2007
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
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdCargo_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Cuenta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCargo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCargo.DoubleClick
        Try
            If Seg.HasPermission("ModificarCargo") Then
                LlamaModificarCargo()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdCargo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCargo.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdCtaBancaria_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCargo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCargo.Filter
        Try
            XdsCargo("Cargo").FilterLocal(e.Condition)
            Me.grdCargo.Caption = " Listado de Cargos (" + Me.grdCargo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarCargo") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarCargo") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarCargo") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirCargo") Then
                Me.ToolImprimir.Enabled = True
            Else
                Me.ToolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	05/07/2007
    ' Procedure name	:	Imprimir
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de 
    '                   :   Cargos
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirCargo()
        Dim ObjfrmScnParametroCargo As New frmStbParametroMoneda
        Try
            ObjfrmScnParametroCargo.NomRep = frmStbParametroMoneda.EnumReportes.rptStbCargo
            ObjfrmScnParametroCargo.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmScnParametroCargo.Close()
            ObjfrmScnParametroCargo = Nothing
        End Try
    End Sub

    Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImprimir.Click
        Try
            ImprimirCargo()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class