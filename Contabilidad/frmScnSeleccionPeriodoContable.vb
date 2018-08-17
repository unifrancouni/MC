Public Class frmScnSeleccionPeriodoContable
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim XcDatos As New BOSistema.Win.XComando

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim ObjFrmFNC As New frmScnProcesoCDR
        Try
            If My.Application.OpenForms.Count > My.Forms.frmPrincipal.VentanasPermitidas Then
                Exit Sub
            End If
            ObjFrmFNC.MdiParent = FrmMDIContabilidad
            ObjFrmFNC.ColorVentana = "CelesteLight"
            ObjFrmFNC.nScnPeriodo = cboPeriodoContable.SelectedValue
            ObjFrmFNC.ShowDialog()
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmFNC.Close()
            ObjFrmFNC = Nothing
        End Try
    End Sub

    Private Sub frmScnSeleccionPeriodoContable_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            Inicializar()

            CargarPeriodo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub Inicializar()
        XdsCombos = New BOSistema.Win.XDataSet()
    End Sub

    Private Sub CargarPeriodo()
        Try
            Dim Strsql, Strsql2 As String


            Strsql = "select a.nScnPeriodoContableID, a.sDescripcionMes+' '+cast(a.nAnio as varchar(4)) periodo from ScnPeriodoContable a order by nAnio desc, nMes desc"

            Strsql2 = "select nScnPeriodoContableID from vwScnUltimoPeriodoContable"

            If XdsCombos.ExistTable("Periodo") Then
                XdsCombos("Periodo").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Periodo")
                XdsCombos("Periodo").Retrieve()
            End If

            Dim ultimo As Integer
            ultimo = XcDatos.ExecuteScalar(Strsql2)

            'Asignando a las fuentes de datos
            Me.cboPeriodoContable.DataSource = XdsCombos("Periodo").Source

            'Configurar el combo
            Me.cboPeriodoContable.Splits(0).DisplayColumns("periodo").Width = 150

            Me.cboPeriodoContable.Columns("periodo").Caption = "Año"
            Me.cboPeriodoContable.Columns("nScnPeriodoContableID").Caption = "Código"


            Me.cboPeriodoContable.DisplayMember = "periodo"
            Me.cboPeriodoContable.ValueMember = "nScnPeriodoContableID"

            Me.cboPeriodoContable.SelectedValue = ultimo

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class