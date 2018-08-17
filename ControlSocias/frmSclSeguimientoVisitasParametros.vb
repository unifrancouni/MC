Public Class frmSclSeguimientoVisitasParametros

#Region "Variables"
    Dim IntPermiteConsultar As Integer = 1
    Dim IntDepartamento As Integer = 0

    Dim XdsCombos As BOSistema.Win.XDataSet

    Public strSQl As String = ""

#End Region

    Private Sub frmSclSeguimientoVisitasParametros_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declaración de Variables
        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            InicializarVariables()
            CargarDepartamento()
            CargarFuente()
            CargarMonto()
            CargarVeces()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

#Region "Funciones Generales"

    Private Sub InicializarVariables()
        XdsCombos = New BOSistema.Win.XDataSet
        EncuentraParametros()
    End Sub

    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando

        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Departamento de la Delegación
            Strsql = "SELECT nStbDepartamentoID FROM vwStbDatosDelegacion WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntDepartamento = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    Private Sub HabilitarComboMunicipio()
        'If Me.CboDepartamento.SelectedIndex > 0 Then
        If (Me.cboDepartamento.SelectedIndex > 0 And Me.IntPermiteConsultar = 1) Or (Me.cboDepartamento.SelectedIndex >= 0 And Me.IntPermiteConsultar = 0) Then
            Me.cboMunicipio.Enabled = True
        Else
            Me.cboMunicipio.Enabled = False
        End If
    End Sub

    Private Function ValidarDatosEntrada() As Boolean
        Dim cmd As New BOSistema.Win.XComando

        ''Validacion de fechas
        'Fechas NO nulas
        If IsDBNull(CdeFechaFinal.Value) Or IsDBNull(cdeFechaInicial.Value) Then
            MsgBox("Debe seleccionar un rango de fechas de desembolso válido.", vbCritical, "Error")
            Return False
        End If

        'Rango válido
        If CdeFechaFinal.Value < cdeFechaInicial.Value Then
            MsgBox("Debe seleccionar un rango de fechas de desembolso válido.", vbCritical, "Error")
            Return False
        End If

        'Fecha inicial no menor a la fecha de inicio del programa
        If cdeFechaInicial.Value < CDate("2007-08-02") Then
            MsgBox("La fecha inicial no puede ser menor que la fecha de inicio del programa.", vbCritical, "Error")
            Return False
        End If

        'Fecha final no mayor a la fecha del servidor
        Dim fechaServer As Date
        fechaServer = CDate(cmd.ExecuteScalar("select Getdate()"))
        If CdeFechaFinal.Value > fechaServer Then
            MsgBox("La fecha final no puede ser mayor que la fecha del servidor.", vbCritical, "Error")
            Return False
        End If

        Return True
    End Function

#End Region

#Region "Cargar Ubicacion"
    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If IntPermiteConsultar = 0 Then
                Strsql = " Select a.nStbDepartamentoID, a.sCodigo, a.sNombre As Descripcion, 1 As Orden " &
                         " From StbDepartamento a " &
                         " Where a.nStbDepartamentoID = " & Me.IntDepartamento &
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID, a.sCodigo, a.sNombre As Descripcion, 1 As Orden " &
                         " From StbDepartamento a " &
                         " Order by a.sCodigo"
            End If

            If XdsCombos.ExistTable("Departamento") Then
                XdsCombos("Departamento").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Departamento")
                XdsCombos("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsCombos("Departamento").Source
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboDepartamento.ListCount > 0 Then
                If IntPermiteConsultar = 1 Then
                    XdsCombos("Departamento").AddRow()
                    XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                    XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                    XdsCombos("Departamento").ValueField("Orden") = 0
                    XdsCombos("Departamento").UpdateLocal()
                    XdsCombos("Departamento").Sort = "Orden, sCodigo asc"
                End If
                Me.cboDepartamento.SelectedIndex = 0
                End If

                Me.cboDepartamento.ValueMember = "nStbDepartamentoID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer)
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19 Then
                    Strsql = " Select a.nStbMunicipioID, a.nStbDepartamentoID, a.sCodigo, a.sNombre As Descripcion, 1 As Orden " &
                             " From StbMunicipio a " &
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID, a.nStbDepartamentoID, a.sCodigo, a.sNombre As Descripcion, 1 As Orden " &
                             " From StbMunicipio a " &
                             " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" &
                             " Order by a.sCodigo"
                End If
            ElseIf intLimpiarID = 1 Then
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre As Descripcion,1 As Orden " &
                                                " From StbMunicipio a " &
                                                " Where (a.nStbDepartamentoID = " & XdsCombos("Departamento").ValueField("nStbDepartamentoID") & ")" &
                                                " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre As Descripcion,1 As Orden " &
                                        " From StbMunicipio a " &
                                        " WHERE a.nStbMunicipioID = 0" &
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
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General
            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboMunicipio.ListCount > 0 Then
                'If mNomRep <> EnumReportes.ListaDeMoraSocias Then
                XdsCombos("Municipio").AddRow()
                XdsCombos("Municipio").ValueField("Descripcion") = "Todos"
                XdsCombos("Municipio").ValueField("nStbMunicipioID") = -19
                XdsCombos("Municipio").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Municipio").ValueField("Orden") = 0
                XdsCombos("Municipio").UpdateLocal()
                XdsCombos("Municipio").Sort = "Orden,sCodigo asc"
                Me.cboMunicipio.SelectedIndex = 0
            End If

            Me.cboMunicipio.ValueMember = "nStbMunicipioID"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarDistrito(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre As Descripcion,1 As Orden " &
                             " From StbDistrito a " &
                             " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre As Descripcion,1 As Orden " &
                         " From StbDistrito a " &
                         " Where a.nStbDistritoID = 0" &
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

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 157

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

            Me.cboDistrito.ValueMember = "nStbDistritoID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CargarBarrio(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String
            Dim CadWhere As String '' Cadena para el filtro por todos o  departamento y o municipio

            Me.cboBarrio.ClearFields()
            CadWhere = ""
            If Me.cboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If

            If Me.cboDistrito.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbBarrio.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
            End If


            If intLimpiarID = 0 Then
                Strsql = " Select dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre As Descripcion,1 As Orden " &
                             " FROM         dbo.StbBarrio INNER JOIN" &
                             " dbo.StbMunicipio On dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " &
                             "  dbo.StbDepartamento On dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " &
                             CadWhere & " Order by dbo.StbBarrio.sCodigo"
            Else
                Strsql = " Select dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre As Descripcion,1 As Orden " &
                             " FROM     dbo.StbBarrio INNER JOIN" &
                             " dbo.StbMunicipio On dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " &
                             "  dbo.StbDepartamento On dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " &
                            " Where dbo.StbBarrio.nStbBarrioID = 0" &
                         " Order by dbo.StbBarrio.sCodigo"
            End If

            If XdsCombos.ExistTable("Barrio") Then
                XdsCombos("Barrio").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Barrio")
                XdsCombos("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsCombos("Barrio").Source
            Me.cboBarrio.Rebind()

            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            If Me.cboBarrio.ListCount > 0 Then
                XdsCombos("Barrio").AddRow()
                XdsCombos("Barrio").ValueField("Descripcion") = "Todos"
                XdsCombos("Barrio").ValueField("nStbDistritoID") = -19
                XdsCombos("Barrio").ValueField("nStbBarrioID") = -19
                XdsCombos("Barrio").ValueField("Orden") = 0
                XdsCombos("Barrio").UpdateLocal()
                XdsCombos("Barrio").Sort = "Orden,sCodigo asc"
                Me.cboBarrio.SelectedIndex = 0
            End If

            Me.cboBarrio.ValueMember = "nStbBarrioID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region

#Region "Cargar Fuente"
    Private Sub CargarFuente()
        Try
            Dim Strsql As String

            'If IntPermiteConsultar = 0 Then
            '    Strsql = "Select   1 As Orden , a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
            '             " FROM         dbo.ScnFuenteFinanciamiento a Where  a.nScnFuenteFinanciamientoID=-1"
            'Else
            '    Strsql = "Select     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" & _
            '                             " FROM         dbo.ScnFuenteFinanciamiento a Order By a.sCodigo "
            'End If

            Strsql = "Select     1 As Orden, a.nScnFuenteFinanciamientoID,a.sCodigo , a.sNombre" &
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
            'If Me.CboFuentes.ListCount > 0 And IntPermiteConsultar = 1 Then
            If Me.CboFuentes.ListCount > 0 Then
                XdsCombos("Fuente").AddRow()
                XdsCombos("Fuente").ValueField("sNombre") = "Todos"
                XdsCombos("Fuente").ValueField("sCodigo") = -19
                XdsCombos("Fuente").ValueField("nScnFuenteFinanciamientoID") = -19
                XdsCombos("Fuente").ValueField("Orden") = 0
                XdsCombos("Fuente").UpdateLocal()
                XdsCombos("Fuente").Sort = "Orden,sCodigo asc"
                Me.CboFuentes.SelectedIndex = 0
            End If

            Me.CboFuentes.ValueMember = "nScnFuenteFinanciamientoID"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
#End Region

#Region "Cargar Monto - Veces"
    Private Sub CargarMonto()
        cboMontoAprobado.Enabled = True
        cboMontoAprobado.AddItem("(Todos)")
        cboMontoAprobado.AddItem("1,850.00")
        cboMontoAprobado.AddItem("3,700.00")
        cboMontoAprobado.AddItem("4,600.00")
        cboMontoAprobado.AddItem("5,500.00")
        cboMontoAprobado.AddItem("7,000.00")
        cboMontoAprobado.AddItem("10,000.00")
        cboMontoAprobado.AddItem("15,000.00")
        cboMontoAprobado.AddItem("20,000.00")
        cboMontoAprobado.AllowSort = False
        cboMontoAprobado.Columns(0).Caption = ""
        cboMontoAprobado.SelectedIndex = 0
    End Sub

    Private Sub CargarVeces()
        cboVeces.AddItem("Al menos Un Crédito")
        cboVeces.AddItem("Solo Un Crédito")
        cboVeces.AddItem("Dos Créditos")
        cboVeces.AddItem("Tres Créditos")
        cboVeces.AddItem("Cuatro Créditos")
        cboVeces.AddItem("Cinco Créditos")
        cboVeces.AddItem("Seis Créditos")
        cboVeces.AddItem("Siete Créditos")
        cboVeces.AddItem("Ocho Créditos")
        cboVeces.AddItem("Nueve Créditos")
        cboVeces.AddItem("Diez Créditos")
        cboVeces.Columns(0).Caption = ""
        cboVeces.AllowSort = False
        cboVeces.SelectedIndex = 0
    End Sub
#End Region

#Region "Eventos"
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
    End Sub

    Private Sub cboMunicipio_TextChanged(sender As Object, e As EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0)
                Me.cboDistrito.Enabled = False
            End If
            CargarBarrio(0)

            If Me.cboMunicipio.Text = "Todos" Then
                Me.cboBarrio.Enabled = False
            Else
                Me.cboBarrio.Enabled = True
            End If
        Else
            CargarDistrito(1)
            CargarBarrio(1)

        End If
    End Sub

    Private Sub radFondos_CheckedChanged(sender As Object, e As EventArgs) Handles rdFondos.CheckedChanged
        If Me.rdFondos.Checked = True Then
            grpFuente.Enabled = True
            CboFuentes.Enabled = False
        Else
            grpFuente.Enabled = False
            CboFuentes.Enabled = True
        End If
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click

        If ValidarDatosEntrada() = True Then
            'Filtro de Ubicacion
            If cboDepartamento.SelectedValue <> -19 Then
                strSQl = strSQl & " And (nStbDepartamentoID = " & cboDepartamento.SelectedValue & ") "
                If cboMunicipio.SelectedValue <> -19 Then
                    strSQl = strSQl & " And (nStbMunicipioID=" & cboMunicipio.SelectedValue & ") "
                    If cboDepartamento.Text = "Managua" Then
                        If cboDistrito.SelectedValue <> -19 Then
                            strSQl = strSQl & " And (nStbDistritoID=" & cboDistrito.SelectedValue & ") "
                            If cboBarrio.SelectedValue <> -19 Then
                                strSQl = strSQl & " And (vwStbUbicacionGeografica.nStbBarrioID=" & cboBarrio.SelectedValue & ") "
                            End If
                        End If
                    Else
                        If cboBarrio.SelectedValue <> -19 Then
                            strSQl = strSQl & " And (vwStbUbicacionGeografica.nStbBarrioID=" & cboBarrio.SelectedValue & ") "
                        End If
                    End If
                End If
            End If

            'Filtro de Monto
            If cboMontoAprobado.SelectedIndex <> 0 Then
                strSQl = strSQl & " And (nMontoAprobado=" & cboMontoAprobado.SelectedText & ") "
            End If

            'Filtro de veces aprobada
            If cboVeces.SelectedIndex <> 0 Then
                strSQl = strSQl & " And ([dbo].[fnNumerodelCreditoFND](dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID)=" & cboVeces.SelectedIndex & ") "
            End If

            'Filtro Plazo Aprobado
            If rdTodosMeses.Checked = False Then
                If rdSeisMeses.Checked Then
                    strSQl = strSQl & " And (nPlazoAprobado=" & 6 & ") "
                End If

                If rdOchoMeses.Checked Then
                    strSQl = strSQl & " And (nPlazoAprobado=" & 8 & ") "
                End If

                If rdDoceMeses.Checked Then
                    strSQl = strSQl & " And (nPlazoAprobado=" & 12 & ") "
                End If
            End If

            'Filtro Período Desembolso
            strSQl = strSQl & " And (dFechaDesembolso>='" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "') "
            strSQl = strSQl & " And (dFechaDesembolso<='" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "') "

            'Filtro de Fondos/Fuentes
            If rdFondos.Checked Then
                If rdPresupuesto.Checked Then
                    strSQl = strSQl & " And (nFondoPresupuestario=" & 1 & ") "
                End If
                If rdExternos.Checked Then
                    strSQl = strSQl & " And (nFondoPresupuestario=" & 0 & ") "
                End If
            Else
                If CboFuentes.SelectedValue <> -19 Then
                    strSQl = strSQl & " And (nFuenteFinanciamientoID=" & CboFuentes.SelectedValue & ") "
                End If
            End If

            Try
                Me.Close()
            Catch ex As Exception
                Control_Error(ex)
            End Try
        End If

    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Try
            Me.strSQl = ""
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboDistrito_TextChanged(sender As Object, e As EventArgs) Handles cboDistrito.TextChanged
        If Me.cboDistrito.SelectedIndex > -1 Then
            CargarBarrio(0)
        End If
    End Sub

#End Region

End Class