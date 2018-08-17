' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                17/09/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclFichaNotificacionCredito.vb
' Descripción:          Este formulario carga los principales datos de
'                       la Ficha de Notificación de Crédito.
'-------------------------------------------------------------------------
Public Class frmSclFichaNotificacionCredito

    '- Declaración de Variables 
    Dim StrCadena As String

    Dim XdtFicha As BOSistema.Win.XDataSet.xDataTable
    Dim XdsUbicacion As BOSistema.Win.XDataSet
    Dim intFNCID As Long

    'Parámetros:
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    Dim DblTasaInteres As Double
    Dim DblTasaMora As Double
    Dim StrFormaPago As String
    Dim StrTasaInteres As String
    Dim StrTasaMora As String

    Dim StrRepresentante As String
    Dim StrCargoR As String
    Dim StrCedulaR As String
    Dim StrEstadoCivilR As String
    Dim StrProfesionR As String
    Dim StrGeneralesR As String
    Dim StrAbogado As String
    Dim StrGeneralesA As String

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       frmSclFichaNotificacionCredito_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaNotificacionCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdtFicha.Close()
            XdtFicha = Nothing

            XdsUbicacion.Close()
            XdsUbicacion = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       frmSclFichaNotificacionCredito_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Fichas de Notificación en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclFichaNotificacionCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Verde")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            '-- Cargar Fechas de Corte con primer y ultimo dia del Mes en Curso:
            REM Me.cdeFechaD.Value = CDate("01/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            REM Me.cdeFechaH.Value = CDate(Str(IntUltimoDiaMes(Month(FechaServer), Year(FechaServer))) + "/" + Str(Month(FechaServer)) + "/" + Str(Year(FechaServer)))
            'Si tiene permisos para Consulta Amplia de Fichas:
            'If Seg.HasPermission("PermitirConsultaAmpliaFNC") Then
            '    Me.RadTodas.Enabled = True
            'Else
            '    Me.RadTodas.Enabled = False
            'End If

            Me.cboDepartamento.Select()
            InicializaVariables()

            'Cargar Departamentos:
            XdsUbicacion = New BOSistema.Win.XDataSet
            Me.cboDepartamento.ClearFields()
            CargarDepartamento()

            StrCadena = " WHERE (a.nSclFichaNotificacionID = 0) " 'Al cargar Grid en Blanco
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
    ' Fecha:                07/10/2008
    ' Procedure Name:       CargarFicha
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de las Fichas de Notificación en el Grid.
    '-------------------------------------------------------------------------
    Public Sub CargarFicha(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String = ""

            'If Me.radFichasActivas.Checked Then 'Unicamente las Fichas Activas
            '    sCadenaFiltro = sCadenaFiltro + " And (a.sCodEstado <> '5' AND a.sCodEstado <> '4')"
            'End If

            If Me.cboDepartamento.SelectedIndex = -1 Then
                Strsql = " SELECT a.nSclFichaNotificacionID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.nSclGrupoSolidarioID, a.sNombreGS, a.sNumSesion, " & _
                         " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
                         " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio, Usuario " & _
                         " FROM vwSclFichaNotificacionCredito AS a " & _
                         " WHERE (a.nSclFichaNotificacionID = 0)"
            Else
                Strsql = " SELECT a.nSclFichaNotificacionID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.nSclGrupoSolidarioID, a.sNombreGS, a.sNumSesion, " & _
                         " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
                         " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio, Usuario " & _
                         " FROM vwSclFichaNotificacionCredito AS a " & sCadenaFiltro & _
                         " Order by a.nCodigo"
            End If
            XdtFicha.ExecuteSql(Strsql)
            'Asignando fuente de datos al Grid:
            Me.grdFicha.DataSource = XdtFicha.Source
            Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito (" + Me.grdFicha.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    '' ------------------------------------------------------------------------
    '' Autor:                Yesenia Gutiérrez
    '' Fecha:                17/09/2007
    '' Procedure Name:       CargarFicha
    '' Descripción:          Este procedimiento permite cargar los datos
    ''                       de las Fichas de Notificación en el Grid.
    ''-------------------------------------------------------------------------
    'Public Sub CargarFicha()
    '    Try
    '        Dim Strsql As String = ""

    '        If Me.cboDepartamento.SelectedIndex = -1 Then
    '            Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
    '                     " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
    '                     " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio " & _
    '                     " FROM vwSclFichaNotificacionCredito AS a " & _
    '                     " WHERE (a.nSclFichaNotificacionID = 0)"
    '        Else
    '            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
    '                If Me.RadTodas.Checked Then 'TODAS las Fichas:
    '                    Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
    '                             " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
    '                             " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio " & _
    '                             " FROM vwSclFichaNotificacionCredito AS a " & _
    '                             " WHERE (a.nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") and (a.dFechaR BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
    '                             " Order by a.nCodigo"
    '                Else 'Fichas Activas (Diferentes de Anuladas y Anuladas con Regeneración)
    '                    Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
    '                             " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado,  IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
    '                             " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio " & _
    '                             " FROM vwSclFichaNotificacionCredito AS a " & _
    '                             " WHERE (a.sCodEstado <> '5' AND a.sCodEstado <> '4') and (a.nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") and (a.dFechaR BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
    '                             " Order by a.nCodigo"
    '                End If

    '            Else 'Solo Filtra las Fichas de su Delegación: 
    '                If Me.RadTodas.Checked Then 'TODAS las Fichas:
    '                    Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
    '                             " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado, IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
    '                             " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio " & _
    '                             " FROM vwSclFichaNotificacionCredito AS a " & _
    '                             " WHERE (a.nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") and (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (a.dFechaR BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
    '                             " Order by a.nCodigo"
    '                Else 'Fichas Activas (Diferentes de Anuladas y Anuladas con Regeneración)
    '                    Strsql = " SELECT a.nSclFichaNotificacionID, a.nSclGrupoSolidarioID, a.nCodigo, a.EstadoFicha, a.CodigoGS, a.sNombreGS, a.sNumSesion, " & _
    '                             " a.dFechaFirmaActaCompromiso, a.dFechaNotificacion, a.dFechaHoraEntregaCK, a.sCodEstado, IsNull(a.EstadoSDC,'NO Generada') as EstadoSDC, " & _
    '                             " a.NombreCoordinadora, a.TelefonoCoordinadora, a.nSclFNCOrigenID, a.sUsuarioCreacion, a.dFechaR, a.nStbDelegacionProgramaID, a.CodEnvio, a.EstadoEnvio " & _
    '                             " FROM vwSclFichaNotificacionCredito AS a " & _
    '                             " WHERE (a.sCodEstado <> '5' AND a.sCodEstado <> '4') and (a.nStbDepartamentoId = " & cboDepartamento.Columns("nStbDepartamentoId").Value & ") and (a.nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") and (a.dFechaR BETWEEN CONVERT(DATETIME, '" & Format(CDate(cdeFechaD.Text), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(CDate(cdeFechaH.Text), "yyyy-MM-dd") & "', 102)) " & _
    '                             " Order by a.nCodigo"
    '                End If
    '            End If
    '        End If

    '        XdtFicha.ExecuteSql(Strsql)

    '        'Asignando fuente de datos al Grid:
    '        Me.grdFicha.DataSource = XdtFicha.Source
    '        Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito (" + Me.grdFicha.RowCount.ToString + " registros)"

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       FormatoFicha
    ' Descripción:          Este procedimiento permite configurar los datos
    '                       sobre la FNC en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoFicha()
        Try

            'Configuracion del Grid FNC
            Me.grdFicha.Splits(0).DisplayColumns("nSclFichaNotificacionID").Visible = False
            'Me.grdFicha.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("sCodEstado").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("dFechaFirmaActaCompromiso").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nSclFNCOrigenID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("dFechaR").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdFicha.Splits(0).DisplayColumns("CodEnvio").Visible = False

            Me.grdFicha.Splits(0).DisplayColumns("nCodigo").Width = 50
            Me.grdFicha.Splits(0).DisplayColumns("EstadoFicha").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("CodigoGS").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Width = 60
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGS").Width = 200
            Me.grdFicha.Splits(0).DisplayColumns("sNumSesion").Width = 80
            Me.grdFicha.Splits(0).DisplayColumns("dFechaNotificacion").Width = 130
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraEntregaCK").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("sUsuarioCreacion").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("NombreCoordinadora").Width = 200
            Me.grdFicha.Splits(0).DisplayColumns("TelefonoCoordinadora").Width = 100
            Me.grdFicha.Splits(0).DisplayColumns("EstadoSDC").Width = 150
            Me.grdFicha.Splits(0).DisplayColumns("EstadoEnvio").Width = 120
            Me.grdFicha.Splits(0).DisplayColumns("Usuario").Width = 200

            Me.grdFicha.Columns("nCodigo").Caption = "Código"
            Me.grdFicha.Columns("CodigoGS").Caption = "Código Grupo"
            Me.grdFicha.Columns("nSclGrupoSolidarioID").Caption = "Grupo"
            Me.grdFicha.Columns("sNombreGS").Caption = "Nombre Grupo Solidario"
            Me.grdFicha.Columns("sNumSesion").Caption = "No. Sesión"
            Me.grdFicha.Columns("dFechaNotificacion").Caption = "Fecha Resolución"
            Me.grdFicha.Columns("dFechaHoraEntregaCK").Caption = "Fecha Entrega CK"
            Me.grdFicha.Columns("EstadoFicha").Caption = "Estado Crédito"
            Me.grdFicha.Columns("sUsuarioCreacion").Caption = "Elaborado Por"
            Me.grdFicha.Columns("NombreCoordinadora").Caption = "Coordinadora"
            Me.grdFicha.Columns("TelefonoCoordinadora").Caption = "Teléfono"
            Me.grdFicha.Columns("EstadoSDC").Caption = "Estado Solicitud Desembolso"
            Me.grdFicha.Columns("EstadoEnvio").Caption = "Envio a CARUNA"
            Me.grdFicha.Columns("Usuario").Caption = "Aprobado por"

            Me.grdFicha.Splits(0).DisplayColumns("CodigoGS").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("nSclGrupoSolidarioID").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdFicha.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Justify
            Me.grdFicha.Splits(0).DisplayColumns("dFechaNotificacion").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraEntregaCK").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdFicha.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("CodigoGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("nSclGrupoSolidarioID").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNombreGS").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sNumSesion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaNotificacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("dFechaHoraEntregaCK").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("EstadoFicha").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("sUsuarioCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("NombreCoordinadora").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("TelefonoCoordinadora").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("EstadoSDC").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("EstadoEnvio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdFicha.Splits(0).DisplayColumns("Usuario").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Formato de Fecha/Hora para la Resolución del Crédito:
            Me.grdFicha.Columns("dFechaNotificacion").NumberFormat = "dd/MM/yyyy hh:mm tt"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdtFicha = New BOSistema.Win.XDataSet.xDataTable
            Me.Text = "Ficha de Notificación de Crédito"
            'Limpiar los Grids, estructura y Datos
            Me.grdFicha.ClearFields()

            'Encuentra parámetros de Consulta / Edición Sucursales:
            EncuentraParametrosD()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaModificarMeta()
        Dim Obj As New frmSccMetaCumplidaSocia
        Try
            Dim StrSql As String
            'Si no existen FNC registradas:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM
            'Si NO tiene permisos de edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si FNC esta APROBADA:
            If XdtFicha.ValueField("sCodEstado") = 2 Then
                'No Modificar Si No existen Fichas de Inscripción Aprobadas:
                StrSql = "SELECT DFNC.nSclFichaNotificacionID " & _
                         "FROM SclFichaNotificacionDetalle as DFNC INNER JOIN SclFichaSocia FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN StbValorCatalogo as C ON FS.nStbEstadoFichaID = C.nStbValorCatalogoID " & _
                         "WHERE (C.sCodigoInterno = '7') AND (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("Aprobación de meta, solo se permite a un crédito cancelado.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else
                MsgBox("Ficha no se encuentra en estado aprobado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            REM

            ''Valida si la Ficha no tiene el estado "En Proceso":
            'If XdtFicha.ValueField("sCodEstado") <> 1 Then
            '    If XdtFicha.ValueField("sCodEstado") = 2 Then
            '        MsgBox("La Ficha no se encuentra En Proceso." & Chr(13) & "No podrá modificar todos los datos de la Notificación.", MsgBoxStyle.Information, NombreSistema)
            '    Else
            '        MsgBox("La Ficha no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
            '    End If
            '    'Exit Sub
            'End If

            Obj.intSclFichaID = XdtFicha.ValueField("nSclFichaNotificacionID")
            Obj.ShowDialog()
            CargarFicha(StrCadena)
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", Obj.intSclFichaID)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Obj.Close()
            'Obj = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       tbFicha_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbFicha.
    '-------------------------------------------------------------------------
    Private Sub tbFicha_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbFicha.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolMetaCumplida"
                LlamaModificarMeta()

            Case "toolBuscar"
                LlamaBuscarFicha()
            Case "toolAgregar"
                LlamaAgregarFicha()
            Case "toolModificar"
                LlamaModificarFicha()
            Case "toolRechazar"
                LlamaAprobarRechazarFNC(0)
            Case "toolAprobar"
                LlamaAprobarRechazarFNC(1)
            Case "toolAnular"
                LlamaAnular()
            Case "toolAnularR"
                LlamaAnularR()
            Case "toolGenerarSD"
                LlamaGenerarSD()
            Case "toolModificarSD"
                LlamaModificarSD()
            Case "toolVerificarSD"
                LlamaVerificarSD()
            Case "toolRefrescar"
                'Debe indicar un Departamento:
                If Me.cboDepartamento.SelectedIndex = -1 Then
                    MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, NombreSistema)
                    Me.cboDepartamento.Focus()
                    Exit Sub
                End If

                ''Fechas de Corte Validas:
                'If (Trim(RTrim(Me.cdeFechaD.Text)).ToString.Length <> 10) Or (Trim(RTrim(Me.cdeFechaH.Text)).ToString.Length <> 10) Then
                '    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                '    Exit Sub
                'End If
                'If (Not IsDate(cdeFechaD.Text)) Or (Not IsDate(cdeFechaH.Text)) Then
                '    MsgBox("Debe indicar fechas de corte Válidas.", MsgBoxStyle.Information)
                '    Exit Sub
                'End If
                ''Fecha de Corte no mayor a la de Inicio:
                'If CDate(cdeFechaD.Text) > CDate(cdeFechaH.Text) Then
                '    MsgBox("Fecha de Inicio no debe ser mayor que la Fecha de Corte.", MsgBoxStyle.Information)
                '    Me.cdeFechaD.Focus()
                '    Exit Sub
                'End If
                ''Si tiene permisos para consulta amplia de Fichas de Notificación (6 meses):
                'If Seg.HasPermission("PermitirConsultaAmpliaFNC") Then
                '    REM REM REM
                '    If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 5 Then
                '        MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a seis meses.", MsgBoxStyle.Information)
                '        Me.cdeFechaD.Focus()
                '        Exit Sub
                '    End If
                '    'Máximo 3 meses entre la fecha de inicio y corte:
                'Else
                '    If DateDiff(DateInterval.Month, CDate(cdeFechaD.Text), CDate(cdeFechaH.Text)) > 2 Then
                '        MsgBox("Imposible seleccionar cortes de fecha" & Chr(13) & "superiores a tres meses.", MsgBoxStyle.Information)
                '        Me.cdeFechaD.Focus()
                '        Exit Sub
                '    End If                
                'End If

                InicializaVariables()
                CargarFicha(StrCadena)
                FormatoFicha()

            Case "toolCerrar"
                LlamaCerrar()
                'Case "toolEnviarCARUNA"
                '    LlamaEnviarCARUNA()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                08/10/2008
    ' Procedure Name:       LlamaBuscarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclBusquedaFichas para buscar FNCs con
    '                       criterios indicados por el usuario.
    '-------------------------------------------------------------------------
    Private Sub LlamaBuscarFicha()
        Dim ObjFrmSclBusquedaFichas As New frmSclBusquedaFichas
        Try

            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento.", MsgBoxStyle.Information)
                cboDepartamento.Focus()
                Exit Sub
            End If

            ObjFrmSclBusquedaFichas.StrCriterioFicha = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaFichas.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclBusquedaFichas.IdDepartamento = cboDepartamento.Columns("nStbDepartamentoId").Value
            ObjFrmSclBusquedaFichas.ShowDialog()
            If ObjFrmSclBusquedaFichas.StrCriterioFicha <> "0" Then
                StrCadena = ObjFrmSclBusquedaFichas.StrCriterioFicha
                CargarFicha(StrCadena)
            End If
            'LlamaRefrescarRecibo()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaFichas.Close()
            ObjFrmSclBusquedaFichas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       LlamaModificarSD
    ' Descripción:          Este procedimiento permite Modificar las Solicitudes
    '                       de Desembolso de Crédito si aún no se encuentran
    '                       Verificadas.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarSD()
        Dim ObjFrmSccEditSD As New frmSclSolicitudDesembolso
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            'Si no existen FNC registradas:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si NO se han Generado las Solicitudes:
            strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("Las Solicitudes de Desembolso aún no han sido generadas" & Chr(13) & "para esta Ficha de Notificación.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si estas ya se Verificaron:
            strSQL = " Select * From SccSolicitudDesembolsoCredito " & _
                   " Where (nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoDesembolsoCredito' " & _
                   " )) And (nSclFichaNotificacionDetalleID IN (SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")))"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Las Solicitudes de Desembolso ya han sido Verificadas" & Chr(13) & "para esta Ficha de Notificación.", MsgBoxStyle.Information, NombreSistema)
                'Exit Sub
            End If

            'Encuentra al menos una de las Solicitude de Desembolso Generadas:
            strSQL = "SELECT MAX(a.nSccSolicitudDesembolsoCreditoID) AS SDId FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE  (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            ObjFrmSccEditSD.ModoFrm = "UPD"
            ObjFrmSccEditSD.intSclFichaID = XdtFicha.ValueField("nSclFichaNotificacionID")
            ObjFrmSccEditSD.intSccSolicitudID = XcDatos.ExecuteScalar(strSQL)
            ObjFrmSccEditSD.dSccFechaCK = XdtFicha.ValueField("dFechaHoraEntregaCK")
            ObjFrmSccEditSD.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccEditSD.Close()
            ObjFrmSccEditSD = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       LlamaVerificarSD
    ' Descripción:          Este procedimiento permite Verificar las Solicitudes
    '                       de Desembolso de Crédito impidiendo con ello su
    '                       posterior modificación y la generación de la 
    '                       Solicitud de Pago.
    '-------------------------------------------------------------------------
    Private Sub LlamaVerificarSD()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer
            Dim nFichaOrigenID As Integer

            'Si no existen FNC registradas:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si el estado de la FNC no es APROBADA:
            If (XdtFicha.ValueField("sCodEstado") <> 2) Then
                MsgBox("El crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si NO se han Generado las Solicitudes de Desembolso de Crédito:
            Strsql = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("Las Solicitudes de Desembolso aún no han sido generadas" & Chr(13) & "para esta Ficha de Notificación.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si Solicitudes de Desembolso de Crédito ya se Verificaron:
            Strsql = " Select * From SccSolicitudDesembolsoCredito " & _
                   " Where (nStbEstadoSolicitudID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoDesembolsoCredito' " & _
                   " )) And (nSclFichaNotificacionDetalleID IN (SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")))"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Las Solicitudes de Desembolso ya han sido Verificadas" & Chr(13) & "para esta Ficha de Notificación.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar VERIFICACION: 
            If MsgBox("¿Desea VERIFICAR las Solicitudes de Desembolso?" & Chr(13) & Chr(13) & Chr(13) & _
                      "Con ello se generarán en forma automática las correspondientes" & Chr(13) & _
                      "Solicitudes de Cheques para cada una de las socias con el Crédito" & Chr(13) & _
                      "Aprobado en la Ficha de Notificación.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '****************************************** I ***************************************
            '1. Verifica Solicitudes de Desembolso.
            '-- Si la FNC no se basa en una FNC Anulada con Regeneración o la FF cambio: 
            '2. Unicamente Generar Encabezados de Solicitudes de Cheque (En Proceso).
            '****************************************** II **************************************
            '-- Si Ficha es Producto de una Regeneración: Por cada Solicitud de Desembolso de la Ficha:
            '** Si la Solicitud de Cheque Origen NO tiene CK Anulado:
            '3. Unicamente genera Encabezado de Solicitud de Ck En Proceso.
            '** Si la Solicitud de Cheque Origen TIENE CK Anulado:
            '** CON LA FF DEL CK realiza las siguientes accciones (Con la fuente del CK pues pueden haber pagos parciales entre fuentes x socias):
            '4. Genera Sol. Ck Autorizada con CK Emitido .
            '5. Genera los Detalles de las Solicitudes de Cheque conforme SCK Originales y el Monto Aprobado en la FNC.
            '6. Genera los Cheques con el mismo No. de la Ficha Origen.
            '7. Mayoriza los Cheques en Saldos.

            'Si la Ficha no se basa en otra Anulada con Regeneracion o si la nueva Ficha
            'corresponde a otra Fuente de Financiamiento: nFichaOrigenID = 0, lo que implica
            'unicamente generar los encabezados de las Solicitudes de Cheque En Proceso.
            If IsNumeric(XdtFicha.ValueField("nSclFNCOrigenID")) Then
                'Si cambio la Fuente de Financiamiento:
                Strsql = "SELECT COUNT(DISTINCT SDC.nScnFuenteFinanciamientoID) AS TotalFuentes " & _
                         "FROM  SccSolicitudDesembolsoCredito AS SDC INNER JOIN SclFichaNotificacionDetalle AS DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " & _
                         "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") OR (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFNCOrigenID") & ")"
                If XcDatos.ExecuteScalar(Strsql) > 1 Then 'HUBO un Cambio de la F.F.
                    'Si Existen Cheques creados con la Ficha Origen:
                    Strsql = "SELECT E.nScnTransaccionContableID " & _
                             "FROM  ScnTransaccionContable E INNER JOIN SccSolicitudCheque SCK ON E.nSccSolicitudChequeID = SCK.nSccSolicitudChequeID INNER JOIN SccSolicitudDesembolsoCredito SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN SclFichaNotificacionDetalle DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " & _
                             "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFNCOrigenID") & ") GROUP BY E.nScnTransaccionContableID"
                    '-- Advertir que estos Cheques NO se regenerarán.
                    If RegistrosAsociados(Strsql) Then
                        If MsgBox("Ud. cambió la Fuente de Financiamiento con respecto a la Ficha " & Chr(13) & _
                                  "de Notificación de Crédito original por lo que únicamente se " & Chr(13) & _
                                  "regenerarán las Solicitudes de Cheque y NO se generarán " & Chr(13) & _
                                  "nuevamente los Comprobantes de Pago en Contabilidad. " & Chr(13) & Chr(13) & _
                                  "¿Aún así Desea VERIFICAR las Solicitudes de Desembolso?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                            Exit Sub
                        End If
                    End If
                    nFichaOrigenID = 0
                Else 'NO hubo cambiod de F.F.
                    nFichaOrigenID = XdtFicha.ValueField("nSclFNCOrigenID")
                End If
            Else '-- La Ficha NO es producto de una Ficha Anulada con Regeneración.
                nFichaOrigenID = 0
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor

            'Ejecuta Procedimiento Almacenado:
            '**OJO
            Strsql = " EXEC spSccVerificarSolicitudDesembolso " & XdtFicha.ValueField("nSclFichaNotificacionID") & ", '" & InfoSistema.LoginName & "', " & InfoSistema.IDCuenta & "," & nFichaOrigenID
            Me.intFNCID = XcDatos.ExecuteScalar(Strsql)

            'Guardar posición actual de la selección:
            intPosicion = Me.intFNCID
            CargarFicha(StrCadena)
            'Ubicar la selección en la posición original:
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

            If Me.intFNCID = 0 Then
                MsgBox("Las Solicitudes no pudieron Verificarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                Call GuardarAuditoria(5, 15, "Verificación de Solicitudes Desembolso Ficha Notificación No.: " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ").")
                MsgBox("Solicitudes VERIFICADAS Exitosamente." & Chr(13) & "Se generaron Solicitudes de Cheque.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing
        End Try

    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/10/2007
    ' Procedure Name:       LlamaGenerarSD
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclSolicitudDesembolso para Generar las
    '                       correspondientes solicitudes para todas las socias
    '                       de la Ficha de Notificación con Crédito Aprobado.
    '-------------------------------------------------------------------------
    Private Sub LlamaGenerarSD()
        Dim ObjFrmSclSD As New frmSclSolicitudDesembolso
        Try
            Dim strSQL As String
            'Si no existen FNC registradas:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible si el estado de la FNC no es APROBADA: 
            If (XdtFicha.ValueField("sCodEstado") <> 2) Then
                MsgBox("El crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si ya se han Generado las Solicitudes: 
            strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Las Solicitudes de Desembolso ya han sido generadas" & Chr(13) & "para esta Ficha de Notificación.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            ObjFrmSclSD.ModoFrm = "ADD"
            ObjFrmSclSD.intSclFichaID = XdtFicha.ValueField("nSclFichaNotificacionID")
            ObjFrmSclSD.dSccFechaCK = XdtFicha.ValueField("dFechaHoraEntregaCK")
            ObjFrmSclSD.ShowDialog()

            'Si se ingreso una nueva SD:
            If ObjFrmSclSD.intSclFichaID <> 0 Then
                CargarFicha(StrCadena)
                XdtFicha.SetCurrentByID("nSclFichaNotificacionID", ObjFrmSclSD.intSclFichaID)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclSD.Close()
            ObjFrmSclSD = Nothing
        End Try
    End Sub


    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       LlamaAgregarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaNotificacion para Agregar una nueva ficha.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarFicha()
        Dim ObjFrmSclEditFNC As New frmSclEditFichaNotificacion
        Try
            ObjFrmSclEditFNC.ModoFrm = "ADD"
            ObjFrmSclEditFNC.intSclPermiteEditarFNC = IntPermiteEditar
            ObjFrmSclEditFNC.ShowDialog()

            'Si se ingreso una nueva FNC:
            If ObjFrmSclEditFNC.intSclFichaID <> 0 Then
                StrCadena = "Where (a.nSclFichaNotificacionID = " & ObjFrmSclEditFNC.intSclFichaID & ")"
                CargarFicha(StrCadena)
                XdtFicha.SetCurrentByID("nSclFichaNotificacionID", ObjFrmSclEditFNC.intSclFichaID)
                Me.grdFicha.Row = XdtFicha.BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFNC.Close()
            ObjFrmSclEditFNC = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/10/2007
    ' Procedure Name:       LlamaAnularR
    ' Descripción:          Este procedimiento permite Anular una FNC APROBADA
    '                       permitiendo la regeneración de una Ficha En Proceso
    '                       basada en la Ficha Origen.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularR()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable

        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer
            Dim intPlazoPeriodoGracia As Integer

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

            'Valida si la Ficha no tiene el estado "APROBADA":
            If XdtFicha.ValueField("sCodEstado") <> 2 Then
                MsgBox("La Ficha no se encuentra APROBADA.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible Anular FNC si existen Recibos Oficiales generados y ACTIVOS.
            '(Es posible Anular aunque existan Solicitudes de Cheque o Cheques asociados ya 
            'que estos igualmente se anularán de forma automática con la Anulación de la FNC).
            'Strsql = "SELECT Recibo.nSccReciboOficialCajaID " & _
            '         "FROM SclFichaNotificacionDetalle DFNC INNER JOIN SccSolicitudDesembolsoCredito SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN  SccSolicitudCheque SCK ON SDC.nSccSolicitudDesembolsoCreditoID = SCK.nSccSolicitudDesembolsoCreditoID INNER JOIN SccReciboOficialCaja RECIBO ON SCK.nSccSolicitudChequeID = Recibo.nSccSolicitudChequeID " & _
            '         "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            Strsql = "SELECT Recibo.nSccReciboOficialCajaID " &
                     "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN SccSolicitudCheque AS SCK ON SDC.nSccSolicitudDesembolsoCreditoID = SCK.nSccSolicitudDesembolsoCreditoID INNER JOIN SccReciboOficialCaja AS RECIBO ON SCK.nSccSolicitudChequeID = RECIBO.nSccSolicitudChequeID INNER JOIN StbValorCatalogo ON RECIBO.nStbEstadoReciboID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Imposible Anular Ficha de Notificación de Crédito. Existen Recibos Oficiales ACTIVOS.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible generar si existen Cheques generados y el mes contable esta Cerrado. 
            Strsql = "SELECT E.dFechaTransaccion " &
                     "FROM ScnTransaccionContable E INNER JOIN SccSolicitudCheque SCK ON E.nSccSolicitudChequeID = SCK.nSccSolicitudChequeID INNER JOIN SccSolicitudDesembolsoCredito SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN SclFichaNotificacionDetalle DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                If PeriodoAbiertoDadaFecha(XcDatos.ExecuteScalar(Strsql)) = False Then
                    MsgBox("Imposible Anular Ficha de Notificación de Crédito. Existen Cheques generados de un mes Contable Cerrado.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Confirmar Anulación:
            Strsql = "¿Desea ANULAR la Ficha de Notificación?" & Chr(13) & "Se generará una Nueva Ficha de Notificación con el Estado En Proceso."
            If MsgBox(Strsql, MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor

            'Cargar XdtFichaTmp:
            Strsql = " Select * " &
                     " From SclFichaNotificacionCredito " &
                     " Where nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtFichaTmp.ExecuteSql(Strsql)

            'Plazo del Periodo de Gracia:
            If XdtFichaTmp.ValueField("nStbTipoPlazoPeriodoGraciaID").ToString.Length = 0 Then
                intPlazoPeriodoGracia = -1
            Else
                intPlazoPeriodoGracia = XdtFichaTmp.ValueField("nStbTipoPlazoPeriodoGraciaID")
            End If

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS UPDATE DE AUDITORIA 

            Dim XdtConsulta As BOSistema.Win.XDataSet.xDataTable
            Dim XdtDDE As BOSistema.Win.XDataSet.xDataTable
            Dim StrQuery As String
            XdtConsulta = New BOSistema.Win.XDataSet.xDataTable
            XdtDDE = New BOSistema.Win.XDataSet.xDataTable

            Dim IdnSclFichaNotificacionDetalle As Integer
            Dim IdnSccSolicitudDesembolsoCredito As Integer
            Dim IdnSccSolicitudCheque As Integer
            Dim IdnScnTransaccionContableID As Integer

            ' Esto es para SclFichaNotificacionDetalle
            StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
                GuardarAuditoriaTablas(5, 2, "Modificar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)
            End If

            ' UPDATE SclFichaSocia
            Dim IdnSclFichaSocia As Integer
            StrQuery = "SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaSocia = XdtConsulta.ValueField("nSclFichaSociaID")
                GuardarAuditoriaTablas(7, 2, "Modificar SclFichaSocia", IdnSclFichaSocia, InfoSistema.IDCuenta)
            End If

            ' UPDATE SccSolicitudDesembolsoCredito
            ' halar el último registro de SclFichaNotificacionDetalle y mandar a actualizar a SccSolicitudDesembolsoCredito
            StrQuery = "SELECT nSccSolicitudDesembolsoCreditoID FROM SccSolicitudDesembolsoCredito WHERE nSclFichaNotificacionDetalleID = " & IdnSclFichaNotificacionDetalle
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSccSolicitudDesembolsoCredito = XdtConsulta.ValueField("nSccSolicitudDesembolsoCreditoID")
                GuardarAuditoriaTablas(3, 2, "Modificar SccSolicitudDesembolsoCredito", IdnSccSolicitudDesembolsoCredito, InfoSistema.IDCuenta)
            End If

            ' UPDATE SclGrupoSolidario
            Dim IdnSclGrupoSolidario As Integer
            StrQuery = "SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclGrupoSolidario = XdtConsulta.ValueField("nSclGrupoSolidarioID")
                GuardarAuditoriaTablas(9, 2, "Modificar SclGrupoSolidario", IdnSclGrupoSolidario, InfoSistema.IDCuenta)
            End If

            ' UPDATE SccSolicitudCheque
            ' halar el último registro de SccSolicitudDesembolsoCredito para el SclFichaNotificacionDetalle y mandar a actualizar a SccSolicitudCheque
            StrQuery = "SELECT nSccSolicitudChequeID FROM SccSolicitudCheque WHERE nSccSolicitudDesembolsoCreditoID = " & IdnSccSolicitudDesembolsoCredito
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSccSolicitudCheque = XdtConsulta.ValueField("nSccSolicitudChequeID")
                GuardarAuditoriaTablas(1, 2, "Modificar SccSolicitudCheque", IdnSccSolicitudCheque, InfoSistema.IDCuenta)
            End If

            ' UPDATE ScnTransaccionContable
            ' halar el último registro de SccSolicitudCheque para la SccSolicitudDesembolsoCredito del SclFichaNotificacionDetalle y mandar a actualizar a ScnTransaccionContable
            StrQuery = "SELECT nScnTransaccionContableID FROM ScnTransaccionContable WHERE nSccSolicitudChequeID = " & IdnSccSolicitudCheque
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnScnTransaccionContableID = XdtConsulta.ValueField("nScnTransaccionContableID")
                GuardarAuditoriaTablas(24, 2, "Modificar ScnTransaccionContable ", IdnScnTransaccionContableID, InfoSistema.IDCuenta)
            End If

            ' UPDATE SclFichaNotificacionCredito
            GuardarAuditoriaTablas(4, 2, "Modificar FNC", XdtFicha.ValueField("nSclFichaNotificacionID"), InfoSistema.IDCuenta)

            ' ------------------------------------------------------------------------------------------

            '****************************************** I ***************************************
            '1. Anula FNC Actual.
            '2. Anula Solicitudes de Desembolso asociadas a la FNC Actual.
            '3. Crea una FNC En Proceso con Base en los Datos de la FNC Actual:                
            '4. Genera Detalles de la FNC con base en FNC Original 
            '   CON TODAS LAS SOCIAS CON EL CREDITO APROBADO:
            '5. Genera detalles de expediente con base en FNC Original:                
            '6. Regresa TODAS las Fichas Aprobadas/Rechazadas de la Ficha Origen al Estado Verificadas.
            '7. Revertir en SclGrupoSocia estado crédito Denegado desde la FNC Origen.
            '8. Disminuir en uno el campo nConsecutivoCredito del Grupo Solidario.
            '-- ****************************************************
            '9: Anula Solicitudes de Cheques (SI EXISTEN).
            '10: Anula Comprobantes de Cheques MAYORIZADOS (SI EXISTEN).
            '11: Revierte Mayorización de los Comprobantes de Cheque encontrados.
            'Ejecuta Procedimiento Almacenado:

            If IsDate(XdtFichaTmp.ValueField("dFechaPrimerCuota")) Then
                Strsql = " EXEC spSclGrabarFNC " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & "," & XdtFichaTmp.ValueField("nSclGrupoSolidarioID") & ",'" _
                        & XdtFichaTmp.ValueField("sNumSesion") & "','" & Format(XdtFichaTmp.ValueField("dFechaFirmaActaCompromiso"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "','" _
                        & XdtFichaTmp.ValueField("sObservacion") & "'," & XdtFichaTmp.ValueField("nSrhEmpleadoComite1ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite2ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite3ID") & ",'" _
                        & Format(XdtFichaTmp.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd HH:mm") & "'," & XdtFichaTmp.ValueField("nStbPersonaEntregaCKID") & ",'" & Format(XdtFichaTmp.ValueField("dFechaPrimerCuota"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaUltimaCuota"), "yyyy-MM-dd") & "'," _
                        & XdtFichaTmp.ValueField("nStbDiaSemanaPagosID") & ",'" & XdtFichaTmp.ValueField("sHorarioEntregaPagos") & "'," & XdtFichaTmp.ValueField("nStbPersonaLugarPagosID") & ",'ANL','" & InfoSistema.LoginName & "', 0, " & InfoSistema.IDCuenta & ", " & XdtFichaTmp.ValueField("nStbDelegacionProgramaID") & ",0 " & "," & intPlazoPeriodoGracia & " ," & XdtFichaTmp.ValueField("nTotalPeriodoGracia") & " ," & XdtFichaTmp.ValueField("nStbTipoPlazoPagosID")
            Else
                Strsql = " EXEC spSclGrabarFNC " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & "," & XdtFichaTmp.ValueField("nSclGrupoSolidarioID") & ",'" _
                        & XdtFichaTmp.ValueField("sNumSesion") & "','" & Format(XdtFichaTmp.ValueField("dFechaFirmaActaCompromiso"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "','" _
                        & XdtFichaTmp.ValueField("sObservacion") & "'," & XdtFichaTmp.ValueField("nSrhEmpleadoComite1ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite2ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite3ID") & ",'" _
                        & Format(XdtFichaTmp.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd HH:mm") & "'," & XdtFichaTmp.ValueField("nStbPersonaEntregaCKID") & ",Null,Null," _
                        & XdtFichaTmp.ValueField("nStbDiaSemanaPagosID") & ",'" & XdtFichaTmp.ValueField("sHorarioEntregaPagos") & "'," & XdtFichaTmp.ValueField("nStbPersonaLugarPagosID") & ",'ANL','" & InfoSistema.LoginName & "', 0, " & InfoSistema.IDCuenta & ", " & XdtFichaTmp.ValueField("nStbDelegacionProgramaID") & ",0 " & "," & intPlazoPeriodoGracia & " ," & XdtFichaTmp.ValueField("nTotalPeriodoGracia") & " ," & XdtFichaTmp.ValueField("nStbTipoPlazoPagosID")
            End If

            Me.intFNCID = XcDatos.ExecuteScalar(Strsql)

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS INSERT DE AUDITORIA 

            ' Esto es para SclFichaNotificacionCredito
            GuardarAuditoriaTablas(4, 1, "Agregar FNC", XdtFicha.ValueField("nSclFichaNotificacionID"), InfoSistema.IDCuenta)

            ' Esto es para SclDetalleDocExpediente
            Dim sqlQuery As String
            Dim IntRegistros As Integer

            sqlQuery = "SELECT DDE.nSclDetalleDocExpedienteID " &
                     "FROM   dbo.SclFichaNotificacionCredito AS FNC INNER JOIN " &
                     "       dbo.SclDetalleDocExpediente AS DDE ON FNC.nSclFichaNotificacionID = DDE.nSclFichaNotificacionID " &
                     "WHERE  FNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtDDE.ExecuteSql(sqlQuery)
            IntRegistros = XdtDDE.Count

            While IntRegistros > 0
                GuardarAuditoriaTablas(23, 1, "Agregar SclDetalleDocExpediente", XdtDDE.ValueField("nSclDetalleDocExpedienteID"), InfoSistema.IDCuenta)
                XdtDDE.Source.MoveNext()
                IntRegistros = IntRegistros - 1
            End While

            ' Esto es para SclFichaNotificacionDetalle
            StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID=" & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
            End If
            GuardarAuditoriaTablas(5, 1, "Agregar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)

            ' ------------------------------------------------------------------------------------------

            'Guardar posición actual de la selección
            intPosicion = Me.intFNCID
            'StrCadena = StrCadena + " Or (a.nSclFichaNotificacionID = " & intPosicion & ")"
            StrCadena = " Where (a.nSclFichaNotificacionID = " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & ") Or (a.nSclFNCOrigenID = " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & ") "
            CargarFicha(StrCadena)
            'Ubicar la selección en la posición original+
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

            If Me.intFNCID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                Call GuardarAuditoria(5, 15, "Anulación de Ficha de Notificación No. " & XdtFichaTmp.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & "). Regeneración de FNC En Proceso (No.: " & XdtFicha.ValueField("nCodigo") & ").")
                MsgBox("Ficha de Notificación fue ANULADA Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

            XdtFichaTmp.Close()
            XdtFichaTmp = Nothing

        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/09/2008
    ' Procedure Name:       LlamaEnviarCARUNA
    ' Descripción:          Este procedimiento permite marcas las fichas de una
    '                       sesión de crédito como Enviadas a CARUNA.
    '-------------------------------------------------------------------------
    Private Sub LlamaEnviarCARUNA()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String
            Dim intPosicion As Integer
            Dim IdFicha As Integer = 0

            '1. Imposible si no existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '2. Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible enviar ACTAS de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            '3. Imposible si existen Fichas En Proceso para la sesión:
            Strsql = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM SclFichaNotificacionCredito INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoCreditoID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (SclFichaNotificacionCredito.sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (StbValorCatalogo.sCodigoInterno = '1')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Fichas En Proceso para la Resolución.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '4. Imposible si existen Fichas APROBADAS en la sesion que NO estan VERIFICADAS:
            Strsql = "SELECT EstadoFicha " &
                     "FROM vwSclFichaNotificacionCredito " &
                     "WHERE (EstadoSDC IS NULL OR EstadoSDC <> 'Verificada') AND (sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (sCodEstado = '2')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Antes debe Verificar las Solicitudes de Desembolso" & Chr(13) & "de todas las Fichas Aprobadas de la Resolución.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '5. Todas las Fuentes de Fichas Aprobadas de la Sesión deben ser de FONDOS EXTERNOS:
            Strsql = "SELECT FNC.nSclFichaNotificacionID " &
                     "FROM SclFichaNotificacionCredito AS FNC INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID " &
                     "INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                     "WHERE (FNC.sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (FF.nFondoPresupuestario = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Fichas de Fondos Presupuestarios en la Resolución.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Confirmar cambio:
            If MsgBox("¿Esta seguro que desea Enviar la Sesión a CARUNA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            Strsql = " EXEC spSclEnviarCARUNA " & XdtFicha.ValueField("nSclFichaNotificacionID") & ", '" & XdtFicha.ValueField("sNumSesion") & "', '" & InfoSistema.LoginName & "'"
            IdFicha = XcDatos.ExecuteScalar(Strsql)

            'Guardar posición actual de la selección
            intPosicion = XdtFicha.ValueField("nSclFichaNotificacionID")
            CargarFicha(StrCadena)
            'Ubicar la selección en la posición original 
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

            If IdFicha = 0 Then
                MsgBox("La Sesión de Crédito NO pudo enviarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                Call GuardarAuditoria(5, 15, "Enviar a CARUNA Resolución de Crédito No. " & XdtFicha.ValueField("sNumSesion"))
                MsgBox("Sesión del Crédito fue marcada para Enviar a CARUNA.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                24/09/2007
    ' Procedure Name:       LlamaAnular
    ' Descripción:          Este procedimiento permite Anular una FNC APROBADA
    '-------------------------------------------------------------------------
    Private Sub LlamaAnular()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtFichaTmp As New BOSistema.Win.XDataSet.xDataTable

        Try

            Dim intDiaPagosID As Integer
            Dim intLugarEntregaCKID As Integer
            Dim intLugarPagosID As Integer
            Dim intPlazoPeriodoGracia As Integer
            Dim strFechaCK As String

            Dim Strsql As String = ""
            Dim intPosicion As Integer

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

            REM Se bloquea Validacion por grupos que disminuyen en sus integrantes
            REM y una vez generada la FNC se impide la aprobacion por no estar todas
            REM las socias del grupo con Ficha de Inscripción.
            'Valida si la Ficha no tiene el estado "APROBADA":
            'If XdtFicha.ValueField("sCodEstado") <> 2 Then
            '    MsgBox("La Ficha no se encuentra APROBADA.", MsgBoxStyle.Critical, NombreSistema)
            '    Exit Sub
            'End If

            'Imposible Anular FNC si existen Recibos Oficiales generados: 
            '(Es POSIBLE Anular aunque existan Solicitudes de Cheque o Cheques asociados ya 
            'que estos igualmente se anularán de forma automática con la Anulación de la FNC).
            Strsql = "SELECT Recibo.nSccReciboOficialCajaID " &
                     "FROM SclFichaNotificacionDetalle DFNC INNER JOIN SccSolicitudDesembolsoCredito SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN  SccSolicitudCheque SCK ON SDC.nSccSolicitudDesembolsoCreditoID = SCK.nSccSolicitudDesembolsoCreditoID INNER JOIN SccReciboOficialCaja RECIBO ON SCK.nSccSolicitudChequeID = Recibo.nSccSolicitudChequeID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Imposible Anular Ficha de Notificación de Crédito." & Chr(13) & "Existen Recibos Oficiales de Caja generados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible generar si existen Cheques generados y el mes contable esta Cerrado.
            Strsql = "SELECT E.dFechaTransaccion " &
                     "FROM ScnTransaccionContable E INNER JOIN SccSolicitudCheque SCK ON E.nSccSolicitudChequeID = SCK.nSccSolicitudChequeID INNER JOIN SccSolicitudDesembolsoCredito SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN SclFichaNotificacionDetalle DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                If PeriodoAbiertoDadaFecha(XcDatos.ExecuteScalar(Strsql)) = False Then
                    MsgBox("Imposible Anular Ficha de Notificación de Crédito." & Chr(13) & "Existen Comprobantes generados de un mes Contable Cerrado.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Confirmar Anulación: 
            If MsgBox("¿Desea ANULAR la Ficha de Notificación?" & Chr(13) & "NO se generará nueva Ficha.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor: 
            Me.Cursor = Cursors.WaitCursor

            'Cargar XdtFichaTmp:  
            Strsql = " Select * " &
                     " From SclFichaNotificacionCredito " &
                     " Where nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtFichaTmp.ExecuteSql(Strsql)

            'Si no se indicó Fecha/Hora Entrega CK:
            If XdtFichaTmp.ValueField("dFechaHoraEntregaCK").ToString.Length = 0 Then
                strFechaCK = "Null"
            Else
                'Fecha/Hora de entrega del Cheque:
                strFechaCK = Format(XdtFichaTmp.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd HH:mm")
            End If
            'Día Pagos:
            If XdtFichaTmp.ValueField("nStbDiaSemanaPagosID").ToString.Length = 0 Then
                intDiaPagosID = -1
            Else
                intDiaPagosID = XdtFichaTmp.ValueField("nStbDiaSemanaPagosID")
            End If
            'Lugar Pagos:
            If XdtFichaTmp.ValueField("nStbPersonaLugarPagosID").ToString.Length = 0 Then
                intLugarPagosID = -1
            Else
                intLugarPagosID = XdtFichaTmp.ValueField("nStbPersonaLugarPagosID")
            End If
            'Plazo del Periodo de Gracia:
            If XdtFichaTmp.ValueField("nStbTipoPlazoPeriodoGraciaID").ToString.Length = 0 Then
                intPlazoPeriodoGracia = -1
            Else
                intPlazoPeriodoGracia = XdtFichaTmp.ValueField("nStbTipoPlazoPeriodoGraciaID")
            End If
            'Lugar Entrega CK:
            If XdtFichaTmp.ValueField("nStbPersonaEntregaCKID").ToString.Length = 0 Then
                intLugarEntregaCKID = -1
            Else
                intLugarEntregaCKID = XdtFichaTmp.ValueField("nStbPersonaEntregaCKID")
            End If

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            ' VAMOS SOLO CON LOS UPDATE DE AUDITORIA 

            Dim XdtConsulta As BOSistema.Win.XDataSet.xDataTable
            Dim StrQuery As String
            XdtConsulta = New BOSistema.Win.XDataSet.xDataTable

            ' Esto es para SclFichaNotificacionDetalle
            Dim IdnSclFichaNotificacionDetalle As Integer
            StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
            End If
            GuardarAuditoriaTablas(5, 2, "Modificar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)

            ' UPDATE SclFichaSocia
            Dim IdnSclFichaSocia As Integer
            StrQuery = "SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaSocia = XdtConsulta.ValueField("nSclFichaSociaID")
            End If
            GuardarAuditoriaTablas(7, 2, "Modificar SclFichaSocia", IdnSclFichaSocia, InfoSistema.IDCuenta)

            ' UPDATE SccSolicitudDesembolsoCredito
            ' halar el último registro de SclFichaNotificacionDetalle y mandar a actualizar a SccSolicitudDesembolsoCredito
            Dim IdnSccSolicitudDesembolsoCredito As Integer
            StrQuery = "SELECT nSccSolicitudDesembolsoCreditoID FROM SccSolicitudDesembolsoCredito WHERE nSclFichaNotificacionDetalleID = " & IdnSclFichaNotificacionDetalle
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSccSolicitudDesembolsoCredito = XdtConsulta.ValueField("nSccSolicitudDesembolsoCreditoID")
                GuardarAuditoriaTablas(3, 2, "Modificar SccSolicitudDesembolsoCredito", IdnSccSolicitudDesembolsoCredito, InfoSistema.IDCuenta)
            End If

            ' UPDATE SclGrupoSolidario
            Dim IdnSclGrupoSolidario As Integer
            StrQuery = "SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclGrupoSolidario = XdtConsulta.ValueField("nSclGrupoSolidarioID")
                GuardarAuditoriaTablas(9, 2, "Modificar SclGrupoSolidario", IdnSclGrupoSolidario, InfoSistema.IDCuenta)
            End If

            ' UPDATE SccSolicitudCheque
            ' halar el último registro de SccSolicitudDesembolsoCredito para el SclFichaNotificacionDetalle y mandar a actualizar a SccSolicitudCheque
            Dim IdnSccSolicitudCheque As Integer
            StrQuery = "SELECT nSccSolicitudChequeID FROM SccSolicitudCheque WHERE nSccSolicitudDesembolsoCreditoID = " & IdnSccSolicitudDesembolsoCredito
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSccSolicitudCheque = XdtConsulta.ValueField("nSccSolicitudChequeID")
                GuardarAuditoriaTablas(1, 2, "Modificar SccSolicitudCheque", IdnSccSolicitudCheque, InfoSistema.IDCuenta)
            End If

            ' UPDATE ScnTransaccionContable
            ' halar el último registro de SccSolicitudCheque para la SccSolicitudDesembolsoCredito del SclFichaNotificacionDetalle y mandar a actualizar a ScnTransaccionContable
            Dim IdnScnTransaccionContableID As Integer
            StrQuery = "SELECT nScnTransaccionContableID FROM ScnTransaccionContable WHERE nSccSolicitudChequeID = " & IdnSccSolicitudCheque
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnScnTransaccionContableID = XdtConsulta.ValueField("nScnTransaccionContableID")
                GuardarAuditoriaTablas(24, 2, "Modificar ScnTransaccionContable ", IdnScnTransaccionContableID, InfoSistema.IDCuenta)
            End If

            ' UPDATE SclFichaNotificacionCredito
            GuardarAuditoriaTablas(4, 2, "Modificar FNC", XdtFicha.ValueField("nSclFichaNotificacionID"), InfoSistema.IDCuenta)

            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            '************************************************************************************
            '1: Anular FNC Actual.
            '2: Anular Solicitudes de Desembolso (si las tiene).
            '3: Anular TODAS las Fichas de Verificación Asociadas.
            '4: Disminuye Consecutivo de Crédito del Grupo Solidario.
            '-- ****************************************************
            '5: Anula Solicitudes de Cheques (SI EXISTEN).
            '6: Anula Comprobantes de Cheques MAYORIZADOS (SI EXISTEN).
            '7: Revierte Mayorización de los Comprobantes de Cheque encontrados.
            If IsDate(XdtFichaTmp.ValueField("dFechaPrimerCuota")) Then
                Strsql = " EXEC spSclGrabarFNC " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & "," & XdtFichaTmp.ValueField("nSclGrupoSolidarioID") & ",'" _
                        & XdtFichaTmp.ValueField("sNumSesion") & "','" & Format(XdtFichaTmp.ValueField("dFechaFirmaActaCompromiso"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "','" _
                        & XdtFichaTmp.ValueField("sObservacion") & "'," & XdtFichaTmp.ValueField("nSrhEmpleadoComite1ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite2ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite3ID") & ",'" _
                        & Format(XdtFichaTmp.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd HH:mm") & "'," & XdtFichaTmp.ValueField("nStbPersonaEntregaCKID") & ",'" & Format(XdtFichaTmp.ValueField("dFechaPrimerCuota"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaUltimaCuota"), "yyyy-MM-dd") & "'," _
                        & XdtFichaTmp.ValueField("nStbDiaSemanaPagosID") & ",'" & XdtFichaTmp.ValueField("sHorarioEntregaPagos") & "'," & XdtFichaTmp.ValueField("nStbPersonaLugarPagosID") & ",'ANS','" & InfoSistema.LoginName & "', 0, " & InfoSistema.IDCuenta & ", " & XdtFichaTmp.ValueField("nStbDelegacionProgramaID") & ",0 " & "," & intPlazoPeriodoGracia & " ," & XdtFichaTmp.ValueField("nTotalPeriodoGracia") & " ," & XdtFichaTmp.ValueField("nStbTipoPlazoPagosID")
            Else 'No se han Generado las Tablas de Amortización, Fecha de Primer Cuota esta en Null:
                If strFechaCK = "Null" Then
                    Strsql = " EXEC spSclGrabarFNC " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & "," & XdtFichaTmp.ValueField("nSclGrupoSolidarioID") & ",'" _
                            & XdtFichaTmp.ValueField("sNumSesion") & "','" & Format(XdtFichaTmp.ValueField("dFechaFirmaActaCompromiso"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "','" _
                            & XdtFichaTmp.ValueField("sObservacion") & "'," & XdtFichaTmp.ValueField("nSrhEmpleadoComite1ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite2ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite3ID") & "," _
                            & strFechaCK & "," & intLugarEntregaCKID & ",Null,Null," _
                            & intDiaPagosID & ",'" & XdtFichaTmp.ValueField("sHorarioEntregaPagos") & "'," & intLugarPagosID & ",'ANS','" & InfoSistema.LoginName & "', 0, " & InfoSistema.IDCuenta & ", " & XdtFichaTmp.ValueField("nStbDelegacionProgramaID") & ",0 " & "," & intPlazoPeriodoGracia & " ," & XdtFichaTmp.ValueField("nTotalPeriodoGracia") & " ," & XdtFichaTmp.ValueField("nStbTipoPlazoPagosID")
                Else
                    Strsql = " EXEC spSclGrabarFNC " & XdtFichaTmp.ValueField("nSclFichaNotificacionID") & "," & XdtFichaTmp.ValueField("nSclGrupoSolidarioID") & ",'" _
                            & XdtFichaTmp.ValueField("sNumSesion") & "','" & Format(XdtFichaTmp.ValueField("dFechaFirmaActaCompromiso"), "yyyy-MM-dd") & "','" & Format(XdtFichaTmp.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "','" _
                            & XdtFichaTmp.ValueField("sObservacion") & "'," & XdtFichaTmp.ValueField("nSrhEmpleadoComite1ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite2ID") & "," & XdtFichaTmp.ValueField("nSrhEmpleadoComite3ID") & ",'" _
                            & Format(XdtFichaTmp.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd HH:mm") & "'," & intLugarEntregaCKID & ",Null,Null," _
                            & intDiaPagosID & ",'" & XdtFichaTmp.ValueField("sHorarioEntregaPagos") & "'," & intLugarPagosID & ",'ANS','" & InfoSistema.LoginName & "', 0, " & InfoSistema.IDCuenta & ", " & XdtFichaTmp.ValueField("nStbDelegacionProgramaID") & ",0 " & "," & intPlazoPeriodoGracia & " ," & XdtFichaTmp.ValueField("nTotalPeriodoGracia") & " ," & XdtFichaTmp.ValueField("nStbTipoPlazoPagosID")
                End If
            End If
            Me.intFNCID = XcDatos.ExecuteScalar(Strsql)

            'Guardar posición actual de la selección:
            intPosicion = Me.intFNCID
            CargarFicha(StrCadena)
            'Ubicar la selección en la posición original:
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

            If Me.intFNCID = 0 Then
                MsgBox("La Ficha NO pudo Anularse.", MsgBoxStyle.Information, NombreSistema)
            Else
                Call GuardarAuditoria(5, 15, "Anulación de Ficha de Notificación de Crédito No. " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ")")
                MsgBox("Ficha de Notificación fue ANULADA Exitosamente.", MsgBoxStyle.Information, NombreSistema)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default

            XcDatos.Close()
            XcDatos = Nothing

            XdtFichaTmp.Close()
            XdtFichaTmp = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       LlamaAprobarRechazarFNC
    ' Descripción:          Este procedimiento permite realizar el cambio a Aprobada
    '                       o Rechazada para la Ficha de Notificación de Crédito.
    '                       IntAprobar = 1 (Aprobar FNC) 
    '-------------------------------------------------------------------------
    Private Sub LlamaAprobarRechazarFNC(ByVal IntAprobar As Integer)
        Dim XcAprobarRechazar As New BOSistema.Win.XComando
        Try

            Dim Strsql As String = ""
            Dim intPosicion As Integer
            Dim intFichaID As Integer
            Dim ficha As Integer

            'No existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si la Ficha no tiene el estado "En Proceso":
            If XdtFicha.ValueField("sCodEstado") <> 1 Then
                MsgBox("La Ficha no se encuentra En Proceso.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si existe al menos: Una Ficha de Inscripción "En Proceso", "Pendiente de Verificar" 
            'o "Verificada" para el GS y aún no contenida dentro de los datos de Resolución del Crédito
            '(SclFichaNotificacionDetalle):
            Strsql = " SELECT a.nSclGrupoSolidarioID " &
                     " FROM   SclGrupoSolidario AS a INNER JOIN SclGrupoSocia AS b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID " &
                     " INNER JOIN SclFichaSocia AS c ON b.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN StbValorCatalogo AS d ON c.nStbEstadoFichaID = d.nStbValorCatalogoID " &
                     " WHERE (d.sCodigoInterno IN ('1', '2', '3')) AND (a.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") " &
                     " AND (NOT (c.nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM  SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & "))))"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Fichas de Inscripción activas que aún no han sido" & Chr(13) & "incorporadas dentro de los datos de Resolución del Crédito.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si no existen registros asociados en SclDetalleDocExpediente:
            Strsql = "SELECT nSclDetalleDocExpedienteID FROM SclDetalleDocExpediente WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("Antes debe registrar los Datos de Expediente.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si no existen registros asociados en SclFichaNotificacionDetalle:
            Strsql = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("Antes debe registrar los datos de Resolución del Crédito.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si hay diferentes Fecha/Hora de Resolución/Entrega de CK para un mismo No. de Sesión
            'en un mismo Año:
            'Si ya se registro ese número de sesión con otra fecha de notificación:
            'Y que las fichas encontradas se encuentren APROBADAS:
            'Strsql = "SELECT sNumSesion FROM SclFichaNotificacionCredito WHERE (nSclFichaNotificacionID <> " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (dFechaNotificacion <> CONVERT(DATETIME, '" & Format(XdtFicha.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "', 102)) AND (sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "')"
            Strsql = "SELECT FNC.sNumSesion FROM SclFichaNotificacionCredito AS FNC INNER JOIN StbValorCatalogo AS Catalogo ON FNC.nStbEstadoCreditoID = Catalogo.nStbValorCatalogoID WHERE  (FNC.dFechaNotificacion <> CONVERT(DATETIME, '" & Format(XdtFicha.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "', 102)) AND (FNC.sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (Catalogo.sCodigoInterno = '2')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El número de Sesión del Crédito ya fue registrado con otra fecha" & Chr(13) & "de resolución en una Ficha de Notificación APROBADA.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If
            Strsql = "SELECT FNC.sNumSesion FROM SclFichaNotificacionCredito AS FNC INNER JOIN StbValorCatalogo AS Catalogo ON FNC.nStbEstadoCreditoID = Catalogo.nStbValorCatalogoID WHERE  (CONVERT(DATE, FNC.dFechaHoraEntregaCK, 102) <> CONVERT(DATE, '" & Format(XdtFicha.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd HH:mm") & "', 102)) AND (FNC.sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (Catalogo.sCodigoInterno = '2')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("El número de Sesión del Crédito ya fue registrado con otra fecha" & Chr(13) & "de entrega de CK en una Ficha de Notificación APROBADA.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si el Codigo de sesion en "000"
            If Mid(XdtFicha.ValueField("sNumSesion"), 4, 3) = "000" Then
                MsgBox("Número de Sesión del Crédito inválido.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If


            If IntAprobar <> 0 Then


                'Imposible si no cumplió Meta de Prosperidad
                Strsql = "spSclMetaCumplidaCreditoAnteriorSocias " & XdtFicha.ValueField("nSclFichaNotificacionID")
                If RegistrosAsociados(Strsql) Then
                    MsgBox("Metas de prosperidad de algunas socias no se cumplieron.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If



                'Imposible si las socias no tienen el mismo Tipo de Turismo
                ' Revisar que la fichas de notificacion (SclFichaSociaNegocio)
                ' todas tengan Turismo, o todas tengan <>Turismo
                ' (Solo en caso de Usura Cero)
                Dim tipoPrograma As Integer = 0 'vwSclTipoProgramaFichaSocia
                Dim cmd As New BOSistema.Win.XComando
                Strsql = " select sCodigoInterno from vwSclTipoProgramaFichaSocia where nSclFichaNotificacionID=" & XdtFicha.ValueField("nSclFichaNotificacionID")
                tipoPrograma = CInt(cmd.ExecuteScalar(Strsql))

                If tipoPrograma = 1 Then
                    Strsql = "select dbo.fnSclPermiteAprobarCreditoTurismo(" & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    ficha = cmd.ExecuteScalar(Strsql)
                    If ficha <> -1 Then
                        MsgBox("No se pueden combinar TURISMO con otro tipo de actividades entre las socias.", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If

                    'Monto Mínimo y Máximo:
                    ' Si es TURISMO es 10,000 (1ros creditos)
                    Strsql = "select dbo.fnSclFichaSoloTurismoValidarMontos(" & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    ficha = IIf(Not IsDBNull(cmd.ExecuteScalar(Strsql)), cmd.ExecuteScalar(Strsql), -1)
                    If ficha = 0 Then
                        MsgBox("No se pueden aprobar TURISMO con montos diferentes de 10,000*N.", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If

                    'Un crédito cuando no se puede combinar turismo con normales en la historia
                    'Revisar que no haya tenido el tipo de crédito opuesto (TURISMO)
                    'select dbo.fnSclFichaSoloTurismoHistoria(163587)
                    Strsql = "select dbo.fnSclFichaSoloTurismoHistoria(" & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    ficha = cmd.ExecuteScalar(Strsql)
                    If ficha <> -1 Then
                        MsgBox("No se pueden combinar TURISMO con otro tipo de actividades o viceversa en la HISTORIA de créditos de las socias.", MsgBoxStyle.Critical, NombreSistema)
                        Exit Sub
                    End If


                    'Tirar Mensaje para que Lean el tipo de Turismo que es
                    Strsql = "select sValorParametro from stbvalorparametro where nStbParametroID=115"
                    ficha = CInt(cmd.ExecuteScalar(Strsql))

                    If IsDBNull(ficha) Then
                        ficha = 1
                    End If

                    Dim mensaje As String = ""
                    Dim numero As Integer = 0

                    If ficha = 1 Then

                        Strsql = "Select Cantidad from vwSclTURISMO_FNC where nTipoTurismo=1 and nSclFichaNotificacionID=" & XdtFicha.ValueField("nSclFichaNotificacionID")
                        numero = cmd.ExecuteScalar(Strsql)
                        mensaje &= " " & numero & " socias con NO VINCULADA" & vbCrLf
                        Strsql = "Select Cantidad from vwSclTURISMO_FNC where nTipoTurismo=2 and nSclFichaNotificacionID=" & XdtFicha.ValueField("nSclFichaNotificacionID")
                        numero = cmd.ExecuteScalar(Strsql)
                        mensaje &= " " & numero & " socias con VINCULADA" & vbCrLf
                        Strsql = "Select Cantidad from vwSclTURISMO_FNC where nTipoTurismo=3 and nSclFichaNotificacionID=" & XdtFicha.ValueField("nSclFichaNotificacionID")
                        numero = cmd.ExecuteScalar(Strsql)
                        mensaje &= " " & numero & " socias con TURISMO" & vbCrLf

                        Dim r As MsgBoxResult = MsgBox("ALERTA: " & vbCrLf & vbCrLf & "El tipo de TURISMO que está por aprobarse es: " & vbCrLf _
                       & vbCrLf & mensaje & vbCrLf & vbCrLf & "¿Es correcto?", vbQuestion + vbYesNo)
                        If r = vbNo Then Exit Sub
                    End If
                End If
                End If

                '**************************************************************************************
                '************************ Si es un Rechazo al Crédito:  *******************************
                '**************************************************************************************
                If IntAprobar = 0 Then
                'Imposible si no se lleno el campo de Observaciones: 
                Strsql = "SELECT nSclFichaNotificacionID FROM SclFichaNotificacionCredito WHERE ((sObservacion IS NULL) OR (sObservacion = ''))  AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                If RegistrosAsociados(Strsql) Then
                    MsgBox("Antes debe registrar Motivo del Rechazo en el campo Observaciones" & Chr(13) & "de los Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If
            End If

            Dim cmd2 As New BOSistema.Win.XComando
            Strsql = "select dbo.fnSclFichaSoloTurismo(" & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            ficha = cmd2.ExecuteScalar(Strsql)

            '**************************************************************************************
            '************************** Si es una Aprobación  al Crédito:  ************************
            '**************************************************************************************
            If (IntAprobar = 1) Then
                If ficha <> 1 Then
                    If (ValidaDatosAprobacion() = False) Then
                        Exit Sub
                    End If
                Else
                    Strsql = "exec spSccValidarCreditosTurismo " & XdtFicha.ValueField("nSclFichaNotificacionID")
                    Dim cmd As New BOSistema.Win.XComando
                    Dim errorsp As Integer
                    errorsp = cmd.ExecuteScalar(Strsql)
                    Select Case errorsp
                        Case 0
                        Case 1
                            MsgBox("No se puede aprobar, existen socias con más de 4 créditos cancelados del tipo TURISMO.", vbCritical, "Error")
                            Exit Sub
                        Case 2
                            MsgBox("No se puede aprobar, existen montos aprobados que no coinciden con el número de crédito establecido.", vbCritical, "Error")
                            Exit Sub
                    End Select
                End If
            End If

                'Confirmar Acción:
                If IntAprobar = 1 Then
                Strsql = "¿Desea APROBAR la Ficha de Notificación?"
            Else
                Strsql = "¿Desea RECHAZAR la Ficha de Notificación?"
            End If
            If MsgBox(Strsql, MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor

            ' ------------------------------------------------------------------------------------------

            ' VAMOS CON LOS UPDATE DE AUDITORIA 

            Dim XdtConsulta As BOSistema.Win.XDataSet.xDataTable
            Dim StrQuery As String
            XdtConsulta = New BOSistema.Win.XDataSet.xDataTable

            Dim IdnSclFichaNotificacionDetalle As Integer

            ' UPDATE SclFichaNotificacionCredito
            GuardarAuditoriaTablas(4, 2, "Modificar FNC", XdtFicha.ValueField("nSclFichaNotificacionID"), InfoSistema.IDCuenta)

            ' UPDATE SclFichaSocia
            Dim IdnSclFichaSocia As Integer
            StrQuery = "SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaSocia = XdtConsulta.ValueField("nSclFichaSociaID")
                GuardarAuditoriaTablas(7, 2, "Modificar SclFichaSocia", IdnSclFichaSocia, InfoSistema.IDCuenta)
            End If

            ' Esto es para SclFichaNotificacionDetalle
            StrQuery = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclFichaNotificacionDetalle = XdtConsulta.ValueField("nSclFichaNotificacionDetalleID")
                GuardarAuditoriaTablas(5, 2, "Modificar SclFichaNotificacionDetalle", IdnSclFichaNotificacionDetalle, InfoSistema.IDCuenta)
            End If

            ' UPDATE SclGrupoSolidario
            Dim IdnSclGrupoSolidario As Integer
            StrQuery = "SELECT nSclGrupoSolidarioID FROM SclFichaNotificacionCredito WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtConsulta.ExecuteSql(StrQuery)

            If XdtConsulta.Count > 0 Then
                IdnSclGrupoSolidario = XdtConsulta.ValueField("nSclGrupoSolidarioID")
                GuardarAuditoriaTablas(9, 2, "Modificar SclGrupoSolidario", IdnSclGrupoSolidario, InfoSistema.IDCuenta)
            End If

            ' ------------------------------------------------------------------------------------------

            'Ejecuta Procedimiento Almacenado:
            Strsql = " EXEC spSclAprobarRechazarFNC " & XdtFicha.ValueField("nSclFichaNotificacionID") & ", " & IntAprobar & ", '" & InfoSistema.LoginName & "'," & InfoSistema.IDCuenta
            intFichaID = XcAprobarRechazar.ExecuteScalar(Strsql)

            'Refrescar Grid: 
            intPosicion = XdtFicha.ValueField("nSclFichaNotificacionID")
            CargarFicha(StrCadena)
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

            If intFichaID = 0 Then
                MsgBox("La Ficha NO se pudo Actualizar.", MsgBoxStyle.Information, NombreSistema)
            Else
                If IntAprobar = 1 Then
                    Call GuardarAuditoria(5, 15, "Aprobación de Ficha de Notificación de Crédito No. " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ")")
                    MsgBox("Estado del Crédito fue actualizado a APROBADO Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                Else
                    Call GuardarAuditoria(5, 15, "Rechazo de Ficha de Notificación de Crédito No. " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ")")
                    MsgBox("Estado del Crédito fue actualizado a RECHAZADO Exitosamente.", MsgBoxStyle.Information, NombreSistema)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XcAprobarRechazar.Close()
            XcAprobarRechazar = Nothing
        End Try
    End Sub

    'Private Sub LlamaAprobarRechazarFNC(ByVal IntAprobar As Integer)
    '    Dim Trans As BOSistema.Win.Transact
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Trans = Nothing
    '    Try
    '        Dim Strsql As String = ""
    '        Dim intPosicion As Integer
    '        Dim intNoPagare As Integer

    '        'No existen registros:
    '        If Me.grdFicha.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO tiene permisos de Edición fuera de su Delegación: 
    '        If IntPermiteEditar = 0 Then
    '            If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
    '                MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '        End If

    '        'Valida si la Ficha no tiene el estado "En Proceso":
    '        If XdtFicha.ValueField("sCodEstado") <> 1 Then
    '            MsgBox("La Ficha no se encuentra En Proceso.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si existe al menos: Una Ficha de Inscripción "En Proceso", "Pendiente de Verificar" 
    '        'o "Verificada" para el GS y aún no contenida dentro de los datos de Resolución del Crédito
    '        '(SclFichaNotificacionDetalle):
    '        Strsql = " SELECT a.nSclGrupoSolidarioID " & _
    '                 " FROM   SclGrupoSolidario AS a INNER JOIN SclGrupoSocia AS b ON a.nSclGrupoSolidarioID = b.nSclGrupoSolidarioID " & _
    '                 " INNER JOIN SclFichaSocia AS c ON b.nSclGrupoSociaID = c.nSclGrupoSociaID INNER JOIN StbValorCatalogo AS d ON c.nStbEstadoFichaID = d.nStbValorCatalogoID " & _
    '                 " WHERE (d.sCodigoInterno IN ('1', '2', '3')) AND (a.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") " & _
    '                 " AND (NOT (c.nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM  SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & "))))"
    '        If RegistrosAsociados(Strsql) Then
    '            MsgBox("Existen Fichas de Inscripción activas que aún no han sido" & Chr(13) & "incorporadas dentro de los datos de Resolución del Crédito.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si no existen registros asociados en SclDetalleDocExpediente:
    '        Strsql = "SELECT nSclDetalleDocExpedienteID FROM SclDetalleDocExpediente WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
    '        If RegistrosAsociados(Strsql) = False Then
    '            MsgBox("Antes debe registrar los Datos de Expediente.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si no existen registros asociados en SclFichaNotificacionDetalle:
    '        Strsql = "SELECT nSclFichaNotificacionDetalleID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
    '        If RegistrosAsociados(Strsql) = False Then
    '            MsgBox("Antes debe registrar los datos de Resolución del Crédito.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si hay diferentes Fecha/Hora de Resolución para un mismo No. de Sesión
    '        'en un mismo Año:
    '        'Si ya se registro ese número de sesión con otra fecha de notificación:
    '        'Y que las fichas encontradas se encuentren APROBADAS:
    '        'Strsql = "SELECT sNumSesion FROM SclFichaNotificacionCredito WHERE (nSclFichaNotificacionID <> " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (dFechaNotificacion <> CONVERT(DATETIME, '" & Format(XdtFicha.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "', 102)) AND (sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "')"
    '        Strsql = "SELECT FNC.sNumSesion FROM SclFichaNotificacionCredito AS FNC INNER JOIN StbValorCatalogo AS Catalogo ON FNC.nStbEstadoCreditoID = Catalogo.nStbValorCatalogoID WHERE  (FNC.dFechaNotificacion <> CONVERT(DATETIME, '" & Format(XdtFicha.ValueField("dFechaNotificacion"), "yyyy-MM-dd HH:mm") & "', 102)) AND (FNC.sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (Catalogo.sCodigoInterno = '2')"
    '        If RegistrosAsociados(Strsql) Then
    '            MsgBox("El número de Sesión del Crédito ya fue registrado con otra fecha" & Chr(13) & "de resolución en una Ficha de Notificación APROBADA.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Imposible si el Codigo de sesion en "000"
    '        If Mid(XdtFicha.ValueField("sNumSesion"), 4, 3) = "000" Then
    '            MsgBox("Número de Sesión del Crédito inválido.", MsgBoxStyle.Critical, NombreSistema)
    '            Exit Sub
    '        End If

    '        '**************************************************************************************
    '        '************************ Si es un Rechazo al Crédito:  *******************************
    '        '**************************************************************************************
    '        If IntAprobar = 0 Then
    '            'Imposible si no se lleno el campo de Observaciones: 
    '            Strsql = "SELECT nSclFichaNotificacionID FROM SclFichaNotificacionCredito WHERE ((sObservacion IS NULL) OR (sObservacion = ''))  AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
    '            If RegistrosAsociados(Strsql) Then
    '                MsgBox("Antes debe registrar Motivo del Rechazo en el campo Observaciones" & Chr(13) & "de los Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
    '                Exit Sub
    '            End If
    '        End If

    '        '**************************************************************************************
    '        '************************** Si es una Aprobación  al Crédito:  ************************
    '        '**************************************************************************************
    '        If (IntAprobar = 1) Then
    '            If (ValidaDatosAprobacion() = False) Then Exit Sub
    '        End If

    '        'Confirmar Acción:
    '        If IntAprobar = 1 Then
    '            Strsql = "¿Desea APROBAR la Ficha de Notificación?"
    '        Else
    '            Strsql = "¿Desea RECHAZAR la Ficha de Notificación?"
    '        End If
    '        If MsgBox(Strsql, MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '        'Cambiar cursor:
    '        Me.Cursor = Cursors.WaitCursor

    '        '******************


    '        Strsql = "SELECT ISNULL(MAX(nNumeroPagare), 0) + 1 AS MaxPagare FROM SclFichaNotificacionCredito"
    '        intNoPagare = XcDatos.ExecuteScalar(Strsql)
    '        'Instanciar Trans:
    '        Trans = New BOSistema.Win.Transact
    '        'Inicio la Transaccion:
    '        Trans.BeginTrans()

    '        '****************************************** I ***************************************
    '        '*** 1. Si es Aprobación: Actualizar el Estado FNC a Aprobada y Actualiza Pagaré:
    '        '*** 2. Si es Rechazo: Actualizar el Estado FNC a Rechazada:
    '        If IntAprobar = 1 Then
    '            Strsql = " Update SclFichaNotificacionCredito " & _
    '                     " SET nNumeroPagare = " & intNoPagare & ", sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbEstadoCreditoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoCredito')" & _
    '                     " WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
    '        Else
    '            Strsql = " Update SclFichaNotificacionCredito " & _
    '                     " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbEstadoCreditoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoCredito')" & _
    '                     " WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
    '        End If
    '        Trans.ExecuteSql(Strsql)

    '        '****************************************** II **************************************
    '        '*** 1. Actualizar Estado de Fichas asociadas a Aprobada para aquellas fichas
    '        '*** que NO se les DENEGO el crédito a través del campo (nCreditoRechazado)
    '        '*** 2. Si es Rechazo del Crédito actualizar todas las Fichas de Inscripción a Rechazadas:
    '        If IntAprobar = 1 Then
    '            Strsql = " Update SclFichaSocia " & _
    '                     " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '5' And b.sNombre = 'EstadoFicha')" & _
    '                     " WHERE (nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE (nCreditoRechazado = 0) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")))"
    '        Else
    '            Strsql = " Update SclFichaSocia " & _
    '                     " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '6' And b.sNombre = 'EstadoFicha')" & _
    '                     " WHERE (nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")))"
    '        End If
    '        Trans.ExecuteSql(Strsql)

    '        '****************************************** III *************************************
    '        '*** 1. Actualizar Estado de Fichas asociadas a Recahzada para aquellas fichas
    '        '*** que se les DENEGO el crédito a través del campo (nCreditoRechazado) a pesar
    '        '*** que se Aprueba la FNC para el resto de socias.
    '        '*** Si es Rechazo actualizar bandera de Crédito denegado a todas las integrantes del Grupo:
    '        If IntAprobar = 1 Then
    '            Strsql = " Update SclFichaSocia " & _
    '                     " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '6' And b.sNombre = 'EstadoFicha')" & _
    '                     " WHERE (nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE (nCreditoRechazado = 1) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")))"
    '            Trans.ExecuteSql(Strsql)
    '        Else
    '            '1. Denegar crédito en SclFichaNotificacionDetalle:
    '            Strsql = " Update SclFichaNotificacionDetalle " & _
    '                     " SET sMotivoRechazo = 'Ficha de Notificación de Crédito Denegada', sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), nCreditoRechazado = 1" & _
    '                     " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
    '            Trans.ExecuteSql(Strsql)
    '            '2. Si existen Señoras Enviadas a CARUNA y la Ficha tiene Ficha Origen regresar a las Señoras a Enviar:
    '            If IsNumeric(XdtFicha.ValueField("nSclFNCOrigenID")) Then
    '                If XdtFicha.ValueField("nSclFNCOrigenID") > 0 Then
    '                    Strsql = " Update SclFichaNotificacionDetalle " & _
    '                             " SET sUsuariomodificacion = '" & InfoSistema.LoginName & "', dfechamodificacion = getdate(), " & _
    '                             " nStbEstadoEnvioID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '2' And b.sNombre = 'EstadoEnvioCARUNA') " & _
    '                             " WHERE (nStbEstadoEnvioID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (a.sCodigoInterno = '3') And (b.sNombre = 'EstadoEnvioCARUNA'))) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
    '                    Trans.ExecuteSql(Strsql)
    '                End If
    '            End If
    '        End If

    '        '****************************************** V ********************************************
    '        '*** 1. APROBACION/RECHAZO: Actualizar Estado GS a Cerrado e incrementa "nConsecutivoCredito":
    '        Strsql = " Update SclGrupoSolidario " & _
    '                 " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), nConsecutivoCredito = nConsecutivoCredito + 1, nStbEstadoGrupoID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoGrupo')" & _
    '                 " WHERE nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID")
    '        Trans.ExecuteSql(Strsql)

    '        'Finaliza Transacción:
    '        Trans.Commit()



    '        'Guardar posición actual de la selección
    '        intPosicion = XdtFicha.ValueField("nSclFichaNotificacionID")
    '        CargarFicha(StrCadena)
    '        'Ubicar la selección en la posición original 
    '        XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
    '        Me.grdFicha.Row = XdtFicha.BindingSource.Position

    '        If IntAprobar = 1 Then
    '            Call GuardarAuditoria(5, 15, "Aprobación de Ficha de Notificación de Crédito No. " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ")")
    '            MsgBox("Estado del Crédito fue actualizado a APROBADO Exitosamente.", MsgBoxStyle.Information, NombreSistema)
    '        Else
    '            Call GuardarAuditoria(5, 15, "Rechazo de Ficha de Notificación de Crédito No. " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ")")
    '            MsgBox("Estado del Crédito fue actualizado a RECHAZADO Exitosamente.", MsgBoxStyle.Information, NombreSistema)
    '        End If

    '    Catch ex As Exception
    '        Trans.RollBack()
    '        Control_Error(ex)
    '    Finally
    '        Me.Cursor = Cursors.Default
    '        Trans = Nothing

    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       ValidaDatosAprobacion
    ' Descripción:          Este procedimiento sirve para realizar todas las
    '                       las validaciones necesarias antes de cambiar a
    '                       Aprobado a una Ficha de Notificación.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAprobacion() As Boolean
        Dim XdtTmpPlazos As BOSistema.Win.XDataSet.xDataTable
        Dim XdtSclFicha As New BOSistema.Win.XDataSet.xDataTable
        Dim XdtSclEdad As New BOSistema.Win.XDataSet.xDataTable
        Try
            ValidaDatosAprobacion = True
            Dim Strsql As String
            Dim sFechaServer As String


            'Dim intPosicion As Integer
            Dim nCreditoUsuraCero As Integer
            Dim nCreditoUCMercado As Integer
            Dim nCreditoPDIBA As Integer

            Dim nCreditoValida20mil As Integer  'VALIDA 20 mil cordobas


            Dim EsSegundaEtapa As Boolean 'Marca si un credito es de segunda etapa o no

            nCreditoUCMercado = 0
            nCreditoPDIBA = 0
            nCreditoValida20mil = 0 'VALIDA 20 mil '






            'Dim IntTotalSocias As Integer

            'Imposible si NO hay socias con el Crédito APROBADO en Resolución Crédito:
            Strsql = "SELECT nCreditoRechazado FROM  SclFichaNotificacionDetalle WHERE (nCreditoRechazado = 0) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("A TODAS las socias se le(s) DENEGO" & Chr(13) & "el Crédito en los datos de Resolución.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Imposible si existen plazos aprobados diferentes:
            XdtTmpPlazos = New BOSistema.Win.XDataSet.xDataTable
            Strsql = "SELECT nPlazoAprobado FROM SclFichaNotificacionDetalle WHERE (nCreditoRechazado = 0) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") GROUP BY nPlazoAprobado"
            XdtTmpPlazos.ExecuteSql(Strsql)
            If XdtTmpPlazos.Count > 1 Then
                MsgBox("Las Socias tienen diferentes PLAZOS Aprobados.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                XdtTmpPlazos.Close()
                XdtTmpPlazos = Nothing
                Exit Function
            End If
            XdtTmpPlazos.Close()
            XdtTmpPlazos = Nothing

            REM Imposible APROBAR si en el Detalle de la FNC existe al menos una Socia  
            'con formato de Cédula inválido "999-999999-9999Z" y que no tenga el Crédito 
            'marcado como Denegado: 
            Strsql = "SELECT SclSocia.sNumeroCedula " &
                     "FROM  SclFichaNotificacionDetalle INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID INNER JOIN SclGrupoSocia ON SclFichaSocia.nSclGrupoSociaID = SclGrupoSocia.nSclGrupoSociaID INNER JOIN  SclSocia ON SclGrupoSocia.nSclSociaID = SclSocia.nSclSociaID " &
                     "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (SclFichaNotificacionDetalle.nCreditoRechazado = 0) AND (SclSocia.sNumeroCedula = '999-999999-9999Z')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existe socia con Cédula de Identidad Inválida" & Chr(13) & "a la cual NO se Denego el Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Advertir si hay socias a las cuales se les haya DENEGADO el Crédito:
            Strsql = "SELECT nCreditoRechazado FROM  SclFichaNotificacionDetalle WHERE (nCreditoRechazado = 1) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                If MsgBox("ADVERTENCIA: Existen socias a las cuales se les DENEGO el Crédito." & Chr(13) &
                          "¿Desea Aprobar la Ficha de Notificación para las socias restantes?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    ValidaDatosAprobacion = False
                    Exit Function
                End If
            End If
            ' 1079 Grupo de 20 Horas no importa excepcion 30/07/2015 agregado
            'Imposible si existe al menos un requisito en NO:
            Strsql = "SELECT nCumpleRequisito FROM  SclDetalleDocExpediente WHERE nStbDocumentoID <> 1079 And  (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (nCumpleRequisito = 0)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen requisitos no cumplidos en los Datos " & Chr(10) &
                       "del Expediente de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Valida si se registro Fecha/Hora Entrega Cheque:
            Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE (dFechaHoraEntregaCK IS NULL) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Antes debe registrar Fecha/Hora de entrega del Cheque" & Chr(10) &
                       "en los datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Valida si se registro Lugar de Entrega de Cheque:
            Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE (nStbPersonaEntregaCKID IS NULL) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Antes debe registrar Lugar de entrega del Cheque" & Chr(10) &
                       "en los datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Valida si se registro Fecha de Primer Cuota:
            'Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE (dFechaPrimerCuota IS NULL) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            'If RegistrosAsociados(Strsql) Then
            '    MsgBox("Antes debe registrar fecha del pago de la primer cuota" & Chr(10) & _
            '           "en los Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosAprobacion = False
            '    Exit Function
            'End If
            'Valida si se registro Fecha de Ultima Cuota:
            'Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE (dFechaUltimaCuota IS NULL) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            'If RegistrosAsociados(Strsql) Then
            '    MsgBox("Antes debe registrar fecha del pago de la última cuota" & Chr(10) & _
            '           "en los Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosAprobacion = False
            '    Exit Function
            'End If

            'Valida si se registro Día de pagos:
            Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE (nStbDiaSemanaPagosID IS NULL) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Antes debe registrar día designado para efectuar pagos por el Grupo" & Chr(10) &
                       "Solidario en los Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Valida si se registro Horario pagos:
            Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE ((sHorarioEntregaPagos IS NULL) OR (sHorarioEntregaPagos = '')) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Antes debe registrar Horario para efectuar pagos" & Chr(10) &
                       "en los Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Valida si se registro Lugar para pagos:
            Strsql = "SELECT nSclFichaNotificacionID  FROM SclFichaNotificacionCredito WHERE (nStbPersonaLugarPagosID IS NULL) AND (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Antes debe registrar Lugar para efectuar pagos en los" & Chr(10) &
                       "Datos Generales de la Ficha de Notificación.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Todas las Socias No denegadas del Grupo deben formar parte de la FNC:
            Strsql = "SELECT nSclGrupoSociaID FROM  SclGrupoSocia " &
                     "WHERE (nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") AND (nCreditoRechazado = 0) AND (NOT (nSclGrupoSociaID IN " &
                     "(SELECT nSclGrupoSociaID FROM (SELECT SclFichaSocia.nSclGrupoSociaID FROM SclFichaNotificacionDetalle INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID " &
                     "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")) AS c)))"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Socias ACTIVAS en el Grupo Solidario que no" & Chr(13) & "forman parte de la Resolución de Crédito.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If
            REM-- Valida que el número de integrantes del Grupo debe ser el mismo que los registros de Fichas:
            'Total Socias Grupo Solidario:
            'Strsql = "SELECT  COUNT(nSclGrupoSociaID) AS Conteo FROM  SclGrupoSocia WHERE  (nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ")"
            'IntTotalSocias = XcDatosA.ExecuteScalar(Strsql)
            ''Total Fichas asociadas:
            'Strsql = "SELECT COUNT(nSclFichaNotificacionDetalleID) AS Conteo FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            'If IntTotalSocias <> CInt(XcDatosA.ExecuteScalar(Strsql)) Then
            '    MsgBox("No se han incorporado el total de Socias del Grupo Solidario.", MsgBoxStyle.Critical, NombreSistema)
            '    ValidaDatosAprobacion = False
            '    XcDatosA.Close()
            '    XcDatosA = Nothing
            '    Exit Function
            'End If
            'XcDatosA.Close()
            'XcDatosA = Nothing

            'Imposible si existen Socias con Mala Referencia Personales y el Credito Sin Denegar:
            Strsql = " SELECT S.sNumeroCedula, S.sNombre1 + ' ' + S.sNombre2 + ' ' + S.sApellido1 + ' ' + S.sApellido2 as Socia " &
                     " FROM SclFichaSocia as FS INNER JOIN SclFichaNotificacionDetalle as DFNC ON FS.nSclFichaSociaID = DFNC.nSclFichaSociaID INNER JOIN SclGrupoSocia GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclReferenciaSocia as R INNER JOIN SclSocia as S ON R.nSclSociaID = S.nSclSociaID ON GS.nSclSociaID = S.nSclSociaID " &
                     " WHERE (R.nActiva = 1) AND (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (DFNC.nCreditoRechazado = 0)"
            If RegistrosAsociados(Strsql) Then
                XdtSclFicha.ExecuteSql(Strsql)
                MsgBox("Imposible Aprobar Crédito a Socia con malas referencias" & Chr(13) & "personales: " & Chr(13) & Chr(13) & "Cédula: " & XdtSclFicha.ValueField("sNumeroCedula") & Chr(13) & "Nombre: " & XdtSclFicha.ValueField("Socia") & ".", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                XdtSclFicha.Close()
                XdtSclFicha = Nothing
                Exit Function
            End If
            XdtSclFicha.Close()
            XdtSclFicha = Nothing

            '17/10/2008 Solicitado por Sheila
            'Imposible APROBAR si existe al menos una Socia < de 18 años y que no tenga
            'el Crédito DENEGADO.
            'o menor de 16 años en el caso de Ventana de Genero.
            sFechaServer = Format(FechaServer(), "yyyy-MM-dd")
            Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " &
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            'Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " & _
            '         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " & _
            '         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") AND (SclTipodePlandeNegocio.nCodigo < 3)"
            If RegistrosAsociados(Strsql) Then 'Creditos Usura Cero / Mercados (Menores de 18 años)
                Strsql = "SELECT  S.sNumeroCedula " &
                         "FROM  SclFichaSocia as FS INNER JOIN SclFichaNotificacionDetalle as DFNC ON FS.nSclFichaSociaID = DFNC.nSclFichaSociaID " &
                         "INNER JOIN SclGrupoSocia as GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia as S ON GS.nSclSociaID = S.nSclSociaID " &
                         "WHERE (CASE WHEN DATEADD(yy, DATEDIFF(yy, S.dFechaNacimiento, '" & sFechaServer & "'), S.dFechaNacimiento) > '" & sFechaServer & "' THEN DATEDIFF(yy, S.dFechaNacimiento, '" & sFechaServer & "') - 1 ELSE DATEDIFF(yy, S.dFechaNacimiento, '" & sFechaServer & "') END < (Select sValorParametro From StbValorParametro Where nStbParametroID = 60)) " &
                         "AND (DFNC.nCreditoRechazado = 0) AND (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            Else 'Creditos Ventana de Genero (Menores de 16 años)
                Strsql = "SELECT  S.sNumeroCedula " &
                         "FROM  SclFichaSocia as FS INNER JOIN SclFichaNotificacionDetalle as DFNC ON FS.nSclFichaSociaID = DFNC.nSclFichaSociaID " &
                         "INNER JOIN SclGrupoSocia as GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia as S ON GS.nSclSociaID = S.nSclSociaID " &
                         "WHERE (CASE WHEN DATEADD(yy, DATEDIFF(yy, S.dFechaNacimiento, '" & sFechaServer & "'), S.dFechaNacimiento) > '" & sFechaServer & "' THEN DATEDIFF(yy, S.dFechaNacimiento, '" & sFechaServer & "') - 1 ELSE DATEDIFF(yy, S.dFechaNacimiento, '" & sFechaServer & "') END < (Select sValorParametro From StbValorParametro Where nStbParametroID = 61)) " &
                         "AND (DFNC.nCreditoRechazado = 0) AND (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            End If
            If RegistrosAsociados(Strsql) Then
                XdtSclEdad.ExecuteSql(Strsql)
                MsgBox("Existe socia con edad menor a la permitida por el Programa sin Denegar." & Chr(13) & "Cédula de Identidad: " & XdtSclEdad.ValueField("sNumeroCedula") & ".", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                XdtSclEdad.Close()
                XdtSclEdad = Nothing
                Exit Function
            End If
            XdtSclEdad.Close()
            XdtSclEdad = Nothing

            'Tipo de Plazo en Periodo de Gracia si el valor no es cero:
            Strsql = "SELECT nSclFichaNotificacionID FROM SclFichaNotificacionCredito " &
                     "WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (nTotalPeriodoGracia > 0) AND (nStbTipoPlazoPeriodoGraciaID IS NULL)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Debe indicar el plazo para el periodo de gracia." & Chr(13) & "Cédula de Identidad: " & XdtSclEdad.ValueField("sNumeroCedula") & ".", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Fecha de Resolución de un mes Contable Cerrado:
            If PeriodoAbiertoDadaFecha(Format(XdtFicha.ValueField("dFechaNotificacion"), "yyyy-MM-dd")) = False Then
                MsgBox("El mes asociado a la Fecha de Resolución" & Chr(13) & "se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Fecha de Entrega de Cheque de un mes Contable Cerrado:
            If PeriodoAbiertoDadaFecha(Format(XdtFicha.ValueField("dFechaHoraEntregaCK"), "yyyy-MM-dd")) = False Then
                MsgBox("El mes asociado a la Fecha de Entrega de Cheque" & Chr(13) & "se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaDatosAprobacion = False
                Exit Function
            End If

            'Advertir si existen socias con iguales apellidos (Primer Apellido):
            Strsql = "SELECT COUNT(S.sApellido1) AS Conteo, S.sApellido1 " &
                     "FROM SclFichaNotificacionDetalle as DFNC INNER JOIN SclFichaSocia as FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia as GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia as S ON GS.nSclSociaID = S.nSclSociaID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") GROUP BY S.sApellido1 HAVING (COUNT(S.sApellido1) > 1)"
            If RegistrosAsociados(Strsql) Then
                If MsgBox("ADVERTENCIA: Existen socias que coinciden en el primer apellido." & Chr(13) &
                          "¿Desea Aprobar la Ficha de Notificación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    ValidaDatosAprobacion = False
                    Exit Function
                End If
            End If

            'Advertir si existen socias con iguales apellidos (Segundo Apellido):
            Strsql = "SELECT COUNT(S.sApellido2) AS Conteo, S.sApellido2 " &
                     "FROM SclFichaNotificacionDetalle as DFNC INNER JOIN SclFichaSocia as FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia as GS ON FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia as S ON GS.nSclSociaID = S.nSclSociaID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (S.sApellido2 <> ' ') " &
                     "GROUP BY S.sApellido2 HAVING (COUNT(S.sApellido2) > 1)"
            If RegistrosAsociados(Strsql) Then
                If MsgBox("ADVERTENCIA: Existen socias que coinciden en el segundo apellido." & Chr(13) &
                          "¿Desea Aprobar la Ficha de Notificación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    ValidaDatosAprobacion = False
                    Exit Function
                End If
            End If


            '---INICIO
            'Cambios agregados para validar que el monto de 10 mil córdobas solo sea para creditos configurables 
            'con n a mas creditos dados.






            '-- Si es Credito del Programa Usura Cero.
            Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " &
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") AND (StbValorCatalogo.sCodigoInterno = '3')"


            If RegistrosAsociados(Strsql) Then 'Grupo Solidario usura cero
                nCreditoPDIBA = 1
            End If




            '-- Si es Credito del Programa Usura Cero.
            Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " &
                     "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") AND (StbValorCatalogo.sCodigoInterno = '1')"
            If RegistrosAsociados(Strsql) Then 'Grupo Solidario usura cero
                nCreditoUsuraCero = 1


                'Determinar si es de Mercados:
                Strsql = "SELECT SclGrupoSolidario.nSclGrupoSolidarioID " &
                         "FROM SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID " &
                         "WHERE (SclGrupoSolidario.nSclGrupoSolidarioID = " & XdtFicha.ValueField("nSclGrupoSolidarioID") & ") AND (SclTipodePlandeNegocio.nCodigo = 5)"
                If RegistrosAsociados(Strsql) Then
                    nCreditoUCMercado = 1
                End If
            Else 'Grupo Solidario Ventana de Genero


                nCreditoUsuraCero = 0
            End If






            'Condicion Modificada 27/07/2017 Solicitud de Sheyla ----Or nCreditoPDIBA = 1
            If nCreditoUsuraCero = 1 Or nCreditoPDIBA = 1 Then ' And CDbl(cneMontoAprobado.Value) >= 10000 Then




                Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
                Dim CreditosCanceladosMinimo, CreditosCanceladosMaximo As Integer
                'Dim SociaID As Integer




                CreditosCanceladosMinimo = 4
                Strsql = " SELECT     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 99) "
                XdtDatos.ExecuteSql(Strsql)
                If XdtDatos.Count > 0 Then

                    CreditosCanceladosMinimo = XdtDatos.ValueField("sValorParametro")

                End If

                Strsql = "Exec  SpSccConsultaTotalCanceladosMinimoGrupos " & XdtFicha.ValueField("nSclGrupoSolidarioID")
                XdtDatos.ExecuteSql(Strsql)
                If XdtDatos.Count > 0 Then
                    'Determinar fnSclFichaSoloTurismo
                    'Dim cmd2 As New BOSistema.Win.XComando
                    'Strsql = "select dbo.fnSclFichaSoloTurismo(" & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    'Dim ficha2 = cmd2.ExecuteScalar(Strsql)
                    'If ficha2 <> 1 Then
                    If Seg.HasPermission("AprobarFichaMontoDiezMil") Then
                        If MsgBox("Existen Socias con Montos de 10 mil cordobas . con menos de " & CreditosCanceladosMinimo & " Créditos Cancelados. " & Chr(13) & "Esta Seguro de Aprobar.  ", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                            ValidaDatosAprobacion = False
                            Exit Function
                        End If
                    Else
                        MsgBox("Existen   " & XdtDatos.Count & " Socias en el grupo con Monto de 10 mil cordobas . Con menos de " & CreditosCanceladosMinimo & " Créditos Cancelados. " & " No se puede aprobar revise ", MsgBoxStyle.Information)
                        ValidaDatosAprobacion = False
                        Exit Function
                    End If
                    'End If
                End If


                'Noviembre del 2014 Agregar para evitar el aprobar a una socia con mas de N Creditos







                CreditosCanceladosMaximo = 10
                Strsql = " SELECT     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 106) "

                'Diferenciar para turismo, si TipoTurismo=3 entonces son 4 creditos Maximo
                Dim Strsql2 As String
                Dim cmd As New BOSistema.Win.XComando
                Strsql2 = "select dbo.fnSclFichaSoloTurismo(" & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                Dim ficha As Integer = cmd.ExecuteScalar(Strsql2)
                If ficha = 1 Then
                    Strsql = " SELECT sValorParametro FROM dbo.StbValorParametro WHERE (nStbParametroID = 114) "
                End If




                XdtDatos.ExecuteSql(Strsql)
                If XdtDatos.Count > 0 Then
                    CreditosCanceladosMaximo = XdtDatos.ValueField("sValorParametro")
                End If

                Strsql = "Exec  SpSccConsultaTotalCanceladosMaximoGrupos " & XdtFicha.ValueField("nSclGrupoSolidarioID")
                XdtDatos.ExecuteSql(Strsql)

                If XdtDatos.Count > 0 Then
                    'Validación Agosto 2018, se permite aprobar créditos a socias con más de 10 créditos
                    'pero al 10% de interés
                    Dim resp = MsgBox("Existen " & XdtDatos.Count & " socias en el grupo con " & CreditosCanceladosMaximo & " o más créditos cancelados. " & vbCrLf & " ¿Desea aprobarle crédito en SEGUNDA ETAPA? ", MsgBoxStyle.Question + MsgBoxStyle.YesNo)

                    If resp = MsgBoxResult.Yes Then
                        'Validar que sólo hayan socias con 10 o más créditos
                        Strsql = "Select dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID, dbo.SclFichaNotificacionCredito.nCodigo, dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) As CreditoNO
                        From dbo.SclFichaNotificacionCredito INNER Join
                        dbo.SclFichaNotificacionDetalle ON dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID INNER Join
                        dbo.SclFichaSocia ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID
                        Where (dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID = {{0}} ) 
                        And (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0) 
                        And (dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) < 10)".Replace("{{0}}", XdtFicha.ValueField("nSclFichaNotificacionID"))

                        If RegistrosAsociados(Strsql) Then
                            MsgBox("Existen Socias con menos de 10 créditos cancelados. No se pueden combinar socias de SEGUNDA ETAPA con las de primera etapa.", vbExclamation, "SMUSURA0")
                            ValidaDatosAprobacion = False
                            Exit Function
                        End If

                        'Validar que tengan un máximo de 4 créditos en la SEGUNDA ETAPA
                        'Buscar en la tabla nueva a N, por cada socia
                        Strsql = "
                        SELECT        nSclFichaNotificacionID, nSclFichaNotificacionDetalleID, nSclSociaID, CreditoNO AS TotalCreditos, CreditoSE_NO AS TotalCreditosSE, CreditoSE_NO + 1 AS ActualCreditosSE, 
                        CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END AS MontoMaximo
                        FROM            (SELECT        SclFichaNotificacionCredito_1.nSclFichaNotificacionID, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, dbo.SclGrupoSocia.nSclSociaID, 
                        dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS CreditoNO, 
                        COUNT(CASE WHEN dbo.StbValorCatalogo.sCodigoInterno = '7' THEN dbo.SclFichaSegundaEtapa.nSclFichaSegundaEtapaID ELSE NULL END) AS CreditoSE_NO
                        FROM            dbo.SclFichaNotificacionDetalle AS SclFichaNotificacionDetalle_1 LEFT OUTER JOIN
                        dbo.SclFichaSocia LEFT OUTER JOIN
                        dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID ON 
                        SclFichaNotificacionDetalle_1.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID LEFT OUTER JOIN
                        dbo.StbValorCatalogo AS StbValorCatalogo_1 RIGHT OUTER JOIN
                        dbo.SclFichaNotificacionCredito ON StbValorCatalogo_1.nStbValorCatalogoID = dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID ON 
                        SclFichaNotificacionDetalle_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID RIGHT OUTER JOIN
                        dbo.SclFichaSegundaEtapa ON SclFichaNotificacionDetalle_1.nSclFichaNotificacionDetalleID = dbo.SclFichaSegundaEtapa.nSclFichaNotificacionDetalleID RIGHT OUTER JOIN
                        dbo.SclFichaNotificacionCredito AS SclFichaNotificacionCredito_1 LEFT OUTER JOIN
                        dbo.SclFichaNotificacionDetalle ON SclFichaNotificacionCredito_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID LEFT OUTER JOIN
                        dbo.SclFichaSocia AS SclFichaSocia_1 ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia_1.nSclFichaSociaID LEFT OUTER JOIN
                        dbo.SclGrupoSocia ON SclFichaSocia_1.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID ON dbo.SclFichaSegundaEtapa.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID
                        WHERE        (SclFichaNotificacionCredito_1.nSclFichaNotificacionID = {{0}}) AND (SclFichaNotificacionDetalle_1.nCreditoRechazado = 0 OR
                        SclFichaNotificacionDetalle_1.nCreditoRechazado IS NULL) AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)
                        GROUP BY SclFichaNotificacionCredito_1.nSclFichaNotificacionID, dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, 
                        dbo.SclGrupoSocia.nSclSociaID) AS I
                        WHERE        (CreditoSE_NO + 1 >= 5)".Replace("{{0}}", XdtFicha.ValueField("nSclFichaNotificacionID"))

                        If RegistrosAsociados(Strsql) Then
                            MsgBox("Existen Socias que ya cumplieron su SEGUNDA ETAPA, no se puede aprobar.", vbExclamation, "SMUSURA0")
                            ValidaDatosAprobacion = False
                            Exit Function
                        End If

                        'Validar que los montos vayan conforme el número de crédito de la SEGUNDA ETAPA
                        ' 1 - 10,000; 2 - 15,000; 3 - 20,000; 4 - 30,000; -- 5000+N*5000
                        Strsql = "SELECT        nSclFichaNotificacionID, nSclFichaNotificacionDetalleID, nSclSociaID, CreditoNO AS TotalCreditos, CreditoSE_NO AS TotalCreditosSE, CreditoSE_NO + 1 AS ActualCreditosSE, 
                        CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END AS MontoMaximo, nMontoCreditoAprobado, 
                        CASE WHEN CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END >= nMontoCreditoAprobado THEN 1 ELSE 0 END AS Permisible
                        FROM            (SELECT        SclFichaNotificacionCredito_1.nSclFichaNotificacionID, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, dbo.SclGrupoSocia.nSclSociaID, 
                        dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID) AS CreditoNO, 
                        COUNT(CASE WHEN dbo.StbValorCatalogo.sCodigoInterno = '7' THEN dbo.SclFichaSegundaEtapa.nSclFichaSegundaEtapaID ELSE NULL END) AS CreditoSE_NO, 
                        dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado
                        FROM            dbo.SclFichaNotificacionDetalle AS SclFichaNotificacionDetalle_1 LEFT OUTER JOIN
                        dbo.SclFichaSocia LEFT OUTER JOIN
                        dbo.StbValorCatalogo ON dbo.SclFichaSocia.nStbEstadoFichaID = dbo.StbValorCatalogo.nStbValorCatalogoID ON 
                        SclFichaNotificacionDetalle_1.nSclFichaSociaID = dbo.SclFichaSocia.nSclFichaSociaID LEFT OUTER JOIN
                        dbo.StbValorCatalogo AS StbValorCatalogo_1 RIGHT OUTER JOIN
                        dbo.SclFichaNotificacionCredito ON StbValorCatalogo_1.nStbValorCatalogoID = dbo.SclFichaNotificacionCredito.nStbEstadoCreditoID ON 
                        SclFichaNotificacionDetalle_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionCredito.nSclFichaNotificacionID RIGHT OUTER JOIN
                        dbo.SclFichaSegundaEtapa ON SclFichaNotificacionDetalle_1.nSclFichaNotificacionDetalleID = dbo.SclFichaSegundaEtapa.nSclFichaNotificacionDetalleID RIGHT OUTER JOIN
                        dbo.SclFichaNotificacionCredito AS SclFichaNotificacionCredito_1 LEFT OUTER JOIN
                        dbo.SclFichaNotificacionDetalle ON SclFichaNotificacionCredito_1.nSclFichaNotificacionID = dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID LEFT OUTER JOIN
                        dbo.SclFichaSocia AS SclFichaSocia_1 ON dbo.SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia_1.nSclFichaSociaID LEFT OUTER JOIN
                        dbo.SclGrupoSocia ON SclFichaSocia_1.nSclGrupoSociaID = dbo.SclGrupoSocia.nSclGrupoSociaID ON dbo.SclFichaSegundaEtapa.nSclSociaID = dbo.SclGrupoSocia.nSclSociaID
                        WHERE        (SclFichaNotificacionCredito_1.nSclFichaNotificacionID = {{0}}) AND (SclFichaNotificacionDetalle_1.nCreditoRechazado = 0 OR
                        SclFichaNotificacionDetalle_1.nCreditoRechazado IS NULL) AND (dbo.SclFichaNotificacionDetalle.nCreditoRechazado = 0)
                        GROUP BY SclFichaNotificacionCredito_1.nSclFichaNotificacionID, dbo.fnNumerodelCreditoFND(dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID), dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, 
                        dbo.SclGrupoSocia.nSclSociaID, dbo.SclFichaNotificacionDetalle.nMontoCreditoAprobado) AS I
                        WHERE        (CASE WHEN CASE WHEN CreditoSE_NO <= 2 THEN 10000 + CreditoSE_NO * 5000 ELSE CreditoSE_NO * 10000 END >= nMontoCreditoAprobado THEN 1 ELSE 0 END = 0)".Replace("{{0}}", XdtFicha.ValueField("nSclFichaNotificacionID"))

                        If RegistrosAsociados(Strsql) Then
                            MsgBox("Existen Socias de SEGUNDA ETAPA con montos no permisibles.", vbExclamation, "SMUSURA0")
                            ValidaDatosAprobacion = False
                            Exit Function
                        End If
                    Else
                        ValidaDatosAprobacion = False
                        Exit Function
                    End If

                    'Si llega hasta este punto es que todo está validado de la SEGUNDA ETAPA
                    'Marcar como grupo de segunda etapa para crear registro en SclFichaSegundaEtapa
                    EsSegundaEtapa = True

                    Strsql = "Exec spSclGrabarSegundaEtapa {{0}}, '{{1}}' " _
                    .Replace("{{0}}", XdtFicha.ValueField("nSclFichaNotificacionID")) _
                    .Replace("{{1}}", InfoSistema.LoginName)

                    Dim command As New BOSistema.Win.XComando
                    command.ExecuteNonQuery(Strsql)

                    Strsql = "SELECT 1 AS A
                    FROM SclFichaSegundaEtapa
                    WHERE nSclFichaNotificacionID={{0}}".Replace("{{0}}", XdtFicha.ValueField("nSclFichaNotificacionID"))

                    If Not RegistrosAsociados(Strsql) Then
                        MsgBox("No se ha podido crear registro de crédito de segunda etapa.", vbExclamation, "SMUSURA0")
                        ValidaDatosAprobacion = False
                        Exit Function
                    End If

                End If



                If Not EsSegundaEtapa Then

                    '---------Aqui para 20 mil Noviembre 24 2015 

                    ''Obtener si valida el flujo para 20 mil cordobas a mas a partir del 2016 poner la bandera en 1 .
                    nCreditoValida20mil = 0


                    Strsql = " Select     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 109) "
                    XdtDatos.ExecuteSql(Strsql)
                    If XdtDatos.Count > 0 Then

                        nCreditoValida20mil = XdtDatos.ValueField("sValorParametro")

                    End If

                    'Si esta en el flujo ahora validar 20 mil.

                    If nCreditoValida20mil = 1 Then

                        CreditosCanceladosMinimo = 9
                        Strsql = " Select     sValorParametro FROM         dbo.StbValorParametro WHERE     (nStbParametroID = 110) "
                        XdtDatos.ExecuteSql(Strsql)
                        If XdtDatos.Count > 0 Then

                            CreditosCanceladosMinimo = XdtDatos.ValueField("sValorParametro")

                        End If
                        'parecida a SpSccConsultaTotalCanceladosMinimoGrupos cambiar solo a 20 mil'
                        Strsql = "Exec  SpSccConsultaTotalCanceladosMinimoGrupos20mil " & XdtFicha.ValueField("nSclGrupoSolidarioID")
                        XdtDatos.ExecuteSql(Strsql)
                        If XdtDatos.Count > 0 Then

                            MsgBox("Existen   " & XdtDatos.Count & " Socias en el grupo con Monto de 20 mil cordobas . Con menos de " & CreditosCanceladosMinimo & " Créditos Cancelados. " & " No se puede aprobar revise ", MsgBoxStyle.Information)
                            ValidaDatosAprobacion = False
                            Exit Function

                        End If

                        Strsql = "Select 1 from vwSccDetalleMontosAprobadosGrupo where nSclFichaNotificacionID=" & XdtFicha.ValueField("nSclFichaNotificacionID")
                        XdtDatos.ExecuteSql(Strsql)
                        If XdtDatos.Count > 0 And Not Seg.HasPermission("AprobarFichaMontoVeinteMil") Then
                            MsgBox("No tiene permiso para aprobar créditos de más de veinte mil córdobas ", MsgBoxStyle.Information)
                            ValidaDatosAprobacion = False
                            Exit Function
                        End If


                        'Incluir  procedimiento de la condicion  al 24  de noviembre del 2015 
                        'Condiciones(.) Para el crédito número 10 . Mora que sea 0
                        ' Lleva registro de ventas si no.
                        'Tiene negocio actualmente
                        '' Monto inventario debería ser igual o mayor al préstamo dado de su ultimo crédito el noveno.
                        'Acápite vi prosperidad del negocio 
                        'Le ha hecho agregado al negocio si no.

                        'Para obtener la mora 
                        'nSclFichaNotificacionID filtro deberia ser el ultimo cancelado

                        '                    SELECT        SUM(dbo.SccTablaAmortizacionPagos.nInteresesMoratorios) AS Expr2, dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID, 
                        '                         dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID AS Expr1, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID
                        'FROM            dbo.SclFichaNotificacionDetalle INNER JOIN
                        '                         dbo.SccTablaAmortizacion ON dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID = dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID INNER JOIN
                        '                         dbo.SccTablaAmortizacionPagos ON dbo.SccTablaAmortizacion.nSccTablaAmortizacionID = dbo.SccTablaAmortizacionPagos.nSccTablaAmortizacionID INNER JOIN
                        '                         dbo.SccReciboOficialCaja ON dbo.SccTablaAmortizacionPagos.nSccReciboOficialCajaID = dbo.SccReciboOficialCaja.nSccReciboOficialCajaID INNER JOIN
                        '                         dbo.StbValorCatalogo ON dbo.SccReciboOficialCaja.nStbEstadoReciboID = dbo.StbValorCatalogo.nStbValorCatalogoID
                        'WHERE        (dbo.StbValorCatalogo.sCodigoInterno <> '3')
                        'GROUP BY dbo.SccTablaAmortizacion.nSclFichaNotificacionDetalleID, dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID, 
                        '                         dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID
                        'HAVING        (dbo.SclFichaNotificacionDetalle.nSclFichaNotificacionID = 100)


                    End If



                    ''------HASTA AQUI 20 MIL

                End If




                Strsql = "Exec  SpSccConsultaSinMetas " & XdtFicha.ValueField("nSclGrupoSolidarioID")
                XdtDatos.ExecuteSql(Strsql)
                If XdtDatos.Count > 0 Then

                    MsgBox("Existen   " & XdtDatos.Count & " Socias en el grupo sin metas definidas. No se puede aprobar revise ", MsgBoxStyle.Information)
                    ValidaDatosAprobacion = False
                    Exit Function
                    'End If  

                End If



                'INICIO Agregado diciembre 2014  para solicitud de permiter registrar menos de 5 por grupo y aprobar al menos de 5 

                Dim XcDatos As New BOSistema.Win.XComando

                Dim intNoMinimoSocias As Integer


                Strsql = "Select sValorParametro FROM  StbValorParametro WHERE (nStbValorParametroID = 113)"

                intNoMinimoSocias = XcDatos.ExecuteScalar(Strsql)



                Strsql = " Select COUNT(nSclFichaNotificacionDetalleID) As NumSocias " &
                       " FROM SclFichaNotificacionDetalle " &
                       " WHERE  (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") And (nCreditoRechazado = 0)"

                If CInt(XcDatos.ExecuteScalar(Strsql)) < intNoMinimoSocias Then
                    MsgBox("El Grupo seleccionado DEBE contener al menos" & Chr(13) & intNoMinimoSocias & " Fichas de Inscripción asociadas.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosAprobacion = False
                    'Me.errFicha.SetError(Me.cboGrupo, "El Grupo seleccionado DEBE contener al menos " & intNoMinimoSocias & " Fichas de Inscripción asociadas.")
                    'Me.cboGrupo.Focus()
                    Exit Function
                End If

                'FIN Agregado diciembre 2014  para solicitud de permiter registrar menos de 5 por grupo y aprobar al menos de 5 

            End If


            'FIN---------------------------
            'Cambios agregados para validar que el monto de 10 mil córdobas solo sea para creditos configurables 
            'con n a mas creditos dados.


            'Advertir si existen socias con iguales apellidos (Primer vs Segundo Apellido):
            Strsql = "Select Apellido FROM (Select  Apellido FROM  (Select S.sApellido1 As Apellido " &
                     "FROM SclFichaNotificacionDetalle As DFNC INNER JOIN SclFichaSocia As FS On DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia As GS On FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia As S On GS.nSclSociaID = S.nSclSociaID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")) As a UNION ALL " &
                     "Select Apellido FROM (Select S.sApellido2 As Apellido " &
                     "FROM SclFichaNotificacionDetalle As DFNC INNER JOIN SclFichaSocia As FS On DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN SclGrupoSocia As GS On FS.nSclGrupoSociaID = GS.nSclGrupoSociaID INNER JOIN SclSocia As S On GS.nSclSociaID = S.nSclSociaID " &
                     "WHERE  (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") And (S.sApellido2 <> ' ')) AS b) AS c " &
                     "GROUP BY Apellido HAVING (COUNT(Apellido) > 1)"
            If RegistrosAsociados(Strsql) Then
                If MsgBox("ADVERTENCIA: Existen socias que coinciden en el primer y/o segundo apellido." & Chr(13) &
                          "¿Desea Aprobar la Ficha de Notificación?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    ValidaDatosAprobacion = False
                    Exit Function
                End If
            End If

        Catch ex As Exception
            ValidaDatosAprobacion = False
            Control_Error(ex)
        End Try
    End Function

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       LlamaModificarFicha
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditFichaNotificacion para Modificar una ficha.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarFicha()
        Dim ObjFrmSclEditFNC As New frmSclEditFichaNotificacion
        Try
            Dim StrSql As String
            'Si no existen FNC registradas:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            REM
            'Si NO tiene permisos de edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Si FNC esta APROBADA:
            If XdtFicha.ValueField("sCodEstado") = 2 Then
                'No Modificar Si No existen Fichas de Inscripción Aprobadas:
                StrSql = "SELECT DFNC.nSclFichaNotificacionID " &
                         "FROM SclFichaNotificacionDetalle as DFNC INNER JOIN SclFichaSocia FS ON DFNC.nSclFichaSociaID = FS.nSclFichaSociaID INNER JOIN StbValorCatalogo as C ON FS.nStbEstadoFichaID = C.nStbValorCatalogoID " &
                         "WHERE (C.sCodigoInterno = '5') AND (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("Imposible modificar los préstamos se encuentran Cancelados.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If
            REM

            'Valida si la Ficha no tiene el estado "En Proceso":
            If XdtFicha.ValueField("sCodEstado") <> 1 Then
                If XdtFicha.ValueField("sCodEstado") = 2 Then
                    MsgBox("La Ficha no se encuentra En Proceso." & Chr(13) & "No podrá modificar todos los datos de la Notificación.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("La Ficha no se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                End If
                'Exit Sub
            End If

            ObjFrmSclEditFNC.ModoFrm = "UPD"
            ObjFrmSclEditFNC.intSclPermiteEditarFNC = IntPermiteEditar
            ObjFrmSclEditFNC.intSclFichaID = XdtFicha.ValueField("nSclFichaNotificacionID")
            ObjFrmSclEditFNC.ShowDialog()

            CargarFicha(StrCadena)
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", ObjFrmSclEditFNC.intSclFichaID)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditFNC.Close()
            ObjFrmSclEditFNC = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de FNC.
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
    ' Fecha:                17/09/2007
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

    '----------------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                02/10/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir un reporte 
    '                       según el campo IntReporte:
    '                           IntReporte (0): FNC = Ficha de Notificación de Crédito
    '                           IntReporte (1): Pagaré
    '                           IntReporte (2): FCC = Ficha de Comité de Crédito
    '                           IntReporte (3): ACC = Acta de Comité de Crédito
    '                           IntReporte (4): TA = Tablas de Amortización
    '                           IntReporte (5): SDC = Solicitudes de Desembolso de Crédito
    '                           IntReporte (6): Reporte ACC = Acta de Comité sin Firmas 
    '----------------------------------------------------------------------------------
    Private Sub LlamaImprimir(ByVal IntReporte As Integer)
        Dim ObjFrmSclParametroFNC As New frmSclParametroFNC
        Dim strSQL As String = ""

        Try

            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            Select Case IntReporte
                Case 0 'Ficha de Notificación de Crédito
                    '-- Imposible si el Estado es En Proceso: 
                    If (XdtFicha.ValueField("sCodEstado") = 1) Then
                        MsgBox("La Ficha de Notificación se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                Case 1  'Pagaré 
                    '    '-- Imposible si la FNC Se encuentra En Proceso:
                    '    If (XdtFicha.ValueField("sCodEstado") = 1) Then
                    '        MsgBox("La Ficha se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    '        Exit Sub
                    '    End If
                    '    '-- Imposible si la FNC Se encuentra Rechazada:
                    '    If (XdtFicha.ValueField("sCodEstado") = 3) Then
                    '        MsgBox("El Crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                    '        Exit Sub
                    '    End If
                    '-- Imposible si no se han Generado las Solicitudes:
                    strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    If RegistrosAsociados(strSQL) = False Then
                        MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                Case 2  'Ficha de Comite de Credito 
                    '-- Por Solicitud de Beyra Santana (10/Sep/2009) imprimir las tasas en null si no se han generado las 
                    'Solicitudes de Desembolso.
                    '-- Imposible si no se han Generado las Solicitudes:
                    'strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    'If RegistrosAsociados(strSQL) = False Then
                    '    MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
                    '    Exit Sub
                    'End If
                Case 4  'Tablas de Amortización
                    '-- Imposible si el estado de la FNC no es APROBADA:
                    If (XdtFicha.ValueField("sCodEstado") <> 2) Then
                        MsgBox("El crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                    '-- Imposible si no se han Generado las Solicitudes
                    strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    If RegistrosAsociados(strSQL) = False Then
                        MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                Case 5 'Solicitudes de Desembolso:
                    '-- Imposible si la FNC Se encuentra En Proceso:
                    If (XdtFicha.ValueField("sCodEstado") = 1) Then
                        MsgBox("La Ficha se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                    '-- Imposible si la FNC Se encuentra Rechazada:
                    If (XdtFicha.ValueField("sCodEstado") = 3) Then
                        MsgBox("El Crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                    '-- Imposible si no se han Generado las Solicitudes
                    strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    If RegistrosAsociados(strSQL) = False Then
                        MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                Case 7 'Solicitudes de Cheque:
                    '-- Imposible si la FNC Se encuentra En Proceso:
                    If (XdtFicha.ValueField("sCodEstado") = 1) Then
                        MsgBox("La Ficha se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                    '-- Imposible si la FNC Se encuentra Rechazada:
                    If (XdtFicha.ValueField("sCodEstado") = 3) Then
                        MsgBox("El Crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                    '-- Imposible si no se han Generado las Solicitudes:
                    strSQL = "SELECT SccSolicitudCheque.nSccSolicitudChequeID " &
                             "FROM SccSolicitudCheque INNER JOIN SccSolicitudDesembolsoCredito ON SccSolicitudCheque.nSccSolicitudDesembolsoCreditoID = SccSolicitudDesembolsoCredito.nSccSolicitudDesembolsoCreditoID INNER JOIN SclFichaNotificacionDetalle ON SccSolicitudDesembolsoCredito.nSclFichaNotificacionDetalleID = SclFichaNotificacionDetalle.nSclFichaNotificacionDetalleID " &
                             "INNER JOIN SccSolicitudChequeDetalle ON SccSolicitudCheque.nSccSolicitudChequeID = SccSolicitudChequeDetalle.nSccSolicitudChequeID WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    If RegistrosAsociados(strSQL) = False Then
                        MsgBox("Ficha no tiene Solicitudes de Cheque generadas" & Chr(13) & "y codificadas por Contabilidad.", MsgBoxStyle.Information, NombreSistema)
                        Exit Sub
                    End If
                    'No debe existir ninguna Solicitud diferente de Anulada o Autorizada:
                    strSQL = "SELECT FNC.nCodigo " &
                             "FROM SccSolicitudCheque as SCK INNER JOIN SccSolicitudDesembolsoCredito as SDC ON SCK.nSccSolicitudDesembolsoCreditoID = SDC.nSccSolicitudDesembolsoCreditoID INNER JOIN " &
                             "SclFichaNotificacionDetalle as DFNC ON SDC.nSclFichaNotificacionDetalleID = DFNC.nSclFichaNotificacionDetalleID INNER JOIN SclFichaNotificacionCredito as FNC ON  DFNC.nSclFichaNotificacionID = FNC.nSclFichaNotificacionID INNER JOIN StbValorCatalogo as C ON SCK.nStbEstadoSolicitudID = C.nStbValorCatalogoID " &
                             "WHERE (C.sCodigoInterno < '4') AND (FNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                    If RegistrosAsociados(strSQL) Then
                        MsgBox("Existen Socias con Solicitud aún NO Autorizada en el Grupo.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
            End Select

            'Ficha de Notificación de Crédito:
            If IntReporte = 0 Then
                ObjFrmSclParametroFNC.NomRep = 2
                ' -- Pagaré
            ElseIf IntReporte = 1 Then
                ObjFrmSclParametroFNC.NomRep = 4
                ' -- Ficha de Comité de Crédito
            ElseIf IntReporte = 2 Then
                ObjFrmSclParametroFNC.NomRep = 3
                ' -- Acta de Comité de Crédito
            ElseIf IntReporte = 3 Then
                ObjFrmSclParametroFNC.NomRep = 7
                ' -- Tablas de Amortización
            ElseIf IntReporte = 4 Then
                ObjFrmSclParametroFNC.NomRep = 8
                ' -- Solicitudes de Desembolso 
            ElseIf IntReporte = 5 Then
                ObjFrmSclParametroFNC.NomRep = 9
                ' -- Reporte de Comité de Crédito
            ElseIf IntReporte = 6 Then
                ObjFrmSclParametroFNC.NomRep = 10
                ' -- Reporte de Solicitudes de Cheque
            ElseIf IntReporte = 7 Then
                ObjFrmSclParametroFNC.NomRep = 11
                ObjFrmSclParametroFNC.intSccTipoID = 1
            ElseIf IntReporte = 13 Then
                ObjFrmSclParametroFNC.NomRep = 13
                ObjFrmSclParametroFNC.grpdestino.Enabled = False
            ElseIf IntReporte = 14 Then
                ObjFrmSclParametroFNC.NomRep = 14
                ObjFrmSclParametroFNC.grpdestino.Enabled = False
            End If

            ObjFrmSclParametroFNC.intSclFormatoID = XdtFicha.ValueField("nSclFichaNotificacionID")
            ObjFrmSclParametroFNC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
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
    ' Fecha:                17/09/2007
    ' Procedure Name:       grdFicha_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdFicha_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdFicha.Filter
        Try
            XdtFicha.FilterLocal(e.Condition)
            Me.grdFicha.Caption = " Listado de Fichas de Notificación de Crédito (" + Me.grdFicha.RowCount.ToString + " registros)"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar FNC:
            If Seg.HasPermission("AgregarFNC") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If
            'Modificar FNC:
            If Seg.HasPermission("ModificarFNC") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If
            'Aprobar FNC:
            If Seg.HasPermission("AprobarFNC") Then
                Me.toolAprobar.Enabled = True
            Else
                Me.toolAprobar.Enabled = False
            End If
            'Rechazar FNC:
            If Seg.HasPermission("RechazarFNC") Then
                Me.toolRechazar.Enabled = True
            Else
                Me.toolRechazar.Enabled = False
            End If
            'Anular FNC Aprobada:
            If Seg.HasPermission("AnularFNC") Then
                Me.toolAnular.Enabled = True
            Else
                Me.toolAnular.Enabled = False
            End If
            'Anular FNC CON REGENERACION:
            If Seg.HasPermission("AnularFNCConRegeneracion") Then
                Me.toolAnularR.Enabled = True
            Else
                Me.toolAnularR.Enabled = False
            End If
            'Generar Solicitud de Desembolso de Crédito:
            If Seg.HasPermission("AgregarSolicitudDesembolso") Then
                Me.toolGenerarSD.Enabled = True
            Else
                Me.toolGenerarSD.Enabled = False
            End If
            'Modificar Solicitud de Desembolso de Crédito:
            If Seg.HasPermission("ModificarSolicitudDesembolso") Then
                Me.toolModificarSD.Enabled = True
            Else
                Me.toolModificarSD.Enabled = False
            End If
            'Verificar Solicitud de Desembolso de Crédito:
            If Seg.HasPermission("VerificarSolicitudDesembolso") Then
                Me.toolVerificarSD.Enabled = True
            Else
                Me.toolVerificarSD.Enabled = False
            End If

            '-- Imprimir:
            'Ficha de Notificación de Crédito:
            If Seg.HasPermission("ImprimirFNC") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If
            'Pagaré:
            If Seg.HasPermission("ImprimirPagare") Then
                Me.toolImprimirP.Enabled = True
            Else
                Me.toolImprimirP.Enabled = False
            End If
            'Ficha de Comité de Crédito (Revisión de Expediente):
            If Seg.HasPermission("ImprimirFCC") Then
                Me.toolImprimirE.Enabled = True
            Else
                Me.toolImprimirE.Enabled = False
            End If
            'Acta de Comité de Crédito:
            If Seg.HasPermission("ImprimirACC") Then
                Me.toolImprimirA.Enabled = True
            Else
                Me.toolImprimirA.Enabled = False
            End If
            'Imprimir Solicitud de Desembolso de Crédito:
            If Seg.HasPermission("ImprimirSolicitudesDesembolso") Then
                Me.toolImprimirSD.Enabled = True
            Else
                Me.toolImprimirSD.Enabled = False
            End If
            'Imprimir Tablas de Amortización:
            If Seg.HasPermission("ImprimirTablasAmortizacion") Then
                Me.toolImprimirTA.Enabled = True
            Else
                Me.toolImprimirTA.Enabled = False
            End If
            'Imprimir Reporte de Comité de Crédito:
            If Seg.HasPermission("ImprimirRptComiteCredito") Then
                Me.toolImprimirReporteA.Enabled = True
            Else
                Me.toolImprimirReporteA.Enabled = False
            End If
            'Imprimir Contrato CARUNA:
            If Seg.HasPermission("ImprimirContratoCARUNA") Then
                Me.toolImprimirContrato.Enabled = True
            Else
                Me.toolImprimirContrato.Enabled = False
            End If
            'Imprimir Estado de Cuenta Resumen Por Grupo:
            If Seg.HasPermission("ImprimirEstadoCuentaResumen") Then
                Me.toolImprimirEC.Enabled = True
            Else
                Me.toolImprimirEC.Enabled = False
            End If
            'Imprimir Desglose Efectivo:
            If Seg.HasPermission("ImprimirDesloseBilletesMonedasCC39") Then
                Me.toolImprimirDenominaciones.Enabled = True
            Else
                Me.toolImprimirDenominaciones.Enabled = False
            End If
            'Imprimir Planilla Por Grupo:
            If Seg.HasPermission("ImprimirPlanillaPagosEfectivoCC40") Then
                Me.toolImprimirPlanillaEfectivo.Enabled = True
            Else
                Me.toolImprimirPlanillaEfectivo.Enabled = False
            End If
            'Imprimir Solicitudes de Cheque: 
            If Seg.HasPermission("ImprimirSCK") Then
                Me.toolImprimirSolicitudCK.Enabled = True
            Else  'Habilita
                Me.toolImprimirSolicitudCK.Enabled = False
            End If

            '**********************************************
            'OPCION DE MENU CARUNA
            'Envios de ACTAS a CARUNA (Menú): 
            If Seg.HasPermission("EnviosActasCARUNA") Then
                Me.toolEnviosCARUNA.Enabled = True
            Else
                Me.toolEnviosCARUNA.Enabled = False
            End If

            'Enviar ACTA a CARUNA:
            If Seg.HasPermission("EnviarActaCARUNA") Then
                Me.toolEnviarCARUNA.Enabled = True
            Else
                Me.toolEnviarCARUNA.Enabled = False
            End If
            'Marcar Ficha como Enviada a CARUNA:
            If Seg.HasPermission("MarcarFNCEnviadaCARUNA") Then
                Me.toolFichaEnviada.Enabled = True
            Else
                Me.toolFichaEnviada.Enabled = False
            End If
            'Cancelar Crédito (Fichas de Inscripción del Grupo Solidario) a CARUNA:
            If Seg.HasPermission("CancelarFichasCARUNA") Then
                Me.toolCancelarFichasI.Enabled = True
            Else
                Me.toolCancelarFichasI.Enabled = False
            End If
            '**********************************************
            'Buscar Ficha:
            If Seg.HasPermission("BuscarFichaNotificacion") Then
                Me.toolBuscar.Enabled = True
            Else
                Me.toolBuscar.Enabled = False
            End If
            ' Constancia de cancelación de crédito
            If Seg.HasPermission("ImprimirRptCartaCancelacionCredito") Then
                Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem.Enabled = True
            Else
                Me.ConstanciaDeCancelaciónCréditoToolStripMenuItem.Enabled = False
            End If
            ' Constancia de vigencia de crédito
            If Seg.HasPermission("ImprimirRptCartaVigenciaCredito") Then
                Me.ConstanciaDeToolStripMenuItem.Enabled = True
            Else
                Me.ConstanciaDeToolStripMenuItem.Enabled = False
            End If

            ' Imprimir Todos los Reportes Salida Formateada
            If Seg.HasPermission("ImprimirRptComiteTodosFormateado") Then
                Me.ReportesDirectosAImpresoraToolStripMenuItem.Enabled = True
            Else
                Me.ReportesDirectosAImpresoraToolStripMenuItem.Enabled = False
            End If


            ' Imprimir Todos los Reportes Salida Formateada
            If Seg.HasPermission("VerMetaCumplida") Then
                Me.toolMetaCumplida.Enabled = True
            Else
                Me.toolMetaCumplida.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/09/2007
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
            If Seg.HasPermission("ModificarFNC") Then
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

    'Impresión de Ficha de Notificación de Crédito:
    Private Sub toolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click
        LlamaImprimir(0)
    End Sub

    'Impresión de Pagaré del Grupo Solidario:
    Private Sub toolImprimirP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirP.Click
        Try
            'Dim strSQL As String
            ''-- Imposible si la FNC Se encuentra En Proceso:
            'If (XdtFicha.ValueField("sCodEstado") = 1) Then
            '    MsgBox("La Ficha se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If
            ''-- Imposible si la FNC Se encuentra Rechazada: 
            'If (XdtFicha.ValueField("sCodEstado") = 3) Then
            '    MsgBox("El Crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If
            ''-- Imposible si no se han Generado las Solicitudes de Desembolso:
            'strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            'If RegistrosAsociados(strSQL) = False Then
            '    MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
            '    Exit Sub
            'End If

            ''Si es CREDITO DE VENTANA DE GENERO:
            'strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
            '         "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " & _
            '         "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " & _
            '         "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            'If RegistrosAsociados(strSQL) Then
            '    LlamaImprimirPagareVG()
            'Else 'CREDITOS USURA CERO/CARUNA/MERCADOS.
            '    'Si es un Fondo Presupuestario:
            '    strSQL = "SELECT FF.nFondoPresupuestario " & _
            '             "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " & _
            '             "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (FF.nFondoPresupuestario = 1)"
            '    If RegistrosAsociados(strSQL) Then
            '        'LlamaImprimir(1)
            '        LlamaImprimirPagareFNI()
            '    Else '*** No es un Fondo Presupuestario:
            '        '-- Si el fondo es BANDES:
            '        strSQL = "SELECT FF.sCodigo " & _
            '                 "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " & _
            '                 "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (FF.sCodigo = '94' or FF.sCodigo = '96')"
            '        If RegistrosAsociados(strSQL) Then
            '            LlamaImprimirPagareNoPresupuestario(94)
            '        Else '-- Fondo No Presupuestario Pagare CARUNA.
            '            LlamaImprimirPagareNoPresupuestario(93)

            '        End If
            '    End If
            'End If
            LlamaImprimirPagareGrupoSolidario(XdtFicha.ValueField("sCodEstado"), XdtFicha.ValueField("nSclFichaNotificacionID"), 1, False, "")
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Sub LlamaImprimirPagareGrupoSolidario(ByVal codEstado As String, ByVal nSclFichaNotificacionID As Integer, ByVal copias As Integer, ByVal intercalar As Boolean, ByVal simpresora As String, Optional ByVal duplex As Boolean = False, Optional ByVal toprint As Boolean = False)
        Dim strSQL As String
        '-- Imposible si la FNC Se encuentra En Proceso:
        If (codEstado = 1) Then
            MsgBox("La Ficha se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
            Exit Sub
        End If
        '-- Imposible si la FNC Se encuentra Rechazada: 
        If (codEstado = 3) Then
            MsgBox("El Crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
            Exit Sub
        End If
        '-- Imposible si no se han Generado las Solicitudes de Desembolso:
        strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
        If RegistrosAsociados(strSQL) = False Then
            MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
            Exit Sub
        End If

        'Si es CREDITO DE VENTANA DE GENERO:
        strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                 "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                 "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                 "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
        If RegistrosAsociados(strSQL) Then
            LlamaImprimirPagareVG(nSclFichaNotificacionID, simpresora, copias, intercalar, duplex, toprint)
        Else


            'Si es CREDITO DE PDIBA:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
            If RegistrosAsociados(strSQL) Then
                LlamaImprimirPagarePDIBA(nSclFichaNotificacionID, simpresora, copias, intercalar, duplex, toprint)


            Else  'Es tipo 1 Usura Cero solamente





                'CREDITOS USURA CERO/CARUNA/MERCADOS.
                'Si es un Fondo Presupuestario:
                strSQL = "SELECT FF.nFondoPresupuestario " &
                         "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                         "WHERE (DFNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") AND (FF.nFondoPresupuestario = 1)"
                If RegistrosAsociados(strSQL) Then
                    'LlamaImprimir(1)
                    LlamaImprimirPagareFNI(nSclFichaNotificacionID, simpresora, copias, intercalar, duplex, toprint)
                Else '*** No es un Fondo Presupuestario:
                    '-- Si el fondo es BANDES:
                    strSQL = "SELECT FF.sCodigo " &
                             "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                             "WHERE (DFNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") AND (FF.sCodigo = '94' or FF.sCodigo = '96')"
                    If RegistrosAsociados(strSQL) Then
                        LlamaImprimirPagareNoPresupuestario(94, nSclFichaNotificacionID, simpresora, copias, intercalar, duplex, toprint)
                    Else '-- Fondo No Presupuestario Pagare CARUNA.
                        LlamaImprimirPagareNoPresupuestario(93, nSclFichaNotificacionID, simpresora, copias, intercalar, duplex, toprint)

                    End If
                End If

            End If

        End If


    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/11/2009
    ' Procedure Name:       LlamaImprimirContratoVG
    ' Descripción:          Este evento permite imprimir Contrato
    '                       de grupos solidarios de Ventana de Genero.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirContratoVG()
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            frmVisor.WindowState = FormWindowState.Maximized

            '-- Asigna Fórmulas al informe:
            '-- Encuentra Socias del Grupo:
            strSQL = " EXEC SpSclPagareSocias " & XdtFicha.ValueField("nSclFichaNotificacionID")
            frmVisor.Formulas("StrSociasGrupo") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
            frmVisor.Formulas("StrSocias") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
            frmVisor.Text = "Contrato Programa Ventana de Genero"

            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "WHERE (SclTipodePlandeNegocio.nCodigo = 3) AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            'Creditos Individuales Ventana de Genero:
            If RegistrosAsociados(strSQL) Then
                'strSQL = "SELECT ISNULL(Fiador, '') AS Fiador " & _
                '         "FROM (SELECT ' y' + ' ' + StbPersona.sNombre1 + ' ' + StbPersona.sNombre2 + ' ' + StbPersona.sApellido1RS + ' ' + StbPersona.sApellido2 + ' identificado(a) con cédula de identidad de la República de Nicaragua número ' + " & _
                '         "StbPersona.sNumCedula  + ' de este domicilio, mayor de edad, quien para efectos del presente contrato se denominará FIADOR SOLIDARIO, este último en su propio nombre e interés'  AS Fiador " & _
                '         "FROM  StbPersona INNER JOIN SclGarantiaFiduciaria ON StbPersona.nStbPersonaID = SclGarantiaFiduciaria.nStbFiadorID  RIGHT OUTER JOIN SclFichaNotificacionDetalle INNER JOIN SclFichaSocia " & _
                '         "ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID  ON  SclGarantiaFiduciaria.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID " & _
                '         "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")) AS a"
                strSQL = " EXEC spSclFiadorSocias " & XdtFicha.ValueField("nSclFichaNotificacionID")
                frmVisor.Formulas("Fiador") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"

                'Si el Prestamo tiene garantia prendaria:
                strSQL = "SELECT SclGarantiaPrendaria.sDescripcion " &
                         "FROM SclFichaNotificacionDetalle INNER JOIN SclFichaSocia ON SclFichaNotificacionDetalle.nSclFichaSociaID = SclFichaSocia.nSclFichaSociaID INNER JOIN SclGarantiaPrendaria ON SclFichaSocia.nSclFichaSociaID = SclGarantiaPrendaria.nSclFichaSociaID " &
                         "WHERE (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
                If RegistrosAsociados(strSQL) Then
                    frmVisor.Formulas("TieneGPrendaria") = "1"
                    frmVisor.Formulas("BienesGPrendaria") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
                Else
                    frmVisor.Formulas("TieneGPrendaria") = "0"
                End If

                frmVisor.NombreReporte = "RepSclCS26VGSocia.rpt"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            Else 'CREDITOS SOLIDARIOS:
                frmVisor.NombreReporte = "RepSclCS26VGGrupo.rpt"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            End If

            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/11/2009
    ' Procedure Name:       LlamaImprimirPagareVG
    ' Descripción:          Este evento permite imprimir Pagare a la Orden
    '                       de grupos solidarios asociadas al Programa 
    '                       Ventana de Genero.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirPagareVG(ByVal nSclFichaNotificacionID As Integer, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal duplex As Boolean = False, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            frmVisor.WindowState = FormWindowState.Maximized

            '-- Asigna Fórmulas al informe:
            '-- Encuentra Socias del Grupo:
            strSQL = " EXEC SpSclPagareSocias " & nSclFichaNotificacionID.ToString
            Dim socias As String = XcDatosSocias.ExecuteScalar(strSQL)
            frmVisor.Formulas("StrSociasGrupo") = "'" & socias & "'"
            frmVisor.Formulas("StrSocias") = "'" & socias & "'"
            frmVisor.Text = "Pagaré Programa Ventana de Genero"

            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "WHERE (SclTipodePlandeNegocio.nCodigo = 3) AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
            'Creditos Individuales Ventana de Genero:
            If RegistrosAsociados(strSQL) Then
                strSQL = " EXEC spSclFiadorSocias " & nSclFichaNotificacionID.ToString
                frmVisor.Formulas("Fiador") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"

                frmVisor.NombreReporte = "RepSclCS6VGSocia.rpt"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            Else 'CREDITOS SOLIDARIOS:
                frmVisor.NombreReporte = "RepSclCS6VGGrupo.rpt"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            End If

            frmVisor.SQLQuery = strSQL

            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar, duplex)
            Else
                frmVisor.ShowDialog()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub

    Private Sub LlamaImprimirPagarePDIBA(ByVal nSclFichaNotificacionID As Integer, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal duplex As Boolean = False, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""
            frmVisor.WindowState = FormWindowState.Maximized

            '-- Asigna Fórmulas al informe:
            '-- Encuentra Socias del Grupo:
            strSQL = " EXEC SpSclPagareSocias " & nSclFichaNotificacionID.ToString
            Dim socias As String = XcDatosSocias.ExecuteScalar(strSQL)
            frmVisor.Formulas("StrSociasGrupo") = "'" & socias & "'"
            frmVisor.Formulas("StrSocias") = "'" & socias & "'"
            frmVisor.Text = "Pagaré Programa PDIBA"

            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "WHERE (SclTipodePlandeNegocio.nCodigo = 5) AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
            'Creditos Individuales Ventana de Genero:
            If RegistrosAsociados(strSQL) Then
                strSQL = " EXEC spSclFiadorSocias " & nSclFichaNotificacionID.ToString
                frmVisor.Formulas("Fiador") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"

                frmVisor.NombreReporte = "RepSclCS6PDIBASocia.rpt"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            Else 'CREDITOS SOLIDARIOS:
                frmVisor.NombreReporte = "RepSclCS6PDIBA.rpt"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            End If

            frmVisor.SQLQuery = strSQL

            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar, duplex)
            Else
                frmVisor.ShowDialog()
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/02/2010
    ' Procedure Name:       LlamaImprimirPagareFNI
    ' Descripción:          Este evento permite imprimir Pagare a la Orden
    '                       de grupos solidarios asociadas al Programa 
    '                       Usura Cero tras traslado MIFIC-FNI.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirPagareFNI(ByVal nSclFichaNotificacionID As Integer, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal duplex As Boolean = False, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Dim sqlStr As String, idTipoPrograma As Integer
        Dim data As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""
            frmVisor.WindowState = FormWindowState.Maximized

            '-- Asigna Fórmulas al informe:
            '-- Encuentra Socias del Grupo:
            strSQL = " EXEC SpSclPagareSocias " & nSclFichaNotificacionID.ToString
            frmVisor.Formulas("StrSociasGrupo") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
            frmVisor.Formulas("StrSocias") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
            frmVisor.Text = "Pagaré Programa Usura Cero / FNI"

            sqlStr = "SELECT CAT.sCodigoInterno " &
                     "FROM   SclGrupoSolidario AS GS INNER JOIN " &
                     "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " &
                     "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " &
                     "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID & ""
            idTipoPrograma = data.ExecuteScalar(sqlStr)

            If idTipoPrograma = 3 Then
                frmVisor.NombreReporte = "RepSclCS6_PDIBA.rpt"
            Else
                frmVisor.NombreReporte = "RepSclCS6FNI.rpt" '****original
            End If

            strSQL = " Select vwSclPagareBANDES.* " &
                     " From vwSclPagareBANDES " &
                     " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString.ToString & ") " &
                     " Order by nCoordinador DESC, sNumeroCedula "
            frmVisor.SQLQuery = strSQL

            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar, duplex)
            Else
                frmVisor.ShowDialog()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                14/05/2008
    ' Procedure Name:       LlamaImprimirPagareNoPresupuestario
    ' Descripción:          Este evento permite imprimir Pagare a la Orden
    '                       de grupos solidarios asociadas a fuentes de 
    '                       fondos no presupuestarios.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirPagareNoPresupuestario(ByVal IntFuente As Integer, ByVal nSclFichaNotificacionID As Integer, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal duplex As Boolean = False, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Dim sqlStr As String, idTipoPrograma As Integer
        Dim Data As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""
            EncuentraParametros()
            EncuentraParametrosAdicionales()
            frmVisor.WindowState = FormWindowState.Maximized


            'frmVisor.Formulas("StrTasaInteres") = "'" & StrTasaInteres & "'"
            'frmVisor.Formulas("TasaMora") = "'" & StrTasaMora & "'"
            'frmVisor.Formulas("TasaInteresNumero") = "'" & DblTasaInteres & "'"
            'frmVisor.Formulas("TasaMoraNumero") = "'" & DblTasaMora & "'"

            '-- Asigna Fórmulas al informe:
            '-- Encuentra Socias del Grupo:
            strSQL = " EXEC SpSclPagareSocias " & nSclFichaNotificacionID.ToString
            frmVisor.Formulas("StrSociasGrupo") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"

            'CARUNA
            If IntFuente = 93 Then

                frmVisor.Formulas("StrPlazoCuotas") = "'" & StrFormaPago & "'"
                frmVisor.Formulas("RepresentanteLegal") = "'" & StrRepresentante & "'"
                frmVisor.Formulas("CargoRepresentante") = "'" & StrCargoR & "'"
                frmVisor.Formulas("CedulaRepresentante") = "'" & StrCedulaR & "'"
                frmVisor.Formulas("EstadoCivilRepresentante") = "'" & StrEstadoCivilR & "'"
                frmVisor.Formulas("ProfesionRepresentante") = "'" & StrProfesionR & "'"
                frmVisor.Formulas("GeneralesRepresentante") = "'" & StrGeneralesR & "'"
                frmVisor.Formulas("NombreAbogado") = "'" & StrAbogado & "'"
                frmVisor.Formulas("GeneralesAbogado") = "'" & StrGeneralesA & "'"

                sqlStr = "SELECT CAT.sCodigoInterno " &
                         "FROM   SclGrupoSolidario AS GS INNER JOIN " &
                         "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " &
                         "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " &
                         "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID & ""
                idTipoPrograma = Data.ExecuteScalar(sqlStr)

                If idTipoPrograma = 3 Then
                    frmVisor.NombreReporte = "RepSclCS6_PDIBA.rpt"
                Else
                    frmVisor.NombreReporte = "RepSclCS6.rpt" '****original
                End If

                '****OJO
                'frmVisor.NombreReporte = "RepSclCS6FNI.rpt" 'CAMBIO REALIZADO EL 23/06/2011
                frmVisor.Text = "Pagaré Fondos No Presupuestarios"
                strSQL = " Select vwSclPagareFondoNoPresupuestarioRep.* " &
                         " From vwSclPagareFondoNoPresupuestarioRep " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "

                'BANDES
            ElseIf IntFuente = 94 Or IntFuente = 96 Then

                frmVisor.Formulas("StrSocias") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
                frmVisor.NombreReporte = "RepSclCS6BANDES.rpt"
                'frmVisor.NombreReporte = "RepSclCS6FNI.rpt" 'CAMBIO REALIZADO EL 23/06/2011
                frmVisor.Text = "Pagaré Fondos No Presupuestarios BANDES"
                strSQL = " Select vwSclPagareBANDES.* " &
                         " From vwSclPagareBANDES " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "

                'PROGRAMA VENTANA DE GENERO:
            ElseIf IntFuente = 0 Then

                frmVisor.Formulas("StrSocias") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
                frmVisor.NombreReporte = "RepSclCS6VG.rpt"
                frmVisor.Text = "Pagaré Programa Ventana de Genero"
                strSQL = " Select vwSclPagareVG.* " &
                         " From vwSclPagareVG " &
                         " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") " &
                         " Order by nCoordinador DESC, sNumeroCedula "
            End If

            frmVisor.SQLQuery = strSQL

            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar, duplex)
            Else
                frmVisor.ShowDialog()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing

            XcDatosSocias.Close()
            XcDatosSocias = Nothing
        End Try
    End Sub

    'Impresión de Ficha de Comité de Crédito;
    Private Sub toolImprimirE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirE.Click
        LlamaImprimir(2)
    End Sub

    'Impresión de Acta de Comité de Crédito:
    Private Sub toolImprimirA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirA.Click
        'LlamaImprimir(3)
        Try

            LlamaImprimirActaReporte("CS9", Me.grdFicha.RowCount, XdtFicha.ValueField("nSclFichaNotificacionID"), XdtFicha.ValueField("EstadoSDC"), XdtFicha.ValueField("sNumSesion"), "", 1, False)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	17/07/2008
    ' Procedure name		   	:	LlamaImprimirActaReporte
    ' Description			   	:	Imprimir Acta o Reporte de Comite de Credito.
    ' -----------------------------------------------------------------------------------------
    Public Sub LlamaImprimirActaReporte(ByVal StrCodigo As String, ByVal cantidad As Integer, ByVal nSclFichaNotificacionID As Integer, ByVal EstadoSDC As String, ByVal sNumSesion As String, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosD As New BOSistema.Win.XComando
        Dim sqlStr As String, idTipoPrograma As Integer
        Dim Data As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""
            Dim IntDenegados As Integer
            If cantidad = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            IntDenegados = 0
            'Para el Reporte: FICHA tiene que tener Solicitud de Desembolso Generada:
            If StrCodigo = "CS12" Then
                'XdtFicha.ValueField("EstadoSDC")
                If EstadoSDC = "NO Generada" Then
                    MsgBox("No se han generado las Solicitudes de Desembolso.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            Else 'Para el Acta: 

                strSQL = " Select vwSclActaComiteCreditoRep.* " &
                         " From vwSclActaComiteCreditoRep " &
                         " WHERE (EstadoCredito = '2') And (nCreditoRechazado = 0) And (sNumSesion = '" & sNumSesion & "')"
                If RegistrosAsociados(strSQL) Then 'Si hay al menos un credito aprobado en la sesion:
                    'Verifica si las Solicitudes de Desembolso estan Aprobadas
                    If EstadoSDC = "NO Generada" Then
                        MsgBox("No se han generado las Solicitudes de Desembolso.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                Else 'Solo Créditos Denegados:
                    IntDenegados = 1
                End If
            End If
            '
            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.Formulas("StrCodigoRpt") = "'" & StrCodigo & "'"
            If StrCodigo = "CS12" Then
                strSQL = " SELECT FNC.nSclFichaNotificacionID " &
                         " FROM SclFichaNotificacionCredito AS FNC INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " &
                         " SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                         " WHERE (FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") AND (FF.nFondoPresupuestario = 0)"
                If RegistrosAsociados(strSQL) Then 'CARUNA (Fondos No Presupuestarios)
                    frmVisor.Formulas("FuenteCARUNA") = 1
                    strSQL = "SELECT FF.sCodigo " &
                             "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                             "WHERE (DFNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") AND (FF.sCodigo = '94')"
                    If RegistrosAsociados(strSQL) Then
                        frmVisor.Formulas("BANDES") = 1
                    Else '-- Fondo No Presupuestario Pagare CARUNA.
                        frmVisor.Formulas("BANDES") = 0
                    End If
                Else
                    frmVisor.Formulas("FuenteCARUNA") = 0
                End If
            Else 'CS9
                frmVisor.Formulas("FuenteCARUNA") = 0
            End If

            'Ubicación de la Sucursal:
            strSQL = "SELECT D.sUbicacionDelegacion " &
                     "FROM SclGrupoSolidario AS GS INNER JOIN SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN vwStbUbicacionGeografica AS UG ON GS.nStbBarrioVerificadoID = UG.nStbBarrioID INNER JOIN StbDelegacionPrograma AS D ON UG.nStbMunicipioID = D.nStbMunicipioID " &
                     "WHERE (FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
            If RegistrosAsociados(strSQL) Then
                frmVisor.Formulas("UbicacionDelegacion") = "'" & XcDatosD.ExecuteScalar(strSQL) & "'"
            End If

            If StrCodigo = "CS9" Then
                frmVisor.Text = "Acta de Comité de Crédito"
            Else
                frmVisor.Text = "Reporte de Comité de Crédito"
            End If

            If IntDenegados = 1 Then
                frmVisor.NombreReporte = "RepSclCS9.rpt"
                strSQL = " Select vwSclActaDenegadosComiteCreditoRep.* " &
                     " From vwSclActaDenegadosComiteCreditoRep " &
                     " WHERE (EstadoCredito = '3') And (sNumSesion = '" & sNumSesion & "') " &
                     " Order by Departamento, Municipio, Grupo, Texto, CodigoGS, nCoordinador DESC, NombreSocia "
            Else

                sqlStr = "SELECT CAT.sCodigoInterno " &
                         "FROM   SclGrupoSolidario AS GS INNER JOIN " &
                         "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " &
                         "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " &
                         "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID & ""
                idTipoPrograma = Data.ExecuteScalar(sqlStr)

                If idTipoPrograma = 3 Then
                    frmVisor.NombreReporte = "RepScnCS9_PDIBA.rpt"
                Else
                    frmVisor.NombreReporte = "RepScnCS9.rpt"
                End If

                strSQL = " Select vwSclActaComiteCreditoRep.* " &
                     " From vwSclActaComiteCreditoRep " &
                     " WHERE (EstadoCredito = '2') And (nCreditoRechazado = 0) And (sNumSesion = '" & sNumSesion & "') " &
                     " Order by Departamento, Municipio, Grupo, Texto, CodigoGS, nCoordinador DESC, NombreSocia "

                ''frmVisor.Parametros("@sNumSesion") = XdtFicha.ValueField("sNumSesion")

            End If

            frmVisor.SQLQuery = strSQL

            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar)
            Else
                frmVisor.ShowDialog()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing

            XcDatosD.Close()
            XcDatosD = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	06/03/2008
    ' Procedure name		   	:	EncuentraParametrosD
    ' Description			   	:	Encontrar parámetros de Delegación.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametrosD()
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

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	15/05/2008
    ' Procedure name		   	:	EncuentraParametrosAdicionales
    ' Description			   	:	Encontrar parámetros adicionales para los reportes
    '                               Pagaré de Fondos No Presupuestarios y Contrato de 
    '                               Crédito con Fianza Solidaria.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametrosAdicionales()
        Dim XcDatosA As New BOSistema.Win.XComando
        Try

            Dim Strsql As String
            '-- Tasa de Interes en Letras:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 22)"
            StrTasaInteres = XcDatosA.ExecuteScalar(Strsql)

            '-- Tasa de Mora en Letras:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 24)"
            StrTasaMora = XcDatosA.ExecuteScalar(Strsql)

            '-- Nombre Representante Legal CARUNA:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 39)"
            StrRepresentante = XcDatosA.ExecuteScalar(Strsql)

            '-- Cargo Representante Legal CARUNA:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 40)"
            StrCargoR = XcDatosA.ExecuteScalar(Strsql)

            '-- Cédula Representante Legal CARUNA:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 41)"
            StrCedulaR = XcDatosA.ExecuteScalar(Strsql)

            '-- Estado Civil Representante Legal CARUNA:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 42)"
            StrEstadoCivilR = XcDatosA.ExecuteScalar(Strsql)

            '-- Profesión Representante Legal CARUNA:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 43)"
            StrProfesionR = XcDatosA.ExecuteScalar(Strsql)

            '-- Generales Ley Representante Legal CARUNA:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 44)"
            StrGeneralesR = XcDatosA.ExecuteScalar(Strsql)

            '-- Nombre Abogado:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 45)"
            StrAbogado = XcDatosA.ExecuteScalar(Strsql)

            '-- Generales Ley Abogado:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 46)"
            StrGeneralesA = XcDatosA.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatosA.Close()
            XcDatosA = Nothing
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	07/12/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros del reporte.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Tasa de Interes para colocacion de Prestamos:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 1)"
            DblTasaInteres = XcDatos.ExecuteScalar(Strsql)

            'Tasa de Mora:
            Strsql = "SELECT sValorParametro FROM StbValorParametro WHERE (nStbParametroID = 3)"
            DblTasaMora = XcDatos.ExecuteScalar(Strsql)

            'Forma de Pago de las socias (Semanal):
            Strsql = "SELECT b.sDescripcion FROM   StbValorParametro a INNER JOIN StbValorCatalogo b ON a.sValorParametro = b.nStbValorCatalogoID WHERE (a.nStbParametroID = 6)"
            StrFormaPago = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    Public Sub ImprimirTablaAmortizacion(ByVal nSclFichaNotificacionID As Integer, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal toprint As Boolean = False)
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim sqlStr As String, idTipoPrograma As Integer
        Dim Data As New BOSistema.Win.XComando
        Dim frmVisor As New frmCRVisorReporte

        Try
            Dim strSQL As String = ""
            Dim nTasaIntCorriente As Double
            Dim nTasaMantValor As Double

            Me.Cursor = Cursors.WaitCursor

            ' Obtener parámetro de Tasa de Interés Corriente
            strSQL = " Select sValorParametro " &
                     " FROM StbValorParametro " &
                     " WHERE (nStbValorParametroID = 1) "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                nTasaIntCorriente = XdtDatos.ValueField("sValorParametro")
            End If

            ' Obtener parámetro de Tasa de Mantenimiento al Valor
            strSQL = " Select sValorParametro " &
                     " FROM StbValorParametro " &
                     " WHERE (nStbValorParametroID = 2) "

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count > 0 Then
                nTasaMantValor = XdtDatos.ValueField("sValorParametro")
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"

            sqlStr = "SELECT CAT.sCodigoInterno " &
                     "FROM   SclGrupoSolidario AS GS INNER JOIN " &
                     "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " &
                     "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " &
                     "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID & ""
            idTipoPrograma = Data.ExecuteScalar(sqlStr)

            If idTipoPrograma = 3 Then
                frmVisor.NombreReporte = "RepSclCS10_PDIBA.rpt"
            Else
                frmVisor.NombreReporte = "RepSclCS10.rpt"
            End If

            frmVisor.Formulas("Interes") = nTasaIntCorriente
            frmVisor.Formulas("Mantenimiento") = nTasaMantValor
            frmVisor.Text = "Listado de Tablas de Amortización"
            frmVisor.SQLQuery = " Select * From vwSclTablaAmortizacionDetalleReporte " &
                                " Where (IdReestructuracion = 0) And (nSclFichaNotificacionID= " & nSclFichaNotificacionID.ToString & ") " &
                                " Order by  nSclFichaNotificacionID, nSclFichaSociaID, nNumCuota "

            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar)
            Else
                frmVisor.ShowDialog()
            End If

            Me.Cursor = Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'frmVisor.Close()
            frmVisor = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub

    'Impresión de Tablas de Amortización:
    Private Sub toolImprimirTA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirTA.Click
        'LlamaImprimir(4)
        ImprimirTablaAmortizacion(XdtFicha.ValueField("nSclFichaNotificacionID"), "", 1, False)
    End Sub

    'Impresión de Solicitudes de Desembolso de Crédito
    Private Sub toolImprimirSD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirSD.Click
        LlamaImprimir(5)
    End Sub

    'Reporte de Comite de Credito:
    Private Sub toolImprimirReporteA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirReporteA.Click
        'LlamaImprimir(6)
        Try
            LlamaImprimirActaReporte("CS12", Me.grdFicha.RowCount, XdtFicha.ValueField("nSclFichaNotificacionID"), XdtFicha.ValueField("EstadoSDC"), XdtFicha.ValueField("sNumSesion"), "", 1, False)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Impresión de Contrato de Credito si la Fuente no es Presupuestaria:
    Private Sub toolImprimirContrato_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirContrato.Click
        Try
            Dim strSQL As String
            '-- Imposible si la FNC Se encuentra En Proceso:
            If (XdtFicha.ValueField("sCodEstado") = 1) Then
                MsgBox("La Ficha se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            '-- Imposible si la FNC Se encuentra Rechazada:
            If (XdtFicha.ValueField("sCodEstado") = 3) Then
                MsgBox("El Crédito no se encuentra APROBADO.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            '-- Imposible si no se han Generado las Solicitudes de Desembolso:
            strSQL = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(strSQL) = False Then
                MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If
            '-- Imposible Si es un Fondo Presupuestario:
            strSQL = "SELECT FF.nFondoPresupuestario " &
                     "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (FF.nFondoPresupuestario = 1)"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Imposible imprimir Contrato de Crédito" & Chr(13) & "para Fondos Presupuestarios.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            '-- Impresión de Contrato de Crédito con Fianza Solidaria:
            'Si es CREDITO DE VENTANA DE GENERO:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (StbValorCatalogo.sCodigoInterno = '2') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(strSQL) Then
                LlamaImprimirContratoVG()
            Else
                LlamaImprimirContrato()
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                15/05/2008
    ' Procedure Name:       LlamaImprimirContrato
    ' Descripción:          Este evento permite imprimir Contrato de Crédito
    '                       de grupos solidarios asociadas a fuentes de 
    '                       fondos no presupuestarios.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimirContrato()
        Dim frmVisor As New frmCRVisorReporte
        Dim XcDatosSocias As New BOSistema.Win.XComando
        Dim sqlStr As String, idTipoPrograma As Integer
        Dim Data As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""
            EncuentraParametros()
            EncuentraParametrosAdicionales()
            frmVisor.WindowState = FormWindowState.Maximized
            '-- Encuentra Socias del Grupo:
            strSQL = " EXEC SpSclPagareSocias " & XdtFicha.ValueField("nSclFichaNotificacionID")
            '-- Asigna Fórmulas del Reporte:
            frmVisor.Formulas("StrSociasGrupo") = "'" & XcDatosSocias.ExecuteScalar(strSQL) & "'"
            'frmVisor.Formulas("StrTasaInteres") = "'" & StrTasaInteres & "'"
            'frmVisor.Formulas("TasaMora") = "'" & StrTasaMora & "'"
            'frmVisor.Formulas("TasaInteresNumero") = "'" & DblTasaInteres & "'"
            'frmVisor.Formulas("TasaMoraNumero") = "'" & DblTasaMora & "'"
            frmVisor.Formulas("StrPlazoCuotas") = "'" & StrFormaPago & "'"
            frmVisor.Formulas("RepresentanteLegal") = "'" & StrRepresentante & "'"
            frmVisor.Formulas("CargoRepresentante") = "'" & StrCargoR & "'"
            frmVisor.Formulas("CedulaRepresentante") = "'" & StrCedulaR & "'"
            frmVisor.Formulas("EstadoCivilRepresentante") = "'" & StrEstadoCivilR & "'"
            frmVisor.Formulas("ProfesionRepresentante") = "'" & StrProfesionR & "'"
            frmVisor.Formulas("GeneralesRepresentante") = "'" & StrGeneralesR & "'"
            frmVisor.Formulas("NombreAbogado") = "'" & StrAbogado & "'"
            frmVisor.Formulas("GeneralesAbogado") = "'" & StrGeneralesA & "'"

            sqlStr = "SELECT CAT.sCodigoInterno " &
                     "FROM   SclGrupoSolidario AS GS INNER JOIN " &
                     "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " &
                     "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " &
                     "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ""
            idTipoPrograma = Data.ExecuteScalar(sqlStr)

            If idTipoPrograma = 3 Then
                frmVisor.NombreReporte = "RepSclCS26_PDIBA.rpt"
            Else
                frmVisor.NombreReporte = "RepSclCS26.rpt"
            End If

            frmVisor.Text = "Contrato de Crédito con Fianza Solidaria"
            strSQL = " Select * " &
                     " From vwSclContratoCredito " &
                     " WHERE (nCreditoRechazado = 0) And (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") " &
                     " Order by nCoordinador DESC, sNumeroCedula "
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing

            XcDatosSocias.Close()
            XcDatosSocias = Nothing
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

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " &
                     " From StbDepartamento a " &
                     " Where (a.nActivo = 1) AND (a.nPertenecePrograma = 1) " &
                     " Order by a.sCodigo"

            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
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
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 50
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 120
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
    '    CargarFicha(StrCadena)
    '    FormatoFicha()
    'End Sub

    'Private Sub radFichasActivas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles radFichasActivas.Click
    '    InicializaVariables()
    '    CargarFicha(StrCadena)
    '    FormatoFicha()
    'End Sub

    'Private Sub RadTodas_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles RadTodas.Click
    '    InicializaVariables()
    '    CargarFicha(StrCadena)
    '    FormatoFicha()
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                18/08/2008
    ' Procedure Name:       LlamaImprimirContrato
    ' Descripción:          Este evento permite imprimir Contrato de Crédito
    '                       de grupos solidarios asociadas a fuentes de 
    '                       fondos no presupuestarios.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirEC_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirEC.Click
        Try
            Dim ObjFrmSccParametroEC As New frmSccParametroEC
            Try
                Dim strSQL As String = ""
                '-- Imposible si no existen registros:
                If Me.grdFicha.RowCount = 0 Then
                    MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                    Exit Sub
                End If

                '-- Imposible si la FNC Se encuentra Rechazada:
                If (XdtFicha.ValueField("sCodEstado") = 3) Then
                    MsgBox("El Crédito se encuentra DENEGADO.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If

                '-- Imposible si el Estado es En Proceso: 
                If (XdtFicha.ValueField("sCodEstado") = 1) Then
                    MsgBox("La Ficha de Notificación se encuentra En Proceso.", MsgBoxStyle.Information, NombreSistema)
                    Exit Sub
                End If

                ObjFrmSccParametroEC.NomRep = 1
                ObjFrmSccParametroEC.intSclFormatoID = XdtFicha.ValueField("nSclFichaNotificacionID")
                ObjFrmSccParametroEC.LlamadoDesde = frmSclParametroFNC.eLlamado.Interfaz
                ObjFrmSccParametroEC.ShowDialog()

            Catch ex As Exception
                Control_Error(ex)
                ObjFrmSccParametroEC.Close()
                ObjFrmSccParametroEC = Nothing
            End Try

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                09/09/2008
    ' Procedure Name:       toolImprimirDenominaciones_Click
    ' Descripción:          Este evento permite imprimir Reporte de
    '                       Desglose de Billetes y Monedas por Grupo Solidario
    '                       para una determinada Acta de Comité de Crédito.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirDenominaciones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirDenominaciones.Click

        Dim frmVisor As New frmCRVisorReporte
        'Dim sqlStr As String, idTipoPrograma As Integer
        Dim Data As New BOSistema.Win.XComando

        Try
            Dim strSQL As String = ""
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO es Grupo Solidario Usura:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE ((StbValorCatalogo.sCodigoInterno = '2')  or(StbValorCatalogo.sCodigoInterno = '3') )AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Reporte no utilizado para Programa Conjunto de Género. o PDIBA", MsgBoxStyle.Information)
                Exit Sub
            End If

            'FICHA tiene que tener Solicitud de Desembolso Generada (para que exista la FF):
            If XdtFicha.ValueField("EstadoSDC") = "NO Generada" Then
                MsgBox("No se han generado las Solicitudes de Desembolso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'Segun Fuente de Fondos es el Encabezado del Reporte:
            strSQL = " SELECT FNC.nSclFichaNotificacionID " &
                     " FROM SclFichaNotificacionCredito AS FNC INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " &
                     " SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                     " WHERE (FNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (FF.nFondoPresupuestario = 0)"
            If RegistrosAsociados(strSQL) Then 'CARUNA (Fondos No Presupuestarios)
                frmVisor.Formulas("FuenteCARUNA") = 1
            Else
                frmVisor.Formulas("FuenteCARUNA") = 0
            End If

            'sqlStr = "SELECT CAT.sCodigoInterno " & _
            '         "FROM   SclGrupoSolidario AS GS INNER JOIN " & _
            '         "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " & _
            '         "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " & _
            '         "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ""
            'idTipoPrograma = Data.ExecuteScalar(sqlStr)

            'If idTipoPrograma = 3 Then
            '    frmVisor.NombreReporte = "RepSccCC39_PDIBA.rpt"
            'Else
            '    frmVisor.NombreReporte = "RepSccCC39.rpt"
            'End If
            frmVisor.NombreReporte = "RepSccCC39.rpt"
            frmVisor.Text = "Desglose de Billetes y Monedas"
            strSQL = " Select vwSclActaComiteCreditoRep.* " &
                     " From vwSclActaComiteCreditoRep " &
                     " WHERE (EstadoCredito = '2') And (nCreditoRechazado = 0) And (sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') " &
                     " Order by  sNumSesion, CodigoGS, Grupo "
            frmVisor.SQLQuery = strSQL
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Public Sub ImprimirPlanillaEfectivo(ByVal cantidad As Integer, ByVal nSclFichaNotificacionID As Integer, ByVal sNumSesion As String, ByVal EstadoSDC As String, ByVal simpresora As String, ByVal copias As Integer, ByVal intercalar As Boolean, Optional ByVal codigogrupo As String = "", Optional ByVal toprint As Boolean = False)
        Dim frmVisor As New frmCRVisorReporte
        'Dim sqlStr As String, idTipoPrograma As Integer
        Dim Data As New BOSistema.Win.XComando


        'Me.grdFicha.RowCount
        'XdtFicha.ValueField("nSclFichaNotificacionID")
        'XdtFicha.ValueField("sNumSesion")
        Try
            Dim strSQL As String = ""
            If cantidad = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO es Grupo Solidario Usura:
            strSQL = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " &
                     "FROM  SclGrupoSolidario INNER JOIN SclTipodePlandeNegocio ON SclGrupoSolidario.nSclTipodePlandeNegocioID = SclTipodePlandeNegocio.nSclTipodePlandeNegocioID INNER JOIN SclFichaNotificacionCredito ON SclGrupoSolidario.nSclGrupoSolidarioID = SclFichaNotificacionCredito.nSclGrupoSolidarioID " &
                     "INNER JOIN StbValorCatalogo ON SclTipodePlandeNegocio.nStbTipoProgramaID = StbValorCatalogo.nStbValorCatalogoID " &
                     "WHERE (StbValorCatalogo.sCodigoInterno = '2' or StbValorCatalogo.sCodigoInterno = '3') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ")"
            If RegistrosAsociados(strSQL) Then
                MsgBox("Reporte no utilizado para Programa Conjunto de Género. o PDIBA", MsgBoxStyle.Information)
                Exit Sub
            End If

            'FICHA: Tiene que tener Solicitud de Desembolso Generada (para que exista la FF):
            If EstadoSDC = "NO Generada" Then
                MsgBox("No se han generado las Solicitudes de Desembolso.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            EncuentraParametros()
            'frmVisor.Formulas("TasaInteres") = "'" & Format(DblTasaInteres, "#,##0.0") & "%'"
            'frmVisor.Formulas("TasaMora") = "'" & Format(DblTasaMora, "#,##0.0") & "%'"

            'Segun Fuente de Fondos es el Encabezado del Reporte:
            strSQL = " SELECT FNC.nSclFichaNotificacionID " &
                     " FROM SclFichaNotificacionCredito AS FNC INNER JOIN SclFichaNotificacionDetalle AS DFNC ON FNC.nSclFichaNotificacionID = DFNC.nSclFichaNotificacionID INNER JOIN " &
                     " SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                     " WHERE (FNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") AND (FF.nFondoPresupuestario = 0)"

            If RegistrosAsociados(strSQL) Then 'CARUNA (Fondos No Presupuestarios).
                frmVisor.Formulas("FuenteCARUNA") = 1
                strSQL = "SELECT FF.sCodigo " &
                         "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " &
                         "WHERE (DFNC.nSclFichaNotificacionID = " & nSclFichaNotificacionID.ToString & ") AND (FF.sCodigo = '94')"
                If RegistrosAsociados(strSQL) Then
                    frmVisor.Formulas("BANDES") = 1
                Else '-- Fondo No Presupuestario Pagare CARUNA.
                    frmVisor.Formulas("BANDES") = 0
                End If
            Else
                frmVisor.Formulas("FuenteCARUNA") = 0
            End If

            'sqlStr = "SELECT CAT.sCodigoInterno " & _
            '         "FROM   SclGrupoSolidario AS GS INNER JOIN " & _
            '         "SclTipodePlandeNegocio AS TPN ON GS.nSclTipodePlandeNegocioID = TPN.nSclTipodePlandeNegocioID INNER JOIN " & _
            '         "SclFichaNotificacionCredito AS FNC ON GS.nSclGrupoSolidarioID = FNC.nSclGrupoSolidarioID INNER JOIN " & _
            '         "StbValorCatalogo AS CAT ON TPN.nStbTipoProgramaID = CAT.nStbValorCatalogoID WHERE  FNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ""
            'idTipoPrograma = Data.ExecuteScalar(sqlStr)

            'If idTipoPrograma = 3 Then
            '    frmVisor.NombreReporte = "RepSccCC40_PDIBA.rpt"
            'Else
            '    frmVisor.NombreReporte = "RepSccCC40.rpt"
            'End If


            frmVisor.NombreReporte = "RepSccCC40.rpt"

            frmVisor.Text = "Planilla de Pagos en Efectivo" 'vwSccPlanillaEfectivo
            strSQL = " Select * " &
                     " From vwSclActaComiteCreditoRep  " &
                     " WHERE (EstadoCredito = '2') And (nCreditoRechazado = 0) And (sNumSesion = '" & sNumSesion & "') " &
                     IIf(Not String.IsNullOrEmpty(codigogrupo), " And CodigoGS='" + codigogrupo + "'", "") & Chr(13) &
                     " Order by sNumSesion, CodigoGS, nCoordinador DESC, sNumeroCedula "
            frmVisor.SQLQuery = strSQL



            If toprint Then
                frmVisor.Imprimir(simpresora, copias, intercalar)
            Else
                frmVisor.ShowDialog()
            End If


        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                10/09/2008
    ' Procedure Name:       toolImprimirPlanillaEfectivo_Click
    ' Descripción:          Este evento permite imprimir Planilla de
    '                       Pagos en Efectivo.
    '-------------------------------------------------------------------------
    Private Sub toolImprimirPlanillaEfectivo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirPlanillaEfectivo.Click
        ImprimirPlanillaEfectivo(Me.grdFicha.RowCount, XdtFicha.ValueField("nSclFichaNotificacionID"), XdtFicha.ValueField("sNumSesion"), XdtFicha.ValueField("EstadoSDC"), "", 1, False)
    End Sub

    Private Sub toolEnviarCARUNA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolEnviarCARUNA.Click
        LlamaEnviarCARUNA()
    End Sub

    Private Sub toolFichaEnviada_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolFichaEnviada.Click
        LlamaFichaEnviadaCARUNA()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                25/09/2007
    ' Procedure Name:       LlamaFichaEnviadaCARUNA
    ' Descripción:          Este procedimiento permite marcar una Ficha marcada 
    '                       con Enviar a CARUNA con el estado ENVIADA siempre que
    '                       todas las Señoras esten Enviadas.
    '-------------------------------------------------------------------------
    Private Sub LlamaFichaEnviadaCARUNA()
        Dim XdtEnvioR As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer

            'No existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si la Ficha no tiene el estado "APROBADA" o "RECHAZADA":
            If XdtFicha.ValueField("sCodEstado") <> 2 And XdtFicha.ValueField("sCodEstado") <> 3 Then
                MsgBox("La Ficha no se encuentra Aprobada ni Rechazada.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Valida si la Ficha no tiene el estado Enviada a CARUNA:
            Strsql = "SELECT SclFichaNotificacionCredito.nSclFichaNotificacionID " & _
                     "FROM SclFichaNotificacionCredito INNER JOIN StbValorCatalogo ON SclFichaNotificacionCredito.nStbEstadoEnvioID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '2') AND (SclFichaNotificacionCredito.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Ficha no se encuentra con el estado Enviar a CARUNA.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si existen Socias que no estan con Envio Realizado:
            Strsql = "SELECT SclFichaNotificacionDetalle.nSclFichaNotificacionID " & _
                     "FROM  StbValorCatalogo INNER JOIN SclFichaNotificacionDetalle ON StbValorCatalogo.nStbValorCatalogoID = SclFichaNotificacionDetalle.nStbEstadoEnvioID " & _
                     "WHERE (StbValorCatalogo.sCodigoInterno <> '3') AND (SclFichaNotificacionDetalle.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Existen Socias que no tienen el Envio Realizado a CARUNA.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Confirmar Acción:
            If MsgBox("¿Desea marcar la Ficha como Enviada a CARUNA?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            'Marcar Ficha con estado Envio Realizado:
            Strsql = " Update SclFichaNotificacionCredito " & _
                     " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), " & _
                     " nStbEstadoEnvioID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '3' And b.sNombre = 'EstadoEnvioCARUNA') " & _
                     " WHERE nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID")
            XdtEnvioR.ExecuteSqlNotTable(Strsql)

            'Guardar posición actual de la selección
            intPosicion = XdtFicha.ValueField("nSclFichaNotificacionID")
            CargarFicha(StrCadena)
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position
            MsgBox("Ficha ha sido marcada como Enviada a CARUNA.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdtEnvioR.Close()
            XdtEnvioR = Nothing
        End Try
    End Sub

    Private Sub toolImprimirSolicitudCK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimirSolicitudCK.Click
        LlamaImprimir(7)
    End Sub

    Private Sub toolCancelarFichasI_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolCancelarFichasI.Click
        LlamaCancelarFichasInscripcion()
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                06/01/2009
    ' Procedure Name:       LlamaCancelarFichasInscripcion
    ' Descripción:          Este procedimiento permite pasar todas las Fichas
    '                       de Inscripción APROBADAS del Grupo Solidario a 
    '                       CANCELADAS siempre que la Fuente sea CARUNA.
    '-------------------------------------------------------------------------
    Private Sub LlamaCancelarFichasInscripcion()
        Dim XdtCancelar As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim Strsql As String = ""
            Dim intPosicion As Integer

            'No existen registros:
            If Me.grdFicha.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtFicha.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible modificar Fichas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Valida si la Ficha no tiene el estado "APROBADA":
            If XdtFicha.ValueField("sCodEstado") <> 2 Then
                MsgBox("La Ficha no se encuentra Aprobada.", MsgBoxStyle.Critical, NombreSistema)
                Exit Sub
            End If

            'Imposible si no se han Generado las Solicitudes de Desembolso:
            Strsql = "SELECT a.nCodigo FROM SccSolicitudDesembolsoCredito AS a INNER JOIN SclFichaNotificacionDetalle AS b ON a.nSclFichaNotificacionDetalleID = b.nSclFichaNotificacionDetalleID WHERE (b.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")"
            If RegistrosAsociados(Strsql) = False Then
                MsgBox("La Ficha no tiene Solicitudes de Desembolso generadas.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Imposible si las Solicitudes de Desembolso no se encuentran VERIFICADAS:
            Strsql = "SELECT EstadoFicha " & _
                     "FROM vwSclFichaNotificacionCredito " & _
                     "WHERE (EstadoSDC IS NULL OR EstadoSDC <> 'Verificada') AND (sNumSesion = '" & XdtFicha.ValueField("sNumSesion") & "') AND (sCodEstado = '2')"
            If RegistrosAsociados(Strsql) Then
                MsgBox("Las Solicitudes de Desembolso" & Chr(13) & "no se encuentran Verificadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible Si es un Fondo Presupuestario:
            Strsql = "SELECT FF.nFondoPresupuestario " & _
                     "FROM SclFichaNotificacionDetalle AS DFNC INNER JOIN SccSolicitudDesembolsoCredito AS SDC ON DFNC.nSclFichaNotificacionDetalleID = SDC.nSclFichaNotificacionDetalleID INNER JOIN ScnFuenteFinanciamiento AS FF ON SDC.nScnFuenteFinanciamientoID = FF.nScnFuenteFinanciamientoID " & _
                     "WHERE (DFNC.nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ") AND (FF.nFondoPresupuestario = 1)"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Fuente de Fondos es Presupuestaria.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Confirmar Acción:
            If MsgBox("¿Desea Cancelar todas las Fichas de Inscripción APROBADAS" & Chr(13) & "para el Grupo Solidario?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            'Cambiar cursor:
            Me.Cursor = Cursors.WaitCursor
            'Fichas de Inscripción que esten asociadas a la FNC y que tengan el estado 
            'APROBADAS pasarlas al estado CANCELADAS:
            Strsql = " Update SclFichaSocia " & _
                     " SET sUsuarioModificacion = '" & InfoSistema.LoginName & "', dFechaModificacion = getdate(), " & _
                     " nStbEstadoFichaID = (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno = '7' And b.sNombre = 'EstadoFicha') " & _
                     " WHERE (nStbEstadoFichaID = (SELECT  a.nStbValorCatalogoID FROM  StbValorCatalogo AS a INNER JOIN StbCatalogo AS b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE (a.sCodigoInterno = '5') AND (b.sNombre = 'EstadoFicha'))) " & _
                     " AND (nSclFichaSociaID IN (SELECT nSclFichaSociaID FROM SclFichaNotificacionDetalle WHERE (nSclFichaNotificacionID = " & XdtFicha.ValueField("nSclFichaNotificacionID") & ")))"
            XdtCancelar.ExecuteSqlNotTable(Strsql)

            'Guardar posición actual de la selección:
            intPosicion = XdtFicha.ValueField("nSclFichaNotificacionID")
            CargarFicha(StrCadena)
            XdtFicha.SetCurrentByID("nSclFichaNotificacionID", intPosicion)
            Me.grdFicha.Row = XdtFicha.BindingSource.Position
            Call GuardarAuditoria(5, 15, "Cancelación manual de Créditos para la Ficha Notificación No.: " & XdtFicha.ValueField("nCodigo") & " (Grupo Solidario: " & XdtFicha.ValueField("CodigoGS") & " - " & XdtFicha.ValueField("sNombreGS") & ").")
            MsgBox("Los Créditos se han dado por CANCELADOS.", MsgBoxStyle.Information, NombreSistema)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            Me.Cursor = Cursors.Default
            XdtCancelar.Close()
            XdtCancelar = Nothing
        End Try
    End Sub

    Private Sub grdFicha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grdFicha.Click

    End Sub

    Private Sub toolVerificarSD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolVerificarSD.Click

    End Sub

    Private Sub ConstanciaDeCancelaciónCréditoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConstanciaDeCancelaciónCréditoToolStripMenuItem.Click
        Me.LlamaImprimir(13)
    End Sub

    Private Sub ConstanciaDeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ConstanciaDeToolStripMenuItem.Click
        Me.LlamaImprimir(14)
    End Sub

    Private Sub toolModificarSD_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolModificarSD.Click

    End Sub

    Private Sub ReportesDirectosAImpresoraToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportesDirectosAImpresoraToolStripMenuItem.Click
        Dim objfrmSccReportesDirectoAImpresora As New frmSccReportesDirectoAImpresora
        objfrmSccReportesDirectoAImpresora.intSclFormatoID = XdtFicha.ValueField("nSclFichaNotificacionID")
        objfrmSccReportesDirectoAImpresora.EstadoFicha = XdtFicha.ValueField("sCodEstado")
        objfrmSccReportesDirectoAImpresora.NombreGrupo = XdtFicha.ValueField("sNombreGS")
        objfrmSccReportesDirectoAImpresora.CodigoGrupo = XdtFicha.ValueField("CodigoGS")
        objfrmSccReportesDirectoAImpresora.CodigoFichaNotificacion = XdtFicha.ValueField("nCodigo")
        objfrmSccReportesDirectoAImpresora.NumSesion = XdtFicha.ValueField("sNumSesion")
        objfrmSccReportesDirectoAImpresora.EstadoSDC = XdtFicha.ValueField("EstadoSDC")
        objfrmSccReportesDirectoAImpresora.Show()

    End Sub

    Private Sub toolImpresiones_ButtonClick(sender As System.Object, e As System.EventArgs) Handles toolImpresiones.ButtonClick

    End Sub

    Private Sub ImprimirMódulosAprobdosDeGrupoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImprimirMódulosAprobdosDeGrupoToolStripMenuItem.Click
        LlamaImprimirModulos()
    End Sub

    Public Sub LlamaImprimirModulos()
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
            frmVisor.Parametros("@nSclFichaNotificacionID") = XdtFicha.ValueField("nSclFichaNotificacionID")
            frmVisor.Parametros("@nSclFichaSociaID") = 0
            frmVisor.NombreReporte = "RepSclCS68.rpt"
            frmVisor.Text = "Módulo Máximo Aprobado - Cursos"
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

End Class