Public Class frmSclParametrosFichasKioscos

    Private ds As BOSistema.Win.XDataSet

    Public Enum nReporte
        CS1 = 1
        K1 = 2
    End Enum

    Public NumReporte As nReporte = nReporte.CS1

    Private Sub frmSclParametrosFichasKioscos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            InicializarVariables()
            CargarDelegaciones()

            If Me.NumReporte = nReporte.K1 Then
                grpNivelDetalle.Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub Inicializarvariables()
        ds = New BOSistema.Win.XDataSet()
        cdeFechaInicial.Value = Now
        CdeFechaFinal.Value = Now
    End Sub

    Private Sub CargarDelegaciones()
        Dim strSQL As String
        strSQL = "SELECT TOP (100) PERCENT nStbDelegacionProgramaID, nCodigo, sNombreDelegacion
        FROM     dbo.StbDelegacionPrograma
        WHERE  (nActiva = 1) AND (nStbDelegacionProgramaID={0})
        ORDER BY sNombreDelegacion".Replace("{0}", InfoSistema.IDDelegacion)

        If ds.ExistTable("Delegaciones") Then
            ds("Delegaciones").ExecuteSql(strSQL)
        Else
            ds.NewTable(strSQL, "Delegaciones")
            ds("Delegaciones").Retrieve()
        End If

        Me.CboDelegacion.DataSource = ds("Delegaciones").Source

        'Configurar el combo
        Me.CboDelegacion.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
        Me.CboDelegacion.Splits(0).DisplayColumns("nCodigo").Visible = False
        Me.CboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
        Me.CboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").Width = 300

        Me.CboDelegacion.Columns("sNombreDelegacion").Caption = "Delegación"
        Me.CboDelegacion.Splits(0).DisplayColumns("sNombreDelegacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Me.CboDelegacion.DisplayMember = "sNombreDelegacion"
        Me.CboDelegacion.ValueMember = "nStbDelegacionProgramaID"

        Me.CboDelegacion.DropDownWidth = Me.CboDelegacion.Width

        Me.CboDelegacion.SelectedValue = InfoSistema.IDDelegacion

    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Me.Cursor = Cursors.WaitCursor
        Dim frmVisor As New frmCRVisorReporte

        Select Case NumReporte
            Case nReporte.CS1
                frmVisor.CustomServer(0) = "UCERO-PROD"
                frmVisor.CustomServer(1) = "SMKIOSKO"
                frmVisor.CustomServer(2) = "UsAcceso"
                frmVisor.CustomServer(3) = "usuracero"

                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy")
                frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy")
                frmVisor.Parametros("@nStbDelegacionProgramaID") = CboDelegacion.SelectedValue
                frmVisor.NombreReporte = "RepKskCS1.rpt"
                frmVisor.Text = "Fichas de Inscripción - Kioscos"
            Case nReporte.K1
                frmVisor.CustomServer(0) = "UCERO-PROD"
                frmVisor.CustomServer(1) = "SMKIOSKO"
                frmVisor.CustomServer(2) = "UsAcceso"
                frmVisor.CustomServer(3) = "usuracero"

                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                frmVisor.Formulas("PresentarDepartamentos") = IIf(ckDepartamentos.Checked, 1, 0)
                frmVisor.Formulas("PresentarMunicipios") = IIf(ckMunicipios.Checked, 1, 0)
                frmVisor.Formulas("PresentarDistritos") = IIf(ckDistritos.Checked, 1, 0)
                frmVisor.Formulas("PresentarBarrios") = IIf(ckBarrios.Checked, 1, 0)
                frmVisor.Formulas("PresentarEdecanes") = IIf(ckEdecanes.Checked, 1, 0)

                frmVisor.Parametros("@FechaINI") = Format(Me.cdeFechaInicial.Value, "dd/MM/yyyy")
                frmVisor.Parametros("@FechaFIN") = Format(Me.CdeFechaFinal.Value, "dd/MM/yyyy")
                frmVisor.Parametros("@nStbDelegacionProgramaID") = CboDelegacion.SelectedValue
                frmVisor.NombreReporte = "RepKskK1.rpt"
                frmVisor.Text = "Resumen de Atención - Kioscos"
        End Select


        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Show()
        Me.Cursor = Cursors.Default
    End Sub
End Class