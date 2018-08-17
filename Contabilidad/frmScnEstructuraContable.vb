' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                05/07/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbCargo.vb
' Descripción:          Este formulario muestra Catálogo de Niveles.
'-------------------------------------------------------------------------
Public Class frmScnEstructuraContable

    '- Declaración de Variables 
    Dim XdsEstructura As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmScnEstructuraContable_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnEstructuraContable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsEstructura.Close()
            XdsEstructura = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmScnEstructuraContable_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Cuentas Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnEstructuraContable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarEstructura()
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
    ' Procedure Name:       CargarEstructura
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre las Estructura de Cuetnas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarEstructura()
        Try
            Dim Strsql As String

            Strsql = " Select a.nScnEstructuraContableID,a.nNivel,a.sDescripcionNivel,a.nDigitosNivel " & _
                     " From ScnEstructuraContable a " & _
                     " Order by a.nNivel "

            If XdsEstructura.ExistTable("Estructura") Then
                XdsEstructura("Estructura").ExecuteSql(Strsql)
            Else
                XdsEstructura.NewTable(Strsql, "Estructura")
                XdsEstructura("Estructura").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdEstructuraCuenta.DataSource = XdsEstructura("Estructura").Source

            'Actualizando el caption de los GRIDS
            Me.grdEstructuraCuenta.Caption = " Listado de Niveles (" + Me.grdEstructuraCuenta.RowCount.ToString + " registros)"
            FormatoEstructura()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       FormatoEstructura
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoEstructura()
        Try
            'Configuracion del Grid Cargos
            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nScnEstructuraContableID").Visible = False

            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nNivel").Width = 150
            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("sDescripcionNivel").Width = 400
            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nDigitosNivel").Width = 60

            Me.grdEstructuraCuenta.Columns("nNivel").Caption = "Nivel"
            Me.grdEstructuraCuenta.Columns("sDescripcionNivel").Caption = "Descripción"
            Me.grdEstructuraCuenta.Columns("nDigitosNivel").Caption = "Número de Dígitos del Nivel"

            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nNivel").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nDigitosNivel").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nNivel").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("sDescripcionNivel").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEstructuraCuenta.Splits(0).DisplayColumns("nDigitosNivel").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
            XdsEstructura = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdEstructuraCuenta.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       tbEstructuraCuenta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbEstructuraCuenta.
    '-------------------------------------------------------------------------
    Private Sub tbEstructuraCuenta_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbEstructuraCuenta.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarEstructura()
            Case "toolModificar"
                LlamaModificarEstructura()
            Case "toolEliminar"
                LlamaEliminarEstructura()
            Case "toolRefrescar"
                InicializaVariables()
                CargarEstructura()
            Case "ToolImprimir"
                ImprimirEstructura()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaAgregarEstructura
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Agregar un nuevo Cargo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarEstructura()
        Dim ObjFrmScnEditEstructuraContable As New frmScnEditEstructuraContable
        Try
            ObjFrmScnEditEstructuraContable.ModoFrm = "ADD"
            ObjFrmScnEditEstructuraContable.ShowDialog()

            If ObjFrmScnEditEstructuraContable.IdEstructura <> 0 Then
                CargarEstructura()
                XdsEstructura("Estructura").SetCurrentByID("nScnEstructuraContableID", ObjFrmScnEditEstructuraContable.IdEstructura)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditEstructuraContable.Close()
            ObjFrmScnEditEstructuraContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaModificarCargo
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Modificar un cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarEstructura()
        Dim XdtCatalogoContable As New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
        Dim ObjFrmScnEditEstructuraContable As New frmScnEditEstructuraContable
        Try
            If Me.grdEstructuraCuenta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            XdtCatalogoContable.Filter = " nScnEstructuraContableID = " & XdsEstructura("Estructura").ValueField("nScnEstructuraContableID")
            XdtCatalogoContable.Retrieve()

            If XdtCatalogoContable.Count > 0 Then
                MsgBox("No es posible Modificar. Existen Cuentas Contables asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmScnEditEstructuraContable.ModoFrm = "UPD"
            ObjFrmScnEditEstructuraContable.IdEstructura = XdsEstructura("Estructura").ValueField("nScnEstructuraContableID")
            ObjFrmScnEditEstructuraContable.ShowDialog()

            If ObjFrmScnEditEstructuraContable.IdEstructura <> 0 Then
                InicializaVariables()
                CargarEstructura()
                XdsEstructura("Estructura").SetCurrentByID("nScnEstructuraContableID", ObjFrmScnEditEstructuraContable.IdEstructura)
                Me.grdEstructuraCuenta.Row = XdsEstructura("Estructura").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmScnEditEstructuraContable.Close()
            ObjFrmScnEditEstructuraContable = Nothing

            XdtCatalogoContable.Close()
            XdtCatalogoContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaEliminarEstructura
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarEstructura()
        Dim XdtEstructura As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdEstructuraCuenta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtEstructura.ExecuteSqlNotTable("Delete From ScnEstructuraContable where nScnEstructuraContableID=" & XdsEstructura("Estructura").ValueField("nScnEstructuraContableID"))
                CargarEstructura()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdEstructuraCuenta.Caption = "Listado de Niveles (" + Me.grdEstructuraCuenta.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtEstructura.Close()
            XdtEstructura = Nothing
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
    ' Procedure Name:       grdEstructuraCuenta_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Cuenta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdEstructuraCuenta_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdEstructuraCuenta.DoubleClick
        Try
            If Seg.HasPermission("ModificarEstructuraContable") Then
                LlamaModificarEstructura()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdEstructuraCuenta_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdEstructuraCuenta.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdCtaBancaria_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdEstructuraCuenta_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdEstructuraCuenta.Filter
        Try
            XdsEstructura("Estructura").FilterLocal(e.Condition)
            Me.grdEstructuraCuenta.Caption = " Listado de Niveles (" + Me.grdEstructuraCuenta.RowCount.ToString + " registros)"

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
            If Seg.HasPermission("AgregarEstructuraContable") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarEstructuraContable") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarEstructuraContable") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirEstructuraContable") Then
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
    Private Sub ImprimirEstructura()
        Dim frmVisor As New frmCRVisorReporte
        Try
            If Me.grdEstructuraCuenta.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Parametros("@gfg") = ""
            frmVisor.NombreReporte = "RepScnCN1.rpt"
            frmVisor.Text = "Reporte de Estructura Contable"
            'frmVisor.RegistrosSeleccion = "{ScnEstructuraContable.nNivel} = 1"
            'frmVisor.SQLQuery = "Select * From ScnEstructuraContable Where nNivel = 1"
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

End Class