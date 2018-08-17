' ------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                04/01/2008
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmSteCaja.vb
' Descripción:          Este formulario muestra Catálogo de Cajas.
'-------------------------------------------------------------------------

Public Class frmSteCaja
    '- Declaración de Variables. 
    Dim XdtCaja As BOSistema.Win.XDataSet.xDataTable
    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       frmSteCaja_Load
    ' Descripción:          Evento Load del formulario donde se inicializan 
    '                       variables y se carga listado de Cajas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub frmSteCaja_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI

        Try
            '-- Asignar el tema de Color a utilizarse.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Naranja")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarCaja()
            FormatoCaja()
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       frmSteCaja_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde se eliminan variables
    '                       que fueron instanciadas de manera global.
    '-------------------------------------------------------------------------
    Private Sub frmSteCaja_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try

            XdtCaja.Close()
            XdtCaja = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	Yesenia Gutiérrez
    ' Date			    		:	13/03/2008
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
    ' Fecha:                04/01/2008
    ' Procedure Name:       InicializaVariables
    ' Descripción:          Este procedimiento permite inicializar el Grid.
    '-------------------------------------------------------------------------
    Private Sub InicializaVariables()
        Try
            '-- Encuentra parámetros de Delegación.
            EncuentraParametros()

            XdtCaja = New BOSistema.Win.XDataSet.xDataTable
            'Limpiar los Grids (estructura y Datos).
            Me.grdCaja.ClearFields()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       CargarCaja
    ' Descripción:          Procedimiento permite cargar datos de las Cajas 
    '                       en el Grid.
    '-------------------------------------------------------------------------
    Private Sub CargarCaja()
        Try

            'Asignar Qry al Xdt:
            Dim Strsql As String
            If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa.
                Strsql = " Select * From vwSteCaja " & _
                         " Order by vwSteCaja.nCodigo"
            Else 'Solo Filtra las Solicitudes de Cheque de su Delegación:
                Strsql = " Select * From vwSteCaja " & _
                         " WHERE (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") " & _
                         " Order by vwSteCaja.nCodigo"
            End If
            
            XdtCaja.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdCaja.DataSource = XdtCaja.Source

            'Actualizando el caption del GRID:
            Me.grdCaja.Caption = " Listado de Cajas (" + Me.grdCaja.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       FormatoCaja
    ' Descripción:          Este procedimiento permite configurar los datos 
    '                       sobre Cajas en el Grid.
    '-------------------------------------------------------------------------
    Private Sub FormatoCaja()
        Try

            'Oculta llave principal en el Grid:
            Me.grdCaja.Splits(0).DisplayColumns("nSteCajaID").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("nStbMercadoID").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("nStbDelegacionProgramaID").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("CodPrograma").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("nStbTipoProgramaID").Visible = False
            Me.grdCaja.Splits(0).DisplayColumns("nStbTipoPlazoPagosID").Visible = False

            'Establecer ancho de columnas visibles al usuario:
            Me.grdCaja.Splits(0).DisplayColumns("nCerrada").Width = 60
            Me.grdCaja.Splits(0).DisplayColumns("TieneCajaDesconectada").Width = 80
            Me.grdCaja.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.grdCaja.Splits(0).DisplayColumns("sDescripcionCaja").Width = 250
            Me.grdCaja.Splits(0).DisplayColumns("dFechaApertura").Width = 80
            Me.grdCaja.Splits(0).DisplayColumns("Barrio").Width = 180
            Me.grdCaja.Splits(0).DisplayColumns("sMercado").Width = 180
            Me.grdCaja.Splits(0).DisplayColumns("sLugarPagos").Width = 180
            Me.grdCaja.Splits(0).DisplayColumns("dFechaCierre").Width = 80
            Me.grdCaja.Splits(0).DisplayColumns("TipoPrograma").Width = 160
            Me.grdCaja.Splits(0).DisplayColumns("PlazoPagos").Width = 100
            
            'Ubicar Nombre de los Campos:
            Me.grdCaja.Columns("nCerrada").Caption = "Cerrada"
            Me.grdCaja.Columns("nCodigo").Caption = "Código"
            Me.grdCaja.Columns("sDescripcionCaja").Caption = "Nombre de Caja"
            Me.grdCaja.Columns("dFechaApertura").Caption = "Fecha Apertura"
            Me.grdCaja.Columns("Barrio").Caption = "Barrio"
            Me.grdCaja.Columns("sMercado").Caption = "Mercado"
            Me.grdCaja.Columns("sLugarPagos").Caption = "Ubicación"
            Me.grdCaja.Columns("dFechaCierre").Caption = "Fecha Cierre"
            Me.grdCaja.Columns("TipoPrograma").Caption = "Tipo de Programa"
            Me.grdCaja.Columns("PlazoPagos").Caption = "Periodicidad Pagos"
            Me.grdCaja.Columns("TieneCajaDesconectada").Caption = "Desconectada"

            'Check Box:
            Me.grdCaja.Columns("nCerrada").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdCaja.Splits(0).DisplayColumns("nCerrada").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.grdCaja.Columns("TieneCajaDesconectada").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
            Me.grdCaja.Splits(0).DisplayColumns("TieneCajaDesconectada").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center



            'Alineación Campos Centrados:
            Me.grdCaja.Splits(0).DisplayColumns("dFechaApertura").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("dFechaCierre").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Alineación Encabezados Centrados:
            Me.grdCaja.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("sDescripcionCaja").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("dFechaApertura").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("Barrio").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("sMercado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("sLugarPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("dFechaCierre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("nCerrada").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("TipoPrograma").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("PlazoPagos").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdCaja.Splits(0).DisplayColumns("TieneCajaDesconectada").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       tbCaja_ItemClicked
    ' Descripción:          Este evento permite manejar las opciones del control
    '                       toolStrip (tbBanco).
    '-------------------------------------------------------------------------
    Private Sub tbCaja_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbCaja.ItemClicked

        Select Case e.ClickedItem.Name
            Case "toolAgregar"
                LlamaAgregarCaja()
            Case "toolModificar"
                LlamaModificarCaja()
            Case "toolInactivar"
                LlamaInactivarCaja()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolRefrescar"
                InicializaVariables()
                CargarCaja()
                FormatoCaja()
            Case "toolCerrar"
                LlamaCerrar()
            Case "toolCajaDesconectadaAgregar"
                LlamaPonerCajaDesconectada()
            Case "toolCajaDesconectadaEliminar"
                LlamaQuitarCajaDesconectada()

            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       LlamaImprimir
    ' Descripción:          Este procedimiento permite Imprimir El Listado
    '                       de Cajas. 
    '-------------------------------------------------------------------------
    Private Sub LlamaImprimir()
        Dim frmVisor As New frmCRVisorReporte
        Try
            Dim strSQL As String = ""
            If Me.grdCaja.RowCount = 0 Then
                MsgBox("No existen registros grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            frmVisor.WindowState = FormWindowState.Maximized
            frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSteTE1.rpt"
            frmVisor.Text = "Cajas del Programa"
            If IntPermiteConsultar = 1 Then
                frmVisor.SQLQuery = "Select * From vwSteCaja Order by nCodigo"
            Else
                frmVisor.SQLQuery = "Select * From vwSteCaja Where (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ") Order by nCodigo"
            End If
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       LlamaAgregarCaja
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCaja para Agregar una nueva Caja.
    '-------------------------------------------------------------------------
    Private Sub LlamaAgregarCaja()
        Dim ObjFrmSteEditCaja As New frmSteEditCaja
        Try

            'Indicador de adición:
            ObjFrmSteEditCaja.ModoFrm = "ADD"
            ObjFrmSteEditCaja.intStePermiteEditar = IntPermiteEditar
            'Inhabilitar Cierre: 
            ObjFrmSteEditCaja.grpCierre.Enabled = False
            'Mostrar forma para la adición:
            ObjFrmSteEditCaja.ShowDialog()

            If ObjFrmSteEditCaja.IdCaja <> 0 Then 'No se produjo error.
                'Refrescar registros: 
                CargarCaja()
                'Se ubica sobre el registro recién ingresado.
                XdtCaja.SetCurrentByID("nSteCajaID", ObjFrmSteEditCaja.IdCaja)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSteEditCaja.Close()
            ObjFrmSteEditCaja = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       LlamaModificarCaja
    ' Descripción:          Este procedimiento permite llamar al formulario
    '                       frmSteEditCaja para Modificar una Caja existente.
    '-------------------------------------------------------------------------
    Private Sub LlamaModificarCaja()
        Dim ObjFrmSteEditCaja As New frmSteEditCaja
        Try

            Dim StrSql As String
            'Si no hay registros ingresados salir del Sub:
            If Me.grdCaja.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtCaja.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Modificar Cajas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If


 



            'Si la Caja no se encuentra Activa Advertir:
            If XdtCaja.ValueField("nCerrada") = 1 Then
                MsgBox("La Caja está Cerrada.", MsgBoxStyle.Information)
                Exit Sub
            End If



            'Imposible modificar Caja si tiene Arqueos asociados:
            StrSql = "SELECT A.nSteCajaID " & _
                     "FROM  SteArqueoCaja A INNER JOIN StbValorCatalogo C ON A.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
                     "WHERE (A.nSteCajaID = " & XdtCaja.ValueField("nSteCajaID") & ")"
            If RegistrosAsociados(StrSql) Then




                ' Si tiene el permiso 1269 - PModificarCaja
                StrSql = "SELECT     dbo.SsgCuenta.Login, dbo.SsgAccion.SsgAccionID, dbo.SsgAccion.CodInterno " & _
                          "FROM         dbo.SsgCuenta INNER JOIN " & _
                          "dbo.SsgCuentaRol ON dbo.SsgCuenta.SsgCuentaID = dbo.SsgCuentaRol.objCuentaID INNER JOIN " & _
                          "dbo.SsgRol ON dbo.SsgCuentaRol.objRolID = dbo.SsgRol.SsgRolID INNER JOIN " & _
                          "dbo.SsgRolAccion ON dbo.SsgRol.SsgRolID = dbo.SsgRolAccion.objRolID INNER JOIN " & _
                          "dbo.SsgAccion ON dbo.SsgRolAccion.objAccionID = dbo.SsgAccion.SsgAccionID " & _
                          "WHERE (dbo.SsgCuenta.Login = '" & InfoSistema.LoginName & "') AND " & _
                          "(dbo.SsgAccion.CodInterno = 'PModificarCaja') "
                If RegistrosAsociados(StrSql) = False Then
                    MsgBox("No tiene permisos especiales asociados para modificar esta Caja", MsgBoxStyle.Information)
                    Exit Sub
                End If
















                'MsgBox("Imposible Modificar. Existen Arqueos asociados.", MsgBoxStyle.Information)
                'Exit Sub




            End If


            'Indicador de Actualización:
            ObjFrmSteEditCaja.ModoFrm = "UPD"
            ObjFrmSteEditCaja.intStePermiteEditar = IntPermiteEditar
            'Se indica llave principal:
            ObjFrmSteEditCaja.IdCaja = XdtCaja.ValueField("nSteCajaID")
            'Inhabilitar Cierre: 
            ObjFrmSteEditCaja.grpCierre.Enabled = False
            'Se muestra en formulario de edición:
            ObjFrmSteEditCaja.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            CargarCaja()
            'Y se posiciona sobre el registro modificado.
            XdtCaja.SetCurrentByID("nSteCajaID", ObjFrmSteEditCaja.IdCaja)
            'Refresca posicionamiento del Grid:
            Me.grdCaja.Row = XdtCaja.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSteEditCaja.Close()
            ObjFrmSteEditCaja = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       LlamaInactivarCaja
    ' Descripción:          Este procedimiento permite inactivar una Caja.
    '-------------------------------------------------------------------------
    Private Sub LlamaInactivarCaja()
        Dim ObjFrmSteEditCaja As New frmSteEditCaja
        Try
            Dim StrSql As String
            'Si no hay registros ingresados salir del Sub:
            If Me.grdCaja.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtCaja.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Inactivar Cajas de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            'Imposible Cerrar Caja si tiene Arqueos En Proceso asociados:
            StrSql = "SELECT A.nSteCajaID " & _
                     "FROM  SteArqueoCaja A INNER JOIN StbValorCatalogo C ON A.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
                     "WHERE (C.sCodigoInterno = '1') AND (A.nSteCajaID = " & XdtCaja.ValueField("nSteCajaID") & ")"
            If RegistrosAsociados(StrSql) Then
                MsgBox("Imposible Cerrar. Existen Arqueos En Proceso asociados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si la Caja no se encuentra Activa Advertir:
            If XdtCaja.ValueField("nCerrada") = 1 Then
                MsgBox("La Caja está inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Indicador de Actualización: 
            ObjFrmSteEditCaja.ModoFrm = "INN"
            ObjFrmSteEditCaja.intStePermiteEditar = IntPermiteEditar
            'Se indica llave principal:
            ObjFrmSteEditCaja.IdCaja = XdtCaja.ValueField("nSteCajaID")
            'Habilitar Cierre:
            ObjFrmSteEditCaja.grpCierre.Enabled = True
            ObjFrmSteEditCaja.grpGenerales.Enabled = False
            ObjFrmSteEditCaja.grpLocalizacion.Enabled = False
            ObjFrmSteEditCaja.chkCerrada.Checked = True
            ObjFrmSteEditCaja.chkCerrada.Enabled = False
            'Se muestra en formulario de edición:
            ObjFrmSteEditCaja.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            CargarCaja()
            'Y se posiciona sobre el registro modificado.
            XdtCaja.SetCurrentByID("nSteCajaID", ObjFrmSteEditCaja.IdCaja)
            'Refresca posicionamiento del Grid:
            Me.grdCaja.Row = XdtCaja.BindingSource.Position

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjFrmSteEditCaja.Close()
            ObjFrmSteEditCaja = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       LlamaCerrar
    ' Descripción:          Procedimiento permite cerrar la opción de Cajas.
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
    ' Fecha:                04/01/2008
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
    ' Fecha:                04/01/2008
    ' Procedure Name:       grdCaja_DoubleClick
    ' Descripción:          Este evento permite llamar al procedimiento encargado
    '                       de Modificar una Caja existente, al hacer doble click
    '                       sobre el registro deseado.
    '-------------------------------------------------------------------------
    Private Sub grdCaja_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles grdCaja.DoubleClick
        Try
            If Seg.HasPermission("ModificarCaja") Then
                LlamaModificarCaja()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdCaja_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdCaja.Error
        Control_Error(e.Exception)
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       grdCaja_Filter
    ' Descripción:          Este evento permite realizar el filtrado correspondiente
    '                       al FilterBar del Grid.
    '-------------------------------------------------------------------------
    Private Sub grdCaja_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdCaja.Filter
        Try
            XdtCaja.FilterLocal(e.Condition)
            'Se invocá para refrescar el count de registros:
            Me.grdCaja.Caption = " Listado de Cajas (" + Me.grdCaja.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                04/01/2008
    ' Procedure Name:       Seguridad
    ' Descripción:          Este procedimiento permite validar si el Usuario
    '                       tiene permiso para ejecutar las opciones del Toolbar.
    '-------------------------------------------------------------------------
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()
            'Agregar:
            If Seg.HasPermission("AgregarCaja") = False Then
                Me.tbCaja.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolAgregar").Enabled = True
            End If
            'Editar:
            If Seg.HasPermission("ModificarCaja") = False Then
                Me.tbCaja.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolModificar").Enabled = True
            End If
            'Inactivar:
            If Seg.HasPermission("CerrarCaja") = False Then
                Me.tbCaja.Items("toolInactivar").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolInactivar").Enabled = True
            End If
            'Imprimir:
            If Seg.HasPermission("ImprimirListadoCajas") = False Then
                Me.tbCaja.Items("toolImprimir").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolImprimir").Enabled = True
            End If

            'Imprimir:
            If Seg.HasPermission("AgregarCajaDesconectada") = False Then
                Me.tbCaja.Items("toolCajaDesconectadaAgregar").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolCajaDesconectadaAgregar").Enabled = True
            End If

            'Imprimir:
            If Seg.HasPermission("QuitarCajaDesconectada") = False Then
                Me.tbCaja.Items("toolCajaDesconectadaEliminar").Enabled = False
            Else  'Habilita
                Me.tbCaja.Items("toolCajaDesconectadaEliminar").Enabled = True
            End If




        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub LlamaPonerCajaDesconectada()

        Try
            Dim XdtTmp As New BOSistema.Win.XDataSet.xDataTable
            Dim XIdCaja As Long
            Dim StrSql As String
            'Si no hay registros ingresados salir del Sub:
            If Me.grdCaja.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtCaja.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Poner como Caja Desconectada de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If








            ''Imposible Cerrar Caja si tiene Arqueos En Proceso asociados:
            'StrSql = "SELECT A.nSteCajaID " & _
            '         "FROM  SteArqueoCaja A INNER JOIN StbValorCatalogo C ON A.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
            '         "WHERE (C.sCodigoInterno = '1') AND (A.nSteCajaID = " & XdtCaja.ValueField("nSteCajaID") & ")"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("Imposible Cerrar. Existen Arqueos En Proceso asociados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Si la Caja no se encuentra Activa Advertir:
            If XdtCaja.ValueField("nCerrada") = 1 Then
                MsgBox("La Caja está inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Indicador de Actualización: 
            XdtTmp.ExecuteSql("Select nSteCajaID from  dbo.SttProcesarCajaParametroES Where  nSteCajaID=" & XdtCaja.ValueField("nSteCajaID"))
            If XdtTmp.Count > 0 Then
                MsgBox("La Caja ya esta Asignada como Local.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If MsgBox("Esta seguro de Poner como Caja Desconectada.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

 

            XdtTmp.ExecuteSql("Insert Into SttProcesarCajaParametroES(nSteCajaID) Values(" & XdtCaja.ValueField("nSteCajaID") & ")")



            XIdCaja = XdtCaja.ValueField("nSteCajaID")
            CargarCaja()
            'Y se posiciona sobre el registro modificado.
            XdtCaja.SetCurrentByID("nSteCajaID", XIdCaja)
            'Refresca posicionamiento del Grid:
            Me.grdCaja.Row = XdtCaja.BindingSource.Position
            MsgBox("La Caja a sido Asignada como Local.", MsgBoxStyle.Information)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:

        End Try
    End Sub


    Private Sub LlamaQuitarCajaDesconectada()

        Try
            Dim XdtTmp As New BOSistema.Win.XDataSet.xDataTable
            Dim XIdCaja As Long
            Dim StrSql As String
            'Si no hay registros ingresados salir del Sub:
            If Me.grdCaja.RowCount = 0 Then
                MsgBox("No Existen Registros Grabados.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            If IntPermiteEditar = 0 Then
                If InfoSistema.IDDelegacion <> XdtCaja.ValueField("nStbDelegacionProgramaID") Then
                    MsgBox("Imposible Quitar como Caja Desconectada de otra Delegación.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If








            ''Imposible Cerrar Caja si tiene Arqueos En Proceso asociados:
            'StrSql = "SELECT A.nSteCajaID " & _
            '         "FROM  SteArqueoCaja A INNER JOIN StbValorCatalogo C ON A.nStbEstadoArqueoID = C.nStbValorCatalogoID " & _
            '         "WHERE (C.sCodigoInterno = '1') AND (A.nSteCajaID = " & XdtCaja.ValueField("nSteCajaID") & ")"
            'If RegistrosAsociados(StrSql) Then
            '    MsgBox("Imposible Cerrar. Existen Arqueos En Proceso asociados.", MsgBoxStyle.Information)
            '    Exit Sub
            'End If

            'Si la Caja no se encuentra Activa Advertir:
            If XdtCaja.ValueField("nCerrada") = 1 Then
                MsgBox("La Caja está inactiva.", MsgBoxStyle.Information)
                Exit Sub
            End If

            'Indicador de Actualización: 

            XdtTmp.ExecuteSql("Select nSteCajaID from  dbo.SttProcesarCajaParametroES Where  nSteCajaID=" & XdtCaja.ValueField("nSteCajaID"))
            If XdtTmp.Count = 0 Then
                MsgBox("La Caja No esta Asignada como Local.", MsgBoxStyle.Information)
                Exit Sub
            End If


  

            XdtTmp.ExecuteSql("Select nSteCajaID from dbo.SttProcesarEnvioES Where  nSteCajaID=" & XdtCaja.ValueField("nSteCajaID"))
            If XdtTmp.Count > 0 Then
                If MsgBox("La Caja Tiene Archivos Enviados Localmente . No podra seguir generando." & Chr(13) & "Esta Seguro de Quitar la Caja como Desconectada .", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                    Exit Sub
                End If
            End If
            If MsgBox("Esta seguro de Quitar Como Caja Desconectada.", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                Exit Sub
            End If

            XdtTmp.ExecuteSql("Delete From SttProcesarCajaParametroES Where nSteCajaID=" & XdtCaja.ValueField("nSteCajaID"))



            XIdCaja = XdtCaja.ValueField("nSteCajaID")
            CargarCaja()
            'Y se posiciona sobre el registro modificado.
            XdtCaja.SetCurrentByID("nSteCajaID", XIdCaja)
            'Refresca posicionamiento del Grid:
            Me.grdCaja.Row = XdtCaja.BindingSource.Position
            MsgBox("La Caja a sido Des Asignada como Local.", MsgBoxStyle.Information)

        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:

        End Try
    End Sub

End Class