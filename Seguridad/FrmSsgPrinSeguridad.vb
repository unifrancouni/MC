Imports System.Windows.Forms
Public Class FrmSsgPrinSeguridad

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub mnuSeguridad_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSeguridad.Click
        Try
            LlamaSeguridad()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '-------------------------------------------------------------
    '-- Implementado Por:           
    '-- Fecha de Implementacion:    17 de Julio del 2006
    '-- Descripcion:                Llamar al formulario que permitirá dar mantenimiento a la Seguridad.
    '-------------------------------------------------------------
    Private Sub LlamaSeguridad()
        Try
            Dim ObjFrmSeguridad As FrmSsgSeguridad
            ObjFrmSeguridad = New FrmSsgSeguridad

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmSeguridad.MdiParent = Me
            ObjFrmSeguridad.Text = "Seguridad"
            ObjFrmSeguridad.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmSeguridad)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmSeguridad.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FrmSsgPrinSeguridad_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        Try
            Me.Text = "SMUSURA0 - Módulo de Seguridad"
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub FrmSsgPrinSeguridad_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI

            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Oro")

            Me.Text = "SMUSURA0 - Módulo de Seguridad"
            InicializaBarraEstado()

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' -----------------------------------------------------------------------------------------
    ' Author		    		:	
    ' Date			    		:	08 de Agosto del 2006
    ' Procedure name		   	:	InicializaVariables
    ' Description			   	:   Inicializa las variables de la Pantalla Principal 
    '                               de Presupuesto.
    ' -----------------------------------------------------------------------------------------
    Private Sub InicializaBarraEstado()
        Try

            'Me.tmrGeneral.Start()
            Me.staFecha.Text = Format(Now.Date, "dd-MM-yyyy")
            Me.staBaseDatos.Text = "Base de Datos: " + InfoSistema.DBName
            Me.staServidor.Text = "Servidor: " + InfoSistema.ServerName
            Me.staHora.Text = ""   'Date.Now.Hour
            If Trim(InfoSistema.UsrName) <> "" Then
                Me.staLogin.Text = "Usuario: " + InfoSistema.UsrName
            Else
                Me.staLogin.Text = "Usuario: " + InfoSistema.LoginName
            End If
            Me.staUnidadSalud.Text = ""   '"Unidad: " + InfoSistema.CodigoUnidadLocal + "-" + InfoSistema.UnidadSaludLocal
            'Me.staVarios.Text = ""

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    'Private Sub tmrSeguridad_Tick(ByVal sender As Object, ByVal e As System.EventArgs)
    '    Me.staHora.Text = Now.ToLongTimeString
    'End Sub

    Private Sub mnuAyuda_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAyuda.Click
        Try
            Help.ShowHelp(Me, MyHelpNameSpace)
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuReporteSSG1_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteSSG1.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSsgSG1.rpt"
            frmVisor.Text = "Listado de Acciones del Sistema"
            frmVisor.SQLQuery = " Select SsgModuloID, " & _
                                "        sModulo, " & _
                                "        sServicioUsuario, " & _
                                "        sAccion " & _
                                " From vwStbListadoOpciones " & _
                                " Where CodInterno <> 'SSG' " & _
                                " Order by sModulo desc,sServicioUsuario desc,sAccion "
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub mnuReporteSSG2_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteSSG2.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSsgSG2.rpt"
            frmVisor.Text = "Listado de Acciones del Sistema"
            frmVisor.SQLQuery = " Select * " & _
                                " From vwSsgUsuarios " & _
                                " Order by Empleado"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub mnuReporteSSG3_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteSSG3.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSsgSG3.rpt"
            frmVisor.Text = "Listado de Acciones del Sistema"
            frmVisor.SQLQuery = " Select * " & _
                                " From vwSsgRol " & _
                                " Order by Empleado, Rol"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub mnuReporteSSG4_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteSSG4.Click
        Dim frmVisor As New frmCRVisorReporte
        Try
            frmVisor.WindowState = FormWindowState.Maximized
            'frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
            frmVisor.NombreReporte = "RepSsgSG4.rpt"
            frmVisor.Text = "Listado de Acciones del Sistema"
            frmVisor.SQLQuery = " Select * " & _
                                " From vwSsgRolAccion " & _
                                " Order by Rol, Acción"
            frmVisor.ShowDialog()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            frmVisor = Nothing
        End Try
    End Sub

    Private Sub mnuReporteSSG5_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuReporteSSG5.Click
        LlamaRptAuditoria(1)
    End Sub
    Private Sub LlamaRptAuditoria(ByVal IdReporte As Integer)
        Dim ObjFrm As New FrmSsgReporteAuditoria
        Try
            If My.Application.OpenForms.Count > 2 Then
                Exit Sub
            End If
            ObjFrm.NomRep = IdReporte
            ObjFrm.ShowDialog()
        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjFrm.Close()
            ObjFrm = Nothing
        End Try
    End Sub
End Class
