' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                04/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclGrupoSolidario.vb
' Descripción:          Formulario muestra Catálogo de Grupos Solidarios
'-------------------------------------------------------------------------
Public Class frmSclGrupoSolidario
    '- Declaración de Variables 
    Dim XdsGrupoSolidario As BOSistema.Win.XDataSet
    Dim StrCadena As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    Dim XdsUbicacion As BOSistema.Win.XDataSet
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       frmSclGrupoSolidario_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclGrupoSolidario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsGrupoSolidario.Close()
            XdsGrupoSolidario = Nothing

            XdsUbicacion.Close()
            XdsUbicacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	04/03/2008
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros de Delegación.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatosD As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Permite Consultar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalLectura FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteConsultar = XcDatosD.ExecuteScalar(Strsql)

            'Fecha Editar datos de Todas las Delegaciones:
            Strsql = "SELECT nAccesoTotalEdicion FROM StbDelegacionPrograma WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")"
            IntPermiteEditar = XcDatosD.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       frmSclGrupoSolidario_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Grupo Solidario en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclGrupoSolidario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()

            'Cargar Departamentos:
            XdsUbicacion = New BOSistema.Win.XDataSet
            Me.cboDepartamento.ClearFields()
            CargarDepartamento()

            StrCadena = " WHERE (nSclGrupoSolidarioID = 0) " 'Al cargar Grid en Blanco
            CargarGrupoSolidario(StrCadena)
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdsGrupoSolidario = New BOSistema.Win.XDataSet

            'Encuentra parámetros de Consulta / Edición Sucursales:
            EncuentraParametros()

            'Limpiar los Grids, estructura y Datos:
            Me.grdGS.ClearFields()
            Me.grdSocias.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/09/2007
    ' Procedure Name:       CargarGrupoSolidario
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Grupos Solidarios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarGrupoSolidario(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String

            'Maestro (Grupo Solidario):
            If Me.cboDepartamento.SelectedIndex = -1 Then
                Strsql = " SELECT * " & _
                         " FROM  vwSclGrupoSolidario " & _
                         " WHERE (nSclGrupoSolidarioID = 0)"
            Else
                Strsql = " SELECT * " & _
                         " FROM  vwSclGrupoSolidario " & sCadenaFiltro & _
                         " Order by vwSclGrupoSolidario.sCodigo"
                'If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                '    Strsql = " SELECT * " & _
                '             " FROM  vwSclGrupoSolidario " & _
                '             " WHERE (sDescripcion Like '" & sCadenaFiltro & "') and (nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                '             " Order by vwSclGrupoSolidario.sCodigo"
                'Else 'Solo Filtra las Socias de su Delegación:
                '    Strsql = " SELECT * " & _
                '             " FROM  vwSclGrupoSolidario " & _
                '             " WHERE (sDescripcion Like '" & sCadenaFiltro & "') and (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                '             " Order by vwSclGrupoSolidario.sCodigo"
                'End If
            End If

            If XdsGrupoSolidario.ExistTable("GrupoSolidario") Then
                XdsGrupoSolidario("GrupoSolidario").ExecuteSql(Strsql)
            Else
                XdsGrupoSolidario.NewTable(Strsql, "GrupoSolidario")
                XdsGrupoSolidario("GrupoSolidario").Retrieve()
            End If

            'Detalle: Socias integrantes del Grupo Solidario:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                Strsql = " SELECT * " & _
                         " FROM vwSclGsSocia " & _
                         " WHERE (nSclGrupoSociaID = 0)"
            Else
                Strsql = " SELECT * " & _
                         " FROM vwSclGsSocia " & sCadenaFiltro & _
                         " Order by nCodigoSocia"
                'Strsql = " SELECT * " & _
                '         " FROM vwSclGsSocia " & _
                '         " WHERE (sDescripcion Like '" & sCadenaFiltro & "') and (nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") " & _
                '         " Order by nCodigoSocia"
            End If

            If XdsGrupoSolidario.ExistTable("Socias") Then
                XdsGrupoSolidario("Socias").ExecuteSql(Strsql)
            Else
                XdsGrupoSolidario.NewTable(Strsql, "Socias")
                XdsGrupoSolidario("Socias").Retrieve()
            End If

            If XdsGrupoSolidario.ExistRelation("GrupoConSocia") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsGrupoSolidario.NewRelation("GrupoConSocia", "GrupoSolidario", "Socias", "nSclGrupoSolidarioID", "nSclGrupoSolidarioID")
            End If

            XdsGrupoSolidario.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdGS.DataSource = XdsGrupoSolidario("GrupoSolidario").Source
            Me.grdSocias.DataSource = XdsGrupoSolidario("Socias").Source

            'Actualizando el caption de los GRIDS
            Me.grdGS.Caption = " Listado de Grupos Solidarios (" + Me.grdGS.RowCount.ToString + " registros)"
            Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario (" + Me.grdSocias.RowCount.ToString + " registros)"
            FormatoGrupoSolidario()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       FormatoGrupoSolidario
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Grupos Solidarios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoGrupoSolidario()
        Try

            'Configuracion del Grid Grupo Solidario:
            Me.grdGS.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("nStbBarrioVerificadoID").Visible = False
            'Codigo del Estado del GS en sCodigoInterno (1 = En Proceso):
            Me.grdGS.Splits(0).DisplayColumns("sCodEstadoGS").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("NombreCoordinadora").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("CodigoPlanNegocio").Visible = False
            Me.grdGS.Splits(0).DisplayColumns("CodTipoPrograma").Visible = False

            Me.grdGS.Splits(0).DisplayColumns("TipoPlanNegocio").Width = 230
            Me.grdGS.Splits(0).DisplayColumns("sCodigo").Width = 90
            Me.grdGS.Splits(0).DisplayColumns("sDescripcion").Width = 280
            Me.grdGS.Splits(0).DisplayColumns("Departamento").Width = 90
            Me.grdGS.Splits(0).DisplayColumns("Municipio").Width = 90
            Me.grdGS.Splits(0).DisplayColumns("Distrito").Width = 65
            Me.grdGS.Splits(0).DisplayColumns("Barrio").Width = 130
            Me.grdGS.Splits(0).DisplayColumns("Mercado").Width = 100
            Me.grdGS.Splits(0).DisplayColumns("Estado").Width = 65
            Me.grdGS.Splits(0).DisplayColumns("sUsuarioCreacion").Width = 90

            Me.grdGS.Columns("TipoPlanNegocio").Caption = "Plan de Negocio"
            Me.grdGS.Columns("sCodigo").Caption = "Código"
            Me.grdGS.Columns("sDescripcion").Caption = "Nombre del Grupo"
            Me.grdGS.Columns("Departamento").Caption = "Departamento"
            Me.grdGS.Columns("Municipio").Caption = "Municipio"
            Me.grdGS.Columns("Distrito").Caption = "Distrito"
            Me.grdGS.Columns("Barrio").Caption = "Barrio"
            Me.grdGS.Columns("Mercado").Caption = "Mercado"
            Me.grdGS.Columns("Estado").Caption = "Estado"
            Me.grdGS.Columns("sUsuarioCreacion").Caption = "Elaborado Por"

            Me.grdGS.Splits(0).DisplayColumns("TipoPlanNegocio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Distrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Mercado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("sUsuarioCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Socias del GS:
            Me.grdSocias.Splits(0).DisplayColumns("nSclGrupoSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("sDescripcion").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdSocias.Splits(0).DisplayColumns("nCodigoSocia").Width = 50
            Me.grdSocias.Splits(0).DisplayColumns("sNombreSocia").Width = 260
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").Width = 260
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").Width = 120
            Me.grdSocias.Splits(0).DisplayColumns("nCoordinador").Width = 80
            Me.grdSocias.Splits(0).DisplayColumns("nCreditoRechazado").Width = 70

            Me.grdSocias.Columns("nCodigoSocia").Caption = "Código"
            Me.grdSocias.Columns("sNombreSocia").Caption = "Nombre de la Socia"
            Me.grdSocias.Columns("sDireccionSocia").Caption = "Dirección de la Socia"
            Me.grdSocias.Columns("sNumeroCedula").Caption = "Número de Cédula"
            Me.grdSocias.Columns("nCoordinador").Caption = "Coordinadora"
            Me.grdSocias.Columns("nCreditoRechazado").Caption = "Crédito Denegado"

            Me.grdSocias.Splits(0).DisplayColumns("nCodigoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sNombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nCoordinador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nCreditoRechazado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Coordinador como checkbox y centrado:
            Me.grdSocias.Columns("nCoordinador").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdSocias.Splits(0).DisplayColumns("nCoordinador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Crédito Denegado como checkbox y centrado:
            Me.grdSocias.Columns("nCreditoRechazado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdSocias.Splits(0).DisplayColumns("nCreditoRechazado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/07/2008
    ' Procedure Name:       LlamaBuscarGrupoSolidario
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaGrupos para buscar grupos con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarGrupoSolidario()
        Dim ObjFrmSclBusquedaGS As New frmSclBusquedaGrupos
        Try

            'Debe indicar un Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                Me.cboDepartamento.Focus()
                Exit Sub
            End If

            ObjFrmSclBusquedaGS.StrCriterioGrupo = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaGS.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclBusquedaGS.IdDepartamento = cboDepartamento.Columns("nStbDepartamentoId").Value
            ObjFrmSclBusquedaGS.IdTipoBusqueda = 1 'Busqueda Por Nombre o Cédula Socia.
            ObjFrmSclBusquedaGS.ShowDialog()
            If ObjFrmSclBusquedaGS.StrCriterioGrupo <> "0" Then
                StrCadena = ObjFrmSclBusquedaGS.StrCriterioGrupo
                CargarGrupoSolidario(StrCadena)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaGS.Close()
            ObjFrmSclBusquedaGS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       tbGrupoSolidario_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbDocSoporte.
    '-------------------------------------------------------------------------
    Private Sub tbGrupoSolidario_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbGrupoSolidario.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscarGrupoSolidario()
            Case "toolAgregar"
                LlamaAgregarGrupoSolidario()
            Case "toolModificar"
                LlamaModificarGrupoSolidario()
            Case "toolAnular"
                LlamaAnularGrupoSolidario()
            Case "toolRefrescar"
                'Debe indicar un Departamento:
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido y" & Chr(13) & "posteriormente Buscar Grupos Solidarios.", MsgBoxStyle.Information, NombreSistema)
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                InicializaVariables()
                CargarGrupoSolidario(StrCadena)
            Case "toolImprimirL"
                LlamaImprimir(0)
            Case "toolImprimirA"
                'Grupo Solidario USURA CERO / MERCADO (1. Programa Usura Cero):
                If CInt(XdsGrupoSolidario("GrupoSolidario").ValueField("CodTipoPrograma")) = "1" Or CInt(XdsGrupoSolidario("GrupoSolidario").ValueField("CodTipoPrograma")) = "3" Then
                    LlamaImprimir(1)
                Else ' Ventana de Genero
                    LlamaImprimirActaVG()
                End If
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    :	Yesenia Gutiérrez
    ' Date			    :	03/08/2009
    ' Procedure name	:	LlamaImprimirActaVG
    ' Description		:	Este procedimiento permite imprimir Acta de Compromiso. 
    ' -----------------------------------------------------------------------------------------
    Private Sub LlamaImprimirActaVG()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdGS.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSclCS3.rpt"
            frmVisor.Text = "Acta de Compromiso"
            strSQL = " Select * " & _
                     " From vwSclActaCompromisoRep " & _
                     " WHERE (nCreditoRechazado = 0) AND (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") " & _
                     " Order by nSclGrupoSolidarioID, nCoordinador DESC, sNumeroCedula"
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Grupo Solidario (0) y el Acta de Compromiso (1) 
    '                       del Grupo Solidario seleccionado.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir(ByVal intTipo As Integer)
        Dim ObjFrmSclParametroFNC As New frmSclParametroFNC
        Try
            Dim strSQL As String = ""
            If Me.grdGS.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Acta de Compromiso del Grupo Solidario:
            If intTipo = 1 Then
                'Imposible si Grupo se encuentra ANULADO:
                If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") = "2" Then
                    MsgBox("El Grupo Solidario se encuentra ANULADO.", MsgBoxStyle.Information)
                    Exit Sub
                End If
                'Acta de Compromiso:
                ObjFrmSclParametroFNC.NomRep = 1
            Else
                'Listado de Grupos Solidarios:
                ObjFrmSclParametroFNC.NomRep = 5
            End If

            ObjFrmSclParametroFNC.intSclFormatoID = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
            ObjFrmSclParametroFNC.intSccTipoID = IIf(IntPermiteConsultar = 1, 0, InfoSistema.IDDelegacion)
            ObjFrmSclParametroFNC.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametroFNC.Close()
            ObjFrmSclParametroFNC = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       tbSocia_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSocia.
    '-------------------------------------------------------------------------
    Private Sub tbSocia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocia.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarS"
                LlamaAgregarSocia()
            Case "toolModificarS"
                LlamaModificarSocia()
            Case "toolEliminarS"
                LlamaEliminarSocia()
            Case "toolCambiarCoordinador"
                LlamaCambiarCoordinadorGS()
            Case "toolDenegarCredito"
                LlamaDenegarCredito()
            Case "toolAyudaS"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaAgregarGrupoSolidario
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditGS para Agregar un nuevo Grupo Solidario.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarGrupoSolidario()
        Dim ObjFrmSclEditGS As New frmSclEditGS
        Try

            ObjFrmSclEditGS.ModoFrm = "ADD"
            ObjFrmSclEditGS.intSclPermiteEditarFNC = IntPermiteEditar
            ObjFrmSclEditGS.ShowDialog()

            If ObjFrmSclEditGS.IdGrupoSolidario <> 0 Then
                StrCadena = "Where (nSclGrupoSolidarioID = " & ObjFrmSclEditGS.IdGrupoSolidario & ")"
                CargarGrupoSolidario(StrCadena)
                'Se ubica sobre el registro recien agregado:
                XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", ObjFrmSclEditGS.IdGrupoSolidario)
                Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditGS.Close()
            ObjFrmSclEditGS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaAgregarSocias
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSociaGS para Agregar una Socia a un
    '                       determinado Grupo Solidario.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarSocia()
        Dim ObjFrmSclEditSociaGS As New frmSclEditSociaGS
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim intNoMaximoSocias As Integer
            Dim intSociasExistentes As Integer
            Dim strSQL As String

            'No existen GSs registrados:
            If Me.grdGS.RowCount = 0 Then
                MsgBox("No Existen Grupos Solidarios grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Grupo Solidario no esta En Proceso:
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("No puede Agregar Socias, Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible Adicionar Socias a Grupos de Crédito Individual, SOLO PDIBA individual:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND    (SclTipodePlandeNegocio.nCreditoIndividual = 1 )  AND ( SclTipodePlandeNegocio.nCodigo <> 5 )  "
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible adicionar más integrantes a" & Chr(13) & "Grupo Solidario de Crédito Individual.", MsgBoxStyle.Information)
                Exit Sub
            End If


            'Imposible Adicionar mas de una Socias a Grupos de Crédito Individual:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN dbo.SclGrupoSocia ON dbo.SclGrupoSolidario.nSclGrupoSolidarioID = dbo.SclGrupoSocia.nSclGrupoSolidarioId " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND    (SclTipodePlandeNegocio.nCreditoIndividual = 1 )    "
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible adicionar más de un  integrantes a" & Chr(13) & "Grupo Solidario de Crédito Individual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Encontrar Socias Adicionadas:
            strSQL = "SELECT COUNT(nSclGrupoSociaID) AS TotalSocias FROM  SclGrupoSocia WHERE (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ")"
            intSociasExistentes = XcDatos.ExecuteScalar(strSQL)

            'Imposible agregar socias si ya existe el máximo permitido para el Grupo:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            If RegistrosAsociados(strSQL) Then 'CodTipoPrograma 1: Creditos Usura Cero / Mercados =>(Máximo 10)
                strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 19)"
            Else 'Creditos PDIBA
                strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (StbValorCatalogo.sCodigoInterno = '3')"
                If RegistrosAsociados(strSQL) Then 'CodTipoPrograma 1: Creditos Usura Cero / Mercados =>(Máximo 10)
                    strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 96)"
                Else 'Creditos Ventana Genero
                    strSQL = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 59)"
                End If






            End If
            intNoMaximoSocias = XcDatos.ExecuteScalar(strSQL)
            'If CInt(Me.grdSocias.RowCount) >= intNoMaximoSocias Then
            If intSociasExistentes >= intNoMaximoSocias Then
                MsgBox("El Grupo seleccionado DEBE contener como máximo " & intNoMaximoSocias & " Socias.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If


            ObjFrmSclEditSociaGS.ModoFrm = "ADD"
            ObjFrmSclEditSociaGS.IdGrupoSolidario = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            'ObjFrmSclEditSociaGS.NumSocias = Me.grdSocias.RowCount
            ObjFrmSclEditSociaGS.NumSocias = intSociasExistentes
            ObjFrmSclEditSociaGS.ShowDialog()

            'Si se ingreso el registro correctamente:
            If ObjFrmSclEditSociaGS.IdGrupoSolidario <> 0 Then
                CargarGrupoSolidario(StrCadena)
                'Se ubica sobre el GS:
                XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", ObjFrmSclEditSociaGS.IdGrupoSolidario)
                Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position
                'Se ubica sobre la socia recien ingresada:
                XdsGrupoSolidario("Socias").SetCurrentByID("nSclGrupoSociaID", ObjFrmSclEditSociaGS.IdSocia)
                Me.grdSocias.Row = XdsGrupoSolidario("Socias").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSociaGS.Close()
            ObjFrmSclEditSociaGS = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaModificarGrupoSolidario
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditGS para Modificar un GS existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarGrupoSolidario()
        Dim ObjFrmScnEditGS As New frmSclEditGS
        Try

            'Dim strSQL As String

            'No existen GSs registrados:
            If Me.grdGS.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Grupos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible modificar Grupos de Crédito Individual:
            'strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
            '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
            '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (SclTipodePlandeNegocio.nCreditoIndividual = 1)"
            'If RegistrosAsociados(strSQL) Then
            '    MsgBox("Imposible modificar Grupo Solidario de Crédito Individual.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Grupo Solidario no esta En Proceso:
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            ObjFrmScnEditGS.ModoFrm = "UPD"
            ObjFrmScnEditGS.intSclPermiteEditarFNC = IntPermiteEditar
            ObjFrmScnEditGS.IdGrupoSolidario = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            ObjFrmScnEditGS.IdBarrioVerificado = XdsGrupoSolidario("GrupoSolidario").ValueField("nStbBarrioVerificadoID")
            ObjFrmScnEditGS.ShowDialog()

            CargarGrupoSolidario(StrCadena)
            XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", ObjFrmScnEditGS.IdGrupoSolidario)
            Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditGS.Close()
            ObjFrmScnEditGS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/03/2008
    ' Procedure Name:       LlamaDenegarCredito
    ' Descripción:          Este procedimiento permite Denegar crédito
    '                       a una Socia del Grupo.
    '-------------------------------------------------------------------------
    Private Sub LlamaDenegarCredito()
        Dim XdtDenegarSocia As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatosMin As New BOSistema.Win.XComando
        Dim StrSql As String = ""
        Try
            Dim intPosicion As Integer
            Dim intPosicionS As Integer
            Dim intNoMinimoSocias As Integer

            'No existen socias registradas:
            If Me.grdSocias.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Grupos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Grupo Solidario no esta En Proceso: 
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible denegar unica socia de Grupo de Crédito Individual:
            StrSql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (SclTipodePlandeNegocio.nCreditoIndividual = 1)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible denegar a socia con crédito individual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si el crédito ya se encuentra nCreditoRechazado = 1:
            If XdsGrupoSolidario("Socias").ValueField("nCreditoRechazado") = "1" Then
                MsgBox("El Crédito se encuentra Denegado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'La socia actual es la Coordinadora:
            If XdsGrupoSolidario("Socias").ValueField("nCoordinador") = "1" Then
                MsgBox("La socia seleccionada es la Coordinadora del Grupo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si existen Fichas de Incripción <> Anuladas para la Socia:
            StrSql = " SELECT  GS.nSclSociaID " & _
                     " FROM StbValorCatalogo AS C INNER JOIN SclGrupoSocia AS GS INNER JOIN SclFichaSocia AS FS ON GS.nSclGrupoSociaID = FS.nSclGrupoSociaID ON C.nStbValorCatalogoID = FS.nStbEstadoFichaID " & _
                     " WHERE (C.sCodigoInterno <> '4') AND (GS.nSclSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclSociaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La socia seleccionada tiene Fichas" & Chr(13) & "de Inscripción ACTIVAS asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si la Socia existe en un detalle de una FNC <> de Anulada y Anulada con Regeneración:
            StrSql = " SELECT GS.nSclSociaID " & _
                     " FROM SclFichaNotificacionCredito AS FNC INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN SclFichaSocia AS FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia AS GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN StbValorCatalogo AS C ON FNC.nStbEstadoCreditoID = C.nStbValorCatalogoID " & _
                     " WHERE (C.sCodigoInterno <> '5') AND (GS.nSclSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclSociaID") & ") AND (C.sCodigoInterno <> '4')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La socia seleccionada existe en una" & Chr(13) & "Ficha de Notificación ACTIVA.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible Denegar Crédito si solo hay 5 integrantes:
            StrSql = "SELECT sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 16)"
            intNoMinimoSocias = XcDatosMin.ExecuteScalar(StrSql)
            StrSql = " SELECT COUNT(nSclGrupoSociaID) AS NumSocias " & _
                     " FROM SclGrupoSocia " & _
                     " WHERE (nCreditoRechazado = 0) AND (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ")"
            If CInt(XcDatosMin.ExecuteScalar(StrSql)) = intNoMinimoSocias Then
                MsgBox("Imposible Denegar Crédito a una Socia del Grupo." & Chr(13) & "Los Grupos Solidarios DEBEN contener al menos" & Chr(13) & intNoMinimoSocias & " Socias con el Crédito Activo.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar Cambio:
            If MsgBox("¿Está seguro de Denegar el Crédito" & Chr(13) & _
                      "a la Socia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            intPosicion = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            intPosicionS = XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID")



            'Denegar Crédito:

            GuardarAuditoriaTablas(8, 2, "Modificar Denegar Credito a Socia en Grupo Solidario .", XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID"), InfoSistema.IDCuenta)

            StrSql = "UPDATE SclGrupoSocia " & _
                     "SET nCreditoRechazado = 1, dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                     "WHERE (nSclSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclSociaID") & ") And (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ")"
            XdtDenegarSocia.ExecuteSqlNotTable(StrSql)

            'Refrescar Datos: 
            CargarGrupoSolidario(StrCadena)
            XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", intPosicion)
            Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position
            XdsGrupoSolidario("Socias").SetCurrentByID("nSclGrupoSociaID", intPosicionS)
            Me.grdSocias.Row = XdsGrupoSolidario("Socias").BindingSource.Position

            MsgBox("El cambio se efectuó satisfactoriamente.", MsgBoxStyle.Information, NombreSistema)
            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(2, 15, "Crédito Denegado a la Socia: " & XdsGrupoSolidario("Socias").ValueField("sNombreSocia") & " (Cédula: " & XdsGrupoSolidario("Socias").ValueField("sNumeroCedula") & ") del Grupo Solidario: " & XdsGrupoSolidario("GrupoSolidario").ValueField("sCodigo") & " - " & XdsGrupoSolidario("GrupoSolidario").ValueField("sDescripcion"))

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatosMin.Close()
            XcDatosMin = Nothing

            XdtDenegarSocia.Close()
            XdtDenegarSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaModificarSocia
    ' Descripción:          Este procedimiento permite modificar la Coordinadora
    '                       actual del Grupo Solidario.
    '-------------------------------------------------------------------------
    Private Sub LlamaCambiarCoordinadorGS()
        Dim Trans As BOSistema.Win.Transact
        Dim StrSql As String = ""
        Dim XcDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim PosicionSanterior As Long

        Trans = Nothing
        Try
            Dim intPosicion As Integer
            Dim intPosicionS As Integer

            'No existen socias registradas:
            If Me.grdSocias.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Grupos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Grupo Solidario no esta En Proceso:
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("No puede Modificar Socias, Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'La socia actual ya es la Coordinadora:
            If XdsGrupoSolidario("Socias").ValueField("nCoordinador") = "1" Then
                MsgBox("La socia seleccionada es la Coordinadora del Grupo.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar Cambio:
            If MsgBox("¿Está seguro de asignar a la Socia seleccionada" & Chr(13) & _
                      "como la Coordinadora del Grupo Solidario?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            StrSql = "Select  nSclGrupoSociaID  from SclGrupoSocia " & _
                     "WHERE (nCoordinador = 1) AND (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ")"
            XcDatos.ExecuteSql(StrSql)
            PosicionSanterior = 0
            If XcDatos.Count > 0 Then
                PosicionSanterior = XcDatos.ValueField("nSclGrupoSociaID")
                GuardarAuditoriaTablas(8, 2, "Modificar Coordinador Anterior Socia en Grupo Solidario .", PosicionSanterior, InfoSistema.IDCuenta)
            End If





            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            intPosicion = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            intPosicionS = XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID")

            GuardarAuditoriaTablas(8, 2, "Modificar Coordinador Nuevo Socia en Grupo Solidario .", XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID"), InfoSistema.IDCuenta)


            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact

            'Inicio la Transacción:
            Trans.BeginTrans()

            'Actualiza coordinadora actual nCoordinador = 0:
            StrSql = "UPDATE SclGrupoSocia " & _
                     "SET nCoordinador = 0, dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                     "WHERE (nCoordinador = 1) AND (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ")"
            Trans.ExecuteSql(StrSql)
            'Actualiza Coordinadora seleccionada nCoordinador = 1:
            StrSql = "UPDATE SclGrupoSocia " & _
                     "SET nCoordinador = 1, dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "' " & _
                     "WHERE (nSclGrupoSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID") & ")"
            Trans.ExecuteSql(StrSql)

            Trans.Commit()

            CargarGrupoSolidario(StrCadena)

            XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", intPosicion)
            Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position

            XdsGrupoSolidario("Socias").SetCurrentByID("nSclGrupoSociaID", intPosicionS)
            Me.grdSocias.Row = XdsGrupoSolidario("Socias").BindingSource.Position

            MsgBox("Se cambió satisfactoriamente la Coordinadora del Grupo.", MsgBoxStyle.Information, NombreSistema)
            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(2, 15, "Modificación de Coordinadora por Socia: " & XdsGrupoSolidario("Socias").ValueField("sNombreSocia") & " (Cédula: " & XdsGrupoSolidario("Socias").ValueField("sNumeroCedula") & ") del Grupo Solidario: " & XdsGrupoSolidario("GrupoSolidario").ValueField("sCodigo") & " - " & XdsGrupoSolidario("GrupoSolidario").ValueField("sDescripcion"))

        Catch ex As Exception
            Control_Error(ex)
            Trans.RollBack()
        Finally
            Me.Cursor = Cursors.Default
            Trans = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaModificarSocia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSociaGS para Modificar una socia existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarSocia()
        Dim ObjFrmSclEditSociaGS As New frmSclEditSociaGS
        Dim ObjSclFichaSocia As New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            Dim strSQL As String
            'No existen socias registradas:
            If Me.grdSocias.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Grupos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Grupo Solidario no esta En Proceso:
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("No puede Modificar Socias, Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible modificar socia de Grupo de Crédito Individual:
            strSQL = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (SclTipodePlandeNegocio.nCreditoIndividual = 1)"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible modificar a socia con crédito individual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Validar registros relacionados en la tabla SclFichaSocia:
            ObjSclFichaSocia.Filter = "nSclGrupoSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID")
            ObjSclFichaSocia.Retrieve()
            If ObjSclFichaSocia.Count > 0 Then
                MsgBox("Imposible Modificar. Socia tiene fichas de inscripción registradas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditSociaGS.ModoFrm = "UPD"
            ObjFrmSclEditSociaGS.IdGrupoSolidario = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            ObjFrmSclEditSociaGS.IdSocia = XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID")
            strSQL = "SELECT COUNT(nSclGrupoSociaID) AS TotalSocias FROM  SclGrupoSocia WHERE (nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ")"
            ObjFrmSclEditSociaGS.NumSocias = XcDatos.ExecuteScalar(strSQL) 'Me.grdSocias.RowCount
            ObjFrmSclEditSociaGS.ShowDialog()

            CargarGrupoSolidario(StrCadena)
            XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", ObjFrmSclEditSociaGS.IdGrupoSolidario)
            Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position

            XdsGrupoSolidario("Socias").SetCurrentByID("nSclGrupoSociaID", ObjFrmSclEditSociaGS.IdSocia)
            Me.grdSocias.Row = XdsGrupoSolidario("Socias").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSociaGS.Close()
            ObjFrmSclEditSociaGS = Nothing

            ObjSclFichaSocia.Close()
            ObjSclFichaSocia = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaAnularGrupoSolidario
    ' Descripción:          Este procedimiento permite Anular un Grupo
    '                       Solidario existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularGrupoSolidario()

        Dim ObjFrmScnEditGS As New frmSclEditGS
        Dim ObjSclFichaSocia As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XdtGS As New BOSistema.Win.SclEntSocia.SclGrupoSolidarioDataTable
        Dim XdrGS As New BOSistema.Win.SclEntSocia.SclGrupoSolidarioRow

        Try

            Dim intPosicion As Integer
            Dim strCausaAnulacion As String = ""

            'Imposible si no hay GS registrados:
            If Me.grdGS.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Grupos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Grupo Solidario no esta En Proceso:
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si tiene Fichas asociadas con Estado <> Anuladas (fichas activas):
            Strsql = " SELECT b.nSclGrupoSolidarioID  " & _
                     " FROM SclFichaSocia a INNER Join SclGrupoSocia b ON a.nSclGrupoSociaID = b.nSclGrupoSociaID  " & _
                     " INNER Join StbValorCatalogo c ON a.nStbEstadoFichaID = c.nStbValorCatalogoID " & _
                     " WHERE (b.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (c.sCodigoInterno <> '4')"
            ObjSclFichaSocia.ExecuteSql(Strsql)
            If ObjSclFichaSocia.Count > 0 Then
                MsgBox("Existen Fichas de Inscripción activas asociadas.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If
            'Intentar Eliminar encabezado:
            'If Me.grdModulo.RowCount > 0 Then
            '    MsgBox("El registro no se puede eliminar porque tiene datos relacionados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If
            'Valida si el Comprobante ha sido Confirmado anteriormente.
            'Strsql = " SELECT a.StbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.objCatalogoID = b.StbCatalogoID WHERE a.CodigoInterno = 'C' And b.Nombre = 'EstadoComprobante' "
            'If XcDatos.ExecuteScalar(Strsql) <> XdtComprobante.ValueField("objEstadoID") Then
            '    MsgBox("El Comprobante DEBE estar Confirmado.", MsgBoxStyle.Critical, "SIAFI")
            '    Exit Sub
            'End If

            'Solicita al Usuario la Causa de la Anulación
            XdtGS.Filter = " nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            XdtGS.Retrieve()
            XdrGS = XdtGS.Current

            ObjFrmStbDatoComplemento.strPrompt = "¿Motivo de Anulación? "
            ObjFrmStbDatoComplemento.strTitulo = "Anulación de Grupo Solidario"
            ObjFrmStbDatoComplemento.intAncho = XdrGS.GetColumnLenght("sMotivoAnulacion")
            ObjFrmStbDatoComplemento.strDato = ""
            ObjFrmStbDatoComplemento.strColor = "RojoLight"
            ObjFrmStbDatoComplemento.strMensaje = "El motivo de la Anulación NO DEBE quedar vacío"
            ObjFrmStbDatoComplemento.ShowDialog()

            strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

            'Valida que se ingrese la Causa de la Anulación
            If strCausaAnulacion = "" Then
                MsgBox("El motivo NO PUEDE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Strsql = " EXEC spScnAnularComprobante " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ",'" & strTipoDato & "','" & strCausaAnulacion & "','" & InfoSistema.LoginName & "',Null"
            'intAnulacion = XcDatos.ExecuteScalar(Strsql)


            GuardarAuditoriaTablas(9, 2, "Anular Grupo Solidario.", XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID"), InfoSistema.IDCuenta)


            Strsql = " Update SclGrupoSolidario " & _
                     " SET sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), sMotivoAnulacion = '" & strCausaAnulacion & "', nStbEstadoGrupoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoGrupo')" & _
                     " WHERE nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            XcDatos.ExecuteNonQuery(Strsql)
            MsgBox("Grupo Solidario Anulado Exitosamente.", MsgBoxStyle.Information, NombreSistema)

            'Almacena Pista de Auditoría:
            Call GuardarAuditoria(4, 15, "Anulación de Grupo Solidario: " & XdsGrupoSolidario("GrupoSolidario").ValueField("sCodigo") & ". " & XdsGrupoSolidario("GrupoSolidario").ValueField("sDescripcion"))

            'Guardar posición actual de la selección
            intPosicion = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            CargarGrupoSolidario(StrCadena)

            'Ubicar la selección en la posición original
            XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", intPosicion)
            Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditGS.Close()
            ObjFrmScnEditGS = Nothing

            ObjSclFichaSocia.Close()
            ObjSclFichaSocia = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing

            XdtGS.Close()
            XdtGS = Nothing

            XdrGS.Close()
            XdrGS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaEliminarSocia
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una socia de un GS existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarSocia()

        Dim ObjSclFichaSocia As New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
        Dim XdtSocia As New BOSistema.Win.XDataSet.xDataTable
        Dim StrNumCedula As String
        Dim StrNombreSocia As String

        Try

            Dim intPosicion As Integer
            Dim StrSql As String

            'Imposible si no hay socias registradas:
            If Me.grdSocias.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Grupos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Grupo Solidario no esta En Proceso:
            If XdsGrupoSolidario("GrupoSolidario").ValueField("sCodEstadoGS") <> "1" Then
                MsgBox("Grupo Solidario no se encuentra En Proceso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible eliminar unica socia de Grupo de Crédito Individual:
            StrSql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID") & ") AND (SclTipodePlandeNegocio.nCreditoIndividual = 1)"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible eliminar a socia con crédito individual.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible eliminar a Coordinadora del GS:
            If Me.grdSocias.RowCount > 1 Then
                If XdsGrupoSolidario("Socias").ValueField("nCoordinador") = "1" Then
                    MsgBox("Imposible eliminar a Coordinadora del Grupo." & Chr(13) & _
                           "Antes cambie de Coordinadora.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
            'Validar registros relacionados en la tabla SclFichaSocia:
            ObjSclFichaSocia.Filter = "nSclGrupoSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID")
            ObjSclFichaSocia.Retrieve()
            If ObjSclFichaSocia.Count > 0 Then
                MsgBox("Imposible eliminar socia. Existen fichas de inscripción asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Eliminar la Socia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                StrNumCedula = XdsGrupoSolidario("Socias").ValueField("sNumeroCedula")
                StrNombreSocia = XdsGrupoSolidario("Socias").ValueField("sNombreSocia")

                intPosicion = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
                XdtSocia.ExecuteSqlNotTable("Delete From SclGrupoSocia where nSclGrupoSociaID=" & XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID"))
                CargarGrupoSolidario(StrCadena)
                XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", intPosicion)
                Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position
                MsgBox("La socia se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                'Almacena Pista de Auditoría:
                Call GuardarAuditoria(3, 15, "Eliminación de Socia " & StrNombreSocia & " (Cédula: " & StrNumCedula & ") del Grupo Solidario: " & XdsGrupoSolidario("GrupoSolidario").ValueField("sCodigo") & " - " & XdsGrupoSolidario("GrupoSolidario").ValueField("sDescripcion"))
                Me.grdGS.Caption = " Listado de Grupos Solidarios (" + Me.grdGS.RowCount.ToString + " registros)"
                Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario (" + Me.grdSocias.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtSocia.Close()
            XdtSocia = Nothing

            ObjSclFichaSocia.Close()
            ObjSclFichaSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite Salir de la opción de GS.
    '-------------------------------------------------------------------------
    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripción:          Este procedimiento permite presentar la Ayuda en
    '                       Línea al usuario. Actualmente en Construcción.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       grdGrupoSolidario_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar un GS existente, al hacer doble click en
    '                       el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdGS_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdGS.DoubleClick
        Try
            If Seg.HasPermission("ModificarGS") Then
                LlamaModificarGrupoSolidario()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdGS_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdGS.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       grdGS_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdGS_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdGS.Filter
        Try
            XdsGrupoSolidario("GrupoSolidario").FilterLocal(e.Condition)
            Me.grdGS.Caption = " Listado de Grupos Solidarios (" + Me.grdGS.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar GS:
            If Seg.HasPermission("BuscarGrupoSolidario") = False Then
                Me.tbGrupoSolidario.Items("toolBuscar").Enabled = False
            Else  'Habilita
                Me.tbGrupoSolidario.Items("toolBuscar").Enabled = True
            End If

            'Agregar GS:
            If Seg.HasPermission("AgregarGS") = False Then
                Me.tbGrupoSolidario.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbGrupoSolidario.Items("toolAgregar").Enabled = True
            End If
            'Editar GS:
            If Seg.HasPermission("ModificarGS") = False Then
                Me.tbGrupoSolidario.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbGrupoSolidario.Items("toolModificar").Enabled = True
            End If
            'Anular GS:
            If Seg.HasPermission("AnularGS") = False Then
                Me.tbGrupoSolidario.Items("toolAnular").Enabled = False
            Else  'Habilita
                Me.tbGrupoSolidario.Items("toolAnular").Enabled = True
            End If
            'Imprimir Listado GS / Acta de Compromiso:
            If Seg.HasPermission("ImprimirListadoGS") = False Then
                Me.tbGrupoSolidario.Items("toolImprimirL").Enabled = False
            Else  'Habilita
                Me.tbGrupoSolidario.Items("toolImprimirL").Enabled = True
            End If
            If Seg.HasPermission("ImprimirActaCompromisoGS") = False Then
                Me.tbGrupoSolidario.Items("toolImprimirA").Enabled = False
            Else  'Habilita
                Me.tbGrupoSolidario.Items("toolImprimirA").Enabled = True
            End If

            '-- Agregar Socia:
            If Seg.HasPermission("AgregarSociaGS") = False Then
                Me.tbSocia.Items("toolAgregarS").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolAgregarS").Enabled = True
            End If
            'Editar Socia:
            If Seg.HasPermission("ModificarSociaGS") = False Then
                Me.tbSocia.Items("toolModificarS").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolModificarS").Enabled = True
            End If
            'Eliminar Socia:
            If Seg.HasPermission("EliminarSociaGS") = False Then
                Me.tbSocia.Items("toolEliminarS").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolEliminarS").Enabled = True
            End If
            'Cambiar Coordinador:
            If Seg.HasPermission("CambiarCoordinadora") = False Then
                Me.tbSocia.Items("toolCambiarCoordinador").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolCambiarCoordinador").Enabled = True
            End If
            'Denegar Credito:
            If Seg.HasPermission("DenegarCreditoSocia") = False Then
                Me.tbSocia.Items("toolDenegarCredito").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolDenegarCredito").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       grdGS_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Socias con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdGS_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdGS.RowColChange
        Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario (" + Me.grdSocias.RowCount.ToString + " registros)"
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       grdSocias_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Socia existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSocias.DoubleClick
        Try
            If Seg.HasPermission("ModificarSociaGS") Then
                LlamaModificarSocia()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdSocias_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSocias.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/09/2007
    ' Procedure Name:       grdSocias_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSocias.Filter
        Try
            XdsGrupoSolidario("Socias").FilterLocal(e.Condition)
            Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario (" + Me.grdSocias.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Departamentos en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                     " From StbDepartamento a " & _
                     " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " & _
                     " Order by a.sCodigo"

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            'Ubicarse en el primer registro
            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Departamento:
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    'Private Sub cboDepartamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
    '    InicializaVariables()
    '    CargarGrupoSolidario(StrCadena)
    'End Sub

    Private Sub toolBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolBuscar.Click

    End Sub
End Class