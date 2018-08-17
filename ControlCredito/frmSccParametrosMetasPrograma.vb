Public Class frmSccParametrosMetasPrograma

    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String
    Dim strColorFrm As String
    'Propiedad utilizada para el setear el color del formulario
    Public Property strColor() As String
        Get
            strColor = strColorFrm
        End Get
        Set(ByVal value As String)
            strColorFrm = value
        End Set
    End Property

    'Listado de Reportes
    Public Enum EnumReportes
        rptPorAnio = 1
        SociasVentanaUsura = 2
    End Enum

    Dim mNomRep As EnumReportes

    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    Private Sub InicializarVariables()
        Try

            'Inicializar las clases 
            XdsCombos = New BOSistema.Win.XDataSet

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptPorAnio
                    Me.Text = "Parámetros Reporte Por Año"

                Case EnumReportes.SociasVentanaUsura
                    Me.Text = "Socias Ventana Género/Usura Cero"
                    Me.cboDistrito.Enabled = False
                    Me.cneAnio.Enabled = False

            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            If XdsCombos.ExistTable("Departamento") Then
                XdsCombos("Departamento").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Departamento")
                XdsCombos("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsCombos("Departamento").Source

            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Departamento").Count > 0 Then
            '    XdsCombos("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDepartamento.ListCount > 0 Then
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.cboDepartamento.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer)
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbMunicipio a " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsCombos.ExistTable("Municipio") Then
                XdsCombos("Municipio").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Municipio")
                XdsCombos("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsCombos("Municipio").Source
            Me.cboMunicipio.Rebind()

            'XdtValorParametro.Filter = "nStbParametroID = 15"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsCombos("Municipio").Count > 0 Then
            '    XdsCombos("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboMunicipio.ListCount > 0 Then
                XdsCombos("Municipio").AddRow()
                XdsCombos("Municipio").ValueField("Descripcion") = "Todos"
                XdsCombos("Municipio").ValueField("nStbMunicipioID") = -19
                XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Municipio").ValueField("Orden") = 0
                XdsCombos("Municipio").UpdateLocal()
                XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
                Me.cboMunicipio.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbDistrito a " & _
                             " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsCombos.ExistTable("Distrito") Then
                XdsCombos("Distrito").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Distrito")
                XdsCombos("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsCombos("Distrito").Source
            Me.cboDistrito.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDistrito.ListCount > 0 Then
                XdsCombos("Distrito").AddRow()
                XdsCombos("Distrito").ValueField("Descripcion") = "Todos"
                XdsCombos("Distrito").ValueField("nStbDistritoID") = -19
                XdsCombos("Distrito").ValueField("Orden") = 0
                XdsCombos("Distrito").UpdateLocal()
                XdsCombos("Distrito").Sort = "Orden,sCodigo asc"
                Me.cboDistrito.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0)
                'If Me.cboDistrito.ListCount > 0 Then
                '    Me.cboDistrito.SelectedIndex = 0
                'End If
                Me.cboDistrito.Enabled = False
                'CargarBarrio(0, 0)
            End If
        Else
            CargarDistrito(1)
        End If
    End Sub

    Private Function ValidarParametros() As Boolean

        'Declaracion de Variables 
        Dim VbResultado As Boolean

        Try
            VbResultado = False
            Me.errParametro.Clear()

            'Departamento
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                GoTo SALIR
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                GoTo SALIR
            End If

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                GoTo SALIR
            End If

            If Me.NomRep <> EnumReportes.SociasVentanaUsura Then
                If IsDBNull(Me.cneAnio.Value) Then
                    MsgBox("Debe seleccionar un año de 4 dígitos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cneAnio, "Debe seleccionar un año de 4 dígitos.")
                    Me.cneAnio.Focus()
                    GoTo SALIR
                End If
                If Len(Trim(Me.cneAnio.Text)) <> 4 Then
                    MsgBox("Debe seleccionar un año de 4 dígitos.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cneAnio, "Debe seleccionar un año de 4 dígitos.")
                    Me.cneAnio.Focus()
                    GoTo SALIR
                End If
            End If
            


            VbResultado = True
salir:
            Return VbResultado
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function

    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim Filtro As String = ""
        Dim frmVisor As New frmCRVisorReporte
        Try
            If ValidarParametros() = False Then
                Exit Sub
            End If

            Me.Cursor = Cursors.WaitCursor

            If Me.NomRep = EnumReportes.rptPorAnio Then

                Filtro = Filtro & " {vwSccMetasPrograma.AnioMeta}=" & Me.cneAnio.Value
                'Departamento:
                If cboDepartamento.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSccMetasPrograma.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    Else
                        Filtro = "{vwSccMetasPrograma.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                    End If
                End If
                'Municipio:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSccMetasPrograma.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = "{vwSccMetasPrograma.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If
                'Distrito:
                If cboDistrito.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSccMetasPrograma.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    Else
                        Filtro = "{vwSccMetasPrograma.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    End If
                End If

            ElseIf Me.NomRep = EnumReportes.SociasVentanaUsura Then
                'Departamento:
                If cboDepartamento.SelectedIndex > 0 Then
                    Filtro = "{vwSclSociasVentanaUsura.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                'Municipio:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSclSociasVentanaUsura.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = "{vwSclSociasVentanaUsura.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If
            End If

            frmVisor.WindowState = FormWindowState.Maximized

            Select Case mNomRep

                Case EnumReportes.rptPorAnio
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.NombreReporte = "RepSccCC24.rpt"
                    frmVisor.Formulas("Parametros") = "' Departamento:(" & Trim(cboDepartamento.Text) & ") Municipio:(" & Trim(cboMunicipio.Text) & ") Distrito:(" & Trim(cboDistrito.Text) & ")'"
                    frmVisor.Text = "Reporte de Meta por Año"
                    frmVisor.CRVReportes.SelectionFormula = Filtro

                Case EnumReportes.SociasVentanaUsura
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.NombreReporte = "RepSclCS39.rpt"
                    frmVisor.Text = "Reporte de Socias con Crédito Aprobado Ventana Género/Usura Cero"
                    frmVisor.CRVReportes.SelectionFormula = Filtro


            End Select

            frmVisor.CRVReportes.ShowRefreshButton = False
            frmVisor.ShowDialog()


        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Reestablezco el cursor
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    
    Private Sub frmSccParametrosMetasPrograma_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            

            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSccParametrosMetasPrograma_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, Me.strColor)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
End Class