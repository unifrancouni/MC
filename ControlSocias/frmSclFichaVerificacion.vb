' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Su�rez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclFichaVerificacion.vb
' Descripci�n:          Este formulario carga los principales datos de
'                       la Ficha de Verificaci�n.
'-------------------------------------------------------------------------
Public Class frmSclFichaVerificacion
    '- Declaraci�n de Variables 
    Dim XdtFicha As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDepto As BOSistema.Win.XDataSet.xDataTable
    Dim StrCadena As String = ""
    Dim nAccesoTotalLectura As Short
    Dim nAccesoTotalEdicion As Short
    Dim XdtRubro As BOSistema.Win.XDataSet.xDataTable
    'Anexada para cambio de la actividad de negocio 08 feb 2011
    Dim XTmpdtFicha As BOSistema.Win.XDataSet.xDataTable

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclFichaVerificacion_FormClosing
    ' Descripci�n:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaVerificacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFicha.Close()
            XdtFicha = Nothing
            XTmpdtFicha.Close()
            XTmpdtFicha = Nothing

            XdtDepto.Close()
            XdtDepto = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclFichaVerificacion_Load
    ' Descripci�n:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Fichas de Verificaci�n en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaVerificacion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicaci�n.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            'Me.tbCaracterInicio.Visible = False
            Me.toolRefrescar.Visible = False

            'StrCadena = "A%"
            CargarDepartamento()
            StrCadena = ""

            CargarFicha(StrCadena)
            FormatoFicha()
            Seguridad()
            grpModificarActividad.Visible = False

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripci�n:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selecci�n.
    '-------------------------------------------------------------------------
    Private Sub CargarDepartamento()
        'Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDepartamento a " & _
                         " Order by a.sCodigo"

            XdtDepto.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdtDepto.Source

            ''Asignando a las fuentes de datos
            'Me.cboDepartamento.DataSource = XdsFicha("Departamento").Source

            'XdtValorParametro.Filter = "nStbParametroID = 14"
            'XdtValorParametro.Retrieve()

            ''Ubicarse en el primer registro
            'If XdsFicha("Departamento").Count > 0 Then
            '    XdsFicha("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            'End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "C�digo"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripci�n"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
            'Finally
            '    XdtValorParametro.Close()
            '    XdtValorParametro = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarFicha
    ' Descripci�n:          Este procedimiento permite cargar 
    '                       los datos de la Ficha en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarFicha(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String = ""

            Me.grdFicha.ClearFields()

            'If nAccesoTotalLectura = 1 Then
            '    Strsql = " Select a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSociaVerificado, " & _
            '             " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSociaVerificada, " & _
            '             " a.dFechaInscripcion,a.dFechaHoraVerificacion,a.nStbEstadoFichaID,a.nStbDelegacionProgramaID " & _
            '             " From vwSclFichaVerificacion a " & _
            '             " WHERE a.nStbDepartamentoID = " & XdtDepto.ValueField("nStbDepartamentoID") & " And a.sCodigoEstadoFicha > '1'" & _
            '             " AND a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
            '             " Order by a.sCodigo"
            'Else
            '    Strsql = " Select a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSociaVerificado, " & _
            '             " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSociaVerificada, " & _
            '             " a.dFechaInscripcion,a.dFechaHoraVerificacion,a.nStbEstadoFichaID,a.nStbDelegacionProgramaID " & _
            '             " From vwSclFichaVerificacion a " & _
            '             " WHERE a.sCodigoEstadoFicha > '1'" & _
            '             " AND a.nStbDepartamentoID = " & XdtDepto.ValueField("nStbDepartamentoID") & " And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
            '             " AND a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & _
            '             " Order by a.sCodigo"
            'End If

            If sCadenaFiltro = "" Then
                Strsql = " Select a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSociaVerificado, " & _
                         " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSociaVerificada, " & _
                         " a.dFechaInscripcion,a.dFechaHoraVerificacion,a.nStbEstadoFichaID,a.nStbDelegacionProgramaID ,a.DesActividadVerificada,a.nSclSociaID,a.CodPrograma,a.DesPrograma" & _
                         " From vwSclFichaVerificacion a " & _
                         " Where a.nSclFichaSociaID = 0" & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSociaVerificado, " & _
                         " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSociaVerificada, " & _
                         " a.dFechaInscripcion,a.dFechaHoraVerificacion,a.nStbEstadoFichaID,a.nStbDelegacionProgramaID ,a.DesActividadVerificada ,a.nSclSociaID,a.nSclSociaID,a.CodPrograma,a.DesPrograma" & _
                         " From vwSclFichaVerificacion a " & sCadenaFiltro & _
                         " Order by a.sCodigo"
            End If

            XdtFicha.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdFicha.DataSource = XdtFicha.Source
            Me.grdFicha.Rebind(False)

            Me.grdFicha.Caption = " Listado de Fichas de Verificaci�n (" + Me.grdFicha.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       LlamaBuscarSocia
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaSocias para buscar socias con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarSocia()
        Dim ObjFrmSclBusquedaSocias As New frmSclBusquedaSocias
        Try

            ObjFrmSclBusquedaSocias.StrCriterioSocia = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaSocias.IdDepartamento = XdtDepto.ValueField("nStbDepartamentoID")
            ObjFrmSclBusquedaSocias.IdConsultarDelegacion = nAccesoTotalLectura
            ObjFrmSclBusquedaSocias.IdTipoBusqueda = 4 'Busqueda Por Nombre o C�dula Socias.
            ObjFrmSclBusquedaSocias.ShowDialog()
            If ObjFrmSclBusquedaSocias.StrCriterioSocia <> "0" Then
                StrCadena = ObjFrmSclBusquedaSocias.StrCriterioSocia
                CargarFicha(StrCadena)
                FormatoFicha()
            End If
            'LlamaRefrescarRecibo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias.Close()
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Guti�rrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       LlamaBuscarSocia
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaSocias para buscar socias con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarGrupo()
        Dim ObjFrmSclBusquedaGrupos As New frmSclBusquedaGrupos
        Try

            ObjFrmSclBusquedaGrupos.StrCriterioGrupo = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaGrupos.IdDepartamento = XdtDepto.ValueField("nStbDepartamentoID")
            ObjFrmSclBusquedaGrupos.IdConsultarDelegacion = nAccesoTotalLectura
            ObjFrmSclBusquedaGrupos.IdTipoBusqueda = 4 'Busqueda Por Nombre o C�dula Socias.
            ObjFrmSclBusquedaGrupos.ShowDialog()
            If ObjFrmSclBusquedaGrupos.StrCriterioGrupo <> "0" Then
                StrCadena = ObjFrmSclBusquedaGrupos.StrCriterioGrupo
                CargarFicha(StrCadena)
                FormatoFicha()
            End If
            'LlamaRefrescarRecibo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaGrupos.Close()
            ObjFrmSclBusquedaGrupos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       FormatoFicha
    ' Descripci�n:          Este procedimiento permite configurar 
    '                       los datos sobre la Ficha en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoFicha()
        Try
            'Configuracion del Grid Comprobante
            Me.grdFicha.Splits(0).DisplayColumns("CodPrograma").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("DesPrograma").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaSociaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbEstadoFichaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdFicha.Splits(0).DisplayColumns("sCodigo").Width = 120
            Me.grdFicha.Splits(0).DisplayColumns("sNombre").Width = 140
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sDireccionSociaVerificada").Width = 90
            Me.grdFicha.Splits(0).DisplayColumns("sTelefonoSociaVerificado").Width = 50
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDepartamento").Width = 80
            Me.grdFicha.Splits(0).DisplayColumns("sNombreMunicipio").Width = 60
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDistrito").Width = 60
            Me.grdFicha.Splits(0).DisplayColumns("sNombreBarrio").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGrupo").Width = 150
            Me.grdFicha.Splits(0).DisplayColumns("dFechaInscripcion").Width = 70
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraVerificacion").Width = 80
            Me.grdFicha.Splits(0).DisplayColumns("sEstadoFicha").Width = 110

            Me.grdFicha.Columns("sCodigo").Caption = "C�digo"
            Me.grdFicha.Columns("sNombre").Caption = "Nombre Socia"
            Me.grdFicha.Columns("sNumeroCedula").Caption = "No.C�dula"
            Me.grdFicha.Columns("sDireccionSociaVerificada").Caption = "Direcci�n"
            Me.grdFicha.Columns("sTelefonoSociaVerificado").Caption = "Tel�fono"
            Me.grdFicha.Columns("sNombreDepartamento").Caption = "Departamento"
            Me.grdFicha.Columns("sNombreMunicipio").Caption = "Municipio"
            Me.grdFicha.Columns("sNombreDistrito").Caption = "Distrito"
            Me.grdFicha.Columns("sNombreBarrio").Caption = "Barrio"
            Me.grdFicha.Columns("sNombreGrupo").Caption = "Grupo Solidario"
            Me.grdFicha.Columns("dFechaInscripcion").Caption = "F.Inscripci�n"
            Me.grdFicha.Columns("dFechaHoraVerificacion").Caption = "F.Verificaci�n"
            Me.grdFicha.Columns("sNombreDistrito").Caption = "Distrito"
            Me.grdFicha.Columns("sEstadoFicha").Caption = "Estado"
            Me.grdFicha.Columns("DesActividadVerificada").Caption = "Actividad"

            Me.grdFicha.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaInscripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraVerificacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFicha.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sDireccionSociaVerificada").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sTelefonoSociaVerificado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDepartamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreMunicipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreBarrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaInscripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sEstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraVerificacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("DesActividadVerificada").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializaVariables
    ' Descripci�n:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            XdtFicha = New BOSistema.Win.XDataSet.xDataTable
            'agregado cambio 08 02 2011
            XTmpdtFicha = New BOSistema.Win.XDataSet.xDataTable

            XdtDepto = New BOSistema.Win.XDataSet.xDataTable

            Me.toolAgregar.Enabled = False
            Me.toolAgregar.Visible = False
            Me.toolAnular.Enabled = False
            Me.toolAnular.Visible = False

            strSQL = " SELECT nAccesoTotalLectura,nAccesoTotalEdicion " & _
                     " FROM StbDelegacionPrograma " & _
                     " WHERE nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion

            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nAccesoTotalLectura = XdtDatos.ValueField("nAccesoTotalLectura")
                nAccesoTotalEdicion = XdtDatos.ValueField("nAccesoTotalEdicion")
            End If

            Me.Text = "Ficha de Verificaci�n"

            'Limpiar los Grids, estructura y Datos
            Me.grdFicha.ClearFields()

            XdtRubro = New BOSistema.Win.XDataSet.xDataTable
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    'Private Sub LlamaHistorial()
    '    Dim ObjfrmSclReptFichaVerificacion As frmSclReptFichaVerificacion

    '    Try

    '        'ObjfrmSclReptFichaVerificacion = New frmSclReptFichaVerificacion

    '        '-- Poner el cursor en un estado de ocupado
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
    '        frmSclReptFichaVerificacion.ShowDialog()


    '        'ObjfrmSclReptFichaVerificacion.MdiParent = Me

    '        'ObjfrmSclReptFichaVerificacion.WindowState = FormWindowState.Maximized
    '        'OpenForm(ObjfrmSclReptFichaVerificacion, Me)

    '        ''-- Para enviar el foco al formulario 
    '        ''-- que se est� llamando.
    '        'ObjfrmSclReptFichaVerificacion.BringToFront()

    '        '-- Poner el cursor en un estado de desocupado
    '        Me.Cursor = System.Windows.Forms.Cursors.Default

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        ObjfrmSclReptFichaVerificacion = Nothing
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       tbFicha_ItemClicked
    ' Descripci�n:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbFicha.
    '-------------------------------------------------------------------------
    Private Sub tbFicha_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name

            Case "toolAgregar"
                'LlamaAgregarFicha()
            Case "toolModificar"

                If XdtFicha.ValueField("CodPrograma") = "3" Then 'PDIBA
                    LlamaModificarFichaVersionAnterior()
                Else
                    LlamaModificarFicha()  'Usura cero
                End If

            Case "toolAnular"
                'LlamaAnularFicha()
            Case "toolConfirmar"
                LlamaConfirmar()
            Case "toolRefrescar"
                'InicializaVariables()
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento v�lido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento v�lido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                CargarFicha(StrCadena)
                FormatoFicha()

            Case "toolBuscar"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento v�lido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento v�lido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                LlamaBuscarSocia()

            Case "toolBuscarGrupo"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento v�lido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento v�lido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                LlamaBuscarGrupo()

            Case "toolImprimir"
                LlamaImprimir()
            Case "toolImprimirModulo"
                LlamaImprimirModulos()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
            Case "toolActualizarActividad"
                LlamaActualizarActividad()

            Case "toolGrabarModulo"
                LlamaGrabarModulo()

        End Select
    End Sub

    Private Sub LlamaImprimirModulos()
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdFicha.RowCount = 0 Then
                'MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Parametros("@nSclFichaNotificacionID") = 0
            frmVisor.Parametros("@nSclFichaSociaID") = XdtFicha.ValueField("nSclFichaSociaID")
            frmVisor.NombreReporte = "RepSclCS68.rpt"
            frmVisor.Text = "M�dulo M�ximo Aprobado - Cursos"
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.ShowDialog()
            Me.Cursor = Cursors.Default
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
            frmVisor.Close()
            frmVisor = Nothing
        End Try
    End Sub


    'Anexado 07 Jun 2016
    'Para grabar el m�dulo de curso m�ximo que la socia aprob�
    '
    Private Sub LlamaGrabarModulo()
        Dim objFrmSclModuloFichaSocia As New frmSclEditModuloCursoSocia

        Try
            Dim TmpBusqueda As BOSistema.Win.XDataSet.xDataTable
            TmpBusqueda = New BOSistema.Win.XDataSet.xDataTable

            Dim strsql As String
            strsql = "SELECT nStbActividadEconomicaVerificadaID, nSclFichaSociaID,sCodigoInterno   ,sDireccionSociaVerificada,sTelefonoSociaVerificado   ,sDireccionNegocioVerificada    FROM dbo.SclFichaSocia  INNER Join dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID WHERE     (nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID") & ")"

            TmpBusqueda.ExecuteSql(strsql)
            If TmpBusqueda.ValueField("sCodigoInterno") <> "3" And TmpBusqueda.ValueField("sCodigoInterno") <> "2" Then 'And TmpBusqueda.ValueField("sCodigoInterno") <> "5"
                MsgBox("Solo se permite modificar m�dulo en la ficha de verificacion en estado pendiente de verificar y verificado.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If

            objFrmSclModuloFichaSocia.nSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            objFrmSclModuloFichaSocia.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub


    'Anexado 10 feb 2011
    'Permite activar los controles para ingresar la actividad economica
    '
    Private Sub LlamaActualizarActividad()
        Dim lSclFichaID As Long
        Dim TmpBusqueda As BOSistema.Win.XDataSet.xDataTable
        TmpBusqueda = New BOSistema.Win.XDataSet.xDataTable
        If Me.grdFicha.RowCount = 0 Then
            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
            Exit Sub
        End If

        lSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
        Dim strsql As String
        strsql = "SELECT     nStbActividadEconomicaVerificadaID, nSclFichaSociaID,sCodigoInterno   ,sDireccionSociaVerificada,sTelefonoSociaVerificado   ,sDireccionNegocioVerificada    FROM dbo.SclFichaSocia  INNER Join dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID WHERE     (nSclFichaSociaID = " & lSclFichaID & ")"

        TmpBusqueda.ExecuteSql(strsql)
        If TmpBusqueda.ValueField("sCodigoInterno") <> "3" And TmpBusqueda.ValueField("sCodigoInterno") <> "5" Then
            MsgBox("Solo se permite modificar activad economica en la ficha de verificacion en estado aprobado y verificado.", MsgBoxStyle.Critical, "SMUSURA0")
            Exit Sub

        End If

        grpModificarActividad.Visible = True
        ActivarControles(False)

        txtCodigo.Text = XdtFicha.ValueField("sCodigo")
        txtnocedula.Text = XdtFicha.ValueField("sNumeroCedula")
        txtNombre.Text = XdtFicha.ValueField("sNombre")
        txtdepartamento.Text = XdtFicha.ValueField("sNombreDepartamento")
        txtmunicipio.Text = XdtFicha.ValueField("sNombreMunicipio")
        txtdistrito.Text = XdtFicha.ValueField("sNombreDistrito")
        txtbarrio.Text = XdtFicha.ValueField("sNombreBarrio")
        txtDireccion.Text = XdtFicha.ValueField("sDireccionSociaVerificada")
        If Not IsDBNull(XdtFicha.ValueField("sTelefonoSociaVerificado")) Then
            txtTelefono.Text = XdtFicha.ValueField("sTelefonoSociaVerificado")
        Else
            txtTelefono.Text = ""
        End If


        If Not IsDBNull(TmpBusqueda.ValueField("sDireccionNegocioVerificada")) Then
            txtIV12.Text = TmpBusqueda.ValueField("sDireccionNegocioVerificada")
        Else
            txtIV12.Text = ""
        End If

        strsql = " SELECT   nStbRubroNegocioID,  sMeta, SclFichaSocia.nStbActividadEconomicaVerificadaID From SclFichaSociaNegocio inner join SclFichaSocia on SclFichaSocia.nSclFichaSociaID=SclFichaSociaNegocio.nSclFichaSociaID WHERE (SclFichaSocia.nSclFichaSociaID = " & lSclFichaID & ")"
        TmpBusqueda.ExecuteSql(strsql)
        If TmpBusqueda.Count > 0 Then
            txtMetaProsperidad.Text = TmpBusqueda.ValueField("sMeta")
            'cboIV13.SelectedValue = TmpBusqueda.ValueField("nStbRubroNegocioID")
            cboIV13.BackColor = System.Drawing.Color.FromArgb(255, 224, 224, 224)
            cboIV13.Enabled = True
            cboIV13.ReadOnly = False
            CargarRubro(0)

            If Not IsDBNull(TmpBusqueda.ValueField("nStbActividadEconomicaVerificadaID")) Then
                CargarTipoNegocioActual(TmpBusqueda.ValueField("nStbActividadEconomicaVerificadaID"))
                XTmpdtFicha.SetCurrentByID("nStbValorCatalogoID", TmpBusqueda.ValueField("nStbActividadEconomicaVerificadaID"))
            Else
                MsgBox("Socia NO tiene Actividad Econ�mica.", vbExclamation, "SMUSURA0")
                CargarTipoNegocioActual(0)
            End If

            XdtRubro.SetCurrentByID("nStbValorCatalogoID", TmpBusqueda.ValueField("nStbRubroNegocioID"))

            cboIV13.SelectedValue = TmpBusqueda.ValueField("nStbRubroNegocioID")
        End If
        txtIV12.Enabled = True
        txtIV12.ReadOnly = False



        'TmpBusqueda.ValueField("nStbActividadEconomicaID"))

    End Sub

    Private Sub CargarRubro(ByVal RubroEspecifico As Integer)
        Try
            Dim Strsql As String = ""
            Dim cmd As New BOSistema.Win.XComando

            Strsql = "SELECT dbo.StbValorCatalogo.nStbValorCatalogoID FROM dbo.SclClasificacionEconomica INNER JOIN dbo.StbValorCatalogo ON dbo.SclClasificacionEconomica.nStbTipoActividadEconomicaID = dbo.StbValorCatalogo.nStbValorCatalogoID INNER JOIN dbo.StbValorCatalogo AS StbValorCatalogo_1 ON dbo.SclClasificacionEconomica.nStbActividadEconomicaID = StbValorCatalogo_1.nStbValorCatalogoID WHERE StbValorCatalogo_1.nStbValorCatalogoID=" & RubroEspecifico

            Dim rubroID = cmd.ExecuteScalar(Strsql)

            CmdAceptar.Enabled = True
            If RubroEspecifico = 0 Then
                Strsql = "SELECT     nStbValorCatalogoID, sCodigoInterno as Codigo, sDescripcion as Descripcion " &
                    "FROM         dbo.StbValorCatalogo " &
                    "WHERE     nStbCatalogoID = 39"
            Else
                Strsql = "SELECT     nStbValorCatalogoID, sCodigoInterno as Codigo, sDescripcion as Descripcion " &
                    "FROM         dbo.StbValorCatalogo " &
                    "WHERE     nStbValorCatalogoID = " & rubroID
            End If

            XdtRubro.ExecuteSql(Strsql)

            If XdtRubro.Count = 0 And RubroEspecifico <> 0 Then
                MsgBox("La actividad econ�mica seleccionada no tiene rubro asociado. Comunicar a direcci�n de promoci�n y capacitaci�n.", vbCritical, "SMUSURA0")
                CmdAceptar.Enabled = False
                Exit Sub
            End If

            Me.cboIV13.DataSource = XdtRubro.Source

            Me.cboIV13.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboIV13.Splits(0).DisplayColumns("Codigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboIV13.Splits(0).DisplayColumns("Codigo").Width = 47
            Me.cboIV13.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboIV13.Columns("Codigo").Caption = "C�digo"
            Me.cboIV13.Columns("Descripcion").Caption = "Descripci�n"

            Me.cboIV13.Splits(0).DisplayColumns("Codigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboIV13.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboIV13.DisplayMember = "Descripci�n"
            Me.cboIV13.ValueMember = "nStbValorCatalogoID"

            If XdtRubro.Count > 0 Then
                Me.cboIV13.SelectedIndex = 0
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Anexado Febrero 10 2011
    Private Sub CargarTipoNegocioActual(ByVal nStbActVerificada As Long)
        Try
            Dim Strsql As String = ""


            'If nStbActVerificada <> 0 Then
            Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " &
                         " From StbValorCatalogo a INNER JOIN " &
                         " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " &
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " &
                         " WHERE a.nActivo = 1  or  a.nStbValorCatalogoID=" & nStbActVerificada &
                         " Order by a.sCodigoInterno "
                'Else
                '    Strsql = " Select a.nStbValorCatalogoID,a.sCodigoInterno,a.sDescripcion " &
                '             " From StbValorCatalogo a INNER JOIN " &
                '             " (Select nStbCatalogoID From StbCatalogo Where sNombre = 'TipoNegocio') b " &
                '             " ON a.nStbCatalogoID = b.nStbCatalogoID " &
                '             " WHERE a.nActivo = 1 " &
                '             " Order by a.sCodigoInterno "
                'End If
                XTmpdtFicha.ExecuteSql(Strsql)
            'If XdsFicha.ExistTable("TipoNegocioActual") Then
            '    XdsFicha("TipoNegocioActual").ExecuteSql(Strsql)
            'Else
            '    XdsFicha.NewTable(Strsql, "TipoNegocioActual")
            '    XdsFicha("TipoNegocioActual").Retrieve()
            'End If

            'Asignando a las fuentes de datos
            Me.cboTipoNegocioActual.DataSource = XTmpdtFicha.Source

            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").Width = 43
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sDescripcion").Width = 250

            Me.cboTipoNegocioActual.Columns("sCodigoInterno").Caption = "C�digo"
            Me.cboTipoNegocioActual.Columns("sDescripcion").Caption = "Descripci�n"

            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboTipoNegocioActual.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboTipoNegocioActual.ValueMember = "nStbValorCatalogoID"
            Me.cboTipoNegocioActual.DisplayMember = "sDescripcion"


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Su�rez Tijerino
    '' Fecha:                12/09/2007
    '' Procedure Name:       tbCaracterInicio_ItemClicked
    '' Descripci�n:          Este evento permite manejar las opciones del control
    ''                       toolStrip llamado tbSocia.
    ''-------------------------------------------------------------------------
    'Private Sub tbCaracterInicio_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    '    Try
    '        If Me.cboDepartamento.SelectedIndex = -1 Then
    '            MsgBox("Debe seleccionar un Departamento v�lido.", MsgBoxStyle.Critical, "SMUSURA0")
    '            'ValidaDatosEntrada = False
    '            'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento v�lido.")
    '            Me.cboDepartamento.Focus()
    '            Exit Sub
    '        End If

    '        Select Case e.ClickedItem.Name
    '            Case "toolA"
    '                StrCadena = "A%"
    '            Case "toolB"
    '                StrCadena = "B%"
    '            Case "toolC"
    '                StrCadena = "C%"
    '            Case "toolD"
    '                StrCadena = "D%"
    '            Case "toolE"
    '                StrCadena = "E%"
    '            Case "toolF"
    '                StrCadena = "F%"
    '            Case "toolG"
    '                StrCadena = "G%"
    '            Case "toolH"
    '                StrCadena = "H%"
    '            Case "toolI"
    '                StrCadena = "I%"
    '            Case "toolJ"
    '                StrCadena = "J%"
    '            Case "toolK"
    '                StrCadena = "K%"
    '            Case "toolL"
    '                StrCadena = "L%"
    '            Case "toolM"
    '                StrCadena = "M%"
    '            Case "toolN"
    '                StrCadena = "N%"
    '            Case "tool�"
    '                StrCadena = "�%"
    '            Case "toolO"
    '                StrCadena = "O%"
    '            Case "toolP"
    '                StrCadena = "P%"
    '            Case "toolQ"
    '                StrCadena = "Q%"
    '            Case "toolR"
    '                StrCadena = "R%"
    '            Case "toolS"
    '                StrCadena = "S%"
    '            Case "toolT"
    '                StrCadena = "T%"
    '            Case "toolU"
    '                StrCadena = "U%"
    '            Case "toolV"
    '                StrCadena = "V%"
    '            Case "toolW"
    '                StrCadena = "W%"
    '            Case "toolX"
    '                StrCadena = "X%"
    '            Case "toolY"
    '                StrCadena = "Y%"
    '            Case "toolZ"
    '                StrCadena = "Z%"
    '            Case "tool1"
    '                StrCadena = "1%"
    '            Case "tool2"
    '                StrCadena = "2%"
    '            Case "tool3"
    '                StrCadena = "3%"
    '            Case "tool4"
    '                StrCadena = "4%"
    '            Case "tool5"
    '                StrCadena = "5%"
    '            Case "tool6"
    '                StrCadena = "6%"
    '            Case "tool7"
    '                StrCadena = "7%"
    '            Case "tool8"
    '                StrCadena = "8%"
    '            Case "tool9"
    '                StrCadena = "9%"
    '        End Select
    '        CargarFicha(StrCadena)
    '        FormatoFicha()

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAgregarFicha
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaInscripcion para Agregar una nueva ficha.
    '-------------------------------------------------------------------------
    'Private Sub LlamaAgregarFicha()
    '    Dim ObjFrmSclEditFichaVerificacion As New frmSclEditFichaVerificacion
    '    Try
    '        ObjFrmSclEditFichaVerificacion.ModoFrm = "ADD"
    '        ObjFrmSclEditFichaVerificacion.ShowDialog()

    '        If ObjFrmSclEditFichaVerificacion.intSclFichaID <> 0 Then
    '            CargarFicha()
    '            XdtFicha.SetCurrentByID("nSclFichaSociaID", ObjFrmSclEditFichaVerificacion.intSclFichaID)
    '            Me.grdFicha.Row = XdtFicha.BindingSource.Position
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        'ObjFrmSclEditFichaInscripcion.Close()
    '        ObjFrmSclEditFichaVerificacion = Nothing
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaConfirmar
    ' Descripci�n:          Este procedimiento permite realizar el cambio a Pendiente
    '                       Verificaci�n para la Ficha de Inscripci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaConfirmar()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer

            If ValidaDatosConfirmacion() Then
                'Actualizar el EstadoFicha a Verificada.
                Strsql = " Update SclFichaSocia " & _
                        "  SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoFicha')," & _
                        "      sUsuarioModificacion = '" & InfoSistema.LoginName & "'," & _
                        "      dFechaModificacion = getdate()" & _
                        "  WHERE nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")


                Strsql = "Exec SpAUDITSclFichaSociaVERIFICADA  'Update','Actualizar  Ficha a Confirmada'," & XdtFicha.ValueField("nSclFichaSociaID") & ",''," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "',1"


                XcDatos.ExecuteNonQuery(Strsql)

                Call GuardarAuditoria(5, 15, "Confirmaci�n de Ficha de Verificaci�n ID: " & XdtFicha.ValueField("nSclFichaSociaID") & ".")

                MsgBox("Cambio a Verificada realizado Exitosamente.", MsgBoxStyle.Information, "SMUSURA0")

                'Guardar posici�n actual de la selecci�n
                intPosicion = XdtFicha.ValueField("nSclFichaSociaID")
                CargarFicha(StrCadena)
                FormatoFicha()
                'Ubicar la selecci�n en la posici�n original
                XdtFicha.SetCurrentByID("nSclFichaSociaID", intPosicion)
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
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosConfirmacion
    ' Descripci�n:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de cambiar a
    '                       Verificada a una Ficha de Verificaci�n.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosConfirmacion() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            ValidaDatosConfirmacion = True

            Dim Strsql As String

            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                ValidaDatosConfirmacion = False
                Exit Function
            End If

            If nAccesoTotalEdicion = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("No puede Modificar datos de otra Delegaci�n.", MsgBoxStyle.Information)
                    ValidaDatosConfirmacion = False
                    Exit Function
                End If
            End If

            'Valida si la Ficha tiene estado "Pendiente Verificaci�n"
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoFicha' "
            If XcDatos.ExecuteScalar(Strsql) <> XdtFicha.ValueField("nStbEstadoFichaID") Then
                MsgBox("Para cambiarse al estado Verificada," & Chr(10) & _
                       "la Ficha DEBE estar actualmente en estado Pendiente Verificaci�n.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosConfirmacion = False
                Exit Function
            End If

            'Valida que la Fecha de Verificaci�n no est� en Null y por lo tanto haya grabado
            'aunque sea una vez los datos de la verificaci�n.
            If XdtFicha.ValueField("dFechaHoraVerificacion") Is DBNull.Value Then
                MsgBox("Fecha de Verificaci�n no existe." & Chr(10) & _
                       "Primero DEBE ingresar los datos correspondientes a la Verificaci�n.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosConfirmacion = False
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaModificarFicha
    ' Descripci�n:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaVerificacion para Modificar una ficha existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarFicha()
        Dim ObjFrmSclEditFichaVerificacion As New frmSclEditFichaVerificacionNueva
        Try
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If nAccesoTotalEdicion = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("No puede Modificar datos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            ObjFrmSclEditFichaVerificacion.ModoFrm = "UPD"
            ObjFrmSclEditFichaVerificacion.intSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            ObjFrmSclEditFichaVerificacion.ShowDialog()

            CargarFicha(StrCadena)
            FormatoFicha()
            XdtFicha.SetCurrentByID("nSclFichaSociaID", ObjFrmSclEditFichaVerificacion.intSclFichaID)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFichaVerificacion.Close()
            ObjFrmSclEditFichaVerificacion = Nothing
        End Try
    End Sub
    Private Sub LlamaModificarFichaVersionAnterior()
        Dim ObjFrmSclEditFichaVerificacion As New frmSclEditFichaVerificacion
        Try
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If nAccesoTotalEdicion = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("No puede Modificar datos de otra Delegaci�n.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            ObjFrmSclEditFichaVerificacion.ModoFrm = "UPD"
            ObjFrmSclEditFichaVerificacion.intSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            ObjFrmSclEditFichaVerificacion.ShowDialog()

            CargarFicha(StrCadena)
            FormatoFicha()
            XdtFicha.SetCurrentByID("nSclFichaSociaID", ObjFrmSclEditFichaVerificacion.intSclFichaID)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFichaVerificacion.Close()
            ObjFrmSclEditFichaVerificacion = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAnularFicha
    ' Descripci�n:          Este procedimiento permite Anular un registro
    '                       de una Ficha existente. No se realiza una Eliminaci�n
    '                       f�sica del registro.
    '-------------------------------------------------------------------------
    'Private Sub LlamaAnularFicha()
    '    Dim XdtFichaAnular As New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
    '    Dim XdrFichaAnular As New BOSistema.Win.SclEntFicha.SclFichaSociaRow
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
    '    Try
    '        Dim Strsql As String
    '        Dim intPosicion As Long  'Posicion del registro seleccionado, ID de la Ficha
    '        Dim strCausaAnulacion As String

    '        If MsgBox("�Est� seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

    '            If ValidaDatosAnular() Then

    '                'Solicita al Usuario la Causa de la Anulaci�n
    '                XdtFichaAnular.Filter = " nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")
    '                XdtFichaAnular.Retrieve()
    '                XdrFichaAnular = XdtFichaAnular.Current

    '                ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulaci�n? "
    '                ObjFrmStbDatoComplemento.strTitulo = "Anulaci�n de la Ficha"
    '                ObjFrmStbDatoComplemento.intAncho = XdrFichaAnular.GetColumnLenght("sMotivoAnulacion")
    '                ObjFrmStbDatoComplemento.strDato = ""
    '                ObjFrmStbDatoComplemento.strColor = "RojoLight"
    '                ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulaci�n NO DEBE quedar vac�a"
    '                ObjFrmStbDatoComplemento.ShowDialog()

    '                strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

    '                'Valida que se ingrese la Causa de la Anulaci�n
    '                If strCausaAnulacion = "" Then
    '                    MsgBox("El registro NO PUEDE ser Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
    '                    Exit Sub
    '                End If

    '                'Actualizar el EstadoFicha a Anulado.
    '                Strsql = " Update SclFichaSocia " & _
    '                        "  SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '4' And b.sNombre = 'EstadoFicha')," & _
    '                        "      sMotivoAnulacion = '" & strCausaAnulacion & "'" & _
    '                        "  WHERE nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")

    '                XcDatos.ExecuteNonQuery(Strsql)

    '                MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
    '                        "de forma satisfactoria.", MsgBoxStyle.Information)
    '                'Guardar posici�n actual de la selecci�n
    '                intPosicion = XdtFicha.ValueField("nSclFichaSociaID")
    '                CargarFicha()

    '                'Ubicar la selecci�n en la posici�n original
    '                XdtFicha.SetCurrentByID("nSclFichaSociaID", intPosicion)
    '                Me.grdFicha.Row = XdtFicha.BindingSource.Position

    '            End If
    '        End If
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XdtFichaAnular.Close()
    '        XdtFichaAnular = Nothing

    '        XdrFichaAnular.Close()
    '        XdrFichaAnular = Nothing

    '        XcDatos.Close()
    '        XcDatos = Nothing

    '        ObjFrmStbDatoComplemento.Close()
    '        ObjFrmStbDatoComplemento = Nothing
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosAnular
    ' Descripci�n:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de Anular una
    '                       Ficha.
    '-------------------------------------------------------------------------
    'Private Function ValidaDatosAnular() As Boolean
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Try
    '        ValidaDatosAnular = True

    '        Dim Strsql As String

    '        If Me.grdFicha.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Critical, "SMUSURA0")
    '            ValidaDatosAnular = False
    '            Exit Function
    '        End If

    '        'Se verificar si el Estado de la Ficha es Anulado
    '        Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '4' And b.sNombre = 'EstadoFicha' "
    '        If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
    '            MsgBox("La Ficha ya tiene Estado Anulada.", MsgBoxStyle.Critical, "SMUSURA0")
    '            ValidaDatosAnular = False
    '            Exit Function
    '        End If

    '        'Se verificar si el Estado de la Ficha es Aprobada
    '        Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '5' And b.sNombre = 'EstadoFicha' "
    '        If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
    '            MsgBox("La Ficha NO PUEDE ser Anulada, porque actualmente tiene estado Aprobada.", MsgBoxStyle.Critical, "SMUSURA0")
    '            ValidaDatosAnular = False
    '            Exit Function
    '        End If

    '        'Se verificar si el Estado de la Ficha es Rechazada
    '        Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '6' And b.sNombre = 'EstadoFicha' "
    '        If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
    '            MsgBox("La Ficha NO PUEDE ser Anulada, porque actualmente tiene estado Rechazada.", MsgBoxStyle.Critical, "SMUSURA0")
    '            ValidaDatosAnular = False
    '            Exit Function 
    '        End If

    '        'Se verificar si el Estado de la Ficha es Cancelada
    '        Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '7' And b.sNombre = 'EstadoFicha' "
    '        If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
    '            MsgBox("La Ficha NO PUEDE ser Anulada, porque actualmente tiene estado Cancelada.", MsgBoxStyle.Critical, "SMUSURA0")
    '            ValidaDatosAnular = False
    '            Exit Function
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripci�n:          Este procedimiento permite cerrar la opci�n de Ficha de Inscripci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAyuda
    ' Descripci�n:          Este procedimiento permite presentar la Ayuda en
    '                       L�nea al usuario. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripci�n:          Este procedimiento permite Imprimir La Hoja de 
    '                       Verificaci�n seleccionado. Actualmente en Construcci�n.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim ObjFrmSclParametroFicha As New frmSclParametroFicha
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdFicha.RowCount = 0 Then
                'MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclParametroFicha.NomRep = 2
            ObjFrmSclParametroFicha.intSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            'ObjFrmSclParametroFicha.IdConsecutivoPrestamo = XdtFicha.ValueField("nConsecutivoCredito")
            'ObjFrmSclParametroFicha.ModoFrm = "IMPRIMIR"
            'ObjFrmSclParametroFicha.strColor = "Verde"
            'ObjFrmSclParametroFicha.strTipoComprobante = Me.strTipoComp
            ObjFrmSclParametroFicha.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmSclParametroFicha.Close()
            ObjFrmSclParametroFicha = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdFicha_Filter
    ' Descripci�n:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFicha.Filter
        Try
            XdtFicha.FilterLocal(e.Condition)
            Me.grdFicha.Caption = " Listado de Fichas de Verificaci�n (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       Seguridad
    ' Descripci�n:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            'If Seg.HasPermission("AgregarFichaInscripcion") Then
            '    Me.toolAgregar.Enabled = True
            'Else
            '    Me.toolAgregar.Enabled = False
            'End If

            'Modificar
            If Seg.HasPermission("ModificarFichaVerificacion") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Buscar
            If Seg.HasPermission("BuscarFichaVerificacion") Then
                Me.toolBuscar.Enabled = True
                Me.toolBuscarGrupo.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
                Me.toolBuscarGrupo.Enabled = False
            End If

            'Confirmar
            If Seg.HasPermission("ConfirmarFichaVerificacion") Then
                Me.toolConfirmar.Enabled = True
            Else
                Me.toolConfirmar.Enabled = False
            End If

            'Imprimir 
            If Seg.HasPermission("ImprimirFichaVerificacion") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If
            'Imprimir 
            If Seg.HasPermission("ActualizarActividadFichaVerificacion") Then
                Me.toolActualizarActividad.Enabled = True
            Else
                Me.toolActualizarActividad.Enabled = False
            End If



        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Su�rez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdFicha_DoubleClick
    ' Descripci�n:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Ficha existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdFicha.DoubleClick
        Try
            If Me.grdFicha.RowCount = 0 Then
                Exit Sub
            End If

            If Seg.HasPermission("ModificarFichaVerificacion") Then
                'LlamaModificarFicha()


                If XdtFicha.ValueField("CodPrograma") = "3" Then 'PDIBA
                    LlamaModificarFichaVersionAnterior()
                Else
                    LlamaModificarFicha()  'Usura cero
                End If

            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra Otro Tipo de Error
    Private Sub grdFicha_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdFicha.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Me.grpModificarActividad.Visible = False
        ActivarControles(True)
        

    End Sub
    Private Sub ActivarControles(ByVal band As Boolean)
        Me.tbFicha.Enabled = band
        Me.cboDepartamento.Enabled = band
        Me.grdFicha.Enabled = band

    End Sub



    Private Sub CmdAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Dim StrSql As String
        Dim XcEjecuta As New BOSistema.Win.XComando
        Dim xnSclFichaSociaID As Long
        Dim IdFicha As Long
        Try

            If Trim(txtDireccion.Text) = "" Then
                MsgBox("La direcci�n no puede quedar vac�a.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If


            If Trim(txtIV12.Text) = "" Then
                MsgBox("La direcci�n del negocio no puede quedar vac�a.", MsgBoxStyle.Critical, "SMUSURA0")
                Exit Sub
            End If




            If MsgBox("Esta seguro de actualizar la direccion y actividad economica.", MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.No Then
                Exit Sub
            End If



            'StrSql = " Update SclFichaSocia Set nStbActividadEconomicaVerificadaID= " & XTmpdtFicha.ValueField("nStbValorCatalogoId") & _
            '", sDireccionSocia= '" & Trim(Me.txtDireccion.Text) & "' ,sDireccionSociaVerificada='" & Trim(Me.txtDireccion.Text) & "'   ,  sUsuarioModificacion = '" & InfoSistema.LoginName & "'," & _
            '"      dFechaModificacion = getdate()" & _
            '"  WHERE nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")




            GuardarAuditoriaTablas(25, 2, "Modificar Ficha verificacion Actividad Economica SclSocia", XdtFicha.ValueField("nSclSociaID"), InfoSistema.IDCuenta)
            GuardarAuditoriaTablas(7, 2, "Modificar Ficha verificacion Actividad Economica SclFichaSocia", XdtFicha.ValueField("nSclFichaSociaID"), InfoSistema.IDCuenta)

            '-- Ejecuta Procedimiento Almacenado:
            StrSql = " EXEC spSclActualizarFichaSociaActividad " & XdtFicha.ValueField("nSclFichaSociaID") & ", '" & Trim(Me.txtDireccion.Text) & "', '" & Trim(txtTelefono.Text) & "'," & XTmpdtFicha.ValueField("nStbValorCatalogoId") & ",'" & InfoSistema.LoginName & "','" & txtMetaProsperidad.Text.Trim() & "','" & txtIV12.Text.Trim() & "'," & Me.cboIV13.SelectedValue
            IdFicha = XcEjecuta.ExecuteScalar(StrSql)


            'XcEjecuta.ExecuteNonQuery(StrSql)

            If IdFicha = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                Call GuardarAuditoria(5, 15, "Actualizacion Actividad Economica de Ficha de Verificaci�n ID: " & XdtFicha.ValueField("nSclFichaSociaID") & ".")
                MsgBox("La Ficha de Verificacion ha sido actualizada en su actividad economica.", MsgBoxStyle.Information, "SMUSURA0")
            End If

            xnSclFichaSociaID = XdtFicha.ValueField("nSclFichaSociaID")

            CargarFicha(StrCadena)
            FormatoFicha()
            XdtFicha.SetCurrentByID("nSclFichaSociaID", xnSclFichaSociaID)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

            grpModificarActividad.Visible = False
            ActivarControles(True)
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcEjecuta.Close()
            XcEjecuta = Nothing

        End Try
    End Sub

    Private Sub cboTipoNegocioActual_TextChanged(sender As Object, e As EventArgs) Handles cboTipoNegocioActual.TextChanged
        CargarRubro(cboTipoNegocioActual.SelectedValue)
    End Sub

End Class