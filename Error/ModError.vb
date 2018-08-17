Module ModError
    '-----------------------------------------------
    'Implementado Por:          
    'Fecha de Implementacion:   08 de Mayo del 2006
    'Descripcion:               Controlar el manejo de errores mediante la Traza y 
    '                           y el uso de un formulario que le permita mayor presentacion.
    '-----------------------------------------------
    Public Sub Control_Error(ByVal mEx As Object, Optional ByVal ErrCode As Decimal = 0)

        'Declaracion de Variables 
        Dim nFRM As New frmError
        Dim ErrDescr As String, ErrNum As Long
        Dim UserErrDescr As String
        '-------------------------
        nFRM.Text = "Error en el " & NombreSistema
        If ErrCode = 0 Then
            UserErrDescr = mEx.Message
            ErrDescr = mEx.Message
            nFRM.lblError.Text = ErrNum.ToString & " - " & UserErrDescr
            nFRM.txtError.Text = "Mensaje: " & vbTab & ErrDescr & vbCrLf & "Traza: " & vbTab & mEx.StackTrace & vbCrLf & " Origen:" & vbTab & mEx.Source
            nFRM.ShowDialog()
        Else
            Select Case ErrCode
                Case -2147217873D
                    nFRM.Text = "Mensaje del sistema"
                    nFRM.lblError.Text = "No se puede eliminar el registro debido a que tiene relaciones con otras tablas"
                    nFRM.txtError.Text = "Mensaje: " & vbTab & mEx.Message & vbCrLf & "Traza: " & vbTab & mEx.StackTrace & vbCrLf & " Origen:" & vbTab & mEx.Source
                    nFRM.ShowDialog()
            End Select
        End If
    End Sub
End Module

