'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                15/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    srptSclCreditosDenegados.vb
' Descripción:          Formulario para impresión de Subreporte Créditos 
'                       Denegados del Acta de Comité de Crédito. 
'----------------------------------------------------------------------------
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class srptSclCreditosDenegados

    Dim StrSclNoSesion As String
    Dim StrCodGrupo As String
    Dim m, n As Integer
    Dim StrsGrupo As String

    Dim XdtGrupo As BOSistema.Win.XDataSet.xDataTable

    'Propiedad utilizada para obtener el No de Sesión del Crédito:
    Public Property StrNoSesion() As String
        Get
            StrNoSesion = StrSclNoSesion
        End Get
        Set(ByVal value As String)
            StrSclNoSesion = value
        End Set
    End Property

    Private Sub srptSclCreditosDenegados_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        XdtGrupo.Close()
        XdtGrupo = Nothing
    End Sub

    Private Sub srptSclCreditosDenegados_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try

            InicializarVariables()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            m = 0
            n = 0
            StrCodGrupo = ""

            XdtGrupo = New BOSistema.Win.XDataSet.xDataTable
            strSQL = " Select 1 as Item, vwSclActaDenegadosComiteCreditoRep.* " & _
                     " From vwSclActaDenegadosComiteCreditoRep " & _
                     " WHERE (EstadoCredito = '2' or EstadoCredito = '3') AND (nCreditoRechazado = 1) And (sNumSesion = '" & StrNoSesion & "') " & _
                     " Order by Item, Departamento, Municipio, Grupo, Texto, CodigoGS, nCoordinador DESC, NombreSocia "
            XdtGrupo.ExecuteSql(strSQL)
            Me.DataSource = XdtGrupo.Table
            txtPie.Text = "No habiendo otros aspectos que tratar se levanta la sesión a las 5:00 p.m. del mismo día " & Format(XdtGrupo.ValueField("dFechaNotificacion"), "dd' de 'MMMM' del año 'yyyy") & "."

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Try
            Me.txtMontoS.Text = Format(Me.txtMontoS.Value, "#,##0.00")

            If XdtGrupo.Count > 0 Then
                'Socias:
                'Me.txtsCodSocia.Text = m + 1
                'm = m + 1
                If txtGrupo.Text <> StrsGrupo Then
                    m = 0
                    n = 0
                End If
                m = m + 1
                Me.txtsCodSocia.Text = m
                StrsGrupo = txtGrupo.Text

                'Grupos:
                If txtNombreGS.Text <> StrCodGrupo Then
                    n = n + 1
                    txtNombreGS.Visible = True
                    txtTexto.Visible = True
                    txtsCodGS.Visible = True
                    txtObservaciones.Visible = True
                Else
                    txtNombreGS.Visible = False
                    txtTexto.Visible = False
                    txtsCodGS.Visible = False
                    txtObservaciones.Visible = False
                End If
                Me.txtsCodGS.Text = n
                StrCodGrupo = txtNombreGS.Text
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
        End Try
    End Sub

    Private Sub GroupFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter1.Format
        Me.txtsMontoSTg.Text = Format(Me.txtsMontoSTg.Value, "#,##0.00")
    End Sub

    Private Sub GroupFooter2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter2.Format
        Me.txtsMontoST.Text = Format(Me.txtsMontoST.Value, "#,##0.00")
        lblDenegadasGrupo.Text = "TOTAL SOLICITUDES DENEGADAS " + UCase(txtGrupo.Text)
    End Sub

    Private Sub GroupFooter3_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupFooter3.Format
        Me.txtsMontoSSt.Text = Format(Me.txtsMontoSSt.Value, "#,##0.00")
    End Sub
End Class
