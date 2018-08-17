Imports System.Windows.Forms

Public Class FrmPrinManuales

    Private Sub LlamaManuales()
        Try
            Dim ObjFrmManuales As FrmManuales
            ObjFrmManuales = New FrmManuales

            '-- Poner el cursor en un estado de ocupado
            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            ObjFrmManuales.MdiParent = Me
            ObjFrmManuales.Text = "Manuales"
            ObjFrmManuales.WindowState = FormWindowState.Maximized
            OpenForm(ObjFrmManuales)

            '-- Para enviar el foco al formulario 
            '-- que se está llamando.
            ObjFrmManuales.BringToFront()

            '-- Poner el cursor en un estado de desocupado
            Me.Cursor = System.Windows.Forms.Cursors.Default

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmPrinManuales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Try

            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "General")

            Me.Text = "Manuales " & NombreSistema

        Catch ex As Exception
            Control_Error(ex)

        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub mnuAyuda_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuAyuda.Click
        MsgBox("En construcción", MsgBoxStyle.Information, NombreSistema)
    End Sub

    Private Sub mnuSalir_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuSalir.Click
        Try
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub mnuManuales_Click(ByVal sender As System.Object, ByVal e As C1.Win.C1Command.ClickEventArgs) Handles mnuManuales.Click
        Try
            LlamaManuales()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class
