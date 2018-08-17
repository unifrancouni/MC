Public Class frmSclEditFichaUnica
    '-- Declaracion de Variables 
    Dim ModoForm As String 'ADD/MOD
    Dim IdSclSocia As Long 'SclSocia.nSclSociaID
    Dim nLimpiar As Integer
    Dim StrFecha As String
    Dim bValidar As Boolean = True



    '-- Clases para procesar la informacion de los combos
    Dim XdtEstadoCivil As BOSistema.Win.XDataSet.xDataTable
    Dim XdtDocumento As BOSistema.Win.XDataSet.xDataTable
    Dim XdsEscolaridad As BOSistema.Win.XDataSet
    Dim XdsUbicacion As BOSistema.Win.XDataSet
    Dim XdtPersonas As BOSistema.Win.XDataSet.xDataTable
    Dim XdsCajeroCaja As BOSistema.Win.XDataSet
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
    Public Property IdSocia() As Long
        Get
            IdSocia = IdSclSocia
        End Get
        Set(ByVal value As Long)
            IdSclSocia = value
        End Set
    End Property
    Public ModoPersona As String

    Private Sub frmSclEditFichaUnica_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "RojoLight")
            InicializarVariables()
            '-- Ruta de Archivo de Ayuda:
            Seguridad()
            CargarDepartamento(0)
            CargarEmpleado()
            CargarInfoSocia()
            CargarInfoFichaUnica()



            'Cargar Combos:

         
            Seg.RefreshPermissions()


            'Si el formulario está en modo edición cargar los datos del Catalogo.
            'If ModoFrm = "UPD" Then
            '    CargarSocia()
            '    InhabilitarControles()
            '    ' Si no tiene permiso de agregar cédula deshabilitar la busqueda y modificación de la cédula
            '    If Not Seg.HasPermission("ModificarNombreSocia") Then
            '        Me.mtbNumCedula.Enabled = False
            '        Me.cmdBuscar.Enabled = False
            '    End If

            'Else 'ADD.


            'End If

            'Me.mtbNumCedula.Select()
            vbModifico = False 'Inicializa en False.
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub CargarInfoFichaUnica()

        Dim IdMunicipio As Long
        Dim IdDepartamento As Long
        Dim XcUbicacion As New BOSistema.Win.XComando
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Dim StrSql As String
        Try
            '--Buscar si tiene ficha unica

            StrSql = "SELECT     nSclFichaUnicaID, nSclSociaID, nStbBarrioID, sDireccionSocia, sTelefonoSocia, sTelefonoSociaMovil, nTotalMiembros, nTotalMiembrosMujeres, nTotalMiembrosHombres, nTotalMiembrosMujeres0a5, nTotalMiembrosMujeres6a12, nTotalMiembrosMujeres13a18, nTotalMiembrosMujeres19a60, nTotalMiembrosMujeres60Amas, nTotalMiembrosHombres0a5, nTotalMiembrosHombres6a12, nTotalMiembrosHombres13a18, nTotalMiembrosHombres19a60, nTotalMiembrosHombres60Amas, nCasaHabita,nCasaPropia,nCasaConsidera, sNombreGFCV, sCargoGFCV, sTelefonoGFCV, nSrhEmpleadoID, dFechaRegistro         FROM dbo.SclFichaUnicaHogar  WHERE (nSclSociaID = " & IdSclSocia & ")"

            ModoFrm = "ADD"
            RegTmp.ExecuteSql(StrSql)



            If RegTmp.Count > 0 Then 'Existe setear los valores
                cmdAceptar.Enabled = False
                cmdCancelar.Enabled = False


                If Seg.HasPermission("ModificarHogarFichaUnica") = False Then
                    Me.cmdModificar.Enabled = False
                Else  'Habilita
                    Me.cmdModificar.Enabled = True
                End If
                tbSocia.Enabled = True
                grpLocalizacion.Enabled = False
                grpHogar.Enabled = False



                ModoFrm = "UPD"

                XdsCajeroCaja("Cajero").SetCurrentByID("nSrhEmpleadoID", RegTmp.ValueField("nSrhEmpleadoID"))


                'Cargar Combo de Departamentos:
                'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
                'Determinar Id de Municipio:
                StrSql = " SELECT nStbMunicipioID FROM StbBarrio WHERE (nStbBarrioID = " & RegTmp.ValueField("nStbBarrioID") & ")"
                IdMunicipio = XcUbicacion.ExecuteScalar(StrSql)
                'Cargar Dpto:
                StrSql = " SELECT nStbDepartamentoID FROM StbMunicipio WHERE (nStbMunicipioID = " & IdMunicipio & ")"
                IdDepartamento = XcUbicacion.ExecuteScalar(StrSql)
                CargarDepartamento(IdDepartamento)
                If cboDepartamento.ListCount > 0 Then
                    Me.cboDepartamento.SelectedIndex = 0
                End If
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XcUbicacion.ExecuteScalar(StrSql))
                'Else
                '    Me.cboDepartamento.Text = ""
                '    Me.cboDepartamento.SelectedIndex = -1
                'End If

                'Cargar Combo de Municipios:
                'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
                CargarMunicipio(0, IdMunicipio)
                If cboMunicipio.ListCount > 0 Then
                    Me.cboMunicipio.SelectedIndex = 0
                End If
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", IdMunicipio)
                'Else
                '    Me.cboMunicipio.Text = ""
                '    Me.cboMunicipio.SelectedIndex = -1
                'End If

                'Cargar Combo de Distritos:
                'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
                StrSql = " SELECT nStbDistritoID FROM StbBarrio WHERE (nStbBarrioID = " & RegTmp.ValueField("nStbBarrioID") & ")"
                CargarDistrito(0, XcUbicacion.ExecuteScalar(StrSql))
                If cboDistrito.ListCount > 0 Then
                    Me.cboDistrito.SelectedIndex = 0
                End If
                XdsUbicacion("Distrito").SetCurrentByID("nStbDistritoID", XcUbicacion.ExecuteScalar(StrSql))
                'Else
                '    Me.cboDistrito.Text = ""
                '    Me.cboDistrito.SelectedIndex = -1
                'End If

                'Cargar Combo de Barrios:
                'If Not ObjSociadr.IsFieldNull("nStbBarrioID") Then
                CargarBarrio(0, RegTmp.ValueField("nStbBarrioID"))
                If cboBarrio.ListCount > 0 Then
                    Me.cboBarrio.SelectedIndex = 0
                End If
                XdsUbicacion("Barrio").SetCurrentByID("nStbBarrioID", RegTmp.ValueField("nStbBarrioID"))
                'Else 'Estado civil esta en Null.
                '    Me.cboBarrio.Text = ""
                '    Me.cboBarrio.SelectedIndex = -1
                'End If

                txtDireccion.Text = RegTmp.ValueField("sDireccionSocia")
                If IsDBNull(RegTmp.ValueField("sTelefonoSocia")) Then
                    txtTelefono.Text = ""
                Else
                    txtTelefono.Text = RegTmp.ValueField("sTelefonoSocia")
                End If

                If IsDBNull(RegTmp.ValueField("sTelefonoSociaMovil")) Then
                    txtmovil.Text = ""
                Else
                    txtmovil.Text = RegTmp.ValueField("sTelefonoSociaMovil")
                End If

                txtMiembros.Text = RegTmp.ValueField("nTotalMiembros")
                txtMiembrosMujer.Text = RegTmp.ValueField("nTotalMiembrosMujeres")
                txtMiembrosHombres.Text = RegTmp.ValueField("nTotalMiembrosHombres")
                txtMiembrosMujeres0A5.Text = RegTmp.ValueField("nTotalMiembrosMujeres0a5")
                txtMiembrosMujeres6A12.Text = RegTmp.ValueField("nTotalMiembrosMujeres6a12")
                txtMiembrosMujeres13A18.Text = RegTmp.ValueField("nTotalMiembrosMujeres13a18")
                txtMiembrosMujeres19A60.Text = RegTmp.ValueField("nTotalMiembrosMujeres19a60")
                txtMiembrosMujeres60AMas.Text = RegTmp.ValueField("nTotalMiembrosMujeres60Amas")
                txtMiembrosHombres0A5.Text = RegTmp.ValueField("nTotalMiembrosHombres0a5")
                txtMiembrosHombres6A12.Text = RegTmp.ValueField("nTotalMiembrosHombres6a12")
                txtMiembrosHombres13A18.Text = RegTmp.ValueField("nTotalMiembrosHombres13a18")
                txtMiembrosHombres19A60.Text = RegTmp.ValueField("nTotalMiembrosHombres19a60")
                txtMiembrosHombres60AMas.Text = RegTmp.ValueField("nTotalMiembrosHombres60Amas")
      
                If RegTmp.ValueField("nCasaHabita") = 1 Then
                    RadPropia.Checked = True
                Else
                    If RegTmp.ValueField("nCasaHabita") = 2 Then
                        RadAlquilada.Checked = True
                    Else
                        If RegTmp.ValueField("nCasaHabita") = 3 Then
                            RadPosando.Checked = True
                        End If
                    End If
                End If



                If RegTmp.ValueField("nCasaPropia") = 1 Then
                    RadSi.Checked = True
                Else
                    If RegTmp.ValueField("nCasaPropia") = 2 Then
                        RadNo.Checked = True
                    Else
                        If RegTmp.ValueField("nCasaPropia") = 3 Then
                            RadEnTramite.Checked = True
                        End If
                    End If
                End If


                If RegTmp.ValueField("nCasaConsidera") = 1 Then
                    RadHumilde.Checked = True
                Else
                    If RegTmp.ValueField("nCasaConsidera") = 2 Then
                        RadComoda.Checked = True
                    Else
                        If RegTmp.ValueField("nCasaConsidera") = 3 Then
                            RadLujosa.Checked = True
                        End If
                    End If
                End If



                If IsDBNull(RegTmp.ValueField("sNombreGFCV")) Then
                    TxtNombreGFCV.Text = ""
                Else
                    TxtNombreGFCV.Text = RegTmp.ValueField("sNombreGFCV")
                End If



                If IsDBNull(RegTmp.ValueField("sCargoGFCV")) Then
                    TxtCargoGFCV.Text = ""
                Else
                    TxtCargoGFCV.Text = RegTmp.ValueField("sCargoGFCV")
                End If




                If IsDBNull(RegTmp.ValueField("sTelefonoGFCV")) Then
                    TxtTelefonoGFCV.Text = ""
                Else
                    TxtTelefonoGFCV.Text = RegTmp.ValueField("sTelefonoGFCV")
                End If



                'If IsDBNull(RegTmp.ValueField("sNombreAuditor")) Then
                '    TxtNombreAuditor.Text = ""
                'Else
                '    TxtNombreAuditor.Text = RegTmp.ValueField("sNombreAuditor")
                'End If



                cdeFechaRegistro.Value = RegTmp.ValueField("dFechaRegistro")

                CargarPersonas()
            Else

                cmdAceptar.Enabled = True
                cmdCancelar.Enabled = True
                cmdModificar.Enabled = False
                tbSocia.Enabled = False
                grpLocalizacion.Enabled = True
                grpHogar.Enabled = True


            End If
            




        Catch ex As Exception
            Control_Error(ex)
        Finally
            XcUbicacion.Close()
            XcUbicacion = Nothing
        End Try
    End Sub
    Private Sub CargarInfoSocia()
        Dim RegTmp As New BOSistema.Win.XDataSet.xDataTable
        Dim StrSql As String
        Try

            StrSql = "SELECT  'Departamento:' +rtrim(ltrim(dbo.vwStbUbicacionGeografica.Departamento)) + ' Municipio:' +ltrim(rtrim(dbo.vwStbUbicacionGeografica.Municipio)) +' Distrito:'+ltrim(rtrim( dbo.vwStbUbicacionGeografica.Distrito))+ ' Barrio:'+ ltrim(rtrim( dbo.vwStbUbicacionGeografica.Barrio)) As Ubicacion,   dbo.vwStbUbicacionGeografica.Departamento, dbo.vwStbUbicacionGeografica.Municipio, dbo.vwStbUbicacionGeografica.Distrito,  dbo.vwStbUbicacionGeografica.Barrio, dbo.SclSocia.sDireccionSocia, dbo.SclSocia.dFechaNacimiento, dbo.SclSocia.sNumeroCedula, dbo.SclSocia.sTelefonoSocia, dbo.SclSocia.nSclSociaID , LTRIM(RTRIM(dbo.SclSocia.sNombre1)) + ' '+ LTRIM(RTRIM( dbo.SclSocia.sNombre2))+ ' ' +LTRIM(RTRIM( dbo.SclSocia.sApellido1))+' '+ LTRIM(RTRIM(dbo.SclSocia.sApellido2)) As NombreSocia FROM         dbo.SclSocia INNER JOIN  dbo.vwStbUbicacionGeografica ON dbo.SclSocia.nStbBarrioID = dbo.vwStbUbicacionGeografica.nStbBarrioID            WHERE (dbo.SclSocia.nSclSociaID = " & IdSclSocia & ")"
            RegTmp.ExecuteSql(StrSql)
            If RegTmp.Count > 0 Then
                txtCedulaSocia.Text = RegTmp.ValueField("sNumeroCedula")
                TxtNombreSocia.Text = RegTmp.ValueField("NombreSocia")
                TxtFechaNac.Text = RegTmp.ValueField("dFechaNacimiento")
                TxtTelefonoSocia.Text = IIf(IsDBNull(RegTmp.ValueField("sTelefonoSocia")), "", RegTmp.ValueField("sTelefonoSocia"))
                TxtUbicacion.Text = RegTmp.ValueField("Ubicacion")

            End If
            


        Catch ex As Exception
            Control_Error(ex)
        End Try



    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                31/08/2007
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try

            'If ModoFrm = "ADD" Then
            '    Me.Text = "Agregar Socia"
            'Else
            '    Me.Text = "Modificar Socia"
            'End If

            XdtEstadoCivil = New BOSistema.Win.XDataSet.xDataTable
            XdtDocumento = New BOSistema.Win.XDataSet.xDataTable
            XdsEscolaridad = New BOSistema.Win.XDataSet
            XdsUbicacion = New BOSistema.Win.XDataSet


            ObjSociadt = New BOSistema.Win.SclEntSocia.SclSociaDataTable
            ObjSociadr = New BOSistema.Win.SclEntSocia.SclSociaRow

            XdtPersonas = New BOSistema.Win.XDataSet.xDataTable
            XdsCajeroCaja = New BOSistema.Win.XDataSet
            'Limpiar los Grids (estructura y Datos).
            Me.grdPersonas.ClearFields()

            'Limpiar los combos:
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()
            Me.cboBarrio.ClearFields()
            

            'If ModoFrm = "ADD" Then
            '    ObjSociadr = ObjSociadt.NewRow
            '    'Inicializar los Length de los campos (Strings)
            '    Me.txtNombre1.MaxLength = ObjSociadr.GetColumnLenght("sNombre1")
            '    Me.txtNombre2.MaxLength = ObjSociadr.GetColumnLenght("sNombre2")
            '    Me.txtApellido1.MaxLength = ObjSociadr.GetColumnLenght("sApellido1")
            '    Me.txtApellido2.MaxLength = ObjSociadr.GetColumnLenght("sApellido2")
            '    Me.txtDireccion.MaxLength = ObjSociadr.GetColumnLenght("sDireccionSocia")
            '    Me.txtTelefono.MaxLength = ObjSociadr.GetColumnLenght("sTelefonoSocia")
            '    Me.txtOtrosEstudios.MaxLength = ObjSociadr.GetColumnLenght("sOtrosEstudios")
            '    Me.mtbNumCedula.MaxLength = ObjSociadr.GetColumnLenght("sNumeroCedula")
            '    Me.txtOtroDocumento.MaxLength = ObjSociadr.GetColumnLenght("sNumeroOtroDocumento")
            'End If

            'Siempre Inhabilitar Nombres:
            nLimpiar = 1




            'Me.txtNombre1.Enabled = False
            'Me.txtNombre2.Enabled = False
            'Me.txtApellido1.Enabled = False
            'Me.txtApellido2.Enabled = False



            'OJO TEMPORAL PROBAR SE ACTIVARA SOLO CON USUARIO CON PERMISO DE MODIFICAR
            Seg.RefreshPermissions()



            'If Seg.HasPermission("ModificarNombreSocia") = True Then

            '    Me.txtNombre1.Enabled = True
            '    Me.txtNombre2.Enabled = True
            '    Me.txtApellido1.Enabled = True
            '    Me.txtApellido2.Enabled = True
            'End If

            'OJO FIN 





        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarDepartamento(ByVal intDepartamentoID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            If intDepartamentoID = 0 Then
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) " & _
                         " Order by a.sCodigo"
            Else
                Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbDepartamento a " & _
                         " Where (a.nActivo = 1) Or (a.nStbDepartamentoID = " & intDepartamentoID & ") " & _
                         " Order by a.sCodigo"
            End If


            If XdsUbicacion.ExistTable("Departamento") Then
                XdsUbicacion("Departamento").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Departamento")
                XdsUbicacion("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsUbicacion("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsUbicacion("Departamento").Count > 0 Then
                XdsUbicacion("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Departamento:
            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("sNombre").Caption = "Descripción"
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboMunicipio.ClearFields()

            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & _
                             " ) And (a.nActivo = 1) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                             " From StbMunicipio a " & _
                             " Where ((a.nActivo = 1) And (a.nStbDepartamentoID = " & XdsUbicacion("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " ) Or (a.nStbMunicipioID = " & intMunicipioID & _
                             " )  Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Municipio") Then
                XdsUbicacion("Municipio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Municipio")
                XdsUbicacion("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsUbicacion("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsUbicacion("Municipio").Count > 0 Then
                XdsUbicacion("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            'Configurar el combo Municipio:
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("sNombre").Caption = "Descripción"
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarDistrito
    ' Descripción:          Este procedimiento permite cargar el listado de Distritos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboDistrito.ClearFields()

            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where (a.nActivo = 1) " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbDistrito a " & _
                             " Where (a.nActivo = 1) " & _
                             " Or (a.nStbDistritoID = " & intDistritoID & _
                             " )  Order by a.sCodigo"

                End If
            Else 'Limpiar = 0 Qry No regresa ningun Distrito:
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsUbicacion.ExistTable("Distrito") Then
                XdsUbicacion("Distrito").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Distrito")
                XdsUbicacion("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsUbicacion("Distrito").Source
            Me.cboDistrito.Rebind()

            'Configurar el combo Distritos:
            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").Width = 80
            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("sNombre").Caption = "Descripción"
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarEmpleado()
        Try
            Dim Strsql As String

            Me.cboCajero.ClearFields()

            'Si NO tiene permisos de Edición fuera de su Delegación: 
            

            Strsql = " Select a.nSrhEmpleadoID,a.nCodigo,a.sNombreEmpleado " & _
                     " From vwSclRepresentantePrograma a " & _
                     " WHERE (a.nActivo = 1) Order by a.nCodigo "

            


            If XdsCajeroCaja.ExistTable("Cajero") Then
                XdsCajeroCaja("Cajero").ExecuteSql(Strsql)
            Else
                XdsCajeroCaja.NewTable(Strsql, "Cajero")
                XdsCajeroCaja("Cajero").Retrieve()
            End If

            'Asignando a las fuentes de datos:
            Me.cboCajero.DataSource = XdsCajeroCaja("Cajero").Source
            Me.cboCajero.Rebind()

            Me.cboCajero.Splits(0).DisplayColumns("nSrhEmpleadoID").Visible = False

            'Configurar el combo: 
            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").Width = 60
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").Width = 310

            Me.cboCajero.Columns("nCodigo").Caption = "Código"
            Me.cboCajero.Columns("sNombreEmpleado").Caption = "Nombres y Apellidos"

            Me.cboCajero.Splits(0).DisplayColumns("nCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboCajero.Splits(0).DisplayColumns("sNombreEmpleado").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    ' ------------------------------------------------------------------------
    ' Autor:                Yesenia Gutiérrez
    ' Fecha:                07/09/2007
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrio(ByVal intLimpiarID As Integer, ByVal intBarrioID As Integer)
        Try
            Dim Strsql As String

            'Limpiar Combo:
            Me.cboBarrio.ClearFields()

            If intLimpiarID = 0 Then
                If intBarrioID = 0 Then
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where (a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
                             " )  And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & _
                             " ) Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                             " From StbBarrio a " & _
                             " Where ((a.nActivo = 1) And (a.nStbMunicipioID = " & XdsUbicacion("Municipio").ValueField("nStbMunicipioID") & _
                             " ) And (a.nStbDistritoID = " & XdsUbicacion("Distrito").ValueField("nStbDistritoID") & ")" & _
                             " ) Or (a.nStbBarrioID = " & intBarrioID & _
                             " ) Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbBarrioID,a.nStbMunicipioID,a.nStbDistritoID,a.sCodigo,a.sNombre " & _
                         " From StbBarrio a " & _
                         " Where a.nStbBarrioID = 0"
            End If

            If XdsUbicacion.ExistTable("Barrio") Then
                XdsUbicacion("Barrio").ExecuteSql(Strsql)
            Else
                XdsUbicacion.NewTable(Strsql, "Barrio")
                XdsUbicacion("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsUbicacion("Barrio").Source
            Me.cboBarrio.Rebind()

            'Configurar el combo Barrio:
            Me.cboBarrio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbDistritoID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").Width = 100
            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("sNombre").Caption = "Descripción"
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("sNombre").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
        Try
            If Me.cboMunicipio.SelectedIndex <> -1 Then
                If Me.cboMunicipio.Text = "Managua" Then
                    CargarDistrito(0, 0)
                    Me.cboDistrito.Enabled = True
                Else
                    CargarDistrito(0, 0)
                    If Me.cboDistrito.ListCount > 0 Then
                        Me.cboDistrito.SelectedIndex = 0
                    End If
                    Me.cboDistrito.Enabled = False
                End If
            Else
                CargarDistrito(1, 0)
                CargarBarrio(1, 0)
            End If
            vbModifico = True

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        Try
            If Me.cboDistrito.SelectedIndex <> -1 Then
                CargarBarrio(0, 0)
            Else
                CargarBarrio(1, 0)
            End If
            vbModifico = True
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        vbModifico = True
    End Sub

 

    Private Function ValidaDatosEntrada() As Boolean
        Dim ObjTmpSocia As New BOSistema.Win.SclEntSocia.SclSociaDataTable
        Dim ObjSclGS As New BOSistema.Win.SclEntSocia.SclGrupoSociaDataTable

        Try

            ValidaDatosEntrada = True
            Me.errSocia.Clear()





            'Departamento:
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Departamento donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboDepartamento, "Debe seleccionar Departamento donde reside la socia.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio:
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Municipio donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboMunicipio, "Debe seleccionar Municipio donde reside la socia.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Distrito:
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Distrito donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboDistrito, "Debe seleccionar Distrito donde reside la socia.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Barrio:
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar Barrio donde reside la socia.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboBarrio, "Debe seleccionar Barrio donde reside la socia.")
                Me.cboBarrio.Focus()
                Exit Function
            End If




            'Direccion:
            If Trim(Me.txtDireccion.Text) = "" Then
                MsgBox("Debe ingresar la dirección.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtDireccion, "Debe ingresar la dirección.")
                Me.txtDireccion.Focus()
                Exit Function
            End If







            If Not IsNumeric(txtMiembros.Text) Then
                MsgBox("Debe indicar el numero de miembros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembros, "Debe indicar el numero de miembros.")
                Me.txtMiembros.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembros.Text) >= 1 And Val(txtMiembros.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros. 1 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembros, "Debe indicar el numero de miembros. 1 a 99")
                Me.txtMiembros.Focus()
                Exit Function
            End If



            If Not IsNumeric(txtMiembrosMujer.Text) Then
                MsgBox("Debe indicar el numero de miembros mujeres.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujer, "Debe indicar el numero de miembros mujeres.")
                Me.txtMiembrosMujer.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosMujer.Text) >= 0 And Val(txtMiembrosMujer.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros mujeres. 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujer, "Debe indicar el numero de miembros mujeres. 0 a 99")
                Me.txtMiembrosMujer.Focus()
                Exit Function
            End If




            If Not IsNumeric(txtMiembrosHombres.Text) Then
                MsgBox("Debe indicar el numero de miembros hombres.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres, "Debe indicar el numero de miembros hombres.")
                Me.txtMiembrosHombres.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosHombres.Text) >= 0 And Val(txtMiembrosHombres.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros hombres. 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres, "Debe indicar el numero de miembros hombres. 0 a 99")
                Me.txtMiembrosHombres.Focus()
                Exit Function
            End If




            '-------------MUJERES


            If Not IsNumeric(txtMiembrosMujeres0A5.Text) Then
                MsgBox("Debe indicar el numero de miembros mujeres 0 a 5 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres0A5, "Debe indicar el numero de miembros mujeres (0 a 5 años).")
                Me.txtMiembrosMujeres0A5.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosMujeres0A5.Text) >= 0 And Val(txtMiembrosMujeres0A5.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros mujeres (0 a 5 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres0A5, "Debe indicar el numero de miembros mujeres(0 5 años) Entre . 0 a 99")
                Me.txtMiembrosMujeres0A5.Focus()
                Exit Function
            End If





            If Not IsNumeric(txtMiembrosMujeres6A12.Text) Then
                MsgBox("Debe indicar el numero de miembros mujeres 6 a 12 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres6A12, "Debe indicar el numero de miembros mujeres (6 a 12 años).")
                Me.txtMiembrosMujeres6A12.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosMujeres6A12.Text) >= 0 And Val(txtMiembrosMujeres6A12.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros mujeres (6 a 12 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres6A12, "Debe indicar el numero de miembros mujeres(6 12 años) Entre . 0 a 99")
                Me.txtMiembrosMujeres6A12.Focus()
                Exit Function
            End If








            If Not IsNumeric(txtMiembrosMujeres13A18.Text) Then
                MsgBox("Debe indicar el numero de miembros mujeres 13 a 18 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres13A18, "Debe indicar el numero de miembros mujeres (13 a 18 años).")
                Me.txtMiembrosMujeres13A18.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosMujeres13A18.Text) >= 0 And Val(txtMiembrosMujeres13A18.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros mujeres (13 a 18 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres13A18, "Debe indicar el numero de miembros mujeres(13 18 años) Entre . 0 a 99")
                Me.txtMiembrosMujeres13A18.Focus()
                Exit Function
            End If





            If Not IsNumeric(txtMiembrosMujeres19A60.Text) Then
                MsgBox("Debe indicar el numero de miembros mujeres 19 a 60 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres19A60, "Debe indicar el numero de miembros mujeres (19 a 60 años).")
                Me.txtMiembrosMujeres19A60.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosMujeres19A60.Text) >= 0 And Val(txtMiembrosMujeres19A60.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros mujeres (19 a 60 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres19A60, "Debe indicar el numero de miembros mujeres(19 a 60 años) Entre . 0 a 99")
                Me.txtMiembrosMujeres19A60.Focus()
                Exit Function
            End If




            If Not IsNumeric(txtMiembrosMujeres60AMas.Text) Then
                MsgBox("Debe indicar el numero de miembros mujeres 60 años a más.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres60AMas, "Debe indicar el numero de miembros mujeres 60 años a más.")
                Me.txtMiembrosMujeres60AMas.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosMujeres60AMas.Text) >= 0 And Val(txtMiembrosMujeres60AMas.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros mujeres 60 años a más .Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres60AMas, "Debe indicar el numero de miembros mujeres 60 años a más Entre . 0 a 99")
                Me.txtMiembrosMujeres60AMas.Focus()
                Exit Function
            End If










            '---------VARONES














            If Not IsNumeric(txtMiembrosHombres0A5.Text) Then
                MsgBox("Debe indicar el numero de miembros hombres 0 a 5 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres0A5, "Debe indicar el numero de miembros hombres (0 a 5 años).")
                Me.txtMiembrosHombres0A5.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosHombres0A5.Text) >= 0 And Val(txtMiembrosHombres0A5.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros hombres (0 a 5 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres0A5, "Debe indicar el numero de miembros hombres(0 5 años) Entre . 0 a 99")
                Me.txtMiembrosHombres0A5.Focus()
                Exit Function
            End If





            If Not IsNumeric(txtMiembrosHombres6A12.Text) Then
                MsgBox("Debe indicar el numero de miembros hombres 6 a 12 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres6A12, "Debe indicar el numero de miembros hombres (6 a 12 años).")
                Me.txtMiembrosHombres6A12.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosHombres6A12.Text) >= 0 And Val(txtMiembrosHombres6A12.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros hombres (6 a 12 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres6A12, "Debe indicar el numero de miembros hombres(6 12 años) Entre . 0 a 99")
                Me.txtMiembrosHombres6A12.Focus()
                Exit Function
            End If








            If Not IsNumeric(txtMiembrosHombres13A18.Text) Then
                MsgBox("Debe indicar el numero de miembros hombres 13 a 18 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres13A18, "Debe indicar el numero de miembros hombres (13 a 18 años).")
                Me.txtMiembrosHombres13A18.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosHombres13A18.Text) >= 0 And Val(txtMiembrosHombres13A18.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros Hombres (13 a 18 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres13A18, "Debe indicar el numero de miembros hombres(13 18 años) Entre . 0 a 99")
                Me.txtMiembrosHombres13A18.Focus()
                Exit Function
            End If





            If Not IsNumeric(txtMiembrosHombres19A60.Text) Then
                MsgBox("Debe indicar el numero de miembros hombres 19 a 60 años.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres19A60, "Debe indicar el numero de miembros hombres(19 a 60 años).")
                Me.txtMiembrosHombres19A60.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosHombres19A60.Text) >= 0 And Val(txtMiembrosHombres19A60.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros hombres(19 a 60 años).Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujeres19A60, "Debe indicar el numero de miembros hombres(19 a 60 años) Entre . 0 a 99")
                Me.txtMiembrosHombres19A60.Focus()
                Exit Function
            End If




            If Not IsNumeric(txtMiembrosHombres60AMas.Text) Then
                MsgBox("Debe indicar el numero de miembros hombres 60 años a más.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres60AMas, "Debe indicar el numero de miembros hombres 60 años a más.")
                Me.txtMiembrosHombres60AMas.Focus()
                Exit Function
            End If



            If Not (Val(txtMiembrosHombres60AMas.Text) >= 0 And Val(txtMiembrosHombres60AMas.Text) <= 99) Then
                MsgBox("Debe indicar el numero de miembros hombres 60 años a más .Entre 0 a 99 ", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres60AMas, "Debe indicar el numero de miembros hombres 60 años a más Entre . 0 a 99")
                Me.txtMiembrosHombres60AMas.Focus()
                Exit Function
            End If





            '-------VAlidar que las suma de miembros sea la correcta

            If (Val(txtMiembrosMujer.Text) + Val(txtMiembrosHombres.Text)) <> Val(txtMiembros.Text) Then
                MsgBox("Sumatoria de miembros mujeres y hombres no concuerda con el total indicado de miembros.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembros, "Sumatoria de miembros mujeres y hombres no concuerda con el total indicado de miembros.")
                Me.txtMiembros.Focus()
                Exit Function
            End If



            If (Val(txtMiembrosMujeres0A5.Text) + Val(txtMiembrosMujeres6A12.Text) + Val(txtMiembrosMujeres13A18.Text) + Val(txtMiembrosMujeres19A60.Text) + Val(txtMiembrosMujeres60AMas.Text)) <> Val(txtMiembrosMujer.Text) Then
                MsgBox("Sumatoria de miembros mujeres no concuerda con el total indicado por grupos de edades.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosMujer, "Sumatoria de miembros mujeres no concuerda con el total indicado por grupos de edades.")
                Me.txtMiembrosMujer.Focus()
                Exit Function
            End If




            If (Val(txtMiembrosHombres0A5.Text) + Val(txtMiembrosHombres6A12.Text) + Val(txtMiembrosHombres13A18.Text) + Val(txtMiembrosHombres19A60.Text) + Val(txtMiembrosHombres60AMas.Text)) <> Val(txtMiembrosHombres.Text) Then
                MsgBox("Sumatoria de miembros hombres no concuerda con el total indicado por grupos de edades.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.txtMiembrosHombres, "Sumatoria de miembros hombres no concuerda con el total indicado por grupos de edades.")
                Me.txtMiembrosHombres.Focus()
                Exit Function
            End If




            If RadPropia.Checked = False And RadAlquilada.Checked = False And RadPosando.Checked = False Then
                MsgBox("Debe indicar si la casa que habita es propia,alquilada,posando", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpCasa, "Debe indicar si la casa que habita es propia,alquilada,posando")
                Me.GrpCasa.Focus()
                Exit Function
            End If




            If RadSi.Checked = False And RadNo.Checked = False And RadEnTramite.Checked = False Then
                MsgBox("Debe indicar si la casa tiene titulo de propiedad.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpPropia, "Debe indicar si la casa tiene titulo de propiedad.")
                Me.GrpPropia.Focus()
                Exit Function
            End If


            If RadHumilde.Checked = False And RadComoda.Checked = False And RadLujosa.Checked = False Then
                MsgBox("Debe indicar como se considera la casa que habita.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.GrpSituacion, "Debe indicar como se considera la casa que habita.")
                Me.GrpSituacion.Focus()
                Exit Function
            End If

            If cboCajero.SelectedIndex = -1 Then
                MsgBox("Debe indicar el Auditor Nacional.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cboCajero, "Debe indicar el Auditor Nacional.")
                Me.cboCajero.Focus()
                Exit Function
            End If

            If IsDBNull(Me.cdeFechaRegistro.Value) Then
                MsgBox("Debe indicar la fecha de registro.", MsgBoxStyle.Critical, NombreSistema)
                ValidaDatosEntrada = False
                Me.errSocia.SetError(Me.cdeFechaRegistro, "Debe indicar la fecha de registro.")
                Me.cdeFechaRegistro.Focus()
                Exit Function
            End If








        Catch ex As Exception
            ValidaDatosEntrada = False
            Control_Error(ex)
        Finally
            ObjTmpSocia.Close()
            ObjTmpSocia = Nothing

            ObjSclGS.Close()
            ObjSclGS = Nothing
        End Try
    End Function


    Private Sub SalvarFicha()
        Dim XcDatos As New BOSistema.Win.XComando
        Try
            Dim strSQL As String
            Dim dFechaRegistro As Date
            Dim intSociaTmpID As Integer
            Dim CasaHabita As Integer
            Dim CasaPropia As Integer
            Dim CasaConsidera As Integer


            dFechaRegistro = Me.cdeFechaRegistro.Value


            If RadPropia.Checked Then
                CasaHabita = 1
            Else
                If RadAlquilada.Checked Then
                    CasaHabita = 2
                Else
                    If RadPosando.Checked Then
                        CasaHabita = 3
                    End If
                End If

            End If



            If RadSi.Checked Then
                CasaPropia = 1
            Else
                If RadNo.Checked Then
                    CasaPropia = 2
                Else
                    If RadEnTramite.Checked Then
                        CasaPropia = 3
                    End If
                End If

            End If


            If RadHumilde.Checked Then
                CasaConsidera = 1
            Else
                If RadComoda.Checked Then
                    CasaConsidera = 2
                Else
                    If RadLujosa.Checked Then
                        CasaConsidera = 3
                    End If
                End If

            End If



            'If ModoFrm = "ACR" Then
            '    strSQL = " EXEC spSccAnularReciboConRegeneracion " & Me.IdSccReciboOficialCaja & "," & Me.IdSccSolicitudCheque & "," & Me.txtNumRecibo.Text & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & XdsRecibo("Representante").ValueField("nSrhEmpleadoID") & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta & ",'" & Me.sMotivoAnulacion & "'"
            'Else
            'strSQL = " EXEC spSclGrabarFichaUnica '" & Me.ModoFrm & "',"    & Me.IdSccSolicitudCheque & "," & Me.txtNumRecibo.Text & ",'" & Format(dFechaRecibo.Date, "yyyy-MM-dd") & "'," & Me.cneValor.Value & ",'" & Me.txtConcepto.Text & "'," & XdsRecibo("Representante").ValueField("nSrhEmpleadoID") & "," & IdMinutaDeposito & ",'" & Me.ModoFrm & "'," & InfoSistema.IDCuenta & "," & Me.IdEspecial & "," & IdCaja & "," & nCodigoTalonario
            strSQL = " EXEC spSclGrabarFichaUnicaHogar '" & Me.ModoFrm & "'," & Me.IdSocia & "," & Me.cboBarrio.Columns("nStbBarrioID").Value & ",'" & Trim(Me.txtDireccion.Text) & "','" & Trim(txtTelefono.Text) & "','" & Trim(txtmovil.Text) & "'," & _
                      Val(txtMiembros.Text) & "," & Val(txtMiembrosMujer.Text) & "," & Val(txtMiembrosHombres.Text) & "," & Val(txtMiembrosMujeres0A5.Text) & "," & Val(txtMiembrosMujeres6A12.Text) & "," & Val(txtMiembrosMujeres13A18.Text) & "," & Val(txtMiembrosMujeres19A60.Text) & "," & Val(txtMiembrosMujeres60AMas.Text) & "," & _
                      Val(txtMiembrosHombres0A5.Text) & "," & Val(txtMiembrosHombres6A12.Text) & "," & Val(txtMiembrosHombres13A18.Text) & "," & Val(txtMiembrosHombres19A60.Text) & "," & Val(txtMiembrosHombres60AMas.Text) & "," & _
                       CasaHabita & "," & CasaPropia & "," & CasaConsidera & ",'" & Trim(TxtNombreGFCV.Text) & "','" & Trim(TxtCargoGFCV.Text) & "','" & Trim(TxtTelefonoGFCV.Text) & "'," & Me.cboCajero.Columns("nSrhEmpleadoID").Value & ",'" & Format(Me.cdeFechaRegistro.Value, "yyyy-MM-dd") & "','" & InfoSistema.LoginName & "'"
            'End If

            'Asignar el Id de la Socia a la variable publica del formulario
            intSociaTmpID = XcDatos.ExecuteScalar(strSQL)
            'Me.IdSccReciboOficialCaja = XcDatos.ExecuteScalar(strSQL)
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If intSociaTmpID = 0 Then
                MsgBox("Los datos no pudieron grabarse.", MsgBoxStyle.Information, "SMUSURA0")

            Else
                tbSocia.Enabled = True
                If ModoFrm = "ADD" Then


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
                SalvarFicha()
                AccionUsuario = AccionBoton.BotonAceptar
                cmdAceptar.Enabled = False
                cmdCancelar.Enabled = False
                cmdModificar.Enabled = True
                tbSocia.Enabled = True
                grpLocalizacion.Enabled = False
                grpHogar.Enabled = False
                Seguridad()
                'Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub TxtTelefonoGFCV_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TxtTelefonoGFCV.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtTelefono_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTelefono.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtmovil_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmovil.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) And UCase(e.KeyChar) <> "(" And UCase(e.KeyChar) <> ")" And UCase(e.KeyChar) <> "-" And UCase(e.KeyChar) <> "," Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembros_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembros.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosMujer_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosMujer.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosHombres_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosHombres.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosMujeres0A5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosMujeres0A5.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosMujeres6A12_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosMujeres6A12.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosMujeres13A18_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosMujeres13A18.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosMujeres19A60_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosMujeres19A60.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosMujeres60AMas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosMujeres60AMas.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosHombres0A5_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosHombres0A5.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosHombres6A12_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosHombres6A12.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosHombres13A18_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosHombres13A18.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosHombres19A60_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosHombres19A60.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub txtMiembrosHombres60AMas_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMiembrosHombres60AMas.KeyPress
        Try
            If (UCase(e.KeyChar) < "0" Or UCase(e.KeyChar) > "9") And e.KeyChar <> Convert.ToChar(Keys.Back) And e.KeyChar <> Convert.ToChar(Keys.Space) Then
                e.Handled = True
                SendKeys.Send("")
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarPersonas()
        Try

            'Asignar Qry al Xdt:
            Dim Strsql As String
            'If IntPermiteConsultar = 1 Then 'Puede visualizar todas las Delegaciones del Programa. '" Where NombreSocia Like '" & sCadenaFiltro & "'" & _
            Strsql = "SELECT   Desparentesco, nSclSociaID, nSclFichaUnicaPersonaID, nSclFichaUnicaID, nCodigo, nStbParentescoID, sNombre1, sNombre2, sApellido1, sApellido2, dFechaNacimiento,sNumeroCedula, nEdad, DesPrimaria, DesSecundaria, DesTecnico, nAlfabetizada,  sOtrosEstudios,      CASE WHEN nSexo = 1 THEN 'H' WHEN nSexo = 2 THEN 'M' END AS Sexo, CASE WHEN nInscrito = 1 THEN 'S' WHEN nInscrito = 2 THEN 'N' END AS Inscrito, CASE WHEN nVacunas = 1 THEN 'S' WHEN nVacunas = 2 THEN 'N' END AS Vacunas, CASE WHEN nControlPrenatal = 1 THEN 'S' WHEN nControlPrenatal = 2 THEN 'N' WHEN nControlPrenatal = 3 THEN 'N/A'  END AS ControlPrenatal, CASE WHEN nMatricula = 1 THEN 'S' WHEN nMatricula = 2 THEN 'N' WHEN nMatricula = 3 THEN 'N/A' END AS Matricula FROM         dbo.vwSclFichaUnicaPersona     WHERE     (nSclSociaID = " & Me.IdSocia & ")"


            'Else    'Solo Filtra las Socias de su Delegación:
            'Strsql = " Select * From vwSclSocia " & sCadenaFiltro & _
            '         " and (nStbDelegacionProgramaID = " & InfoSistema.IDDelegacion & ")" & _
            '         " Order by vwSclSocia.nCodigo"
            'End If
            XdtPersonas.ExecuteSql(Strsql)

            'Asignando a las fuentes de datos al Grid:
            Me.grdPersonas.DataSource = XdtPersonas.Source

            'Actualizando el caption del GRID:
            Me.grdPersonas.Caption = " Listado de Personsas (" + Me.grdPersonas.RowCount.ToString + " registros)"











            Me.grdPersonas.Splits(0).DisplayColumns("nSclSociaID").Visible = False
            Me.grdPersonas.Splits(0).DisplayColumns("nSclFichaUnicaID").Visible = False
            Me.grdPersonas.Splits(0).DisplayColumns("nSclFichaUnicaPersonaID").Visible = False
            Me.grdPersonas.Splits(0).DisplayColumns("nStbParentescoID").Visible = False
            'Me.grdPersonas.Splits(0).DisplayColumns("nStbPrimariaID").Visible = False
            'Me.grdPersonas.Splits(0).DisplayColumns("nStbSecundariaID").Visible = False
            'Me.grdPersonas.Splits(0).DisplayColumns("nStbCarreraTecnicaID").Visible = False


            'Establecer ancho de columnas visibles al usuario:
            Me.grdPersonas.Splits(0).DisplayColumns("Desparentesco").Width = 60
            Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Width = 40
            Me.grdPersonas.Splits(0).DisplayColumns("sNombre1").Width = 80
            Me.grdPersonas.Splits(0).DisplayColumns("sNombre2").Width = 80
            Me.grdPersonas.Splits(0).DisplayColumns("sApellido1").Width = 80
            Me.grdPersonas.Splits(0).DisplayColumns("sApellido2").Width = 80
            Me.grdPersonas.Splits(0).DisplayColumns("dFechaNacimiento").Width = 80
            Me.grdPersonas.Splits(0).DisplayColumns("sNumeroCedula").Width = 100



            Me.grdPersonas.Splits(0).DisplayColumns("nEdad").Width = 50
            Me.grdPersonas.Splits(0).DisplayColumns("DesPrimaria").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("DesSecundaria").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("DesTecnico").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("nAlfabetizada").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("sOtrosEstudios").Width = 100


            'CASE WHEN nSexo = 1 THEN 'H' WHEN nSexo = 2 THEN 'M' END AS Sexo, CASE WHEN nInscrito = 1 THEN 'S' WHEN nInscrito = 2 THEN 'N' END AS Inscrito, CASE WHEN nVacunas = 1 THEN 'S' WHEN nVacunas = 2 THEN 'N' END AS Vacunas, CASE WHEN nControlPrenatal = 1 THEN 'S' WHEN nControlPrenatal = 2 THEN 'N' END AS ControlPrenatal, CASE WHEN nMatricula = 1 THEN 'S' WHEN nMatricula = 2 THEN 'N' END AS Matricula 


            Me.grdPersonas.Splits(0).DisplayColumns("Sexo").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("Inscrito").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("Vacunas").Width = 70
            Me.grdPersonas.Splits(0).DisplayColumns("ControlPrenatal").Width = 70


            Me.grdPersonas.Splits(0).DisplayColumns("Matricula").Width = 70
      






            'Ubicar Nombre de los Campos:
            Me.grdPersonas.Columns("Desparentesco").Caption = "Parentesco"
            Me.grdPersonas.Columns("nCodigo").Caption = "No "
            Me.grdPersonas.Columns("sNombre1").Caption = "1er Nombre"
            Me.grdPersonas.Columns("sNombre2").Caption = "2do Nombre"
            Me.grdPersonas.Columns("sApellido1").Caption = "1er Apellido"
            Me.grdPersonas.Columns("sApellido2").Caption = "2do Apellido"
            Me.grdPersonas.Columns("dFechaNacimiento").Caption = "Fecha Nac."
            Me.grdPersonas.Columns("sNumeroCedula").Caption = "Cédula"
            Me.grdPersonas.Columns("nEdad").Caption = "Edad"
            Me.grdPersonas.Columns("DesPrimaria").Caption = "Primaria"
            Me.grdPersonas.Columns("DesSecundaria").Caption = "Secundaria"
            Me.grdPersonas.Columns("DesTecnico").Caption = "Tecnico"
            Me.grdPersonas.Columns("nAlfabetizada").Caption = "Alfabetizada"
            Me.grdPersonas.Columns("sOtrosEstudios").Caption = "Otros Estudios"
            Me.grdPersonas.Columns("Sexo").Caption = "Sexo"
            Me.grdPersonas.Columns("Inscrito").Caption = "Inscrito"
            Me.grdPersonas.Columns("Vacunas").Caption = "Vacunas"
            Me.grdPersonas.Columns("ControlPrenatal").Caption = "Control Pren."
            Me.grdPersonas.Columns("Matricula").Caption = "Matricula"




           
            Me.grdPersonas.Columns("nAlfabetizada").ValueItems.Presentation = C1.Win.C1TrueDBGrid.PresentationEnum.CheckBox
      

            'Alineación:
            Me.grdPersonas.Splits(0).DisplayColumns("Desparentesco").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sNombre1").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sNombre2").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sApellido1").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sApellido2").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("dFechaNacimiento").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("nEdad").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("DesPrimaria").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("DesSecundaria").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("DesTecnico").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("nAlfabetizada").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sOtrosEstudios").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Sexo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Inscrito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Vacunas").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("ControlPrenatal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Matricula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center







            Me.grdPersonas.Splits(0).DisplayColumns("Desparentesco").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("nCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sNombre1").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sApellido1").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sApellido2").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("dFechaNacimiento").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sNumeroCedula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("nEdad").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("DesPrimaria").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("DesSecundaria").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("DesTecnico").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("nAlfabetizada").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("sOtrosEstudios").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Sexo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Inscrito").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Vacunas").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("ControlPrenatal").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.grdPersonas.Splits(0).DisplayColumns("Matricula").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center













        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub Seguridad()
        Try
            Seg.RefreshPermissions()

            'Buscar:
            If Seg.HasPermission("ModificarHogarFichaUnica") = False Then
                Me.cmdModificar.Enabled = False
            Else  'Habilita
                Me.cmdModificar.Enabled = True
            End If

            'Agregar:
            If Seg.HasPermission("AgregarPersonaFichaUnica") = False Then
                Me.tbSocia.Items("toolAgregar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolAgregar").Enabled = True
            End If

            'Editar:
            If Seg.HasPermission("ModificarPersonaFichaUnica") = False Then
                Me.tbSocia.Items("toolModificar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolModificar").Enabled = True
            End If

            'Inactivar:
            If Seg.HasPermission("EliminarPersonaFichaUnica") = False Then
                Me.tbSocia.Items("toolEliminar").Enabled = False
            Else  'Habilita
                Me.tbSocia.Items("toolEliminar").Enabled = True
            End If

            







        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub LlamaMantenimientoPersona()
        Dim ObjfrmSclEditFichaUnicaPersona As New frmSclEditFichaUnicaPersona
        Try
            'Si no hay registros ingresados salir del Sub:
            If Me.grdPersonas.RowCount = 0 And ModoPersona = "UPD" Then
                MsgBox("No Existen registros de personas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If Me.grdPersonas.RowCount >= Val(Me.txtMiembros.Text) And ModoPersona = "ADD" Then
                MsgBox("No se puede agregar más personas. Modifique la cantidad de miembros del hogar.", MsgBoxStyle.Information)
                Me.errSocia.SetError(Me.txtMiembros, "No se puede agregar más personas. Modifique la cantidad de miembros del hogar.")
                Me.txtMiembros.Focus()
                Exit Sub
            End If


            'Indicador de Actualización:
            ObjfrmSclEditFichaUnicaPersona.ModoFrm = ModoPersona
            'Se indica llave principal:
            If ModoPersona = "UPD" Then
                ObjfrmSclEditFichaUnicaPersona.IdPersona = XdtPersonas.ValueField("nSclFichaUnicaPersonaID")

            End If
            ObjfrmSclEditFichaUnicaPersona.IdSocia = Me.IdSocia
            'Se muestra en formulario de edición:
            ObjfrmSclEditFichaUnicaPersona.ShowDialog()
            'Refresca las modificaciones realizadas en el Grid.
            'CargarSocia(StrCadena)
            CargarPersonas()
            If ModoPersona = "UPD" Then
                'Y se posiciona sobre el registro modificado.
                XdtPersonas.SetCurrentByID("nSclFichaUnicaPersonaID", ObjfrmSclEditFichaUnicaPersona.IdPersona)
                'Refresca posicionamiento del Grid:
                Me.grdPersonas.Row = XdtPersonas.BindingSource.Position
            End If
        Catch ex As Exception
            Control_Error(ex)
        Finally
            'Cierra el objeto form:
            ObjfrmSclEditFichaUnicaPersona.Close()
            ObjfrmSclEditFichaUnicaPersona = Nothing
        End Try
    End Sub
    Private Sub LlamaEliminar()
        Dim XdtCat As New BOSistema.Win.XDataSet.xDataTable

        Try
            'Si no hay registros ingresados salir del Sub:
            If Me.grdPersonas.RowCount = 0 Then
                MsgBox("No Existen registros de personas.", MsgBoxStyle.Information)
                Exit Sub
            End If

            If XdtPersonas.ValueField("nCodigo") = 1 Then
                MsgBox("No se puede Eliminar al Jefe(a).", MsgBoxStyle.Information)
                Exit Sub
            End If
            XdtCat.ExecuteSql("SELECT     TOP (1) dbo.SclFichaUnicaPersona.nCodigo  FROM         dbo.SclFichaUnicaPersona INNER JOIN   dbo.SclFichaUnicaHogar ON dbo.SclFichaUnicaPersona.nSclFichaUnicaID = dbo.SclFichaUnicaHogar.nSclFichaUnicaID AND  dbo.SclFichaUnicaPersona.nSclFichaUnicaID = dbo.SclFichaUnicaHogar.nSclFichaUnicaID WHERE     (dbo.SclFichaUnicaHogar.nSclSociaID = " & Me.IdSocia & " ) ORDER BY dbo.SclFichaUnicaPersona.nCodigo DESC")

            If XdtCat.Count > 0 Then
                If XdtCat.ValueField("nCodigo") <> XdtPersonas.ValueField("nCodigo") Then
                    MsgBox("Solo se puede eliminar a partir del último.", MsgBoxStyle.Information)
                    Exit Sub
                End If
            End If

            If MsgBox("¿Está seguro de eliminar la persona del hogar?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "SMUSURA0") = MsgBoxResult.Yes Then

                XdtCat.ExecuteSqlNotTable("Delete From SclFichaUnicaPersona  where nSclFichaUnicaPersonaID=" & XdtPersonas.ValueField("nSclFichaUnicaPersonaID"))
                CargarPersonas()

                MsgBox("El registro se eliminó satisfactoriamente.", MsgBoxStyle.Information)
            End If

        Catch ex As Exception
            MsgBox("El registro no se pudo eliminar porque tiene datos relacionados.", MsgBoxStyle.Critical, NombreSistema)
            'Control_Error(ex)
        Finally
            XdtCat.Close()
            XdtCat = Nothing
        End Try
    End Sub
    Private Sub tbSocia_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles tbSocia.ItemClicked
        Try

        
            Select Case e.ClickedItem.Name

                Case "toolAgregar"
                    ModoPersona = "ADD"
                    LlamaMantenimientoPersona()

                Case "toolModificar"
                    ModoPersona = "UPD"
                    LlamaMantenimientoPersona()
                Case "toolEliminar"

                    LlamaEliminar()
            End Select
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdModificar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModificar.Click
        Try
            cmdAceptar.Enabled = True
            cmdCancelar.Enabled = True
            cmdModificar.Enabled = False
            tbSocia.Enabled = False
            grpLocalizacion.Enabled = True
            grpHogar.Enabled = True
        Catch ex As Exception
            Control_Error(ex)
        End Try

    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            cmdAceptar.Enabled = False
            cmdCancelar.Enabled = False
            cmdModificar.Enabled = True
            tbSocia.Enabled = True
            grpLocalizacion.Enabled = False
            grpHogar.Enabled = False
            If Me.ModoFrm = "ADD" Then
                Me.Close()
            Else
                CargarInfoFichaUnica()
            End If
            Seguridad()
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSalir.Click
        Try
        
            Me.Close()
          
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

End Class