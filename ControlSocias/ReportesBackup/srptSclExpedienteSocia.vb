'----------------------------------------------------------------------------
' Autor:                Yesenia Gutiérrez
' Fecha:                05/10/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    srptSclExpedienteSocia.vb
' Descripción:          Formulario para impresión de los Formatos siguientes:
'                                  o Subreporte de Expediente de cumplimiento 
'                                    de requisitos de una Ficha de Comité de
'                                    Crédito. 
'----------------------------------------------------------------------------
Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document 

Public Class srptSclExpedienteSocia

    Dim IdSclFichaNotificacion As Integer
    Dim IdSclEstadoCredito As Integer

    Dim XdtGrupo As BOSistema.Win.XDataSet.xDataTable

    'Propiedad utilizada para obtener el IdSclFichaNotificacion.
    Public Property IdFichaNotificacion() As Integer
        Get
            IdFichaNotificacion = IdSclFichaNotificacion
        End Get
        Set(ByVal value As Integer)
            IdSclFichaNotificacion = value
        End Set
    End Property

    'Propiedad utilizada para obtener el Estado del Credito.
    Public Property IdEstadoCredito() As Integer
        Get
            IdEstadoCredito = IdSclEstadoCredito
        End Get
        Set(ByVal value As Integer)
            IdSclEstadoCredito = value
        End Set
    End Property

    Private Sub srptSclSociasGrupo_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        XdtGrupo.Close()
        XdtGrupo = Nothing
    End Sub

    Private Sub srptSclSociasGrupo_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Try
            InicializarVariables()

            'Ficha de Notificación En Proceso: Check de cumplimiento del requisito:
            If IdSclEstadoCredito <> 1 Then
                'Asignar el data field
                Me.ChkCumple.DataField = "nCumple"
                Me.ChkNoCumple.DataField = "nNOCumple"
                Me.txtObserva.DataField = "sObservacion"
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub InicializarVariables()
        Try
            Dim strSQL As String = ""

            'i = 0
            XdtGrupo = New BOSistema.Win.XDataSet.xDataTable
            strSQL = " Select nSclDetalleDocExpedienteID, sCodigoInterno, sDescripcion, sObservacion, nCumple, nNOCumple " & _
                         " From vwSclFichaComiteCreditosubRep " & _
                         " Where nSclFichaNotificacionID = " & Me.IdFichaNotificacion & _
                         " Order by sCodigoInterno "

            XdtGrupo.ExecuteSql(strSQL)
            Me.DataSource = XdtGrupo.Table

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    'Private Sub Detail1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles Detail1.Format
    '    Try
    '        If XdtGrupo.Count > 0 Then
    '            Me.txtNumero.Text = i + 1
    '            Me.txtNombreApellido.Text = XdtGrupo.Table.Rows(i)(0)
    '            Me.txtTipoNegocio.Text = XdtGrupo.Table.Rows(i)(1)
    '            Me.txtDireccion.Text = XdtGrupo.Table.Rows(i)(2)
    '            i = i + 1
    '        End If

    '    Catch ex As Exception
    '        Control_Error(ex)
    '    Finally
    '    End Try
    'End Sub

End Class
