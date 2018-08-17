Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class rptEncabezadoH

    Private Sub Encabezado_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Encabezado.Format
        Try
            'Me.LogoEscudoNicaragua.Image = Image.FromFile(LeerRutaImagen("LogoEscudoNicaragua"))
            'Me.LogoMinsa.Image = Image.FromFile(LeerRutaImagen("LogoMinsa"))
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Public Function LeerRutaImagen(ByVal StrNombre As String) As String
        Dim xdtGeneral As BOSistema.Win.XDataSet.xDataTable
        Dim StrSql As String
        Dim vRetorno As String = ""
        Try
            xdtGeneral = New BOSistema.Win.XDataSet.xDataTable

            StrSql = "Select IsNull(Valor,'') as Valor From StbParametro Where Lower(Ltrim(Rtrim(Nombre)))='" & Trim(StrNombre.ToLower) & "'"

            xdtGeneral.ExecuteSql(StrSql)
            vRetorno = xdtGeneral("Valor")

            xdtGeneral.Dispose()
        Catch ex As Exception
            MsgBox("Ocurri� el siguiente error: " & ex.Message, MsgBoxStyle.Critical, "BOSMUSURA0")
        Finally
            xdtGeneral = Nothing
        End Try

        Return vRetorno
    End Function

End Class