' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                05/07/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmScnCatalogoContable.vb
' Descripción:          Este formulario muestra Catálogo de Niveles.
'-------------------------------------------------------------------------
Public Class frmScnCatalogoContable

    '- Declaración de Variables 
    Dim XdsCatContable As BOSistema.Win.XDataSet

    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmScnEstructuraContable_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde Elimino
    '                       variables que fueron instanciadas de manera global al formulario.
    '-------------------------------------------------------------------------
    Private Sub frmScnCatalogoContable_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdsCatContable.Close()
            XdsCatContable = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       frmScnEstructuraContable_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo listado de Cuentas Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmScnCatalogoContable_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try

            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Celeste")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarCatContable()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       CargarCatContable
    ' Descripción:          Este procedimiento permite cargar 
    '                       los datos sobre el Catálogo Contable en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCatContable()
        Try
            Dim Strsql As String

            Strsql = " Select a.nScnCatalogoContableID,a.sCodigoCuenta,a.sNombreCuenta,a.nNivel, " & _
                     " a.sDebeHaber,a.sTipoCuenta,a.nCuentaDetalle " & _
                     " From vwScnCatalogoContable a " & _
                     " Order by a.sCodigoCuenta "

            If XdsCatContable.ExistTable("CatContable") Then
                XdsCatContable("CatContable").ExecuteSql(Strsql)
            Else
                XdsCatContable.NewTable(Strsql, "CatContable")
                XdsCatContable("CatContable").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdCatContable.DataSource = XdsCatContable("CatContable").Source

            'Actualizando el caption de los GRIDS
            Me.grdCatContable.Caption = " Listado de Niveles (" + Me.grdCatContable.RowCount.ToString + " registros)"
            FormatoCatContable()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       FormatoEstructura
    ' Descripción:          Este procedimiento permite configurar 
    '                       los datos sobre Ctas. Bancarias en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCatContable()
        Try
            'Configuracion del Grid Cargos
            Me.grdCatContable.Splits(0).DisplayColumns("nScnCatalogoContableID").Visible = False

            Me.grdCatContable.Splits(0).DisplayColumns("sCodigoCuenta").Width = 120
            Me.grdCatContable.Splits(0).DisplayColumns("sNombreCuenta").Width = 300
            Me.grdCatContable.Splits(0).DisplayColumns("nNivel").Width = 60
            Me.grdCatContable.Splits(0).DisplayColumns("sDebeHaber").Width = 100
            Me.grdCatContable.Splits(0).DisplayColumns("sTipoCuenta").Width = 100
            Me.grdCatContable.Splits(0).DisplayColumns("nCuentaDetalle").Width = 60

            Me.grdCatContable.Columns("nNivel").Caption = "Nivel"
            Me.grdCatContable.Columns("sCodigoCuenta").Caption = "Código Cuenta"
            Me.grdCatContable.Columns("sNombreCuenta").Caption = "Nombre Cuenta"
            Me.grdCatContable.Columns("sTipoCuenta").Caption = "Clase de Cuenta"
            Me.grdCatContable.Columns("sDebeHaber").Caption = "Tipo de Cuenta"
            Me.grdCatContable.Columns("nCuentaDetalle").Caption = "Detalle"

            Me.grdCatContable.Splits(0).DisplayColumns("nNivel").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("sDebeHaber").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("sTipoCuenta").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCatContable.Splits(0).DisplayColumns("nCuentaDetalle").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Columns("nCuentaDetalle").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox

            Me.grdCatContable.Splits(0).DisplayColumns("nNivel").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("sCodigoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("sNombreCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("sTipoCuenta").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("sDebeHaber").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCatContable.Splits(0).DisplayColumns("nCuentaDetalle").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            XdsCatContable = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos
            Me.grdCatContable.ClearFields()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       tbEstructuraCuenta_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip llamado tbEstructuraCuenta.
    '-------------------------------------------------------------------------
    Private Sub tbEstructuraCuenta_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCatContable.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCatContable()
            Case "toolAgregarNiveln"
                LlamaAgregarCatContableNiveln()
            Case "toolModificar"
                LlamaModificarCatContable()
            Case "toolEliminar"
                LlamaEliminarCatContable()
            Case "toolRefrescar"
                InicializaVariables()
                CargarCatContable()
            Case "ToolImprimir"
                ImprimirCatContable()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaAgregarCatContable
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Agregar un nuevo Cargo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCatContable()
        Dim ObjFrmScnEditCatalogoContable As New frmScnEditCatalogoContable
        Try
            If ValidaDatosAgregarPrimerNivel() Then

                ObjFrmScnEditCatalogoContable.ModoFrm = "ADD"
                ObjFrmScnEditCatalogoContable.IdCatContablePadre = 0
                ObjFrmScnEditCatalogoContable.ShowDialog()

                If ObjFrmScnEditCatalogoContable.IdCatContable <> 0 Then
                    CargarCatContable()
                    XdsCatContable("CatContable").SetCurrentByID("nScnCatalogoContableID", ObjFrmScnEditCatalogoContable.IdCatContable)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmScnEditCatalogoContable.Close()
            ObjFrmScnEditCatalogoContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAgregarPrimerNivel() As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            ValidaDatosAgregarPrimerNivel = True

            'Validar que existan Fuentes de Financiamiento Activas
            strSQL = " SELECT nScnFuenteFinanciamientoID FROM ScnFuenteFinanciamiento " & _
                     " WHERE nActiva = 1"

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No Existen Fuentes de Financiamiento Activas. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAgregarPrimerNivel = False
                Exit Function
            End If

            'Validar que exista en la Estructura Contable el Primer Nivel
            strSQL = " SELECT nScnEstructuraContableID,nDigitosNivel FROM ScnEstructuraContable " & _
                     " WHERE nNivel = 1"

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No Existe el Primer Nivel en la Estructura de Cuentas. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAgregarPrimerNivel = False
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosAgregarNivelN() As Boolean
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            ValidaDatosAgregarNivelN = True

            'Validar que existan Fuentes de Financiamiento Activas
            strSQL = " SELECT nScnFuenteFinanciamientoID FROM ScnFuenteFinanciamiento " & _
                     " WHERE nActiva = 1"

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No Existen Fuentes de Financiamiento Activas. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAgregarNivelN = False
                Exit Function
            End If

            'Validar que existan registros y por lo tanto Cuentas de Primer Nivel
            If Me.grdCatContable.RowCount = 0 Then
                MsgBox("Deben existir Cuentas de Primer Nivel.", MsgBoxStyle.Information)
                ValidaDatosAgregarNivelN = False
                Exit Function
            End If

            'Validar que la Cuenta Padre no sea de Detalle
            If XdsCatContable("CatContable").ValueField("nCuentaDetalle") = 1 Then
                MsgBox("Cuenta Padre NO DEBE ser una Cuenta de Detalle.", MsgBoxStyle.Information)
                ValidaDatosAgregarNivelN = False
                Exit Function
            End If

            'Validar que exista en la Estructura Contable exista el Nivel a registrar
            strSQL = " SELECT nScnEstructuraContableID,nDigitosNivel FROM ScnEstructuraContable " & _
                     " WHERE nNivel = " & XdsCatContable("CatContable").ValueField("nNivel") + 1

            XdtDatos.ExecuteSql(strSQL)

            If XdtDatos.Count <= 0 Then
                MsgBox("No Existe el Nivel de la Nueva Cuenta en la Estructura de Cuentas. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosAgregarNivelN = False
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaAgregarCatContable
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCargo para Agregar un nuevo Cargo.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCatContableNiveln()
        Dim ObjFrmScnEditCatalogoContable As New frmScnEditCatalogoContable
        Try
            If ValidaDatosAgregarNivelN() Then
                ObjFrmScnEditCatalogoContable.ModoFrm = "ADD"
                ObjFrmScnEditCatalogoContable.IdCatContablePadre = XdsCatContable("CatContable").ValueField("nScnCatalogoContableID")
                ObjFrmScnEditCatalogoContable.ShowDialog()

                If ObjFrmScnEditCatalogoContable.IdCatContable <> 0 Then
                    CargarCatContable()
                    XdsCatContable("CatContable").SetCurrentByID("nScnCatalogoContableID", ObjFrmScnEditCatalogoContable.IdCatContable)
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmScnEditCatalogoContable.Close()
            ObjFrmScnEditCatalogoContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaModificarCatContable
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmScnEditCatalogoContable para Modificar un cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCatContable()
        Dim XdtDatos As New BOSistema.Win.XDataSet.xDataTable
        Dim ObjFrmScnEditCatalogoContable As New frmScnEditCatalogoContable
        Try
            Dim strSQL As String = ""

            If Me.grdCatContable.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            strSQL = " SELECT nScnTransaccionContableDetalleID FROM ScnTransaccionContableDetalle " & _
                     " WHERE nScnCatalogoContableID = " & XdsCatContable("CatContable").ValueField("nScnCatalogoContableID")

            XdtDatos.ExecuteSql(strSQL)
            If XdtDatos.Count > 0 Then
                MsgBox("No es posible Modificar. Existen Transacciones Contables asociadas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            ObjFrmScnEditCatalogoContable.ModoFrm = "UPD"
            'ObjFrmScnEditCatalogoContable.IdCatContablePadre = XdsCatContable("CatContable").ValueField("nScnCatalogoContableID")
            ObjFrmScnEditCatalogoContable.IdCatContable = XdsCatContable("CatContable").ValueField("nScnCatalogoContableID")
            ObjFrmScnEditCatalogoContable.ShowDialog()

            If ObjFrmScnEditCatalogoContable.IdCatContable <> 0 Then
                InicializaVariables()
                CargarCatContable()
                XdsCatContable("CatContable").SetCurrentByID("nScnCatalogoContableID", ObjFrmScnEditCatalogoContable.IdCatContable)
                Me.grdCatContable.Row = XdsCatContable("CatContable").BindingSource.Position
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'ObjFrmScnEditCatalogoContable.Close()
            ObjFrmScnEditCatalogoContable = Nothing

            XdtDatos.Close()
            XdtDatos = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       LlamaEliminarCatContable
    ' Descripción:          Este procedimiento permite eliminar un registro
    '                       de un Cargo existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaEliminarCatContable()
        Dim XdtCatContable As New BOSistema.Win.XDataSet.xDataTable
        Try

            If ValidaDatosEliminar() Then
                If MsgBox("¿Está seguro de eliminar el registro seleccionado?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                    XdtCatContable.ExecuteSqlNotTable("Delete From ScnCatalogoContable where nScnCatalogoContableID=" & XdsCatContable("CatContable").ValueField("nScnCatalogoContableID"))
                    CargarCatContable()

                    MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
                    Me.grdCatContable.Caption = "Listado de Cuentas del Catálogo Contable (" + Me.grdCatContable.RowCount.ToString + " registros)"
                End If
            End If
        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtCatContable.Close()
            XdtCatContable = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                28/07/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEliminar() As Boolean
        Try
            ValidaDatosEliminar = True

            'Validar que existan Fuentes de Financiamiento Activas
            If Me.grdCatContable.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                ValidaDatosEliminar = False
                Exit Function
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
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
    ' Fecha:                05/07/2007
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
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdEstructuraCuenta_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Cuenta existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCatContable_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCatContable.DoubleClick
        Try
            If Seg.HasPermission("ModificarCatalogoContable") Then
                LlamaModificarCatContable()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'En caso que ocurra otro Tipo de Error
    Private Sub grdCatContable_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCatContable.Error
        Control_Error(e.Exception)
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       grdCtaBancaria_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCatContable_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCatContable.Filter
        Try
            XdsCatContable("CatContable").FilterLocal(e.Condition)
            Me.grdCatContable.Caption = " Listado de Cuentas del Catálogo Contable (" + Me.grdCatContable.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                05/07/2007
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones de la Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            ' Agregar
            If Seg.HasPermission("AgregarCatalogoContable") Then
                Me.toolAgregar.Enabled = True
            Else
                Me.toolAgregar.Enabled = False
            End If

            ' Agregar Nivel n
            If Seg.HasPermission("AgregarCuentaNiveln") Then
                Me.toolAgregarNiveln.Enabled = True
            Else
                Me.toolAgregarNiveln.Enabled = False
            End If

            'Editar
            If Seg.HasPermission("ModificarCatalogoContable") Then
                Me.toolModificar.Enabled = True
            Else
                Me.toolModificar.Enabled = False
            End If

            'Eliminar
            If Seg.HasPermission("EliminarCatalogoContable") Then
                Me.toolEliminar.Enabled = True
            Else
                Me.toolEliminar.Enabled = False
            End If

            'Imprimir
            If Seg.HasPermission("ImprimirCatalogoContable") Then
                Me.ToolImprimir.Enabled = True
            Else
                Me.ToolImprimir.Enabled = False
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    :	
    ' Date			    :	05/07/2007
    ' Procedure name	:	Imprimir
    ' Description		:	Este procedimiento se encarga de mostrar el formulario de impresion de 
    '                   :   Cargos
    ' -----------------------------------------------------------------------------------------
    Private Sub ImprimirCatContable()
        Dim ObjFrmScnParametroCatalogoContable As New frmScnParametroCatalogoContable
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String = ""

            If Me.grdCatContable.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'ObjFrmScnParametroCatalogoContable.NomRep = 1
            'ObjFrmScnParametroCatalogoContable.intSclFichaID = XdtFicha.ValueField("nSclFichaSociaID")
            'ObjFrmScnParametroCatalogoContable.IdConsecutivoPrestamo = XdtFicha.ValueField("nConsecutivoCredito")
            'ObjFrmSclParametroFicha.ModoFrm = "IMPRIMIR"
            'ObjFrmSclParametroFicha.strColor = "Verde"
            'ObjFrmSclParametroFicha.strTipoComprobante = Me.strTipoComp
            ObjFrmScnParametroCatalogoContable.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing

            ObjFrmScnParametroCatalogoContable.Close()
            ObjFrmScnParametroCatalogoContable = Nothing
        End Try
    End Sub

    'Private Sub ToolImprimir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolImprimir.Click
    '    Try
    '        ImprimirEstructura()

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    End Try
    'End Sub

End Class