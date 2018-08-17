Public Class frmStbTasaCambio

    Dim ModoForm As String
    Dim ObjParidad As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable
    Dim ObjParidadDr As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaRow

    Dim XdtParidad As New BOSistema.Win.XDataSet.xDataTable

    Private Sub FrmSteParidadCambiaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtParidad = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    07/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    frmStbTasaCambio.vb
    '-- Descripcion      :    Formulario Principal de Caso de Uso Paridad Cambiaria
    '--------------------------------------------------------------------------------------------
    Private Sub frmStbTasaCambio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a  utilizarse en la aplicación.

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '----------- DATOS DEL GRID 
            InicializaVariables()
            MostrarDatos()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub InicializaVariables()
        Try
            'Limpiar los Grids, estructura y Datos
            XdtParidad = New BOSistema.Win.XDataSet.xDataTable
            Me.grdParidad10.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCerrar.Click
        Me.Close()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    07/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiaria.vb
    '-- Descripción      :    Permite Mostrar los datos en el Grid.
    '----------------------------------------------------------------------------------------------------------
    Public Sub MostrarDatos()
        Try
            '---   Muestra datos en el Grid, de acuerdo a opción seleccionada por el Usuario  
            Dim Strsql As String

            Strsql = " Select * From vwStbParidadCambiaria" & _
                     " Order By MonedaBase, [Moneda de Cambio],FechaInicio"

            XdtParidad.ExecuteSql(Strsql)
            Me.grdParidad10.DataSource = XdtParidad.Source
            Me.grdParidad10.Caption = "Registro de Tasas de Cambio (" + Me.grdParidad10.RowCount.ToString + " Registros)"

            Me.grdParidad10.Splits(0).DisplayColumns("nStbParidadCambiariaID").Visible = False
            ' Me.grdParidad10.Splits(0).DisplayColumns("Activo").Visible = False
            Me.grdParidad10.Splits(0).DisplayColumns("nStbMonedaBaseID").Visible = False
            Me.grdParidad10.Splits(0).DisplayColumns("nStbMonedaCambioId").Visible = False
            Me.grdParidad10.Splits(0).DisplayColumns("FechaInicio").Visible = False
            Me.grdParidad10.Splits(0).DisplayColumns("FechaFin").Visible = False
            Me.grdParidad10.Splits(0).DisplayColumns("ColumnaMentira").Visible = False

            Me.grdParidad10.Splits(0).DisplayColumns("nActivo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("nOcupado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("Periodo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdParidad10.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdParidad10.Columns("nOcupado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            '----  Redimensionando el Ancho de las Columnas 
            Me.grdParidad10.Splits(0).DisplayColumns("MonedaBase").Width = 150
            Me.grdParidad10.Splits(0).DisplayColumns("Moneda de Cambio").Width = 150
            Me.grdParidad10.Splits(0).DisplayColumns("nMontoTCambio").Width = 90
            Me.grdParidad10.Splits(0).DisplayColumns("Periodo").Width = 90

            '----   Columnas a Mostrar en el grid

            Me.grdParidad10.Columns("MonedaBase").Caption = "Moneda Base"
            Me.grdParidad10.Columns("Moneda de Cambio").Caption = "Moneda de Cambio"
            Me.grdParidad10.Columns("FechaInicio").Caption = "Fecha Inicio"
            Me.grdParidad10.Columns("FechaFin").Caption = "Fecha Fin"
            Me.grdParidad10.Columns("nMontoTCambio").Caption = "Tasa de Cambio"
            Me.grdParidad10.Columns("Periodo").Caption = "Periodo"
            Me.grdParidad10.Columns("nActivo").Caption = "Activo"
            Me.grdParidad10.Columns("nOcupado").Caption = "Ocupado"

            Me.grdParidad10.Splits(0).DisplayColumns("MonedaBase").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("Moneda de Cambio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("FechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("FechaFin").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("nActivo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("nOcupado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("Periodo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdParidad10.Splits(0).DisplayColumns("nMontoTCambio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '----   Columnas que no se mostrarán en el grid

            'Me.grdParidad10.Splits(0).Locked = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    07/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiaria.vb
    '-- Descripción      :    Modifica datos de una Registro de Tasa de Cambio Seleccionado.
    '----------------------------------------------------------------------------------------------------------
    Private Sub LLamaModificarDatos()
        Dim ObjFrmEditParidadCambiaria As New frmStbEditTasaCambio
        Try

            'Validar que existan datos que eliminar
            If Me.grdParidad10.RowCount = 0 Then
                Exit Sub
            End If

            ObjFrmEditParidadCambiaria.ModoFrm = "UPD"
            ObjFrmEditParidadCambiaria.Text = "Modificar Tasa de Cambio"
            ObjFrmEditParidadCambiaria.IdParidad = XdtParidad.ValueField("nStbParidadCambiariaID")
            ObjFrmEditParidadCambiaria.IdMonedaBase = XdtParidad.ValueField("nStbMonedaBaseId")
            ObjFrmEditParidadCambiaria.IdMonedaCambio = XdtParidad.ValueField("nStbMonedaCambioId")
            ObjFrmEditParidadCambiaria.ShowDialog()

            '-- Refrescar el GRID
            MostrarDatos()
            XdtParidad.SetCurrentByID("nStbParidadCambiariaID", ObjFrmEditParidadCambiaria.IdParidad)
            Me.grdParidad10.Row = XdtParidad.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmEditParidadCambiaria.Close()
            ObjFrmEditParidadCambiaria = Nothing
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    07/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiaria.vb
    '-- Descripción      :    Le indica al Programa la Ruta a SEguir de acuerdo a lo seleccionado por el Usuario.
    '----------------------------------------------------------------------------------------------------------
    Private Sub TbTasasdeCambio_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TbTasasdeCambio.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolRefrescar"
                InicializaVariables()
                MostrarDatos()
            Case "toolAgregar"
                LlamaAgregarDatos()
            Case "toolEliminar"
                LlamaEliminarDatos()
            Case "toolModificar"
                LLamaModificarDatos()
            Case "toolImprimir"
                LlamaImprimir()
        End Select
    End Sub

    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    07/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmStbParidadCambiaria.vb
    '-- Descripción      :    Agrega un nuevo Registro de Tasas de Cambio
    '----------------------------------------------------------------------------------------------------------
    Private Sub LlamaAgregarDatos()
        Dim ObjFrmEditParidadCambiaria As New frmStbEditTasaCambio
        Try

            ObjFrmEditParidadCambiaria.ModoFrm = "ADD"
            ObjFrmEditParidadCambiaria.Text = "Agregar Tasa de Cambio"
            ObjFrmEditParidadCambiaria.ShowDialog()

            'Si el id del Cajero es mayor que cero es porque agrego el registro.

            If ObjFrmEditParidadCambiaria.IdParidad > 0 Then
                XdtParidad.SetCurrentByID("nStbParidadCambiariaID", ObjFrmEditParidadCambiaria.IdParidad)
            End If
            MostrarDatos()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmEditParidadCambiaria.Close()
            ObjFrmEditParidadCambiaria = Nothing
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    07/10/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteParidadCambiaria.vb
    '-- Descripción      :    Permite Eliminar el Registro de Paridad Cambiaria Seleccionada
    '----------------------------------------------------------------------------------------------------------
    Private Sub LlamaEliminarDatos()

        Dim ObjFrmParidadCambiaria As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable
        Dim ObjParidadCambiariaDt As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaDataTable
        Dim ObjParidadCambiariaDr As New BOSistema.Win.StbEntCatalogo.StbParidadCambiariaRow
        Dim sqlstr As String
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            If Me.grdParidad10.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                '-- Eliminar Paridad Cambiaria


                'ObjPagodt.Filter = "objParidadCambiariaID =" & XdtParidad.ValueField("SteParidadCambiariaID")
                'ObjPagodt.Retrieve()
                'If ObjPagodt.Count > 0 Then
                '    MsgBox("No se puede eliminar esta tasa de cambio porque esta asociado en los pagos", MsgBoxStyle.Critical, "SMUSURA0")
                '    Exit Sub
                'End If


                ObjParidadCambiariaDt.Filter = "nStbParidadCambiariaID =" & XdtParidad.ValueField("nStbParidadCambiariaID")
                ObjParidadCambiariaDt.Retrieve()
                If ObjParidadCambiariaDt.Count > 0 Then
                    ObjParidadCambiariaDr = ObjParidadCambiariaDt.Current
                    If ObjParidadCambiariaDr.nOcupado = 1 Then
                        MsgBox("No se puede eliminar esta tasa de cambio porque esta ocupado", MsgBoxStyle.Critical, "SMUSURA0")
                        Exit Sub
                    End If

                End If
                sqlstr = "DELETE FROM [StbParidadCambiaria] " & _
                         "WHERE (nStbParidadCambiariaID = " & XdtParidad.ValueField("nStbParidadCambiariaID") & ")"
                XcDatos.ExecuteNonQuery(sqlstr)

                Me.MostrarDatos()

                MsgBox("El registro se eliminó satisfactoriamente")
                Me.grdParidad10.Caption = "Listado de Tasas de Cambios (" + Me.grdParidad10.RowCount.ToString + " Registros)"
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmParidadCambiaria.Close()
            ObjFrmParidadCambiaria = Nothing

            ObjParidadCambiariaDt.Close()
            ObjParidadCambiariaDt = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            If Seg.HasPermission("AgregarParidadCambiaria") = False Then  'Habilita
                Me.TbTasasdeCambio.Items("toolAgregar").Enabled = False
            Else  'Deshabilita
                Me.TbTasasdeCambio.Items("toolAgregar").Enabled = True
            End If

            If Seg.HasPermission("EditarParidadCambiaria") = False Then  'Habilita
                Me.TbTasasdeCambio.Items("toolModificar").Enabled = False
            Else  'Deshabilita
                Me.TbTasasdeCambio.Items("toolModificar").Enabled = True
            End If

            If Seg.HasPermission("EliminarParidadCambiaria") = False Then  'Habilita
                Me.TbTasasdeCambio.Items("toolEliminar").Enabled = False
            Else  'Deshabilita
                Me.TbTasasdeCambio.Items("toolEliminar").Enabled = True
            End If

            If Seg.HasPermission("ImprimirParidadCambiaria") Then  'Habilita
                Me.TbTasasdeCambio.Items("toolImprimir").Enabled = True
            Else  'Deshabilita
                Me.TbTasasdeCambio.Items("toolImprimir").Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                12/09/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El listado
    '                       de Tasas de Cambio según los parámetros seleccionados. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmStbParametroTasaCambio As New frmStbParametroTasaCambio
        Try
            Dim strSQL As String = ""

            If Me.grdParidad10.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmStbParametroTasaCambio.NomRep = 1
            ObjFrmStbParametroTasaCambio.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmStbParametroTasaCambio.Close()
            ObjFrmStbParametroTasaCambio = Nothing
        End Try
    End Sub
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAyuda.Click
        LlamaAyuda()
    End Sub
    Private Sub grdParidad10_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdParidad10.DoubleClick
        Try
            LLamaModificarDatos()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdParidad10_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdParidad10.Error
        Control_Error(e.Exception)
    End Sub
    'En caso que ocurra otro Tipo de Error  
    Private Sub grdParidad10_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdParidad10.Filter
        Try
            XdtParidad.FilterLocal(e.Condition)
            Me.grdParidad10.Caption = "Registro de Tasas de Cambio (" + Me.grdParidad10.RowCount.ToString + " Registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class
