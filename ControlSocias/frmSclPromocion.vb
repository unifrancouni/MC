Imports BOSistema.Win
Imports C1.Win.C1TrueDBGrid

Public Class frmSclPromocion

    Private xds As XDataSet
    Dim IntDepartamento As Integer
    Dim IntPermiteConsultar As Integer

    Private Sub frmSclPromocion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            InicializaVariables()

            CargarDepartamento()

            CargarPromocion()
            FormatoPromocion()

            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub Seguridad()

        Seg.RefreshPermissions()

        'Poder cerrar el informe de promoción y no modificarlo más
        If Seg.HasPermission("CerrarPromocion") Then
            toolCerrar.Enabled = True
        Else
            toolCerrar.Enabled = False
        End If

        'Poder cerrar el informe de promoción y no modificarlo más
        If Seg.HasPermission("ImprimirPromocion") Then
            toolImprimir.Enabled = True
        Else
            toolImprimir.Enabled = False
        End If

    End Sub

    Private Sub InicializaVariables()
        Try
            xds = New XDataSet

            Dim strSQL As String
            Dim cmd As New XComando
            strSQL = "SELECT nStbDepartamentoID FROM vwStbDatosDelegacion WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntDepartamento = cmd.ExecuteScalar(strSQL)

            strSQL = " SELECT nAccesoTotalLectura,nAccesoTotalEdicion " &
                     " FROM StbDelegacionPrograma " &
                     " WHERE nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion

            IntPermiteConsultar = cmd.ExecuteScalar(strSQL)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                         " From StbDepartamento a " &
                         " Where a.nStbDepartamentoID = " & Me.IntDepartamento &
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " &
                         " From StbDepartamento a " &
                         " Order by a.sCodigo"
            End If



            If xds.ExistTable("Departamento") Then
                xds("Departamento").ExecuteSql(Strsql)
            Else
                xds.NewTable(Strsql, "Departamento")
                xds("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = xds("Departamento").Source
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            '          Me.cboReporte.Splits(0).DisplayColumns(0).Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            '           Me.cboReporte.Splits(0).DisplayColumns(0).Width = 238

            '            Me.cboReporte.Splits(0).DisplayColumns(0).HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General


            'Ubicarlo en el primer registro
            If Me.cboDepartamento.ListCount > 0 Then
                '    XdsCombos("Departamento").AddRow()
                '    XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                '    XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -1
                '    XdsCombos("Departamento").ValueField("Orden") = 0
                '    XdsCombos("Departamento").UpdateLocal()
                '    XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.cboDepartamento.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Overloads Sub CargarPromocion()

        Dim strSQL As String = ""

        strSQL = String.Format("Exec [spSclListarPromocion] {0}, '2017-01-01', '2017-01-01'", InfoSistema.IDDelegacion)

        Me.Cursor = Cursors.WaitCursor

        If Not xds.ExistTable("Promocion") Then
            xds.NewTable(strSQL, "Promocion")
            xds("Promocion").Retrieve()
        Else
            xds("Promocion").ExecuteSql(strSQL)
        End If

        Me.grdPromocion.DataSource = xds("Promocion").Source
        Me.grdPromocion.Columns(0).ValueItems.Presentation = PresentationEnum.CheckBox

        Me.Cursor = Cursors.Default

    End Sub

    Private Overloads Sub CargarPromocion(ByVal dFechaInicio As DateTime, ByVal dFechaFin As DateTime)

        Dim strSQL As String = ""

        strSQL = String.Format("Exec [spSclListarPromocion] {0}, '{1}', '{2}' ", xds("Departamento").ValueField("nStbDepartamentoID"), dFechaInicio.ToString("yyyy-MM-dd"), dFechaFin.ToString("yyyy-MM-dd"))

        Me.Cursor = Cursors.WaitCursor

        If Not xds.ExistTable("Promocion") Then
            xds.NewTable(strSQL, "Promocion")
            xds("Promocion").Retrieve()
        Else
            xds("Promocion").ExecuteSql(strSQL)
        End If

        Me.grdPromocion.DataSource = xds("Promocion").Source
        Me.grdPromocion.Columns(0).ValueItems.Presentation = PresentationEnum.CheckBox

        Me.Cursor = Cursors.Default

        toolRefrescar.Enabled = True

    End Sub

    Private Sub FormatoPromocion()
        Try

            Me.grdPromocion.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("nSclPromocionID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("nSrhPromotorID").Visible = False
            'Me.grdPromocion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("nStbEstadoPromocionID").Visible = False
            Me.grdPromocion.Splits(0).DisplayColumns("CodEstado").Visible = False
            'Me.grdPromocion.Splits(0).DisplayColumns("Estado").Visible = False


            Me.grdPromocion.Splits(0).DisplayColumns("dFechaPromocion").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("Estado").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("Departamento").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("Municipio").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("Distrito").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("Barrio").Width = 100

            Me.grdPromocion.Splits(0).DisplayColumns("nNoAsambleas").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("nNoCasas").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("nNoGrupos").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasNuevas").Width = 120
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasSubsecuentes").Width = 100
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasAI").Width = 130

            Me.grdPromocion.Splits(0).DisplayColumns("cNombresApellidos").Width = 300
            Me.grdPromocion.Splits(0).DisplayColumns("Selected").Width = 15


            Me.grdPromocion.Columns("dFechaPromocion").Caption = "Fecha de Visita"
            Me.grdPromocion.Columns("Estado").Caption = "Estado"
            Me.grdPromocion.Columns("Departamento").Caption = "Departamento"
            Me.grdPromocion.Columns("Municipio").Caption = "Municipio"
            Me.grdPromocion.Columns("Distrito").Caption = "Distrito"
            Me.grdPromocion.Columns("Barrio").Caption = "Barrio"
            Me.grdPromocion.Columns("nNoAsambleas").Caption = "N° de Asambleas"
            Me.grdPromocion.Columns("nNoGrupos").Caption = "N° de Grupos"
            Me.grdPromocion.Columns("nNoCasas").Caption = "N° de Casas"
            Me.grdPromocion.Columns("nNoSociasNuevas").Caption = "N° de Socias Nuevas"
            Me.grdPromocion.Columns("nNoSociasSubsecuentes").Caption = "N° de Socias Subs."
            Me.grdPromocion.Columns("nNoSociasAI").Caption = "N° de Mujeres asist. A.I"
            Me.grdPromocion.Columns("cNombresApellidos").Caption = "Promotor"
            Me.grdPromocion.Columns("Selected").Caption = ""


            Me.grdPromocion.Splits(0).DisplayColumns("dFechaPromocion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Estado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoAsambleas").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoCasas").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoGrupos").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasNuevas").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasSubsecuentes").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasAI").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Selected").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdPromocion.Splits(0).DisplayColumns("dFechaPromocion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Distrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoAsambleas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoCasas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoGrupos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasNuevas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasSubsecuentes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("nNoSociasAI").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("cNombresApellidos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPromocion.Splits(0).DisplayColumns("Selected").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdPromocion.Columns("dFechaPromocion").NumberFormat = "dd/MM/yyyy"

            Dim i As Integer
            For i = 0 To Me.grdPromocion.Splits(0).DisplayColumns.Count - 1
                If Me.grdPromocion.Splits(0).DisplayColumns(i).Name <> "" Then
                    Me.grdPromocion.Splits(0).DisplayColumns(i).Style.Locked = True
                End If
            Next

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Refrescar()
        If IsDate(cdeFechaInicio.Value) And IsDate(cdeFechaFin.Value) Then
            CargarPromocion(cdeFechaInicio.Value, cdeFechaFin.Value)
        End If
    End Sub

    Private Sub btnBuscar_Click(sender As Object, e As EventArgs) Handles btnBuscar.Click
        'Validar y Buscar

        If Not IsDate(cdeFechaInicio.Value) Or Not IsDate(cdeFechaFin.Value) Then
            MsgBox("Debe indicar las fechas de inicio y fin", vbCritical, "SMUSURA0")
            Exit Sub
        Else
            If cdeFechaInicio.Value > cdeFechaFin.Value Then
                MsgBox("La fecha de inicio debe ser menor o igual a la fecha de fin", vbCritical, "SMUSURA0")
                Exit Sub
            End If
        End If

        CargarPromocion(cdeFechaInicio.Value, cdeFechaFin.Value)
        FormatoPromocion()

        grpBuscar.Visible = False
        toolRefrescar.Enabled = True
    End Sub

    Private Sub chkSeleccion_CheckedChanged(sender As Object, e As EventArgs) Handles chkSeleccion.CheckedChanged
        If chkSeleccion.Checked Then
            For i = 0 To Me.grdPromocion.RowCount - 1
                Me.grdPromocion.Bookmark = i
                Me.grdPromocion.Columns("Selected").Value = 1
            Next
        Else
            For i = 0 To Me.grdPromocion.RowCount - 1
                Me.grdPromocion.Bookmark = i
                Me.grdPromocion.Columns("Selected").Value = 0
            Next
        End If
    End Sub

    Private Sub tbPromocion_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbPromocion.ItemClicked
        Try
            Select Case e.ClickedItem.Name
                Case "toolRefrescar"
                    Refrescar()
                Case "toolBuscar"
                    grpBuscar.Visible = True
                Case "toolAgregar"
                    AgregarEditarPromocion(True)
                Case "toolEditar"
                    AgregarEditarPromocion(False)
                Case "toolCerrar"
                    CerrarSeleccionados()
                Case "toolSalir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CerrarSeleccionados()

        Dim strSQL As String = ""
        Dim cmd As New XComando
        Dim existenRegistros As Boolean = False


        For i = 0 To Me.grdPromocion.RowCount - 1
            Me.grdPromocion.Bookmark = i

            If xds("Promocion").Current("Selected") = True Then
                existenRegistros = True

                strSQL = "Exec spSclCerrarPromocion " & Me.grdPromocion.Columns("nSclPromocionID").Value

                Try
                    cmd.ExecuteNonQuery(strSQL)
                Catch ex As Exception
                    Control_Error(ex)
                End Try

            End If

        Next

        If Not existenRegistros Then
            MsgBox("Ningún registro está seleccionado con check", vbExclamation, "SMUSURA0")
            Exit Sub
        End If

        MsgBox("Se han cerrado todos los registros seleccionados", vbInformation, "SMUSURA0")
        Refrescar()

    End Sub

    Private Sub AgregarEditarPromocion(ByVal add As Boolean)
        Dim frm As New frmSclEditPromocion

        If add Then

            Try

                Me.Cursor = Cursors.WaitCursor

                frm.intPromocionID = 0

                frm.ShowDialog()

                frm.BringToFront()

                Refrescar()

                Me.Cursor = Cursors.Default

            Catch ex As Exception
                Control_Error(ex)
            Finally
                frm = Nothing
            End Try

        Else

            Try

                Me.Cursor = Cursors.WaitCursor

                If grdPromocion.RowCount = 0 Then
                    MsgBox("No ha seleccionado ningún registro", vbCritical, "SMUSURA0")
                Else

                    If xds("Promocion").Current.Item("CodEstado").Equals("2") Then
                        MsgBox("No se puede editar un registro que ya está cerrado", vbCritical, "SMUSURA0")
                        Exit Sub
                    End If
                    frm.intPromocionID = xds("Promocion").Current.Item("nSclPromocionID")
                    Me.Cursor = Cursors.Default
                    frm.ShowDialog()
                    frm.BringToFront()
                    Refrescar()
                    xds("Promocion").SetCurrentByID("nSclPromocionID", frm.intPromocionID)
                    Me.grdPromocion.Row = xds("Promocion").BindingSource.Position
                End If

            Catch ex As Exception
                Control_Error(ex)
            Finally
                Me.Cursor = Cursors.Default
                frm = Nothing
            End Try

        End If



    End Sub

    Private Sub grdPromocion_DoubleClick(sender As Object, e As EventArgs) Handles grdPromocion.DoubleClick
        AgregarEditarPromocion(False)
    End Sub
End Class