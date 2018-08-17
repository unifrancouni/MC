Imports BOSistema.Win
Imports C1.Win.C1TrueDBGrid

Public Class frmSclSeguimientoVisitas

#Region "Efectos Visuales"
    Private Sub btnBack_MouseDown(sender As Object, e As MouseEventArgs) Handles btnBack.MouseDown
        btnBack.Image = My.Resources.back_2
    End Sub

    Private Sub btnBack_MouseUp(sender As Object, e As MouseEventArgs) Handles btnBack.MouseUp
        btnBack.Image = My.Resources.back_1
    End Sub

    Private Sub btnNext_MouseDown(sender As Object, e As MouseEventArgs) Handles btnNext.MouseDown
        btnNext.Image = My.Resources.next_2
    End Sub

    Private Sub btnNext_MouseUp(sender As Object, e As MouseEventArgs) Handles btnNext.MouseUp
        btnNext.Image = My.Resources.next_1
    End Sub

    Private Sub btnNext_MouseMove(sender As Object, e As EventArgs) Handles btnNext.MouseMove
        Me.Cursor = Cursors.Hand
        btnNext.Image = My.Resources.next_hv
    End Sub

    Private Sub btnNext_MouseLeave(sender As Object, e As EventArgs) Handles btnNext.MouseLeave
        Me.Cursor = Cursors.Default
        btnNext.Image = My.Resources.next_1
    End Sub

    Private Sub btnBack_MouseMove(sender As Object, e As EventArgs) Handles btnBack.MouseMove
        Me.Cursor = Cursors.Hand
        btnBack.Image = My.Resources.back_hv
    End Sub

    Private Sub btnBack_MouseLeave(sender As Object, e As EventArgs) Handles btnBack.MouseLeave
        Me.Cursor = Cursors.Default
        btnBack.Image = My.Resources.back_1
    End Sub

#End Region

#Region "Variables Locales"
    Dim XdtSocias As XDataSet.xDataTable
    Dim XdtVisitas As XDataSet.xDataTable
    Dim strSQL As String = ""
    Dim strSQL2 As String = ""
#End Region

    Private Sub frmSclSeguimientoVisitas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try

            '-- Asignar el tema de Color a
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            InicializaVariables()
            CargarSocias("")
            CargarVisitas("")

            'Seguridad()
            If Not Seg.HasPermission("mnuNoEncontradas") Then
                toolNoEncontrada.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub tbFicha_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Try
            Select Case e.ClickedItem.Name
                Case "toolBuscar"
                    LlamarParametros()
                Case "toolRefrescar"
                    CargarSocias(strSQL)
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub tbVisitas_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbVisitas.ItemClicked
        Try
            Select Case e.ClickedItem.Name
                Case "toolRefrescar2"
                    CargarVisitas(strSQL2)
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamarAgregarDetalle(ByVal intVisita As Integer, ByVal nModoGrabacion As Integer)
        Dim obj As New frmSclSeguimientoVisitaDetalle
        Dim strSQL As String = ""
        Dim cmd As New XComando

        Try
            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = Cursors.WaitCursor

            obj.intSeguimientoVisitaID = XdtVisitas.Current.Item("nSclSeguimientoVisitaID")
            obj.intNumeroVisita = intVisita

            obj.nModoGrabacion = nModoGrabacion

            obj.sNombreSocia = XdtVisitas.Current.Item("Socia")
            obj.sNumeroCedula = XdtVisitas.Current.Item("sNumeroCedula")
            obj.sGrupoSolidario = XdtVisitas.Current.Item("Grupo")
            obj.nNumeroCredito = XdtVisitas.Current.Item("CreditoNO")
            obj.sDireccionSocia = XdtVisitas.Current.Item("sDireccionSocia")
            obj.nMontoAprobado = XdtVisitas.Current.Item("nMontoCreditoAprobado")
            obj.nPlazoAprobado = XdtVisitas.Current.Item("nPLazoAprobado")

            strSQL = "SELECT ES.sCodigoInterno AS Existe
							FROM dbo.SclSeguimientoVisita INNER JOIN
							dbo.SclSeguimientoVisitaDetalle ON dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID = dbo.SclSeguimientoVisitaDetalle.nSclSeguimientoVisitaID
							INNER JOIN StbValorCatalogo ES ON ES.nStbValorCatalogoID=dbo.SclSeguimientoVisita.nStbEstadoSeguimientoID
							WHERE dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID=" & XdtVisitas.Current.Item("nSclSeguimientoVisitaID")


            Dim registros_asociados As Boolean = RegistrosAsociados(strSQL)


            Dim strSQL_1 As String = strSQL
            Dim strSQL_2 As String = "SELECT ES.sCodigoInterno AS Existe
							FROM dbo.SclSeguimientoVisita INNER JOIN
							dbo.SclSeguimientoVisitaDetalle ON dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID = dbo.SclSeguimientoVisitaDetalle.nSclSeguimientoVisitaID
							INNER JOIN StbValorCatalogo ES ON ES.nStbValorCatalogoID=dbo.SclSeguimientoVisita.nStbEstadoSeguimiento2ID
							WHERE dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID=" & XdtVisitas.Current.Item("nSclSeguimientoVisitaID")
            Dim strSQL_3 As String = "SELECT ES.sCodigoInterno AS Existe
							FROM dbo.SclSeguimientoVisita INNER JOIN
							dbo.SclSeguimientoVisitaDetalle ON dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID = dbo.SclSeguimientoVisitaDetalle.nSclSeguimientoVisitaID
							INNER JOIN StbValorCatalogo ES ON ES.nStbValorCatalogoID=dbo.SclSeguimientoVisita.nStbEstadoSeguimiento3ID
							WHERE dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID=" & XdtVisitas.Current.Item("nSclSeguimientoVisitaID")

            Dim SID As Integer = obj.intSeguimientoVisitaID

            'If RegistrosAsociados(strSQL) Then
            '    obj.ModoFrm = "UPD"
            '    Dim es As String = cmd.ExecuteScalar(strSQL)

            '    If nModoGrabacion = 2 Then 'Inactivo
            '        If es = "3" Then
            '            MsgBox("Va a modificar negocio que ya ha sido grabado como inactivo.", vbExclamation, "Alerta")
            '        ElseIf es = "2"
            '            MsgBox("Ya se han grabado visitas, no se puede inactivar.", vbCritical, "Alerta")
            '            GoTo Final
            '        ElseIf es = "4"
            '            MsgBox("Ya se ha marcado que no se encontró la socia, no se puede inactivar.", vbCritical, "Alerta")
            '            GoTo Final
            '        End If
            '    ElseIf nModoGrabacion = 3 'No encontrado
            '        If es = "4" Then
            '            MsgBox("Va a modificar negocio que ya ha sido grabado como No encontrado.", vbExclamation, "Alerta")
            '        ElseIf es = "2"
            '            MsgBox("Ya se han grabado visitas, no se puede cambiar.", vbCritical, "Alerta")
            '            GoTo Final
            '        ElseIf es = "3" Then
            '            MsgBox("Ya se ha registrado que el negocio de esta socia está inactivo.", vbCritical, "Error")
            '            GoTo Final
            '        End If
            '    ElseIf nModoGrabacion = 1 'Visita
            '        es = cmd.ExecuteScalar(strSQL)
            '        If es = "3" Then
            '            MsgBox("Ya se ha registrado que el negocio de esta socia está inactivo.", vbCritical, "Error")
            '            GoTo Final
            '        ElseIf es = "2"
            '            MsgBox("Va a modificar una visita a esta socia.", vbCritical, "Alerta")
            '            GoTo Final
            '        ElseIf es = "4"
            '            MsgBox("Ya se ha marcado que no se encontró la socia, no se puede inactivar.", vbCritical, "Alerta")
            '            GoTo Final
            '        End If
            '    End If
            'Else
            '    obj.ModoFrm = "ADD"
            '    If intVisita = 2 Or intVisita = 3 Then
            '        MsgBox("Debe tener al menos la primera visita registrada.", vbCritical, "Error")
            '        GoTo Final
            '    End If
            'End If

            If intVisita = 1 Then 'Únicamente en la primera visita se graba con modo ADD
                If nModoGrabacion = 1 Then 'Visita
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v1 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_1)), cmd.ExecuteScalar(strSQL_1), "-1")
                        If v1 <> "-1" And v1 <> Nothing Then
                            If v1 = "1" Then
                                'Es imposible este caso
                                MsgBox("Favor reportar este caso a informática. Seguimiento Visita Id: " & SID, vbCritical, "Alerta")
                                Exit Sub
                            ElseIf v1 = "2" Then
                                MsgBox("Va a modificar una visita a esta socia.", vbExclamation, "Alerta")
                            ElseIf v1 = "3" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita está inactivo.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v1 = "4" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita no se encontró.", vbCritical, "Error")
                                Exit Sub
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        obj.ShowDialog()
                        'MsgBox("Para grabr la N visita, debe tener al menos la primera visita registrada.", vbCritical, "Error")
                    End If
                ElseIf nModoGrabacion = 2 Then 'Inactivo
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v1 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_1)), cmd.ExecuteScalar(strSQL_1), "-1")
                        If v1 <> "-1" And v1 <> Nothing Then
                            If v1 = "1" Then
                                'Es imposible este caso
                                MsgBox("Favor reportar este caso a informática. Seguimiento Visita Id: " & SID, vbCritical, "Alerta")
                                Exit Sub
                            ElseIf v1 = "2" Then
                                MsgBox("Ya se ha registrado primera visita, no se puede inactivar.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v1 = "3" Then
                                MsgBox("Va a modificar el motivo de inactivación a esta socia.", vbExclamation, "Alerta")
                            ElseIf v1 = "4" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita no se encontró.", vbCritical, "Error")
                                Exit Sub
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        obj.ShowDialog()
                        'MsgBox("Para grabr la N visita, debe tener al menos la primera visita registrada.", vbCritical, "Error")
                    End If
                ElseIf nModoGrabacion = 3 Then 'No Encontrado
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v1 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_1)), cmd.ExecuteScalar(strSQL_1), "-1")
                        If v1 <> "-1" And v1 <> Nothing Then
                            If v1 = "1" Then
                                'Es imposible este caso
                                MsgBox("Favor reportar este caso a informática. Seguimiento Visita Id: " & SID, vbCritical, "Alerta")
                                Exit Sub
                            ElseIf v1 = "2" Then
                                MsgBox("Ya se ha registrado primera visita, no se puede cambiar.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v1 = "3" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita está inactivo.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v1 = "4" Then
                                MsgBox("Va a modificar las oservaciones de que no se encontró a esta socia.", vbExclamation, "Alerta")
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        obj.ShowDialog()
                        'MsgBox("Para grabr la N visita, debe tener al menos la primera visita registrada.", vbCritical, "Error")
                    End If
                End If
            ElseIf intVisita = 2 Then
                If nModoGrabacion = 1 Then 'Visita
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v1 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_1)), cmd.ExecuteScalar(strSQL_1), "-1")
                        Dim v2 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_2)), cmd.ExecuteScalar(strSQL_2), "-1")
                        If v1 <> "-1" And v2 <> "-1" And v1 <> Nothing And v2 <> Nothing Then
                            If v1 = "1" Then
                                MsgBox("Para grabar la segunda visita, antes debe grabar la primera.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "2" Then
                                MsgBox("Va a modificar una visita a esta socia.", vbExclamation, "Alerta")
                            ElseIf v2 = "3" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita está inactivo.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "4" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita no se encontró.", vbCritical, "Error")
                                Exit Sub
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        MsgBox("Para grabar la segunda visita, debe tener al menos la primera visita registrada.", vbCritical, "Error")
                        Exit Sub
                        'obj.ShowDialog()
                    End If
                ElseIf nModoGrabacion = 2 Then 'Inactivo
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v1 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_1)), cmd.ExecuteScalar(strSQL_1), "-1")
                        Dim v2 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_2)), cmd.ExecuteScalar(strSQL_2), "-1")
                        If v1 <> "-1" And v2 <> "-1" And v1 <> Nothing And v2 <> Nothing Then
                            If v1 = "1" Then
                                MsgBox("Para inactivar la segunda visita, antes debe registrar la primera.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "2" Then
                                MsgBox("Ya se ha registrado segunda visita, no se puede inactivar.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "3" Then
                                MsgBox("Va a modificar el motivo de inactivación a esta socia.", vbExclamation, "Alerta")
                            ElseIf v2 = "4" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita no se encontró.", vbCritical, "Error")
                                Exit Sub
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        MsgBox("Para inactivar la segunda visita, debe tener al menos la primera visita registrada.", vbCritical, "Error")
                        Exit Sub
                        'obj.ShowDialog()
                    End If
                ElseIf nModoGrabacion = 3 Then 'No Encontrado
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v1 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_1)), cmd.ExecuteScalar(strSQL_1), "-1")
                        Dim v2 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_2)), cmd.ExecuteScalar(strSQL_2), "-1")
                        If v1 <> "-1" And v2 <> "-1" And v1 <> Nothing And v2 <> Nothing Then
                            If v1 = "1" Then
                                MsgBox("Para marcar la segunda visita como No encontrada, antes debe registrar la primera.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "2" Then
                                MsgBox("Ya se ha registrado segunda visita, no se puede cambiar.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "3" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita está inactivo.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v2 = "4" Then
                                MsgBox("Va a modificar las oservaciones de que no se encontró a esta socia.", vbExclamation, "Alerta")
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        MsgBox("Para marcar la segunda visita como No encontrada, debe tener al menos la primera visita registrada.", vbCritical, "Error")
                        Exit Sub
                        'obj.ShowDialog()
                    End If
                End If
            ElseIf intVisita = 3 Then
                If nModoGrabacion = 1 Then 'Visita
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v2 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_2)), cmd.ExecuteScalar(strSQL_2), "-1")
                        Dim v3 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_3)), cmd.ExecuteScalar(strSQL_3), "-1")
                        If v2 <> "-1" And v3 <> "-1" And v2 <> Nothing And v3 <> Nothing Then
                            If v2 = "1" Then
                                MsgBox("Para grabar la tercera visita, antes debe grabar la segunda.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "2" Then
                                MsgBox("Va a modificar una visita a esta socia.", vbExclamation, "Alerta")
                            ElseIf v3 = "3" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita está inactivo.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "4" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita no se encontró.", vbCritical, "Error")
                                Exit Sub
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        MsgBox("Para grabar la tercera visita, debe tener al menos la segunda visita registrada.", vbCritical, "Error")
                        Exit Sub
                        'obj.ShowDialog()
                    End If
                ElseIf nModoGrabacion = 2 Then 'Inactivo
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v2 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_2)), cmd.ExecuteScalar(strSQL_2), "-1")
                        Dim v3 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_3)), cmd.ExecuteScalar(strSQL_3), "-1")
                        If v2 <> "-1" And v3 <> "-1" And v2 <> Nothing And v3 <> Nothing Then
                            If v2 = "1" Then
                                MsgBox("Para inactivar la tercera visita, antes debe registrar la segunda.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "2" Then
                                MsgBox("Ya se ha registrado tercera visita, no se puede inactivar.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "3" Then
                                MsgBox("Va a modificar el motivo de inactivación a esta socia.", vbExclamation, "Alerta")
                            ElseIf v3 = "4" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita no se encontró.", vbCritical, "Error")
                                Exit Sub
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        MsgBox("Para inactivar la tercera visita, debe tener al menos la segunda visita registrada.", vbCritical, "Error")
                        Exit Sub
                        'obj.ShowDialog()
                    End If
                ElseIf nModoGrabacion = 3 Then 'No Encontrado
                    If registros_asociados Then
                        obj.ModoFrm = "UPD"
                        Dim v2 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_2)), cmd.ExecuteScalar(strSQL_2), "-1")
                        Dim v3 As String = IIf(Not IsDBNull(cmd.ExecuteScalar(strSQL_3)), cmd.ExecuteScalar(strSQL_3), "-1")
                        If v2 <> "-1" And v3 <> "-1" And v2 <> Nothing And v3 <> Nothing Then
                            If v2 = "1" Then
                                MsgBox("Para marcar la tercera visita como No encontrada, antes debe registrar la segunda.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "2" Then
                                MsgBox("Ya se ha registrado tercera visita, no se puede cambiar.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "3" Then
                                MsgBox("Ya se ha registrado que el negocio de esta socia en esta visita está inactivo.", vbCritical, "Error")
                                Exit Sub
                            ElseIf v3 = "4" Then
                                MsgBox("Va a modificar las oservaciones de que no se encontró a esta socia.", vbExclamation, "Alerta")
                            End If
                            obj.ShowDialog()
                        Else
                            MsgBox("No se puede verificar estado de visita.", vbCritical, "Error")
                        End If
                    Else
                        obj.ModoFrm = "ADD"
                        MsgBox("Para marcar la tercera visita como No encontrada, debe tener al menos la segunda visita registrada.", vbCritical, "Error")
                        Exit Sub
                        'obj.ShowDialog()
                    End If
                End If
            End If

            'obj.ShowDialog()

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            obj.BringToFront()

            'Final:
            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmSclReferenciaSocia.Close()
            obj = Nothing
        End Try
    End Sub

    Private Sub tbSalir_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbSalir.ItemClicked
        Try
            Select Case e.ClickedItem.Name
                Case "toolSalir"
                    Me.Close()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamarParametros()
        Dim obj As New frmSclSeguimientoVisitasParametros

        Try

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = Cursors.WaitCursor

            obj.strSQl = setBasicStrSQL()

            obj.ShowDialog()

            If Not String.IsNullOrEmpty(Trim(obj.strSQl)) Then
                If Trim(setBasicStrSQL()) <> Trim(obj.strSQl) Then
                    strSQL = obj.strSQl
                    CargarSocias(strSQL)
                End If
            End If

            If Me.grdSocias.RowCount <= 0 Then
                MsgBox("No se encontraron registros", vbInformation, "SMUSURA0")
            End If

            FormatoSocias()

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            obj.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmSclReferenciaSocia.Close()
            obj = Nothing
        End Try
    End Sub

    Private Sub InicializaVariables()
        XdtSocias = New XDataSet.xDataTable
        XdtVisitas = New XDataSet.xDataTable

        cboFiltro.SelectedIndex = 0
    End Sub

    Private Sub CargarSocias(ByVal strSql As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            If Trim(strSql) = "" Then
                Me.strSQL = setBasicNullstrSQL()
                strSql = Me.strSQL
                XdtSocias.ExecuteSql(strSql)
            Else
                XdtSocias.ExecuteSql(strSql)
            End If

            Me.grdSocias.DataSource = XdtSocias.Source

            FormatoSocias()

            TituloSocias()

            Me.grdSocias.Columns(0).ValueItems.Presentation = PresentationEnum.CheckBox

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarVisitas(ByVal strSql2 As String)
        Try
            Me.Cursor = Cursors.WaitCursor

            'If Trim(strSql2) = "" Then
            Me.strSQL2 = setBasicStrSQL2()
            strSql2 = Me.strSQL2
            XdtVisitas.ExecuteSql(strSql2)
            'Else
            'XdtVisitas.ExecuteSql(strSql2)
            'End If

            Me.grdVisitas.DataSource = XdtVisitas.Source

            FormatoVisitas()

            TituloVisitas()

            Me.grdVisitas.Columns(0).ValueItems.Presentation = PresentationEnum.CheckBox

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub TituloSocias()
        Dim j As Integer = 0

        For i = 0 To XdtSocias.Table.Rows.Count - 1
            If XdtSocias.Table.Rows(i).Item("Selected") = True Then
                j += 1
            End If
        Next

        'Mostrar Cantidad de socias (Para tener el 100% y ellos saquen el 25% o el n%)
        If Me.grdSocias.RowCount > 0 Then
            Me.grdSocias.Caption = "Listado de socias filtradas (" & Me.grdSocias.RowCount & " Socias, " & j & " seleccionadas)"
        Else
            Me.grdSocias.Caption = "Listado de socias filtradas"
        End If


    End Sub

    Private Sub TituloVisitas()
        Dim j As Integer = 0

        For i = 0 To XdtVisitas.Table.Rows.Count - 1
            If XdtVisitas.Table.Rows(i).Item("Selected") = True Then
                j += 1
            End If
        Next

        'Mostrar Cantidad de socias (Para tener el 100% y ellos saquen el 25% o el n%)
        If Me.grdVisitas.RowCount > 0 Then
            Me.grdVisitas.Caption = "Listado de visitas (" & Me.grdVisitas.RowCount & " registros, " & j & " seleccionados)"
        Else
            Me.grdVisitas.Caption = "Listado visitas"
        End If
    End Sub

    Private Sub FormatoSocias()
        Try

            'Configuracion del Grid FNC
            Me.grdSocias.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nFondoPresupuestario").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nCodigo").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False

            Me.grdSocias.Splits(0).DisplayColumns("Grupo").Width = 200
            Me.grdSocias.Splits(0).DisplayColumns("Socia").Width = 200
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("Departamento").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("Municipio").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("Distrito").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("Barrio").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("CreditoNO").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").Width = 200
            Me.grdSocias.Splits(0).DisplayColumns("sTelefonoSocia").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("nMontoCreditoAprobado").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("nPlazoAprobado").Width = 50
            Me.grdSocias.Splits(0).DisplayColumns("dFechaDesembolso").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("Fuente").Width = 200
            Me.grdSocias.Splits(0).DisplayColumns("Selected").Width = 15

            Me.grdSocias.Columns("Grupo").Caption = "Grupo Solidario"
            Me.grdSocias.Columns("Socia").Caption = "Nombre de Socia"
            Me.grdSocias.Columns("sNumeroCedula").Caption = "Cédula"
            Me.grdSocias.Columns("Departamento").Caption = "Departamento"
            Me.grdSocias.Columns("Municipio").Caption = "Municipio"
            Me.grdSocias.Columns("Distrito").Caption = "Distrito"
            Me.grdSocias.Columns("Barrio").Caption = "Barrio"
            Me.grdSocias.Columns("CreditoNO").Caption = "N° Crédito"
            Me.grdSocias.Columns("sDireccionSocia").Caption = "Dirección"
            Me.grdSocias.Columns("sTelefonoSocia").Caption = "Teléfono(s)"
            Me.grdSocias.Columns("nMontoCreditoAprobado").Caption = "Monto Aprobado"
            Me.grdSocias.Columns("nPlazoAprobado").Caption = "Plazo"
            Me.grdSocias.Columns("dFechaDesembolso").Caption = "Fecha Desembolso"
            Me.grdSocias.Columns("Fuente").Caption = "Fuente de Financiemiento"
            Me.grdSocias.Columns("Selected").Caption = ""


            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nMontoCreditoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSocias.Splits(0).DisplayColumns("nPlazoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdSocias.Splits(0).DisplayColumns("dFechaDesembolso").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("CreditoNO").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sTelefonoSocia").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Selected").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nPlazoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocias.Splits(0).DisplayColumns("Grupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Socia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Distrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("CreditoNO").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sTelefonoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nMontoCreditoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nPlazoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("dFechaDesembolso").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("Selected").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdSocias.Columns("dFechaDesembolso").NumberFormat = "dd/MM/yyyy"

            Dim i As Integer
            For i = 0 To Me.grdSocias.Splits(0).DisplayColumns.Count - 1
                If Me.grdSocias.Splits(0).DisplayColumns(i).Name <> "" Then
                    Me.grdSocias.Splits(0).DisplayColumns(i).Style.Locked = True
                End If
            Next

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoVisitas()
        Try

            'Configuracion del Grid FNC
            Me.grdVisitas.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nFondoPresupuestario").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nCodigo").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.grdVisitas.Splits(0).DisplayColumns("nSclSeguimientoVisitaID").Visible = False

            Me.grdVisitas.Splits(0).DisplayColumns("Grupo").Width = 200
            Me.grdVisitas.Splits(0).DisplayColumns("Socia").Width = 200
            Me.grdVisitas.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("Departamento").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("Municipio").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("Distrito").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("Barrio").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("CreditoNO").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("sDireccionSocia").Width = 200
            Me.grdVisitas.Splits(0).DisplayColumns("sTelefonoSocia").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("nMontoCreditoAprobado").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("nPlazoAprobado").Width = 50
            Me.grdVisitas.Splits(0).DisplayColumns("dFechaDesembolso").Width = 100
            Me.grdVisitas.Splits(0).DisplayColumns("Fuente").Width = 200
            Me.grdVisitas.Splits(0).DisplayColumns("Selected").Width = 15

            Me.grdVisitas.Columns("Grupo").Caption = "Grupo Solidario"
            Me.grdVisitas.Columns("Socia").Caption = "Nombre de Socia"
            Me.grdVisitas.Columns("sNumeroCedula").Caption = "Cédula"
            Me.grdVisitas.Columns("Departamento").Caption = "Departamento"
            Me.grdVisitas.Columns("Municipio").Caption = "Municipio"
            Me.grdVisitas.Columns("Distrito").Caption = "Distrito"
            Me.grdVisitas.Columns("Barrio").Caption = "Barrio"
            Me.grdVisitas.Columns("CreditoNO").Caption = "N° Crédito"
            Me.grdVisitas.Columns("sDireccionSocia").Caption = "Dirección"
            Me.grdVisitas.Columns("sTelefonoSocia").Caption = "Teléfono(s)"
            Me.grdVisitas.Columns("nMontoCreditoAprobado").Caption = "Monto Aprobado"
            Me.grdVisitas.Columns("nPlazoAprobado").Caption = "Plazo"
            Me.grdVisitas.Columns("dFechaDesembolso").Caption = "Fecha Desembolso"
            Me.grdVisitas.Columns("Fuente").Caption = "Fuente de Financiemiento"
            Me.grdVisitas.Columns("Selected").Caption = ""


            Me.grdVisitas.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("nMontoCreditoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdVisitas.Splits(0).DisplayColumns("nPlazoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdVisitas.Splits(0).DisplayColumns("dFechaDesembolso").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("CreditoNO").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("sTelefonoSocia").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Selected").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("nPlazoAprobado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdVisitas.Splits(0).DisplayColumns("Grupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Socia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Distrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("CreditoNO").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("sTelefonoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("nMontoCreditoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("nPlazoAprobado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("dFechaDesembolso").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Fuente").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdVisitas.Splits(0).DisplayColumns("Selected").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdVisitas.Columns("dFechaDesembolso").NumberFormat = "dd/MM/yyyy"

            Dim i As Integer
            For i = 0 To Me.grdVisitas.Splits(0).DisplayColumns.Count - 1
                If Me.grdVisitas.Splits(0).DisplayColumns(i).Name <> "" Then
                    Me.grdVisitas.Splits(0).DisplayColumns(i).Style.Locked = True
                End If
            Next

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function setBasicStrSQL() As String
        Dim strsql As String
        strsql = "SELECT cast(0 as bit) as Selected,
					dbo.vwStbUbicacionGeografica.nStbDepartamentoID,
					dbo.vwStbUbicacionGeografica.nStbMunicipioID,
					dbo.vwStbUbicacionGeografica.nStbDistritoID,
					dbo.vwStbUbicacionGeografica.nStbBarrioID, 
					dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID,
					dbo.SclSocia.nSclSociaID,
					dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID,
					dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, 
					dbo.SclGrupoSolidario.sDescripcion as Grupo,
					dbo.SclSocia.sNombre1 + ' ' + dbo.SclSocia.sNombre2 + ' ' + dbo.SclSocia.sApellido1 + ' ' + dbo.SclSocia.sApellido2 AS Socia,
					dbo.SclSocia.sNumeroCedula, 
					dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS CreditoNO,
					dbo.vwStbUbicacionGeografica.Departamento,
					dbo.vwStbUbicacionGeografica.Municipio,
					dbo.vwStbUbicacionGeografica.Distrito,
					dbo.vwStbUbicacionGeografica.Barrio,                    
					dbo.SclSocia.sDireccionSocia,
					dbo.SclSocia.sTelefonoSocia, 
					dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado,
					dbo.SclFichaNotificacionDetalle.nPlazoAprobado,
					dbo.SccSolicitudDesembolsoCredito.dFechaDesembolso, 
					dbo.ScnFuenteFinanciamiento.nFondoPresupuestario,
					dbo.ScnFuenteFinanciamiento.sNombre AS Fuente,
					dbo.SclFichaNotificacionCredito.nCodigo
					FROM            dbo.SclFichaNotificacionCredito INNER JOIN
					dbo.SclFichaNotificacionDetalle ON dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN
					dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN
					dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN
					dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN
					dbo.SccSolicitudDesembolsoCredito ON dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN
					dbo.SccSolicitudCheque ON dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN
					dbo.ScnFuenteFinanciamiento ON dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID INNER JOIN
					dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN
					dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN
					dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN
					dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID LEFT OUTER JOIN
					dbo.SclSeguimientoVisita ON dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SclSeguimientoVisita.nSclFichaNotificacionDetalleID
					WHERE        (dbo.StbValorCatalogo.sCodigoInterno = '2') AND (StbValorCatalogo_1.sCodigoInterno = '5') AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND 
					(dbo.SclSeguimientoVisita.nSclFichaNotificacionDetalleID IS NULL) "

        Return strsql

    End Function

    Public Function setBasicNullstrSQL() As String
        Return setBasicStrSQL() & " And (dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = 0) "
    End Function

    Public Function setBasicStrSQL2() As String

        strSQL2 = "SELECT cast(0 as bit) as Selected,
					dbo.vwStbUbicacionGeografica.nStbDepartamentoID,
					dbo.vwStbUbicacionGeografica.nStbMunicipioID,
					dbo.vwStbUbicacionGeografica.nStbDistritoID,
					dbo.vwStbUbicacionGeografica.nStbBarrioID, 
					dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID,
					dbo.SclSocia.nSclSociaID,
					dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID,
					dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID,
					dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID,
					dbo.SclGrupoSolidario.sDescripcion as Grupo,
					dbo.SclSocia.sNombre1 + ' ' + dbo.SclSocia.sNombre2 + ' ' + dbo.SclSocia.sApellido1 + ' ' + dbo.SclSocia.sApellido2 AS Socia,
					dbo.SclSocia.sNumeroCedula, 
					dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS CreditoNO,
					dbo.vwStbUbicacionGeografica.Departamento,
					dbo.vwStbUbicacionGeografica.Municipio,
					dbo.vwStbUbicacionGeografica.Distrito,
					dbo.vwStbUbicacionGeografica.Barrio,                    
					dbo.SclSocia.sDireccionSocia,
					dbo.SclSocia.sTelefonoSocia, 
					dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado,
					dbo.SclFichaNotificacionDetalle.nPlazoAprobado,
					dbo.SccSolicitudDesembolsoCredito.dFechaDesembolso, 
					dbo.ScnFuenteFinanciamiento.nFondoPresupuestario,
					dbo.ScnFuenteFinanciamiento.sNombre AS Fuente,
					dbo.SclFichaNotificacionCredito.nCodigo
					FROM            dbo.SclFichaNotificacionCredito INNER JOIN
					dbo.SclFichaNotificacionDetalle ON dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER JOIN
					dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID INNER JOIN
					dbo.SclGrupoSocia ON dbo.SclFichaSocia.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID INNER JOIN
					dbo.SclSocia ON dbo.SclGrupoSocia.nSclSociaID = dbo.SclSocia.nSclSociaID INNER JOIN
					dbo.SccSolicitudDesembolsoCredito ON dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID INNER JOIN
					dbo.SccSolicitudCheque ON dbo.SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID = dbo.SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID INNER JOIN
					dbo.ScnFuenteFinanciamiento ON dbo.SccSolicitudCheque.nScnFuenteFinanciamientoID = dbo.ScnFuenteFinanciamiento.nScnFuenteFinanciamientoID INNER JOIN
					dbo.SclGrupoSolidario ON dbo.SclFichaNotificacionCredito.nSclGrupoSolidarioID = dbo.SclGrupoSolidario.nSclGrupoSolidarioID INNER JOIN
					dbo.vwStbUbicacionGeografica ON dbo.SclGrupoSolidario.nStbBarrioVerificadoID = dbo.vwStbUbicacionGeografica.nStbBarrioID INNER JOIN
					dbo.StbValorCatalogo ON dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN
					dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo_1.nStbValorCatalogoID INNER JOIN
					dbo.SclSeguimientoVisita ON dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SclSeguimientoVisita.nSclFichaNotificacionDetalleID INNER JOIN
					dbo.StbValorCatalogo AS EstadoVisita ON EstadoVisita.nStbValorCatalogoID=dbo.SclSeguimientoVisita.nStbEstadoSeguimientoID INNER JOIN
					dbo.StbValorCatalogo AS EstadoVisita2 ON EstadoVisita2.nStbValorCatalogoID=dbo.SclSeguimientoVisita.nStbEstadoSeguimiento2ID INNER JOIN
					dbo.StbValorCatalogo AS EstadoVisita3 ON EstadoVisita3.nStbValorCatalogoID=dbo.SclSeguimientoVisita.nStbEstadoSeguimiento3ID INNER JOIN
					dbo.StbDelegacionPrograma ON dbo.StbDelegacionPrograma.nStbDelegacionProgramaID=dbo.SclGrupoSolidario.nStbDelegacionProgramaID
					WHERE (dbo.StbValorCatalogo.sCodigoInterno = '2') AND ((StbValorCatalogo_1.sCodigoInterno = '5') OR (StbValorCatalogo_1.sCodigoInterno = '7') )
					AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (dbo.StbDelegacionPrograma.nStbDelegacionProgramaID=" & InfoSistema.IDDelegacion & ") 
					--AND EstadoVisita.sCodigoInterno<>'3' 
					"

        Select Case cboFiltro.SelectedIndex
            Case -1
                strSQL2 &= " AND EstadoVisita.sCodigoInterno='0' "
            Case 0
                strSQL2 &= " AND EstadoVisita.sCodigoInterno='0' "
            Case 1

            Case 2
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=6 "
            Case 3
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=8 "
            Case 4
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=12 "
            Case 5
                strSQL2 &= " AND EstadoVisita.sCodigoInterno='1' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=6 "
            Case 6
                strSQL2 &= " AND EstadoVisita2.sCodigoInterno='1' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=8 "
            Case 7
                strSQL2 &= " AND EstadoVisita3.sCodigoInterno='1' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=12 "
            Case 8
                strSQL2 &= " AND (EstadoVisita.sCodigoInterno='2' OR EstadoVisita2.sCodigoInterno='2' OR EstadoVisita3.sCodigoInterno='2') "
            Case 9
                strSQL2 &= " AND EstadoVisita.sCodigoInterno='2' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=6 "
            Case 10
                strSQL2 &= " AND EstadoVisita2.sCodigoInterno='2' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=8 "
            Case 11
                strSQL2 &= " AND EstadoVisita3.sCodigoInterno='2' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=12 "
            Case 12
                strSQL2 &= " AND (EstadoVisita.sCodigoInterno='3' OR EstadoVisita2.sCodigoInterno='3' OR EstadoVisita3.sCodigoInterno='3') "
            Case 13
                strSQL2 &= " AND EstadoVisita.sCodigoInterno='3' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=6 "
            Case 14
                strSQL2 &= " AND EstadoVisita2.sCodigoInterno='3' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=8 "
            Case 15
                strSQL2 &= " AND EstadoVisita3.sCodigoInterno='3' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=12 "
            Case 16
                strSQL2 &= " AND (EstadoVisita.sCodigoInterno='4' OR EstadoVisita2.sCodigoInterno='4' OR EstadoVisita3.sCodigoInterno='4') "
            Case 17
                strSQL2 &= " AND EstadoVisita.sCodigoInterno='4' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=6 "
            Case 18
                strSQL2 &= " AND EstadoVisita2.sCodigoInterno='4' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=8 "
            Case 19
                strSQL2 &= " AND EstadoVisita3.sCodigoInterno='4' "
                strSQL2 &= " AND dbo.SclFichaNotificacionDetalle.nPlazoAprobado>=12 "
        End Select

        'Dim alguno As Boolean = False
        'alguno = mnu1Pendientes.Checked Or mnu1Encontrada.Checked Or mnu1Inactivo.Checked Or mnu1NoEncontrada.Checked _
        '    Or mnu2Pendientes.Checked Or mnu2Encontrada.Checked Or mnu2Inactivo.Checked Or mnu1NoEncontrada.Checked _
        '    Or mnu3Pendientes.Checked Or mnu3Encontrada.Checked Or mnu3Inactivo.Checked Or mnu3NoEncontrada.Checked


        'If Not alguno Then
        '    strSQL2 &= " AND EstadoVisita.sCodigoInterno='0' "
        'End If


        ''Primera
        'If mnuPrimera.Checked Then
        '    If Not mnu1Pendientes.Checked Then
        '        strSQL2 &= " AND EstadoVisita.sCodigoInterno<>'1' "
        '    End If
        '    If Not mnu1Encontrada.Checked Then
        '        strSQL2 &= " AND EstadoVisita.sCodigoInterno<>'2' "
        '    End If
        '    If Not mnu1Inactivo.Checked Then
        '        strSQL2 &= " AND EstadoVisita.sCodigoInterno<>'3' "
        '    End If
        '    If Not mnu1NoEncontrada.Checked Then
        '        strSQL2 &= " AND EstadoVisita.sCodigoInterno<>'4' "
        '    End If
        'End If

        ''Segunda
        'If mnuSegunda.Checked Then
        '    If Not mnu2Pendientes.Checked Then
        '        strSQL2 &= " AND EstadoVisita2.sCodigoInterno<>'1' "
        '    End If
        '    If Not mnu2Encontrada.Checked Then
        '        strSQL2 &= " AND EstadoVisita2.sCodigoInterno<>'2' "
        '    End If
        '    If Not mnu2Inactivo.Checked Then
        '        strSQL2 &= " AND EstadoVisita2.sCodigoInterno<>'3' "
        '    End If
        '    If Not mnu2NoEncontrada.Checked Then
        '        strSQL2 &= " AND EstadoVisita2.sCodigoInterno<>'4' "
        '    End If
        'End If

        ''Tercera
        'If mnuTercera.Checked Then
        '    If Not mnu3Pendientes.Checked Then
        '        strSQL2 &= " AND EstadoVisita3.sCodigoInterno<>'1' "
        '    End If
        '    If Not mnu3Encontrada.Checked Then
        '        strSQL2 &= " AND EstadoVisita3.sCodigoInterno<>'2' "
        '    End If
        '    If Not mnu3Inactivo.Checked Then
        '        strSQL2 &= " AND EstadoVisita3.sCodigoInterno<>'3' "
        '    End If
        '    If Not mnu3NoEncontrada.Checked Then
        '        strSQL2 &= " AND EstadoVisita3.sCodigoInterno<>'4' "
        '    End If
        'End If

        Return strSQL2
    End Function

    Public Function setBasicNullstrSQL2() As String
        Return setBasicStrSQL2() & " And (dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = 0) "
    End Function

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        Dim cmd As New XComando()
        Dim fnds As New ArrayList()

        Try
            '1- Pasar los marcados(Izquierda) a la tabla SclSeguimientoVisitas -- spGrabarSeguimientoVisita FND_ID, codEstado
            For i = 0 To XdtSocias.Table.Rows.Count - 1
                If XdtSocias.Table.Rows(i).Item("Selected") = True Then
                    'Memoria a la lista de items seleccionados
                    fnds.Add(XdtSocias.Table.Rows(i).Item("nSclFichaNotificacionDetalleID"))
                    cmd.ExecuteNonQuery("spGrabarSeguimientoVisita " & XdtSocias.Table.Rows(i).Item("nSclFichaNotificacionDetalleID") & ", 1, '" & InfoSistema.LoginName & "'")
                End If
            Next

            '2- Refrescar la consulta de la izquierda
            CargarSocias(Me.strSQL)

            '3- Refrescar consulta de la derecha, con la ultima consulta generada
            CargarVisitas(Me.strSQL2)

            '4- Checar los items en memoria
            For i = 0 To XdtVisitas.Table.Rows.Count - 1
                If fnds.Contains(XdtVisitas.Table.Rows(i).Item("nSclFichaNotificacionDetalleID")) Then
                    XdtVisitas.Table.Rows(i).Item("Selected") = True
                End If
            Next

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Dim cmd As New XComando()
        Dim strSQL As String = ""
        Try

            '1- Eliminar los marcados(Derecha) de la tabla SclSeguimientoVisitas -- spGrabarSeguimientoVisita FND_ID, -1
            For i = 0 To XdtVisitas.Table.Rows.Count - 1
                If XdtVisitas.Table.Rows(i).Item("Selected") = True Then
                    'Validar que no tenga visitas registradas (Existencia de nSclSeguimientoVisitaID<->nSclFichaNotificacionDetalleID en SclSeguimientoVisitaDetalle)
                    strSQL = "SELECT 1 AS Existe
							FROM dbo.SclSeguimientoVisita INNER JOIN
							dbo.SclSeguimientoVisitaDetalle ON dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID = dbo.SclSeguimientoVisitaDetalle.nSclSeguimientoVisitaID
							WHERE dbo.SclSeguimientoVisita.nSclSeguimientoVisitaID=" & XdtVisitas.Table.Rows(i).Item("nSclSeguimientoVisitaID")
                    If RegistrosAsociados(strSQL) Then
                        MsgBox("No se puede eliminar de la lista la socia con cédula: " & XdtVisitas.Table.Rows(i).Item("sNumeroCedula") & vbCrLf & "Ya ha sido visitada al menos una vez. Desaparecerá de la lista cuando ya halla concluido sus visitas.", vbExclamation, "Error")
                    Else
                        cmd.ExecuteNonQuery("spGrabarSeguimientoVisita " & XdtVisitas.Table.Rows(i).Item("nSclFichaNotificacionDetalleID") & ", -1, '" & InfoSistema.LoginName & "'")
                    End If
                End If
            Next

            '2- Refrescar la consulta de la izquierda
            CargarSocias(Me.strSQL)

            '3- Refrescar consulta de la derecha, con la ultima consulta generada
            CargarVisitas(Me.strSQL2)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub ckCA1_CheckedChanged(sender As Object, e As EventArgs) Handles ckCA1.CheckedChanged
        If ckCA1.Checked Then
            For i = 0 To Me.grdSocias.RowCount - 1
                Me.grdSocias.Bookmark = i
                Me.grdSocias.Columns("Selected").Value = 1
            Next
        Else
            For i = 0 To Me.grdSocias.RowCount - 1
                Me.grdSocias.Bookmark = i
                Me.grdSocias.Columns("Selected").Value = 0
            Next
        End If

        TituloSocias()
    End Sub

    Private Sub ckCA2_CheckedChanged(sender As Object, e As EventArgs) Handles ckCA2.CheckedChanged
        If ckCA2.Checked Then
            For i = 0 To Me.grdVisitas.RowCount - 1
                Me.grdVisitas.Bookmark = i
                Me.grdVisitas.Columns("Selected").Value = 1
            Next
        Else
            For i = 0 To Me.grdVisitas.RowCount - 1
                Me.grdVisitas.Bookmark = i
                Me.grdVisitas.Columns("Selected").Value = 0
            Next
        End If

        TituloVisitas()
    End Sub

    Private Sub toolMnuCS67_Click(sender As Object, e As EventArgs) Handles toolMnuCS67.Click
        Dim frmVisor As New frmCRVisorReporte
        Me.Cursor = Cursors.WaitCursor

        If ObtenerFiltro() <> "({vwSclSeguimientoVisitasProtagonistas.nSclFichaNotificacionDetalleID} IN []" Then
            frmVisor.CRVReportes.SelectionFormula = ObtenerFiltro()
            frmVisor.NombreReporte = "RepSclCS67.rpt"
            frmVisor.Text = "Ficha de Seguimiento a Protagonistas"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Show()
        Else
            MsgBox("Seleccione con Check al menos un registro.", vbCritical, "Error")
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Function ObtenerFiltro() As String
        Dim filtro As String = "({vwSclSeguimientoVisitasProtagonistas.nSclFichaNotificacionDetalleID} IN ["
        For i = 0 To XdtVisitas.Table.Rows.Count - 1
            If XdtVisitas.Table.Rows(i).Item("Selected") = True Then
                filtro = filtro & XdtVisitas.Table.Rows(i).Item("nSclFichaNotificacionDetalleID") & ","
            End If
        Next
        filtro = filtro & "]"
        filtro = Replace(filtro, ",]", "])")
        Return filtro
    End Function

    Private Sub grdVisitas_AfterColUpdate(sender As Object, e As ColEventArgs) Handles grdVisitas.AfterColUpdate
        TituloVisitas()
    End Sub

    Private Sub grdSocias_AfterColUpdate(sender As Object, e As ColEventArgs) Handles grdSocias.AfterColUpdate
        TituloSocias()
    End Sub

    Private Sub AgregarPrimeraVisitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AgregarPrimeraVisitaToolStripMenuItem.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        LlamarAgregarDetalle(1, 1)
    End Sub

    Private Sub SegundaVisitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SegundaVisitaToolStripMenuItem.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "6" Then
            MsgBox("No se puede dar segunda visita a una socia con crédito de plazo: 6 meses", vbCritical, "Error")
            Exit Sub
        End If
        LlamarAgregarDetalle(2, 1)
    End Sub

    Private Sub TerceraVisitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TerceraVisitaToolStripMenuItem.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "8" Or XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "6" Then
            MsgBox("No se puede dar tercera visita a una socia con crédito de plazos: 6 meses, 8 meses", vbCritical, "Error")
            Exit Sub
        End If
        LlamarAgregarDetalle(3, 1)
    End Sub

    Private Sub PrimeraVisitaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PrimeraVisitaToolStripMenuItem.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        LlamarAgregarDetalle(1, 2)
    End Sub

    Private Sub SegundaVisitaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles SegundaVisitaToolStripMenuItem1.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "6" Then
            MsgBox("No se puede dar segunda visita a una socia con crédito de plazo: 6 meses", vbCritical, "Error")
            Exit Sub
        End If
        LlamarAgregarDetalle(2, 2)
    End Sub

    Private Sub TerceraVisitaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles TerceraVisitaToolStripMenuItem1.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "8" Or XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "6" Then
            MsgBox("No se puede dar tercera visita a una socia con crédito de plazos: 6 meses, 8 meses", vbCritical, "Error")
            Exit Sub
        End If
        LlamarAgregarDetalle(3, 2)
    End Sub

    Private Sub PrimeraVisitaToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles PrimeraVisitaToolStripMenuItem1.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        LlamarAgregarDetalle(1, 3)
    End Sub

    Private Sub SegundaVisitaToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles SegundaVisitaToolStripMenuItem2.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "6" Then
            MsgBox("No se puede dar segunda visita a una socia con crédito de plazo: 6 meses", vbCritical, "Error")
            Exit Sub
        End If
        LlamarAgregarDetalle(2, 3)
    End Sub

    Private Sub TerceraVisitaToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles TerceraVisitaToolStripMenuItem2.Click
        If Me.grdVisitas.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If
        If XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "8" Or XdtVisitas.Current.Item("nPlazoAprobado").ToString() = "6" Then
            MsgBox("No se puede dar tercera visita a una socia con crédito de plazos: 6 meses, 8 meses", vbCritical, "Error")
            Exit Sub
        End If
        LlamarAgregarDetalle(3, 3)
    End Sub

    'Private Sub mnuPrimera_Click(sender As Object, e As EventArgs) Handles mnuPrimera.Click
    '    mnu1Pendientes.Checked = mnuPrimera.Checked
    '    mnu1Encontrada.Checked = mnuPrimera.Checked
    '    mnu1Inactivo.Checked = mnuPrimera.Checked
    '    mnu1NoEncontrada.Checked = mnuPrimera.Checked
    'End Sub

    'Private Sub mnuSegunda_Click(sender As Object, e As EventArgs) Handles mnuSegunda.Click
    '    mnu2Pendientes.Checked = mnuSegunda.Checked
    '    mnu2Encontrada.Checked = mnuSegunda.Checked
    '    mnu2Inactivo.Checked = mnuSegunda.Checked
    '    mnu2NoEncontrada.Checked = mnuSegunda.Checked
    'End Sub

    'Private Sub mnuTercera_Click(sender As Object, e As EventArgs) Handles mnuTercera.Click
    '    mnu3Pendientes.Checked = mnuTercera.Checked
    '    mnu3Encontrada.Checked = mnuTercera.Checked
    '    mnu3Inactivo.Checked = mnuTercera.Checked
    '    mnu3NoEncontrada.Checked = mnuTercera.Checked
    'End Sub
End Class