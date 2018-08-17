Imports BOSistema.Win

Public Class frmSccInformesBancor

    Dim xdt As New XDataSet

    Public intReporte As Integer = 0

    Public Enum EnumReportes

        DetalleCartera = 1 'Detalle de Cartera por Clasificacion
        Rubro = 2 'Detalle de cartera por Rubro
        RubroDelegacion = 3 'Detalle de cartera por Rubro y Delegacion
        Fondos = 4 'Detalle de cartera por Rubro y Delegacion
        Colocaciones = 5 'Colocaciones y cartera
        Estratos = 6 'Detalle de cartera por Estratos
        Plazos = 7 'Detalle de cartera por Plazos
        Creditos = 8 'Consolidado Créditos por Clasificación
        ClasificacionActividad = 9 'Detalle de Cartera por Clasificacion
        CreditosClasificacionActividad = 10 'Consolidado de creditos por clasificacion y actividad
        ReporteCartera = 11 'Reporte Oficial de Cartera CC94

    End Enum

    Private Sub frmSccInformesBancor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            CargarMeses()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try

    End Sub

    Private Sub CargarMeses()

        If xdt.ExistTable("Meses") Then
            xdt("Meses").ExecuteSql("ex_sql_desa 'spListaMeses', 'SMUSURA0_Cierre', 'sp'")
        Else
            xdt.NewTable("ex_sql_desa 'spListaMeses', 'SMUSURA0_Cierre', 'sp'", "Meses")
            xdt("Meses").Retrieve()
        End If

        cboMes.DataSource = xdt("Meses").Source

        cboMes.Splits(0).DisplayColumns().Item("nMes").Visible = False

        cboMes.DisplayMember = "Mes"
        cboMes.ValueMember = "nMes"

        cboMes.SelectedIndex = 0

    End Sub

    Private Sub CargarAños()

        If xdt.ExistTable("Anios") Then
            xdt("Anios").ExecuteSql("ex_sql_desa 'spListaAnios " & cboMes.SelectedValue & "', 'SMUSURA0_Cierre', 'sp'")
        Else
            xdt.NewTable("ex_sql_desa 'spListaAnios " & cboMes.SelectedValue & "', 'SMUSURA0_Cierre', 'sp'", "Anios")
            xdt("Anios").Retrieve()
        End If

        cboAño.DataSource = xdt("Anios").Source

        cboAño.Splits(0).DisplayColumns("nMes").Visible = False
        cboAño.Splits(0).DisplayColumns("nAnio").HeadingStyle.HorizontalAlignment = C1.Win.C1List.AlignHorzEnum.General
        cboAño.Splits(0).DisplayColumns("nAnio").Style.HorizontalAlignment = C1.Win.C1List.AlignHorzEnum.Near
        cboAño.Columns("nAnio").Caption = "Año"

        cboAño.DisplayMember = "nAnio"
        cboAño.ValueMember = "nAnio"

        cboAño.SelectedIndex = 0

    End Sub

    Private Sub cboMes_TextChanged(sender As Object, e As EventArgs) Handles cboMes.TextChanged
        CargarAños()
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        frmVisor.Parametros("@nMes") = Me.cboMes.SelectedValue
        frmVisor.Parametros("@nAnio") = Me.cboAño.SelectedValue
        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
        frmVisor.Text = "Detalle de Cartera por Clasificación"

        Select Case Me.intReporte
            Case EnumReportes.Creditos
                frmVisor.NombreReporte = "RepSccCC94.1.rpt"
            Case EnumReportes.DetalleCartera
                frmVisor.NombreReporte = "RepSccCC94.rpt"
            Case EnumReportes.Fondos
                frmVisor.NombreReporte = "Bancor01.rpt"
            Case EnumReportes.Colocaciones
                frmVisor.NombreReporte = "Bancor02.rpt"
            Case EnumReportes.Estratos
                frmVisor.NombreReporte = "Bancor03.rpt"
            Case EnumReportes.Plazos
                frmVisor.NombreReporte = "Bancor04.rpt"
            Case EnumReportes.Rubro
                frmVisor.NombreReporte = "Bancor07.rpt"
            Case EnumReportes.RubroDelegacion
                frmVisor.NombreReporte = "Bancor08.rpt"
            Case EnumReportes.ClasificacionActividad
                frmVisor.NombreReporte = "Bancor09.rpt"
            Case EnumReportes.CreditosClasificacionActividad
                frmVisor.NombreReporte = "Bancor09.1.rpt"
            Case EnumReportes.ReporteCartera
                frmVisor.NombreReporte = "RepSccCC94.2.rpt"
        End Select

        frmVisor.CustomServer(0) = "UCERO-MG1-DESA"
        frmVisor.CustomServer(1) = "SMUSURA0_Cierre"
        frmVisor.CustomServer(2) = "desa"
        frmVisor.CustomServer(3) = "desa"
        frmVisor.WindowState = FormWindowState.Maximized
        frmVisor.Show()

    End Sub
End Class