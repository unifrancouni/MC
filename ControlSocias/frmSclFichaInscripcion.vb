' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclFichaInscripcion.vb
' Descripción:          Este formulario carga los principales datos de
'                       la Ficha de Inscripción.
'-------------------------------------------------------------------------
Public Class frmSclFichaInscripcion

    '- Declaración de Variables 
    Dim XdtFicha As BOSistema.Win.XDataSet.xDataTable

    Dim XdtDepto As BOSistema.Win.XDataSet.xDataTable
    Dim StrCadena As String = ""
    Dim nAccesoTotalLectura As Short
    Dim nAccesoTotalEdicion As Short

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclFichaInscripcion_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaInscripcion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFicha.Close()
            XdtFicha = Nothing

            XdtDepto.Close()
            XdtDepto = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmSclFichaInscripcion_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Fichas de Inscripción en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaInscripcion_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
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

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
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

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos de los Comprobantes Contables en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarFicha(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String = ""

            Me.grdFicha.ClearFields()
            'If nAccesoTotalLectura = 1 Then
            '    Strsql = " SELECT a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSocia, " & _
            '             " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSocia, " & _
            '             " a.dFechaInscripcion,a.nStbEstadoFichaID,a.nConsecutivoCredito,a.sUsuarioCreacion,a.nStbDelegacionProgramaID " & _
            '             " FROM vwSclFichaInscripcion a " & _
            '             " WHERE a.nStbDepartamentoID = " & XdtDepto.ValueField("nStbDepartamentoID") & " And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
            '             " ORDER BY a.sCodigo"
            'Else
            '    Strsql = " SELECT a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSocia, " & _
            '             " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSocia, " & _
            '             " a.dFechaInscripcion,a.nStbEstadoFichaID,a.nConsecutivoCredito,a.sUsuarioCreacion,a.nStbDelegacionProgramaID " & _
            '             " FROM vwSclFichaInscripcion a " & _
            '             " WHERE a.nStbDepartamentoID = " & XdtDepto.ValueField("nStbDepartamentoID") & " And a.sNombreGrupo Like '" & sCadenaFiltro & "'" & _
            '             " AND a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & _
            '             " ORDER BY a.sCodigo"
            'End If

            If sCadenaFiltro = "" Then
                Strsql = " SELECT a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSocia, " & _
                         " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSocia, " & _
                         " a.dFechaInscripcion,a.nStbEstadoFichaID,a.nConsecutivoCredito,a.sUsuarioCreacion,a.nStbDelegacionProgramaID,a.DesActividad " & _
                         " FROM vwSclFichaInscripcion a " & _
                         " WHERE a.nSclFichaSociaID = 0 " & _
                         " ORDER BY a.sCodigo"
            Else
                Strsql = " SELECT a.nSclFichaSociaID,a.sEstadoFicha,a.sCodigo,a.sNombre,a.sNumeroCedula,a.sNombreGrupo,a.sTelefonoSocia, " & _
                         " a.sNombreDepartamento,a.sNombreMunicipio,a.sNombreDistrito,a.sNombreBarrio,a.sDireccionSocia, " & _
                         " a.dFechaInscripcion,a.nStbEstadoFichaID,a.nConsecutivoCredito,a.sUsuarioCreacion,a.nStbDelegacionProgramaID,a.DesActividad " & _
                         " FROM vwSclFichaInscripcion a " & sCadenaFiltro & _
                         " ORDER BY a.sCodigo"
            End If

            XdtFicha.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos
            Me.grdFicha.DataSource = XdtFicha.Source
            Me.grdFicha.Rebind(False)

            Me.grdFicha.Caption = " Listado de Fichas de Inscripción (" + Me.grdFicha.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       FormatoFicha
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Comprobante Contable en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoFicha()
        Try
            'Configuracion del Grid Comprobante
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaSociaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbEstadoFichaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nConsecutivoCredito").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdFicha.Splits(0).DisplayColumns("sCodigo").Width = 120
            Me.grdFicha.Splits(0).DisplayColumns("sNombre").Width = 140
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sDireccionSocia").Width = 90
            Me.grdFicha.Splits(0).DisplayColumns("sTelefonoSocia").Width = 50
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDepartamento").Width = 80
            Me.grdFicha.Splits(0).DisplayColumns("sNombreMunicipio").Width = 60
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDistrito").Width = 60
            Me.grdFicha.Splits(0).DisplayColumns("sNombreBarrio").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGrupo").Width = 150
            Me.grdFicha.Splits(0).DisplayColumns("dFechaInscripcion").Width = 70
            Me.grdFicha.Splits(0).DisplayColumns("sEstadoFicha").Width = 110
            Me.grdFicha.Splits(0).DisplayColumns("sUsuarioCreacion").Width = 110

            Me.grdFicha.Columns("sCodigo").Caption = "Código"
            Me.grdFicha.Columns("sNombre").Caption = "Nombre Socia"
            Me.grdFicha.Columns("sNumeroCedula").Caption = "No.Cédula"
            Me.grdFicha.Columns("sDireccionSocia").Caption = "Dirección"
            Me.grdFicha.Columns("sTelefonoSocia").Caption = "Teléfono"
            Me.grdFicha.Columns("sNombreDepartamento").Caption = "Departamento"
            Me.grdFicha.Columns("sNombreMunicipio").Caption = "Municipio"
            Me.grdFicha.Columns("sNombreDistrito").Caption = "Distrito"
            Me.grdFicha.Columns("sNombreBarrio").Caption = "Barrio"
            Me.grdFicha.Columns("sNombreGrupo").Caption = "Grupo Solidario"
            Me.grdFicha.Columns("dFechaInscripcion").Caption = "F.Inscripción"
            Me.grdFicha.Columns("sNombreDistrito").Caption = "Distrito"
            Me.grdFicha.Columns("sEstadoFicha").Caption = "Estado"
            Me.grdFicha.Columns("sUsuarioCreacion").Caption = "Elaborado Por"
            Me.grdFicha.Columns("DesActividad").Caption = "Actividad"

            Me.grdFicha.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaInscripcion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFicha.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sTelefonoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDepartamento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreMunicipio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreDistrito").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreBarrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGrupo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaInscripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sEstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sUsuarioCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFicha.Splits(0).DisplayColumns("DesActividad").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center


        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            XdtFicha = New BOSistema.Win.XDataSet.xDataTable
            XdtDepto = New BOSistema.Win.XDataSet.xDataTable

            Me.Text = "Ficha de Inscripción"

            strSQL = " SELECT nAccesoTotalLectura,nAccesoTotalEdicion " & _
                     " FROM StbDelegacionPrograma " & _
                     " WHERE nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion

            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                nAccesoTotalLectura = XdtDatos.ValueField("nAccesoTotalLectura")
                nAccesoTotalEdicion = XdtDatos.ValueField("nAccesoTotalEdicion")
            End If

            'Limpiar los Grids, estructura y Datos
            Me.grdFicha.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       tbFicha_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbFicha.
    '-------------------------------------------------------------------------
    Private Sub tbFicha_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarFicha()
            Case "toolModificar"
                LlamaModificarFicha()
            Case "toolAnular"
                LlamaAnularFicha()
            Case "toolConfirmar"
                LlamaConfirmar()
            Case "toolRefrescar"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                'InicializaVariables()
                CargarFicha(StrCadena)
                FormatoFicha()
            Case "toolBuscar"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                LlamaBuscarSocia()

                ''InicializaVariables()
                'CargarFicha(StrCadena)
                'FormatoFicha()
            Case "toolBuscarGrupo"
                'Departamento
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                    'ValidaDatosEntrada = False
                    'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                LlamaBuscarGrupo()
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
    ' Fecha:                03/07/2008
    ' Procedure Name:       LlamaBuscarSocia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaSocias para buscar socias con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarSocia()
        Dim ObjFrmSclBusquedaSocias As New frmSclBusquedaSocias
        Try

            ObjFrmSclBusquedaSocias.StrCriterioSocia = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaSocias.IdDepartamento = XdtDepto.ValueField("nStbDepartamentoID")
            ObjFrmSclBusquedaSocias.IdConsultarDelegacion = nAccesoTotalLectura
            ObjFrmSclBusquedaSocias.IdTipoBusqueda = 2 'Busqueda Por Nombre o Cédula Socias.
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
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/07/2008
    ' Procedure Name:       LlamaBuscarSocia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaSocias para buscar socias con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarGrupo()
        Dim ObjFrmSclBusquedaGrupos As New frmSclBusquedaGrupos
        Try

            ObjFrmSclBusquedaGrupos.StrCriterioGrupo = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaGrupos.IdDepartamento = XdtDepto.ValueField("nStbDepartamentoID")
            ObjFrmSclBusquedaGrupos.IdConsultarDelegacion = nAccesoTotalLectura
            ObjFrmSclBusquedaGrupos.IdTipoBusqueda = 2 'Busqueda Por Nombre o Cédula Socias.
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
    '' ------------------------------------------------------------------------
    '' Autor:                Ing. Azucena Suárez Tijerino
    '' Fecha:                12/09/2007
    '' Procedure Name:       tbCaracterInicio_ItemClicked
    '' Descripción:          Este evento permite manejar las opciones del control
    ''                       toolStrip llamado tbSocia.
    ''-------------------------------------------------------------------------
    'Private Sub tbCaracterInicio_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
    '    Try
    '        If Me.cboDepartamento.SelectedIndex = -1 Then
    '            MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
    '            'ValidaDatosEntrada = False
    '            'Me.errFicha.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
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
    '            Case "toolÑ"
    '                StrCadena = "Ñ%"
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAgregarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaInscripcion para Agregar una nueva ficha.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarFicha()
        Dim ObjFrmSclEditFichaInscripcion As New frmSclEditFichaInscripcion
        Try
            ObjFrmSclEditFichaInscripcion.ModoFrm = "ADD"
            ObjFrmSclEditFichaInscripcion.ShowDialog()

            If ObjFrmSclEditFichaInscripcion.intSclFichaID <> 0 Then
                StrCadena = " Where (nSclFichaSociaId = " & ObjFrmSclEditFichaInscripcion.intSclFichaID & ")"
                CargarFicha(StrCadena)
                FormatoFicha()
                XdtFicha.SetCurrentByID("nSclFichaSociaID", ObjFrmSclEditFichaInscripcion.intSclFichaID)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFichaInscripcion.Close()
            ObjFrmSclEditFichaInscripcion = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaConfirmar
    ' Descripción:          Este procedimiento permite realizar el cambio a Pendiente
    '                       Verificación para la Ficha de Inscripción.
    '-------------------------------------------------------------------------
    Private Sub LlamaConfirmar()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer

            If ValidaDatosConfirmacion() Then
                'Actualizar el EstadoFicha a PendienteVerificacion.
                Strsql = " Update SclFichaSocia " & _
                        "  SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoFicha')," & _
                        "      sUsuarioModificacion = '" & InfoSistema.LoginName & "'," & _
                        "      dFechaModificacion = getdate()" & _
                        "  WHERE nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")


                Strsql = "Exec SpAUDITSclFichaSociaCONFIRMARANULAR  'Update','Actualizar  Ficha a Estado Verificada Confirmada'," & XdtFicha.ValueField("nSclFichaSociaID") & ",''," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "',1,1"
                XcDatos.ExecuteNonQuery(Strsql)

                MsgBox("Cambio a Pendiente Verificación realizado Exitosamente.", MsgBoxStyle.Information, "SMUSURA0")

                'Guardar posición actual de la selección
                intPosicion = XdtFicha.ValueField("nSclFichaSociaID")
                CargarFicha(StrCadena)
                FormatoFicha()
                'Ubicar la selección en la posición original
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosConfirmacion
    ' Descripción:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de cambiar a
    '                       Pendiente Verificación a una Ficha de Inscripción.
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
                    MsgBox("No puede Modificar datos de otra Delegación.", MsgBoxStyle.Information)
                    ValidaDatosConfirmacion = False
                    Exit Function
                End If
            End If

            'Valida si la Ficha tiene estado "En Proceso"
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '1' And b.sNombre = 'EstadoFicha' "
            If XcDatos.ExecuteScalar(Strsql) <> XdtFicha.ValueField("nStbEstadoFichaID") Then
                MsgBox("Para cambiarse a Pendiente Verificación," & Chr(10) & _
                       "la Ficha DEBE estar actualmente En Proceso.", MsgBoxStyle.Critical, "SMUSURA0")
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaModificarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaInscripcion para Modificar una ficha existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarFicha()
        Dim ObjFrmSclEditFichaInscripcion As New frmSclEditFichaInscripcion
        Try
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If nAccesoTotalEdicion = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("No puede Modificar datos de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            ObjFrmSclEditFichaInscripcion.ModoFrm = "UPD"
            ObjFrmSclEditFichaInscripcion.intSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            ObjFrmSclEditFichaInscripcion.ShowDialog()

            CargarFicha(StrCadena)
            FormatoFicha()
            XdtFicha.SetCurrentByID("nSclFichaSociaID", ObjFrmSclEditFichaInscripcion.intSclFichaID)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFichaInscripcion.Close()
            ObjFrmSclEditFichaInscripcion = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaAnularFicha
    ' Descripción:          Este procedimiento permite Anular un registro
    '                       de una Ficha existente. No se realiza una Eliminación
    '                       física del registro.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularFicha()
        Dim XdtFichaAnular As New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
        Dim XdrFichaAnular As New BOSistema.Win.SclEntFicha.SclFichaSociaRow
        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Try
            Dim Strsql As String
            Dim intPosicion As Long  'Posicion del registro seleccionado, ID de la Ficha
            Dim strCausaAnulacion As String

            If MsgBox("¿Está seguro de Anular El registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                If ValidaDatosAnular() Then

                    'Solicita al Usuario la Causa de la Anulación
                    XdtFichaAnular.Filter = " nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")
                    XdtFichaAnular.Retrieve()
                    XdrFichaAnular = XdtFichaAnular.Current

                    ObjFrmStbDatoComplemento.strPrompt = "Causa de la Anulación? "
                    ObjFrmStbDatoComplemento.strTitulo = "Anulación de la Ficha"
                    ObjFrmStbDatoComplemento.intAncho = XdrFichaAnular.GetColumnLenght("sMotivoAnulacion")
                    ObjFrmStbDatoComplemento.strDato = ""
                    ObjFrmStbDatoComplemento.strColor = "RojoLight"
                    ObjFrmStbDatoComplemento.strMensaje = "La Causa de Anulación NO DEBE quedar vacía"
                    ObjFrmStbDatoComplemento.ShowDialog()

                    strCausaAnulacion = ObjFrmStbDatoComplemento.strDato

                    'Valida que se ingrese la Causa de la Anulación
                    If strCausaAnulacion = "" Then
                        MsgBox("El registro NO PUEDE ser Anulado.", MsgBoxStyle.Critical, "SMUSURA0")
                        Exit Sub
                    End If

                    'Actualizar el EstadoFicha a Anulado.
                    Strsql = " Update SclFichaSocia " & _
                            "  SET nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '4' And b.sNombre = 'EstadoFicha')," & _
                            "      sMotivoAnulacion = '" & strCausaAnulacion & "'," & _
                            "      sUsuarioModificacion = '" & InfoSistema.LoginName & "'," & _
                            "      dFechaModificacion = getdate()" & _
                            "  WHERE nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")

                    Strsql = "Exec SpAUDITSclFichaSociaCONFIRMARANULAR  'Update','Actualizar  Ficha a Estado Anulada'," & XdtFicha.ValueField("nSclFichaSociaID") & ",'" & strCausaAnulacion & "'," & InfoSistema.IDCuenta & ",'" & InfoSistema.LoginName & "',0,1"

                    XcDatos.ExecuteNonQuery(Strsql)

                    Call GuardarAuditoria(4, 15, "Anulación de Ficha de Inscripción ID: " & XdtFicha.ValueField("nSclFichaSociaID") & ".")

                    MsgBox("El registro seleccionado se ha Anulado " & Chr(10) & _
                            "de forma satisfactoria.", MsgBoxStyle.Information)
                    'Guardar posición actual de la selección
                    intPosicion = XdtFicha.ValueField("nSclFichaSociaID")
                    CargarFicha(StrCadena)
                    FormatoFicha()
                    'Ubicar la selección en la posición original
                    XdtFicha.SetCurrentByID("nSclFichaSociaID", intPosicion)
                    Me.grdFicha.Row = XdtFicha.BindingSource.Position

                End If
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       ValidaDatosAnular
    ' Descripción:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de Anular una
    '                       Ficha.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAnular() As Boolean
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            ValidaDatosAnular = True

            Dim Strsql As String

            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            If nAccesoTotalEdicion = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("No puede Modificar datos de otra Delegación.", MsgBoxStyle.Information)
                    ValidaDatosAnular = False
                    Exit Function
                End If
            End If

            'Se verificar si el Estado de la Ficha es Anulado
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '4' And b.sNombre = 'EstadoFicha' "
            If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
                MsgBox("La Ficha ya tiene Estado Anulada.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Se verificar si el Estado de la Ficha es Aprobada
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '5' And b.sNombre = 'EstadoFicha' "
            If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
                MsgBox("La Ficha NO PUEDE ser Anulada, porque actualmente tiene estado Aprobada.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Se verificar si el Estado de la Ficha es Rechazada
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '6' And b.sNombre = 'EstadoFicha' "
            If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
                MsgBox("La Ficha NO PUEDE ser Anulada, porque actualmente tiene estado Rechazada.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Se verificar si el Estado de la Ficha es Cancelada
            Strsql = " SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '7' And b.sNombre = 'EstadoFicha' "
            If XcDatos.ExecuteScalar(Strsql) = XdtFicha.ValueField("nStbEstadoFichaID") Then
                MsgBox("La Ficha NO PUEDE ser Anulada, porque actualmente tiene estado Cancelada.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
                Exit Function
            End If

            'Validar que si se encuentra en SclFichaNotificacionDetalle, primero deben
            'eliminarla de los datos de Resolución de Crédito
            'Strsql = " SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle " & _
            '         " WHERE nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID")

            'Select Case a.nSclFichaNotificacionDetalleID
            Strsql = " SELECT a.nSclFichaNotificacionDetalleID " & _
                     " FROM SclFichaNotificacionDetalle a " & _
                     " INNER JOIN SclFichaNotificacionCredito b " & _
                     " ON a.nSclFichaNotificacionID = b.nSclFichaNotificacionID " & _
                     " WHERE a.nSclFichaSociaID = " & XdtFicha.ValueField("nSclFichaSociaID") & _
                     " AND b.nStbEstadoCreditoID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (a.sCodigoInterno = '4' Or a.sCodigoInterno = '5') And b.sNombre = 'EstadoCredito')"

            If RegistrosAsociados(Strsql) = True Then
                MsgBox("La Ficha NO PUEDE ser Anulada, " & Chr(10) & _
                        "primero debe eliminarla de los datos de Resolución del Crédito" & Chr(10) & _
                        "en la opción de Ficha de Notificación de Crédito.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAnular = False
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de Ficha de Inscripción.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrar()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
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
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir La Ficha de
    '                       Inscripción.
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

            ObjFrmSclParametroFicha.NomRep = 1
            ObjFrmSclParametroFicha.intSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            ObjFrmSclParametroFicha.IdConsecutivoPrestamo = XdtFicha.ValueField("nConsecutivoCredito")
            'ObjFrmSclParametroFicha.ModoFrm = "IMPRIMIR"
            'ObjFrmSclParametroFicha.strColor = "Verde"
            'ObjFrmSclParametroFicha.strTipoComprobante = Me.strTipoComp
            ObjFrmSclParametroFicha.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       grdFicha_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFicha.Filter
        Try
            XdtFicha.FilterLocal(e.Condition)
            Me.grdFicha.Caption = " Listado de Fichas de Inscripción (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarFichaInscripcion") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Modificar
            If Seg.HasPermission("ModificarFichaInscripcion") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Anular
            If Seg.HasPermission("AnularFichaInscripcion") Then
                Me.toolAnular.Enabled = True
            Else
                Me.toolAnular.Enabled = False
            End If

            'Buscar
            If Seg.HasPermission("BuscarFichaInscripcion") Then
                Me.toolBuscar.Enabled = True
                Me.toolBuscarGrupo.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
                Me.toolBuscarGrupo.Enabled = False
            End If

            'Confirmar
            If Seg.HasPermission("ConfirmarFichaInscripcion") Then
                Me.toolConfirmar.Enabled = True
            Else
                Me.toolConfirmar.Enabled = False
            End If

            'Imprimir 
            If Seg.HasPermission("ImprimirFichaInscripcion") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
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

            If Seg.HasPermission("ModificarFichaInscripcion") Then
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
End Class