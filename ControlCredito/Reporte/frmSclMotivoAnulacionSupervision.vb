Imports BOSistema.Win

Public Class frmSclMotivoAnulacionSupervision
    Dim nSclSupervisionID As Integer 'Solo para modificar

    Public Property nSclSupervision()
        Get
            Return nSclSupervisionID
        End Get
        Set(value)
            nSclSupervisionID = value
        End Set
    End Property

    Private Sub frmSclMotivoAnulacionSupervision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            'InicializarVariables()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        Try
            Dim strSQL As String = ""
            strSQL = "update SclSupervision set nActivo=0, sMotivoAnulacion='" & txtObservaciones.Text & "' where nSclSupervisionID=" & nSclSupervisionID
            Dim cmd As New XComando
            cmd.ExecuteNonQuery(strSQL)
            MsgBox("La supervisión se ha anulado correctamente", vbInformation, "SMUSURA0")
            Me.Close()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class