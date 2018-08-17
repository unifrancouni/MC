Public Class frmSclEditFichaUnicaPersona
    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSclPersona As Long 'SclSocia.nSclSociaID
    Dim nLimpiar As Integer
    Dim StrFecha As String
    Dim bValidar As Boolean = True

    Dim IdSclSocia As Long 'SclSocia.nSclSociaID

    '-- Clases para procesar la informacion de los combos
    Dim XdtEstadoCivil As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDocumento As BOSistema.Win.XDataSet.xDataTable
    Dim XdsEscolaridad As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset (conjunto de tablas)
    Dim ObjSociadt As BOSistema.Win.SclEntSocia.SclSociaDataTable
    Dim ObjSociadr As BOSistema.Win.SclEntSocia.SclSociaRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum


    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad publica utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Socia.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID de la Socia que corresponde al campo
    'nSclSociaID de la tabla SclSocia.
    Public Property IdPersona() As Long
        Get
            IdPersona = IdSclPersona
        End Get
        Set(ByVal value As Long)
            IdSclPersona = value
        End Set
    End Property
    Public Property IdSocia() As Long
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Long)
            IdSclSocia = value
        End Set
    End Property
    Private Sub InicializarVariables()
        Try

            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Miembro"
            Else
                Me.Text = "Modificar Miembro"
            End If

            XdtEstadoCivil = New BOSistema.Win.XDataSet.xDataTable
            XdtDocumento = New BOSistema.Win.XDataSet.xDataTable
            XdsEscolaridad = New BOSistema.Win.XDataSet
            XdsUbicacion = New BOSistema.Win.XDataSet

            ObjSociadt = New BOSistema.Win.SclEntSocia.SclSociaDataTable
            ObjSociadr = New BOSistema.Win.SclEntSocia.SclSociaRow

            'Limpiar los combos:
     
            Me.cboPrimaria.ClearFields()
            Me.cboSecundaria.ClearFields()
            Me.cboCarreraTecnica.ClearFields()

            If ModoFrm = "ADD" Then
                'ObjSociadr = ObjSociadt.NewRow
                'Inicializar los Length de los campos (Strings)
           
            End If

            'Siempre Inhabilitar Nombres:
            nLimpiar = 1




    



   

            'OJO FIN 





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarPrimaria()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'EducacionPrimaria')" & _
                         " ORDER BY a.sCodigoInterno"

            If XdsEscolaridad.ExistTable("Primaria") Then
                XdsEscolaridad("Primaria").ExecuteSql(Strsql)
            Else
                XdsEscolaridad.NewTable(Strsql, "Primaria")
                XdsEscolaridad("Primaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboPrimaria.DataSource = XdsEscolaridad("Primaria").Source

            Me.cboPrimaria.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboPrimaria.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboPrimaria.Columns("sCodigoInterno").Caption = "Código"
            Me.cboPrimaria.Columns("sDescripcion").Caption = "Descripción"

            Me.cboPrimaria.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboPrimaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/09/2007
    ' Procedure Name:       CargarSecundaria
    ' Descripción:          Este procedimiento permite cargar el listado de niveles
    '                       de Escolaridad secundaria en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarSecundaria()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'EducacionSecundaria') " & _
                         " ORDER BY a.sCodigoInterno"

            If XdsEscolaridad.ExistTable("Secundaria") Then
                XdsEscolaridad("Secundaria").ExecuteSql(Strsql)
            Else
                XdsEscolaridad.NewTable(Strsql, "Secundaria")
                XdsEscolaridad("Secundaria").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboSecundaria.DataSource = XdsEscolaridad("Secundaria").Source

            Me.cboSecundaria.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboSecundaria.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboSecundaria.Columns("sCodigoInterno").Caption = "Código"
            Me.cboSecundaria.Columns("sDescripcion").Caption = "Descripción"

            Me.cboSecundaria.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboSecundaria.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
            If Me.cboSecundaria.ListCount > 0 Then
                Me.cboSecundaria.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                03/09/2007
    ' Procedure Name:       CargarCarreraTecnica
    ' Descripción:          Este procedimiento permite cargar el listado de 
    '                       Carreras Técnicas en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarCarreraTecnica()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'CarreraTecnica') " & _
                         " ORDER BY a.sCodigoInterno"

            If XdsEscolaridad.ExistTable("CarreraTecnica") Then
                XdsEscolaridad("CarreraTecnica").ExecuteSql(Strsql)
            Else
                XdsEscolaridad.NewTable(Strsql, "CarreraTecnica")
                XdsEscolaridad("CarreraTecnica").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboCarreraTecnica.DataSource = XdsEscolaridad("CarreraTecnica").Source

            Me.cboCarreraTecnica.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboCarreraTecnica.Columns("sCodigoInterno").Caption = "Código"
            Me.cboCarreraTecnica.Columns("sDescripcion").Caption = "Descripción"

            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCarreraTecnica.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro:
            If Me.cboCarreraTecnica.ListCount > 0 Then
                Me.cboCarreraTecnica.SelectedIndex = 0
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarPersona()
        Dim Strsql As String
        'Dim IdMunicipio As Long
        'Dim IdDepartamento As Long
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable

        Try

            '-- Buscar la Socia correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.


            Strsql = "SELECT     nSclFichaUnicaPersonaID, nSclFichaUnicaID, nCodigo, nStbParentescoID, sNombre1, sNombre2, sApellido1, sApellido2, dFechaNacimiento,sNumeroCedula, nEdad, nAlfabetizada, nStbPrimariaID, nStbSecundariaID, nStbCarreraTecnicaID, sOtrosEstudios, nSexo, nInscrito, nVacunas,nControlPrenatal, nMatricula FROM         dbo.SclFichaUnicaPersona WHERE (nSclFichaUnicaPersonaID = " & Me.IdPersona & ")"


            RegTmp.ExecuteSql(StrSql)
            If RegTmp.Count > 0 Then

                txtCodigo.Text = RegTmp.ValueField("nCodigo")



                CargarParentesco() 'EC de socia actual.
                If XdtEstadoCivil.Count > 0 Then
                    Me.cboEstadoCivil.SelectedIndex = 0
                End If
                XdtEstadoCivil.SetCurrentByID("nStbValorCatalogoID", RegTmp.ValueField("nStbParentescoID"))

                CargarPrimaria()
                If XdsEscolaridad("Primaria").Count > 0 Then
                    Me.cboPrimaria.SelectedIndex = 0
                End If
                XdsEscolaridad("Primaria").SetCurrentByID("nStbValorCatalogoID", RegTmp.ValueField("nStbPrimariaID"))


                CargarSecundaria()
                If XdsEscolaridad("Secundaria").Count > 0 Then
                    Me.cboSecundaria.SelectedIndex = 0
                End If
                XdsEscolaridad("Secundaria").SetCurrentByID("nStbValorCatalogoID", RegTmp.ValueField("nStbSecundariaID"))


                CargarCarreraTecnica()
                If XdsEscolaridad("CarreraTecnica").Count > 0 Then
                    Me.cboCarreraTecnica.SelectedIndex = 0
                End If
                XdsEscolaridad("CarreraTecnica").SetCurrentByID("nStbValorCatalogoID", RegTmp.ValueField("nStbCarreraTecnicaID"))



                If Not IsDBNull(RegTmp.ValueField("sNombre1")) Then
                    txtNombre1.Text = RegTmp.ValueField("sNombre1")
                Else
                    txtNombre1.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("sNombre2")) Then
                    txtNombre2.Text = RegTmp.ValueField("sNombre2")
                Else
                    txtNombre2.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("sApellido1")) Then
                    txtApellido1.Text = RegTmp.ValueField("sApellido1")
                Else
                    txtApellido1.Text = ""
                End If

                If Not IsDBNull(RegTmp.ValueField("sApellido2")) Then
                    txtApellido2.Text = RegTmp.ValueField("sApellido2")
                Else
                    txtApellido2.Text = ""
                End If



                If Not IsDBNull(RegTmp.ValueField("sApellido2")) Then
                    txtApellido2.Text = RegTmp.ValueField("sApellido2")
                Else
                    txtApellido2.Text = ""
                End If




                If Not IsDBNull(RegTmp.ValueField("dFechaNacimiento")) Then
                    Me.cdeFechaNace.Value = RegTmp.ValueField("dFechaNacimiento")
                Else
                    Me.cdeFechaNace.ValueIsDbNull = True
                End If





                If Not IsDBNull(RegTmp.ValueField("sNumeroCedula")) Then
                    mtbNumCedula.Text = RegTmp.ValueField("sNumeroCedula")
                Else
                    mtbNumCedula.Text = ""
                End If





                If Not IsDBNull(RegTmp.ValueField("nEdad")) Then
                    TxtEdad.Text = RegTmp.ValueField("nEdad")
                Else
                    TxtEdad.Text = ""
                End If





                If Not IsDBNull(RegTmp.ValueField("nAlfabetizada")) Then
                    If RegTmp.ValueField("nAlfabetizada") > 0 Then

                        chkAlfabetizada.Checked = True
                    Else
                        chkAlfabetizada.Checked = False
                    End If
                Else
                    chkAlfabetizada.Checked = False
                End If




                If Not IsDBNull(RegTmp.ValueField("sOtrosEstudios")) Then
                    txtOtrosEstudios.Text = RegTmp.ValueField("sOtrosEstudios")
                Else
                    txtOtrosEstudios.Text = ""
                End If


                If Not IsDBNull(RegTmp.ValueField("nSexo")) Then
                    If RegTmp.ValueField("nSexo") = 1 Then
                        RadHombre.Checked = True
                    Else
                        If RegTmp.ValueField("nSexo") = 2 Then
                            RadMujer.Checked = True
                        End If
                    End If
                End If


                If Not IsDBNull(RegTmp.ValueField("nInscrito")) Then
                    If RegTmp.ValueField("nInscrito") = 1 Then
                        RadInscritosSI.Checked = True
                    Else
                        If RegTmp.ValueField("nInscrito") = 2 Then
                            RadInscritosNO.Checked = True
                        End If
                    End If
                End If



                If Not IsDBNull(RegTmp.ValueField("nVacunas")) Then
                    If RegTmp.ValueField("nVacunas") = 1 Then
                        RadVacunasSI.Checked = True
                    Else
                        If RegTmp.ValueField("nVacunas") = 2 Then
                            RadVacunasNO.Checked = True
                        End If
                    End If
                End If


                If Not IsDBNull(RegTmp.ValueField("nControlPrenatal")) Then
                    If RegTmp.ValueField("nControlPrenatal") = 1 Then
                        RadControlSI.Checked = True

                    Else
                        If RegTmp.ValueField("nControlPrenatal") = 2 Then
                            RadControlNO.Checked = True
                        Else
                            If RegTmp.ValueField("nControlPrenatal") = 3 Then
                                RadControlNOAplica.Checked = True
                            End If

                        End If
                    End If
                End If


                If Not IsDBNull(RegTmp.ValueField("nMatricula")) Then
                    If RegTmp.ValueField("nMatricula") = 1 Then
                        RadMatriculaSI.Checked = True

                    Else
                        If RegTmp.ValueField("nMatricula") = 2 Then
                            RadMatriculaNO.Checked = True
                        Else
                            If RegTmp.ValueField("nMatricula") = 3 Then
                                RadMatriculaNOAplica.Checked = True
                            End If
                        End If
                    End If
                End If


            End If 'Si tiene registros  If RegTmp.Count > 0 Then


        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub
    Private Sub CargarParentesco()
        Try
            Dim Strsql As String = ""

            Strsql = " SELECT a.nStbValorCatalogoID, a.sCodigoInterno, a.sDescripcion " & _
                         " FROM StbValorCatalogo AS a INNER JOIN StbCatalogo AS b " & _
                         " ON a.nStbCatalogoID = b.nStbCatalogoID " & _
                         " WHERE (b.sNombre = 'Parentesco') " & _
                         " ORDER BY a.sCodigoInterno"

            XdtEstadoCivil.ExecuteSql(Strsql)
            Me.cboEstadoCivil.DataSource = XdtEstadoCivil.Source

            Me.cboEstadoCivil.Splits(0).DisplayColumns("nStbValorCatalogoID").Visible = False
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sCodigoInterno").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sCodigoInterno").Width = 47
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sDescripcion").Width = 100

            Me.cboEstadoCivil.Columns("sCodigoInterno").Caption = "Código"
            Me.cboEstadoCivil.Columns("sDescripcion").Caption = "Descripción"

            Me.cboEstadoCivil.Splits(0).DisplayColumns("sCodigoInterno").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboEstadoCivil.Splits(0).DisplayColumns("sDescripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub frmSclEditFichaUnicaPersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()

            'Cargar Combos:
            CargarParentesco()
            CargarPrimaria()
            CargarSecundaria()
            CargarCarreraTecnica()
            Seg.RefreshPermissions()
            'Si el formulario está en modo edición cargar los datos del Catalogo.
            If ModoFrm = "UPD" Then
                CargarPersona()
                If Val(Me.txtCodigo.Text) = 1 Then 'Es la socia siempre debe quedar como jefe(A)'
                    Me.cboEstadoCivil.Enabled = False

                End If
              

            Else 'ADD.
                'mtbNumHijos.Text = 0
                RegTmp.ExecuteSql("SELECT     ISNULL(COUNT(dbo.SclFichaUnicaPersona.nSclFichaUnicaPersonaID), 0) AS Total FROM         dbo.SclFichaUnicaHogar INNER JOIN  dbo.SclFichaUnicaPersona ON dbo.SclFichaUnicaHogar.nSclFichaUnicaID = dbo.SclFichaUnicaPersona.nSclFichaUnicaID  WHERE(dbo.SclFichaUnicaHogar.nSclSociaID = " & IdSocia & ") GROUP BY dbo.SclFichaUnicaHogar.nSclSociaID")
                If RegTmp.Count = 0 Then
                    Me.txtCodigo.Text = 1
                Else
                    Me.txtCodigo.Text = RegTmp.ValueField("Total") + 1
                End If




            End If

            Me.cboEstadoCivil.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub

    Private Sub txtNombre1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre1.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtNombre2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNombre2.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtApellido1_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido1.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtApellido2_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtApellido2.KeyPress
        Try
            If (UCase(e.KeyChar) < "A" Or UCase(e.KeyChar) > "Z") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "É" And UCase(e.KeyChar) <> "Á" And UCase(e.KeyChar) <> "Í" And UCase(e.KeyChar) <> "Ó" And UCase(e.KeyChar) <> "Ú" And UCase(e.KeyChar) <> "Ñ" And UCase(e.KeyChar) <> "á" And UCase(e.KeyChar) <> "é" And UCase(e.KeyChar) <> "í" And UCase(e.KeyChar) <> "ó" And UCase(e.KeyChar) <> "ú" And UCase(e.KeyChar) <> "ñ" Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtOtrosEstudios_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOtrosEstudios.KeyPress
        Try
            If TextoValido(UCase(e.KeyChar)) = False Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub TxtEdad_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtEdad.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Function ValidaDatosEntrada() As Boolean
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable


        Try

            ValidaDatosEntrada = True
            Me.errSocia.Clear()



            If Me.cboEstadoCivil.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar el parentesco.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboEstadoCivil, "Debe seleccionar el parentesco.")
                Me.cboEstadoCivil.Focus()
                Exit Function
            End If
            'Número de Cédula Obligatorio: Para el Jefe es la Socia.


            
            If Val(txtCodigo.Text) = 1 Then
                If Not IsNumeric(Mid(Me.mtbNumCedula.Text, 1, 1)) Then
                    MsgBox("El Número de Cédula de la Socia NO DEBE quedar vacío, para el jefe(a) hogar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia NO DEBE quedar vacío para el jefe(a) hogar.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
            End If
            If Val(txtCodigo.Text) <> 1 Then

                If cboEstadoCivil.Columns("sCodigoInterno").Value = 0 Then


                    MsgBox("Solo la persona No 1 puede ser jefa(a) del hogar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cboEstadoCivil, "Solo la persona No 1 puede ser jefa(a) del hogar.")
                    Me.cboEstadoCivil.Focus()
                    Exit Function

                End If





            End If

            'NO validar Número de Cédula si no corresponde a Formato:
            'Y establecer como fecha de nacimiento: 30/05/1964
            If Me.mtbNumCedula.Text = "   -      -" Then

                StrFecha = "30/05/1964"
                If Val(txtCodigo.Text) = 1 Then
                    MsgBox("El Número de Cédula es obligatorio para el jefe(a).", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula es obligatorio para el jefe(a).")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
            Else
                'Fecha válida en número de Cédula:
                StrFecha = Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 5, 2) + "/" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 7, 2) + "/19" + Mid(Trim(RTrim(Me.mtbNumCedula.Text)), 9, 2)
                If Not IsDate(StrFecha) Then
                    MsgBox("El Número de Cédula debe contener una fecha válida.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula debe contener una fecha válida.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
                If IsDBNull(cdeFechaNace.Value) Then
                    MsgBox("Debe indicar fecha de nacimiento por que indico cédula.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cdeFechaNace, "Debe indicar fecha de nacimiento por que indico cédula.")
                    Me.cdeFechaNace.Focus()
                    Exit Function
                End If
                If Trim(cdeFechaNace.Text) <> Trim(StrFecha) Then
                    MsgBox("Debe indicar fecha de nacimiento que indico en la  cédula.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.cdeFechaNace, "Debe indicar fecha de nacimientoque indico en la cédula.")
                    Me.cdeFechaNace.Focus()
                    Exit Function
                End If

                'Determinar Duplicados en el Número de Cédula:
                If ModoFrm = "UPD" Then
                    RegTmp.ExecuteSql("Select nSclFichaUnicaPersonaID  from  dbo.SclFichaUnicaPersona INNER JOIN  dbo.SclFichaUnicaHogar ON dbo.SclFichaUnicaPersona.nSclFichaUnicaID = dbo.SclFichaUnicaHogar.nSclFichaUnicaID AND  dbo.SclFichaUnicaPersona.nSclFichaUnicaID = dbo.SclFichaUnicaHogar.nSclFichaUnicaID  Where nSclFichaUnicaPersonaID<>" & Me.IdPersona & " And sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And  nSclSociaID=" & Me.IdSocia)


                Else
                    RegTmp.ExecuteSql("Select  nSclFichaUnicaPersonaID from  dbo.SclFichaUnicaPersona  INNER JOIN  dbo.SclFichaUnicaHogar ON dbo.SclFichaUnicaPersona.nSclFichaUnicaID = dbo.SclFichaUnicaHogar.nSclFichaUnicaID AND  dbo.SclFichaUnicaPersona.nSclFichaUnicaID = dbo.SclFichaUnicaHogar.nSclFichaUnicaID    Where sNumeroCedula = '" & Me.mtbNumCedula.Text & "' And  nSclSociaID=" & Me.IdSocia)
                End If

                If RegTmp.Count > 0 Then
                    MsgBox("El Número de Cédula NO DEBE repetirse. ", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula NO DEBE repetirse.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If
                'Número de Cédula Válido:
                Select Case SMUSURA0.ValidarCedula(Me.mtbNumCedula.Text)
                    Case Cedula.Invalida
                        MsgBox("El Número de Cédula de la Socia es invalido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "El Número de Cédula de la Socia es invalido.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                    Case Cedula.LongitudIncorrecta
                        MsgBox("La Longitud del Número de Cédula de la Socia es incorrecta.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.mtbNumCedula, "La Longitud del Número de Cédula de la Socia es incorrecta.")
                        Me.mtbNumCedula.Focus()
                        Exit Function
                End Select
            End If

            'Primer Nombre Obligatorio:
            If Trim(RTrim(Me.txtNombre1.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Nombre de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtNombre1, "El Primer Nombre de la Socia NO DEBE quedar vacío.")
                Me.txtNombre1.Focus()
                Exit Function
            End If

            'Primer Apellido Obligatorio:
            If Trim(RTrim(Me.txtApellido1.Text)).ToString.Length = 0 Then
                MsgBox("El Primer Apellido de la Socia NO DEBE quedar vacío.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtApellido1, "El Primer Apellido de la Socia NO DEBE quedar vacío.")
                Me.txtApellido1.Focus()
                Exit Function
            End If


            'Edad:
            If Not IsNumeric(Me.TxtEdad.Text) Then
                MsgBox("Debe indicar  la Edad.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.TxtEdad, "Debe indicar  la Edad.")
                Me.TxtEdad.Focus()
                Exit Function
            End If

            If Not (Val(Me.TxtEdad.Text) >= 0 And Val(Me.TxtEdad.Text) <= 130) Then
                MsgBox("Debe indicar  la Edad. Entre 0 y 130 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.TxtEdad, "Debe indicar  la Edad. Entre 0 y 130 años.")
                Me.TxtEdad.Focus()
                Exit Function
            End If




            'Nivel de Educación Primaria:
            If Me.cboPrimaria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un nivel de escolaridad Primaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboPrimaria, "Debe seleccionar un nivel de escolaridad Primaria.")
                Me.cboPrimaria.Focus()
                Exit Function
            End If

            'Si al menos se indicó Educación primaria (último año) 
            'no puede indicar Alfabetizada = 0:
            If chkAlfabetizada.Checked = False Then
                If cboPrimaria.Columns("sCodigoInterno").Value = "7" Then
                    MsgBox("Imposible indicar Socia NO Alfabetizada" & Chr(13) & _
                       " si esta tiene la Primaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.chkAlfabetizada, "Imposible indicar Socia NO Alfabetizada si esta tiene la Primaria aprobada.")
                    Me.chkAlfabetizada.Focus()
                    Exit Function
                End If
            End If

            'Nivel de Educación Secundaria:
            If Me.cboSecundaria.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un nivel de escolaridad Secundaria.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboSecundaria, "Debe seleccionar un nivel de escolaridad Secundaria.")
                Me.cboSecundaria.Focus()
                Exit Function
            End If

            'No se puede indicar secundaria > a NINGUNA 
            'si no se indicó último año de primaria:
            If (CInt(cboSecundaria.Columns("sCodigoInterno").Value) > 1) And (cboPrimaria.Columns("sCodigoInterno").Value <> "7") Then
                MsgBox("Imposible indicar Educación Secundaria" & Chr(13) & _
                       " si no se tiene la Primaria aprobada.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboSecundaria, "Imposible indicar Educación Secundaria si no se tiene la Primaria aprobada.")
                Me.cboSecundaria.Focus()
                Exit Function
            End If

            'Carrera Técnica:
            If Me.cboCarreraTecnica.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar una Carrera Técnica.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboCarreraTecnica, "Debe seleccionar una Carrera Técnica.")
                Me.cboCarreraTecnica.Focus()
                Exit Function
            End If

            'No se puede indicar carrera técnica 
            'si no se indicó Secundaria con Ciclo Báscico:
            If (CInt(cboCarreraTecnica.Columns("sCodigoInterno").Value) > 1) And (CInt(cboSecundaria.Columns("sCodigoInterno").Value) < 4) Then
                MsgBox("Imposible indicar Carrera Técnica si Socia" & Chr(13) & _
                       " no tiene el Ciclo Básico aprobado.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboCarreraTecnica, "Imposible indicar Carrera Técnica si no se tiene el Ciclo Básico aprobado.")
                Me.cboCarreraTecnica.Focus()
                Exit Function
            End If



            If RadHombre.Checked = False And RadMujer.Checked = False Then
                MsgBox("Debe indicar el Sexo de la persona.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpSexo, "Debe indicar el Sexo de la persona.")
                Me.GrpSexo.Focus()
                Exit Function
            End If



            If RadInscritosSI.Checked = False And RadInscritosNO.Checked = False Then
                MsgBox("Debe indicar si esta inscrito o no.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpInscritos, "Debe indicar si esta inscrito o no.")
                Me.GrpInscritos.Focus()
                Exit Function
            End If



            If RadVacunasSI.Checked = False And RadVacunasNO.Checked = False Then
                MsgBox("Debe indicar si tiene vacunas o no.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpVacunas, "Debe indicar si tiene vacunas o no.")
                Me.GrpVacunas.Focus()
                Exit Function
            End If




            If RadControlSI.Checked = False And RadControlNO.Checked = False And RadControlNOAplica.Checked = False Then
                MsgBox("Debe indicar si tiene control prenatal.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpControl, "Debe indicar si tiene control prenatal.")
                Me.GrpControl.Focus()
                Exit Function
            End If


            If RadMatriculaSI.Checked = False And RadMatriculaNO.Checked = False And RadMatriculaNOAplica.Checked = False Then
                MsgBox("Debe indicar si tiene matricula.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpMatricula, "Debe indicar si tiene matricula.")
                Me.GrpMatricula.Focus()
                Exit Function
            End If



            If Val(txtCodigo.Text) = 1 And RadMujer.Checked = False Then
                MsgBox("La Jefa tiene que ser Mujer.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpSexo, "La Jefa tiene que ser Mujer.")
                Me.GrpSexo.Focus()
                Exit Function
            End If

            If Val(txtCodigo.Text) = 1 And CInt(cboEstadoCivil.Columns("sCodigoInterno").Value) <> 0 Then
                MsgBox("Parentesco de la primer persona debe ser Jefe(a).", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboEstadoCivil, "Parentesco de la primer persona debe ser Jefe(a).")
                Me.cboEstadoCivil.Focus()
                Exit Function
            End If





            If Val(txtCodigo.Text) = 1 Then 'Tiene que ser la misma cedula de la jefa en SclSocia. si es la persona numero 1

                RegTmp.ExecuteSql("SELECT     sNumeroCedula, sNombre1, sApellido1  FROM         dbo.SclSocia  WHERE     (nSclSociaID = " & Me.IdSocia & ")")
                If Trim(RegTmp.ValueField("sNumeroCedula")) <> Trim(Me.mtbNumCedula.Text) Then
                    MsgBox("La cédula no coincide con el registro de socias para la jefe(a) de hogar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.mtbNumCedula, "La cédula no coincide con el registro de socias para la jefe(a) de hogar.")
                    Me.mtbNumCedula.Focus()
                    Exit Function
                End If

                If Trim(RegTmp.ValueField("sNombre1")) <> Trim(Me.txtNombre1.Text) Then
                    MsgBox("El Primer Nombre no coincide con el registro de socias para la jefe(a) de hogar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.txtNombre1, "El Primer Nombre no coincide con el registro de socias para la jefe(a) de hogar.")
                    Me.txtNombre1.Focus()
                    Exit Function
                End If
                If Trim(RegTmp.ValueField("sApellido1")) <> Trim(Me.txtApellido1.Text) Then
                    MsgBox("El Primer Apellido no coincide con el registro de socias para la jefe(a) de hogar.", MsgBoxStyle.Critical, NombreSistema)
                    ValidaDatosEntrada = False
                    Me.errSocia.SetError(Me.txtApellido1, "El Primer Apellido no coincide con el registro de socias para la jefe(a) de hogar.")
                    Me.txtApellido1.Focus()
                    Exit Function
                End If

            End If

            If Me.mtbNumCedula.Text <> "   -      -" And Val(txtCodigo.Text) <> 1 Then 'Resto de los miembros ver si esta cedula en socia.

                RegTmp.ExecuteSql("SELECT     sNumeroCedula, sNombre1, sApellido1  FROM         dbo.SclSocia  WHERE     (sNumeroCedula= '" & Me.mtbNumCedula.Text & "')")
                If RegTmp.Count > 0 Then 'Encontro en socia al que no es jefa, ver si coinciden sus nombre uno y apellido uno
                    If Trim(RegTmp.ValueField("sNombre1")) <> Trim(Me.txtNombre1.Text) Then
                        MsgBox("Cédula en registro de Socia no coincide El Primer Nombre.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.txtNombre1, "Cédula en registro de Socia no coincide El Primer Nombre.")
                        Me.txtNombre1.Focus()
                        Exit Function
                    End If
                    If Trim(RegTmp.ValueField("sApellido1")) <> Trim(Me.txtApellido1.Text) Then
                        MsgBox("Cédula en registro de Socia no coincide El Primer Apellido.", MsgBoxStyle.Critical, NombreSistema)
                        ValidaDatosEntrada = False
                        Me.errSocia.SetError(Me.txtApellido1, "Cédula en registro de Socia no coincide El Primer Apellido.")
                        Me.txtApellido1.Focus()
                        Exit Function
                    End If

                End If



            End If


        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            'ObjTmpSocia.Close()
            'ObjTmpSocia = Nothing

            'ObjSclGS.Close()
            'ObjSclGS = Nothing
        End Try
    End Function
    Private Sub SalvarPersona()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            Dim dFechaNace As Date
            Dim intSociaTmpID As Integer
            Dim Sexo As Integer
            Dim Inscrito As Integer
            Dim Vacuna As Integer
            Dim ControlPrenatal As Integer
            Dim Matricula As Integer
            Dim SCedula As String

            'dFechaNace = Me.cdeFechaNace.Value

            If IsDBNull(Me.cdeFechaNace.Value) Then
                'Ponerla en enero 1 de 1800 en el proced la pone en nula.
                dFechaNace = "1800-01-01"
            Else
                dFechaNace = Me.cdeFechaNace.Value
            End If

            If RadHombre.Checked Then
                Sexo = 1
            Else
                If RadMujer.Checked Then
                    Sexo = 2
                End If
            End If

            If RadInscritosSI.Checked Then
                Inscrito = 1
            Else
                If RadInscritosNO.Checked Then
                    Inscrito = 2
                End If
            End If
            If RadVacunasSI.Checked Then
                Vacuna = 1
            Else
                If RadVacunasNO.Checked Then
                    Vacuna = 2
                End If
            End If




            If RadControlSI.Checked Then
                ControlPrenatal = 1
            Else
                If RadControlNO.Checked Then
                    ControlPrenatal = 2
                Else
                    If RadControlNOAplica.Checked Then
                        ControlPrenatal = 3
                    End If
                End If

            End If


            If RadMatriculaSI.Checked Then
                Matricula = 1
            Else
                If RadMatriculaNO.Checked Then
                    Matricula = 2
                Else
                    If RadMatriculaNOAplica.Checked Then
                        Matricula = 3
                    End If
                End If

            End If

            'IIf(IsDBNull(dFechaRegistro), "", )

            ''If ModoFrm = "ACR" Then
            ''    strSQL = " EXEC spSccAnularReciboConRegeneracion " & Me.IdSccReciboOficialCaja & "," & Me.IdSccSolicitudCheque & "," & Me.txtNumRecibo.Text & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & XdsRecibo("Representante").ValueField("nSrhEmpleadoID") & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta & ",'" & Me.sMotivoAnulacion & "'"
            ''Else
            ''strSQL = " EXEC spSclGrabarFichaUnica '" & Me.ModoFrm & "',"    & Me.IdSccSolicitudCheque & "," & Me.txtNumRecibo.Text & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & XdsRecibo("Representante").ValueField("nSrhEmpleadoID") & "," & IdMinutaDeposito & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta & "," & Me.IdEspecial & "," & IdCaja & "," & nCodigoTalonario
            SCedula = ""
            If Trim(mtbNumCedula.Text) <> "-      -" Then
                SCedula = Trim(mtbNumCedula.Text)

            End If



            strSQL = " EXEC spSclGrabarFichaUnicaPersona '" & Me.ModoFrm & "'," & Me.IdSocia & "," & Me.IdPersona & "," & Val(Me.txtCodigo.Text) & "," & Me.cboEstadoCivil.Columns("nStbValorCatalogoID").Value & ",'" & Trim(Me.txtNombre1.Text) & "','" & Trim(txtNombre2.Text) & "','" & _
                      Trim(Me.txtApellido1.Text) & "','" & Trim(Me.txtApellido2.Text) & "','" & Format(dFechaNace, "yyyy-MM-dd") & "','" & Trim(Scedula) & "'," & Val(TxtEdad.Text) & "," & IIf(chkAlfabetizada.Checked, 1, 0) & "," & Me.cboPrimaria.Columns("nStbValorCatalogoID").Value & "," & Me.cboSecundaria.Columns("nStbValorCatalogoID").Value & "," & _
                      Me.cboCarreraTecnica.Columns("nStbValorCatalogoID").Value & ",'" & Trim(Me.txtOtrosEstudios.Text) & "'," & Sexo & "," & Inscrito & "," & Vacuna & "," & ControlPrenatal & "," & Matricula & ",'" & InfoSistema.LoginName & "'"
            ''End If

            'Asignar el Id de la Socia a la variable publica del formulario
            intSociaTmpID = XcDatos.ExecuteScalar(strSQL)
            'Me.IdSccReciboOficialCaja = XcDatos.ExecuteScalar(strSQL)
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If intSociaTmpID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")

            Else
                If ModoFrm = "ADD" Then

                    IdPersona = intSociaTmpID
                    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                    ModoFrm = "UPD"
                Else
                    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
                End If
            End If

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcDatos.Close()
            XcDatos = Nothing
        End Try
    End Sub
    Private Sub cmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdAceptar.Click
        Try
            If ValidaDatosEntrada() Then
                SalvarPersona()
                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdLimpiarFecha_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        cdeFechaNace.Value = 1
    End Sub
End Class