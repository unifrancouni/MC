Public Class frmSclEditModuloCursoSocia

    Dim XdsCombos As BOSistema.Win.XDataSet
    Dim nFichaID As Long

    Public Property nSclFichaID() As Long
        Get
            Return Me.nFichaID
        End Get
        Set(value As Long)
            Me.nFichaID = value
        End Set
    End Property


    Private Sub frmSclEditModuloCursoSocia_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'Declaración de Variables

        Dim ObjGUI As GUI.ClsGUI

        Try
            ObjGUI = New GUI.ClsGUI
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            InicializarVariables()
            CargarModulos()

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
            Me.Cursor = Cursors.Default
        End Try
    End Sub

    Private Sub CargarModulos()
        Dim cmd As New BOSistema.Win.XComando

        Dim strSQL As String = ""
        Try
            strSQL = String.Format("Select top 1 ISNULL(nStbModuloID, 0) nSclModuloFichaSociaID from SclModuloFichaSocia MS 
            right join SclFichaSocia FS ON FS.nSclFichaSociaID=MS.nSclFichaSociaID 
            Where FS.nSclFichaSociaID={0}", Me.nSclFichaID)

            Dim moduloID As Long = 0
            moduloID = cmd.ExecuteScalar(strSQL)

            strSQL = "SELECT dbo.StbCatalogo.nStbCatalogoID, dbo.StbValorCatalogo.nStbValorCatalogoID, dbo.StbCatalogo.sNombre, dbo.StbValorCatalogo.sCodigoInterno, dbo.StbValorCatalogo.sDescripcion
            FROM dbo.StbValorCatalogo INNER JOIN
            dbo.StbCatalogo ON dbo.StbValorCatalogo.nStbCatalogoID = dbo.StbCatalogo.nStbCatalogoID
            WHERE (dbo.StbCatalogo.sNombre = 'ModulosCursoSocias')"

            If XdsCombos.ExistTable("Modulos") Then
                XdsCombos("Modulos").ExecuteSql(strSQL)
            Else
                XdsCombos.NewTable(strSQL, "Modulos")
                XdsCombos("Modulos").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboModulos.DataSource = XdsCombos("Modulos").Source
            Me.cboModulos.Rebind()

            Me.cboModulos.Splits(0).DisplayColumns("nStbCatalogoID").Visible = False
            Me.cboModulos.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboModulos.Splits(0).DisplayColumns("sNombre").Visible = False

            'Me.cboModulos.Splits(0).DisplayColumns("nCodPersona").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboModulos.Splits(0).DisplayColumns("sCodigoInterno").Width = 50
            Me.cboModulos.Splits(0).DisplayColumns("sDescripcion").Width = Me.cboModulos.Width

            Me.cboModulos.Columns("sCodigoInterno").Caption = "Código"
            Me.cboModulos.Columns("sDescripcion").Caption = "Módulo"

            Me.cboModulos.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            'Me.cboModulos.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            Me.cboModulos.DisplayMember = "sDescripcion"
            Me.cboModulos.ValueMember = "nStbValorCatalogoID"

            Me.cboModulos.DropDownWidth = Me.cboModulos.Width

            If moduloID <> 0 Then
                Me.cboModulos.SelectedValue = moduloID
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try




    End Sub

    Private Sub InicializarVariables()
        Try
            XdsCombos = New BOSistema.Win.XDataSet
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdAceptar_Click(sender As Object, e As EventArgs) Handles cmdAceptar.Click
        Dim cmd As New BOSistema.Win.XComando
        Dim strSQL As String = ""
        Try
            strSQL = String.Format("Select top 1 ISNULL(nSclModuloFichaSociaID, 0) nSclModuloFichaSociaID from SclModuloFichaSocia MS 
            right join SclFichaSocia FS ON FS.nSclFichaSociaID=MS.nSclFichaSociaID 
            Where FS.nSclFichaSociaID={0}", Me.nSclFichaID)

            Dim nSclModuloFichaSociaID As Long = 0
            nSclModuloFichaSociaID = cmd.ExecuteScalar(strSQL)

            strSQL = String.Format("Exec spSclCreateModuloFichaSocia {0}, {1}, {2}, '{3}' ", {nSclModuloFichaSociaID, Me.nSclFichaID, cboModulos.SelectedValue, InfoSistema.LoginName})

            cmd.ExecuteNonQuery(strSQL)

            MsgBox("El módulo se ha cambiado exitosamente.", vbInformation, "SMUSURA0")

            Me.Close()

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
End Class