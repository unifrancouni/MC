Public Class frmScnParametroCatalogoContable
    Dim XdsCombos As BOSistema.Win.XDataSet

    Private Sub frmScnParametroCatalogoContable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "CelesteLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarFuente()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    Private Sub CargarFuente()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nScnFuenteFinanciamientoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From ScnFuenteFinanciamiento a " & _
                     " Order by a.sCodigo"
            'XdsCombos.NewTable(Strsql, "Fuente")
            'XdsCombos("Fuente").Retrieve()

            If XdsCombos.ExistTable("Fuente") Then
                XdsCombos("Fuente").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Fuente")
                XdsCombos("Fuente").Retrieve()
            End If

            'Asignando a las fuentes de datos


            'Me.cbcboFuentes()

            cboFuentes.DataSource = XdsCombos("Fuente").Source

            

            Me.cboFuentes.Splits(0).DisplayColumns("nScnFuenteFinanciamientoID").Visible = False
            Me.cboFuentes.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").Width = 40
            Me.cboFuentes.Splits(0).DisplayColumns("Descripcion").Width = 180

            Me.cboFuentes.Columns("sCodigo").Caption = "Código"
            Me.cboFuentes.Columns("Descripcion").Caption = "Descripción"

            Me.cboFuentes.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboFuentes.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboFuentes.ListCount > 0 Then
                XdsCombos("Fuente").AddRow()
                XdsCombos("Fuente").ValueField("Descripcion") = "Todas las fuentes"
                XdsCombos("Fuente").ValueField("nScnFuenteFinanciamientoID") = -19
                XdsCombos("Fuente").ValueField("Orden") = 0
                XdsCombos("Fuente").UpdateLocal()
                XdsCombos("Fuente").Sort = "Orden,sCodigo asc"
                Me.cboFuentes.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            
        End Try
    End Sub
    Private Sub InicializarVariables()
        Try

            'Inicializar las clases 
            XdsCombos = New BOSistema.Win.XDataSet
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False

            'Departamento
            If Me.cboFuentes.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una fuente de financiamento.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboFuentes, "Debe seleccionar una fuente de financiamiento.")
                Me.cboFuentes.Focus()
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
        '----------------------------------------------------------------------
        'Llama al reporte del listado de las fuentes de financiamiento
        '----------------------------------------------------------------------

        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Try
            If ValidarParametros() = False Then Exit Sub
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("Parametros") = "'" & Trim(cboFuentes.Text) & "'"
            frmVisor.NombreReporte = "RepScnCN3.rpt"
            frmVisor.Text = "Reporte de Cuentas del Catálogo Contable"
            Filtro = ""
            If cboFuentes.Columns("nScnFuenteFinanciamientoID").Value <> -19 Then
                If Trim(Filtro) = "" Then
                    Filtro = Filtro & " Where  nScnFuenteFinanciamientoID=" & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                Else
                    Filtro = Filtro & " And  nScnFuenteFinanciamientoID=" & cboFuentes.Columns("nScnFuenteFinanciamientoID").Value
                End If
            End If
            'frmVisor.RegistrosSeleccion = "{ScnEstructuraContable.nNivel} = 1"
            frmVisor.SQLQuery = "Select * From vwScnCatalogoContable " & Filtro & " order by sCodigoCuenta "

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
End Class





