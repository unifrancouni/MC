Imports System.Text

Public Class frmSclSeleccionaActividadEconomica

    '- Declaración de Variables 
    Dim XdtActividades As BOSistema.Win.XDataSet.xDataTable
    Private Const CATALOGO_ACTIVIDADECONOMICA As Integer = 10
    Private CantidadDeActividadesEconomicas As Int16 = 0

    Private _ActividadesSeleccionadas As New List(Of Int32)

    Public ReadOnly Property ActividadesSeleccionadas() As List(Of Int32)
        Get
            Return _ActividadesSeleccionadas
        End Get
    End Property




    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                09/03/2012
    ' Procedure Name:       ActividadEconomicaBind
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub ActividadEconomicaBind()
        Try
            XdtActividades = New BOSistema.Win.XDataSet.xDataTable

            'Limpiar los Grids (estructura y Datos).
            Me.grdActividadEconomica.ClearFields()
            Dim SQLQUERY As New StringBuilder
            SQLQUERY.AppendFormat(" exec spSclObtenerValorCatalogo {0}", CATALOGO_ACTIVIDADECONOMICA)
            'Ejecutamos la consulta
            XdtActividades.ExecuteSql(SQLQUERY.ToString())

            If CantidadDeActividadesEconomicas = 0 Then
                CantidadDeActividadesEconomicas = XdtActividades.Table.Rows.Count
            End If


            'Asignamos el origen de datos al grid
            Me.grdActividadEconomica.DataSource = XdtActividades.Source
            Me.FormatiarGrid()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                09/03/2012
    ' Procedure Name:       FormatiarGrid
    ' Descripción:          Este procedimiento permite dar estilo y comportamiento al grid.
    '-------------------------------------------------------------------------
    Private Sub FormatiarGrid()
        Try

            'Ocultar o Mostrar campos
            Me.grdActividadEconomica.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sCodigoInterno").Visible = True
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sDescripcion").Visible = True
            Me.grdActividadEconomica.Splits(0).DisplayColumns("Seleccionado").Visible = True

            'Establecer ancho de columnas visibles al usuario:
            Me.grdActividadEconomica.Splits(0).DisplayColumns("nStbValorCatalogoID").Width = 50
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sCodigoInterno").Width = 50
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sDescripcion").Width = 300
            Me.grdActividadEconomica.Splits(0).DisplayColumns("Seleccionado").Width = 50

            'Ubicar Nombre de los Campos:
            Me.grdActividadEconomica.Columns("sCodigoInterno").Caption = "Código"
            Me.grdActividadEconomica.Columns("sDescripcion").Caption = "Descripción"
            Me.grdActividadEconomica.Columns("Seleccionado").Caption = "Mostrar"
            Me.grdActividadEconomica.Columns("Seleccionado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            'Alineación:
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sDescripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Near
            Me.grdActividadEconomica.Splits(0).DisplayColumns("Seleccionado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdActividadEconomica.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdActividadEconomica.Splits(0).DisplayColumns("Seleccionado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Comportamiento
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sCodigoInterno").Style.Locked = True
            Me.grdActividadEconomica.Splits(0).DisplayColumns("sDescripcion").Style.Locked = True
            Me.grdActividadEconomica.Splits(0).DisplayColumns("Seleccionado").Style.Locked = False

            'CaptionGrid
            Me.grdActividadEconomica.Caption = " Listado de Actividades Económicas (" + Me.grdActividadEconomica.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Eventos
    Private Sub frmSclSeleccionaActividadEconomica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI

        Try
            '-- Asignar el tema de Color a utilizarse:
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            ActividadEconomicaBind()

            Me.chkMarcar.Checked = True

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub


    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Josué Herrera
    ' Fecha:                09/03/2012
    ' Evento:               grdActividadEconomica_Filter
    ' Descripción:          Filtra el catalogo de actividades económicas.
    '-------------------------------------------------------------------------
    Private Sub grdActividadEconomica_Filter(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdActividadEconomica.Filter
        Try
            Me.XdtActividades.FilterLocal(e.Condition)
            'Se invocá para refrescar el count de registros:
            Me.grdActividadEconomica.Caption = " Listado de Actividades Económicas (" + Me.grdActividadEconomica.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkMarcar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMarcar.CheckedChanged
        If chkMarcar.Checked Then
            Me.chkDesmarcar.Checked = False
            SelectOrNotSelect(XdtActividades, True)
        End If

    End Sub

    Private Sub SelectOrNotSelect(ByRef XDT As BOSistema.Win.XDataSet.xDataTable, ByVal value As Boolean)

        For Each row As Data.DataRow In XDT.Table.Rows
            row("Seleccionado") = value
        Next

        Me.grdActividadEconomica.DataSource = XDT.Source

    End Sub

    Private Sub chkDesmarcar_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkDesmarcar.CheckedChanged
        If chkDesmarcar.Checked Then
            Me.chkMarcar.Checked = False
        End If
        SelectOrNotSelect(XdtActividades, False)
    End Sub

    Private Sub cmdSeleccionar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSeleccionar.Click
        Try
            'Si ninguna está marcada no preguntar
            ' borrar la lista de seleccionados
            If Me.chkDesmarcar.Checked Then
                Me.ActividadesSeleccionadas.Clear()
            Else
                Me.ObtenerListaDeActividadesEconomicas()
            End If
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "SMUSURA0-[Error]: ")
        Finally
            XdtActividades.Close()
            XdtActividades = Nothing
            Me.Close()
        End Try
    End Sub

    Private Sub ObtenerListaDeActividadesEconomicas()
        'Limpiamos la lista
        _ActividadesSeleccionadas.Clear()

        For Each actividad As DataRow In XdtActividades.Table.Rows

            If Convert.ToBoolean(actividad("Seleccionado")) Then
                _ActividadesSeleccionadas.Add(Convert.ToInt32(actividad("sCodigoInterno")))
            End If

        Next
    End Sub
   
    Private Sub grdActividadEconomica_AfterColEdit(ByVal sender As System.Object, ByVal e As C1.Win.C1TrueDBGrid.ColEventArgs) Handles grdActividadEconomica.AfterColEdit
        Me.ObtenerListaDeActividadesEconomicas()

        Me.chkMarcar.Checked = Not (Me.ActividadesSeleccionadas.Count <> Me.CantidadDeActividadesEconomicas)

        Me.chkDesmarcar.Checked = Not (Me.ActividadesSeleccionadas.Count > 0)


    End Sub
End Class