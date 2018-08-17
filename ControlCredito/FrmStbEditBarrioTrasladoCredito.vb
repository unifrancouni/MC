' ------------------------------------------------------------------------
' Autor:                Gamaliel Mejia
' Fecha:                14/02/2011
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbEditBarrioTrasladoCredito.vb
' Descripción:          Este formulario hacer el traslado de los creditos
'                       de un barrio a otro.
'-------------------------------------------------------------------------

Public Class FrmStbEditBarrioTrasladoCredito


    Dim ModoForm As String
    Dim intBarrioID As Integer
    Dim blnModificar As Boolean = True

    '-- Clases para procesar la informacion de los combos
    Dim XdsBarrio As BOSistema.Win.XDataSet

    '-- Crear un data table de tipo Xdataset
    Dim ObjBarriodt As BOSistema.Win.StbEntUbicacionGeografica.StbBarrioDataTable
    Dim ObjBarriodr As BOSistema.Win.StbEntUbicacionGeografica.StbBarrioRow

    'Enumerado para controlar las acciones sobre el Formulario
    Public Enum AccionBoton
        BotonAceptar = 1
        BotonCancelar = 2
        BotonNinguno = 3
    End Enum

    Public AccionUsuario As AccionBoton
    Dim vbModifico As Boolean

    'Propiedad utilizada para el identificar si el formulario se utiliza para 
    'Agregar o bien Modificar los datos de la Ficha.
    Public Property ModoFrm() As String
        Get
            ModoFrm = ModoForm
        End Get
        Set(ByVal value As String)
            ModoForm = value
        End Set
    End Property

    'Propiedad utilizada para obtener el ID del barrio que corresponde al campo
    'StbBarrioID de la tabla StbBarrio.
    Public Property intStbBarrioID() As Long
        Get
            intStbBarrioID = intBarrioID
        End Get
        Set(ByVal value As Long)
            intBarrioID = value
        End Set
    End Property


    Private Sub FrmStbEditBarrioTrasladoCredito_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Try
            If AccionUsuario <> AccionBoton.BotonNinguno Then
                XdsBarrio.Close()
                XdsBarrio = Nothing

                ObjBarriodt.Close()
                ObjBarriodt = Nothing

                ObjBarriodr.Close()
                ObjBarriodr = Nothing
            Else
                e.Cancel = True
                'Regresar la accion del Usuario al estado Inicial
                AccionUsuario = AccionBoton.BotonCancelar
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub FrmStbEditBarrioTrasladoCredito_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim ObjGUI As New GUI.ClsGUI
        Try
            ObjGUI.AppPath = Application.StartupPath
            ObjGUI.SetFormLayout(Me, "Morado")

            '-- Ruta de Archivo de Ayuda:
            Me.HelpProvider.HelpNamespace = MyHelpNameSpace

            InicializarVariables()
            CargarDepartamento()

            'Si el formulario está en modo edición
            'cargar los datos del barrio.
            If ModoFrm = "MOV" Then
                CargarDatosBarrio()
                'ObtenerSiModifica()
                'PresentacionControles()
                'Me.txtCodigo.Enabled = False
                'If Me.chkActivo.Checked = False Then
                '    Me.chkActivo.Select()
                'Else
                '    Me.txtNombreBarrio.Select()
                'End If
            Else
                Me.txtCodigo.Select()
            End If
            Me.cboDepartamento.Enabled = False
            Me.cboMunicipio.Enabled = False
            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "MOV" Then
                Me.Text = "Hacer Traslado de Barrio"
                'Me.chkIncluidoPrograma.Checked = True
                'Me.chkActivo.Checked = True
                'Me.chkActivo.Enabled = False
            Else
                Me.Text = "Deshacer Traslado de Barrio"
                'Me.chkActivo.Enabled = True
            End If

            ObjBarriodt = New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioDataTable
            ObjBarriodr = New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioRow
            XdsBarrio = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()

            If ModoFrm = "MOV" Then

                ObjBarriodr = ObjBarriodt.NewRow

                'Inicializar los Length de los campos
                Me.txtNombreBarrio.MaxLength = ObjBarriodr.GetColumnLenght("sNombre")
                Me.txtCodigo.MaxLength = ObjBarriodr.GetColumnLenght("sCodigo")

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    '**************************************************************************    
    '* Cargar la lista de Barrios existente para un filtro de municipios 
    '**************************************************************************

    Private Sub CargarBarrio(ByVal intLimpiarID As Integer)
        Try
            Dim Strsql As String
            Dim CadWhere As String '' Cadena para el filtro por todos o  departamento y o municipio

            Me.cboBarrio.ClearFields()
            CadWhere = ""
            If Me.cboDepartamento.SelectedIndex > 0 Then
                CadWhere = " Where  dbo.StbDepartamento.nStbDepartamentoID=" & Me.cboDepartamento.Columns("nStbDepartamentoID").Value
            End If
            If Me.cboMunicipio.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbMunicipio.nStbMunicipioID=" & Me.cboMunicipio.Columns("nStbMunicipioID").Value
            End If
            If Me.cboDistrito.SelectedIndex > 0 Then
                CadWhere = CadWhere & " And dbo.StbBarrio.nStbDistritoID=" & Me.cboDistrito.Columns("nStbDistritoID").Value
            End If

            If intLimpiarID = 0 Then
                Strsql = " Select dbo.StbBarrio.nActivo,dbo.StbBarrio.nPertenecePrograma, dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre as Descripcion,1 as Orden " & _
                             " FROM         dbo.StbBarrio INNER JOIN" & _
                             " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                             "  dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " & _
                             CadWhere & " Order by dbo.StbBarrio.sCodigo"
            Else
                Strsql = " Select dbo.StbBarrio.nActivo,dbo.StbBarrio.nPertenecePrograma,dbo.StbBarrio.nStbBarrioID,dbo.StbBarrio.sCodigo,dbo.StbBarrio.sNombre as Descripcion,1 as Orden " & _
                             " FROM     dbo.StbBarrio INNER JOIN" & _
                             " dbo.StbMunicipio ON dbo.StbBarrio.nStbMunicipioID = dbo.StbMunicipio.nStbMunicipioID INNER JOIN " & _
                             "  dbo.StbDepartamento ON dbo.StbMunicipio.nStbDepartamentoID = dbo.StbDepartamento.nStbDepartamentoID  " & _
                            " Where dbo.StbBarrio.nStbBarrioID = 0" & _
                         " Order by dbo.StbBarrio.sCodigo"
            End If

            If XdsBarrio.ExistTable("Barrio") Then
                XdsBarrio("Barrio").ExecuteSql(Strsql)
            Else
                XdsBarrio.NewTable(Strsql, "Barrio")
                XdsBarrio("Barrio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboBarrio.DataSource = XdsBarrio("Barrio").Source
            Me.cboBarrio.Rebind()

            Me.cboBarrio.Splits(0).DisplayColumns("nStbBarrioID").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("Orden").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nActivo").Visible = False
            Me.cboBarrio.Splits(0).DisplayColumns("nPertenecePrograma").Visible = False

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboBarrio.Columns("sCodigo").Caption = "Código"
            Me.cboBarrio.Columns("Descripcion").Caption = "Descripción"

            Me.cboBarrio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboBarrio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Ubicarlo en el primer registro
            'If Me.cboBarrio.ListCount > 0 Then
            '    XdsBarrio("Barrio").AddRow()
            '    XdsBarrio("Barrio").ValueField("Descripcion") = "Todos"
            '    XdsBarrio("Barrio").ValueField("nStbDistritoID") = -19
            '    XdsBarrio("Barrio").ValueField("Orden") = 0
            '    XdsBarrio("Barrio").UpdateLocal()
            '    XdsBarrio("Barrio").Sort = "Orden,sCodigo asc"
            '    Me.cboBarrio.SelectedIndex = 0
            'End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub CargarDatosBarrio()
        Dim ObjUbicacionDT As New BOSistema.Win.XDataSet.xDataTable
        Try
            Dim strSQL As String = ""

            '-- Buscar el Barrio correspondiente al Id especificado
            '-- como parámetro, en los casos que se esté editando una.
            ObjBarriodt.Filter = "nStbBarrioID = " & Me.intBarrioID
            ObjBarriodt.Retrieve()
            If ObjBarriodt.Count = 0 Then
                Exit Sub
            End If
            ObjBarriodr = ObjBarriodt.Current

            'Código 
            If Not ObjBarriodr.IsFieldNull("sCodigo") Then
                Me.txtCodigo.Text = ObjBarriodr.sCodigo
                Me.txtCodigoInicial.Text = ObjBarriodr.sCodigo

            Else
                Me.txtCodigo.Text = ""
            End If

            'Socia
            strSQL = " Select a.nStbMunicipioID,a.nStbDepartamentoID," & _
                     " a.nStbDistritoID,a.nStbBarrioID" & _
                     " From vwStbUbicacionBarrio a " & _
                     " Where a.nStbBarrioID = " & ObjBarriodr.nStbBarrioID

            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then

                XdsBarrio("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))
                Me.txtNombreDepartamento.Text = Me.cboDepartamento.Text
                If Not ObjUbicacionDT.ValueField("nStbMunicipioID") Is DBNull.Value Then
                    CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    If Me.cboMunicipio.ListCount > 0 Then
                        Me.cboMunicipio.SelectedIndex = 0
                        XdsBarrio("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                        Me.txtNombreMunicipio.Text = Me.cboMunicipio.Text
                    End If

                    If Not ObjUbicacionDT.ValueField("nStbDistritoID") Is DBNull.Value Then
                        CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                        If Me.cboDistrito.ListCount > 0 Then
                            Me.cboDistrito.SelectedIndex = 0
                            XdsBarrio("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                            Me.txtNombreDistrito.Text = Me.cboDistrito.Text
                            If Not ObjUbicacionDT.ValueField("nStbDistritoID") Is DBNull.Value Then

                                XdsBarrio("Barrio").SetCurrentByID("nStbBarrioID", ObjUbicacionDT.ValueField("nStbBarrioID"))
                            End If
                            
                        End If
                    End If
                End If
            End If

            'Descripción
            If Not ObjBarriodr.IsFieldNull("sNombre") Then
                Me.txtNombreBarrio.Text = ObjBarriodr.sNombre
            Else
                Me.txtNombreBarrio.Text = ""
            End If

            'Incluido Programa
            If Not ObjBarriodr.IsFieldNull("nPertenecePrograma") Then
                Me.chkIncluidoPrograma.Checked = ObjBarriodr.nPertenecePrograma
                Me.chkIncluidoProgramaInicial.Checked = ObjBarriodr.nPertenecePrograma
            End If

            'Activo
            If Not ObjBarriodr.IsFieldNull("nActivo") Then
                Me.chkActivo.Checked = ObjBarriodr.nActivo
                Me.chkActivoInicial.Checked = ObjBarriodr.nActivo
                If Me.chkActivo.Checked = False Then
                    Me.txtCodigo.Enabled = False
                    Me.txtNombreBarrio.Enabled = False
                    Me.cboDepartamento.Enabled = False
                    Me.cboMunicipio.Enabled = False
                    Me.cboDistrito.Enabled = False
                    Me.chkIncluidoPrograma.Enabled = False
                    Me.chkIncluidoProgramaInicial.Enabled = False

                End If
            End If

            Me.txtNombreBarrio.MaxLength = ObjBarriodr.GetColumnLenght("sNombre")
            Me.txtCodigo.MaxLength = ObjBarriodr.GetColumnLenght("sCodigo")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjUbicacionDT.Close()
            ObjUbicacionDT = Nothing
        End Try
    End Sub

    Private Sub CmdAceptar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then
                SalvarTrasladoCreditoBarrio()

                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Function ValidaDatosEntrada() As Boolean
        Dim objBarrioTmpDT As New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioDataTable
        Try
            'Dim sCodigoBarrio As String

            ValidaDatosEntrada = True
            Me.errBarrio.Clear()

            'Código
            If Trim(RTrim(Me.txtCodigo.Text)).ToString.Length = 0 Then
                MsgBox("El Código NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.txtCodigo, "El Código NO DEBE quedar vacío.")
                Me.txtCodigo.Focus()
                Exit Function
            End If

            ''Determinar duplicados en el Código del Barrio

            'sCodigoBarrio = Format(CInt(Me.txtCodigo.Text), "000")

            'If ModoFrm = "UPD" Then
            '    objBarrioTmpDT.Filter = " nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and sCodigo = '" & sCodigoBarrio & "'" & " And nStbBarrioID <> " & ObjBarriodr.nStbBarrioID
            'Else
            '    objBarrioTmpDT.Filter = " nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and sCodigo = '" & sCodigoBarrio & "'"
            'End If

            'objBarrioTmpDT.Retrieve()

            'If objBarrioTmpDT.Count > 0 Then
            '    MsgBox("El Código del Barrio NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errBarrio.SetError(Me.txtCodigo, "El Código del Barrio NO DEBE repetirse.")
            '    Me.txtCodigo.Focus()
            '    Exit Function
            'End If



            'Departamento
            If Me.cboDepartamento.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Departamento válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDepartamento, "Debe seleccionar un Departamento válido.")
                Me.cboDepartamento.Focus()
                Exit Function
            End If

            'Municipio
            If Me.cboMunicipio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Municipio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboMunicipio, "Debe seleccionar un Municipio válido.")
                Me.cboMunicipio.Focus()
                Exit Function
            End If

            'Distrito
            If Me.cboDistrito.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Distrito válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDistrito, "Debe seleccionar un Distrito válido.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            'Barrio
            If Me.cboBarrio.SelectedIndex = -1 Then
                MsgBox("Debe seleccionar un Barrio válido.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDistrito, "Debe seleccionar un Barrio válido.")
                Me.cboDistrito.Focus()
                Exit Function
            End If

            If XdsBarrio("Barrio").ValueField("nStbBarrioID") = Me.intStbBarrioID Then
                MsgBox("Debe seleccionar un Barrio destino diferente al origen.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDistrito, "Debe seleccionar un Barrio destino diferente al origen.")
                Me.cboBarrio.Focus()
                Exit Function
            End If

            If XdsBarrio("Barrio").ValueField("nPertenecePrograma") = False Then
                MsgBox("El Barrio no pertenece al programa.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDistrito, "El Barrio no pertenece al programa.")
                Me.cboBarrio.Focus()
                Exit Function
            End If
            If XdsBarrio("Barrio").ValueField("nActivo") = False Then
                MsgBox("El Barrio no esta activo.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.cboDistrito, "El Barrio no esta activo.")
                Me.cboBarrio.Focus()
                Exit Function
            End If




            'Descripción
            'If Trim(RTrim(Me.txtNombreBarrio.Text)).ToString.Length = 0 Then
            '    MsgBox("El Nombre del Barrio NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errBarrio.SetError(Me.txtNombreBarrio, "El Nombre del Barrio NO DEBE quedar vacío.")
            '    Me.txtNombreBarrio.Focus()
            '    Exit Function
            'End If

            ''Determinar duplicados en el Nombre del Barrio
            'If ModoFrm = "UPD" Then
            '    objBarrioTmpDT.Filter = " nStbDistritoID = " & XdsBarrio("Distrito").ValueField("nStbDistritoID") & " And nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and Upper(sNombre) = '" & UCase(Me.txtNombreBarrio.Text) & "'" & " And nStbBarrioID <> " & ObjBarriodr.nStbBarrioID
            'Else
            '    objBarrioTmpDT.Filter = " nStbDistritoID = " & XdsBarrio("Distrito").ValueField("nStbDistritoID") & " And nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and Upper(sNombre) = '" & UCase(Me.txtNombreBarrio.Text) & "'"
            'End If

            'objBarrioTmpDT.Retrieve()

            'If objBarrioTmpDT.Count > 0 Then
            '    MsgBox("El Nombre del Barrio NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
            '    ValidaDatosEntrada = False
            '    Me.errBarrio.SetError(Me.txtNombreBarrio, "El Nombre del Barrio NO DEBE repetirse.")
            '    Me.txtNombreBarrio.Focus()
            '    Exit Function
            'End If

        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            objBarrioTmpDT.Close()
            objBarrioTmpDT = Nothing
        End Try
    End Function

    Private Sub SalvarTrasladoCreditoBarrio()
        Dim StrSql As String
        'Dim XdtTmpBusqueda As BOSistema.Win.XDataSet.xDataTable
        Dim XcDatos As New BOSistema.Win.XComando
        Dim CodProcedimiento As Integer
        Dim UbicaOrigen As String
        Dim UbicaDestino As String
        Try
            UbicaOrigen = "Departamento:(" & Me.txtNombreDepartamento.Text.Trim() & ")Municipio:(" & Me.txtNombreMunicipio.Text.Trim() & ")Distrito:(" & Me.txtNombreDistrito.Text.Trim() & ")Barrio:(" & Me.txtNombreBarrio.Text.Trim() & ")"

            UbicaDestino = "Departamento:(" & Me.cboDepartamento.Text.Trim() & ")Municipio:(" & Me.cboMunicipio.Text.Trim() & ")Distrito:(" & Me.cboDistrito.Text.Trim() & ")Barrio:(" & Me.cboBarrio.Text.Trim() & ")"


            'Confirmar Anulación:
            If MsgBox("¿Está seguro de hacer el traslado de las fichas y datos de las socias y sus grupos ubicados en  " & UbicaOrigen.Trim() & Chr(13) & "A la nueva ubicacion de barrio en " & UbicaDestino.Trim() & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, NombreSistema) = MsgBoxResult.No Then
                Exit Sub
            End If

            StrSql = " EXEC spSccHacerTrasladoBarrioCredito  " & Me.intBarrioID & "," & XdsBarrio("Barrio").ValueField("nStbBarrioID") & "," & InfoSistema.IDCuenta
            CodProcedimiento = XcDatos.ExecuteScalar(StrSql)

            If CodProcedimiento = 1 Then
                MsgBox("Se ha hecho el traslado satisfactoriamente", MsgBoxStyle.Information)
                
            Else
                If CodProcedimiento = 0 Then
                    MsgBox("No existen Grupos ni Socias para hacer traslado desde este barrio.", MsgBoxStyle.Information)
                Else
                    MsgBox("Ocurrio un error en el procedimiento de traslado spSccHacerTrasladoBarrioCredito", MsgBoxStyle.Information)
                End If

            End If


            'If ModoFrm = "ADD" Then
            '    ObjBarriodr.sUsuarioCreacion = InfoSistema.LoginName
            '    ObjBarriodr.dFechaCreacion = FechaServer()
            'Else
            '    ObjBarriodr.sUsuarioModificacion = InfoSistema.LoginName
            '    ObjBarriodr.dFechaModificacion = FechaServer()
            'End If

            'ObjBarriodr.sCodigo = Format(CInt(Me.txtCodigo.Text), "000")
            'ObjBarriodr.sNombre = Me.txtNombreBarrio.Text
            'ObjBarriodr.nStbDistritoID = XdsBarrio("Distrito").ValueField("nStbDistritoID")
            'ObjBarriodr.nStbMunicipioID = XdsBarrio("Municipio").ValueField("nStbMunicipioID")

            'If Me.chkActivo.Checked = True Then
            '    ObjBarriodr.nActivo = 1
            'Else
            '    ObjBarriodr.nActivo = 0
            'End If

            'If Me.chkIncluidoPrograma.Checked = True Then
            '    ObjBarriodr.nPertenecePrograma = 1
            'Else
            '    ObjBarriodr.nPertenecePrograma = 0
            'End If

            'ObjBarriodr.Update()

            ''Asignar el Id del Barrio a la 
            ''variable publica del formulario
            'Me.intBarrioID = ObjBarriodr.nStbBarrioID
            ''--------------------------------

            ''Si el salvado se realizó de forma satisfactoria
            ''enviar mensaje informando y cerrar el formulario.
            'If ModoFrm = "ADD" Then
            '    MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            'Else
            '    MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            'End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cmdCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmdCancelar.Click
        Try
            'Declaracion de Variables 
            Dim res As Object

            If (vbModifico = True) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarTrasladoCreditoBarrio()
                            AccionUsuario = AccionBoton.BotonAceptar
                            Me.Close()
                        Else
                            AccionUsuario = AccionBoton.BotonNinguno
                        End If

                    Case vbNo
                        AccionUsuario = AccionBoton.BotonCancelar
                        Me.Close()

                    Case vbCancel
                        AccionUsuario = AccionBoton.BotonNinguno
                End Select
            Else
                AccionUsuario = AccionBoton.BotonCancelar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub cboDepartamento_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)


        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
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
        End If
        vbModifico = True
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    Private Sub cboDistrito_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub
#Region "Combos"

    Private Sub CargarDepartamento()
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Strsql = " Select a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                     " From StbDepartamento a " & _
                     " Order by a.sCodigo"

            If XdsBarrio.ExistTable("Departamento") Then
                XdsBarrio("Departamento").ExecuteSql(Strsql)
            Else
                XdsBarrio.NewTable(Strsql, "Departamento")
                XdsBarrio("Departamento").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDepartamento.DataSource = XdsBarrio("Departamento").Source

            XdtValorParametro.Filter = "nStbParametroID = 14"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsBarrio("Departamento").Count > 0 Then
                XdsBarrio("Departamento").SetCurrentByID("nStbDepartamentoID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboDepartamento.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDepartamento.Columns("sCodigo").Caption = "Código"
            Me.cboDepartamento.Columns("Descripcion").Caption = "Descripción"

            Me.cboDepartamento.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDepartamento.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub CargarMunicipio(ByVal intLimpiarID As Integer, ByVal intMunicipioID As Integer)
        Dim XdtValorParametro As New BOSistema.Win.StbEntCatalogo.StbValorParametroDataTable
        Try
            Dim Strsql As String

            Me.cboMunicipio.ClearFields()
            If intLimpiarID = 0 Then
                If intMunicipioID = 0 Then
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where a.nStbDepartamentoID = " & XdsBarrio("Departamento").ValueField("nStbDepartamentoID") & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbMunicipio a " & _
                             " Where (a.nStbDepartamentoID = " & XdsBarrio("Departamento").ValueField("nStbDepartamentoID") & ")" & _
                             " Or a.nStbMunicipioID = " & intMunicipioID & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbMunicipioID,a.nStbDepartamentoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbMunicipio a " & _
                         " WHERE a.nStbMunicipioID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsBarrio.ExistTable("Municipio") Then
                XdsBarrio("Municipio").ExecuteSql(Strsql)
            Else
                XdsBarrio.NewTable(Strsql, "Municipio")
                XdsBarrio("Municipio").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboMunicipio.DataSource = XdsBarrio("Municipio").Source
            Me.cboMunicipio.Rebind()

            XdtValorParametro.Filter = "nStbParametroID = 15"
            XdtValorParametro.Retrieve()

            'Ubicarse en el primer registro
            If XdsBarrio("Municipio").Count > 0 Then
                XdsBarrio("Municipio").SetCurrentByID("nStbMunicipioID", XdtValorParametro.ValueField("sValorParametro"))
            End If

            Me.cboMunicipio.Splits(0).DisplayColumns("nStbMunicipioID").Visible = False
            Me.cboMunicipio.Splits(0).DisplayColumns("nStbDepartamentoID").Visible = False

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").Width = 100

            Me.cboMunicipio.Columns("sCodigo").Caption = "Código"
            Me.cboMunicipio.Columns("Descripcion").Caption = "Descripción"

            Me.cboMunicipio.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboMunicipio.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        Finally
            XdtValorParametro.Close()
            XdtValorParametro = Nothing
        End Try
    End Sub

    Private Sub CargarDistrito(ByVal intLimpiarID As Integer, ByVal intDistritoID As Integer)
        Try
            Dim Strsql As String

            Me.cboDistrito.ClearFields()
            If intLimpiarID = 0 Then
                If intDistritoID = 0 Then
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbDistrito a " & _
                             " Order by a.sCodigo"
                Else
                    Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                             " From StbDistrito a " & _
                             " Order by a.sCodigo"
                End If
            Else
                Strsql = " Select a.nStbDistritoID,a.sCodigo,a.sNombre as Descripcion " & _
                         " From StbDistrito a " & _
                         " Where a.nStbDistritoID = 0" & _
                         " Order by a.sCodigo"
            End If

            If XdsBarrio.ExistTable("Distrito") Then
                XdsBarrio("Distrito").ExecuteSql(Strsql)
            Else
                XdsBarrio.NewTable(Strsql, "Distrito")
                XdsBarrio("Distrito").Retrieve()
            End If

            'Asignando a las fuentes de datos
            Me.cboDistrito.DataSource = XdsBarrio("Distrito").Source
            Me.cboDistrito.Rebind()

            'Ubicarse en el primer registro
            'If XdsComprobante("TipoMoneda").Count > 0 Then
            '    Me.cboTipoMoneda.SelectedIndex = 0
            'End If

            Me.cboDistrito.Splits(0).DisplayColumns("nStbDistritoID").Visible = False

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Style.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

            'Configurar el combo
            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").Width = 43
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").Width = 80

            Me.cboDistrito.Columns("sCodigo").Caption = "Código"
            Me.cboDistrito.Columns("Descripcion").Caption = "Descripción"

            Me.cboDistrito.Splits(0).DisplayColumns("sCodigo").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center
            Me.cboDistrito.Splits(0).DisplayColumns("Descripcion").HeadingStyle.HorizontalAlignment = C1.Win.C1TrueDBGrid.AlignHorzEnum.Center

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub


#End Region

    Private Sub cboDistrito_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        If Me.cboMunicipio.SelectedIndex <> -1 Then
            CargarBarrio(0)
        Else
            CargarBarrio(1)
        End If
    End Sub

    Private Sub cboBarrio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboBarrio.TextChanged
        Me.chkIncluidoPrograma.Checked = XdsBarrio("Barrio").ValueField("nPertenecePrograma")
        Me.chkActivo.Checked = XdsBarrio("Barrio").ValueField("nActivo")
        Me.txtCodigo.Text = XdsBarrio("Barrio").ValueField("sCodigo")
    End Sub

    Private Sub cboDepartamento_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDepartamento.TextChanged
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub

    Private Sub cboMunicipio_TextChanged_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboMunicipio.TextChanged
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
        End If
        vbModifico = True
    End Sub
End Class