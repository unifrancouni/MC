' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                04/07/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSclReferenciaSocia.vb
' Descripción:          Formulario muestra Socias con Problemas de referencia
'                       en créditos anteriores.
'-------------------------------------------------------------------------
Public Class frmSclReferenciaSocia
    '- Declaración de Variables 
    Dim XdsReferencia As BOSistema.Win.XDataSet
    Dim StrCadena As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       frmSclReferenciaSocia_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSclReferenciaSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsReferencia.Close()
            XdsReferencia = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	04/07/2008
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
    ' Fecha:                04/07/2008
    ' Procedure Name:       frmSclReferenciaSocia_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado de Referencias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSclReferenciaSocia_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            StrCadena = "Where (nSclSociaID = 0) " 'Al cargar Grid en Blanco
            CargarReferenciaSocia(StrCadena)
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try

            XdsReferencia = New BOSistema.Win.XDataSet

            'Encuentra parámetros de Consulta / Edición Sucursales:
            EncuentraParametros()

            'Limpiar los Grids, estructura y Datos:
            Me.grdSocias.ClearFields()
            Me.grdReferencias.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       CargarReferenciaSocia
    ' Descripción:          Este procedimiento permite cargar los datos
    '                       de Socias con referencias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarReferenciaSocia(ByVal sCadenaFiltro As String)
        Try
            Dim Strsql As String

            'Maestro (Socias con Referencias asignadas): 
            Strsql = " SELECT nSclSociaID, nCodigo, NombreSocia, sNumeroCedula, sTelefonoSocia, sDireccionSocia, nStbDelegacionProgramaID " &
                     " From vwSclSociasConReferencias " & sCadenaFiltro &
                     " Order by vwSclSociasConReferencias.nCodigo"

            If XdsReferencia.ExistTable("SociasConReferencia") Then
                XdsReferencia("SociasConReferencia").ExecuteSql(Strsql)
            Else
                XdsReferencia.NewTable(Strsql, "SociasConReferencia")
                XdsReferencia("SociasConReferencia").Retrieve()
            End If

            'Detalle: Referencias de las Socias:
            Strsql = " SELECT nSclReferenciaSociaID, nSclSociaID, NombreSocia, nActiva, CodReferencia, TipoReferencia, dFechaCreacion, AsignadaPor, sObservaciones " &
                     " FROM vwSclReferenciasSocias " & sCadenaFiltro &
                     " Order by nSclReferenciaSociaID"
            If XdsReferencia.ExistTable("Referencias") Then
                XdsReferencia("Referencias").ExecuteSql(Strsql)
            Else
                XdsReferencia.NewTable(Strsql, "Referencias")
                XdsReferencia("Referencias").Retrieve()
            End If

            If XdsReferencia.ExistRelation("SociaConReferencia") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsReferencia.NewRelation("SociaConReferencia", "SociasConReferencia", "Referencias", "nSclSociaID", "nSclSociaID")
            End If

            XdsReferencia.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdSocias.DataSource = XdsReferencia("SociasConReferencia").Source
            Me.grdReferencias.DataSource = XdsReferencia("Referencias").Source

            'Actualizando el caption de los GRIDS
            Me.grdSocias.Caption = " Listado de Socias (" + Me.grdSocias.RowCount.ToString + " registros)"
            Me.grdReferencias.Caption = " Listado de Referencias de Socia (" + Me.grdReferencias.RowCount.ToString + " registros)"
            FormatoReferenciasSocias()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       FormatoReferenciasSocias
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Socias y sus Referencias.
    '-------------------------------------------------------------------------
    Private Sub FormatoReferenciasSocias()
        Try

            'Configuracion del Grid Socias:
            Me.grdSocias.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdSocias.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False

            Me.grdSocias.Splits(0).DisplayColumns("nCodigo").Width = 90
            Me.grdSocias.Splits(0).DisplayColumns("NombreSocia").Width = 200
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").Width = 120
            Me.grdSocias.Splits(0).DisplayColumns("sTelefonoSocia").Width = 90
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").Width = 200

            Me.grdSocias.Columns("nCodigo").Caption = "Código"
            Me.grdSocias.Columns("NombreSocia").Caption = "Nombre Socia"
            Me.grdSocias.Columns("sNumeroCedula").Caption = "Cédula Socia"
            Me.grdSocias.Columns("sTelefonoSocia").Caption = "Teléfono Socia"
            Me.grdSocias.Columns("sDireccionSocia").Caption = "Dirección Socia"

            Me.grdSocias.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("NombreSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sTelefonoSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSocias.Splits(0).DisplayColumns("sDireccionSocia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuración del Grid Referencias de Socia:
            Me.grdReferencias.Splits(0).DisplayColumns("nSclReferenciaSociaID").Visible = False
            Me.grdReferencias.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdReferencias.Splits(0).DisplayColumns("CodReferencia").Visible = False
            Me.grdReferencias.Splits(0).DisplayColumns("NombreSocia").Visible = False

            Me.grdReferencias.Splits(0).DisplayColumns("nActiva").Width = 50
            Me.grdReferencias.Splits(0).DisplayColumns("TipoReferencia").Width = 140
            Me.grdReferencias.Splits(0).DisplayColumns("dFechaCreacion").Width = 120
            Me.grdReferencias.Splits(0).DisplayColumns("AsignadaPor").Width = 200
            Me.grdReferencias.Splits(0).DisplayColumns("sObservaciones").Width = 280

            Me.grdReferencias.Columns("nActiva").Caption = "Activa"
            Me.grdReferencias.Columns("TipoReferencia").Caption = "Tipo de Referencia"
            Me.grdReferencias.Columns("dFechaCreacion").Caption = "Fecha Asignación"
            Me.grdReferencias.Columns("AsignadaPor").Caption = "Asignada Por"
            Me.grdReferencias.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdReferencias.Splits(0).DisplayColumns("nActiva").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencias.Splits(0).DisplayColumns("TipoReferencia").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencias.Splits(0).DisplayColumns("dFechaCreacion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencias.Splits(0).DisplayColumns("AsignadaPor").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdReferencias.Splits(0).DisplayColumns("sObservaciones").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Activa como checkbox y centrado:
            Me.grdReferencias.Columns("nActiva").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdReferencias.Splits(0).DisplayColumns("nActiva").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Campos Fecha:
            Me.grdReferencias.Columns("dFechaCreacion").NumberFormat = "dd/MM/yyyy hh:mm tt"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       tbSocias_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbSocias.
    '-------------------------------------------------------------------------
    Private Sub tbSocias_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocias.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscarSocia()
            Case "toolRefrescar"
                InicializaVariables()
                CargarReferenciaSocia(StrCadena)
            Case "toolImprimirS"
                LlamaImprimir(2) 'Listado de Socias con Referencias Personales
            Case "toolImprimirL"
                LlamaImprimir(3) 'Listado de Referencias Personales
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/07/2008
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Socias con referencias.
    '                       2: Listado de Socias con Malas Referencias
    '                       3: Listado de Referencias Personales de Socias
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir(ByVal ReporteId As Integer)
        Dim ObjFrmSclParametroRpt As New frmSclParametrosPromocion
        Try

            ObjFrmSclParametroRpt.NomRep = ReporteId
            ObjFrmSclParametroRpt.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclParametroRpt.Close()
            ObjFrmSclParametroRpt = Nothing
        End Try
        '    If IntPermiteConsultar = 1 Then
        '        frmVisor.SQLQuery = "Select * From vwSclReferenciasSociasRep " & _
        '                            "Where (nActiva = 1) " & _
        '                            "Order by CodReferencia, NombreSocia"
        '    Else
        '        frmVisor.SQLQuery = "Select * From vwSclReferenciasSociasRep " & _
        '                            "Where (nActiva = 1) and (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
        '                            "Order by CodReferencia, NombreSocia"
        '    End If        
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       tbReferencias_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbReferencias.
    '-------------------------------------------------------------------------
    Private Sub tbReferencias_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbReferencias.ItemClicked
        'Llama al reporte del listado de recibos
        '----------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte

        Try
            Select Case e.ClickedItem.Name
                Case "toolAgregarR"
                    LlamaAgregarReferencia()
                Case "toolModificarR"
                    LlamaModificarReferencia()
                Case "toolInactivarR"
                    LlamaAnularReferencia()
                Case "toolAyudaR"
                    LlamaAyuda()
                Case "toolImprimirR"
                    If Me.grdReferencias.RowCount = 0 Then
                        MsgBox("No Existen referencias grabadas.", MsgBoxStyle.Information)
                        Exit Sub
                    End If
                    frmVisor.CRVReportes.SelectionFormula = " {vwSclSociasConReferenciasRepActa.nSclReferenciaSociaID}=" & XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID")
                    frmVisor.WindowState = FormWindowState.Maximized
                    frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                    frmVisor.NombreReporte = "RepSclCS40.rpt"







                    frmVisor.ShowDialog()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       LlamaAgregarReferencia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditReferenciaSocia para Agregar una referencia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarReferencia()
        Dim ObjFrmSclEditReferencia As New frmSclEditReferenciaSocia
        Try

            ObjFrmSclEditReferencia.ModoFrm = "ADD"

            If Me.grdSocias.RowCount = 0 Then
                ObjFrmSclEditReferencia.IdSocia = 0
            Else
                ObjFrmSclEditReferencia.IdSocia = XdsReferencia("SociasConReferencia").ValueField("nSclSociaID")
            End If

            ObjFrmSclEditReferencia.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclEditReferencia.ShowDialog()

            'Si se ingreso el registro correctamente:
            If ObjFrmSclEditReferencia.IdReferencia <> 0 Then

                'Refrescar registros:
                StrCadena = "Where (nSclSociaId = " & ObjFrmSclEditReferencia.IdSocia & ")"
                CargarReferenciaSocia(StrCadena)
                'Se ubica sobre el registro recién ingresado:
                XdsReferencia("SociasConReferencia").SetCurrentByID("nSclSociaID", ObjFrmSclEditReferencia.IdSocia)
                Me.grdSocias.Row = XdsReferencia("SociasConReferencia").BindingSource.Position
                'Se ubica sobre la referencia recien ingresada:
                XdsReferencia("Referencias").SetCurrentByID("nSclReferenciaSociaID", ObjFrmSclEditReferencia.IdReferencia)
                Me.grdReferencias.Row = XdsReferencia("Referencias").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclEditReferencia.Close()
            ObjFrmSclEditReferencia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       LlamaModificarReferencia
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSclEditReferenciaSocia para Modificar una referencia.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarReferencia()
        Dim ObjFrmSclEditReferencia As New frmSclEditReferenciaSocia
        Try

            Dim StrSql As String
            'No existen Referencias registradas:
            If Me.grdReferencias.RowCount = 0 Then
                MsgBox("No Existen referencias grabadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsReferencia("SociasConReferencia").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Socias de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Referencia esta Inactiva:
            StrSql = "SELECT * FROM SclReferenciaSocia WHERE (nActiva = 0) AND (nSclReferenciaSociaID = " & XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("No puede Modificar Referencias Inactivas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmSclEditReferencia.ModoFrm = "UPD"
            ObjFrmSclEditReferencia.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclEditReferencia.IdSocia = XdsReferencia("SociasConReferencia").ValueField("nSclSociaID")
            ObjFrmSclEditReferencia.IdReferencia = XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID")
            ObjFrmSclEditReferencia.ShowDialog()

            CargarReferenciaSocia(StrCadena)
            XdsReferencia("SociasConReferencia").SetCurrentByID("nSclSociaID", ObjFrmSclEditReferencia.IdSocia)
            Me.grdSocias.Row = XdsReferencia("SociasConReferencia").BindingSource.Position

            XdsReferencia("Referencias").SetCurrentByID("nSclReferenciaSociaID", ObjFrmSclEditReferencia.IdReferencia)
            Me.grdReferencias.Row = XdsReferencia("Referencias").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       LlamaAnularReferencia
    ' Descripción:          Este procedimiento permite Inactivar una referencia.
    '-------------------------------------------------------------------------
    Private Sub LlamaAnularReferencia()
        Dim XcDatos As New BOSistema.Win.XComando
        Dim ObjFrmStbDatoComplemento As New frmStbDatoComplemento
        Dim XdtReferencia As New BOSistema.Win.SclEntSocia.SclReferenciaSociaDataTable
        Dim XdrReferencia As New BOSistema.Win.SclEntSocia.SclReferenciaSociaRow
        Dim Strsql As String

        Try

            Dim intPosicion As Integer
            Dim intPosicionR As Integer
            Dim strCausaAnulacion As String = ""

            'Imposible si no hay referencias registrados:
            If Me.grdReferencias.RowCount = 0 Then
                MsgBox("No Existen referencias grabadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación:
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdsReferencia("SociasConReferencia").ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Inactivar Referencias de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Referencia esta Inactiva:
            Strsql = "SELECT * FROM SclReferenciaSocia WHERE (nActiva = 0) AND (nSclReferenciaSociaID = " & XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID") & ")"
            If RegistrosAsociados(Strsql) Then
                MsgBox("La Referencia esta Inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Solicita al Usuario la Causa de la Anulación
            XdtReferencia.Filter = " nSclReferenciaSociaID = " & XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID")
            XdtReferencia.Retrieve()
            XdrReferencia = XdtReferencia.Current

            ObjFrmStbDatoComplemento.strPrompt = "¿Motivo de Anulación? "
            ObjFrmStbDatoComplemento.strTitulo = "Inactivar Referencia de Socia"
            ObjFrmStbDatoComplemento.intAncho = XdrReferencia.GetColumnLenght("sMotivoInactivacion")
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

            Strsql = " Update SclReferenciaSocia " &
                     " SET nUsuarioModificacionID = '" & InfoSistema.IDCuenta & "', dfechamodificacion = getdate(), sMotivoInactivacion = '" & strCausaAnulacion & "', nActiva = 0 " &
                     " WHERE nSclReferenciaSociaID = " & XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID")
            XcDatos.ExecuteNonQuery(Strsql)
            MsgBox("Referencia Inactivada Exitosamente.", MsgBoxStyle.Information, NombreSistema)

            'Guardar posición actual de la selección
            intPosicion = XdsReferencia("SociasConReferencia").ValueField("nSclSociaID")
            intPosicionR = XdsReferencia("Referencias").ValueField("nSclReferenciaSociaID")
            CargarReferenciaSocia(StrCadena)

            'Ubicar la selección en la posición original
            XdsReferencia("SociasConReferencia").SetCurrentByID("nSclSociaID", intPosicion)
            Me.grdSocias.Row = XdsReferencia("SociasConReferencia").BindingSource.Position
            XdsReferencia("Referencias").SetCurrentByID("nSclReferenciaSociaID", intPosicionR)
            Me.grdReferencias.Row = XdsReferencia("Referencias").BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmStbDatoComplemento.Close()
            ObjFrmStbDatoComplemento = Nothing

            XdtReferencia.Close()
            XdtReferencia = Nothing

            XdrReferencia.Close()
            XdrReferencia = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       LlamaSalir
    ' Descripción:          Este procedimiento permite Salir de la opción.
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
    ' Fecha:                04/07/2008
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
    Private Sub grdSocias_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSocias.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       grdSocias_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSocias.Filter
        Try
            XdsReferencia("SociasConReferencia").FilterLocal(e.Condition)
            Me.grdSocias.Caption = " Listado de Socias (" + Me.grdSocias.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar Socia:
            If Seg.HasPermission("BuscarSociaConReferencias") = False Then
                Me.tbSocias.Items("toolBuscar").Enabled = False
            Else  'Habilita
                Me.tbSocias.Items("toolBuscar").Enabled = True
            End If

            'Agregar Referencia:
            If Seg.HasPermission("AgregarReferenciaSocia") = False Then
                Me.tbReferencias.Items("toolAgregarR").Enabled = False
            Else  'Habilita
                Me.tbReferencias.Items("toolAgregarR").Enabled = True
            End If

            'Editar Referencia:
            If Seg.HasPermission("ModificarReferenciaSocia") = False Then
                Me.tbReferencias.Items("toolModificarR").Enabled = False
            Else  'Habilita
                Me.tbReferencias.Items("toolModificarR").Enabled = True
            End If

            'Inactivar Referencia:
            If Seg.HasPermission("InactivarReferenciaSocia") = False Then
                Me.tbReferencias.Items("toolInactivarR").Enabled = False
            Else  'Habilita
                Me.tbReferencias.Items("toolInactivarR").Enabled = True
            End If

            'Imprimir Listado de Socias con Malas Referencias Activas:
            If Seg.HasPermission("ImprimirListadoSociasConReferencias") = False Then
                Me.tbSocias.Items("toolImprimirS").Enabled = False
            Else  'Habilita
                Me.tbSocias.Items("toolImprimirS").Enabled = True
            End If

            'Imprimir Listado Referencias: 
            If Seg.HasPermission("ImprimirListadoReferenciasSocias") = False Then
                Me.tbSocias.Items("toolImprimirL").Enabled = False
            Else  'Habilita
                Me.tbSocias.Items("toolImprimirL").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       grdSocias_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       de Referencias con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdSocias_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdSocias.RowColChange
        Me.grdReferencias.Caption = " Listado de Referencias de Socia (" + Me.grdReferencias.RowCount.ToString + " registros)"
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       grdReferencias_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una referencia existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdReferencias_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdReferencias.DoubleClick
        Try
            If Seg.HasPermission("ModificarReferenciaSocia") Then
                LlamaModificarReferencia()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdReferencias_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdReferencias.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
    ' Procedure Name:       grdReferencias_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdReferencias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdReferencias.Filter
        Try
            XdsReferencia("Referencias").FilterLocal(e.Condition)
            Me.grdReferencias.Caption = " Listado de Referencias de Socia (" + Me.grdReferencias.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/07/2008
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
            ObjFrmSclBusquedaSocias.IdTipoBusqueda = 3 'Busqueda Por Nombre o Cédula Socias con Referencias.
            ObjFrmSclBusquedaSocias.ShowDialog()
            If ObjFrmSclBusquedaSocias.StrCriterioSocia <> "0" Then
                StrCadena = ObjFrmSclBusquedaSocias.StrCriterioSocia
                CargarReferenciaSocia(StrCadena)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias.Close()
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub


End Class