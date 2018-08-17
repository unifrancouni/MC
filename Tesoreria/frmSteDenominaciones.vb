' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                09/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteDenominaciones.vb
' Descripción:          Este formulario muestra Catálogo de Denominaciones.
'-------------------------------------------------------------------------

Public Class frmSteDenominaciones
    '- Declaración de Variables 
    Dim XdtDenominaciones As BOSistema.Win.XDataSet.xDataTable

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       frmSteDenominaciones_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Denominaciones en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteDenominaciones_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI

        Try
            '-- Asignar el tema de Color a utilizarse.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarDenominaciones()
            FormatoDenominaciones()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       frmSteDenominaciones_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan variables
    '                       que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteDenominaciones_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtDenominaciones.Close()
            XdtDenominaciones = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtDenominaciones = New BOSistema.Win.XDataSet.xDataTable
            'Limpiar los Grids (estructura y Datos).
            Me.grdDenominaciones.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       CargarDenominaciones
    ' Descripción:          Procedimiento permite cargar datos de las 
    '                       Denominaciones de Billetes y Monedas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarDenominaciones()
        Try

            'Asignar Qry al Xdt:
            Dim Strsql As String
            Strsql = " Select a.nSteDenominacionID, a.nBillete, a.nValor " & _
                     " From SteDenominaciones a " & _
                     " Order by a.nBillete desc, a.nValor"
            XdtDenominaciones.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdDenominaciones.DataSource = XdtDenominaciones.Source

            'Actualizando el caption del GRID:
            Me.grdDenominaciones.Caption = " Listado de Denominaciones (" + Me.grdDenominaciones.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       FormatoDenominaciones
    ' Descripción:          Este procedimiento permite configurar los datos 
    '                       sobre Denominaciones en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoDenominaciones()
        Try

            'Oculta llave principal en el Grid:
            Me.grdDenominaciones.Splits(0).DisplayColumns("nSteDenominacionID").Visible = False

            'Establecer ancho de columnas visibles al usuario:
            Me.grdDenominaciones.Splits(0).DisplayColumns("nBillete").Width = 200
            Me.grdDenominaciones.Splits(0).DisplayColumns("nValor").Width = 60
            
            'Ubicar Nombre de los Campos:
            Me.grdDenominaciones.Columns("nBillete").Caption = "Denominación de Billetes"
            Me.grdDenominaciones.Columns("nValor").Caption = "Valor de la Denominación"

            'Check Box:
            Me.grdDenominaciones.Columns("nBillete").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdDenominaciones.Splits(0).DisplayColumns("nBillete").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Alineación Encabezados:
            Me.grdDenominaciones.Splits(0).DisplayColumns("nBillete").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDenominaciones.Splits(0).DisplayColumns("nValor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       tbDenominaciones_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip.
    '-------------------------------------------------------------------------
    Private Sub tbDenominaciones_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbDenominaciones.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarDenominacion()
            Case "toolModificar"
                LlamaModificarDenominacion()
            Case "toolEliminar"
                LlamaEliminarDenominacion()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolRefrescar"
                InicializaVariables()
                CargarDenominaciones()
                FormatoDenominaciones()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Denominaciones de Billetes y Monedas. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdDenominaciones.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE2.rpt"
            frmVisor.Text = "Catálogo de Denominaciones"
            frmVisor.SQLQuery = "Select * From SteDenominaciones Order by nBillete desc, nValor"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       LlamaAgregarDenominacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditDenominaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarDenominacion()
        Dim ObjFrmSteEditDenominacion As New frmSteEditDenominaciones
        Try

            'Indicador de adición:
            ObjFrmSteEditDenominacion.ModoFrm = "ADD"
            'Mostrar forma para la adición:
            ObjFrmSteEditDenominacion.ShowDialog()

            If ObjFrmSteEditDenominacion.IdDenominacion <> 0 Then 'No se produjo error.
                'Refrescar registros:
                CargarDenominaciones()
                'Se ubica sobre el registro recién ingresado.
                XdtDenominaciones.SetCurrentByID("nSteDenominacionID", ObjFrmSteEditDenominacion.IdDenominacion)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditDenominacion.Close()
            ObjFrmSteEditDenominacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       LlamaModificarDenominacion
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditDenominaciones para Modificar.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarDenominacion()
        Dim ObjFrmSteEditDenominacion As New frmSteEditDenominaciones
        Try
            Dim StrSql As String
            'Si no hay registros ingresados salir del Sub:
            If Me.grdDenominaciones.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Si la Denominación esta siendo usada por un Arqueo:
            StrSql = "SELECT * FROM  SteArqueoDenominacion WHERE (nSteDenominacionID = " & XdtDenominaciones.ValueField("nSteDenominacionID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Denominación está siendo utilizada por un Arqueo.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Indicador de Actualización:
            ObjFrmSteEditDenominacion.ModoFrm = "UPD"
            ObjFrmSteEditDenominacion.IdDenominacion = XdtDenominaciones.ValueField("nSteDenominacionID")
            ObjFrmSteEditDenominacion.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            CargarDenominaciones()
            XdtDenominaciones.SetCurrentByID("nSteDenominacionID", ObjFrmSteEditDenominacion.IdDenominacion)
            Me.grdDenominaciones.Row = XdtDenominaciones.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSteEditDenominacion.Close()
            ObjFrmSteEditDenominacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       LlamaEliminarDenominacion
    ' Descripción:          Este procedimiento permite eliminar una denominacion
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarDenominacion()
        Dim XdtEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String

            'Si no existen registros:
            If Me.grdDenominaciones.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Si la Denominación esta siendo usada por un Arqueo:
            StrSql = "SELECT * FROM  SteArqueoDenominacion WHERE (nSteDenominacionID = " & XdtDenominaciones.ValueField("nSteDenominacionID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La Denominación está siendo utilizada por un Arqueo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XdtEliminar.ExecuteSqlNotTable("Delete From SteDenominaciones where nSteDenominacionID=" & XdtDenominaciones.ValueField("nSteDenominacionID"))
                CargarDenominaciones()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdDenominaciones.Caption = "Listado de Denominaciones (" + Me.grdDenominaciones.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtEliminar.Close()
            XdtEliminar = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Procedimiento permite cerrar la opción de Socias.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       grdDenominaciones_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Denominacion existente, al hacer doble 
    '                       click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDenominaciones_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDenominaciones.DoubleClick
        Try
            If Seg.HasPermission("ModificarDenominacion") Then
                LlamaModificarDenominacion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdDenominaciones_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDenominaciones.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       grdDenominaciones_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDenominaciones.Filter
        Try
            XdtDenominaciones.FilterLocal(e.Condition)
            'Se invocá para refrescar el count de registros:
            Me.grdDenominaciones.Caption = " Listado de Denominaciones (" + Me.grdDenominaciones.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/01/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Agregar:
            If Seg.HasPermission("AgregarDenominacion") = False Then
                Me.tbDenominaciones.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbDenominaciones.Items("toolAgregar").Enabled = True
            End If
            'Editar:
            If Seg.HasPermission("ModificarDenominacion") = False Then
                Me.tbDenominaciones.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbDenominaciones.Items("toolModificar").Enabled = True
            End If
            'Eliminar:
            If Seg.HasPermission("EliminarDenominacion") = False Then
                Me.tbDenominaciones.Items("toolEliminar").Enabled = False
            Else  'Habilita
                Me.tbDenominaciones.Items("toolEliminar").Enabled = True
            End If
            'Imprimir:
            If Seg.HasPermission("ImprimirCatalogoDenominaciones") = False Then
                Me.tbDenominaciones.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbDenominaciones.Items("toolImprimir").Enabled = True
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class