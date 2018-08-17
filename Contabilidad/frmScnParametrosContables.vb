' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                03/12/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnParametrosContables.vb
' Descripción:          Este formulario muestra Parámetros Contables.
'-------------------------------------------------------------------------

Public Class frmScnParametrosContables
    '- Declaración de Variables 
    Dim XdtParametros As BOSistema.Win.XDataSet.xDataTable

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       frmScnParametrosContables_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnParametrosContables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI

        Try
            '-- Asignar el tema de Color a utilizarse.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarParametros()
            FormatoParametro()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       frmScnParametrosContables_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan variables
    '                       que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmScnParametrosContables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtParametros.Close()
            XdtParametros = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtParametros = New BOSistema.Win.XDataSet.xDataTable
            'Limpiar los Grids (estructura y Datos).
            Me.grdParametro.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       CargarParametros
    ' Descripción:          Procedimiento permite cargar datos de los Parámetros
    '                       en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarParametros()
        Try

            'Asignar Qry al Xdt:
            Dim Strsql As String
            Strsql = " Select * From vwScnParametrosContables " & _
                     " Order by FuenteFondos, TipoDocumento, sCodigoCuenta"
            XdtParametros.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdParametro.DataSource = XdtParametros.Source

            'Actualizando el caption del GRID:
            Me.grdParametro.Caption = " Listado de Parámetros Contables (" + Me.grdParametro.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       FormatoParametro
    ' Descripción:          Este procedimiento permite configurar los datos 
    '                       sobre Parámetros en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoParametro()
        Try

            'Oculta llave principal en el Grid:
            Me.grdParametro.Splits(0).DisplayColumns("nScnTransaccionParametroID").Visible = False
            Me.grdParametro.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False
            Me.grdParametro.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdParametro.Splits(0).DisplayColumns("nStbTipoDocContableID").Visible = False
            Me.grdParametro.Splits(0).DisplayColumns("nStbTipoAfectacionID").Visible = False
            Me.grdParametro.Splits(0).DisplayColumns("CodTipoDocumento").Visible = False

            'Establecer ancho de columnas visibles al usuario:
            Me.grdParametro.Splits(0).DisplayColumns("FuenteFondos").Width = 200
            Me.grdParametro.Splits(0).DisplayColumns("TipoDocumento").Width = 210
            Me.grdParametro.Splits(0).DisplayColumns("sCodigoCuenta").Width = 120
            Me.grdParametro.Splits(0).DisplayColumns("sNombreCuenta").Width = 280
            Me.grdParametro.Splits(0).DisplayColumns("nDebito").Width = 70
            Me.grdParametro.Splits(0).DisplayColumns("TipoAfectacion").Width = 210
            
            'Ubicar Nombre de los Campos:
            Me.grdParametro.Columns("FuenteFondos").Caption = "Fuente de Fondos"
            Me.grdParametro.Columns("TipoDocumento").Caption = "Tipo de Documento"
            Me.grdParametro.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.grdParametro.Columns("sNombreCuenta").Caption = "Nombre Cuenta Contable"
            Me.grdParametro.Columns("nDebito").Caption = "Débito"
            Me.grdParametro.Columns("TipoAfectacion").Caption = "Tipo de Afectación"

            'Check Box:
            Me.grdParametro.Columns("nDebito").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdParametro.Splits(0).DisplayColumns("nDebito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdParametro.Splits(0).DisplayColumns("FuenteFondos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("TipoDocumento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("nDebito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParametro.Splits(0).DisplayColumns("TipoAfectacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       tbParametro_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip (tbParametro).
    '-------------------------------------------------------------------------
    Private Sub tbParametro_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbParametro.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarParametro()
            Case "toolModificar"
                LlamaModificarParametro()
            Case "toolEliminar"
                LlamaEliminarParametro()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolRefrescar"
                InicializaVariables()
                CargarParametros()
                FormatoParametro()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Parámetros. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdParametro.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepScnCN9.rpt"
            frmVisor.Text = "Parámetros Contables"
            frmVisor.SQLQuery = "Select * From vwScnParametrosContables Order by nScnFuenteFinanciamientoID, CodTipoDocumento, sCodigoCuenta"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       LlamaAgregarParametro
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSocia para Agregar una nueva Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarParametro()
        Dim ObjFrmSclEditParametro As New frmScnEditParametrosContables
        Try

            'Indicador de adición:
            ObjFrmSclEditParametro.ModoFrm = "ADD"
            'Mostrar forma para la adición:
            ObjFrmSclEditParametro.ShowDialog()

            If ObjFrmSclEditParametro.IdParametro <> 0 Then 'No se produjo error.
                'Refrescar registros:
                CargarParametros()
                'Se ubica sobre el registro recién ingresado.
                XdtParametros.SetCurrentByID("nScnTransaccionParametroID", ObjFrmSclEditParametro.IdParametro)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditParametro.Close()
            ObjFrmSclEditParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       LlamaModificarParametro
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditParametrosContables para Modificar uno existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarParametro()
        Dim ObjFrmSclEditParametro As New frmScnEditParametrosContables
        Try
            'Si no hay registros ingresados salir del Sub:
            If Me.grdParametro.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            
            'Indicador de Actualización:
            ObjFrmSclEditParametro.ModoFrm = "UPD"
            'Se indica llave principal:
            ObjFrmSclEditParametro.IdParametro = XdtParametros.ValueField("nScnTransaccionParametroID")
            'Se muestra en formulario de edición:
            ObjFrmSclEditParametro.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            CargarParametros()
            'Y se posiciona sobre el registro modificado.
            XdtParametros.SetCurrentByID("nScnTransaccionParametroID", ObjFrmSclEditParametro.IdParametro)
            'Refresca posicionamiento del Grid:
            Me.grdParametro.Row = XdtParametros.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSclEditParametro.Close()
            ObjFrmSclEditParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       LlamaEliminarParametro
    ' Descripción:          Este procedimiento permite eliminar un parámetro.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarParametro()
        Dim XdtParametroEliminar As New BOSistema.Win.XDataSet.xDataTable
        Try
            If Me.grdParametro.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XdtParametroEliminar.ExecuteSqlNotTable("Delete From ScnTransaccionParametros where nScnTransaccionParametroID=" & XdtParametros.ValueField("nScnTransaccionParametroID"))
                CargarParametros()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdParametro.Caption = "Listado de Parámetros Contables (" + Me.grdParametro.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtParametroEliminar.Close()
            XdtParametroEliminar = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
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
    ' Fecha:                03/12/2007
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
    ' Fecha:                03/12/2007
    ' Procedure Name:       grdParametro_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un parámetro existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdParametro_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdParametro.DoubleClick
        Try
            If Seg.HasPermission("ModificarParametro") Then
                LlamaModificarParametro()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdParametro_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdParametro.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       grdParametro_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdParametro_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdParametro.Filter
        Try
            XdtParametros.FilterLocal(e.Condition)
            'Se invocá para refrescar el count de registros:
            Me.grdParametro.Caption = " Listado de Parámetros Contables (" + Me.grdParametro.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/12/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Agregar
            If Seg.HasPermission("AgregarParametro") = False Then
                Me.tbParametro.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbParametro.Items("toolAgregar").Enabled = True
            End If
            'Modificar
            If Seg.HasPermission("ModificarParametro") = False Then
                Me.tbParametro.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbParametro.Items("toolModificar").Enabled = True
            End If
            'Eliminar:
            If Seg.HasPermission("EliminarParametro") = False Then
                Me.tbParametro.Items("toolEliminar").Enabled = False
            Else  'Habilita
                Me.tbParametro.Items("toolEliminar").Enabled = True
            End If
            'Imprimir:
            If Seg.HasPermission("ImprimirListadoParametros") = False Then
                Me.tbParametro.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbParametro.Items("toolImprimir").Enabled = True
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class