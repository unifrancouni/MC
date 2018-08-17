' ------------------------------------------------------------------------
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Descripción:          Este formulario carga los principales datos de las
'                       Metas.
'-------------------------------------------------------------------------
Public Class frmSccMetasPrograma
    '- Declaración de Variables 
    Dim XdtMetas As BOSistema.Win.XDataSet.xDataTable
    Dim strColorFrm As String
    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbBarrio_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSccMetasPrograma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtMetas.Close()
            XdtMetas = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       frmSccMetasPrograma_Load
    ' Descripción:          Evento Load del formulario donde inicializa variables
    '                       y carga listado de Metas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSccMetasPrograma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarMetas()
            FormatoMetas()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       CargarMeta
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de las metas en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarMetas()
        Try
            Dim Strsql As String = ""

            Strsql = "SELECT     nSccMetasProgramaID, nStbDepartamentoID, nStbMunicipioID, " & _
                     "  SDepartamento,  SMunicipio,  nStbDistritoID, " & _
                     " SDistrito, CodDistrito,CodigoPlazo,DescripcionPlazo,AnioMeta, dFechaInicio, dFechaFin, nCantidadNuevos,nMontoNuevos,nCantidadRecurrentes,nMontoRecurrentes  From vwSccMetasPrograma " & _
                     " Order by sDepartamento,sMunicipio,sDistrito,dFechaInicio"

            XdtMetas.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdMetas.DataSource = XdtMetas.Source

            Me.grdMetas.Caption = " Listado de Metas (" + Me.grdMetas.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    
    Private Sub FormatoMetas()
        Try
            'Configuracion del Grid Metas
            Me.grdMetas.Splits(0).DisplayColumns("nSccMetasProgramaID").Visible = False
            Me.grdMetas.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdMetas.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdMetas.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.grdMetas.Splits(0).DisplayColumns("CodigoPlazo").Visible = False
            Me.grdMetas.Splits(0).DisplayColumns("CodDistrito").Visible = False

            Me.grdMetas.Splits(0).DisplayColumns("sDepartamento").Width = 80
            Me.grdMetas.Splits(0).DisplayColumns("sMunicipio").Width = 70
            Me.grdMetas.Splits(0).DisplayColumns("sDistrito").Width = 70
            Me.grdMetas.Splits(0).DisplayColumns("AnioMeta").Width = 40
            Me.grdMetas.Splits(0).DisplayColumns("DescripcionPlazo").Width = 70


            Me.grdMetas.Splits(0).DisplayColumns("nCantidadNuevos").Width = 80
            Me.grdMetas.Splits(0).DisplayColumns("nMontoNuevos").Width = 80
            Me.grdMetas.Splits(0).DisplayColumns("nCantidadRecurrentes").Width = 80
            Me.grdMetas.Splits(0).DisplayColumns("nMontoRecurrentes").Width = 80

            Me.grdMetas.Columns("sDepartamento").Caption = "Departamento"
            Me.grdMetas.Columns("sMunicipio").Caption = "Municipio"
            Me.grdMetas.Columns("sDistrito").Caption = "Distrito"

            Me.grdMetas.Columns("DescripcionPlazo").Caption = "Plazo"
            Me.grdMetas.Columns("AnioMeta").Caption = "Año"
            Me.grdMetas.Columns("dFechaInicio").Caption = "Fecha Inicial"
            Me.grdMetas.Columns("dFechaFin").Caption = "Fecha Final"

            Me.grdMetas.Columns("nCantidadNuevos").Caption = "Nuevos"
            Me.grdMetas.Columns("nCantidadNuevos").NumberFormat = "#,##0"

            Me.grdMetas.Columns("nMontoNuevos").Caption = "Monto C$"
            Me.grdMetas.Columns("nMontoNuevos").NumberFormat = "#,##0.00"

            Me.grdMetas.Columns("nCantidadRecurrentes").Caption = "Recurrentes"
            Me.grdMetas.Columns("nCantidadRecurrentes").NumberFormat = "#,##0"

            Me.grdMetas.Columns("nMontoRecurrentes").Caption = "Monto C$"
            Me.grdMetas.Columns("nMontoRecurrentes").NumberFormat = "#,##0.00"


            Me.grdMetas.Splits(0).DisplayColumns("sDepartamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("sMunicipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("sDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("DescripcionPlazo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("dFechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("dFechaFin").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdMetas.Splits(0).DisplayColumns("nMontoNuevos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("nCantidadNuevos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdMetas.Splits(0).DisplayColumns("nMontoRecurrentes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("nCantidadRecurrentes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            Me.grdMetas.Splits(0).DisplayColumns("AnioMeta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdMetas.Splits(0).DisplayColumns("dFechaInicio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("dFechaFin").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdMetas.Splits(0).DisplayColumns("AnioMeta").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


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
            XdtMetas = New BOSistema.Win.XDataSet.xDataTable

            Me.Text = "Metas"

            'Limpiar los Grids, estructura y Datos
            Me.grdMetas.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       tbMetas_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbMetas.
    '-------------------------------------------------------------------------
    Private Sub tbMetas_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbMetas.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarMeta()
            Case "toolModificar"
                LlamaModificarMeta()
            Case "toolEliminar"
                LlamaEliminarMeta()
            Case "toolRefrescar"
                InicializaVariables()
                CargarMetas()
                FormatoMetas()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       LlamaAgregarMeta
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditMetasPrograma para Agregar una nueva meta.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarMeta()
        Dim ObjfrmSccEditMetasPrograma As New frmSccEditMetasPrograma
        Try
            ObjfrmSccEditMetasPrograma.ModoFrm = "ADD"
            ObjfrmSccEditMetasPrograma.strColor = "Verde"
            ObjfrmSccEditMetasPrograma.ShowDialog()

            If ObjfrmSccEditMetasPrograma.intStbMetaID <> 0 Then
                CargarMetas()
                XdtMetas.SetCurrentByID("nSccMetasProgramaID", ObjfrmSccEditMetasPrograma.intStbMetaID)
                Me.grdMetas.Row = XdtMetas.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSccEditMetasPrograma.Close()
            ObjfrmSccEditMetasPrograma = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       LlamaModificarMeta
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSccEditMetasPrograma para Modificar una meta  existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarMeta()
        Dim ObjFrmStbEditMetasPrograma As New frmSccEditMetasPrograma
        Try
            If Me.grdMetas.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbEditMetasPrograma.ModoFrm = "UPD"
            ObjFrmStbEditMetasPrograma.intStbMetaID = XdtMetas.ValueField("nSccMetasProgramaID")
            ObjFrmStbEditMetasPrograma.strColor = "Verde"
            ObjFrmStbEditMetasPrograma.ShowDialog()

            CargarMetas()
            XdtMetas.SetCurrentByID("nSccMetasProgramaID", ObjFrmStbEditMetasPrograma.intStbMetaID)
            Me.grdMetas.Row = XdtMetas.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditMetasPrograma.Close()
            ObjFrmStbEditMetasPrograma = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       LlamaEliminarMeta
    ' Descripción:          Este procedimiento permite Eliminar un registro
    '                       de una Meta existente. Realiza una Eliminación
    '                       física del registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarMeta()
        Dim XdtMetaEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdMetas.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtMetaEliminar.ExecuteSqlNotTable("Delete From SccMetasPrograma where nSccMetasProgramaID=" & XdtMetas.ValueField("nSccMetasProgramaID"))
                CargarMetas()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdMetas.Caption = "Listado de Metas (" + Me.grdMetas.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtMetaEliminar.Close()
            XdtMetaEliminar = Nothing
        End Try

    End Sub
    ' ------------------------------------------------------------------------
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
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El listado
    '                       de metas según los parámetros seleccionados. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmStbParametroMetas As New frmSccParametrosMetasPrograma
        Try
            Dim strSQL As String = ""

            If Me.grdMetas.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbParametroMetas.NomRep = 1
            ObjFrmStbParametroMetas.strColor = "Verde"
            ObjFrmStbParametroMetas.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbParametroMetas.Close()
            ObjFrmStbParametroMetas = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       grdMetas_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdMetas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdMetas.Filter
        Try
            XdtMetas.FilterLocal(e.Condition)
            Me.grdMetas.Caption = " Listado de Metas (" + Me.grdMetas.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarMeta") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar
            If Seg.HasPermission("ModificarMeta") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarMeta") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirMeta") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Procedure Name:       grdMetas_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Meta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdMetas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMetas.DoubleClick
        Try
            If Me.grdMetas.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarMeta") Then
                LlamaModificarMeta()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFicha_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdMetas.Error
        Control_Error(e.Exception)
    End Sub

    
    
End Class