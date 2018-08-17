' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbMercado.vb
' Descripción:          Este formulario carga los principales datos del
'                       catálogo de mercados.
'-------------------------------------------------------------------------
Public Class frmStbMercado
    '- Declaración de Variables 
    Dim XdtMercado As BOSistema.Win.XDataSet.xDataTable

    Private _tipo As Integer

    Public Property Tipo() As Integer
        Get
            Return _tipo
        End Get
        Set(ByVal value As Integer)
            _tipo = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbMercado_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbMercado_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtMercado.Close()
            XdtMercado = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbMercado_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Mercados en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmStbMercado_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarMercado()
            FormatoMercado()
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
    ' Procedure Name:       CargarMercado
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de los barrios en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarMercado()
        Try
            Dim Strsql As String = ""


            Strsql = " Select a.nStbMercadoID,a.sDepartamento,a.sMunicipio,a.sDistrito,a.sBarrio,a.sMercado,a.nPertenecePrograma,a.nActivo " & _
                     " From vwStbMercado a " & _
                     String.Format(" Where nCooperativa = {0} ", Tipo) & _
                     " Order by a.sDepartamento,a.sMunicipio,a.sDistrito,a.sBarrio,a.sMercado"

            XdtMercado.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdMercado.DataSource = XdtMercado.Source

            Me.grdMercado.Caption = String.Format(" Listado de {0} (" + Me.grdMercado.RowCount.ToString + " registros)", IIf(Tipo = 1, "Cooperativas", "Mercados"))

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       FormatoMercado
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Barrios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoMercado()
        Try
            'Configuracion del Grid Barrio
            Me.grdMercado.Splits(0).DisplayColumns("nStbMercadoID").Visible = False

            Me.grdMercado.Splits(0).DisplayColumns("sDepartamento").Width = 120
            Me.grdMercado.Splits(0).DisplayColumns("sMunicipio").Width = 120
            Me.grdMercado.Splits(0).DisplayColumns("sDistrito").Width = 120
            Me.grdMercado.Splits(0).DisplayColumns("sBarrio").Width = 130
            Me.grdMercado.Splits(0).DisplayColumns("sMercado").Width = 130
            Me.grdMercado.Splits(0).DisplayColumns("nActivo").Width = 60
            Me.grdMercado.Splits(0).DisplayColumns("nPertenecePrograma").Width = 110

            Me.grdMercado.Columns("sDepartamento").Caption = "Departamento"
            Me.grdMercado.Columns("sMunicipio").Caption = "Municipio"
            Me.grdMercado.Columns("sDistrito").Caption = "Distrito"
            Me.grdMercado.Columns("sBarrio").Caption = "Barrio"
            Me.grdMercado.Columns("sMercado").Caption = "Mercado"
            Me.grdMercado.Columns("nActivo").Caption = "Activo"
            Me.grdMercado.Columns("nPertenecePrograma").Caption = "Incluido en Programa"

            Me.grdMercado.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdMercado.Splits(0).DisplayColumns("nPertenecePrograma").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Columns("nPertenecePrograma").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdMercado.Splits(0).DisplayColumns("sDepartamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Splits(0).DisplayColumns("sMunicipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Splits(0).DisplayColumns("sBarrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Splits(0).DisplayColumns("sMercado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMercado.Splits(0).DisplayColumns("nPertenecePrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

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
            XdtMercado = New BOSistema.Win.XDataSet.xDataTable

            Me.Text = IIf(Tipo = 1, "Cooperativa", "Mercado")

            'Limpiar los Grids, estructura y Datos
            Me.grdMercado.ClearFields()
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
    Private Sub tbBarrio_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMercado.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarMercado()
            Case "toolModificar"
                LlamaModificarMercado(Tipo)
            Case "toolEliminar"
                LlamaEliminarMercado()
            Case "toolRefrescar"
                InicializaVariables()
                CargarMercado()
                FormatoMercado()
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
    ' Procedure Name:       LlamaAgregarBarrio
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditBarrio para Agregar un nuevo Mercado.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarMercado()
        Dim ObjFrmStbEditMercado As New frmStbEditMercado
        Try
            ObjFrmStbEditMercado.ModoFrm = "ADD"
            'Establecemos como va a comportarse el formulario 
            ObjFrmStbEditMercado.TipoObjeto = IIf(Me.Tipo = 0, frmStbEditMercado.eTipoObjeto.Mercado, frmStbEditMercado.eTipoObjeto.Cooperativa)
            ObjFrmStbEditMercado.ShowDialog()

            If ObjFrmStbEditMercado.intStbMercadoID <> 0 Then
                CargarMercado()
                XdtMercado.SetCurrentByID("nStbMercadoID", ObjFrmStbEditMercado.intStbMercadoID)
                Me.grdMercado.Row = XdtMercado.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditMercado.Close()
            ObjFrmStbEditMercado = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaModificarMercado
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmStbEditMercado para Modificar un Mercado existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarMercado(Optional ByVal _tipo As Int16 = 0)
        Dim ObjFrmStbEditMercado As New frmStbEditMercado
        Try
            If Me.grdMercado.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbEditMercado.ModoFrm = "UPD"
            ObjFrmStbEditMercado.TipoObjeto = _tipo
            ObjFrmStbEditMercado.intStbMercadoID = XdtMercado.ValueField("nStbMercadoID")
            ObjFrmStbEditMercado.ShowDialog()

            CargarMercado()
            XdtMercado.SetCurrentByID("nStbMercadoID", ObjFrmStbEditMercado.intStbMercadoID)
            Me.grdMercado.Row = XdtMercado.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditMercado.Close()
            ObjFrmStbEditMercado = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaEliminarBarrio
    ' Descripción:          Este procedimiento permite Eliminar un registro
    '                       de un Mercado existente. Realiza una Eliminación
    '                       física del registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarMercado()
        Dim XdtMercadoEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdMercado.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtMercadoEliminar.ExecuteSqlNotTable("Delete From StbMercado where nStbMercadoID=" & XdtMercado.ValueField("nStbMercadoID"))
                CargarMercado()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMercado.Caption = String.Format("Listado de {0} (" + Me.grdMercado.RowCount.ToString + " registros)", IIf(Tipo = 1, "Cooperativas", "Mercados"))
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtMercadoEliminar.Close()
            XdtMercadoEliminar = Nothing
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


            If Me.grdMercado.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbParametroBarrio.TipoObjeto = IIf(Me.Tipo = frmStbEditMercado.eTipoObjeto.Mercado, frmStbEditMercado.eTipoObjeto.Mercado, frmStbEditMercado.eTipoObjeto.Cooperativa)

            ObjFrmStbParametroBarrio.NomRep = 2
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
    Private Sub grdBarrio_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdMercado.Filter
        Try
            XdtMercado.FilterLocal(e.Condition)
            Me.grdMercado.Caption = String.Format(" Listado de Mercados (" + Me.grdMercado.RowCount.ToString + " registros)", IIf(Tipo = 1, "Cooperativas", "Mercados"))
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
            If Seg.HasPermission("AgregarMercado") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar
            If Seg.HasPermission("ModificarMercado") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarMercado") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirMercado") Then
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
    ' Procedure Name:       grdMercado_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Barrio existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdBarrio_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMercado.DoubleClick
        Try
            If Me.grdMercado.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarMercado") Then
                LlamaModificarMercado(Tipo)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFicha_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdMercado.Error
        Control_Error(e.Exception)
    End Sub
End Class