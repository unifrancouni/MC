
Public Class frmStbParametroListadoRpt
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes
    Public Enum EnumReportes
        ListadodeReportes = 1
    End Enum

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property
    Private Sub frmStbParametroListadoRpt_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            CargarNombreModulo()
            Me.cboModulo.Text = "Todos los módulos"

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarNombreModulo()
        Try
            Dim Strsql As String = ""
            Strsql = " SELECT     SsgModuloID, CodInterno, Nombre " & _
                    " FROM SsgModulo " & _
                    " ORDER BY Nombre"

            If XdsCombos.ExistTable("Modulo") Then
                XdsCombos("Modulo").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Modulo")
                XdsCombos("Modulo").Retrieve()
            End If

            Me.cboModulo.DataSource = XdsCombos("Modulo").Source
            Me.cboModulo.Rebind()

            Me.cboModulo.Splits(0).DisplayColumns("SsgModuloID").Visible = False
            Me.cboModulo.Splits(0).DisplayColumns("SsgModuloID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboModulo.Splits(0).DisplayColumns("CodInterno").Width = 50
            Me.cboModulo.Splits(0).DisplayColumns("Nombre").Width = 210

            Me.cboModulo.Columns("CodInterno").Caption = "Código"
            Me.cboModulo.Columns("Nombre").Caption = "Nombre"

            Me.cboModulo.Splits(0).DisplayColumns("CodInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboModulo.Splits(0).DisplayColumns("Nombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            If Me.cboModulo.ListCount > 0 Then
                XdsCombos("Modulo").AddRow()
                XdsCombos("Modulo").ValueField("Nombre") = "Todos los módulos"
                XdsCombos("Modulo").ValueField("SsgModuloID") = -19
                XdsCombos("Modulo").ValueField("Orden") = 0
                XdsCombos("Modulo").UpdateLocal()
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


    Private Sub HabilitarObjetos()

    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click

        '---------------------------------------------------------------------
        'Llama  a las opciones de los  reportes
        '---------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro, CadSql As String


        Dim XdtTmpPeriodoA As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        XdtTmpPeriodoA = New BOSistema.Win.XDataSet.xDataTable
        Try

            Filtro = " "
            If ValidarParametros() = False Then Exit Sub
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            If Me.cboModulo.Columns("Nombre").Value = "Todos los módulos" Then
                Filtro = " ORDER BY nCodigo "
            Else
                If Me.cboModulo.Columns("SsgModuloID").Value <> -19 Then
                    Filtro = " WHERE     (sNombreModulo = '" & Me.cboModulo.Columns("Nombre").Value & "') ORDER BY nCodigo"
                End If
            End If
            CadSql = ""
            frmVisor.NombreReporte = "RepStbCB16.rpt"
            frmVisor.Text = "Listado de Reportes"
            CadSql = " SELECT    *  FROM         vwStbReporteModulo"
            frmVisor.SQLQuery = CadSql & " " & Filtro
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try



    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False
            If Me.cboModulo.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Modulo.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboModulo, "Debe seleccionar un Modulo.")
                Me.cboModulo.Focus()
                GoTo SALIR
            End If
            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

End Class