Public Class frmStbCatalogo

    'Variable de tipo entidad que me contiene los Catalogos y 
    'valores de catalogos

    Dim ObjCatalogos As BOSistema.Win.StbEntCatalogo

    Private Sub toolCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCerrar.Click
        Try
            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	frmStbCatalogo_Load
    ' Description		:	Cargar el formulario principal de mantenimiento de Catalogos
    ' -----------------------------------------------------------------------------------------
    Private Sub frmStbCatalogo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            'Seteo la apariencia del formulario
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            'Inicializo variables y controles
            InicializarVariables()
            'Cargo objetos
            CargarCatalogos()

            'Caption del formulario
            Me.Text = "Mantenimiento de Catálogos Básicos"

            'Llamo al procedimiento de seguridad para habilitar o deshabilitar las opciones de la barra de herramientas
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	InicializarVariables
    ' Description		:	Permite inicializar las variables ocupadas en el presente
    ' formulario
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            'Inicializo el objeto de tipo Entidad catalogo
            ObjCatalogos = New BOSistema.Win.StbEntCatalogo

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	CargarCatalogos
    ' Description		:	Este metodo me permite cargar los catalogos basicos del sistema
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarCatalogos()
        Try
            'Me traigo los datos de la base de datos
            ObjCatalogos.StbCatalogo.Retrieve("*,'' as ColumnMentira")
            ObjCatalogos.StbCatalogo.OrderBy = "sNombre ASC"
            ObjCatalogos.StbValorCatalogo.Retrieve("*,'' as ColumnMentira")
            ObjCatalogos.StbValorCatalogo.OrderBy = " sCodigoInterno ASC"
            ObjCatalogos.StbCatalogo.FilterLocal(" sNombre <> 'TipoNegocio'")

            'Asigno al source de la tabla hija el source de la relacion con el padre
            ObjCatalogos.StbValorCatalogo.Source = ObjCatalogos.StbValorCatalogo.SourceStbCatalogonStbCatalogoID

            'Inicializo los controles con los objetos
            Me.LstCatalogos.DataSource = ObjCatalogos.StbCatalogo.Source
            Me.GrdValoresCatalogos.DataSource = Nothing
            'Limpio el filtro local de los valores de catalogos
            ObjCatalogos.StbValorCatalogo.FilterLocal("")
            Me.GrdValoresCatalogos.DataSource = ObjCatalogos.StbValorCatalogo.SourceStbCatalogonStbCatalogoID

            Me.LstCatalogos.Caption = "Listado de Catálogos Básicos (" & LstCatalogos.ListCount.ToString & " registros )"
            Me.GrdValoresCatalogos.Caption = "Valores del Catálogo " & ObjCatalogos.StbCatalogo("sNombre") & " ( " & GrdValoresCatalogos.RowCount.ToString & " registros )"

            'Formateo el control list
            Me.LstCatalogos.Splits(0).DisplayColumns("nStbCatalogoID").Visible = False
            Me.LstCatalogos.Splits(0).DisplayColumns("sDescripcion").Visible = False
            Me.LstCatalogos.Splits(0).DisplayColumns("sUsuarioCreacion").Visible = False
            Me.LstCatalogos.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.LstCatalogos.Splits(0).DisplayColumns("sUsuarioModificacion").Visible = False
            Me.LstCatalogos.Splits(0).DisplayColumns("FechaModificacion").Visible = False

            Me.LstCatalogos.Columns("ColumnMentira").Caption = ""
            Me.LstCatalogos.Columns("sDescripcion").Caption = "Descripción"
            Me.LstCatalogos.Columns("sNombre").Caption = "Nombre"
            Me.LstCatalogos.Columns("nActivo").Caption = "Activo"
            Me.LstCatalogos.Columns("nReservado").Caption = "Reservado"

            Me.LstCatalogos.Columns("nActivo").ValueItems.Presentation = C1.Win.C1List.PresentationEnum.CheckBox
            Me.LstCatalogos.Columns("nActivo").ValueItems.Translate = True
            Me.LstCatalogos.Columns("nActivo").ValueItems.Validate = True

            Me.LstCatalogos.Columns("nReservado").ValueItems.Presentation = C1.Win.C1List.PresentationEnum.CheckBox
            Me.LstCatalogos.Columns("nReservado").ValueItems.Translate = True
            Me.LstCatalogos.Columns("nReservado").ValueItems.Validate = True

            Me.LstCatalogos.Splits(0).DisplayColumns("sNombre").Width = 180
            Me.LstCatalogos.Splits(0).DisplayColumns("nActivo").Width = 50
            Me.LstCatalogos.Splits(0).DisplayColumns("nReservado").Width = 70
            Me.LstCatalogos.Splits(0).DisplayColumns("ColumnMentira").Width = 1

            'Formateo el grid
            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("UsuarioCreacion").Visible = False
            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("FechaCreacion").Visible = False
            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("UsuarioModificacion").Visible = False
            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("FechaModificacion").Visible = False
            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("nStbCatalogoID").Visible = False

            Me.GrdValoresCatalogos.Splits(0).DisplayColumns("sDescripcion").Width = 350
            Me.GrdValoresCatalogos.Columns("ColumnMentira").Caption = ""
            Me.GrdValoresCatalogos.Columns("sCodigoInterno").Caption = "Código"
            Me.GrdValoresCatalogos.Columns("sDescripcion").Caption = "Descripción"
            Me.GrdValoresCatalogos.Columns("nActivo").Caption = "Activo"

            If Me.LstCatalogos.ListCount > 0 Then
                Me.LstCatalogos.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	CargarCatalogos
    ' Description		:	Este metodo me permite cargar los catalogos basicos del sistema
    ' -----------------------------------------------------------------------------------------
    Private Sub ReCargarCatalogos()
        Try
            'Me traigo los datos de la base de datos
            ObjCatalogos.StbCatalogo.Retrieve("*,'' as ColumnMentira")
            ObjCatalogos.StbValorCatalogo.Retrieve("*,'' as ColumnMentira")
            ObjCatalogos.StbValorCatalogo.OrderBy = "sCodigoInterno ASC"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	toolAgregar_Click
    ' Description		:	En dependencia de quien tenga el foco asi manejo los procedimientos, si 
    ' el foco lo tiene la lista, agrego un nuevo catalogo, pero si el foco lo tiene el grid, agrego
    ' un nuevo valor de catalogo
    ' -----------------------------------------------------------------------------------------
    Private Sub toolAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregar.Click
        Dim ObjfrmEditCatalogo As frmStbEditCatalogo
        Dim ObjFrmEditValorCatalogo As frmStbEditValorCatalogo

        Try
            If Me.LstCatalogos.ContainsFocus = True Then

                'Llamo al metodo de seguridad para ver el permiso del usuario
                If Seg.HasPermission("AgregarCatalogo") = False Then
                    MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                'Llamo al formulario para agregar un nuevo catalogo
                ObjfrmEditCatalogo = New frmStbEditCatalogo

                ObjfrmEditCatalogo.ModoFrm = "ADD"
                ObjfrmEditCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.NewRow

                ObjfrmEditCatalogo.ShowDialog()

                If ObjfrmEditCatalogo.AccionUsuario = frmStbEditCatalogo.AccionBoton.BotonAceptar Then
                    'Pongo el foco en el grid 
                    ObjCatalogos.StbCatalogo.SetCurrentByID(ObjfrmEditCatalogo.IDCatalogo)
                    Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                    GrdValoresCatalogos.Focus()
                End If

                LstCatalogos.Caption = "Catálogos Básicos (" & LstCatalogos.ListCount.ToString & " registros )"

            ElseIf Me.GrdValoresCatalogos.ContainsFocus = True Then
                If Seg.HasPermission("AgregarValorCatalogo") = False Then
                    MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If
                If ObjCatalogos.StbCatalogo("nReservado") = True Then
                    If Seg.HasPermission("EditarCatalogoReservado") = False Then
                        MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If
                End If

                'Llamo al formulario para agregar un nuevo valor de catalogo
                ObjFrmEditValorCatalogo = New frmStbEditValorCatalogo

                ObjFrmEditValorCatalogo.ModoFrm = "ADD"
                ObjFrmEditValorCatalogo.ObjValorCatalogoRow = ObjCatalogos.StbValorCatalogo.NewRow
                ObjFrmEditValorCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.Current

                ObjFrmEditValorCatalogo.ShowDialog()

                If ObjFrmEditValorCatalogo.AccionUsuario = frmStbEditValorCatalogo.AccionBoton.BotonAceptar Then
                    ObjCatalogos.StbCatalogo.SetCurrentByID(ObjFrmEditValorCatalogo.IDCatalogo)
                    ObjCatalogos.StbValorCatalogo.SetCurrentByID(ObjFrmEditValorCatalogo.IDValorCatalogo)
                    Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                End If

                'Pongo el foco en el grid 
                GrdValoresCatalogos.Focus()

                GrdValoresCatalogos.Caption = "Valores del Catálogo " & ObjCatalogos.StbCatalogo("sNombre") & " ( " & GrdValoresCatalogos.RowCount.ToString & " registros)"
            End If

            '*********************AQUI CAMBIOS
            If Seg.HasPermission("AgregarReferenciaSocia") = False Then
                MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Llamo al formulario para agregar un nuevo catalogo
            ObjfrmEditCatalogo = New frmStbEditCatalogo

            ObjfrmEditCatalogo.ModoFrm = "ADD"
            ObjfrmEditCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.NewRow

            ObjfrmEditCatalogo.ShowDialog()

            If ObjfrmEditCatalogo.AccionUsuario = frmStbEditCatalogo.AccionBoton.BotonAceptar Then
                'Pongo el foco en el grid 
                ObjCatalogos.StbCatalogo.SetCurrentByID(ObjfrmEditCatalogo.IDCatalogo)
                Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                GrdValoresCatalogos.Focus()
            End If

            LstCatalogos.Caption = "Catálogos Básicos (" & LstCatalogos.ListCount.ToString

            '*******************************

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjfrmEditCatalogo = Nothing
            ObjFrmEditValorCatalogo = Nothing
        End Try

    End Sub

   

    Private Sub LstCatalogos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCatalogos.DoubleClick
        Dim ObjfrmEditCatalogo As frmStbEditCatalogo
        Try
            If Seg.HasPermission("EditarCatalogo") = True Then
                'Si hay registros de catalogos puedo modificar el actual
                'Si el catalogo actual tiene el valor reservado a True

                If LstCatalogos.ListCount > 0 Then

                    If ObjCatalogos.StbCatalogo("nReservado") = True Then
                        If Seg.HasPermission("EditarCatalogoReservado") = False Then
                            MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If

                    ObjfrmEditCatalogo = New frmStbEditCatalogo

                    'Establezco el modo del formulario y mando la fila que voy a modificar
                    ObjfrmEditCatalogo.ModoFrm = "UPD"
                    ObjfrmEditCatalogo.IDCatalogo = ObjCatalogos.StbCatalogo("nStbCatalogoID")
                    ObjfrmEditCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.Current

                    'Mando los valores de Catalogos que tiene este catalogo
                    ObjfrmEditCatalogo.ObjValoresCatalogo = ObjCatalogos.StbValorCatalogo

                    ObjfrmEditCatalogo.ShowDialog()
                    If ObjfrmEditCatalogo.AccionUsuario = frmStbEditCatalogo.AccionBoton.BotonAceptar Then
                        ObjCatalogos.StbCatalogo.SetCurrentByID(ObjfrmEditCatalogo.IDCatalogo)
                        Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmEditCatalogo = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	LstCatalogos_RowChange
    ' Description		:	Permite actualizar el caption del grid de valores de catalogos en 
    ' dependencia del catalogo seleccionado
    ' -----------------------------------------------------------------------------------------
    Private Sub LstCatalogos_RowChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstCatalogos.RowChange
        Try
            Me.GrdValoresCatalogos.Caption = "Valores del Catálogo " & ObjCatalogos.StbCatalogo("sNombre") & " ( " & GrdValoresCatalogos.RowCount.ToString & " registros)"
            ObjCatalogos.StbValorCatalogo.OrderBy = "sCodigoInterno Asc"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub GrdValoresCatalogos_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GrdValoresCatalogos.DoubleClick
        'Llamo al formulario para agregar un nuevo valor de catalogo
        Dim ObjFrmEditValorCatalogo As frmStbEditValorCatalogo

        Try
            If Seg.HasPermission("EditarValorCatalogo") = True Then
                If Me.GrdValoresCatalogos.RowCount > 0 Then

                    If ObjCatalogos.StbCatalogo("nReservado") = True Then
                        If Seg.HasPermission("EditarCatalogoReservado") = False Then
                            MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If

                    ObjFrmEditValorCatalogo = New frmStbEditValorCatalogo

                    ObjFrmEditValorCatalogo.ModoFrm = "UPD"
                    ObjFrmEditValorCatalogo.ObjValorCatalogoRow = ObjCatalogos.StbValorCatalogo.Current
                    ObjFrmEditValorCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.Current

                    ObjFrmEditValorCatalogo.ShowDialog()
                    If ObjFrmEditValorCatalogo.AccionUsuario = frmStbEditValorCatalogo.AccionBoton.BotonAceptar Then
                        ObjCatalogos.StbCatalogo.SetCurrentByID(ObjFrmEditValorCatalogo.IDCatalogo)
                        ObjCatalogos.StbValorCatalogo.SetCurrentByID(ObjFrmEditValorCatalogo.IDValorCatalogo)
                        Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmEditValorCatalogo = Nothing
        End Try

    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	GrdValoresCatalogos_Filter
    ' Description		:	Filtra sobre el grid de valores de catalogos
    ' -----------------------------------------------------------------------------------------
    Private Sub GrdValoresCatalogos_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles GrdValoresCatalogos.Filter
        Try
            ObjCatalogos.StbValorCatalogo.FilterLocal(e.Condition)
            'ObjCatalogos.StbValorCatalogo.Sourcestbcatalogo.Filter = e.Condition
            GrdValoresCatalogos.Caption = "Valores del Catálogo " & ObjCatalogos.StbCatalogo("sNombre") & " ( " & GrdValoresCatalogos.RowCount.ToString & " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	toolModificar_Click
    ' Description		:	En dependencia de quien tenga el foco asi manejo los procedimientos, si 
    ' el foco lo tiene la lista, agrego un nuevo catalogo, pero si el foco lo tiene el grid, agrego
    ' un nuevo valor de catalogo
    ' -----------------------------------------------------------------------------------------
    Private Sub toolModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModificar.Click
        Try
            If LstCatalogos.ContainsFocus = True Then
                'Llamo al formulario para agregar un nuevo catalogo
                Dim ObjfrmEditCatalogo As frmStbEditCatalogo

                'Si hay registros de catalogos puedo modificar el actual
                If LstCatalogos.ListCount > 0 Then

                    'Pregunto para saber si el usuario tiene permisos
                    If Seg.HasPermission("EditarCatalogo") = False Then
                        MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If

                    'Si el catalogo actual tiene el valor reservado a True
                    If ObjCatalogos.StbCatalogo("nReservado") = True Then
                        If Seg.HasPermission("EditarCatalogoReservado") = False Then
                            MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If

                    ObjfrmEditCatalogo = New frmStbEditCatalogo

                    'Establezco el modo del formulario y mando la fila que voy a modificar
                    ObjfrmEditCatalogo.ModoFrm = "UPD"
                    ObjfrmEditCatalogo.IDCatalogo = ObjCatalogos.StbCatalogo("nStbCatalogoID")
                    ObjfrmEditCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.Current

                    'Mando los valores de Catalogos que tiene este catalogo
                    ObjfrmEditCatalogo.ObjValoresCatalogo = ObjCatalogos.StbValorCatalogo

                    ObjfrmEditCatalogo.ShowDialog()
                    If ObjfrmEditCatalogo.AccionUsuario = frmStbEditCatalogo.AccionBoton.BotonAceptar Then
                        ObjCatalogos.StbCatalogo.SetCurrentByID(ObjfrmEditCatalogo.IDCatalogo)
                        Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                    End If
                End If

            ElseIf GrdValoresCatalogos.ContainsFocus = True Then
                'Llamo al formulario para agregar un nuevo valor de catalogo
                Dim ObjFrmEditValorCatalogo As frmStbEditValorCatalogo

                'Pregunto para saber si el usuario tiene permisos
                If Seg.HasPermission("EditarValorCatalogo") = False Then
                    MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                If GrdValoresCatalogos.RowCount > 0 Then
                    'Si el catalogo actual tiene el valor reservado a True
                    If ObjCatalogos.StbCatalogo("nReservado") = True Then
                        If Seg.HasPermission("EditarCatalogoReservado") = False Then
                            MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If

                    ObjFrmEditValorCatalogo = New frmStbEditValorCatalogo

                    ObjFrmEditValorCatalogo.ModoFrm = "UPD"
                    ObjFrmEditValorCatalogo.ObjValorCatalogoRow = ObjCatalogos.StbValorCatalogo.Current
                    ObjFrmEditValorCatalogo.ObjCatalogoRow = ObjCatalogos.StbCatalogo.Current

                    ObjFrmEditValorCatalogo.ShowDialog()
                    If ObjFrmEditValorCatalogo.AccionUsuario = frmStbEditValorCatalogo.AccionBoton.BotonAceptar Then
                        ObjCatalogos.StbCatalogo.SetCurrentByID(ObjFrmEditValorCatalogo.IDCatalogo)
                        ObjCatalogos.StbValorCatalogo.SetCurrentByID(ObjFrmEditValorCatalogo.IDValorCatalogo)
                        Me.LstCatalogos.SelectedIndex = ObjCatalogos.StbCatalogo.Source.Position
                    End If

                End If

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImprimir.Click
        Try
            LlamaImprimirCatalogoValor()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    '' -----------------------------------------------------------------------------------------
    '' Author		    :	
    '' Date			    :	21/07/2006
    '' Procedure name	:   toolEliminar_Click	    
    '' Description		:	Este procedimiento permite desactivar un Catalogo y sus valores de catalogo
    '' o un valor de catalogo especifico y si es el ultimo valor de catalogo activo para un catalogo
    '' inactiva a su papa catalogo
    '' -----------------------------------------------------------------------------------------
    'Private Sub toolEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEliminar.Click
    '    Try
    '        'Si el foco lo tiene la lista inactivo el registro de catalogo si lo hay y sus hijos
    '        If LstCatalogos.ContainsFocus = True Then

    '            If LstCatalogos.ListCount > 0 Then

    '                'Pregunto para saber si el usuario tiene permisos
    '                If Seg.HasPermission("InactivarCatalogo") = False Then
    '                    MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
    '                    Exit Sub
    '                End If

    '                'Si el catalogo actual tiene el valor reservado a True
    '                If ObjCatalogos.StbCatalogo("Reservado") = True Then
    '                    If Seg.HasPermission("EditarCatalogoReservado") = False Then
    '                        MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
    '                        Exit Sub
    '                    End If
    '                End If

    '                If MsgBox("¿Desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
    '                    EliminarCatalogo()
    '                End If

    '            End If

    '            'Si el foco lo tiene el grid inactivo el registro de valor catalogo y si este es el
    '            'ultimo de su papa inactivo a su papa
    '        ElseIf GrdValoresCatalogos.ContainsFocus = True Then
    '            If GrdValoresCatalogos.RowCount > 0 Then

    '                'Pregunto para saber si el usuario tiene permisos
    '                If Seg.HasPermission("InactivarValorCatalogo") = False Then
    '                    MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
    '                    Exit Sub
    '                End If

    '                'Si el catalogo actual tiene el valor reservado a True
    '                If ObjCatalogos.StbCatalogo("Reservado") = True Then
    '                    If Seg.HasPermission("EditarCatalogoReservado") = False Then
    '                        MsgBox("Acción no permitida para su rol.", MsgBoxStyle.Critical, NombreSistema)
    '                        Exit Sub
    '                    End If
    '                End If

    '                If Me.GrdValoresCatalogos.RowCount > 1 Then
    '                    If MsgBox("¿Desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
    '                        EliminarValorCatalogo()
    '                    End If
    '                Else
    '                    If MsgBox(" Al eliminar este Valor de Catálogo se eliminará el Catálogo correspondiente " & _
    '                    Chr(13) & "¿Desea eliminarlo de todas formas?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
    '                        EliminarValorCatalogo(True)
    '                    End If
    '                End If
    '            End If
    '        End If
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:   toolEliminar_Click	    
    ' Description		:	Este procedimiento permite desactivar un Catalogo y sus valores de catalogo
    ' o un valor de catalogo especifico y si es el ultimo valor de catalogo activo para un catalogo
    ' inactiva a su papa catalogo
    ' -----------------------------------------------------------------------------------------
    Private Sub toolEliminar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEliminar.Click
        Try
            'Si el foco lo tiene la lista inactivo el registro de catalogo si lo hay y sus hijos
            If LstCatalogos.ContainsFocus = True Then

                If LstCatalogos.ListCount > 0 Then

                    'Pregunto para saber si el usuario tiene permisos
                    If Seg.HasPermission("InactivarCatalogo") = False Then
                        MsgBox("Acción no permitida para su rol!", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If

                    'Si el catalogo actual tiene el valor reservado a True
                    If ObjCatalogos.StbCatalogo("nReservado") = True Then
                        If Seg.HasPermission("EditarCatalogoReservado") = False Then
                            MsgBox("Acción no permitida para su rol!", MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If

                    If ObjCatalogos.StbCatalogo("nActivo") = True Then
                        If MsgBox("¿Desea inactivar el Catálogo seleccionado?" & Chr(13) & _
                        "Recuerde que la inactivación de un Catálogo básico puede ocasionar un funcionamiento indebido en alguna parte de la aplicación," & Chr(13) & _
                        " a demás todos sus valores serán inactivados.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                            InactivarCatalogo()
                        End If
                    End If
                End If

                'Si el foco lo tiene el grid inactivo el registro de valor catalogo y si este es el
                'ultimo de su papa inactivo a su papa
            ElseIf GrdValoresCatalogos.ContainsFocus = True Then
                If GrdValoresCatalogos.RowCount > 0 Then

                    'Pregunto para saber si el usuario tiene permisos
                    If Seg.HasPermission("InactivarValorCatalogo") = False Then
                        MsgBox("Acción no permitida para su rol!", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If

                    'Si el catalogo actual tiene el valor reservado a True
                    If ObjCatalogos.StbCatalogo("nReservado") = True Then
                        If Seg.HasPermission("EditarCatalogoReservado") = False Then
                            MsgBox("Acción no permitida para su rol!", MsgBoxStyle.Critical, NombreSistema)
                            Exit Sub
                        End If
                    End If

                    If ObjCatalogos.StbValorCatalogo("nActivo") = True Then
                        If MsgBox("¿Desea inactivar el valor de Catálogo seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                            InactivarValorCatalogo()
                        End If
                    End If
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	EliminarCatalogo
    ' Description		:	Elimina un catalogo y sus hijos si los tiene
    ' -----------------------------------------------------------------------------------------
    Private Sub EliminarCatalogo()
        Dim xComando As BOSistema.Win.XComando
        Dim StrSql As String

        Try
            xComando = New BOSistema.Win.XComando

            StrSql = "Exec spSprVerificaCatalogo " & _
                     "   @ObjCatalogoID =   " & ObjCatalogos.StbCatalogo("nStbCatalogoID")

            If xComando.ExecuteScalar(StrSql) = -1 Then
                StrSql = " Exec spSprEliminarCatalogo " & _
                         "   @ObjCatalogoID =   " & ObjCatalogos.StbCatalogo("nStbCatalogoID")

                If xComando.ExecuteScalar(StrSql) = -1 Then
                    ReCargarCatalogos()
                Else
                    MsgBox("El registro no se pudo eliminar por que tiene relaciones con otras tablas.", MsgBoxStyle.Critical, NombreSistema)
                End If

            Else
                MsgBox("El registro no se pudo eliminar por que tiene relaciones con otras tablas.", MsgBoxStyle.Critical, NombreSistema)
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar por que tiene relaciones con otras tablas.", MsgBoxStyle.Critical, NombreSistema)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	EliminarValorCatalogo
    ' Description		:	Elimina un valor de catalogo
    ' -----------------------------------------------------------------------------------------
    Private Sub EliminarValorCatalogo(Optional ByVal EliminarPapa As Boolean = False)
        Dim xComando As BOSistema.Win.XComando
        Dim StrSql As String

        Try
            xComando = New BOSistema.Win.XComando

            StrSql = "Exec spSprVerificaValorCatalogo " & _
                     "   @ObjValorCatalogoID =   " & ObjCatalogos.StbValorCatalogo("nStbValorCatalogoID")

            If xComando.ExecuteScalar(StrSql) = -1 Then
                If EliminarPapa = True Then
                    StrSql = " Exec spSprEliminarCatalogo " & _
                        "   @ObjCatalogoID =   " & ObjCatalogos.StbCatalogo("nStbCatalogoID")

                    If xComando.ExecuteScalar(StrSql) = -1 Then
                        ReCargarCatalogos()
                    Else
                        MsgBox("El registro no se pudo eliminar por que tiene relaciones con otras tablas.", MsgBoxStyle.Critical, NombreSistema)
                    End If
                Else
                    StrSql = "Delete StbValorCatalogo Where nStbValorCatalogoID=" & ObjCatalogos.StbValorCatalogo("nStbValorCatalogoID")
                    xComando.Execute(StrSql)
                    ReCargarCatalogos()
                End If
            Else
                MsgBox("El registro no se pudo eliminar por que tiene relaciones con otras tablas.", MsgBoxStyle.Critical, NombreSistema)
            End If
            
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar por que tiene relaciones con otras tablas.", MsgBoxStyle.Critical, NombreSistema)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	InactivarCatalogo
    ' Description		:	Inactiva un catalogo y sus hijos si los tiene
    ' -----------------------------------------------------------------------------------------
    Private Sub InactivarCatalogo()
        Try
            Dim i As Integer

            'Inactivo al papa
            ObjCatalogos.StbCatalogo.Current.nActivo = False

            'Inactivo a sus hijos si los tiene
            If GrdValoresCatalogos.RowCount > 0 Then
                For i = 0 To GrdValoresCatalogos.RowCount - 1
                    ObjCatalogos.StbValorCatalogo.Itemn(i).nActivo = False
                Next
            End If

            'Actualizo los datos
            ObjCatalogos.StbCatalogo.Update()
            ObjCatalogos.StbValorCatalogo.Update()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/07/2006
    ' Procedure name	:	InactivarCatalogo
    ' Description		:	Inactiva un valor de catalogo y si este es el ultimo activo 
    ' se inactiva su papa
    ' -----------------------------------------------------------------------------------------
    Private Sub InactivarValorCatalogo()
        Try
            Dim i As Integer, Cont As Integer = 0

            For i = 0 To GrdValoresCatalogos.RowCount - 1
                If ObjCatalogos.StbValorCatalogo.Itemn(i).nActivo = True Then
                    Cont = Cont + 1
                End If
            Next

            If Cont = 1 Then
                If MsgBox("Al inactivar este registro se inactivará su Catálogo " & Chr(13) & _
                "¿Desea inactivarlo de todas formas?" & Chr(13) & _
                "Recuerde que la inactivación de un Catálogo básico puede ocasionar un funcionamiento indebido en alguna parte de la aplicación.", MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                    ObjCatalogos.StbValorCatalogo.Current.nActivo = False
                    ObjCatalogos.StbCatalogo.Current.nActivo = False
                    ObjCatalogos.StbValorCatalogo.Update()
                    ObjCatalogos.StbCatalogo.Update()
                End If
            Else
                ObjCatalogos.StbValorCatalogo.Current.nActivo = False
                ObjCatalogos.StbValorCatalogo.Update()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolModificar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles toolModificar.MouseMove
        If LstCatalogos.ContainsFocus = True Then
            toolModificar.ToolTipText = "Modificar Catálogo"
        ElseIf GrdValoresCatalogos.ContainsFocus = True Then
            toolModificar.ToolTipText = "Modificar Valor de Catálogo"
        End If
    End Sub

    Private Sub toolAgregar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles toolAgregar.MouseMove
        If LstCatalogos.ContainsFocus = True Then
            toolAgregar.ToolTipText = "Agregar Catálogo"
        ElseIf GrdValoresCatalogos.ContainsFocus = True Then
            toolAgregar.ToolTipText = "Agregar Valor de Catálogo"
        End If
    End Sub

    Private Sub toolEliminar_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles toolEliminar.MouseMove
        If LstCatalogos.ContainsFocus = True Then
            toolEliminar.ToolTipText = "Inactivar Catálogo"
        ElseIf GrdValoresCatalogos.ContainsFocus = True Then
            toolEliminar.ToolTipText = "Inactivar Valor de Catálogo"
        End If
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	31 de Diciembre del 2006
    ' Procedure name	:	LlamaImprimirCatalogoValor
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de catalogos
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimirCatalogoValor()

        'Declaracion de Variables 
        Dim ObjFrmParamCat As New frmStbParamCatalogoValor

        Try
            'ObjFrmParamCat = New frmStbParamCatalogoValor
            ObjFrmParamCat.NombreReporteCat = frmStbParamCatalogoValor.EnumReportesCatalogoValor.StbCatCatalogoValor
            ObjFrmParamCat.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmParamCat.Close()
            ObjFrmParamCat = Nothing
        End Try
    End Sub
    Private Sub toolRefrescar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolRefrescar.Click
        Try
            CargarCatalogos()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	11/10/2006
    ' Procedure name		   	:	Seguridad
    ' Description			   	:	Este procedimiento se encarga de activar o desactivar las opciones
    ' del formulario en dependencia de los permisos del usuario que inicio sesion
    ' -----------------------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            If Seg.HasPermission("AgregarCatalogo") = False And Seg.HasPermission("AgregarValorCatalogo") = False Then  'Habilita
                Me.toolCatalogos.Items("ToolAgregar").Enabled = False
            Else  'Deshabilita
                Me.toolCatalogos.Items("ToolAgregar").Enabled = True
            End If

            If Seg.HasPermission("EditarCatalogo") = False And Seg.HasPermission("EditarValorCatalogo") = False Then  'Habilita
                Me.toolCatalogos.Items("ToolModificar").Enabled = False
            Else  'Deshabilita
                Me.toolCatalogos.Items("ToolModificar").Enabled = True
            End If

            If Seg.HasPermission("InactivarCatalogo") = False And Seg.HasPermission("InactivarValorCatalogo") = False Then  'Habilita
                Me.toolCatalogos.Items("ToolEliminar").Enabled = False
            Else  'Deshabilita
                Me.toolCatalogos.Items("ToolEliminar").Enabled = True
            End If

            If Seg.HasPermission("ImprimirCatalogo") Then  'Habilita
                Me.toolCatalogos.Items("ToolImprimir").Enabled = True
            Else  'Deshabilita
                Me.toolCatalogos.Items("ToolImprimir").Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ToolAyuda_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ToolAyuda.Click
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LstCatalogos_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LstCatalogos.Click

    End Sub
End Class