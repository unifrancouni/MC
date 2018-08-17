' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                01/07/2009
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclFichaSeguimiento.vb
' Descripción:          Este formulario carga los principales datos de la
'                       Ficha de Seguimiento al Crédito para socias del
'                       Programa.
'-------------------------------------------------------------------------
Public Class frmSclFichaSeguimiento

    '- Declaración de Variables 
    Dim XdtFicha As BOSistema.Win.XDataSet.xDataTable
    Dim StrCadena As String

    'Parámetros Delegación:
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       frmSclFichaSeguimiento_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaSeguimiento_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFicha.Close()
            XdtFicha = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       frmSclFichaSeguimiento_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado de en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaSeguimiento_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            'Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))

            InicializaVariables()
            StrCadena = " WHERE (a.nSclFichaSeguimientoID = 0) " 'Al cargar Grid en Blanco
            CargarFicha(StrCadena)
            FormatoFicha()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarFicha(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String = ""
            '    If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
            '        Strsql = " SELECT a.nSclFichaSeguimientoID, a.nSrhTecnicoID, a.nStbDelegacionProgramaID, a.nSclFichaNotificacionDetalleID, a.nSclSociaID,  " & _
            '                 " a.EstadoFicha, a.dFechaFicha, a.GrupoSolidario, a.Socia, a.sNumeroCedula, a.sTelefono, a.ActividadEconomica, a.sUbicacionNegocio " & _
            '                 " FROM vwSclFichaSeguimiento AS a "
            '        '" WHERE (a.nSrhTecnicoID = 20) and (a.dFechaFicha BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '        '" Order by a.nSclFichaSeguimientoID"

            '    Else 'Solo Filtra las Fichas de su Delegación: 
            '        Strsql = " SELECT a.nSclFichaSeguimientoID, a.nSrhTecnicoID, a.nStbDelegacionProgramaID, a.nSclFichaNotificacionDetalleID, a.nSclSociaID,  " & _
            '                 " a.EstadoFicha, a.dFechaFicha,a.GrupoSolidario,  a.Socia, a.sNumeroCedula, a.sTelefono, a.ActividadEconomica, a.sUbicacionNegocio " & _
            '                 " FROM vwSclFichaSeguimiento AS a "
            '        '" WHERE (a.nSrhTecnicoID = 20) and (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (a.dFechaFicha BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
            '        '" Order by a.nSclFichaSeguimientoID"
            '    End If
            Strsql = " SELECT a.nSclFichaSeguimientoID, a.nSrhTecnicoID, a.nStbDelegacionProgramaID, a.nSclFichaNotificacionDetalleID, a.nSclSociaID,  " & _
                     " a.EstadoFicha, a.dFechaFicha,a.GrupoSolidario,  a.Socia, a.sNumeroCedula, a.sTelefono, a.ActividadEconomica, a.NombreTecnico, a.sUbicacionNegocio " & _
                     " FROM vwSclFichaSeguimiento AS a " & sCadenaFiltro & _
                     " Order by a.dFechaFicha, a.NombreTecnico"
            XdtFicha.ExecuteSql(Strsql)

            'Asignando fuente de datos al Grid:
            Me.grdFicha.DataSource = XdtFicha.Source
            Me.grdFicha.Caption = " Listado de Fichas de Seguimiento (" + Me.grdFicha.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       FormatoFicha
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre los Formatos en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoFicha()
        Try

            'Configuracion del Grid 
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaSeguimientoID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSrhTecnicoID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaNotificacionDetalleID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclSociaID").Visible = False

            Me.grdFicha.Splits(0).DisplayColumns("EstadoFicha").Width = 80
            Me.grdFicha.Splits(0).DisplayColumns("dFechaFicha").Width = 90
            Me.grdFicha.Splits(0).DisplayColumns("GrupoSolidario").Width = 200
            Me.grdFicha.Splits(0).DisplayColumns("Socia").Width = 210
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Width = 110
            Me.grdFicha.Splits(0).DisplayColumns("sTelefono").Width = 90
            Me.grdFicha.Splits(0).DisplayColumns("ActividadEconomica").Width = 150
            Me.grdFicha.Splits(0).DisplayColumns("NombreTecnico").Width = 210
            Me.grdFicha.Splits(0).DisplayColumns("sUbicacionNegocio").Width = 180

            Me.grdFicha.Columns("EstadoFicha").Caption = "Estado"
            Me.grdFicha.Columns("dFechaFicha").Caption = "Fecha"
            Me.grdFicha.Columns("GrupoSolidario").Caption = "Grupo Solidario"
            Me.grdFicha.Columns("Socia").Caption = "Nombre Socia"
            Me.grdFicha.Columns("sNumeroCedula").Caption = "Cédula Socia"
            Me.grdFicha.Columns("sTelefono").Caption = "Teléfono"
            Me.grdFicha.Columns("ActividadEconomica").Caption = "Actividad Económica"
            Me.grdFicha.Columns("NombreTecnico").Caption = "Nombre del Técnico"
            Me.grdFicha.Columns("sUbicacionNegocio").Caption = "Ubicación Negocio"

            Me.grdFicha.Splits(0).DisplayColumns("EstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("GrupoSolidario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("Socia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sTelefono").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("ActividadEconomica").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("NombreTecnico").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sUbicacionNegocio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formatos:
            Me.grdFicha.Columns("dFechaFicha").NumberFormat = "dd/MM/yyyy"
            Me.grdFicha.Splits(0).DisplayColumns("dFechaFicha").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtFicha = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = "Ficha de Seguimiento al Crédito"
            'Limpiar Grid, estructura y Datos
            Me.grdFicha.ClearFields()

            'Encuentra parámetros de Consulta / Edición Sucursales:
            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/07/2009
    ' Procedure Name:       LlamaBuscarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaFichasSeguimiento para buscar con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarFicha()
        Dim ObjFrmSclBusquedaFichas As New frmSclBusquedaFichasSeguimiento
        Try

            ObjFrmSclBusquedaFichas.StrCriterioFicha = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaFichas.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclBusquedaFichas.IdTipoBusqueda = 1 'Busqueda para Fichas de Seguimiento.
            ObjFrmSclBusquedaFichas.ShowDialog()
            If ObjFrmSclBusquedaFichas.StrCriterioFicha <> "0" Then
                StrCadena = ObjFrmSclBusquedaFichas.StrCriterioFicha
                CargarFicha(StrCadena)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaFichas.Close()
            ObjFrmSclBusquedaFichas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       tbFormato_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbFicha.
    '-------------------------------------------------------------------------
    Private Sub tbFormato_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscarFicha()
            Case "toolAgregar"
                LlamaAgregarFicha()
            Case "toolModificar"
                LlamaModificarFicha()
            Case "toolAnular"
                LlamaAnular()
            Case "toolAplicar"
                LlamaAplicar()
            Case "toolRevertir"
                LlamaRevertirAplicacion()
            Case "toolRefrescar"
                InicializaVariables()
                CargarFicha(StrCadena)
                FormatoFicha()

            Case "toolImprimir"
                LlamaImprimir()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       LlamAplicar
    ' Descripción:          Este procedimiento permite aplicar un registro
    '                       impidiendo su posterior edición.
    '-------------------------------------------------------------------------
    Private Sub LlamaAplicar()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim Strsql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

            'No existen registros: 
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Aplicar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no se encuentra En Proceso: 
            Strsql = "SELECT SclFichaSeguimiento.nSclFichaSeguimientoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclFichaSeguimiento ON C.nStbValorCatalogoID = SclFichaSeguimiento.nStbEstadoFichaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SclFichaSeguimiento.nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Ficha NO se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Aplicar la Ficha seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(26, 2, "Modificar SclFichaSeguimiento Aplicar ", XdtFicha.ValueField("nSclFichaSeguimientoID"), InfoSistema.IDCuenta)

                'Actualizar el Estado a Aplicada:
                Strsql = " Update SclFichaSeguimiento " & _
                         " SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoFichaSeguimiento')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate()" & _
                         " WHERE nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha Aplicado " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdtFicha.ValueField("nSclFichaSeguimientoID")
                Call GuardarAuditoria(5, 15, "Aplicación Ficha de Seguimiento ID: " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ".")
                CargarFicha(StrCadena)

                'Ubicar la selección en la posición original:
                XdtFicha.SetCurrentByID("nSclFichaSeguimientoID", intPosicion)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/07/2009
    ' Procedure Name:       LlamaRevertirAplicacion
    ' Descripción:          Este procedimiento permite regresar fichas
    '                       aplicadas al estado En Proceso.
    '-------------------------------------------------------------------------
    Private Sub LlamaRevertirAplicacion()
        Dim XcDatos As New BOSistema.Win.XComando
        Try

            Dim Strsql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.

            'No existen registros: 
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Aplicar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si no se encuentra Aplicada: 
            Strsql = "SELECT SclFichaSeguimiento.nSclFichaSeguimientoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclFichaSeguimiento ON C.nStbValorCatalogoID = SclFichaSeguimiento.nStbEstadoFichaID " & _
                     "WHERE (C.sCodigoInterno = '2') AND (SclFichaSeguimiento.nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Ficha NO se encuentra Aplicada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Revertir la Aplicación de la Ficha seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                GuardarAuditoriaTablas(26, 2, "Modificar SclFichaSeguimiento Revertir ", XdtFicha.ValueField("nSclFichaSeguimientoID"), InfoSistema.IDCuenta)
                'Actualizar el Estado a Aplicada:
                Strsql = " Update SclFichaSeguimiento " & _
                         " SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoFichaSeguimiento')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate()" & _
                         " WHERE nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha revertido " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdtFicha.ValueField("nSclFichaSeguimientoID")
                Call GuardarAuditoria(5, 15, "Reversión de Aplicación Ficha de Seguimiento ID: " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ".")
                CargarFicha(StrCadena)

                'Ubicar la selección en la posición original:
                XdtFicha.SetCurrentByID("nSclFichaSeguimientoID", intPosicion)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       LlamaAnular
    ' Descripción:          Este procedimiento permite inactivar un registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnular()
        Dim XdtFichaAnular As New BOSistema.Win.SclEntFicha.SclFichaSeguimientoDataTable
        Dim XdrFichaAnular As New BOSistema.Win.SclEntFicha.SclFichaSeguimientoRow

        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try

            Dim Strsql As String
            Dim intPosicion As Long  'Posición del registro seleccionado, ID de la Ficha.
            Dim strCausaAnulacion As String

            'No existen registros: 
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Anular Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si ya esta Anulada: 
            Strsql = "SELECT SclFichaSeguimiento.nSclFichaSeguimientoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclFichaSeguimiento ON C.nStbValorCatalogoID = SclFichaSeguimiento.nStbEstadoFichaID " & _
                     "WHERE (C.sCodigoInterno = '3') AND (SclFichaSeguimiento.nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ")"
            If (RegistrosAsociados(Strsql)) Then
                MsgBox("Ficha se encuentra Anulada.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de Anular la Ficha seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then

                'Solicita al Usuario la Causa de la Anulación:
                XdtFichaAnular.Filter = " nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID")
                XdtFichaAnular.Retrieve()
                XdrFichaAnular = XdtFichaAnular.Current

                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                ObjFrmStbDatoComplemento.strTitulo = "Anulación de Ficha"
                ObjFrmStbDatoComplemento.intAncho = XdrFichaAnular.GetColumnLenght("sMotivoAnulacion")
                ObjFrmStbDatoComplemento.strDato = ""
                ObjFrmStbDatoComplemento.strColor = "RojoLight"
                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                ObjFrmStbDatoComplemento.ShowDialog()

                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                'Valida que se ingrese la Causa de la Anulación:
                If strCausaAnulacion = "" Then
                    MsgBox("El registro NO PUEDE ser Anulado.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                GuardarAuditoriaTablas(26, 2, "Modificar SclFichaSeguimiento Anular", XdtFicha.ValueField("nSclFichaSeguimientoID"), InfoSistema.IDCuenta)

                'Actualizar el Estado a Anulada:
                Strsql = " Update SclFichaSeguimiento " & _
                         " SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoFichaSeguimiento')," & _
                         "      nUsuarioModificacionID = " & InfoSistema.IDCuenta & ", dFechaModificacion = getdate(), sMotivoAnulacion = '" & strCausaAnulacion & "'" & _
                         " WHERE nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID")
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                       "de forma satisfactoria.", MsgBoxStyle.Information)
                'Guardar posición actual de la selección:
                intPosicion = XdtFicha.ValueField("nSclFichaSeguimientoID")
                Call GuardarAuditoria(5, 15, "Anulación Ficha de Seguimiento ID: " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ".")

                'StrCadena = " Where (a.nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ") "
                CargarFicha(StrCadena)

                'Ubicar la selección en la posición original:
                XdtFicha.SetCurrentByID("nSclFichaSeguimientoID", intPosicion)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position

            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtFichaAnular.Close()
            XdtFichaAnular = Nothing

            XdrFichaAnular.Close()
            XdrFichaAnular = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       LlamaAgregarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaSeguimiento para Agregar uno nuevo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarFicha()
        Dim ObjFrmSclEditFicha As New frmSclEditFichaSeguimiento
        Try

            ObjFrmSclEditFicha.ModoFrm = "ADD"
            ObjFrmSclEditFicha.intSclPermiteEditarDelegacion = IntPermiteEditar
            ObjFrmSclEditFicha.ShowDialog()

            'Si se ingreso un nuevo registro (Carga el Grid solo con este registro):
            If ObjFrmSclEditFicha.IdFicha <> 0 Then
                StrCadena = "Where (a.nSclFichaSeguimientoID = " & ObjFrmSclEditFicha.IdFicha & ")"
                CargarFicha(StrCadena)
                XdtFicha.SetCurrentByID("nSclFichaSeguimientoID", ObjFrmSclEditFicha.IdFicha)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFicha.Close()
            ObjFrmSclEditFicha = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       LlamaModificarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaSeguimiento para Modificar uno.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarFicha()
        Dim ObjFrmSclEditFicha As New frmSclEditFichaSeguimiento
        Try
            Dim Strsql As String
            'Si no existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Formatos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Verifica si no esta En Proceso:
            'Valida si no se encuentra En Proceso: 
            Strsql = "SELECT SclFichaSeguimiento.nSclFichaSeguimientoID " & _
                     "FROM StbValorCatalogo AS C INNER JOIN SclFichaSeguimiento ON C.nStbValorCatalogoID = SclFichaSeguimiento.nStbEstadoFichaID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (SclFichaSeguimiento.nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ")"
            If (RegistrosAsociados(Strsql) = False) Then
                MsgBox("Ficha NO se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                'Exit Sub
            End If

            ObjFrmSclEditFicha.ModoFrm = "UPD"
            ObjFrmSclEditFicha.intSclPermiteEditarDelegacion = IntPermiteEditar
            ObjFrmSclEditFicha.IdFicha = XdtFicha.ValueField("nSclFichaSeguimientoID")

            ObjFrmSclEditFicha.ShowDialog()

            CargarFicha(StrCadena)
            XdtFicha.SetCurrentByID("nSclFichaSeguimientoID", ObjFrmSclEditFicha.IdFicha)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFicha.Close()
            ObjFrmSclEditFicha = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
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
    ' Fecha:                03/07/2009
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Formato
    '                       de Promoción y Capacitación.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            'Si no existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            frmVisor.NombreReporte = "RepSclCS32.rpt"
            frmVisor.Text = "Ficha de Seguimiento al Crédito"
            frmVisor.SQLQuery = " Select * From vwSclFichaSeguimiento " & _
                                " Where (nSclFichaSeguimientoID = " & XdtFicha.ValueField("nSclFichaSeguimientoID") & ") "
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       grdFicha_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFicha.Filter
        Try
            XdtFicha.FilterLocal(e.Condition)
            Me.grdFicha.Caption = " Listado de Fichas de Seguimiento al Crédito (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Buscar: 
            If Seg.HasPermission("BuscarFichaSeguimiento") Then
                Me.toolBuscar.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
            End If

            'Agregar:
            If Seg.HasPermission("AgregarFichaSeguimiento") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar:
            If Seg.HasPermission("ModificarFichaSeguimiento") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Aplicar:
            If Seg.HasPermission("AplicarFichaSeguimiento") Then
                Me.toolAplicar.Enabled = True
            Else
                Me.toolAplicar.Enabled = False
            End If

            'Revertir Aplicacion (regresar Ficha a En Proceso):
            If Seg.HasPermission("RevertirAplicacionFichaSeguimiento") Then
                Me.toolRevertir.Enabled = True
            Else
                Me.toolRevertir.Enabled = False
            End If

            'Inactivar:
            If Seg.HasPermission("AnularFichaSeguimiento") Then
                Me.toolAnular.Enabled = True
            Else
                Me.toolAnular.Enabled = False
            End If

            '-- Imprimir:
            If Seg.HasPermission("ImprimirFichaSeguimientoCS32") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                01/07/2009
    ' Procedure Name:       grdFicha_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Ficha existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFicha.DoubleClick
        Try
            If Me.grdFicha.RowCount = 0 Then
                Exit Sub
            End If
            If Seg.HasPermission("ModificarFichaSeguimiento") Then
                LlamaModificarFicha()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFicha_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdFicha.Error
        Control_Error(e.Exception)
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	01/07/2009
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

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub
End Class