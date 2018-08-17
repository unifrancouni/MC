Imports System.Data.SqlClient

Public Class frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar

    '-- Declaracion de Variables 
    Public ModoForm As String
    Public intFichaID As Integer
    Public intFichaNegocioID As Integer
    Public intFichaSociaFamiliaresID As Integer
    Public strColor As String

    Dim Xds As BOSistema.Win.XDataSet

    Dim XdtParentesco As BOSistema.Win.XDataSet.xDataTable

    Dim ObjTmpFichaNegocio As New BOSistema.Win.SclEntFicha.SclFichaSociaNegocioDataTable
    Dim ObjTmpFichaFamiliares As New BOSistema.Win.SclEntFicha.SclFichaSociaFamiliaresDataTable

    Private Sub frmSclEditFichaVerificacionNuevaEditNuecleoFamiliar_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")
            Xds = New BOSistema.Win.XDataSet

            XdtParentesco = New BOSistema.Win.XDataSet.xDataTable

            CargarDatos()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Public Sub CargarDatos()
        'Codigo de ficha
        Dim XidFichaNegocio As New BOSistema.Win.XComando
        If Not intFichaID = Nothing Then
            Dim fichaSocia As New BOSistema.Win.SclEntFicha.SclFichaSociaDataTable
            fichaSocia.Filter = " nSclFichaSociaID=" & intFichaID
            fichaSocia.Retrieve()
            Dim cod As String
            cod = fichaSocia.ValueField("sCodigo")
            txtCodigoFicha.Text = cod

            intFichaNegocioID = XidFichaNegocio.ExecuteScalar("SELECT nSclFichaSociaNegocioID FROM SclFichaSociaNegocio WHERE SclFichaSociaNegocio.nSclFichaSociaID=" & Me.intFichaID)
            CargarParentesco()
        End If
        If ModoForm = "UPD" Then
            Dim nombre1, nombre2, apellido1, apellido2, cedula As String
            nombre1 = XidFichaNegocio.ExecuteScalar("select sNombre1 from SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & Me.intFichaSociaFamiliaresID)
            nombre2 = XidFichaNegocio.ExecuteScalar("select sNombre2 from SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & Me.intFichaSociaFamiliaresID)
            apellido1 = XidFichaNegocio.ExecuteScalar("select sApellido1 from SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & Me.intFichaSociaFamiliaresID)
            apellido2 = XidFichaNegocio.ExecuteScalar("select sApellido2 from SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & Me.intFichaSociaFamiliaresID)
            cedula = XidFichaNegocio.ExecuteScalar("select sNumeroCedula from SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & Me.intFichaSociaFamiliaresID)
            Dim idParentesco As Integer
            idParentesco = XidFichaNegocio.ExecuteScalar("select nStbParentescoID from SclFichaSociaFamiliares where nSclFichaSociaFamiliaresID=" & Me.intFichaSociaFamiliaresID)

            txtPrimerNombre.Text = nombre1
            txtSegundoNombre.Text = nombre2
            txtPrimerApellido.Text = apellido1
            txtSegundoApellido.Text = apellido2
            mtbNumCedula.Text = cedula
            cboParentesco.SelectedValue = idParentesco

        End If
    End Sub


    Public Function ValidarDatosEntrada() As Boolean
        Dim txts As Boolean
        txts = TextBoxAceptable(txtPrimerNombre) And TextBoxAceptable(txtPrimerApellido)
        txts = txts And (cboParentesco.SelectedValue > 0)
        If txts = False Then
            MsgBox("Debe de rellenar al menos el primer nombre, los dos apellidos y el parentesco.", vbCritical)
            Return False
        End If
        'Dim strFecha As String
        ''Fecha válida en número de Cédula:
        'strFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
        'If Not IsDate(strFecha) Then
        '    MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
        '    Return False
        'End If
        ''Número de Cédula Válido:
        'Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
        '    Case Cedula.LongitudIncorrecta
        '        MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
        '        Return False
        'End Select
        Return True
    End Function

    Public Sub CargarParentesco()
        Try
            Dim Strsql As String = ""

            Strsql = "select nStbValorCatalogoID as Cod, sCodigoInterno as Codigo, sDescripcion as Descripcion " & _
            "from StbValorCatalogo where nStbCatalogoID=45"

            XdtParentesco.ExecuteSql(Strsql)
            Me.cboParentesco.DataSource = XdtParentesco.Source

            Me.cboParentesco.Splits(0).DisplayColumns("Cod").Visible = False
            Me.cboParentesco.Splits(0).DisplayColumns("Codigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboParentesco.Splits(0).DisplayColumns("Codigo").Width = 47
            Me.cboParentesco.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboParentesco.Columns("Codigo").Caption = "Código"
            Me.cboParentesco.Columns("Descripcion").Caption = "Descripción"

            Me.cboParentesco.Splits(0).DisplayColumns("Codigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboParentesco.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboParentesco.DisplayMember = "Descripción"
            Me.cboParentesco.ValueMember = "Cod"

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            If ValidarDatosEntrada() Then
                SalvarFamiliar()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub SalvarFamiliar()
        Try
            Dim strSQL = "Exec spSclGrabarHojaVerificacionNuevoNucleoFamiliar "
            If ModoForm = "ADD" Then
                strSQL &= "0"
            Else
                strSQL &= intFichaSociaFamiliaresID
            End If
            strSQL &= ", " & intFichaNegocioID
            strSQL &= ", '" & txtPrimerNombre.Text & "'"
            strSQL &= ", '" & txtSegundoNombre.Text & "'"
            strSQL &= ", '" & txtPrimerApellido.Text & "'"
            strSQL &= ", '" & txtSegundoApellido.Text & "'"
            strSQL &= ", '" & mtbNumCedula.Text & "'"
            strSQL &= ", " & cboParentesco.SelectedValue
            strSQL &= ", " & InfoSistema.IDCuenta
            strSQL &= ", '" & ModoForm & "'"

            Dim cmd As New BOSistema.Win.XComando
            Dim coderror As Integer = cmd.ExecuteScalar(strSQL)

            Select Case coderror
                Case -2
                    MsgBox("No se ha modificado el familiar.", vbCritical, "SMUSURA0")
                    Me.Close()
                Case -1
                    MsgBox("No se ha agregado el familiar.", vbCritical, "SMUSURA0")
                    Me.Close()
                Case 0
                    MsgBox("Cambios realizados exitosamente.", vbInformation, "SMUSURA0")
                    Me.Close()
                Case 1
                    MsgBox("No se puede duplicar la cédula en una misma ficha.", vbCritical, "SMUSURA0")
                Case 2
                    MsgBox("Error en transacción SQL.", vbCritical, "SMUSURA0")
                    Me.Close()
                Case 3
                    MsgBox("Error Fatal. No se pudo extraer la razón del problema.", vbCritical, "SMUSURA0")
                    Me.Close()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function TextBoxAceptable(ByRef txt As TextBox) As Boolean
        Dim i As Integer = 0
        If txt.TextLength = 0 Then
            Return False
        ElseIf txt.TextLength = 1 And txt.Text <> " " Then
            Return True
        End If
        For i = 1 To txt.TextLength - 1
            If Mid(txt.Text, i, 1) <> " " Then
                Return True
            End If
        Next
        Return False
    End Function

End Class