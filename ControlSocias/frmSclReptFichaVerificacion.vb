Imports System.Text

Public Class frmSclReptFichaVerificacion

    Dim xdtSocia As BOSistema.Win.XDataSet.xDataTable

    Private _sColor As String

    Public Property Color() As String
        Get
            Return _sColor
        End Get
        Set(ByVal value As String)
            _sColor = value
        End Set
    End Property

    Private Sub btnCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Me.Close()
    End Sub

    Private Sub frmSclReptFichaVerificacion_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            xdtSocia.Close()
            xdtSocia = Nothing

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub frmSclReptFichaVerificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As GUI.ClsGUI
        Me.Text = "SMUSURA0-[Ficha de Verificación de Socia]"
        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")
            xdtSocia = New BOSistema.Win.XDataSet.xDataTable
        Catch ex As Exception
            xdtSocia = Nothing
        End Try
    End Sub

    Private Function CargarDatosSocia(ByRef xdtSocia As BOSistema.Win.XDataSet.xDataTable) As Integer

        Dim SQLQuery As String

        Try
            If Not String.IsNullOrEmpty(Me.mscCedula.Text) Then
                SQLQuery = "exec spSclObtenerDatosSocia '" & Me.mscCedula.Text & "'"
                xdtSocia.ExecuteSql(SQLQuery)

                If xdtSocia.Count = 0 Then
                    Return 0
                End If

                Me.txtCodigo.Text = xdtSocia("CodigoSocia")
                Me.txtNombreGrupo.Text = xdtSocia("NombreGrupo")
                Me.txtTelefono.Text = IIf(IsDBNull(xdtSocia("sTelefonoSocia")), "", xdtSocia("sTelefonoSocia"))
                Me.txtNombreSocia.Text = xdtSocia("NombreSocia")
                Me.dtFechaInscripcion.Value = Convert.ToDateTime(xdtSocia("dFechaInscripcion"))
                Me.dtFechaVerificacion.Value = Convert.ToDateTime(xdtSocia("dFechaHoraVerificacion"))
                Me.txtDepartamento.Text = xdtSocia("Departamento")
                Me.txtMunicipio.Text = xdtSocia("Municipio")
                Me.txtDistrito.Text = xdtSocia("Distrito")
                Me.txtBarrio.Text = xdtSocia("Barrio")
                xdtSocia.Retrieve()
                CargarDatosSocia = xdtSocia.Count
            Else
                CargarDatosSocia = 0
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Function


    Private Sub LimpiarCampos()
        Me.txtCodigo.Text = String.Empty
        Me.txtNombreGrupo.Text = String.Empty
        Me.txtTelefono.Text = String.Empty
        Me.txtNombreSocia.Text = String.Empty
        Me.dtFechaInscripcion.Value = Convert.ToDateTime(DateTime.Now)
        Me.dtFechaVerificacion.Value = Convert.ToDateTime(DateTime.Now)
        Me.txtDepartamento.Text = String.Empty
        Me.txtMunicipio.Text = String.Empty
        Me.txtDistrito.Text = String.Empty
        Me.txtBarrio.Text = String.Empty
    End Sub

    Private Sub btnAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAceptar.Click

        Try
            If Not String.IsNullOrEmpty(Me.txtNombreSocia.Text) Then
                Dim frmVisor As New frmCRVisorReporte
                frmVisor.WindowState = FormWindowState.Maximized
                frmVisor.Formulas("Usuario") = "'" & InfoSistema.LoginName & "'"
                frmVisor.Formulas("sReferencia") = "'" & xdtSocia("sObservaciones") & "'"
                frmVisor.Formulas("ReferenciaSociaID") = "'" & xdtSocia("nSclRefSociaID") & "'"
                frmVisor.Formulas("TipoReferenciaSocia") = "'" & xdtSocia("TipoReferencia") & "'"

                frmVisor.NombreReporte = "RepSclCS42.rpt"
                If String.IsNullOrEmpty(Me.mscCedula.Text) Then
                    MsgBox("Ingrese el Número de Cédula de la Socia.", MsgBoxStyle.Critical, NombreSistema)
                    Exit Sub
                End If

                frmVisor.Parametros("@cedula") = Me.mscCedula.Text

                frmVisor.Show()
            Else
                MsgBox("Primero busque a la socia.", MsgBoxStyle.OkOnly, "SMUSUARA0-[Ficha Verificación]")
            End If
        Catch ex As Exception
            MsgBox("Error al mostrar reporte: " & ex.Message, MsgBoxStyle.Critical, "SMUSURA0-[Error al mostrar reporte]")
        End Try
    End Sub

    Private Sub btnBuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBuscar.Click

        If ValidarCedula() Then
            If CargarDatosSocia(xdtSocia) = 0 Then
                LimpiarCampos()
                MsgBox("No existe existe una socia con está cédula", MsgBoxStyle.Exclamation, "SMUSUARA0-[Ficha Verificación]")
                Exit Sub
            End If
        Else
            MsgBox("Ingrese el número de cédula", MsgBoxStyle.OkOnly, "SMUSUARA0-[Ficha Verificación]")
        End If
    End Sub

    Public Function ValidarCedula() As Boolean
        If Not IsNumeric(Mid(Me.mscCedula.Text, 1, 1)) Then
            MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
            ValidarCedula = False
            Me.errSocia.SetError(Me.mscCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío.")
            Me.mscCedula.Focus()
            Exit Function
        End If
        ValidarCedula = True
    End Function

End Class