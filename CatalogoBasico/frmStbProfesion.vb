' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Su�rez Tijerino
' Fecha:                05/07/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbProfesion.vb
' Descripci�n:          Este formulario muestra Cat�logo de Profesiones.
'-------------------------------------------------------------------------
Public Class frmStbProfesion

    '- Declaraci�n de Variables 
    Dim XdsProfesion As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmStbProfesion_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbProfesion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsProfesion.Close()
            XdsProfesion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmStbProfesion_Load
    ' Descripci�n:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Profesiones en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbProfesion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicaci�n.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarProfesion()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       CargarProfesion
    ' Descripci�n:          Este procedimiento permite cargar 
    '                       los datos sobre Profesiones en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarProfesion()
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbProfesionID,a.sCodigo,a.sNombreCarrera,a.sTituloObtenido,a.sTituloAbreviado,a.nActivo " & _
                     " From vwStbProfesion a " & _
                     " Order by a.sCodigo "

            If XdsProfesion.ExistTable("Profesion") Then
                XdsProfesion("Profesion").ExecuteSql(Strsql)
            Else
                XdsProfesion.NewTable(Strsql, "Profesion")
                XdsProfesion("Profesion").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdProfesion.DataSource = XdsProfesion("Profesion").Source

            'Actualizando el caption de los GRIDS
            Me.grdProfesion.Caption = " Listado de Profesiones (" + Me.grdProfesion.RowCount.ToString + " registros)"
            FormatoProfesion()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       FormatoProfesion
    ' Descripci�n:          Este procedimiento permite configurar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoProfesion()
        Try
            'Configuracion del Grid Cargos
            Me.grdProfesion.Splits(0).DisplayColumns("nStbProfesionID").Visible = False

            Me.grdProfesion.Splits(0).DisplayColumns("sCodigo").Width = 80
            Me.grdProfesion.Splits(0).DisplayColumns("sNombreCarrera").Width = 300
            Me.grdProfesion.Splits(0).DisplayColumns("sTituloObtenido").Width = 190
            Me.grdProfesion.Splits(0).DisplayColumns("sTituloAbreviado").Width = 120
            Me.grdProfesion.Splits(0).DisplayColumns("nActivo").Width = 60

            Me.grdProfesion.Columns("sCodigo").Caption = "C�digo"
            Me.grdProfesion.Columns("sNombreCarrera").Caption = "Descripci�n"
            Me.grdProfesion.Columns("sTituloObtenido").Caption = "T�tulo Obtenido"
            Me.grdProfesion.Columns("sTituloAbreviado").Caption = "T�tulo Abreviado"
            Me.grdProfesion.Columns("nActivo").Caption = "Activo"

            Me.grdProfesion.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdProfesion.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdProfesion.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdProfesion.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdProfesion.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdProfesion.Splits(0).DisplayColumns("sNombreCarrera").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdProfesion.Splits(0).DisplayColumns("sTituloObtenido").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdProfesion.Splits(0).DisplayColumns("sTituloAbreviado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsProfesion = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdProfesion.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       tbProfesion_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbProfesion.
    '-------------------------------------------------------------------------
    Private Sub tbCargo_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbProfesion.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarProfesion()
            Case "toolModificar"
                LlamaModificarProfesion()
            Case "toolEliminar"
                LlamaEliminarProfesion()
            Case "toolRefrescar"
                InicializaVariables()
                CargarProfesion()

            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaAgregarProfesion
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmStbEditProfesion para Agregar un nuevo Profesion.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarProfesion()
        Dim ObjFrmStbEditProfesion As New frmStbEditProfesion
        Try
            ObjFrmStbEditProfesion.ModoFrm = "ADD"
            ObjFrmStbEditProfesion.ShowDialog()

            If ObjFrmStbEditProfesion.IdProfesion <> 0 Then
                CargarProfesion()
                XdsProfesion("Profesion").SetCurrentByID("nStbProfesionID", ObjFrmStbEditProfesion.IdProfesion)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditProfesion.Close()
            ObjFrmStbEditProfesion = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaModificarProfesion
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Modificar un cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarProfesion()
        Dim ObjFrmScnEditProfesion As New frmStbEditProfesion
        Try
            If Me.grdProfesion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            ObjFrmScnEditProfesion.ModoFrm = "UPD"
            ObjFrmScnEditProfesion.IdProfesion = XdsProfesion("Profesion").ValueField("nStbProfesionID")
            ObjFrmScnEditProfesion.ShowDialog()

            If ObjFrmScnEditProfesion.IdProfesion <> 0 Then
                InicializaVariables()
                CargarProfesion()
                XdsProfesion("Profesion").SetCurrentByID("nStbProfesionID", ObjFrmScnEditProfesion.IdProfesion)
                Me.grdProfesion.Row = XdsProfesion("Profesion").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditProfesion.Close()
            ObjFrmScnEditProfesion = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaEliminarProfesion
    ' Descripci�n:          Este procedimiento permite eliminar un registro
    '                       de una Profesion existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarProfesion()
        Dim XdtCargo As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdProfesion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("�Est� seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtCargo.ExecuteSqlNotTable("Delete From StbProfesion where nStbProfesionID=" & XdsProfesion("Profesion").ValueField("nStbProfesionID"))
                CargarProfesion()

                MsgBox("El registro se elimin� satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdProfesion.Caption = "Listado de Profesiones (" + Me.grdProfesion.RowCount.ToString + " registros)"
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
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripci�n:          Este procedimiento permite cerrar la opci�n de CtaBancaria.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripci�n:          Este procedimiento permite presentar la Ayuda en
    '                       L�nea al usuario. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdCargo_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Cuenta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCargo_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdProfesion.DoubleClick
        Try
            If Seg.HasPermission("ModificarProfesion") Then
                LlamaModificarProfesion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdCargo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdProfesion.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdCtaBancaria_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCargo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdProfesion.Filter
        Try
            XdsProfesion("Profesion").FilterLocal(e.Condition)
            Me.grdProfesion.Caption = " Listado de Profesiones (" + Me.grdProfesion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       Seguridad
    ' Descripci�n:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarProfesion") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarProfesion") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarProfesion") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirProfesion") Then
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
    '                   :   Profesiones
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirProfesion()
        Try
            Dim ObjfrmScnParametroProfesion As frmStbParametroMoneda

            ObjfrmScnParametroProfesion = New frmStbParametroMoneda
            ObjfrmScnParametroProfesion.NomRep = frmStbParametroMoneda.EnumReportes.rptStbProfesion
            ObjfrmScnParametroProfesion.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImprimir.Click
        Try
            ImprimirProfesion()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class