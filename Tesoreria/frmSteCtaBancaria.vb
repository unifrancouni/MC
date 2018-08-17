' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                25/07/2006
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnCtaBancaria.vb
' Descripción:          Este formulario muestra Catálogo de Cuentas Bancarias.
'-------------------------------------------------------------------------
Public Class frmSteCtaBancaria

    '- Declaración de Variables 
    Dim XdsCtaBancaria As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       frmSteCtaBancaria_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnCtaBancaria_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsCtaBancaria.Close()
            XdsCtaBancaria = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       frmScnCtaBancaria_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Cuentas Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnCtaBancaria_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            Me.HelpProvider.SetHelpKeyword(Me, "Cuentas Bancarias") 'Cuentas Bancarias (Tesorería)

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarCtaBancaria()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       CargarCtaBancaria
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCtaBancaria()
        Try
            Dim Strsql As String

            Strsql = " Select a.nSteCuentaBancariaID,a.sNumeroCuenta,a.sNombreCuenta,a.sSiglas,a.sInstitucionBancaria, " & _
                     "        a.sTipoCuenta,a.sMoneda,a.dFechaApertura,a.dFechaCierre, " & _
                     "        a.nCerrada,a.nNumeroInicialCheque, a.nNumeroFinalCheque " & _
                     " From vwSteCtaBancaria a " & _
                     " Order by a.sInstitucionBancaria,a.sNumeroCuenta"

            If XdsCtaBancaria.ExistTable("Cuenta") Then
                XdsCtaBancaria("Cuenta").ExecuteSql(Strsql)
            Else
                XdsCtaBancaria.NewTable(Strsql, "Cuenta")
                XdsCtaBancaria("Cuenta").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdCtaBancaria.DataSource = XdsCtaBancaria("Cuenta").Source

            'Actualizando el caption de los GRIDS
            Me.grdCtaBancaria.Caption = " Listado de Cuentas Bancarias (" + Me.grdCtaBancaria.RowCount.ToString + " registros)"
            FormatoCtaBancaria()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       FormatoCtaBancaria
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCtaBancaria()
        Try
            'Configuracion del Grid Bancos
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nSteCuentaBancariaID").Visible = False

            Me.grdCtaBancaria.Splits(0).DisplayColumns("sInstitucionBancaria").Width = 200
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sNombreCuenta").Width = 200
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sNumeroCuenta").Width = 110
            Me.grdCtaBancaria.Splits(0).DisplayColumns("dFechaApertura").Width = 90
            Me.grdCtaBancaria.Splits(0).DisplayColumns("dFechaCierre").Width = 90
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nCerrada").Width = 60
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sMoneda").Width = 70
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nNumeroInicialCheque").Width = 110
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nNumeroFinalCheque").Width = 110
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sTipoCuenta").Width = 110

            Me.grdCtaBancaria.Columns("sInstitucionBancaria").Caption = "Institución"
            Me.grdCtaBancaria.Columns("sNumeroCuenta").Caption = "Número de Cuenta"
            Me.grdCtaBancaria.Columns("sNombreCuenta").Caption = "Nombre de Cuenta"
            Me.grdCtaBancaria.Columns("sSiglas").Caption = "Banco"
            Me.grdCtaBancaria.Columns("nNumeroInicialCheque").Caption = "No.Inicial Chequera"
            Me.grdCtaBancaria.Columns("nNumeroFinalCheque").Caption = "No.Final Chequera"
            Me.grdCtaBancaria.Columns("dFechaApertura").Caption = "Fecha Apertura"
            Me.grdCtaBancaria.Columns("dFechaCierre").Caption = "Fecha Cierre"
            Me.grdCtaBancaria.Columns("sTipoCuenta").Caption = "Tipo de Cuenta"
            Me.grdCtaBancaria.Columns("sMoneda").Caption = "Moneda"
            Me.grdCtaBancaria.Columns("nCerrada").Caption = "Cerrada"

            Me.grdCtaBancaria.Splits(0).DisplayColumns("nCerrada").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Columns("nCerrada").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdCtaBancaria.Splits(0).DisplayColumns("dFechaApertura").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("dFechaCierre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCtaBancaria.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sNumeroCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sInstitucionBancaria").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sSiglas").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nNumeroInicialCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nNumeroFinalCheque").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("dFechaApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("dFechaCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sTipoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("sMoneda").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCtaBancaria.Splits(0).DisplayColumns("nCerrada").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsCtaBancaria = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdCtaBancaria.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       tbCtaBancaria_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbCtaBancaria.
    '-------------------------------------------------------------------------
    Private Sub tbCtaBancaria_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCtaBancaria.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCtaBancaria()
            Case "toolModificar"
                LlamaModificarCtaBancaria()
            Case "toolEliminar"
                LlamaEliminarCtaBancaria()
            Case "toolImprimir"
                ImprimirCtaBancaria()
            Case "toolRefrescar"
                InicializaVariables()
                CargarCtaBancaria()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	05/07/2007
    ' Procedure name	:	Imprimir
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de 
    '                   :   Cargos
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirCtaBancaria()
        Dim frmVisor As New frmCRVisorReporte
        Try
            If Me.grdCtaBancaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            'frmVisor.Parametros("@gfg") = ""
            frmVisor.NombreReporte = "RepScnCN7.rpt"
            frmVisor.Text = "Reporte de Cuentas Bancarias"
            'frmVisor.RegistrosSeleccion = "{ScnEstructuraContable.nNivel} = 1"
            'frmVisor.SQLQuery = "Select * From ScnEstructuraContable Where nNivel = 1"
            frmVisor.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       LlamaAgregarCtaBancaria
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCtaBancaria para Agregar una nueva Cuenta Bancaria.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCtaBancaria()
        Dim ObjFrmScnEditCtaBancaria As New frmSteEditCtaBancaria
        Try
            ObjFrmScnEditCtaBancaria.ModoFrm = "ADD"
            ObjFrmScnEditCtaBancaria.ShowDialog()

            If ObjFrmScnEditCtaBancaria.IdCtaBancaria <> 0 Then
                CargarCtaBancaria()
                XdsCtaBancaria("Cuenta").SetCurrentByID("nSteCuentaBancariaID", ObjFrmScnEditCtaBancaria.IdCtaBancaria)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmScnEditCtaBancaria.Close()
            ObjFrmScnEditCtaBancaria = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       LlamaModificarCtaBancaria
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCtaBancaria para Modificar una CtaBancaria existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCtaBancaria()
        Dim XdtCatalogoContable As New BOSistema.Win.ScnEntContabilidad.ScnCatalogoContableDataTable
        Dim ObjFrmScnEditCtaBancaria As New frmSteEditCtaBancaria
        Try
            If Me.grdCtaBancaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'If XdsCtaBancaria("Cuenta").ValueField("nCerrada") = 1 Then
            '    MsgBox("Cuenta ya se encuentra Cerrada.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            XdtCatalogoContable.Filter = " nSteCuentaBancariaID = " & XdsCtaBancaria("Cuenta").ValueField("nSteCuentaBancariaID")
            XdtCatalogoContable.Retrieve()

            If XdtCatalogoContable.Count > 0 Then
                MsgBox("No es posible Modificar. Existen Cuentas Contables asociadas.", MsgBoxStyle.Information)
                'Exit Sub
            End If

            ObjFrmScnEditCtaBancaria.ModoFrm = "UPD"
            ObjFrmScnEditCtaBancaria.IdCtaBancaria = XdsCtaBancaria("Cuenta").ValueField("nSteCuentaBancariaID")
            ObjFrmScnEditCtaBancaria.ShowDialog()

            If ObjFrmScnEditCtaBancaria.IdCtaBancaria <> 0 Then
                InicializaVariables()
                CargarCtaBancaria()
                'FormatoCtaBancaria()
                XdsCtaBancaria("Cuenta").SetCurrentByID("nSteCuentaBancariaID", ObjFrmScnEditCtaBancaria.IdCtaBancaria)
                Me.grdCtaBancaria.Row = XdsCtaBancaria("Cuenta").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmScnEditCtaBancaria.Close()
            ObjFrmScnEditCtaBancaria = Nothing

            XdtCatalogoContable.Close()
            XdtCatalogoContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       LlamaEliminarCtaBancaria
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de una CtaBancaria existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCtaBancaria()
        Dim XdtCuenta As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim StrSql As String
            If Me.grdCtaBancaria.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If
            'Imposible si existe en una Cuenta Contable:
            StrSql = "SELECT  nSteCuentaBancariaID FROM  ScnCatalogoContable WHERE  (nSteCuentaBancariaID = " & XdsCtaBancaria("Cuenta").ValueField("nSteCuentaBancariaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("No es posible Eliminar. Existen Cuentas Contables asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtCuenta.ExecuteSqlNotTable("Delete From SteCuentaBancaria where nSteCuentaBancariaID=" & XdsCtaBancaria("Cuenta").ValueField("nSteCuentaBancariaID"))
                CargarCtaBancaria()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                Me.grdCtaBancaria.Caption = "Listado de Cuentas Bancarias (" + Me.grdCtaBancaria.RowCount.ToString + " registros)"
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
        Finally
            XdtCuenta.Close()
            XdtCuenta = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Este procedimiento permite cerrar la opción de CtaBancaria.
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
    ' Fecha:                25/07/2006
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
    ' Fecha:                25/07/2006
    ' Procedure Name:       grdCtaBancaria_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Cuenta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCtaBancaria_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCtaBancaria.DoubleClick
        Try
            If Seg.HasPermission("ModificarCtaBancaria") Then
                LlamaModificarCtaBancaria()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdCtaBancaria_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCtaBancaria.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       grdCtaBancaria_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCtaBancaria_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCtaBancaria.Filter
        Try
            XdsCtaBancaria("Cuenta").FilterLocal(e.Condition)
            Me.grdCtaBancaria.Caption = " Listado de Cuentas Bancarias (" + Me.grdCtaBancaria.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                25/07/2006
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarCtaBancaria") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarCtaBancaria") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarCtaBancaria") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirCtaBancaria") Then
                Me.toolImprimir.Enabled = True
            Else
                Me.toolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	18/01/2007
    ' Procedure name	:	ImprimirCuentaBancaria
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de 
    '                   :   cuentas Bancarias
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirCuentaBancaria()
        'Try
        '    Dim ObjfrmparaTipoMov As frmSteParamentroBanco

        '    ObjfrmparaTipoMov = New frmSteParamentroBanco
        '    ObjfrmparaTipoMov.NomRep = frmSteParamentroBanco.EnumReportes.rptSteCuentaBancaria
        '    ObjfrmparaTipoMov.ShowDialog()
        'Catch ex As Exception
        '    Control_Error(ex)
        'End Try
    End Sub


    Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles toolImprimir.Click
        Try
            ImprimirCuentaBancaria()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class