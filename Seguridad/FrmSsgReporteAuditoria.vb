
Public Class FrmSsgReporteAuditoria

    Public Enum EnumReportes
        Auditoria_XML = 1
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Dim mNomRep As EnumReportes
    Dim XdsCombos As BOSistema.Win.XDataSet

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte

        Try
            If ValidaDatosEntrada() Then
                frmVisor.WindowState = FormWindowState.Maximized
                Select Case mNomRep
                    Case EnumReportes.Auditoria_XML

                        frmVisor.Formulas("RangoFechas") = "'DEL " & Format(Me.dtFechaInicial.Value, "yyyy/MM/dd") & " AL " & Format(Me.dtFechaFinal.Value, "yyyy/MM/dd") & " '"
                        frmVisor.Formulas("Parametros") = "' Fechas " & Format(Me.dtFechaInicial.Value, "yyyy-MM-dd") & " - " & Format(Me.dtFechaFinal.Value, "yyyy-MM-dd") & " Tabla: (" & Trim(cboTabla.Text) & ")" & "'"
                        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                        frmVisor.Formulas("StrModulo") = "'" & Trim(CboPrograma.Text) & "'"
                        frmVisor.Formulas("StrTabla") = "'" & Trim(cboTabla.Text) & "'"

                        frmVisor.NombreReporte = "RepSsgSG5.rpt"
                        frmVisor.Text = "Listado de Recibos de Caja"

                        frmVisor.Parametros("@tabla") = Trim(cboTabla.Text)
                        frmVisor.Parametros("@fechaI") = Format(Me.dtFechaInicial.Value, "yyyy-MM-dd")
                        frmVisor.Parametros("@fechaF") = Format(Me.dtFechaFinal.Value, "yyyy-MM-dd")

                End Select

                frmVisor.ShowDialog()

                'Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Function ValidaDatosEntrada() As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            ValidaDatosEntrada = True
            Me.errRecibo.Clear()

            'Tipo de Programa: 
            If Me.CboPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Módulo válido.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.CboPrograma, "Debe seleccionar un Módulo válido.")
                Me.CboPrograma.Focus()
                Exit Function
            End If

            If Me.cboTabla.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Tabla válida.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errRecibo.SetError(Me.cboTabla, "Debe seleccionar una Tabla válida.")
                Me.CboPrograma.Focus()
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSsgReporteAuditoria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsCombos.Close()
            XdsCombos = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmSsgReporteAuditoria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            If mNomRep = EnumReportes.Auditoria_XML Then
                ObjGUI.SetFormLayout(Me, "Oro")
                Me.HelpProvider.SetHelpKeyword(Me, "Reportes Módulo de Auditoría")
            End If

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace
            XdsCombos = New BOSistema.Win.XDataSet

            CargarTipoSistema()
            'Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub CargarTipoSistema()
        Dim Strsql As String = ""
        Try

            Strsql = "SELECT SarSistemaID, CodigoInterno, Nombre FROM SarSistema ORDER BY Nombre"

            If XdsCombos.ExistTable("Sistema") Then
                XdsCombos("Sistema").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Sistema")
                XdsCombos("Sistema").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.CboPrograma.DataSource = XdsCombos("Sistema").Source

            Me.CboPrograma.Splits(0).DisplayColumns("SarSistemaID").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("CodigoInterno").Visible = False
            Me.CboPrograma.Splits(0).DisplayColumns("Nombre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

            'Configurar el combo
            Me.CboPrograma.Splits(0).DisplayColumns("Nombre").Width = 150
            Me.CboPrograma.Columns("Nombre").Caption = "Descripción"
            Me.CboPrograma.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarTabla(ByVal intLimpiarID As Integer)
        Dim Strsql As String
        Try

            Me.cboTabla.ClearFields()
            If XdsCombos("Sistema").ValueField("SarSistemaID") = -19 Then
                Strsql = " SELECT SarTablaID, Nombre, objSistemaID FROM SarTabla ORDER BY Nombre"
            Else
                Strsql = "SELECT SarTablaID, Nombre, objSistemaID FROM SarTabla " & _
                         "WHERE objSistemaID = " & XdsCombos("Sistema").ValueField("SarSistemaID") & " ORDER BY Nombre"
            End If

            If XdsCombos.ExistTable("Tabla") Then
                XdsCombos("Tabla").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Tabla")
                XdsCombos("Tabla").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboTabla.DataSource = XdsCombos("Tabla").Source
            Me.cboTabla.Rebind()
            Me.cboTabla.Splits(0).DisplayColumns("SarTablaID").Visible = False
            Me.cboTabla.Splits(0).DisplayColumns("objSistemaID").Visible = False

            'Configurar el combo
            Me.cboTabla.Splits(0).DisplayColumns("Nombre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            Me.cboTabla.Splits(0).DisplayColumns("Nombre").Width = 100
            Me.cboTabla.Columns("Nombre").Caption = "Descripción"
            Me.cboTabla.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CboPrograma_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboPrograma.TextChanged
        If Me.CboPrograma.SelectedIndex <> -1 Then
            cboTabla.Enabled = True
            CargarTabla(0)
        Else
            cboTabla.Enabled = False
        End If
    End Sub

End Class