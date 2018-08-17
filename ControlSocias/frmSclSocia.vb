' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclSocia.vb
' Descripción:          Este formulario muestra Catálogo de Socias.
'-------------------------------------------------------------------------

Public Class frmSclSocia

    '- Declaración de Variables 
    Dim XdtSocias As BOSistema.Win.XDataSet.xDataTable
    Dim StrCadena As String
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

     ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       frmSclSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Socias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclSocia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI

        Try
            '-- Asignar el tema de Color a utilizarse:
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            StrCadena = "Where (nSclSociaID = 0) " 'Al cargar Grid en Blanco
            CargarSocia(StrCadena)
            FormatoSocia()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       frmSclSocia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan variables
    '                       que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtSocias.Close()
            XdtSocias = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	03/03/2008
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
    ' Fecha:                30/08/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdtSocias = New BOSistema.Win.XDataSet.xDataTable

            'Limpiar los Grids (estructura y Datos).
            Me.grdSocia.ClearFields()
            Me.toolConyuge.Enabled = False
            'Encuentra parámetros de Consulta / Edición Sucursales:
            EncuentraParametros()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       CargarSocia
    ' Descripción:          Procedimiento permite cargar datos de las Socias 
    '                       en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarSocia(ByVal sCadenaFiltro As String)
        Try

            'Asignar Qry al Xdt:
            Dim Strsql As String
            'If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa. '" Where NombreSocia Like '" & sCadenaFiltro & "'" & _
            Strsql = " Select nSociaActiva, nSclSociaID, nCodigo, NombreSocia, sNumeroCedula, dFechaNacimiento, sDireccionSocia, sTelefonoSocia, nNumHijosVivos, " & _
                     " nNumHijosDependientes, CodigoUbicacion, nDispuestaFormarGS, nStbBarrioID, nStbDelegacionProgramaID " & _
                     " From vwSclSocia " & sCadenaFiltro & _
                     " Order by vwSclSocia.nCodigo"
            'Else    'Solo Filtra las Socias de su Delegación:
            'Strsql = " Select * From vwSclSocia " & sCadenaFiltro & _
            '         " and (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")" & _
            '         " Order by vwSclSocia.nCodigo"
            'End If
            XdtSocias.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdSocia.DataSource = XdtSocias.Source

            'Actualizando el caption del GRID:
            Me.grdSocia.Caption = " Listado de Socias (" + Me.grdSocia.RowCount.ToString + " registros)"

            'Buscar:
            If Seg.HasPermission("AgregarSociaConyuge") = False Then
                Me.tbSocia.Items("toolConyuge").Enabled = False
            Else  'Habilita
                If Val(grdSocia.RowCount.ToString) > 0 Then
                    Me.toolConyuge.Enabled = True
                Else
                    Me.toolConyuge.Enabled = False
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       FormatoSocia
    ' Descripción:          Este procedimiento permite configurar los datos 
    '                       sobre Socias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoSocia()
        Try

            'Oculta llave principal en el Grid:
            Me.grdSocia.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdSocia.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            'Establecer ancho de columnas visibles al usuario:
            Me.grdSocia.Splits(0).DisplayColumns("nSociaActiva").Width = 50
            Me.grdSocia.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdSocia.Splits(0).DisplayColumns("NombreSocia").Width = 250
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").Width = 120
            Me.grdSocia.Splits(0).DisplayColumns("dFechaNacimiento").Width = 120
            Me.grdSocia.Splits(0).DisplayColumns("sDireccionSocia").Width = 300
            Me.grdSocia.Splits(0).DisplayColumns("CodigoUbicacion").Width = 100
            Me.grdSocia.Splits(0).DisplayColumns("sTelefonoSocia").Width = 100
            Me.grdSocia.Splits(0).DisplayColumns("nNumHijosVivos").Width = 80
            Me.grdSocia.Splits(0).DisplayColumns("nNumHijosDependientes").Width = 80
            Me.grdSocia.Splits(0).DisplayColumns("nDispuestaFormarGS").Width = 150

            'Ubicar Nombre de los Campos:
            Me.grdSocia.Columns("nCodigo").Caption = "Código"
            Me.grdSocia.Columns("NombreSocia").Caption = "Nombre de Socia"
            Me.grdSocia.Columns("sNumeroCedula").Caption = "Cédula"
            Me.grdSocia.Columns("dFechaNacimiento").Caption = "Fecha Nacimiento"
            Me.grdSocia.Columns("sDireccionSocia").Caption = "Dirección"
            Me.grdSocia.Columns("CodigoUbicacion").Caption = "Código Ubicación"
            Me.grdSocia.Columns("sTelefonoSocia").Caption = "Teléfono"
            Me.grdSocia.Columns("nNumHijosVivos").Caption = "Hijos Vivos"
            Me.grdSocia.Columns("nNumHijosDependientes").Caption = "Dependientes"
            Me.grdSocia.Columns("nDispuestaFormarGS").Caption = "Dispuesta Formar GS"
            Me.grdSocia.Columns("nDispuestaFormarGS").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdSocia.Columns("nSociaActiva").Caption = "Activa"
            Me.grdSocia.Columns("nSociaActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            'Alineación:
            Me.grdSocia.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("dFechaNacimiento").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("CodigoUbicacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nNumHijosVivos").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nNumHijosDependientes").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocia.Splits(0).DisplayColumns("nDispuestaFormarGS").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nSociaActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdSocia.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("NombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("dFechaNacimiento").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("CodigoUbicacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("sTelefonoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nNumHijosVivos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nNumHijosDependientes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nDispuestaFormarGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocia.Splits(0).DisplayColumns("nSociaActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaFichaUnica()
        Dim ObjfrmSclEditFichaUnica As New frmSclEditFichaUnica
        Try
            'Si no hay registros ingresados salir del Sub:
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("Antes debe Buscar la Socia a Modificar.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la socia no se encuentra Activa Advertir:
            If XdtSocias.ValueField("nSociaActiva") = 0 Then
                MsgBox("La socia está inactiva.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtSocias.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Socias de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Indicador de Actualización:
            ObjfrmSclEditFichaUnica.ModoFrm = "UPD"
            'Se indica llave principal:
            'ObjfrmSclEditFichaUnica.IdSocia = XdtSocias.ValueField("nSclSociaID")
            'Se muestra en formulario de edición:
            ObjfrmSclEditFichaUnica.ShowDialog()
            ''Refresca las modificaciones realizadas en el Grid.
            'CargarSocia(StrCadena)
            ''Y se posiciona sobre el registro modificado.
            'XdtSocias.SetCurrentByID("nSclSociaID", ObjfrmSclEditFichaUnica.IdSocia)
            ''Refresca posicionamiento del Grid:
            'Me.grdSocia.Row = XdtSocias.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjfrmSclEditFichaUnica.Close()
            ObjfrmSclEditFichaUnica = Nothing
        End Try
    End Sub

    Private Sub LlamaHistorial()
        Dim ObjfrmSclReptFichaVerificacion As frmSclReptFichaVerificacion

        Try
            'ObjfrmSclReptFichaVerificacion = New frmSclReptFichaVerificacion
            '-- Poner el cursor en un estado de ocupado
            ObjfrmSclReptFichaVerificacion = New frmSclReptFichaVerificacion
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjfrmSclReptFichaVerificacion.ShowDialog()

            'ObjfrmSclReptFichaVerificacion.MdiParent = Me
            'ObjfrmSclReptFichaVerificacion.WindowState = FormWindowState.Maximized
            'OpenForm(ObjfrmSclReptFichaVerificacion, Me)

            ''-- Para enviar el foco al formulario 
            ''-- que se está llamando.
            'ObjfrmSclReptFichaVerificacion.BringToFront()

            '-- Poner el cursor en un estado de desocupado


            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjfrmSclReptFichaVerificacion = Nothing
        End Try
    End Sub

    Private Sub LlamaCónyuge()
        Dim ObjFrm As New frmSclEditSociaConyuge
        Try
            ObjFrm.IdSocia = XdtSocias.ValueField("nSclSociaID")
            ObjFrm.NombreSocia = XdtSocias.ValueField("NombreSocia")
            ObjFrm.ModoFrm = "ADD"
            ObjFrm.ShowDialog()
            'If ObjFrm.StrCriterioSocia <> "0" Then
            '    StrCadena = ObjFrm.StrCriterioSocia
            '    CargarSocia(StrCadena)
            'End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrm.Close()
            ObjFrm = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       tbSocia_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip (tbBanco).
    '-------------------------------------------------------------------------
    Private Sub tbSocia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocia.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolHistorial"
                LlamaHistorial()
            Case "toolBuscar"
                LlamaBuscarSocia()
            Case "toolAgregar"
                LlamaAgregarSocia()
            Case "toolModificar"
                LlamaModificarSocia()
            Case "toolInactivar"
                LlamaInactivarSocia()
            Case "toolCambiarDelegacion"
                LlamaTrasladarDelegacion()
            Case "toolCreditoIndividual"
                LlamaCrearGrupoSolidario()
            Case "toolRefrescar"
                InicializaVariables()
                CargarSocia(StrCadena)
                FormatoSocia()
            Case "toolConyuge"
                LlamaCónyuge()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
            Case "toolfichaunica"
                LlamaFichaUnica()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Socias. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir(ByVal IDReporte As Integer)
        Dim ObjFrmSclParametroFNC As New frmSclParametroFNC
        Try
            Dim strSQL As String = ""
            'If Me.grdSocia.RowCount = 0 Then
            '    MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Listado de Socias :
            'En caso de llamarse desde Menu intSclFormatoID = 0.
            ObjFrmSclParametroFNC.NomRep = IDReporte
            ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
            ObjFrmSclParametroFNC.intSclFormatoID = XdtSocias.ValueField("nSclSociaID")
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
    ' Fecha:                30/08/2007
    ' Procedure Name:       LlamaImprimirDatosSocia
    ' Descripción:          Este procedimiento permite Imprimir Datos Generales
    '                       de la Socia. 
    '-------------------------------------------------------------------------
    'Private Sub LlamaImprimirDatosSocia()
    '    Dim frmVisor As New frmCRVisorReporte
    '    Try
    '        Dim strSQL As String = ""
    '        If Me.grdSocia.RowCount = 0 Then
    '            MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        frmVisor.NombreReporte = "RepSclCS23.rpt"
    '        frmVisor.Text = "Listado de Creditos Aprobados Por Socias "
    '        frmVisor.WindowState = FormWindowState.Maximized
    '        frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
    '        frmVisor.SQLQuery = "Select * From vwSclListadoSociasHistorico Where nSclSociaID=" & Me.grdSocia.Columns("nSclSociaID").Value
    '        frmVisor.Show()
    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        frmVisor = Nothing
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       LlamaAgregarSocia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSocia para Agregar una nueva Socia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarSocia()
        Dim ObjFrmSclEditSocia As New frmSclEditSocia
        Try

            'Indicador de adición:
            ObjFrmSclEditSocia.ModoFrm = "ADD"
            'Mostrar forma para la adición:
            ObjFrmSclEditSocia.ShowDialog()

            If ObjFrmSclEditSocia.IdSocia <> 0 Then 'No se produjo error.
                'Refrescar registros:
                StrCadena = "Where (nSclSociaId = " & ObjFrmSclEditSocia.IdSocia & ")"
                CargarSocia(StrCadena)
                'Se ubica sobre el registro recién ingresado:
                XdtSocias.SetCurrentByID("nSclSociaID", ObjFrmSclEditSocia.IdSocia)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditSocia.Close()
            ObjFrmSclEditSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       LlamaModificarSocia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditSocia para Modificar una Socia existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarSocia()
        Dim ObjFrmSclEditSocia As New frmSclEditSocia
        Try
            'Si no hay registros ingresados salir del Sub:
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("Antes debe Buscar la Socia a Modificar.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la socia no se encuentra Activa Advertir:
            If XdtSocias.ValueField("nSociaActiva") = 0 Then
                MsgBox("La socia está inactiva.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtSocias.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Socias de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Indicador de Actualización:
            ObjFrmSclEditSocia.ModoFrm = "UPD"
            'Se indica llave principal:
            ObjFrmSclEditSocia.IdSocia = XdtSocias.ValueField("nSclSociaID")
            'Se muestra en formulario de edición:
            ObjFrmSclEditSocia.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            CargarSocia(StrCadena)
            'Y se posiciona sobre el registro modificado.
            XdtSocias.SetCurrentByID("nSclSociaID", ObjFrmSclEditSocia.IdSocia)
            'Refresca posicionamiento del Grid:
            Me.grdSocia.Row = XdtSocias.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSclEditSocia.Close()
            ObjFrmSclEditSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                27/07/2009
    ' Procedure Name:       CrearGrupoSolidario
    ' Descripción:          Este procedimiento permite crear de forma automática
    '                       Grupo Solidario con una unica socia como integrante.
    '-------------------------------------------------------------------------
    Private Sub LlamaCrearGrupoSolidario()
        Dim ObjFrmSclEditSociaGS As New frmSclEditSociaCreacionGS
        Try
            Dim StrSql As String
            'Si no hay registros ingresados salir del Sub:
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("Antes debe Buscar la Socia.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la socia no se encuentra Activa Advertir:
            If XdtSocias.ValueField("nSociaActiva") = 0 Then
                MsgBox("La socia está inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtSocias.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Socias de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Verificar si la Socia existe en un Grupo Solidario en Proceso:
            StrSql = " SELECT a.nSclSociaID " & _
                     " FROM  SclGrupoSocia a INNER JOIN SclGrupoSolidario b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID INNER JOIN StbValorCatalogo c ON b.nStbEstadoGrupoID = c.nStbValorCatalogoID  " & _
                     " WHERE (a.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ") AND (c.sCodigoInterno = '1')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La socia forma parte de un Grupo Solidario En Proceso.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Validar si la socia seleccionada se encuentra en una Ficha Activa
            '(<> Rechazada (6), <> Anulada (4) y Cancelada (7)) en este u otro GS:
            StrSql = " SELECT a.nSclGrupoSociaID " & _
                     " FROM  SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID  " & _
                     " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') AND (c.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La socia tiene Fichas registradas aún no Canceladas.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Validar si la Socia forma parte de un grupo donde NO fue Rechazada O ANULADA y donde existe al menos 
            'una Ficha (Activa) (<> Rechazada (6), <> Anulada (4) y Cancelada (7)) en este u otro GS:
            StrSql = " SELECT c.nSclGrupoSolidarioID, SclSocia.sNombre1 + ' ' + SclSocia.sNombre2 + ' ' + SclSocia.sApellido1 + ' ' + SclSocia.sApellido2 AS Socia,  SclSocia.sNumeroCedula " & _
                     " FROM SclFichaSocia AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoFichaID = b.nStbValorCatalogoID INNER JOIN SclGrupoSocia AS c ON a.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN SclSocia ON c.nSclSociaID = SclSocia.nSclSociaID " & _
                     " WHERE (b.sCodigoInterno <> '4') AND (b.sCodigoInterno <> '6') AND (b.sCodigoInterno <> '7') " & _
                     " AND (c.nSclGrupoSolidarioID IN  (SELECT SclGrupoSocia.nSclGrupoSolidarioID FROM  SclGrupoSocia INNER JOIN SclFichaSocia ON SclGrupoSocia.nSclGrupoSociaID = SclFichaSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (SclGrupoSocia.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ") AND (StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '4')))"
            If RegistrosAsociados(StrSql) Then
                MsgBox("La socia forma parte de un Grupo Solidario" & Chr(13) & "en el cual existe(n) Socia(s) con Fichas aún" & Chr(13) & "no Canceladas.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Indicador de Actualización:
            ObjFrmSclEditSociaGS.IdSocia = XdtSocias.ValueField("nSclSociaID")
            ObjFrmSclEditSociaGS.IdBarrio = XdtSocias.ValueField("nStbBarrioID")
            ObjFrmSclEditSociaGS.ShowDialog()

            'Refresca las modificaciones realizadas en el Grid.
            CargarSocia(StrCadena)
            XdtSocias.SetCurrentByID("nSclSociaID", ObjFrmSclEditSociaGS.IdSocia)
            Me.grdSocia.Row = XdtSocias.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSclEditSociaGS.Close()
            ObjFrmSclEditSociaGS = Nothing
        End Try
    End Sub
    'Private Sub LlamaCrearGrupoSolidario()
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Try
    '        Dim Strsql As String
    '        Dim intGrupoID As Integer

    '        'Si no hay registros ingresados salir del Sub:
    '        If Me.grdSocia.RowCount = 0 Then
    '            MsgBox("Antes debe Buscar la Socia.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si la socia no se encuentra Activa Advertir:
    '        If XdtSocias.ValueField("nSociaActiva") = 0 Then
    '            MsgBox("La socia está inactiva.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO tiene permisos de Edición fuera de su Delegación:
    '        If IntPermiteEditar = 0 Then
    '            If InfoSistema.IDDelegacion <> XdtSocias.ValueField("nStbDelegacionProgramaID") Then
    '                MsgBox("Imposible modificar Socias de otra Delegación.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '        End If

    '        'Verifica si ya existe Grupo Solidario individual ACTIVO para la Socia:
    '        Strsql = " SELECT SclGrupoSolidario.nCreditoIndividual " & _
    '                 " FROM SclGrupoSolidario INNER JOIN StbValorCatalogo ON SclGrupoSolidario.nStbEstadoGrupoID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN SclGrupoSocia ON SclGrupoSolidario.nSclGrupoSolidarioID = SclGrupoSocia.nSclGrupoSolidarioID " & _
    '                 " WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SclGrupoSolidario.nCreditoIndividual = 1) AND (SclGrupoSocia.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ")"
    '        If RegistrosAsociados(Strsql) = True Then
    '            MsgBox("Ya existe Grupo Solidario de Crédito Individual" & Chr(13) & "para la socia seleccionada.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Confirmar Acción:
    '        If MsgBox("¿Está seguro de procesar para Crédito Individual?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '        'Ejecuta Procedimiento Almacenado:
    '        Strsql = " EXEC spSclGrabarGrupoCreditoIndividual " & XdtSocias.ValueField("nSclSociaID") & ",0, '" & InfoSistema.LoginName & "', " & InfoSistema.IDDelegacion & ", " & XdtSocias.ValueField("nStbBarrioID")
    '        intGrupoID = XcDatos.ExecuteScalar(Strsql)

    '        If intGrupoID = 0 Then
    '            MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
    '        Else
    '            MsgBox("El Grupo Solidario se generó de forma satisfactoria.", MsgBoxStyle.Information)
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/03/2008
    ' Procedure Name:       LlamaTrasladarDelegacion
    ' Descripción:          Este procedimiento permite trasladar a la Socia de
    '                       Delegación del Programa.
    '-------------------------------------------------------------------------
    Private Sub LlamaTrasladarDelegacion()
        Dim ObjFrmSclTrasladarSocia As New frmSclTrasladosDelegacionSocia
        Dim Strsql As String

        Try
            'Imposible trasladar si no hay ninguna socia registrada:
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("Antes debe Buscar la Socia que" & Chr(13) & "desea Trasladar de Delegación.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la socia no se encuentra Activa salir del Sub:
            If XdtSocias.ValueField("nSociaActiva") = 0 Then
                MsgBox("La socia está inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtSocias.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("La Socia no pertenece a su Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la socia existe en una Ficha de Inscripción Activa 
            '(diferente de Cancelada (7), Rechazada (6) y Anulada (4)):
            Strsql = " SELECT  SclGrupoSocia.nSclSociaID " & _
                     " FROM  SclFichaSocia INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID INNER JOIN StbValorCatalogo ON SclFichaSocia.nStbEstadoFichaID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno <> '4' AND StbValorCatalogo.sCodigoInterno <> '6' AND StbValorCatalogo.sCodigoInterno <> '7') AND (dbo.SclGrupoSocia.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La socia tiene Fichas de Inscripción Activas asociadas.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si la Socia existe en un Grupo Solidario En Proceso:
            'Debido a la Validaci{on en GS que todas las socias del Grupo deben ser de la misma Delegacion.
            Strsql = " SELECT SclGrupoSocia.nSclSociaID " & _
                     " FROM SclGrupoSolidario INNER JOIN StbValorCatalogo ON SclGrupoSolidario.nStbEstadoGrupoID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN SclGrupoSocia ON SclGrupoSolidario.nSclGrupoSolidarioID = SclGrupoSocia.nSclGrupoSolidarioID " & _
                     " WHERE (StbValorCatalogo.sCodigoInterno = '1') AND (SclGrupoSocia.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La socia existe en un Grupo Solidario En Proceso." _
                        & Chr(13) & "Todas las socias de un Grupo deben pertenecer a " _
                        & Chr(13) & "la misma Delegación.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Trasladar Socia:
            ObjFrmSclTrasladarSocia.IdDelegacion = XdtSocias.ValueField("nStbDelegacionProgramaID")
            ObjFrmSclTrasladarSocia.IdSociaD = XdtSocias.ValueField("nSclSociaID")
            ObjFrmSclTrasladarSocia.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            CargarSocia(StrCadena)
            XdtSocias.SetCurrentByID("nSclSociaID", ObjFrmSclTrasladarSocia.IdSociaD)
            Me.grdSocia.Row = XdtSocias.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclTrasladarSocia.Close()
            ObjFrmSclTrasladarSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       LlamaInactivarSocia
    ' Descripción:          Este procedimiento permite inactivar una socia
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivarSocia()
        Dim XdtInactivaSocia As New BOSistema.Win.XDataSet.xDataTable
        Dim Strsql As String

        Try
            Dim intPosicion As Integer  'Posicion del registro seleccionado, ID de la Socia

            'Imposible inactivar si no hay ninguna socia registrada:
            If Me.grdSocia.RowCount = 0 Then
                MsgBox("Antes debe Buscar la Socia a Inactivar.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la socia no se encuentra Activa salir del Sub: 
            If XdtSocias.ValueField("nSociaActiva") = 0 Then
                MsgBox("La socia está inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si no tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtSocias.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Inactivar Socias de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si la socia existe en un GSs activo:
            Strsql = " SELECT a.nSclGrupoSociaID  " & _
                     " FROM SclGrupoSocia AS a INNER JOIN SclGrupoSolidario AS b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID  " & _
                     " INNER Join StbValorCatalogo ON b.nStbEstadoGrupoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     " WHERE (a.nSclSociaID = " & XdtSocias.ValueField("nSclSociaID") & ") AND (StbValorCatalogo.sCodigoInterno <> '2')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La socia forma parte de un grupo solidario activo.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Inactivar Socia:
            If MsgBox("¿Está seguro de Inactivar la socia seleccionada?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'No regresa datos (ExecuteSqlNotTable):

                GuardarAuditoriaTablas(16, 2, "Actualizar Socia Inactivar", XdtSocias.ValueField("nSclSociaID"), InfoSistema.IDCuenta)

                XdtInactivaSocia.ExecuteSqlNotTable("Update SclSocia SET dFechaModificacion = GetDate(), sUsuarioModificacion = '" & InfoSistema.LoginName & "', nSociaActiva = 0 WHERE nSclSociaID = " & XdtSocias.ValueField("nSclSociaID"))

                'Guardar posición actual de la selección
                intPosicion = XdtSocias.ValueField("nSclSociaID")

                'Refrescar Datos:
                CargarSocia(StrCadena)

                'Ubicar la selección en la posición original
                XdtSocias.SetCurrentByID("nSclSociaID", intPosicion)
                Me.grdSocia.Row = XdtSocias.BindingSource.Position

                'Envía mensaje de inactivación:
                MsgBox("El registro se inactivó satisfactoriamente.", MsgBoxStyle.Information)

                'Almacena Pista de Auditoría:
                Call GuardarAuditoria(4, 15, "Inactivación de Socia: " & XdtSocias.ValueField("nCodigo") & ". " & XdtSocias.ValueField("NombreSocia") & " (Cédula: " & XdtSocias.ValueField("sNumeroCedula") & ")")
            End If

        Catch ex As Exception
            Control_Error(ex)
            'MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtInactivaSocia.Close()
            XdtInactivaSocia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Procedimiento permite cerrar la opción de Socias.
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
    ' Fecha:                30/08/2007
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
    ' Fecha:                30/08/2007
    ' Procedure Name:       grdSocia_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Socia existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdSocia.DoubleClick
        Try
            If Seg.HasPermission("ModificarSocia") Then
                LlamaModificarSocia()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdSocia_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSocia.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       grdSocia_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocia_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSocia.Filter
        Try
            XdtSocias.FilterLocal(e.Condition)
            'Se invocá para refrescar el count de registros:
            Me.grdSocia.Caption = " Listado de Socias (" + Me.grdSocia.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                30/08/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar:
            If Seg.HasPermission("BuscarSocia") = False Then
                Me.tbSocia.Items("toolBuscar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolBuscar").Enabled = True
            End If

            'Agregar:
            If Seg.HasPermission("AgregarSocia") = False Then
                Me.tbSocia.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolAgregar").Enabled = True
            End If

            'Editar:
            If Seg.HasPermission("ModificarSocia") = False Then
                Me.tbSocia.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolModificar").Enabled = True
            End If

            'Inactivar:
            If Seg.HasPermission("InactivarSocia") = False Then
                Me.tbSocia.Items("toolInactivar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolInactivar").Enabled = True
            End If

            'Trasladar Socia de Delegacion: 
            If Seg.HasPermission("TrasladarDelegacionSocia") = False Then
                Me.tbSocia.Items("toolCambiarDelegacion").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolCambiarDelegacion").Enabled = True
            End If

            'Crear Grupo Solidario para Crédito Individual:
            If Seg.HasPermission("AgregarGrupoCreditoIndividual") = False Then
                Me.tbSocia.Items("toolCreditoIndividual").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolCreditoIndividual").Enabled = True
            End If

            'Imprimir Listado de Socias:
            If Seg.HasPermission("ImprimirListadoSocias") = False Then
                Me.toolImprimirSocia.Enabled = False
            Else  'Habilita
                Me.toolImprimirSocia.Enabled = True
            End If

            'Imprimir Listado de Socias:
            If Seg.HasPermission("ImprimirDatosSocia") = False Then
                Me.toolImprimirDatosSocia.Enabled = False
            Else  'Habilita
                Me.toolImprimirDatosSocia.Enabled = True
            End If

            If Seg.HasPermission("ImprimirHistorialSocia") Then
                Me.toolHistorial.Enabled = True
            Else
                Me.toolHistorial.Enabled = False
            End If

            'Imprimir Listado de Socias:
            If Seg.HasPermission("MantenimientoFichaUnica") = False Then
                Me.toolfichaunica.Enabled = False
            Else  'Habilita
                Me.toolfichaunica.Enabled = True
            End If







        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub toolImprimirSocia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirSocia.Click
        LlamaImprimir(6)
    End Sub

    Private Sub toolImprimirDatosSocia_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirDatosSocia.Click
        LlamaImprimir(12)
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
            ObjFrmSclBusquedaSocias.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclBusquedaSocias.IdTipoBusqueda = 1 'Busqueda Por Nombre o Cédula Socias.
            ObjFrmSclBusquedaSocias.ShowDialog()
            If ObjFrmSclBusquedaSocias.StrCriterioSocia <> "0" Then
                StrCadena = ObjFrmSclBusquedaSocias.StrCriterioSocia
                CargarSocia(StrCadena)
            End If
            'LlamaRefrescarRecibo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias.Close()
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub

    Private Sub toolModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModificar.Click

    End Sub

End Class