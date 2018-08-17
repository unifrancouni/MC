' ------------------------------------------------------------------------
' Autor:                Ing. Azucena Suárez Tijerino
' Fecha:                31/08/2007
' Solution Name:        prjSMUSURA0
' Project Name:         prjSMUSURA0
' Project Item Name:    frmStbEditBarrio.vb
' Descripción:          Este formulario permite ingresar o modificar datos
'                       de una Ficha de Inscripción.
'-------------------------------------------------------------------------

Public Class frmStbEditBarrio

    '-- Declaracion de Variables 
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                31/08/2007
    ' Procedure Name:       frmStbEditBarrio_FormClosing
    ' Descripción:          Evento FormClosing del formulario donde elimino
    '                       objetos que se instanciaron de forma global al
    '                       formulario.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditBarrio_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
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

    Private Sub frmStbEditBarrio_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Leave

    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       frmStbEditBarrio_Load
    ' Descripción:          Evento Load del formulario donde inicializo variables
    '                       y cargo datos de la Ficha en caso de estar en el modo de
    '                       Modificar.
    '-------------------------------------------------------------------------
    Private Sub frmStbEditBarrio_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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
            If ModoFrm = "UPD" Then
                CargarBarrio()
                'ObtenerSiModifica()
                'PresentacionControles()
                Me.txtCodigo.Enabled = False
                If Me.chkActivo.Checked = False Then
                    Me.chkActivo.Select()
                Else
                    Me.txtDescripcion.Select()
                End If
            Else
                Me.txtCodigo.Select()
            End If

            vbModifico = False
            AccionUsuario = AccionBoton.BotonCancelar

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjGUI = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       InicializarVariables
    ' Descripción:          Este procedimiento permite Inicializar variables
    '                       y controles.
    '-------------------------------------------------------------------------
    Private Sub InicializarVariables()
        Try
            If ModoFrm = "ADD" Then
                Me.Text = "Agregar Barrio"
                Me.chkIncluidoPrograma.Checked = True
                Me.chkActivo.Checked = True
                Me.chkActivo.Enabled = False
            Else
                Me.Text = "Modificar Barrio"
                Me.chkActivo.Enabled = True
            End If

            ObjBarriodt = New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioDataTable
            ObjBarriodr = New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioRow
            XdsBarrio = New BOSistema.Win.XDataSet

            Control.CheckForIllegalCrossThreadCalls = False

            'Limpiar los combos
            Me.cboDepartamento.ClearFields()
            Me.cboMunicipio.ClearFields()
            Me.cboDistrito.ClearFields()

            If ModoFrm = "ADD" Then

                ObjBarriodr = ObjBarriodt.NewRow

                'Inicializar los Length de los campos
                Me.txtDescripcion.MaxLength = ObjBarriodr.GetColumnLenght("sNombre")
                Me.txtCodigo.MaxLength = ObjBarriodr.GetColumnLenght("sCodigo")

            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar los datos de la Ficha
    '                       seleccionado en caso de estar en el Modo de Modificar.
    '-------------------------------------------------------------------------
    Private Sub CargarBarrio()
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
            Else
                Me.txtCodigo.Text = ""
            End If

            'Socia
            strSQL = " Select a.nStbMunicipioID,a.nStbDepartamentoID," & _
                     " a.nStbDistritoID" & _
                     " From vwStbUbicacionBarrio a " & _
                     " Where a.nStbBarrioID = " & ObjBarriodr.nStbBarrioID

            ObjUbicacionDT.ExecuteSql(strSQL)
            If ObjUbicacionDT.Count > 0 Then

                XdsBarrio("Departamento").SetCurrentByID("nStbDepartamentoID", ObjUbicacionDT.ValueField("nStbDepartamentoID"))

                If Not ObjUbicacionDT.ValueField("nStbMunicipioID") Is DBNull.Value Then
                    CargarMunicipio(0, ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    If Me.cboMunicipio.ListCount > 0 Then
                        Me.cboMunicipio.SelectedIndex = 0
                        XdsBarrio("Municipio").SetCurrentByID("nStbMunicipioID", ObjUbicacionDT.ValueField("nStbMunicipioID"))
                    End If

                    If Not ObjUbicacionDT.ValueField("nStbDistritoID") Is DBNull.Value Then
                        CargarDistrito(0, ObjUbicacionDT.ValueField("nStbDistritoID"))
                        If Me.cboDistrito.ListCount > 0 Then
                            Me.cboDistrito.SelectedIndex = 0
                            XdsBarrio("Distrito").SetCurrentByID("nStbDistritoID", ObjUbicacionDT.ValueField("nStbDistritoID"))
                        End If
                    End If
                End If
            End If

            'Descripción
            If Not ObjBarriodr.IsFieldNull("sNombre") Then
                Me.txtDescripcion.Text = ObjBarriodr.sNombre
            Else
                Me.txtDescripcion.Text = ""
            End If

            'Incluido Programa
            If Not ObjBarriodr.IsFieldNull("nPertenecePrograma") Then
                Me.chkIncluidoPrograma.Checked = ObjBarriodr.nPertenecePrograma
            End If

            'Activo
            If Not ObjBarriodr.IsFieldNull("nActivo") Then
                Me.chkActivo.Checked = ObjBarriodr.nActivo
                If Me.chkActivo.Checked = False Then
                    Me.txtCodigo.Enabled = False
                    Me.txtDescripcion.Enabled = False
                    Me.cboDepartamento.Enabled = False
                    Me.cboMunicipio.Enabled = False
                    Me.cboDistrito.Enabled = False
                    Me.chkIncluidoPrograma.Enabled = False
                End If
            End If

            Me.txtDescripcion.MaxLength = ObjBarriodr.GetColumnLenght("sNombre")
            Me.txtCodigo.MaxLength = ObjBarriodr.GetColumnLenght("sCodigo")

        Catch ex As Exception
            Control_Error(ex)
        Finally
            ObjUbicacionDT.Close()
            ObjUbicacionDT = Nothing
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       CmdAceptar_click
    ' Descripción:          Este evento permite validar los datos ingresado y
    '                       luego Salvar los mismos en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub CmdAceptar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CmdAceptar.Click
        Try
            Dim strsql As String = ""

            If ValidaDatosEntrada() Then
                SalvarBarrio()

                AccionUsuario = AccionBoton.BotonAceptar
                Me.Close()
            End If
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       ValidaDatosEntrada
    ' Descripción:          Esta función permite Validar los datos ingresados y
    '                       devuelve True en caso de estar todo bien.
    '-------------------------------------------------------------------------
    Private Function ValidaDatosEntrada() As Boolean
        Dim objBarrioTmpDT As New BOSistema.Win.StbEntUbicacionGeografica.StbBarrioDataTable
        Dim XdtTmpBusqueda As BOSistema.Win.XDataSet.xDataTable
        Dim StrSql As String
        Try
            Dim sCodigoBarrio As String

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

            'Determinar duplicados en el Código del Barrio

            sCodigoBarrio = Format(CInt(Me.txtCodigo.Text), "000")

            If ModoFrm = "UPD" Then
                objBarrioTmpDT.Filter = " nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and sCodigo = '" & sCodigoBarrio & "'" & " And nStbBarrioID <> " & ObjBarriodr.nStbBarrioID
            Else
                objBarrioTmpDT.Filter = " nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and sCodigo = '" & sCodigoBarrio & "'"
            End If

            objBarrioTmpDT.Retrieve()

            If objBarrioTmpDT.Count > 0 Then
                MsgBox("El Código del Barrio NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.txtCodigo, "El Código del Barrio NO DEBE repetirse.")
                Me.txtCodigo.Focus()
                Exit Function
            End If

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

            'Descripción
            If Trim(RTrim(Me.txtDescripcion.Text)).ToString.Length = 0 Then
                MsgBox("El Nombre del Barrio NO DEBE quedar vacío.", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.txtDescripcion, "El Nombre del Barrio NO DEBE quedar vacío.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            'Determinar duplicados en el Nombre del Barrio
            If ModoFrm = "UPD" Then
                objBarrioTmpDT.Filter = " nStbDistritoID = " & XdsBarrio("Distrito").ValueField("nStbDistritoID") & " And nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and Upper(sNombre) = '" & UCase(Me.txtDescripcion.Text) & "'" & " And nStbBarrioID <> " & ObjBarriodr.nStbBarrioID
            Else
                objBarrioTmpDT.Filter = " nStbDistritoID = " & XdsBarrio("Distrito").ValueField("nStbDistritoID") & " And nStbMunicipioID = " & XdsBarrio("Municipio").ValueField("nStbMunicipioID") & " and Upper(sNombre) = '" & UCase(Me.txtDescripcion.Text) & "'"
            End If

            objBarrioTmpDT.Retrieve()

            If objBarrioTmpDT.Count > 0 Then
                MsgBox("El Nombre del Barrio NO DEBE repetirse. ", MsgBoxStyle.Critical, "SMUSURA0")
                ValidaDatosEntrada = False
                Me.errBarrio.SetError(Me.txtDescripcion, "El Nombre del Barrio NO DEBE repetirse.")
                Me.txtDescripcion.Focus()
                Exit Function
            End If

            If ModoFrm = "UPD" And chkActivo.Checked Then
                XdtTmpBusqueda = New BOSistema.Win.XDataSet.xDataTable
                StrSql = "SELECT     nSccMovimientoID, nStbBarrioOrigenID, nRevertido FROM         dbo.SccBarriosMovimientosMaestro WHERE     (nStbBarrioOrigenID =" & ObjBarriodr.nStbBarrioID & ") And  nRevertido=0"
                XdtTmpBusqueda.ExecuteSql(StrSql)


                If XdtTmpBusqueda.Table.Rows.Count > 0 Then
                    MsgBox("Ese barrio tiene un traslado vigente por lo cual no se puede poner en estado activo. ", MsgBoxStyle.Critical, "SMUSURA0")
                    ValidaDatosEntrada = False
                    Me.errBarrio.SetError(Me.chkActivo, "Ese barrio tiene un traslado vigente por lo cual no se puede poner en estado activo.")
                    Me.chkActivo.Focus()
                    Exit Function
                End If
            End If
        Catch ex As Exception
            Control_Error(ex)
            ValidaDatosEntrada = False
        Finally
            objBarrioTmpDT.Close()
            objBarrioTmpDT = Nothing
        End Try
    End Function
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2007
    ' Procedure Name:       SalvarBarrio
    ' Descripción:          Este procedimiento permite salvar los datos ingresados
    '                       o modificados del Barrio en la Base de Datos.
    '-------------------------------------------------------------------------
    Private Sub SalvarBarrio()
        Try
            If ModoFrm = "ADD" Then
                ObjBarriodr.sUsuarioCreacion = InfoSistema.LoginName
                ObjBarriodr.dFechaCreacion = FechaServer()
            Else
                ObjBarriodr.sUsuarioModificacion = InfoSistema.LoginName
                ObjBarriodr.dFechaModificacion = FechaServer()
            End If

            ObjBarriodr.sCodigo = Format(CInt(Me.txtCodigo.Text), "000")
            ObjBarriodr.sNombre = Me.txtDescripcion.Text
            ObjBarriodr.nStbDistritoID = XdsBarrio("Distrito").ValueField("nStbDistritoID")
            ObjBarriodr.nStbMunicipioID = XdsBarrio("Municipio").ValueField("nStbMunicipioID")

            If Me.chkActivo.Checked = True Then
                ObjBarriodr.nActivo = 1
            Else
                ObjBarriodr.nActivo = 0
            End If

            If Me.chkIncluidoPrograma.Checked = True Then
                ObjBarriodr.nPertenecePrograma = 1
            Else
                ObjBarriodr.nPertenecePrograma = 0
            End If

            ObjBarriodr.Update()

            'Asignar el Id del Barrio a la 
            'variable publica del formulario
            Me.intBarrioID = ObjBarriodr.nStbBarrioID
            '--------------------------------

            'Si el salvado se realizó de forma satisfactoria
            'enviar mensaje informando y cerrar el formulario.
            If ModoFrm = "ADD" Then
                MsgBox("Los datos se agregaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            Else
                MsgBox("Los datos se actualizaron satisfactoriamente.", MsgBoxStyle.Information, "SMUSURA0")
            End If

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       cmdCancelar_Click
    ' Descripción:          Este evento permite Confirmar que el Usuario desea
    '                       Salir del formulario sin salvar los cambios o bien
    '                       puede arrepentirse y salvar o quedarse en el formulario.
    '-------------------------------------------------------------------------
    Private Sub cmdCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Try
            'Declaracion de Variables 
            Dim res As Object

            If (vbModifico = True) Then
                res = MsgBox("Desea salvar los cambios antes de salir?", vbQuestion + vbYesNoCancel)
                Select Case res
                    Case vbYes
                        'DEBERIA IR EL CODIGO DEL BOTON ACEPTAR
                        If ValidaDatosEntrada() Then
                            SalvarBarrio()
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

    'Se indica que hubo modificación en la Dirección de la Socia
    Private Sub txtDireccion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        vbModifico = True
    End Sub

    'En caso que haya habido algún cambio
    Private Sub cboDepartamento_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Me.cboDepartamento.SelectedIndex <> -1 Then
            CargarMunicipio(0, 0)
        Else
            CargarMunicipio(1, 0)
        End If
        vbModifico = True
    End Sub
    'En caso que haya habido algún cambio
    Private Sub cboMunicipio_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
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
                'CargarBarrio(0, 0)
            End If
        Else
            CargarDistrito(1, 0)
        End If
        vbModifico = True
    End Sub
    Private Sub txtDescripcion_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDescripcion.KeyPress
        If TextoValido(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtDescripcion_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDescripcion.TextChanged
        vbModifico = True
    End Sub

    Private Sub txtCodigo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtCodigo.KeyPress
        If Numeros(e.KeyChar) = False Then
            e.Handled = True
            e.KeyChar = Microsoft.VisualBasic.ChrW(0)
        End If
    End Sub

    Private Sub txtCodigo_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCodigo.TextChanged
        vbModifico = True
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

    Private Sub cboDistrito_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboDistrito.TextChanged
        vbModifico = True
    End Sub

    Private Sub chkActivo_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkActivo.CheckedChanged
        vbModifico = True
    End Sub
    Private Sub chkActivo_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.GotFocus
        Try
            Me.chkActivo.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub chkActivo_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkActivo.LostFocus
        Try
            Me.chkActivo.BackColor = Me.grpDatosBarrio.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub
    Private Sub chkIncluidoPrograma_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.CheckedChanged
        vbModifico = True
    End Sub

    Private Sub chkIncluidoPrograma_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.GotFocus
        Try
            Me.chkIncluidoPrograma.BackColor = Color.White
        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

    Private Sub chkIncluidoPrograma_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkIncluidoPrograma.LostFocus
        Try
            Me.chkIncluidoPrograma.BackColor = Me.grpDatosBarrio.BackColor

        Catch ex As Exception
            Control_Error(ex)
        End Try
    End Sub

#Region "Combos"
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarDepartamento
    ' Descripción:          Este procedimiento permite cargar el listado de Departamentos
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarMunicipio
    ' Descripción:          Este procedimiento permite cargar el listado de Municipios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
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
    ' ------------------------------------------------------------------------
    ' Autor:                Ing. Azucena Suárez Tijerino
    ' Fecha:                21/08/2006
    ' Procedure Name:       CargarBarrio
    ' Descripción:          Este procedimiento permite cargar el listado de Barrios
    '                       en el combo para su selección.
    '-------------------------------------------------------------------------
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

End Class