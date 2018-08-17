' -----------------------------------------------------------------------------------------
' Author		    		:	
' Date			    		:	09/08/2006
' Procedure name		   	:	FrmSprFuenteF
' Description			   	:	Este formulario referencia al caso de uso SprFuentesFinanciamiento
' -----------------------------------------------------------------------------------------
Public Class frmScnFuenteF

    '- Declaración de Variables 

    Dim XdtFuentesF As BOSistema.Win.XDataSet.xDataTable

    Private Sub frmSprFuenteF_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFuentesF.Close()
            XdtFuentesF = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSprFuenteF_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Dim ObjGUI As New GUI.ClsGUI

        Try

            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargaFuenteF()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09/08/2006
    ' Procedure name		   	:	InicializaVariables
    ' Description			   	:	Este Procediemiento Permite inicializar las variables en el grid.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            'Obtener los Datos de la Fuente de Financiamiento
            XdtFuentesF = New BOSistema.Win.XDataSet.xDataTable

            'Limpia Grid Estructura y Datos
            Me.grdFuenteF.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	09/08/2006
    ' Procedure name		   	:	CargaFuenteF()
    ' Description			   	:	1.- Permite cargar los datos al Grid
    ' Description			   	:	2.- Configurar formato a los datos sobre Fuentes de Financiamiento en el Grib 
    '--------------------------------------------------------------------------------------
    Private Sub CargaFuenteF()

        Try
            Dim Strsql As String

            Strsql = "Select nScnFuenteFinanciamientoID,sCodigo,sNombre,sSiglas,nActiva,nFondoPresupuestario " & _
                     " From ScnFuenteFinanciamiento " & _
                     " Order By sCodigo "

            XdtFuentesF.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdFuenteF.DataSource = XdtFuentesF.Source

            'Actualizando el caption de los GRIDS
            Me.grdFuenteF.Caption = "Listado de Fuentes de Financiamiento (" + Me.grdFuenteF.RowCount.ToString + " registros )"

            '2.- Configuracion del Grib en Fuentes de Financiamiento

            Me.grdFuenteF.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            Me.grdFuenteF.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFuenteF.Splits(0).DisplayColumns("nActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFuenteF.Columns("nActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdFuenteF.Splits(0).DisplayColumns("nFondoPresupuestario").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFuenteF.Columns("nFondoPresupuestario").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdFuenteF.Splits(0).DisplayColumns("sNombre").Width = 450
            Me.grdFuenteF.Splits(0).DisplayColumns("sSiglas").Width = 100
            Me.grdFuenteF.Splits(0).DisplayColumns("nActiva").Width = 50
            Me.grdFuenteF.Splits(0).DisplayColumns("sCodigo").Width = 100
            Me.grdFuenteF.Splits(0).DisplayColumns("nFondoPresupuestario").Width = 100

            Me.grdFuenteF.Columns("sCodigo").Caption = "Código"
            Me.grdFuenteF.Columns("sNombre").Caption = "Nombre"
            Me.grdFuenteF.Columns("sSiglas").Caption = "Siglas"
            Me.grdFuenteF.Columns("nActiva").Caption = "Activa"
            Me.grdFuenteF.Columns("nFondoPresupuestario").Caption = "Fondo Presupuestario"

            Me.grdFuenteF.Splits(0).DisplayColumns("nActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFuenteF.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFuenteF.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFuenteF.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFuenteF.Splits(0).DisplayColumns("nFondoPresupuestario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            '*********************** Menú Catalogos *********************

            'Opción Agregar
            If Seg.HasPermission("AgregarFuenteFinanciamiento") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Opción Modificar
            If Seg.HasPermission("ModificarFuenteFinanciamiento") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Opción Eliminar
            If Seg.HasPermission("EliminarFuenteFinanciamiento") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Opcion Imprimir
            If Seg.HasPermission("ImprimirFuenteFinanciamiento") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdFuenteF_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFuenteF.DoubleClick
        Try
            If Seg.HasPermission("ModificarFuenteFinanciamiento") Then
                ModificarFuentesF()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub grdFuenteF_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFuenteF.Filter
        Try
            XdtFuentesF.FilterLocal(e.Condition)
            Me.grdFuenteF.Caption = " Listado de Fuentes de Financiamiento (" + Me.grdFuenteF.RowCount.ToString + " registros )"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                
    ' Fecha:                16/08/2006
    ' Procedure Name:       AgregarFuentesF
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSprEditFuenteF para Agregar una nueva Fuente de Financiamiento.
    ' ------------------------------------------------------------------------
    Private Sub AgregarFuentesF()
        Dim ObjfrmEditFuenteF As New frmScnEditFuenteF
        Try
            ObjfrmEditFuenteF.ModoFrm = "ADD"
            ObjfrmEditFuenteF.ShowDialog()

            If ObjfrmEditFuenteF.FuenteFinanID <> 0 Then
                CargaFuenteF()
                XdtFuentesF.SetCurrentByID("nScnFuenteFinanciamientoID", ObjfrmEditFuenteF.FuenteFinanID)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmEditFuenteF.Close()
            ObjfrmEditFuenteF = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	21/08/2006
    ' Procedure name	:	ModificarFuentesF
    ' Description		:	Este procedimiento permite modificar una
    '                   :   Fuente de Financiamineto
    ' -----------------------------------------------------------------------------------------
    Private Sub ModificarFuentesF()
        Dim XdtCatalogoContable As New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
        Dim ObjfrmEditFuenteF As New frmScnEditFuenteF
        Try
            If Me.grdFuenteF.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            XdtCatalogoContable.Filter = " nScnFuenteFinanciamientoID = " & XdtFuentesF.ValueField("nScnFuenteFinanciamientoID")
            XdtCatalogoContable.Retrieve()

            If XdtCatalogoContable.Count > 0 Then
                MsgBox("No es posible Modificar. Existen Cuentas Contables asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjfrmEditFuenteF.ModoFrm = "UPD"
            ObjfrmEditFuenteF.FuenteFinanID = XdtFuentesF("nScnFuenteFinanciamientoID")
            ObjfrmEditFuenteF.ShowDialog()

            If ObjfrmEditFuenteF.FuenteFinanID <> 0 Then
                CargaFuenteF()
                XdtFuentesF.SetCurrentByID("nScnFuenteFinanciamientoID", ObjfrmEditFuenteF.FuenteFinanID)
                Me.grdFuenteF.Row = XdtFuentesF.Source.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmEditFuenteF.Close()
            ObjfrmEditFuenteF = Nothing

            XdtCatalogoContable.Close()
            XdtCatalogoContable = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	21/08/2006
    ' Procedure name		   	:	EliminarFuentesF
    ' Description			   	:	Permite eliminar una Fuente de Financiamiento
    ' -----------------------------------------------------------------------------------------
    Private Sub EliminarFuentesF()
        Try
            If Me.grdFuenteF.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then
                XdtFuentesF.ExecuteSqlNotTable("Delete From ScnFuenteFinanciamiento where nScnFuenteFinanciamientoID=" & XdtFuentesF("nScnFuenteFinanciamientoID"))
                CargaFuenteF()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       tbFuenteF_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCargo.
    '-------------------------------------------------------------------------
    Private Sub tbFuenteF_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFuenteF.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                AgregarFuentesF()
            Case "toolModificar"
                ModificarFuentesF()
            Case "toolEliminar"
                EliminarFuentesF()
            Case "toolRefrescar"
                InicializaVariables()
                CargaFuenteF()
            Case "toolImprimir"
                ImprimirFuenteF()
            Case "toolCerrar"
                LlamaCerrar()
            Case "ToolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	05/07/2007
    ' Procedure name	:	Imprimir
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de 
    '                   :   Cargos
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirFuenteF()
        Dim frmVisor As New frmCRVisorReporte
        Try
            If Me.grdFuenteF.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Parametros("@gfg") = ""
            frmVisor.NombreReporte = "RepScnCN2.rpt"
            frmVisor.Text = "Reporte de Fuente de Financiamiento"
            'frmVisor.RegistrosSeleccion = "{ScnEstructuraContable.nNivel} = 1"
            'frmVisor.SQLQuery = "Select * From ScnEstructuraContable Where nNivel = 1"
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
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
    ' Autor:                Ing. Azucena Suárez Tijerino.
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
End Class
