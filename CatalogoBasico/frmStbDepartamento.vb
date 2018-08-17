' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbDepartamento.vb
' Descripción:          Este formulario muestra Catálogo de Departamentos 
'                       y Municipios
'-------------------------------------------------------------------------
Public Class frmStbDepartamento
    '- Declaración de Variables 
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       frmStbDepartamento_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbDepartamento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsUbicacion.Close()
            XdsUbicacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       frmStbDepartamento_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Departamentos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbDepartamento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Departamentos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Try
            Dim Strsql As String

            Me.grdDepartamento.ClearFields()
            Me.grdMunicipio.ClearFields()

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre,a.nPertenecePrograma,a.nActivo " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre,a.nPertenecePrograma,a.nActivo, a.nPagoEfectivo " & _
                     " From StbMunicipio a " & _
                     " Order by a.sCodigo"

            If XdsUbicacion.ExistTable("Municipio") Then
                XdsUbicacion("Municipio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Municipio")
                XdsUbicacion("Municipio").Retrieve()
            End If

            If XdsUbicacion.ExistRelation("DepartamentoConMunicipio") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsUbicacion.NewRelation("DepartamentoConMunicipio", "Departamento", "Municipio", "nStbDepartamentoID", "nStbDepartamentoID")
            End If

            XdsUbicacion.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdDepartamento.DataSource = XdsUbicacion("Departamento").Source
            Me.grdDepartamento.Rebind(False)
            Me.grdMunicipio.DataSource = XdsUbicacion("Municipio").Source
            Me.grdMunicipio.Rebind(False)


            'Actualizando el caption de los GRIDS
            Me.grdDepartamento.Caption = " Listado de Departamentos (" + Me.grdDepartamento.RowCount.ToString + " registros)"
            Me.grdMunicipio.Caption = " Listado de Municipios (" + Me.grdMunicipio.RowCount.ToString + " registros)"
            FormatoDepartamento()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       FormatoDepartamento
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Departamentos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoDepartamento()
        Try
            'Configuracion del Grid Departamento
            Me.grdDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.grdDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 100
            Me.grdDepartamento.Splits(0).DisplayColumns("sNombre").Width = 490
            Me.grdDepartamento.Splits(0).DisplayColumns("nPertenecePrograma").Width = 110
            Me.grdDepartamento.Splits(0).DisplayColumns("nActivo").Width = 50

            Me.grdDepartamento.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDepartamento.Columns("nPertenecePrograma").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdDepartamento.Columns("sNombre").Caption = "Nombre del Departamento"
            Me.grdDepartamento.Columns("sCodigo").Caption = "Código"
            Me.grdDepartamento.Columns("nActivo").Caption = "Activo"
            Me.grdDepartamento.Columns("nPertenecePrograma").Caption = "Incluido en Programa"

            Me.grdDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDepartamento.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDepartamento.Splits(0).DisplayColumns("nPertenecePrograma").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDepartamento.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDepartamento.Splits(0).DisplayColumns("nPertenecePrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Municipio
            Me.grdMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.grdMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 100
            Me.grdMunicipio.Splits(0).DisplayColumns("sNombre").Width = 490
            Me.grdMunicipio.Splits(0).DisplayColumns("nActivo").Width = 50
            Me.grdMunicipio.Splits(0).DisplayColumns("nPertenecePrograma").Width = 110
            Me.grdMunicipio.Splits(0).DisplayColumns("nPagoEfectivo").Width = 50

            Me.grdMunicipio.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdMunicipio.Columns("nPertenecePrograma").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdMunicipio.Columns("nPagoEfectivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdMunicipio.Columns("sCodigo").Caption = "Código"
            Me.grdMunicipio.Columns("sNombre").Caption = "Nombre del Municipio"
            Me.grdMunicipio.Columns("nActivo").Caption = "Activo"
            Me.grdMunicipio.Columns("nPertenecePrograma").Caption = "Incluido en Programa"
            Me.grdMunicipio.Columns("nPagoEfectivo").Caption = "Efectivo"

            Me.grdMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("nPertenecePrograma").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("nPagoEfectivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("nPertenecePrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMunicipio.Splits(0).DisplayColumns("nPagoEfectivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsUbicacion = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdDepartamento.ClearFields()
            Me.grdMunicipio.ClearFields()


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbDepartamento_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbDepartamento.
    '-------------------------------------------------------------------------
    Private Sub tbDepartamento_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbDepartamento.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarDepartamento()
            Case "toolModificar"
                LlamaModificarDepartamento()
            Case "toolEliminar"
                LlamaEliminarDepartamento()
            Case "toolRefrescar"
                InicializaVariables()
                CargarDepartamento()
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
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir listado por
    '                       Departamento y Municipio. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmStbParametroDepto As New frmStbParametroDepto
        Try
            Dim strSQL As String = ""

            If Me.grdDepartamento.RowCount = 0 Then
                'MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbParametroDepto.NomRep = 1
            ObjFrmStbParametroDepto.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbParametroDepto.Close()
            ObjFrmStbParametroDepto = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       tbMunicipio_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMunicipio.
    '-------------------------------------------------------------------------
    Private Sub tbMunicipio_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMunicipio.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarM"
                LlamaAgregarMunicipio()
            Case "toolModificarM"
                LlamaModificarMunicipio()
            Case "toolEliminarM"
                LlamaEliminarMunicipio()
            Case "toolAyudaM"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarDepartamento
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditDepartamento para Agregar un nuevo Departamento.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarDepartamento()
        Dim ObjFrmStbEditDepartamento As New frmStbEditDepartamento
        Try
            ObjFrmStbEditDepartamento.ModoFrm = "ADD"
            ObjFrmStbEditDepartamento.ShowDialog()

            If ObjFrmStbEditDepartamento.IdDepartamento <> 0 Then
                CargarDepartamento()
                XdsUbicacion("Departamento").SetCurrentByID("nstbDepartamentoID", ObjFrmStbEditDepartamento.IdDepartamento)
                Me.grdDepartamento.Row = XdsUbicacion("Departamento").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditDepartamento.Close()
            ObjFrmStbEditDepartamento = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaAgregarMunicipio
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditMunicipio para Agregar un nuevo Municipio para un
    '                       determinado Departamento.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarMunicipio()
        Dim ObjFrmStbEditMunicipio As New frmStbEditMunicipio
        Try
            'Departamento Inactivo
            If XdsUbicacion("Departamento").ValueField("nActivo") = False Then
                MsgBox("No puede Agregar Municipios, Departamento Inactivo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbEditMunicipio.ModoFrm = "ADD"
            ObjFrmStbEditMunicipio.IdDepartamento = XdsUbicacion("Departamento").ValueField("nstbDepartamentoID")
            ObjFrmStbEditMunicipio.ShowDialog()

            If ObjFrmStbEditMunicipio.IdMunicipio <> 0 Then

                CargarDepartamento()
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", ObjFrmStbEditMunicipio.IdDepartamento)
                Me.grdDepartamento.Row = XdsUbicacion("Departamento").BindingSource.Position

                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", ObjFrmStbEditMunicipio.IdMunicipio)
                Me.grdMunicipio.Row = XdsUbicacion("Municipio").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditMunicipio.Close()
            ObjFrmStbEditMunicipio = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       LlamaModificarDepartamento
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditDepartamento para Modificar un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarDepartamento()
        Dim ObjFrmStbEditDepartamento As New frmStbEditDepartamento
        Try
            If Me.grdDepartamento.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'If XdsDocSoporte("Documento").ValueField("Activo") = False Then
            '    MsgBox("No se puede Modificar. Documento Soporte Inactivo.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            ObjFrmStbEditDepartamento.ModoFrm = "UPD"
            ObjFrmStbEditDepartamento.IdDepartamento = XdsUbicacion("Departamento").ValueField("nStbDepartamentoID")
            ObjFrmStbEditDepartamento.ShowDialog()

            'InicializaVariables()
            CargarDepartamento()
            XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", ObjFrmStbEditDepartamento.IdDepartamento)
            Me.grdDepartamento.Row = XdsUbicacion("Departamento").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditDepartamento.Close()
            ObjFrmStbEditDepartamento = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaModificarMunicipio
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditMunicipio para Modificar un Municipio existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarMunicipio()
        Dim ObjFrmStbEditMunicipio As New frmStbEditMunicipio
        Try
            If Me.grdMunicipio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If XdsUbicacion("Departamento").ValueField("nActivo") = False Then
                MsgBox("No se puede Modificar. Departamento Inactivo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbEditMunicipio.ModoFrm = "UPD"
            ObjFrmStbEditMunicipio.IdDepartamento = XdsUbicacion("Departamento").ValueField("nStbDepartamentoID")
            ObjFrmStbEditMunicipio.IdMunicipio = XdsUbicacion("Municipio").ValueField("nStbMunicipioID")
            ObjFrmStbEditMunicipio.ShowDialog()

            CargarDepartamento()
            XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", ObjFrmStbEditMunicipio.IdDepartamento)
            Me.grdDepartamento.Row = XdsUbicacion("Departamento").BindingSource.Position

            XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", ObjFrmStbEditMunicipio.IdMunicipio)
            Me.grdMunicipio.Row = XdsUbicacion("Municipio").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditMunicipio.Close()
            ObjFrmStbEditMunicipio = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       LlamaEliminarDepartamento
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarDepartamento()
        Dim XdtDepartamento As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdDepartamento.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Eliminar El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtDepartamento.ExecuteSqlNotTable("Delete From StbDepartamento where nStbDepartamentoID=" & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID"))
                CargarDepartamento()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdDepartamento.Caption = "Listado de Departamentos (" + Me.grdDepartamento.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtDepartamento.Close()
            XdtDepartamento = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaEliminarMunicipio
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Municipio asociado a un Departamento existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarMunicipio()
        Dim XdtMunicipio As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim intPosicion As Integer

            If Me.grdMunicipio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If Me.grdMunicipio.RowCount = 1 Then
                MsgBox("DEBE existir al menos un (1) Municipio asociado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Eliminar El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                intPosicion = XdsUbicacion("Departamento").ValueField("nStbDepartamentoID")

                XdtMunicipio.ExecuteSqlNotTable("Delete From StbMunicipio where nStbMunicipioID=" & XdsUbicacion("Municipio").ValueField("nStbMunicipioID"))
                CargarDepartamento()
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", intPosicion)
                Me.grdDepartamento.Row = XdsUbicacion("Departamento").BindingSource.Position

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdDepartamento.Caption = "Listado de Departamentos (" + Me.grdDepartamento.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtMunicipio.Close()
            XdtMunicipio = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Departamento.
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
    ' Fecha:                12/09/2007
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
    ' Procedure Name:       grdDepartamento_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Departamento existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDepartamento_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDepartamento.DoubleClick
        Try
            If Seg.HasPermission("ModificarDepto") Then
                LlamaModificarDepartamento()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdDepartamento_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDepartamento.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdDepartamento_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdDepartamento_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDepartamento.Filter
        Try
            XdsUbicacion("Departamento").FilterLocal(e.Condition)
            Me.grdDepartamento.Caption = " Listado de Departamentos (" + Me.grdDepartamento.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarDepto") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarDepto") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarDepto") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirDeptoMunic") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

            'Agregar
            If Seg.HasPermission("AgregarMunic") Then
                Me.toolAgregarM.Enabled = True
            Else
                Me.toolAgregarM.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarMunic") Then
                Me.toolModificarM.Enabled = True
            Else
                Me.toolModificarM.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarMunic") Then
                Me.toolEliminarM.Enabled = True
            Else
                Me.toolEliminarM.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdDepartamento_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Municipios con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdDepartamento_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdDepartamento.RowColChange
        Me.grdMunicipio.Caption = " Listado de Municipios (" + Me.grdMunicipio.RowCount.ToString + " registros)"
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdMunicipio_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Municipio existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdMunicipio_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMunicipio.DoubleClick
        Try
            If Seg.HasPermission("ModificarMunic") Then
                LlamaModificarMunicipio()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdMunicipio_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdMunicipio.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       grdMunicipio_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdMunicipio_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdMunicipio.Filter
        Try
            XdsUbicacion("Municipio").FilterLocal(e.Condition)
            Me.grdMunicipio.Caption = " Listado de Municipios (" + Me.grdMunicipio.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class