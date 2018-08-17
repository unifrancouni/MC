Public Class FrmSccParametroNotaCredito
    Dim XdsCombos As BOSistema.Win.XDataSet
    Private Sub CargarEstado()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion, 1 as Orden " & _
                     " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                     " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                     " WHERE (b.sNombre = 'EstadoNotaDebitoCredito')" & _
                     " ORDER BY a.sCodigoInterno"

            If XdsCombos.ExistTable("Estado") Then
                XdsCombos("Estado").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Estado")
                XdsCombos("Estado").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboEstadoNota.DataSource = XdsCombos("Estado").Source

            Me.CboEstadoNota.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.CboEstadoNota.Splits(0).DisplayColumns("Orden").Visible = False
            Me.CboEstadoNota.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboEstadoNota.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.CboEstadoNota.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.CboEstadoNota.Columns("sCodigoInterno").Caption = "Código"
            Me.CboEstadoNota.Columns("sDescripcion").Caption = "Descripción"

            Me.CboEstadoNota.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboEstadoNota.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboEstadoNota.ListCount > 0 Then
                XdsCombos("Estado").AddRow()
                XdsCombos("Estado").ValueField("sDescripcion") = "Todos"
                XdsCombos("Estado").ValueField("nStbValorCatalogoID") = -19
                XdsCombos("Estado").ValueField("Orden") = 0
                XdsCombos("Estado").UpdateLocal()
                XdsCombos("Estado").Sort = "Orden, sCodigoInterno asc"
                Me.CboEstadoNota.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False

            If Me.RdoFechaNota.Checked Then

                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válido.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If

                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                    Me.CdeFechaFinal.Focus()
                    GoTo SALIR
                End If
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If

                VbResultado = True
            Else
                VbResultado = True
            End If
            
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        '----------------------------------------------------------------------
        'Llama al reporte del listado de recibos
        '----------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim CadSql As String
        Dim Filtro As String

        Try


            If ValidarParametros() = False Then Exit Sub
            Me.errParametro.Clear()

            frmVisor.Text = "Listado de Notas de Debitos-Creditos"
            frmVisor.NombreReporte = "RepSccCC73.rpt"
            CadSql = "SELECT     nSccNotaID, nCodigoN,SCodigo, nMonto,nMontoFicha, Socia, CodGrupo, NombreGrupo, nSclFichaNotificacionID, nCodigoFNC, sNumSesion, sNumeroCedula, sCodigoInterno,  dFechaNota, dFechaTipoCambio, nSclFichaNotificacionDetalleID, nSccSolicitudChequeID, sDescripcion, nScnFuenteFinanciamientoID, sConceptoNota FROM         dbo.vwSccNotaCreditoDebitoReporte "
            If Me.RdoFechaNota.Checked Then
                Filtro = " Where dFechaNota>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') And dFechaNota<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "
            Else
                Filtro = " Where year(dFechaPago)= " & Convert.ToInt32(Me.ndAnio.Value)
                If CboMeses.SelectedIndex > 0 Then
                    Filtro = Filtro & " and  month(dFechaPago)= " & CboMeses.SelectedIndex
                End If

            End If

            If Me.CboEstadoNota.SelectedIndex > 0 Then
                Filtro = Filtro & "  And  ScodigoInterno= '" & Me.CboEstadoNota.Columns("ScodigoInterno").Value & "'"
            End If

            If Me.CboFuentes.SelectedIndex > 0 Then
                Filtro = Filtro & "  And  nScnFuenteFinanciamientoID = " & Me.CboFuentes.Columns("nScnFuenteFinanciamientoID").Value
            End If
            frmVisor.Formulas("DesFuenteFinanciamiento") = "'" & IIf(Me.CboFuentes.SelectedIndex = 0, " TODAS LAS FUENTES DE FINANCIAMIENTO ", " FUENTE FINANCIAMIENTO: " & Me.CboFuentes.Text) & "'"

            frmVisor.Formulas("RangoFecha") = "'REPORTE DE NOTAS DE DEBITO-CREDITO DEL " & IIf(Not Me.RdoAnio.Checked, cdeFechaInicial.Value & " AL " & CdeFechaFinal.Value & " '", " Al :" & ndAnio.Value.ToString() & "'")

            frmVisor.SQLQuery = CadSql & " " & Filtro & " Order By nCodigon asc"

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"







            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSccParametroNotaCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try


            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarFuente()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String
           
            Strsql = "SELECT     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
                                     " FROM         dbo.ScnFuenteFinanciamiento a Order By a.sCodigo "


            If XdsCombos.ExistTable("Fuente") Then
                XdsCombos("Fuente").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Fuente")
                XdsCombos("Fuente").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboFuentes.DataSource = XdsCombos("Fuente").Source
            Me.CboFuentes.Rebind()
            Me.CboFuentes.Refresh()

            Me.CboFuentes.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.CboFuentes.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboFuentes.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.CboFuentes.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.CboFuentes.Splits(0).DisplayColumns("sNombre").Width = 160

            Me.CboFuentes.Columns("sCodigo").Caption = "Código"
            Me.CboFuentes.Columns("sNombre").Caption = "Nombre"

            Me.CboFuentes.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboFuentes.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.CboFuentes.ListCount > 0 Then
                XdsCombos("Fuente").AddRow()
                XdsCombos("Fuente").ValueField("sNombre") = "Todos"
                XdsCombos("Fuente").ValueField("sCodigo") = -19
                XdsCombos("Fuente").ValueField("Orden") = 0
                XdsCombos("Fuente").UpdateLocal()
                XdsCombos("Fuente").Sort = "Orden,sCodigo asc"
                Me.CboFuentes.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarMeses()
        CboMeses.AddItem("Todos")
        CboMeses.AddItem("Enero")
        CboMeses.AddItem("Febrero")
        CboMeses.AddItem("Marzo")
        CboMeses.AddItem("Abril")
        CboMeses.AddItem("Mayo")
        CboMeses.AddItem("Junio")
        CboMeses.AddItem("Julio")
        CboMeses.AddItem("Agosto")
        CboMeses.AddItem("Septiembre")
        CboMeses.AddItem("Octubre")
        CboMeses.AddItem("Noviembre")
        CboMeses.AddItem("Diciembre")
        CboMeses.SelectedIndex = 0
    End Sub
    Private Sub FrmSccParametroNotaCredito_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            XdsCombos = New BOSistema.Win.XDataSet
            CargarEstado()
            Me.CargarFuente()
            CargarMeses()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

   
    Private Sub RdoFechaNota_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoFechaNota.CheckedChanged
        HabilitarControles()
    End Sub

    Private Sub HabilitarControles()
        Dim Enabled As Boolean = RdoFechaNota.Checked

        Me.grpFechaNota.Enabled = Enabled
        Me.grpAnioAfectado.Enabled = Not Enabled

    End Sub

    Private Sub RdoAnio_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RdoAnio.CheckedChanged
        HabilitarControles()
    End Sub
End Class