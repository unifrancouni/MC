' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                11/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclCambioGrupoSolidario.vb
' Descripción:          Formulario Cambios de Grupos Solidarios en Fichas 
'                       de Inscripción (En Proceso, Pend. Verificar o Verificadas).
'-------------------------------------------------------------------------
Public Class frmSclCambioGrupoSolidario
    '- Declaración de Variables 
    Dim XdsGrupoSolidario As BOSistema.Win.XDataSet

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    Private Sub frmSclCambioGrupoSolidario_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            'Al activar Formulario:

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       Activar
    ' Descripción:          Este procedimiento permite invocar al evento Activated
    '                       del formulario.
    '-------------------------------------------------------------------------
    Public Sub Activar()
        Dim e As New System.EventArgs
        Try
            MyBase.OnActivated(e)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       frmSclCambioGrupoSolidario_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclCambioGrupoSolidario_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsGrupoSolidario.Close()
            XdsGrupoSolidario = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       frmSclCambioGrupoSolidario_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Grupo Solidario en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclCambioGrupoSolidario_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            'Ruta de Archvio de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarGrupoSolidario()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	14/03/2008
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
    ' Fecha:                11/09/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros de la Delegación:
            EncuentraParametros()

            XdsGrupoSolidario = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdGS.ClearFields()
            Me.grdSocias.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       CargarGrupoSolidario
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Grupos Solidarios en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarGrupoSolidario()
        Try
            Dim Strsql As String

            'Maestro (Grupo Solidario EN PROCESO):
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " SELECT a.nSclGrupoSolidarioID, a.nStbBarrioID, a.nStbBarrioVerificadoID, a.sCodigo, a.sDescripcion, vwStbUbicacionGeografica.Departamento, vwStbUbicacionGeografica.Municipio, " & _
                         " vwStbUbicacionGeografica.Distrito, vwStbUbicacionGeografica.Barrio, b.sDescripcion AS Estado, b.sCodigoInterno AS sCodEstadoGS, IsNull(a.nStbDelegacionProgramaID,0) as nStbDelegacionProgramaID  " & _
                         " FROM  SclGrupoSolidario AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoGrupoID = b.nStbValorCatalogoID INNER JOIN vwStbUbicacionGeografica " & _
                         " ON a.nStbBarrioVerificadoID = vwStbUbicacionGeografica.nStbBarrioID " & _
                         " WHERE (b.sCodigoInterno = '1') " & _
                         " Order by a.sCodigo"
            Else 'Solo Filtra los Grupos de su Delegación:
                Strsql = " SELECT a.nSclGrupoSolidarioID, a.nStbBarrioID, a.nStbBarrioVerificadoID, a.sCodigo, a.sDescripcion, vwStbUbicacionGeografica.Departamento, vwStbUbicacionGeografica.Municipio, " & _
                        " vwStbUbicacionGeografica.Distrito, vwStbUbicacionGeografica.Barrio, b.sDescripcion AS Estado, b.sCodigoInterno AS sCodEstadoGS, IsNull(a.nStbDelegacionProgramaID,0) as nStbDelegacionProgramaID " & _
                        " FROM SclGrupoSolidario AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoGrupoID = b.nStbValorCatalogoID INNER JOIN vwStbUbicacionGeografica " & _
                        " ON a.nStbBarrioVerificadoID = vwStbUbicacionGeografica.nStbBarrioID " & _
                        " WHERE (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (b.sCodigoInterno = '1') " & _
                        " Order by a.sCodigo"
            End If

            
            If XdsGrupoSolidario.ExistTable("GrupoSolidario") Then
                XdsGrupoSolidario("GrupoSolidario").ExecuteSql(Strsql)
            Else
                XdsGrupoSolidario.NewTable(Strsql, "GrupoSolidario")
                XdsGrupoSolidario("GrupoSolidario").Retrieve()
            End If

            'Detalle: Fichas de Inscripción del GS: 
            'Con todos los estados pero sólo es posible cambiar de GS si 
            'estan en: En Proceso, Pendientes de Verificar o Verificadas:
            Strsql = " SELECT c.sCodigo AS sCodigoFicha, d.sDescripcion AS sEstadoFicha,  b.nCodigo AS nCodigoSocia, a.nSclGrupoSociaID, a.nSclSociaID, c.nSclFichaSociaID, a.nSclGrupoSolidarioID, d.sCodigoInterno, " & _
                     " a.nCoordinador, b.sNombre1 + ' ' + b.sNombre2 + ' ' + b.sApellido1 + ' ' + b.sApellido2 AS sNombreSocia, b.sNumeroCedula, b.sDireccionSocia, a.nCreditoRechazado " & _
                     " FROM SclGrupoSocia AS a INNER JOIN SclSocia AS b ON a.nSclSociaID = b.nSclSociaID INNER JOIN SclFichaSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN StbValorCatalogo AS d ON c.nStbEstadoFichaID = d.nStbValorCatalogoID " & _
                     " ORDER BY sCodigoFicha, nCodigoSocia"
            'WHERE (d.sCodigoInterno BETWEEN '1' AND '3')
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
            Me.grdGS.Caption = " Listado de Grupos Solidarios En Proceso (" + Me.grdGS.RowCount.ToString + " registros)"
            Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario con Fichas de Inscripción (" + Me.grdSocias.RowCount.ToString + " registros)"
            FormatoGrupoSolidario()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
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

            Me.grdGS.Splits(0).DisplayColumns("sCodigo").Width = 90
            Me.grdGS.Splits(0).DisplayColumns("sDescripcion").Width = 150
            Me.grdGS.Splits(0).DisplayColumns("Departamento").Width = 130
            Me.grdGS.Splits(0).DisplayColumns("Municipio").Width = 130
            Me.grdGS.Splits(0).DisplayColumns("Distrito").Width = 130
            Me.grdGS.Splits(0).DisplayColumns("Barrio").Width = 130
            Me.grdGS.Splits(0).DisplayColumns("Estado").Width = 45

            Me.grdGS.Columns("sCodigo").Caption = "Código"
            Me.grdGS.Columns("sDescripcion").Caption = "Nombre del Grupo"
            Me.grdGS.Columns("Departamento").Caption = "Departamento"
            Me.grdGS.Columns("Municipio").Caption = "Municipio"
            Me.grdGS.Columns("Distrito").Caption = "Distrito"
            Me.grdGS.Columns("Barrio").Caption = "Barrio"
            Me.grdGS.Columns("Estado").Caption = "Estado"

            Me.grdGS.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Departamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Municipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Distrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdGS.Splits(0).DisplayColumns("Estado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Socias del GS:
            Me.grdSocias.Splits(0).DisplayColumns("nSclGrupoSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclFichaSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            'Estado de la Ficha de Inscripción
            Me.grdSocias.Splits(0).DisplayColumns("sCodigoInterno").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nCreditoRechazado").Visible = False

            Me.grdSocias.Splits(0).DisplayColumns("sCodigoFicha").Width = 130
            Me.grdSocias.Splits(0).DisplayColumns("sEstadoFicha").Width = 130
            Me.grdSocias.Splits(0).DisplayColumns("nCodigoSocia").Width = 100
            Me.grdSocias.Splits(0).DisplayColumns("sNombreSocia").Width = 200
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").Width = 300
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").Width = 120
            Me.grdSocias.Splits(0).DisplayColumns("nCoordinador").Width = 80

            Me.grdSocias.Columns("sCodigoFicha").Caption = "Código Ficha Inscripción"
            Me.grdSocias.Columns("sEstadoFicha").Caption = "Estado Ficha"
            Me.grdSocias.Columns("nCodigoSocia").Caption = "Código Socia"
            Me.grdSocias.Columns("sNombreSocia").Caption = "Nombre de la Socia"
            Me.grdSocias.Columns("sDireccionSocia").Caption = "Dirección de la Socia"
            Me.grdSocias.Columns("sNumeroCedula").Caption = "Número de Cédula"
            Me.grdSocias.Columns("nCoordinador").Caption = "Coordinadora"

            Me.grdSocias.Splits(0).DisplayColumns("sCodigoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sEstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nCodigoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sNombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("nCoordinador").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Coordinador como checkbox y centrado:
            Me.grdSocias.Columns("nCoordinador").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdSocias.Splits(0).DisplayColumns("nCoordinador").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       tbGrupoSolidario_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbGrupoSolidario.
    '-------------------------------------------------------------------------
    Private Sub tbGrupoSolidario_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbGrupoSolidario.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolRefrescar"
                InicializaVariables()
                CargarGrupoSolidario()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       tbSocia_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSocia.
    '-------------------------------------------------------------------------
    Private Sub tbSocia_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocia.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolCambiarGS"
                LlamaModificarGrupoSolidario()
            Case "toolAyudaS"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       LlamaModificarGrupoSolidario
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditCambioGS para Cambiar de Grupo a una
    '                       Ficha de inscripción de una socia existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarGrupoSolidario()

        Dim ObjFrmSclEditCambioGS As New frmSclEditCambioGS
        Dim Strsql As String

        Try
            'No existen fichas registradas:
            If Me.grdSocias.RowCount = 0 Then
                MsgBox("No Existen Fichas registradas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsGrupoSolidario("GrupoSolidario").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la Ficha no se encuentra: En Proceso, Pendiente de Verificar o Verificada:
            If XdsGrupoSolidario("Socias").ValueField("sCodigoInterno") <> "1" And XdsGrupoSolidario("Socias").ValueField("sCodigoInterno") <> "2" And XdsGrupoSolidario("Socias").ValueField("sCodigoInterno") <> "3" Then
                MsgBox("La ficha no se encuentra activa.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si es la Coordinadora del GS:
            If XdsGrupoSolidario("Socias").ValueField("nCoordinador") = "1" Then
                MsgBox("Imposible cambiar de grupo a la Coordinadora de este. " & Chr(13) & "Antes cambie a la Coordinadora.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si tiene al menos una Ficha Cancelada:
            Strsql = " SELECT a.nSclGrupoSociaID " & _
                     " FROM   SclFichaSocia a INNER JOIN StbValorCatalogo b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID " & _
                     " WHERE  (a.nSclGrupoSociaID = " & XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID") & ") AND (b.sCodigoInterno = '7')"
            If RegistrosAsociados(Strsql) = True Then
                MsgBox("La socia ya tiene Fichas de Inscripción Canceladas.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclEditCambioGS.ModoFrm = "UPD"
            ObjFrmSclEditCambioGS.IdGrupoSolidario = XdsGrupoSolidario("GrupoSolidario").ValueField("nSclGrupoSolidarioID")
            ObjFrmSclEditCambioGS.IdSocia = XdsGrupoSolidario("Socias").ValueField("nSclGrupoSociaID")
            'Datos de Consulta del Grupo Actual:
            ObjFrmSclEditCambioGS.StrCedulaSocia = XdsGrupoSolidario("Socias").ValueField("sNumeroCedula")
            ObjFrmSclEditCambioGS.StrCodFicha = XdsGrupoSolidario("Socias").ValueField("sCodigoFicha")
            ObjFrmSclEditCambioGS.StrCodGrupo = XdsGrupoSolidario("GrupoSolidario").ValueField("sCodigo")
            ObjFrmSclEditCambioGS.StrNombreGrupo = XdsGrupoSolidario("GrupoSolidario").ValueField("sDescripcion")
            ObjFrmSclEditCambioGS.StrNombreSocia = XdsGrupoSolidario("Socias").ValueField("sNombreSocia")
            ObjFrmSclEditCambioGS.ShowDialog()

            CargarGrupoSolidario()
            XdsGrupoSolidario("GrupoSolidario").SetCurrentByID("nSclGrupoSolidarioID", ObjFrmSclEditCambioGS.IdGrupoSolidario)
            Me.grdGS.Row = XdsGrupoSolidario("GrupoSolidario").BindingSource.Position

            XdsGrupoSolidario("Socias").SetCurrentByID("nSclGrupoSociaID", ObjFrmSclEditCambioGS.IdSocia)
            Me.grdSocias.Row = XdsGrupoSolidario("Socias").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditCambioGS.Close()
            ObjFrmSclEditCambioGS = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                11/09/2007
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
    ' Fecha:                11/09/2007
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

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdGS_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdGS.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       grdGS_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdGS_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdGS.Filter
        Try
            XdsGrupoSolidario("GrupoSolidario").FilterLocal(e.Condition)
            Me.grdGS.Caption = " Listado de Grupos Solidarios En Proceso (" + Me.grdGS.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try

            Seg.RefreshPermissions()
            'CambiarSociaDeGS:
            If Seg.HasPermission("CambiarSociaDeGS") = False Then
                Me.tbSocia.Items("toolCambiarGS").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolCambiarGS").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       grdGS_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Socias con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdGS_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdGS.RowColChange
        Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario con Fichas de Inscripción (" + Me.grdSocias.RowCount.ToString + " registros)"
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                11/09/2007
    ' Procedure Name:       grdSocias_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Socia existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSocias.DoubleClick
        Try
            If Seg.HasPermission("CambiarSociaDeGS") Then
                LlamaModificarGrupoSolidario()
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
    ' Fecha:                11/09/2007
    ' Procedure Name:       grdSocias_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSocias.Filter
        Try
            XdsGrupoSolidario("Socias").FilterLocal(e.Condition)
            Me.grdSocias.Caption = " Listado de Socias del Grupo Solidario con Fichas de Inscripción (" + Me.grdSocias.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class