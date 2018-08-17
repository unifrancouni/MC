
Public Class frmSclSupervision
    '- Declaración de Variables 
    Dim XdsSupervisiones As BOSistema.Win.XDataSet
    Dim StrCadena As String

    Dim IntPermiteConsultar As Integer
    Dim IntPermiteEditar As Integer


    Private Sub frmSclReferenciaSocia_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            XdsSupervisiones.Close()
            XdsSupervisiones = Nothing
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


    Private Sub LlamaImprimir()
        Dim ObjFrmSccParametrosCreditosSocia As New frmSclParametrosReportesSociaUbicacion
        Try

            ObjFrmSccParametrosCreditosSocia.NomRep = 17
            ObjFrmSccParametrosCreditosSocia.strColor = "RojoLight"
            ObjFrmSccParametrosCreditosSocia.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSccParametrosCreditosSocia.Close()
            ObjFrmSccParametrosCreditosSocia = Nothing
        End Try

    End Sub

    Private Sub tbReferencias_ItemClicked(ByVal sender As Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs)
        'Llama al reporte del listado de recibos
        '----------------------------------------------------------------------
        Dim frmVisor As New frmCRVisorReporte

        Try
            Select Case e.ClickedItem.Name

            End Select
        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub LlamaSalir()
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaAyuda()
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra Otro Tipo de Error
    Private Sub grdSocias_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs) Handles grdSupervisiones.Error
        Control_Error(e.Exception)
    End Sub

    Private Sub grdSocias_Filter(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.FilterEventArgs) Handles grdSupervisiones.Filter
        Try
            XdsSupervisiones("Supervisiones").FilterLocal(e.Condition)
            Me.grdSupervisiones.Caption = " Listado de Supervisiones (" + Me.grdSupervisiones.RowCount.ToString + " registros)"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Agregar y Modificar Supervision:
            If Seg.HasPermission("AgregarModificarSupervision") = False Then
                Me.tbSocias.Items("toolAgregar").Enabled = False
                Me.tbSocias.Items("toolEditar").Enabled = False
            Else
                Me.tbSocias.Items("toolAgregar").Enabled = True
                Me.tbSocias.Items("toolEditar").Enabled = True
            End If

            'Anular Supervision:
            If Seg.HasPermission("AnularSupervision") = False Then
                Me.tbSocias.Items("toolAnular").Enabled = False
            Else
                Me.tbSocias.Items("toolAnular").Enabled = True
            End If

            'Imprimir Supervisiones CS65
            If Seg.HasPermission("ImprimirReporteCS65") = False Then
                Me.tbSocias.Items("toolImprimir").Enabled = False
            Else
                Me.tbSocias.Items("toolImprimir").Enabled = True
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'En caso que ocurra otro Tipo de Error
    Private Sub grdReferencias_Error(ByVal sender As Object, ByVal e As C1.Win.C1TrueDBGrid.ErrorEventArgs)
        Control_Error(e.Exception)
    End Sub

    Private Sub LlamaBuscarSocia()
        Dim ObjFrmSclBusquedaSocias As New frmSclBusquedaSocias
        Try

            ObjFrmSclBusquedaSocias.StrCriterioSocia = "0" 'Sin Criterio de Busqueda
            ObjFrmSclBusquedaSocias.IdConsultarDelegacion = IntPermiteConsultar
            ObjFrmSclBusquedaSocias.IdTipoBusqueda = 6 'Busqueda Por Nombre o Cédula Socias desde Supervisiones.

            CargarSupervisiones("0")

            ObjFrmSclBusquedaSocias.ShowDialog()

            If ObjFrmSclBusquedaSocias.StrCriterioSocia <> "0" Then
                StrCadena = ObjFrmSclBusquedaSocias.StrCriterioSocia
            End If

            CargarSupervisiones(StrCadena)
            StrCadena = ""
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias.Close()
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub

    Private Sub CargarSupervisiones(ByVal strCriterio As String)
        Try
            Dim Strsql As String

            Strsql = "SELECT nSclSupervisionID, [PrimerNombre], [SegundoNombre], [PrimerApellido], [SegundoApellido], [sNumeroCedula], dFechaSupervision, sObservaciones, nSclSociaID FROM vwSclSupervision "

            If strCriterio = "0" Or strCriterio = Nothing Then
                Strsql &= " where 1=0 "
            Else
                Strsql &= strCriterio
                If strCriterio.Contains("Where") Then
                    Strsql &= " and nActivo=1 "
                Else
                    Strsql &= " where nActivo=1 "
                End If
            End If

            If XdsSupervisiones.ExistTable("Supervisiones") Then
                XdsSupervisiones("Supervisiones").ExecuteSql(Strsql)
            Else
                XdsSupervisiones.NewTable(Strsql, "Supervisiones")
                XdsSupervisiones("Supervisiones").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.grdSupervisiones.DataSource = XdsSupervisiones("Supervisiones").Source

            'Actualizando el caption de los GRIDS
            Me.grdSupervisiones.Caption = " Listado de Supervisiones (" + Me.grdSupervisiones.RowCount.ToString + " registros)"

            FormatoSupervisiones()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FormatoSupervisiones()
        Try

            'Configuracion del Grid Socias:
            Me.grdSupervisiones.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdSupervisiones.Splits(0).DisplayColumns("nSclSupervisionID").Visible = False

            Me.grdSupervisiones.Splits(0).DisplayColumns("PrimerNombre").Width = 100
            Me.grdSupervisiones.Splits(0).DisplayColumns("SegundoNombre").Width = 100
            Me.grdSupervisiones.Splits(0).DisplayColumns("PrimerApellido").Width = 100
            Me.grdSupervisiones.Splits(0).DisplayColumns("SegundoApellido").Width = 100
            Me.grdSupervisiones.Splits(0).DisplayColumns("sNumeroCedula").Width = 100
            Me.grdSupervisiones.Splits(0).DisplayColumns("dFechaSupervision").Width = 100
            Me.grdSupervisiones.Splits(0).DisplayColumns("sObservaciones").Width = 200

            Me.grdSupervisiones.Columns("PrimerNombre").Caption = "Primer Nombre"
            Me.grdSupervisiones.Columns("SegundoNombre").Caption = "Segundo Nombre"
            Me.grdSupervisiones.Columns("PrimerApellido").Caption = "Primer Apellido"
            Me.grdSupervisiones.Columns("SegundoApellido").Caption = "Segundo Apellido"
            Me.grdSupervisiones.Columns("sNumeroCedula").Caption = "Cédula"
            Me.grdSupervisiones.Columns("dFechaSupervision").Caption = "Fecha Supervisión"
            Me.grdSupervisiones.Columns("sObservaciones").Caption = "Observaciones"

            Me.grdSupervisiones.Splits(0).DisplayColumns("sNumeroCedula").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdSupervisiones.Splits(0).DisplayColumns("dFechaSupervision").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub InicializaVariables()
        Try

            XdsSupervisiones = New BOSistema.Win.XDataSet

            'Limpiar los Grids, estructura y Datos:
            Me.grdSupervisiones.ClearFields()

            CargarSupervisiones(StrCadena)

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSclSupervision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            '-- Asignar el tema de Color a 
            '-- utilizarse en la aplicación.
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Cafe")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializaVariables()
            CargarSupervisiones("0")
            Seguridad()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub LlamarAgregarModificar(ByVal modoForm As String)
        Dim ObjFrmSclBusquedaSocias As New frmSclEditSupervision
        Try

            ObjFrmSclBusquedaSocias.pModoForm = modoForm

            If modoForm = "UPD" Then
                If grdSupervisiones.RowCount = 0 Then
                    MsgBox("No existen registros grabados.", vbCritical, "SMUSURA0")
                    Exit Sub
                End If
                ObjFrmSclBusquedaSocias.nSclSupervision = XdsSupervisiones("Supervisiones").Current.Item("nSclSupervisionID")
                ObjFrmSclBusquedaSocias.nSclSocia = XdsSupervisiones("Supervisiones").Current.Item("nSclSociaID")
            Else
                ObjFrmSclBusquedaSocias.nSclSupervision = 0
                CargarSupervisiones("0")
            End If

            ObjFrmSclBusquedaSocias.ShowDialog()

            If ObjFrmSclBusquedaSocias.Refrescar <> "" Then
                CargarSupervisiones(ObjFrmSclBusquedaSocias.Refrescar)
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub

    Private Sub AnularSupervision()
        Dim ObjFrmSclBusquedaSocias As New frmSclMotivoAnulacionSupervision
        Try
            If grdSupervisiones.RowCount = 0 Then
                MsgBox("No existen registros grabados.", vbCritical, "SMUSURA0")
                Exit Sub
            End If

            ObjFrmSclBusquedaSocias.nSclSupervision = XdsSupervisiones("Supervisiones").Current.Item("nSclSupervisionID")
            ObjFrmSclBusquedaSocias.ShowDialog()

            CargarSupervisiones("0")
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrmSclBusquedaSocias = Nothing
        End Try
    End Sub

    Private Sub tbSocias_ItemClicked(sender As Object, e As ToolStripItemClickedEventArgs) Handles tbSocias.ItemClicked
        Select Case e.ClickedItem.Name
            Case "toolBuscar"
                LlamaBuscarSocia()
            Case "toolAgregar"
                LlamarAgregarModificar("ADD")
            Case "toolEditar"
                LlamarAgregarModificar("UPD")
            Case "toolAnular"
                AnularSupervision()
            Case "toolImprimir"
                LlamaImprimir()
            Case "toolSalir"
                LlamaSalir()
            Case "toolAyuda"
                LlamaAyuda()
        End Select
    End Sub

End Class