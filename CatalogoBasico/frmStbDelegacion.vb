' ------------------------------------------------------------------------
' Autor:                Yesenia Guti�rrez
' Fecha:                08/02/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbDelegacion.vb
' Descripci�n:          Este formulario muestra Cat�logo de Delegaciones 
'                       del Programa.
'-------------------------------------------------------------------------

Public Class frmStbDelegacion
    '- Declaraci�n de Variables 
    Dim XdtDelegaciones As BOSistema.Win.XDataSet.xDataTable

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       frmStbDelegacion_Load
    ' Descripci�n:          Evento Load del formulario donde se inicializan 
    '                       variables.
    '-------------------------------------------------------------------------
    Private Sub frmStbDelegacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI

        Try
            '-- Asignar el tema de Color a utilizarse.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarDelegacion()
            FormatoDelegacion()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       frmStbDelegacion_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde se eliminan variables
    '                       que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmStbDelegacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtDelegaciones.Close()
            XdtDelegaciones = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtDelegaciones = New BOSistema.Win.XDataSet.xDataTable
            'Limpiar los Grids (estructura y Datos).
            Me.grdDelegacion.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       CargarDelegacion
    ' Descripci�n:          Procedimiento permite cargar datos de Delegaciones
    '                       en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarDelegacion()
        Try

            'Asignar Qry al Xdt:
            Dim Strsql As String
            Strsql = " Select nStbDelegacionProgramaID, nStbMunicipioID, nActiva, nCodigo, sNombreDelegacion, " & _
                     " Departamento, Municipio, sUbicacionDelegacion, sTelefonoUbicacion, sDireccionUbicacion " & _
                     " From vwStbDelegaciones " & _
                     " Order by nCodigo"
            XdtDelegaciones.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdDelegacion.DataSource = XdtDelegaciones.Source

            'Actualizando el caption del GRID:
            Me.grdDelegacion.Caption = " Listado de Delegaciones del Programa (" + Me.grdDelegacion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       FormatoDelegacion
    ' Descripci�n:          Este procedimiento permite configurar los datos 
    '                       sobre Delegaciones del Programa en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoDelegacion()
        Try

            'Oculta llave principal en el Grid:
            Me.grdDelegacion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdDelegacion.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False

            'Establecer ancho de columnas visibles al usuario:
            Me.grdDelegacion.Splits(0).DisplayColumns("nActiva").Width = 50
            Me.grdDelegacion.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").Width = 150
            Me.grdDelegacion.Splits(0).DisplayColumns("Departamento").Width = 130
            Me.grdDelegacion.Splits(0).DisplayColumns("Municipio").Width = 130
            Me.grdDelegacion.Splits(0).DisplayColumns("sUbicacionDelegacion").Width = 350
            Me.grdDelegacion.Splits(0).DisplayColumns("sTelefonoUbicacion").Width = 150
            Me.grdDelegacion.Splits(0).DisplayColumns("sDireccionUbicacion").Width = 450

            'Ubicar Nombre de los Campos:
            Me.grdDelegacion.Columns("nCodigo").Caption = "C�digo"
            Me.grdDelegacion.Columns("sNombreDelegacion").Caption = "Nombre Delegaci�n"
            Me.grdDelegacion.Columns("Departamento").Caption = "Departamento"
            Me.grdDelegacion.Columns("Municipio").Caption = "Municipio"
            Me.grdDelegacion.Columns("sUbicacionDelegacion").Caption = "Ubicaci�n Delegaci�n"
            Me.grdDelegacion.Columns("sTelefonoUbicacion").Caption = "Telef�no"
            Me.grdDelegacion.Columns("sDireccionUbicacion").Caption = "Direcci�n"

            'Check Box:
            Me.grdDelegacion.Columns("nActiva").Caption = "Activa"
            Me.grdDelegacion.Columns("nActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            'Alineaci�n:
            Me.grdDelegacion.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("nActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdDelegacion.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("nActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("sUbicacionDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("sTelefonoUbicacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdDelegacion.Splits(0).DisplayColumns("sDireccionUbicacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2007
    ' Procedure Name:       tbDelegacion_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip.
    '-------------------------------------------------------------------------
    Private Sub tbDelegacion_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbDelegacion.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarDelegacion()
            Case "toolModificar"
                LlamaModificarDelegacion()
            Case "toolInactivar"
                LlamaInactivarDelegacion()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolRefrescar"
                InicializaVariables()
                CargarDelegacion()
                FormatoDelegacion()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       LlamaImprimir
    ' Descripci�n:          Este procedimiento permite Imprimir El Listado
    '                       de Delegaciones del Programa. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdDelegacion.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepStbCB13.rpt"
            frmVisor.Text = "Listado de Delegaciones del Programa"
            strSQL = " Select * " & _
                     " From vwStbDelegaciones " & _
                     " Order by nCodigo"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       LlamaAgregarDelegacion
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmStbEditDelegacion para Agregar un nuevo registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarDelegacion()
        Dim ObjFrmStbEditDelegacion As New frmStbEditDelegacion
        Try

            ObjFrmStbEditDelegacion.ModoFrm = "ADD"
            ObjFrmStbEditDelegacion.ShowDialog()

            If ObjFrmStbEditDelegacion.IdDelegacion <> 0 Then 'No se produjo error.
                CargarDelegacion()
                XdtDelegaciones.SetCurrentByID("nStbDelegacionProgramaID", ObjFrmStbEditDelegacion.IdDelegacion)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbEditDelegacion.Close()
            ObjFrmStbEditDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       LlamaModificarDelegacion
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmStbEditDelegacion para Modificar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarDelegacion()
        Dim ObjFrmStbEditDelegacion As New frmStbEditDelegacion
        Try
            'Si no hay registros ingresados salir del Sub:
            If Me.grdDelegacion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la socia no se encuentra Activa Advertir:
            If XdtDelegaciones.ValueField("nActiva") = 0 Then
                MsgBox("La Delegaci�n est� inactiva.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            ObjFrmStbEditDelegacion.ModoFrm = "UPD"
            ObjFrmStbEditDelegacion.IdDelegacion = XdtDelegaciones.ValueField("nStbDelegacionProgramaID")
            ObjFrmStbEditDelegacion.ShowDialog()

            'Refresca las modificaciones realizadas en el Grid.
            CargarDelegacion()
            XdtDelegaciones.SetCurrentByID("nStbDelegacionProgramaID", ObjFrmStbEditDelegacion.IdDelegacion)
            Me.grdDelegacion.Row = XdtDelegaciones.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmStbEditDelegacion.Close()
            ObjFrmStbEditDelegacion = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       LlamaInactivarDelegacion
    ' Descripci�n:          Este procedimiento permite inactivar una Delegaci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivarDelegacion()
        Dim XdtInactivar As New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim intPosicion As Integer  'Posicion del registro seleccionado, ID de la Socia

            'Imposible inactivar si no hay ninguna Delegaci�n registrada:
            If Me.grdDelegacion.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no se encuentra Activa salir del Sub:
            If XdtDelegaciones.ValueField("nActiva") = 0 Then
                MsgBox("La Delegaci�n est� inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Inactivar:
            If MsgBox("�Est� seguro de Inactivar la Delegaci�n seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                XdtInactivar.ExecuteSqlNotTable("Update StbDelegacionPrograma SET dFechaModificacion = GetDate(), nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', nActiva = 0 WHERE nStbDelegacionProgramaID = " & XdtDelegaciones.ValueField("nStbDelegacionProgramaID"))
                intPosicion = XdtDelegaciones.ValueField("nStbDelegacionProgramaID")
                'Refrescar Datos:
                CargarDelegacion()
                XdtDelegaciones.SetCurrentByID("nStbDelegacionProgramaID", intPosicion)
                Me.grdDelegacion.Row = XdtDelegaciones.BindingSource.Position

                'Env�a mensaje de inactivaci�n:
                MsgBox("El registro se inactiv� satisfactoriamente.", MsgBoxStyle.Information)

                'Almacena Pista de Auditor�a:
                Call GuardarAuditoria(4, 13, "Inactivaci�n de Delegaci�n: " & XdtDelegaciones.ValueField("nCodigo") & ". ")
            End If

        Catch ex As Exception
            Control_Error(ex)
            'MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtInactivar.Close()
            XdtInactivar = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripci�n:          Procedimiento permite cerrar la opci�n de Delegaciones.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
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
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       grdDelegacion_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Delegaci�n existente, al hacer doble 
    '                       click sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdDelegacion_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdDelegacion.DoubleClick
        Try
            If Seg.HasPermission("ModificarDelegacion") Then
                LlamaModificarDelegacion()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdDelegacion_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdDelegacion.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       grdDelegacion_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdDelegacion_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdDelegacion.Filter
        Try
            XdtDelegaciones.FilterLocal(e.Condition)
            'Se invoc� para refrescar el count de registros:
            Me.grdDelegacion.Caption = " Listado de Delegaciones del Programa (" + Me.grdDelegacion.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                08/02/2008
    ' Procedure Name:       Seguridad
    ' Descripci�n:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Agregar
            If Seg.HasPermission("AgregarDelegacion") = False Then
                Me.tbDelegacion.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbDelegacion.Items("toolAgregar").Enabled = True
            End If
            'Editar:
            If Seg.HasPermission("ModificarDelegacion") = False Then
                Me.tbDelegacion.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbDelegacion.Items("toolModificar").Enabled = True
            End If
            'Inactivar:
            If Seg.HasPermission("InactivarDelegacion") = False Then
                Me.tbDelegacion.Items("toolInactivar").Enabled = False
            Else  'Habilita
                Me.tbDelegacion.Items("toolInactivar").Enabled = True
            End If
            'Imprimir:
            If Seg.HasPermission("ImprimirListadoDelegaciones") = False Then
                Me.tbDelegacion.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbDelegacion.Items("toolImprimir").Enabled = True
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class