Public Class frmScnProcesoCDR
    Public ColorVentana As String
    Public nScnPeriodo As Integer
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim XcDatos As New BOSistema.Win.XComando
    Dim a As Integer

    Private Sub frmScnProcesoCDR_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, ColorVentana)
            Inicializar()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub Inicializar()
        cdeFechaInicial.Value = Now()
        CdeFechaFinal.Value = Now()
        XdsCombos = New BOSistema.Win.XDataSet
    End Sub

    Private Sub tbSolicitud_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbProcesoCDR.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolRefrescar"
                CargarListado()
            Case "toolGenerarCDR"
                'Llama al job spJobGeneracionCDR por si no se ejecutó
                LlamaJobManual()
            Case "toolAsignar"
                'Cambia estado a Revisado
                CambiaEstado(2)
            Case "toolAutorizar"
                'Cambia estado a Autorizado
                CambiaEstado(3)
            Case "toolImprimirCDR"
                'Imprimir listado de socias CDR
                Imprimir()
            Case "toolSalir"
                Me.Close()
        End Select
    End Sub

    Private Sub Imprimir()

    End Sub

    Private Sub CambiaEstado(ByVal estado As Integer)
        Dim cmd As New BOSistema.Win.XComando
        Dim StrSql As String = ""
        Try
            Dim periodo As Integer = 1
            periodo = XdsCombos("Periodo").Current.Item("nScnPeriodoContableID")
            StrSql = " spCambiarEstadoPeriodoCDR " & periodo & ", " & estado
            cmd.ExecuteNonQuery(StrSql)
            CargarListado()
            If estado = 2 Then
                MsgBox("El estado de la generación se ha marcado como REVISADO.", vbInformation)
            ElseIf estado = 3
                MsgBox("El estado de la generación se ha marcado como AUTORIZADO.", vbInformation)
            End If
        Catch ex As Exception
            MsgBox("No se logró cambiar el estado de dicha generación.", vbCritical)
        End Try
    End Sub

    Private Sub LlamaJobManual()
        Dim cmd As New BOSistema.Win.XComando
        Dim StrSql As String = ""
        Try
            StrSql = " spJobGeneracionCDR " & InfoSistema.IDCuenta
            cmd.ExecuteNonQuery(StrSql)
            Dim periodo As Integer = 1
            periodo = XdsCombos("Periodo").Current.Item("nScnPeriodoContableID")
            StrSql = " spGrabarGeneracionCDR " & InfoSistema.IDCuenta & ", " & periodo
            cmd.ExecuteNonQuery(StrSql)
            CargarListado()
            MsgBox("El listado de socias en CDR se ha generado correctamente.", vbInformation)
        Catch ex As Exception
            MsgBox("No se logró generar CDR debido a un error interno en el sistema.", vbCritical)
        End Try
    End Sub

    Private Sub CargarListado()
        Try
            Dim Strsql As String


            Strsql = "select  nScnPeriodoContableID, nScnPeriodoCdrID, Periodo, [Fecha Corte], Estado, Asignado, Usuario from vwScnListadoPeriodosCDR where CAST(SUBSTRING(Periodo, LEN(Periodo)-4, 5) AS INT)>=2016 ORDER BY Asignado Desc, nScnPeriodoCdrID Asc "

            If XdsCombos.ExistTable("Periodo") Then
                XdsCombos("Periodo").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Periodo")
                XdsCombos("Periodo").Retrieve()
            End If


            'Asignando a las fuentes de datos
            Me.grdListadoGeneracionesCDR.DataSource = XdsCombos("Periodo").Source

            Me.grdListadoGeneracionesCDR.Splits(0).DisplayColumns("nScnPeriodoContableID").Visible = False
            Me.grdListadoGeneracionesCDR.Splits(0).DisplayColumns("nScnPeriodoCdrID").Visible = False

            'Configurar el combo
            'Me.grdListadoGeneracionesCDR.Splits(0).DisplayColumns("Periodo").Width = 150

            'Me.grdListadoGeneracionesCDR.Columns("periodo").Caption = "Año"
            'Me.grdListadoGeneracionesCDR.Columns("nScnPeriodoContableID").Caption = "Código"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


End Class