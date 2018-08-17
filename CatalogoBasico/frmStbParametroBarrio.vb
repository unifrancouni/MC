Public Class frmStbParametroBarrio

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim XdtEstados As BOSistema.Win.XDataSet.xDataTable
    Dim XdtPertenece As BOSistema.Win.XDataSet.xDataTable
    Dim Strsql As String
    Dim _tipo As frmStbEditMercado.eTipoObjeto


    Public Property TipoObjeto() As frmStbEditMercado.eTipoObjeto
        Get
            Return _tipo
        End Get
        Set(ByVal value As frmStbEditMercado.eTipoObjeto)
            _tipo = value
        End Set
    End Property


    'Listado de Reportes
    Public Enum EnumReportes
        rptStbBarrio = 1
        rptStbMercado = 2
        rptStbBarrioMov = 3
        rptStbBarrioTraslado = 4
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
            XdtPertenece = New BOSistema.Win.XDataSet.xDataTable
            XdtEstados = New BOSistema.Win.XDataSet.xDataTable

            'Titúlo de Reporte
            Select Case mNomRep

                Case EnumReportes.rptStbBarrio
                    Me.Text = "Parámetros Reporte de Barrio"
                Case EnumReportes.rptStbMercado
                    Me.Text = "Parámetros Reporte de Mercado"

                Case EnumReportes.rptStbBarrioMov
                    Me.Text = "Parámetros Reporte de Movimientos en Barrio"
                    grpdestino.Visible = False

                Case EnumReportes.rptStbBarrioTraslado
                    Me.Text = "Parámetros Reporte de Traslados de Barrios"
                    grpdestino.Visible = False
            End Select

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12 de Septiembre del 2007
    ' Procedure name		   	:	CargarEstados
    ' Description			   	:	Cargar los estados de Barrios
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarEstados()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdEstado, " & _
                     "      'Todos'     As Estado, " & _
                     "        0         As Orden "

            XdtEstados.ExecuteSql(Strsql)
            XdtEstados.AddRow()
            XdtEstados("IdEstado") = 1
            XdtEstados("Estado") = "Activo"
            XdtEstados("Orden") = 1
            XdtEstados.UpdateLocal()
            '--------------------------------

            XdtEstados.AddRow()
            XdtEstados("IdEstado") = 0
            XdtEstados("Estado") = "Inactivo"
            XdtEstados("Orden") = 2
            XdtEstados.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboEstado.DataSource = XdtEstados.Source

            'Formateando el Combo
            Me.cboEstado.Splits(0).DisplayColumns("IdEstado").Visible = False
            Me.cboEstado.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboEstado.Columns("Estado").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtEstados.Count > 0 Then
                Me.cboEstado.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12 de Septiembre del 2007
    ' Procedure name		   	:	CargarPertenece
    ' Description			   	:	Cargar las posibles variantes de si pertenece al programa.
    ' -----------------------------------------------------------------------------------------
    Private Sub CargarPertenece()

        'Declaracion de Variables
        Dim Strsql As String

        Try
            Strsql = ""
            Strsql = "Select -19        As IdPertenece, " & _
                     "      'Todos'     As Pertenece, " & _
                     "        0         As Orden "

            XdtPertenece.ExecuteSql(Strsql)
            XdtPertenece.AddRow()
            XdtPertenece("IdPertenece") = 1
            XdtPertenece("Pertenece") = "Si"
            XdtPertenece("Orden") = 1
            XdtPertenece.UpdateLocal()
            '--------------------------------

            XdtPertenece.AddRow()
            XdtPertenece("IdPertenece") = 0
            XdtPertenece("Pertenece") = "No"
            XdtPertenece("Orden") = 2
            XdtPertenece.UpdateLocal()
            '--------------------------------
            'Asignando la fuente de datos
            Me.cboIncluidoPrograma.DataSource = XdtPertenece.Source

            'Formateando el Combo
            Me.cboIncluidoPrograma.Splits(0).DisplayColumns("IdPertenece").Visible = False
            Me.cboIncluidoPrograma.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboIncluidoPrograma.Columns("Pertenece").Caption = ""

            'Inicializar el combo en el primer elemento
            If XdtPertenece.Count > 0 Then
                Me.cboIncluidoPrograma.SelectedIndex = 0
            End If

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

            'Estado
            If Me.cboEstado.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Estado válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboEstado, "Debe seleccionar un Estado válido.")
                Me.cboEstado.Focus()
                GoTo SALIR
            End If

            'Incluido Programa
            If Me.cboIncluidoPrograma.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una opción para Incluido Programa válida.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboIncluidoPrograma, "Debe seleccionar una opción para Incluido Programa válida.")
                Me.cboIncluidoPrograma.Focus()
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
        Dim Filtro As String

        Try
            If ValidarParametros() = False Then
                Exit Sub
            End If

            If mNomRep <> EnumReportes.rptStbBarrioMov And mNomRep <> EnumReportes.rptStbBarrioTraslado Then 'Esto es para el active report de barrios y mercados anteriores
                Me.Cursor = Cursors.WaitCursor

                Select Case mNomRep

                    Case EnumReportes.rptStbBarrio
                        ObjReporte = RepBarrio()
                    Case EnumReportes.rptStbMercado
                        ObjReporte = RepMercado(Me.TipoObjeto)

                End Select

                If ObjReporte Is Nothing Then
                    MsgBox("No hay datos para mostrar el reporte.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                'Si el destino del reporte es Pantalla
                If Me.radPantalla.Checked Then
                    ImprimirEnPantalla(ObjReporte)

                    'Si el destino del reporte es Impresora
                ElseIf Me.RadImpresora.Checked Then
                    ImprimirEnImpresora(ObjReporte)

                    'Si el destino del reporte es Archivo
                ElseIf Me.RadArchivo.Checked Then
                    ImprimirEnArchivo(ObjReporte)
                End If
            Else 'Aqui es para Crystal Report Anexado para el listado de movimientos de barrios. 02 feb 2011
                Filtro = ""
                If mNomRep = EnumReportes.rptStbBarrioMov Then
                    'frmVisor.CRVReportes.SelectionFormula = "{SpScnRegistroAuxiliar.CodTipoCD}='CD'"

                    '1. Corte por Departamento:
                    If cboDepartamento.SelectedIndex > 0 Then
                        Filtro = Filtro & " {vwStbBarrioMovimientos.nStbDepartamentoID}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                        'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                        '    Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                        'End If
                    End If
                    '2. Corte por Municipio:
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwStbBarrioMovimientos.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = " {vwStbBarrioMovimientos.nStbMunicipioID} =" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If
                    '3. Corte por Distrito:
                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwStbBarrioMovimientos.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {vwStbBarrioMovimientos.nStbDistritoID} =" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If

                    frmVisor.NombreReporte = "RepSTBCB1_brpt.rpt"
                Else
                    If mNomRep = EnumReportes.rptStbBarrioTraslado Then

                        '1. Corte por Departamento:
                        If cboDepartamento.SelectedIndex > 0 Then
                            Filtro = Filtro & " {vwStbTrasladoBarrios.nStbDepartamentoIDOrigen}=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
                            'If cboMunicipio.SelectedIndex <> -1 And cboMunicipio.Text <> "Todos" Then
                            '    Filtro = Filtro & " And Municipio='" & Trim(cboMunicipio.Text) & "'"
                            'End If
                        End If
                        '2. Corte por Municipio:
                        If cboMunicipio.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {vwStbTrasladoBarrios.nStbMunicipioIDOrigen}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            Else
                                Filtro = " {vwStbTrasladoBarrios.nStbMunicipioIDOrigen} =" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                            End If
                        End If
                        '3. Corte por Distrito:
                        If cboDistrito.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {vwStbTrasladoBarrios.nStbDistritoIDOrigen}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                            Else
                                Filtro = " {vwStbTrasladoBarrios.nStbDistritoIDOrigen} =" & Me.cboDistrito.Columns("nStbDistritoID").Value
                            End If
                        End If

                        frmVisor.NombreReporte = "RepSTBCB1_c.rpt"

                    End If

                End If



                frmVisor.CRVReportes.SelectionFormula = Filtro
                frmVisor.WindowState = FormWindowState.Maximized
                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"


                frmVisor.Text = "Listado de Barrios que han tenido de movimientos"


                frmVisor.ShowDialog()
                End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Reestablezco el cursor
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	ImprimirEnPantalla
    ' Description			   	:	Este procedimiento permite imprimir en pantalla un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnPantalla(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        'Declaración de Variables
        Dim ObjVisorReporte As frmVisorReporte

        Try

            ObjVisorReporte = New frmVisorReporte

            'Seteo el text del reporte
            Select Case mNomRep
                Case EnumReportes.rptStbBarrio
                    ObjVisorReporte.Text = "Reporte de Barrio"
                Case EnumReportes.rptStbBarrio
                    ObjVisorReporte.Text = "Reporte de Mercado"
            End Select

            ObjReporte.Run()
            ObjVisorReporte.VisorReportes.Document = ObjReporte.Document
            ObjVisorReporte.WindowState = FormWindowState.Maximized
            ObjVisorReporte.ShowDialog()


        Catch ex As Exception
            Control_Error(ex)
        Finally

        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	ImprimirEnImpresora
    ' Description			   	:	Este procedimiento permite imprimir en la impresora un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnImpresora(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)
        Try
            ObjReporte.Run()
            If ObjReporte.Document.Pages.Count > 0 Then
                ObjReporte.Document.Print(True, True)
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	ImprimirEnArchivo
    ' Description			   	:	Este procedimiento permite imprimir en archivo un reporte
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirEnArchivo(ByVal ObjReporte As DataDynamics.ActiveReports.ActiveReport3)

        Try
            With Exportar

                .FilterIndex = 1
                .Filter = "PDF|*.pdf|XLS|*.xls|RTF|*.rtf"
                .Title = "Exportar Reporte"
                .InitialDirectory = MyCurrentDocs
                .OverwritePrompt = True
            End With

            If Exportar.ShowDialog() = Windows.Forms.DialogResult.Cancel Then
                Me.Cursor = Cursors.Default
                Exit Sub
            Else
                ObjReporte.Run()
                If ObjReporte.Document.Pages.Count = 0 Then
                    Exit Sub
                End If
            End If

            Select Case Exportar.FilterIndex
                Case 1 'pdf
                    Dim ObjExportPDF As DataDynamics.ActiveReports.Export.Pdf.PdfExport
                    ObjExportPDF = New DataDynamics.ActiveReports.Export.Pdf.PdfExport
                    ObjExportPDF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato PDF con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 2 'excel
                    Dim ObjExportXLS As DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS = New DataDynamics.ActiveReports.Export.Xls.XlsExport
                    ObjExportXLS.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato Excel con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 4 'rtf
                    Dim ObjExportRTF As DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF = New DataDynamics.ActiveReports.Export.Rtf.RtfExport
                    ObjExportRTF.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato rtf con éxito !!!", MsgBoxStyle.Information, NombreSistema)

                Case 5 'HTML
                    Dim ObjExportHTML As DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML = New DataDynamics.ActiveReports.Export.Html.HtmlExport
                    ObjExportHTML.Export(ObjReporte.Document, Exportar.FileName)
                    MsgBox("El reporte se exportó en formato HTML con éxito !!!", MsgBoxStyle.Information, NombreSistema)
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSclParametroBarrio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            ObjReporte = Nothing

            XdtEstados.Close()
            XdtEstados = Nothing

            XdsCombos.Close()
            XdsCombos = Nothing

            XdtPertenece.Close()
            XdtPertenece = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmStbParametroBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'If mNomRep = EnumReportes.rptStbBarrio Then
            CargarPertenece()
            CargarDepartamento()
            CargarEstados()
            'End If
            'si es movimiento de barrios grpdestino combo de incluido en programa y estado
            If mNomRep = EnumReportes.rptStbBarrioMov Or mNomRep = EnumReportes.rptStbBarrioTraslado Then
                cboIncluidoPrograma.Enabled = False
                cboEstado.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepBarrio
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Barrios
    ' -----------------------------------------------------------------------------------------
    Private Function RepBarrio() As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbBarrio As rptStbBarrio

        Try
            ObjRptStbBarrio = New rptStbBarrio

            'Estado del Barrio
            ObjRptStbBarrio.IdEstado = XdtEstados("IdEstado")
            ObjRptStbBarrio.Estado = UCase(Me.cboEstado.Text)

            'Pertenece Programa
            ObjRptStbBarrio.IdPertenece = XdtPertenece("IdPertenece")
            ObjRptStbBarrio.Pertenece = UCase(Me.cboIncluidoPrograma.Text)

            'If Me.cboMunicipio.SelectedIndex = -1 Then
            '    ObjRptStbBarrio.IdMunicipio = -20
            '    ObjRptStbBarrio.Municipio = ""
            'Else

            'Departamento
            ObjRptStbBarrio.IdDepartamento = XdsCombos("Departamento").ValueField("nStbDepartamentoID")
            ObjRptStbBarrio.Departamento = UCase(Me.cboDepartamento.Text)

            'Municipio
            ObjRptStbBarrio.IdMunicipio = XdsCombos("Municipio").ValueField("nStbMunicipioID")
            ObjRptStbBarrio.Municipio = UCase(Me.cboMunicipio.Text)

            'Distrito
            ObjRptStbBarrio.IdDistrito = XdsCombos("Distrito").ValueField("nStbDistritoID")
            ObjRptStbBarrio.Distrito = UCase(Me.cboDistrito.Text)


            'End If

            Return ObjRptStbBarrio

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Azucena Suárez Tijerino
    ' Date			    		:	12/09/2007
    ' Procedure name		   	:	RepMercado
    ' Description			   	:	Esta Funcion permite generar el reporte 
    '                           :   de Listado de Mercados
    ' -----------------------------------------------------------------------------------------
    Private Function RepMercado(ByVal Tipo As Integer) As DataDynamics.ActiveReports.ActiveReport3

        'Declaracion de Variables
        Dim ObjRptStbMercado As rptStbMercado

        Try
            ObjRptStbMercado = New rptStbMercado

            'Tipo de objeto
            ObjRptStbMercado.TipoObjeto = IIf(Tipo = 0, frmStbEditMercado.eTipoObjeto.Mercado, frmStbEditMercado.eTipoObjeto.Cooperativa)

            'Estado del Barrio
            ObjRptStbMercado.IdEstado = XdtEstados("IdEstado")
            ObjRptStbMercado.Estado = UCase(Me.cboEstado.Text)

            'Pertenece Programa
            ObjRptStbMercado.IdPertenece = XdtPertenece("IdPertenece")
            ObjRptStbMercado.Pertenece = UCase(Me.cboIncluidoPrograma.Text)

            'If Me.cboMunicipio.SelectedIndex = -1 Then
            '    ObjRptStbBarrio.IdMunicipio = -20
            '    ObjRptStbBarrio.Municipio = ""
            'Else

            'Departamento
            ObjRptStbMercado.IdDepartamento = XdsCombos("Departamento").ValueField("nStbDepartamentoID")
            ObjRptStbMercado.Departamento = UCase(Me.cboDepartamento.Text)

            'Municipio
            ObjRptStbMercado.IdMunicipio = XdsCombos("Municipio").ValueField("nStbMunicipioID")
            ObjRptStbMercado.Municipio = UCase(Me.cboMunicipio.Text)

            'Distrito
            ObjRptStbMercado.IdDistrito = XdsCombos("Distrito").ValueField("nStbDistritoID")
            ObjRptStbMercado.Distrito = UCase(Me.cboDistrito.Text)


            'End If

            Return ObjRptStbMercado

        Catch ex As Exception
            Control_Error(ex)
            Return Nothing
        End Try
    End Function

End Class