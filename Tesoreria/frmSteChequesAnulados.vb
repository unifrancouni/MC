' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                22/03/2010
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteChequesAnulados.vb
' Descripción:          Este formulario muestra Listado de Cheques Anulados
'                       y no registrados dentro de los Comprobantes.
'-------------------------------------------------------------------------
Public Class frmSteChequesAnulados

    '- Declaración de Variables 
    Dim XdsChequeAnulado As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       frmSteChequesAnulados_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteChequesAnulados_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsChequeAnulado.Close()
            XdsChequeAnulado = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       frmSteChequesAnulados_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteChequesAnulados_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            'Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))

            InicializaVariables()
            CargarCheques()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       CargarCheques
    ' Descripción:          Este procedimiento permite cargar los datos de
    '                       Cheques en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCheques()
        Try
            Dim Strsql As String
            Strsql = " Select a.nSteChequeAnuladoID, a.nSteCuentaBancariaID, a.nNumeroCheque, " & _
                     "        a.sNumeroCuenta , a.dFechaCheque, a.Programa, a.sObservaciones " & _
                     " From vwSteChequesAnulados a " & _
                     " WHERE (a.dFechaCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                     " Order by a.sNumeroCuenta, a.nNumeroCheque, a.dFechaCheque"
            If XdsChequeAnulado.ExistTable("Cheque") Then
                XdsChequeAnulado("Cheque").ExecuteSql(Strsql)
            Else
                XdsChequeAnulado.NewTable(Strsql, "Cheque")
                XdsChequeAnulado("Cheque").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.grdCheques.DataSource = XdsChequeAnulado("Cheque").Source

            'Actualizando el caption de los GRIDS:
            Me.grdCheques.Caption = " Listado de Cheques Anulados (" + Me.grdCheques.RowCount.ToString + " registros)"
            FormatoCheque()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       FormatoCheque
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre Cheques en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCheque()
        Try

            'Configuracion del Grid: 
            Me.grdCheques.Splits(0).DisplayColumns("nSteChequeAnuladoID").Visible = False
            Me.grdCheques.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            Me.grdCheques.Splits(0).DisplayColumns("nNumeroCheque").Width = 100
            Me.grdCheques.Splits(0).DisplayColumns("sNumeroCuenta").Width = 250
            Me.grdCheques.Splits(0).DisplayColumns("dFechaCheque").Width = 100
            Me.grdCheques.Splits(0).DisplayColumns("Programa").Width = 150
            Me.grdCheques.Splits(0).DisplayColumns("sObservaciones").Width = 180

            Me.grdCheques.Columns("nNumeroCheque").Caption = "Número Cheque"
            Me.grdCheques.Columns("sNumeroCuenta").Caption = "Cuenta Bancaria"
            Me.grdCheques.Columns("dFechaCheque").Caption = "Fecha"
            Me.grdCheques.Columns("Programa").Caption = "Nombre del Programa"
            Me.grdCheques.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdCheques.Splits(0).DisplayColumns("dFechaCheque").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCheques.Columns("dFechaCheque").NumberFormat = "dd/MM/yyyy"

            Me.grdCheques.Splits(0).DisplayColumns("nNumeroCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCheques.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCheques.Splits(0).DisplayColumns("dFechaCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCheques.Splits(0).DisplayColumns("Programa").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCheques.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Inicializa DataSet:
            XdsChequeAnulado = New BOSistema.Win.XDataSet
            '-- Limpiar Grid, estructura y Datos:
            Me.grdCheques.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       tbCheque_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip.
    '-------------------------------------------------------------------------
    Private Sub tbCheque_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCheque.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCheque()
            Case "toolModificar"
                LlamaModificarCheque()
            Case "toolEliminar"
                LlamaEliminarCheque()
            Case "toolEliminarRango"
                LlamaEliminarRangos()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolRefrescar"
                'Fechas de Corte Validas:
                If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                'Fecha de Corte no mayor a la de Inicio:
                If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                    Me.cdeFechaD.Focus()
                    Exit Sub
                End If

                InicializaVariables()
                CargarCheques()

            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	22/03/2010
    ' Procedure name	:	LlamaImprimir
    ' Description		:	Este procedimiento permite imprimir Listado de Cheques Anulados
    '                       para el rango de fechas de corte indicadas por el Usuario. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdCheques.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaD.Value, "dd/MM/yyyy") & " Al " & Format(cdeFechaH.Value, "dd/MM/yyyy") & " '"
            frmVisor.NombreReporte = "RepSteTE43.rpt"
            frmVisor.Text = "Listado de Cheques Anulados"
            frmVisor.SQLQuery = " Select * From vwSteChequesAnulados " & _
                                " Where (dFechaCheque BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
                                " Order by nSteCuentaBancariaId, nNumeroCheque, dFechaCheque"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       LlamaAgregarCheque
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditChequeAnulado.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCheque()
        Dim ObjFrmSteEditCheque As New frmSteEditChequeAnulado
        Try
            ObjFrmSteEditCheque.ModoFrm = "ADD"
            ObjFrmSteEditCheque.ShowDialog()

            If ObjFrmSteEditCheque.IdCheque <> 0 Then
                CargarCheques()
                XdsChequeAnulado("Cheque").SetCurrentByID("nSteChequeAnuladoID", ObjFrmSteEditCheque.IdCheque)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCheque.Close()
            ObjFrmSteEditCheque = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       LlamaModificarCheque
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditChequeAnulado para Modificar.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCheque()
        Dim ObjFrmSteEditCheque As New frmSteEditChequeAnulado
        Try
            Dim StrSql As String
            'Imposible si no existen registros:
            If Me.grdCheques.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditCheque.ModoFrm = "UPD"
            ObjFrmSteEditCheque.IdCheque = XdsChequeAnulado("Cheque").ValueField("nSteChequeAnuladoID")
            ObjFrmSteEditCheque.ShowDialog()

            If ObjFrmSteEditCheque.IdCheque <> 0 Then

                InicializaVariables()
                CargarCheques()
                XdsChequeAnulado("Cheque").SetCurrentByID("nSteChequeAnuladoID", ObjFrmSteEditCheque.IdCheque)
                Me.grdCheques.Row = XdsChequeAnulado("Cheque").BindingSource.Position
                'Almacena pista de auditoria: 
                StrSql = "Modificación Cheque Anulado. Código: " & XdsChequeAnulado("Cheque").ValueField("nNumeroCheque")
                Call GuardarAuditoria(2, 25, StrSql)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCheque.Close()
            ObjFrmSteEditCheque = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       LlamaEliminarRangos
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Cheque existente dentro de un Rango.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarRangos()
        Dim ObjFrmSteEditCheques As New frmSteEditChequeAnulado
        Try

            'Si no existen registros:
            If Me.grdCheques.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSteEditCheques.ModoFrm = "DEL"
            ObjFrmSteEditCheques.IdCheque = XdsChequeAnulado("Cheque").ValueField("nSteChequeAnuladoID")
            ObjFrmSteEditCheques.ShowDialog()

            'InicializaVariables()
            CargarCheques()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCheques.Close()
            ObjFrmSteEditCheques = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       LlamaEliminarCheque
    ' Descripción:          Este procedimiento permite eliminar un registro
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCheque()
        Dim XdtCheque As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            'Imposible si no existen Registros:
            If Me.grdCheques.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Eliminación:
            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                StrSql = "Eliminación de Cheque Anulado Código: " & XdsChequeAnulado("Cheque").ValueField("sNumeroCuenta") & XdsChequeAnulado("Cheque").ValueField("nNumeroCheque")
                XdtCheque.ExecuteSqlNotTable("Delete From SteChequeAnulado Where nSteChequeAnuladoID =" & XdsChequeAnulado("Cheque").ValueField("nSteChequeAnuladoID"))
                CargarCheques()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena pista de auditoria:
                Call GuardarAuditoria(3, 25, StrSql)
                Me.grdCheques.Caption = "Listado de Cheques Anulados (" + Me.grdCheques.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtCheque.Close()
            XdtCheque = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción.
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
    ' Fecha:                22/03/2010
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
    ' Fecha:                22/03/2010
    ' Procedure Name:       grdCheques_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un Cheque, al hacer doble click sobre el
    '                       registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCheques_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCheques.DoubleClick
        Try
            If Seg.HasPermission("ModificarChequeAnulado") Then
                LlamaModificarCheque()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdCheques_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCheques.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       grdCheques_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCheques_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCheques.Filter
        Try
            XdsChequeAnulado("Cheque").FilterLocal(e.Condition)
            Me.grdCheques.Caption = " Listado de Cheques Anulados (" + Me.grdCheques.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                22/03/2010
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'MantChequeAnulado - frmMantChequeAnulado:
            'Agregar:
            If Seg.HasPermission("AgregarChequeAnulado") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarChequeAnulado") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar:
            If Seg.HasPermission("EliminarChequeAnulado") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Eliminar Rango:
            If Seg.HasPermission("EliminarChequeAnulado") Then
                Me.toolEliminarRango.Enabled = True
            Else
                Me.toolEliminarRango.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirListadoChequesAnuladosTE43") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolAgregar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolAgregar.Click

    End Sub
End Class