Public Class frmSclSeguimientoVisitaDetalle

    Dim xdsPromotor As BOSistema.Win.XDataSet

    Public ModoFrm As String = "ADD"

    Enum ModoGrabacion
        Visita = 1
        Anulamiento = 2
        NoEncontrada = 3
    End Enum

    Public nModoGrabacion As Integer

    Public intSeguimientoVisitaID As Integer = 0
    Public intNumeroVisita As Integer = 0

    Public sNombreSocia As String = ""
    Public sNumeroCedula As String = ""
    Public sGrupoSolidario As String = ""
    Public sDireccionSocia As String = ""
    Public nNumeroCredito As Integer = 0
    Public nMontoAprobado As Integer = 0
    Public nPlazoAprobado As Integer = 0



    Private Sub frmSclSeguimientoVisitaDetalle_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            InicializarVariables()
            LlenarGenerales()
            Me.tabFicha.SelectedTab = ctpGenerales

            If Me.intNumeroVisita = 1 Then
                ctpSegundaVisita.Enabled = False
                ctpTerceraVisita.Enabled = False
                If Me.nModoGrabacion = ModoGrabacion.Visita Then
                    grp3.Enabled = False
                    grp1.Enabled = True
                    grp2.Enabled = True
                    grp4.Enabled = True
                    grp5.Enabled = True
                    grp6.Enabled = True
                ElseIf Me.nModoGrabacion = ModoGrabacion.Anulamiento Then
                    grp3.Enabled = True
                    grp1.Enabled = True
                    grp2.Enabled = True
                    grp4.Enabled = False
                    grp5.Enabled = False
                    grp6.Enabled = False
                    txt3Explique.Enabled = False
                ElseIf Me.nModoGrabacion = ModoGrabacion.NoEncontrada Then
                    grp3.Enabled = False
                    grp1.Enabled = False
                    grp2.Enabled = False
                    grp4.Enabled = False
                    grp5.Enabled = False
                    grp6.Enabled = False
                End If
            ElseIf Me.intNumeroVisita = 2 Then
                ctpPrimeraVisita.Enabled = False
                ctpTerceraVisita.Enabled = False
                If nModoGrabacion = ModoGrabacion.Visita Then
                    grp8.Enabled = True
                    grp9.Enabled = True
                    grp11.Enabled = True
                    grp12.Enabled = True
                    grp13.Enabled = True
                    grp14.Enabled = True
                    grp15.Enabled = True
                    grp16.Enabled = True
                    grp17.Enabled = False
                ElseIf nModoGrabacion = ModoGrabacion.Anulamiento Then
                    grp8.Enabled = False
                    grp9.Enabled = False
                    grp11.Enabled = False
                    grp12.Enabled = False
                    grp13.Enabled = False
                    grp14.Enabled = False
                    grp15.Enabled = False
                    grp16.Enabled = False
                    grp17.Enabled = True
                    txt17Explique.Enabled = False
                ElseIf nModoGrabacion = ModoGrabacion.NoEncontrada Then
                    grp8.Enabled = False
                    grp9.Enabled = False
                    grp11.Enabled = False
                    grp12.Enabled = False
                    grp13.Enabled = False
                    grp14.Enabled = False
                    grp15.Enabled = False
                    grp16.Enabled = False
                    grp17.Enabled = False
                End If
            ElseIf Me.intNumeroVisita = 3 Then
                ctpPrimeraVisita.Enabled = False
                ctpSegundaVisita.Enabled = False
                If nModoGrabacion = ModoGrabacion.Visita Then
                    grp18.Enabled = True
                    grp19.Enabled = True
                    grp20.Enabled = True
                    grp21.Enabled = True
                    grp22.Enabled = False
                ElseIf nModoGrabacion = ModoGrabacion.Anulamiento Then
                    grp18.Enabled = False
                    grp19.Enabled = False
                    grp20.Enabled = False
                    grp21.Enabled = False
                    grp22.Enabled = True
                    txt22Explique.Enabled = False
                ElseIf nModoGrabacion = ModoGrabacion.NoEncontrada Then
                    grp18.Enabled = False
                    grp19.Enabled = False
                    grp20.Enabled = False
                    grp21.Enabled = False
                    grp22.Enabled = False
                End If
            End If

            CargarPromotores()

            If Me.ModoFrm = "UPD" Then
                CargarVisitas()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub InicializarVariables()
        Try
            xdsPromotor = New BOSistema.Win.XDataSet
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarVisitas()
        Dim datos As New BOSistema.Win.XDataSet
        Dim strSQL As String = "SELECT * FROM SclSeguimientoVisitaDetalle WHERE nSclSeguimientoVisitaID=" & Me.intSeguimientoVisitaID

        Try
            If Not datos.ExistTable("Detalle") Then
                datos.NewTable(strSQL, "Detalle")
                datos("Detalle").Retrieve()
            Else
                datos("Detalle").ExecuteSql(strSQL)
            End If
        Catch ex As Exception
            Control_Error(ex)
            Exit Sub
        End Try

        If datos("Detalle").Count > 0 Then
            If Me.intNumeroVisita = 1 Then
                If Not IsDBNull(datos("Detalle").ValueField("nExisteNegocio")) Then
                    If datos("Detalle").ValueField("nExisteNegocio") = 0 Then
                        Rd1No.Checked = True
                    ElseIf datos("Detalle").ValueField("nExisteNegocio") = 1 Then
                        Rd1Si.Checked = True
                    End If
                End If

                If Not IsDBNull(datos("Detalle").ValueField("nInvirtioEnNegocio")) Then
                    If datos("Detalle").ValueField("nInvirtioEnNegocio") = 2 Then
                        Rd2OtrosNegocios.Checked = True
                    ElseIf datos("Detalle").ValueField("nInvirtioEnNegocio") = 1 Then
                        Rd2NegocioPropuesto.Checked = True
                    ElseIf datos("Detalle").ValueField("nInvirtioEnNegocio") = 3 Then
                        Rd2NingunNegocio.Checked = True
                    End If
                End If

                If Not IsDBNull(datos("Detalle").ValueField("nRazonInactividad")) Then
                    If datos("Detalle").ValueField("nRazonInactividad") = 1 Then
                        Rd3ObtuvoTrabajo.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad") = 2 Then
                        Rd3SalioDelPais.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad") = 3 Then
                        Rd3ProblemasSalud.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad") = 4 Then
                        Rd3Otros.Checked = True
                    End If
                End If

                If Not IsDBNull(datos("Detalle").ValueField("sOtrosExplique")) Then
                    txt3Explique.Text = datos("Detalle").ValueField("sOtrosExplique").ToString
                End If

                If Not IsDBNull(datos("Detalle").ValueField("nRealizacionVentas")) Then
                    If datos("Detalle").ValueField("nRealizacionVentas") = 1 Then
                        Rd4Contado.Checked = True
                    ElseIf datos("Detalle").ValueField("nRealizacionVentas") = 2 Then
                        Rd4Credito.Checked = True
                    ElseIf datos("Detalle").ValueField("nRealizacionVentas") = 3 Then
                        Rd4LasDos.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nAnotaVentas")) Then
                    If datos("Detalle").ValueField("nAnotaVentas") = 0 Then
                        Rd5No.Checked = True
                    ElseIf datos("Detalle").ValueField("nAnotaVentas") = 1 Then
                        Rd5Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nQuienAnota")) Then
                    If datos("Detalle").ValueField("nQuienAnota") = 1 Then
                        Rd6Usted.Checked = True
                    ElseIf datos("Detalle").ValueField("nQuienAnota") = 2 Then
                        Rd6Familiar.Checked = True
                    ElseIf datos("Detalle").ValueField("nQuienAnota") = 3 Then
                        Rd6Otro.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("sObservaciones1")) Then
                    txt1Observaciones.Text = datos("Detalle").ValueField("sObservaciones1").ToString
                End If
                If Not IsDBNull(datos("Detalle").ValueField("dFechaVisita1")) Then
                    cdeFechaVisita1.Value = datos("Detalle").ValueField("dFechaVisita1")
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nStbPromotorVisita1ID")) Then
                    cboPromotor1.SelectedValue = CInt(datos("Detalle").ValueField("nStbPromotorVisita1ID"))
                End If

            ElseIf Me.intNumeroVisita = 2 Then

                If Not IsDBNull(datos("Detalle").ValueField("nMejoraNegocio")) Then
                    If datos("Detalle").ValueField("nMejoraNegocio") = 0 Then
                        Rd7No.Checked = True
                    ElseIf datos("Detalle").ValueField("nMejoraNegocio") = 1 Then
                        Rd7Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nReunionGrupal")) Then
                    If datos("Detalle").ValueField("nReunionGrupal") = 0 Then
                        Rd8No.Checked = True
                    ElseIf datos("Detalle").ValueField("nReunionGrupal") = 1 Then
                        Rd8Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nDiversificaNegocio")) Then
                    If datos("Detalle").ValueField("nDiversificaNegocio") = 0 Then
                        Rd10No.Checked = True
                    ElseIf datos("Detalle").ValueField("nDiversificaNegocio") = 1 Then
                        Rd10Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nRespetoClientes")) Then
                    If datos("Detalle").ValueField("nRespetoClientes") = 0 Then
                        Rd13No.Checked = True
                    ElseIf datos("Detalle").ValueField("nRespetoClientes") = 1 Then
                        Rd13Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nAmabilidad")) Then
                    If datos("Detalle").ValueField("nAmabilidad") = 0 Then
                        Rd14No.Checked = True
                    ElseIf datos("Detalle").ValueField("nAmabilidad") = 1 Then
                        Rd14Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nLocalHigienico")) Then
                    If datos("Detalle").ValueField("nLocalHigienico") = 0 Then
                        Rd15No.Checked = True
                    ElseIf datos("Detalle").ValueField("nLocalHigienico") = 1 Then
                        Rd15Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("sTipoProductoAgrego")) Then
                    txt11Productos.Text = datos("Detalle").ValueField("sTipoProductoAgrego").ToString()
                End If
                If Not IsDBNull(datos("Detalle").ValueField("sParaQue")) Then
                    txt8ParaQue.Text = datos("Detalle").ValueField("sParaQue").ToString()
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nMontoInversion")) Then
                    cne12Monto.Value = CDbl(datos("Detalle").ValueField("nMontoInversion"))
                End If

                'Razon de Inactividad
                If Not IsDBNull(datos("Detalle").ValueField("nRazonInactividad2")) Then
                    If datos("Detalle").ValueField("nRazonInactividad2") = 1 Then
                        Rd17ObtuvoTrabajo.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad2") = 2 Then
                        Rd17SalioDelPais.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad2") = 3 Then
                        Rd17ProblemasSalud.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad2") = 4 Then
                        Rd17Otros.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("sOtrosExplique2")) Then
                    txt17Explique.Text = datos("Detalle").ValueField("sOtrosExplique2").ToString()
                End If

                If Not IsDBNull(datos("Detalle").ValueField("sObservaciones2")) Then
                    txt2Observaciones.Text = datos("Detalle").ValueField("sObservaciones2").ToString()
                End If
                If Not IsDBNull(datos("Detalle").ValueField("dFechaVisita2")) Then
                    cdeFechaVisita2.Value = datos("Detalle").ValueField("dFechaVisita2")
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nStbPromotorVisita2ID")) Then
                    cboPromotor2.SelectedValue = CInt(datos("Detalle").ValueField("nStbPromotorVisita2ID"))
                End If

            ElseIf Me.intNumeroVisita = 3 Then

                'Dim dato As Integer = datos("Detalle").ValueField("nRealizaAhorro")
                If Not IsDBNull(datos("Detalle").ValueField("nRealizaAhorro")) Then
                    If datos("Detalle").ValueField("nRealizaAhorro") = 0 Then
                        Rd18No.Checked = True
                    ElseIf datos("Detalle").ValueField("nRealizaAhorro") = 1 Then
                        Rd18Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nCreditoMejoraCalidadVida")) Then
                    If datos("Detalle").ValueField("nCreditoMejoraCalidadVida") = 0 Then
                        Rd20No.Checked = True
                    ElseIf datos("Detalle").ValueField("nCreditoMejoraCalidadVida") = 1 Then
                        Rd20Si.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nMejorasLocal")) Then
                    If datos("Detalle").ValueField("nMejorasLocal") = 1 Then
                        Rd17Infraestructura.Checked = True
                    ElseIf datos("Detalle").ValueField("nMejorasLocal") = 2 Then
                        Rd17Equipos.Checked = True
                    ElseIf datos("Detalle").ValueField("nMejorasLocal") = 3 Then
                        Rd17Mobiliario.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nPorcentaje")) Then
                    cne19Porcentaje.Value = CDbl(datos("Detalle").ValueField("nPorcentaje"))
                End If

                'Razon de Inactividad
                If Not IsDBNull(datos("Detalle").ValueField("nRazonInactividad3")) Then
                    If datos("Detalle").ValueField("nRazonInactividad3") = 1 Then
                        Rd22ObtuvoTrabajo.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad3") = 2 Then
                        Rd22SalioDelPais.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad3") = 3 Then
                        Rd22ProblemasSalud.Checked = True
                    ElseIf datos("Detalle").ValueField("nRazonInactividad3") = 4 Then
                        Rd22Otros.Checked = True
                    End If
                End If
                If Not IsDBNull(datos("Detalle").ValueField("sOtrosExplique3")) Then
                    txt22Explique.Text = datos("Detalle").ValueField("sOtrosExplique3").ToString()
                End If

                If Not IsDBNull(datos("Detalle").ValueField("sObservaciones3")) Then
                    txt3Observaciones.Text = datos("Detalle").ValueField("sObservaciones3").ToString
                End If
                If Not IsDBNull(datos("Detalle").ValueField("dFechaVisita3")) Then
                    cdeFechaVisita3.Value = datos("Detalle").ValueField("dFechaVisita3")
                End If
                If Not IsDBNull(datos("Detalle").ValueField("nStbPromotorVisita3ID")) Then
                    cboPromotor3.SelectedValue = CInt(datos("Detalle").ValueField("nStbPromotorVisita3ID"))
                End If

            End If
        Else
            MsgBox("Esta socia aun no tiene datos reistrados", vbCritical, "Error")
        End If

    End Sub

    Private Sub CargarPromotores()
        Dim strSQL As String

        'Promotores:
        Try
            'strSQL = "spSrhEmpleadoCargoLista '%custom_1%' "
            strSQL = "spSrhEmpleadoDelegacionRRHH " & InfoSistema.IDDelegacion
            xdsPromotor.Dispose()
            xdsPromotor = New BOSistema.Win.XDataSet
            xdsPromotor.NewTable(strSQL, "Promotor1")
            xdsPromotor.NewTable(strSQL, "Promotor2")
            xdsPromotor.NewTable(strSQL, "Promotor3")
            xdsPromotor("Promotor1").Retrieve()
            xdsPromotor("Promotor2").Retrieve()
            xdsPromotor("Promotor3").Retrieve()

            cboPromotor1.DataSource = xdsPromotor("Promotor1").Source
            cboPromotor2.DataSource = xdsPromotor("Promotor2").Source
            cboPromotor3.DataSource = xdsPromotor("Promotor3").Source

            cboPromotor1.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            'cboPromotor1.Splits(0).DisplayColumns("cDescripcion").Visible = False
            cboPromotor1.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            cboPromotor2.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            'cboPromotor2.Splits(0).DisplayColumns("cDescripcion").Visible = False
            cboPromotor2.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            cboPromotor3.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            'cboPromotor3.Splits(0).DisplayColumns("cDescripcion").Visible = False
            cboPromotor3.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            cboPromotor1.Columns("cNombresApellidos").Caption = "Promotor"
            cboPromotor2.Columns("cNombresApellidos").Caption = "Promotor"
            cboPromotor3.Columns("cNombresApellidos").Caption = "Promotor"

            cboPromotor1.DisplayMember = "cNombresApellidos"
            cboPromotor1.ValueMember = "nSrhEmpleadoID"
            cboPromotor2.DisplayMember = "cNombresApellidos"
            cboPromotor2.ValueMember = "nSrhEmpleadoID"
            cboPromotor3.DisplayMember = "cNombresApellidos"
            cboPromotor3.ValueMember = "nSrhEmpleadoID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlenarGenerales()
        Me.txtSocia.Text = Me.sNombreSocia
        Me.txtCedula.Text = Me.sNumeroCedula
        Me.txtGrupo.Text = Me.sGrupoSolidario
        Me.txtDireccion.Text = Me.sDireccionSocia
        Me.txtNumeroCredito.Value = Me.nNumeroCredito
        Me.txtMontoAprobado.Value = Me.nMontoAprobado
        Me.txtPlazoAprobado.Value = Me.nPlazoAprobado
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        If Not ValidarDatosEntrada() Then
            MsgBox("No se pudieron guardar los cambios", vbCritical, "Error")
        Else
            SalvarFicha()
        End If
    End Sub

    Private Function ValidarDatosEntrada() As Boolean

        Dim cmd As New BOSistema.Win.XComando
        Dim fechaServer As Date
        fechaServer = CDate(cmd.ExecuteScalar("Select Getdate()"))

        If Me.intNumeroVisita = 1 Then
            'Validacion llenar campos

            If Not (Rd1Si.Checked Or Rd1No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                MsgBox("Debe marcar: ¿Existe el negocio?.", vbCritical, "Error")
                Return False
            End If

            If Not (Rd2NegocioPropuesto.Checked Or Rd2OtrosNegocios.Checked Or Rd2NingunNegocio.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                MsgBox("Debe marcar: ¿Invirtió el crédito en el negocio?.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.Visita Then

                If Not (Rd4Contado.Checked Or Rd4Credito.Checked Or Rd4LasDos.Checked) Then
                    MsgBox("Debe marcar: ¿Cómo realiza sus ventas?.", vbCritical, "Error")
                    Return False
                End If

                If Not (Rd5Si.Checked Or Rd5No.Checked) Then
                    MsgBox("Debe marcar: ¿Anotas sus ventas?.", vbCritical, "Error")
                    Return False
                End If

                If Rd5Si.Checked And Not (Rd6Usted.Checked Or Rd6Familiar.Checked Or Rd6Otro.Checked) Then
                    MsgBox("Debe marcar: ¿Cómo realiza sus ventas?.", vbCritical, "Error")
                    Return False
                End If

            End If

            If Me.nModoGrabacion = ModoGrabacion.Anulamiento And Not (Rd3ObtuvoTrabajo.Checked Or Rd3SalioDelPais.Checked Or Rd3ProblemasSalud.Checked Or Rd3Otros.Checked) Then
                MsgBox("Debe marcar: Negocio Inactivo.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.Anulamiento And Rd3Otros.Checked And Trim(txt3Explique.Text).Length = 0 Then
                MsgBox("Debe marcar: Explique inactividad de negocio.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.NoEncontrada Then
                If Trim(txt1Observaciones.Text) = "" Then
                    MsgBox("Debe indicar este campo: Observaciones.", vbCritical, "Error")
                    Return False
                End If
            End If

            'Validacion de longitudes y desbordes de cualquier tipo
            If txt3Explique.Text.Length >= 199 Then
                MsgBox("Longitud de texto muy larga: Explique inactividad de negocio.", vbCritical, "Error")
                Return False
            End If

            If txt1Observaciones.Text.Length >= 299 Then
                MsgBox("Longitud de texto muy larga: Observaciones.", vbCritical, "Error")
                Return False
            End If

            If cboPromotor1.SelectedIndex = -1 Then
                MsgBox("Debe indicar un promotor.", vbCritical, "Error")
                Return False
            End If

            If Not IsDate(cdeFechaVisita1.Value) Then
                MsgBox("Debe indicar un fecha de visita.", vbCritical, "Error")
                Return False
            End If

            If CDate(cdeFechaVisita1.Value) > fechaServer Then
                MsgBox("No debe sobrepasar la fecha Actual.", vbCritical, "Error")
                Return False
            End If

            Dim consulta As New BOSistema.Win.XComando
            Dim str As String = "Select sValorParametro from StbValorParametro where nStbParametroID=118"
            Dim valida_fecha_limite As Integer = consulta.ExecuteScalar(str)

            If valida_fecha_limite Then
                If CDate(cdeFechaVisita1.Value) <= DateAdd(DateInterval.Day, -8, fechaServer) Then
                    MsgBox("Esta ficha tendría 8 días de que se visitó y no se registró en sistema. Revise la fecha de Visita.", vbCritical, "Error")
                    Return False
                End If
            End If

        ElseIf Me.intNumeroVisita = 2 Then

            If Me.nModoGrabacion = ModoGrabacion.Visita Then
                'Validacion llenar campos
                If Not (Rd7Si.Checked Or Rd7No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿Le ha hecho mejoras a su negocio?.", vbCritical, "Error")
                    Return False
                End If
                If Not (Rd8Si.Checked Or Rd8No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿Se ha estado reuniendo con el grupo solidario?.", vbCritical, "Error")
                    Return False
                End If
                If Rd8Si.Checked And Trim(txt8ParaQue.Text).Length = 0 And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe llenar: ¿Para qué se reúne con el grupo solidario?.", vbCritical, "Error")
                    Return False
                End If
                If Not (Rd10Si.Checked Or Rd10No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿Diversificó el negocio?.", vbCritical, "Error")
                    Return False
                End If
                If Rd10Si.Checked And (Trim(txt11Productos.Text).Length = 0) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe llenar: Tipo de productos que agregó.", vbCritical, "Error")
                    Return False
                End If
                If Rd10Si.Checked And (Trim(cne12Monto.Text).Length = 0 Or cne12Monto.Value = 0.00) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe llenar: Monto de la inversión, a su vez debe ser distinto de cero.", vbCritical, "Error")
                    Return False
                End If
                If Not (Rd13Si.Checked Or Rd13No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿Trata con respeto a los clientes?.", vbCritical, "Error")
                    Return False
                End If
                If Not (Rd14Si.Checked Or Rd14No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿Responde con buena información y amabilidad?.", vbCritical, "Error")
                    Return False
                End If
                If Not (Rd15Si.Checked Or Rd15No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: Local limpio e higiénico.", vbCritical, "Error")
                    Return False
                End If
            End If



            If Me.nModoGrabacion = ModoGrabacion.Anulamiento And Not (Rd17ObtuvoTrabajo.Checked Or Rd17SalioDelPais.Checked Or Rd17ProblemasSalud.Checked Or Rd17Otros.Checked) Then
                MsgBox("Debe marcar: Negocio Inactivo.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.Anulamiento And Rd17Otros.Checked And Trim(txt17Explique.Text).Length = 0 Then
                MsgBox("Debe marcar: Explique inactividad de negocio.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.NoEncontrada Then
                If Trim(txt2Observaciones.Text) = "" Then
                    MsgBox("Debe indicar este campo: Observaciones.", vbCritical, "Error")
                    Return False
                End If
            End If

            'Validacion de longitudes y desbordes de cualquier tipo
            If txt8ParaQue.Text.Length >= 200 Then
                MsgBox("Longitud de texto muy larga: ¿Para qué se reúne con el grupo solidario?.", vbCritical, "Error")
                Return False
            End If
            If txt11Productos.Text.Length >= 200 Then
                MsgBox("Longitud de texto muy larga: Tipo de producto que agregó.", vbCritical, "Error")
                Return False
            End If
            If txt2Observaciones.Text.Length >= 300 Then
                MsgBox("Longitud de texto muy larga: Observaciones.", vbCritical, "Error")
                Return False
            End If

            If cboPromotor2.SelectedIndex = -1 Then
                MsgBox("Debe indicar un promotor.", vbCritical, "Error")
                Return False
            End If

            If Not IsDate(cdeFechaVisita2.Value) Then
                MsgBox("Debe indicar un fecha de visita.", vbCritical, "Error")
                Return False
            End If

            If CDate(cdeFechaVisita2.Value) > fechaServer Then
                MsgBox("No debe sobrepasar la fecha Actual.", vbCritical, "Error")
                Return False
            End If

            Dim consulta As New BOSistema.Win.XComando
            Dim str As String = "Select sValorParametro from StbValorParametro where nStbParametroID=118"
            Dim valida_fecha_limite As Integer = consulta.ExecuteScalar(str)

            If valida_fecha_limite Then
                If CDate(cdeFechaVisita2.Value) <= DateAdd(DateInterval.Day, -8, fechaServer) Then
                    MsgBox("Esta ficha tendría 8 días de que se visitó y no se registró en sistema. Revise la fecha de Visita.", vbCritical, "Error")
                    Return False
                End If
            End If
        ElseIf Me.intNumeroVisita = 3 Then

            If Me.nModoGrabacion = ModoGrabacion.Visita Then
                'Validacion llenar campos
                If Not (Rd17Infraestructura.Checked Or Rd17Equipos.Checked Or Rd17Mobiliario.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: Mejoras en el local del negocio.", vbCritical, "Error")
                    Return False
                End If
                If Not (Rd18Si.Checked Or Rd18No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿De sus ganancias realiza ahorro?.", vbCritical, "Error")
                    Return False
                End If

                If (Rd18Si.Checked = True) Then
                    If Not IsDBNull(Me.cne19Porcentaje.Value) And (Me.nModoGrabacion <> ModoGrabacion.Anulamiento) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                        If Me.cne19Porcentaje.Value = 0.00 Then
                            MsgBox("Debe llenar: Porcentaje de ahorro, a su vez debe ser distinto de cero.", vbCritical, "Error")
                            Return False
                        End If
                    End If
                End If

                If Not (Rd20Si.Checked Or Rd20No.Checked) And (Me.nModoGrabacion <> ModoGrabacion.NoEncontrada) Then
                    MsgBox("Debe marcar: ¿Considera usted que el crédito le ha ayudado a mejorar su calidad de vida y la de su familia?.", vbCritical, "Error")
                    Return False
                End If
            End If


            If Me.nModoGrabacion = ModoGrabacion.Anulamiento And Not (Rd22ObtuvoTrabajo.Checked Or Rd22SalioDelPais.Checked Or Rd22ProblemasSalud.Checked Or Rd22Otros.Checked) Then
                MsgBox("Debe marcar: Negocio Inactivo.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.Anulamiento And Rd22Otros.Checked And Trim(txt22Explique.Text).Length = 0 Then
                MsgBox("Debe marcar: Explique inactividad de negocio.", vbCritical, "Error")
                Return False
            End If

            If Me.nModoGrabacion = ModoGrabacion.NoEncontrada Then
                If Trim(txt3Observaciones.Text) = "" Then
                    MsgBox("Debe indicar este campo: Observaciones.", vbCritical, "Error")
                    Return False
                End If
            End If

            'Validacion de longitudes y desbordes de cualquier tipo
            If Not IsDBNull(cne19Porcentaje.Value) Then
                If cne19Porcentaje.Value > 100 Then
                    MsgBox("Porcentaje no válido.", vbCritical, "Error")
                    Return False
                End If
            End If

            If txt3Observaciones.Text.Length >= 300 Then
                MsgBox("Longitud de texto muy larga: Observaciones.", vbCritical, "Error")
                Return False
            End If

            If cboPromotor3.SelectedIndex = -1 Then
                MsgBox("Debe indicar un promotor.", vbCritical, "Error")
                Return False
            End If

            If Not IsDate(cdeFechaVisita3.Value) Then
                MsgBox("Debe indicar un fecha de visita.", vbCritical, "Error")
                Return False
            End If

            If CDate(cdeFechaVisita3.Value) > fechaServer Then
                MsgBox("No debe sobrepasar la fecha Actual.", vbCritical, "Error")
                Return False
            End If

            Dim consulta As New BOSistema.Win.XComando
            Dim str As String = "Select sValorParametro from StbValorParametro where nStbParametroID=118"
            Dim valida_fecha_limite As Integer = consulta.ExecuteScalar(str)

            If valida_fecha_limite Then
                If CDate(cdeFechaVisita3.Value) <= DateAdd(DateInterval.Day, -8, fechaServer) Then
                    MsgBox("Esta ficha tendría 8 días de que se visitó y no se registró en sistema. Revise la fecha de Visita.", vbCritical, "Error")
                    Return False
                End If
            End If

        End If
        Return True
    End Function

    Private Sub SalvarFicha()
        Dim cmd As New BOSistema.Win.XComando
        Dim strsql As String

        Try
            strsql = ArmarCadenaSQL()
            cmd.ExecuteNonQuery(strsql)
            MsgBox("Se actualizó la información correctamente.", vbInformation, "Correcto")
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Function ArmarCadenaSQL() As String
        Dim strsql As String = "EXEC spSclGrabarVisitaDetalle "
        strsql &= Me.intSeguimientoVisitaID & ", "
        If Me.intNumeroVisita = 1 Then
            strsql &= Me.cboPromotor1.SelectedValue & ", "
            strsql &= "'" & Format(Me.cdeFechaVisita1.Value, "yyyy-MM-dd") & "', "
            strsql &= IIf(Me.Rd1Si.Checked, 1, IIf(Rd1No.Checked, 0, 2)) & ", "

            'strsql &= IIf(Me.Rd2aSi.Checked, 1, IIf(Rd2aNo.Checked, 0, 2)) & ", "
            'strsql &= "'" & Trim(Me.txt2PorQue.Text) & "', "
            strsql &= IIf(Rd2NegocioPropuesto.Checked, 1, IIf(Rd2OtrosNegocios.Checked, 2, IIf(Rd2NingunNegocio.Checked, 3, 4))) & ", "
            strsql &= IIf(Rd3ObtuvoTrabajo.Checked, 1, IIf(Rd3SalioDelPais.Checked, 2, IIf(Rd3ProblemasSalud.Checked, 3, IIf(Rd3Otros.Checked, 4, 5)))) & ", "
            strsql &= "'" & txt3Explique.Text & "', "



            strsql &= IIf(Me.Rd4Contado.Checked, 1, IIf(Rd4Credito.Checked, 2, IIf(Rd4LasDos.Checked, 3, 4))) & ", "
            strsql &= IIf(Me.Rd5Si.Checked, 1, IIf(Rd5No.Checked, 0, 2)) & ", "
            strsql &= IIf(Me.Rd6Usted.Checked, 1, IIf(Rd6Familiar.Checked, 2, IIf(Rd6Otro.Checked, 3, 4))) & ", "
            strsql &= "'" & Trim(Me.txt1Observaciones.Text) & "', "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= Me.intNumeroVisita & ", "
            strsql &= "'" & Me.ModoFrm & "', "
            strsql &= Me.nPlazoAprobado & ", "
            strsql &= Me.nModoGrabacion
        ElseIf Me.intNumeroVisita = 2 Then
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= Me.cboPromotor2.SelectedValue & ", "
            strsql &= "'" & Format(Me.cdeFechaVisita2.Value, "yyyy-MM-dd") & "', "
            strsql &= IIf(Rd17ObtuvoTrabajo.Checked, 1, IIf(Rd17SalioDelPais.Checked, 2, IIf(Rd17SalioDelPais.Checked, 3, IIf(Rd17Otros.Checked, 4, 5)))) & ", "
            strsql &= "'" & txt17Explique.Text & "', "
            strsql &= IIf(Me.Rd7Si.Checked, 1, IIf(Rd7No.Checked, 0, 2)) & ", "
            strsql &= IIf(Me.Rd8Si.Checked, 1, IIf(Rd8No.Checked, 0, 2)) & ", "
            strsql &= "'" & Trim(Me.txt8ParaQue.Text) & "', "
            strsql &= IIf(Me.Rd10Si.Checked, 1, IIf(Rd10No.Checked, 0, 2)) & ", "
            strsql &= "'" & Trim(Me.txt11Productos.Text) & "', "
            strsql &= CDbl(IIf(Not IsDBNull(cne12Monto.Value), cne12Monto.Value, 0)) & ", "
            strsql &= IIf(Me.Rd13Si.Checked, 1, IIf(Rd13No.Checked, 0, 2)) & ", "
            strsql &= IIf(Me.Rd14Si.Checked, 1, IIf(Rd14No.Checked, 0, 2)) & ", "
            strsql &= IIf(Me.Rd15Si.Checked, 1, IIf(Rd15No.Checked, 0, 2)) & ", "
            strsql &= "'" & Trim(Me.txt2Observaciones.Text) & "', "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= Me.intNumeroVisita & ", "
            strsql &= "'" & Me.ModoFrm & "', "
            strsql &= Me.nPlazoAprobado & ", "
            strsql &= Me.nModoGrabacion
        ElseIf Me.intNumeroVisita = 3 Then
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= "NULL, "
            strsql &= Me.cboPromotor3.SelectedValue & ", "
            strsql &= "'" & Format(Me.cdeFechaVisita3.Value, "yyyy-MM-dd") & "', "
            strsql &= IIf(Rd22ObtuvoTrabajo.Checked, 1, IIf(Rd22SalioDelPais.Checked, 2, IIf(Rd22SalioDelPais.Checked, 3, IIf(Rd22Otros.Checked, 4, 5)))) & ", "
            strsql &= "'" & txt22Explique.Text & "', "
            strsql &= IIf(Me.Rd17Infraestructura.Checked, 1, IIf(Rd17Equipos.Checked, 2, IIf(Rd17Mobiliario.Checked, 3, 4))) & ", "
            strsql &= IIf(Me.Rd18Si.Checked, 1, IIf(Rd18No.Checked, 0, 2)) & ", "
            strsql &= CDbl(IIf(Not IsDBNull(cne19Porcentaje.Value), cne19Porcentaje.Value, 0)) & ", "
            strsql &= IIf(Me.Rd20Si.Checked, 1, IIf(Rd20No.Checked, 0, 2)) & ", "
            strsql &= "'" & Trim(Me.txt3Observaciones.Text) & "', "
            strsql &= Me.intNumeroVisita & ", "
            strsql &= "'" & Me.ModoFrm & "', "
            strsql &= Me.nPlazoAprobado & ", "
            strsql &= Me.nModoGrabacion
        End If

        Return strsql
    End Function

#Region "Validaciones Visuales"

    'Private Sub Rd2Si_CheckedChanged(sender As Object, e As EventArgs) Handles Rd2aSi.CheckedChanged
    '    If Rd2aSi.Checked = False Then
    '        txt2PorQue.Enabled = True
    '    Else
    '        txt2PorQue.Enabled = False
    '        txt2PorQue.Text = ""
    '    End If
    'End Sub

    Private Sub Rd8Si_CheckedChanged(sender As Object, e As EventArgs) Handles Rd8Si.CheckedChanged
        If Rd8Si.Checked = True Then
            txt8ParaQue.Enabled = True
        Else
            txt8ParaQue.Enabled = False
            txt8ParaQue.Text = ""
        End If
    End Sub

    Private Sub Rd10Si_CheckedChanged(sender As Object, e As EventArgs) Handles Rd10Si.CheckedChanged
        If Rd10Si.Checked = True Then
            grp13.Enabled = True
            grp12.Enabled = True
        Else
            grp13.Enabled = False
            grp12.Enabled = False
            txt11Productos.Text = ""
            cne12Monto.Value = 0.00
        End If
    End Sub

    Private Sub Rd18Si_CheckedChanged(sender As Object, e As EventArgs) Handles Rd18Si.CheckedChanged
        If Rd18Si.Checked = True Then
            grp20.Enabled = True
        Else
            grp20.Enabled = False
            cne19Porcentaje.Value = 0.00
        End If
    End Sub

    Private Sub Rd18No_CheckedChanged(sender As Object, e As EventArgs) Handles Rd18No.CheckedChanged
        If Rd18Si.Checked = True Then
            grp20.Enabled = True
        Else
            grp20.Enabled = False
            cne19Porcentaje.Value = 0.00
        End If
    End Sub

    Private Sub Rd10No_CheckedChanged(sender As Object, e As EventArgs) Handles Rd10No.CheckedChanged
        If Rd10Si.Checked = True Then
            grp13.Enabled = True
            grp12.Enabled = True
        Else
            grp13.Enabled = False
            grp12.Enabled = False
            txt11Productos.Text = ""
            cne12Monto.Value = 0.00
        End If
    End Sub

    Private Sub Rd8No_CheckedChanged(sender As Object, e As EventArgs) Handles Rd8No.CheckedChanged
        If Rd8Si.Checked = True Then
            txt8ParaQue.Enabled = True
        Else
            txt8ParaQue.Enabled = False
            txt8ParaQue.Text = ""
        End If
    End Sub

    Private Sub Rd3Otros_CheckedChanged(sender As Object, e As EventArgs) Handles Rd3Otros.CheckedChanged
        txt3Explique.Enabled = Rd3Otros.Checked
        If txt3Explique.Enabled = False Then
            txt3Explique.Clear()
        End If
    End Sub

    Private Sub Rd17Otros_CheckedChanged(sender As Object, e As EventArgs) Handles Rd17Otros.CheckedChanged
        txt17Explique.Enabled = Rd17Otros.Checked
        If txt17Explique.Enabled = False Then
            txt17Explique.Clear()
        End If
    End Sub

    Private Sub Rd22Otros_CheckedChanged(sender As Object, e As EventArgs) Handles Rd22Otros.CheckedChanged
        txt22Explique.Enabled = Rd22Otros.Checked
        If txt22Explique.Enabled = False Then
            txt22Explique.Clear()
        End If
    End Sub

#End Region
End Class