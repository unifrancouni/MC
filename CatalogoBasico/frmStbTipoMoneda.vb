' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                12/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbTipoMoneda.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de un Tipo de Moneda.
'-------------------------------------------------------------------------

Public Class frmStbTipoMoneda

    Dim ModoForm As String
    Dim XdtMoneda As New BOSistema.Win.XDataSet.xDataTable
    '--------------------------------------------------------------------------------------------------------
    'Propiedad utilizada para el identificar si el formulario se utiliza para agregar o Modificar los datos 
    '--------------------------------------------------------------------------------------------------------
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda.vb
    '-- Descripcion      :    Formulario Principal de Caso de Uso Moneda
    '--------------------------------------------------------------------------------------------
    Private Sub frmStbTipoMoneda_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try

            '-- Asignar el tema de Color a utilizarse en la aplicación.         
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            '----------- DATOS DEL GRID 
            MostrarDatos()
            ' ------   Cargar el Procedimiento Seguridad
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally


        End Try

    End Sub

    Private Sub InicializaVariables()
        Try
            'Limpiar los Grids, estructura y Datos
            XdtMoneda = New BOSistema.Win.XDataSet.xDataTable
            Me.grdMonedas.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:
    ' Date			    		:19/10/2006
    ' Procedure name		   	:Activar
    ' Description			   	:Este procedimiento invoca el evento activated del formulario
    '                           :se usa en los procedimientos cuando se llama al formulario de
    '                           :seleccionar periodo en cada formulario mdi
    ' -----------------------------------------------------------------------------------------
    Public Sub Activar()
        Dim e As New System.EventArgs
        Try
            MyBase.OnActivated(e)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda.vb
    '-- Descripción      :    Permite conocer las variables del Sistema y Entorno que nos puede ser útil.
    '----------------------------------------------------------------------------------------------------------
    Private Sub toolCerrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCerrar.Click
        Me.Close()
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda.vb
    '-- Descripción      :    Permite Mostrar los datos en el Grid.
    '----------------------------------------------------------------------------------------------------------
    Public Sub MostrarDatos()
        Try
            '---   Muestra datos en el Grid, de acuerdo a opción seleccionada por el Usuario  

            'Dim ObjFrmSteMoneda As New frmStbTipoMoneda
            Dim Strsql As String

            Strsql = " Select nStbMonedaID, sCodigoInterno, sDescripcion, " & _
                     " sSimbolo,nNacional,nActivo, '' As ColumnaMentira" & _
                     " From   StbMoneda " & _
                     " Order By sCodigoInterno Asc"


            XdtMoneda.ExecuteSql(Strsql)
            Me.grdMonedas.DataSource = XdtMoneda.Source
            Me.grdMonedas.Caption = "Listado de Tipos de Moneda (" + Me.grdMonedas.RowCount.ToString + " registros)"

            '----  Redimensionando el Ancho de las Columnas 
            Me.grdMonedas.Splits(0).DisplayColumns("sCodigoInterno").Width = 100
            Me.grdMonedas.Splits(0).DisplayColumns("sDescripcion").Width = 200
            Me.grdMonedas.Splits(0).DisplayColumns("sSimbolo").Width = 100
            Me.grdMonedas.Splits(0).DisplayColumns("nNacional").Width = 100
            Me.grdMonedas.Splits(0).DisplayColumns("nActivo").Width = 80
            '----   Columnas a Mostrar en el grid

            Me.grdMonedas.Columns("nActivo").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdMonedas.Columns("nNacional").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdMonedas.Columns("sCodigoInterno").Caption = "Código"
            Me.grdMonedas.Columns("sDescripcion").Caption = "Nombre"
            Me.grdMonedas.Columns("sSimbolo").Caption = "Símbolo"
            Me.grdMonedas.Columns("nNacional").Caption = "Es Nacional?"
            Me.grdMonedas.Columns("nActivo").Caption = "Activo"
            Me.grdMonedas.Columns("ColumnaMentira").Caption = ""
            '----   Columnas que no se mostrarán en el grid

            Me.grdMonedas.Splits(0).DisplayColumns("nStbMonedaID").Visible = False
            'Me.grdMonedas.Splits(0).DisplayColumns("Activo").Visible = False
            'grdMonedas.Splits(0).Locked = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmStbMoneda.vb
    '-- Descripción      :    Modifica datos de una Moneda Seleccionada.
    '----------------------------------------------------------------------------------------------------------
    Private Sub LLamaModificarDatos()
        Dim ObjFrmEditMoneda As New frmStbEditTipoMoneda
        Try

            'Validar que existan datos que eliminar
            If Me.grdMonedas.RowCount = 0 Then
                Exit Sub
            End If

            'If Seg.HasPermission("EditarMoneda") = False Then
            '    Exit Sub
            'End If

            ObjFrmEditMoneda.ModoFrm = "UPD"
            ObjFrmEditMoneda.Text = "Modificar Moneda"
            ObjFrmEditMoneda.IdMoneda = XdtMoneda.ValueField("nStbMonedaID")
            ObjFrmEditMoneda.ShowDialog()

            '-- Refrescar el GRID
            MostrarDatos()
            XdtMoneda.SetCurrentByID("nStbMonedaID", ObjFrmEditMoneda.IdMoneda)
            Me.grdMonedas.Row = XdtMoneda.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally

            ObjFrmEditMoneda = Nothing
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda.vb
    '-- Descripción      :    Le indica al Programa la Ruta a SEguir de acuerdo a lo seleccionado por el Usuario.
    '----------------------------------------------------------------------------------------------------------
    Private Sub TbMoneda_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles TbMoneda.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolRefrescar"
                InicializaVariables()
                MostrarDatos()
            Case "toolAgregar"
                LlamaAgregarMoneda()
            Case "toolEliminar"
                LlamaEliminarMoneda()
            Case "toolModificar"
                LLamaModificarDatos()
            Case "toolImprimir"
                LLamaImprimir()
        End Select
    End Sub

    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    Ing. Claudia Castro Granados
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmStbMoneda.vb
    '-- Descripción      :    Agrega una nueva Moneda a la Tabla StbMoneda
    '----------------------------------------------------------------------------------------------------------
    Private Sub LlamaAgregarMoneda()
        Try
            Dim ObjFrmEditMoneda As New frmStbEditTipoMoneda

            ObjFrmEditMoneda.ModoFrm = "ADD"
            ObjFrmEditMoneda.Text = "Agregar Moneda"
            ObjFrmEditMoneda.ShowDialog()

            '------------   Si el id Moneda es mayor que cero es porque agrego el registro.  --------------

            If ObjFrmEditMoneda.IdMoneda > 0 Then
                MostrarDatos()
                XdtMoneda.SetCurrentByID("nStbMonedaID", ObjFrmEditMoneda.IdMoneda)
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '----------------------------------------------------------------------------------------------------------
    '-- Implementado por :    
    '-- Fecha            :    18/07/2006
    '-- Solution Name    :    FrmMDITablasBasicas
    '-- Project Name     :    PrjTablasBasicas
    '-- Project Item Name:    FrmSteMoneda.vb
    '-- Descripción      :    Permite Eliminar Monedas.
    '----------------------------------------------------------------------------------------------------------
    Private Sub LlamaEliminarMoneda()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim strsql As String
        Dim intPosicion As Integer

        Try
            If Me.grdMonedas.RowCount = 0 Then
                MsgBox("No existen monedas grabadas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            If MsgBox("¿Desea eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                strsql = "DELETE FROM [dbo].[StbMoneda] " & _
                         "WHERE StbMonedaID= " & XdtMoneda.ValueField("nStbMonedaID") & ""
                XcDatos.ExecuteScalar(strsql)

                MsgBox("El registro se eliminó satisfactoriamente", MsgBoxStyle.Information)
                Me.grdMonedas.Caption = "Listado de Tipos de Moneda (" + Me.grdMonedas.RowCount.ToString + " registros)"

                intPosicion = XdtMoneda.ValueField("nStbMonedaID")
                MostrarDatos()

                'Ubicar la selección en la posición original
                XdtMoneda.SetCurrentByID("nStbMonedaID", intPosicion)
                Me.grdMonedas.Row = XdtMoneda.BindingSource.Position

            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            If Seg.HasPermission("AgregarMoneda") = False Then  'Habilita
                Me.TbMoneda.Items("toolAgregar").Enabled = False
            Else  'Deshabilita
                Me.TbMoneda.Items("toolAgregar").Enabled = True
            End If

            If Seg.HasPermission("EditarMoneda") = False Then  'Habilita
                Me.TbMoneda.Items("toolModificar").Enabled = False
            Else  'Deshabilita
                Me.TbMoneda.Items("toolModificar").Enabled = True
            End If

            If Seg.HasPermission("EliminarMoneda") = False Then  'Habilita
                Me.TbMoneda.Items("toolEliminar").Enabled = False
            Else  'Deshabilita
                Me.TbMoneda.Items("toolEliminar").Enabled = True
            End If

            If Seg.HasPermission("ImprimirMoneda") Then  'Habilita
                Me.TbMoneda.Items("toolImprimir").Enabled = True
            Else  'Deshabilita
                Me.TbMoneda.Items("toolImprimir").Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub toolAyuda_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAyuda.Click
        LlamaAyuda()
    End Sub
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '---------------------------------------------------------------------------------------------------------
    ' Implementado por :    Cristhiam Jesús Mercado Obando
    ' Fecha            :    21/11/2006
    ' Solution Name:        prjSMUSURA0
    ' Project Name:         prjSMUSURA0
    ' Project Item Name:    FrmSteParametroMoneda.vb
    'Descripción      :    Permite Imprimir.
    '----------------------------------------------------------------------------------------------------------
    Private Sub LLamaImprimir()
        Try
            Dim ObjFrmSteParametroReporte As New frmStbParametroMoneda
            ObjFrmSteParametroReporte.NomRep = 1

            'ObjFrmSteParametroReporte.ModoFrm = "IMPRIMIR"
            ObjFrmSteParametroReporte.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub grdMonedas_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdMonedas.DoubleClick
        Try
            If Me.grdMonedas.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("EditarMoneda") Then
                LLamaModificarDatos()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub grdMonedas_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdMonedas.Error
        Control_Error(e.Exception)
    End Sub
    Private Sub grdMonedas_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdMonedas.Filter
        Try
            XdtMoneda.FilterLocal(e.Condition)
            Me.grdMonedas.Caption = "Listado de Tipos de Moneda (" + Me.grdMonedas.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click

    End Sub
End Class
