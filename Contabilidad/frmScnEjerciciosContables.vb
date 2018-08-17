' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                12/12/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnEjerciciosContables.vb
' Descripción:          Formulario muestra Catálogo de Ejercicios Contables
'                       y permite el cierre de períodos y años contables.
'-------------------------------------------------------------------------
Public Class frmScnEjerciciosContables
    '- Declaración de Variables 
    Dim XcDatosG As New BOSistema.Win.XComando
    Dim XdsEjercicios As BOSistema.Win.XDataSet
    Dim nTotalParametros As Integer

    '-- Parametros 
    Dim dFechaInicio As Date
    Dim dFechaFin As Date
    Dim IntPrimerPeriodoID As Integer

    '-- Tabla Temporal:
    Dim StrNombreTablaTmp As String
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       frmScnEjerciciosContables_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan
    '                       variables que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmScnEjerciciosContables_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsEjercicios.Close()
            XdsEjercicios = Nothing

            XcDatosG.Close()
            XcDatosG = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       frmScnEjerciciosContables_Load
    ' Descripción:          Evento Load del formulario donde se inicializan variables
    '                       y se carga listado en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnEjerciciosContables_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarEjercicio()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsEjercicios = New BOSistema.Win.XDataSet

            'Encuentra Parámetros:
            EncuentraParametros()

            'Limpiar los Grids, estructura y Datos:
            Me.grdEjercicio.ClearFields()
            Me.grdPeriodo.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       CargarEjercicio
    ' Descripción:          Este procedimiento permite cargar los
    '                       datos de Ejercicios Contables en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarEjercicio()
        Try
            Dim Strsql As String

            'Ejercicio Contable:
            Strsql = " SELECT a.nScnEjercicioContableID, a.sDescripcion, a.dFechaInicio, a.dFechaFin, a.nCerrado, a.nPrimerEjercicio " & _
                     " FROM  ScnEjercicioContable as a " & _
                     " Order by a.nScnEjercicioContableID"
            If XdsEjercicios.ExistTable("Ejercicio") Then
                XdsEjercicios("Ejercicio").ExecuteSql(Strsql)
            Else
                XdsEjercicios.NewTable(Strsql, "Ejercicio")
                XdsEjercicios("Ejercicio").Retrieve()
            End If

            'Detalle: Períodos del Ejercicio Contable:
            Strsql = " SELECT a.nScnPeriodoContableID, a.nScnEjercicioContableID, a.nStbEstadoPeriodoID, " & _
                     " a.sDescripcionMes, a.nAnio, a.nPeriodo, a.nMes, a.nPrimerPeriodo, a.nUltimoPeriodo, b.sDescripcion AS EstadoCierre, b.sCodigoInterno AS CodigoCierre " & _
                     " FROM  ScnPeriodoContable a INNER JOIN StbValorCatalogo b ON a.nStbEstadoPeriodoID = b.nStbValorCatalogoID " & _
                     " Order by a.nPeriodo"
            If XdsEjercicios.ExistTable("Periodos") Then
                XdsEjercicios("Periodos").ExecuteSql(Strsql)
            Else
                XdsEjercicios.NewTable(Strsql, "Periodos")
                XdsEjercicios("Periodos").Retrieve()
            End If

            If XdsEjercicios.ExistRelation("EjercicioConPeriodos") = False Then
                'Creando la relación entre el Primer Query y el Segundo
                XdsEjercicios.NewRelation("EjercicioConPeriodos", "Ejercicio", "Periodos", "nScnEjercicioContableID", "nScnEjercicioContableID")
            End If

            XdsEjercicios.SincronizarRelaciones()

            'Asignando a las fuentes de datos
            Me.grdEjercicio.DataSource = XdsEjercicios("Ejercicio").Source
            Me.grdPeriodo.DataSource = XdsEjercicios("Periodos").Source

            'Actualizando el caption de los GRIDS
            Me.grdEjercicio.Caption = " Listado de Ejercicios Contables (" + Me.grdEjercicio.RowCount.ToString + " registros)"
            Me.grdPeriodo.Caption = " Listado de Períodos Contables (" + Me.grdPeriodo.RowCount.ToString + " registros)"
            FormatoEjercicioContable()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       FormatoEjercicioContable
    ' Descripción:          Este procedimiento permite configurar los
    '                       datos sobre Ejercicios Contables en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoEjercicioContable()
        Try

            'Configuracion del Grid Ejercicio Contable:
            Me.grdEjercicio.Splits(0).DisplayColumns("nScnEjercicioContableID").Visible = False
            Me.grdEjercicio.Splits(0).DisplayColumns("nPrimerEjercicio").Visible = False

            Me.grdEjercicio.Splits(0).DisplayColumns("sDescripcion").Width = 200
            Me.grdEjercicio.Splits(0).DisplayColumns("dFechaInicio").Width = 90
            Me.grdEjercicio.Splits(0).DisplayColumns("dFechaFin").Width = 90
            Me.grdEjercicio.Splits(0).DisplayColumns("nCerrado").Width = 90

            Me.grdEjercicio.Columns("sDescripcion").Caption = "Descripción Ejercicio"
            Me.grdEjercicio.Columns("dFechaInicio").Caption = "Fecha Inicio"
            Me.grdEjercicio.Columns("dFechaFin").Caption = "Fecha Fin"
            Me.grdEjercicio.Columns("nCerrado").Caption = "Cerrado"

            'Check Box:
            Me.grdEjercicio.Columns("nCerrado").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdEjercicio.Splits(0).DisplayColumns("nCerrado").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdEjercicio.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEjercicio.Splits(0).DisplayColumns("dFechaInicio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEjercicio.Splits(0).DisplayColumns("dFechaFin").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdEjercicio.Splits(0).DisplayColumns("nCerrado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configuracion del Grid Períodos:
            Me.grdPeriodo.Splits(0).DisplayColumns("nScnPeriodoContableID").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("nScnEjercicioContableID").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("nStbEstadoPeriodoID").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("nPeriodo").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("nMes").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("nPrimerPeriodo").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("nUltimoPeriodo").Visible = False
            Me.grdPeriodo.Splits(0).DisplayColumns("CodigoCierre").Visible = False

            Me.grdPeriodo.Splits(0).DisplayColumns("sDescripcionMes").Width = 200
            Me.grdPeriodo.Splits(0).DisplayColumns("nAnio").Width = 90
            Me.grdPeriodo.Splits(0).DisplayColumns("EstadoCierre").Width = 100

            Me.grdPeriodo.Columns("sDescripcionMes").Caption = "Mes Contable"
            Me.grdPeriodo.Columns("nAnio").Caption = "Año"
            Me.grdPeriodo.Columns("EstadoCierre").Caption = "Estado Cierre"

            Me.grdPeriodo.Splits(0).DisplayColumns("sDescripcionMes").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPeriodo.Splits(0).DisplayColumns("nAnio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPeriodo.Splits(0).DisplayColumns("EstadoCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPeriodo.Splits(0).DisplayColumns("nAnio").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       tbEjercicio_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbEjercicio.
    '-------------------------------------------------------------------------
    Private Sub tbEjercicio_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbEjercicio.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregarE"
                LlamaAgregarEjercicio()
            Case "toolEliminarE"
                LlamaEliminarEjercicio()
            Case "toolCerrarE"
                LlamaCerrarEjercicio()
            Case "toolRefrescar"
                InicializaVariables()
                CargarEjercicio()
            Case "toolImprimirL"
                LlamaImprimir()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Ejercicios Contables.
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdEjercicio.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepScnCN10.rpt"
            frmVisor.Text = "Ejercicios Contables"
            frmVisor.SQLQuery = "Select * From vwScnEjerciciosContablesRep Order by nScnEjercicioContableID, nScnPeriodoContableID"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       tbPeriodo_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbPeriodo.
    '-------------------------------------------------------------------------
    Private Sub tbPeriodo_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbPeriodo.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolCerrarP"
                LlamaCerrarPeriodo(0) '0 = Cierre Preliminar
            Case "toolCerrarD"
                LlamaCerrarPeriodo(1) '1 = Cierre Definitivo
            Case "toolAyudaC"
                LlamaAyuda()
        End Select
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	12/12/2007
    ' Procedure name		   	:	EncuentraParametros
    ' Description			   	:	Encontrar parámetros del primer ejercicio contable.
    ' -----------------------------------------------------------------------------------------
    Private Sub EncuentraParametros()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim Strsql As String

            'Fecha de Inicio de Ejercicios Contables en Parámetros:
            Strsql = "SELECT SUBSTRING(sValorParametro, 1, 2) + '/' + SUBSTRING(sValorParametro, 3, 2) + '/' + SUBSTRING(sValorParametro, 5, 4) AS FI " & _
                     "FROM StbValorParametro WHERE (nStbParametroID = 30)"
            dFechaInicio = XcDatos.ExecuteScalar(Strsql)
            'Fecha de Fin de Ejercicios Contables en Parámetros:
            Strsql = "SELECT SUBSTRING(sValorParametro, 1, 2) + '/' + SUBSTRING(sValorParametro, 3, 2) + '/' + SUBSTRING(sValorParametro, 5, 4) AS FI " & _
                     "FROM StbValorParametro WHERE (nStbParametroID = 31)"
            dFechaFin = XcDatos.ExecuteScalar(Strsql)
            'Primer PeriodoId:
            Strsql = "SELECT  sValorParametro FROM  StbValorParametro WHERE (nStbParametroID = 32)"
            IntPrimerPeriodoID = XcDatos.ExecuteScalar(Strsql)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       LlamaAgregarEjercicio
    ' Descripción:          Este procedimiento permite Agregar un nuevo
    '                       Ejercicio Contable con sus 12 períodos.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarEjercicio()
        Dim Trans As BOSistema.Win.Transact
        Dim XcDatos As New BOSistema.Win.XComando
        Trans = Nothing
        Try

            Dim nIntPrimerEjercicio As Integer
            Dim nIntPrimerPeriodo As Integer
            Dim nIntUltimoPeriodo As Integer
            Dim IdEstadoPeriodo As Integer
            Dim dFechaUltimoEjercicio As Date
            Dim i As Integer
            Dim StrSql As String
            Dim sDescripcion As String

            '-- Confirmar Adición del Ejercicio Contable:
            If MsgBox("¿Está seguro de Agregar un Ejercicio?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- Encuentra Estado de Periodo Abierto:
            StrSql = "SELECT StbValorCatalogo.nStbValorCatalogoID FROM StbValorCatalogo INNER JOIN StbCatalogo ON StbValorCatalogo.nStbCatalogoID = StbCatalogo.nStbCatalogoID " & _
                     "WHERE (StbCatalogo.sNombre = 'EstadoPeriodoContable') AND (StbValorCatalogo.sCodigoInterno = '1')"
            IdEstadoPeriodo = XcDatos.ExecuteScalar(StrSql)

            '-- Si es el primer Ejercicio:
            If Me.grdEjercicio.RowCount = 0 Then
                nIntPrimerEjercicio = 1
            Else
                nIntPrimerEjercicio = 0
                StrSql = "SELECT MAX(dFechaFin) AS F FROM ScnEjercicioContable"
                dFechaUltimoEjercicio = XcDatos.ExecuteScalar(StrSql)
                dFechaInicio = DateSerial(Year(dFechaUltimoEjercicio), Month(dFechaUltimoEjercicio), Microsoft.VisualBasic.DateAndTime.Day(dFechaUltimoEjercicio) + 1)
                dFechaFin = DateSerial(Year(dFechaUltimoEjercicio), Month(dFechaUltimoEjercicio) + 12, Microsoft.VisualBasic.DateAndTime.Day(dFechaUltimoEjercicio))
            End If

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transacción:
            Trans.BeginTrans()

            '-- 1. Insertar Ejercicio Contable:
            sDescripcion = NombreMes(Month(dFechaInicio), Year(dFechaInicio)) & " " & Year(dFechaInicio) & " - " & NombreMes(Month(dFechaFin), Year(dFechaFin)) & " " & Year(dFechaFin)
            StrSql = "Insert Into ScnEjercicioContable " & _
                     "(nCerrado, sDescripcion, dFechaInicio, dFechaFin, nPrimerEjercicio, nUsuarioCreacionID, dFechaCreacion) " & _
                     " Values (0, '" & sDescripcion & "', '" & Format(dFechaInicio, "yyyy-MM-dd") & "', '" & Format(dFechaFin, "yyyy-MM-dd") & "', " & nIntPrimerEjercicio & ", " & InfoSistema.IDCuenta & ", GetDate())"
            Trans.ExecuteSql(StrSql)

            '-- 2. Insertar Períodos Contables:
            Dim cont% : cont = Month(dFechaInicio)
            Dim Annio% : Annio = Year(dFechaInicio)
            For i = 1 To 12
                '-- Determinar Número de Período:
                If i = 1 Then
                    nIntPrimerPeriodo = 1
                    nIntUltimoPeriodo = 0
                ElseIf i = 12 Then
                    nIntPrimerPeriodo = 0
                    nIntUltimoPeriodo = 1
                Else
                    nIntPrimerPeriodo = 0
                    nIntUltimoPeriodo = 0
                End If
                '-- Insertar Periodo:
                StrSql = "INSERT INTO ScnPeriodoContable " & _
                         "(nScnEjercicioContableID, nStbEstadoPeriodoID, nAnio, nPeriodo, nMes, sDescripcionMes, nPrimerPeriodo, nUltimoPeriodo, nUsuarioCreacionID, dFechaCreacion) " & _
                         "SELECT a.Id, " & IdEstadoPeriodo & ", " & Annio & ", " & i & ", " & cont & ", '" & NombreMes(cont, Annio) & "', " & nIntPrimerPeriodo & ", " & nIntUltimoPeriodo & ", " & InfoSistema.IDCuenta & ", GetDate()  " & _
                         "FROM (SELECT MAX(nScnEjercicioContableID) as Id FROM ScnEjercicioContable) a"
                Trans.ExecuteSql(StrSql)
                cont = cont + 1
                If cont = 13 Then 'En caso de años fiscales.
                    cont = 1          'Mes de Enero
                    Annio = Annio + 1 'Siguiente Ejercicio
                End If
            Next i

            '-- Finaliza Transacción:
            Trans.Commit()

            '-- Se ubica sobre el registro recien agregado:
            CargarEjercicio()
            XdsEjercicios("Ejercicio").SetCurrentByID("nScnEjercicioContableID", XcDatos.ExecuteScalar("SELECT MAX(nScnEjercicioContableID) AS Id FROM ScnEjercicioContable"))
            Me.grdEjercicio.Row = XdsEjercicios("Ejercicio").BindingSource.Position

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       LlamaEliminarEjercicio
    ' Descripción:          Este procedimiento permite Eliminar un Ejercicio
    '                       Contable existente con sus doce períodos.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarEjercicio()
        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing
        Try
            Dim StrSql As String
            'Imposible si no hay ningún registro activo:
            If Me.grdEjercicio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si el Ejercicio esta Cerrado:
            If XdsEjercicios("Ejercicio").ValueField("nCerrado") = "1" Then
                MsgBox("El Ejercicio se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si hay al menos un Período Cerrado en Forma 
            'Definitiva para el Ejercicio Contable seleccionado.
            StrSql = "SELECT b.sCodigoInterno " & _
                     "FROM ScnPeriodoContable AS a INNER JOIN StbValorCatalogo AS b ON a.nStbEstadoPeriodoID = b.nStbValorCatalogoID  " & _
                     "WHERE (a.nScnEjercicioContableID = " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ") AND (b.sCodigoInterno = '3')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen períodos Cerrados en forma Definitiva.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si hay Transacciones Contables en el rango de Fechas del Ejercicio:
            StrSql = "SELECT * FROM ScnTransaccionContable " & _
                     "WHERE (dFechaTransaccion BETWEEN CONVERT(DATETIME, '" & Format(XdsEjercicios("Ejercicio").ValueField("dFechaInicio"), "yyyy-MM-dd") & "', 102) AND CONVERT(DATETIME, '" & Format(XdsEjercicios("Ejercicio").ValueField("dFechaFin"), "yyyy-MM-dd") & "', 102))"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Transacciones Contables generadas.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible eliminar si existen ejercicios superiores:
            StrSql = "SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
                     "WHERE  (nScnEjercicioContableID > " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Ejercicios Contables superiores.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible eliminar si existen registros en Saldos:
            StrSql = "SELECT ScnPeriodoContable.nScnEjercicioContableID " & _
                     "FROM ScnPeriodoContable INNER JOIN ScnSaldoContable ON ScnPeriodoContable.nScnPeriodoContableID = ScnSaldoContable.nScnPeriodoContableID " & _
                     "WHERE (ScnPeriodoContable.nScnEjercicioContableID = " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Saldos Contables registrados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el Ejercicio seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.Yes Then
                'Instanciar Trans:
                Trans = New BOSistema.Win.Transact
                'Inicio de la Transaccion:
                Trans.BeginTrans()

                '-- 1. Eliminar Períodos Contables:
                StrSql = "Delete From ScnPeriodoContable Where (nScnEjercicioContableID = " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
                Trans.ExecuteSql(StrSql)
                '-- 2. Eliminar Ejercicio Cntable: 
                StrSql = "Delete From ScnEjercicioContable Where (nScnEjercicioContableID = " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
                Trans.ExecuteSql(StrSql)

                'Finaliza Transacción:
                Trans.Commit()

                CargarEjercicio()
                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdEjercicio.Caption = "Listado de Ejercicios Contables (" + Me.grdEjercicio.RowCount.ToString + " registros)"
                Me.grdPeriodo.Caption = " Listado de Períodos Contables (" + Me.grdPeriodo.RowCount.ToString + " registros)"
            End If

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       ValidaCierrePeriodo
    ' Descripción:          Esta función permite Validar la posibilidad de cerrar
    '                       un período contable.
    '-------------------------------------------------------------------------
    Private Function ValidaCierrePeriodo(ByVal nCierreDefinitivo As Integer) As Boolean
        Dim XcDatos As New BOSistema.Win.XComando

        Try
            ValidaCierrePeriodo = True
            Dim StrSql As String
            Dim StrEstadoAnterior As String

            'Imposible si no hay ningún Ejercicio activo:
            If Me.grdEjercicio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                ValidaCierrePeriodo = False
                Exit Function
            End If

            'Imposible si no hay ningún período:
            If Me.grdPeriodo.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                ValidaCierrePeriodo = False
                Exit Function
            End If

            'Imposible si el Ejercicio esta Cerrado:
            If XdsEjercicios("Ejercicio").ValueField("nCerrado") = "1" Then
                MsgBox("El Ejercicio se encuentra Cerrado.", MsgBoxStyle.Information)
                ValidaCierrePeriodo = False
                Exit Function
            End If

            'Imposible si el Período esta Cerrado en forma Definitiva:
            If XdsEjercicios("Periodos").ValueField("CodigoCierre") = "3" Then
                MsgBox("El Período se encuentra Cerrado en forma Definitiva.", MsgBoxStyle.Information)
                ValidaCierrePeriodo = False
                Exit Function
            End If

            'Si es el primer Ejercicio: No puede cerrar períodos inferiores al de parámetros:
            If XdsEjercicios("Ejercicio").ValueField("nPrimerEjercicio") = "1" Then
                If CInt(XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID")) < IntPrimerPeriodoID Then
                    MsgBox("Imposible Cerrar períodos inferiores al período de inicio" & Chr(13) & "de la operación Contable indicado en parámetros.", MsgBoxStyle.Information)
                    ValidaCierrePeriodo = False
                    Exit Function
                End If
            End If

            'Si no es el primer mes de parámetros:
            If CInt(XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID")) > IntPrimerPeriodoID Then
                'Encuentra Estado del Mes Anterior:
                StrSql = "SELECT C.sCodigoInterno " & _
                         "FROM ScnPeriodoContable AS P INNER JOIN (SELECT MAX(nScnPeriodoContableID) AS IdPeriodoAnterior FROM  (SELECT nScnPeriodoContableID FROM ScnPeriodoContable " & _
                         "WHERE (nScnPeriodoContableID < " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ")) AS b) AS a ON P.nScnPeriodoContableID = a.IdPeriodoAnterior INNER JOIN StbValorCatalogo AS C ON P.nStbEstadoPeriodoID = C.nStbValorCatalogoID"
                StrEstadoAnterior = XcDatos.ExecuteScalar(StrSql)
                '-- Si es Cierre Preliminar: Mes anterior NO debe estar Abierto:
                If nCierreDefinitivo = 0 Then
                    If StrEstadoAnterior = "1" Then
                        MsgBox("Antes debe Cerrar el Período anterior.", MsgBoxStyle.Information)
                        ValidaCierrePeriodo = False
                        Exit Function
                    End If
                    '-- Si es Cierre Definitivo: 
                Else
                    '1. Mes anterior debe estar Cerrado D:
                    If StrEstadoAnterior <> "3" Then
                        MsgBox("Antes debe Cerrar el Período anterior" & Chr(13) & "en forma Definitiva.", MsgBoxStyle.Information)
                        ValidaCierrePeriodo = False
                        Exit Function
                    End If
                    '2. Si no el el primer Año: Año anterior debe estar Cerrado:
                    If XdsEjercicios("Ejercicio").ValueField("nPrimerEjercicio") <> "1" Then
                        'Encuentra Estado del Ejercicio Anterior:
                        StrSql = "SELECT  E.nCerrado FROM (SELECT MAX(nScnEjercicioContableID) AS IdEjercicio " & _
                                 "FROM  (SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
                                 "WHERE (nScnEjercicioContableID < " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")) AS b) AS a INNER JOIN ScnEjercicioContable AS E ON a.IdEjercicio = E.nScnEjercicioContableID"
                        If XcDatos.ExecuteScalar(StrSql) = 0 Then
                            MsgBox("Para cerrar el Período en forma Definitiva" & Chr(13) & "Antes debe Cerrar el Ejercicio anterior.", MsgBoxStyle.Information)
                            ValidaCierrePeriodo = False
                            Exit Function
                        End If
                    End If
                End If
            End If

            'Si el mes a cerrar es el último y no hay siguiente ejercicio:
            If XdsEjercicios("Periodos").ValueField("nUltimoPeriodo") = "1" Then
                StrSql = "SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
                         "WHERE  (nScnEjercicioContableID > " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("Antes debe generar el siguiente Ejercicio Contable.", MsgBoxStyle.Information)
                    ValidaCierrePeriodo = False
                    Exit Function
                End If
            End If

            'Deben existir parámetros de Cuentas Contables para el Cierre Anual
            'por cada Fuente de Fondos (Tipos de Afectación: 7, 8, 9, 10):
            '7: Utilidad o Pérdida del Ejercicio Anterior
            '8: Utilidad o Pérdida del Ejercicio Actual
            '9: Resumen de Ingresos y Gastos
            '10: Patrimonio
            StrSql = "SELECT COUNT(nScnFuenteFinanciamientoID) AS TFuentes FROM  ScnFuenteFinanciamiento " & _
                     "WHERE (nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM  ScnTransaccionContable))"
            nTotalParametros = XcDatos.ExecuteScalar(StrSql) * 4
            '-- Total de Parametros Registrados:
            StrSql = "SELECT COUNT(ScnTransaccionParametros.nScnTransaccionParametroID) AS TParam " & _
                     "FROM  ScnTransaccionParametros INNER JOIN StbValorCatalogo ON ScnTransaccionParametros.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE  (ScnTransaccionParametros.nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM ScnTransaccionContable)) AND (StbValorCatalogo.sCodigoInterno = 'CC')"
            If XcDatos.ExecuteScalar(StrSql) <> nTotalParametros Then
                MsgBox("Antes debe Registrar los Parametros de Cierre" & Chr(13) & "Contable por cada Fuente de Fondos.", MsgBoxStyle.Information)
                ValidaCierrePeriodo = False
                Exit Function
            End If

        Catch ex As Exception
            ValidaCierrePeriodo = False
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Function

    '' ------------------------------------------------------------------------
    '' Autor:                Yesenia Gutiérrez
    '' Fecha:                12/12/2007
    '' Procedure Name:       LlamaCerrarPeriodo
    '' Descripción:          Este procedimiento permite Cerrar un Período
    ''                       Contable existente en forma preliminar o definitiva.
    ''                       nCierreDefinitivo = 0: Cierre Preliminar
    ''                       nCierreDefinitivo = 1: Cierre Definitivo
    ''-------------------------------------------------------------------------
    'Private Sub LlamaCerrarPeriodo(ByVal nCierreDefinitivo As Integer)
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable
    '    Try

    '        Dim StrSql As String
    '        Dim IntSiguientePeriodoId As Integer   '-- Periodo posterior al Mes Contable a Cerrar
    '        Dim IntUltimoPeriodoCerrado As Integer '-- Ultimo Mes Cerrado en forma Definitiva
    '        Dim IntPeriodoId As Integer

    '        If ValidaCierrePeriodo(nCierreDefinitivo) Then
    '            '-- Encuentra Ultimo Periodo Cerrado en Forma Definitiva:
    '            IntUltimoPeriodoCerrado = XcDatos.ExecuteScalar("SELECT sValorParametro FROM StbValorParametro WHERE (nStbValorParametroID = 33)")
    '            '-- Encuentra Siguiente Periodo despues del Mes a Cerrar:
    '            IntSiguientePeriodoId = XcDatos.ExecuteScalar("SELECT TOP (1) PERCENT nScnPeriodoContableID FROM ScnPeriodoContable WHERE (nScnPeriodoContableID > " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") ORDER BY nScnPeriodoContableID")
    '            '-- Validar Posibles saldos Negativos:
    '            StrSql = "Select a.SaldoFinalCordobas From " & _
    '                     "(SELECT (CASE a.nCuentaDeudora WHEN 1 THEN a.nSaldoInicialPeriodoC + b.nDebitoPeriodoC - b.nCreditoPeriodoC ELSE a.nSaldoInicialPeriodoC - b.nDebitoPeriodoC + b.nCreditoPeriodoC END) AS 'SaldoFinalCordobas' " & _
    '                     "FROM (SELECT b.nSaldoInicialPeriodoC, b.nSaldoInicialPeriodoD, a.nScnCatalogoContableID, a.nScnPeriodoContableID, a.nCuentaDeudora " & _
    '                     "FROM (SELECT b.nScnCatalogoContableID, MIN(b.nScnPeriodoContableID) AS nScnPeriodoContableID, a.nCuentaDeudora FROM ScnCatalogoContable a INNER JOIN ScnSaldoContable b ON  a.nScnCatalogoContableID = b.nScnCatalogoContableID " & _
    '                     "WHERE (b.nScnPeriodoContableID BETWEEN " & IntUltimoPeriodoCerrado & " AND " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") GROUP BY b.nScnCatalogoContableID, a.nCuentaDeudora ) a INNER JOIN ScnSaldoContable b ON (a.nScnCatalogoContableID = b.nScnCatalogoContableID) AND (a.nScnPeriodoContableID = b.nScnPeriodoContableID)) a " & _
    '                     "INNER JOIN (SELECT SUM(b.nDebitoPeriodoC) AS nDebitoPeriodoC, SUM(b.nDebitoPeriodoD) AS nDebitoPeriodoD, SUM(b.nCreditoPeriodoC) AS nCreditoPeriodoC, SUM(b.nCreditoPeriodoD) AS nCreditoPeriodoD, b.nScnCatalogoContableID FROM ScnSaldoContable b " & _
    '                     "WHERE (b.nScnPeriodoContableID BETWEEN " & IntUltimoPeriodoCerrado & " AND " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") GROUP BY b.nScnCatalogoContableID ) b  ON a.nScnCatalogoContableID = b.nScnCatalogoContableID ) a Where a.SaldoFinalCordobas < 0"
    '            If RegistrosAsociados(StrSql) Then
    '                MsgBox("Imposible Cerrar Mes Contable." & Chr(13) & Chr(13) & "Con ello se generarían Saldos de Apertura" & Chr(13) & "Negativos en el siguiente Período.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '            '-- Confirmar Cierre:
    '            If MsgBox("¿Está seguro de Cerrar el Período de forma " & IIf(nCierreDefinitivo = 0, "Preliminar", "Definitiva") & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
    '                Exit Sub
    '            End If
    '            '-- *****************************************************************************************
    '            '-- **************************** Cierre de Período Contable *********************************
    '            '-- *****************************************************************************************
    '            '-- Poner el cursor en un estado de Ocupado:
    '            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    '            '============================================================================================
    '            '-- 1. Crear Tabla Temporal: 
    '            'CrearTablaTemporalM()
    '            Randomize()
    '            StrNombreTablaTmp = "TmpScnCierreMensual" & InfoSistema.LoginName & Trim(Str(Int((9999 * Rnd()) + 1)))
    '            'Si la tabla ya existe en tempDb eliminar la misma:
    '            StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
    '            If XcDatos.ExecuteScalar(StrSql) > 0 Then
    '                StrSql = "Drop Table  ##" & StrNombreTablaTmp
    '                XcDatos.ExecuteNonQuery(StrSql)
    '            End If
    '            'Crea la Tabla en: System Databases: tempDb: Temporary Tables
    '            StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
    '                                "[nFuenteID] [int] NOT NULL , " & _
    '                                "[nScnPeriodoContableID] [int] NOT NULL , " & _
    '                                "[nScnUtilidadPeriodoID] [int] NOT NULL , " & _
    '                                "[nScnPatrimonioID] [int] NOT NULL , " & _
    '                                "[nCuentaDeudora] [tinyint] NOT NULL , " & _
    '                                "[sTipoCuenta] [varchar] (1) NOT NULL , " & _
    '                                "[nSaldoC] [numeric] (18, 2) NOT NULL , " & _
    '                                "[nSaldoD] [numeric] (18, 2) NOT NULL)"
    '            XcDatos.ExecuteNonQuery(StrSql)
    '            '============================================================================================

    '            '============================================================================================
    '            '-- 2. Inserta Detalles de Transacciones por Fuente de Fondos en Tabla Temporal:
    '            'CargarTablaTemporalM(XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID"))
    '            Dim IntRegistros As Integer
    '            Dim IdUtilidadPeriodo As Integer
    '            Dim IdPatrimonio As Integer

    '            '-- Fuentes de Financiamiento que tienen Movimientos Contables:
    '            StrSql = " SELECT  ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnSaldoContable.nScnPeriodoContableID, ScnCatalogoContable.nCuentaDeudora, ScnCatalogoContable.sTipoCuenta, " & _
    '                     " CASE ScnCatalogoContable.nCuentaDeudora WHEN 1 THEN SUM(ScnSaldoContable.nDebitoPeriodoC) - SUM(ScnSaldoContable.nCreditoPeriodoC) ELSE SUM(ScnSaldoContable.nCreditoPeriodoC) - SUM(ScnSaldoContable.nDebitoPeriodoC)  END AS SaldoC, " & _
    '                     " CASE ScnCatalogoContable.nCuentaDeudora WHEN 1 THEN SUM(ScnSaldoContable.nDebitoPeriodoD) - SUM(ScnSaldoContable.nCreditoPeriodoD) ELSE SUM(ScnSaldoContable.nCreditoPeriodoD) - SUM(ScnSaldoContable.nDebitoPeriodoD)  END AS SaldoD " & _
    '                     " FROM  ScnSaldoContable INNER JOIN ScnCatalogoContable ON ScnSaldoContable.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
    '                     " WHERE  (ScnCatalogoContable.nCuentaDetalle = 1) AND (ScnSaldoContable.nScnPeriodoContableID = " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") " & _
    '                     " GROUP BY ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnCatalogoContable.sTipoCuenta, ScnCatalogoContable.nCuentaDeudora, ScnSaldoContable.nScnPeriodoContableID " & _
    '                     " HAVING  (ScnCatalogoContable.sTipoCuenta = 'I' OR ScnCatalogoContable.sTipoCuenta = 'E') " & _
    '                     " ORDER BY ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnCatalogoContable.sTipoCuenta DESC"
    '            XdtTmpCuentas.ExecuteSql(StrSql)
    '            IntRegistros = XdtTmpCuentas.Count

    '            'Para cada una de las Fuentes de Financiamiento:
    '            While IntRegistros > 0
    '                '-- Inserta Registro: 
    '                'StrSql = " Select * From ##" & StrNombreTablaTmp & " Where (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                StrSql = " Select count(*) From ##" & StrNombreTablaTmp & " Where (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                If XcDatos.ExecuteScalar(StrSql) = 0 Then 'RegistrosAsociados(StrSql) = False 
    '                    '-- Encuentra Cuenta de Utilidad del Periodo:
    '                    StrSql = "SELECT P.nScnCatalogoContableID FROM ScnTransaccionParametros P INNER JOIN StbValorCatalogo C ON P.nStbTipoAfectacionID = C.nStbValorCatalogoID WHERE (C.sCodigoInterno = '8') AND (P.nScnFuenteFinanciamientoID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                    IdUtilidadPeriodo = XcDatos.ExecuteScalar(StrSql)

    '                    '-- Encuentra Cuenta de Patrimonio:
    '                    StrSql = "SELECT P.nScnCatalogoContableID FROM ScnTransaccionParametros P INNER JOIN StbValorCatalogo C ON P.nStbTipoAfectacionID = C.nStbValorCatalogoID WHERE (C.sCodigoInterno = '10') AND (P.nScnFuenteFinanciamientoID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                    IdPatrimonio = XcDatos.ExecuteScalar(StrSql)

    '                    '-- Inserta registro en Tabla Temporal:
    '                    If XdtTmpCuentas.ValueField("sTipoCuenta") = "I" Then
    '                        StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
    '                                 " nFuenteID, nScnPeriodoContableID, nScnUtilidadPeriodoID, nScnPatrimonioID, nCuentaDeudora, sTipoCuenta, " & _
    '                                 " nSaldoC, nSaldoD) " & _
    '                                 " Values (" & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ", " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ", " & IdUtilidadPeriodo & ", " & IdPatrimonio & ", " & XdtTmpCuentas.ValueField("nCuentaDeudora") & ", '" & XdtTmpCuentas.ValueField("sTipoCuenta") & "' " & _
    '                                 " ," & XdtTmpCuentas.ValueField("SaldoC") & ", " & XdtTmpCuentas.ValueField("SaldoD") & ")"
    '                    Else 'Solo hay egresos para la Fuente:
    '                        StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
    '                                 " nFuenteID, nScnPeriodoContableID, nScnUtilidadPeriodoID, nScnPatrimonioID, nCuentaDeudora, sTipoCuenta, " & _
    '                                 " nSaldoC, nSaldoD) " & _
    '                                 " Values (" & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ", " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ", " & IdUtilidadPeriodo & ", " & IdPatrimonio & ", " & XdtTmpCuentas.ValueField("nCuentaDeudora") & ", '" & XdtTmpCuentas.ValueField("sTipoCuenta") & "' " & _
    '                                 " ," & XdtTmpCuentas.ValueField("SaldoC") * -1 & ", " & XdtTmpCuentas.ValueField("SaldoD") * -1 & ")"
    '                    End If

    '                Else 'Al haber Ordenado por Tipo de Cuenta la Segunda Cuenta es la de Egresos por eso se resta al ingreso:
    '                    StrSql = " UPDATE ##" & StrNombreTablaTmp & " SET " & _
    '                             " nSaldoC = nSaldoC - " & XdtTmpCuentas.ValueField("SaldoC") & "," & _
    '                             " nSaldoD = nSaldoD - " & XdtTmpCuentas.ValueField("SaldoD") & _
    '                             " WHERE (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                End If
    '                XcDatos.ExecuteNonQuery(StrSql)
    '                '------------------------------
    '                XdtTmpCuentas.Source.MoveNext()
    '                IntRegistros = IntRegistros - 1
    '            End While
    '            '============================================================================================


    '            '-- Cerrar Periodo Contable: 
    '            'CerrarPeriodo(XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID"), nCierreDefinitivo, IntSiguientePeriodoId, IntUltimoPeriodoCerrado)
    '            StrSql = " EXEC spScnCerrarMesContable " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & "," & _
    '                     nCierreDefinitivo & "," & IntSiguientePeriodoId & "," & IntUltimoPeriodoCerrado & "," & InfoSistema.IDCuenta & ", '" & StrNombreTablaTmp & "'"
    '            IntPeriodoId = XcDatos.ExecuteScalar(StrSql)
    '            If IntPeriodoId = 0 Then
    '                MsgBox("El Cierre Contable no pudo Ejecutarse.", MsgBoxStyle.Information, NombreSistema)
    '            Else
    '                MsgBox("El Período Contable ha sido Cerrado.", MsgBoxStyle.Information, NombreSistema)
    '            End If

    '            '============================================================================================
    '            '-- 3. Eliminar Tabla Temporal:
    '            'EliminarTablaTemporal()
    '            'StrSql = "Drop Table ##" & StrNombreTablaTmp
    '            'XcDatos.ExecuteNonQuery(StrSql)
    '            StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
    '            If XcDatos.ExecuteScalar(StrSql) > 0 Then
    '                StrSql = "Drop Table  ##" & StrNombreTablaTmp
    '                XcDatos.ExecuteNonQuery(StrSql)
    '            End If
    '            '============================================================================================

    '            '-- Poner el cursor en un estado de desocupado:
    '            Me.Cursor = System.Windows.Forms.Cursors.Default
    '            InicializaVariables()
    '            CargarEjercicio()
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing

    '        XdtTmpCuentas.Close()
    '        XdtTmpCuentas = Nothing
    '    End Try
    'End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       LlamaCerrarPeriodo
    ' Descripción:          Este procedimiento permite Cerrar un Período
    '                       Contable existente en forma preliminar o definitiva.
    '                       nCierreDefinitivo = 0: Cierre Preliminar
    '                       nCierreDefinitivo = 1: Cierre Definitivo
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrarPeriodo(ByVal nCierreDefinitivo As Integer)

        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
        XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable
        Try


            Dim StrSql As String
            Dim IntSiguientePeriodoId As Integer   '-- Periodo posterior al Mes Contable a Cerrar
            Dim IntUltimoPeriodoCerrado As Integer '-- Ultimo Mes Cerrado en forma Definitiva
            Dim IntPeriodoId As Integer

            '*** Para cargar Tabla Temporal:
            Dim IntRegistros As Integer
            Dim IdUtilidadPeriodo As Integer
            Dim IdPatrimonio As Integer
            Dim intPosicion As Integer
            Dim intPosicionS As Integer
            '***

            If ValidaCierrePeriodo(nCierreDefinitivo) Then
                '-- Encuentra Ultimo Periodo Cerrado en Forma Definitiva:
                IntUltimoPeriodoCerrado = XcDatos.ExecuteScalar("SELECT sValorParametro FROM StbValorParametro WHERE (nStbValorParametroID = 33)")
                '-- Encuentra Siguiente Periodo despues del Mes a Cerrar:
                IntSiguientePeriodoId = XcDatos.ExecuteScalar("SELECT TOP (1) PERCENT nScnPeriodoContableID FROM ScnPeriodoContable WHERE (nScnPeriodoContableID > " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") ORDER BY nScnPeriodoContableID")
                '-- Validar Posibles saldos Negativos:
                'StrSql = "Select a.SaldoFinalCordobas From " & _
                '         "(SELECT (CASE a.nCuentaDeudora WHEN 1 THEN a.nSaldoInicialPeriodoC + b.nDebitoPeriodoC - b.nCreditoPeriodoC ELSE a.nSaldoInicialPeriodoC - b.nDebitoPeriodoC + b.nCreditoPeriodoC END) AS 'SaldoFinalCordobas' " & _
                '         "FROM (SELECT b.nSaldoInicialPeriodoC, b.nSaldoInicialPeriodoD, a.nScnCatalogoContableID, a.nScnPeriodoContableID, a.nCuentaDeudora " & _
                '         "FROM (SELECT b.nScnCatalogoContableID, MIN(b.nScnPeriodoContableID) AS nScnPeriodoContableID, a.nCuentaDeudora FROM ScnCatalogoContable a INNER JOIN ScnSaldoContable b ON  a.nScnCatalogoContableID = b.nScnCatalogoContableID " & _
                '         "WHERE (b.nScnPeriodoContableID BETWEEN " & IntUltimoPeriodoCerrado & " AND " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") GROUP BY b.nScnCatalogoContableID, a.nCuentaDeudora ) a INNER JOIN ScnSaldoContable b ON (a.nScnCatalogoContableID = b.nScnCatalogoContableID) AND (a.nScnPeriodoContableID = b.nScnPeriodoContableID)) a " & _
                '         "INNER JOIN (SELECT SUM(b.nDebitoPeriodoC) AS nDebitoPeriodoC, SUM(b.nDebitoPeriodoD) AS nDebitoPeriodoD, SUM(b.nCreditoPeriodoC) AS nCreditoPeriodoC, SUM(b.nCreditoPeriodoD) AS nCreditoPeriodoD, b.nScnCatalogoContableID FROM ScnSaldoContable b " & _
                '         "WHERE (b.nScnPeriodoContableID BETWEEN " & IntUltimoPeriodoCerrado & " AND " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") GROUP BY b.nScnCatalogoContableID ) b  ON a.nScnCatalogoContableID = b.nScnCatalogoContableID ) a Where a.SaldoFinalCordobas < 0"
                StrSql = "Select a.SaldoFinalCordobas From " & _
                         "(SELECT (CASE a.nCuentaDeudora WHEN 1 THEN a.nSaldoInicialPeriodoC + b.nDebitoPeriodoC - b.nCreditoPeriodoC ELSE a.nSaldoInicialPeriodoC - b.nDebitoPeriodoC + b.nCreditoPeriodoC END) AS 'SaldoFinalCordobas' " & _
                         "FROM (SELECT b.nSaldoInicialPeriodoC, b.nSaldoInicialPeriodoD, a.nScnCatalogoContableID, a.nScnPeriodoContableID, a.nCuentaDeudora " & _
                         "FROM (SELECT b.nScnCatalogoContableID, MIN(b.nScnPeriodoContableID) AS nScnPeriodoContableID, a.nCuentaDeudora FROM ScnCatalogoContable a INNER JOIN ScnSaldoContable b ON  a.nScnCatalogoContableID = b.nScnCatalogoContableID " & _
                         "WHERE (b.nScnPeriodoContableID BETWEEN " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & " AND " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") GROUP BY b.nScnCatalogoContableID, a.nCuentaDeudora ) a INNER JOIN ScnSaldoContable b ON (a.nScnCatalogoContableID = b.nScnCatalogoContableID) AND (a.nScnPeriodoContableID = b.nScnPeriodoContableID)) a " & _
                         "INNER JOIN (SELECT SUM(b.nDebitoPeriodoC) AS nDebitoPeriodoC, SUM(b.nDebitoPeriodoD) AS nDebitoPeriodoD, SUM(b.nCreditoPeriodoC) AS nCreditoPeriodoC, SUM(b.nCreditoPeriodoD) AS nCreditoPeriodoD, b.nScnCatalogoContableID FROM ScnSaldoContable b " & _
                         "WHERE (b.nScnPeriodoContableID BETWEEN " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & " AND " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") GROUP BY b.nScnCatalogoContableID ) b  ON a.nScnCatalogoContableID = b.nScnCatalogoContableID ) a Where a.SaldoFinalCordobas < 0"
                'If RegistrosAsociados(StrSql) Then
                '    REM Por Solicitud de Contabilidad solo advertir y no validar:
                '    REM If MsgBox("¿Está seguro de Cerrar el Mes Contable?" & Chr(13) & "Con ello se generarían Saldos de Apertura" & Chr(13) & "Negativos en el siguiente Período.", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                '    MsgBox("Imposible Cerrar Mes Contable." & Chr(13) & Chr(13) & "Con ello se generarían Saldos de Apertura" & Chr(13) & "Negativos en el siguiente Período.", MsgBoxStyle.Information)
                '    Exit Sub
                '    REM End If
                'End If
                '-- Confirmar Cierre:
                If MsgBox("¿Está seguro de Cerrar el Período de forma " & IIf(nCierreDefinitivo = 0, "Preliminar", "Definitiva") & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                    Exit Sub
                End If

                '-- *****************************************************************************************
                '-- **************************** Cierre de Período Contable *********************************
                '-- *****************************************************************************************
                '-- Poner el cursor en un estado de Ocupado:
                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                intPosicion = XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID")
                intPosicionS = XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID")

                '============================================================================================
                '-- 1. Crear Tabla Temporal: 
                'CrearTablaTemporalM()
                Randomize()
                StrNombreTablaTmp = "TmpScnCierreMensual" & InfoSistema.LoginName & Trim(Str(Int((9999 * Rnd()) + 1)))
                'Si la tabla ya existe en tempDb eliminar la misma:
                StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
                If XcDatos.ExecuteScalar(StrSql) > 0 Then
                    StrSql = "Drop Table  ##" & StrNombreTablaTmp
                    XcDatos.ExecuteNonQuery(StrSql)
                End If

                'Instanciar Trans:
                Trans = New BOSistema.Win.Transact
                'Inicio la Transaccion:
                Trans.BeginTrans()

                'Crea la Tabla en: System Databases: tempDb: Temporary Tables
                StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
                                    "[nFuenteID] [int] NOT NULL , " & _
                                    "[nScnPeriodoContableID] [int] NOT NULL , " & _
                                    "[nScnUtilidadPeriodoID] [int] NOT NULL , " & _
                                    "[nScnPatrimonioID] [int] NOT NULL , " & _
                                    "[nCuentaDeudora] [tinyint] NOT NULL , " & _
                                    "[sTipoCuenta] [varchar] (1) NOT NULL , " & _
                                    "[nSaldoC] [numeric] (18, 2) NOT NULL , " & _
                                    "[nSaldoD] [numeric] (18, 2) NOT NULL)"
                Trans.ExecuteSql(StrSql)
                '============================================================================================

                '============================================================================================
                '-- 2. Inserta Detalles de Transacciones por Fuente de Fondos en Tabla Temporal:
                'CargarTablaTemporalM(XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID"))
                '-- Fuentes de Financiamiento que tienen Movimientos Contables:
                StrSql = " SELECT  ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnSaldoContable.nScnPeriodoContableID, ScnCatalogoContable.nCuentaDeudora, ScnCatalogoContable.sTipoCuenta, " & _
                         " CASE ScnCatalogoContable.nCuentaDeudora WHEN 1 THEN SUM(ScnSaldoContable.nDebitoPeriodoC) - SUM(ScnSaldoContable.nCreditoPeriodoC) ELSE SUM(ScnSaldoContable.nCreditoPeriodoC) - SUM(ScnSaldoContable.nDebitoPeriodoC)  END AS SaldoC, " & _
                         " CASE ScnCatalogoContable.nCuentaDeudora WHEN 1 THEN SUM(ScnSaldoContable.nDebitoPeriodoD) - SUM(ScnSaldoContable.nCreditoPeriodoD) ELSE SUM(ScnSaldoContable.nCreditoPeriodoD) - SUM(ScnSaldoContable.nDebitoPeriodoD)  END AS SaldoD " & _
                         " FROM  ScnSaldoContable INNER JOIN ScnCatalogoContable ON ScnSaldoContable.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                         " WHERE  (ScnCatalogoContable.nCuentaDetalle = 1) AND (ScnSaldoContable.nScnPeriodoContableID = " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ") " & _
                         " GROUP BY ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnCatalogoContable.sTipoCuenta, ScnCatalogoContable.nCuentaDeudora, ScnSaldoContable.nScnPeriodoContableID " & _
                         " HAVING  (ScnCatalogoContable.sTipoCuenta = 'I' OR ScnCatalogoContable.sTipoCuenta = 'E') " & _
                         " ORDER BY ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnCatalogoContable.sTipoCuenta DESC"
                XdtTmpCuentas.ExecuteSql(StrSql)
                IntRegistros = XdtTmpCuentas.Count

                'Para cada una de las Fuentes de Financiamiento:
                While IntRegistros > 0
                    '-- Inserta Registro: 
                    'StrSql = " Select * From ##" & StrNombreTablaTmp & " Where (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                    StrSql = " Select count(*) From ##" & StrNombreTablaTmp & " Where (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                    If Trans.ExecuteScalar(StrSql) = 0 Then 'RegistrosAsociados(StrSql) = False 
                        '-- Encuentra Cuenta de Utilidad del Periodo:
                        StrSql = "SELECT P.nScnCatalogoContableID FROM ScnTransaccionParametros P INNER JOIN StbValorCatalogo C ON P.nStbTipoAfectacionID = C.nStbValorCatalogoID WHERE (C.sCodigoInterno = '8') AND (P.nScnFuenteFinanciamientoID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                        IdUtilidadPeriodo = XcDatos.ExecuteScalar(StrSql)

                        '-- Encuentra Cuenta de Patrimonio:
                        StrSql = "SELECT P.nScnCatalogoContableID FROM ScnTransaccionParametros P INNER JOIN StbValorCatalogo C ON P.nStbTipoAfectacionID = C.nStbValorCatalogoID WHERE (C.sCodigoInterno = '10') AND (P.nScnFuenteFinanciamientoID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                        IdPatrimonio = XcDatos.ExecuteScalar(StrSql)

                        '-- Inserta registro en Tabla Temporal:
                        If XdtTmpCuentas.ValueField("sTipoCuenta") = "I" Then
                            StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                                     " nFuenteID, nScnPeriodoContableID, nScnUtilidadPeriodoID, nScnPatrimonioID, nCuentaDeudora, sTipoCuenta, " & _
                                     " nSaldoC, nSaldoD) " & _
                                     " Values (" & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ", " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ", " & IdUtilidadPeriodo & ", " & IdPatrimonio & ", " & XdtTmpCuentas.ValueField("nCuentaDeudora") & ", '" & XdtTmpCuentas.ValueField("sTipoCuenta") & "' " & _
                                     " ," & XdtTmpCuentas.ValueField("SaldoC") & ", " & XdtTmpCuentas.ValueField("SaldoD") & ")"
                        Else 'Solo hay egresos para la Fuente:
                            StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                                     " nFuenteID, nScnPeriodoContableID, nScnUtilidadPeriodoID, nScnPatrimonioID, nCuentaDeudora, sTipoCuenta, " & _
                                     " nSaldoC, nSaldoD) " & _
                                     " Values (" & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ", " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ", " & IdUtilidadPeriodo & ", " & IdPatrimonio & ", " & XdtTmpCuentas.ValueField("nCuentaDeudora") & ", '" & XdtTmpCuentas.ValueField("sTipoCuenta") & "' " & _
                                     " ," & XdtTmpCuentas.ValueField("SaldoC") * -1 & ", " & XdtTmpCuentas.ValueField("SaldoD") * -1 & ")"
                        End If

                    Else 'Al haber Ordenado por Tipo de Cuenta la Segunda Cuenta es la de Egresos por eso se resta al ingreso:
                        StrSql = " UPDATE ##" & StrNombreTablaTmp & " SET " & _
                                 " nSaldoC = nSaldoC - " & XdtTmpCuentas.ValueField("SaldoC") & "," & _
                                 " nSaldoD = nSaldoD - " & XdtTmpCuentas.ValueField("SaldoD") & _
                                 " WHERE (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                    End If
                    Trans.ExecuteSql(StrSql)
                    '------------------------------
                    XdtTmpCuentas.Source.MoveNext()
                    IntRegistros = IntRegistros - 1
                End While
                '============================================================================================

                '-- Cerrar Periodo Contable: 
                'CerrarPeriodo(XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID"), nCierreDefinitivo, IntSiguientePeriodoId, IntUltimoPeriodoCerrado)
                'StrSql = " EXEC spScnCerrarMesContable " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & "," & _
                '         nCierreDefinitivo & "," & IntSiguientePeriodoId & "," & IntUltimoPeriodoCerrado & "," & InfoSistema.IDCuenta & ", '" & StrNombreTablaTmp & "'"

                StrSql = " EXEC spScnCerrarMesContable " & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & "," & _
                         nCierreDefinitivo & "," & IntSiguientePeriodoId & "," & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & "," & InfoSistema.IDCuenta & ", '" & StrNombreTablaTmp & "'"

                IntPeriodoId = Trans.ExecuteScalar(StrSql)
                If IntPeriodoId = 0 Then
                    MsgBox("El Cierre Contable no pudo Ejecutarse.", MsgBoxStyle.Information, NombreSistema)
                Else
                    MsgBox("El Período Contable ha sido Cerrado.", MsgBoxStyle.Information, NombreSistema)
                    Call GuardarAuditoria(5, 24, "Cierre de Período Contable ID:" & XdsEjercicios("Periodos").ValueField("nScnPeriodoContableID") & ".")
                End If

                '============================================================================================
                '-- 3. Eliminar Tabla Temporal:
                'EliminarTablaTemporal()
                StrSql = "Drop Table ##" & StrNombreTablaTmp
                Trans.ExecuteSql(StrSql)
                '============================================================================================

                'Finaliza Transaccion:
                Trans.Commit()

                '-- Poner el cursor en un estado de desocupado:
                Me.Cursor = System.Windows.Forms.Cursors.Default
                'InicializaVariables()
                'CargarEjercicio()

                'Refrescar Datos: 
                CargarEjercicio()
                XdsEjercicios("Ejercicio").SetCurrentByID("nScnEjercicioContableID", intPosicion)
                Me.grdEjercicio.Row = XdsEjercicios("Ejercicio").BindingSource.Position
                XdsEjercicios("Periodos").SetCurrentByID("nScnPeriodoContableID", intPosicionS)
                Me.grdPeriodo.Row = XdsEjercicios("Periodos").BindingSource.Position

            End If

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            XdtTmpCuentas.Close()
            XdtTmpCuentas = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       LlamaCerrarEjercicio
    ' Descripción:          Este procedimiento permite Cerrar un Ejercicio
    '                       Contable existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaCerrarEjercicio()
        Dim Trans As BOSistema.Win.Transact
        Trans = Nothing

        Dim XcDatos As New BOSistema.Win.XComando
        Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
        XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            Dim IntPeriodoId As Integer
            Dim IntSiguientePeriodoId As Integer
            Dim IntRegistros As Integer

            Dim nMontoDebeC As Double
            'Dim nMontoDebeD As Double
            Dim nMontoHaberC As Double
            'Dim nMontoHaberD As Double
            'Imposible si no hay ningún registro:
            If Me.grdEjercicio.RowCount = 0 Then
                MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si el Ejercicio esta Cerrado:
            If XdsEjercicios("Ejercicio").ValueField("nCerrado") = "1" Then
                MsgBox("El Ejercicio se encuentra Cerrado.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Imposible si existen períodos sin Cierre Definitivo:
            StrSql = "SELECT  StbValorCatalogo.sDescripcion " & _
                     "FROM ScnPeriodoContable INNER JOIN StbValorCatalogo ON ScnPeriodoContable.nStbEstadoPeriodoID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE (ScnPeriodoContable.nScnPeriodoContableID >= " & IntPrimerPeriodoID & ") AND (ScnPeriodoContable.nScnEjercicioContableID = " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3')"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Existen Períodos aún no Cerrados de forma Definitiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Debe existir Tasa de Cambio para la fecha final del Ejercicio:
            If nTasaCambio(XdsEjercicios("Ejercicio").ValueField("dFechaFin")) = -1 Then
                MsgBox("No existe una Tasa de Cambio para" & Chr(13) & "Fecha de Corte del Ejercicio.", MsgBoxStyle.Information, NombreSistema)
                Exit Sub
            End If

            'Antes debe generar el siguiente Ejercicio: 
            StrSql = "SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
                     "WHERE  (nScnEjercicioContableID > " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
            If RegistrosAsociados(StrSql) = False Then
                MsgBox("Antes debe generar el siguiente Ejercicio Contable.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO es el primer Ejercicio: Ejercicio anterior debe estar Cerrado:
            If XdsEjercicios("Ejercicio").ValueField("nPrimerEjercicio") <> "1" Then
                'Encuentra Estado del Ejercicio Anterior:
                StrSql = "SELECT  E.nCerrado FROM (SELECT MAX(nScnEjercicioContableID) AS IdEjercicio " & _
                         "FROM  (SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
                         "WHERE (nScnEjercicioContableID < " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")) AS b) AS a INNER JOIN ScnEjercicioContable AS E ON a.IdEjercicio = E.nScnEjercicioContableID"
                If XcDatos.ExecuteScalar(StrSql) = 0 Then
                    MsgBox("Antes debe Cerrar el Ejercicio anterior.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Deben existir parámetros de Cuentas Contables para el Cierre Anual
            'por cada Fuente de Fondos (Tipos de Afectación: 7, 8, 9, 10):
            '7: Utilidad o Pérdida del Ejercicio Anterior
            '8: Utilidad o Pérdida del Ejercicio Actual
            '9: Resumen de Ingresos y Gastos
            '10: Patrimonio
            StrSql = "SELECT COUNT(nScnFuenteFinanciamientoID) AS TFuentes FROM  ScnFuenteFinanciamiento " & _
                     "WHERE (nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM  ScnTransaccionContable))"
            nTotalParametros = XcDatos.ExecuteScalar(StrSql) * 4
            '-- Total de Parametros Registrados:
            StrSql = "SELECT COUNT(ScnTransaccionParametros.nScnTransaccionParametroID) AS TParam " & _
                     "FROM  ScnTransaccionParametros INNER JOIN StbValorCatalogo ON ScnTransaccionParametros.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
                     "WHERE  (ScnTransaccionParametros.nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM ScnTransaccionContable)) AND (StbValorCatalogo.sCodigoInterno = 'CC')"
            If XcDatos.ExecuteScalar(StrSql) <> nTotalParametros Then
                MsgBox("Antes debe Registrar los Parametros de Cierre" & Chr(13) & "Contable por cada Fuente de Fondos.", MsgBoxStyle.Information)
                Exit Sub
            End If

            '-- Confirmar Cierre:
            If MsgBox("¿Está seguro de Cerrar el Ejercicio Contable?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            '-- *******************************************************************************************
            '-- ****************************** Cierre de Año Contable ************************************* 
            '-- *******************************************************************************************
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

            '============================================================================================
            '-- 1. Crear Tabla Temporal: 
            'CrearTablaTemporal()
            Randomize()
            StrNombreTablaTmp = "TmpScnCierre" & InfoSistema.LoginName & Trim(Str(Int((9999 * Rnd()) + 1)))
            'Si la tabla ya existe en tempDb eliminar la misma:
            StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
            If XcDatos.ExecuteScalar(StrSql) > 0 Then
                StrSql = "Drop Table  ##" & StrNombreTablaTmp
                XcDatos.ExecuteNonQuery(StrSql)
            End If

            'Instanciar Trans:
            Trans = New BOSistema.Win.Transact
            'Inicio la Transaccion:
            Trans.BeginTrans()

            'Crea la Tabla en: System Databases: tempDb: Temporary Tables
            StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
                                "[nFuenteID] [int] NOT NULL , " & _
                                "[nCatalogoContableID] [int] NOT NULL , " & _
                                "[nDebito] [tinyint] NOT NULL , " & _
                                "[sTipoCuenta] [varchar] (1) NOT NULL , " & _
                                "[sCodigoCuenta] [varchar] (70) NOT NULL , " & _
                                "[sNombreCuenta] [varchar] (200) NOT NULL , " & _
                                "[nSaldoFinalC] [numeric] (18, 2) NOT NULL , " & _
                                "[nSaldoFinalD] [numeric] (18, 2) NOT NULL)"
            Trans.ExecuteSql(StrSql)
            '============================================================================================

            '============================================================================================
            '-- 2. Inserta Detalles de Transacciones por Fuente de Fondos en Tabla Temporal:
            'CargarTablaTemporal()
            '-- Fuentes de Financiamiento que tienen Movimientos Contables:
            StrSql = "SELECT nScnFuenteFinanciamientoID,sNombre " & _
                     "FROM  ScnFuenteFinanciamiento " & _
                     "WHERE (nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM  ScnTransaccionContable)) " & _
                     "ORDER BY nScnFuenteFinanciamientoID"
            XdtTmpCuentas.ExecuteSql(Strsql)
            IntRegistros = XdtTmpCuentas.Count
            'Para cada una de las Fuentes de Financiamiento:
            While IntRegistros > 0
                EjecutaCierreTblTemporal(Trans, XdsEjercicios("Ejercicio").ValueField("dFechaFin"), nTasaCambio(XdsEjercicios("Ejercicio").ValueField("dFechaFin")), XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID"), IDPeriodo(XdsEjercicios("Ejercicio").ValueField("dFechaFin")), 1)
                '------------------------------
                '-- Encuentra Suma de Movimientos Deudores y Acreedores:
                StrSql = "SELECT  ISNULL(SUM(nSaldoFinalC), 0) AS M FROM ##" & StrNombreTablaTmp & " WHERE (nDebito = 1) AND (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                nMontoDebeC = Trans.ExecuteScalar(StrSql)


                StrSql = "SELECT  ISNULL(SUM(nSaldoFinalC), 0) AS M FROM ##" & StrNombreTablaTmp & " WHERE (nDebito = 0) AND (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
                nMontoHaberC = Trans.ExecuteScalar(StrSql)

                If Math.Abs(nMontoDebeC - nMontoHaberC) >= 0.1 Then
                    MsgBox("Existen diferencias en el debe y el haber al momento de generar la partida de cierre para la fuente " & XdtTmpCuentas.ValueField("sNombre"), MsgBoxStyle.Information, NombreSistema)
                    Trans.RollBack()
                    Exit Sub
                End If




                XdtTmpCuentas.Source.MoveNext()
                IntRegistros = IntRegistros - 1
            End While
            '============================================================================================

            '-- Encuentra Ultimo Periodo Cerrado en Forma Definitiva:
            IntPeriodoId = IDPeriodo(XdsEjercicios("Ejercicio").ValueField("dFechaFin"))
            '-- Encuentra Siguiente Periodo despues del Ultimo Mes del Año a Cerrar:
            IntSiguientePeriodoId = XcDatos.ExecuteScalar("SELECT TOP (1) PERCENT nScnPeriodoContableID FROM ScnPeriodoContable WHERE (nScnPeriodoContableID > " & IntPeriodoId & ") ORDER BY nScnPeriodoContableID")

            '-- Ejecuta Procedimiento Almacenado:
            StrSql = " EXEC spScnCerrarEjercicioContable " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ", " & IntPeriodoId & "," & _
                         IntSiguientePeriodoId & "," & InfoSistema.IDCuenta & ", '" & Format(XdsEjercicios("Ejercicio").ValueField("dFechaFin"), "yyyy-MM-dd") & "', '" & StrNombreTablaTmp & "', " & InfoSistema.IDDelegacion
            IntPeriodoId = Trans.ExecuteScalar(StrSql)
            If IntPeriodoId = 0 Then
                MsgBox("El Ejercicio Contable no pudo Cerrarse.", MsgBoxStyle.Information, NombreSistema)
            Else
                MsgBox("El Ejercicio Contable ha sido Cerrado.", MsgBoxStyle.Information, NombreSistema)
                Call GuardarAuditoria(5, 24, "Cierre de Ejercicio Contable ID:" & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ".")
            End If

            '============================================================================================
            '-- 3. Eliminar Tabla Temporal:
            'EliminarTablaTemporal()
            StrSql = "Drop Table ##" & StrNombreTablaTmp
            Trans.ExecuteSql(StrSql)
            '============================================================================================

            'Finaliza Transaccion:
            Trans.Commit()


            '-- Poner el cursor en un estado de desocupado: 
            Me.Cursor = System.Windows.Forms.Cursors.Default
            InicializaVariables()
            CargarEjercicio()

        Catch ex As Exception
            Trans.RollBack()
            Control_Error(ex)
        Finally
            Trans = Nothing

            XcDatos.Close()
            XcDatos = Nothing

            XdtTmpCuentas.Close()
            XdtTmpCuentas = Nothing
        End Try
    End Sub

    'Private Sub LlamaCerrarEjercicio()
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable
    '    Try
    '        Dim StrSql As String
    '        Dim IntPeriodoId As Integer
    '        Dim IntSiguientePeriodoId As Integer
    '        Dim IntRegistros As Integer

    '        'Imposible si no hay ningún registro:
    '        If Me.grdEjercicio.RowCount = 0 Then
    '            MsgBox("No Existen registros grabados.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Imposible si el Ejercicio esta Cerrado:
    '        If XdsEjercicios("Ejercicio").ValueField("nCerrado") = "1" Then
    '            MsgBox("El Ejercicio se encuentra Cerrado.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Imposible si existen períodos sin Cierre Definitivo:
    '        StrSql = "SELECT  StbValorCatalogo.sDescripcion " & _
    '                 "FROM ScnPeriodoContable INNER JOIN StbValorCatalogo ON ScnPeriodoContable.nStbEstadoPeriodoID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                 "WHERE (ScnPeriodoContable.nScnPeriodoContableID >= " & IntPrimerPeriodoID & ") AND (ScnPeriodoContable.nScnEjercicioContableID = " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ") AND (StbValorCatalogo.sCodigoInterno <> '3')"
    '        If RegistrosAsociados(StrSql) Then
    '            MsgBox("Existen Períodos aún no Cerrados de forma Definitiva.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Debe existir Tasa de Cambio para la fecha final del Ejercicio:
    '        If nTasaCambio(XdsEjercicios("Ejercicio").ValueField("dFechaFin")) = -1 Then
    '            MsgBox("No existe una Tasa de Cambio para" & Chr(13) & "Fecha de Corte del Ejercicio.", MsgBoxStyle.Information, NombreSistema)
    '            Exit Sub
    '        End If

    '        'Antes debe generar el siguiente Ejercicio: 
    '        StrSql = "SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
    '                 "WHERE  (nScnEjercicioContableID > " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")"
    '        If RegistrosAsociados(StrSql) = False Then
    '            MsgBox("Antes debe generar el siguiente Ejercicio Contable.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        'Si NO es el primer Ejercicio: Ejercicio anterior debe estar Cerrado:
    '        If XdsEjercicios("Ejercicio").ValueField("nPrimerEjercicio") <> "1" Then
    '            'Encuentra Estado del Ejercicio Anterior:
    '            StrSql = "SELECT  E.nCerrado FROM (SELECT MAX(nScnEjercicioContableID) AS IdEjercicio " & _
    '                     "FROM  (SELECT nScnEjercicioContableID FROM ScnEjercicioContable " & _
    '                     "WHERE (nScnEjercicioContableID < " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ")) AS b) AS a INNER JOIN ScnEjercicioContable AS E ON a.IdEjercicio = E.nScnEjercicioContableID"
    '            If XcDatos.ExecuteScalar(StrSql) = 0 Then
    '                MsgBox("Antes debe Cerrar el Ejercicio anterior.", MsgBoxStyle.Information)
    '                Exit Sub
    '            End If
    '        End If

    '        'Deben existir parámetros de Cuentas Contables para el Cierre Anual
    '        'por cada Fuente de Fondos (Tipos de Afectación: 7, 8, 9, 10):
    '        '7: Utilidad o Pérdida del Ejercicio Anterior
    '        '8: Utilidad o Pérdida del Ejercicio Actual
    '        '9: Resumen de Ingresos y Gastos
    '        '10: Patrimonio
    '        StrSql = "SELECT COUNT(nScnFuenteFinanciamientoID) AS TFuentes FROM  ScnFuenteFinanciamiento " & _
    '                 "WHERE (nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM  ScnTransaccionContable))"
    '        nTotalParametros = XcDatos.ExecuteScalar(StrSql) * 4
    '        '-- Total de Parametros Registrados:
    '        StrSql = "SELECT COUNT(ScnTransaccionParametros.nScnTransaccionParametroID) AS TParam " & _
    '                 "FROM  ScnTransaccionParametros INNER JOIN StbValorCatalogo ON ScnTransaccionParametros.nStbTipoDocContableID = StbValorCatalogo.nStbValorCatalogoID " & _
    '                 "WHERE  (ScnTransaccionParametros.nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM ScnTransaccionContable)) AND (StbValorCatalogo.sCodigoInterno = 'CC')"
    '        If XcDatos.ExecuteScalar(StrSql) <> nTotalParametros Then
    '            MsgBox("Antes debe Registrar los Parametros de Cierre" & Chr(13) & "Contable por cada Fuente de Fondos.", MsgBoxStyle.Information)
    '            Exit Sub
    '        End If

    '        '-- Confirmar Cierre:
    '        If MsgBox("¿Está seguro de Cerrar el Ejercicio Contable?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
    '            Exit Sub
    '        End If

    '        '-- *******************************************************************************************
    '        '-- ****************************** Cierre de Año Contable ************************************* 
    '        '-- *******************************************************************************************
    '        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

    '        '============================================================================================
    '        '-- 1. Crear Tabla Temporal: 
    '        'CrearTablaTemporal()
    '        Randomize()
    '        StrNombreTablaTmp = "TmpScnCierre" & InfoSistema.LoginName & Trim(Str(Int((9999 * Rnd()) + 1)))
    '        'Si la tabla ya existe en tempDb eliminar la misma:
    '        StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
    '        If XcDatos.ExecuteScalar(StrSql) > 0 Then
    '            StrSql = "Drop Table  ##" & StrNombreTablaTmp
    '            XcDatos.ExecuteNonQuery(StrSql)
    '        End If
    '        'Crea la Tabla en: System Databases: tempDb: Temporary Tables
    '        StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
    '                            "[nFuenteID] [int] NOT NULL , " & _
    '                            "[nCatalogoContableID] [int] NOT NULL , " & _
    '                            "[nDebito] [tinyint] NOT NULL , " & _
    '                            "[sTipoCuenta] [varchar] (1) NOT NULL , " & _
    '                            "[sCodigoCuenta] [varchar] (70) NOT NULL , " & _
    '                            "[sNombreCuenta] [varchar] (200) NOT NULL , " & _
    '                            "[nSaldoFinalC] [numeric] (18, 2) NOT NULL , " & _
    '                            "[nSaldoFinalD] [numeric] (18, 2) NOT NULL)"
    '        XcDatos.ExecuteNonQuery(StrSql)
    '        '============================================================================================

    '        '============================================================================================
    '        '-- 2. Inserta Detalles de Transacciones por Fuente de Fondos en Tabla Temporal:
    '        'CargarTablaTemporal()
    '        '-- Fuentes de Financiamiento que tienen Movimientos Contables:
    '        Strsql = "SELECT nScnFuenteFinanciamientoID " & _
    '                 "FROM  ScnFuenteFinanciamiento " & _
    '                 "WHERE (nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM  ScnTransaccionContable)) " & _
    '                 "ORDER BY nScnFuenteFinanciamientoID"
    '        XdtTmpCuentas.ExecuteSql(Strsql)
    '        IntRegistros = XdtTmpCuentas.Count
    '        'Para cada una de las Fuentes de Financiamiento:
    '        While IntRegistros > 0
    '            EjecutaCierreTblTemporal(XdsEjercicios("Ejercicio").ValueField("dFechaFin"), nTasaCambio(XdsEjercicios("Ejercicio").ValueField("dFechaFin")), XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID"), IDPeriodo(XdsEjercicios("Ejercicio").ValueField("dFechaFin")))
    '            '------------------------------
    '            XdtTmpCuentas.Source.MoveNext()
    '            IntRegistros = IntRegistros - 1
    '        End While
    '        '============================================================================================

    '        '-- Encuentra Ultimo Periodo Cerrado en Forma Definitiva:
    '        IntPeriodoId = IDPeriodo(XdsEjercicios("Ejercicio").ValueField("dFechaFin"))
    '        '-- Encuentra Siguiente Periodo despues del Ultimo Mes del Año a Cerrar:
    '        IntSiguientePeriodoId = XcDatos.ExecuteScalar("SELECT TOP (1) PERCENT nScnPeriodoContableID FROM ScnPeriodoContable WHERE (nScnPeriodoContableID > " & IntPeriodoId & ") ORDER BY nScnPeriodoContableID")

    '        '-- Ejecuta Procedimiento Almacenado:
    '        StrSql = " EXEC spScnCerrarEjercicioContable " & XdsEjercicios("Ejercicio").ValueField("nScnEjercicioContableID") & ", " & IntPeriodoId & "," & _
    '                     IntSiguientePeriodoId & "," & InfoSistema.IDCuenta & ", '" & Format(XdsEjercicios("Ejercicio").ValueField("dFechaFin"), "yyyy-MM-dd") & "', '" & StrNombreTablaTmp & "', " & InfoSistema.IDDelegacion
    '        IntPeriodoId = XcDatos.ExecuteScalar(StrSql)
    '        If IntPeriodoId = 0 Then
    '            MsgBox("El Ejercicio Contable no pudo Cerrarse.", MsgBoxStyle.Information, NombreSistema)
    '        Else
    '            MsgBox("El Ejercicio Contable ha sido Cerrado.", MsgBoxStyle.Information, NombreSistema)
    '        End If

    '        '============================================================================================
    '        '-- 3. Eliminar Tabla Temporal:
    '        'EliminarTablaTemporal()
    '        StrSql = "Drop Table ##" & StrNombreTablaTmp
    '        XcDatos.ExecuteNonQuery(StrSql)
    '        '============================================================================================

    '        '-- Poner el cursor en un estado de desocupado: 
    '        Me.Cursor = System.Windows.Forms.Cursors.Default
    '        InicializaVariables()
    '        CargarEjercicio()

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing

    '        XdtTmpCuentas.Close()
    '        XdtTmpCuentas = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutierrez
    ' Fecha:                12/12/2007
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
    ' Fecha:                12/12/2007
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
    Private Sub grdEjercicio_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdEjercicio.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       grdEjercicio_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdEjercicio_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdEjercicio.Filter
        Try
            XdsEjercicios("Ejercicio").FilterLocal(e.Condition)
            Me.grdEjercicio.Caption = " Listado de Ejercicios Contables (" + Me.grdEjercicio.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar:
            If Seg.HasPermission("AgregarEjercicioContable") = False Then
                Me.tbEjercicio.Items("toolAgregarE").Enabled = False
            Else  'Habilita
                Me.tbEjercicio.Items("toolAgregarE").Enabled = True
            End If
            'Eliminar:
            If Seg.HasPermission("EliminarEjercicioContable") = False Then
                Me.tbEjercicio.Items("toolEliminarE").Enabled = False
            Else  'Habilita
                Me.tbEjercicio.Items("toolEliminarE").Enabled = True
            End If
            'Cerrar Ejercicio:
            If Seg.HasPermission("CerrarEjercicioContable") = False Then
                Me.tbEjercicio.Items("toolCerrarE").Enabled = False
            Else  'Habilita
                Me.tbEjercicio.Items("toolCerrarE").Enabled = True
            End If
            'Imprimir Listado:
            If Seg.HasPermission("ImprimirListadoEjercicios") = False Then
                Me.tbEjercicio.Items("toolImprimirL").Enabled = False
            Else  'Habilita
                Me.tbEjercicio.Items("toolImprimirL").Enabled = True
            End If
            'Cierre Preliminar Periodo:
            If Seg.HasPermission("CierrePreliminarPeriodoContable") = False Then
                Me.tbPeriodo.Items("toolCerrarP").Enabled = False
            Else  'Habilita
                Me.tbPeriodo.Items("toolCerrarP").Enabled = True
            End If
            'Cierre Definitivo Periodo:
            If Seg.HasPermission("CierreDefinitivoPeriodoContable") = False Then
                Me.tbPeriodo.Items("toolCerrarD").Enabled = False
            Else  'Habilita
                Me.tbPeriodo.Items("toolCerrarD").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/12/2007
    ' Procedure Name:       grdEjercicio_RowColChange
    ' Descripción:          Este evento permite actualizar el título del grid
    '                       con la cantidad de registros.
    '-------------------------------------------------------------------------
    Private Sub grdEjercicio_RowColChange(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.RowColChangeEventArgs) Handles grdEjercicio.RowColChange
        Me.grdPeriodo.Caption = " Listado de Períodos Contables (" + Me.grdPeriodo.RowCount.ToString + " registros)"
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdPeriodo_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdPeriodo.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                12/07/2007
    ' Procedure Name:       grdPeriodo_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdPeriodo_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdPeriodo.Filter
        Try
            XdsEjercicios("Periodos").FilterLocal(e.Condition)
            Me.grdPeriodo.Caption = " Listado de Períodos Contables (" + Me.grdPeriodo.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/12/2007
    ' Procedure Name:       CrearTablaTemporal
    ' Descripción:          Esta función permite Crear tabla para el registro 
    '                       de datos temporales.
    '-------------------------------------------------------------------------
    'Private Sub CrearTablaTemporal()
    '    Try

    '        Dim StrSql As String
    '        Randomize()
    '        StrNombreTablaTmp = "TmpScnCierre" & InfoSistema.LoginName & Trim(Str(Int((9999 * Rnd()) + 1)))

    '        'Si la tabla ya existe en tempDb eliminar la misma:
    '        StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
    '        If XcDatosG.ExecuteScalar(StrSql) > 0 Then
    '            StrSql = "Drop Table  ##" & StrNombreTablaTmp
    '            XcDatosG.ExecuteNonQuery(StrSql)
    '        End If

    '        'Crea la Tabla en: System Databases: tempDb: Temporary Tables
    '        StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
    '                            "[nFuenteID] [int] NOT NULL , " & _
    '                            "[nCatalogoContableID] [int] NOT NULL , " & _
    '                            "[nDebito] [tinyint] NOT NULL , " & _
    '                            "[sTipoCuenta] [varchar] (1) NOT NULL , " & _
    '                            "[sCodigoCuenta] [varchar] (70) NOT NULL , " & _
    '                            "[sNombreCuenta] [varchar] (200) NOT NULL , " & _
    '                            "[nSaldoFinalC] [numeric] (18, 2) NOT NULL , " & _
    '                            "[nSaldoFinalD] [numeric] (18, 2) NOT NULL)"
    '        XcDatosG.ExecuteNonQuery(StrSql)

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/03/2008
    ' Procedure Name:       CrearTablaTemporalM
    ' Descripción:          Esta función permite Crear tabla para el registro 
    '                       de datos temporales.
    '-------------------------------------------------------------------------
    'Private Sub CrearTablaTemporalM()
    '    Try

    '        Dim StrSql As String
    '        Randomize()
    '        StrNombreTablaTmp = "TmpScnCierreMensual" & InfoSistema.LoginName & Trim(Str(Int((9999 * Rnd()) + 1)))

    '        'Si la tabla ya existe en tempDb eliminar la misma:
    '        StrSql = "Select count(*) From tempdb.dbo.sysobjects where name = '##" & StrNombreTablaTmp & "'"
    '        If XcDatosG.ExecuteScalar(StrSql) > 0 Then
    '            StrSql = "Drop Table  ##" & StrNombreTablaTmp
    '            XcDatosG.ExecuteNonQuery(StrSql)
    '        End If

    '        'Crea la Tabla en: System Databases: tempDb: Temporary Tables
    '        StrSql = "CREATE TABLE [dbo].[##" & StrNombreTablaTmp & "] ( " & _
    '                            "[nFuenteID] [int] NOT NULL , " & _
    '                            "[nScnPeriodoContableID] [int] NOT NULL , " & _
    '                            "[nScnUtilidadPeriodoID] [int] NOT NULL , " & _
    '                            "[nScnPatrimonioID] [int] NOT NULL , " & _
    '                            "[nCuentaDeudora] [tinyint] NOT NULL , " & _
    '                            "[sTipoCuenta] [varchar] (1) NOT NULL , " & _
    '                            "[nSaldoC] [numeric] (18, 2) NOT NULL , " & _
    '                            "[nSaldoD] [numeric] (18, 2) NOT NULL)"
    '        XcDatosG.ExecuteNonQuery(StrSql)

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                17/03/2008
    ' Procedure Name:       CargarTablaTemporalM
    ' Descripción:          Esta función permite Cargar tabla con datos temporales
    '                       de Detalles de las Transacciones Contables.
    '-------------------------------------------------------------------------
    'Private Sub CargarTablaTemporalM(ByVal IdPeriodo As Integer)

    '    Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable

    '    Dim XcDatosMes As New BOSistema.Win.XComando

    '    Try

    '        Dim Strsql As String
    '        Dim IntRegistros As Integer
    '        Dim IdUtilidadPeriodo As Integer
    '        Dim IdPatrimonio As Integer

    '        '-- Fuentes de Financiamiento que tienen Movimientos Contables:
    '        Strsql = " SELECT  ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnSaldoContable.nScnPeriodoContableID, ScnCatalogoContable.nCuentaDeudora, ScnCatalogoContable.sTipoCuenta, " & _
    '                 " CASE ScnCatalogoContable.nCuentaDeudora WHEN 1 THEN SUM(ScnSaldoContable.nDebitoPeriodoC) - SUM(ScnSaldoContable.nCreditoPeriodoC) ELSE SUM(ScnSaldoContable.nCreditoPeriodoC) - SUM(ScnSaldoContable.nDebitoPeriodoC)  END AS SaldoC, " & _
    '                 " CASE ScnCatalogoContable.nCuentaDeudora WHEN 1 THEN SUM(ScnSaldoContable.nDebitoPeriodoD) - SUM(ScnSaldoContable.nCreditoPeriodoD) ELSE SUM(ScnSaldoContable.nCreditoPeriodoD) - SUM(ScnSaldoContable.nDebitoPeriodoD)  END AS SaldoD " & _
    '                 " FROM  ScnSaldoContable INNER JOIN ScnCatalogoContable ON ScnSaldoContable.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
    '                 " WHERE  (ScnCatalogoContable.nCuentaDetalle = 1) AND (ScnSaldoContable.nScnPeriodoContableID = " & IdPeriodo & ") " & _
    '                 " GROUP BY ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnCatalogoContable.sTipoCuenta, ScnCatalogoContable.nCuentaDeudora, ScnSaldoContable.nScnPeriodoContableID " & _
    '                 " HAVING (ScnCatalogoContable.sTipoCuenta = 'I') OR (ScnCatalogoContable.sTipoCuenta = 'E') " & _
    '                 " ORDER BY ScnCatalogoContable.nScnFuenteFinanciamientoID, ScnCatalogoContable.sTipoCuenta DESC"
    '        XdtTmpCuentas.ExecuteSql(Strsql)
    '        IntRegistros = XdtTmpCuentas.Count

    '        'Para cada una de las Fuentes de Financiamiento:
    '        While IntRegistros > 0
    '            '-- Inserta Registro: 
    '            Strsql = " Select * From ##" & StrNombreTablaTmp & " Where (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '            If RegistrosAsociados(Strsql) = False Then
    '                '-- Encuentra Cuenta de Utilidad del Periodo:
    '                Strsql = "SELECT P.nScnCatalogoContableID FROM ScnTransaccionParametros P INNER JOIN StbValorCatalogo C ON P.nStbTipoAfectacionID = C.nStbValorCatalogoID WHERE (C.sCodigoInterno = '8') AND (P.nScnFuenteFinanciamientoID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                IdUtilidadPeriodo = XcDatosMes.ExecuteScalar(Strsql)

    '                '-- Encuentra Cuenta de Patrimonio:
    '                Strsql = "SELECT P.nScnCatalogoContableID FROM ScnTransaccionParametros P INNER JOIN StbValorCatalogo C ON P.nStbTipoAfectacionID = C.nStbValorCatalogoID WHERE (C.sCodigoInterno = '10') AND (P.nScnFuenteFinanciamientoID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '                IdPatrimonio = XcDatosMes.ExecuteScalar(Strsql)

    '                '-- Inserta registro en Tabla Temporal:
    '                If XdtTmpCuentas.ValueField("sTipoCuenta") = "I" Then
    '                    Strsql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
    '                             " nFuenteID, nScnPeriodoContableID, nScnUtilidadPeriodoID, nScnPatrimonioID, nCuentaDeudora, sTipoCuenta, " & _
    '                             " nSaldoC, nSaldoD) " & _
    '                             " Values (" & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ", " & IdPeriodo & ", " & IdUtilidadPeriodo & ", " & IdPatrimonio & ", " & XdtTmpCuentas.ValueField("nCuentaDeudora") & ", '" & XdtTmpCuentas.ValueField("sTipoCuenta") & "' " & _
    '                             " ," & XdtTmpCuentas.ValueField("SaldoC") & ", " & XdtTmpCuentas.ValueField("SaldoD") & ")"
    '                Else 'Solo hay egresos para la Fuente:
    '                    Strsql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
    '                             " nFuenteID, nScnPeriodoContableID, nScnUtilidadPeriodoID, nScnPatrimonioID, nCuentaDeudora, sTipoCuenta, " & _
    '                             " nSaldoC, nSaldoD) " & _
    '                             " Values (" & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ", " & IdPeriodo & ", " & IdUtilidadPeriodo & ", " & IdPatrimonio & ", " & XdtTmpCuentas.ValueField("nCuentaDeudora") & ", '" & XdtTmpCuentas.ValueField("sTipoCuenta") & "' " & _
    '                             " ," & XdtTmpCuentas.ValueField("SaldoC") * -1 & ", " & XdtTmpCuentas.ValueField("SaldoD") * -1 & ")"
    '                End If

    '            Else 'Al haber Ordenado por Tipo de Cuenta la Segunda Cuenta es la de Egresos por eso se resta al ingreso:
    '                Strsql = " UPDATE ##" & StrNombreTablaTmp & " SET " & _
    '                         " nSaldoC = nSaldoC - " & XdtTmpCuentas.ValueField("SaldoC") & "," & _
    '                         " nSaldoD = nSaldoD - " & XdtTmpCuentas.ValueField("SaldoD") & _
    '                         " WHERE (nFuenteID = " & XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID") & ")"
    '            End If
    '            XcDatosMes.ExecuteNonQuery(Strsql)
    '            '------------------------------
    '            XdtTmpCuentas.Source.MoveNext()
    '            IntRegistros = IntRegistros - 1
    '        End While

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XdtTmpCuentas.Close()
    '        XdtTmpCuentas = Nothing

    '        XcDatosMes.Close()
    '        XcDatosMes = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/12/2007
    ' Procedure Name:       EliminarTablaTemporal
    ' Descripción:          Esta función permite Eliminar los datos temporales
    '                       creados para Detalles de Transacción Contable.
    '-------------------------------------------------------------------------
    'Private Sub EliminarTablaTemporal()
    '    Dim XcDatos As New BOSistema.Win.XComando
    '    Try

    '        Dim StrSql As String
    '        'Eliminar Tabla Temporal
    '        StrSql = "Drop Table ##" & StrNombreTablaTmp
    '        XcDatos.ExecuteNonQuery(StrSql)

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XcDatos.Close()
    '        XcDatos = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/12/2007
    ' Procedure Name:       CargarTablaTemporal
    ' Descripción:          Esta función permite Cargar tabla con datos temporales
    '                       de Detalles de las Transacciones Contables.
    '-------------------------------------------------------------------------
    'Private Sub CargarTablaTemporal()

    '    Dim XdtTmpCuentas As BOSistema.Win.XDataSet.xDataTable
    '    XdtTmpCuentas = New BOSistema.Win.XDataSet.xDataTable

    '    Try

    '        Dim Strsql As String
    '        Dim IntRegistros As Integer

    '        '-- Fuentes de Financiamiento que tienen Movimientos Contables:
    '        Strsql = "SELECT nScnFuenteFinanciamientoID " & _
    '                 "FROM  ScnFuenteFinanciamiento " & _
    '                 "WHERE (nScnFuenteFinanciamientoID IN (SELECT nScnFuenteFinanciamientoID FROM  ScnTransaccionContable)) " & _
    '                 "ORDER BY nScnFuenteFinanciamientoID"
    '        XdtTmpCuentas.ExecuteSql(Strsql)
    '        IntRegistros = XdtTmpCuentas.Count

    '        'Para cada una de las Fuentes de Financiamiento:
    '        While IntRegistros > 0
    '            EjecutaCierreTblTemporal(XdsEjercicios("Ejercicio").ValueField("dFechaFin"), nTasaCambio(XdsEjercicios("Ejercicio").ValueField("dFechaFin")), XdtTmpCuentas.ValueField("nScnFuenteFinanciamientoID"), IDPeriodo(XdsEjercicios("Ejercicio").ValueField("dFechaFin")))
    '            '------------------------------
    '            XdtTmpCuentas.Source.MoveNext()
    '            IntRegistros = IntRegistros - 1
    '        End While

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '        XdtTmpCuentas.Close()
    '        XdtTmpCuentas = Nothing
    '    End Try
    'End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                26/12/2007
    ' Procedure Name:       EjecutaCierreTblTemporal
    ' Descripción:          Esta función permite Cargar tabla con datos temporales
    '                       de Detalles de las Transacciones Contables para una
    '                       determinada Fuente de Fondos.
    '-------------------------------------------------------------------------
    Public Sub EjecutaCierreTblTemporal(ByRef Trans As BOSistema.Win.Transact, ByVal DateFechaTx As Date, ByVal DblTasaCambio As Double, ByVal IdFuente As Integer, ByVal IdPeriodo As Integer, ByVal IncluirResumenIngresos As Integer)

        Dim XdtTmpProc As BOSistema.Win.XDataSet.xDataTable
        XdtTmpProc = New BOSistema.Win.XDataSet.xDataTable

        Dim XdtParametro As BOSistema.Win.XDataSet.xDataTable
        XdtParametro = New BOSistema.Win.XDataSet.xDataTable

        Dim XdtSaldoAnterior As BOSistema.Win.XDataSet.xDataTable
        XdtSaldoAnterior = New BOSistema.Win.XDataSet.xDataTable

        Dim XcDatos As New BOSistema.Win.XComando

        Try

            Dim nDebito As Integer
            Dim StrSql As String
            Dim IntRegistros As Integer
            Dim nMontoD As Double

            Dim nMontoDebeC As Double
            Dim nMontoDebeD As Double
            Dim nMontoHaberC As Double
            Dim nMontoHaberD As Double

            '-- Ejecuta Procedimiento almacenado para Cuentas Diferentes de Balance:
            StrSql = " EXEC spScnGenerarComprobanteCierre " & IdPeriodo & ", " & IdFuente
            XdtTmpProc.ExecuteSql(StrSql)
            IntRegistros = XdtTmpProc.Count

            '-- No existen Cuentas de Ingresos/Egresos para la Fuente:
            If IntRegistros = 0 Then
                Exit Sub
            End If

            'Para cada una de las Cuentas de la Fuente de Fondos:
            While IntRegistros > 0
                '-- Cuentas de Resultados para cerrarlas contra Cuenta Resumen de Ingresos y Gastos:
                nDebito = 8
                If (XdtTmpProc.ValueField("nCuentaDeudora") = 1) And (XdtTmpProc.ValueField("SaldoFinalCordobas") > 0) Then
                    nDebito = 0
                ElseIf (XdtTmpProc.ValueField("nCuentaDeudora") = 1) And (XdtTmpProc.ValueField("SaldoFinalCordobas") < 0) Then
                    nDebito = 1
                ElseIf (XdtTmpProc.ValueField("nCuentaDeudora") = 0) And (XdtTmpProc.ValueField("SaldoFinalCordobas") > 0) Then
                    nDebito = 1
                ElseIf (XdtTmpProc.ValueField("nCuentaDeudora") = 0) And (XdtTmpProc.ValueField("SaldoFinalCordobas") < 0) Then
                    nDebito = 0
                End If
                If nDebito = "8" Then 'Saldo Final Cordobas es Cero, Solo Hay Saldo Final en Dolares.
                    If (XdtTmpProc.ValueField("nCuentaDeudora") = 1) And (XdtTmpProc.ValueField("SaldoFinalDolares") > 0) Then
                        nDebito = 0
                    ElseIf (XdtTmpProc.ValueField("nCuentaDeudora") = 1) And (XdtTmpProc.ValueField("SaldoFinalDolares") < 0) Then
                        nDebito = 1
                    ElseIf (XdtTmpProc.ValueField("nCuentaDeudora") = 0) And (XdtTmpProc.ValueField("SaldoFinalDolares") > 0) Then
                        nDebito = 1
                    ElseIf (XdtTmpProc.ValueField("nCuentaDeudora") = 0) And (XdtTmpProc.ValueField("SaldoFinalDolares") < 0) Then
                        nDebito = 0
                    End If
                End If
                '-- SaldoFinalDolares: Cuando x ajustes Córdobas sean > Cero y Dólares menor que cero:
                If (XdtTmpProc.ValueField("SaldoFinalCordobas") > 0) And (XdtTmpProc.ValueField("SaldoFinalDolares") < 0) Then
                    nMontoD = XdtTmpProc.ValueField("SaldoFinalDolares") 'Monto en Dolares Negativo
                ElseIf (XdtTmpProc.ValueField("SaldoFinalCordobas") < 0) And (XdtTmpProc.ValueField("SaldoFinalDolares") > 0) Then
                    nMontoD = XdtTmpProc.ValueField("SaldoFinalDolares") * -1 'Convertir Monto en Dolares Negativo
                Else 'Ambos son mayores o menores que cero:
                    nMontoD = Math.Abs(XdtTmpProc.ValueField("SaldoFinalDolares"))
                End If
                '-- Inserta Registro:
                StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                         " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
                         " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
                         " Values (" & IdFuente & ", " & XdtTmpProc.ValueField("nScnCatalogoContableID") & ", " & nDebito & ", 'N', " & _
                         " '" & XdtTmpProc.ValueField("sCodigoCuenta") & "', '" & XdtTmpProc.ValueField("sNombreCuenta") & "', " & XdtTmpProc.ValueField("SaldoFinalCordobas") & ", " & nMontoD & ")"

                'XcDatos.ExecuteNonQuery(StrSql)
                Trans.ExecuteSql(StrSql)
                Debug.Print(StrSql)
                '------------------------------
                XdtTmpProc.Source.MoveNext()
                IntRegistros = IntRegistros - 1
            End While

            '-- Encuentra Parámetro de Cuenta de Resultados:
            '--Antes cuenta de egresos
            'StrSql = "SELECT ScnCatalogoContable.nScnCatalogoContableID,  ScnCatalogoContable.sCodigoCuenta,  ScnCatalogoContable.sNombreCuenta " & _
            '         "FROM  ScnTransaccionParametros INNER JOIN StbValorCatalogo ON ScnTransaccionParametros.nStbTipoAfectacionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnCatalogoContable ON ScnTransaccionParametros.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
            '         "WHERE  (StbValorCatalogo.sCodigoInterno = '9') AND (ScnTransaccionParametros.nScnFuenteFinanciamientoID = " & IdFuente & ")"

            '--Ahora de Saldo Anterior


            StrSql = "SELECT ScnCatalogoContable.nScnCatalogoContableID,  ScnCatalogoContable.sCodigoCuenta,  ScnCatalogoContable.sNombreCuenta " & _
                     "FROM  ScnTransaccionParametros INNER JOIN StbValorCatalogo ON ScnTransaccionParametros.nStbTipoAfectacionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnCatalogoContable ON ScnTransaccionParametros.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
                     "WHERE  (StbValorCatalogo.sCodigoInterno = '7') AND (ScnTransaccionParametros.nScnFuenteFinanciamientoID = " & IdFuente & ")"

            XdtParametro.ExecuteSql(StrSql)

            '-- Encuentra Suma de Movimientos Deudores y Acreedores:
            StrSql = "SELECT  ISNULL(SUM(nSaldoFinalC), 0) AS M FROM ##" & StrNombreTablaTmp & " WHERE (nDebito = 1) AND (sTipoCuenta = 'N') AND (nFuenteID = " & IdFuente & ")"
            nMontoDebeC = Trans.ExecuteScalar(StrSql)

            StrSql = "SELECT  ISNULL(SUM(nSaldoFinalD), 0) AS M FROM ##" & StrNombreTablaTmp & " WHERE (nDebito = 1) AND (sTipoCuenta = 'N') AND (nFuenteID = " & IdFuente & ")"
            nMontoDebeD = Trans.ExecuteScalar(StrSql)

            StrSql = "SELECT  ISNULL(SUM(nSaldoFinalC), 0) AS M FROM ##" & StrNombreTablaTmp & " WHERE (nDebito = 0) AND (sTipoCuenta = 'N') AND (nFuenteID = " & IdFuente & ")"
            nMontoHaberC = Trans.ExecuteScalar(StrSql)

            StrSql = "SELECT  ISNULL(SUM(nSaldoFinalD), 0) AS M FROM ##" & StrNombreTablaTmp & " WHERE (nDebito = 0) AND (sTipoCuenta = 'N') AND (nFuenteID = " & IdFuente & ")"
            nMontoHaberD = Trans.ExecuteScalar(StrSql)




            If IncluirResumenIngresos = 1 Then

                '-- Suma de Movimientos Deudores va a Cuenta de Resultados con Naturaleza Opuesta:
                If nMontoDebeC > 0 Or nMontoDebeD > 0 Then
                    StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                             " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
                             " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
                             " Values (" & IdFuente & ", " & XdtParametro.ValueField("nScnCatalogoContableID") & ", 0, 'R', " & _
                             " '" & XdtParametro.ValueField("sCodigoCuenta") & "', '" & XdtParametro.ValueField("sNombreCuenta") & "', " & nMontoDebeC & ", " & nMontoDebeD & ")"
                    'XcDatos.ExecuteNonQuery(StrSql)
                    Trans.ExecuteSql(StrSql)
                End If
                '-- Suma de Movimientos Acreedores va a Cuenta de Resultados con Naturaleza Opuesta:
                If nMontoHaberC > 0 Or nMontoHaberD > 0 Then
                    StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                             " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
                             " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
                             " Values (" & IdFuente & ", " & XdtParametro.ValueField("nScnCatalogoContableID") & ", 1, 'R', " & _
                             " '" & XdtParametro.ValueField("sCodigoCuenta") & "', '" & XdtParametro.ValueField("sNombreCuenta") & "', " & nMontoHaberC & ", " & nMontoHaberD & ")"
                    'XcDatos.ExecuteNonQuery(StrSql)
                    Trans.ExecuteSql(StrSql)
                End If


                ''--Cambiado antes aqui busccaba el resumen de ingresos /egresos
                ''-- Suma de Movimientos Deudores de Ingresos/Egresos - Suma de Movimientos Acreedores
                ''   Ubicarlo en la Cuenta de Resultados:
                'If nMontoDebeC > nMontoHaberC Then 'Resultado en DEBE
                '    StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                '             " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
                '             " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
                '             " Values (" & IdFuente & ", " & XdtParametro.ValueField("nScnCatalogoContableID") & ", 1, 'R', " & _
                '             " '" & XdtParametro.ValueField("sCodigoCuenta") & "', '" & XdtParametro.ValueField("sNombreCuenta") & "', " & nMontoDebeC - nMontoHaberC & ", " & nMontoDebeD - nMontoHaberD & ")"
                '    'XcDatos.ExecuteNonQuery(StrSql)
                '    Trans.ExecuteSql(StrSql)
                'Else    'Resultado en HABER.
                '    StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
                '             " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
                '             " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
                '             " Values (" & IdFuente & ", " & XdtParametro.ValueField("nScnCatalogoContableID") & ", 0, 'R', " & _
                '             " '" & XdtParametro.ValueField("sCodigoCuenta") & "', '" & XdtParametro.ValueField("sNombreCuenta") & "', " & nMontoHaberC - nMontoDebeC & ", " & nMontoHaberD - nMontoDebeD & ")"
                '    'XcDatos.ExecuteNonQuery(StrSql)
                '    Trans.ExecuteSql(StrSql)
                'End If




            End If            'If IncluirResumenIngresos = 1 Then












            ''Antes encontraba la utilidad anterior aqui.
            ''------------------Deberia n-----------
            ''-- Encuentra Parámetro de Cuenta de Saldo Anterior: 
            'StrSql = "SELECT ScnCatalogoContable.nScnCatalogoContableID,  ScnCatalogoContable.sCodigoCuenta,  ScnCatalogoContable.sNombreCuenta " & _
            '         "FROM  ScnTransaccionParametros INNER JOIN StbValorCatalogo ON ScnTransaccionParametros.nStbTipoAfectacionID = StbValorCatalogo.nStbValorCatalogoID INNER JOIN ScnCatalogoContable ON ScnTransaccionParametros.nScnCatalogoContableID = ScnCatalogoContable.nScnCatalogoContableID " & _
            '         "WHERE  (StbValorCatalogo.sCodigoInterno = '7') AND (ScnTransaccionParametros.nScnFuenteFinanciamientoID = " & IdFuente & ")"
            'XdtSaldoAnterior.ExecuteSql(StrSql)

            ''-- Suma de Movimientos Deudores de Ingresos/Egresos - Suma de Movimientos Acreedores
            ''   Ubicarlo en la Cuenta de Saldo del Periodo Anterior:
            'If nMontoDebeC > nMontoHaberC Then 'Resultado en HABER:
            '    StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
            '             " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
            '             " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
            '             " Values (" & IdFuente & ", " & XdtSaldoAnterior.ValueField("nScnCatalogoContableID") & ", 0, 'U', " & _
            '             " '" & XdtSaldoAnterior.ValueField("sCodigoCuenta") & "', '" & XdtSaldoAnterior.ValueField("sNombreCuenta") & "', " & nMontoDebeC - nMontoHaberC & ", " & nMontoDebeD - nMontoHaberD & ")"
            '    'XcDatos.ExecuteNonQuery(StrSql)
            '    Trans.ExecuteSql(StrSql)
            'Else    'Resultado en DEBE:
            '    StrSql = " Insert Into ##" & StrNombreTablaTmp & " (" & _
            '             " nFuenteID, nCatalogoContableID, nDebito, sTipoCuenta, " & _
            '             " sCodigoCuenta, sNombreCuenta, nSaldoFinalC, nSaldoFinalD) " & _
            '             " Values (" & IdFuente & ", " & XdtSaldoAnterior.ValueField("nScnCatalogoContableID") & ", 1, 'U', " & _
            '             " '" & XdtSaldoAnterior.ValueField("sCodigoCuenta") & "', '" & XdtSaldoAnterior.ValueField("sNombreCuenta") & "', " & nMontoHaberC - nMontoDebeC & ", " & nMontoHaberD - nMontoDebeD & ")"
            '    'XcDatos.ExecuteNonQuery(StrSql)
            '    Trans.ExecuteSql(StrSql)
            'End If








        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtTmpProc.Close()
            XdtTmpProc = Nothing

            XdtParametro.Close()
            XdtParametro = Nothing

            XdtSaldoAnterior.Close()
            XdtSaldoAnterior = Nothing

            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
End Class