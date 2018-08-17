Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class srptSclSociasGrupo

    Dim IdSclGrupoSolidario As Integer
    Dim i As Integer
    Dim XdtGrupo As BOSistema.Win.XDataSet.xDataTable

    'Propiedad utilizada para obtener el ID del Comprobante que corresponde al campo
    'nSclGrupoSolidarioID de la tabla SclGrupoSocia.
    Public Property IdGrupoSolidario() As Integer
        Get
            IdGrupoSolidario = IdSclGrupoSolidario
        End Get
        Set(ByVal value As Integer)
            IdSclGrupoSolidario = value
        End Set
    End Property

    Private Sub srptSclSociasGrupo_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        XdtGrupo.Close()
        XdtGrupo = Nothing
    End Sub
    Private Sub srptSclSociasGrupo_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            i = 0

            XdtGrupo = New BOSistema.Win.XDataSet.xDataTable

            strSQL = " Select a.sNombreSocia,a.sTipoNegocio,a.sDireccionSocia " & _
                         " From vwSclDetalleSociaRep a " & _
                         " Where a.nSclGrupoSolidarioID = " & Me.IdGrupoSolidario & _
                         " And a.nStbEstadoFichaID NOT IN (SELECT a.nStbValorCatalogoID FROM StbValorCatalogo a INNER JOIN StbCatalogo b ON a.nStbCatalogoID = b.nStbCatalogoID WHERE a.sCodigoInterno IN ('4') And b.sNombre = 'EstadoFicha')" & _
                         " Order by a.sNombreSocia "

            XdtGrupo.ExecuteSql(strSQL)
            Me.DataSource = XdtGrupo.Table

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Private Sub Detail1_AfterPrint(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.AfterPrint
    '    Me.txtTotalMonto.Text = Format(Me.dblTotalMonto, "#,##0.00")
    'End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            If XdtGrupo.Count > 0 Then
                Me.txtNumero.Text = i + 1
                Me.txtNombreApellido.Text = XdtGrupo.Table.Rows(i)(0)
                Me.txtTipoNegocio.Text = XdtGrupo.Table.Rows(i)(1)
                Me.txtDireccion.Text = XdtGrupo.Table.Rows(i)(2)

                i = i + 1
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
        End Try
    End Sub

End Class
