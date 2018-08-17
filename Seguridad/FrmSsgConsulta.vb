Public Class FrmSsgConsulta
    Dim IntPermiteConsultar As Integer
    Dim IntDepartamento As Integer
    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim mColorVentana As String

    Public Property ColorVentana() As String
        Get
            Return mColorVentana
        End Get
        Set(ByVal value As String)
            mColorVentana = value
        End Set
    End Property

    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet
            cboTipoOperación.Items.Add("Insertar")
            cboTipoOperación.Items.Add("Borrar")
            cboTipoOperación.Items.Add("Actualizar")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Procedure Name:       CargarTabla
    ' Descripción:          Este procedimiento permite cargar el listado de Tablas
    '-------------------------------------------------------------------------
    Private Sub CargarTabla()
        Try
            Dim Strsql As String

            Strsql = "Select SarTablaID, Nombre From SarTabla"
            If XdsCombos.ExistTable("Tabla") Then
                XdsCombos("Tabla").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Tabla")
                XdsCombos("Tabla").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTabla.DataSource = XdsCombos("Tabla").Source
            Me.cboTabla.Splits(0).DisplayColumns("SarTablaID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTabla.Splits(0).DisplayColumns("Nombre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.cboTabla.Splits(0).DisplayColumns("SarTablaID").Width = 43
            Me.cboTabla.Splits(0).DisplayColumns("Nombre").Width = 185
            Me.cboTabla.Columns("SarTablaID").Caption = "Código"
            Me.cboTabla.Columns("Nombre").Caption = "Descripción"
            Me.cboTabla.Splits(0).DisplayColumns("SarTablaID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTabla.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean

        Try
            VbResultado = False
            Me.errParametro.Clear()

            If IsDBNull(cdeFechaInicial.Value) Then
                MsgBox("Debe seleccionar una fecha inicial válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial válida.")
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
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim strTipo As String = ""

        Try
            If ValidarParametros() = True Then
                frmVisor.WindowState = FormWindowState.Maximized
                frmVisor.NombreReporte = "RepSsgSG7.rpt"
                frmVisor.Text = "Listado de Auditoría del Sistema"

                If cboTipoOperación.Text <> "" Then
                    If cboTipoOperación.Text = "Insertar" Then
                        strTipo = "INS"
                    ElseIf cboTipoOperación.Text = "Borrar" Then
                        strTipo = "DEL"
                    ElseIf cboTipoOperación.Text = "Actualizar" Then
                        strTipo = "UPD"
                    End If
                End If

                If cboTabla.Text = "" And cboTipoOperación.Text = "" Then
                    frmVisor.SQLQuery = " Select * From vwAuditoria Where dFecha>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') and dFecha<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "')"
                ElseIf cboTabla.Text <> "" And cboTipoOperación.Text = "" Then
                    frmVisor.SQLQuery = " Select * From vwAuditoria Where Nombre='" & Trim(cboTabla.Text) & "' and dFecha>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') and dFecha<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "')"
                ElseIf cboTipoOperación.Text <> "" And cboTabla.Text = "" Then
                    frmVisor.SQLQuery = " Select * From vwAuditoria Where sCodOperacion='" & strTipo & "' and dFecha>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') and dFecha<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "')"
                ElseIf cboTipoOperación.Text <> "" And cboTabla.Text <> "" Then
                    frmVisor.SQLQuery = " Select * From vwAuditoria Where Nombre='" & Trim(cboTabla.Text) & "' and sCodOperacion='" & strTipo & "' and dFecha>=CONVERT(DATETIME,'" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') and dFecha<=CONVERT(DATETIME,'" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "')"
                End If
                frmVisor.ShowDialog()

                End If
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

    Private Sub FrmSsgConsulta_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSsgConsulta_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.ColorVentana)

            If Me.ColorVentana = "Verde" Then
                'If mNomRep = 5 Or mNomRep = 6 Then
                '    Me.HelpProvider.SetHelpKeyword(Me, "Indicadores (Reportes)")
                'Else
                '    Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Control de Crédito")
                'End If
            Else
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Auditoría")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarTabla()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

End Class