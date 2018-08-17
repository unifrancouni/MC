'------------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                15/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclParametrosPromocion.vb
' Descripción:          Este formulario permite imprimir listados de Socias.
'------------------------------------------------------------------------------
Public Class frmSclParametrosPromocion

    Dim ObjReporte As DataDynamics.ActiveReports.ActiveReport3
    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim Strsql As String

    'Listado de Reportes:
    Dim mNomRep As EnumReportes
    Public LlamadoDesde As eLlamado

    'Llamado Desde:
    Public Enum eLlamado
        MenuReportes = 1
        Interfaz = 2
    End Enum

    'Listado de Reportes:
    Public Enum EnumReportes
        FormatoPromocion = 1 'Detalle/Consolidado
        ListadoSociasConReferencias = 2
        ListadoReferenciasSocias = 3
    End Enum

    'Nombre del Reporte:
    Public Property NomRep() As EnumReportes
        Get
            Return mNomRep
        End Get
        Set(ByVal value As EnumReportes)
            mNomRep = value
        End Set
    End Property

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            XdsCombos = New BOSistema.Win.XDataSet

            'Si Son Listados de Referencias Personales:
            If Me.NomRep = EnumReportes.ListadoReferenciasSocias Or Me.NomRep = EnumReportes.ListadoSociasConReferencias Then
                Me.cboTecnico.Enabled = False
                Me.cdeFechaInicial.Enabled = False
                Me.CdeFechaFinal.Enabled = False
                Me.grpTipoRpt.Visible = False 'Ocultar Reporte Detalle o Consolidado.
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
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

            'Asignando a las fuentes de datos:
            Me.CboDepartamento.DataSource = XdsCombos("Departamento").Source
            Me.CboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.CboDepartamento.Splits(0).DisplayColumns("Orden").Visible = False

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo:
            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.CboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.CboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.CboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.CboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro (Solamente para Formato Promoción)
            'pues se imprime consolidado por Municipios:
            'If Me.NomRep = EnumReportes.FormatoPromocion Then
            If Me.CboDepartamento.ListCount > 0 Then
                XdsCombos("Departamento").AddRow()
                XdsCombos("Departamento").ValueField("Descripcion") = "Todos"
                XdsCombos("Departamento").ValueField("nStbDepartamentoID") = -19
                XdsCombos("Departamento").ValueField("Orden") = 0
                XdsCombos("Departamento").UpdateLocal()
                XdsCombos("Departamento").Sort = "Orden,sCodigo asc"
                Me.CboDepartamento.SelectedIndex = 0
            End If
            'End If
            HabilitarComboMunicipio()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Municipios en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer)
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
                If intLimpiarID = 1 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                                                 " From StbMunicipio a " & _
                                                 " Order by a.sCodigo"
                Else



                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion,1 as Orden " & _
                             " From StbMunicipio a " & _
                             " WHERE a.nStbMunicipioID = 0" & _
                             " Order by a.sCodigo"
                End If
            End If

            If XdsCombos.ExistTable("Municipio") Then
                XdsCombos("Municipio").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Municipio")
                XdsCombos("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboMunicipio.DataSource = XdsCombos("Municipio").Source
            Me.cboMunicipio.Rebind()
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("Orden").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.General

            'Configurar el combo:
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 185

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            'Ubicarlo en el primer registro (Solamente para Formato Promocion):
            'If Me.NomRep = EnumReportes.FormatoPromocion Then
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
            'End If

        Catch ex As Exception
            Control_Error(ex)

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Distritos en el combo para su selección.
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

            'Asignando a las fuentes de datos:
            Me.cboDistrito.DataSource = XdsCombos("Distrito").Source
            Me.cboDistrito.Rebind()

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo:
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 157

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       CargarTecnico
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Técnicos del Programa.
    '-------------------------------------------------------------------------
    Private Sub CargarTecnico()
        Try
            Dim Strsql As String

            Me.cboTecnico.ClearFields() '01: Verificador, 03: Director Promocion, 12: Tecnico de Promocion, 10: Oficial Crédito.
            Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado, a.nActivo, 1 as Orden " & _
                     " From vwSclRepresentantePrograma a " & _
                     " Where (a.sCodCargo = '01') or (a.sCodCargo = '03') or (a.sCodCargo = '10') or (a.sCodCargo = '12') " & _
                     " Order by a.sNombreEmpleado "

            If XdsCombos.ExistTable("Tecnico") Then
                XdsCombos("Tecnico").ExecuteSql(Strsql)
            Else
                XdsCombos.NewTable(Strsql, "Tecnico")
                XdsCombos("Tecnico").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboTecnico.DataSource = XdsCombos("Tecnico").Source
            Me.cboTecnico.Rebind()

            Me.cboTecnico.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Visible = False

            'Configurar el combo: 
            'Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").Width = 210

            'Me.cboTecnico.Columns("nCodigo").Caption = "Código"
            Me.cboTecnico.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            'Me.cboTecnico.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTecnico.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
            If Me.cboTecnico.ListCount > 0 Then
                XdsCombos("Tecnico").AddRow()
                XdsCombos("Tecnico").ValueField("sNombreEmpleado") = "Todos"
                XdsCombos("Tecnico").ValueField("nSrhEmpleadoID") = -19
                XdsCombos("Tecnico").ValueField("Orden") = 0
                XdsCombos("Tecnico").UpdateLocal()
                XdsCombos("Tecnico").Sort = "Orden, sNombreEmpleado asc"
                Me.cboTecnico.SelectedIndex = 0
            End If


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       ValidarParametros
    ' Descripción:          Este procedimiento permite validar los parámetros
    '                       de corte indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Function ValidarParametros() As Boolean
        Dim VbResultado As Boolean
        Try

            VbResultado = False
            Me.errParametro.Clear()

            'Departamento:
            If Me.CboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.CboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.CboDepartamento.Focus()
                GoTo SALIR
            End If

            'Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                GoTo SALIR
            End If

            'Distrito:
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.errParametro.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                GoTo SALIR
            End If

            'Tecnico:
            If Me.cboTecnico.Enabled Then
                If Me.cboTecnico.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Técnico válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cboTecnico, "Debe seleccionar un Técnico válido.")
                    Me.cboTecnico.Focus()
                    GoTo SALIR
                End If
            End If
            
            'Fecha de Inicio:
            If Me.cdeFechaInicial.Enabled Then
                'Indicar Fecha Inicial:
                If IsDBNull(cdeFechaInicial.Value) Then
                    MsgBox("Debe seleccionar una fecha de inicio válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha de inicio válida.")
                    Me.cdeFechaInicial.Focus()
                    GoTo SALIR
                End If
                'Indicar Fecha de Corte:
                If IsDBNull(CdeFechaFinal.Value) Then
                    MsgBox("Debe seleccionar una fecha final válida.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.CdeFechaFinal, "Debe seleccionar una fecha final válida.")
                    Me.CdeFechaFinal.Focus()
                    GoTo SALIR
                End If
                'Fecha de Corte no menor:
                If cdeFechaInicial.Value > CdeFechaFinal.Value Then
                    MsgBox("Debe seleccionar una fecha inicial menor o igual que la final.", MsgBoxStyle.Critical, NombreSistema)
                    Me.errParametro.SetError(Me.cdeFechaInicial, "Debe seleccionar una fecha inicial menor o igual que la final.")
                    Me.cdeFechaInicial.Focus()
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

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       cmdAceptar_Click
    ' Descripción:          Este procedimiento permite generar el reporte
    '                       indicado por el usuario.
    '-------------------------------------------------------------------------
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Dim frmVisor As New frmCRVisorReporte
        Dim Filtro As String
        Dim CadSql As String
        Try

            If ValidarParametros() = False Then Exit Sub
            Filtro = ""
            CadSql = ""
            frmVisor.WindowState = FormWindowState.Maximized

            If Me.NomRep = EnumReportes.FormatoPromocion Then
                '1. Corte por Departamento en particular:
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro = Filtro & " {vwSclFormatoPromocionRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If
                'Consolidado Departamental no filtra por Municipio/Distrito:
                If Me.RadConsolidadoDpto.Checked = False Then
                    '2. Corte por Municipio:
                    If cboMunicipio.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFormatoPromocionRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSclFormatoPromocionRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                    End If
                    '3. Si se indicó un Distrito en Particular:
                    If cboDistrito.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFormatoPromocionRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        Else
                            Filtro = " {vwSclFormatoPromocionRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                        End If
                    End If
                End If
                '4. Reporte Detalle: Para un Técnico en Particular:
                If Me.radDetalle.Checked Then
                    '1. Corte por Técnico en particular:
                    If cboTecnico.SelectedIndex > 0 Then
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclFormatoPromocionRep.nSrhTecnicoID}=" & Me.cboTecnico.Columns("nSrhEmpleadoID").Value
                        Else
                            Filtro = " {vwSclFormatoPromocionRep.nSrhTecnicoID}=" & Me.cboTecnico.Columns("nSrhEmpleadoID").Value
                        End If
                    End If
                End If
                '5. Entre el Rango de Fechas de Corte Indicadas:
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSclFormatoPromocionRep.dFechaActividad} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSclFormatoPromocionRep.dFechaActividad} <= #" & Format(CdeFechaFinal.Value, "yyyy-MM-dd") & "#"
                End If
                If Trim(Filtro) <> "" Then
                    Filtro = Filtro & " And {vwSclFormatoPromocionRep.dFechaActividad} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                Else
                    Filtro = " {vwSclFormatoPromocionRep.dFechaActividad} >= #" & Format(cdeFechaInicial.Value, "yyyy-MM-dd") & "#"
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoReferenciasSocias Then
                '1. Corte por Departamento en particular para Referencias Activas:
                Filtro = Filtro & " {vwSclReferenciasSociasRep.nActiva} = 1 "
                If CboDepartamento.SelectedIndex > 0 Then
                    Filtro += " And {vwSclReferenciasSociasRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                End If

                '2. Corte por Municipio:
                If cboMunicipio.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSclReferenciasSociasRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    Else
                        Filtro = "{vwSclReferenciasSociasRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                    End If
                End If
                '3. Si se indicó un Distrito en Particular:
                If cboDistrito.SelectedIndex > 0 Then
                    If Trim(Filtro) <> "" Then
                        Filtro = Filtro & " And {vwSclReferenciasSociasRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    Else
                        Filtro = " {vwSclReferenciasSociasRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                    End If
                End If

            ElseIf Me.NomRep = EnumReportes.ListadoSociasConReferencias Then
                ''*****OJO CAMBIO REALIZADO EL 08-07-2011**************************
                '1. Corte por Departamento en particular para Socias Activas:

                If CboDepartamento.Text = "Todos" And cboMunicipio.Text = "Todos" And cboDistrito.Text = "Todos" Then
                    Filtro = Filtro & " {vwSclSociasConReferenciasRep.nSociaActiva} = 1 "
                Else
                    If CboDepartamento.Text <> "Todos" And cboMunicipio.Text = "Todos" And cboDistrito.Text = "Todos" Then
                        Filtro = Filtro & " {vwSclSociasConReferenciasRep.nSociaActiva} = 1 And {vwSclSociasConReferenciasRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                    Else


                        '1. Corte por Departamento en particular para Socias Activas:

                        Filtro = Filtro & " {vwSclSociasConReferenciasRep.nSociaActiva} = 1 And {vwSclSociasConReferenciasRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                        '2. Corte por Municipio:
                        If Trim(Filtro) <> "" Then
                            Filtro = Filtro & " And {vwSclSociasConReferenciasRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        Else
                            Filtro = "{vwSclSociasConReferenciasRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                        End If
                        '3. Si se indicó un Distrito en Particular:
                        If cboDistrito.SelectedIndex > 0 Then
                            If Trim(Filtro) <> "" Then
                                Filtro = Filtro & " And {vwSclSociasConReferenciasRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                            Else
                                Filtro = " {vwSclSociasConReferenciasRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                            End If
                        End If
                    End If
                End If


                '**********************************************************************

                '*****original*********
                ''1. Corte por Departamento en particular para Socias Activas:

                'Filtro = Filtro & " {vwSclSociasConReferenciasRep.nSociaActiva} = 1 And {vwSclSociasConReferenciasRep.nStbDepartamentoID}=" & Me.CboDepartamento.Columns("nStbDepartamentoID").Value
                ''2. Corte por Municipio:
                'If Trim(Filtro) <> "" Then
                '    Filtro = Filtro & " And {vwSclSociasConReferenciasRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                'Else
                '    Filtro = "{vwSclSociasConReferenciasRep.nStbMunicipioID}=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
                'End If
                ''3. Si se indicó un Distrito en Particular:
                'If cboDistrito.SelectedIndex > 0 Then
                '    If Trim(Filtro) <> "" Then
                '        Filtro = Filtro & " And {vwSclSociasConReferenciasRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                '    Else
                '        Filtro = " {vwSclSociasConReferenciasRep.nStbDistritoID}=" & Me.cboDistrito.Columns("nStbDistritoID").Value
                '    End If
                'End If
            End If

            'Asignación del Filtro indicado:
            Me.Cursor = Cursors.WaitCursor
            If Trim(Filtro) <> "" Then
                frmVisor.CRVReportes.SelectionFormula = Filtro
            End If

            'Formato de Promoción y Capacitación (Detalle / Consolidado):
            If mNomRep = EnumReportes.FormatoPromocion Then
                If Me.radDetalle.Checked Then
                    frmVisor.NombreReporte = "RepSclCS28.rpt"
                    frmVisor.Text = "Formato de Promoción y Capacitación"
                ElseIf Me.RadConsolidado.Checked Then
                    frmVisor.NombreReporte = "RepSclCS30.rpt"
                    frmVisor.Text = "Consolidado Formato de Promoción y Capacitación"
                Else
                    frmVisor.NombreReporte = "RepSclCS38.rpt"
                    frmVisor.Text = "Visitas por Departamento realizadas a Socias"
                End If
                frmVisor.Formulas("RangoFechas") = "' Del " & Format(cdeFechaInicial.Value, "dd/MM/yyyy") & " Al " & Format(CdeFechaFinal.Value, "dd/MM/yyyy") & " '"

                'Listado de Socias con Malas Referencias:
            ElseIf mNomRep = EnumReportes.ListadoSociasConReferencias Then
                frmVisor.NombreReporte = "RepSclCS29.rpt"
                frmVisor.Text = "Listado de Socias Activas Con Malas Referencias Personales"
                frmVisor.Formulas("Distrito") = "'" & Me.cboDistrito.Text & "'"

                'Listado de Referencias:
            ElseIf mNomRep = EnumReportes.ListadoReferenciasSocias Then
                frmVisor.NombreReporte = "RepSclCS27.rpt"
                frmVisor.Text = "Listado de Referencias Personales de Socias"
                frmVisor.Formulas("Distrito") = "'" & Me.cboDistrito.Text & "'"
            End If

            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este procedimiento permite salir de la Interfaz
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       CboDepartamento_TextChanged
    ' Descripción:          Al cambiar Departamento.
    '-------------------------------------------------------------------------
    Private Sub CboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CboDepartamento.TextChanged
        If Me.CboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0)
        Else
            CargarMunicipio(1)
        End If
        HabilitarComboMunicipio()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       HabilitarComboMunicipio
    ' Descripción:          Habilitar Combo Municipio.
    '-------------------------------------------------------------------------
    Private Sub HabilitarComboMunicipio()
        If Me.CboDepartamento.SelectedIndex >= 0 Then
            Me.cboMunicipio.Enabled = True
        Else
            Me.cboMunicipio.Enabled = False
        End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       cboMunicipio_TextChanged
    ' Descripción:          Al cambiar Municipio.
    '-------------------------------------------------------------------------
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            If Me.cboMunicipio.Text = "Managua" Then
                CargarDistrito(0)
                Me.cboDistrito.Enabled = True
            Else
                CargarDistrito(0)
                Me.cboDistrito.Enabled = False
            End If
        Else
            CargarDistrito(1)
        End If
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       frmSteParametrosPromocion_FormClosing
    ' Descripción:          Al cerrar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteParametrosPromocion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            ObjReporte = Nothing
            XdsCombos.Close()
            XdsCombos = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2008
    ' Procedure Name:       frmSteParametrosPromocion_Load
    ' Descripción:          Al cargar el formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSteParametrosPromocion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()
            CargarTecnico()
            HabilitarComboMunicipio()
            Me.CboDepartamento.Select()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub FrmSccParametrosPromocion_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
        If Me.NomRep = EnumReportes.FormatoPromocion Then
            Me.Text = "Formato de Promoción y Capacitación"
        End If
    End Sub

    Private Sub radDetalle_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles radDetalle.CheckedChanged
        If radDetalle.Checked Then
            Me.cboTecnico.Enabled = True
        Else
            Me.cboTecnico.Enabled = False
        End If
    End Sub

    Private Sub RadConsolidado_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RadConsolidado.CheckedChanged
        If radDetalle.Checked Then
            Me.cboTecnico.Enabled = True
        Else
            Me.cboTecnico.Enabled = False
        End If
    End Sub
End Class