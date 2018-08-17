Imports BOSistema.Win

Public Class frmSclEditSupervision
    Dim ModoForm As String
    Dim nSclSociaID As Integer
    Dim nSclSupervisionID As Integer 'Solo para modificar
    Dim xdsSocia As XComando
    Dim xdsConsulta As XDataSet
    Dim refr As String = ""

    Public Property Refrescar() As String
        Get
            Return refr
        End Get
        Set(value As String)
            refr = value
        End Set
    End Property

    Public Property nSclSupervision() As Integer
        Get
            Return nSclSupervisionID
        End Get
        Set(value As Integer)
            nSclSupervisionID = value
        End Set
    End Property

    Public Property nSclSocia() As Integer
        Get
            Return nSclSociaID
        End Get
        Set(value As Integer)
            nSclSociaID = value
        End Set
    End Property

    Public Property pModoForm() As String
        Get
            Return ModoForm
        End Get
        Set(value As String)
            ModoForm = value
        End Set
    End Property

    Private Sub InicializarVariables()
        xdsSocia = New XComando
        xdsConsulta = New XDataSet
        Refrescar = ""
    End Sub

    Private Sub frmSclEditSupervision_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            InicializarVariables()

            If ModoForm = "UPD" Then
                mtbNumCedula.Enabled = False
                'Cargar los datos existentes
                Dim strSQL As String = ""
                strSQL = "SELECT        dbo.vwSclSupervision.sNumeroCedula, dbo.vwSclSupervision.dFechaSupervision, dbo.vwSclSupervision.sObservaciones, dbo.vwSclSocia.NombreSocia FROM  dbo.vwSclSupervision INNER JOIN dbo.vwSclSocia ON dbo.vwSclSupervision.nSclSociaID = dbo.vwSclSocia.nSclSociaID WHERE        (dbo.vwSclSupervision.nActivo = 1) AND (dbo.vwSclSupervision.nSclSociaID = " & nSclSociaID & ")"


                If xdsConsulta.ExistTable("Supervision") Then
                    xdsConsulta("Supervision").ExecuteSql(strSQL)
                Else
                    xdsConsulta.NewTable(strSQL, "Supervision")
                    xdsConsulta("Supervision").Retrieve()
                End If

                If xdsConsulta("Supervision").Count > 0 Then
                    mtbNumCedula.Text = xdsConsulta("Supervision").ValueField("sNumeroCedula")
                    txtNombreSocia.Text = xdsConsulta("Supervision").ValueField("NombreSocia")
                    cdeFechaSupervision.Value = xdsConsulta("Supervision").ValueField("dFechaSupervision")
                    txtObservaciones.Text = xdsConsulta("Supervision").ValueField("sObservaciones")
                End If

                mtbNumCedula.Enabled = False

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub txtObservaciones_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtObservaciones.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = ChrW(0)
        End If
    End Sub

    Private Sub cmdBuscar_Click(sender As Object, e As EventArgs) Handles cmdBuscar.Click
        Try
            Dim Strsql As String

            Strsql = "SELECT nSclSociaID FROM SclSocia WHERE sNumeroCedula='" & mtbNumCedula.Text & "'"

            If IsDBNull(xdsSocia.ExecuteScalar(Strsql)) = False Then
                nSclSociaID = xdsSocia.ExecuteScalar(Strsql)
            Else
                nSclSociaID = 0
            End If

            'Cargar nombre de la socia
            If nSclSociaID <> 0 Then
                Strsql = "SELECT NombreSocia FROM vwSclSocia WHERE sNumeroCedula='" & mtbNumCedula.Text & "'"
                txtNombreSocia.Text = xdsSocia.ExecuteScalar(Strsql).ToString
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidarDatos() As Boolean
        Dim valido As Boolean = True

        If Format(cdeFechaSupervision.Value, "yyyy-MM-dd") >= Format(FechaServer(), "yyyy-MM-dd") Then
            MsgBox("La fecha de supervisión debe ser menor a la fecha actual.", vbCritical, "SMUSURA0")
            valido = False
        End If

        If Not TextoValido(txtObservaciones.Text) Then
            MsgBox("El texto de observación es inválido, pueda que contenga caracteres prohibidos.", vbCritical, "SMUSURA0")
            valido = False
        End If

        Return valido

    End Function

    Private Sub CmdAceptar_Click(sender As Object, e As EventArgs) Handles CmdAceptar.Click
        Dim strSQL As String = ""
        If ModoForm = "UPD" Then
            Try
                If ValidarDatos() Then
                    strSQL = "spSclAgregarModificarSupervision "
                    strSQL &= nSclSupervisionID & ", "
                    strSQL &= nSclSociaID & ", "
                    strSQL &= "'" & Format(cdeFechaSupervision.Value, "yyyy-MM-dd") & "', "
                    strSQL &= "'" & txtObservaciones.Text & "', "
                    strSQL &= "1, "
                    strSQL &= "'', "
                    strSQL &= InfoSistema.IDCuenta

                    xdsSocia.ExecuteNonQuery(strSQL)
                    MsgBox("Los datos se actualizaron correctamente.", vbInformation, "SMUSURA0")
                    Me.Close()
                End If

            Catch ex As Exception
                Control_Error(ex)
            End Try
        Else
            Try
                If ValidarDatos() Then
                    strSQL = "spSclAgregarModificarSupervision "
                    strSQL &= "0, "
                    strSQL &= nSclSociaID & ", "
                    strSQL &= "'" & Format(cdeFechaSupervision.Value, "yyyy-MM-dd") & "', "
                    strSQL &= "'" & txtObservaciones.Text & "', "
                    strSQL &= "1, "
                    strSQL &= "'', "
                    strSQL &= InfoSistema.IDCuenta

                    xdsSocia.ExecuteNonQuery(strSQL)
                    MsgBox("Los datos se agregaron correctamente.", vbInformation, "SMUSURA0")
                    Me.Close()
                End If

            Catch ex As Exception
                Control_Error(ex)
            End Try
        End If
        Refrescar = " Where sNumeroCedula='" & mtbNumCedula.Text & "'"
    End Sub

    Private Sub cmdCancelar_Click(sender As Object, e As EventArgs) Handles cmdCancelar.Click
        Me.Close()
    End Sub
End Class